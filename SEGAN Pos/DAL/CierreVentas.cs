using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{
  #region Data Types

  public class ItemCierre
  {
    public DateTime Fecha { get; set; }

    public DateTime FechaCreacion { get; set; }

    public TimeSpan Hora { get; set; }

    public int IdCierreV { get; set; }
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; }
    public decimal? TotalEfectivo { get; set; }

    public decimal TotalGeneral { get; set; }

    public decimal? TotalOtrosPagos { get; set; }
    public decimal? TotalOtrosPagospag { get; set; }
    public decimal? TotalOtrosPagospos { get; set; }
  }

  #endregion Data Types

  public class CierreVentas : DataAccess
  {
    #region Constructor

    public CierreVentas(bool skip = false)
      : base(skip)
    {
    }

    #endregion Constructor

    #region Public Methods

    public List<ItemCierre> Buscar(DateTime fechaIni, DateTime fechaFin, int? idUsuario)
    {
      List<ItemCierre> results = null;

      try {
        int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");

        results = context.EPK_CierreVentaEncabezado.Where(cv => cv.Fecha >= fechaIni.Date && cv.Fecha <= fechaFin.Date &&
          (idUsuario.HasValue ? cv.IdUsuario == idUsuario.Value : true)).OrderByDescending(cv => cv.Fecha).
          Select(cv => new ItemCierre {
            IdCierreV = cv.IdCierreV,
            Fecha = cv.Fecha,
            Hora = cv.Hora,
            IdUsuario = cv.IdUsuario,
            NombreUsuario = cv.EPK_Usuario.Identificacion,
            FechaCreacion = cv.FechaCreacion,
            TotalEfectivo = cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago == idEfectivo).Sum(cp => cp.MontoCierre),
            //TotalOtrosPagos = cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago == idEfectivo).Sum(cp => cp.MontoCierre) + cv.EPK_CierreVentaPOS.Sum(cp => cp.MontoCierre),
            //TotalOtrosPagospag = cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago != idEfectivo).Sum(cp => cp.MontoPagos),
            //TotalOtrosPagospos = cv.EPK_CierreVentaPOS.Sum(cp => cp.TotalDia),
            // + cv.EPK_CierreVentaPOS.Sum(cp => cp.MontoCierre),
            ///TotalOtrosPagos = (cv.EPK_CierreVentaPOS.Sum(cp => cp.TotalDia)).ToString().Union(cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago != idEfectivo).Sum(cp => cp.MontoCierre)).ToString(),
            //TotalOtrosPagos = (cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago != idEfectivo).Sum(cp => (cp.MontoPagos.ToString().Equals(null) ? 0 : cp.MontoPagos))) + ((cv.EPK_CierreVentaPOS.Sum(cp => cp.TotalDia.ToString().Equals(null) ? 0 : cp.TotalDia))),
            TotalOtrosPagospag = cv.EPK_CierreVentaPagos.Where(cp => cp.IdFormaPago != idEfectivo).Sum(cp => cp.MontoPagos),
            TotalOtrosPagospos = cv.EPK_CierreVentaPOS.Sum(cpos => cpos.TotalDia),
            TotalOtrosPagos = 0,
            TotalGeneral = 0
          }).ToList();


        foreach (ItemCierre item in results) {
          if (!item.TotalEfectivo.HasValue)
            item.TotalEfectivo = 0;

          //if (!item.TotalOtrosPagos.HasValue)
          //  item.TotalOtrosPagos = 0;

          if (!item.TotalOtrosPagospag.HasValue)
              item.TotalOtrosPagospag = 0;

          if (!item.TotalOtrosPagospos.HasValue)
              item.TotalOtrosPagospos = 0;

          item.TotalOtrosPagos = item.TotalOtrosPagospag + item.TotalOtrosPagospos;
          item.TotalGeneral = item.TotalEfectivo.Value + item.TotalOtrosPagos.Value;
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        results = new List<ItemCierre>();
      }

      return results;
    }

    public decimal MontoCierres(int idUsuario, DateTime fechaIni, DateTime fechaFin, int idFormaPago)
    {
      decimal result = 0;

      try {
        return context.EPK_CierreCajeroPagos.Where(ccp => ccp.EPK_CierreCajeroEncabezado.IdCajero == idUsuario &&
          ccp.EPK_CierreCajeroEncabezado.Fecha >= fechaIni && ccp.EPK_CierreCajeroEncabezado.Fecha <= fechaFin &&
          ccp.IdFormaPago == idFormaPago).Sum(ccp => ccp.MontoCierre);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public int Nuevo(EPK_CierreVentaEncabezado cierre)
    {
      int result = 0;

      try {
        DateTime currDate = this.FechaDB();

        cierre.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (cierre.EPK_CierreVentaPOS.FirstOrDefault() != null)
          foreach (EPK_CierreVentaPOS item in cierre.EPK_CierreVentaPOS)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (cierre.EPK_CierreVentaPagos.FirstOrDefault() != null)
          foreach (EPK_CierreVentaPagos item in cierre.EPK_CierreVentaPagos)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        cierre.Hora = currDate.TimeOfDay;
        cierre.FechaCreacion = currDate;
        context.EPK_CierreVentaEncabezado.Add(cierre);
        context.SaveChanges();

        if (EstadoAplicacion.PermitirContingencia && cierre.IdCierreV > 0)
          Util.SetAppSettingsValue("UltimoCierreVentas", cierre.IdCierreV.ToString(), false);

        result = cierre.IdCierreV;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_CierreVentaEncabezado Obtener()
    {
      try {
        return context.EPK_CierreVentaEncabezado.FirstOrDefault(cv => cv.Fecha == DateTime.Today);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public EPK_CierreVentaEncabezado Obtener(DateTime fecha)
    {
      try {
        return context.EPK_CierreVentaEncabezado.FirstOrDefault(cv => cv.Fecha == fecha.Date);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public EPK_CierreVentaEncabezado Obtener(int idCierreV)
    {
      try {
        return context.EPK_CierreVentaEncabezado.FirstOrDefault(cv => cv.IdCierreV == idCierreV);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public string ObtenerObservacion(DateTime fecha)
    {
      try {
        return context.EPK_CierreVentaEncabezado.FirstOrDefault(cv => cv.Fecha == fecha.Date).Observaciones.ToString();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public int ObtenerUltimoId()
    {
      try {
        return this.context.EPK_CierreVentaEncabezado.Max(c => c.IdCierreV);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 0;
    }

    public bool ReSeed(int id)
    {
      if (id <= 0)
        return false;

      try {
        this.context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})",
          "EPK_CierreVentaEncabezado", id.ToString()));

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    #endregion Public Methods
  }
}