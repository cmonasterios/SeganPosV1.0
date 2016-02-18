using SEGAN_POS.DAL;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmRepZ : Form
  {
    #region Public Properties

    public bool MultiplesZ { get; set; }
    public bool SkipAuth { get; set; }

    public bool Confirm { get; set; }

    #endregion Public Properties

    #region Constructor

    public frmRepZ()
    {
      InitializeComponent();
    }

    public frmRepZ(bool multiplesZ, bool confim = true, bool skipAuth = false)
    {
      this.MultiplesZ = multiplesZ;
      this.SkipAuth = skipAuth;
      this.Confirm = confim;

      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btContinuar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmRepZ_Activated(object sender, EventArgs e)
    {
      this.Text = "Emitiendo Reporte Z - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmRepZ_Shown(object sender, EventArgs e)
    {
      this.lbMensajes.Items.Add("Verificando estado de la impresora");

      if (!Util.VerificarImpresora("frmFacturar")) {
        this.Close();
        return;
      }

      this.Refresh();
      try {
        Impresora impresora = new Impresora();

        int impLinea = impresora.EnLinea();
        if (impLinea != 0) {
          new NLogLogger().Error(Properties.Resources.MsgErrorComImp + "(" + impLinea.ToString() +")");
          MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error - SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
          return;
        }

        this.Refresh();

        this.lbMensajes.Items.Add("Verificando el último Reporte Z");

        string datosUltRed = impresora.DatosUltimaReduccion();

        this.Refresh();

        if (datosUltRed != string.Empty)
          if (datosUltRed.Substring(0, 2) == "01" ) // Reporte automatico
            if (!impresora.CierreReporteZAutomatico()) {
              new NLogLogger().Error(Properties.Resources.MsgErrorComImp +"(Reporte Z Automático)");
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error - SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
              this.Close();
              return;
            }

        this.Refresh();

        string Fecha = string.Empty, Hora = string.Empty;

        // Obtener la fecha del ultimo reporte Z
        if (!impresora.FechaHoraReducion(ref Fecha, ref Hora)) {
            new NLogLogger().Error(Properties.Resources.MsgErrorComImp + "(Error obteniendo Fecha del último Z)");
          MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error - SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
          return;
        }

        this.Refresh();

        DateTime currDate = new DataAccess(true).FechaDB();

        this.Refresh();

        if (currDate.ToString("ddMMyy") == Fecha) {
          // Ya existe un reporte Z para el día actual.
          if (!this.MultiplesZ) {
            this.Close();
            return;
          }

          if (this.Confirm)
            if (MessageBox.Show(Properties.Resources.MsgReporteZDelDía, "SEGAN POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) {
              this.Close();
              return;
            }
        }

        this.Refresh();

        if (string.IsNullOrEmpty(impresora.Serial)) {
            new NLogLogger().Error(Properties.Resources.MsgErrorComImp + "(Error obteniendo Serial MF)");
          MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error - SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
          return;
        }

        this.Refresh();

        this.lbMensajes.Items.Add("Generando Reporte Z");

        while (!impresora.ReporteZ())
        {
            if (MessageBox.Show(Properties.Resources.MsgImpNoResp, "Error de Impresora", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {

                int idAut = 0;

                if (this.SkipAuth)
                {
                    idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
                }
                else
                {
                    if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Abortar_Cierre"))
                    {
                        frmAutorizar fAut = new frmAutorizar();
                        fAut.Mensaje = Properties.Resources.MsgAbortarCierre;
                        fAut.NombreTecnico = this.Name;
                        fAut.Accion = "Abortar_Cierre";
                        fAut.Obligatoria = true;
                        fAut.ShowDialog();

                        if (fAut.UsuarioAutorizador != null)
                            idAut = fAut.UsuarioAutorizador.IdUsuario;
                    }
                    else
                    {
                        idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
                    }
                }

                if (idAut > 0)
                {
                    EPK_Usuario usuarioAut = new Usuarios().Obtener(idAut);

                    if (usuarioAut != null)
                    {
                        new NLogLogger().Info(string.Format(Properties.Resources.LogAbortarCierre, usuarioAut.Identificacion, usuarioAut.Login));
                        this.Close();
                        return;
                    }
                }

            }
        }

        this.Refresh();

        Thread.Sleep(5000);

        this.Refresh();

        impresora.Refrescar();

        while (string.IsNullOrEmpty(impresora.Serial)) {
          if (MessageBox.Show(Properties.Resources.MsgImpNoResp, "Error de Impresora", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) {

            int idAut = 0;

            if (this.SkipAuth) {
              idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
            }
            else {
              if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Abortar_Cierre")) {
                frmAutorizar fAut = new frmAutorizar();
                fAut.Mensaje = Properties.Resources.MsgAbortarCierre;
                fAut.NombreTecnico = this.Name;
                fAut.Accion = "Abortar_Cierre";
                fAut.Obligatoria = true;
                fAut.ShowDialog();

                if (fAut.UsuarioAutorizador != null)
                  idAut = fAut.UsuarioAutorizador.IdUsuario;
              }
              else {
                idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
              }
            }

            if (idAut > 0) {
              EPK_Usuario usuarioAut = new Usuarios().Obtener(idAut);

              if (usuarioAut != null) {
                new NLogLogger().Info(string.Format(Properties.Resources.LogAbortarCierre, usuarioAut.Identificacion, usuarioAut.Login));
                this.Close();
                return;
              }
            }

          }

          impresora.Refrescar();
        }

        this.Refresh();

        Thread.Sleep(2000);

        this.Refresh();

        this.lbMensajes.Items.Add("Generando Cierre de Máquina Fiscal");

        while (!impresora.CierreReporteZ()) {
          if (MessageBox.Show(Properties.Resources.MsgImpNoResp, "Error de Impresora", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) {

            int idAut = 0;

            if (this.SkipAuth) {
              idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
            }
            else {
              if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Abortar_Cierre")) {
                frmAutorizar fAut = new frmAutorizar();
                fAut.Mensaje = Properties.Resources.MsgAbortarCierre;
                fAut.NombreTecnico = this.Name;
                fAut.Accion = "Abortar_Cierre";
                fAut.Obligatoria = true;
                fAut.ShowDialog();

                if (fAut.UsuarioAutorizador != null)
                  idAut = fAut.UsuarioAutorizador.IdUsuario;
              }
              else {
                idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
              }
            }

            if (idAut > 0) {
              EPK_Usuario usuarioAut = new Usuarios().Obtener(idAut);

              if (usuarioAut != null) {
                new NLogLogger().Info(string.Format(Properties.Resources.LogAbortarCierre, usuarioAut.Identificacion, usuarioAut.Login));
                this.Close();
                return;
              }
            }

          }
        }

        this.Refresh();

        this.lbWarning.Visible = this.pbWarning.Visible = false;
        this.lbOK.Visible = this.pbOK.Visible = true;

        this.lbMensajes.Items.Add(Properties.Resources.MsgSucessZ);
        this.btContinuar.Enabled = true;
        this.UseWaitCursor = false;

        Util.ClearMessages(true);
      }
      catch (Exception ex) {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

      }
    }

    #endregion Events
  }
}