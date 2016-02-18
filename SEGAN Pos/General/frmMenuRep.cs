using System;
using System.Drawing;
using System.Windows.Forms;
using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmMenuRep : Form
  {

    #region Constructor

    public frmMenuRep()
    {
      InitializeComponent();
      this.groupBox2.Enabled = true;
    }

    #endregion

    #region Events

    private void frmMenuRep_Load(object sender, EventArgs e)
    {
          
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      foreach (Control controlItem in this.Controls) {
        if (controlItem.GetType() != typeof(Button))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

      foreach (Control controlItem in this.groupBox1.Controls) {
        if (controlItem.GetType() != typeof(Button))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

      foreach (Control controlItem in this.groupBox2.Controls) {
        if (controlItem.GetType() != typeof(Button))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btVentasDiarias_Click(object sender, EventArgs e)
    {
      new frmRelacionVentasDiarias().ShowDialog();
    }

    private void btRefSinMovimiento_Click(object sender, EventArgs e)
    {
      new frmReferenciasSinMovimiento().ShowDialog();
    }

    private void btFormasPago_Click(object sender, EventArgs e)
    {
      new frmConciliacionFormaPago().ShowDialog();
    }

    private void btHorasPico_Click(object sender, EventArgs e)
    {
      new frmComportamiento().ShowDialog();
    }

    private void btnPagosConsolidados_Click(object sender, EventArgs e)
    {
      new frmPagosConsolidados().ShowDialog();
    }

    private void btMaquinasFiscales_Click(object sender, EventArgs e)
    {
    }

    private void btDenominaciones_Click(object sender, EventArgs e)
    {
      new frmRepOperacionesCajero().ShowDialog();
    }

    private void btDevoluciones_Click(object sender, EventArgs e)
    {
      new frmDevoluciones().ShowDialog();
    }

    private void frmMenuRep_Activated(object sender, EventArgs e)
    {
      this.Text = "Reportes - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btnExistencias_Click(object sender, EventArgs e)
    {
      new frmArticulos().ShowDialog();
    }

    private void btnPedidoSugerido_Click(object sender, EventArgs e)
    {
      new frmArtVend().ShowDialog();
    }

    private void btRepoArt_Click(object sender, EventArgs e)
    {
      new frmRepoArt().ShowDialog();
    }

    #endregion

    private void groupBox2_Enter(object sender, EventArgs e)
    {
        this.btRefSinMovimiento.Enabled = false;
    }

  }
}
