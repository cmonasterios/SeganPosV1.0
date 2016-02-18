using System.Linq;

namespace SEGAN_POS.DAL
{
  public class Terminales : DataAccess
  {

    #region Constructor

    public Terminales(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public bool HayActivas()
    {
      return context.EPK_Terminal.Where(t => t.Activo.Value).Count() > 0;
    }

    public EPK_Terminal GetByTienda()
    {
        int? IdRegion = context.EPK_Region.Where(p => p.IdTienda == EstadoAplicacion.TiendaActual.IdTienda).FirstOrDefault().IdTienda;

        if (IdRegion == null)
            return new EPK_Terminal();
        else
            return context.EPK_Terminal.Where(p => p.IdRegion == IdRegion).FirstOrDefault();
    }

    #endregion

  }
}
