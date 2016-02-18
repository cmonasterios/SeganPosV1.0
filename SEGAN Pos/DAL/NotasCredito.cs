using EntityFramework.Audit;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{
  #region Data Types

  public class ItemNC
  {
    public int Cantidad { get; set; }

    public int CantidadNC { get; set; }

    public int CantidadNCProc { get; set; }

    public string CodigoArticulo { get; set; }

    public string DescRef { get; set; }

    public string Descripcion { get; set; }

    public bool Descuento { get; set; }

    public bool Devolucion { get; set; }

    public bool Exento { get; set; }

    public int IdArticulo { get; set; }
    public int IdReferencia { get; set; }
    public decimal MontoDescuento { get; set; }

    public decimal MontoIVA { get; set; }

    public decimal PrecioBase { get; set; }

    public decimal PrecioNeto { get; set; }

    public decimal PrecioVenta { get; set; }
  }

  #endregion Data Types

  public class NotasCredito : DataAccess
  {
    #region Constructor

    public NotasCredito(bool skip = false)
      : base(skip)
    {
    }

    #endregion Constructor

    #region Public Methods

    public bool Actualizar(EPK_NotaCreditoEncabezado nCredito)
    {
      bool result = false;

      try {
        AuditLogger audit = this.context.BeginAudit();

        DateTime currDate = this.FechaDB();

        EPK_NotaCreditoEncabezado NCActual = this.Obtener(nCredito.IdNotaC);

        NCActual.IdEstatus = nCredito.IdEstatus;
        NCActual.COO = nCredito.COO;
        NCActual.TicketFiscal = nCredito.TicketFiscal;
        NCActual.NroReporteZ = nCredito.NroReporteZ;
        NCActual.Fecha = nCredito.Fecha;
        NCActual.Hora = nCredito.Hora;
        NCActual.FechaModificacion = currDate;
        NCActual.IdUsuarioModificacion = EstadoAplicacion.UsuarioActual.IdUsuario;

        this.context.SaveChanges();

        AuditLog log = audit.CreateLog();

        new NLogLogger().Info(string.Format("NC #{0} actualizada por: {1}({2}). Datos: {3}", nCredito.IdNotaC,
                              EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login, log.ToXml()));

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool ActualizarSolicitud(EPK_NotaCreditoEsperaEncabezado ncEspera)
    {
      bool result = false;

      try {
        AuditLogger audit = this.context.BeginAudit();

        DateTime currDate = this.FechaDB();

        EPK_NotaCreditoEsperaEncabezado ncEspActual = this.ObtenerSolicitud(ncEspera.IdNotaCreditoE);

        ncEspActual.IdEstatus = ncEspera.IdEstatus;
        ncEspActual.IdNCTienda = ncEspera.IdNCTienda;
        ncEspActual.TicketFiscalTienda = ncEspera.TicketFiscalTienda;
        ncEspActual.COO = ncEspera.COO;
        ncEspActual.Fecha = ncEspera.Fecha;
        ncEspActual.Hora = ncEspera.Hora;
        ncEspActual.NroReporteZ = ncEspera.NroReporteZ;
        ncEspActual.FechaModificacion = currDate;
        ncEspActual.IdUsuarioModificacion = ncEspera.IdUsuarioModificacion;

        this.context.SaveChanges();

        new NLogLogger().Info(string.Format("NC #{0} actualizada por: {1}({2})."/* Datos: {3}*/, ncEspera.IdNotaCreditoE,
                              EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login/*, audit.LastLog.ToXml()*/));

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool Anular(int id)
    {
      bool result = false;

      try {
        EPK_NotaCreditoEncabezado NCAct = this.Obtener(id);

        NCAct.IdEstatus = EstadoAplicacion.EstadosNC["NCAnulada"];
        NCAct.IdUsuarioModificacion = EstadoAplicacion.UsuarioActual.IdUsuario;
        NCAct.FechaModificacion = this.FechaDB();

        context.SaveChanges();

        new NLogLogger().Info(string.Format("NC #{0} anulada por: {1}({2}).", id,
                              EstadoAplicacion.UsuarioActual.Identificacion,
                              EstadoAplicacion.UsuarioActual.Login));

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = false;
      }

      return result;
    }

    public bool Emitir(int id)
    {
      bool result = false;

      try {
        EPK_NotaCreditoEncabezado NCAct = this.Obtener(id);

        NCAct.IdEstatus = EstadoAplicacion.EstadosNC["NCEmitida"];
        NCAct.IdUsuarioModificacion = EstadoAplicacion.UsuarioActual.IdUsuario;
        NCAct.FechaModificacion = this.FechaDB();

        context.SaveChanges();

        new NLogLogger().Info(string.Format("NC #{0} emitida por: {1}({2}).", id,
                              EstadoAplicacion.UsuarioActual.Identificacion,
                              EstadoAplicacion.UsuarioActual.Login));

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = false;
      }

      return result;
    }

    public int Nueva(EPK_NotaCreditoEncabezado nc)
    {
      int result = 0;

      try {
        DateTime currDate = this.FechaDB();

        int LongTF = Util.ObtenerParametroEntero("LONGTF");
        if (LongTF <= 0)
          LongTF = 8;

        if (!string.IsNullOrEmpty(nc.TicketFiscal))
          if (nc.TicketFiscal.Length < LongTF)
            nc.TicketFiscal = nc.TicketFiscal.PadLeft(LongTF, '0');

        nc.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
        nc.IdEstatus = EstadoAplicacion.EstadosNC["NCCreada"];
        nc.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
        nc.FechaCreacion = currDate;

        foreach (EPK_NotaCreditoDetalle item in nc.EPK_NotaCreditoDetalle) {
          item.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
          item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
          item.FechaCreacion = currDate;
        }

        this.context.EPK_NotaCreditoEncabezado.Add(nc);
        this.context.SaveChanges();

        new NLogLogger().Info(string.Format("NC #{0} creada por: {1}({2}).", nc.IdNotaC,
                              EstadoAplicacion.UsuarioActual.Identificacion,
                              EstadoAplicacion.UsuarioActual.Login));

        if (EstadoAplicacion.PermitirContingencia && nc.IdNotaC > 0)
          Util.SetAppSettingsValue("UltimaNC", nc.IdNotaC.ToString(), false);

        result = nc.IdNotaC;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public int NuevaSolicitud(EPK_NotaCreditoEsperaEncabezado ncEsp)
    {
      int result = 0;

      try {
        ncEsp.IdEstatus = EstadoAplicacion.EstadosNC["NCCreada"];
        ncEsp.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
        ncEsp.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
        ncEsp.FechaCreacion = this.FechaDB();
        ncEsp.FechaModificacion = ncEsp.FechaCreacion;

        foreach (EPK_NotaCreditoEsperaDetalle item in ncEsp.EPK_NotaCreditoEsperaDetalle) {
          item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
          item.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
          item.FechaCreacion = ncEsp.FechaCreacion;
          item.FechaModificacion = ncEsp.FechaCreacion;
        }

        context.EPK_NotaCreditoEsperaEncabezado.Add(ncEsp);
        context.SaveChanges();

        new NLogLogger().Info(string.Format("Solicitud de NC #{0} creada por: {1}({2}).", ncEsp.IdNotaCreditoE,
                              EstadoAplicacion.UsuarioActual.Identificacion,
                              EstadoAplicacion.UsuarioActual.Login));

        result = ncEsp.IdNotaCreditoE;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_NotaCreditoEncabezado Obtener(int id)
    {
      return this.context.EPK_NotaCreditoEncabezado.FirstOrDefault(nc => nc.IdNotaC == id);
    }

    public EPK_NotaCreditoEsperaEncabezado ObtenerSolicitud(int id)
    {
      return this.context.EPK_NotaCreditoEsperaEncabezado.FirstOrDefault(nc => nc.IdNotaCreditoE == id);
    }

    public int ObtenerUltimoId()
    {
      try {
        return this.context.EPK_NotaCreditoEncabezado.Max(nc => nc.IdNotaC);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 0;
    }

    public int ObtenerUltimoId(int idCaja)
    {
      try {
        return this.context.EPK_NotaCreditoEncabezado.Where(nc => nc.EPK_FacturaEncabezado.IdCaja == idCaja).Max(nc => nc.IdNotaC);
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
          "EPK_NotaCreditoEncabezado", id.ToString()));

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public List<EPK_NotaCreditoEsperaEncabezado> SolictudesAprobadas(string serialMF)
    {
      List<EPK_NotaCreditoEsperaEncabezado> result = new List<EPK_NotaCreditoEsperaEncabezado>();

      if (string.IsNullOrEmpty(serialMF))
        return result;

      try {
        short idAprobada = EstadoAplicacion.EstadosNC["NCAprobada"];
        result = this.context.EPK_NotaCreditoEsperaEncabezado.Where(nc => nc.IdEstatus == idAprobada && 
                                                                          nc.SerialMF == serialMF &&
                                                                          nc.EPK_NotaCreditoEsperaDetalle.Count > 0).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool TieneSolicitudesAprobadas(string serialMF)
    {
      if (string.IsNullOrEmpty(serialMF))
        return false;

      try {
        short idAprobada = EstadoAplicacion.EstadosNC["NCAprobada"];
        return (this.context.EPK_NotaCreditoEsperaEncabezado.Where(nc => nc.IdEstatus == idAprobada && 
                                                                         nc.SerialMF == serialMF &&
                                                                         nc.EPK_NotaCreditoEsperaDetalle.Count> 0).Count() > 0);
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