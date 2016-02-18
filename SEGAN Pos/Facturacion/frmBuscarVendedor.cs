using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmBuscarVendedor : Form
  {

    #region Public Properties

    public EPK_Empleados VendedorSel { get; set; }

    #endregion

    #region Private Properties

    private List<EPK_Empleados> _vendedores { get; set; }

    #endregion

    #region Constructor

    public frmBuscarVendedor()
    {
      InitializeComponent();

      this._vendedores = null;
      this.VendedorSel = null;
    }

    #endregion

    #region Events

    private void frmBuscarVendedor_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombo();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      if (this.cbVendedor.SelectedIndex < 0)
        return;

      int idEmpleado;
      int.TryParse(this.cbVendedor.SelectedValue.ToString(), out idEmpleado);

      if (idEmpleado <= 0)
        return;

      if (this._vendedores == null)
        return;

      this.VendedorSel = this._vendedores.FirstOrDefault(v => v.IdEmpleado == idEmpleado);

      if (this.VendedorSel == null)
        return;

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.VendedorSel = null;
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.btOK.Enabled = false;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      this.btOK.Enabled = true;
    }

    private void frmBuscarVendedor_Activated(object sender, EventArgs e)
    {
      this.Text = Properties.Resources.TipSelVendedor + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmBuscarVendedor_Shown(object sender, EventArgs e)
    {
      this.cbVendedor.Focus();
    }

    #endregion

    #region Private Methods

    private void CargarCombo()
    {
        this._vendedores = new Empleados().ObtenerVendedores();

        if (this._vendedores == null)
            return;

        if (this._vendedores.Count() == 0)
            return;

        this.cbVendedor.DataSource = this._vendedores.Select(v => new { IdEmpleado = v.IdEmpleado, NombreCompleto = v.Nombre.Trim() + " " + v.Apellido.Trim() }).ToList();
        this.cbVendedor.ValueMember = "IdEmpleado";
        this.cbVendedor.DisplayMember = "NombreCompleto";

        this.cbVendedor.Enabled = true;
        this.cbVendedor.SelectedIndex = 0;
        this.cbVendedor.SelectedIndex = -1;
    }

    #endregion

  }
}
