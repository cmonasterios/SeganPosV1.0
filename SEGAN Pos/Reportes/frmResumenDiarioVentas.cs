using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmResumenDiarioVentas : Form
  {
    #region Constructor

    public frmResumenDiarioVentas()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      string observaciones = " ";

      this.ePKspReporteResumenDiarioVtasResultBindingSource.DataSource =
                new DAL.Reportes().ResumenDiarioVentas(
                            dtpDesde.Value.Date, dtpHasta.Value.Date, txtMFiscal.Text);

      string Filtro = "";
      Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();

      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
      Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
      Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
      Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterObservaciones", observaciones);
      this.rvResumenDiarioVtas.LocalReport.SetParameters(Parametros);
      this.rvResumenDiarioVtas.RefreshReport();
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.txtMFiscal.Text = "";
    }

    private void frmResumenDiarioVentas_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Resumen Diario de Ventas " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmResumenDiarioVentas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
    }
    private void rvResumenDiarioVtas_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      string observaciones = string.Empty;

      Reportes.frmResDiaVtasObs fObs = new Reportes.frmResDiaVtasObs();
      fObs.ShowDialog();
      if (fObs.DialogResult == System.Windows.Forms.DialogResult.OK)
        observaciones = fObs.observaciones;
      if (observaciones == string.Empty)
        observaciones = " ";

      string Filtro = "";
      Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();
      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
      Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
      Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
      Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterObservaciones", observaciones);
      this.rvResumenDiarioVtas.LocalReport.SetParameters(Parametros);
      rvResumenDiarioVtas.PrintDialog();
      this.rvResumenDiarioVtas.RefreshReport();
    }

    private void rvResumenDiarioVtas_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void rvResumenDiarioVtas_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }
    #endregion Events

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvResumenDiarioVtas.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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

    #endregion Private Methods
  }
}