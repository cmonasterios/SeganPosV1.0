using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmComprobanteDeposito : Form
  {

    #region Public Properties

    public long IdDeposito { get; set; }
    public bool Forzar { get; set; }

    #endregion

    #region Constructor

    public frmComprobanteDeposito(bool forzar = true)
    {
      InitializeComponent();

      this.Forzar = forzar;
    }

    #endregion

    #region Events

    private void frmComprobanteDeposito_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      try {
        EPK_DepositoEncabezado deposito = new DAL.Depositos().Obtener(this.IdDeposito);

        if (deposito == null) {
          this.FormClosing -= new FormClosingEventHandler(this.frmComprobanteDeposito_FormClosing);
          this.Close();
        }

        List<DetalleDeposito> detalle = new List<DetalleDeposito>();

        if (deposito.EPK_DepositoDetalle.FirstOrDefault() != null)
          detalle = deposito.EPK_DepositoDetalle.Select(dd => new DetalleDeposito {
            Denominacion = dd.EPK_Denominacion.Denominacion,
            Cantidad = dd.Cantidad,
            Total = dd.EPK_Denominacion.Denominacion * dd.Cantidad
          }).OrderByDescending(det => det.Denominacion).ToList();

        this.detalleDepositoBindingSource.DataSource = detalle;

        string nroControl = deposito.IdDeposito.ToString();
        string fechaVenta = deposito.FechaVenta.ToString("d");
        string nroTrans = deposito.NumeroTransaccion.Trim();
        string serial = deposito.SerialPrecinto.Trim();
        string nombreEnt = deposito.IdEntidad.HasValue ? deposito.EPK_EntidadFinanciera.Nombre.Trim() : "N/A";
        string obs = deposito.Observaciones.Trim();

        string nomResp1 = deposito.EPK_Usuario.Identificacion.Trim();
        string cargoResp1 = deposito.EPK_Usuario.EPK_UsuarioApp.Where(ua => ua.IdApp == EstadoAplicacion.IDApp).Select(ua => ua.EPK_Perfil.Descripcion).FirstOrDefault();
        string nomResp2 = deposito.IdUsuarioResponsable2.HasValue ? deposito.EPK_Usuario1.Identificacion.Trim() : "N/A";
        string cargoResp2 = deposito.IdUsuarioResponsable2.HasValue ?
          deposito.EPK_Usuario1.EPK_UsuarioApp.Where(ua => ua.IdApp == EstadoAplicacion.IDApp).
          Select(ua => ua.EPK_Perfil.Descripcion).FirstOrDefault() : "N/A";

        Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[12];

        Parametros[0] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterTitulo", EstadoAplicacion.TiendaActual.Descripcion);
        Parametros[1] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterUsuario", EstadoAplicacion.UsuarioActual.Identificacion);

        Parametros[2] = new Microsoft.Reporting.WinForms.ReportParameter("NroControl", nroControl);
        Parametros[3] = new Microsoft.Reporting.WinForms.ReportParameter("FechaVenta", fechaVenta);
        Parametros[4] = new Microsoft.Reporting.WinForms.ReportParameter("NumeroTransaccion", nroTrans);
        Parametros[5] = new Microsoft.Reporting.WinForms.ReportParameter("SerialPrecinto", serial);
        Parametros[6] = new Microsoft.Reporting.WinForms.ReportParameter("NombreEntidad", nombreEnt);
        Parametros[7] = new Microsoft.Reporting.WinForms.ReportParameter("Observaciones", obs);

        Parametros[8] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterRepons", nomResp1);
        Parametros[9] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterReponsPerf", cargoResp1);
        Parametros[10] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterSuperv", nomResp2);
        Parametros[11] = new Microsoft.Reporting.WinForms.ReportParameter("ReportParameterSupervPerf", cargoResp2);

        this.rvComprobante.LocalReport.SetParameters(Parametros);
        this.rvComprobante.RefreshReport();

        // Log Auditoria
        new NLogLogger().Info(string.Format("Se consultó reporte {0}", this.Name));

        this.DisableReportViewerExportWord();

        if (!this.Forzar)
          this.FormClosing -= new FormClosingEventHandler(this.frmComprobanteDeposito_FormClosing);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        this.FormClosing -= new FormClosingEventHandler(this.frmComprobanteDeposito_FormClosing);
        this.Close();
      }
    }

    private void frmComprobanteDeposito_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
    }

    private void rvComprobante_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se imprimió reporte {0} , ", this.Name));
    }

    private void rvComprobante_ReportExport(object sender, Microsoft.Reporting.WinForms.ReportExportEventArgs e)
    {
      // Log Auditoria
      new NLogLogger().Info(string.Format("Se exportó reporte {0} ,  ", this.Name));

      SaveFileDialog saveFileDialog = new SaveFileDialog();

      if (rvComprobante.ExportDialog(e.Extension) == DialogResult.OK)
        this.FormClosing -= new FormClosingEventHandler(this.frmComprobanteDeposito_FormClosing);

      e.Cancel = true;
    }

    private void frmComprobanteDeposito_Activated(object sender, EventArgs e)
    {
      this.Text = "Comprobante de Depósito " + EstadoAplicacion.UsuarioActual.Identificacion + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.rvComprobante.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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
