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
  public partial class frmCantidad : Form
  {

    #region Public Properties

    public int Cantidad { get; set; }

    public decimal ValorMinimo
    {
      set
      {
        this.udCantidad.Minimum = value;
      }
    }

    public decimal ValorMaximo
    {
      set
      {
        this.udCantidad.Maximum = value;
      }
    }

    public string Titulo
    {
      set
      {
        this.Text = value;
      }
      get
      {
        return this.Text;
      }
    }

    #endregion

    #region Constructor

    public frmCantidad()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmCantidad_Load(object sender, EventArgs e)
    {
      if (this.Cantidad >= this.udCantidad.Minimum && this.Cantidad <= this.udCantidad.Maximum)
        this.udCantidad.Value = this.Cantidad;

      this.udCantidad.Select(0, this.udCantidad.Text.Length);
      this.udCantidad.Focus();
    }

    private void frmCantidad_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Escape) {
        this.Close();
      }
    }

    private void udCantidad_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      if (e.KeyChar.ToString() == "-")
      {
          e.Handled = true;
          return;
      }

      this.Cantidad = (int)this.udCantidad.Value;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    #endregion

  }
}
