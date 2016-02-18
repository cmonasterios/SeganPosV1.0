using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
  public class POS : DataAccess
  {

    #region Public Methods

    public List<EPK_POS> ObtenerTodos(EPK_POS _search)
    {
      try {
        List<EPK_POS> results = context.EPK_POS.Where(p => p.IdPOS == (_search.IdPOS == 0 ? p.IdPOS : _search.IdPOS)).ToList();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public EPK_POS Obtener(int _idPos)
    {
      try {
        EPK_POS results = context.EPK_POS.First(p => p.IdPOS == _idPos);

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public List<EPK_POS> ObtenerPorEntidad(int idEntidad)
    {
      return context.EPK_POS.Where(p => p.IdEntidad == idEntidad && p.Activo && 
        p.EPK_POSTienda.Any(pt => pt.IdTienda == EstadoAplicacion.TiendaActual.IdTienda)).OrderBy(p => p.Descripcion).ToList();
    }

    public List<EPK_POS> ObtenerTodos()
    {
      List<EPK_POS> results = context.EPK_POS.OrderBy(p => p.Descripcion).ToList();
      return results;
    }

    #endregion

  }
}
