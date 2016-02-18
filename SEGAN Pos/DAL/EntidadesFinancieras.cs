using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class EntidadesFinancieras : DataAccess
  {

    #region Public Methods

    public List<EPK_EntidadFinanciera> ObtenerActivas()
    {
      try {
        return context.EPK_EntidadFinanciera.Where(ef => ef.Activa).OrderBy(ef => ef.Nombre).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_EntidadFinanciera>();
    }

    public List<EPK_EntidadFinanciera> ObtenerActivasPOS()
    {
      try {
        return context.EPK_EntidadFinanciera.Where(
          ef => ef.Activa && ef.EPK_POS.Any(p => p.Activo && p.EPK_POSTienda.Any(pt => pt.IdTienda == EstadoAplicacion.TiendaActual.IdTienda))).
          OrderBy(ef => ef.Nombre).FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_EntidadFinanciera>();
    }

    public List<EPK_EntidadFinanciera> ObtenerTodos()
    {
      return context.EPK_EntidadFinanciera.OrderBy(b => b.Nombre).ToList();
    }

    public EPK_EntidadFinanciera Obtener(int idEntidad)
    {
      return context.EPK_EntidadFinanciera.Where(e => e.IdEntidad == idEntidad).First();
    }

    #endregion

  }
}
