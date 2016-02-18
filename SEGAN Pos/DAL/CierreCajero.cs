using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SEGAN_POS.DAL
{
  public class CierreCajero : DataAccess
  {

    #region Constructor

    public CierreCajero(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public List<EPK_CierreCajeroEncabezado> ObtenerTodos()
    {
      try {
        return context.EPK_CierreCajeroEncabezado.ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public List<EPK_CierreCajeroEncabezado> ObtenerTodos(DateTime fechaDesde, DateTime fechaHasta)
    {
      try {
        return context.EPK_CierreCajeroEncabezado.Where(p => p.Fecha >= fechaDesde && p.Fecha <= fechaHasta).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public decimal Total(DateTime fechaIni, DateTime fechaFin)
    {
      decimal? result = null;

      try {
        result = context.EPK_CierreCajeroDenominacion.Where(c => c.EPK_CierreCajeroEncabezado.Fecha >= fechaIni &&
          c.EPK_CierreCajeroEncabezado.Fecha <= fechaFin).Sum(c => c.Cantidad * c.EPK_Denominacion.Denominacion);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = 0;
      }

      return result ?? 0;
    }

    public EPK_CierreCajeroEncabezado Obtener(long idCierre)
    {
      return context.EPK_CierreCajeroEncabezado.FirstOrDefault(p => p.IdCierre == idCierre);
    }

    public long Nuevo(EPK_CierreCajeroEncabezado cierre)
    {
      long result = 0;

      try {
        cierre.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (cierre.EPK_CierreCajeroDenominacion.FirstOrDefault() != null)
          foreach (EPK_CierreCajeroDenominacion item in cierre.EPK_CierreCajeroDenominacion)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (cierre.EPK_CierreCajeroPOS.FirstOrDefault() != null)
          foreach (EPK_CierreCajeroPOS item in cierre.EPK_CierreCajeroPOS)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (cierre.EPK_CierreCajeroPagos.FirstOrDefault() != null)
          foreach (EPK_CierreCajeroPagos item in cierre.EPK_CierreCajeroPagos)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        context.EPK_CierreCajeroEncabezado.Add(cierre);
        context.SaveChanges();

        if (EstadoAplicacion.PermitirContingencia && cierre.IdCierre > 0)
          Util.SetAppSettingsValue("UltimoCierreCajero", cierre.IdCierre.ToString(), false);

        result = cierre.IdCierre;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool ActualizarLote(DateTime fecha, List<CierreVentasOtrosPagos> pagosCierre)
    {
      bool result = false;

      try {
        using (TransactionScope transaction = new TransactionScope()) {
          foreach (CierreVentasOtrosPagos pagoCierre in pagosCierre) {
            if (pagoCierre.IdFormaPago <= 0 || pagoCierre.IdPOS <= 0 || pagoCierre.Lote <= 0)
              continue;

            List<EPK_CierreCajeroPOS> cierresPOS = context.EPK_CierreCajeroPOS.Where(cp => cp.IdFormaPago == pagoCierre.IdFormaPago &&
              cp.IdPOS == pagoCierre.IdPOS && cp.EPK_CierreCajeroEncabezado.Fecha == fecha).ToList();

            foreach (EPK_CierreCajeroPOS pagos in cierresPOS)
              pagos.LotePOS = pagoCierre.Lote;
          }

          context.SaveChanges();
          transaction.Complete();
        }

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        result = false;
      }

      return result;
    }

    public EPK_CierreCajeroEncabezado ObtenerUltimo(int idUsuario)
    {
      try {
        return context.EPK_CierreCajeroEncabezado.Where(cc => cc.IdCajero == idUsuario).
          OrderByDescending(cc => cc.Fecha).ThenByDescending(cc => cc.Hora).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public List<EPK_Usuario> ObtenerPendientes(DateTime fecha)
    {
      List<EPK_Usuario> results = new List<EPK_Usuario>();

      try {
        int idFaCProc = Util.ObtenerParametroEntero("FACProcesada");

        results = context.EPK_Usuario.Where(u => u.EPK_FacturaEncabezado.FirstOrDefault(f => f.IdEstatus == idFaCProc &&
          DbFunctions.TruncateTime(f.FechaCreacion) == fecha.Date) == null ? false :
          (u.EPK_FacturaEncabezado.Where(f => f.IdEstatus == idFaCProc && DbFunctions.TruncateTime(f.FechaCreacion) == fecha.Date &&
            (u.EPK_CierreCajeroEncabezado.FirstOrDefault(cc => cc.Fecha == fecha.Date) == null ? true :
            DbFunctions.CreateTime(f.FechaCreacion.Hour, f.FechaCreacion.Minute, f.FechaCreacion.Second) >
            u.EPK_CierreCajeroEncabezado.Where(cc => cc.Fecha == fecha.Date).
          OrderByDescending(cc => cc.Hora).FirstOrDefault().Hora)).Count() > 0)).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public bool TienePendiente(int idUsuario)
    {
      bool result = false;

      try {
        DateTime? fechaUltCierre = null;

        EPK_CierreCajeroEncabezado ultimoCierre = this.ObtenerUltimo(idUsuario);

        if (ultimoCierre != null)
          fechaUltCierre = ultimoCierre.Fecha + ultimoCierre.Hora;

        EPK_FacturaEncabezado primeraFactura = new Facturas().ObtenerPrimera(idUsuario, fechaUltCierre);

        if (primeraFactura != null) {
          DateTime currDate = this.FechaDB();
          result = primeraFactura.FechaCreacion.Date < currDate.Date;
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public long ObtenerUltimoId()
    {
      try {
        return this.context.EPK_CierreCajeroEncabezado.Max(c => c.IdCierre);
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
        return this.context.EPK_CierreCajeroEncabezado.Where(c => c.IdCaja == idCaja).Max(c => c.IdCierre);
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
          "EPK_CierreCajeroEncabezado", id.ToString()));

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
