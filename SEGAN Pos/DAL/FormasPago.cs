using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.Caching;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class FormasPago : DataAccess
  {

    #region Public Methods

    public EPK_FormaPago Obtener(int idFormaPago)
    {
      EPK_FormaPago result = context.EPK_FormaPago.FirstOrDefault(a => a.IdFormaPago == idFormaPago);

      if (result != null) {
        result.IdFormaPago = result.IdFormaPago;
        result.Descripcion = result.Descripcion.Trim();
        result.Codigo_Pago = result.Codigo_Pago;
        result.Activa = result.Activa;
      }

      return result;
    }

    public EPK_FormaPago Obtener(string Codigo)
    {
      EPK_FormaPago result = context.EPK_FormaPago.FirstOrDefault(a => a.Codigo_Pago == Codigo);

      if (result != null) {
        result.IdFormaPago = result.IdFormaPago;
        result.Descripcion = result.Descripcion.Trim();
        result.Codigo_Pago = result.Codigo_Pago;
        result.Activa = result.Activa;
      }

      return result;
    }

    public IEnumerable<EPK_FormaPago> BuscarTodos()
    {
      IEnumerable<EPK_FormaPago> results = context.EPK_FormaPago.ToList();

      foreach (EPK_FormaPago item in results) {
        item.Descripcion = item.Descripcion.Trim();
        item.Codigo_Pago = item.Codigo_Pago.Trim();
      }

      return results;
    }

    public List<EPK_FormaPago> ObtenerActivas(int idTipoTienda, int idCliente)
    {
      try {
        return context.EPK_FormaPago.Where(fp => fp.Activa && (!fp.Restringida ||
          (fp.Restringida && fp.EPK_ClienteFormaPago.Count(cf => cf.IdCliente == idCliente) > 0)) &&
          fp.EPK_TipoTiendaFormaPago.Where(tf => tf.IdTipoTienda == idTipoTienda && tf.Activa).Count() > 0
          ).OrderBy(fp => fp.Descripcion).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_FormaPago>();
    }

    public List<EPK_FormaPago> ObtenerTodas()
    {
      return context.EPK_FormaPago.OrderBy(fp => fp.Descripcion).ToList();
    }

    #endregion

  }
}
