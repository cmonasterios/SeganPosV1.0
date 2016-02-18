using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEGAN_POS.Reportes
{
  public partial class frmResDiaVtasObs : Form
  {
    public string observaciones { get; set; }

    #region Constructor

    public frmResDiaVtasObs()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void Form1_Load(object sender, EventArgs e)
    {
      this.Text = this.Text + " - " + Application.ProductName;

      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.observaciones = this.txtObservaciones.Text;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    #endregion

    #region Methods

    #endregion

  }
}
