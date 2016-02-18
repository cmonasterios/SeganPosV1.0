using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmBuscarCheques : Form
  {

    #region Public Properties

    public List<Cheque> Cheques { get; set; }
    public List<Cheque> ChequesSel { get; set; }

    #endregion

    #region Private Properties

    private int _CantReg { get; set; }

    #endregion

    #region Constructor

    public frmBuscarCheques()
    {
      InitializeComponent();

      this._CantReg = 0;
      this.Cheques = null;
    }

    #endregion

    #region Events

    private void frmBuscarCheques_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
      this.CalcularTotales();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.Cheques = this.Cheques.Where(c => c.Seleccionado).ToList();

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void frmBuscarCheques_Activated(object sender, EventArgs e)
    {
      this.Text = "Buscar Cheques - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex != 0)
        e.Cancel = true;
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void cbTodos_Click(object sender, EventArgs e)
    {
      foreach (Cheque item in this.Cheques)
        item.Seleccionado = ((CheckBox)sender).Checked;

      this.dgItems.Refresh();
      this.CalcularTotales();
    }

    private void dgItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (((DataGridView)sender).IsCurrentCellDirty)
        ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 0)
        return;

      this.CalcularTotales();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      this.Cheques = new Facturas().ChequesSinDepositar();

      if (this.Cheques == null)
        return;

      if (this.Cheques.Count() == 0)
        return;

      if (this.ChequesSel != null)
        foreach (Cheque item in this.ChequesSel) {
          Cheque found = this.Cheques.FirstOrDefault(c => c.IdPago == item.IdPago);
          if (found != null)
            found.Seleccionado = true;
        }

      this._CantReg = this.Cheques.Count();
      this.lbCantReg.Text = string.Format("{0} Registro(s) Encontrado(s).", this._CantReg);

      this.dgItems.DataSource = this.Cheques;
      this.dgItems.Refresh();

      this.cbTodos.Enabled = true;
    }

    private void CalcularTotales()
    {
      if (this.Cheques == null) {
        this.lbCantReg.Text = "0 Registro(s) Seleccionado(s).";
        return;
      }

      int cantSel = this.Cheques.Where(c => c.Seleccionado).Count();

      this.lbCantSel.Text = string.Format("{0} Registro(s) Seleccionado(s).", this.Cheques.Where(c => c.Seleccionado).Count());

      this.cbTodos.Checked = (this._CantReg == cantSel);
    }

    #endregion

  }
}
