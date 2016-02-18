using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmAutorizar : Form
  {

    #region Public Properties

    public bool Obligatoria { get; set; }

    public bool Autorizado { get; private set; }
    public EPK_Usuario UsuarioAutorizador { get; private set; }

    public string Mensaje { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }

    public string NombreTecnico { get; set; }
    public string Accion { get; set; }

    public bool ExigirObservacion { get; set; }
    public string Observacion { get; set; }

    #endregion

    #region Constructor

    public frmAutorizar()
    {
      InitializeComponent();

      this.UsuarioAutorizador = null;
    }

    #endregion

    #region Events

    private void frmAutorizar_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.Autorizado = false;
      this.txMensaje.Text = this.Mensaje;

      if (this.Obligatoria) {
        this.btCancel.Visible = false;
        this.btOK.Location = this.btCancel.Location;
      }

      if (string.IsNullOrEmpty(Login)) {
        this.txLogin.Text = this.txPassword.Text = string.Empty;
        this.txLogin.Focus();
      }
      else {
        this.txLogin.Text = Login;
        this.txLogin.Enabled = false;
        this.txPassword.Text = string.Empty;
        this.txPassword.Focus();
      }

      if (this.ExigirObservacion)
      {
          this.lbObservacion.Visible = true;
          this.txObservacion.Visible = true;
      }

    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txLogin, "");
      this.errorProvider1.SetError(this.txPassword, "");
      this.errorProvider1.SetError(this.txObservacion, "");

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

      if (string.IsNullOrEmpty(this.txObservacion.Text.Trim()) && this.ExigirObservacion){
          this.errorProvider1.SetError(this.txObservacion, Properties.Resources.ValIngreseObs);
          this.txObservacion.Focus();
          return;
      }


      if (this.txObservacion.TextLength < 10 && this.ExigirObservacion) {
          this.errorProvider1.SetError(this.txObservacion, string.Format(Properties.Resources.ValMinCar, 10));
          this.txObservacion.Focus();
          return;
      }

      this.Cursor = Cursors.WaitCursor;

      string login = this.txLogin.Text.Trim();
      string passwd = this.txPassword.Text.Trim();

      KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(login, passwd);

      if (result.Key == null) {
        MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        return;
      }

      if (!string.IsNullOrEmpty(this.NombreTecnico) && !string.IsNullOrEmpty(this.Accion)) {
        if (!new Accesos(true).EsAutorizadorAccion(result.Key.IdUsuario, this.NombreTecnico, this.Accion)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

          // Log Auditoria
          new NLogLogger().Error(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login));

          this.Cursor = Cursors.Default;
          return;
        }
      }

      // Log Auditoria
      new NLogLogger().Info(string.Format("Autorizado por: {0}, Acción: {1}, Nombre Técnico: {2}. {3}", result.Key.Login, this.Accion, this.NombreTecnico, this.Mensaje));

      this.Cursor = Cursors.Default;
      this.UsuarioAutorizador = result.Key;

      this.Autorizado = true;
      this.Login = txLogin.Text;
      this.Password = txPassword.Text;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Observacion = txObservacion.Text;

      this.FormClosing -= new FormClosingEventHandler(this.frmAutorizar_FormClosing);
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Autorizado = false;

      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

      // Log Auditoria
      new NLogLogger().Info(string.Format("Acción: {0}, Nombre Técnico: {1}. {2}", this.Accion, this.NombreTecnico, this.Mensaje));

      this.Close();
    }

    private void frmAutorizar_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = this.Obligatoria;
    }

    private void frmAutorizar_Activated(object sender, EventArgs e)
    {
      this.Text = "Autorización - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion


  }
}
