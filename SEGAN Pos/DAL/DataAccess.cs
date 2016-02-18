using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

using EntityFramework.Extensions;
using EntityFramework.Audit;

namespace SEGAN_POS.DAL
{
  public class DataAccess
  {

    #region Private Properties

    protected bool _skip { get; set; }

    protected SEGANPOSEntities context { get; set; }

    #endregion

    #region Constructor

    public DataAccess(bool skip = false)
    {
      var auditConfiguration = AuditConfiguration.Default;

      auditConfiguration.IncludeRelationships = true;
      auditConfiguration.LoadRelationships = true;
      auditConfiguration.DefaultAuditable = true;
      auditConfiguration.MaintainAcrossSaves = true;

      this._skip = skip;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal && skip) {
        this.context = new SEGANPOSEntities(ConfigurationManager.ConnectionStrings["Contingencia"].ToString());
        return;
      }

      if (EstadoAplicacion.Contingencia == EstadoContingencia.Activa) {
        this.context = new SEGANPOSEntities(ConfigurationManager.ConnectionStrings["Contingencia"].ToString());

        int vCont = new Parametros(true).ObtenerValorEntero("Contingencia");

        if (vCont == (int)EstadoContingencia.Activa)
          return;

        if (vCont == (int)EstadoContingencia.Espera || vCont == (int)EstadoContingencia.Regreso) {
          EstadoAplicacion.SetContingencia((EstadoContingencia)vCont);
          this.context = null;
          return;
        }
      }

      if (EstadoAplicacion.Contingencia == EstadoContingencia.Regreso ||
        EstadoAplicacion.Contingencia == EstadoContingencia.Espera) {
        this.context = null;
        return;
      }

      if (this.VerificarConexion("SEGANPOSEntities")) {
        this.context = new SEGANPOSEntities(ConfigurationManager.ConnectionStrings["SEGANPOSEntities"].ToString());
        return;
      }

      if (EstadoAplicacion.PermitirContingencia) {
        EstadoAplicacion.SetContingencia(EstadoContingencia.Espera);
        new Parametros(true).AsignarEntero("Contingencia", (int)EstadoContingencia.Espera);
      }

      this.context = null;
    }

    public DataAccess(string conexStringName)
    {
      this.context = new SEGANPOSEntities(ConfigurationManager.ConnectionStrings[conexStringName].ToString());
      return;
    }

    #endregion

    #region Public Methods

    public bool VerificarConexion(string conexStringName)
    {
      try {
        ConfigurationManager.RefreshSection("connectionStrings");

        SEGANPOSEntities tempContext = new SEGANPOSEntities(ConfigurationManager.ConnectionStrings[conexStringName].ToString());

        if (!tempContext.Database.Exists())
          return false;
        else
          tempContext.EPK_ParametrosSistema.Count();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public bool VerificarCadenaConexion(string conexString)
    {
      try {
        SEGANPOSEntities tempContext = new SEGANPOSEntities(conexString);

        if (!tempContext.Database.Exists())
          return false;
        else
          tempContext.EPK_ParametrosSistema.Count();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public DateTime FechaDB()
    {
      DateTime result = DateTime.Now;

      try {
        result = this.context.Database.SqlQuery<DateTime>("SELECT GETDATE()").AsEnumerable().FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public void ClearCache()
    {
      try {
        const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        var method = this.context.GetType().GetMethod("ClearCache", FLAGS);

        method.Invoke(this.context, null);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion

  }
}
