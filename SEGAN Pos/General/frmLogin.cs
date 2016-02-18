using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmLogin : Form
  {

    #region Public Properties

    public bool Desbloqueo { get; set; }

    #endregion

    #region Constructor

    public frmLogin()
    {
      InitializeComponent();
    }

    public frmLogin(bool desbloqueo)
    {
      InitializeComponent();

      this.Desbloqueo = desbloqueo;
    }

    #endregion

    #region Events

    private void btCambioUsuario_Click(object sender, EventArgs e)
    {
      if (EstadoAplicacion.Contingencia == EstadoContingencia.Espera) {
        this.Close();
        Environment.Exit(0);
        return;
      }

      this.TopMost = false;

      if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, ((Button)sender).Tag.ToString())) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutorizarDesbloq;
        fAut.NombreTecnico = this.Name;
        fAut.Accion = ((Button)sender).Tag.ToString();
        fAut.ShowDialog();

        if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado) {
          this.TopMost = true;
          return;
        }
      }

      /*EPK_AperturaCajeroEncabezado _apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario);

      if (_apertura != null) {
        frmCierreCajero fCierre = new frmCierreCajero();
        fCierre.ShowDialog();
        if (fCierre.DialogResult != System.Windows.Forms.DialogResult.OK) {
          this.TopMost = true;
          return;
        }
      }*/

      this.DialogResult = System.Windows.Forms.DialogResult.Abort;
      this.FormClosing -= new FormClosingEventHandler(this.frmLogin_FormClosing);
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      if (EstadoAplicacion.UsuarioActual != null)
        EstadoAplicacion.SetUsuarioActual(null);

      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      ((Button)sender).Enabled = this.btCancel.Enabled = this.btCambioUsuario.Enabled = false;

      if (EstadoAplicacion.Contingencia == EstadoContingencia.Espera) {
        this.Close();
        Environment.Exit(0);
        return;
      }

      bool result = false;

      if (this.Desbloqueo)
        result = this.DoUnlock();
      else
        result = this.DoLogin();

      Util.ClearMessages();

      if (result) {
        Util.VerificarValoresContingencia();

        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.FormClosing -= new FormClosingEventHandler(this.frmLogin_FormClosing);
        this.Close();
      }

      ((Button)sender).Enabled = this.btCancel.Enabled = this.btCambioUsuario.Enabled = true;
    }

    private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (EstadoAplicacion.Contingencia == EstadoContingencia.Espera) {
        this.Close();
        Environment.Exit(0);
        return;
      }

      e.Cancel = this.Desbloqueo;
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (this.Desbloqueo && EstadoAplicacion.UsuarioActual != null) {
        this.Text = "Desbloquear Sesión - " + Application.ProductName;
        this.ShowInTaskbar = false;
        this.BringToFront();
        this.TopMost = true;

        this.btCancel.Visible = false;
        this.btOK.Location = this.btCancel.Location;
        this.btCambioUsuario.Visible = true;

        this.txLogin.Text = EstadoAplicacion.UsuarioActual.Login;
        this.txLogin.Enabled = false;
        this.txPassword.Focus();
      }
      else {
        //EstadoAplicacion.CargarTienda();
        //this.backgroundWorkerBio.RunWorkerAsync();

        this.Text = "Inicio de Sesión - " + Application.ProductName;
        this.txLogin.Text = this.txPassword.Text = string.Empty;
        this.txLogin.Enabled = true;
        this.txLogin.Focus();
      }
    }

    private void txLogin_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txPassword_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void backgroundWorkerBio_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        DAL.Biometrico Bio = new DAL.Biometrico();

        try
        {
            EPK_Terminal Terminal = new Terminales().GetByTienda();

            Bio.DireccionIP = Terminal.DireccionIP;
            Bio.Puerto = Terminal.Puerto ?? 0;//crear param
            Bio.Modelo = Terminal.Modelo != null ? (int)Terminal.Modelo : 1;
            Bio.IdRegion = Terminal.IdRegion;
            Bio.IdLocalidad = Terminal.IdLocalidad;
            Bio.IdTerminal = Terminal.IdTerminal;
            Bio.NumeroDeMaquina = 1;
            Bio.FechaUltAct = DateTime.Today.AddDays(-3);

            Bio.ConectarBioTrack();

            Bio.ObtenerCaracteristicas();

            Bio.GetLecturas();            
        }
        catch
        {
            MessageBox.Show(Properties.Resources.MsgErrorCargarBiometrico, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        { 
            if(Bio.Conectado)
                Bio.DesconectarBioTrack();
        }
    }

    #endregion

    #region Private Methods

    private bool DoLogin()
    {
      this.errorProvider1.SetError(this.txLogin, "");
      this.errorProvider1.SetError(this.txPassword, "");

      if (string.IsNullOrEmpty(this.txLogin.Text.Trim())) {
        this.errorProvider1.SetError(this.txLogin, Properties.Resources.ValIngreseUsuario);
        this.txLogin.Focus();
        return false;
      }

      if (string.IsNullOrEmpty(this.txPassword.Text.Trim())) {
        this.errorProvider1.SetError(this.txPassword, Properties.Resources.ValIngresePassword);
        this.txPassword.Focus();
        return false;
      }

      try {
        this.Cursor = Cursors.WaitCursor;

        /*if (!new Usuarios().VerificarConexion()) {
          MessageBox.Show("No hay conexion con la DB", "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }*/

        string login = this.txLogin.Text.Trim();
        string passwd = this.txPassword.Text.Trim();

        if (!EstadoAplicacion.CargarTienda()){
            MessageBox.Show(Properties.Resources.ErrorCargaTienda, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Cursor = Cursors.Default;
            this.txPassword.Text = string.Empty;
            this.txLogin.Focus();
            return false;
        }
          
        if (!EstadoAplicacion.CargarParametros()) {
            MessageBox.Show(Properties.Resources.MsgErrorCargaInicial, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Cursor = Cursors.Default;
            this.txPassword.Text = string.Empty;
            this.txLogin.Focus();
            return false;
        }

        if (!EstadoAplicacion.CargarCaja() && !EstadoAplicacion.SkipValidation) {
          MessageBox.Show(Properties.Resources.ErrorCargaFacturacion, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }

        KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(login, passwd, false);

        if (result.Key == null) {
          MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txPassword.Focus();
          return false;
        }

        EPK_Usuario usuarioActual = result.Key;

        if (!EstadoAplicacion.CargarEstatus() && !EstadoAplicacion.SkipValidation) {
          MessageBox.Show(Properties.Resources.ErrorCargaFacturacion, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }

        if (!EstadoAplicacion.CargaInicial()) {
          MessageBox.Show(Properties.Resources.ErrorCargaFacturacion, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }

        string Error = EstadoAplicacion.ValidarConfigImpuestos();
        if (!string.IsNullOrEmpty(Error))
        {
            MessageBox.Show(Error, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Cursor = Cursors.Default;
            this.txPassword.Text = string.Empty;
            this.txLogin.Focus();
            return false;
        }

        if (EstadoAplicacion.CajaActual == null && !EstadoAplicacion.SkipValidation) {
          MessageBox.Show(Properties.Resources.MsgErrorSinCaja, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }

        //if (!EstadoAplicacion.TieneImpresora && !EstadoAplicacion.SkipValidation) {
        //  MessageBox.Show(Properties.Resources.MsgErrorSinImpresora, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //  this.txPassword.Text = string.Empty;
        //  this.txLogin.Focus();
        //  this.Cursor = Cursors.Default;
        //  return false;
        //}

        EstadoAplicacion.SetUsuarioActual(usuarioActual);

        EstadoAplicacion.SetSerialImpresora(new Impresora().Serial);

        this.Cursor = Cursors.Default;

#if !DEBUG
        int vigencia = Util.ObtenerParametroEntero("VIGENCIA_CLAVE");
        DateTime currDate = new DataAccess(true).FechaDB();
        if (EstadoAplicacion.UsuarioActual.ReqPassChange || (vigencia > 0 && Math.Abs((usuarioActual.LastPassChange - currDate).TotalDays) > vigencia)) {
          frmCambioClave fCambioClave = new frmCambioClave();
          fCambioClave.ShowDialog();
          if (fCambioClave.DialogResult != System.Windows.Forms.DialogResult.OK)
            Environment.Exit(0);
        }
#endif

        if (ConfigurationManager.AppSettings["VersionBaseDatos"].ToString() != Util.ObtenerParametroCadena("VersionBaseDatos")) {
          MessageBox.Show("La versión de Base de Datos es incorrecta.", "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return false;
        }

        return true;
      }
      catch (Exception ex) {
        this.Cursor = Cursors.Default;
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show(Properties.Resources.MsgErrorLogin, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return false;
    }

    private bool DoUnlock()
    {
      this.errorProvider1.SetError(this.txPassword, "");

      if (string.IsNullOrEmpty(this.txPassword.Text.Trim())) {
        this.errorProvider1.SetError(this.txPassword, Properties.Resources.ValIngresePassword);
        this.txPassword.Focus();
        return false;
      }

      try {
        this.Cursor = Cursors.WaitCursor;

        string login = EstadoAplicacion.UsuarioActual.Login;
        string passwd = this.txPassword.Text.Trim();

        KeyValuePair<EPK_Usuario, string> result = new Usuarios().Validar(login, passwd);

        if (result.Key == null) {
          MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          this.txPassword.Text = string.Empty;
          this.txLogin.Focus();
          return false;
        }

        this.Cursor = Cursors.Default;

        return true;
      }
      catch (Exception ex) {
        this.Cursor = Cursors.Default;
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show(Properties.Resources.MsgErrorLogin, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      return false;
    }

    #endregion

  }
}
