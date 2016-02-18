using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmVerFactura : Form
  {

    #region Public Properties

    public int? idFactura { get; set; }
    public int? idFacturaEspera { get; set; }

    #endregion

    #region Private Properties

    private decimal _porcDescuento { get; set; }
    private string _COO { get; set; }

    private EPK_FacturaEncabezado _factura { get; set; }
    private BindingList<ItemsFactura> _itemsFactura { get; set; }
    private BindingList<ItemsPago> _itemsPago { get; set; }

    #endregion

    #region Constructor

    public frmVerFactura()
    {
      InitializeComponent();

      this._COO = string.Empty;
      this._factura = null;
      this._itemsFactura = new BindingList<ItemsFactura>();
      this._itemsPago = new BindingList<ItemsPago>();
    }

    #endregion

    #region Events

    private void frmVerFactura_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (EstadoAplicacion.TieneImpresora)
        Util.VerificarImpresora("frmFacturar");

      this.CargarDatos();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgPagos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgPagos_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void btReImprimir_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;

      new Impresora().ReImprimirFactura(this._COO);

      this.Cursor = Cursors.Default;
    }

    private void btNCredito_Click(object sender, EventArgs e)
    {
      if (this._factura == null)
        return;

      if (MessageBox.Show(Properties.Resources.MsgConfirmNotaC, "Confirmación " + this.Text,
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return;

      List<ClienteCompra.ClienteComp> ListClienteCompraNC = new List<ClienteCompra.ClienteComp>(); //Se Crea colection de Clientes Compras

      try
      {
          this.Cursor = Cursors.WaitCursor;

          if (!Util.VerificarImpresora("frmFacturar"))
              return;

          decimal valorIVA = EstadoAplicacion.AplicaImpuesto ? Util.ObtenerParametroDecimal("IVA", this._factura.FechaCreacion) : 0;

          string rifCliente = Util.GenDocCliente(this._factura.EPK_Cliente, true);
          string nombreCliente = Util.GenNomCliente(this._factura.EPK_Cliente, true);

          EPK_NotaCreditoEncabezado nuevaNC = new EPK_NotaCreditoEncabezado
          {
              IdFactura = this._factura.IdFactura,
              PorcDescuento = this._factura.PorcDescuento,
              MontoBase = this._factura.MontoBase,
              MontoDescuento = this._factura.MontoDescuento,
              MontoIVA = this._factura.MontoIVA,
              MontoTotal = this._factura.MontoTotal ?? 0,
              SerialMF = this._factura.SerialMF,
              NombreCliente = nombreCliente
          };

          nuevaNC.EPK_NotaCreditoDetalle = this._factura.EPK_FacturaDetalle.Select(fd => new EPK_NotaCreditoDetalle
          {
              IdArticulo = fd.IdArticulo,
              Cantidad = fd.Cantidad,
              Precio = fd.Precio,
              Descuento = fd.Descuento,
              MontoDescuento = fd.MontoDescuento,
              Exento = fd.Exento,
              MontoImpuesto = fd.MontoImpuesto,
              PrecioNeto = fd.PrecioNeto,
              Cambio = fd.Cambio
          }).ToList();

          int idNC = new NotasCredito().Nueva(nuevaNC);

          if (idNC <= 0)
          {
              MessageBox.Show(Properties.Resources.MsgErrorGenNC, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }
          else
          {
              //Restrcciones de Ventas al mayor
              if (EstadoAplicacion.RestriccionVentasMayor)
              {
                  EPK_FacturaEncabezado FanctEncNC = new Facturas().Obtener(nuevaNC.IdFactura);

                  foreach (EPK_NotaCreditoDetalle ItemNC in nuevaNC.EPK_NotaCreditoDetalle)
                  {
                      if (new Articulos().AplicaRestriccion(ItemNC.IdArticulo))
                          ListClienteCompraNC.Add(new ClienteCompra.ClienteComp
                          {
                              IdArticulo = ItemNC.IdArticulo,
                              Cantidad = (ItemNC.Cambio ? ItemNC.Cantidad : -1 * ItemNC.Cantidad),
                              NumeroDocumento = FanctEncNC.EPK_Cliente.NumeroDocumento,
                              IdTipoDocumento = FanctEncNC.EPK_Cliente.IdTipoDocumento,
                              Devolucion = true // Se le asigna True porque para Nota de Credito se consideran las piexas como devoluciones
                          });
                  }
              }
          }

          DateTime fechaFactura = this._factura.Fecha + this._factura.Hora;

          Impresora impresora = new Impresora();

          if (!impresora.AbrirNotaCredito(nombreCliente, this._factura.SerialMF, rifCliente, fechaFactura, this._factura.COO))
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorCrearComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          string resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado))
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorCrearComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          string nuevoTicketFiscal = impresora.NroComprobanteFiscal();
          string nuevoCOO = impresora.NroCupon();
          string numReduccion = impresora.NroRepZ();

          resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado))
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorInfoComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          int numZ;
          int.TryParse(numReduccion, out numZ);
          numZ++;

          nuevaNC = new NotasCredito().Obtener(idNC);

          nuevaNC.COO = nuevoCOO;
          nuevaNC.TicketFiscal = nuevoTicketFiscal;
          nuevaNC.NroReporteZ = numZ.ToString("0000");

          int totalItems = 0;

          foreach (EPK_FacturaDetalle item in this._factura.EPK_FacturaDetalle)
              if (item.Cambio)
              {
                  if (!impresora.DevolverArticulo(item.EPK_Articulo.CodigoArticulo, item.EPK_Articulo.EPK_Referencia.Descripcion,
                                                  valorIVA, item.Exento, item.Cantidad, item.Precio, this._factura.PorcDescuento, item.Descuento))
                  {
                      impresora.AnularComprobante();
                      new NotasCredito().Anular(idNC);
                      MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }
                  totalItems++;
              }
              else
              {
                  if (!impresora.VenderArticulo(item.EPK_Articulo.CodigoArticulo, item.EPK_Articulo.EPK_Referencia.Descripcion,
                                                valorIVA, item.Exento, item.Cantidad, item.Precio, this._factura.PorcDescuento, item.Descuento))
                  {
                      impresora.AnularComprobante();
                      new NotasCredito().Anular(idNC);
                      MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                      return;
                  }
                  totalItems++;
              }

          if (totalItems <= 0 || this._factura.EPK_FacturaDetalle.Count() != totalItems)
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          decimal tempTotal = impresora.SubTotal();

          if (!impresora.IniciarCierreComprobante())
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          DateTime? fechaImp = impresora.FechaHoraImpresora();

          if (fechaImp == null)
          {
              DateTime currDate = new DataAccess(true).FechaDB();
              nuevaNC.Fecha = currDate.Date;
              nuevaNC.Hora = currDate.TimeOfDay;
          }
          else
          {
              nuevaNC.Fecha = fechaImp.Value.Date;
              nuevaNC.Hora = fechaImp.Value.TimeOfDay;
          }

          // Pie de la nota de credito
          const int maxLinea = 48, maxPie = 384;

          string pieFactura = Util.TruncarCadena("FS # " + this._factura.IdFactura.ToString(), maxLinea) + Environment.NewLine;
          pieFactura += Util.TruncarCadena("NC # " + idNC.ToString(), maxLinea) + Environment.NewLine;
          pieFactura += Util.TruncarCadena("Cajero:" + EstadoAplicacion.UsuarioActual.Identificacion + " Caja:" + EstadoAplicacion.CajaActual.Descripcion, maxLinea) + Environment.NewLine;
          pieFactura = Util.TruncarCadena(pieFactura, maxPie);
          pieFactura = Util.StripAccents(pieFactura);

          // Se cierra el comprobante
          if (!impresora.FinalizarCierreComprobante(pieFactura))
          {
              impresora.AnularComprobante();
              new NotasCredito().Anular(idNC);
              MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          nuevaNC.IdEstatus = EstadoAplicacion.EstadosNC["NCEmitida"];
          new NotasCredito().Actualizar(nuevaNC);

          if (ListClienteCompraNC.Count > 0)
              new ClienteCompra().SaveCompras(ListClienteCompraNC); //Se guarda Clientes Compras

          MessageBox.Show(string.Format("Nota de Crédito #{0} generada con éxito", idNC), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex)
      {
          new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally
      {
          this.btNCredito.Enabled = (new Facturas().TieneNC(this.idFactura.Value) == TipoNC.No);
          this.Cursor = Cursors.Default;
          this.DialogResult = System.Windows.Forms.DialogResult.OK;
      }
    }

    private void frmVerFactura_Activated(object sender, EventArgs e)
    {
      this.Text = "Ver Factura - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      int idEstatus = 0;
      string rifCliente = string.Empty, nombreCliente = string.Empty, serialMF = string.Empty;

      if (this.idFactura.HasValue) {
        this._factura = new Facturas().Obtener(this.idFactura.Value);

        if (this._factura == null)
          return;

        idEstatus = this._factura.IdEstatus;

        rifCliente = Util.GenDocCliente(this._factura.EPK_Cliente);
        nombreCliente = Util.GenNomCliente(this._factura.EPK_Cliente);

        this.lbNombre.Text = nombreCliente;
        this.lbDoc.Text = rifCliente;
        this.lbDireccion.Text = this._factura.EPK_Cliente.Direccion;
        this.lbEmail.Text = this._factura.EPK_Cliente.Email;

        if (this._factura.EPK_Cliente.EPK_ClienteTelefono != null &&
          this._factura.EPK_Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0)
          this.lbTelefono.Text = this._factura.EPK_Cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero;

        decimal totExento = this._factura.EPK_FacturaDetalle.Where(fd => !fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto) -
          this._factura.EPK_FacturaDetalle.Where(fd => fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto);

        // Datos de la Factura
        this.lbNroFactura.Text = this._factura.IdFactura.ToString();
        this.lbSubtotal.Text = string.Format("{0:c}", this._factura.MontoBase + totExento);
        this.lbTotIVA.Text = string.Format("{0:c}", this._factura.MontoIVA);
        this.lbTotal.Text = string.Format("{0:c}", this._factura.MontoTotal);
        this.lbEstatusFact.Text = this._factura.EPK_Estatus.Descripcion;
        this.lbFechaFact.Text = this._factura.FechaCreacion.ToString();
        this.lbNombreCaja.Text = this._factura.EPK_Caja.Descripcion;
        this.lbNombreCajero.Text = this._factura.EPK_Usuario.Identificacion.Trim();

        if (this._factura.IdVendedor.HasValue) {
          this.lbVend.Text = this._factura.EPK_Empleados.Nombre + " " + this._factura.EPK_Empleados.Apellido;
          this.lbVendedor.Visible = true;
        }

        this._COO = this._factura.COO;
        serialMF = this._factura.SerialMF;

        this.lbNroCOO.Text = this._COO;
        this.lbImpresora.Text = serialMF;
        this.lbZ.Text = this._factura.NroReporteZ;
        this.lbTicketFiscal.Text = this._factura.TicketFiscal;

        // Articulos de la factura
        foreach (EPK_FacturaDetalle itemDetalle in this._factura.EPK_FacturaDetalle) {
          this._itemsFactura.Add(new ItemsFactura {
            IdArticulo = itemDetalle.IdArticulo,
            CodigoArticulo = itemDetalle.EPK_Articulo.CodigoArticulo.Trim(),
            Descripcion = itemDetalle.EPK_Articulo.Descripcion.Trim(),
            IdReferencia = itemDetalle.EPK_Articulo.IdReferencia,
            DescRef = itemDetalle.EPK_Articulo.EPK_Referencia.Descripcion.Trim(),
            Cantidad = itemDetalle.Cantidad,

            PrecioBase = itemDetalle.Precio,
            PrecioNeto = itemDetalle.PrecioNeto,
            MontoDescuento = itemDetalle.MontoDescuento,
            PrecioVenta = Util.TruncarDecimal(itemDetalle.PrecioNeto * itemDetalle.Cantidad, 2),

            Descuento = itemDetalle.Descuento,
            Exento = itemDetalle.Exento,

            Devolucion = itemDetalle.Cambio,
            IdMotivo = itemDetalle.IdMotivoDevolucion
          });
        }

        this.dgItems.DataSource = this._itemsFactura;
        this.dgItems.Refresh();

        // Pagos de la factura
        foreach (EPK_FacturaPago itemPago in this._factura.EPK_FacturaPago) {
          string descFormaPago = itemPago.EPK_FormaPago.Descripcion;

          string descEntidad = string.Empty;
          if (itemPago.IdEntidad.HasValue)
            descEntidad = itemPago.EPK_EntidadFinanciera.Nombre;

          string descEntidadPOS = string.Empty, descPOS = string.Empty;
          if (itemPago.IdPOS.HasValue) {
            descEntidadPOS = itemPago.EPK_POS.EPK_EntidadFinanciera.Nombre;
            descPOS = itemPago.EPK_POS.Descripcion;
          }

          this._itemsPago.Add(new ItemsPago {
            idFormaPago = itemPago.IdFormaPago,
            idEntidad = itemPago.IdEntidad,
            idPOS = itemPago.IdPOS,
            NumeroPago = itemPago.NumeroPago,
            Monto = itemPago.Monto,
            DescFormaPago = descFormaPago,
            DescEntidad = descEntidad,
            DescEntidadPOS = descEntidadPOS,
            DescPOS = descPOS
          });
        }

        this.dgPagos.DataSource = this._itemsPago;
        this.dgPagos.Refresh();
      }
      else if (this.idFacturaEspera.HasValue) {
        EPK_FacturaEsperaEncabezado facturaEspera = new FacturasEspera().Obtener(this.idFacturaEspera.Value);

        if (facturaEspera == null)
          return;

        idEstatus = facturaEspera.IdEstatus;

        rifCliente = Util.GenDocCliente(facturaEspera.EPK_Cliente);
        nombreCliente = Util.GenNomCliente(facturaEspera.EPK_Cliente);

        this.lbNombre.Text = nombreCliente;
        this.lbDoc.Text = rifCliente;
        this.lbDireccion.Text = facturaEspera.EPK_Cliente.Direccion;
        this.lbEmail.Text = facturaEspera.EPK_Cliente.Email;

        if (facturaEspera.EPK_Cliente.EPK_ClienteTelefono != null &&
          facturaEspera.EPK_Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0)
          this.lbTelefono.Text = facturaEspera.EPK_Cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero;

        decimal totExento = facturaEspera.EPK_FacturaEsperaDetalle.Where(fd => !fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto) -
            facturaEspera.EPK_FacturaEsperaDetalle.Where(fd => fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto);

        // Datos de la Factura
        this.lbNroFactura.Text = facturaEspera.IdFactura.ToString();
        this.lbSubtotal.Text = string.Format("{0:c}", facturaEspera.MontoBase + totExento);
        this.lbTotIVA.Text = string.Format("{0:c}", facturaEspera.MontoIVA);
        this.lbTotal.Text = string.Format("{0:c}", facturaEspera.MontoTotal);
        this.lbEstatusFact.Text = facturaEspera.EPK_Estatus.Descripcion;
        this.lbFechaFact.Text = facturaEspera.FechaCreacion.ToString();

        // Articulos de la factura
        foreach (EPK_FacturaEsperaDetalle itemDetalle in facturaEspera.EPK_FacturaEsperaDetalle) {
          this._itemsFactura.Add(new ItemsFactura {
            IdArticulo = itemDetalle.IdArticulo,
            CodigoArticulo = itemDetalle.EPK_Articulo.CodigoArticulo.Trim(),
            Descripcion = itemDetalle.EPK_Articulo.Descripcion.Trim(),
            IdReferencia = itemDetalle.EPK_Articulo.IdReferencia,
            DescRef = itemDetalle.EPK_Articulo.EPK_Referencia.Descripcion.Trim(),
            Cantidad = itemDetalle.Cantidad,

            PrecioBase = itemDetalle.Precio,
            PrecioNeto = itemDetalle.PrecioNeto,
            MontoDescuento = itemDetalle.MontoDescuento,
            PrecioVenta = Util.TruncarDecimal(itemDetalle.PrecioNeto * itemDetalle.Cantidad, 2),

            Descuento = itemDetalle.Descuento,
            Exento = itemDetalle.Exento,

            Devolucion = itemDetalle.Cambio,
            IdMotivo = null
          });
        }

        this.dgItems.DataSource = this._itemsFactura;
        this.dgItems.Refresh();

        this.gbPagos.Visible = false;
        this.gbItems.Height += this.gbPagos.Height + this.pnDatosImp.Height;
        this.gbItems.Top -= this.pnDatosImp.Height;

        this.pnDatosImp.Visible = false;
      }

      if ((idEstatus == EstadoAplicacion.EstadosFactura["FACProcesada"] || idEstatus == EstadoAplicacion.EstadosFactura["FACAnulada"]) &&
          !string.IsNullOrEmpty(this._COO)) {

        Impresora impresora = new Impresora();

        if (!string.IsNullOrEmpty(serialMF) && serialMF == impresora.Serial) {
          if (new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btReImprimir.Tag.ToString()))
            this.btReImprimir.Enabled = true;

          if (new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btNCredito.Tag.ToString()) 
              && idEstatus == EstadoAplicacion.EstadosFactura["FACProcesada"] 
              && this._factura.MontoTotal > 0)
          {
              this.btNCredito.Enabled = (new Facturas().TieneNC(this.idFactura.Value) == TipoNC.No) && 
                                        (!new Facturas().TieneSolicitudNC((int)this.idFactura, (int)EstadoAplicacion.TiendaActual.IdTienda));

          }

        }
      }

    }

    #endregion

  }
}
