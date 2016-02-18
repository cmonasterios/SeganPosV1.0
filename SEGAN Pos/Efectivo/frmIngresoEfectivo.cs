using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmIngresoEfectivo : Form
  {

    #region Private Properties

    private BindingList<DenominacionIngresoEfectivo> _listDenominacionIngreso { get; set; }

    #endregion

    #region Constructor

    public frmIngresoEfectivo()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmIngresoEfectivo_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
      this.CalcularTotales();
    }

    private void frmIngresoEfectivo_Activated(object sender, EventArgs e)
    {
      this.Text = "Ingreso de Efectivo - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;

    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txObs, "");

      this.txObs.Text = this.txObs.Text.Trim();

      if (string.IsNullOrEmpty(this.txObs.Text)) {
        this.errorProvider1.SetError(this.txObs, Properties.Resources.ValIngreseObs);
        return;
      }

      EPK_FlujoEfectivo ingresoEfectivo = new EPK_FlujoEfectivo();

      ingresoEfectivo.Cambio = false;
      ingresoEfectivo.Total = this._listDenominacionIngreso.Sum(l => l.TotalIngreso);
      ingresoEfectivo.Observacion = this.txObs.Text;

      ingresoEfectivo.EPK_FlujoEfectivoDetalle = this._listDenominacionIngreso.
        Where(l => l.Ingreso > 0).Select(l => new EPK_FlujoEfectivoDetalle {
          IdDenominacion = l.IdDenominacion,
          Ingreso = l.Ingreso,
          Egreso = 0
        }).ToList();

      int idCambio = new FlujoEfectivo().Nuevo(ingresoEfectivo);

      if (idCambio <= 0) {
        MessageBox.Show(Properties.Resources.ErrorIngresoEfectivo, "Error - " + this.Text,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgEfectivo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgEfectivo_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgEfectivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DenominacionIngresoEfectivo itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionIngresoEfectivo);

      if (itemSel == null)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;

      fCant.Titulo = "Ingreso";
      fCant.Cantidad = itemSel.Ingreso;
      fCant.ValorMaximo = 999;

      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      if (fCant.Cantidad == itemSel.Ingreso)
        return;

      itemSel.Ingreso = (short)fCant.Cantidad;
      itemSel.TotalIngreso = itemSel.Ingreso * itemSel.Denominacion;

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      List<EPK_Denominacion> denominaciones = new Denominacion().ObtenerTodas();

      if (denominaciones == null)
        return;

      this._listDenominacionIngreso = new BindingList<DenominacionIngresoEfectivo>(
        denominaciones.Select(d => new DenominacionIngresoEfectivo {
          IdDenominacion = d.IdDenominacion,
          Logo = d.Logo,
          Denominacion = d.Denominacion,
          Ingreso = 0,
          TotalIngreso = 0
        }).OrderByDescending(rd => rd.Denominacion).ToList());

      this.dgEfectivo.DataSource = this._listDenominacionIngreso;
      this.dgEfectivo.Refresh();
    }

    private void CalcularTotales()
    {
      this.btOK.Enabled = false;

      int cantIngreso = this._listDenominacionIngreso.Sum(l => l.Ingreso);
      decimal montoIngreso = this._listDenominacionIngreso.Sum(l => l.TotalIngreso);

      this.txIngreso.Text = cantIngreso.ToString();
      this.txMontoIngreso.Text = string.Format("{0:C2}", montoIngreso);

      if (cantIngreso > 0)
        this.btOK.Enabled = true;
    }

    #endregion

  }
}
