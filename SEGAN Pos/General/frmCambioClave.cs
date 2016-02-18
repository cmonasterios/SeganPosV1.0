using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmCambioClave : Form
  {

    #region Constructor

    public frmCambioClave()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmCambioClave_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.lbUsuario.Text = EstadoAplicacion.UsuarioActual.Identificacion + " (" + EstadoAplicacion.UsuarioActual.Login + ")";

      this.txOldPass.Text = this.txNewPass.Text = this.txNewPassConfirm.Text = string.Empty;
      this.txOldPass.Focus();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txOldPass, "");
      this.errorProvider1.SetError(this.txNewPass, "");
      this.errorProvider1.SetError(this.txNewPassConfirm, "");

      if (string.IsNullOrEmpty(this.txOldPass.Text.Trim())) {
        this.errorProvider1.SetError(this.txOldPass, Properties.Resources.ValIngresePassActual);
        this.txOldPass.Focus();
        return;
      }

      if (string.IsNullOrEmpty(this.txNewPass.Text.Trim())) {
        this.errorProvider1.SetError(this.txNewPass, Properties.Resources.ValIngreseNuevoPass);
        this.txNewPass.Focus();
        return;
      }

      if (string.IsNullOrEmpty(this.txNewPassConfirm.Text.Trim())) {
        this.errorProvider1.SetError(this.txNewPassConfirm, Properties.Resources.ValRepitaNuevoPass);
        this.txNewPassConfirm.Focus();
        return;
      }

      if (this.txNewPass.Text.Trim() != this.txNewPassConfirm.Text.Trim()) {
        this.errorProvider1.SetError(this.txNewPass, Properties.Resources.ValNuevoPassNoMatch);
        this.errorProvider1.SetError(this.txNewPassConfirm, Properties.Resources.ValNuevoPassNoMatch);
        this.txNewPass.Focus();
        return;
      }

      if (this.txOldPass.Text.Trim() == this.txNewPass.Text.Trim()) {
        MessageBox.Show(Properties.Resources.MsgNuevoPassDiferente, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.txNewPass.Focus();
        return;
      }

      string valClave = this.ValidarClave(EstadoAplicacion.UsuarioActual.Login, this.txNewPass.Text.Trim());
      if (!string.IsNullOrEmpty(valClave)) {
        this.errorProvider1.SetError(this.txNewPass, Properties.Resources.ValClaveCompleja);
        this.errorProvider1.SetError(this.txNewPassConfirm, Properties.Resources.ValClaveCompleja);
        this.txNewPass.Focus();
        return;
      }

      try {
        this.Cursor = Cursors.WaitCursor;

        string passActual = this.txOldPass.Text.Trim();
        string nuevoPass = this.txNewPass.Text.Trim();
        string repNuevoPass = this.txNewPassConfirm.Text.Trim();

        KeyValuePair<EPK_Usuario, string> result = new Usuarios().Validar(EstadoAplicacion.UsuarioActual.Login, passActual);

        if (result.Key == null) {
          MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

        if (!new Usuarios().CambiarClave(result.Key.IdUsuario, nuevoPass)) {
          MessageBox.Show(Properties.Resources.MsgErrorCambioPass, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Cursor = Cursors.Default;
          return;
        }

        this.Cursor = Cursors.Default;

        MessageBox.Show(Properties.Resources.MsgCambioClaveExitoso, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        this.DialogResult = System.Windows.Forms.DialogResult.OK;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show(LogUtility.BuildExceptionMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void txOldPass_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txNewPass_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txNewPassConfirm_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void frmCambioClave_Activated(object sender, EventArgs e)
    {
      this.Text = "Cambio de Clave - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private string ValidarClave(string login, string clave)
    {
      string result = string.Empty;

      if (clave.Contains(login))
        return Properties.Resources.ValClaveNoLogin;

      if (!Regex.IsMatch(clave, @"(?=.{6,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+"))
        return Properties.Resources.ValClaveCompleja;

      return result;
    }

    #endregion

  }
}
