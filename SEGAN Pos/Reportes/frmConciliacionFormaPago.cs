using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmConciliacionFormaPago : Form
  {
    #region Constructor

    public frmConciliacionFormaPago()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      int? intIdCaja = null;
      byte? intIdFormaPago = null;
      int? intIdEntidad = null;
      int? intIdPOS = null;
      int? intIdMF = null;
      //int? intIdCajero = null;
      decimal? decMontoD = null;
      decimal? decMontoH = null;
      string strCajero = "";

      if (cbCaja.SelectedIndex >= 0) {
        intIdCaja = (int)cbCaja.SelectedValue;
      }

      if (cbFormaPago.SelectedIndex >= 0) {
        intIdFormaPago = (byte)cbFormaPago.SelectedValue;
      }

      if (cbBanco.SelectedIndex >= 0) {
        intIdEntidad = (int)cbBanco.SelectedValue;
      }

      if (cbPOS.SelectedIndex >= 0) {
        intIdPOS = (int)cbPOS.SelectedValue;
      }

      if (cbMF.SelectedIndex >= 0) {
        intIdMF = (int)cbMF.SelectedValue;
      }

      if (nudMontoD.Value > 0) {
        decMontoD = (decimal)nudMontoD.Value;
      }

      if (nudMontoH.Value > 0) {
        decMontoH = (decimal)nudMontoH.Value;
      }

      //if (cbCajero.SelectedIndex >= 0) {
      //  intIdCajero = (int)cbCajero.SelectedValue;
      //}

      strCajero = txtCajero.Text;

      if (optResumen.Checked) {
        this.ePKspReporteConciliacionFormaPagoResultBindingSource.DataSource = new DAL.Reportes().ReporteConciliacionFormaPago(
            dtpDesde.Value, intIdCaja, intIdFormaPago,
            intIdEntidad, intIdPOS,
            decMontoD, decMontoH,
            intIdMF, strCajero);

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsResumen";
        reportDataSource1.Value = this.ePKspReporteConciliacionFormaPagoResultBindingSource;
        this.rvPagos.LocalReport.DataSources.Add(reportDataSource1);
        this.rvPagos.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptConsolidadoFormaPago.rdlc";
        string Filtro = "";

        Filtro = "Fecha: " + dtpDesde.Value.ToShortDateString();

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTipo", " Consolidado ");
        this.rvPagos.LocalReport.SetParameters(Parametros);
        this.rvPagos.RefreshReport();
      }

      if (optDetalle.Checked) {
        this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource.DataSource = new DAL.Reportes().ReporteConciliacionFormaPagoDetalle(
            dtpDesde.Value, intIdCaja, intIdFormaPago,
            intIdEntidad, intIdPOS,
            decMontoD, decMontoH,
            intIdMF, strCajero);

        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

        reportDataSource1.Name = "dsDetalle";
        reportDataSource1.Value = this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource;
        this.rvPagos.LocalReport.DataSources.Add(reportDataSource1);
        this.rvPagos.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptConsolidadoFormaPagoDetalle.rdlc";
        string Filtro = "";

        Filtro = "Fecha: " + dtpDesde.Value.ToShortDateString();

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[4];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFiltro", Filtro);
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTipo", " Detallado ");
        this.rvPagos.LocalReport.SetParameters(Parametros);
        this.rvPagos.RefreshReport();
      }
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se consultó reporte {0} , Filtro: {1} ", this.Name, dtpDesde.Value.ToShortDateString()));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.cbBanco.SelectedIndex = -1;
      this.cbCaja.SelectedIndex = -1;
      this.cbFormaPago.SelectedIndex = -1;
      this.cbPOS.SelectedIndex = -1;
      this.cbMF.SelectedIndex = -1;
      this.txtCajero.Text = string.Empty;
      this.nudMontoD.Value = 0;
      this.nudMontoH.Value = 0;
      this.dtpDesde.Value = DateTime.Now.Date;
      this.optResumen.Checked = false;
      this.optDetalle.Checked = false;

      this.rvPagos.Clear();
    }

    private void frmConciliacionFormaPago_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Consolidado por Formas de Pago - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmConciliacionFormaPago_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
      this.dtpDesde.MaxDate = DateTime.Today.Date; 

      this.CargarCombos();

      this.DisableReportViewerExportWord();
    }
    private void groupBoxCriterios_AutoSizeChanged(object sender, EventArgs e)
    {
      this.Text = "Reporte Consolidado por Formas de Pago " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void rvPagos_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , Filtro: {1} ", this.Name, dtpDesde.Value.ToShortDateString()));
    }

    private void rvPagos_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
        new NLogLogger().Info(string.Format("Se exportó reporte {0} , Filtro: {1} ", this.Name, dtpDesde.Value.ToShortDateString()));
    }
    #endregion Events

    #region Private Methods

    private void CargarCombos()
    {
      IEnumerable<EPK_Caja> cajas = new Cajas().ObtenerTodas();
      if (cajas != null && cajas.Count() > 0) {
        this.cbCaja.DataSource = cajas;
        this.cbCaja.ValueMember = "IdCaja";
        this.cbCaja.DisplayMember = "Descripcion";
        this.cbCaja.SelectedIndex = -1;
      }

      IEnumerable<EPK_FormaPago> fp = new FormasPago().ObtenerTodas();
      this.cbFormaPago.DataSource = fp;
      this.cbFormaPago.ValueMember = "IdFormaPago";
      this.cbFormaPago.DisplayMember = "Descripcion";
      this.cbFormaPago.SelectedIndex = -1;

      IEnumerable<EPK_POS> POS = new POS().ObtenerTodos();
      this.cbPOS.DataSource = POS;
      this.cbPOS.ValueMember = "Idpos";
      this.cbPOS.DisplayMember = "Descripcion";
      this.cbPOS.SelectedIndex = -1;

      IEnumerable<EPK_EntidadFinanciera> Bancos = new EntidadesFinancieras().ObtenerTodos();
      this.cbBanco.DataSource = Bancos;
      this.cbBanco.ValueMember = "IdEntidad";
      this.cbBanco.DisplayMember = "Nombre";
      this.cbBanco.SelectedIndex = -1;

      IEnumerable<EPK_Dispositivo> MF = new Dispositivos().ObtenerMF();
      this.cbMF.DataSource = MF;
      this.cbMF.ValueMember = "IdDispositivo";
      this.cbMF.DisplayMember = "Serial";
      this.cbMF.SelectedIndex = -1;
    }

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvPagos.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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