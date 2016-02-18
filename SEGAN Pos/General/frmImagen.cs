using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmImagen : Form
  {

    #region Public Properties

    public string Titulo { get; set; }
    public byte[] Imagen { get; set; }
    public string FileName { get; set; }
    public string MimeType { get; set; }
    public bool ReadOnly { get; set; }

    #endregion

    #region Constructor

    public frmImagen()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmImagen_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (this.Imagen != null)
        this.pbImagen.Image = this.Imagen.ToImage();

      if (this.ReadOnly) {
        this.pnEdit.Visible = false;
        this.btOK.Visible = false;
        this.btCancel.Text = "Cerrar";
      }

    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.FileName = this.MimeType = null;
      this.Imagen = null;

      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void frmImagen_Activated(object sender, EventArgs e)
    {
      this.Text = this.Titulo + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btAbrir_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.ShowDialog();
    }

    private void btEliminar_Click(object sender, EventArgs e)
    {
      this.FileName = this.MimeType = null;
      this.Imagen = null;
      this.pbImagen.Image = null;
    }

    private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      try {
        Image imagen = Image.FromFile(((OpenFileDialog)sender).FileName);

        this.pbImagen.Image = imagen;

        this.Imagen = File.ReadAllBytes(((OpenFileDialog)sender).FileName);
        this.FileName = Path.GetFileName(((OpenFileDialog)sender).FileName);
        this.MimeType = System.Web.MimeMapping.GetMimeMapping(((OpenFileDialog)sender).FileName);
      }
      catch (Exception ex) {


        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion

  }
}
