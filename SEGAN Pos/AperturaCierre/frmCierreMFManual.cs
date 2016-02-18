using SEGAN_POS.DAL;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmCierreMFManual : Form
  {
    #region Public Properties

    public DateTime FechaCierre { get; set; }

    public int IdDispositivo { get; set; }

    #endregion Public Properties

    #region Private Properties

    protected EPK_Dispositivo _dispositivo { get; set; }

    protected int _longTF { get; set; }

    #endregion Private Properties

    #region Constructor

    public frmCierreMFManual()
    {
      InitializeComponent();
    }

    public frmCierreMFManual(int idDispositivo, DateTime fechaCierre)
    {
      this.IdDispositivo = idDispositivo;
      this.FechaCierre = fechaCierre;

      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      this.LimpiarErrores();
      this.LimpiarDatos();

      this.errorProvider1.SetError(this.txRepZ, "");

      if (string.IsNullOrEmpty(this.txRepZ.Text)) {
        this.errorProvider1.SetError(this.txRepZ, "Ingrese el Nro. del Reporte Z");
        return;
      }

      this.txRepZ.Text = this.txRepZ.Text.PadLeft(4, '0');

      DatosCierre datosCierre = new CierreMaquinaFiscal().ObtenerDatos(this.IdDispositivo, this.FechaCierre,
        new TimeSpan(this.dtHora.Value.TimeOfDay.Hours, this.dtHora.Value.TimeOfDay.Minutes, 00), this.txRepZ.Text);

      if (datosCierre == null) {
        MessageBox.Show(Properties.Resources.ErrorDatosCierre, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.txFactDesdeSys.Text = datosCierre.FacturasCierre.FacturaDesde;
      this.txFactDesdeSys.Text = this.txFactDesdeSys.Text.PadLeft(this.txFactDesdeSys.MaxLength, '0');
      this.txFactHastaSys.Text = datosCierre.FacturasCierre.FacturaHasta;
      this.txFactHastaSys.Text = this.txFactHastaSys.Text.PadLeft(this.txFactHastaSys.MaxLength, '0');

      this.txBaseSys.Text = string.Format("{0:n2}", datosCierre.FacturasCierre.BaseImponibleFact ?? 0);
      this.txIVASys.Text = string.Format("{0:n2}", datosCierre.FacturasCierre.ImpuestoFact ?? 0);
      this.txDescSys.Text = string.Format("{0:n2}", datosCierre.FacturasCierre.DescuentoFact ?? 0);
      this.txExentosSys.Text = string.Format("{0:n2}", datosCierre.FacturasCierre.ExentoFact ?? 0);

      if (datosCierre.NCsCierre != null)
      {
          this.txBaseNCSys.Text = string.Format("{0:n2}", datosCierre.NCsCierre.BaseImponibleNC ?? 0);
          this.txIVANCSys.Text = string.Format("{0:n2}", datosCierre.NCsCierre.ImpuestoNC ?? 0);
          this.txExentoNCSys.Text = string.Format("{0:n2}", datosCierre.NCsCierre.ExentoNC ?? 0);
          this.txTotNCSys.Text = (datosCierre.NCsCierre.MontoTotalNC ?? 0).ToString();

          this.txVentaNetaSys.Text = (string.Format("{0:n2}", (datosCierre.FacturasCierre.BaseImponibleFact +
                                                               datosCierre.FacturasCierre.ExentoFact -
                                                               datosCierre.NCsCierre.BaseImponibleNC -
                                                               datosCierre.NCsCierre.ExentoNC)));
      }
      else 
      {
          this.txBaseNCSys.Text = string.Format("{0:n2}", 0);
          this.txIVANCSys.Text = string.Format("{0:n2}", 0);
          this.txExentoNCSys.Text = string.Format("{0:n2}", 0);
          this.txTotNCSys.Text = string.Format("{0:n2}", 0);

          this.txVentaNetaSys.Text = (string.Format("{0:n2}", (datosCierre.FacturasCierre.BaseImponibleFact +
                                                               datosCierre.FacturasCierre.ExentoFact)));
      }

      this.txTotFactSys.Text = string.Format("{0:n2}", datosCierre.FacturasCierre.MontoTotalFact);

      this.txCantFactSys.Text = (datosCierre.FacturasCierre.CantidadFacturas ?? 0).ToString();


      this.groupBox1.Enabled = this.btOK.Enabled = true;
      this.txCOO.Focus();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      try {
        this.LimpiarErrores();

        // Se eliminan los espacios al inicio y fin
        this.txRepZ.Text = this.txRepZ.Text.Trim();
        this.txCOO.Text = this.txCOO.Text.Trim();
        this.txFactDesde.Text = this.txFactDesde.Text.Trim();
        this.txFactHasta.Text = this.txFactHasta.Text.Trim();
        this.txBase.Text = this.txBase.Text.Trim();
        this.txIVA.Text = this.txIVA.Text.Trim();
        this.txDesc.Text = this.txDesc.Text.Trim();
        this.txExentos.Text = this.txExentos.Text.Trim();
        this.txBaseNC.Text = this.txBaseNC.Text.Trim();
        this.txIVANC.Text = this.txIVANC.Text.Trim();
        this.txExentoNC.Text = this.txExentoNC.Text.Trim();

        // Validaciones
        if (string.IsNullOrEmpty(this.txRepZ.Text)) {
          this.errorProvider1.SetError(this.txRepZ, Properties.Resources.ValIngreseValor);
          return;
        }
        this.txRepZ.Text = this.txRepZ.Text.PadLeft(this.txRepZ.MaxLength, '0');

        if (string.IsNullOrEmpty(this.txCOO.Text)) {
          this.errorProvider1.SetError(this.txCOO, Properties.Resources.ValIngreseValor);
          return;
        }
        this.txCOO.Text = this.txCOO.Text.PadLeft(this.txCOO.MaxLength, '0');

        if (string.IsNullOrEmpty(this.txFactDesde.Text)) {
          this.errorProvider1.SetError(this.txFactDesde, Properties.Resources.ValIngreseValor);
          return;
        }
        this.txFactDesde.Text = this.txFactDesde.Text.PadLeft(this.txFactDesde.MaxLength, '0');

        if (string.IsNullOrEmpty(this.txFactHasta.Text)) {
          this.errorProvider1.SetError(this.txFactHasta, Properties.Resources.ValIngreseValor);
          return;
        }
        this.txFactHasta.Text = this.txFactHasta.Text.PadLeft(this.txFactHasta.MaxLength, '0');

        if (string.IsNullOrEmpty(this.txBase.Text) && !string.IsNullOrEmpty(this.txBaseSys.Text)) {
          this.errorProvider1.SetError(this.txBase, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoBase;
        if (!decimal.TryParse(this.txBase.Text, out montoBase) && !string.IsNullOrEmpty(this.txBaseSys.Text)) {
          this.errorProvider1.SetError(this.txBase, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txIVA.Text) && !string.IsNullOrEmpty(this.txIVASys.Text)) {
          this.errorProvider1.SetError(this.txIVA, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoIVA;
        if (!decimal.TryParse(this.txIVA.Text, out montoIVA) && !string.IsNullOrEmpty(this.txIVASys.Text)) {
          this.errorProvider1.SetError(this.txIVA, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txDesc.Text) && !string.IsNullOrEmpty(this.txDescSys.Text)) {
          this.errorProvider1.SetError(this.txDesc, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoDesc;
        if (!decimal.TryParse(this.txDesc.Text, out montoDesc) && !string.IsNullOrEmpty(this.txDescSys.Text)) {
          this.errorProvider1.SetError(this.txDesc, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txExentos.Text) && !string.IsNullOrEmpty(this.txExentosSys.Text)) {
          this.errorProvider1.SetError(this.txExentos, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoExento;
        if (!decimal.TryParse(this.txExentos.Text, out montoExento) && !string.IsNullOrEmpty(this.txExentosSys.Text)) {
          this.errorProvider1.SetError(this.txExentos, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txBaseNC.Text) && !string.IsNullOrEmpty(this.txBaseNCSys.Text)) {
          this.errorProvider1.SetError(this.txBaseNC, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoBaseNC;
        if (!decimal.TryParse(this.txBaseNC.Text, out montoBaseNC) && !string.IsNullOrEmpty(this.txBaseNCSys.Text)) {
          this.errorProvider1.SetError(this.txBaseNC, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txIVANC.Text) && !string.IsNullOrEmpty(this.txIVANCSys.Text)) {
          this.errorProvider1.SetError(this.txIVANC, Properties.Resources.ValIngreseValor);
          return;
        }
        decimal montoIVANC;
        if (!decimal.TryParse(this.txIVANC.Text, out montoIVANC) && !string.IsNullOrEmpty(this.txIVANCSys.Text)) {
          this.errorProvider1.SetError(this.txIVANC, Properties.Resources.ValMontoNoVal);
          return;
        }

        if (string.IsNullOrEmpty(this.txExentoNC.Text) && !string.IsNullOrEmpty(this.txExentoNCSys.Text))
        {
            this.errorProvider1.SetError(this.txExentoNC, Properties.Resources.ValIngreseValor);
            return;
        }
        decimal montoExentoNC;
        if (!decimal.TryParse(this.txExentoNC.Text, out montoExentoNC) && !string.IsNullOrEmpty(this.txExentoNCSys.Text))
        {
            this.errorProvider1.SetError(this.txExentoNC, Properties.Resources.ValMontoNoVal);
            return;
        }
        int NZ;
        if (!int.TryParse(this.txZrestantes.Text, out NZ))
        {
            this.errorProvider1.SetError(this.txZrestantes, Properties.Resources.ValMontoNoVal);
            return;
        }

        if (MessageBox.Show(Properties.Resources.MsgPregCierreMF, "Confirmación - " + this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
        

        // Se crea la estructura y cargan los datos
        DatosReduccionZ datosRepZ = new DatosReduccionZ();

        datosRepZ.COO = this.txCOO.Text;
        datosRepZ.PrimerTicketF = this.txFactDesde.Text;
        datosRepZ.UltimoTicketF = this.txFactHasta.Text;
        datosRepZ.BaseTributados = montoBase;
        datosRepZ.IVATributados = montoIVA;
        datosRepZ.Descuentos = montoDesc;
        datosRepZ.Exentos = montoExento;
        datosRepZ.BaseNotasCredito = montoBaseNC;
        datosRepZ.ExentosNC = montoExentoNC;
        datosRepZ.IVANotasCredito = montoIVANC;
        datosRepZ.VentaBruta = montoBase + montoIVA + montoExento;
        datosRepZ.NotasCredito = montoBaseNC + montoIVANC + montoExentoNC;
        datosRepZ.Zrestantes = NZ;
        datosRepZ.Manual = true;

        int priFact = 0, ultFact = 0;
        int.TryParse(this.txFactDesde.Text, out priFact);
        int.TryParse(this.txFactHasta.Text, out ultFact);

        if (priFact > 0 && ultFact > 0)
          datosRepZ.CantidadFacturas = (ultFact - priFact + 1);

        if (!new CierreMaquinaFiscal().Guardar(this.IdDispositivo, this.FechaCierre.Date, this.dtHora.Value.TimeOfDay, this.txRepZ.Text, datosRepZ)) {
          MessageBox.Show(Properties.Resources.ErrorCierreMF, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(Properties.Resources.MsgExitoCierre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format(Properties.Resources.ErrorCierreMF + ": {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        MessageBox.Show(Properties.Resources.ErrorCierreMF, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dtHora_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        this.btBuscar.Focus();
        return;
      }
    }

    private void frmCierreMFManual_Activated(object sender, EventArgs e)
    {
      this.Text = "Cierre de Máquina Fiscal - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmCierreMFManual_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this._longTF = Util.ObtenerParametroEntero("LONGTF");
      if (this._longTF <= 0)
        this._longTF = 8;

      this._dispositivo = new Dispositivos().Obtener(this.IdDispositivo);

      if (this._dispositivo != null)
        this.txSerial.Text = this._dispositivo.Serial;

      if (this.FechaCierre != DateTime.MinValue)
        this.txFecha.Text = this.FechaCierre.ToShortDateString();

      this.dtHora.Value = DateTime.Now;

      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Controls.Add(this.panel2);
      this.groupBox1.Controls.Add(this.panel3);     
      this.groupBox1.Controls.Add(this.panel4);
    }

    private void txBase_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txBaseSys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txBaseSys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.txExentos.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txBase_Leave(object sender, EventArgs e)
    {
      this.txTotFact.Text = string.Empty;

      if (string.IsNullOrEmpty(this.txIVA.Text) && string.IsNullOrEmpty(this.txBase.Text) && string.IsNullOrEmpty(txExentos.Text))
        return;

      decimal mBase = 0, mIVA = 0, mExento = 0;
      decimal.TryParse(this.txIVA.Text, out mIVA);
      decimal.TryParse(this.txBase.Text, out mBase);
      decimal.TryParse(this.txExentos.Text, out mExento);


      this.txTotFact.Text = string.Format("{0:n2}", mBase + mIVA + mExento);
    }

    private void txBaseNC_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txBaseNCSys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txBaseNCSys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.txExentoNC.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txBaseNC_Leave(object sender, EventArgs e)
    {
      this.txTotNC.Text = string.Empty;

      if (string.IsNullOrEmpty(this.txIVANC.Text) && string.IsNullOrEmpty(((TextBox)sender).Text) && string.IsNullOrEmpty(this.txExentoNC.Text))
          return;

      decimal mBase = 0, mIVA = 0, mExento = 0;
      decimal.TryParse(this.txIVANC.Text, out mIVA);
      decimal.TryParse(((TextBox)sender).Text, out mBase);
      decimal.TryParse(this.txExentoNC.Text, out mExento);

      this.txTotNC.Text = string.Format("{0:n2}", mBase + mIVA + mExento);
    }

    private void txCOO_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError((TextBox)sender, "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        ((TextBox)sender).Text = ((TextBox)sender).Text.PadLeft(((TextBox)sender).MaxLength, '0');

        this.txDesc.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txDesc_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txDescSys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txDescSys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.txZrestantes.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txDesc_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.txDesc.Text))
        {
            this.txDesc.Text = (-1 * decimal.Parse(this.txDesc.Text)).ToString();
        }
    }

    private void txExentos_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txExentosSys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txExentosSys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.txIVA.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txFactDesde_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        ((TextBox)sender).Text = ((TextBox)sender).Text.PadLeft(((TextBox)sender).MaxLength, '0');

        this.txFactHasta.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txFactDesde_Leave(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.txFactHasta.Text) && string.IsNullOrEmpty(((TextBox)sender).Text))
        return;

      int priFact = 0, ultFact = 0;
      int.TryParse(((TextBox)sender).Text, out priFact);
      int.TryParse(this.txFactHasta.Text, out ultFact);

      if (priFact > 0 && ultFact > 0)
        this.txCantFact.Text = (ultFact - priFact + 1).ToString();
    }

    private void txFactHasta_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        ((TextBox)sender).Text = ((TextBox)sender).Text.PadLeft(((TextBox)sender).MaxLength, '0');

        this.txBase.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txFactHasta_Leave(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.txFactDesde.Text) && string.IsNullOrEmpty(((TextBox)sender).Text))
        return;

      int priFact = 0, ultFact = 0;
      int.TryParse(this.txFactDesde.Text, out priFact);
      int.TryParse(((TextBox)sender).Text, out ultFact);

      if (priFact > 0 && ultFact > 0)
        this.txCantFact.Text = (ultFact - priFact + 1).ToString();
    }

    private void txIVA_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txIVASys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txIVASys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.txBaseNC.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txIVANC_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txIVANCSys.Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        decimal monto;
        if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txIVANCSys.Text)) {
          this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
          return;
        }

        this.btOK.Focus();
        return;
      }

      if (e.KeyChar == '.')
        e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txIVANC_Leave(object sender, EventArgs e)
    {
        this.txTotNC.Text = string.Empty;

        if (string.IsNullOrEmpty(this.txBaseNC.Text) && string.IsNullOrEmpty(((TextBox)sender).Text) && string.IsNullOrEmpty(this.txExentoNC.Text))
            return;

        decimal mBase = 0, mIVA = 0, mExento = 0;
        decimal.TryParse(this.txExentoNC.Text, out mExento);
        decimal.TryParse(((TextBox)sender).Text, out mIVA);
        decimal.TryParse(this.txBaseNC.Text, out mBase);

        this.txTotNC.Text = string.Format("{0:n2}", mBase + mIVA + mExento);

        //Calculo de Venta Neta
        if (string.IsNullOrEmpty(this.txBase.Text) && string.IsNullOrEmpty(this.txExentos.Text))
            return;

        decimal Base = 0, Exento = 0;
        decimal.TryParse(this.txBase.Text, out Base);
        decimal.TryParse(this.txExentos.Text, out Exento);

        this.txVentaNeta.Text = string.Format("{0:n2}", Base + Exento - mBase - mExento);
    }

    private void txRepZ_KeyPress(object sender, KeyPressEventArgs e)
    {
      this.errorProvider1.SetError(((TextBox)sender), "");

      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
          return;
        }

        ((TextBox)sender).Text = ((TextBox)sender).Text.PadLeft(((TextBox)sender).MaxLength, '0');

        this.dtHora.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txExentoNC_KeyPress(object sender, KeyPressEventArgs e)
    {
        this.errorProvider1.SetError(((TextBox)sender), "");

        if (e.KeyChar == (char)Keys.Back)
        {
            base.OnKeyPress(e);
            return;
        }

        if (e.KeyChar == (char)Keys.Return)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

            if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txExentoNCSys.Text))
            {
                this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
                return;
            }

            decimal monto;
            if (!decimal.TryParse(((TextBox)sender).Text, out monto) && !string.IsNullOrEmpty(this.txExentoNCSys.Text))
            {
                this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
                return;
            }

            this.txIVANC.Focus();
            return;
        }

        if (e.KeyChar == '.')
            e.KeyChar = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

        if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
            e.Handled = true;
        else
            base.OnKeyPress(e);
    }

    private void txExentoNC_Leave(object sender, EventArgs e)
    {
        this.txTotNC.Text = string.Empty;

        if (string.IsNullOrEmpty(this.txBaseNC.Text) && string.IsNullOrEmpty(((TextBox)sender).Text) && string.IsNullOrEmpty(this.txIVANC.Text))
            return;

        decimal mBase = 0, mIVA = 0, mExento = 0;
        decimal.TryParse(this.txIVANC.Text, out mIVA);
        decimal.TryParse(((TextBox)sender).Text, out mExento);
        decimal.TryParse(this.txBaseNC.Text, out mBase);

        this.txTotNC.Text = string.Format("{0:n2}", mBase + mIVA + mExento);
    }

    #endregion Events

    #region Private Methods

    private void LimpiarErrores()
    {
      this.errorProvider1.SetError(this.txRepZ, "");
      this.errorProvider1.SetError(this.txCOO, "");
      this.errorProvider1.SetError(this.txFactDesde, "");
      this.errorProvider1.SetError(this.txFactHasta, "");
      this.errorProvider1.SetError(this.txBase, "");
      this.errorProvider1.SetError(this.txIVA, "");
      this.errorProvider1.SetError(this.txDesc, "");
      this.errorProvider1.SetError(this.txExentos, "");
      this.errorProvider1.SetError(this.txBaseNC, "");
      this.errorProvider1.SetError(this.txIVANC, "");
    }

    private void LimpiarDatos()
    {
      this.txFactDesdeSys.Text = this.txFactHastaSys.Text = this.txBaseSys.Text = this.txIVASys.Text = this.txDescSys.Text =
        this.txExentosSys.Text = this.txBaseNCSys.Text = this.txIVANCSys.Text = this.txTotFactSys.Text = this.txTotNCSys.Text =
        this.txCantFactSys.Text = string.Empty;

      this.txFactDesde.Text = this.txFactHasta.Text = this.txBase.Text = this.txIVA.Text =
        this.txDesc.Text = this.txExentos.Text = this.txBaseNC.Text = this.txIVANC.Text = this.txTotFact.Text = this.txTotNC.Text =
        this.txCantFact.Text = string.Empty;
    }
    
    
    #endregion Private Methods

    private void txZrestantes_KeyPress(object sender, KeyPressEventArgs e)
    {
        this.errorProvider1.SetError(((TextBox)sender), "");

        if (e.KeyChar == (char)Keys.Back)
        {
            base.OnKeyPress(e);
            return;
        }

        if (e.KeyChar == (char)Keys.Return)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

            if (string.IsNullOrEmpty(((TextBox)sender).Text) && !string.IsNullOrEmpty(this.txDescSys.Text))
            {
                this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseValor);
                return;
            }

            int NZ;
            if (!int.TryParse(((TextBox)sender).Text, out NZ))
            {
                this.errorProvider1.SetError(((TextBox)sender), Properties.Resources.ValMontoNoVal);
                return;
            }

            this.txFactDesde.Focus();
            return;
        }

        if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9\\" + Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0] + "]+$"))
            e.Handled = true;
        else
            base.OnKeyPress(e);
    }
  }
}