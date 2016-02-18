using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmVerDeposito : Form
  {

    #region Public Properties

    /// <summary>
    /// 
    /// </summary>
    public long idDeposito { get; set; }

    #endregion

    #region Private Properties

    private EPK_DepositoEncabezado _deposito { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// 
    /// </summary>
    public frmVerDeposito()
    {
      InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idDep"></param>
    public frmVerDeposito(long idDep)
    {
      InitializeComponent();

      this.idDeposito = idDep;
    }

    #endregion

    #region Events

    private void frmVerDeposito_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpFRecog.Format = DateTimePickerFormat.Custom;
      this.dtpFRecog.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      // Carga de datos
      if (this.idDeposito <= 0) {
        this.Close();
        return;
      }

      this._deposito = new Depositos().Obtener(this.idDeposito);

      if (this._deposito == null) {
        this.Close();
        return;
      }

      this.lbObs.Text = this._deposito.Observaciones.Trim();

      if (this._deposito.DepositoValores)
      {
          this.pnValores.Visible = true;
          this.pnBanco.Visible = false;
          this.pnRespConteo.Visible = true;
          this.pnTotCheques.Visible = false;

          this.lbFeVenVal.Text = this._deposito.FechaVenta.ToShortDateString();
          this.LbNTransVal.Text = this._deposito.NumeroTransaccion.Trim();
          this.lbSerialPrecinto.Text = this._deposito.SerialPrecinto.Trim();
          this.lbBancoVal.Text = this._deposito.EPK_EntidadFinanciera.Nombre.Trim();

          this.btImprimir.Visible = true;

          if (this._deposito.IdUsuarioResponsable2.HasValue)
              this.lbResponsable.Text = this._deposito.EPK_Usuario1.Identificacion.Trim();

          if (this._deposito.FechaRecogida.HasValue)
          {
              this.dtpFRecog.Visible = false;

              this.lbFRecog.Visible = true;
              this.lbFRecog.Text = this._deposito.FechaRecogida.Value.ToShortDateString();

              this.lbObs.Visible = true;
              this.txObs.Visible = false;

              this.btOK.Visible = false;
              this.btCancel.Text = "Cerrar";
          }
          else
          {
              this.dtpFRecog.Visible = true;
              this.dtpFRecog.Value = new DataAccess(true).FechaDB();
              this.dtpFRecog.MaxDate = DateTime.Today;
              this.dtpFRecog.MinDate = this._deposito.FechaVenta;

              this.lbFRecog.Visible = false;

              this.lbObs.Visible = false;
              this.txObs.Text = this._deposito.Observaciones.Trim();
              this.txObs.Visible = true;
          }

          this.btImagen.Enabled = true;
      }
      else
      {
          this.pnValores.Visible = this.pnRespConteo.Visible = false;
          this.pnBanco.Visible = this.pnTotCheques.Visible = this.pnTotalDep.Visible = true;

          this.lbTotalDep.Text = "Total Efectivo";

          this.dgEfectivo.Height -= this.dgCheques.Height;

          this.lbFeVenBan.Text = this._deposito.FechaVenta.ToShortDateString();
          this.lbFechaDep.Text = this._deposito.FechaRecogida == null ? string.Empty : this._deposito.FechaRecogida.Value.ToShortDateString();
          this.LbNTransBan.Text = this._deposito.NumeroTransaccion.Trim();
          this.lbBancoBan.Text = this._deposito.EPK_EntidadFinanciera.Nombre.Trim();

          if (this._deposito.EPK_DepositoCheque.FirstOrDefault() != null)
          {
              List<Cheque> cheques = this._deposito.EPK_DepositoCheque.Select(dc => new Cheque
              {
                  FechaVenta = dc.EPK_FacturaPago.EPK_FacturaEncabezado.FechaCreacion,
                  NombreEntidad = dc.EPK_FacturaPago.EPK_EntidadFinanciera.Nombre.Trim(),
                  NumeroCheque = dc.EPK_FacturaPago.NumeroPago.Trim(),
                  Monto = dc.EPK_FacturaPago.Monto
              }).ToList();

              this.dgCheques.DataSource = cheques;
              this.dgCheques.Refresh();
          }

          this.btImagen.Enabled = (this._deposito.ImagenCataporte != null);
          this.btOK.Visible = false;
          this.btCancel.Text = "Cerrar";
      }

      if (this._deposito.EPK_DepositoDetalle.FirstOrDefault() != null) {
        List<DenominacionDepositos> efectivo = this._deposito.EPK_DepositoDetalle.Select(dd => new DenominacionDepositos {
          Logo = dd.EPK_Denominacion.Logo,
          Denominacion = dd.EPK_Denominacion.Denominacion,
          CantidadDeposito = dd.Cantidad,
          TotalDeposito = dd.Cantidad * dd.EPK_Denominacion.Denominacion
        }).OrderByDescending(dd => dd.Denominacion).ToList();

        this.dgEfectivo.DataSource = efectivo;
        this.dgEfectivo.Refresh();
      }

      // Totales
      this.txTotalBilletes.Text = "0";
      this.txTotalDeposito.Text = this.txTotCheques.Text = this.txTotalDepB.Text = string.Format("{0:C2}", 0);

      if (this._deposito.EPK_DepositoDetalle.FirstOrDefault() != null)
        this.txTotalBilletes.Text = this._deposito.EPK_DepositoDetalle.Sum(dd => dd.Cantidad).ToString();

      if (this._deposito.DepositoValores) {
        this.txTotalDeposito.Text = string.Format("{0:C2}", this._deposito.MontoEfectivo);
      }
      else {
        this.txTotCheques.Text = string.Format("{0:C2}", this._deposito.MontoCheque.HasValue ? this._deposito.MontoCheque.Value : 0);
        this.txTotalDeposito.Text = string.Format("{0:C2}", this._deposito.MontoEfectivo);
        this.txTotalDepB.Text = string.Format("{0:C2}", this._deposito.MontoEfectivo + (this._deposito.MontoCheque.HasValue ? this._deposito.MontoCheque.Value : 0));
      }
    }

    private void frmVerDeposito_Activated(object sender, EventArgs e)
    {
      this.Text = string.Format("Depósito #{0} - {1}", this.idDeposito, Application.ProductName);

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btImagen_Click(object sender, EventArgs e)
    {
      frmImagen fImgDep = new frmImagen();

      fImgDep.Titulo = "Comprobante de Depósito";
      fImgDep.Imagen = this._deposito.ImagenCataporte;
      fImgDep.FileName = this._deposito.FileName;
      fImgDep.MimeType = this._deposito.MimeType;
      fImgDep.ReadOnly = true;

      if (this._deposito.DepositoValores)
        fImgDep.ReadOnly = this._deposito.FechaRecogida.HasValue;

      if (fImgDep.ShowDialog() == System.Windows.Forms.DialogResult.OK && !fImgDep.ReadOnly) {
        this._deposito.ImagenCataporte = fImgDep.Imagen;
        this._deposito.FileName = fImgDep.FileName;
        this._deposito.MimeType = fImgDep.MimeType;
      }
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txObs, "");
      this.errorProvider1.SetError(this.btImagen, "");

      if (this.txObs.Text.Trim().Length < 15) {
        this.errorProvider1.SetError(this.txObs, string.Format(Properties.Resources.ValMinCar, 15));
        this.txObs.Focus();
        return;
      }

      if (this._deposito.ImagenCataporte == null) {
        this.errorProvider1.SetError(this.btImagen, Properties.Resources.ValCargarImagen);
        return;
      }

      this._deposito.FechaRecogida = this.dtpFRecog.Value;
      this._deposito.Observaciones = this.txObs.Text.Trim();

      if (new Depositos().Actualizar(this.idDeposito, this._deposito)) {
        MessageBox.Show(Properties.Resources.MsgDepAct, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
      }
      else
        MessageBox.Show(Properties.Resources.ErrorActDep, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btImprimir_Click(object sender, EventArgs e)
    {
      frmComprobanteDeposito fCDeposito = new frmComprobanteDeposito();
      fCDeposito.IdDeposito = this.idDeposito;
      fCDeposito.Forzar = false;
      fCDeposito.ShowDialog();
    }

    #endregion

  }
}
