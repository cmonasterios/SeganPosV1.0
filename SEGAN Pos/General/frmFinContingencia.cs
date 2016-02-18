using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmFinContingencia : Form
  {

    #region Constructor

    public frmFinContingencia()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmFinContingencia_Load(object sender, EventArgs e)
    {
      this.Text = this.Text + " - " + Application.ProductName;

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.txLogin.Text = this.txPassword.Text = string.Empty;

      this.BringToFront();
      this.TopMost = true;
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
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

      if (!new DataAccess().VerificarConexion("SEGANPOSEntities")) {
        MessageBox.Show(Properties.Resources.MsgErrorConexPrinc, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        this.txLogin.Focus();
        return;
      }

      if (!new Parametros(true).AsignarEntero("Contingencia", (int)EstadoContingencia.Regreso)) {
        MessageBox.Show(Properties.Resources.MsgErrorFinCont, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        return;
      }

      EstadoAplicacion.SetContingencia(EstadoContingencia.Normal);

      new Usuarios(true).LimpiarSesiones();

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void frmFinContingencia_Shown(object sender, EventArgs e)
    {
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

    #endregion

  }
}
