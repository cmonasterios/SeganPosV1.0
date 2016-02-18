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
  public partial class frmAutorizarDesc : Form
  {

    #region Public Properties

    public bool Autorizado { get; private set; }
    public EPK_Usuario UsuarioAutorizador { get; private set; }

    public decimal Descuento { get; set; }

    public string NombreTecnico { get; set; }
    public string Accion { get; set; }

    #endregion

    #region Constructor

    public frmAutorizarDesc()
    {
      InitializeComponent();

      this.UsuarioAutorizador = null;
    }

    #endregion

    #region Events

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.udDescuento, "");
      this.errorProvider1.SetError(this.txLogin, "");
      this.errorProvider1.SetError(this.txPassword, "");

      if (this.udDescuento.Value == 0) {
        this.errorProvider1.SetError(this.udDescuento, Properties.Resources.ValIngreseUsuario);
        this.udDescuento.Focus();
        return;
      }

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

      KeyValuePair<EPK_Usuario, string> result = new Usuarios().Validar(login, passwd);

      if (result.Key == null) {
        MessageBox.Show(result.Value, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Cursor = Cursors.Default;
        return;
      }

      if (!string.IsNullOrEmpty(this.NombreTecnico) && !string.IsNullOrEmpty(this.Accion)) {
        if (!new Accesos().EsAutorizadorAccion(result.Key.IdUsuario, this.NombreTecnico, this.Accion)) {
          MessageBox.Show(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

          // Log Auditoria
          new NLogLogger().Info(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login));


          this.Cursor = Cursors.Default;
          return;
        }
      }

      this.Cursor = Cursors.Default;

      this.Autorizado = true;
      this.UsuarioAutorizador = result.Key;

      this.Descuento = this.udDescuento.Value;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;

      // Log Auditoria
      new NLogLogger().Info(string.Format("Descuento de {0} %, autorizado por: {1}, Acción: {2}, Nombre Técnico {3}.", udDescuento.Value, result.Key.Login, Accion, NombreTecnico));

      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Autorizado = false;
      this.Descuento = 0;

      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

      // Log Auditoria
      new NLogLogger().Info(string.Format("Acción: {0}, Nombre Técnico: {1}", Accion, NombreTecnico));

      this.Close();
    }

    private void frmAutorizarDesc_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.udDescuento.Value = this.Descuento;
    }

    #endregion

    private void frmAutorizarDesc_Activated(object sender, EventArgs e)
    {
      this.Text = "Autorizar Descuento - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

  }
}
