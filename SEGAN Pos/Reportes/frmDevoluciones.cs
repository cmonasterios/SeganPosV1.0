using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmDevoluciones : Form
  {
    #region Constructor

    public frmDevoluciones()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Methods

    private void CargarCombos()
    {
      //segun CU por defecto debe aparecer la coleccion actual**
      this.cbColeccion.Focus();

      IEnumerable<EPK_Coleccion> colecciones = new Colecciones().ObtenerTodas();
      this.cbColeccion.DataSource = colecciones;
      this.cbColeccion.ValueMember = "IdColeccion";
      this.cbColeccion.DisplayMember = "Descripcion";
      this.cbColeccion.SelectedIndex = -1;

      // Segun CU debe mostrar todos los generos de la coleccion seleccionada
      IEnumerable<EPK_Genero> generos = new Generos().ObtenerTodos();
      this.cbGenero.DataSource = generos;
      this.cbGenero.ValueMember = "IdGenero";
      this.cbGenero.DisplayMember = "Descripcion";
      this.cbGenero.SelectedIndex = -1;

      // Segun CU debe mostrar todos los grupos de la coleccion seleccionada
      IEnumerable<EPK_Grupo> grupos = new Grupos().ObtenerTodos();
      this.cbGrupo.DataSource = grupos;
      this.cbGrupo.ValueMember = "IdGrupo";
      this.cbGrupo.DisplayMember = "Descripcion";
      this.cbGrupo.SelectedIndex = -1;

      IEnumerable<EPK_MotivoDevolucion> Devolucion = new MotivosDevolucion().ObtenerTodos();
      this.cbMotDevolucion.DataSource = Devolucion;
      this.cbMotDevolucion.ValueMember = "IdMotivo";
      this.cbMotDevolucion.DisplayMember = "Motivo";
      this.cbMotDevolucion.SelectedIndex = -1;

      IEnumerable<EPK_Usuario> usuarios = new Usuarios().ObtenerCajeros();
      if (usuarios != null && usuarios.Count() > 0) {
        this.cbCajero.DataSource = usuarios;
        this.cbCajero.ValueMember = "IdUsuario";
        this.cbCajero.DisplayMember = "Identificacion";
        this.cbCajero.SelectedIndex = -1;
      }

      IEnumerable<EPK_Usuario> autorizador = new Accesos().ObtenerAutorizadores("frmFacturar", "Devolucion_Item");
      this.cbAutorizador.DataSource = autorizador;
      this.cbAutorizador.ValueMember = "IdUsuario";
      this.cbAutorizador.DisplayMember = "Identificacion";
      this.cbAutorizador.SelectedIndex = -1;
    }

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvDevoluciones.Controls.Find("toolStrip1", true)[0] as ToolStrip;

      if (toolStrip != null)
        foreach (var dropDownButton in toolStrip.Items.OfType<ToolStripDropDownButton>())
          dropDownButton.DropDownOpened += new EventHandler(dropDownButton_DropDownOpened);
    }

    private void dropDownButton_DropDownOpened(object sender, EventArgs e)
    {
      if (sender is ToolStripDropDownButton) {
        var ddList = sender as ToolStripDropDownButton;
        foreach (var item in ddList.DropDownItems.OfType<ToolStripDropDownItem>())
          if (item.Text.Contains("Word"))
            item.Visible = false;
      }
    }

    #endregion Methods

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      int? intIdColeccion = null;
      int? intIdGrupo = null;
      int? intIdGenero = null;
      int? intIdMotDev = null;
      int? intIdAutoriz = null;
      int? intIdCajero = null;
      string strCajero = "";

      if (cbColeccion.SelectedIndex >= 0)
        intIdColeccion = (int)cbColeccion.SelectedValue;

      if (cbGrupo.SelectedIndex >= 0)
        intIdGrupo = (int)cbGrupo.SelectedValue;

      if (cbGenero.SelectedIndex >= 0)
        intIdGenero = (int)cbGenero.SelectedValue;

      if (cbMotDevolucion.SelectedIndex >= 0)
        intIdMotDev = int.Parse(cbMotDevolucion.SelectedValue.ToString());

      if (cbAutorizador.SelectedIndex >= 0)
        intIdAutoriz = (int)cbAutorizador.SelectedValue;

      if (cbCajero.SelectedIndex >= 0)
        intIdCajero = (int)cbCajero.SelectedValue;

      strCajero = txtCajero.Text;

      int fDesde;
      int.TryParse(txtFactDesd.Text, out fDesde);
      int fHasta;
      int.TryParse(txtFactHast.Text, out fHasta);
      int? factD = null;
      int? factH = null;

      if (fDesde != 0)
        factD = fDesde;

      if (fHasta != 0)
        factH = fHasta;

      this.ePKspReporteDevolucionesResultBindingSource.DataSource =
              new DAL.Reportes().ReporteDevoluciones(
                      dtpDesde.Value.Date, dtpHasta.Value.Date, factD, factH,
                       intIdMotDev, intIdAutoriz, intIdColeccion,
                      intIdGenero, intIdGrupo, strCajero);

      string Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();
      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
      Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
      Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
      this.rvDevoluciones.LocalReport.SetParameters(Parametros);
      this.rvDevoluciones.RefreshReport();
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbMotDevolucion.SelectedIndex = -1;
      this.cbColeccion.SelectedIndex = -1;
      this.cbGenero.SelectedIndex = -1;
      this.cbGrupo.SelectedIndex = -1;
      this.cbCajero.SelectedIndex = -1;
      this.cbAutorizador.SelectedIndex = -1;
      this.txtFactDesd.Text = "";
      this.txtFactHast.Text = "";
      this.txtCajero.Text ="";
      this.dtpDesde.Value = DateTime.Now.Date;
      this.dtpHasta.Value = DateTime.Now.Date;

      this.rvDevoluciones.Clear();
    }

    private void frmDevoluciones_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte de Devoluciones - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmDevoluciones_Load(object sender, EventArgs e)
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
    private void frmDevoluciones_Shown(object sender, EventArgs e)
    {
      this.dtpDesde.Focus();
    }

    private void rvDevoluciones_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtro: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void rvDevoluciones_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void txtFactDesd_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$") && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
        else
            base.OnKeyPress(e);
    }

    private void txtFactHast_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$") && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
        else
            base.OnKeyPress(e);
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
        if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
            this.dtpHasta.Value = ((DateTimePicker)sender).Value;

        this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    #endregion Events
  }
}