using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmRepOperacionesCajero : Form
  {
    #region Constructor

    public frmRepOperacionesCajero()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      int? IdCaja = null;
      if (cbCaja.SelectedIndex != -1) {
        IdCaja = (int)cbCaja.SelectedValue;
      }

      if (optCierre.Checked == true) {
        this.ePKspReporteCierreCajeroResultBindingSource.DataSource =
                new DAL.Reportes().ReporteCierreCajero(dtpDesde.Value, dtpHasta.Value, IdCaja, txCajero.Text.Trim());

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsCierreCajero";
        reportDataSource1.Value = this.ePKspReporteCierreCajeroResultBindingSource;
        this.rvApertura.LocalReport.DataSources.Add(reportDataSource1);
        this.rvApertura.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptCierreCajero.rdlc";

        string Filtro = "";
        Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        this.rvApertura.LocalReport.SetParameters(Parametros);
        this.rvApertura.RefreshReport();
        // Log Auditoria
        new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.rvApertura.LocalReport.ReportEmbeddedResource, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
      }

      if (optApertura.Checked == true) {
        this.ePKspReporteAperturaCajeroResultBindingSource.DataSource =
                new DAL.Reportes().ReporteAperturaCajero(dtpDesde.Value, dtpHasta.Value, IdCaja, txCajero.Text);

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsApertura";
        reportDataSource1.Value = this.ePKspReporteAperturaCajeroResultBindingSource;
        this.rvApertura.LocalReport.DataSources.Add(reportDataSource1);
        this.rvApertura.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptAperturaCajeros.rdlc";

        string Filtro = "";
        Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        this.rvApertura.LocalReport.SetParameters(Parametros);
        this.rvApertura.RefreshReport();
        new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.rvApertura.LocalReport.ReportEmbeddedResource, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
      }

      if (optTodas.Checked == true) {
        this.ePKspReporteOperacionesCajeroResultBindingSource.DataSource =
                new DAL.Reportes().ReporteOperacionesCajero(dtpDesde.Value, dtpHasta.Value, IdCaja, txCajero.Text.Trim());

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsOperaciones";
        reportDataSource1.Value = this.ePKspReporteOperacionesCajeroResultBindingSource;
        this.rvApertura.LocalReport.DataSources.Add(reportDataSource1);
        this.rvApertura.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptOperacionesCajero.rdlc";

        string Filtro = "";
        Filtro = "Desde: " + dtpDesde.Value.ToShortDateString() + " al " + dtpHasta.Value.ToShortDateString();

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[3];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        this.rvApertura.LocalReport.SetParameters(Parametros);
        this.rvApertura.RefreshReport();
        new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtros: {1} ", this.rvApertura.LocalReport.ReportEmbeddedResource, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
      }
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbCaja.SelectedIndex = -1;
      this.txCajero.Text = string.Empty;
      this.dtpDesde.Value = DateTime.Now.Date;
      this.dtpHasta.Value = DateTime.Now.Date;
      this.optApertura.Checked = false;
      this.optCierre.Checked = false;
      this.optTodas.Checked = false;

      this.rvApertura.Clear();
    }

    private void frmRepAperturaCajero_Load(object sender, EventArgs e)
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

        IEnumerable<EPK_Caja> cajas = new Cajas().ObtenerTodas();
        if (cajas != null && cajas.Count() > 0)
        {
            this.cbCaja.DataSource = cajas;
            this.cbCaja.ValueMember = "IdCaja";
            this.cbCaja.DisplayMember = "Descripcion";
            this.cbCaja.SelectedIndex = -1;
        }

        this.DisableReportViewerExportWord();
    }
    private void frmRepOperacionesCajero_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Operaciones de Cajeros - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void rvApertura_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtros: {1} ", this.rvApertura.LocalReport.ReportEmbeddedResource, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void rvApertura_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtros: {1} ", this.rvApertura.LocalReport.ReportEmbeddedResource, dtpDesde.Value.ToShortDateString() + " - " + dtpHasta.Value.ToShortDateString()));
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
        if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
            this.dtpHasta.Value = ((DateTimePicker)sender).Value;

        this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }
    #endregion Events

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvApertura.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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