using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class Colecciones : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Coleccion> ObtenerTodas()
    {
        return context.EPK_Coleccion.OrderBy(g => g.Descripcion).ToList();
    }

    public IEnumerable<EPK_Coleccion> ObtenerActivas()
    {
      try {
        IEnumerable<EPK_Coleccion> results = context.EPK_Coleccion.Where(c => c.Activo).OrderByDescending(c => c.IdColeccion).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

        foreach (EPK_Coleccion item in results)
          item.Descripcion = item.Descripcion.Trim();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_Coleccion>();
    }

    #endregion

  }
}
