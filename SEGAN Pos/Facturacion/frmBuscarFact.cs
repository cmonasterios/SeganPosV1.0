using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmBuscarFact : Form
  {

    #region Public Properties

    public int idFacturaOrig { get; set; }
    public int idFacturaSust { get; set; }

    #endregion

    #region Contructor

    public frmBuscarFact()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmBuscarFact_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      if (this.dgFacturas.SelectedRows.Count == 0)
        return;

      ListadoFacturas itemSel = (this.dgFacturas.SelectedRows[0].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      this.idFacturaSust = itemSel.IdFactura.Value;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btBuscarFact_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txNFact, "");
      this.errorProvider1.SetError(this.txDocCliente, "");

      this.LimpiarGrid();

      int tempInt;

      int? Numero = null;
      if (int.TryParse(this.txNFact.Text, out tempInt))
        Numero = tempInt;

      if (!Numero.HasValue && string.IsNullOrEmpty(this.txDocCliente.Text.Trim())) {
        this.errorProvider1.SetError(this.txNFact, Properties.Resources.ValIngreseNumeroODoc);
        this.errorProvider1.SetError(this.txDocCliente, Properties.Resources.ValIngreseNumeroODoc);
        return;
      }

      SortableBindingList<ListadoFacturas> resultFacturas = new SortableBindingList<ListadoFacturas>(
        new Facturas().Consultar(this.idFacturaOrig, Numero, this.txDocCliente.Text.Trim()));

      this.dgFacturas.DataSource = resultFacturas;
      this.dgFacturas.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", resultFacturas.Count());
      this.lbCantReg.Visible = true;
    }

    private void dgFacturas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void txNFact_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void dgFacturas_SelectionChanged(object sender, EventArgs e)
    {
      this.btOK.Enabled = false;

      if (((DataGridView)sender).SelectedRows.Count == 0)
        return;

      ListadoFacturas itemSel = (((DataGridView)sender).SelectedRows[0].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      this.btOK.Enabled = true;
    }

    private void dgFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      ListadoFacturas itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      this.idFacturaSust = itemSel.IdFactura.Value;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void frmBuscarFact_Shown(object sender, EventArgs e)
    {
      this.txNFact.Focus();
    }

    #endregion

    #region Private Methods

    private void LimpiarGrid()
    {
      List<ListadoFacturas> tempList = new List<ListadoFacturas>();

      this.dgFacturas.DataSource = tempList;
      this.dgFacturas.Refresh();

      this.lbCantReg.Visible = false;
      this.btOK.Enabled = false;
    }

    #endregion

  }
}
