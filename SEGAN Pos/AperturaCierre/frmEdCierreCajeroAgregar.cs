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
  public partial class frmEdCierreCajeroAgregar : Form
  {

    #region Public Properties

    public BindingList<CierreCajeroEntidad> _listCierre { get; set; }
    public CierreCajeroEntidad itemCierre { get; set; }

    #endregion

    #region Pirvate Properties

    private bool numPad { get; set; }

    #endregion

    #region Constructor

    public frmEdCierreCajeroAgregar()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmEdCierreCajero_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      if (!this.CargarDatos())
      {
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
      //if (e.KeyChar == (char)Keys.Enter)
      //  this.SalvarDatos();
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
      this.Text = "Agregar Forma de Pago - " + Application.ProductName;

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

    private void cbFormasPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        int IdFP = 0;
        int.TryParse(this.cbFormasPago.SelectedValue.ToString(), out IdFP);
        EPK_FormaPago F = new FormasPago().Obtener(IdFP);
        if (F == null)
            return;

        if (F.DatosPOS)
        {
            cbPOS.Enabled = true;
            txLote.Enabled = true;
            CargarPOS(F.IdFormaPago);
        }
        else
        {
            cbPOS.Enabled = false;
            txLote.Enabled = false;
            cbPOS.DataSource = null;
            cbPOS.Refresh();
        }
    }

    private void cbPOS_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    #endregion

    #region Private Methods

    private bool CargarDatos()
    {
      bool result = false;

      try {

          List<EPK_FormaPago> FP = new FormasPago().BuscarTodos().Where(p => p.Activa == true && p.IdFormaPago != Util.ObtenerParametroEntero("ID_EFECTIVO")).ToList();

          foreach (CierreCajeroEntidad C in _listCierre)
          {
              EPK_FormaPago F = FP.Where(p=>p.IdFormaPago==C.idFormaPago).FirstOrDefault();
              
              if(!F.DatosPOS)
              FP.RemoveAt(FP.FindIndex(p => p.IdFormaPago == C.idFormaPago));
          }

          if (FP.Count() > 0)
          {
              cbFormasPago.DataSource = FP;
              cbFormasPago.ValueMember = "IdFormaPago";
              cbFormasPago.DisplayMember = "Descripcion";
          }

          if (FP.FirstOrDefault().DatosPOS)
          {
              cbPOS.Enabled = true;
              txLote.Enabled = true;
              CargarPOS(FP.FirstOrDefault().IdFormaPago);
          }
          else
          {
              cbPOS.Enabled = false;
              txLote.Enabled = false;
              cbPOS.Items.Clear();
              cbPOS.Refresh();
          }

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

        this.itemCierre = new CierreCajeroEntidad();

        this.txObs.Text = this.txObs.Text.Trim();

        if (this.txLote.Enabled)
        {
            if (string.IsNullOrEmpty(this.txLote.Text.Trim()))
            {
                this.errorProvider1.SetError(this.txLote, Properties.Resources.ValLoteReq);
                this.txLote.Focus();
                return;
            }

            int lote;
            int.TryParse(this.txLote.Text, out lote);

            if (lote < 0 || lote > short.MaxValue)
            {
                this.errorProvider1.SetError(this.txLote, string.Format(Properties.Resources.ValRangoLote, 0, short.MaxValue));
                this.txLote.Focus();
                return;
            }
        }

        if (string.IsNullOrEmpty(this.txObs.Text.Trim()))
        {
            this.errorProvider1.SetError(this.txObs, Properties.Resources.ValIngreseObs);
            this.txObs.Focus();
            return;
        }

        if (string.IsNullOrEmpty(this.txMonto.Text.Trim()))
        {
            this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoReq);
            this.txMonto.Focus();
            return;
        }

        decimal montoPOS;
        if (!decimal.TryParse(this.txMonto.Text, out montoPOS))
        {
            this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoNoVal);
            this.txMonto.Focus();
            return;
        }

        montoPOS = Math.Abs(montoPOS);

        if (string.IsNullOrEmpty(this.txObs.Text))
        {
            this.errorProvider1.SetError(this.txObs, Properties.Resources.ValIngreseObs);
            this.txObs.Focus();
            return;
        }

        if (this.txLote.Enabled)
        {
            short lote;
            short.TryParse(this.txLote.Text, out lote);
            this.itemCierre.Lote = lote;
        }

        EPK_FormaPago FormaPago = new FormasPago().Obtener(int.Parse(cbFormasPago.SelectedValue.ToString()));
        EPK_POS Pos = new EPK_POS();
        if(FormaPago.DatosPOS)
            Pos = new POS().Obtener(int.Parse(cbPOS.SelectedValue.ToString()));

        this.itemCierre.idFormaPago = FormaPago.IdFormaPago;
        this.itemCierre.DatosPOS = FormaPago.DatosPOS;
        this.itemCierre.FormaPago = FormaPago.Descripcion;
        this.itemCierre.IdPos = Pos.IdPOS;
        this.itemCierre.Pos = Pos.Descripcion;
        this.itemCierre.Monto = 0;
        this.itemCierre.MontoPOS = montoPOS;
        this.itemCierre.Diferencia = itemCierre.Monto-itemCierre.MontoPOS;
        this.itemCierre.Observacion = this.txObs.Text;

        this._listCierre.Add(this.itemCierre);

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void CargarPOS(int IdFormaPago)
    {
        List<EPK_POS> POS = new POS().ObtenerTodos().Where(p => p.Activo == true).ToList();

        foreach (CierreCajeroEntidad C in this._listCierre)
        {
            EPK_FormaPago formaP = new FormasPago().Obtener(C.idFormaPago);
            if (formaP.DatosPOS)
            {
                if (C.idFormaPago == IdFormaPago && this._listCierre.Count(p => p.IdPos == C.IdPos) > 0)
                {
                    POS.RemoveAt(POS.FindIndex(p => p.IdPOS == C.IdPos));
                }
            }
        }

        if (POS.Count() > 0)
        {
            cbPOS.DataSource = POS.ToList();
            cbPOS.ValueMember = "IdPos";
            cbPOS.DisplayMember = "Descripcion";
        }

        cbPOS.Refresh();
    }

    #endregion

  }
}
