using System;
using System.Drawing;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmInfoNC : Form
  {

    #region Public Properties

    public EPK_NotaCreditoEsperaEncabezado NCEspera { get; set; }

    #endregion

    #region Constructor

    public frmInfoNC()
    {
      InitializeComponent();
    }

    public frmInfoNC(EPK_NotaCreditoEsperaEncabezado ncespera)
    {
      InitializeComponent();

      this.NCEspera = ncespera;
    }

    #endregion

    #region Events

    private void frmInfoNC_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void frmInfoNC_Activated(object sender, EventArgs e)
    {
      this.Text = "Impresión de Nota de Crédito - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      string rifCliente = Util.GenDocCliente(this.NCEspera.EPK_FacturaEncabezado.EPK_Cliente);
      string nombreCliente = this.NCEspera.NombreCliente.Trim();

      this.txNroSolNC.Text = this.NCEspera.IdNotaCreditoE.ToString();
      this.txNroFactura.Text = this.NCEspera.IdFactura.ToString();
      this.txFechaFactura.Text = this.NCEspera.EPK_FacturaEncabezado.FechaCreacion.ToString();
      this.txDoc.Text = rifCliente;
      this.txNombre.Text = nombreCliente;
      this.txMontoTotal.Text = string.Format("{0:C2}", this.NCEspera.MontoTotal);
    }

    #endregion

  }
}
