using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmReferenciasSinMovimiento : Form
  {

    #region Constructor

    public frmReferenciasSinMovimiento()
    {
      InitializeComponent();
    }

    #endregion

    #region Private Methods

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
        this.cbTema.SelectedValue = "Seleccione";
    

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

      IEnumerable<EPK_TipoPrenda> TiposPrenda = new SEGAN_POS.DAL.TipoPrenda().ObtenerTodos();
      this.cbTipoPrenda.DataSource = TiposPrenda;
      this.cbTipoPrenda.ValueMember = "IdTipoPrenda";
      this.cbTipoPrenda.DisplayMember = "Descripcion";
      this.cbTipoPrenda.SelectedIndex = -1;

    }

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvReferencias.Controls.Find("toolStrip1", true)[0] as ToolStrip;

      if (toolStrip != null)
        foreach (var dropDownButton in toolStrip.Items.OfType<ToolStripDropDownButton>())
          dropDownButton.DropDownOpened += new EventHandler(dropDownButton_DropDownOpened);
    }

    void dropDownButton_DropDownOpened(object sender, EventArgs e)
    {
      if (sender is ToolStripDropDownButton) {
        var ddList = sender as ToolStripDropDownButton;
        foreach (var item in ddList.DropDownItems.OfType<ToolStripDropDownItem>())
          if (item.Text.Contains("Word"))
            item.Visible = false;
      }
    }

    #endregion

    #region Events

    private void frmReferenciasSinMovimiento_Load(object sender, EventArgs e)
    {
      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.CargarCombos();
      this.DisableReportViewerExportWord();
    }

    private void btBuscar_Click(object sender, EventArgs e)
    {
      int? intIdColeccion = null;
      int? intIdGrupo = null;
      int? intIdGenero = null;
      int? intIdTema = null;
      int? intIdTalla = null;
      int? intIdColor = null;
      byte? intIdTipoPrenda = null;

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

      if (cbTipoPrenda.SelectedIndex >= 0) {
        intIdTipoPrenda = (byte)cbTipoPrenda.SelectedValue;
      }

      this.EPK_sp_ReporteReferenciasSinMovimiento_ResultBindingSource.DataSource =
              new DAL.Reportes().ReporteReferenciasSinMovimiento(
                      dtpDesde.Value.Date, dtpHasta.Value.Date,
                      intIdColeccion, txtReferencia.Text.Trim(),
                      intIdTalla, intIdColor,
                      intIdGenero, intIdGrupo,
                      intIdTema, intIdTipoPrenda);

      string Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();
      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
      Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
      Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
      this.rvReferencias.LocalReport.SetParameters(Parametros);
      this.rvReferencias.RefreshReport();
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));

    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbTema.SelectedIndex = -1;
      this.cbColeccion.SelectedIndex = -1;
      this.cbGenero.SelectedIndex = -1;
      this.cbGrupo.SelectedIndex = -1;
      this.cbTalla.SelectedIndex = -1;
      this.cbTipoPrenda.SelectedIndex = -1;
      this.cbColor.SelectedIndex = -1;
      this.txtReferencia.Text = "";
      this.dtpDesde.Value = DateTime.Now.Date;
      this.dtpHasta.Value = DateTime.Now.Date;

      this.rvReferencias.Clear();
    }

    private void rvReferencias_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));

    }

    private void rvReferencias_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));

    }

    private void frmReferenciasSinMovimiento_Activated(object sender, EventArgs e)
    {
      this.Text = "Referencias Sin Movimiento - "  + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmReferenciasSinMovimiento_Shown(object sender, EventArgs e)
    {
        this.dtpDesde.Focus();
    }

    #endregion

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
        if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
            this.dtpHasta.Value = ((DateTimePicker)sender).Value;

        this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

  }
}



