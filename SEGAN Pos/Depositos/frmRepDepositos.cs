using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmRepDepositos : Form
  {

    #region Public Properties

    public decimal VentasEfectivo { get; set; }
    public decimal VentasCheque { get; set; }
    public List<DepositosConsulta> datosDep { get; set; }

    #endregion

    #region Constructor

    public frmRepDepositos()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmRepDepositos_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      decimal depEfectivo = this.datosDep.Sum(d => d.MontoEfectivo);
      decimal depCheque = this.datosDep.Sum(d => d.MontoCheque);

      DateTime fVDesde = this.datosDep.OrderBy(d => d.FechaVenta).FirstOrDefault().FechaVenta.Value;
      DateTime fVHasta = this.datosDep.OrderByDescending(d => d.FechaVenta).FirstOrDefault().FechaVenta.Value;

      this.DepositosConsultaBindingSource.DataSource = this.datosDep;

      Microsoft.Reporting.WinForms.ReportParameter[] Parametros = new Microsoft.Reporting.WinForms.ReportParameter[12];

      Parametros[0] = new ReportParameter("rpNombreTienda", EstadoAplicacion.TiendaActual.Descripcion);
      Parametros[1] = new ReportParameter("rpVentasEf", this.VentasEfectivo.ToString("C2"));
      Parametros[2] = new ReportParameter("rpVentasCh", this.VentasCheque.ToString("C2"));
      Parametros[3] = new ReportParameter("fpVentasTot", (this.VentasEfectivo + this.VentasCheque).ToString("C2"));
      Parametros[4] = new ReportParameter("rpDepEf", depEfectivo.ToString("C2"));
      Parametros[5] = new ReportParameter("rpDepCh", depCheque.ToString("C2"));
      Parametros[6] = new ReportParameter("rpDepTot", (depEfectivo + depCheque).ToString("C2"));
      Parametros[7] = new ReportParameter("rpDifEf", (this.VentasEfectivo - depEfectivo).ToString("C2"));
      Parametros[8] = new ReportParameter("rpDifCh", (this.VentasCheque - depCheque).ToString("C2"));
      Parametros[9] = new ReportParameter("rpDifTot", ((this.VentasEfectivo + this.VentasCheque) - (depEfectivo + depCheque)).ToString("C2"));
      Parametros[10] = new ReportParameter("rpFeVenDesde", fVDesde.ToLongDateString());
      Parametros[11] = new ReportParameter("rpFeVenHasta", fVHasta.ToLongDateString());

      this.reportViewer1.LocalReport.SetParameters(Parametros);
      this.reportViewer1.RefreshReport();

      // Log Auditoria
      // new NLogLogger().Info(string.Format("Se consultó reporte {0}", this.Name));

      this.DisableReportViewerExportWord();
    }

    private void frmRepDepositos_Activated(object sender, EventArgs e)
    {
      this.Text = "Consulta de Depósitos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void DisableReportViewerExportWord()
    {
      var toolStrip = this.reportViewer1.Controls.Find("toolStrip1", true)[0] as ToolStrip;

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
