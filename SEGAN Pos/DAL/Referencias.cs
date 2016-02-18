using EntityFramework.Caching;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{
  public class Referencias : DataAccess
  {
    #region Public Methods

    public IEnumerable<EPK_Referencia> Buscar(int idColeccion, int idGenero, int idGrupo)
    {
      try {
        IEnumerable<EPK_Referencia> results = context.EPK_Referencia.Where(r => r.IdColeccion == idColeccion &&
          r.IdGenero == idGenero && r.IdGrupo == idGrupo && r.Activo).OrderBy(r => r.CodigoReferencia).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

        foreach (EPK_Referencia item in results)
          item.CodigoReferencia = item.CodigoReferencia.Trim();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_Referencia>();
    }

    public EPK_Referencia Obtener(int id)
    {
      return context.EPK_Referencia.FirstOrDefault(r => r.IdReferencia == id);
    }

    public IEnumerable<EPK_Referencia> ObtenerTodas()
    {
      IEnumerable<EPK_Referencia> results = context.EPK_Referencia.ToList();

      foreach (EPK_Referencia item in results)
        item.CodigoReferencia = item.CodigoReferencia.Trim();

      return results;
    }
    #endregion Public Methods
  }
}