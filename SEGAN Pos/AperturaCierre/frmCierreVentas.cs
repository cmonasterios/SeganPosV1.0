using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmCierreVentas : Form
  {

    #region Private Properties

    private decimal _totalRecibido { get; set; }
    private decimal _sumaAperturas { get; set; }
    private decimal _montoAlivios { get; set; }
    private decimal _montoCierre { get; set; }
    private decimal _montoCierreOrig { get; set; }
    private string _obsEfectivo { get; set; }
    private int _idCierreVentas { get; set; }

    private List<CierreVentasOtrosPagos> _itemsCierreOtrosPagos { get; set; }
    private List<ConsolidadoCierreVtas> _CierreTotalConsolidados { get; set; }
    private List<CierreVtasNotasCredito> _CierreVtasNC { get; set; }
    private List<CierreVtasMaqFiscal> _CierreVtasEfectivo { get; set; }
    private List<CierreVtasMaqFiscalZ> _CierreVtasEfectivoZ { get; set; }
    private List<CierreVtasInventario> _CierreVtasInventario { get; set; }

    #endregion

    #region Constructor

    public frmCierreVentas()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmCierreVentas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpFechaCierre.Format = DateTimePickerFormat.Custom;
      this.dtpFechaCierre.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txObs, "");
      this.errorProvider1.SetError(btAjustar, "");
      
      bool hayDif = false;
      if ((this._totalRecibido - this._montoCierre) != 0 && this._obsEfectivo.Length < 15) {
        this.errorProvider1.SetError(btAjustar, Properties.Resources.ValIngreseObs);
        hayDif = true;
      }

      if (!hayDif)
        foreach (CierreVentasOtrosPagos item in this._itemsCierreOtrosPagos)
          if (item.Diferencia != 0 && (string.IsNullOrEmpty(item.Observaciones) || item.Observaciones.Length < 15)) {
            hayDif = true;
            break;
          }

      if (hayDif) {
        MessageBox.Show(Properties.Resources.MsgDifCierreVen, "Advertencia - " + this.Text, MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
        return;
      }

      this.txObs.Text = this.txObs.Text.Trim();

      if (this.txObs.Text.Length < 15) {
        this.errorProvider1.SetError(this.txObs, string.Format(Properties.Resources.ValMinCar, 15));
        this.txObs.Focus();
        return;
      }

      if (MessageBox.Show(Properties.Resources.MsgPregCierreVentas, "Confirmación " + this.Text,
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) {
        return;
      }

      this._idCierreVentas = this.GuardarCierreVenta();

      if (this._idCierreVentas <= 0)
      {
        MessageBox.Show(Properties.Resources.MsgErrorCierreVentas, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        new NLogLogger().Info(Properties.Resources.MsgErrorCierreVentas); // Log Auditoria
        return;
      }

      // Emerge la ventada del reporte Cierre Vtas
      frmReporteCierreVtas fCVtas = new frmReporteCierreVtas();
      fCVtas.idCierreVentas = this._idCierreVentas;
      fCVtas.fechaIni = this.dtpFechaCierre.Value.Date;
      fCVtas.totalRecibido = this._totalRecibido;
      fCVtas.sumaAperturas = this._sumaAperturas;
      fCVtas.montoAlivios = this._montoAlivios;
      fCVtas.montoCierre = this._montoCierre;
      fCVtas.obsEfectivo = this._obsEfectivo;
      fCVtas._itemsCierreOtrosPagos = this._itemsCierreOtrosPagos;
      fCVtas.ObservacionesG = this.txObs.Text == null ? "" : this.txObs.Text.ToString();
      fCVtas.ShowDialog();

      MessageBox.Show(Properties.Resources.MsgExitoCierreVentas, this.Text,
        MessageBoxButtons.OK, MessageBoxIcon.Information);

      new NLogLogger().Error(Properties.Resources.MsgExitoCierreVentas); // Log Auditoria
      this.Close();
    }

    private void grdCierreOtrosPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (!this.btOK.Enabled)
        return;

      CierreVentasOtrosPagos itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as CierreVentasOtrosPagos);

      if (itemSel == null)
        return;

      new frmEdCierreVentas(itemSel).ShowDialog();

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    private void grdCierreOtrosPagos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void grdCierreOtrosPagos_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void frmCierreVentas_Shown(object sender, EventArgs e)
    {
      if (new AlivioEfectivo().CantidadPorAprobar() > 0) {
        MessageBox.Show(Properties.Resources.MsgAliviosPendientes, "Error - " + this.Text,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
        return;
      }

      this.dtpFechaCierre.MinDate = DateTime.Today.AddYears(-5);
      this.dtpFechaCierre.MaxDate = DateTime.Today.AddYears(+5);

      this.dtpFechaCierre.Value = DateTime.Today;
    }

    private void dtpFechaCierre_ValueChanged(object sender, EventArgs e)
    {
      this.Limpiar();
      this.CargarDatos();
    }

    private void btAjustar_Click(object sender, EventArgs e)
    {
      frmEdCierreVentasEf fEditEfect = new frmEdCierreVentasEf();
      fEditEfect.MontoSistema = this._totalRecibido;
      fEditEfect.MontoCierre = this._montoCierre;
      fEditEfect.MontoCierreOrig = this._montoCierreOrig;
      fEditEfect.Observaciones = this._obsEfectivo;
      fEditEfect.ShowDialog();

      if (fEditEfect.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      this._montoCierre = fEditEfect.MontoCierre;
      this._obsEfectivo = fEditEfect.Observaciones;

      this.txMontoCierre.Text = this._montoCierre.ToString("C2");
      this.txDifEfectivo.Text = (this._totalRecibido - this._montoCierre).ToString("C2");
      this.txDifEfectivo.BackColor = SystemColors.Control;
      this.txDifEfectivo.ForeColor = this.ColorParaDiferencias(this._totalRecibido, this._montoCierre);
      this.txDifEfectivo.ReadOnly = true;

      this.errorProvider1.SetError(((Button)sender), "");

      this.CalcularTotales();
    }

    private void frmCierreVentas_Activated(object sender, EventArgs e)
    {
      this.Text = "Cierre de Ventas - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private methods

    private int GuardarCierreVenta()
    {
      if (!new CierreCajero().ActualizarLote(this.dtpFechaCierre.Value.Date, this._itemsCierreOtrosPagos))
        return 0;

      EPK_CierreVentaEncabezado cierreVtas = new EPK_CierreVentaEncabezado();

      cierreVtas.IdUsuario = EstadoAplicacion.UsuarioActual.IdUsuario;
      cierreVtas.Fecha = this.dtpFechaCierre.Value.Date;
      cierreVtas.Observaciones = this.txObs.Text.Trim();
      cierreVtas.EPK_CierreVentaPOS = this.GenerarDetalleCierrePOS();
      cierreVtas.EPK_CierreVentaPagos = this.GenerarDetalleCierrePagos();

      ConsolidadoTotales ccvtas = new DAL.Reportes().CierreVtasTotales(this.dtpFechaCierre.Value.Date,
        this.dtpFechaCierre.Value.Date.AddDays(1).Date);

      if (ccvtas != null) {
        cierreVtas.MontoBase = ccvtas.TotalBI;
        cierreVtas.MontoIVA = ccvtas.TotalIVA;
        cierreVtas.MontoDescuento = ccvtas.TotalDesc;
        cierreVtas.MontoExento = ccvtas.TotalExento;

        decimal cNC = new DAL.Reportes().TotalConsolidadoNC(this.dtpFechaCierre.Value.Date, this.dtpFechaCierre.Value.Date);

        cierreVtas.MontoTotal = ccvtas.TotalBI + ccvtas.TotalExento + ccvtas.TotalIVA - cNC;
      }

      cierreVtas.TotalAlivios = this._montoAlivios;
      cierreVtas.TotalAperturas = this._sumaAperturas;

      int Result = new CierreVentas().Nuevo(cierreVtas);

      return Result;
    }

    private List<EPK_CierreVentaPagos> GenerarDetalleCierrePagos()
    {
      List<EPK_CierreVentaPagos> results = new List<EPK_CierreVentaPagos>();

      // Efectivo
      int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
      results.Add(new EPK_CierreVentaPagos {
        IdFormaPago = (byte)idEfectivo,
        MontoPagos = this._totalRecibido,
        MontoCierre = this._montoCierre,
        Observacion = this._obsEfectivo
      });

      // Otras formas de pago que no tienen POS
      if (this._itemsCierreOtrosPagos != null)
        foreach (CierreVentasOtrosPagos item in this._itemsCierreOtrosPagos.Where(cvp => cvp.IdPOS == 0).ToList()) {
          results.Add(new EPK_CierreVentaPagos {
            IdFormaPago = (byte)item.IdFormaPago,
            MontoPagos = item.TotalMontoSistema,
            MontoCierre = item.TotalMontoCierre,
            Observacion = item.Observaciones
          });
        }

      return results;
    }

    private List<EPK_CierreVentaPOS> GenerarDetalleCierrePOS()
    {
      List<EPK_CierreVentaPOS> listCierreVentasDetalle = new List<EPK_CierreVentaPOS>();

      if (this._itemsCierreOtrosPagos != null)
        foreach (CierreVentasOtrosPagos item in this._itemsCierreOtrosPagos.Where(cvp => cvp.IdPOS > 0).ToList()) {
          listCierreVentasDetalle.Add(new EPK_CierreVentaPOS {
            IdFormaPago = (byte)item.IdFormaPago,
            IdPOS = item.IdPOS,
            LotePOS = item.Lote,
            TotalDia = item.TotalMontoSistema,
            MontoCierre = item.TotalMontoCierre,
            Observacion = item.Observaciones
          });
        }

      return listCierreVentasDetalle;
    }

    private void CargarDatos()
    {
      this.Cursor = Cursors.WaitCursor;

      DateTime fechaSel = this.dtpFechaCierre.Value.Date;

      // Total efectivo -> monto en efectivo de la facturación
      this._totalRecibido = new Facturas().MontoEfectivo(fechaSel, fechaSel);

      // Total aperturas
      this._sumaAperturas = new AperturaCajero().Total(fechaSel, fechaSel);

      // total alivios -> total del todos los alivios
      this._montoCierre = this._montoCierreOrig = this._montoAlivios = new AlivioEfectivo().TotalAprobados(fechaSel, fechaSel);

      this.txMontoApertura.Text = this._sumaAperturas.ToString("C2");
      this.txTotalRecibido.Text = this._totalRecibido.ToString("C2");
      this.txTotalEfectivo.Text = this._totalRecibido.ToString("C2");
      this.txTotalAlivios.Text = this._montoAlivios.ToString("C2");
      this.txMontoCierre.Text = this._montoCierre.ToString("C2");
      this.txDifEfectivo.Text = (this._totalRecibido - this._montoCierre).ToString("C2");
      this.txDifEfectivo.BackColor = SystemColors.Control;
      this.txDifEfectivo.ForeColor = this.ColorParaDiferencias(this._totalRecibido, this._montoCierre);
      this.txDifEfectivo.ReadOnly = true;

      this._itemsCierreOtrosPagos = this.GenerarResumenVentaOtrosPagos();
      this.grdCierreOtrosPagos.DataSource = this._itemsCierreOtrosPagos;

      this.CalcularTotales();

      this.btOK.Enabled = this.btAjustar.Enabled = this.txObs.Enabled = false;

      List<EPK_Usuario> cajeros = new CierreCajero().ObtenerPendientes(fechaSel);
      int cierresPend = cajeros.Count();
      this.txCierresPend.Text = cierresPend.ToString();

      EPK_CierreVentaEncabezado cierreExiste = new CierreVentas().Obtener(fechaSel);

      this.Cursor = Cursors.Default;

      if (cierreExiste != null)
        return;

      if (new Dispositivos().PendientesPorCierre(fechaSel).Count() > 0) {
        frmCierreMFPend fCierreMFPend = new frmCierreMFPend(fechaSel);
        fCierreMFPend.ShowDialog();

        List<EPKCierreMaquinaValidar> dispCaja = fCierreMFPend.CierreMaquinaValidar;
       // List<DispositivoCaja> dispCaja = fCierreMFPend.DispCaja;
        List<EPK_Dispositivo> dispPend = new Dispositivos().PendientesPorCierre(fechaSel);

        bool notFound = false;
        foreach (EPK_Dispositivo item in dispPend)
          if (dispCaja.Where(d => d.Exclude && d.IdDispositivo == item.IdDispositivo).Count() == 0) {
            notFound = true;
            break;
          }

        if (notFound)
          return;
      }

      if (cierresPend > 0) {
        MessageBox.Show(Properties.Resources.MsgCierresCajPend, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.btOK.Enabled = this.btAjustar.Enabled = this.txObs.Enabled = true;
    }

    private List<CierreVentasOtrosPagos> GenerarResumenVentaOtrosPagos()
    {
      int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");

      DateTime fechaSel = this.dtpFechaCierre.Value.Date;

      List<CierreVentasOtrosPagos> listCierrePagos = new List<CierreVentasOtrosPagos>();

      List<EPK_CierreCajeroEncabezado> _listCierres = new CierreCajero().ObtenerTodos(fechaSel, fechaSel);
      foreach (EPK_CierreCajeroEncabezado item in _listCierres) {
        foreach (EPK_CierreCajeroPOS pagos in item.EPK_CierreCajeroPOS) {
          if (pagos.IdFormaPago == idEfectivo)
            continue;

          if (!listCierrePagos.Exists(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS)) {
            listCierrePagos.Add(new CierreVentasOtrosPagos {
              IdFormaPago = pagos.IdFormaPago,
              IdPOS = pagos.IdPOS,
              POS = pagos.EPK_POS.Descripcion,
              FormaPago = pagos.EPK_FormaPago.Descripcion,
              TotalMontoCierre = pagos.MontoPOS,
              TotalMontoSistema = pagos.MontoPago,
              Diferencia = (pagos.MontoPago - pagos.MontoPOS),
              Lote = pagos.LotePOS
            });
          }
          else {
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).TotalMontoCierre += pagos.MontoPOS;
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).TotalMontoSistema += pagos.MontoPago;
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).Diferencia += (pagos.MontoPago - pagos.MontoPOS);
            if (listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).Lote == 0 ||
              Convert.ToInt16(listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).Lote) < pagos.LotePOS) {
              listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago && a.IdPOS == pagos.IdPOS).Lote = pagos.LotePOS;
            }
          }
        }

        foreach (EPK_CierreCajeroPagos pagos in item.EPK_CierreCajeroPagos) {
          if (pagos.IdFormaPago == idEfectivo)
            continue;

          if (!listCierrePagos.Exists(a => a.IdFormaPago == pagos.IdFormaPago)) {
            listCierrePagos.Add(new CierreVentasOtrosPagos {
              IdFormaPago = pagos.IdFormaPago,
              IdPOS = 0,
              POS = string.Empty,
              FormaPago = pagos.EPK_FormaPago.Descripcion,
              TotalMontoCierre = pagos.MontoCierre,
              TotalMontoSistema = pagos.MontoPagos,
              Diferencia = (pagos.MontoPagos - pagos.MontoCierre),
              Lote = 0
            });
          }
          else {
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago).TotalMontoCierre += pagos.MontoCierre;
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago).TotalMontoSistema += pagos.MontoPagos;
            listCierrePagos.First(a => a.IdFormaPago == pagos.IdFormaPago).Diferencia += (pagos.MontoPagos - pagos.MontoCierre);
          }
        }

      }

      return listCierrePagos.OrderBy(cp => cp.IdPOS).ThenBy(cp => cp.IdFormaPago).ToList();
    }

    public void CalcularTotales()
    {
      try {
        foreach (DataGridViewRow row in this.grdCierreOtrosPagos.Rows) {
          CierreVentasOtrosPagos item = (row.DataBoundItem as CierreVentasOtrosPagos);

          if (item == null)
            continue;

          row.DefaultCellStyle.ForeColor = this.grdCierreOtrosPagos.DefaultCellStyle.ForeColor;

          if (item.Diferencia == 0) {
            row.DefaultCellStyle.Font = new Font(this.grdCierreOtrosPagos.DefaultCellStyle.Font, FontStyle.Regular);
            row.DefaultCellStyle.ForeColor = Color.Green;
          }
          else {
            row.DefaultCellStyle.Font = new Font(this.grdCierreOtrosPagos.DefaultCellStyle.Font, FontStyle.Bold);
            row.DefaultCellStyle.ForeColor = Color.Red;
          }
        }

        decimal totalOtros = this._itemsCierreOtrosPagos.Sum(a => a.TotalMontoSistema);
        decimal totalOtrosCierre = this._itemsCierreOtrosPagos.Sum(a => a.TotalMontoCierre);
        decimal totalSistema = totalOtros + this._totalRecibido;
        decimal totalCierre = totalOtrosCierre + this._montoCierre;

        this.txtlEfectivoCierre.Text = this._montoCierre.ToString("C2");
        this.txtlEfectivoCierre.ForeColor = this.ColorParaDiferencias(_montoCierre, _totalRecibido);

        this.txtlOtrosPagosCierre.Text = totalOtrosCierre.ToString("C2");
        this.txtlOtrosPagosCierre.ForeColor = this.ColorParaDiferencias(totalOtrosCierre, totalOtros);

        this.txTotalOtros.Text = totalOtros.ToString("C2");
        this.txTotalSistema.Text = totalSistema.ToString("C2");

        this.txTotalCierre.Text = totalCierre.ToString("C2");
        this.txTotalCierre.ForeColor = this.ColorParaDiferencias(totalCierre, totalSistema);

        this.txDiferencia.Text = (totalSistema - totalCierre).ToString("C2");
        this.txDiferencia.ForeColor = this.ColorParaDiferencias(totalSistema, totalCierre);

        this.grdCierreOtrosPagos.Refresh();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    public void Limpiar()
    {
      this._totalRecibido = this._sumaAperturas = this._montoAlivios = this._montoCierre = this._montoCierreOrig = 0;
      this._obsEfectivo = string.Empty;

      this.txObs.Text = string.Empty;

      this.txMontoApertura.Text = this.txTotalRecibido.Text = this.txTotalAlivios.Text =
        this.txMontoCierre.Text = this.txDifEfectivo.Text = string.Format("{0:c}", 0);

      this.txTotalEfectivo.Text = this.txTotalOtros.Text = this.txTotalSistema.Text =
        this.txTotalCierre.Text = this.txDiferencia.Text = string.Format("{0:c}", 0);
    }

    public Color ColorParaDiferencias(decimal MontoCierre, decimal MontoSistema)
    {
      if (MontoCierre != MontoSistema)
        return Color.Red;

      return Color.Green;
    }

    #endregion

  }
}
