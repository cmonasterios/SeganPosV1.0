using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{

  #region Public Enums

  public enum TipoParametro
  {
    Cadena = 1, Decimal, Entero
  }

  #endregion

  public class Parametros : DataAccess
  {

    #region Constructor

    public Parametros(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public IEnumerable<EPK_ParametrosSistema> ObtenerTodos()
    {
      try {
        return context.EPK_ParametrosSistema.Where(p=>p.IdTipoTienda==EstadoAplicacion.TiendaActual.IdTipoTienda).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public EPK_ParametrosSistema Obtener(string Codigo)
    {
      try {
          return context.EPK_ParametrosSistema.Where(ps => ps.CodParametro == Codigo && ps.IdTipoTienda == EstadoAplicacion.TiendaActual.IdTipoTienda 
                                                           && ps.FechaInicio <= DateTime.Now && (!ps.FechaFin.HasValue || ps.FechaFin.Value >= DateTime.Now)).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public EPK_ParametrosSistema Obtener(string Codigo, DateTime fecha)
    {
      try {
          return context.EPK_ParametrosSistema.Where(ps => ps.CodParametro == Codigo && ps.IdTipoTienda == EstadoAplicacion.TiendaActual.IdTipoTienda 
                                                           && ps.FechaInicio <= fecha.Date && (!ps.FechaFin.HasValue || ps.FechaFin.Value >= fecha.Date)).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public bool AsignarEntero(string Codigo, int valor)
    {
      try {
        EPK_ParametrosSistema pEntero = this.Obtener(Codigo);

        if (pEntero == null)
          return false;

        if (pEntero.TipoParametro != (int)TipoParametro.Entero)
          return false;

        pEntero.ValorEntero = valor;

        this.context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public int ObtenerValorEntero(string Codigo)
    {
      int result = -1;

      try {
        EPK_ParametrosSistema pEntero = this.Obtener(Codigo);

        if (pEntero == null)
          return result;

        if (pEntero.TipoParametro != (int)TipoParametro.Entero)
          return result;

        if (!pEntero.ValorEntero.HasValue)
          return result;

        result = pEntero.ValorEntero.Value;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public Dictionary<string, short> Obtener(string[] nombresParams)
    {
      Dictionary<string, short> results = new Dictionary<string, short>();

      try {
        results = this.context.EPK_ParametrosSistema.Where(p => nombresParams.Contains(p.CodParametro)).
                    Select(p => new { Cod = p.CodParametro, Valor = (short)p.ValorEntero }).ToDictionary(v => v.Cod, v => v.Valor);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    #endregion

  }
}
