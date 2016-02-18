using System;
using System.Configuration;
using System.Windows.Forms;

using SEGAN_POS.Common;

namespace SEGAN_POS
{
  static class Program
  {

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      if (!SingleInstance.Start()) {
        SingleInstance.ShowFirstInstance();
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      try {
        string cultureName = ConfigurationManager.AppSettings["ConfigRegional"];

        if (!string.IsNullOrEmpty(cultureName)) {
          System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo(cultureName);
          Application.CurrentCulture = cultureInfo;
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        string cultureName = ConfigurationManager.AppSettings["Config"];

        if (cultureName.ToLower() == "false")
          if (new frmConfig().ShowDialog() != DialogResult.OK) {
            SingleInstance.Stop();
            return;
          }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      if (EstadoAplicacion.PermitirContingencia)
        globTimer.Start();

      do {
        Application.Run(new frmLogin());

        if (EstadoAplicacion.UsuarioActual != null)
          if (new DAL.Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmMenuPrincipal")) {
            Application.Run(new frmMenuPrincipal());
            EstadoAplicacion.SetShellMode(false);
          }
          else {
              int itemfactura = 0;
              Application.Run(new frmFacturar(itemfactura));
          }

      } while (EstadoAplicacion.ShellMode);

      if (EstadoAplicacion.PermitirContingencia)
        globTimer.Stop();

      SingleInstance.Stop();
    }

  }
}
