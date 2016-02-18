using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{
  public class Talla : DataAccess
  {

    #region Public Methods

    public IEnumerable<EPK_Talla> ObtenerTodos()
    {
      return this.context.EPK_Talla.ToList();
    }

    public EPK_Talla Obtener(int id)
    {
      return this.context.EPK_Talla.FirstOrDefault(t => t.IdTalla == id);
    }

    public List<EPK_Talla> ObtenerPorColeccion(int idColeccion)
    {
      return this.context.EPK_Talla.Where(t => t.EPK_Articulo.Where(a => a.EPK_Referencia.IdColeccion == idColeccion).Count() > 0).ToList();
    }

    #endregion

  }
}
