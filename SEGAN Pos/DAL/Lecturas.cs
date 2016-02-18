using System;
using System.Linq;

namespace SEGAN_POS.DAL
{

  #region Public Enums

  public enum TipoLectura
  {
    Entrada = 0, Salida, SalidaBreak, EntradaBreak
  }

  #endregion

  public class Lecturas : DataAccess
  {

    #region Constructor

    public Lecturas(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public int BuscarPorUsuarioFecha(int idUsuario, DateTime fecha)
    {
      return context.EPK_Lecturas.Where(l => l.EPK_Empleados.IdUsuario == idUsuario &&
        (l.FechaLectura.HasValue && l.FechaLectura.Value == fecha.Date)).Count();
    }

    public EPK_Lecturas UltimaSalida(int idUsuario, DateTime fecha)
    {
      EPK_Lecturas result = null;

      try {
        result = context.EPK_Lecturas.Where(l => l.EPK_Empleados.IdUsuario == idUsuario &&
          (l.FechaLectura.HasValue && l.FechaLectura.Value == fecha.Date) &&
          (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
          ).OrderByDescending(l => l.HoraLectura).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_Lecturas UltimaSalida(int idUsuario)
    {
      EPK_Lecturas result = null;

      try {
        result = context.EPK_Lecturas.Where(l => l.EPK_Empleados.IdUsuario == idUsuario &&
          (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
          (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
          ).OrderByDescending(l => l.HoraLectura).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool TieneEntrada(int idUsuario, DateTime fecha)
    {
      bool result = false;

      try {
        EPK_Lecturas ultSalida = this.UltimaSalida(idUsuario, fecha);

        TimeSpan? horaSalida = null;
        if (ultSalida != null)
          horaSalida = ultSalida.HoraLectura;

        result = context.EPK_Lecturas.Where(l => l.EPK_Empleados.IdUsuario == idUsuario &&
          (l.FechaLectura.HasValue && (l.FechaLectura.Value == fecha.Date)) &&
          (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
          (horaSalida.HasValue ? (l.HoraLectura > horaSalida) : true)).Count() > 0;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool TieneEntrada(int idUsuario)
    {
      bool result = false;

      try {
        EPK_Lecturas ultSalida = this.UltimaSalida(idUsuario);

        TimeSpan? horaSalida = null;
        if (ultSalida != null)
          horaSalida = ultSalida.HoraLectura;

        result = context.EPK_Lecturas.Where(l => l.EPK_Empleados.IdUsuario == idUsuario &&
          (l.FechaLectura.HasValue && (l.FechaLectura.Value == DateTime.Today)) &&
          (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
          (horaSalida.HasValue ? (l.HoraLectura > horaSalida) : true)).Count() > 0;
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
