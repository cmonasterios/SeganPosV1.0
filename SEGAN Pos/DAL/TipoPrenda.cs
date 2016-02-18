using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class TipoPrenda : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_TipoPrenda> ObtenerTodos()
    {
        return context.EPK_TipoPrenda.OrderBy(g => g.Descripcion).ToList();
    }


    #endregion

  }
}
