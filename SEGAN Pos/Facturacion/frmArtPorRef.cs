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
using System.IO;

namespace SEGAN_POS
{
  public partial class frmArtPorRef : Form
  {

    #region Public Properties

    public IEnumerable<EPK_Articulo> ArticulosRef { get; set; }

    public EPK_Articulo ArticuloSel { get; set; }

    #endregion

    #region Constructor

    public frmArtPorRef()
    {
      InitializeComponent();

      this.ArticuloSel = null;
    }

    #endregion

    #region Events

    private void frmArtPorRef_Load(object sender, EventArgs e)
    {
      if (!this.CargarDatos())
        this.Close();

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.lbArticulos.Focus();
    }

    private void frmArtPorRef_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Escape) {
        this.ArticuloSel = null;
        this.Close();
      }
    }

    private void lbArticulos_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.Seleccionar();
    }

    private void lbArticulos_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      this.Seleccionar();
    }

    private void lbArticulos_SelectedIndexChanged(object sender, EventArgs e)
    {
      int idSel;
      int.TryParse(this.lbArticulos.SelectedValue.ToString(), out idSel);

      if (idSel <= 0)
        return;

      EPK_Articulo currArt = this.ArticulosRef.First(ar => ar.IdArticulo == idSel);

      if (currArt.EPK_Referencia.FotoMediana != null) {
        Byte[] data = new Byte[0];
        data = (Byte[])(currArt.EPK_Referencia.FotoMediana);
        MemoryStream mem = new MemoryStream(data);
        this.pbFotoArt.Image = Image.FromStream(mem);
      }
      else
        this.pbFotoArt.Image = Properties.Resources.imagennodisp;
    }

    private void frmArtPorRef_Activated(object sender, EventArgs e)
    {
      this.Text = "Seleccionar Artículo - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private bool CargarDatos()
    {
      if (this.ArticulosRef == null)
        return false;

      if (this.ArticulosRef.Count() == 0)
        return false;

      this.lbArticulos.DataSource = this.ArticulosRef;
      this.lbArticulos.ValueMember = "IdArticulo";
      this.lbArticulos.DisplayMember = "CodigoArticulo";

      this.lbArticulos.SelectedIndex = 0;
      this.lbArticulos.Focus();

      return true;
    }

    private void Seleccionar()
    {
      int idSel;
      int.TryParse(this.lbArticulos.SelectedValue.ToString(), out idSel);

      if (idSel <= 0)
        return;

      this.ArticuloSel = this.ArticulosRef.First(ar => ar.IdArticulo == idSel);
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    #endregion

  }
}
