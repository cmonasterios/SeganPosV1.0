using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmConfig : Form
  {

    #region Constructor

    public frmConfig()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmConfig_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.Text = this.Text + " - " + Application.ProductName;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      // Limpiar errores
      foreach (Control controlItem in this.Controls)
        if (controlItem.GetType() == typeof(TextBox))
          this.errorProvider1.SetError(controlItem, "");

      this.errorProvider1.SetError(txPwd, "");
      this.errorProvider1.SetError(txServidor, "");
      this.errorProvider1.SetError(txUsr, "");
      this.errorProvider1.SetError(txDB, "");

      // Validaciones
      foreach (Control controlItem in this.Controls)
        if (controlItem.GetType() == typeof(TextBox) && controlItem.Enabled && string.IsNullOrEmpty(controlItem.Text)) {
          controlItem.Text = controlItem.Text.Trim();
          this.errorProvider1.SetError(controlItem, Properties.Resources.ValIngreseValor);
          return;
        }

      if (string.IsNullOrEmpty(txServidor.Text)) {
        this.errorProvider1.SetError(txServidor, Properties.Resources.ValIngreseValor);
        return;
      }

      if (string.IsNullOrEmpty(txUsr.Text)) {
        this.errorProvider1.SetError(txUsr, Properties.Resources.ValIngreseValor);
        return;
      }

      if (string.IsNullOrEmpty(txDB.Text)) {
        this.errorProvider1.SetError(txDB, Properties.Resources.ValIngreseValor);
        return;
      }

      if (string.IsNullOrEmpty(txPwd.Text)) {
        this.errorProvider1.SetError(txPwd, Properties.Resources.ValIngreseValor);
        return;
      }

      // Guardar configuracion
      try {
        string cadPrincipal = string.Empty, cadContingencia = string.Empty;
        cadPrincipal = string.Format("metadata=res://*/DAL.SEGANPOSModel.csdl|res://*/DAL.SEGANPOSModel.ssdl|res://*/DAL.SEGANPOSModel.msl;provider=System.Data.SqlClient;provider connection string='data source={0};initial catalog={1};persist security info=True;user id={2};password={3};Connection Timeout=30;MultipleActiveResultSets=True;App=EntityFramework'",
          this.txServidor.Text, this.txDB.Text, this.txUsr.Text, this.txPwd.Text);

        if (!new DataAccess().VerificarCadenaConexion(cadPrincipal)) {
          MessageBox.Show(string.Format(Properties.Resources.ErrorConexDB, "Principal"), "Error - " + this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        if (this.chCont.Checked) {
          cadContingencia = string.Format("metadata=res://*/DAL.SEGANPOSModel.csdl|res://*/DAL.SEGANPOSModel.ssdl|res://*/DAL.SEGANPOSModel.msl;provider=System.Data.SqlClient;provider connection string='data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework'",
            this.txServCont.Text, this.txDBCont.Text, this.txUsrCont.Text, this.txPwdCont.Text);

          if (!new DataAccess().VerificarCadenaConexion(cadContingencia)) {
            MessageBox.Show(string.Format(Properties.Resources.ErrorConexDB, "de Contingencia"), "Error - " + this.Text,
              MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        config.ConnectionStrings.ConnectionStrings["SEGANPOSEntities"].ConnectionString = cadPrincipal;
        config.AppSettings.Settings["PermitirContingencia"].Value = this.chCont.Checked.ToString().ToLower();

        if (this.chCont.Checked) {
          config.ConnectionStrings.ConnectionStrings["Contingencia"].ConnectionString = cadContingencia;
        }

        config.Save(ConfigurationSaveMode.Modified);

        config.AppSettings.Settings["Config"].Value = "true";
        config.Save(ConfigurationSaveMode.Modified);

        ConfigurationManager.RefreshSection("appSettings");
        ConfigurationManager.RefreshSection("connectionStrings");
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show(ex.Message, "Error - " + this.Text, MessageBoxButtons.OK,
          MessageBoxIcon.Error);

        MessageBox.Show(Properties.Resources.ErrorActConfig, "Error - " + this.Text, MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return;
      }

      MessageBox.Show(Properties.Resources.MsgConfAct, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void cbCont_CheckedChanged(object sender, EventArgs e)
    {
      this.gbCont.Enabled = ((CheckBox)sender).Checked;
    }

    private void TextBox_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void frmConfig_Shown(object sender, EventArgs e)
    {
      this.txServidor.Focus();
    }

    #endregion

  }
}
