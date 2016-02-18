using DisplayManager.Providers;
using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using UserInactivityMonitoring;

namespace SEGAN_POS
{
  public partial class frmFacturar : Form
  {
    #region Private Properties

    private EPK_Articulo _articulo { get; set; }

    private EPK_Usuario _autorizador { get; set; }

    private decimal _cambio { get; set; }

    private EPK_Cliente _cliente { get; set; }

    private List<int> _controlFactEspera { get; set; }

    private EPK_Descuento _descuento { get; set; }

    private List<EPK_FacturaEsperaEncabezado> _facturasEspera { get; set; }

    private BindingList<ItemsFactura> _itemsFactura { get; set; }

    private BindingList<ItemsPago> _itemsPago { get; set; }

    private decimal _IVAFactura { get; set; }

    private decimal _montoBase { get; set; }

    private decimal _porcDescuento { get; set; }

    private decimal _saldo { get; set; }

    private decimal _totalFactura { get; set; }

    private decimal _totDescuento { get; set; }

    private EPK_Empleados _vendedor { get; set; }

    private List<EPK_ClienteCompra> _clienteCompras { get; set; }

    private bool SkipRule { get; set; }

    private EPK_VentasVolumen LogVentas { get; set; }

    private int itemfacturaEsp { get; set; }

    private bool ValidarPreg { get; set; }
    #endregion Private Properties

    #region Private Variables

    private IInactivityMonitor inactivityMonitor = null;
    private bool FormCloseAut = false;


    #endregion Private Variables

    #region Constructor

    public frmFacturar(int itemfactura)
    {
      InitializeComponent();
      itemfacturaEsp = itemfactura;
      
      //else
      //    CargarFactura(this._facturasEspera.FirstOrDefault());

      this._montoBase = this._totalFactura = this._IVAFactura = this._cambio =
        this._porcDescuento = this._saldo = this._totDescuento = 0;

      this._vendedor = null;
      this._cliente = null;
      this._articulo = null;
      this._autorizador = null;

      this._itemsFactura = new BindingList<ItemsFactura>();
      this._itemsPago = new BindingList<ItemsPago>();

      this._controlFactEspera = new List<int>();

      int timeOut = Util.ObtenerParametroEntero("TIMEOUTSESION");
      if (timeOut == 0)
        timeOut = 300;

      inactivityMonitor = MonitorCreator.CreateInstance(MonitorType.LastInputMonitor);
      inactivityMonitor.SynchronizingObject = this;
      inactivityMonitor.MonitorKeyboardEvents = true;
      inactivityMonitor.MonitorMouseEvents = true;
      inactivityMonitor.Interval = timeOut * 1000;
      inactivityMonitor.Elapsed += new ElapsedEventHandler(TimeoutSesion);
    }

    #endregion Constructor

    #region Events

    private void btAgregarFPago_Click(object sender, EventArgs e)
    {
      if (this._itemsFactura == null)
        return;

      if (this._itemsFactura.Count() == 0)
        return;

      if (this._descuento != null)
        if (this._descuento.MontoLimite.HasValue)
          if (this._totalFactura > this._descuento.MontoLimite.Value) {
            if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btDescuento.Tag.ToString())) {
              frmAutorizar fAut = new frmAutorizar();
              fAut.Mensaje = string.Format(Properties.Resources.MsgAutoLimiteDescuento, this._descuento.MontoLimite.Value.ToString("c"));
              fAut.NombreTecnico = this.Name;
              fAut.Accion = this.btDescuento.Tag.ToString();
              fAut.ShowDialog();

              if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado) {
                ((Button)sender).Enabled = true;
                return;
              }

