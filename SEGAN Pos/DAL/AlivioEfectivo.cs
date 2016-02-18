using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class AlivioAprobacion
  {
    public DateTime FechaAlivio { get; set; }
    public TimeSpan HoraAlivio { get; set; }
    public long IdAlivio { get; set; }
    public int IdCaja { get; set; }
    public string Caja { get; set; }
    public string Cajero { get; set; }
  }

  public class AlivioAutorizacion
  {

    public byte IdDenominacion { get; set; }
    public byte[] Logo { get; set; }
    public string Denominacion { get; set; }
    public int CantidadCajero { get; set; }
    public decimal MontoCajero { get; set; }
    public int CantidadAprobada { get; set; }
    public decimal MontoAprobado { get; set; }
    public decimal Diferencia { get; set; }

  }

  public class AlivioConsulta
  {

    public long Id { get; set; }
    public byte[] Semaforo { get; set; }
    public string Caja { get; set; }
    public string Cajero { get; set; }
    public int CantidadAlivios { get; set; }
    public decimal MontoConsolidado { get; set; }
    public decimal MontoAprobado { get; set; }
    public DateTime FechaVenta { get; set; }
    public DateTime FechaAlivio { get; set; }
    public Nullable<DateTime> FechaAprobación { get; set; }
    public bool Pendientes { get; set; }

  }

  public class DenominacionAlivio
  {

    public byte IdDenominacion { get; set; }
    public byte[] Logo { get; set; }
    public decimal Denominacion { get; set; }
    public short Cantidad { get; set; }
    public decimal TotalXDenominacion { get; set; }

  }

  #endregion

  public class AlivioEfectivo : DataAccess
  {

    #region Constructor

    public AlivioEfectivo(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public bool NecesitaAlivioEfectivo(int idUsuario)
    {
      try {
        EPK_ParametrosSistema param = EstadoAplicacion.GetParametroSistema("MAX_EFECTIVO");

        decimal montoEfectivo = new Facturas().MontoEfectivo(idUsuario);
        decimal montoTotalAlivios = this.BuscarMontoTotalAlivios(idUsuario);

        return ((montoEfectivo - montoTotalAlivios) > param.ValorNumerico);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    public EPK_AlivioEfectivoEncabezado BuscarUltimoAlivio(int idUsuario)
    {
      try {
        long lastId = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioCajero == idUsuario).Max(b => b.IdAlivioEfectivo);

        EPK_AlivioEfectivoEncabezado result = context.EPK_AlivioEfectivoEncabezado.Where(p => p.IdAlivioEfectivo == lastId).First();

        return result;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public decimal BuscarMontoTotalAlivios(int idUsuario)
    {
        decimal? Valor;
        try
        {
            EPK_CierreCajeroEncabezado ultimoCierre = new CierreCajero().ObtenerUltimo(idUsuario);

            if (ultimoCierre != null)
            {
                Valor = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioCajero == idUsuario &&
                        ((a.FechaAlivio > ultimoCierre.Fecha) || (a.FechaAlivio == ultimoCierre.Fecha && a.HoraAlivio > ultimoCierre.Hora))
                        ).Sum(a => (decimal?)a.TotalAlivio)?? 0;
            }
            else
                Valor = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioCajero == idUsuario).Sum(a => (decimal?)a.TotalAlivio) ?? 0;

            if (Valor.HasValue)
                return Valor.Value;
            else
                return 0;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
            return 0;
        }
    }

    public decimal BuscarMontoTotalAlivios(int idUsuario, DateTime fechaIni)
    {
      decimal? result = null;

      try {
        DateTime fechaFin = fechaIni.Date.AddDays(1).Date;
        fechaFin = fechaFin.AddSeconds(-1);

        DateTime fIni = fechaIni.Date;
        TimeSpan hIni = fechaIni.TimeOfDay;
        TimeSpan hFin = fechaFin.TimeOfDay;

        result = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioCajero == idUsuario &&
          a.FechaAlivio == fIni && a.HoraAlivio > hIni && a.HoraAlivio <= hFin).Sum(a => a.TotalAprobado);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = 0;
      }

      return result ?? 0;
    }

    public decimal TotalPendientes(int idUsuario, DateTime fechaInicio)
    {
        decimal? result = null;

        try
        {
            int idCreado = EstadoAplicacion.EstadosAlivio["ALICreacion"];

            result = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdEstatus == idCreado &&
                                                                     a.FechaAlivio == fechaInicio.Date &&
                                                                     a.HoraAlivio > fechaInicio.TimeOfDay &&
                                                                     a.IdUsuarioCajero == idUsuario).Sum(a => (decimal?)a.TotalAlivio)?? 0;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            result = 0;
        }

        return result ?? 0;
    }

    public decimal TotalAprobados(int idUsuario, DateTime fechaInicio)
    {
        decimal? result = null;

        try
        {
            int idAprobado = EstadoAplicacion.EstadosAlivio["ALIAprobacion"];

            result = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioAprobador.HasValue && 
                                                                a.IdEstatus == idAprobado &&
                                                                a.FechaAlivio == fechaInicio.Date &&
                                                                a.HoraAlivio > fechaInicio.TimeOfDay &&
                                                                a.IdUsuarioCajero == idUsuario).Sum(a => a.TotalAprobado)?? 0;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            result = 0;
        }

        return result ?? 0;
    }

    public decimal TotalAprobados(DateTime fechaIni, DateTime fechaFin)
    {
      decimal? result = null;

      try {
        int idAprobado = EstadoAplicacion.EstadosAlivio["ALIAprobacion"];

        result = context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdUsuarioAprobador.HasValue && a.IdEstatus == idAprobado &&
          a.FechaAlivio >= fechaIni.Date && a.FechaAlivio <= fechaFin.Date).Sum(a => a.TotalAprobado)?? 0;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = 0;
      }

      return result ?? 0;
    }

    public int CantidadPorAprobar(int idUsuario = 0)
    {
      int result = 0;

      try {
        short idCreado = EstadoAplicacion.EstadosAlivio["ALICreacion"];

        result = context.EPK_AlivioEfectivoEncabezado.Where(p => p.IdUsuarioAprobador == null && p.IdEstatus == idCreado &&
          (idUsuario > 0 ? p.IdUsuarioCajero == idUsuario : true)).Count();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = 0;
      }

      return result;
    }

    public List<EPK_AlivioEfectivoEncabezado> ObtenerPorAprobar()
    {
      try {
        short idCreado = EstadoAplicacion.EstadosAlivio["ALICreacion"];

        List<EPK_AlivioEfectivoEncabezado> results =
          context.EPK_AlivioEfectivoEncabezado.Where(p => !p.IdUsuarioAprobador.HasValue && p.IdEstatus == idCreado).ToList();

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public List<EPK_AlivioEfectivoEncabezado> ObtenerTodos(int? idCajero, int? idEstatus, DateTime fechaIni, DateTime fechaFin)
    {
      try {
        return context.EPK_AlivioEfectivoEncabezado.Where(p => (idCajero.HasValue ? p.IdUsuarioCajero == idCajero : true) &&
          (idEstatus.HasValue ? p.IdEstatus == idEstatus : true) &&
          p.FechaCreacion >= fechaIni && p.FechaCreacion <= fechaFin).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public List<EPK_AlivioEfectivoEncabezado> ObtenerTodos(DateTime fechaIni, DateTime fechaFin)
    {
      try {
        return context.EPK_AlivioEfectivoEncabezado.Where(p => (p.FechaCreacion >= fechaIni && p.FechaCreacion <= fechaFin)).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public EPK_AlivioEfectivoEncabezado Obtener(long idAlivio)
    {
      return context.EPK_AlivioEfectivoEncabezado.FirstOrDefault(p => p.IdAlivioEfectivo == idAlivio);
    }

    public long Nuevo(EPK_AlivioEfectivoEncabezado alivio)
    {
      long result = 0;

      try {
        DateTime currDate = this.FechaDB();

        alivio.IdEstatus = EstadoAplicacion.EstadosAlivio["ALICreacion"];
        alivio.FechaCreacion = currDate;

        if (alivio.FechaAlivio == null || alivio.FechaAlivio == DateTime.MinValue.Date) {
          alivio.FechaAlivio = currDate;
          alivio.HoraAlivio = currDate.TimeOfDay;
        }

        context.EPK_AlivioEfectivoEncabezado.Add(alivio);
        context.SaveChanges();

        if (EstadoAplicacion.PermitirContingencia && alivio.IdAlivioEfectivo > 0)
          Util.SetAppSettingsValue("UltimoAlivio", alivio.IdAlivioEfectivo.ToString(), false);

        result = alivio.IdAlivioEfectivo;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return result;
    }

    public bool Actualizar(EPK_AlivioEfectivoEncabezado alivio)
    {
      try {
        DateTime currDate = this.FechaDB();

        EPK_AlivioEfectivoEncabezado alivioActual = Obtener(alivio.IdAlivioEfectivo);

        alivioActual.IdUsuarioAprobador = alivio.IdUsuarioAprobador;
        alivioActual.FechaHoraAprobacion = currDate;
        alivioActual.TotalAprobado = alivio.TotalAprobado;
        alivioActual.IdEstatus = alivio.IdEstatus;

        foreach (EPK_AlivioEfectivoDetalle item in alivio.EPK_AlivioEfectivoDetalle)
          alivioActual.EPK_AlivioEfectivoDetalle.FirstOrDefault(p => p.IdDenominacion == item.IdDenominacion).CantidadAprobador = item.CantidadAprobador;

        context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    public long ObtenerUltimoId()
    {
      try {
        return this.context.EPK_AlivioEfectivoEncabezado.Max(a => a.IdAlivioEfectivo);
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
        return this.context.EPK_AlivioEfectivoEncabezado.Where(a => a.IdCaja == idCaja).Max(a => a.IdAlivioEfectivo);
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
          "EPK_AlivioEfectivoEncabezado", id.ToString()));

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
