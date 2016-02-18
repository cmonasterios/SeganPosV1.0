using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class Temas : DataAccess
  {

    #region Public Methods

      public IEnumerable<EPK_Tema> ObtenerTodos()
    {
      try
        {
            IEnumerable<EPK_Tema> results = context.EPK_Tema.OrderBy(t => t.CodigoTema).
            FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

          foreach (EPK_Tema item in results)
              item.CodigoTema = item.CodigoTema.Trim();

          return results;
        }
          catch (Exception ex) {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return new List<EPK_Tema>();
    }

    #endregion

  }
}

