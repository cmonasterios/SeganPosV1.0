using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmEdCierreCajero : Form
  {

    #region Public Properties

    public CierreCajeroEntidad ItemCierre { get; set; }

    #endregion

    #region Pirvate Properties

    private bool numPad { get; set; }

    #endregion

    #region Constructor

    public frmEdCierreCajero()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmEdCierreCajero_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;
      //if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Visualizar"))
      //{

      //    foreach (var ctrl in this.Controls)
      //    {
      //        if (ctrl.GetType() == typeof(TextBox))
      //        {
      //            var tagString = (ctrl as TextBox).Tag;
      //            if (!string.IsNullOrEmpty((string)tagString))
      //            {
      //                if (tagString.ToString() == "Visualizar")
      //                    ((TextBox)ctrl).PasswordChar = 'x';
      //            }
      //        }

      //    }
      //}
      if (!this.CargarDatos()) {
        this.Close();
        return;
      }

      this.txMonto.Focus();
    }

    private void txMonto_KeyPress(object sender, KeyPressEventArgs e)
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

    private void btOK_Click(object sender, EventArgs e)
    {
      this.SalvarDatos();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void txObs_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter)
        this.SalvarDatos();
    }

    private void txMonto_Enter(object sender, EventArgs e)
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

    private void frmEdCierreCajero_Activated(object sender, EventArgs e)
    {
      this.Text = "Editar Forma de Pago - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void txMonto_KeyDown(object sender, KeyEventArgs e)
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

        EPK_FormaPago formaPago = new FormasPago().Obtener(this.ItemCierre.idFormaPago);

        if (formaPago == null)
          return result;

        this.txFormaPago.Text = formaPago.Descripcion.Trim();
        this.txMontoSistema.Text = this.ItemCierre.Monto.ToString("N2");
        this.txMonto.Text = this.ItemCierre.MontoPOS.ToString();

        if (formaPago.DatosPOS) {
          this.txLote.Enabled = true;
          EPK_POS pos = new POS().Obtener(this.ItemCierre.IdPos);
          this.txPOS.Text = pos.Descripcion.Trim();
        }
        else
          this.txLote.Enabled = false;

        if (this.txLote.Enabled)
          this.txLote.Text = this.ItemCierre.Lote.ToString();

        this.txObs.Text = this.ItemCierre.Observacion;
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
      this.errorProvider1.SetError(this.txLote, "");
      this.errorProvider1.SetError(this.txMonto, "");
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

      if (string.IsNullOrEmpty(this.txMonto.Text.Trim())) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoReq);
        this.txMonto.Focus();
        return;
      }

      decimal montoPOS;
      if (!decimal.TryParse(this.txMonto.Text, out montoPOS)) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoNoVal);
        this.txMonto.Focus();
        return;
      }

      montoPOS = Math.Abs(montoPOS);

      if ((this.ItemCierre.Monto - montoPOS) != 0 && string.IsNullOrEmpty(this.txObs.Text)) {
        this.errorProvider1.SetError(this.txObs, Properties.Resources.ValIngreseObs);
        this.txObs.Focus();
        return;
      }

      this.ItemCierre.Diferencia = this.ItemCierre.Monto - montoPOS;
      this.ItemCierre.MontoPOS = montoPOS;

      if (this.txLote.Enabled) {
        short lote;
        short.TryParse(this.txLote.Text, out lote);
        this.ItemCierre.Lote = lote;
      }

      this.ItemCierre.Observacion = this.txObs.Text;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    #endregion

  }
}
