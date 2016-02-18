using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
  public class MotivosDescuento : DataAccess
  {

    #region Public Methods
    public List<EPK_MotivoDescuento> ObtenerTodos()
    {
      try {

        List<EPK_MotivoDescuento> results = context.EPK_MotivoDescuento.ToList();
        return results;

      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public EPK_MotivoDescuento Obtener(EPK_MotivoDescuento _search)
    {
      try {

        EPK_MotivoDescuento results = context.EPK_MotivoDescuento.First(m => m.IdMotivoDesc == _search.IdMotivoDesc);
        return results;

      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }
    #endregion

  }
}
