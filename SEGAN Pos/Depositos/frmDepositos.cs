using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmDepositos : Form
  {

    #region Private Properties

    private BindingList<DenominacionDepositos> _listDepositosDenominacion { get; set; }
    private BindingList<Cheque> _cheques { get; set; }

    private string _fileName { get; set; }
    private string _mimeType { get; set; }
    private byte[] _imagen { get; set; }

    #endregion

    #region Constructor

    public frmDepositos()
    {
      InitializeComponent();

      this._listDepositosDenominacion = new BindingList<DenominacionDepositos>();
      this._cheques = new BindingList<Cheque>();

      this._fileName = this._mimeType = null;
      this._imagen = null;
    }

    #endregion

    #region Events

    private void frmValores_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpFechaDep.Format = DateTimePickerFormat.Custom;
      this.dtpFechaDep.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpFechaVenta.Format = DateTimePickerFormat.Custom;
      this.dtpFechaVenta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpFVentaVal.Format = DateTimePickerFormat.Custom;
      this.dtpFVentaVal.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpFVentaVal.MaxDate = this.dtpFVentaVal.Value = DateTime.Today;
      this.dtpFechaVenta.MaxDate = this.dtpFechaVenta.Value = DateTime.Today;
      this.dtpFechaDep.MaxDate = this.dtpFechaDep.Value = DateTime.Today;

      this.CargarDatos();
      this.CalcularTotales();

      this.tabTipoDep.SelectedTab = this.tpValores;
    }

    private void dtpFechaVenta_ValueChanged(object sender, EventArgs e)
    {
        if (((DateTimePicker)sender).Value < this.dtpFechaDep.Value)
            this.dtpFechaDep.MinDate = ((DateTimePicker)sender).Value;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgEfectivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DenominacionDepositos itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionDepositos);

      if (itemSel == null)
        return;

      if (itemSel.Cantidad <= 0)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;
      fCant.ValorMaximo = itemSel.Cantidad;
      fCant.Cantidad = itemSel.CantidadDeposito;
      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      if (fCant.Cantidad == itemSel.CantidadDeposito)
        return;

      // Actualizar la cantidad
      itemSel.CantidadDeposito = fCant.Cantidad;
      itemSel.TotalDeposito = itemSel.CantidadDeposito * itemSel.Denominacion;

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.CalcularTotales();

      if (!this.ValidarDatos())
        return;

      if (MessageBox.Show(Properties.Resources.MsgConfDatos, "Confirmación - " + this.Text,
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return;

      if (!this.GuardarDeposito()) {
        MessageBox.Show(Properties.Resources.ErrorDeposito, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void txMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
        return;

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9,]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void frmValores_Shown(object sender, EventArgs e)
    {
      if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name)) {
        MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
        return;
      }

      if (!new EfectivoRemanente().HayDisponible() && !new Facturas().HayChequesSinDepositar()) {
        MessageBox.Show(Properties.Resources.ErrorNadaDep, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
        return;
      }

      MessageBox.Show(Properties.Resources.MsgRecordDep, "Atención - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

      this.txComprobante.Focus();
    }

    private void dgEfectivo_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgEfectivo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmValores_Activated(object sender, EventArgs e)
    {
      this.Text = "Registro de Depósitos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void rbValores_CheckedChanged(object sender, EventArgs e)
    {
      this.CargarDatos();
    }

    private void btAgregar_Click(object sender, EventArgs e)
    {
      frmBuscarCheques fBCheq = new frmBuscarCheques();

      fBCheq.ChequesSel = this._cheques.ToList();

      fBCheq.ShowDialog();

      if (fBCheq.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      this._cheques = new BindingList<Cheque>(fBCheq.Cheques);

      this.dgCheques.DataSource = this._cheques;
      this.dgCheques.Refresh();

      this.CalcularTotales();
    }

    private void dgCheques_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = false;
    }

    private void dgCheques_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgCheques_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 12) // Botón Borrar
        return;

      foreach (DataGridViewRow row in ((DataGridView)sender).SelectedRows)
        this._cheques.RemoveAt(row.Index);

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    private void btImagen_Click(object sender, EventArgs e)
    {
      frmImagen fImgDep = new frmImagen();

      fImgDep.Titulo = "Comprobante de Depósito";
      fImgDep.Imagen = this._imagen;
      fImgDep.FileName = this._fileName;
      fImgDep.MimeType = this._mimeType;

      if (fImgDep.ShowDialog() == DialogResult.OK) {
        this._imagen = fImgDep.Imagen;
        this._fileName = fImgDep.FileName;
        this._mimeType = fImgDep.MimeType;
      }
    }

    private void txComprobante_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txNroEnvase_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[\w]+$") || e.KeyChar.Equals('_'))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txNroDeposito_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void tabTipoDep_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      this.SuspendLayout();

      if (((TabControl)sender).SelectedTab == this.tpValores) {
        this.pnCheques.Visible = this.pnTotCheques.Visible =
          this.pnImagen.Visible = this.pnTotalDep.Visible = false;
        this.pnRespConteo.Visible = true;
        this.dgEfectivo.Height += this.pnCheques.Height;
        this.lbTotalDeposito.Text = "Total Depósito";
        this.txComprobante.Focus();
      }
      else {
        this.pnCheques.Visible = this.pnTotCheques.Visible =
          this.pnImagen.Visible = this.pnTotalDep.Visible = true;
        this.pnRespConteo.Visible = false;
        this.dgEfectivo.Height -= this.pnCheques.Height;
        this.btAgregar.Enabled = new Facturas().HayChequesSinDepositar();
        this.lbTotalDeposito.Text = "Total Efectivo";
        this.txNroDeposito.Focus();
      }

      this.CargarDatos();
      this.CalcularTotales();

      this.ResumeLayout();
      this.Cursor = Cursors.Default;
    }

    #endregion

    #region Private Methods

    private void CalcularTotales()
    {
      this.txTotalBilletes.Text = this.txTotalBilletesSD.Text = "0";
      this.txTotalEfectivo.Text = this.txTotalDeposito.Text = this.txTotCheques.Text = string.Format("{0:C2}", 0);
      this.txTotalEfectivo.Tag = this.txTotalDeposito.Tag = this.txTotCheques.Tag = 0;

      foreach (DenominacionDepositos item in this._listDepositosDenominacion)
        item.TotalDeposito = item.CantidadDeposito * item.Denominacion;

      int cantBilletes = this._listDepositosDenominacion.Sum(ld => ld.Cantidad);
      int cantBilletesDep = this._listDepositosDenominacion.Sum(ld => ld.CantidadDeposito);
      decimal totalDeposito = this._listDepositosDenominacion.Sum(ld => ld.CantidadDeposito * ld.Denominacion);
      decimal totalGeneral = this._listDepositosDenominacion.Sum(ld => ld.TotalDenominacion);

      this.txTotalBilletes.Text = cantBilletesDep.ToString();
      this.txTotalBilletesSD.Text = (cantBilletes - cantBilletesDep).ToString();

      this.txTotalEfectivo.Tag = totalGeneral - totalDeposito;
      this.txTotalEfectivo.Text = string.Format("{0:C2}", totalGeneral - totalDeposito);

      bool okEnabled = false;

      if (this.tabTipoDep.SelectedTab == this.tpBanco) {
        decimal totalCheques = this._cheques.Sum(c => c.Monto);

        this.txTotCheques.Text = string.Format("{0:C2}", totalCheques);
        this.txTotalDeposito.Text = string.Format("{0:C2}", totalDeposito);
        this.txTotalDepB.Text = string.Format("{0:C2}", totalDeposito + totalCheques);

        okEnabled = (totalDeposito + totalCheques) > 0;
      }
      else {
        this.txTotalDeposito.Text = string.Format("{0:C2}", totalDeposito);

        okEnabled = totalDeposito > 0;
      }

      this.btOK.Enabled = okEnabled;
    }

    private void CargarDatos()
    {
      this.CargarCombos();

      this._cheques.Clear();
      this.dgCheques.Refresh();

      EPK_EfectivoRemanenteEncabezado remanente = new EfectivoRemanente().ObtenerUltimo();

      if (remanente == null)
        return;

      this._listDepositosDenominacion = new BindingList<DenominacionDepositos>(
        remanente.EPK_EfectivoRemanenteDetalle.Where(rd => (this.tabTipoDep.SelectedTab == this.tpValores ? rd.EPK_Denominacion.Billete : true) &&
          rd.CantidadActual > 0).GroupBy(rd => rd.EPK_Denominacion).Select(rd => new DenominacionDepositos {
            IdDenominacion = rd.Key.IdDenominacion,
            Denominacion = rd.Key.Denominacion,
            Logo = rd.Key.Logo,
            Cantidad = rd.Sum(d => d.CantidadActual),
            TotalDenominacion = rd.Sum(d => d.CantidadActual) * rd.Key.Denominacion
          }).OrderByDescending(rd => rd.Denominacion).ToList());

      this.dgEfectivo.DataSource = this._listDepositosDenominacion;
      this.dgEfectivo.Refresh();
    }

    private void CargarCombos()
    {
      List<EPK_EntidadFinanciera> entidaesFinancieras = new EntidadesFinancieras().ObtenerActivas().ToList();

      this.cbBancoValores.DataSource = entidaesFinancieras;
      this.cbBancoValores.ValueMember = "IdEntidad";
      this.cbBancoValores.DisplayMember = "Nombre";

      EPK_ParametrosSistema IdEntidadDefault = EstadoAplicacion.GetParametroSistema("IdEntidadDefault");

      int IdEntidad = 0;
      int.TryParse(IdEntidadDefault.ValorEntero.ToString(), out IdEntidad);
      if (IdEntidad != 0) {
        EPK_EntidadFinanciera entidadDefault = new EntidadesFinancieras().Obtener(IdEntidad);
        this.cbBancoValores.Text = entidadDefault.Nombre;
      }
      else {
        if (entidaesFinancieras.Count() == 1) {
          this.cbBancoValores.SelectedIndex = 0;
          this.cbBancoValores.Enabled = false;
        }
        else
          this.cbBancoValores.SelectedIndex = -1;
      }

      this.cbBanco.DataSource = entidaesFinancieras;
      this.cbBanco.ValueMember = "IdEntidad";
      this.cbBanco.DisplayMember = "Nombre";

      if (entidaesFinancieras.Count() == 1) {
        this.cbBanco.SelectedIndex = 0;
        this.cbBanco.Enabled = false;
      }
      else
        this.cbBanco.SelectedIndex = -1;

      List<EPK_Usuario> usuarios = new Usuarios().ObtenerActivos();

      this.cbEmpleados.DataSource = usuarios;
      this.cbEmpleados.ValueMember = "IdUsuario";
      this.cbEmpleados.DisplayMember = "Identificacion";

      if (usuarios.Count() == 1) {
        this.cbEmpleados.SelectedIndex = 0;
        this.cbEmpleados.Enabled = false;
      }
      else
        this.cbEmpleados.SelectedIndex = -1;
    }

    private bool GuardarDeposito()
    {
      decimal totalEfectivo = this._listDepositosDenominacion.Sum(ld => ld.CantidadDeposito * ld.Denominacion);
      decimal saldo = this._listDepositosDenominacion.Sum(ld => ld.TotalDenominacion) - totalEfectivo;
      decimal totalCheques = this._cheques.Sum(c => c.Monto);

      EPK_DepositoEncabezado nuevoDeposito = new EPK_DepositoEncabezado();

      nuevoDeposito.IdUsuarioResponsable = EstadoAplicacion.UsuarioActual.IdUsuario;
      nuevoDeposito.Saldo = saldo;
      nuevoDeposito.MontoEfectivo = totalEfectivo;
      nuevoDeposito.Observaciones = this.txObs.Text.Trim();

      if (this.tabTipoDep.SelectedTab == this.tpValores) {
        nuevoDeposito.DepositoValores = true;
        nuevoDeposito.FechaVenta = this.dtpFVentaVal.Value;
        nuevoDeposito.NumeroTransaccion = this.txComprobante.Text.Trim();
        nuevoDeposito.SerialPrecinto = this.txNroEnvase.Text.Trim();
        nuevoDeposito.IdUsuarioResponsable2 = int.Parse(this.cbEmpleados.SelectedValue.ToString());
        nuevoDeposito.IdEntidad = int.Parse(this.cbBancoValores.SelectedValue.ToString());
      }
      else {
        nuevoDeposito.DepositoValores = false;
        nuevoDeposito.FechaVenta = this.dtpFechaVenta.Value;
        nuevoDeposito.FechaRecogida = this.dtpFechaDep.Value;
        nuevoDeposito.NumeroTransaccion = this.txNroDeposito.Text;
        nuevoDeposito.MontoCheque = totalCheques;
        nuevoDeposito.IdEntidad = int.Parse(this.cbBanco.SelectedValue.ToString());

        nuevoDeposito.EPK_DepositoCheque = this._cheques.Select(c => new EPK_DepositoCheque {
          IdPago = c.IdPago
        }).ToList();

        if (this._imagen != null) {
          nuevoDeposito.ImagenCataporte = this._imagen;
          nuevoDeposito.FileName = this._fileName;
          nuevoDeposito.MimeType = this._mimeType;
        }
      }

      nuevoDeposito.EPK_DepositoDetalle = this._listDepositosDenominacion.Where(ld => ld.CantidadDeposito > 0).
        Select(ld => new EPK_DepositoDetalle {
          IdDenominacion = ld.IdDenominacion,
          Cantidad = (short)ld.CantidadDeposito
        }).ToList();

      long result = new DAL.Depositos().Nuevo(nuevoDeposito);

      if (result == 0)
        return false;

      new EfectivoRemanente().ActualizarDeposito(result);

      if (this.tabTipoDep.SelectedTab == this.tpValores) {
        frmComprobanteDeposito fCDeposito = new frmComprobanteDeposito();
        fCDeposito.IdDeposito = result;
        fCDeposito.ShowDialog();
      }

      return true;
    }

    private bool ValidarDatos()
    {
      this.errorProvider1.SetError(this.txComprobante, "");
      this.errorProvider1.SetError(this.txNroEnvase, "");
      this.errorProvider1.SetError(this.txTotalDeposito, "");
      this.errorProvider1.SetError(this.cbBancoValores, "");
      this.errorProvider1.SetError(this.cbEmpleados, "");
      this.errorProvider1.SetError(this.cbBanco, "");
      this.errorProvider1.SetError(this.txNroDeposito, "");
      this.errorProvider1.SetError(this.txObs, "");

      if (this.tabTipoDep.SelectedTab == this.tpValores) {
        if (string.IsNullOrEmpty(this.txComprobante.Text.Trim())) {
          this.errorProvider1.SetError(this.txComprobante, Properties.Resources.ValNumComp);
          this.txComprobante.Focus();
          return false;
        }

        if (string.IsNullOrEmpty(this.txNroEnvase.Text.Trim())) {
          this.errorProvider1.SetError(this.txNroEnvase, Properties.Resources.ValNumEnvase);
          this.txNroEnvase.Focus();
          return false;
        }

        if (this.cbBancoValores.SelectedIndex < 0) {
          this.errorProvider1.SetError(this.cbBancoValores, Properties.Resources.ValSelBanco);
          this.cbBancoValores.Focus();
          return false;
        }

        if (this.cbEmpleados.SelectedIndex < 0) {
          this.errorProvider1.SetError(this.cbEmpleados, Properties.Resources.ValSelResp);
          this.cbEmpleados.Focus();
          return false;
        }
      }
      else {
        if (string.IsNullOrEmpty(this.txNroDeposito.Text.Trim())) {
          this.errorProvider1.SetError(this.txNroDeposito, Properties.Resources.ValNumDep);
          this.txNroDeposito.Focus();
          return false;
        }

        if (this.cbBanco.SelectedIndex < 0) {
          this.errorProvider1.SetError(this.cbBanco, Properties.Resources.ValSelBanco);
          this.cbBanco.Focus();
          return false;
        }

        if (this._imagen == null) {
          this.errorProvider1.SetError(this.btImagen, Properties.Resources.ValCargarImagen);
          return false;
        }
      }

      if (string.IsNullOrEmpty(this.txObs.Text.Trim())) {
        this.errorProvider1.SetError(this.txObs, Properties.Resources.ValIngreseObs);
        this.txObs.Focus();
        return false;
      }

      if (this.txObs.Text.Trim().Length < 15) {
        this.errorProvider1.SetError(this.txObs, string.Format(Properties.Resources.ValMinCar, 15));
        this.txObs.Focus();
        return false;
      }

      return true;
    }

    #endregion

  }
}
