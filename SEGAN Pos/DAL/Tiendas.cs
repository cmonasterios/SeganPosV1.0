using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
  public class Tiendas : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Tienda> ObtenerTodas()
    {
      return this.context.EPK_Tienda.ToList();
    }

    public EPK_Tienda ObtenerPrimera()
    {
      return this.context.EPK_Tienda.FirstOrDefault();
    }

    #endregion

  }
}
