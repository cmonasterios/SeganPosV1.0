using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class Grupos : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Grupo> ObtenerTodos()
    {
      try {
        IEnumerable<EPK_Grupo> results = context.EPK_Grupo.OrderBy(g => g.Descripcion).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

        foreach (EPK_Grupo item in results)
          item.Descripcion = item.Descripcion.Trim();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_Grupo>();
    }

    #endregion

  }
}
