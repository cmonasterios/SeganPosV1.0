using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class Colores : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Color> ObtenerTodos()
    {
        return context.EPK_Color.OrderBy(g => g.Descripcion).ToList();
    }

    #endregion

  }
}
