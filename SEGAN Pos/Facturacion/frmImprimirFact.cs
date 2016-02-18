using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmImprimirFact : Form
  {

    #region Public Properties

    public EPK_Cliente Cliente { get; set; }
    public EPK_FacturaEncabezado Factura { get; set; }
    public EPK_Empleados Vendedor { get; set; }
    public List<ClienteCompra.ClienteComp> ListClienteCompras { get; set; }
    public EPK_VentasVolumen VentasVolumen { get; set; }

    public BindingList<ItemsFactura> itemsFactura { get; set; }
    public BindingList<ItemsPago> itemsPago { get; set; }

    public int cantPiezas { get; set; }
    public int cantDev { get; set; }
    public decimal totalFactura { get; set; }
    public decimal PorcDescuento { get; set; }

    #endregion

    #region Constructor

    public frmImprimirFact()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmImprimirFact_Shown(object sender, EventArgs e)
    {
      this.backgroundWorker1.RunWorkerAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      string[] strError = new string[] { string.Empty, string.Empty };

      try
      {
          decimal valorIVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

          Impresora impresora = new Impresora();

          int impLinea = impresora.EnLinea();
          if (impLinea != 0)
          {
              e.Result = 1;
              return;
          }

          if (string.IsNullOrEmpty(this.Factura.SerialMF))
          {
              if (!string.IsNullOrEmpty(impresora.Serial))
                  this.Factura.SerialMF = impresora.Serial;
              else
              {
                  impresora.Refrescar();
                  this.Factura.SerialMF = impresora.Serial;              
              }          
          }

          string rifCliente = Util.GenDocCliente(this.Cliente, true);
          string nombreCliente = Util.GenNomCliente(this.Cliente, true);
          string dirCliente = Util.TruncarCadena(this.Cliente.Direccion, 133);

          nombreCliente = Util.StripAccents(nombreCliente);
          rifCliente = Util.StripAccents(rifCliente);
          dirCliente = Util.StripAccents(dirCliente);

          if (!impresora.AbrirComprobanteEx(rifCliente, nombreCliente, dirCliente))
          {
              e.Result = 2;
              return;
          }

          string resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado))
          {
              e.Result = 2;
              return;
          }

          string nuevoTicketFiscal = impresora.NroComprobanteFiscal();
          string nuevoCOO = impresora.NroCupon();
          string numReduccion = impresora.NroRepZ();

          resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado))
          {
              impresora.AnularComprobante();
              e.Result = 3;
              return;
          }

          int numZ;
          int.TryParse(numReduccion, out numZ);
          numZ++;

          this.Factura.COO = nuevoCOO;
          this.Factura.TicketFiscal = nuevoTicketFiscal;
          this.Factura.NroReporteZ = numZ.ToString("0000");

          new Facturas().Actualizar(this.Factura.IdFactura, this.Factura);

          int totalItems = 0;

          foreach (ItemsFactura item in this.itemsFactura)
              if (item.Devolucion)
              {
                  if (!impresora.DevolverArticulo(item.CodigoArticulo, item.DescRef, valorIVA, item.Exento, item.Cantidad, item.PrecioBase, this.PorcDescuento, item.Descuento))
                  {
                      impresora.AnularComprobante();
                      e.Result = 4;
                      return;
                  }
                  totalItems++;
              }
              else
              {
                  if (!impresora.VenderArticulo(item.CodigoArticulo, item.DescRef, valorIVA, item.Exento, item.Cantidad, item.PrecioBase, this.PorcDescuento, item.Descuento))
                  {
                      impresora.AnularComprobante();
                      e.Result = 4;
                      return;
                  }
                  totalItems++;
              }

          if (totalItems <= 0 || this.itemsFactura.Count() != totalItems)
          {
              impresora.AnularComprobante();
              e.Result = 4;
              return;
          }

          decimal tempTotal = impresora.SubTotal();

          if (tempTotal < 0 || this.totalFactura != tempTotal)
          {
              impresora.AnularComprobante();
              e.Result = 5;
              return;
          }

          if (!impresora.IniciarCierreComprobante())
          {
              impresora.AnularComprobante();
              e.Result = 5;
              return;
          }

          foreach (ItemsPago item in this.itemsPago)
              if (item.Efectivo)
              {
                  if (!impresora.EfectuarPago(item.DescFormaPago, item.Monto))
                  {
                      impresora.AnularComprobante();
                      e.Result = 5;
                      return;
                  }
              }
              else
              {
                  if (!impresora.EfectuarPagoEx(item.DescFormaPago, item.Monto, item.DescPOS, item.NumeroPago))
                  {
                      impresora.AnularComprobante();
                      e.Result = 5;
                      return;
                  }
              }

          // Pie de la factura
          const int maxLinea = 48, maxPie = 384;

          string pieFactura = Util.TruncarCadena("FS# " + this.Factura.IdFactura.ToString() + " Cant Vta:" + this.cantPiezas.ToString() + " Cant Dev:" + this.cantDev.ToString(), maxLinea) + Environment.NewLine;

          if (this.Vendedor != null)
              pieFactura += Util.TruncarCadena("Vendedor:" + this.Vendedor.Nombre + " " + this.Vendedor.Apellido, maxLinea) + Environment.NewLine;

          pieFactura += Util.TruncarCadena("Cajero:" + EstadoAplicacion.UsuarioActual.Identificacion + " Caja:" + EstadoAplicacion.CajaActual.Descripcion, maxLinea) + Environment.NewLine;

          if (EstadoAplicacion.ListaPoliticas != null)
              foreach (EPK_Politica item in EstadoAplicacion.ListaPoliticas)
                  pieFactura += Util.CenterString(item.Descripcion.ToUpper(), maxLinea) + Environment.NewLine;

          pieFactura += Util.CenterString(EstadoAplicacion.TiendaActual.PiedeFactura.ToUpper(), maxLinea);

          pieFactura = Util.TruncarCadena(pieFactura, maxPie);

          pieFactura = Util.StripAccents(pieFactura);

          // Se cierra el comprobante
          if (!impresora.FinalizarCierreComprobante(pieFactura))
          {
              impresora.AnularComprobante();
              e.Result = 5;
              return;
          }

          int espera = EstadoAplicacion.EsperaDuplicado * 1000;
         

         // System.Threading.Thread.Sleep(espera);

          DateTime? fechaImp = impresora.FechaHoraUltimoDocumento();
          DateTime currDate = new DataAccess(true).FechaDB();

          if (fechaImp != null)
          {
              this.Factura.Fecha = fechaImp.Value.Date;
              this.Factura.Hora = fechaImp.Value.TimeOfDay;

              if (this.Factura.Fecha != currDate.Date)
              {
                  System.Threading.Thread.Sleep(espera);
                  fechaImp = impresora.FechaHoraImpresora();
                  if (fechaImp != null)
                  {
                      this.Factura.Fecha = fechaImp.Value.Date;
                      this.Factura.Hora = fechaImp.Value.TimeOfDay;
                  }
              }

              if (this.Factura.Fecha != currDate.Date)
              {
                  this.Factura.Fecha = currDate.Date;
                  this.Factura.Hora = currDate.TimeOfDay;
              }
          }

          // Si es cliente especial, se imprime una compia de la factura
          if (this.Cliente.Especial.HasValue && this.Cliente.Especial.Value)
          {
              if (espera > 0)
                  System.Threading.Thread.Sleep(espera);
              impresora.ImprimirCopiaFactura();
          }
              

          this.Factura.IdEstatus = EstadoAplicacion.EstadosFactura["FACProcesada"];
          new Facturas().Actualizar(this.Factura.IdFactura, this.Factura);

          if (new Facturas().Obtener(this.Factura.IdFactura).IdEstatus == EstadoAplicacion.EstadosFactura["FACProcesada"])
          {
              //Se Guarda las trasacciones para restriccciones de ventas al mayor
              if (EstadoAplicacion.RestriccionVentasMayor)
                  new ClienteCompra().SaveCompras(this.ListClienteCompras);

              //Si es una venta al mayor guarda el Log
              if(VentasVolumen != null)
              {
                  VentasVolumen.IdFactura = Factura.IdFactura;
                  new VentasVolumen().SaveLogVentas(VentasVolumen);
              }

          }

          if (EstadoAplicacion.PermitirContingencia)
              Util.SetAppSettingsValue("UltimoTicket", this.Factura.TicketFiscal);

          EstadoAplicacion.SetSerialImpresora(impresora.Serial);
      }
      catch (Exception ex)
      {
          new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." +
                                 System.Reflection.MethodBase.GetCurrentMethod().Name), ex);      
      }

      e.Result = 0;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      int result = -1;

      try {
        if (e.Error != null) {
          new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), e.Error);
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          this.Close();
          return;
        }

        if (e.Cancelled) {
          new NLogLogger().Error(Properties.Resources.MsgImpCancel);
          MessageBox.Show(Properties.Resources.MsgImpCancel, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          this.Close();
          return;
        }

        if (e.Result != null)
          result = (int)e.Result;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      switch (result) {
        case 0:
          this.DialogResult = System.Windows.Forms.DialogResult.OK;
          break;

        case 1:
          MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;

        case 2:
          MessageBox.Show(Properties.Resources.MsgErrorCrearComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;

        case 3:
          MessageBox.Show(Properties.Resources.MsgErrorInfoComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;

        case 4:
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;

        case 5:
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;

        default:
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
          break;
      }

      this.Close();
    }

    private void frmImprimirFact_Activated(object sender, EventArgs e)
    {
      this.Text = "Imprimiendo Factura - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

  }
}
