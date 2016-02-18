using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmAliviarEfectivo : Form
  {

    #region Private Properties

    private decimal _montoAlivio { get; set; }
    private decimal _montoSistema { get; set; }
    private decimal _diferencia { get; set; }

    private BindingList<DenominacionAlivio> _listDenominacionAlivio { get; set; }

    #endregion

    #region Constructor

    public frmAliviarEfectivo()
    {
      InitializeComponent();

      this._montoAlivio = this._montoSistema = this._diferencia = 0;
    }

    #endregion

    #region Events

    private void frmAliviarEfectivo_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (new CierreCajero().TienePendiente(EstadoAplicacion.UsuarioActual.IdUsuario)) {
        MessageBox.Show(Properties.Resources.MsgCierreCajPendAli, "Error - Alivio de Efectivo",
          MessageBoxButtons.OK, MessageBoxIcon.Warning);
        this.FormClosing -= new FormClosingEventHandler(this.frmAliviarEfectivo_FormClosing);
        this.DialogResult = DialogResult.Cancel;
        this.Close();
        return;
      }

      this.CargarDatos();

      if (this._montoSistema <= 0) {
        MessageBox.Show(Properties.Resources.MsgAlivioSinEfectivo, "Error - Alivio de Efectivo",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.FormClosing -= new FormClosingEventHandler(this.frmAliviarEfectivo_FormClosing);
        this.DialogResult = DialogResult.Cancel;
        this.Close();
        return;
      }

      if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Visualizar")) 
      {
          txtMontoSistema.PasswordChar = 'x';
          txtDiferencia.PasswordChar ='x';
      }

    }

    private void btOK_Click(object sender, EventArgs e)
    {
      ((Button)sender).Enabled = false;
      Cursor.Current = Cursors.WaitCursor;

      long idAlivio = this.GuardarAlivio();

      Util.ClearMessages();
      Cursor.Current = Cursors.Default;

      if (idAlivio <= 0) {
        MessageBox.Show("Se produjo un error creando el alivio de efectivo", Application.ProductName);
        ((Button)sender).Enabled = true;
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void grdDenominacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmAliviarEfectivo_Shown(object sender, EventArgs e)
    {
      if (new CierreVentas().Obtener() != null) {
        MessageBox.Show(Properties.Resources.MsgCierreVentaExiste, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.FormClosing -= new FormClosingEventHandler(this.frmAliviarEfectivo_FormClosing);
        this.Close();
        return;
      }

      if (!Util.VerificarImpresora("frmFacturar")) {
        this.FormClosing -= new FormClosingEventHandler(this.frmAliviarEfectivo_FormClosing);
        this.Close();
        return;
      }

      new Impresora().AbrirGaveta();
    }

    private void grdDenominacion_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void grdDenominacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DenominacionAlivio itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionAlivio);

      if (itemSel == null)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;
      fCant.ValorMaximo = short.MaxValue;
      fCant.Cantidad = itemSel.Cantidad;
      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      if (fCant.Cantidad == itemSel.Cantidad)
        return;

      itemSel.Cantidad = (short)fCant.Cantidad;
      itemSel.TotalXDenominacion = itemSel.Denominacion * itemSel.Cantidad;

      ((DataGridView)sender).Refresh();

      this.CalcularTotal();
    }

    private void frmAliviarEfectivo_Activated(object sender, EventArgs e)
    {
      this.Text = "Alivio de Efectivo de " + EstadoAplicacion.UsuarioActual.Identificacion + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmAliviarEfectivo_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (new Impresora().GavetaAbierta())
        new frmGavetaAbierta().ShowDialog();
    }

    #endregion

    #region Private Methods

    private long GuardarAlivio()
    {
      long IdAlivio = 0;

      EPK_AlivioEfectivoEncabezado nuevoAlivio = new EPK_AlivioEfectivoEncabezado();

      nuevoAlivio.IdUsuarioCajero = EstadoAplicacion.UsuarioActual.IdUsuario;
      nuevoAlivio.TotalAlivio = this._montoAlivio;
      nuevoAlivio.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
      nuevoAlivio.TotalPagosEfectivo = this._montoSistema;
      nuevoAlivio.IdCaja = EstadoAplicacion.CajaActual.IdCaja;

      nuevoAlivio.EPK_AlivioEfectivoDetalle = this._listDenominacionAlivio.Where(lda => lda.Cantidad > 0).Select(lda => new EPK_AlivioEfectivoDetalle {
        IdDenominacion = lda.IdDenominacion,
        CantidadCajero = lda.Cantidad
      }).ToList();

      IdAlivio = new AlivioEfectivo().Nuevo(nuevoAlivio);

      if (IdAlivio > 0)
      {
          nuevoAlivio = new AlivioEfectivo().Obtener(IdAlivio);
          /*
           Esta sección permite determinar si la impresora se encuentra línea
           puede imprimir el comprobante de alivio en caso de mantenerse el estatus
           fuera de línea el alivio de efectivo ya se encuentra registrado en sistema.
           */
          Impresora impresora = new Impresora();

          int impLinea = impresora.EnLinea();

          if (string.IsNullOrEmpty(impresora.Serial))
          {
              while (MessageBox.Show(Properties.Resources.MsgImpNoResp, "Error de Impresora", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
              {
                  impLinea = impresora.Refrescar();
                  if (!string.IsNullOrEmpty(impresora.Serial))
                  {
                      break;
                  }
              }

              impresora.ImprimirComprobanteAlivio(nuevoAlivio, this._diferencia);
          }
      }

      return IdAlivio;
    }

    private void CargarDatos()
    {
      EPK_AlivioEfectivoEncabezado ultimoAlivio = new AlivioEfectivo().BuscarUltimoAlivio(EstadoAplicacion.UsuarioActual.IdUsuario);;

      DateTime fechaUltCierre = DateTime.Now;
      DateTime fechaIniNuevoCierre = DateTime.Now.AddSeconds(-1);

      EPK_CierreCajeroEncabezado ultimoCierre = new CierreCajero().ObtenerUltimo(EstadoAplicacion.UsuarioActual.IdUsuario);

        if(ultimoCierre!=null)
        {
            fechaUltCierre = ultimoCierre.Fecha;
            fechaUltCierre = fechaUltCierre.Date + ultimoCierre.Hora;
        }
        else
            fechaUltCierre = DateTime.Now.Date;

      EPK_FacturaEncabezado primeraFactura = new Facturas().ObtenerPrimera(EstadoAplicacion.UsuarioActual.IdUsuario, fechaUltCierre);

      if(primeraFactura!=null)
          fechaIniNuevoCierre = primeraFactura.FechaCreacion;

      decimal MontoFacturado = new Facturas().MontoPendiente(EstadoAplicacion.UsuarioActual.IdUsuario, fechaIniNuevoCierre);
      decimal TotalAlivioAprobado = new AlivioEfectivo().TotalAprobados(EstadoAplicacion.UsuarioActual.IdUsuario, fechaIniNuevoCierre);
      decimal TotalAlivioPendiente = new AlivioEfectivo().TotalPendientes(EstadoAplicacion.UsuarioActual.IdUsuario, fechaIniNuevoCierre);

      this.txCajero.Text = EstadoAplicacion.UsuarioActual.Identificacion;
      this._montoSistema = MontoFacturado - TotalAlivioAprobado - TotalAlivioPendiente;
      this.txtMontoSistema.Text = string.Format("{0:C2}", this._montoSistema);

      this.txCaja.Text = EstadoAplicacion.CajaActual.Descripcion;

      if (ultimoAlivio != null) {
        this.txtControlAlivio.Text = ultimoAlivio.IdAlivioEfectivo.ToString();
        DateTime fechaUltAlivio = ultimoAlivio.FechaAlivio + ultimoAlivio.HoraAlivio;
        this.txtFechaUltimoAlivio.Text = fechaUltAlivio.ToString("g");
      }
      else
        this.txtControlAlivio.Text = "0";

      IEnumerable<EPK_Denominacion> denominaciones = new Denominacion().ObtenerTodas();

      this._listDenominacionAlivio = new BindingList<DenominacionAlivio>(denominaciones.Select(d => new DenominacionAlivio {
        IdDenominacion = d.IdDenominacion,
        Denominacion = d.Denominacion,
        Logo = d.Logo,
        Cantidad = 0,
        TotalXDenominacion = 0
      }).ToList());

      this.grdDenominacion.DataSource = _listDenominacionAlivio;
    }

    private void CalcularTotal()
    {
      this._montoAlivio = this._listDenominacionAlivio.Sum(lda => lda.Denominacion * lda.Cantidad);
      this._diferencia = this._montoSistema - this._montoAlivio;

      this.txtMontoAlivio.Text = string.Format("{0:C2}", this._montoAlivio);
      this.txtDiferencia.Text = string.Format("{0:C2}", this._diferencia);

      this.btOK.Enabled = (this._montoAlivio != 0);
    }

    #endregion

  }
}
