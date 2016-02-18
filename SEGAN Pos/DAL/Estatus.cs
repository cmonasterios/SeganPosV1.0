using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class Estatus : DataAccess
  {

    #region Constructor

    public Estatus(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public List<EPK_Estatus> ObtenerTodos()
    {
      try {
        return context.EPK_Estatus.ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return null;
    }

    public EPK_Estatus Obtener(int id)
    {
      return context.EPK_Estatus.FirstOrDefault(e => e.IdEstatus == id);
    }

    #endregion

  }
}
