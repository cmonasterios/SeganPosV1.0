using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmBuscarArt : Form
  {
    #region Public Properties

    public EPK_Articulo ArticuloSel { get; set; }

    public bool NoAgregar { get; set; }

    #endregion Public Properties

    #region Private Properties

    protected List<ItemArticulo> _articulos { get; set; }

    protected int _coleccionActual { get; set; }

    protected bool _limpio { get; set; }

    #endregion Private Properties

    #region Constructor

    public frmBuscarArt()
    {
      this._coleccionActual = 0;
      this._articulos = new List<ItemArticulo>();
      this.ArticuloSel = null;

      InitializeComponent();
    }

    public frmBuscarArt(bool noAgregar)
    {
      this.NoAgregar = noAgregar;

      this._coleccionActual = 0;
      this._articulos = new List<ItemArticulo>();
      this.ArticuloSel = null;

      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      this.LimpiarGrid();

      if (!this.Validar())
        return;

      Cursor.Current = Cursors.WaitCursor;

      int idColeccion = 0, idGenero = 0, idGrupo = 0;

      if (this.cbColeccion.SelectedIndex > -1)
        int.TryParse(this.cbColeccion.SelectedValue.ToString(), out idColeccion);

      if (this.cbGenero.SelectedIndex > -1)
        int.TryParse(this.cbGenero.SelectedValue.ToString(), out idGenero);

      if (this.cbGrupo.SelectedIndex > -1)
        int.TryParse(this.cbGrupo.SelectedValue.ToString(), out idGrupo);

      this._articulos = new Articulos().Buscar(idColeccion, idGenero, idGrupo, this.txReferencia.Text.Trim());

      this.dgItems.DataSource = this._articulos;
      this.dgItems.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", this._articulos.Count());
      this.lbCantReg.Visible = true;

      if (this._articulos.Count() > 0)
        this.dgItems.Focus();

      Cursor.Current = Cursors.Default;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.ArticuloSel = null;

      this.Close();
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
    }

    private void cbColeccion_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._limpio = false;
    }

    private void cbGenero_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._limpio = false;
    }

    private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._limpio = false;
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (this.NoAgregar)
        return;

      if (((DataGridView)sender).SelectedRows.Count == 0)
        return;

      ItemArticulo itemSel = (((DataGridView)sender).SelectedRows[0].DataBoundItem as ItemArticulo);

      if (itemSel == null)
        return;

      this.ArticuloSel = itemSel.Articulo;

      if (this.ArticuloSel == null)
        return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dgItems_SelectionChanged(object sender, EventArgs e)
    {
      this.LimpiarArticulo();

      if (((DataGridView)sender).SelectedRows.Count == 0)
        return;

      ItemArticulo itemSel = (((DataGridView)sender).SelectedRows[0].DataBoundItem as ItemArticulo);

      if (itemSel == null)
        return;

      if (itemSel.Imagen != null) {
        Byte[] data = new Byte[0];
        data = (Byte[])(itemSel.Imagen);
        MemoryStream mem = new MemoryStream(data);
        this.pbFotoArt.Image = Image.FromStream(mem);
      }
      else
        this.pbFotoArt.Image = Properties.Resources.imagennodisp;

      this.ArticuloSel = itemSel.Articulo;

      if (this.ArticuloSel == null)
        return;

      decimal IVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

      decimal precioArt = 0;

      if (EstadoAplicacion.AplicaImpuesto && !this.ArticuloSel.Exento)
        precioArt = this.ArticuloSel.PrecioGravable + Math.Round((this.ArticuloSel.PrecioGravable) * IVA / 100, 2);
      else
        precioArt = this.ArticuloSel.PrecioExento;

      this.txPrecioArt.Text = precioArt.ToString("c");
      this.txExistenciaArt.Text = this.ArticuloSel.Existencia.ToString();
      if (this.ArticuloSel.Activo)
      {
          this.txEstatusArt.Text = "Habilitado";
          this.txEstatusArt.ForeColor = Color.Green;
      }
      else
      {
          this.txEstatusArt.Text = "Deshabilitado";
          this.txEstatusArt.ForeColor = Color.Red   ;       
      }

      this.btOK.Enabled = this.ArticuloSel.Activo;
    }

    private void frmBuscarArt_Activated(object sender, EventArgs e)
    {
      this.Text = Properties.Resources.TipBuscarArt + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmBuscarArt_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombos();
      this.Limpiar();

      if (this.NoAgregar)
        this.btOK.Visible = false;
    }

    private void frmBuscarArt_Shown(object sender, EventArgs e)
    {
      this.cbColeccion.Focus();
    }

    private void pbFotoArt_Click(object sender, EventArgs e)
    {
      if (((PictureBox)sender).Image == null)
        return;

      new frmVerFoto(((PictureBox)sender).Image).ShowDialog();
    }
    private void txReferencia_TextChanged(object sender, EventArgs e)
    {
      this._limpio = false;
    }

    #endregion Events

    #region Private Methods

    private void CargarCombos()
    {
      IEnumerable<EPK_Coleccion> colecciones = new Colecciones().ObtenerActivas();

      this.cbColeccion.DataSource = colecciones;
      this.cbColeccion.ValueMember = "IdColeccion";
      this.cbColeccion.DisplayMember = "Descripcion";

      if (colecciones.Count() == 1) {
        this.cbColeccion.SelectedIndex = 0;
        this.cbColeccion.Enabled = false;
      }
      else {
        EPK_Coleccion actual = colecciones.FirstOrDefault(c => c.Actual);

        if (actual != null)
          this._coleccionActual = actual.IdColeccion;
      }

      IEnumerable<EPK_Genero> generos = new Generos().ObtenerTodos();

      this.cbGenero.DataSource = generos;
      this.cbGenero.ValueMember = "IdGenero";
      this.cbGenero.DisplayMember = "Descripcion";
      this.cbGenero.SelectedIndex = -1;

      IEnumerable<EPK_Grupo> grupos = new Grupos().ObtenerTodos();

      this.cbGrupo.DataSource = grupos;
      this.cbGrupo.ValueMember = "IdGrupo";
      this.cbGrupo.DisplayMember = "Descripcion";
    }

    private void Limpiar()
    {
      this.LimpiarArticulo();
      this.LimpiarGrid();

      if (this.cbColeccion.Enabled) {
        if (this._coleccionActual > 0)
          this.cbColeccion.SelectedValue = this._coleccionActual;
        else
          this.cbColeccion.SelectedIndex = -1;
      }

      this.cbGenero.SelectedIndex = -1;

      this.cbGrupo.SelectedIndex = -1;

      this.txReferencia.Text = string.Empty;

      this._limpio = true;

      this.cbColeccion.Focus();
    }

    private void LimpiarArticulo()
    {
      this.pbFotoArt.Image = null;

      this.txPrecioArt.Text = this.txExistenciaArt.Text = this.txEstatusArt.Text = string.Empty;

      this.btOK.Enabled = false;
    }

    private void LimpiarErrores()
    {
      this.errorProvider1.SetError(this.cbColeccion, "");
      this.errorProvider1.SetError(this.cbGenero, "");
      this.errorProvider1.SetError(this.cbGrupo, "");
      this.errorProvider1.SetError(this.txReferencia, "");
    }

    private void LimpiarGrid()
    {
      this._articulos = new List<ItemArticulo>();
      List<ItemArticulo> tempList = new List<ItemArticulo>();

      this.dgItems.DataSource = tempList;
      this.dgItems.Refresh();

      this.lbCantReg.Visible = false;
      this.btOK.Enabled = false;
    }

    private bool Validar()
    {
      this.LimpiarErrores();

      if (this.cbColeccion.SelectedIndex < 0) {
        this.errorProvider1.SetError(this.cbColeccion, Properties.Resources.ValSelColec);
        return false;
      }

      if (this.cbGenero.SelectedIndex < 0 && this.cbGrupo.SelectedIndex < 0 && string.IsNullOrEmpty(this.txReferencia.Text)) {
        this.errorProvider1.SetError(this.cbGenero, Properties.Resources.ValIngrese1Crit);
        this.errorProvider1.SetError(this.cbGrupo, Properties.Resources.ValIngrese1Crit);
        this.errorProvider1.SetError(this.txReferencia, Properties.Resources.ValIngrese1Crit);
        return false;
      }

      if (!string.IsNullOrEmpty(this.txReferencia.Text) && this.txReferencia.Text.Length < 4) {
        this.errorProvider1.SetError(this.txReferencia, Properties.Resources.ValRef4);
        return false;
      }

      return true;
    }

    #endregion Private Methods

    private void frmBuscarArt_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Shift || e.Alt || e.Control)
        return;

      switch (e.KeyCode) {
        case Keys.Escape:
          if (this._limpio)
            this.Close();
          else {
            this.Limpiar();
          }
          break;
      }
    }

  }
}