using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmVerCierreVentas : Form
  {

    #region Public Properties

    public int IdCierreV { get; set; }

    #endregion

    #region Constructor

    public frmVerCierreVentas()
    {
      InitializeComponent();
    }

    public frmVerCierreVentas(int idCierreV)
    {
      InitializeComponent();

      this.IdCierreV = idCierreV;
    }

    #endregion

    #region Events

    private void frmVerCierreVentas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void grdCierreOtrosPagos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void grdCierreOtrosPagos_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void frmVerCierreVentas_Activated(object sender, EventArgs e)
    {
      this.Text = "Ver Cierre de Ventas - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      if (this.IdCierreV <= 0)
        return;

      EPK_CierreVentaEncabezado cierreVentas = new CierreVentas().Obtener(this.IdCierreV);

      if (cierreVentas == null)
        return;

      this.txFecha.Text = cierreVentas.Fecha.ToString("d");
      this.txUsuario.Text = cierreVentas.EPK_Usuario.Identificacion.Trim();

      int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
      if (cierreVentas.EPK_CierreVentaPagos.FirstOrDefault() != null &&
        cierreVentas.EPK_CierreVentaPagos.FirstOrDefault(c => c.IdFormaPago == idEfectivo) != null)
        this.txObsEf.Text = cierreVentas.EPK_CierreVentaPagos.FirstOrDefault(c => c.IdFormaPago == idEfectivo).Observacion;

      if (!string.IsNullOrEmpty(cierreVentas.Observaciones.Trim())) {
        this.txObs.Text = cierreVentas.Observaciones.Trim();
        this.lbObs.Visible = this.txObs.Visible = true;
      }

      decimal totalRecibido = cierreVentas.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago == idEfectivo).Sum(cp => cp.MontoPagos);
      decimal totalCierreEf = cierreVentas.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago == idEfectivo).Sum(cp => cp.MontoCierre);

      List<CierreVentasOtrosPagos> cierrePOS = cierreVentas.EPK_CierreVentaPOS.Select(
        cp => new CierreVentasOtrosPagos {
          IdFormaPago = cp.IdFormaPago,
          IdPOS = cp.IdPOS,
          POS = cp.EPK_POS.Descripcion,
          FormaPago = cp.EPK_FormaPago.Descripcion,
          TotalMontoCierre = cp.MontoCierre,
          TotalMontoSistema = cp.TotalDia,
          Diferencia = (cp.TotalDia - cp.MontoCierre),
          Lote = 0,
          Observaciones = cp.Observacion
        }).ToList();

      List<CierreVentasOtrosPagos> cierrePagos = cierreVentas.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago != idEfectivo).Select(
        cp => new CierreVentasOtrosPagos {
          IdFormaPago = cp.IdFormaPago,
          IdPOS = 0,
          POS = string.Empty,
          FormaPago = cp.EPK_FormaPago.Descripcion,
          TotalMontoCierre = cp.MontoCierre,
          TotalMontoSistema = cp.MontoPagos,
          Diferencia = (cp.MontoPagos - cp.MontoCierre),
          Lote = 0,
          Observaciones = cp.Observacion
        }).ToList();

      List<CierreVentasOtrosPagos> cierreOtrosPagos = cierrePOS.Union(cierrePagos).ToList().OrderBy(cp => cp.IdPOS).ThenBy(cp => cp.IdFormaPago).ToList();

      decimal totalOtrosPagos = cierreOtrosPagos.Sum(cop => cop.TotalMontoSistema);
      decimal totalOtrosPagosCierre = cierreOtrosPagos.Sum(cop => cop.TotalMontoCierre);
      decimal totalCierre = cierreOtrosPagos.Sum(cop => cop.TotalMontoCierre) + totalCierreEf;

      this.txTotalRecibido.Text = totalRecibido.ToString("C2");
      this.txMontoCierre.Text = totalCierreEf.ToString("C2");
      this.txDifEfectivo.Text = (totalRecibido - totalCierreEf).ToString("C2");

      this.txTotalEfectivo.Text = totalRecibido.ToString("C2");
      this.txTotalOtros.Text = totalOtrosPagos.ToString("C2");
      this.txtlEfectivoCierre.Text = totalCierreEf.ToString("C2");
      this.txtlOtrosPagosCierre.Text = totalOtrosPagosCierre.ToString("C2");

      this.txTotalSistema.Text = (totalOtrosPagos + totalRecibido).ToString("C2");
      this.txTotalCierre.Text = totalCierre.ToString("C2");
      this.txDiferencia.Text = (totalOtrosPagos + totalRecibido - totalCierre).ToString("C2");

      this.grdCierreOtrosPagos.DataSource = cierreOtrosPagos;

      if (((totalOtrosPagos + totalRecibido) - totalCierre) > 0)
          this.txDiferencia.ForeColor = Color.Red;
      else
          this.txDiferencia.ForeColor = Color.Black;
    }

    #endregion

  }
}