              this._autorizador = fAut.UsuarioAutorizador;
            }
          }

      if (EstadoAplicacion.TieneVisor) {
        try {
          BematechDisplay visorManager = new BematechDisplay();

          using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
            visorManager.ClearDisplay(serialPort);
            visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, "Total de la factura:", DisplayManagerEnum.Alineacion.Izquierda);
            visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, this._totalFactura.ToString("c"), DisplayManagerEnum.Alineacion.Derecha);
          }
        }
        catch (Exception ex) {
          MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

          new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        }
      }

      List<ItemsFactura> itemsDevol = this._itemsFactura.Where(it => it.Devolucion && !it.IdMotivo.HasValue).ToList();

      if (itemsDevol.Count() > 0) {
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Devolucion_Item")) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarDevolucion;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = "Devolucion_Item";
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
            return;

          this._autorizador = fAut.UsuarioAutorizador;
        }

        BindingList<ItemsFactura> bItemsDevol = new BindingList<ItemsFactura>();
        foreach (ItemsFactura item in itemsDevol)
          bItemsDevol.Add(item);

        frmDevolucion fDev = new frmDevolucion();
        fDev.ItemsDevolucion = bItemsDevol;

        fDev.ShowDialog();

        if (fDev.DialogResult != System.Windows.Forms.DialogResult.OK)
          return;
      }

      frmFormasPago fFPago = new frmFormasPago();
      fFPago.idCliente = this._cliente.IdCliente;
      fFPago.MontoAPagar = this._totalFactura;
      fFPago.ItemsPago = this._itemsPago;
      fFPago.ShowDialog();

      if (fFPago.DialogResult == System.Windows.Forms.DialogResult.OK)
          this._itemsPago = fFPago.ItemsPago;
      else
          return;

      this.dgPagos.DataSource = this._itemsPago;
      this.dgPagos.Refresh();

      this.CalcularTotales();

      if (this._saldo == 0 && this._vendedor != null && EstadoAplicacion.TemporadaComision)
          this.btProcesar.Focus();
    }

    private void btBuscarArt_Click(object sender, EventArgs e)
    {
      
      frmBuscarArt fBuscarArt = new frmBuscarArt();

      fBuscarArt.NoAgregar = (this._cliente == null);

      if (fBuscarArt.ShowDialog() != System.Windows.Forms.DialogResult.OK)
        return;

      if (!fBuscarArt.ArticuloSel.Activo) {
        MessageBox.Show(Properties.Resources.MsgArticuloInactivo, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;

        bool ValidarObsequio = new Facturas().TieneObsequio(fBuscarArt.ArticuloSel.CodigoArticulo);
        if (!ValidarObsequio)
        {
            MessageBox.Show(string.Format(Properties.Resources.MsgArticuloNoFacturable, fBuscarArt.ArticuloSel.CodigoArticulo),
                            "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

          
            return;
        }
      }

      this.AgregarArticulo(fBuscarArt.ArticuloSel);
    }

    private void btBuscarCliente_MouseClick(object sender, MouseEventArgs e)
    {
      this.BuscarCliente();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      int? idAut = null;

      if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, ((Button)sender).Tag.ToString())) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutorizarCancel;
        fAut.NombreTecnico = this.Name;
        fAut.Accion = ((Button)sender).Tag.ToString();
        fAut.ShowDialog();

        if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
          return;

        if (fAut.UsuarioAutorizador != null)
          idAut = fAut.UsuarioAutorizador.IdUsuario;
      }

      this.DejarEnEspera(EstadoAplicacion.EstadosFactura["FACCancelada"], idAut);

      // Log Auditoria
      new NLogLogger().Info(string.Format("Factura cancelada por: {0} , Acción: {1} , Nombre Técnico: {2} ", EstadoAplicacion.UsuarioActual.Login, ((Button)sender).Tag.ToString(), this.Name));

      this.LimpiarTodo();
      Util.IniciarVisor();
    }

    private void btDescuento_Click(object sender, EventArgs e)
    {
      frmAutorizarDesc fAutDesc = new frmAutorizarDesc();
      fAutDesc.Descuento = this._porcDescuento;
      fAutDesc.NombreTecnico = this.Name;
      fAutDesc.Accion = ((Button)sender).Tag.ToString();
      fAutDesc.ShowDialog();

      if (fAutDesc.DialogResult != System.Windows.Forms.DialogResult.OK || !fAutDesc.Autorizado)
        return;

      this._autorizador = fAutDesc.UsuarioAutorizador;

      this._porcDescuento = fAutDesc.Descuento;
      this.txDescuento.Text = string.Format("{0:N2}", this._porcDescuento);

      this.RefrescarArticulosFactura();
      this.dgItems.Refresh();
      this.CalcularTotales();

      this.txCodArt.Focus();
    }

    private void btElimFPago_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in this.dgPagos.SelectedRows)
        this._itemsPago.RemoveAt(row.Index);

      this.dgPagos.Refresh();

      this.CalcularTotales();
    }

    private void btEliminarItem_Click(object sender, EventArgs e)
    {
      this.EliminarArticulos();
    }

    private void btProcesar_Click(object sender, EventArgs e)
    {
      int? idAut = null;

      if (this._itemsFactura == null)
        return;

      if (this._itemsFactura.Count() == 0)
        return;

      if (EstadoAplicacion.RestriccionVentasMayor && !this.SkipRule)
      {
          int ArtRestringidos = this._itemsFactura.Where(p => p.AplicaRestriccion && !p.Devolucion).Sum(p => p.Cantidad);
          int TotalCompras = this._clienteCompras.Sum(p => p.Cantidad);
          int TotalDev = this._itemsFactura.Where(p => p.AplicaRestriccion && p.Devolucion).Sum(p => p.Cantidad);
          int HolguraDevolucion = Util.ObtenerParametroEntero("HolguraDevolucion");
          int MaxPiezas = Util.ObtenerParametroEntero("MaximoPiezas");

          if ((ArtRestringidos>0) && (ArtRestringidos + TotalCompras - TotalDev > MaxPiezas + HolguraDevolucion))
          {
              bool Loop = true;
              while (Loop)
              {
                  if (MessageBox.Show(string.Format(Properties.Resources.MsgMaxArtCancel, MaxPiezas), "Advertencia - " + this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                  {
                      Loop = false;
                  }
              }

              this.DejarEnEspera(EstadoAplicacion.EstadosFactura["FACCancelada"], Util.ObtenerParametroEntero("IDAUDITORÍA"));

              // Log Auditoria
              new NLogLogger().Info(string.Format("Factura cancelada por: {0} , Acción: {1} , Nombre Técnico: {2} ", EstadoAplicacion.UsuarioActual.Login, ((Button)sender).Tag.ToString(), this.Name));

              this.LimpiarTodo();
              Util.IniciarVisor();
              return;
          }
      }

      ((Button)sender).Enabled = false;

      if (this._porcDescuento > 0 && this._itemsFactura.Where(itf => itf.Descuento).Count() > 0)
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btDescuento.Tag.ToString())) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarDescuento;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = this.btDescuento.Tag.ToString();
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado) {
            ((Button)sender).Enabled = true;
            ((Button)sender).Focus();
            return;
          }

          this._autorizador = fAut.UsuarioAutorizador;
        }

      List<ItemsFactura> itemsDevol = this._itemsFactura.Where(it => it.Devolucion && !it.IdMotivo.HasValue).ToList();

      if (itemsDevol.Count() > 0) {
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Devolucion_Item")) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarDevolucion;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = "Devolucion_Item";
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado) {
            ((Button)sender).Enabled = true;
            ((Button)sender).Focus();
            return;
          }

          this._autorizador = fAut.UsuarioAutorizador;
        }

        BindingList<ItemsFactura> bItemsDevol = new BindingList<ItemsFactura>();
        foreach (ItemsFactura item in itemsDevol)
          bItemsDevol.Add(item);

        frmDevolucion fDev = new frmDevolucion();
        fDev.ItemsDevolucion = bItemsDevol;
        fDev.ShowDialog();

        if (fDev.DialogResult != System.Windows.Forms.DialogResult.OK) {
          ((Button)sender).Enabled = true;
          ((Button)sender).Focus();
          return;
        }
      }

      try {
        if (EstadoAplicacion.TieneVisor) {
          try {
            BematechDisplay visorManager = new BematechDisplay();

            using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
              visorManager.ClearDisplay(serialPort);
              visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, "Imprimiendo factura", DisplayManagerEnum.Alineacion.Centrado);
              visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, "Espere por favor...", DisplayManagerEnum.Alineacion.Centrado);
            }

          }
          catch (Exception ex) {
            MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }
        }

        if (!Util.VerificarImpresora(this.Name))
          return;

        Impresora impresora = new Impresora();

        if (string.IsNullOrEmpty(impresora.Serial))
            impresora.Refrescar();

        /* if (impresora.GavetaAbierta())
             new frmGavetaAbierta().ShowDialog(); */

        impresora.AbrirGaveta();

        int? idVendedor = null;
        if (this._vendedor != null)
          idVendedor = (int)this._vendedor.IdEmpleado;

        idAut = null;
        if (this._autorizador != null)
          idAut = this._autorizador.IdUsuario;

        EPK_FacturaEncabezado nuevaFactura = new EPK_FacturaEncabezado {
          IdCaja = EstadoAplicacion.CajaActual.IdCaja,
          SerialMF = impresora.Serial,
          PorcDescuento = this._porcDescuento,
          IdCliente = this._cliente.IdCliente,
          MontoTotal = this._totalFactura,
          MontoIVA = this._IVAFactura,
          IdVendedor = idVendedor,
          IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario,
          IdUsuarioModificacion = idAut,
          MontoBase = this._montoBase,
          MontoDescuento = this._totDescuento
        };

        List<ClienteCompra.ClienteComp> ListaClienteCompras = new List<ClienteCompra.ClienteComp>();

        foreach (ItemsFactura item in this._itemsFactura)
        {
            byte? idMotDev = null;
            if (item.Devolucion)
                idMotDev = item.IdMotivo;

            nuevaFactura.EPK_FacturaDetalle.Add(new EPK_FacturaDetalle
            {
                IdArticulo = item.IdArticulo,
                Cantidad = item.Cantidad,
                Precio = item.PrecioBase,
                Descuento = item.Descuento,
                Exento = item.Exento,
                Cambio = item.Devolucion,
                MontoImpuesto = item.MontoIVA,
                MontoDescuento = item.MontoDescuento,
                PrecioNeto = item.PrecioNeto,
                IdMotivoDevolucion = idMotDev
            });

            if(item.AplicaRestriccion && EstadoAplicacion.RestriccionVentasMayor)
            ListaClienteCompras.Add(new ClienteCompra.ClienteComp
            {
                IdArticulo = item.IdArticulo,
                Cantidad = (item.Devolucion ? -1 * item.Cantidad : item.Cantidad),
                NumeroDocumento = this._cliente.NumeroDocumento,
                IdTipoDocumento = this._cliente.IdTipoDocumento,
                Devolucion = item.Devolucion
            });
        }

        int cantPiezas = 0;
        try {
          cantPiezas = this._itemsFactura.Where(i => !i.Devolucion).Sum(i => i.Cantidad);
        }
        catch { }

        int cantDev = 0;
        try {
          cantDev = this._itemsFactura.Where(i => i.Devolucion).Sum(i => i.Cantidad);
        }
        catch { }

        foreach (ItemsPago item in this._itemsPago) {
          int? tempPOS = null, tempEntidad = null;

          if (item.idPOS > 0)
            tempPOS = item.idPOS.Value;

          if (item.idEntidad > 0)
            tempEntidad = item.idEntidad.Value;

          nuevaFactura.EPK_FacturaPago.Add(new EPK_FacturaPago {
            IdFormaPago = item.idFormaPago,
            IdEntidad = tempEntidad,
            IdPOS = tempPOS,
            NumeroPago = item.NumeroPago,
            Monto = item.Monto,
            MontoVuelto = item.Efectivo ? this._cambio : 0,
          });
        }

        if (string.IsNullOrEmpty(nuevaFactura.SerialMF))
        {
            impresora.Refrescar();
            nuevaFactura.SerialMF = impresora.Serial;        
        }

        int idNuevaFactura = new Facturas().Nueva(nuevaFactura);

        if (idNuevaFactura <= 0) {
          new NLogLogger().Error("Error al generar la factura.");
          MessageBox.Show("Error al generar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          ((Button)sender).Enabled = true;
          ((Button)sender).Focus();
          return;
        }

        frmImprimirFact fImpFact = new frmImprimirFact();

        fImpFact.Cliente = this._cliente;
        fImpFact.Factura = nuevaFactura;
        fImpFact.Vendedor = this._vendedor;
        fImpFact.itemsFactura = this._itemsFactura;
        fImpFact.itemsPago = this._itemsPago;
        fImpFact.cantPiezas = cantPiezas;
        fImpFact.cantDev = cantDev;
        fImpFact.totalFactura = this._totalFactura;
        fImpFact.PorcDescuento = this._porcDescuento;
        fImpFact.ListClienteCompras = ListaClienteCompras;
        fImpFact.VentasVolumen = this.LogVentas;
        fImpFact.ShowDialog();

        idAut = null;
        if (this._autorizador != null)
          idAut = this._autorizador.IdUsuario;

        if (fImpFact.DialogResult != System.Windows.Forms.DialogResult.OK) {
          new Facturas().Anular(nuevaFactura.IdFactura, idAut);

          this._itemsPago.Clear();
          this.CalcularTotales();
          Util.IniciarVisor();
          return;
        }

        if (EstadoAplicacion.TieneVisor) {
          try {
            BematechDisplay visorManager = new BematechDisplay();

            using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
              visorManager.ClearDisplay(serialPort);
              visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, "GRACIAS", DisplayManagerEnum.Alineacion.Centrado);
              visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, "POR SU COMPRA", DisplayManagerEnum.Alineacion.Centrado);
            }
          }
          catch (Exception ex) {
            MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }
        }

        this.LimpiarTodo();
        Util.IniciarVisor();

        if (impresora.GavetaAbierta()) {
          frmGavetaAbierta fGaveta = new frmGavetaAbierta();
          fGaveta.ShowDialog();
        }

        while (this.ManejoNotasCredito()) ;

        this.ManejoFacturasEspera();

        if (new AlivioEfectivo().NecesitaAlivioEfectivo(EstadoAplicacion.UsuarioActual.IdUsuario)) {

            NotificationManager.Show(this, Properties.Resources.MsgAlivio, Color.Red, EstadoAplicacion.ToastTimeout);

            //if (MessageBox.Show(Properties.Resources.MsgAlivio, "Alivio de Efectivo - " + this.Text,
            //  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Aliviar_Efectivo"))
            //    {
            //        frmAutorizar fAut = new frmAutorizar();
            //        fAut.Mensaje = Properties.Resources.MsgAutorizarAlivio;
            //        fAut.NombreTecnico = this.Name;
            //        fAut.Accion = "Aliviar_Efectivo";
            //        fAut.ShowDialog();

            //        if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
            //        {
            //            if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //                NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,EstadoAplicacion.ToastTimeout);
            //        }
            //    }
            //    else
            //    {
            //        if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //            NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,EstadoAplicacion.ToastTimeout);
            //    }
            //}
        }

        // Log Auditoria
        new NLogLogger().Info(string.Format("Factura #{0}, Procesada por: {1} , Nombre Técnico: {2} ", idNuevaFactura, EstadoAplicacion.UsuarioActual.Login, this.Name));
      }
      catch (Exception ex) {
        new Impresora().AnularComprobante();
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        // Log Auditoria
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void btSelVendedor_Click(object sender, EventArgs e)
    {
        this.SeleccionarVendedor(((Button)sender).Tag.ToString());
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex != 9)
        e.Cancel = true;
    }

    private void dgItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex == 9) // Devolución
        return;

      if (e.ColumnIndex == 3)
      { // Cantidad
          if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Modificar_Cantidad"))
          {
              frmAutorizar fAut = new frmAutorizar();
              fAut.Mensaje = Properties.Resources.MsgAutorizarCambioCant;
              fAut.NombreTecnico = this.Name;
              fAut.Accion = "Modificar_Cantidad";
              fAut.ShowDialog();

              if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                  return;

              this._autorizador = fAut.UsuarioAutorizador;
          }

          ItemsFactura itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ItemsFactura);

          if (itemSel == null)
              return;

          frmCantidad fCant = new frmCantidad();
          fCant.ValorMinimo = 1;
          fCant.Cantidad = itemSel.Cantidad;
          fCant.ShowDialog();

          if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
              return;

          if (fCant.Cantidad == itemSel.Cantidad)
              return;

          ItemsFactura itemFact = this._itemsFactura.FirstOrDefault(it => it.IdArticulo == itemSel.IdArticulo && it.Devolucion == itemSel.Devolucion);

          if (itemFact == null)
              return;

          if (EstadoAplicacion.RestriccionVentasMayor)
          {
              if (ValidarAticulo(itemFact.IdArticulo, itemFact.CodigoArticulo, (itemFact.Devolucion ? 0 : fCant.Cantidad), false) == false)
                  return;

              int MaxPiezas = Util.ObtenerParametroEntero("MaximoPiezas");

              if (itemFact.Devolucion && fCant.Cantidad > MaxPiezas)
                  fCant.Cantidad = MaxPiezas;
          }

          itemFact.Cantidad = fCant.Cantidad;
          itemFact.PrecioVenta = itemFact.Cantidad * itemFact.PrecioNeto;

          this.RefrescarArticulosFactura();
          ((DataGridView)sender).Refresh();
          this.CalcularTotales();



          if (EstadoAplicacion.TieneVisor)
          {
              try
              {
                  BematechDisplay visorManager = new BematechDisplay();

                  using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor))
                  {
                      visorManager.ClearDisplay(serialPort);
                      visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera,
                        Util.TruncarCadena(itemFact.DescRef, 9).PadRight(9, ' ') + " " +
                        Util.TruncarCadena(string.Format("Bs{0:N2}", itemFact.PrecioVenta), 10).PadLeft(10, ' '), DisplayManagerEnum.Alineacion.Izquierda);

                      visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda,
                        string.Format("<Bs{0:N2}>", this._totalFactura), DisplayManagerEnum.Alineacion.Derecha);
                  }
              }
              catch (Exception ex)
              {
                  MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                  new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                    "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
              }
          }

          return;
      }

      // Ver Foto
      int idArtSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ItemsFactura).IdArticulo;

      if (idArtSel <= 0)
        return;

      EPK_Articulo artSel = new Articulos().Obtener(idArtSel);

      if (artSel == null)
        return;

      if (artSel.EPK_Referencia.FotoMediana == null)
        return;

      frmVerFoto fVerFoto = new frmVerFoto();

      fVerFoto.Articulo = artSel;

      fVerFoto.ShowDialog();
    }

    private void dgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 9) // Devolución
        return;

      ItemsFactura itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ItemsFactura);

      //Restricciones de Ventas al Mayor
      if (EstadoAplicacion.RestriccionVentasMayor)
      {
          if (ValidarAticulo(itemSel.IdArticulo,itemSel.CodigoArticulo,(itemSel.Devolucion? 0 : itemSel.Cantidad), false)==false)
          {
              //Solo se permitira hacer devoluciones 
              itemSel.Devolucion = true;
          }
      }

      if (itemSel != null)
        if (!itemSel.Devolucion) {
          itemSel.IdMotivo = null;
          this.RefrescarArticulosFactura();
          this.dgItems.Refresh();
        }

      this.CalcularTotales();
    }

    private void dgItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (((DataGridView)sender).IsCurrentCellDirty)
        ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgItems_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Delete)
        return;

      if (!this.btEliminarItem.Enabled)
        return;

      this.EliminarArticulos();
    }

    private void dgPagos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgPagos_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Delete)
        return;

      foreach (DataGridViewRow row in ((DataGridView)sender).SelectedRows)
        this._itemsPago.RemoveAt(row.Index);

      ((DataGridView)sender).Refresh();
      this.CalcularTotales();
    }

    private void frmFacturar_Activated(object sender, EventArgs e)
    {
      this.Text = Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmFacturar_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.inactivityMonitor != null) {
        this.inactivityMonitor.Enabled = false;
        this.inactivityMonitor = null;
      }

      Util.IniciarVisor();
    }

    private void frmFacturar_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
          if (!FormCloseAut)
          {
              if (MessageBox.Show(Properties.Resources.MsgConfirmarSalir, "Confirmación " + this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
              {
                  e.Cancel = true;
                  return;
              }
          }
      }

      if (this._facturasEspera.Count() > 0) {
        int? idAut = null;

        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Cancelar_Factura")) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgFacEsperaCancel;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = "Cancelar_Factura";
          fAut.Obligatoria = true;
          fAut.ShowDialog();

          if (fAut.UsuarioAutorizador != null)
            idAut = fAut.UsuarioAutorizador.IdUsuario;
        }

        foreach (EPK_FacturaEsperaEncabezado facEspera in this._facturasEspera) {
          facEspera.IdEstatus = EstadoAplicacion.EstadosFactura["FACExpirada"];
          facEspera.IdUsuarioModificacion = idAut;
          new FacturasEspera().Actualizar(facEspera);
        }
      }

      if (this._itemsFactura.Count() > 0)
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btCancelar.Tag.ToString())) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarCancel;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = this.btCancelar.Tag.ToString();
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado) {
            e.Cancel = true;
            return;
          }

          int? idAut = null;
          if (fAut.UsuarioAutorizador != null)
            idAut = fAut.UsuarioAutorizador.IdUsuario;

          this.DejarEnEspera(EstadoAplicacion.EstadosFactura["FACCancelada"], idAut);
        }

      if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
        new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
        EstadoAplicacion.SetUsuarioActual(null);
      }

      this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
      this.Close();
    }

    private void frmFacturar_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Shift || e.Alt || e.Control)
        return;

      switch (e.KeyCode) {
        case Keys.F2:
          if (this.btBuscarCliente.Enabled) {
            this.BuscarCliente();
            e.SuppressKeyPress = true;
          }
          break;

        case Keys.F3:
          if (this.tsbDejarEspera.Enabled)
            this.DejarEnEspera();
          e.SuppressKeyPress = true;
          break;

        case Keys.F4:
          if (this.tsbEfectivo.Enabled)
          {
              if (new frmMenuEfec().ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                  this.FormCloseAut = true;
                  this.Close();
              }
          }
          e.SuppressKeyPress = true;
          break;

        case Keys.F5:
          if (this.tsbReportes.Enabled)
            new frmMenuRep().ShowDialog();
          break;

        case Keys.F6:
          this.tsbBloqSesion_Click(this, EventArgs.Empty);
          break;

        case Keys.F7:
          if (this.btSelVendedor.Enabled)
              this.SeleccionarVendedor(this.btSelVendedor.Tag.ToString());
          break;

        case Keys.F12:
          if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "ReportesMF")) {
            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = Properties.Resources.MsgAutorizarMF;
            fAut.NombreTecnico = this.Name;
            fAut.Accion = "ReportesMF";
            fAut.ShowDialog();

            if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
              return;
          }
          new frmMenuMF().ShowDialog();
          break;
      }
    }

    private void frmFacturar_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (EstadoAplicacion.ShellMode)
        this.FormBorderStyle = FormBorderStyle.None;

      //  this.WindowState = FormWindowState.Maximized;

      // Se coloca el nombre y versión de la aplicación
      this.tlInfoApp.Text = Application.ProductName + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
      this.tlInfoApp.Visible = true;

      // Se muestra el nombre de la tienda
      this.tlTienda.Text = "Tienda: " + EstadoAplicacion.TiendaActual.Descripcion.Trim();
      this.tlTienda.Visible = true;

      if (EstadoAplicacion.CajaActual != null) {
        // Se muestra el nombre de la caja
        this.tlCaja.Text = "Caja: " + EstadoAplicacion.CajaActual.Descripcion.Trim();
        this.tlCaja.Visible = true;

        // Se cargan las facturas en espera
        this.CargarFactEspera();
      }

      // Se muestra el nombre del cajero
      this.tlCajero.Text = "Cajero: " + EstadoAplicacion.UsuarioActual.Identificacion.Trim();
      this.tlCajero.Visible = true;

      // Se inicia el reloj
      this.tlFecha.Text = DateTime.Now.ToShortDateString();
      this.tlHora.Text = DateTime.Now.ToShortTimeString();
      this.tlFecha.Visible = this.tlHora.Visible = true;
      this.tmReloj.Enabled = true;

      this.dgItems.DataSource = this._itemsFactura;
      this.dgPagos.DataSource = this._itemsPago;

      this.AgregarToolTips();

      //Se verifica si hay impresora en el sistema
      if (!EstadoAplicacion.TieneImpresora) {
        MessageBox.Show(Properties.Resources.MsgErrorSinImpresora, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
        this.Close();
        return;
      }

      if (!Util.VerificarImpresora(this.Name)) {
        this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
        this.Close();
        return;
      }

      //Se valida condiciones para boton desbloquear ventas al mayor
      if (!EstadoAplicacion.RestriccionVentasMayor)
      {
          this.tsbDesbloquearCliente.Visible = false;
          this.Separador3.Visible = false;
      }
      else
      {
          if (this._cliente == null)
              this.tsbDesbloquearCliente.Enabled = false;
      }

      // Se inicializan todos los controles
      if (this._facturasEspera != null && this._facturasEspera.Count() > 0)
          //return;
          CargarFactura(this._facturasEspera[itemfacturaEsp]);
      else
          //return;
          this.LimpiarTodo();
      //else
      //    CargarFactura(this._facturasEspera.FirstOrDefault());
    }

    private void frmFacturar_Shown(object sender, EventArgs e)
    {
      Util.IniciarVisor();

      foreach (Control controlItem in this.Controls) {
        if (controlItem.GetType() != typeof(ToolStripButton))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

      if (new CierreVentas().Obtener() != null) {
        MessageBox.Show(Properties.Resources.MsgCierreVentaExiste, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
          new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
          EstadoAplicacion.SetUsuarioActual(null);
        }

        this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
        this.Close();
        return;
      }

      if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name)) {
        MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        // TODO: Agregar log? o mover la validación a otro sitio?
        if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
          new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
          EstadoAplicacion.SetUsuarioActual(null);
        }

        this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
        this.Close();
        return;
      }

      // Se activa el timer que maneja el bloqueo de sesión y el timeout de las facturas.
      inactivityMonitor.Enabled = this.tmExpFact.Enabled = true;

      if (new CierreCajero().TienePendiente(EstadoAplicacion.UsuarioActual.IdUsuario)) {
        MessageBox.Show(Properties.Resources.MsgCierreCajPend, "Cierre de Cajero - " + this.Text,
          MessageBoxButtons.OK, MessageBoxIcon.Warning);

        while (new CierreCajero().TienePendiente(EstadoAplicacion.UsuarioActual.IdUsuario))
          if (new frmCierreCajero().ShowDialog() != System.Windows.Forms.DialogResult.OK) {
            this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
            this.Close();
            return;
          }
      }
      else
          if (new AlivioEfectivo().NecesitaAlivioEfectivo(EstadoAplicacion.UsuarioActual.IdUsuario))
          {

              NotificationManager.Show(this, Properties.Resources.MsgAlivio, Color.Red, EstadoAplicacion.ToastTimeout);

              //if (MessageBox.Show(Properties.Resources.MsgAlivio, "Alivio de Efectivo - " + this.Text,
              //  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
              //{
              //    if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Aliviar_Efectivo"))
              //    {
              //        frmAutorizar fAut = new frmAutorizar();
              //        fAut.Mensaje = Properties.Resources.MsgAutorizarAlivio;
              //        fAut.NombreTecnico = this.Name;
              //        fAut.Accion = "Aliviar_Efectivo";
              //        fAut.ShowDialog();

              //        if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
              //        {
              //            if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
              //                NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,
              //                  EstadoAplicacion.ToastTimeout);
              //        }
              //    }
              //    else
              //    {
              //        if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
              //            NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,
              //              EstadoAplicacion.ToastTimeout);
              //    }
              //}
          }

      EPK_AperturaCajeroEncabezado aperturaPrevia = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario);
      if (aperturaPrevia == null) {
        frmAperturaCajero fAperturaCajero = new frmAperturaCajero();
        if (fAperturaCajero.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
          if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
            new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
            EstadoAplicacion.SetUsuarioActual(null);
          }

          this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
          this.Close();
          return;
        }
        NotificationManager.Show(this, Properties.Resources.MsgApeExito, EstadoAplicacion.ToastColor,
          EstadoAplicacion.ToastTimeout);
      }

      while (this.ManejoNotasCredito()) ;

      this.btBuscarCliente.Focus();
    }

    private void pbCalc_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("calc.exe");
    }

    private void pbFotoArt_Click(object sender, EventArgs e)
    {
      if (this._articulo == null)
        return;

      if (this._articulo.EPK_Referencia.FotoMediana == null)
        return;

      frmVerFoto fVerFoto = new frmVerFoto();

      fVerFoto.Articulo = this._articulo;

      fVerFoto.ShowDialog();
    }

    private void pbLogout_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void TimeoutSesion(object sender, ElapsedEventArgs e)
    {
      try {
        if (EstadoAplicacion.SessionLocked)
          return;

        ((IInactivityMonitor)sender).Enabled = false;

        EstadoAplicacion.SetSessionLocked(true);

        if (new frmFondo().ShowDialog() == System.Windows.Forms.DialogResult.Abort) {
          List<Form> closeForms = new List<Form>();

          foreach (Form f in Application.OpenForms)
            if (!f.Equals(this))
              closeForms.Add(f);

          foreach (Form f in closeForms)
            f.Dispose();

          if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
            new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
            EstadoAplicacion.SetUsuarioActual(null);
          }

          this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
          this.Close();
          return;
        }

        EstadoAplicacion.SetSessionLocked(false);
        ((IInactivityMonitor)sender).Enabled = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void tmExpFact_Tick(object sender, EventArgs e)
    {
      try {
        if (EstadoAplicacion.SessionLocked)
          return;

        if (this._cliente != null)
          return;

        if (this._itemsFactura.Count() > 0)
          return;

        this.ManejoFacturasEspera();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void tmReloj_Tick(object sender, EventArgs e)
    {
      this.tlFecha.Text = DateTime.Now.ToShortDateString();
      this.tlHora.Text = DateTime.Now.ToShortTimeString();
    }

    private void tsbBloqSesion_Click(object sender, EventArgs e)
    {
      EstadoAplicacion.SetSessionLocked(true);
      this.inactivityMonitor.Enabled = this.tmExpFact.Enabled = false;

      if (new frmFondo().ShowDialog() == System.Windows.Forms.DialogResult.Abort) {
        List<Form> closeForms = new List<Form>();

        foreach (Form f in Application.OpenForms)
          if (!f.Equals(this))
            closeForms.Add(f);

        foreach (Form f in closeForms)
          f.Dispose();

        if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
          new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
          EstadoAplicacion.SetUsuarioActual(null);
        }

        this.FormClosing -= new FormClosingEventHandler(this.frmFacturar_FormClosing);
        this.Close();
        return;
      }

      this.inactivityMonitor.Enabled = this.tmExpFact.Enabled = true;
      EstadoAplicacion.SetSessionLocked(false);
    }

    private void tsbCambiarClave_Click(object sender, EventArgs e)
    {
      new frmCambioClave().ShowDialog();
    }

    private void tsbCierreCajero_Click(object sender, EventArgs e)
    {
      EPK_AperturaCajeroEncabezado _apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario);

      if (_apertura == null) {
        MessageBox.Show(Properties.Resources.MsgSinApertura, Application.ProductName);
        return;
      }
      frmCierreCajero fCierreCajero = new frmCierreCajero();
      if (fCierreCajero.ShowDialog() != System.Windows.Forms.DialogResult.OK)
        return;
    }

    private void tsbConsFactura_Click(object sender, EventArgs e)
    {
      new frmConsFacturas().ShowDialog();
    }

    private void tsbDejarEspera_Click(object sender, EventArgs e)
    {
      this.DejarEnEspera();
    }

    private void tsbEfectivo_Click(object sender, EventArgs e)
    {
        if (new frmMenuEfec().ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            this.FormCloseAut = true;
            this.Close();
        }
    }

    private void tsbReportes_Click(object sender, EventArgs e)
    {

        new frmMenuRep().ShowDialog();
        
      
    }

    private void tsbSigEspera_Click(object sender, EventArgs e)
    {
      if (this._facturasEspera.Count() == 0)
        return;

      if (this._facturasEspera.Count() == 1) {
        this.CargarFactura(this._facturasEspera.FirstOrDefault());
      }
      else {
        frmFacEspera fFacEspera = new frmFacEspera();
        fFacEspera.ShowDialog();
        if (fFacEspera.DialogResult == System.Windows.Forms.DialogResult.OK && fFacEspera.idFacturaEspera > 0)
          this.CargarFactura(this._facturasEspera.FirstOrDefault(fe => fe.IdFacturaEspera == fFacEspera.idFacturaEspera));
      }
    }

    private void tsbVentasDia_Click(object sender, EventArgs e)
    {
      if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, "frmVentasDia", "Consultar")) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutorizarMF;
        fAut.NombreTecnico = this.Name;
        fAut.Accion = "Consultar";
        fAut.ShowDialog();

        if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
          return;
      }

      new frmVentasDia().ShowDialog();
    }

    private void txCodArt_KeyPress(object sender, KeyPressEventArgs e)
    {
    
     this.LimpiarArticulo();
      
      
      if (e.KeyChar != (char)Keys.Return)
        return;

      if (string.IsNullOrEmpty(((TextBox)sender).Text) && this._itemsFactura.Count() > 0) 
      {
          if (this._saldo > 0)
              this.btAgregarFPago.Focus();

          if (this._saldo == 0)
              this.btProcesar.Focus();
        
          if (EstadoAplicacion.TemporadaComision && this._saldo == 0)
              this.btSelVendedor.Focus();        
          
          return;
      }

      if (!string.IsNullOrEmpty(EstadoAplicacion.CaracterGuion))
        ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(EstadoAplicacion.CaracterGuion, "-");
      string codigo = ((TextBox)sender).Text.Trim();

      if (string.IsNullOrEmpty(codigo))
          return;

      EPK_Articulo articulo = new Articulos().Obtener(codigo);

      if (articulo != null) {
        if (!articulo.Activo) {
          MessageBox.Show(Properties.Resources.MsgArticuloInactivo, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }
        bool ValidarObsequio = new Facturas().TieneObsequio(articulo.CodigoArticulo);
        if (!ValidarObsequio)
        {
            MessageBox.Show(string.Format(Properties.Resources.MsgArticuloNoFacturable, articulo.CodigoArticulo),
                    "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return;
        }
        this.AgregarArticulo(articulo);
        return;
      }

      IEnumerable<EPK_Articulo> articulosRef = new Articulos().BuscarPorReferencia(codigo);

      if (articulosRef == null || articulosRef.Count() == 0) {
        MessageBox.Show(Properties.Resources.MsgCodigoArtNoEnc, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      if (articulosRef.Any(p => p.Activo))
      {
          frmArtPorRef fArtPorRef = new frmArtPorRef { ArticulosRef = articulosRef };
          fArtPorRef.ShowDialog();

          if (fArtPorRef.DialogResult != System.Windows.Forms.DialogResult.OK)
              return;

          if (fArtPorRef.ArticuloSel == null)
              return;

          if (!fArtPorRef.ArticuloSel.Activo)
          {
              MessageBox.Show(Properties.Resources.MsgArticuloInactivo, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

          bool ValidarObsequio = new Facturas().TieneObsequio(fArtPorRef.ArticuloSel.CodigoArticulo);
                if (!ValidarObsequio)
                {
                    MessageBox.Show(string.Format(Properties.Resources.MsgArticuloNoFacturable, fArtPorRef.ArticuloSel.CodigoArticulo),
                            "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
          this.AgregarArticulo(fArtPorRef.ArticuloSel);
      }
      else
      {
          MessageBox.Show(Properties.Resources.MsgArticuloInactivo, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
      }

      
    }

    private void udCantidad_Enter(object sender, EventArgs e)
    {
      ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
    }

    private void udCantidad_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      this.txCodArt.Focus();
    }

    private void tsbDesbloquearCliente_Click(object sender, EventArgs e)
    {
        if (this._cliente == null)
            return;

        if (!this.SkipRule)
        {

            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = string.Format(Properties.Resources.MsgPregDesbloqueoCliente, Util.GenDocCliente(this._cliente));
            fAut.NombreTecnico = this.Name;
            fAut.Accion = "Debloqueo_Cliente";
            fAut.ExigirObservacion = true;
            fAut.ShowDialog();

            if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
            {
                this.SkipRule = true;
                this.tsbDesbloquearCliente.Image = Properties.Resources.UserUnlock;

                LogVentas = new EPK_VentasVolumen();
                LogVentas.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
                LogVentas.IdUsuarioAprobador = fAut.UsuarioAutorizador.IdUsuario;
                LogVentas.Observacion = fAut.Observacion;
            }
            else
                this.SkipRule = false;
        }
        else
        {
            this.SkipRule = false;
            this.tsbDesbloquearCliente.Image = Properties.Resources.UserLock;
            this.tsbDejarEspera.Enabled = (this._itemsFactura.Count() > 0 && this._facturasEspera.Count < Util.ObtenerParametroEntero("MAXFacturaEspera")) && !this.SkipRule;
        }
    }

    #endregion Events

    #region Private Methods

   

    private void AgregarArticulo(EPK_Articulo articulo)
    {
        ValidarPreg = false;
        //int ValidarObsequio = new Facturas().TieneObsequio(articulo.CodigoArticulo);
        //if (ValidarObsequio == 0)
        //{
        //    MessageBox.Show(string.Format(Properties.Resources.MsgMaximoArticulos, articulo.CodigoArticulo),
        //                    "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    return;
        //}
        

      this.LimpiarArticulo();

      bool Dev = false;

      if (articulo == null)
        return;

      ItemsFactura item = this._itemsFactura.Where(i => i.IdArticulo == articulo.IdArticulo && !i.Devolucion).FirstOrDefault();

      //Validación de Ventas al Mayor
      if (EstadoAplicacion.RestriccionVentasMayor)
      {
          
          if (item == null)
          {
              bool? Validate = ValidarAticulo(articulo.IdArticulo, articulo.CodigoArticulo.Trim(), (int)(this.udCantidad.Value), true);
                ValidarPreg = true;
              if (Validate == false)
                  return; //No desea realizar devoluciones

              if (Validate == null) //Si desea realizar devoluciones
              {
                  if (articulo.Exento)
                  {
                      MessageBox.Show(Properties.Resources.ValArtExcento, "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      return;
                  }

                  Dev = true; 
              }
          }
          else
          {
              if (ValidarAticulo(articulo.IdArticulo, articulo.CodigoArticulo.Trim(), (int)(this.udCantidad.Value + item.Cantidad), false)==false)
                  return;
          }
      }

      this._articulo = articulo;

      //decimal IVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

      decimal precioBaseArt = 0, montoDescuento = 0, precioVenta = 0;
      if (EstadoAplicacion.AplicaImpuesto && !articulo.Exento) {
        precioBaseArt = articulo.PrecioGravable;
        montoDescuento = Util.TruncarDecimal(precioBaseArt * this._porcDescuento / 100, 2);
        precioVenta = precioBaseArt - montoDescuento + Math.Round((precioBaseArt - montoDescuento) * EstadoAplicacion.IVA / 100, 2);
      }
      else {
        precioBaseArt = articulo.PrecioExento;
        montoDescuento = Util.TruncarDecimal(precioBaseArt * this._porcDescuento / 100, 2);
        precioVenta = precioBaseArt - montoDescuento;
      }

      this.txCodArt.Text = articulo.CodigoArticulo;
      this.txPrecioArt.Text = precioVenta.ToString("c");
      this.txDescArt.Text = articulo.Descripcion;

      if (articulo.EPK_Referencia.FotoMediana != null) {
        Byte[] data = new Byte[0];
        data = (Byte[])(articulo.EPK_Referencia.FotoMediana);
        MemoryStream mem = new MemoryStream(data);
        this.pbFotoArt.Image = Image.FromStream(mem);
      }
      else
        this.pbFotoArt.Image = Properties.Resources.imagennodisp;

      if (item != null)
        item.Cantidad += (int)this.udCantidad.Value;
      else {
        this._itemsFactura.Add(new ItemsFactura {
          IdArticulo = articulo.IdArticulo,
          CodigoArticulo = articulo.CodigoArticulo,
          Descripcion = articulo.Descripcion,
          IdReferencia = articulo.IdReferencia,
          DescRef = articulo.EPK_Referencia.Descripcion,
          Cantidad = (int)this.udCantidad.Value,

          PrecioBase = precioBaseArt,

          Exento = EstadoAplicacion.AplicaImpuesto ? articulo.Exento : false,
          Devolucion = Dev,
          IdMotivo = null,
          AplicaRestriccion = articulo.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta
        });
      }

      this.RefrescarArticulosFactura();

      this.btEliminarItem.Enabled = (this._itemsFactura.Count() > 0);

      this.dgItems.Refresh();
      this.CalcularTotales();

      if (EstadoAplicacion.TieneVisor) {
        try {
          BematechDisplay visorManager = new BematechDisplay();

          using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
            visorManager.ClearDisplay(serialPort);
            visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera,
              Util.TruncarCadena(articulo.EPK_Referencia.Descripcion, 9).PadRight(9, ' ') + " " +
              Util.TruncarCadena(string.Format("Bs{0:N2}", precioVenta), 10).PadLeft(10, ' '), DisplayManagerEnum.Alineacion.Izquierda);

            visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda,
              string.Format("<Bs{0:N2}>", this._totalFactura), DisplayManagerEnum.Alineacion.Derecha);
          }
        }
        catch (Exception ex) {
          MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

          new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        }
      }

      if (this._itemsFactura.Count() > 0)
        this.btCancelar.Enabled = true;

      this.udCantidad.Value = 1;
      this.txCodArt.Text = string.Empty;
      this.txCodArt.Focus();
    }

    private void AgregarToolTips()
    {
      ToolTip mainToolTip = new ToolTip();

      // Se asignan los tiempos.
      mainToolTip.AutoPopDelay = 5000;
      mainToolTip.InitialDelay = 1000;
      mainToolTip.ReshowDelay = 500;

      // Se muestra el tooltip siempre, aunque la forma no esté activa.
      mainToolTip.ShowAlways = true;

      // Se colocan los tooltips a los controles.
      mainToolTip.SetToolTip(this.pbCalc, Properties.Resources.TipCalc);
      mainToolTip.SetToolTip(this.pbLogout, Properties.Resources.TipSalir);
      mainToolTip.SetToolTip(this.btBuscarCliente, Properties.Resources.TipBuscarCliente);
      mainToolTip.SetToolTip(this.btBuscarArt, Properties.Resources.TipBuscarArt);
      mainToolTip.SetToolTip(this.pbFotoArt, Properties.Resources.TipVerFoto);
      mainToolTip.SetToolTip(this.btSelVendedor, Properties.Resources.TipSelVendedor);
    }

    private void BuscarCliente()
    {
      frmBuscarCliente fBuscarCli = new frmBuscarCliente(this._cliente, this._itemsFactura.Count() > 0);

      fBuscarCli.ShowDialog();

      if (this._cliente != null && fBuscarCli.Cliente == null)
        return;

      this._cliente = fBuscarCli.Cliente;
      this._clienteCompras = fBuscarCli.ListClienteCompra;

      if (EstadoAplicacion.RestriccionVentasMayor)
          this.tsbDesbloquearCliente.Enabled = true;

      this.CargarCliente();

      if (this._cliente != null) {
        short idFACCreada = EstadoAplicacion.EstadosFactura["FACCreada"];
        DateTime currDate = new DataAccess(true).FechaDB();

        EPK_FacturaEsperaEncabezado facEsperaCliente = this._facturasEspera.FirstOrDefault(fe =>
          fe.IdCliente == this._cliente.IdCliente && fe.IdEstatus == idFACCreada &&
          Math.Abs((fe.FechaCreacion - currDate).TotalSeconds) <= (EstadoAplicacion.TimeoutFacturaEspera * 2));

        if (facEsperaCliente != null) {
          this.CargarFactura(facEsperaCliente);
          return;
        }
      }
      //this.LimpiarTodo();
    }

    private void CalcularTotales()
    {
      this.ConsolidarArticulos();

      this.LimpiarTotales();

      this.btAgregarFPago.Enabled = this.btElimFPago.Enabled = false;

      if (this._itemsFactura == null) {
        this._itemsPago = null;
        return;
      }

      if (this._itemsFactura.Count() == 0) {
        this._itemsPago.Clear();
        this.tsbSigEspera.Enabled = (this._facturasEspera.Count() > 0);
      }
      else
        this.tsbSigEspera.Enabled = false;

      int totArt = 0, totDev = 0;
      decimal totEx = 0, baseImp = 0;

      foreach (ItemsFactura item in this._itemsFactura) {
        if (item.Devolucion) {
          totDev += item.Cantidad;

          if (item.Exento)
            totEx -= (Util.TruncarDecimal(item.PrecioBase * item.Cantidad, 2) - Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2));
          else
            baseImp -= (item.PrecioBase * item.Cantidad) - Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2);

          this._totDescuento -= Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2);
        }
        else {
          totArt += item.Cantidad;

          if (item.Exento)
            totEx += (Util.TruncarDecimal(item.PrecioBase * item.Cantidad, 2) - Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2));
          else
            baseImp += (item.PrecioBase * item.Cantidad) - Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2);

          this._totDescuento += Util.TruncarDecimal((item.PrecioBase * item.Cantidad) * this._porcDescuento / 100, 2);
        }
      }

      decimal IVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

      decimal totIVA = Math.Round(baseImp * IVA / 100, 2);

      decimal subTot = Math.Round(baseImp + totEx, 2);
      decimal totFac = Math.Round(baseImp + totEx + totIVA, 2);

      this._montoBase = baseImp;
      this._totalFactura = totFac;
      this._IVAFactura = totIVA;

      if (totArt > 0) {
        this.txTotalArt.BackColor = SystemColors.Control;
        this.txTotalArt.ForeColor = Color.Green;
        this.txTotalArt.ReadOnly = true;
      }
      this.txTotalArt.Text = totArt.ToString();

      if (totDev > 0) {
        this.txTotalArtDev.BackColor = SystemColors.Control;
        this.txTotalArtDev.ForeColor = Color.Red;
        this.txTotalArtDev.ReadOnly = true;
      }
      this.txTotalArtDev.Text = totDev.ToString();

      this.txtTotalExento.Text = string.Format("{0:c}", totEx);
      this.txBaseImponible.Text = string.Format("{0:c}", baseImp);
      this.txSubtotal.Text = string.Format("{0:c}", subTot);
      this.txTotalDesc.Text = string.Format("{0:c}", this._totDescuento);
      this.txTotalIVA.Text = string.Format("{0:c}", totIVA);
      this.lbTotalFactura.Text = string.Format("Total Factura: {0:c}", this._totalFactura);

      this.dgItems.Enabled = (this._itemsFactura.Count() > 0);

      // Formas de Pago
      decimal totalRecibido = 0;

      foreach (ItemsPago item in this._itemsPago)
        totalRecibido += item.Monto;

      this._saldo = this._totalFactura - totalRecibido;

      if (this._saldo < 0) {
        this._cambio = this._saldo * (decimal)-1;
        this._saldo = 0;
      }

      if (this._saldo > 0 && this._totalFactura > 0)
        this.btAgregarFPago.Enabled = true;

      this.txSaldo.Text = string.Format("{0:c}", this._saldo);
      this.txSaldo.BackColor = SystemColors.Control;
      if (this._saldo > 0)
        this.txSaldo.ForeColor = Color.Red;
      else
        this.txSaldo.ForeColor = Color.Black;
      this.txSaldo.ReadOnly = true;

      this.txCambio.Text = string.Format("{0:c}", this._cambio);
      this.txCambio.BackColor = SystemColors.Control;
      if (this._cambio > 0)
        this.txCambio.ForeColor = Color.Green;
      else
        this.txCambio.ForeColor = Color.Black;
      this.txCambio.ReadOnly = true;

      this.txTotalPagar.Text = string.Format("{0:c}", totalRecibido);

      if (this._itemsPago.Count() > 0) {
        this.btElimFPago.Enabled = this.dgItems.ReadOnly = true;
        //this.btEliminarItem.Enabled = this.btDescuento.Enabled = false;
        this.tsbDejarEspera.Enabled = false;
      }
      else {
        this.btElimFPago.Enabled = this.dgItems.ReadOnly = false;
        //this.btEliminarItem.Enabled = true;

        if (this._descuento != null)
          if (!this._descuento.PorcDescuento.HasValue)
            this.btDescuento.Enabled = true;

        this.tsbDejarEspera.Enabled = (this._itemsFactura.Count() > 0 && this._facturasEspera.Count < Util.ObtenerParametroEntero("MAXFacturaEspera")) && !this.SkipRule;
      }

      this.dgPagos.Enabled = (this._itemsPago.Count() > 0);

      int cantDev = this._itemsFactura.Where(i => i.Devolucion).Count();

      decimal MaxDenominacion = new Denominacion().ObtenerMax();

      if (this._itemsFactura.Count() > 0 //Que tenga items la factura
          && this._saldo == 0            //Que se haya completado el pago
          && (this._cambio <= MaxDenominacion) //Que el vuelto no sea mayor al máximo billete
          && (this._totalFactura > 0 || (this._totalFactura == 0 && cantDev > 0)) //Que el monto a facturar sea positivo ó igual a 0 cuando sea una devolución
          && (this._vendedor != null && EstadoAplicacion.TemporadaComision || !EstadoAplicacion.TemporadaComision)) //Que sea o no obligatorio seleccionar al vendedor
          this.btProcesar.Enabled = true;
      else
          this.btProcesar.Enabled = false;

      foreach (DataGridViewRow item in this.dgItems.Rows)
        if ((item.DataBoundItem as ItemsFactura).Exento)
          item.ReadOnly = true;

      this.dgItems.Refresh();

      //Vericación de Pago
      if (totalRecibido > 0)
      {
          if (totalRecibido < _totalFactura)
          {
              MessageBox.Show(Properties.Resources.MsgFacturaMayorPago, "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              btProcesar.Enabled = false;
              btAgregarFPago.Enabled = true;
              btElimFPago.Enabled = true;
          }
          else
          if (totalRecibido > _totalFactura && (_cambio > _itemsPago.Where(p=>p.Efectivo).Sum(p=>p.Monto) || (_cambio > MaxDenominacion) ))//Ojo revisar otros pagos
          {
              MessageBox.Show(Properties.Resources.MsgPagoMayorFactura, "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              btProcesar.Enabled = false;
              btAgregarFPago.Enabled = true;
              btElimFPago.Enabled = true;
          }      
      }

      this.txCodArt.Focus();
    }

    private void CargarCliente()
    {
      if (this._cliente == null) {
        this.LimpiarCliente();
        this.LimpiarArticulo(true);
        return;
      }

      string rifCliente = Util.GenDocCliente(this._cliente);
      string nombreCliente = Util.GenNomCliente(this._cliente);

      this.btBuscarCliente.Text = string.Format("Cliente: {0} - {1}", nombreCliente, rifCliente);
      this.btBuscarCliente.Font = new Font(this.btBuscarCliente.Font, FontStyle.Bold);

      this.txCodArt.Enabled = this.udCantidad.Enabled = this.btSelVendedor.Enabled = true;

      this.btDescuento.Enabled = false;
      this.txDescuento.Text = string.Empty;
      this._porcDescuento = 0;

      if (EstadoAplicacion.CajaActual.EnDescuento) {
        this._descuento = new Clientes().ObtenerDescuento(this._cliente);
        if (this._descuento != null)
          if (!this._descuento.PorcDescuento.HasValue) {
            this.btDescuento.Enabled = true;
          }
          else {
            if (this._descuento.PorcDescuento.Value <= 0 || this._descuento.PorcDescuento.Value >= 100)
              this._descuento = null;
            else {
              this.txDescuento.Text = string.Format("{0:N2}", this._descuento.PorcDescuento);
              this._porcDescuento = this._descuento.PorcDescuento.Value;
            }
          }
      }

      this.txCodArt.Focus();
      this.udCantidad.Value = 1;
      if (!EstadoAplicacion.TieneVisor)
        return;

      try {
        BematechDisplay visorManager = new BematechDisplay();

        using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
          visorManager.ClearDisplay(serialPort);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, "Bienvenido", DisplayManagerEnum.Alineacion.Centrado);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, Util.StripAccents("Sr(a). " + nombreCliente), DisplayManagerEnum.Alineacion.Centrado);
        }
      }
      catch (Exception ex) {
        MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void CargarFactEspera()
    {
      this._facturasEspera = new FacturasEspera().ObtenerActivasPorCaja(EstadoAplicacion.CajaActual.IdCaja);

      this.tsbSigEspera.Enabled = false;

      if (this._facturasEspera != null)
        this.tsbSigEspera.Enabled = (this._facturasEspera.Count() > 0);
    
    }

    private bool CargarFactura(EPK_FacturaEsperaEncabezado facEspera)
    {
      bool result = false;

      try {
        this.LimpiarTodo();
        Util.IniciarVisor();

        this._cliente = new Clientes().Obtener(facEspera.IdCliente);
          
        this.CargarCliente();

        if (EstadoAplicacion.RestriccionVentasMayor)
            this._clienteCompras = new ClienteCompra().GetCompras(this._cliente.NumeroDocumento, this._cliente.IdTipoDocumento);

        this._porcDescuento = facEspera.PorcDescuento;

        foreach (EPK_FacturaEsperaDetalle itemDetalle in facEspera.EPK_FacturaEsperaDetalle) {
          this._itemsFactura.Add(new ItemsFactura {
            IdArticulo = itemDetalle.IdArticulo,
            CodigoArticulo = itemDetalle.EPK_Articulo.CodigoArticulo.Trim(),
            Descripcion = itemDetalle.EPK_Articulo.Descripcion.Trim(),
            IdReferencia = itemDetalle.EPK_Articulo.IdReferencia,
            DescRef = itemDetalle.EPK_Articulo.EPK_Referencia.Descripcion.Trim(),
            Cantidad = itemDetalle.Cantidad,

            PrecioBase = itemDetalle.Precio,

            Descuento = itemDetalle.Descuento,
            Exento = itemDetalle.Exento,

            Devolucion = itemDetalle.Cambio,
            IdMotivo = null,
            AplicaRestriccion = itemDetalle.EPK_Articulo.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta
          });
        }

        if (facEspera.IdVendedor.HasValue) {
          this._vendedor = new Empleados().Obtener(facEspera.IdVendedor.Value);
          if (this._vendedor != null)
            this.btSelVendedor.Text = String.Format("Vendedor: {0} {1}", this._vendedor.Nombre, this._vendedor.Apellido);
        }

        new FacturasEspera().Borrar(facEspera.IdFacturaEspera);
        this._controlFactEspera.Remove(facEspera.IdFacturaEspera);

        this.RefrescarArticulosFactura();

        this.btEliminarItem.Enabled = (this._itemsFactura.Count() > 0);

        this.dgItems.Refresh();

        if (this._itemsFactura.Count() > 0)
          this.btCancelar.Enabled = true;

        this.udCantidad.Value = 1;
        this.txCodArt.Text = string.Empty;
        this.txCodArt.Focus();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        this.LimpiarTodo();
        Util.IniciarVisor();
      }
      finally {
        this.CargarFactEspera();
        this.CalcularTotales();
        this.tsbDesbloquearCliente.Enabled = true;
      }

      return result;
    }

    private void ConsolidarArticulos()
    {
      if (this._itemsFactura == null)
        return;

      if (this._itemsFactura.Count() == 0)
        return;

      int duplicados = this._itemsFactura.GroupBy(it => new { it.IdArticulo, it.Devolucion }).Where(g => g.Count() > 1).Count();

      if (duplicados == 0)
        return;

      BindingList<ItemsFactura> tempList = new BindingList<ItemsFactura>();

      foreach (ItemsFactura item in this._itemsFactura) {
        ItemsFactura tempItem = tempList.FirstOrDefault(tl => tl.IdArticulo == item.IdArticulo && tl.Devolucion == item.Devolucion);

        if (tempItem == null) {
          tempList.Add(item);
          continue;
        }

        if (EstadoAplicacion.RestriccionVentasMayor)
        {
            //if (ValidarPreg == true)
            //    return null;
            int CantidadTotal = tempItem.Cantidad + item.Cantidad;
            if (ValidarAticulo(item.IdArticulo, item.CodigoArticulo, (item.Devolucion ? 0 : CantidadTotal), false) == false)
            {
                tempItem.Cantidad = Util.ObtenerParametroEntero("MaximoArticulo");
                tempItem.PrecioVenta = Util.TruncarDecimal(tempItem.Cantidad * tempItem.PrecioNeto, 2);
                continue;
            }
            else
            {
                tempItem.Cantidad += item.Cantidad;
                tempItem.PrecioVenta = Util.TruncarDecimal(tempItem.Cantidad * tempItem.PrecioNeto, 2);
            }
        }
        else
        {
            tempItem.Cantidad += item.Cantidad;
            tempItem.PrecioVenta = Util.TruncarDecimal(tempItem.Cantidad * tempItem.PrecioNeto, 2);
        }
        
      }

      this._itemsFactura = tempList;
      this.dgItems.DataSource = this._itemsFactura;

      this.dgItems.Refresh();
    }

    private bool DejarEnEspera(short? estatus = null, int? idUsrMod = null)
    {
      bool result = false;

      try {
        int? idVendedor = null;
        if (this._vendedor != null)
          idVendedor = (int)this._vendedor.IdEmpleado;

        EPK_FacturaEsperaEncabezado facturaEspera = new EPK_FacturaEsperaEncabezado {
          IdCaja = EstadoAplicacion.CajaActual.IdCaja,
          PorcDescuento = this._porcDescuento,
          IdCliente = this._cliente.IdCliente,
          MontoTotal = this._totalFactura,
          MontoIVA = this._IVAFactura,
          IdVendedor = idVendedor,
          IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario,
          IdUsuarioModificacion = idUsrMod,
          MontoBase = this._montoBase,
          MontoDescuento = this._totDescuento
        };

        foreach (ItemsFactura item in this._itemsFactura) {
          byte? idMotDev = null;
          if (item.Devolucion)
            idMotDev = item.IdMotivo;

          facturaEspera.EPK_FacturaEsperaDetalle.Add(new EPK_FacturaEsperaDetalle {
            IdArticulo = item.IdArticulo,
            Cantidad = item.Cantidad,
            Precio = item.PrecioBase,
            Descuento = item.Descuento,
            Exento = item.Exento,
            Cambio = item.Devolucion,
            MontoImpuesto = item.MontoIVA,
            MontoDescuento = item.MontoDescuento,
            PrecioNeto = item.PrecioNeto
          });
        }

        int idFacturaEspera = 0;

        if (estatus.HasValue)
          idFacturaEspera = new FacturasEspera().Nueva(facturaEspera, estatus.Value);
        else
          idFacturaEspera = new FacturasEspera().Nueva(facturaEspera);

        if (idFacturaEspera <= 0) {
          // TODO: Agregar log?
          MessageBox.Show("Error al colocar la factura en espera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          //LOG
          new NLogLogger().Error("Error al colocar la factura en espera Error" + this.Text);

          return result;
        }

        this.CargarFactEspera();

        this.LimpiarTodo();
        Util.IniciarVisor();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show("Error al colocar la factura en espera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      return result;
    }

    private void EliminarArticulos()
    {
      if (this.dgItems.SelectedRows.Count == 0)
        return;

      if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btEliminarItem.Tag.ToString())) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutorizarEliminacion;
        fAut.NombreTecnico = this.Name;
        fAut.Accion = this.btEliminarItem.Tag.ToString();
        fAut.ShowDialog();

        if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
          return;

        this._autorizador = fAut.UsuarioAutorizador;
      }

      try
      {
          foreach (DataGridViewRow row in this.dgItems.SelectedRows)
          {
              if (EstadoAplicacion.RestriccionVentasMayor)
              {
                  ItemsFactura Item = this._itemsFactura.ElementAt(row.Index);

                  int TotalCompras = this._clienteCompras.Sum(p => p.Cantidad);
                  int MaxPiezas = Util.ObtenerParametroEntero("MaximoPiezas");
                  int TotalDev = this._itemsFactura.Count(p => p.Devolucion);

                  if (TotalCompras >= MaxPiezas && Item.Devolucion && TotalDev <= 1)
                  {
                      bool Loop = true;
                      while (Loop)
                      {
                          if (MessageBox.Show(string.Format(Properties.Resources.MsgMaxArtCancel, MaxPiezas), "Advertencia - " + this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                          {
                              Loop = false;
                          }
                      }

                      this.DejarEnEspera(EstadoAplicacion.EstadosFactura["FACCancelada"], Util.ObtenerParametroEntero("IDAUDITORÍA"));

                      this.LimpiarTodo();
                      Util.IniciarVisor();

                      // Log Auditoria
                      new NLogLogger().Info(string.Format("Factura cancelada por: {0} , Acción: {1} , Nombre Técnico: {2} ", EstadoAplicacion.UsuarioActual.Login, "Eliminar_Item", this.Name));

                  }
                  else
                      this._itemsFactura.RemoveAt(row.Index);
              }
              else
              {
                  this._itemsFactura.RemoveAt(row.Index);
              }
          }

          if (this._itemsFactura.Count() == 0)
          {
              this.LimpiarTodo();
              Util.IniciarVisor();
              return;
          }

          this.RefrescarArticulosFactura();

          this.btEliminarItem.Enabled = (this._itemsFactura.Count() > 0);

          this.dgItems.Refresh();

          this.CalcularTotales();

          if (EstadoAplicacion.TieneVisor)
          {
              try
              {
                  BematechDisplay visorManager = new BematechDisplay();

                  using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor))
                  {
                      ItemsFactura item = this._itemsFactura.LastOrDefault();
                      EPK_Articulo articulo = new Articulos().Obtener(item.CodigoArticulo);
                      visorManager.ClearDisplay(serialPort);
                      visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera,
                        Util.TruncarCadena(articulo.EPK_Referencia.Descripcion, 9).PadRight(9, ' ') + " " +
                        Util.TruncarCadena(string.Format("Bs{0:N2}", item.PrecioVenta), 10).PadLeft(10, ' '), DisplayManagerEnum.Alineacion.Izquierda);

                      visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda,
                        string.Format("<Bs{0:N2}>", this._totalFactura), DisplayManagerEnum.Alineacion.Derecha);
                  }

              }
              catch (Exception ex)
              {
                  MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                  new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                    "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
              }
          }
      }
      catch(Exception ex)
      {
          this.LimpiarTodo();
          new NLogLogger().Error(string.Format(Properties.Resources.ErrorEliminarArt, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void LimpiarArticulo(bool full = false)
    {
      this._articulo = null;

      if (full) {
        this.txCodArt.Text = string.Empty;
        this.udCantidad.Value = 1;
      }

      this.txPrecioArt.Text = this.txDescArt.Text = string.Empty;
      this.pbFotoArt.Image = null;

      this.txCodArt.Focus();
    }

    private void LimpiarCliente()
    {
      this._autorizador = null;
      this._cliente = null;
      this._descuento = null;
      this._vendedor = null;

      this._porcDescuento = 0;
      this.txDescuento.Text = string.Empty;

      this.btBuscarCliente.Text = Properties.Resources.TipBuscarCliente;
      this.btBuscarCliente.Font = new Font(this.btBuscarCliente.Font, FontStyle.Regular);

      this.txCodArt.Enabled = this.udCantidad.Enabled = this.btDescuento.Enabled =
        this.btSelVendedor.Enabled = false;

      this.btSelVendedor.Text = Properties.Resources.TipSelVendedor;
    }

    private void LimpiarTodo()
    {
      this.LimpiarCliente();
      this.LimpiarArticulo(true);

      this._itemsFactura.Clear();
      this._itemsPago.Clear();

      this.CalcularTotales();

      this.btEliminarItem.Enabled = false;
      this.btElimFPago.Enabled = false;

      this.btProcesar.Enabled = false;
      this.btCancelar.Enabled = false;

      this.btBuscarCliente.Enabled = true;
      this.btBuscarCliente.Focus();

      this.tsbDesbloquearCliente.Enabled = false;
      this.tsbDesbloquearCliente.Image = Properties.Resources.UserLock;
      this.SkipRule = false;
      this.LogVentas = null;
      this.udCantidad.Value = 1;
    }

    private void LimpiarTotales()
    {
      this._montoBase = this._totalFactura = this._IVAFactura = this._cambio =
        this._saldo = this._totDescuento = 0;

      this.txTotalArt.Text = this.txTotalArtDev.Text = "0";
      this.txTotalArt.BackColor = this.txTotalArtDev.BackColor = SystemColors.Control;
      this.txTotalArt.ForeColor = this.txTotalArtDev.ForeColor = Color.Black;
      this.txTotalArt.ReadOnly = this.txTotalArtDev.ReadOnly = true;

      this.txtTotalExento.Text = this.txSubtotal.Text = this.txTotalDesc.Text = this.txTotalIVA.Text =
        this.lbTotalFactura.Text = this.txBaseImponible.Text = string.Format("{0:c}", 0);

      this.txTotalPagar.Text = this.txSaldo.Text = this.txCambio.Text = string.Format("{0:c}", 0);
      this.txSaldo.BackColor = this.txCambio.BackColor = SystemColors.Control;
      this.txSaldo.ForeColor = this.txCambio.ForeColor = Color.Black;
      this.txSaldo.ReadOnly = this.txCambio.ReadOnly = true;

      this.dgItems.Enabled = this.dgPagos.Enabled = false;
    }

    private void ManejoFacturasEspera()
    {
      if (this._facturasEspera.Count() == 0)
        return;

      this.tmExpFact.Enabled = false;

      short idFACCreada = EstadoAplicacion.EstadosFactura["FACCreada"];
      DateTime currDate = new DataAccess(true).FechaDB();

      List<EPK_FacturaEsperaEncabezado> facturasAdvertencia =
        this._facturasEspera.Where(fe => fe.IdEstatus == idFACCreada && Math.Abs((fe.FechaCreacion - currDate).TotalSeconds) >= EstadoAplicacion.TimeoutFacturaEspera &&
          Math.Abs((fe.FechaCreacion - currDate).TotalSeconds) < (EstadoAplicacion.TimeoutFacturaEspera * 2)).OrderByDescending(fe => fe.FechaCreacion).ToList();

      foreach (EPK_FacturaEsperaEncabezado facEspera in facturasAdvertencia) {
        if (!this._controlFactEspera.Exists(cfe => cfe.Equals(facEspera.IdFacturaEspera))) {
          if (MessageBox.Show(Properties.Resources.MsgTieneFacEspera, "Confirmación " + this.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
            this.CargarFactura(facEspera);
            this.tmExpFact.Enabled = true;
            return;
          }
          this._controlFactEspera.Add(facEspera.IdFacturaEspera);
        }

        this.tmExpFact.Enabled = true;
        return;
      }

      List<EPK_FacturaEsperaEncabezado> facturasExpiradas =
        this._facturasEspera.Where(fe => fe.IdEstatus == idFACCreada && Math.Abs((fe.FechaCreacion - currDate).TotalSeconds) >=
          (EstadoAplicacion.TimeoutFacturaEspera * 2)).OrderByDescending(fe => fe.FechaCreacion).ToList();

      foreach (EPK_FacturaEsperaEncabezado facEspera in facturasExpiradas) {
        MessageBox.Show(string.Format(Properties.Resources.MsgFacEsperaExp, facEspera.IdFacturaEspera.ToString()),
          "Notificación " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        int? idAut = null;

        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Cancelar_Factura")) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = string.Format(Properties.Resources.MsgFacEsperaExp, facEspera.IdFacturaEspera.ToString());
          fAut.NombreTecnico = this.Name;
          fAut.Accion = "Cancelar_Factura";
          fAut.Obligatoria = true;
          fAut.ShowDialog();

          if (fAut.UsuarioAutorizador != null)
            idAut = fAut.UsuarioAutorizador.IdUsuario;
        }

        facEspera.IdEstatus = EstadoAplicacion.EstadosFactura["FACExpirada"];
        facEspera.IdUsuarioModificacion = idAut;

        new FacturasEspera().Actualizar(facEspera);

        this._controlFactEspera.Remove(facEspera.IdFacturaEspera);
      }

      this.CargarFactEspera();

      this.tmExpFact.Enabled = true;
    }

    private bool ManejoNotasCredito()
    {
      if (!new NotasCredito().TieneSolicitudesAprobadas(EstadoAplicacion.SerialImpresora))
        return false;

      if (MessageBox.Show(Properties.Resources.MsgNCPend, "Notas de Crédito - " + this.Text,
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return false;

      int IdUsuarioAut = 0;
      List<ClienteCompra.ClienteComp> ListClienteCompraNC = new List<ClienteCompra.ClienteComp>(); //Se crea colection de Clientes Compras

      if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Emitir_NC")) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutNC;
        fAut.NombreTecnico = this.Name;
        fAut.Accion = "Emitir_NC";
        fAut.ShowDialog();

        if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
          return false;

        IdUsuarioAut = fAut.UsuarioAutorizador.IdUsuario;
      }

      List<EPK_NotaCreditoEsperaEncabezado> NCsPendientes = new NotasCredito().SolictudesAprobadas(EstadoAplicacion.SerialImpresora);

      if (NCsPendientes.Count() == 0) {
        MessageBox.Show(Properties.Resources.ErrorCargarNCs, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      foreach (EPK_NotaCreditoEsperaEncabezado item in NCsPendientes) {
        if (new frmInfoNC(item).ShowDialog() != System.Windows.Forms.DialogResult.OK)
          continue;

        if (!Util.VerificarImpresora(this.Name))
          return false;

        try {
          this.Cursor = Cursors.WaitCursor;

          EPK_NotaCreditoEncabezado nuevaNC = new EPK_NotaCreditoEncabezado {
            IdFactura = item.IdFactura,
            PorcDescuento = item.PorcDescuento,
            MontoBase = item.MontoBase,
            MontoDescuento = item.MontoDescuento,
            MontoIVA = item.MontoIVA,
            MontoTotal = item.MontoTotal,
            SerialMF = item.SerialMF,
            NombreCliente = item.NombreCliente
          };

          nuevaNC.EPK_NotaCreditoDetalle = item.EPK_NotaCreditoEsperaDetalle.Select(nd => new EPK_NotaCreditoDetalle {
            IdArticulo = nd.IdArticulo,
            Cantidad = nd.Cantidad,
            Precio = nd.Precio,
            Descuento = nd.Descuento,
            MontoDescuento = nd.MontoDescuento,
            Exento = nd.Exento,
            MontoImpuesto = nd.MontoImpuesto,
            PrecioNeto = nd.PrecioNeto,
            Cambio = nd.Cambio
          }).ToList();

          int idNC = new NotasCredito().Nueva(nuevaNC);

          if (idNC <= 0)
          {
              MessageBox.Show(Properties.Resources.MsgErrorGenNC, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
              return true;
          }
          else
          { 
              //Restrcciones de Ventas al mayor
              if (EstadoAplicacion.RestriccionVentasMayor)
              {
                  EPK_FacturaEncabezado FanctEncNC = new Facturas().Obtener(nuevaNC.IdFactura);
                  
                  foreach (EPK_NotaCreditoDetalle ItemNC in nuevaNC.EPK_NotaCreditoDetalle)
                  {
                      if(new Articulos().AplicaRestriccion(ItemNC.IdArticulo))
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

          DateTime fechaFactura = item.EPK_FacturaEncabezado.Fecha + item.EPK_FacturaEncabezado.Hora;
          string rifCliente = Util.GenDocCliente(item.EPK_FacturaEncabezado.EPK_Cliente, true);
          string nombreCliente = Util.StripAccents(Util.TruncarCadena(item.NombreCliente, 100));

          rifCliente = Util.StripAccents(rifCliente);

          Impresora impresora = new Impresora();

          if (!impresora.AbrirNotaCredito(nombreCliente, item.SerialMF, rifCliente, fechaFactura, item.EPK_FacturaEncabezado.COO)) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorCrearComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }
          string resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado)) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorCrearComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }

          string nuevoTicketFiscal = impresora.NroComprobanteFiscal();
          string nuevoCOO = impresora.NroCupon();
          string numReduccion = impresora.NroRepZ();

          resultado = impresora.ResultadoComando();
          if (!string.IsNullOrEmpty(resultado)) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorInfoComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }

          int numZ;
          int.TryParse(numReduccion, out numZ);
          numZ++;

          nuevaNC = new NotasCredito().Obtener(idNC);

          nuevaNC.COO = nuevoCOO;
          nuevaNC.TicketFiscal = nuevoTicketFiscal;
          nuevaNC.NroReporteZ = numZ.ToString("0000");

          int totalItems = 0;

          decimal valorIVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA", item.EPK_FacturaEncabezado.FechaCreacion) : 0;

          foreach (EPK_NotaCreditoEsperaDetalle itemDet in item.EPK_NotaCreditoEsperaDetalle)
            if (itemDet.Cambio) {
              if (!impresora.DevolverArticulo(itemDet.EPK_Articulo.CodigoArticulo, itemDet.EPK_Articulo.EPK_Referencia.Descripcion,
                                             valorIVA, itemDet.Exento, itemDet.Cantidad, itemDet.Precio, item.PorcDescuento, itemDet.Descuento)) {
                impresora.AnularComprobante();
                new NotasCredito().Anular(idNC);
                MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
              }
              totalItems++;
            }
            else {
              if (!impresora.VenderArticulo(itemDet.EPK_Articulo.CodigoArticulo, itemDet.EPK_Articulo.EPK_Referencia.Descripcion,
                                            valorIVA, itemDet.Exento, itemDet.Cantidad, itemDet.Precio, item.PorcDescuento, itemDet.Descuento)) {
                impresora.AnularComprobante();
                new NotasCredito().Anular(idNC);
                MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
              }
              totalItems++;
            }

          if (totalItems <= 0 || nuevaNC.EPK_NotaCreditoDetalle.Count() != totalItems) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }

          decimal tempTotal = impresora.SubTotal();

          if (!impresora.IniciarCierreComprobante()) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }

          DateTime? fechaImp = impresora.FechaHoraImpresora();

          if (fechaImp == null) {
            nuevaNC.Fecha = nuevaNC.FechaCreacion.Date;
            nuevaNC.Hora = nuevaNC.FechaCreacion.TimeOfDay;
          }
          else {
            nuevaNC.Fecha = fechaImp.Value.Date;
            nuevaNC.Hora = fechaImp.Value.TimeOfDay;
          }

          // Pie de la nota de credito
          const int maxLinea = 48, maxPie = 384;

          string pieFactura = Util.TruncarCadena("FS # " + item.EPK_FacturaEncabezado.IdFactura.ToString(), maxLinea) + Environment.NewLine;
          pieFactura += Util.TruncarCadena("NC # " + idNC.ToString(), maxLinea) + Environment.NewLine;
          pieFactura += Util.TruncarCadena("Cajero:" + EstadoAplicacion.UsuarioActual.Identificacion + " Caja:" + EstadoAplicacion.CajaActual.Descripcion, maxLinea) + Environment.NewLine;
          pieFactura = Util.TruncarCadena(pieFactura, maxPie);
          pieFactura = Util.StripAccents(pieFactura);

          // Se cierra el comprobante
          if (!impresora.FinalizarCierreComprobante(pieFactura)) {
            impresora.AnularComprobante();
            new NotasCredito().Anular(idNC);
            MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
          }

          nuevaNC.IdEstatus = EstadoAplicacion.EstadosNC["NCEmitida"];
          new NotasCredito().Actualizar(nuevaNC);

          item.IdEstatus = EstadoAplicacion.EstadosNC["NCEmitida"];
          item.IdNCTienda = idNC;
          item.TicketFiscalTienda = nuevaNC.TicketFiscal;
          item.COO = nuevaNC.COO;
          item.Fecha = nuevaNC.Fecha;
          item.Hora = nuevaNC.Hora;
          item.NroReporteZ = nuevaNC.NroReporteZ;
          item.IdUsuarioModificacion = IdUsuarioAut > 0 ? IdUsuarioAut : EstadoAplicacion.UsuarioActual.IdUsuario;

          new NotasCredito().ActualizarSolicitud(item);

          if (ListClienteCompraNC.Count>0)
            new ClienteCompra().SaveCompras(ListClienteCompraNC);// Se guarda en BD el Colection de Clientes Compras

          MessageBox.Show(string.Format("Nota de Crédito #{0} generada con éxito", idNC), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) {
          new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          MessageBox.Show(Properties.Resources.MsgErrorGenComp, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return true;
        }
        finally {
          this.Cursor = Cursors.Default;
        }
      }

      return false;
    }

    private void RefrescarArticulosFactura()
    {
      decimal IVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

      foreach (ItemsFactura itemF in this._itemsFactura) {
        decimal precioNetoArt = 0, montoIVA = 0, montoDescuento = 0;
        if (EstadoAplicacion.AplicaImpuesto && !itemF.Exento) {
          montoDescuento = Util.TruncarDecimal(itemF.PrecioBase * this._porcDescuento / 100, 2);
          montoIVA = Math.Round((itemF.PrecioBase - montoDescuento) * IVA / 100, 2);
          precioNetoArt = itemF.PrecioBase - montoDescuento + montoIVA;
        }
        else {
          montoDescuento = Util.TruncarDecimal(itemF.PrecioBase * this._porcDescuento / 100, 2);
          precioNetoArt = itemF.PrecioBase - montoDescuento;
        }

        itemF.MontoIVA = montoIVA;
        itemF.PrecioNeto = precioNetoArt;
        itemF.MontoDescuento = Util.TruncarDecimal(montoDescuento * itemF.Cantidad, 2);
        itemF.PrecioVenta = Util.TruncarDecimal(precioNetoArt * itemF.Cantidad, 2);
        itemF.Descuento = (this._porcDescuento > 0);
      }
    }

    private void SeleccionarVendedor(string Action)
    {
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, Action))
        {
            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = Properties.Resources.MsgAutorizarSelVendedor;
            fAut.NombreTecnico = this.Name;
            fAut.Accion = Action;
            fAut.ShowDialog();

            if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                return;

            this._autorizador = fAut.UsuarioAutorizador;
        }

        frmBuscarVendedor fBVend = new frmBuscarVendedor();
        fBVend.ShowDialog();

        if (fBVend.DialogResult != System.Windows.Forms.DialogResult.OK || fBVend.VendedorSel == null)
            return;

        this._vendedor = fBVend.VendedorSel;
        this.btSelVendedor.Text = String.Format("Vendedor: {0} {1}", this._vendedor.Nombre, this._vendedor.Apellido);

        int cantDev = this._itemsFactura.Where(i => i.Devolucion).Count();

        decimal MaxDenominacion = new Denominacion().ObtenerMax();

        if (EstadoAplicacion.TemporadaComision && this._saldo == 0 && this._itemsFactura.Count() > 0 && (this._cambio <= MaxDenominacion) && (this._totalFactura > 0 || (this._totalFactura == 0 && cantDev > 0)) && (this._vendedor != null && EstadoAplicacion.TemporadaComision))
        {
            this.btProcesar.Enabled = true;
            this.btProcesar.Focus();
        }
        else
        {
            this.txCodArt.Focus();
        }
    }


    /// <summary>
    /// Funcion que permite validar que el articulo que se va a agregar este disponible para su facturación y 
    /// que las cantidades a agregar esten permitidas segun lo establecido con la ley
    /// </summary>
    /// <param name="IdArticulo"> Id de Artículo a agregar</param>
    /// <param name="CodArticulo">Código de Artículo a agregar</param>
    /// <param name="Cantidad"> Cantidad de Artículos que se van a agregar</param>
    /// <param name="Pregunta"> Bit que indica si se esta agregando un artículo o editando la cantidad</param>
    /// <returns></returns>
    private bool? ValidarAticulo(int IdArticulo, string CodArticulo, int Cantidad, bool Pregunta=false)
    {
        bool? result = true;       
        try
        {

            EPK_Articulo Articulo = new Articulos().Obtener(IdArticulo);

            #region Valida que aplique la restricción

            if (!Articulo.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta)
                return true;

            if (this.SkipRule)
                return true;

            #endregion

            int CantArtCompra = this._clienteCompras.Where(p => p.IdArticulo == IdArticulo &&
                                                           p.IdTipoDocumento == this._cliente.IdTipoDocumento &&
                                                           p.NumeroDocumento == this._cliente.NumeroDocumento).Sum(p => p.Cantidad);

            int CantArtActual = this._itemsFactura.Where(p => p.IdArticulo == IdArticulo).Sum(p => p.Cantidad);
            int CantArtDev = this._itemsFactura.Where(p => p.IdArticulo == IdArticulo && p.Devolucion).Sum(p => p.Cantidad);
            int MaxArticulos = Util.ObtenerParametroEntero("MaximoArticulo");
            int HolguraDevolucion = Util.ObtenerParametroEntero("HolguraDevolucion");
            int MaxPiezas = Util.ObtenerParametroEntero("MaximoPiezas");
            int TotalActual = this._itemsFactura.Where(p => p.IdArticulo != IdArticulo && !p.Devolucion && p.AplicaRestriccion).Sum(p => p.Cantidad);
            int TotalDev = this._itemsFactura.Where(p => p.Devolucion && p.AplicaRestriccion).Sum(p => p.Cantidad);
            int TotalCompras = this._clienteCompras.Sum(p => p.Cantidad);

            //Las devoluciones no pueden ser mayores a lo que se esta llevando
            TotalDev = TotalDev > MaxPiezas ? MaxPiezas : TotalDev;
            CantArtDev = CantArtDev > MaxArticulos ? MaxArticulos : CantArtDev;

            #region Valida Bloqueo del Articulo

            if (Articulo.FechaFinBloqueo != null && Articulo.FechaInicioBloqueo != null)
            {
                if (DateTime.Now >= Articulo.FechaInicioBloqueo && DateTime.Now <= Articulo.FechaFinBloqueo && (Cantidad >= MaxArticulos))
                {
                    MessageBox.Show(string.Format(Properties.Resources.MsgArticuloBloqueado, MaxArticulos, CodArticulo),
                                       "Advertencia - " + this.Text,
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            #endregion

            #region Valida Cantidad de Articulos y Piezas

            if (Cantidad > MaxArticulos)
            {
                MessageBox.Show(string.Format(Properties.Resources.MsgMaxCantidadArt, Cantidad, CodArticulo, MaxArticulos),
                                "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            int CompVsDev = TotalCompras - TotalDev;
            CompVsDev = CompVsDev < 0 ? 0 : CompVsDev; //Se evita que las devoluciones superen a las compras y se pueda llevar mas Art. de lo permitido

            int HolguraPiezas = (this._totalFactura < 0 && TotalCompras == MaxPiezas && TotalDev >= 1) ? HolguraDevolucion : 0;

            if (TotalActual + Cantidad + CompVsDev - HolguraPiezas > MaxPiezas)
            {
                if (TotalCompras >= MaxPiezas && HolguraPiezas == 0 && Pregunta)
                {
                    if (MessageBox.Show(string.Format(Properties.Resources.MsgMaximoPiezasPreg, Util.GenDocCliente(this._cliente), MaxPiezas),
                                                      "Advertencia - " + this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool TieneDev = new Facturas().TieneDevoluciones(this._cliente.IdTipoDocumento, this._cliente.NumeroDocumento);

                        if (TieneDev)
                        {
                            NotificationManager.Show(this, string.Format(Properties.Resources.MsgMaxDevoluciones, Util.GenDocCliente(this._cliente)),
                                             Color.Red, EstadoAplicacion.ToastTimeout);
                            return false;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                        return false;
                }
                else
                {
                    NotificationManager.Show(this, string.Format(Properties.Resources.MsgMaximoPiezas, Util.GenDocCliente(this._cliente), MaxPiezas),
                             Color.Red, EstadoAplicacion.ToastTimeout);
                    return false;
                }
            }
            if (CantArtCompra - CantArtDev >= MaxArticulos)
                Pregunta = true;
            if ((CantArtCompra - CantArtDev >= MaxArticulos) && Pregunta)
            {
                
                if (MessageBox.Show(string.Format(Properties.Resources.MsgMaximoArticulosPreg, Util.GenDocCliente(this._cliente), MaxArticulos, CodArticulo),
                                   "Advertencia - " + this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    return null;
                else
                    return false;
            }

            if (Cantidad + CantArtCompra - CantArtDev > MaxArticulos)
            {
                int Dif = MaxArticulos - CantArtCompra;
                Dif = Dif < 0 ? 0 : Dif;

                MessageBox.Show(string.Format(Properties.Resources.MsgMaximoArticulos, Util.GenDocCliente(this._cliente), CantArtCompra, CodArticulo, Dif),
                                "Advertencia - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            #endregion

            return result;
        }
       


        catch(Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
            MessageBox.Show(Properties.Resources.MsgErrorValArt, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }
    }

    #endregion Private Methods

  }
}