using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmCambioEfectivo : Form
  {

    #region Private Properties

    private BindingList<DenominacionCambioEfectivo> _listDenominacionCambio { get; set; }

    #endregion

    #region Constructor

    public frmCambioEfectivo()
    {
      InitializeComponent();

      this._listDenominacionCambio = new BindingList<DenominacionCambioEfectivo>();
    }

    #endregion

    #region Events

    private void btOK_Click(object sender, EventArgs e)
    {
      EPK_FlujoEfectivo cambioEfectivo = new EPK_FlujoEfectivo();

      cambioEfectivo.Cambio = true;
      cambioEfectivo.Total = this._listDenominacionCambio.Sum(l => l.Ingreso * l.Denominacion);

      cambioEfectivo.EPK_FlujoEfectivoDetalle = this._listDenominacionCambio.
        Where(l => l.Ingreso > 0 || l.Egreso > 0).Select(l => new EPK_FlujoEfectivoDetalle {
          IdDenominacion = l.IdDenominacion,
          Ingreso = l.Ingreso,
          Egreso = l.Egreso
        }).ToList();

      int idCambio = new FlujoEfectivo().Nuevo(cambioEfectivo);

      if (idCambio <= 0) {
        MessageBox.Show(Properties.Resources.ErrorCambioEfectivo, "Error - " + this.Text,
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

    private void dgEfectivo_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void frmCambioEfectivo_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
      this.CalcularTotales();
    }

    private void frmCambioEfectivo_Activated(object sender, EventArgs e)
    {
      this.Text = "Cambio de Efectivo - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void dgEfectivo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgEfectivo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex < 5 || e.ColumnIndex > 6)
        return;

      DenominacionCambioEfectivo itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionCambioEfectivo);

      if (itemSel == null)
        return;

      if (e.ColumnIndex == 6 && itemSel.Cantidad <= 0)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;

      switch (e.ColumnIndex) {
        case 5:
          fCant.Titulo = "Ingreso";
          fCant.Cantidad = itemSel.Ingreso;
          fCant.ValorMaximo = 999;
          break;

        case 6:
          fCant.Titulo = "Egreso";
          fCant.Cantidad = itemSel.Egreso;
          fCant.ValorMaximo = itemSel.Cantidad;
          break;
      }

      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      switch (e.ColumnIndex) {
        case 5:
          if (fCant.Cantidad == itemSel.Ingreso)
            return;
          itemSel.Ingreso = (short)fCant.Cantidad;
          break;

        case 6:
          if (fCant.Cantidad == itemSel.Egreso)
            return;
          itemSel.Egreso = (short)fCant.Cantidad;
          break;
      }

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      EPK_EfectivoRemanenteEncabezado remanente = new EfectivoRemanente().ObtenerUltimo();
      this.dgEfectivo.ShowCellToolTips = false;
      if (remanente == null)
        return;

      this._listDenominacionCambio = new BindingList<DenominacionCambioEfectivo>(
        remanente.EPK_EfectivoRemanenteDetalle.Where(rd => rd.CantidadActual > 0).
        GroupBy(rd => rd.EPK_Denominacion).Select(rd => new DenominacionCambioEfectivo {
          IdDenominacion = rd.Key.IdDenominacion,
          Logo = rd.Key.Logo,
          Denominacion = rd.Key.Denominacion,
          Cantidad = rd.Sum(d => d.CantidadActual),
          TotalDenominacion = rd.Sum(d => d.CantidadActual) * rd.Key.Denominacion,
          Ingreso = 0,
          Egreso = 0
        }).OrderByDescending(rd => rd.Denominacion).ToList());

      decimal totalAprobado = this._listDenominacionCambio.Sum(l => l.TotalDenominacion);
      this.txMontoApro.Text = string.Format("{0:C2}", totalAprobado);


      BindingList<DenominacionCambioEfectivo> ListResult = new BindingList<DenominacionCambioEfectivo>();

      foreach (EPK_Denominacion D in new Denominacion().ObtenerTodas())
      {
          if (this._listDenominacionCambio.Any(p => p.IdDenominacion == D.IdDenominacion))
          {
              ListResult.Add(_listDenominacionCambio.Where(p => p.IdDenominacion == D.IdDenominacion).FirstOrDefault());
          }
          else
          {
              ListResult.Add(new DenominacionCambioEfectivo
              {
                  IdDenominacion = D.IdDenominacion,
                  Logo = D.Logo,
                  Denominacion = D.Denominacion,
                  Cantidad = 0,
                  TotalDenominacion = 0,
                  Ingreso = 0,
                  Egreso = 0
              });
          }
      }

      this._listDenominacionCambio = ListResult;

      this.dgEfectivo.DataSource = ListResult;
      this.dgEfectivo.Refresh();
    }

    private void CalcularTotales()
    {
      this.btOK.Enabled = false;

      decimal totalAprobado = this._listDenominacionCambio.Sum(l => l.TotalDenominacion);
      decimal totalIngresos = this._listDenominacionCambio.Sum(l => l.Ingreso * l.Denominacion);
      decimal totalEgresos = this._listDenominacionCambio.Sum(l => l.Egreso * l.Denominacion);
      decimal diferencia = Math.Abs(totalEgresos - totalIngresos);

      this.txMontoApro.Text = string.Format("{0:C2}", totalAprobado);
      this.txIngreso.Text = string.Format("{0:C2}", totalIngresos);
      this.txEgreso.Text = string.Format("{0:C2}", totalEgresos);
      this.txDiferencia.Text = string.Format("{0:C2}", diferencia);

      this.txDiferencia.BackColor = SystemColors.Control;

      if (diferencia != 0) {
        this.txDiferencia.Font = new Font(this.txDiferencia.Font, FontStyle.Bold);
        this.txDiferencia.ForeColor = Color.Red;
      }
      else {
        this.txDiferencia.Font = new Font(this.txDiferencia.Font, FontStyle.Regular);
        this.txDiferencia.ForeColor = Color.Black;
      }

      this.txDiferencia.ReadOnly = true;

      if (totalIngresos > 0 && totalEgresos > 0 && diferencia == 0)
        this.btOK.Enabled = true;
    }

    #endregion

  }
}
