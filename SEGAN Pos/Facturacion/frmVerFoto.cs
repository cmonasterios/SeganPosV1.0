using SEGAN_POS.DAL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmVerFoto : Form
  {
    #region Public Properties

    public EPK_Articulo Articulo { get; set; }

    public Image Imagen { get; set; }

    #endregion Public Properties

    #region Constructor

    public frmVerFoto()
    {
      InitializeComponent();
    }

    public frmVerFoto(Image imagen)
    {
      InitializeComponent();

      this.Imagen = imagen;
    }

    #endregion Constructor

    #region Events

    private void frmVerFoto_Activated(object sender, EventArgs e)
    {
      this.Text = Properties.Resources.TipVerFoto + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmVerFoto_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Escape)
        this.Close();
    }

    private void frmVerFoto_Load(object sender, EventArgs e)
    {
      if (!this.CargarDatos())
        this.Close();

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      ToolTip verFotoToolTip = new ToolTip();

      verFotoToolTip.AutoPopDelay = 5000;
      verFotoToolTip.InitialDelay = 1000;
      verFotoToolTip.ReshowDelay = 500;

      verFotoToolTip.ShowAlways = true;

      verFotoToolTip.SetToolTip(this.pbFotoArt, Properties.Resources.TipCerrar);
    }
    private void pbFotoArt_MouseClick(object sender, MouseEventArgs e)
    {
      this.Close();
    }

    private void pbFotoArt_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Close();
    }
    #endregion Events

    #region Private Methods

    private bool CargarDatos()
    {
      if (this.Articulo != null) {
        if (this.Articulo.EPK_Referencia.FotoMediana == null)
          return false;

        Byte[] data = new Byte[0];
        data = (Byte[])(this.Articulo.EPK_Referencia.FotoMediana);
        MemoryStream mem = new MemoryStream(data);
        this.pbFotoArt.Image = Image.FromStream(mem);

        return true;
      }

      if (this.Imagen != null) {
        this.pbFotoArt.Image = this.Imagen;

        return true;
      }

      return false;
    }

    #endregion Private Methods
  }
}