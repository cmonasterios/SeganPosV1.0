using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmEdCierreVentas : Form
  {

    #region Public Properties

    public CierreVentasOtrosPagos ItemCierre { get; set; }

    #endregion

    #region Pirvate Properties

    private bool numPad { get; set; }

    #endregion

    #region Constructor

    public frmEdCierreVentas()
    {
      InitializeComponent();
    }

    public frmEdCierreVentas(CierreVentasOtrosPagos itemCierre)
    {
      InitializeComponent();

      this.ItemCierre = itemCierre;
    }

    #endregion

    #region Events

    private void txMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Enter) {
        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          return;
        }

        decimal monto;
        bool montoValido = decimal.TryParse(((TextBox)sender).Text, out monto);

        if (!montoValido) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        if (this.txLote.Enabled)
          this.txLote.Focus();
        else
          this.txObs.Focus();

        return;
      }

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (this.numPad && e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.SalvarDatos();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void txLote_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter) {
        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          return;
        }

        int lote;
        int.TryParse(this.txLote.Text, out lote);

        if (lote < 0 || lote > short.MaxValue) {
          this.errorProvider1.SetError(((TextBox)sender), string.Format(Properties.Resources.ValRangoLote, 0, short.MaxValue));
          return;
        }

        this.txObs.Focus();
        return;
      }

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void frmEditCierreVentas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (!this.CargarDatos()) {
        this.Close();
        return;
      }

      this.txMontoCierre.Focus();
    }

    private void txMontoCierre_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txLote_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txObs_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txObs_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
        this.SalvarDatos();
    }

    private void frmEdCierreVentas_Activated(object sender, EventArgs e)
    {
      this.Text = "Editar Otros Pagos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void txMontoCierre_KeyDown(object sender, KeyEventArgs e)
    {
      this.numPad = false;

      if (e.KeyCode == Keys.Decimal) {
        this.numPad = true;
        return;
      }
    }

    #endregion

    #region Private Methods

    private bool CargarDatos()
    {
      bool result = false;

      try {
        if (this.ItemCierre == null)
          return result;

        EPK_FormaPago formaPago = new FormasPago().Obtener(this.ItemCierre.IdFormaPago);

        if (formaPago == null)
          return result;

        this.txFormaPago.Text = formaPago.Descripcion.Trim();
        this.txMontoSistema.Text = this.ItemCierre.TotalMontoSistema.ToString("N2");
        this.txMontoCierre.Text = this.ItemCierre.TotalMontoCierre.ToString();

        if (formaPago.DatosPOS) {
          this.txLote.Enabled = true;
          EPK_POS pos = new POS().Obtener(this.ItemCierre.IdPOS);
          this.txPOS.Text = pos.Descripcion.Trim();
        }
        else
          this.txLote.Enabled = false;

        if (this.txLote.Enabled)
          this.txLote.Text = this.ItemCierre.Lote.ToString();

        this.txLote.Text = this.ItemCierre.Lote.ToString();

        this.txObs.Text = this.ItemCierre.Observaciones;
        this.txObs.Text = this.txObs.Text.Trim();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    private void SalvarDatos()
    {
      this.errorProvider1.SetError(this.txMontoCierre, "");
      this.errorProvider1.SetError(this.txLote, "");
      this.errorProvider1.SetError(this.txObs, "");

      this.txObs.Text = this.txObs.Text.Trim();

      if (this.txLote.Enabled) {
        if (string.IsNullOrEmpty(this.txLote.Text.Trim())) {
          this.errorProvider1.SetError(this.txLote, Properties.Resources.ValLoteReq);
          this.txLote.Focus();
          return;
        }

        int lote;
        int.TryParse(this.txLote.Text, out lote);

        if (lote < 0 || lote > short.MaxValue) {
          this.errorProvider1.SetError(this.txLote, string.Format(Properties.Resources.ValRangoLote, 0, short.MaxValue));
          this.txLote.Focus();
          return;
        }
      }

      if (string.IsNullOrEmpty(this.txMontoCierre.Text.Trim())) {
        this.errorProvider1.SetError(this.txMontoCierre, Properties.Resources.ValMontoReq);
        this.txMontoCierre.Focus();
        return;
      }

      decimal monto;
      if (!decimal.TryParse(this.txMontoCierre.Text, out monto)) {
        this.errorProvider1.SetError(this.txMontoCierre, Properties.Resources.ValMontoNoVal);
        this.txMontoCierre.Focus();
        return;
      }

      if (this.ItemCierre.TotalMontoSistema != monto && this.txObs.Text.Length < 15) {
        this.errorProvider1.SetError(this.txObs, string.Format(Properties.Resources.ValMinCar, 15));
        this.txObs.Focus();
        return;
      }

      this.ItemCierre.TotalMontoCierre = monto;

      if (this.ItemCierre.IdPOS > 0) {
        short tempLote;
        short.TryParse(this.txLote.Text, out tempLote);
        this.ItemCierre.Lote = tempLote;
      }

      this.ItemCierre.Diferencia = this.ItemCierre.TotalMontoSistema - this.ItemCierre.TotalMontoCierre;

      this.ItemCierre.Observaciones = this.txObs.Text;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    #endregion

  }
}
