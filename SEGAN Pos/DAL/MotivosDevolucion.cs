using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class MotivosDevolucion : DataAccess
  {

    #region Public Methods

    public List<EPK_MotivoDevolucion> ObtenerTodos()
    {
      return context.EPK_MotivoDevolucion.ToList();
    }

    #endregion

  }
}
