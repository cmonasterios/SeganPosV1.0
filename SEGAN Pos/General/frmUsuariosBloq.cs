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
  public partial class frmUsuariosBloq : Form
  {

    #region Private Properties

    private List<UsuariosBloqueados> _usuBloq { get; set; }

    #endregion

    #region Constructor

    public frmUsuariosBloq()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmUsuariosBloq_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 4) // Botón desbloquear
        return;

      UsuariosBloqueados itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as UsuariosBloqueados);

      if (itemSel == null)
        return;

      if (new Usuarios().Desbloquear(itemSel.IdUsuario)) {
        string claveBase = Util.ObtenerParametroCadena("ClaveBase");
        if (string.IsNullOrEmpty(claveBase))
          MessageBox.Show(Properties.Resources.MsgExitoDesbloq, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
          MessageBox.Show(string.Format(Properties.Resources.MsgExitoDesbloqClave, claveBase), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
        MessageBox.Show(Properties.Resources.MsgErrorDesbloq, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

      this.CargarDatos();
    }

    private void frmUsuariosBloq_Activated(object sender, EventArgs e)
    {
      this.Text = "Desbloquear Usuarios - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      try {
        this._usuBloq = new Usuarios().ObtenerBloqueados(EstadoAplicacion.UsuarioActual.IdUsuario);

        this.dgItems.DataSource = this._usuBloq;
        this.dgItems.Refresh();

      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion

  }
}
