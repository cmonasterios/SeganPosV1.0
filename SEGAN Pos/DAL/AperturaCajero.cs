using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
  public class AperturaCajero : DataAccess
  {

    #region Constructor

    public AperturaCajero(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public List<EPK_AperturaCajeroEncabezado> ObtenerTodos()
    {
      try {
        return context.EPK_AperturaCajeroEncabezado.ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public List<EPK_AperturaCajeroEncabezado> ObtenerTodos(DateTime fechaDesde, DateTime fechaHasta)
    {
      try {
        return context.EPK_AperturaCajeroEncabezado.Where(p => p.Fecha >= fechaDesde && p.Fecha <= fechaHasta).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public decimal Total(DateTime fechaIni, DateTime fechaFin)
    {
      decimal result = 0;

      try {
        result = context.EPK_AperturaCajeroDenominacion.Where(a => a.EPK_AperturaCajeroEncabezado.Fecha >= fechaIni &&
          a.EPK_AperturaCajeroEncabezado.Fecha <= fechaFin).Sum(a => a.Cantidad * a.EPK_Denominacion.Denominacion);

        result = context.EPK_AperturaCajeroEncabezado.Where(p => p.Fecha >= fechaIni && p.Fecha <= fechaFin).
          Sum(l => l.EPK_AperturaCajeroDenominacion.Sum(d => d.Cantidad * d.EPK_Denominacion.Denominacion));
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        result = 0;
      }

      return result;
    }

    public EPK_AperturaCajeroEncabezado Obtener(long idApertura)
    {
      return context.EPK_AperturaCajeroEncabezado.FirstOrDefault(p => p.IdApertura == idApertura);
    }

    public long Nuevo(EPK_AperturaCajeroEncabezado apertura)
    {
      long result = 0;

      try {
        DateTime currDate = this.FechaDB();

        DateTime fecha = currDate;

        apertura.Fecha = fecha.Date;
        apertura.Hora = fecha.TimeOfDay;
        context.EPK_AperturaCajeroEncabezado.Add(apertura);
        context.SaveChanges();

        if (EstadoAplicacion.PermitirContingencia && apertura.IdApertura > 0)
          Util.SetAppSettingsValue("UltimaApertura", apertura.IdApertura.ToString(), false);

        result = apertura.IdApertura;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool Actualizar(EPK_AperturaCajeroEncabezado apertura)
    {
      try {
        EPK_AperturaCajeroEncabezado aperturaActual = Obtener(apertura.IdApertura);

        aperturaActual.IdCierre = apertura.IdCierre;

        foreach (EPK_AperturaCajeroDenominacion item in apertura.EPK_AperturaCajeroDenominacion)
          aperturaActual.EPK_AperturaCajeroDenominacion.FirstOrDefault(p => p.IdDenominacion == item.IdDenominacion).Cantidad = item.Cantidad;

        context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public EPK_AperturaCajeroEncabezado ObtenerActiva(int idUsuario)
    {
      try {
        return context.EPK_AperturaCajeroEncabezado.FirstOrDefault(p => p.IdCajero == idUsuario &&
          p.IdCierre == null && p.Fecha == DateTime.Today);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public EPK_AperturaCajeroEncabezado ObtenerActiva(int idUsuario, DateTime? fechaIni)
    {
      try {
        DateTime fIni = DateTime.MinValue.Date;

        if (fechaIni.HasValue)
          fIni = fechaIni.Value.Date;

        return context.EPK_AperturaCajeroEncabezado.FirstOrDefault(p => p.IdCajero == idUsuario && p.IdCierre == null &&
          (fechaIni.HasValue ? (p.Fecha == fIni) : true));
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public int ObtenerActivas(DateTime fecha)
    {
      try {
        return context.EPK_AperturaCajeroEncabezado.Where(p => p.IdCierre == null && p.Fecha == fecha.Date).Count();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return 0;
      }
    }

    public int ObtenerActivas()
    {
      try {
        return context.EPK_AperturaCajeroEncabezado.Where(p => p.IdCierre == null).Count();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return 0;
      }
    }

    public long ObtenerUltimoId()
    {
      try {
        return this.context.EPK_AperturaCajeroEncabezado.Max(a => a.IdApertura);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 0;
    }

    public long ObtenerUltimoId(int idCaja)
    {
      try {
        return this.context.EPK_AperturaCajeroEncabezado.Where(a => a.IdCaja == idCaja).Max(a => a.IdApertura);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 0;
    }

    public bool ReSeed(long id)
    {
      if (id <= 0)
        return false;

      try {
        this.context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})",
          "EPK_AperturaCajeroEncabezado", id.ToString()));

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    #endregion

  }
}
