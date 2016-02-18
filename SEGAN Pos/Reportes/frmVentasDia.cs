using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmVentasDia : Form
  {

    #region Constructor

    public frmVentasDia()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmVentasDia_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmVentasDia_Activated(object sender, EventArgs e)
    {
      this.Text = "Ventas del Día - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      List<ItemVentasDia> ventasDias = new DAL.Reportes().VentasDia();

      if (ventasDias == null)
        return;

      if (ventasDias.Count() == 0)
        return;

      decimal Total = ventasDias.Sum(v => v.MontoTotal ?? 0);

      this.lbTotal.Text = string.Format("Total Ventas: {0:c}", Total);
      this.lbTotal.Visible = true;

      if (Total > 0)
        foreach (ItemVentasDia item in ventasDias)
          item.Porcent = item.MontoTotal * 100 / Total;

      this.dgItems.DataSource = ventasDias;
      this.dgItems.Refresh();
    }

    #endregion

  }
}
