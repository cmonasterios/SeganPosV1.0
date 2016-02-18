using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmComportamiento : Form
  {
    #region Constructor

    public frmComportamiento()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      string Filtro;
      TimeSpan HoraDesde;
      TimeSpan HoraHasta;
      HoraDesde = (dtpHoraDesde.Checked ? new TimeSpan(dtpHoraDesde.Value.Hour, dtpHoraDesde.Value.Minute, dtpHoraDesde.Value.Second) : new TimeSpan(0, 0, 1));
      HoraHasta = (dtpHoraHasta.Checked ? new TimeSpan(dtpHoraHasta.Value.Hour, dtpHoraHasta.Value.Minute, dtpHoraHasta.Value.Second) : new TimeSpan(23, 59, 59));

      this.ePKspReporteComportamientoVtaResultBindingSource.DataSource = new DAL.Reportes().ReporteComportamientoVta(
                          dtpDesde.Value.Date, dtpHasta.Value.Date, Convert.ToByte(numIntervalo.Value), HoraDesde, HoraHasta);
      Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();

      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
      Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
      Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
      this.rvComportamiento.LocalReport.SetParameters(Parametros);
      this.rvComportamiento.RefreshReport();
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.dtpDesde.Value = DateTime.Now.Date;
      this.dtpHasta.Value = DateTime.Now.Date;

      this.dtpHoraDesde.Checked = false;
      this.dtpHoraHasta.Checked = false;

      this.numIntervalo.Value = numIntervalo.Minimum;

      this.rvComportamiento.Clear();
    }

    private void frmComportamiento_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Comportamiento de Venta - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmComportamiento_Load(object sender, EventArgs e)
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

      this.DisableReportViewerExportWord();
    }
    private void rvComportamiento_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void rvComportamiento_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtros: {1} ", this.Name, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }
    #endregion Events

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvComportamiento.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
        if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
            this.dtpHasta.Value = ((DateTimePicker)sender).Value;

        this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }
  }
}