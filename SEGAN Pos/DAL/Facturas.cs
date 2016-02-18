using EntityFramework.Audit;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace SEGAN_POS.DAL
{
  #region Public Enums

  public enum TipoNC { No, Parcial, Total };

  #endregion Public Enums

  #region Data Types

  public class Cheque
  {
    public string DocumentoCliente { get; set; }

    public DateTime FechaVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdEntidad { get; set; }

    public int IdFactura { get; set; }

    public byte IdFormaPago { get; set; }

    public int IdPago { get; set; }

    public decimal Monto { get; set; }

    public string NombreCliente { get; set; }

    public string NombreEntidad { get; set; }

    public string NumeroCheque { get; set; }

    public bool Seleccionado { get; set; }

    public EPK_Cliente cliente { get; set; }
  }

  public class ItemsFactura
  {
    public int Cantidad { get; set; }

    public string CodigoArticulo { get; set; }

    public string DescRef { get; set; }

    public string Descripcion { get; set; }

    public bool Descuento { get; set; }

    public bool Devolucion { get; set; }

    public bool Exento { get; set; }

    public int IdArticulo { get; set; }

    public byte? IdMotivo { get; set; }

    public int IdReferencia { get; set; }

    public decimal MontoDescuento { get; set; }

    public decimal MontoIVA { get; set; }

    public decimal PrecioBase { get; set; }

    public decimal PrecioNeto { get; set; }

    public decimal PrecioVenta { get; set; }

    public bool AplicaRestriccion { get; set; }
  }

  public class ItemsPago
  {
    public string DescEntidad { get; set; }

    public string DescEntidadPOS { get; set; }

    public string DescFormaPago { get; set; }

    public string DescPOS { get; set; }

    public bool Efectivo { get; set; }

    public int? idEntidad { get; set; }

    public byte idFormaPago { get; set; }

    public int? idPago { get; set; }

    public int? idPOS { get; set; }

    public decimal Monto { get; set; }

    public string NumeroPago { get; set; }

    public int? idEntidadPOS { get; set; }
  }

  public class ListadoFacturas
  {
    public string DocCliente { get; set; }

    public string Estatus { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int idEstatus { get; set; }

    public int? IdFactura { get; set; }

    public int? IdFacturaEspera { get; set; }

    public decimal? MontoNC { get; set; }

    public decimal MontoTotal { get; set; }

    public string NombreCliente { get; set; }

    public int Numero { get; set; }

    public string SerialMF { get; set; }

    public string Ticket { get; set; }

    public int TieneNC { get; set; }

    public EPK_Empleados Cajero { get; set; }

    public string Vendedor { get; set; }

    public EPK_Cliente cliente { get; set; }
  }

  public class ListadoFacturasAnuladas
  {
    public string COO { get; set; }

    public int IdFactura { get; set; }

    public decimal MontoBase { get; set; }

    public decimal MontoExento { get; set; }

    public decimal MontoIVA { get; set; }

    public decimal MontoTotal { get; set; }

    public string SerialMF { get; set; }

    public string Ticket { get; set; }
  }

  #endregion Data Types

  public class Facturas : DataAccess
  {
      #region Constructor

      public Facturas(bool skip = false)
          : base(skip)
      {
      }

      #endregion Constructor

      #region Public Methods

      public bool Actualizar(int id, EPK_FacturaEncabezado factura)
      {
          bool result = false;

          try
          {
              AuditLogger audit = this.context.BeginAudit();

              DateTime currDate = this.FechaDB();

              int LongTF = Util.ObtenerParametroEntero("LONGTF");
              if (LongTF <= 0)
                  LongTF = 8;

              EPK_FacturaEncabezado facturaAct = this.Obtener(id);

              facturaAct.TicketFiscal = factura.TicketFiscal;

              if (facturaAct.TicketFiscal.Length < LongTF)
                  facturaAct.TicketFiscal = facturaAct.TicketFiscal.PadLeft(LongTF, '0');

              facturaAct.COO = factura.COO;
              facturaAct.SerialMF = factura.SerialMF;
              facturaAct.IdEstatus = factura.IdEstatus;
              facturaAct.NroReporteZ = factura.NroReporteZ;
              facturaAct.Fecha = factura.Fecha;
              facturaAct.Hora = factura.Hora;

              facturaAct.FechaModificacion = currDate;
              facturaAct.IdUsuarioModificacion = factura.IdUsuarioModificacion;

              this.context.SaveChanges();

              AuditLog log = audit.CreateLog();

              new NLogLogger().Info(string.Format("Factura #{0} actualizada por: {1}({2}). Datos: {3}", id,
                                    EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login, log.ToXml()));

              result = true;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = false;
          }

          return result;
      }

      public bool Anular(int id, int? idUsrMod)
      {
          bool result = false;

          try
          {
              DateTime currDate = this.FechaDB();

              EPK_FacturaEncabezado facturaAct = this.Obtener(id);

              //Si aplica la restricccion de ventas al mayor, y se anula una factura esta debe restarse de Clientes Compras
              if (EstadoAplicacion.RestriccionVentasMayor)
              {
                  List<ClienteCompra.ClienteComp> ListClienteCompra = new List<ClienteCompra.ClienteComp>();

                  foreach (EPK_FacturaDetalle ItemFact in facturaAct.EPK_FacturaDetalle)
                  {
                      if (ItemFact.EPK_Articulo.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta)
                      {
                          ListClienteCompra.Add(new ClienteCompra.ClienteComp
                          {
                              IdArticulo = ItemFact.IdArticulo,
                              Cantidad = (ItemFact.Cambio ? ItemFact.Cantidad : -1 * ItemFact.Cantidad),
                              NumeroDocumento = facturaAct.NumeroDocumento,
                              IdTipoDocumento = facturaAct.EPK_Cliente.IdTipoDocumento,
                              Devolucion = true // Se le asigna True porque para Nota de Credito se consideran las piexas como devoluciones
                          });
                      }

                      //Desbloquea el Articulo
                      if (ItemFact.Cantidad >= Util.ObtenerParametroEntero("MaximoArticulo"))
                          ItemFact.EPK_Articulo.FechaFinBloqueo = null;
                  }

                  new ClienteCompra().SaveCompras(ListClienteCompra);
              }

              facturaAct.IdEstatus = EstadoAplicacion.EstadosFactura["FACAnulada"];

              facturaAct.FechaModificacion = currDate;
              facturaAct.IdUsuarioModificacion = idUsrMod;

              context.SaveChanges();

              new NLogLogger().Info(string.Format("Factura #{0} anulada por: {1}({2}).", id,
                                    EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login));

              result = true;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = false;
          }

          return result;
      }

      public bool Anular(string COO, string TicketFiscal, int? idUsrMod)
      {
          bool result = false;

          try
          {
              DateTime currDate = this.FechaDB();

              EPK_FacturaEncabezado facturaAct = this.Obtener(COO, TicketFiscal);

              //Si aplica la restricccion de ventas al mayor, y se anula una factura esta debe restarse de Clientes Compras
              if (EstadoAplicacion.RestriccionVentasMayor)
              {
                  List<ClienteCompra.ClienteComp> ListClienteCompra = new List<ClienteCompra.ClienteComp>();

                  foreach (EPK_FacturaDetalle ItemFact in facturaAct.EPK_FacturaDetalle)
                  {
                      if (ItemFact.EPK_Articulo.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta)
                      {
                          ListClienteCompra.Add(new ClienteCompra.ClienteComp
                          {
                              IdArticulo = ItemFact.IdArticulo,
                              Cantidad = (ItemFact.Cambio ? ItemFact.Cantidad : -1 * ItemFact.Cantidad),
                              NumeroDocumento = facturaAct.NumeroDocumento,
                              IdTipoDocumento = facturaAct.EPK_Cliente.IdTipoDocumento,
                              Devolucion = true // Se le asigna True porque para Nota de Credito se consideran las piexas como devoluciones
                          });

                          //Desbloquea el Articulo
                          if (ItemFact.Cantidad >= Util.ObtenerParametroEntero("MaximoArticulo"))
                            ItemFact.EPK_Articulo.FechaFinBloqueo = null;
                      }
                  }

                  new ClienteCompra().SaveCompras(ListClienteCompra);
              }

              facturaAct.IdEstatus = EstadoAplicacion.EstadosFactura["FACAnulada"];

              facturaAct.FechaModificacion = currDate;
              facturaAct.IdUsuarioModificacion = idUsrMod;

              context.SaveChanges();

              new NLogLogger().Info(string.Format("Factura #{0} anulada por: {1}({2}).", facturaAct.IdFactura,
                                    EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login));

              result = true;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = false;
          }

          return result;
      }

      public decimal BuscarPagosCheque(DateTime? feIni, DateTime? feFin)
      {
          decimal result = 0;

          try
          {
              int idCheque = Util.ObtenerParametroEntero("IDCHEQUE");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              DateTime? fechaFin = null;
              if (feFin.HasValue)
                  fechaFin = feFin.Value.Date.AddDays(1).Date;

              result = context.EPK_FacturaPago.Where(fp => fp.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                fp.IdFormaPago == idCheque &&
                (feIni.HasValue ? (fp.EPK_FacturaEncabezado.FechaCreacion >= feIni) : true) &&
                (fechaFin.HasValue ? (fp.EPK_FacturaEncabezado.FechaCreacion <= fechaFin) : true)).Sum(fp => fp.Monto);
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return result;
      }

      public decimal BuscarPagosEfectivo(DateTime? feIni, DateTime? feFin)
      {
          decimal result = 0;

          try
          {
              int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              DateTime? fechaFin = null;
              if (feFin.HasValue)
                  fechaFin = feFin.Value.Date.AddDays(1).Date;

              result = context.EPK_FacturaPago.Where(fp => fp.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                fp.IdFormaPago == idEfectivo &&
                (feIni.HasValue ? (fp.EPK_FacturaEncabezado.FechaCreacion >= feIni) : true) &&
                (fechaFin.HasValue ? (fp.EPK_FacturaEncabezado.FechaCreacion <= fechaFin) : true)).Sum(fp => (fp.Monto - fp.MontoVuelto));
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return result;
      }

      public List<Cheque> ChequesSinDepositar()
      {
          List<Cheque> results = new List<Cheque>();

          try
          {
              int idCheque = Util.ObtenerParametroEntero("IDCHEQUE");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              results = context.EPK_FacturaPago.Where(fp => fp.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                fp.IdFormaPago == idCheque && !fp.EPK_DepositoCheque.Any()).
                Select(fp => new Cheque
                {
                    IdPago = fp.IdPago,
                    IdFormaPago = fp.IdFormaPago,
                    FechaVenta = fp.EPK_FacturaEncabezado.FechaCreacion,
                    IdFactura = fp.EPK_FacturaEncabezado.IdFactura,
                    IdCliente = fp.EPK_FacturaEncabezado.IdCliente,
                    IdEntidad = fp.IdEntidad.Value,
                    NombreEntidad = fp.EPK_EntidadFinanciera.Nombre.Trim(),
                    NumeroCheque = fp.NumeroPago.Trim(),
                    Monto = fp.Monto,
                    Seleccionado = false,
                    cliente = fp.EPK_FacturaEncabezado.EPK_Cliente
                }).OrderBy(p=>p.FechaVenta).ToList();

              foreach (Cheque item in results)
              {
                  item.NombreCliente = Util.GenNomCliente(item.cliente, false);
                  item.DocumentoCliente = Util.GenDocCliente(item.cliente, false);
              }
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return results;
      }

      public List<ListadoFacturas> Consultar(int? Numero, DateTime feIni, DateTime feFin, string NumDoc, string SerialMF,
        decimal? montoDesde, decimal? montoHasta, int? idEstatus, int? idCaja, string nomCajero, bool? devol, bool? desc)
      {
          int idNCRechazada = EstadoAplicacion.EstadosNC["NCRechazada"];
          int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];
          
          List<ListadoFacturas> facturas = context.EPK_FacturaEncabezado.Where(fe =>
              (Numero.HasValue ? fe.IdFactura == Numero.Value : true) &&
              fe.Fecha >= feIni && fe.Fecha <= feFin &&
              (string.IsNullOrEmpty(NumDoc) ? true : fe.EPK_Cliente.NumeroDocumento.Equals(NumDoc, StringComparison.OrdinalIgnoreCase)) &&
              (string.IsNullOrEmpty(SerialMF) ? true : fe.SerialMF.Equals(SerialMF, StringComparison.OrdinalIgnoreCase)) &&
              (montoDesde.HasValue? (fe.MontoTotal >= montoDesde.Value) : true) &&
              (montoHasta.HasValue? (fe.MontoTotal <= montoHasta.Value) : true) &&
              (idEstatus.HasValue ? (fe.IdEstatus == idEstatus) : true) &&
              (idCaja.HasValue ? (fe.IdCaja == idCaja.Value) : true) &&
              (string.IsNullOrEmpty(nomCajero) ? true : (fe.EPK_Usuario.Identificacion.Contains(nomCajero))) &&
              (devol.HasValue ? (fe.EPK_FacturaDetalle.Count(det => det.Cambio == devol.Value) > 0) : true)  &&
              (desc.HasValue ? (fe.EPK_FacturaDetalle.Count(det => det.Descuento == desc.Value) > 0) : true)
            ).Select(fe => new ListadoFacturas
            {
                Numero = fe.IdFactura,
                Ticket = fe.TicketFiscal,
                IdFactura = fe.IdFactura,
                IdFacturaEspera = null,
                SerialMF   = fe.SerialMF,
                MontoTotal = (fe.MontoTotal.HasValue ? fe.MontoTotal.Value : 0),
                idEstatus  = fe.IdEstatus,
                Estatus    = fe.EPK_Estatus.Descripcion,
                FechaCreacion = fe.FechaCreacion,
                MontoNC  = ((fe.EPK_NotaCreditoEncabezado.Count() > 0 ? fe.EPK_NotaCreditoEncabezado.Where(nc => nc.IdEstatus == idNCEmitida).Sum(nc => nc.MontoTotal) : 0) +
                           (fe.EPK_NotaCreditoEsperaEncabezado.Where(nc => nc.IdEstatus != idNCRechazada && nc.IdEstatus != idNCEmitida).Count() > 0 ?
                           fe.EPK_NotaCreditoEsperaEncabezado.Where(nc => nc.IdEstatus != idNCRechazada && nc.IdEstatus != idNCEmitida).Sum(ne => ne.MontoTotal) : 0)),
                TieneNC  =  (int)TipoNC.Total,
                //Cajero   =  (context.EPK_Empleados.Where(e => e.IdUsuario == fe.IdUsuarioCreacion)),
                //Vendedor =  fe.EPK_Empleados.Nombre + " " + fe.EPK_Empleados.Apellido,
                cliente  =  fe.EPK_Cliente
            }).ToList();

          foreach (ListadoFacturas item in facturas)
          {
              if (item.MontoNC == 0)
              {
                  item.TieneNC = (int)TipoNC.No;
                  continue;
              }
              if (item.MontoTotal > item.MontoNC)
              {
                  item.TieneNC = (int)TipoNC.Parcial;
                  continue;
              }
              if (item.MontoTotal == item.MontoNC)
              {
                  item.TieneNC = (int)TipoNC.Total;
                  continue;
              }
          }

          List<ListadoFacturas> facturasEspera = new List<ListadoFacturas>();

          if (string.IsNullOrEmpty(SerialMF))
          {
              facturasEspera = context.EPK_FacturaEsperaEncabezado.Where(fe =>
                  (Numero.HasValue ? fe.IdFacturaEspera == Numero.Value : true) &&
                  fe.Fecha >= feIni && fe.Fecha <= feFin &&
                  (string.IsNullOrEmpty(NumDoc) ? true : fe.EPK_Cliente.NumeroDocumento.Equals(NumDoc, StringComparison.OrdinalIgnoreCase)) &&
                  (montoDesde.HasValue? (fe.MontoTotal >= montoDesde.Value) : true) &&
                  (montoHasta.HasValue? (fe.MontoTotal <= montoHasta.Value) : true) &&
                  (idEstatus.HasValue ? (fe.IdEstatus == idEstatus) : true) &&
                  (idCaja.HasValue ? (fe.IdCaja == idCaja.Value) : true) &&
                  (string.IsNullOrEmpty(nomCajero) ? true : (fe.EPK_Usuario.Identificacion.Contains(nomCajero))) &&
                  (devol.HasValue ? (fe.EPK_FacturaEsperaDetalle.Count(det => det.Cambio == devol.Value) > 0) : true) &&
                  (desc.HasValue ? (fe.EPK_FacturaEsperaDetalle.Count(det => det.Descuento == desc.Value) > 0) : true)
                ).Select(fe => new ListadoFacturas
                {
                    Numero = fe.IdFacturaEspera,
                    IdFactura = null,
                    IdFacturaEspera = fe.IdFacturaEspera,
                    SerialMF = "",
                    MontoTotal = fe.MontoTotal,
                    idEstatus = fe.IdEstatus,
                    Estatus = fe.EPK_Estatus.Descripcion,
                    FechaCreacion = fe.FechaCreacion,
                    MontoNC = 0,
                    TieneNC = (int)TipoNC.Total,
                    cliente = fe.EPK_Cliente
                }).ToList();
          }

          List<ListadoFacturas> results = facturas.Union(facturasEspera).ToList();

          foreach (ListadoFacturas item in results)
          {
              item.NombreCliente = Util.GenNomCliente(item.cliente, false);
              item.DocCliente = Util.GenDocCliente(item.cliente, false);
          }

          return results.OrderByDescending(r => r.FechaCreacion).ToList();
      }

      public List<ListadoFacturas> Consultar(int numeroBase, int? numero, string numDoc)
      {
          int idNCRechazada = EstadoAplicacion.EstadosNC["NCRechazada"];
          int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

          List<ListadoFacturas> facturas = context.EPK_FacturaEncabezado.Where(fe => fe.IdFactura > numeroBase && fe.IdEstatus == idFaCProc &&
              (fe.EPK_NotaCreditoEncabezado.Count() +
               fe.EPK_NotaCreditoEsperaEncabezado.Where(nc => nc.IdEstatus != idNCRechazada).Count()) == 0 &&
              (numero.HasValue ? fe.IdFactura == numero.Value : true) &&
              (string.IsNullOrEmpty(numDoc) ? true : fe.EPK_Cliente.NumeroDocumento.Equals(numDoc, StringComparison.OrdinalIgnoreCase))
            ).Select(fe => new ListadoFacturas
            {
                Numero = fe.IdFactura,
                Ticket = fe.TicketFiscal,
                IdFactura = fe.IdFactura,
                IdFacturaEspera = null,
                SerialMF = fe.SerialMF,
                MontoTotal = (fe.MontoTotal.HasValue ? fe.MontoTotal.Value : 0),
                idEstatus = fe.IdEstatus,
                Estatus = fe.EPK_Estatus.Descripcion,
                FechaCreacion = fe.FechaCreacion,
                cliente = fe.EPK_Cliente,
            }).ToList();

          List<ListadoFacturas> results = facturas.ToList();

          foreach (ListadoFacturas item in results)
          {
              item.NombreCliente = Util.GenNomCliente(item.cliente, false);
              item.DocCliente = Util.GenDocCliente(item.cliente, false);
          }

          return results.OrderByDescending(r => r.FechaCreacion).ToList();
      }

      public List<ListadoFacturasAnuladas> ConsultarAnuladas(DateTime feIni, DateTime feFin)
      {
          int idFacAnul = EstadoAplicacion.EstadosFactura["FACAnulada"];

          List<ListadoFacturasAnuladas> facturas = context.EPK_FacturaEncabezado.Where(fe =>
              fe.FechaCreacion >= feIni && fe.FechaCreacion <= feFin && fe.IdEstatus == idFacAnul).
              Select(fe => new ListadoFacturasAnuladas
              {
                  IdFactura = fe.IdFactura,
                  Ticket = fe.TicketFiscal,
                  COO = fe.COO,
                  SerialMF = fe.SerialMF,
                  MontoBase = (fe.MontoBase.HasValue ? fe.MontoBase.Value : 0),
                  MontoExento = (fe.EPK_FacturaDetalle.Any(p=>p.Exento)? fe.EPK_FacturaDetalle.Where(p=>p.Exento).Sum(p=>p.Precio) : 0),
                  MontoIVA = fe.MontoIVA,
                  MontoTotal = (fe.MontoTotal.HasValue ? fe.MontoTotal.Value : 0)
              }).ToList();

          List<ListadoFacturasAnuladas> results = facturas.ToList();

          return results.OrderByDescending(r => r.IdFactura).ToList();
      }

      public bool HayChequesSinDepositar()
      {
          bool result = false;

          try
          {
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              result = context.EPK_FacturaPago.Count(fp => fp.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                fp.EPK_FormaPago.DatosBanco && !fp.EPK_FormaPago.DatosPOS && fp.EPK_DepositoCheque.FirstOrDefault() == null) > 0;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return result;
      }

      public decimal MontoEfectivo(int idUsuario, DateTime fechaIni, DateTime fechaFin)
      {
          try
          {
              int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              return context.EPK_FacturaPago.Where(p => p.EPK_FacturaEncabezado.Fecha >= fechaIni.Date && p.EPK_FacturaEncabezado.Fecha <= fechaFin.Date &&
                (idUsuario > 0 ? p.EPK_FacturaEncabezado.IdUsuarioCreacion == idUsuario : true) &&
                p.IdFormaPago == idEfectivo && p.EPK_FacturaEncabezado.IdEstatus == idFaCProc).Sum(q => (q.Monto - q.MontoVuelto));
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              return 0;
          }
      }

      public decimal MontoEfectivo(DateTime fechaIni, DateTime fechaFin)
      {
          return this.MontoEfectivo(0, fechaIni, fechaFin);
      }

      public decimal MontoEfectivo(int idUsuario)
      {
          try
          {
              int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              EPK_CierreCajeroEncabezado ultimoCierre = new CierreCajero().ObtenerUltimo(idUsuario);

              DateTime? fechaIni = null;

              if (ultimoCierre != null)
                  fechaIni = ultimoCierre.Fecha + ultimoCierre.Hora;

              decimal? result = context.EPK_FacturaPago.Where(p => p.IdFormaPago == idEfectivo && p.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                                p.EPK_FacturaEncabezado.IdUsuarioCreacion == idUsuario &&
                                (fechaIni.HasValue ? (p.EPK_FacturaEncabezado.FechaCreacion > fechaIni) : true)).
                                Sum(q => ((decimal?)q.Monto - (decimal?)q.MontoVuelto));

              if (result.HasValue)
                  return result.Value;
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

      public decimal MontoPendiente(int idUsuario, DateTime? fechaIni)
      {
          decimal? result = null;

          try
          {
              int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              DateTime? fechaFin = null;
              if (fechaIni.HasValue)
                  fechaFin = fechaIni.Value.Date.AddDays(1).Date;

              result = context.EPK_FacturaPago.Where(p => p.EPK_FacturaEncabezado.IdUsuarioCreacion == idUsuario &&
                p.IdFormaPago == idEfectivo && p.EPK_FacturaEncabezado.IdEstatus == idFaCProc &&
                (fechaIni.HasValue ? (p.EPK_FacturaEncabezado.FechaCreacion >= fechaIni.Value) : true) &&
                (fechaFin.HasValue ? (p.EPK_FacturaEncabezado.FechaCreacion < fechaFin.Value) : true)
                ).Sum(q => (q.Monto - q.MontoVuelto));
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = null;
          }

          return result ?? 0;
      }

      public int Nueva(EPK_FacturaEncabezado factura)
      {
          int result = 0;

          try
          {
              EPK_Cliente clienteActual = new Clientes().Obtener(factura.IdCliente);

              factura.IdTipoDocumento = clienteActual.IdTipoDocumento;
              factura.NumeroDocumento = clienteActual.NumeroDocumento;

              foreach (EPK_FacturaDetalle item in factura.EPK_FacturaDetalle)
                  item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

              foreach (EPK_FacturaPago item in factura.EPK_FacturaPago)
                  item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

              DateTime currDate = this.FechaDB();

              factura.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
              factura.FechaCreacion = currDate;
              factura.Fecha = currDate.Date;
              factura.Hora = currDate.TimeOfDay;

              factura.IdEstatus = EstadoAplicacion.EstadosFactura["FACCreada"];

              foreach (EPK_FacturaPago item in factura.EPK_FacturaPago)
                  item.FechaCreacion = factura.Fecha;

              context.EPK_FacturaEncabezado.Add(factura);
              context.SaveChanges();

              new NLogLogger().Info(string.Format("Factura #{0} creada por: {1}({2}).", factura.IdFactura,
                                    EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login));

              if (EstadoAplicacion.PermitirContingencia && factura.IdFactura > 0)
              {
                  Util.SetAppSettingsValue("UltimaFactura", factura.IdFactura.ToString(), false);
                  if (factura.EPK_FacturaPago != null && factura.EPK_FacturaPago.Count() > 0)
                  {
                      int ultPago = factura.EPK_FacturaPago.Max(fp => fp.IdPago);
                      Util.SetAppSettingsValue("UltimoPago", ultPago.ToString(), false);
                  }
              }

              result = factura.IdFactura;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return result;
      }

      public EPK_FacturaEncabezado Obtener(int id)
      {
          return context.EPK_FacturaEncabezado.FirstOrDefault(fe => fe.IdFactura == id);
      }

      public EPK_FacturaEncabezado Obtener(string COO, string TicketFiscal)
      {
          return context.EPK_FacturaEncabezado.FirstOrDefault(fe => fe.COO == COO && fe.TicketFiscal == TicketFiscal);
      }

      public int ObtenerConteo(int idMF, DateTime fecha)
      {
          int result = 0;

          try
          {
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              DateTime fechaFin = fecha.Date.AddDays(1).Date;

              result = context.EPK_FacturaEncabezado.Where(f => f.IdEstatus == idFaCProc && f.Fecha >= fecha.Date &&
                f.Fecha < fechaFin &&
                f.EPK_Caja.EPK_CajaDispositivo.Where(cd => cd.IdDispositivo == idMF).Count() > 0).Count();
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return result;
      }

      public IEnumerable<EPK_FacturaPago> ObtenerPagos(int idFactura)
      {
          return context.EPK_FacturaPago.Where(p => p.IdFactura == idFactura).ToList();
      }

      public EPK_FacturaEncabezado ObtenerPrimera(int idUsuario, DateTime? fechaIni)
      {
          try
          {
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              return context.EPK_FacturaEncabezado.Where(f => f.IdUsuarioCreacion == idUsuario &&
                f.IdEstatus == idFaCProc &&
                (fechaIni.HasValue ? (f.FechaCreacion > fechaIni.Value) : true)).OrderBy(f => f.IdFactura).FirstOrDefault();
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return null;
      }

      public IEnumerable<EPK_FacturaEncabezado> ObtenerTodas(EPK_FacturaEncabezado _search)
      {
          try
          {
              return context.EPK_FacturaEncabezado.Where(p => p.IdUsuarioCreacion ==
                (_search.IdUsuarioCreacion == 0 ? p.IdUsuarioCreacion : _search.IdUsuarioCreacion) &&
                p.IdCaja == (_search.IdCaja == 0 ? p.IdCaja : _search.IdCaja) &&
                (_search.FechaCreacion != DateTime.MinValue ? p.FechaCreacion >= _search.FechaCreacion : true)).ToList();
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return null;
      }

      public List<EPK_FacturaEncabezado> ObtenerTodas(int idUsuario, DateTime? fechaIni)
      {
          try
          {
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              DateTime? fechaFin = null;
              if (fechaIni.HasValue)
                  fechaFin = fechaIni.Value.Date.AddDays(1).Date;

              return context.EPK_FacturaEncabezado.Where(f => f.IdUsuarioCreacion == idUsuario &&
                f.IdEstatus == idFaCProc &&
                (fechaIni.HasValue ? (f.FechaCreacion >= fechaIni.Value) : true) &&
                (fechaFin.HasValue ? (f.FechaCreacion < fechaFin.Value) : true)).ToList();
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return null;
      }

      public EPK_FacturaEncabezado ObtenerUltima(int idUsuario, DateTime? fechaFin)
      {
          try
          {
              int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

              return context.EPK_FacturaEncabezado.Where(f => f.IdUsuarioCreacion == idUsuario &&
                f.IdEstatus == idFaCProc &&
                (fechaFin.HasValue ? (f.FechaCreacion < fechaFin.Value) : true)).OrderByDescending(f => f.IdFactura).FirstOrDefault();
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return null;
      }

      public int ObtenerUltimoId()
      {
          try
          {
              return this.context.EPK_FacturaEncabezado.Max(f => f.IdFactura);
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return 0;
      }

      public int ObtenerUltimoId(int idCaja)
      {
          try
          {
              return this.context.EPK_FacturaEncabezado.Where(f => f.IdCaja == idCaja).Max(f => f.IdFactura);
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return 0;
      }

      public int ObtenerUltimoIdPago()
      {
          try
          {
              return this.context.EPK_FacturaPago.Max(fp => fp.IdPago);
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return 0;
      }

      public int ObtenerUltimoIdPago(int idCaja)
      {
          try
          {
              return this.context.EPK_FacturaPago.Where(fp => fp.EPK_FacturaEncabezado.IdCaja == idCaja).Max(fp => fp.IdPago);
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return 0;
      }

      public bool ReSeed(int id)
      {
          if (id <= 0)
              return false;

          try
          {
              this.context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})",
                "EPK_FacturaEncabezado", id.ToString()));

              return true;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return false;
      }

      public bool ReSeedPago(int id)
      {
          if (id <= 0)
              return false;

          try
          {
              this.context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})",
                "EPK_FacturaPago", id.ToString()));

              return true;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
          }

          return false;
      }

      public TipoNC TieneNC(int id)
      {
          TipoNC result = TipoNC.Total;

          try
          {
              int NCRechazada = EstadoAplicacion.EstadosNC["NCRechazada"];
              int NCAnulada = EstadoAplicacion.EstadosNC["NCAnulada"];

              EPK_FacturaEncabezado factura = this.Obtener(id);

              decimal MontoNC = ((factura.EPK_NotaCreditoEncabezado.Where(nc => nc.IdEstatus != NCAnulada && nc.IdEstatus != NCRechazada).Count() > 0 ? factura.EPK_NotaCreditoEncabezado.Sum(nc => nc.MontoTotal) : 0));

              if (MontoNC == 0)
                  result = TipoNC.No;
              else if (factura.MontoTotal > MontoNC)
                  result = TipoNC.Parcial;
              else if (factura.MontoTotal == MontoNC)
                  result = TipoNC.Total;
          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = TipoNC.Total;
          }

          return result;
      }

      public bool TieneSolicitudNC(int idFactura, int idTienda)
      {
          bool result = false;

          try
          {
              int NCRechazada = EstadoAplicacion.EstadosNC["NCRechazada"];
              int NCAnulada = EstadoAplicacion.EstadosNC["NCAnulada"];

              result = context.EPK_NotaCreditoEsperaEncabezado.Any(p => p.IdFactura == idFactura && p.IdTienda == idTienda && p.IdEstatus != NCRechazada && p.IdEstatus != NCAnulada);

          }
          catch (Exception ex)
          {
              new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
                "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

              result = true;
          }

          return result;
      }

      public List<string> ObtenerRepZ(DateTime fecha, string serialMF)
      {
          int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

          return this.context.EPK_FacturaEncabezado.Where(fe => fe.Fecha == fecha.Date && fe.SerialMF == serialMF && fe.IdEstatus == idFaCProc).
            Select(fe => fe.NroReporteZ).Distinct().ToList();
      }

      public bool TieneDevoluciones(byte IdTipoDocumento, string NumeroDocumento)
      {
          int idFaCProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
          int PeridoValidacion = Util.ObtenerParametroEntero("DiasRestriccion");
          DateTime DiaRestriccion = DateTime.Now.Date.AddDays(-PeridoValidacion);

          int result = this.context.EPK_FacturaEncabezado.Where(fe => fe.FechaCreacion >= DiaRestriccion && fe.IdEstatus == idFaCProc &&
                                                                      fe.EPK_Cliente.IdTipoDocumento == IdTipoDocumento && fe.EPK_Cliente.NumeroDocumento == NumeroDocumento &&
                                                                      fe.EPK_FacturaDetalle.Any(a => a.Cambio)).Count();
          return result > 0 ? true : false;
      }

      public bool TieneObsequio(string codarticulo)
      {         
         
          using (var entities = new SEGANPOSEntities())
          {
           
             var result = new System.Data.Entity.Core.Objects.ObjectParameter("Result", 0);

             int results = this.context.EPK_sp_ValidarArticuloObsequio(codarticulo, result);
       
              string result_string = result.Value.ToString();

              return bool.Parse(result_string);
           
          }


     
        }

  

      #endregion Public Methods
  }
}