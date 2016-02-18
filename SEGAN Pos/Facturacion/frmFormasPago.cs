using DisplayManager.Providers;
using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmFormasPago : Form
  {
    #region Private Properties

    private BindingList<EPK_EntidadFinanciera> _bancos { get; set; }

    private BindingList<EPK_EntidadFinanciera> _bancosPOS { get; set; }

    private EPK_FormaPago _formaPagoSel { get; set; }

    private BindingList<EPK_FormaPago> _formasPago { get; set; }

    private decimal _maxDenominacion { get; set; }

    private int _maxFormasPago { get; set; }

    private decimal _saldo { get; set; }

    private int idEfectivo { get; set; }
    private bool numPad { get; set; }
    #endregion Private Properties

    #region Public Properties

    public int idCliente { get; set; }

    public BindingList<ItemsPago> ItemsPago { get; set; }

    public decimal MontoAPagar { get; set; }
    #endregion Public Properties

    #region Constructor

    public frmFormasPago()
    {
      InitializeComponent();

      this._maxFormasPago = 0;
      this._maxDenominacion = 0;
      this._saldo = 0;
      this._formasPago = new BindingList<EPK_FormaPago>();
      this._formaPagoSel = null;

      if (this.ItemsPago == null)
        this.ItemsPago = new BindingList<ItemsPago>();

      this.idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");

      this._bancos = new BindingList<EPK_EntidadFinanciera>();
      this._bancosPOS = new BindingList<EPK_EntidadFinanciera>();
    }

    #endregion Constructor

    #region Events

    private void btAgregar_Click(object sender, EventArgs e)
    {
      this.Agregar();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.ItemsPago.Clear();
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void cbBanco_Enter(object sender, EventArgs e)
    {
      this.lbBanco.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbBanco.ForeColor = Color.Blue;
    }

    private void cbBanco_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Enter)
        return;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      this.txNumero.Focus();
    }

    private void cbBanco_Leave(object sender, EventArgs e)
    {
      this.lbBanco.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbBanco.ForeColor = SystemColors.ControlText;
    }

    private void cbBancoPOS_Enter(object sender, EventArgs e)
    {
      this.lbBancoPOS.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbBancoPOS.ForeColor = Color.Blue;
    }

    private void cbBancoPOS_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Enter)
        return;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      this.cbPOS.Focus();
    }

    private void cbBancoPOS_Leave(object sender, EventArgs e)
    {
      this.lbBancoPOS.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbBancoPOS.ForeColor = SystemColors.ControlText;
    }

    private void cbBancoPOS_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      int idEntidadPOS;
      int.TryParse(((ComboBox)sender).SelectedValue.ToString(), out idEntidadPOS);

      if (idEntidadPOS <= 0)
        return;

      List<EPK_POS> pos = new POS().ObtenerPorEntidad(idEntidadPOS);

      if (pos == null)
        return;

      this.cbPOS.DataSource = pos;
      this.cbPOS.ValueMember = "IdPOS";
      this.cbPOS.DisplayMember = "Descripcion";
      this.cbPOS.Enabled = true;

      this.cbPOS.SelectedIndex = -1;
    }

    private void cbFormaPago_Enter(object sender, EventArgs e)
    {
      this.lbFormaPago.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbFormaPago.ForeColor = Color.Blue;
    }

    private void cbFormaPago_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Enter)
        return;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      if (this.cbBanco.Enabled)
        this.cbBanco.Focus();
      else
        this.txMonto.Focus();
    }

    private void cbFormaPago_Leave(object sender, EventArgs e)
    {
      this.lbFormaPago.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbFormaPago.ForeColor = SystemColors.ControlText;
    }

    private void cbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.FormaPagoChanged();
    }

    private void cbPOS_Enter(object sender, EventArgs e)
    {
      this.lbPOS.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbPOS.ForeColor = Color.Blue;
    }

    private void cbPOS_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Enter)
        return;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      this.txMonto.Focus();
    }

    private void cbPOS_Leave(object sender, EventArgs e)
    {
      this.lbPOS.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbPOS.ForeColor = SystemColors.ControlText;
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 9) // Botón Borrar
        return;

      foreach (DataGridViewRow row in this.dgItems.SelectedRows)
        this.ItemsPago.RemoveAt(row.Index);

      this.dgItems.Refresh();
      this.CalcularTotales();
    }

    private void dgItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex == 9) // Botón Borrar
        return;

      foreach (DataGridViewRow row in this.dgItems.SelectedRows)
      {
          //this.CargarFormasPago();
          //this.CargarBancos();

          ItemsPago Pago = ItemsPago.ElementAt(row.Index);
          this.ItemsPago.RemoveAt(row.Index);
          this.dgItems.DataSource = this.ItemsPago;
          this.dgItems.Refresh();

          this.CalcularTotales();


          this.cbFormaPago.SelectedValue = Pago.idFormaPago;
          this.cbBancoPOS.SelectedValue = Pago.idEntidadPOS;
          this.cbBanco.SelectedValue = Pago.idEntidad;
          this.cbPOS.SelectedValue = Pago.idPOS;
          this.txMonto.Text = Pago.Monto.ToString();
          this.txMonto.ReadOnly = false;
          this.txNumero.Text = Pago.NumeroPago;
          this.txNumero.ReadOnly = false;

       
      }
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dgItems_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Delete)
        return;

      foreach (DataGridViewRow row in ((DataGridView)sender).SelectedRows)
        this.ItemsPago.RemoveAt(row.Index);

      ((DataGridView)sender).Refresh();
      this.CalcularTotales();
    }

    private void frmFormasPago_Activated(object sender, EventArgs e)
    {
      this.Text = "Pagos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmFormasPago_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this._maxFormasPago = Util.ObtenerParametroEntero("MAX_PAGOS");
      if (this._maxFormasPago <= 0)
        this._maxFormasPago = 3;

      this._maxDenominacion = new Denominacion().ObtenerMax();
      if (this._maxDenominacion <= 0)
        this._maxDenominacion = 100;

      this.CargarFormasPago();
      this.CargarBancos();

      this.dgItems.DataSource = this.ItemsPago;
      this.dgItems.Refresh();

      this.CalcularTotales();
    }

    private void txMonto_Enter(object sender, EventArgs e)
    {
      this.lbMonto.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbMonto.ForeColor = Color.Blue;
      ((TextBox)sender).BackColor = Color.LightYellow;
    }

    private void txMonto_KeyDown(object sender, KeyEventArgs e)
    {
      this.numPad = false;

      if (e.KeyCode == Keys.Decimal) {
        this.numPad = true;
        return;
      }
    }

    private void txMonto_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter) {
        this.Agregar();
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

    private void txMonto_Leave(object sender, EventArgs e)
    {
      this.lbMonto.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbMonto.ForeColor = SystemColors.ControlText;
      ((TextBox)sender).BackColor = SystemColors.Window;
    }

    private void txNumero_Enter(object sender, EventArgs e)
    {
      this.lbNumero.Font = new Font(this.lbFormaPago.Font, FontStyle.Bold);
      this.lbNumero.ForeColor = Color.Blue;
      ((TextBox)sender).BackColor = Color.LightYellow;
    }

    private void txNumero_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Enter) {
        if (string.IsNullOrEmpty(((TextBox)sender).Text))
          return;

        if (this.cbBancoPOS.Enabled)
          this.cbBancoPOS.Focus();
        else
          this.txMonto.Focus();
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

    private void txNumero_Leave(object sender, EventArgs e)
    {
      this.lbNumero.Font = new Font(this.lbFormaPago.Font, FontStyle.Regular);
      this.lbNumero.ForeColor = SystemColors.ControlText;
      ((TextBox)sender).BackColor = SystemColors.Window;
    }

    #endregion Events

    #region Private Methods

    private void Agregar()
    {
      if (this._formaPagoSel.RequiereAutorizacion)
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btAgregar.Tag.ToString())) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarFPago;
          fAut.NombreTecnico = this.Name;
          fAut.Accion = this.btAgregar.Tag.ToString();
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
            return;
        }

      if (!this.Validar())
        return;

      byte idFPago = 0;
      int idEnt = 0, idPOS = 0, idEntPos = 0;
      string descFPago = string.Empty, descEnt = string.Empty, descPOS = string.Empty,
             descEntPOS = string.Empty, numero = string.Empty;

      byte.TryParse(this.cbFormaPago.SelectedValue.ToString(), out idFPago);
      descFPago = this.cbFormaPago.Text.Trim();

      if (this.cbBanco.Enabled) {
        int.TryParse(this.cbBanco.SelectedValue.ToString(), out idEnt);
        descEnt = this.cbBanco.Text.Trim();
      }

      if (this.txNumero.Enabled)
        numero = this.txNumero.Text.Trim();

      if (this.cbBancoPOS.Enabled)
      {
          descEntPOS = this.cbBancoPOS.Text.Trim();
          int.TryParse(this.cbBancoPOS.SelectedValue.ToString(), out idEntPos);
      }

      if (this.cbPOS.Enabled) {
        int.TryParse(this.cbPOS.SelectedValue.ToString(), out idPOS);
        descPOS = this.cbPOS.Text.Trim();
      }

      decimal monto;
      bool montoValido = decimal.TryParse(this.txMonto.Text, out monto);

      if (!montoValido) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoNoVal);
        return;
      }

      bool efectivo = false;
      if (this._formaPagoSel.IdFormaPago == this.idEfectivo) { // Efectivo
        if ((monto - this._saldo) > this._maxDenominacion) {
          MessageBox.Show(string.Format(Properties.Resources.MsgCambioMax, this._maxDenominacion.ToString("c")), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.txMonto.SelectAll();
          this.txMonto.Focus();
          return;
        }
        efectivo = true;
      }
      else {
        if (monto > this._saldo) {
          MessageBox.Show(string.Format(Properties.Resources.MsgMontoMax, this._saldo.ToString("c")), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.txMonto.SelectAll();
          this.txMonto.Focus();
          return;
        }
      }

      ItemsPago nuevoItem = new ItemsPago {
        idFormaPago = idFPago,
        idEntidad = idEnt,
        idPOS = idPOS,
        idEntidadPOS = idEntPos,
        NumeroPago = numero,
        Monto = monto,
        DescFormaPago = descFPago,
        DescEntidad = descEnt,
        DescPOS = descPOS,
        DescEntidadPOS = descEntPOS,
        Efectivo = efectivo
      };
      this.ItemsPago.Add(nuevoItem);

      this.dgItems.Refresh();
      this.Limpiar();
      this.CalcularTotales();

      this.FormaPagoChanged();

      if (!EstadoAplicacion.TieneVisor)
        return;

      try {
        BematechDisplay visorManager = new BematechDisplay();

        using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
          string textFPago = Util.StripAccents(descFPago) + (efectivo ? "" : " #" + numero);

          visorManager.ClearDisplay(serialPort);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, textFPago, DisplayManagerEnum.Alineacion.Izquierda);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, monto.ToString("c"), DisplayManagerEnum.Alineacion.Derecha);
        }
      }
      catch (Exception ex) {
        MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void CalcularTotales()
    {
      this._saldo = 0;
      this.txTotalPagar.Text = this.txSaldo.Text = string.Format("{0:c}", this.MontoAPagar);
      this.txCambio.Text = this.txTotalRecibido.Text = string.Format("{0:c}", 0);

      decimal totalRecibido = 0, cambio = 0;

      bool hayEfectivo = false;
      foreach (ItemsPago item in this.ItemsPago) {
        totalRecibido += item.Monto;
        if (item.Efectivo)
          hayEfectivo = true;
      }

      this._saldo = this.MontoAPagar - totalRecibido;
        
      if (hayEfectivo) {
        this.SuspendLayout();

        EPK_FormaPago formaEfectivo = this._formasPago.FirstOrDefault(fp => fp.IdFormaPago == this.idEfectivo);
        if (formaEfectivo != null)
          this._formasPago.Remove(formaEfectivo);

        this.SeleccionarEfectivo();
        this.ResumeLayout();
      }
      else {
        this.CargarFormasPago();
     }


      if (this._saldo > 0)
      {
          this.btOK.Enabled = false;
          if (this.ItemsPago.Count() < this._maxFormasPago)
          {
              this.txMonto.Enabled = this.cbFormaPago.Enabled = this.btAgregar.Enabled = true;
              this.SeleccionarEfectivo();
              this.cbFormaPago.Focus();
          }
          else
          {
              this.cbFormaPago.SelectedIndex = -1;
              this.txMonto.Enabled = this.cbFormaPago.Enabled = this.btAgregar.Enabled = false;
              this.cbBanco.SelectedIndex = this.cbBancoPOS.SelectedIndex = this.cbPOS.SelectedIndex = -1;
              this.cbBanco.Enabled = this.cbBancoPOS.Enabled = this.cbPOS.Enabled = false;
          }
      }
      else
      {
          if (this._saldo == 0)
          {
              this.btOK.Enabled = true;
              this.cbFormaPago.SelectedIndex = -1;
              this.txMonto.Enabled = this.cbFormaPago.Enabled = this.btAgregar.Enabled = false;
              this.cbBanco.SelectedIndex = this.cbBancoPOS.SelectedIndex = this.cbPOS.SelectedIndex = -1;
              this.cbBanco.Enabled = this.cbBancoPOS.Enabled = this.cbPOS.Enabled = false;
              this.btOK.Focus();
          }
          else
          {
              if (this._saldo*(-1) <= _maxDenominacion && hayEfectivo && ItemsPago.Where(p => p.idFormaPago == idEfectivo).Sum(w => w.Monto) >= this._saldo*(-1))
              {
                  this.btOK.Enabled = true;
                  this.cbFormaPago.SelectedIndex = -1;
                  this.txMonto.Enabled = this.cbFormaPago.Enabled = this.btAgregar.Enabled = false;
                  this.cbBanco.SelectedIndex = this.cbBancoPOS.SelectedIndex = this.cbPOS.SelectedIndex = -1;
                  this.cbBanco.Enabled = this.cbBancoPOS.Enabled = this.cbPOS.Enabled = false;
                  this.btOK.Focus();
              }
              else
              {
                  this.btOK.Enabled = false;
                  this.cbFormaPago.SelectedIndex = this.cbBanco.SelectedIndex = this.cbBancoPOS.SelectedIndex = this.cbPOS.SelectedIndex = -1;
                  this.txMonto.Enabled = this.cbFormaPago.Enabled = this.btAgregar.Enabled = false;
                  this.cbBanco.Enabled = this.cbBancoPOS.Enabled = this.cbPOS.Enabled = false;
              }
          }
      }


      //Colocar resultados, dar formatos y colores.
      if (this._saldo < 0)
      {
          cambio = this._saldo * (decimal)-1;
          this._saldo = 0;
      }
      this.txSaldo.Text = string.Format("{0:c}", this._saldo);
      this.txSaldo.BackColor = SystemColors.Control;
      if (this._saldo > 0)
          this.txSaldo.ForeColor = Color.Red;
      else
          this.txSaldo.ForeColor = Color.Black;
      this.txSaldo.ReadOnly = true;

      this.txCambio.Text = string.Format("{0:c}", cambio);
      this.txCambio.BackColor = SystemColors.Control;
      if (cambio > 0)
          this.txCambio.ForeColor = Color.Green;
      else
          this.txCambio.ForeColor = Color.Black;
      this.txCambio.ReadOnly = true;

      this.txTotalRecibido.Text = string.Format("{0:c}", totalRecibido);
    }

    private void CargarBancos()
    {
      List<EPK_EntidadFinanciera> tempBancos = new EntidadesFinancieras().ObtenerActivas();

      this._bancos.Clear();
      this._bancos = new BindingList<EPK_EntidadFinanciera>(tempBancos);

      if (this._bancos != null) {
        this.cbBanco.DataSource = this._bancos;
        this.cbBanco.ValueMember = "IdEntidad";
        this.cbBanco.DisplayMember = "Nombre";
      }

      List<EPK_EntidadFinanciera> tempBancosPOS = new EntidadesFinancieras().ObtenerActivasPOS();

      this._bancosPOS.Clear();
      this._bancosPOS = new BindingList<EPK_EntidadFinanciera>(tempBancosPOS);

      if (this._bancosPOS != null) {
        this.cbBancoPOS.DataSource = this._bancosPOS;
        this.cbBancoPOS.ValueMember = "IdEntidad";
        this.cbBancoPOS.DisplayMember = "Nombre";
      }
    }

    private void CargarFormasPago()
    {
      List<EPK_FormaPago> tempFormasPago = new FormasPago().ObtenerActivas(EstadoAplicacion.TiendaActual.IdTipoTienda, this.idCliente);

      this._formasPago.Clear();

      this._formasPago = new BindingList<EPK_FormaPago>(tempFormasPago);

      if (this._formasPago == null)
        return;

      this.cbFormaPago.DataSource = this._formasPago;
      this.cbFormaPago.ValueMember = "IdFormaPago";
      this.cbFormaPago.DisplayMember = "Descripcion";

      this.SeleccionarEfectivo();
    }

    private void FormaPagoChanged()
    {
      this.Limpiar();

      if (this._formasPago == null)
        return;

      if (this.cbFormaPago.SelectedIndex < 0)
        return;

      int idFormaPago;
      int.TryParse(this.cbFormaPago.SelectedValue.ToString(), out idFormaPago);

      if (idFormaPago <= 0)
        return;

      this._formaPagoSel = this._formasPago.FirstOrDefault(fp => fp.IdFormaPago == idFormaPago);

      if (this._formaPagoSel == null)
        return;

      if (this._formaPagoSel.DatosBanco) {
        this.cbBanco.Enabled = true;
        this.cbBanco.SelectedIndex = -1;

        this.txNumero.Enabled = true;
        this.txNumero.MaxLength = this._formaPagoSel.Maximo ?? 10;
        if (this.txNumero.MaxLength < 0 || this.txNumero.MaxLength > 30)
          this.txNumero.MaxLength = 30;
      }

      if (this._formaPagoSel.DatosPOS) {
        this.cbBancoPOS.Enabled = true;
        this.cbBancoPOS.SelectedIndex = -1;

        this.txNumero.MaxLength = this._formaPagoSel.Maximo ?? 4;
        if (this.txNumero.MaxLength < 0 || this.txNumero.MaxLength > 30)
          this.txNumero.MaxLength = 30;
      }
    }

    private void Limpiar()
    {
      this.errorProvider1.SetError(this.cbFormaPago, "");
      this.errorProvider1.SetError(this.cbBanco, "");
      this.errorProvider1.SetError(this.txNumero, "");
      this.errorProvider1.SetError(this.cbBancoPOS, "");
      this.errorProvider1.SetError(this.cbPOS, "");
      this.errorProvider1.SetError(this.txMonto, "");

      this.cbBanco.SelectedIndex = -1;
      this.cbBanco.Enabled = false;

      this.txNumero.Text = string.Empty;
      this.txNumero.Enabled = false;

      this.cbBancoPOS.SelectedIndex = -1;
      this.cbBancoPOS.Enabled = false;

      this.cbPOS.DataSource = null;
      this.cbPOS.Items.Clear();
      this.cbPOS.Enabled = false;
      this.cbPOS.SelectedIndex = -1;

      this.txMonto.Text = string.Empty;
    }

    private void SeleccionarEfectivo()
    {
      if (this._formasPago == null)
        return;

      EPK_FormaPago prederminada = null;

      prederminada = this._formasPago.FirstOrDefault(fp => (fp.EPK_ClienteFormaPago.FirstOrDefault() == null ?
        false : (fp.EPK_ClienteFormaPago.Count(cfp => cfp.IdCliente == this.idCliente && cfp.Principal) > 0)));

      if (prederminada == null) {
        if (this.idEfectivo <= 0) {
          if (this._formasPago.Count() > 0)
            this.cbFormaPago.SelectedIndex = 0;
          return;
        }

        prederminada = this._formasPago.FirstOrDefault(fp => fp.IdFormaPago == this.idEfectivo);
      }

      if (prederminada == null) {
        if (this._formasPago.Count() > 0)
          this.cbFormaPago.SelectedIndex = 0;
        return;
      }

      this.cbFormaPago.SelectedItem = prederminada;
      this.FormaPagoChanged();
    }

    private bool Validar()
    {
      if (this.cbFormaPago.Enabled && this.cbFormaPago.SelectedIndex < 0) {
        this.errorProvider1.SetError(this.cbFormaPago, Properties.Resources.ValSelFormaPago);
        this.cbFormaPago.Focus();
        return false;
      }

      if (this.cbBanco.Enabled && this.cbBanco.SelectedIndex < 0) {
        this.errorProvider1.SetError(this.cbBanco, Properties.Resources.ValSelBancoEm);
        this.cbBanco.Focus();
        return false;
      }

      if (this._formaPagoSel.DatosBanco && !this._formaPagoSel.DatosPOS) {
        if (this.txNumero.Enabled && this.txNumero.Text.Length < 8) {
          this.errorProvider1.SetError(this.txNumero, string.Format(Properties.Resources.ValMinCar, 8));
          this.txNumero.Focus();
          return false;
        }
      }
      else {
        if (this.txNumero.Enabled && this.txNumero.Text.Length < 4) {
          this.errorProvider1.SetError(this.txNumero, string.Format(Properties.Resources.ValMinCar, 4));
          this.txNumero.Focus();
          return false;
        }
      }

      if (this.cbBancoPOS.Enabled && this.cbBancoPOS.SelectedIndex < 0) {
        this.errorProvider1.SetError(this.cbBancoPOS, Properties.Resources.ValSelBancoPOS);
        this.cbBancoPOS.Focus();
        return false;
      }

      if (this.cbPOS.Enabled && this.cbPOS.SelectedIndex < 0) {
        this.errorProvider1.SetError(this.cbPOS, Properties.Resources.ValSelPOS);
        this.cbPOS.Focus();
        return false;
      }

      if (string.IsNullOrEmpty(this.txMonto.Text)) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValIngreseMonto);
        this.txMonto.Focus();
        return false;
      }

      decimal tempMonto;
      if (!decimal.TryParse(this.txMonto.Text, out tempMonto)) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoNoVal);
        return false;
      }

      if (tempMonto <= 0) {
        this.errorProvider1.SetError(this.txMonto, Properties.Resources.ValMontoNoVal);
        return false;
      }

      return true;
    }

    #endregion Private Methods
  }
}