using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class Generos : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Genero> ObtenerTodos()
    {
      try {
        IEnumerable<EPK_Genero> results = context.EPK_Genero.OrderBy(g => g.Descripcion).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

        foreach (EPK_Genero item in results)
          item.Descripcion = item.Descripcion.Trim();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_Genero>();
    }

    #endregion

  }
}
