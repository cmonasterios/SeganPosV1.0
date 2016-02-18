using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{
  #region Data Types

  public class CierreVtasInventario
  {
    public int? EntradaNC { get; set; }

    public int? Entradas { get; set; }

    public int? FacturasImp { get; set; }

    public int? Salidas { get; set; }
  }

  public class CierreVtasMaqFiscal
  {
    public decimal? DiferenciaTotal { get; set; }

    public string FactD { get; set; }

    public string FactH { get; set; }

    public decimal? MontoBase { get; set; }

    public decimal? MontoDesc { get; set; }

    public decimal? MontoExento { get; set; }

    public decimal? MontoIVA { get; set; }

    public decimal? MontoTotal { get; set; }

    public string NroZ { get; set; }

    public string SerialMaq { get; set; }
  }

  public class CierreVtasMaqFiscalNC
  {
    public decimal? DiferenciaTotal { get; set; }

    public string FactDNC { get; set; }

    public string FactHNC { get; set; }

    public decimal? MontoBaseNC { get; set; }

    public decimal? MontoDescNC { get; set; }

    public decimal? MontoExentoNC { get; set; }

    public decimal? MontoIVANC { get; set; }

    public decimal? MontoTotalNC { get; set; }

    public string NroZNC { get; set; }

    public string SerialMaqNC { get; set; }
  }

  public class CierreVtasMaqFiscalNCZ
  {
    public string FactDNCZ { get; set; }

    public string FactHNCZ { get; set; }

    public decimal? MontoBaseNCZ { get; set; }

    public decimal? MontoExentoNCZ { get; set; }

    public decimal? MontoIVANCZ { get; set; }

    public decimal? MontoTotalNCZ { get; set; }

    public string NroZNC { get; set; }

    public string SerialMaqNC { get; set; }
  }

  public class CierreVtasMaqFiscalZ
  {
    public string FactDZ { get; set; }

    public string FactHZ { get; set; }

    public decimal? MontoBaseZ { get; set; }

    public decimal? MontoDescZ { get; set; }

    public decimal? MontoExentoZ { get; set; }

    public decimal? MontoIVAZ { get; set; }

    public decimal? MontoTotalZ { get; set; }

    public string NroZ { get; set; }

    public string SerialMaq { get; set; }
  }

  public class CierreVtasNotasCredito
  {
    public decimal? Bruto { get; set; }

    public int Doc { get; set; }

    public decimal? Exento { get; set; }

    public DateTime? FechaFactura { get; set; }

    public decimal? Impuesto { get; set; }

    public string TicketFiscal { get; set; }
    public decimal? TotalConsolidadoNC { get; set; }

    public decimal? TotalGeneral { get; set; }
  }

  public class ConsolidadoCierreVtas
  {
    public string FormaPago { get; set; }

    public int IdFormaPago { get; set; }
    public decimal? TotalGeneral { get; set; }
  }

  public class ConsolidadoTotales
  {
    public decimal? TotalBI { get; set; }

    public decimal? TotalDesc { get; set; }

    public decimal? TotalExento { get; set; }

    public decimal? TotalIVA { get; set; }
  }

  public class ItemRepoArticulos
  {
    public string CodArt { get; set; }

    public string CodColec { get; set; }

    public string CodGrupo { get; set; }

    public string CodRef { get; set; }

    public string DescGene { get; set; }
    public string DescTema { get; set; }

    public int Devolucion { get; set; }

    public decimal Precio { get; set; }

    public int Total { get; set; }

    public int Ventas { get; set; }
  }

  public class ItemVentasDia
  {
    public string DescCaja { get; set; }

    public int IdCaja { get; set; }
    public decimal? MontoTotal { get; set; }

    public decimal? Porcent { get; set; }

    public string RepZ { get; set; }

    public string SerialMF { get; set; }
  }
  #endregion Data Types

  public class Reportes : DataAccess
  {
    #region Public Methods

    public List<ConsolidadoCierreVtas> CierreTotalConsolidados(DateTime fechaD, DateTime fechaH)
    {
      List<ConsolidadoCierreVtas> results = new List<ConsolidadoCierreVtas>();

      try {
        int idProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

        results = context.EPK_FacturaPago.
            Where(cvp => cvp.EPK_FacturaEncabezado.Fecha >= fechaD && cvp.EPK_FacturaEncabezado.Fecha <= fechaH &&
                  cvp.EPK_FacturaEncabezado.IdEstatus == idProc).
            GroupBy(fe => new { fe.IdFormaPago, fe.EPK_FormaPago.Descripcion })
            .Select(cvp => new ConsolidadoCierreVtas {
              IdFormaPago = cvp.Key.IdFormaPago,
              FormaPago = cvp.Key.Descripcion,
              TotalGeneral = cvp.Sum(f => f.Monto - f.MontoVuelto)
            }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return results;
    }

    public List<CierreVtasMaqFiscal> CierreVtasEfectivo(DateTime fechaD, DateTime fechaH)
    {
      List<CierreVtasMaqFiscal> results = new List<CierreVtasMaqFiscal>();
      try {
        results = context.EPK_CierreMaquinaFiscal.Where(f => f.Fecha >= fechaD.Date && f.Fecha <= fechaH.Date).
          GroupBy(f => new { f.Fecha, f.ReporteZ, f.EPK_Dispositivo.Serial, f.FacturaDesde, f.FacturaHasta }).
          Select(g => new CierreVtasMaqFiscal {
            NroZ = g.Key.ReporteZ,
            FactD = g.Key.FacturaDesde,
            FactH = g.Key.FacturaHasta,
            MontoBase = g.Sum(mb => mb.BaseImponibleFact ?? 0),
            MontoExento = g.Sum(mb => mb.ExentoFact ?? 0),
            MontoIVA = g.Sum(mi => mi.ImpuestoFact ?? 0),
            MontoDesc = g.Sum(md => md.DescuentoFact ?? 0),
            MontoTotal = g.Sum(mt => mt.MontoTotalFact),
            DiferenciaTotal = (g.Sum(dt => dt.TotalFactZ ?? 0) - g.Sum(mt => mt.MontoTotalFact)),
            SerialMaq = g.Key.Serial
          }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return results;
    }

    public List<CierreVtasMaqFiscalZ> CierreVtasEfectivoZ(DateTime fechaD, DateTime fechaH)
    {
      List<CierreVtasMaqFiscalZ> results = new List<CierreVtasMaqFiscalZ>();
      try {
        results = context.EPK_CierreMaquinaFiscal.Where(f => f.Fecha >= fechaD.Date && f.Fecha <= fechaH.Date).
          GroupBy(f => new { f.Fecha, f.ReporteZ, f.EPK_Dispositivo.Serial, f.FacturaDesdeZ, f.FacturaHastaZ }).
          Select(g => new CierreVtasMaqFiscalZ {
            NroZ = g.Key.ReporteZ,
            FactDZ = g.Key.FacturaDesdeZ,
            FactHZ = g.Key.FacturaHastaZ,
            MontoBaseZ = g.Sum(mb => mb.BaseImponibleFactZ ?? 0),
            MontoExentoZ = g.Sum(mb => mb.ExentoFactZ ?? 0),
            MontoIVAZ = g.Sum(mi => mi.ImpuestoFactZ ?? 0),
            MontoDescZ = g.Sum(md => md.DescuentoFactZ ?? 0),
            MontoTotalZ = g.Sum(mt => mt.TotalFactZ),
            SerialMaq = g.Key.Serial
          }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return results;
    }

    public List<CierreVtasMaqFiscalNC> CierreVtasMFNC(DateTime fechaD, DateTime fechaH)
    {
      List<CierreVtasMaqFiscalNC> results = new List<CierreVtasMaqFiscalNC>();
      try {
        results = context.EPK_CierreMaquinaFiscal.Where(f => f.Fecha >= fechaD.Date && f.Fecha <= fechaH.Date).
          GroupBy(f => new { f.Fecha, f.ReporteZ, f.EPK_Dispositivo.Serial, f.NCDesde, f.NCHasta }).
          Select(g => new CierreVtasMaqFiscalNC {
            NroZNC = g.Key.ReporteZ,
            FactDNC = g.Key.NCDesde,
            FactHNC = g.Key.NCHasta,
            MontoBaseNC = g.Sum(mb => mb.BaseImponibleNC ?? 0),
            MontoExentoNC = g.Sum(mb => mb.ExentoNC ?? 0),
            MontoIVANC = g.Sum(mi => mi.ImpuestoNC ?? 0),
            MontoDescNC = g.Sum(md => md.DescuentoNC ?? 0),
            MontoTotalNC = g.Sum(mt => mt.MontoTotalNC ?? 0),
            DiferenciaTotal = g.Sum(mi => mi.TotalNCZ ?? 0) - g.Sum(mt => mt.MontoTotalNC ?? 0),
            SerialMaqNC = g.Key.Serial
          }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public List<CierreVtasMaqFiscalNCZ> CierreVtasMFNCZ(DateTime fechaD, DateTime fechaH)
    {
      List<CierreVtasMaqFiscalNCZ> results = new List<CierreVtasMaqFiscalNCZ>();
      try {
        results = context.EPK_CierreMaquinaFiscal.Where(f => f.Fecha >= fechaD.Date && f.Fecha <= fechaH.Date).
          GroupBy(f => new { f.Fecha, f.ReporteZ, f.EPK_Dispositivo.Serial, f.NCDesde, f.NCHasta }).
          Select(g => new CierreVtasMaqFiscalNCZ {
            NroZNC = g.Key.ReporteZ,
            FactDNCZ = g.Key.NCDesde,
            FactHNCZ = g.Key.NCHasta,
            MontoBaseNCZ = g.Sum(mb => mb.BaseImponibleNCZ ?? 0),
            MontoExentoNCZ = g.Sum(me=>me.ExentoNCZ?? 0),
            MontoIVANCZ = g.Sum(mi => mi.ImpuestoNCZ ?? 0),
            MontoTotalNCZ = g.Sum(mt => mt.TotalNCZ ?? 0),
            SerialMaqNC = g.Key.Serial
          }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public List<CierreVtasNotasCredito> CierreVtasNC(DateTime fechaD, DateTime fechaH)
    {
      List<CierreVtasNotasCredito> results = new List<CierreVtasNotasCredito>();

      try {
        int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];

        results = context.EPK_NotaCreditoEncabezado.Where(f => f.FechaCreacion >= fechaD && f.FechaCreacion < fechaH && f.IdEstatus == idNCEmitida).
          Select(nc => new CierreVtasNotasCredito {
            TicketFiscal = nc.EPK_FacturaEncabezado.TicketFiscal,
            FechaFactura = nc.EPK_FacturaEncabezado.Fecha,
            Doc = nc.IdNotaC,
            Exento = (nc.EPK_NotaCreditoDetalle.Where(fd => fd.Exento).Sum(fd => fd.PrecioNeto)) == null ? 0 : (nc.EPK_NotaCreditoDetalle.Where(fd => fd.Exento).Sum(fd => fd.PrecioNeto * fd.Cantidad)),
            Bruto = nc.MontoBase ?? 0,
            Impuesto = nc.MontoIVA,
            TotalGeneral = nc.MontoTotal
          }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return results;
    }

    public ConsolidadoTotales CierreVtasTotales(DateTime fechaD, DateTime fechaH)
    {
      int idProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

      ConsolidadoTotales results = new ConsolidadoTotales { TotalBI = 0, TotalDesc = 0, TotalIVA = 0, TotalExento = 0 };

      try {
        results.TotalBI = context.EPK_FacturaEncabezado.
          Where(fd => fd.Fecha >= fechaD && fd.Fecha < fechaH && fd.IdEstatus == idProc).Sum(fd => fd.MontoBase) ?? 0;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.TotalDesc = context.EPK_FacturaEncabezado.
          Where(fd => fd.Fecha >= fechaD && fd.Fecha < fechaH && fd.IdEstatus == idProc).Sum(fd => fd.MontoDescuento) ?? 0;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.TotalIVA = context.EPK_FacturaEncabezado.
          Where(fd => fd.Fecha >= fechaD && fd.Fecha < fechaH && fd.IdEstatus == idProc).Sum(fd => fd.MontoIVA);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.TotalExento = (context.EPK_FacturaDetalle.Count(fd => fd.EPK_FacturaEncabezado.FechaCreacion >= fechaD &&
          fd.EPK_FacturaEncabezado.FechaCreacion < fechaH && !fd.Cambio && fd.Exento && fd.EPK_FacturaEncabezado.IdEstatus == idProc) > 0 ?
          context.EPK_FacturaDetalle.Where(fd => fd.EPK_FacturaEncabezado.FechaCreacion >= fechaD && fd.EPK_FacturaEncabezado.Fecha < fechaH &&
            !fd.Cambio && fd.Exento && fd.EPK_FacturaEncabezado.IdEstatus == idProc).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0) -
            (context.EPK_FacturaDetalle.Count(fd => fd.EPK_FacturaEncabezado.FechaCreacion >= fechaD && fd.EPK_FacturaEncabezado.Fecha < fechaH &&
              fd.Cambio && fd.Exento && fd.EPK_FacturaEncabezado.IdEstatus == idProc) > 0 ?
              context.EPK_FacturaDetalle.Where(fd => fd.EPK_FacturaEncabezado.Fecha >= fechaD && fd.EPK_FacturaEncabezado.FechaCreacion < fechaH &&
                fd.Cambio && fd.Exento && fd.EPK_FacturaEncabezado.IdEstatus == idProc).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public List<EPK_sp_ArticuloConsultar_Result> ConsultarExistencias(int? IdArticulo, string CodigoArticulo, int? IdReferencia,
       string Descripcion, int? IdColor, int? IdTalla, bool? Activo, bool? Exento, string Referencia, int? IdGrupo,
       int? IdGenero, int? IdTema, int? IdColeccion)
    {
      return this.context.EPK_sp_ArticuloConsultar(IdArticulo, CodigoArticulo, IdReferencia, Descripcion, IdColor, IdTalla, Activo, Exento, Referencia, IdGrupo, IdGenero, IdTema, IdColeccion).ToList();
    }

    public List<EPK_sp_MaestroPedidoSugerido_Result> MaestroPedidoSugerido(int IdColeccion, int MenosDe,
      int PidoPMenosDe, int Entre5y, int PidoEntre5y)
    {
      return this.context.EPK_sp_MaestroPedidoSugerido(IdColeccion, MenosDe, PidoPMenosDe, Entre5y, PidoEntre5y).ToList();
    }

    public CierreVtasInventario ObtenerCierreVtasInv(DateTime fechaD, DateTime fechaH)
    {
      int idProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
      int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];

      CierreVtasInventario results = new CierreVtasInventario { Salidas = 0, Entradas = 0, FacturasImp = 0, EntradaNC = 0 };

      try {
        results.Salidas = context.EPK_FacturaDetalle.
          Where(fd => fd.EPK_FacturaEncabezado.FechaCreacion >= fechaD && fd.EPK_FacturaEncabezado.FechaCreacion < fechaH &&
            !fd.Cambio && fd.EPK_FacturaEncabezado.IdEstatus == idProc).Sum(fd => fd.Cantidad);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.Entradas = context.EPK_FacturaDetalle.
         Where(fd => fd.EPK_FacturaEncabezado.FechaCreacion >= fechaD && fd.EPK_FacturaEncabezado.FechaCreacion < fechaH &&
          fd.Cambio && fd.EPK_FacturaEncabezado.IdEstatus == idProc).Sum(fd => fd.Cantidad);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.EntradaNC = context.EPK_NotaCreditoDetalle.
       Where(fd => fd.EPK_NotaCreditoEncabezado.FechaCreacion >= fechaD && fd.EPK_NotaCreditoEncabezado.FechaCreacion < fechaH &&
        !fd.Cambio && fd.EPK_NotaCreditoEncabezado.IdEstatus == idNCEmitida).Sum(fd => fd.Cantidad);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      try {
        results.FacturasImp = context.EPK_FacturaEncabezado.
         Where(fd => fd.FechaCreacion >= fechaD && fd.FechaCreacion < fechaH && fd.IdEstatus == idProc).Count();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }
    public List<EPK_sp_PedidoSugeridoTotales_Result> PedidoSugeridoTotales(int IdColeccion, int MenosDe,
      int PidoPMenosDe, int Entre5y, int PidoEntre5y)
    {
      return this.context.EPK_sp_PedidoSugeridoTotales(IdColeccion, MenosDe, PidoPMenosDe, Entre5y, PidoEntre5y).ToList();
    }

    public IEnumerable<EPK_sp_ReporteAperturaCajero_Result> ReporteAperturaCajero(DateTime fechaDesde, DateTime fechaHasta,
      int? IdCaja, string Cajero)
    {
      return this.context.EPK_sp_ReporteAperturaCajero(fechaDesde, fechaHasta, IdCaja, Cajero).ToList();
    }

    public IEnumerable<EPK_sp_ReporteCierreCajero_Result> ReporteCierreCajero(
            DateTime fechaDesde, DateTime fechaHasta, int? IdCaja, string Cajero)
    {
      return this.context.EPK_sp_ReporteCierreCajero(fechaDesde, fechaHasta, IdCaja, Cajero).ToList();
    }

    public IEnumerable<EPK_sp_ReporteComportamientoVta_Result> ReporteComportamientoVta(DateTime fechaDesde, DateTime fechaHasta,
      byte Intervalo, TimeSpan? horaDesde, TimeSpan? horaHasta)
    {
      return this.context.EPK_sp_ReporteComportamientoVta(fechaDesde, fechaHasta, Intervalo, horaDesde, horaHasta).ToList();
    }

    public IEnumerable<EPK_sp_ReporteConciliacionFormaPago_Result> ReporteConciliacionFormaPago(
            DateTime fechaDesde, int? intIdCaja,
            byte? IdFormaPago,
            int? intIdEntidad, int? intIdPOS,
            decimal? decMontoD, decimal? decMontoH,
            int? intIdMF, string strCajero)
    {
      return this.context.EPK_sp_ReporteConciliacionFormaPago(fechaDesde, intIdCaja, IdFormaPago, intIdEntidad,
          intIdPOS, decMontoD, decMontoH, intIdMF, (strCajero == "" ? null : strCajero)).ToList();
    }

    public IEnumerable<EPK_sp_ReporteConciliacionFormaPagoDetalle_Result> ReporteConciliacionFormaPagoDetalle(
      DateTime fechaDesde, int? intIdCaja, byte? IdFormaPago, int? intIdEntidad, int? intIdPOS,
      decimal? decMontoD, decimal? decMontoH, int? intIdMF, string strCajero)
    {
      return this.context.EPK_sp_ReporteConciliacionFormaPagoDetalle(fechaDesde, intIdCaja, IdFormaPago, intIdEntidad,
        intIdPOS, decMontoD, decMontoH, intIdMF, strCajero).ToList();
    }

    public IEnumerable<EPK_sp_ReporteDevoluciones_Result> ReporteDevoluciones(DateTime fechaDesde, DateTime fechaHasta, int? factDesde,
      int? factHasta, int? idMotDev, int? idAutoriz, int? intIdColeccion, int? idGenero, int? idGrupo, string strCajero)
    {
      return this.context.EPK_sp_ReporteDevoluciones(fechaDesde, fechaHasta, factDesde, factHasta, idMotDev, idAutoriz,
                 intIdColeccion, idGenero, idGrupo, (strCajero == "" ? null : strCajero)).ToList();
    }

    public IEnumerable<EPK_sp_ReporteOperacionesCajero_Result> ReporteOperacionesCajero(
                DateTime fechaDesde, DateTime fechaHasta, int? IdCaja, string Cajero)
    {
      return this.context.EPK_sp_ReporteOperacionesCajero(fechaDesde, fechaHasta, IdCaja, Cajero).ToList();
    }

    public IEnumerable<EPK_sp_ReportePagosConsolidados_Result> ReportePagoConsolodado(DateTime fechaDesde, DateTime fechaHasta)
    {
      return this.context.EPK_sp_ReportePagosConsolidados(fechaDesde, fechaHasta).ToList();
    }

    public IEnumerable<EPK_sp_ReporteReferenciasSinMovimiento_Result> ReporteReferenciasSinMovimiento(DateTime fechaDesde,
        DateTime fechaHasta, int? intIdColeccion, string txtReferencia, int? idTalla, int? idColor, int? idGenero,
        int? idGrupo, int? idTema, byte? idTipoPrenda)
    {
      return this.context.EPK_sp_ReporteReferenciasSinMovimiento(fechaDesde, fechaHasta,
           intIdColeccion, txtReferencia, idTalla, idColor, idGenero, idGrupo, idTema, idTipoPrenda).ToList();
    }

    public IEnumerable<EPK_sp_ReporteVtaDiariaFPConsolidado_Result> ReporteRelacionVtasDiaria(DateTime Fecha, byte? idFormaPago)
    {
      return this.context.EPK_sp_ReporteVtaDiariaFPConsolidado(Fecha, idFormaPago).ToList();
    }

    public IEnumerable<EPK_sp_ReporteVtaDiariaFPDetallado_Result> ReporteRelacionVtasDiariaDetallado(DateTime Fecha, byte? idFormaPago)
    {
      return this.context.EPK_sp_ReporteVtaDiariaFPDetallado(Fecha, idFormaPago).ToList();
    }

    public IEnumerable<EPK_sp_ReporteVtaDiariaTotalesConsolidado_Result> ReporteRelacionVtasDiariaTotales(DateTime Fecha, byte? idFormaPago)
    {
      return this.context.EPK_sp_ReporteVtaDiariaTotalesConsolidado(Fecha, idFormaPago).ToList();
    }

    public IEnumerable<EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_Result> ReporteRelacionVtasDiariaTotalesFP(DateTime Fecha, byte? idFormaPago)
    {
      return this.context.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado(Fecha, idFormaPago).ToList();
    }

    public IEnumerable<EPK_sp_ReporteVentaDiaria_Result> ReporteVentaDiaria(DateTime fechaDesde, DateTime fechaHasta)
    {
      return this.context.EPK_sp_ReporteVentaDiaria(fechaDesde, fechaHasta).ToList();
    }

    public List<EPK_sp_CierreMaquinaFiscalValidar_Result> sp_CierreMaquinaFiscalValidar(DateTime FechaI, DateTime FechaF) 
    {
        return this.context.EPK_sp_CierreMaquinaFiscalValidar(FechaI, FechaF).ToList();
    }

    public List<EPK_sp_ReporteVentasxArticulos_Result> ReporteVentasxArticulos(int IdColeccion, DateTime FechaDesde, DateTime FechaHasta)
    {
      if (IdColeccion < 0)
        IdColeccion = 0;

      return this.context.EPK_sp_ReporteVentasxArticulos(IdColeccion, FechaDesde, FechaHasta).ToList();
    }

    public  int EPK_LecturasActualizar(int IdRegion,int IdLocalidad, int IdEmpleado,int IdTerminal, string Fecha, string Hora, short TipoEntrada,short IdEstadoLectura,short ModoVer, short WorkCode)
    {
        return this.context.EPK_sp_LecturasActualizar(IdRegion,IdLocalidad,IdEmpleado,IdTerminal,Fecha,Hora,TipoEntrada,IdEstadoLectura,ModoVer,WorkCode);
    }

    public List<ItemRepoArticulos> ReposicionArticulos(DateTime fDesde, DateTime fHasta, int? idColeccion, int? idGrupo,
                                                       int? idGenero, int? idTema, string codRef, int? cantidad)
    {
      List<ItemRepoArticulos> results = new List<ItemRepoArticulos>();

      try {
        int idProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
        decimal IVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA") : 0;

        results = (from fd in this.context.EPK_FacturaDetalle
                   where fd.EPK_FacturaEncabezado.IdEstatus == idProc &&
                         fd.EPK_FacturaEncabezado.FechaCreacion >= fDesde &&
                         fd.EPK_FacturaEncabezado.FechaCreacion <= fHasta &&
                         (idColeccion.HasValue ? fd.EPK_Articulo.EPK_Referencia.IdColeccion == idColeccion : true) &&
                         (idGrupo.HasValue ? fd.EPK_Articulo.EPK_Referencia.IdGrupo == idGrupo : true) &&
                         (idGenero.HasValue ? fd.EPK_Articulo.EPK_Referencia.IdGenero == idGenero : true) &&
                         (idTema.HasValue ? fd.EPK_Articulo.EPK_Referencia.IdTema == idTema : true) &&
                         (string.IsNullOrEmpty(codRef) ? true : fd.EPK_Articulo.EPK_Referencia.CodigoReferencia.StartsWith(codRef))
                   group fd by new { fd.EPK_Articulo } into fdg
                   let ventas = fdg.Where(f => !f.Cambio).Count() > 0 ? fdg.Where(f => !f.Cambio).Sum(f => f.Cantidad) : 0
                   let devol = fdg.Where(f => f.Cambio).Count() > 0 ? fdg.Where(f => f.Cambio).Sum(f => f.Cantidad) : 0
                   let total = ventas - devol
                   where (cantidad.HasValue ? total >= cantidad : true) //&& (fdg.Key.EPK_Articulo.EPK_Referencia.EPK_Tema.Descripcion != "")   Existen Tipo con descripcion vacias
                   select new ItemRepoArticulos {
                     CodColec = (fdg.Key.EPK_Articulo.EPK_Referencia.IdColeccion.HasValue ? fdg.Key.EPK_Articulo.EPK_Referencia.EPK_Coleccion.CodigoColeccion.Trim() : ""),
                     DescGene = (fdg.Key.EPK_Articulo.EPK_Referencia.IdGenero.HasValue ? fdg.Key.EPK_Articulo.EPK_Referencia.EPK_Genero.Descripcion.Trim() : ""),
                     CodGrupo = (fdg.Key.EPK_Articulo.EPK_Referencia.IdGrupo.HasValue ? fdg.Key.EPK_Articulo.EPK_Referencia.EPK_Grupo.CodigoGrupo.Trim() : ""),
                     CodRef = fdg.Key.EPK_Articulo.EPK_Referencia.CodigoReferencia.Trim(),
                     CodArt = fdg.Key.EPK_Articulo.CodigoArticulo.Trim(),
                     DescTema = (fdg.Key.EPK_Articulo.EPK_Referencia.IdTema.HasValue ? fdg.Key.EPK_Articulo.EPK_Referencia.EPK_Tema.Descripcion : ""),
                     Ventas = ventas,
                     Devolucion = devol,
                     Total = total,
                     Precio = ((EstadoAplicacion.AplicaImpuesto && !fdg.Key.EPK_Articulo.Exento) ?
                               (fdg.Key.EPK_Articulo.PrecioGravable + Math.Round((fdg.Key.EPK_Articulo.PrecioGravable) * IVA / 100, 2)) : fdg.Key.EPK_Articulo.PrecioExento)
                   }).OrderBy(r => r.CodColec).ThenBy(r => r.DescGene).ThenBy(r => r.CodGrupo).ThenBy(r => r.CodRef).
                   ThenBy(r => r.CodArt).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public IEnumerable<EPK_sp_ReporteResumenDiarioVtas_Result> ResumenDiarioVentas(
           DateTime fechaDesde, DateTime fechaHasta, string MFiscal)
    {
      return this.context.EPK_sp_ReporteResumenDiarioVtas(fechaDesde, fechaHasta, MFiscal).ToList();
    }

    public decimal TotalConsolidadoNC(DateTime fechaD, DateTime fechaH)
    {
      decimal result = 0;

      try {
        int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];

        result = context.EPK_NotaCreditoEncabezado.Where(f => f.FechaCreacion >= fechaD && f.FechaCreacion < fechaH && f.IdEstatus == idNCEmitida).
          Sum(nc => nc.MontoTotal);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return result;
    }
    public List<ItemVentasDia> VentasDia(DateTime fecha)
    {
      List<ItemVentasDia> results = new List<ItemVentasDia>();

      try {
        int idProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
        int idImpresora = Util.ObtenerParametroEntero("IdImpresora");

        List<EPK_Caja> cajas = context.EPK_Caja.ToList();

        results = context.EPK_Caja.Select(c => new ItemVentasDia {
          IdCaja = c.IdCaja,
          DescCaja = c.Descripcion,
          SerialMF = (c.EPK_CajaDispositivo.Count(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora) > 0 ?
                      c.EPK_CajaDispositivo.FirstOrDefault(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora).EPK_Dispositivo.Serial : "N/A"),
          RepZ = (c.EPK_CajaDispositivo.Count(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora) <= 0 ? "" :
                  (c.EPK_CajaDispositivo.FirstOrDefault(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora).
                   EPK_Dispositivo.EPK_CierreMaquinaFiscal.Count(cm => cm.Fecha == fecha.Date) <= 0 ? "" :
                   c.EPK_CajaDispositivo.FirstOrDefault(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora).
                   EPK_Dispositivo.EPK_CierreMaquinaFiscal.Where(cm => cm.Fecha == fecha.Date).
                   OrderByDescending(cm => cm.Hora).FirstOrDefault().ReporteZ)),
          MontoTotal = c.EPK_FacturaEncabezado.Where(fe => fe.IdEstatus == idProc && fe.Fecha == fecha.Date).Sum(fe => fe.MontoTotal) ?? 0,
          Porcent = 0
        }).OrderBy(r => r.DescCaja).ToList();

        int repZ = 0;
        foreach (ItemVentasDia item in results)
          if (int.TryParse(item.RepZ, out repZ))
            item.RepZ = repZ.ToString("0000");
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public List<ItemVentasDia> VentasDia()
    {
      DateTime currDate = this.FechaDB();
      return this.VentasDia(currDate);
    }
    #endregion Public Methods
  }
}