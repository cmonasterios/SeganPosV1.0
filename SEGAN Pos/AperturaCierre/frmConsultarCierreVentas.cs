using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmConsultarCierreVentas : Form
  {

    #region Constructor

    public frmConsultarCierreVentas()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      int tempInt;

      int? idUsuario = null;
      if (this.cbUsuario.SelectedIndex > -1) {
        int.TryParse(this.cbUsuario.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idUsuario = tempInt;
      }

      List<ItemCierre> resultCierres = new CierreVentas().Buscar(this.dtpDesde.Value.Date, this.dtpHasta.Value.Date, idUsuario);

      this.dgCierres.DataSource = resultCierres;
      this.dgCierres.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", resultCierres.Count());
      this.lbCantReg.Visible = true;
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void frmConsCierreVentas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.CargarCombo();
      this.Limpiar();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
        this.dtpHasta.Value = ((DateTimePicker)sender).Value;

      this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void dgCierres_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgCierres_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgCierres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      ItemCierre itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ItemCierre);

      if (itemSel == null)
        return;

      new frmVerCierreVentas(itemSel.IdCierreV).ShowDialog();
    }

    private void frmConsultarCierreVentas_Activated(object sender, EventArgs e)
    {
      this.Text = "Consultar Cierre de Ventas - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void Limpiar()
    {
      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      this.cbUsuario.SelectedIndex = -1;

      List<ItemCierre> tempList = new List<ItemCierre>();

      this.dgCierres.DataSource = tempList;
      this.dgCierres.Refresh();

      this.lbCantReg.Visible = false;

      this.dtpDesde.Focus();
    }

    private void CargarCombo()
    {
      List<EPK_Usuario> listadoUsuarios = new Accesos().ObtenerAutorizadores("frmCierreVentas", "Agregar");

      if (listadoUsuarios == null)
        return;

      if (listadoUsuarios.Count() == 0)
        return;

      this.cbUsuario.DataSource = listadoUsuarios;
      this.cbUsuario.ValueMember = "IdUsuario";
      this.cbUsuario.DisplayMember = "Identificacion";
    }

    #endregion

  }
}
