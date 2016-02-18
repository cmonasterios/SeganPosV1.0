using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmContingencia : Form
  {

    #region Private Properties

    //private int ultimaF { get; set; }

    #endregion

    #region Constructor

    public frmContingencia()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmContingencia_Load(object sender, EventArgs e)
    {
      this.Text = this.Text + " - " + Application.ProductName;

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.AgregarToolTips();

      if (EstadoAplicacion.CajaActual == null)
        EstadoAplicacion.CargarCaja();

      if (EstadoAplicacion.CajaActual != null) {
        EPK_Contingencia datosCont = Util.ValoresContingencia();
        datosCont.IdCaja = EstadoAplicacion.CajaActual.IdCaja;
        new Contingencia().Actualizar(datosCont);
      }

      this.txLogin.Text = this.txPassword.Text = string.Empty;

      this.CargarDatos();

      this.BringToFront();
      this.TopMost = true;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txLogin, "");
      this.errorProvider1.SetError(this.txPassword, "");

      if (string.IsNullOrEmpty(this.txLogin.Text.Trim())) {
        this.errorProvider1.SetError(this.txLogin, Properties.Resources.ValIngreseUsuario);
        this.txLogin.Focus();
        return;
      }

      if (string.IsNullOrEmpty(this.txPassword.Text.Trim())) {
        this.errorProvider1.SetError(this.txPassword, Properties.Resources.ValIngresePassword);
        this.txPassword.Focus();
        return;
      }

      this.Cursor = Cursors.WaitCursor;

      string login = this.txLogin.Text.Trim();
      string passwd = this.txPassword.Text.Trim();

      new Usuarios(true).LimpiarSesiones();

      KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(login, passwd);

      if (result.Key == null) {
        MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        this.txPassword.Focus();
        return;
      }

      int vCont = new Parametros(true).ObtenerValorEntero("Contingencia");

      if (vCont == (int)EstadoContingencia.Normal || vCont == (int)EstadoContingencia.Regreso) {
        MessageBox.Show(Properties.Resources.MsgErrorParamCont, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        return;
      }

      List<CajaContingencia> datos = new Contingencia().ObtenerTodas();

      int ultimaF = 0, ultimoP = 0, ultimaNC = 0, ultimoC = 0, ultimoCV = 0;
      long ultimaAp = 0, ultimoAl = 0, ultimoCC = 0;

      if (datos.Count() > 0) {
        ultimaF = datos.Max(d => d.UltimaFactura);
        ultimoP = datos.Max(d => d.UltimoPago);
        ultimaNC = datos.Max(d => d.UltimaNC);
        ultimoC = datos.Max(d => d.UltimoCliente);
        ultimaAp = datos.Max(d => d.UltimaApertura);
        ultimoAl = datos.Max(d => d.UltimoAlivio);
        ultimoCC = datos.Max(d => d.UltimoCierreCajero);
        ultimoCV = datos.Max(d => d.UltimoCierreVentas);
      }

      // Se validan todos los IDs antes de hacer los reseed
      if (ultimaF > 0) {
        int idFact = new Facturas(true).ObtenerUltimoId();
        if (ultimaF < idFact) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "factura", idFact.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimoP > 0) {
        int idPago = new Facturas(true).ObtenerUltimoIdPago();
        if (ultimoP < idPago) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "pago", idPago.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimaNC > 0) {
        int idNC = new NotasCredito(true).ObtenerUltimoId();
        if (ultimaNC < idNC) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "nota de crédito", idNC.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimoC < 0) {
        int idCliente = new Clientes(true).ObtenerUltimoId();
        if (ultimoC < idCliente) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "cliente", idCliente.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimaAp > 0) {
        long idApertura = new AperturaCajero(true).ObtenerUltimoId();
        if (ultimaAp < idApertura) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "apertura", idApertura.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimoAl > 0) {
        long idAlivio = new AlivioEfectivo(true).ObtenerUltimoId();
        if (ultimoAl < idAlivio) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "alivio", idAlivio.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimoCC > 0) {
        long idCierreC = new CierreCajero(true).ObtenerUltimoId();
        if (ultimoCC < idCierreC) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "cierre de cajero", idCierreC.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }
      }

      if (ultimoCV > 0) {
        long idCierreV = new CierreVentas(true).ObtenerUltimoId();
        if (ultimoCV < idCierreV) {
          MessageBox.Show(string.Format(Properties.Resources.ValNumeroReseed, "cierre de ventas", idCierreV.ToString()), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      }

      // Se ejecutan todos los reseed, sólo si el nuevo valor es mayor a cero
      if (ultimaF > 0)
        if (!new Facturas(true).ReSeed(ultimaF)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "factura"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimoP > 0)
        if (!new Facturas(true).ReSeedPago(ultimoP)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "pago"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimaNC > 0)
        if (!new NotasCredito(true).ReSeed(ultimaNC)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "nota de crédito"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimoC < 0)
        if (!new Clientes(true).ReSeed(ultimoC)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "cliente"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimaAp > 0)
        if (!new AperturaCajero(true).ReSeed(ultimaAp)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "apertura"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimoAl > 0)
        if (!new AlivioEfectivo(true).ReSeed(ultimoAl)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "alivio"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimoCC > 0)
        if (!new CierreCajero(true).ReSeed(ultimoCC)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "cierre de cajero"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

      if (ultimoCV > 0)
        if (!new CierreVentas(true).ReSeed(ultimoCV)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgErrorReseed, "cierre de ventas"), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }


      if (!new Parametros(true).AsignarEntero("Contingencia", (int)EstadoContingencia.Activa)) {
        MessageBox.Show(Properties.Resources.MsgErrorParamCont, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        return;
      }

      EstadoAplicacion.SetContingencia(EstadoContingencia.Activa);

      new Usuarios(true).LimpiarSesiones();

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
      Environment.Exit(0);
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
      Environment.Exit(0);
    }

    private void frmContingencia_Shown(object sender, EventArgs e)
    {
      this.tmRefresh.Enabled = true;
      this.txLogin.Focus();
    }

    private void txLogin_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txPassword_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void upFactura_Enter(object sender, EventArgs e)
    {
      ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void btRefrescar_Click(object sender, EventArgs e)
    {
      this.CargarDatos();
    }

    private void frmContingencia_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Shift || e.Alt || e.Control)
        return;

      switch (e.KeyCode) {
        case Keys.F5:
          this.CargarDatos();
          break;
      }
    }

    private void tmRefresh_Tick(object sender, EventArgs e)
    {
      this.CargarDatos();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      this.tmRefresh.Enabled = false;

      if (new Parametros(true).ObtenerValorEntero("Contingencia") != (int)EstadoContingencia.Espera)
        this.btCancelar_Click(this, EventArgs.Empty);

      List<CajaContingencia> datos = new Contingencia().ObtenerTodas();

      this.dgItems.DataSource = datos;
      this.dgItems.Refresh();

      int ultimaF = 0, ultimaNC = 0;

      if (datos.Count() > 0) {
        ultimaF = datos.Max(d => d.UltimaFactura);
        ultimaNC = datos.Max(d => d.UltimaNC);
      }

      this.txUltimaF.Text = ultimaF.ToString();
      this.txUltimaNC.Text = ultimaNC.ToString();

      this.tmRefresh.Enabled = true;
    }

    private void AgregarToolTips()
    {
      ToolTip dToolTip = new ToolTip();

      // Se asignan los tiempos.
      dToolTip.AutoPopDelay = 5000;
      dToolTip.InitialDelay = 1000;
      dToolTip.ReshowDelay = 500;

      // Se muestra el tooltip siempre, aunque la forma no esté activa.
      dToolTip.ShowAlways = true;

      // Se colocan los tooltips a los controles.
      dToolTip.SetToolTip(this.btRefrescar, "Refrescar (F5)");
    }

    #endregion

  }
}
