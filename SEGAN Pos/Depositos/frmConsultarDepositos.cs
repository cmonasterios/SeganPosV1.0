using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmConsultarDepositos : Form
  {

    #region Constructor

    public frmConsultarDepositos()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmConsultarDepositos_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombos();
      this.Limpiar();

      if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Exportar"))
        this.btExport.Visible = false;

      /*if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Imprimir"))
        this.btImprimir.Visible = false;*/

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
    }

    private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmConsultarDepositos_Shown(object sender, EventArgs e)
    {
      if (new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name))
        return;

      MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void btBuscar_Click(object sender, EventArgs e)
    {
      List<DepositosConsulta> resultDepositos = this.ConsultarDatos();

      this.dgResults.DataSource = resultDepositos;
      this.dgResults.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", resultDepositos.Count());
      this.lbCantReg.Visible = true;

      this.btExport.Enabled = this.btImprimir.Enabled = (resultDepositos.Count() > 0);
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
        this.dtpHasta.Value = ((DateTimePicker)sender).Value;

      this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void btExport_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "Depositos.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      List<DepositosConsulta> resultDepositos = this.ConsultarDatos();

      if (resultDepositos.Count() == 0)
        return;

      var exceldata = (from r in resultDepositos
                       select new {
                         FechaDeposito = r.FechaDeposito.ToString("d"),
                         NroControl = r.IdDeposito.ToString(),
                         Banco = r.Banco,
                         TipoDeposito = r.TipoDeposito,
                         NroEnvase = r.SerialPrecinto,
                         NroDeposito = r.NroTransaccion,
                         MontoEfectivo = r.MontoEfectivo,
                         MontoCheque = r.MontoCheque,
                         MontoTotal = r.MontoTotal
                       }).ToList();

      if (new ExportExcel().DumpExcel(exceldata, ((SaveFileDialog)sender).FileName))
        MessageBox.Show("Depósitos exportados exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show("Error al escribir el archivo", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void frmConsultarDepositos_Activated(object sender, EventArgs e)
    {
      this.Text = "Consultar Depósitos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void dgResults_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DepositosConsulta itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DepositosConsulta);

      if (itemSel == null)
        return;

      new frmVerDeposito(itemSel.IdDeposito).ShowDialog();
    }

    private void btImprimir_Click(object sender, EventArgs e)
    {
      List<DepositosConsulta> resultDepositos = this.ConsultarDatos();

      if (resultDepositos.Count() == 0)
        return;

      DateTime? fIni = null, fFin = null;

      if (this.dtpDesde.Checked)
        fIni = this.dtpDesde.Value;

      if (this.dtpHasta.Checked)
        fFin = this.dtpHasta.Value;

      decimal ventasEfect = new DAL.Facturas().BuscarPagosEfectivo(fIni, fFin);
      decimal ventasCheq = new DAL.Facturas().BuscarPagosCheque(fIni, fFin);

      frmRepDepositos fRepDep = new frmRepDepositos();

      fRepDep.VentasEfectivo = ventasEfect;
      fRepDep.VentasCheque = ventasCheq;
      fRepDep.datosDep = resultDepositos;

      fRepDep.ShowDialog();
    }

    #endregion

    #region Private Methods

    private void CargarCombos()
    {
      this.cbTiposDeposito.Items.Clear();

      this.cbTiposDeposito.Items.Add("--Todos--");
      this.cbTiposDeposito.Items.Add("Valores");
      this.cbTiposDeposito.Items.Add("En Banco");

      this.cbTiposDeposito.SelectedIndex = 0;

      this.cbBancos.Items.Clear();

      List<EPK_EntidadFinanciera> entidadesFinancieras = new EntidadesFinancieras().ObtenerActivas().ToList();

      this.cbBancos.DataSource = entidadesFinancieras;
      this.cbBancos.ValueMember = "IdEntidad";
      this.cbBancos.DisplayMember = "Nombre";

      this.cbBancos.SelectedIndex = -1;
    }

    private void Limpiar()
    {
      this.txSerialPrecinto.Text = this.txNumeroTrans.Text = string.Empty;

      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      this.dtpDesde.Checked = this.dtpHasta.Checked = false;

      this.cbTiposDeposito.SelectedIndex = 0;
      this.cbBancos.SelectedIndex = -1;

      List<DepositosConsulta> tempList = new List<DepositosConsulta>();

      this.dgResults.DataSource = tempList;
      this.dgResults.Refresh();

      this.lbCantReg.Visible = false;
      this.btExport.Enabled = this.btImprimir.Enabled = false;

      this.dtpDesde.Focus();
    }

    private List<DepositosConsulta> ConsultarDatos()
    {
      DateTime? fIni = null, fFin = null;

      if (this.dtpDesde.Checked)
        fIni = this.dtpDesde.Value;

      if (this.dtpHasta.Checked)
        fFin = this.dtpHasta.Value;

      int tempInt;

      int? idEntidad = null;
      if (this.cbBancos.SelectedIndex > -1) {
        int.TryParse(this.cbBancos.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idEntidad = tempInt;
      }

      bool? DepositoValores = null;
      if (this.cbTiposDeposito.SelectedIndex == 1)
        DepositoValores = true;
      if (this.cbTiposDeposito.SelectedIndex == 2)
        DepositoValores = false;

      return new DAL.Depositos().Consultar(fIni, fFin,
        this.txSerialPrecinto.Text.Trim(), this.txNumeroTrans.Text.Trim(), DepositoValores, idEntidad);
    }

    #endregion

  }
}
