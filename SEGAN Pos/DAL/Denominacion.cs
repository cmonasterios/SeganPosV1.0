using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
  public class Denominacion : DataAccess
  {

    #region Public Methods

    public List<EPK_Denominacion> ObtenerTodas()
    {
      return context.EPK_Denominacion.ToList().OrderByDescending(p => p.Denominacion).ToList();
    }

    public EPK_Denominacion Buscar(byte idDenominacion)
    {
      return context.EPK_Denominacion.First(p => p.IdDenominacion == idDenominacion);
    }

    public decimal ObtenerMax()
    {
      decimal result = 0;

      try {
        result = context.EPK_Denominacion.Max(d => d.Denominacion);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public decimal ObtenerMin()
    {
      decimal result = 0;

      try {
        result = context.EPK_Denominacion.Min(d => d.Denominacion);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    #endregion

  }
}
