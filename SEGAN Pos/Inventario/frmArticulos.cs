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
  public partial class frmArticulos : Form
  {
    List<EPK_sp_ArticuloConsultar_Result> Existencias;
    int? intIdColeccion = null;
    int? intIdGrupo = null;
    int? intIdGenero = null;
    int? intIdTema = null;
    int? intIdTalla = null;
    int? intIdColor = null;
    string Referencia;

    public frmArticulos()
    {
      InitializeComponent();
    }

    private void frmArticulos_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombos();
    }

    #region Methods

    private void CargarCombos()
    {
      this.cbColeccion.Focus();

      IEnumerable<EPK_Coleccion> colecciones = new Colecciones().ObtenerTodas();
      this.cbColeccion.DataSource = colecciones;
      this.cbColeccion.ValueMember = "IdColeccion";
      this.cbColeccion.DisplayMember = "Descripcion";
      this.cbColeccion.SelectedIndex = -1;


      IEnumerable<EPK_Genero> generos = new Generos().ObtenerTodos();
      this.cbGenero.DataSource = generos;
      this.cbGenero.ValueMember = "IdGenero";
      this.cbGenero.DisplayMember = "Descripcion";
      this.cbGenero.SelectedIndex = -1;


      IEnumerable<EPK_Grupo> grupos = new Grupos().ObtenerTodos();
      this.cbGrupo.DataSource = grupos;
      this.cbGrupo.ValueMember = "IdGrupo";
      this.cbGrupo.DisplayMember = "Descripcion";
      this.cbGrupo.SelectedIndex = -1;

      IEnumerable<EPK_Tema> temas = new Temas().ObtenerTodos();
      this.cbTema.DataSource = temas;
      this.cbTema.ValueMember = "IdTema";
      this.cbTema.DisplayMember = "Descripcion";
      this.cbTema.SelectedIndex = -1;

      IEnumerable<EPK_Talla> tallas = new Talla().ObtenerTodos();
      this.cbTalla.DataSource = tallas;
      this.cbTalla.ValueMember = "IdTalla";
      this.cbTalla.DisplayMember = "Descripcion";
      this.cbTalla.SelectedIndex = -1;

      IEnumerable<EPK_Color> colores = new SEGAN_POS.DAL.Colores().ObtenerTodos();
      this.cbColor.DataSource = colores;
      this.cbColor.ValueMember = "IdColor";
      this.cbColor.DisplayMember = "Descripcion";
      this.cbColor.SelectedIndex = -1;

      //IEnumerable<EPK_TipoPrenda> TiposPrenda = new SEGAN_POS.DAL.TipoPrenda().ObtenerTodos();
      //this.cbTipoPrenda.DataSource = TiposPrenda;
      //this.cbTipoPrenda.ValueMember = "IdTipoPrenda";
      //this.cbTipoPrenda.DisplayMember = "Descripcion";
      //this.cbTipoPrenda.SelectedIndex = -1;


    }

    #endregion

    private void btBuscar_Click(object sender, EventArgs e)
    {
      intIdColeccion = null;
      intIdGrupo = null;
      intIdGenero = null;
      intIdTema = null;
      intIdTalla = null;
      intIdColor = null;

      if (cbColeccion.SelectedIndex >= 0) {
        intIdColeccion = (int)cbColeccion.SelectedValue;
      }

      if (cbGrupo.SelectedIndex >= 0) {
        intIdGrupo = (int)cbGrupo.SelectedValue;
      }

      if (cbGenero.SelectedIndex >= 0) {
        intIdGenero = (int)cbGenero.SelectedValue;
      }

      if (cbTema.SelectedIndex >= 0) {
        intIdTema = (int)cbTema.SelectedValue;
      }

      if (cbTalla.SelectedIndex >= 0) {
        intIdTalla = (int)cbTalla.SelectedValue;
      }

      if (cbColor.SelectedIndex >= 0) {
        intIdColor = (int)cbColor.SelectedValue;
      }

      //if (cbTipoPrenda.SelectedIndex >= 0)
      //{
      //    intIdTipoPrenda = (byte)cbTipoPrenda.SelectedValue;
      //}
      if (string.IsNullOrEmpty(txtReferencia.Text)) {
        Referencia = null;
      }
      else {
        Referencia = txtReferencia.Text.Replace('*', '%');
      }

      this.lbResult.Text = string.Empty;
      if (intIdColeccion == null && intIdTalla == null && intIdGrupo == null && intIdGenero == null && intIdTema == null && intIdColeccion == null && Referencia == null && intIdColor == null)
      {
        MessageBox.Show("Ingrese al menos un criterio de búsqueda", "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      if (!string.IsNullOrEmpty(Referencia) && Referencia.Length < 6) {
        MessageBox.Show("Ingrese al menos 5 caracteres para la referencia", "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtReferencia.Focus();
        return;
      }
      try {
        pbVentas.Visible = true;
        this.btBuscar.Enabled = false;
        backgroundWorkerExistencias.RunWorkerAsync();
      }
      catch (Exception) {

        throw;
      }
      finally {

      }
      // Log Auditoria
      //  new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbTema.SelectedIndex = -1;
      this.cbColeccion.SelectedIndex = -1;
      this.cbGenero.SelectedIndex = -1;
      this.cbGrupo.SelectedIndex = -1;
      this.cbTalla.SelectedIndex = -1;
      //this.cbTipoPrenda.SelectedIndex = -1;
      this.cbColor.SelectedIndex = -1;
      this.txtReferencia.Text = "";
      this.lbResult.Visible = false;
      this.dataGridViewExistenciaTienda.DataSource = null;
    }

    private void dataGridViewExistenciaTienda_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dataGridViewExistenciaTienda_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void backgroundWorkerExistencias_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            Existencias = new DAL.Reportes().ConsultarExistencias(null, null, null, null, intIdColor, intIdTalla, null, null, Referencia, intIdGrupo, intIdGenero, intIdTema, intIdColeccion);
            foreach (EPK_sp_ArticuloConsultar_Result Item in Existencias)
            {
                //Calcula el precio Total
                Item.PrecioGravable = Item.PrecioGravable + Math.Round((Item.PrecioGravable) * (EstadoAplicacion.AplicaImpuesto ? Util.ObtenerParametroDecimal("IVA") : 0) / 100, 2);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void backgroundWorkerExistencias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.btBuscar.Enabled = true;
        dataGridViewExistenciaTienda.DataSource = Existencias;
        this.lbResult.Visible = true;
        if (Existencias.Count > 0)
        {
            this.lbResult.Text = "Número registros encontrados:" + Existencias.Count.ToString();
        }
        else
        {
            this.lbResult.Text = "No existen registros que cumplan con la condición";
        }
        pbVentas.Visible = false;
    }

    private void frmArticulos_Activated(object sender, EventArgs e)
    {
      this.Text = "Consulta de Existencias - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

  }
}
