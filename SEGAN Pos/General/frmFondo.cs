using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmFondo : Form
  {

    #region Constructor

    public frmFondo()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmFondo_Load(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Maximized;
      this.BringToFront();
    }

    private void frmFondo_Shown(object sender, EventArgs e)
    {
      frmLogin fLogin = new frmLogin(true);

      fLogin.ShowDialog();

      if (fLogin.DialogResult == System.Windows.Forms.DialogResult.OK) {
        this.FormClosing -= new FormClosingEventHandler(this.frmFondo_FormClosing);
        this.DialogResult = fLogin.DialogResult;
        this.Close();
      }

      if (fLogin.DialogResult == System.Windows.Forms.DialogResult.Abort) {
        this.FormClosing -= new FormClosingEventHandler(this.frmFondo_FormClosing);
        this.DialogResult = fLogin.DialogResult;
        this.Close();
      }
    }

    private void frmFondo_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
    }

    #endregion

  }
}
