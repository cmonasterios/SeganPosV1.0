using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmRelacionVentasDiarias : Form
  {
    #region Constructor

    public frmRelacionVentasDiarias()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      string Filtro = "", Filtro2 = "";
      byte? IdFormaPago = null;
      string strObservacion = "";

      CierreVentas cv = new CierreVentas();
      strObservacion = cv.ObtenerObservacion(dtpFecha.Value);

      Filtro = "Fecha de Venta: " + dtpFecha.Value.ToShortDateString();

      if (cbFormaPago.SelectedIndex != -1) {
        IdFormaPago = (byte)cbFormaPago.SelectedValue;
        Filtro2 = ", Forma de pago: " + cbFormaPago.GetItemText(this.cbFormaPago.SelectedItem);
        
      }

      this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource.DataSource =
            new DAL.Reportes().ReporteRelacionVtasDiariaTotalesFP(dtpFecha.Value, IdFormaPago);

      this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource.DataSource =
        new DAL.Reportes().ReporteRelacionVtasDiariaTotales(dtpFecha.Value, IdFormaPago);

      if (optResumen.Checked == true) {
        this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource.DataSource =
          new DAL.Reportes().ReporteRelacionVtasDiaria(dtpFecha.Value, IdFormaPago);

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsRelacion";
        reportDataSource1.Value = this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource1);
        reportDataSource2.Name = "dsTotalesFP";
        reportDataSource2.Value = this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource2);
        reportDataSource3.Name = "dsTotalesGenerales";
        reportDataSource3.Value = this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource3);

        this.rvRelacion.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptRelacionVta.rdlc";

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro + Filtro2);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterObservacion", "Observación: " + strObservacion);
        this.rvRelacion.LocalReport.SetParameters(Parametros);

        this.rvRelacion.RefreshReport();
      }

      if (optDetalle.Checked == true) {
        this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource.DataSource =
          new DAL.Reportes().ReporteRelacionVtasDiariaDetallado(dtpFecha.Value, IdFormaPago);

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsRelacionD";
        reportDataSource1.Value = this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource1);
        reportDataSource2.Name = "dsTotalesFP";
        reportDataSource2.Value = this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource2);
        reportDataSource2.Name = "dsTotales";
        reportDataSource2.Value = this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource;
        this.rvRelacion.LocalReport.DataSources.Add(reportDataSource3);
        this.rvRelacion.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptRelacionVtaDetallado.rdlc";

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro + Filtro2);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterObservacion", "Observación: " + strObservacion);
        this.rvRelacion.LocalReport.SetParameters(Parametros);

        this.rvRelacion.RefreshReport();
      }
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbFormaPago.SelectedIndex = -1;
      this.dtpFecha.Value = DateTime.Now.Date;
      this.optDetalle.Checked = false;
      this.optResumen.Checked = false;

      this.rvRelacion.Clear();
    }

    private void frmRelacionVentasDiarias_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Relación de Ventas Diarias - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmRelacionVentasDiarias_Load(object sender, EventArgs e)
    {
      this.dtpFecha.Format = DateTimePickerFormat.Custom;
      this.dtpFecha.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
      this.dtpFecha.MaxDate = DateTime.Today.Date;

      IEnumerable<EPK_FormaPago> fp = new FormasPago().ObtenerTodas();
      this.cbFormaPago.DataSource = fp;
      this.cbFormaPago.ValueMember = "IdFormaPago";
      this.cbFormaPago.DisplayMember = "Descripcion";
      this.cbFormaPago.SelectedIndex = -1;
      //  this.rvRelacion.RefreshReport();
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.DisableReportViewerExportWord();
    }
    private void groupBoxCriterios_Enter(object sender, EventArgs e)
    {
    }
    #endregion Events

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvRelacion.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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