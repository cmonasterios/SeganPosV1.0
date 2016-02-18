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
  public partial class frmGavetaAbierta : Form
  {

    #region Private Properties

    private Impresora impresora { get; set; }

    #endregion

    #region Constructor

    public frmGavetaAbierta()
    {
      InitializeComponent();

      this.impresora = new Impresora();
    }

    #endregion

    #region Events

    private void frmGavetaAbierta_Load(object sender, EventArgs e)
    {
      int espera = Util.ObtenerParametroEntero("EsperaGaveta");

      if (espera <= 0)
        espera = 30;

      this.tmEsperaGaveta.Interval = 3000;
      this.tmEsperaGaveta.Enabled = true;

      //this.tmGaveta.Interval = espera * 1000;
      //this.tmGaveta.Enabled = true;
    }

    private void tmGaveta_Tick(object sender, EventArgs e)
    {
      this.tmEsperaGaveta.Enabled = false;

      if (!this.impresora.GavetaAbierta())
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
      else
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

      this.Close();
    }

    private void tmEsperaGaveta_Tick(object sender, EventArgs e)
    {
      if (!this.impresora.GavetaAbierta()) {
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
        return;
      }

      ((Timer)sender).Enabled = true;
    }

    private void frmGavetaAbierta_Activated(object sender, EventArgs e)
    {
      this.Text = "Gaveta Abierta - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

  }
}
