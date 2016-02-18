using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmDevolucion : Form
  {

    #region Public Properties

    public BindingList<ItemsFactura> ItemsDevolucion { get; set; }

    #endregion

    #region Constructor

    public frmDevolucion()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmDevolucion_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombo();

      this.dgItems.DataSource = this.ItemsDevolucion;
      this.dgItems.Refresh();
    }

    private void frmDevolucion_Shown(object sender, EventArgs e)
    {
      if (this.ItemsDevolucion == null) {
        this.Close();
        return;
      }

      if (this.ItemsDevolucion.Count() == 0) {
        this.Close();
        return;
      }
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      if (this.ItemsDevolucion.Where(id => !id.IdMotivo.HasValue).Count() > 0)
        return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;

      // Log Auditoria
      new NLogLogger().Error("Se realizó con éxito la devolución " + Application.ProductName);
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      foreach (ItemsFactura item in this.ItemsDevolucion)
        item.IdMotivo = null;

      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void dgItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (((DataGridView)sender).IsCurrentCellDirty)
        ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void dgItems_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
      ((DataGridView)sender).BeginEdit(false);

      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 6)
        return;

      if (((DataGridView)sender).EditingControl != null && ((DataGridView)sender).EditingControl is ComboBox) {
        ComboBox cmb = ((DataGridView)sender).EditingControl as ComboBox;
        cmb.DroppedDown = true;
      }
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex != 6)
        e.Cancel = true;
    }

    private void dgItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (this.ItemsDevolucion == null)
        return;

      int pendientes = this.ItemsDevolucion.Where(id => !id.IdMotivo.HasValue).Count();
      this.btOK.Enabled = (pendientes == 0);
    }

    private void frmDevolucion_Activated(object sender, EventArgs e)
    {
      this.Text = "Devoluciones - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarCombo()
    {
      List<EPK_MotivoDevolucion> motDev = new MotivosDevolucion().ObtenerTodos();

      if (motDev == null)
        return;

      DataGridViewComboBoxColumn comboColumn = (DataGridViewComboBoxColumn)this.dgItems.Columns["Motivo"];

      comboColumn.DataSource = motDev;
      comboColumn.ValueMember = "IdMotivo";
      comboColumn.DisplayMember = "Motivo";
    }

    #endregion

  }
}
