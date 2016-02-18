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

namespace SEGAN_POS
{
  public partial class frmEdCierreVentasEf : Form
  {

    #region Public Properties

    public decimal MontoSistema { get; set; }
    public decimal MontoCierre { get; set; }
    public decimal MontoCierreOrig { get; set; }
    public string Observaciones { get; set; }

    #endregion

    #region Pirvate Properties

    private bool numPad { get; set; }

    #endregion

    #region Constructor

    public frmEdCierreVentasEf()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmEditCierreVentasEf_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (!this.CargarDatos()) {
        this.Close();
        return;
      }

      this.txMontoCierre.Focus();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.SalvarDatos();
    }

    private void txMontoCierre_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txObs_Enter(object sender, EventArgs e)
    {
      ((TextBox)sender).SelectAll();
    }

    private void txMontoCierre_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Enter) {
        e.Handled = true;

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          return;
        }

        decimal monto;
        bool montoValido = decimal.TryParse(((TextBox)sender).Text, out monto);

        if (!montoValido) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

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

    private void txObs_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
        this.SalvarDatos();
    }

    private void frmEdCierreVentasEf_Activated(object sender, EventArgs e)
    {
      this.Text = "Editar Efectivo - " + Application.ProductName;

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
        this.txMontoSistema.Text = this.MontoSistema.ToString("N2");
        this.txMontoCierre.Text = this.MontoCierre.ToString();
        this.txObs.Text = this.Observaciones;
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
      this.errorProvider1.SetError(this.txObs, "");

      this.txObs.Text = this.txObs.Text.Trim();

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

      if (this.MontoCierreOrig != monto && this.txObs.Text.Length < 15) {
        this.errorProvider1.SetError(this.txObs, string.Format(Properties.Resources.ValMinCar, 15));
        this.txObs.Focus();
        return;
      }

      this.MontoCierre = monto;

      this.Observaciones = this.txObs.Text;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    #endregion

  }
}
