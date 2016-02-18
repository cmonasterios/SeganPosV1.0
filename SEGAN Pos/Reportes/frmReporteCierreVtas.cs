using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmReporteCierreVtas : Form
  {

    #region Public Properties

    public int idCierreVentas { get; set; }
    public decimal totalRecibido { get; set; }
    public string ObservacionesG { get; set; }
    public decimal sumaAperturas { get; set; }
    public decimal montoAlivios { get; set; }
    public decimal montoCierre { get; set; }
    public string obsEfectivo { get; set; }
    public DateTime fechaIni { get; set; }
    public List<CierreVentasOtrosPagos> _itemsCierreOtrosPagos { get; set; }

    #endregion

    #region Constructor

    public frmReporteCierreVtas()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmReporteCierreVtas_Load(object sender, EventArgs e)
    {
      this.Text = this.Text + " - " + Application.ProductName;

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.DisableReportViewerExportWord();

      try {
        DateTime fechaFin = this.fechaIni.Date.AddDays(1).AddSeconds(-1);

        this.CierreVentasOtrosPagosBindingSource.DataSource = this._itemsCierreOtrosPagos;
        this.cierreVtasInventarioBindingSource.DataSource = new DAL.Reportes().ObtenerCierreVtasInv(this.fechaIni, fechaFin);
        this.ePKCierreMaquinaFiscalBindingSource.DataSource = new DAL.Reportes().CierreVtasEfectivo(this.fechaIni, fechaIni);
        this.cierreVtasMaqFiscalZBindingSource.DataSource = new DAL.Reportes().CierreVtasEfectivoZ(this.fechaIni, fechaIni);
        this.cierreVtasNotasCreditoBindingSource.DataSource = new DAL.Reportes().CierreVtasNC(this.fechaIni, fechaFin);
        this.consolidadoCierreVtasBindingSource.DataSource = new DAL.Reportes().CierreTotalConsolidados(this.fechaIni, this.fechaIni);
        this.cierreVtasMaqFiscalNCBindingSource.DataSource = new DAL.Reportes().CierreVtasMFNC(this.fechaIni, this.fechaIni);
        this.cierreVtasMaqFiscalNCZBindingSource.DataSource = new DAL.Reportes().CierreVtasMFNCZ(this.fechaIni, this.fechaIni);
        this.listadoFacturasAnuladasBindingSource.DataSource = new Facturas().ConsultarAnuladas(this.fechaIni, fechaFin);

        ConsolidadoTotales ccvtas = new DAL.Reportes().CierreVtasTotales(this.fechaIni, fechaFin);
        decimal cNC = new DAL.Reportes().TotalConsolidadoNC(this.fechaIni, fechaFin);

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[16];
        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);
        string perfil = EstadoAplicacion.UsuarioActual.EPK_UsuarioApp.Where(ua => ua.IdApp == EstadoAplicacion.IDApp).FirstOrDefault().EPK_Perfil.Descripcion;
        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterReponsPerf", perfil);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalRec", totalRecibido.ToString());
        Parametros[4] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterSumApert", sumaAperturas.ToString());
        Parametros[5] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterMtoAliv", montoAlivios.ToString());
        Parametros[6] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterMtoCierre", montoCierre.ToString());
        Parametros[7] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterObserv", obsEfectivo == "" ? "Sin Observaciones" : obsEfectivo.ToString());
        Parametros[8] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalBI", ccvtas.TotalBI.ToString() == null ? "0" : ccvtas.TotalBI.ToString());
        Parametros[9] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalIVA", ccvtas.TotalIVA.ToString() == null ? "0" : ccvtas.TotalIVA.ToString());
        Parametros[10] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalExento", ccvtas.TotalExento.ToString() == null ? "0" : ccvtas.TotalExento.ToString());
        Parametros[11] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalDesc", ccvtas.TotalDesc.ToString() == null ? "0" : ccvtas.TotalDesc.ToString());
        Parametros[12] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTotalNC", cNC.ToString());
        Parametros[13] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterFechaIni", fechaIni.ToShortDateString());
        Parametros[14] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterOG", ObservacionesG == "" ? "Sin Observaciones" : ObservacionesG.ToString());
        Parametros[15] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterNro", idCierreVentas.ToString());
        this.rvCierreVtas.LocalReport.SetParameters(Parametros);
        this.rvCierreVtas.RefreshReport();

        // Log Auditoria
        new NLogLogger().Info(string.Format("Se consultó reporte {0}", this.Name));
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        MessageBox.Show(Properties.Resources.MsgErrorCierreVentas, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        this.FormClosing -= new FormClosingEventHandler(this.frmReporteCierreVtas_FormClosing);
        this.Close();
      }
    }

    private void frmReporteCierreVtas_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
    }

    private void rvCierreVtas_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , ", this.Name));
    }

    private void rvCierreVtas_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} ,  ", this.Name));

      SaveFileDialog saveFileDialog = new SaveFileDialog();
      if (rvCierreVtas.ExportDialog(e.Extension) == DialogResult.OK) {
        this.FormClosing -= new FormClosingEventHandler(this.frmReporteCierreVtas_FormClosing);

      }
      e.Cancel = true;
    }

    private void frmReporteCierreVtas_Activated(object sender, EventArgs e)
    {
      this.Text = "Reporte Cierre de Ventas - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvCierreVtas.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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

  }
}
