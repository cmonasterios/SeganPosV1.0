using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using UserInactivityMonitoring;

namespace SEGAN_POS
{
  public partial class frmMenuPrincipal : Form
  {
    #region Private Variables

    private IInactivityMonitor inactivityMonitor = null;

    #endregion Private Variables

    #region Constructor

    public frmMenuPrincipal()
    {
      InitializeComponent();

      int timeOut = Util.ObtenerParametroEntero("TIMEOUTSESION");
      if (timeOut == 0)
        timeOut = 300;

      inactivityMonitor = MonitorCreator.CreateInstance(MonitorType.LastInputMonitor);
      inactivityMonitor.SynchronizingObject = this;
      inactivityMonitor.MonitorKeyboardEvents = true;
      inactivityMonitor.MonitorMouseEvents = true;
      inactivityMonitor.Interval = timeOut * 1000;
      inactivityMonitor.Elapsed += new ElapsedEventHandler(TimeoutSesion);
    }

    #endregion Constructor

    #region Events

    private void btBloquear_Click(object sender, EventArgs e)
    {
      EstadoAplicacion.SetSessionLocked(true);
      this.inactivityMonitor.Enabled = false;

      if (new frmFondo().ShowDialog() == System.Windows.Forms.DialogResult.Abort) {
        List<Form> closeForms = new List<Form>();

        foreach (Form f in Application.OpenForms)
          if (!f.Equals(this))
            closeForms.Add(f);

        foreach (Form f in closeForms)
          f.Dispose();

        if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
          new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
          EstadoAplicacion.SetUsuarioActual(null);
        }

        this.Close();
        return;
      }

      this.inactivityMonitor.Enabled = true;
      EstadoAplicacion.SetSessionLocked(false);
    }

    private void btnConsultaFactura_Click(object sender, EventArgs e)
    {
      new frmConsFacturas().ShowDialog();
    }

    private void btnFacturacion_Click(object sender, EventArgs e)
    {
      this.inactivityMonitor.Enabled = false;
      int itemfactura = 0;
      frmFacturar fFact = new frmFacturar(itemfactura);
      fFact.ShowInTaskbar = false;
      fFact.ShowDialog();

      this.inactivityMonitor.Enabled = true;
    }

    private void btnManejoEfectivo_Click(object sender, EventArgs e)
    {
       
      new frmMenuEfec().ShowDialog();
    }

    private void btnReportes_Click(object sender, EventArgs e)
    {
        
        new frmMenuRep().ShowDialog();
      
       
    }
    private void frmMenuPrincipal_Activated(object sender, EventArgs e)
    {
      this.Text = "Menú Principal - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (this.inactivityMonitor != null) {
        this.inactivityMonitor.Enabled = false;
        this.inactivityMonitor = null;
      }

      new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
      EstadoAplicacion.SetUsuarioActual(null);
    }

    private void frmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Shift || e.Alt || e.Control)
        return;

      switch (e.KeyCode) {
        case Keys.F2:
          this.btnFacturacion_Click(this, EventArgs.Empty);
          break;

        case Keys.F3:
          this.btnManejoEfectivo_Click(this, EventArgs.Empty);
          break;

        case Keys.F4:
          this.btnReportes_Click(this, EventArgs.Empty);
          break;

        case Keys.F5:
          this.btnConsultaFactura_Click(this, EventArgs.Empty);
          break;

        case Keys.F6:
          this.btBloquear_Click(this, EventArgs.Empty);
          break;

        case Keys.F7:
          new frmBuscarArt(noAgregar: true).ShowDialog();
          break;

        case Keys.F8:
          if (EstadoAplicacion.Contingencia == EstadoContingencia.Activa)
            new frmFinContingencia().ShowDialog();
          break;

        case Keys.F9:
          new frmUsuariosBloq().ShowDialog();
          break;

        case Keys.F10:
          new frmVentasDia().ShowDialog();
          break;

        case Keys.F11:
          new frmCambioClave().ShowDialog();
          break;

        case Keys.F12:
          new frmMenuMF().ShowDialog();
          break;
      }
    }

    private void frmMenuPrincipal_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.ulVersion.Text = Application.ProductName + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

      foreach (Control controlItem in this.Controls) {
        if (controlItem.GetType() != typeof(Button))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

      this.AgregarToolTips();
    }
    private void frmMenuPrincipal_Shown(object sender, EventArgs e)
    {
      Util.IniciarVisor();

      this.pnBotones.Left = (this.Width - this.pnBotones.Width) / 2;
      this.pnBotones.Top = (this.Height - this.pnBotones.Height) / 2;

      this.btnFacturacion.Focus();
      this.inactivityMonitor.Enabled = true;
    }

    private void TimeoutSesion(object sender, ElapsedEventArgs e)
    {
      try {
        if (EstadoAplicacion.SessionLocked)
          return;

        ((IInactivityMonitor)sender).Enabled = false;
        EstadoAplicacion.SetSessionLocked(true);

        if (new frmFondo().ShowDialog() == System.Windows.Forms.DialogResult.Abort) {
          List<Form> closeForms = new List<Form>();
          foreach (Form f in Application.OpenForms)
            if (!f.Equals(this))
              closeForms.Add(f);
          foreach (Form f in closeForms)
            f.Dispose();

          if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
            new Usuarios().Logout(EstadoAplicacion.UsuarioActual.IdUsuario);
            EstadoAplicacion.SetUsuarioActual(null);
          }

          this.Close();
          return;
        }

        EstadoAplicacion.SetSessionLocked(false);
        ((IInactivityMonitor)sender).Enabled = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }
    #endregion Events

    #region Private Methods

    private void AgregarToolTips()
    {
      ToolTip mainToolTip = new ToolTip();

      // Se asignan los tiempos.
      mainToolTip.AutoPopDelay = 5000;
      mainToolTip.InitialDelay = 1000;
      mainToolTip.ReshowDelay = 500;

      // Se muestra el tooltip siempre, aunque la forma no esté activa.
      mainToolTip.ShowAlways = true;

      // Se colocan los tooltips a los controles.
      mainToolTip.SetToolTip(this.btBloquear, Properties.Resources.TipBloquear);
      mainToolTip.SetToolTip(this.btnFacturacion, "F2");
    }

    #endregion Private Methods
  }
}