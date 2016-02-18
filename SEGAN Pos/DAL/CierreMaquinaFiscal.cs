using System;
using System.Linq;
using System.Windows.Forms;

namespace SEGAN_POS.DAL
{
  #region Data Types

  public class DatosCierre
  {
    public DatosFacturasCierre FacturasCierre { get; set; }

    public DatosNCsCierre NCsCierre { get; set; }
  }

  public class DatosFacturasCierre
  {
    public string FacturaDesde { get; set; }

    public string FacturaHasta { get; set; }

    public int? CantidadFacturas { get; set; }

    public decimal? BaseImponibleFact { get; set; }

    public decimal? ExentoFact { get; set; }

    public decimal? ImpuestoFact { get; set; }

    public decimal? DescuentoFact { get; set; }

    public decimal MontoTotalFact { get; set; }
  }

  public class DatosNCsCierre
  {
    public string NCDesde { get; set; }

    public string NCHasta { get; set; }

    public int? CantidadNC { get; set; }

    public decimal? BaseImponibleNC { get; set; }

    public decimal? ExentoNC { get; set; }

    public decimal? ImpuestoNC { get; set; }

    public decimal? DescuentoNC { get; set; }

    public decimal? MontoTotalNC { get; set; }
  }

  #endregion Data Types

  internal class CierreMaquinaFiscal : DataAccess
  {
    #region Public Methods

    public bool Guardar(int idMaquina, DateTime fecha, TimeSpan hora, string nroReporteZ, DatosReduccionZ datosRepZ)
    {
      if (idMaquina <= 0)
        return false;

      if (datosRepZ == null)
        return false;

      try {
        int idFacProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

        EPK_Dispositivo maquina = new Dispositivos().Obtener(idMaquina);

        if (maquina == null)
          return false;

        if (string.IsNullOrEmpty(nroReporteZ)) {
          EPK_FacturaEncabezado ultimaFact = this.context.EPK_FacturaEncabezado.Where(fe => fe.Fecha == fecha && fe.IdEstatus == idFacProc &&
            fe.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).OrderByDescending(fe => fe.IdFactura).FirstOrDefault();

          if (ultimaFact != null)
            nroReporteZ = ultimaFact.NroReporteZ;
        }

        EPK_CierreMaquinaFiscal cierreMaq = new EPK_CierreMaquinaFiscal();
         
        cierreMaq.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
        cierreMaq.IdMaquina = idMaquina;

        if (datosRepZ.FechaOperacion != null)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            cierreMaq.Fecha = DateTime.Parse(datosRepZ.FechaOperacion, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }
        else 
        {
            cierreMaq.Fecha = fecha;
        }

        DatosCierre datosCierre = this.ObtenerDatos(idMaquina, cierreMaq.Fecha, hora, nroReporteZ);

        if (datosCierre == null)
            return false;

        cierreMaq.Hora = hora;
        cierreMaq.ReporteZ = nroReporteZ;
        cierreMaq.FacturaDesde = this.context.EPK_CierreMaquinaFiscal.Where(fe => fe.EPK_Dispositivo.IdDispositivo == idMaquina).
        OrderByDescending(f => f.IdCierreMF).Select(g => g.FacturaHasta).FirstOrDefault();

        cierreMaq.FacturaHasta = cierreMaq.FacturaDesde;

        cierreMaq.CantidadFacturas = 0;
        cierreMaq.BaseImponibleFact = cierreMaq.ExentoFact = cierreMaq.ImpuestoFact = cierreMaq.DescuentoFact = cierreMaq.MontoTotalFact = 0;

        cierreMaq.CantidadNC = 0;
        cierreMaq.BaseImponibleNC = cierreMaq.ExentoNC = cierreMaq.ImpuestoNC = cierreMaq.DescuentoNC = cierreMaq.MontoTotalNC = 0;

        int LongTF = Util.ObtenerParametroEntero("LONGTF");
        if (LongTF <= 0)
          LongTF = 8;

        string str = "";
        str = str.PadLeft(LongTF, '0');

        cierreMaq.NCDesde = str;
        cierreMaq.NCHasta = str;

        if (datosCierre.FacturasCierre != null) {
            cierreMaq.FacturaDesde = datosCierre.FacturasCierre.FacturaDesde.PadLeft(8 - datosCierre.FacturasCierre.FacturaDesde.Length, '0'); //datosCierre.FacturasCierre.FacturaDesde;
            cierreMaq.FacturaHasta = datosCierre.FacturasCierre.FacturaHasta.PadLeft(8 - datosCierre.FacturasCierre.FacturaHasta.Length, '0'); //datosCierre.FacturasCierre.FacturaHasta;
          cierreMaq.CantidadFacturas = datosCierre.FacturasCierre.CantidadFacturas;
          cierreMaq.BaseImponibleFact = datosCierre.FacturasCierre.BaseImponibleFact;
          cierreMaq.ExentoFact = datosCierre.FacturasCierre.ExentoFact;
          cierreMaq.ImpuestoFact = datosCierre.FacturasCierre.ImpuestoFact;
          cierreMaq.DescuentoFact = datosCierre.FacturasCierre.DescuentoFact;
          cierreMaq.MontoTotalFact = datosCierre.FacturasCierre.MontoTotalFact;
        }
        if (datosCierre.NCsCierre != null) {
          if (datosCierre.NCsCierre.MontoTotalNC > 0) {
            cierreMaq.NCDesde = datosCierre.NCsCierre.NCDesde;
            cierreMaq.NCHasta = datosCierre.NCsCierre.NCHasta;
          }
          cierreMaq.CantidadNC = datosCierre.NCsCierre.CantidadNC;
          cierreMaq.BaseImponibleNC = datosCierre.NCsCierre.BaseImponibleNC;
          cierreMaq.ExentoNC = datosCierre.NCsCierre.ExentoNC;
          cierreMaq.ImpuestoNC = datosCierre.NCsCierre.ImpuestoNC;
          cierreMaq.DescuentoNC = datosCierre.NCsCierre.DescuentoNC;
          cierreMaq.MontoTotalNC = datosCierre.NCsCierre.MontoTotalNC;
        }

        cierreMaq.COO = datosRepZ.COO;
        cierreMaq.FacturaDesdeZ = datosRepZ.PrimerTicketF;
        cierreMaq.FacturaHastaZ = datosRepZ.UltimoTicketF;
        cierreMaq.TotalFactZ = datosRepZ.VentaBruta;
        cierreMaq.DescuentoFactZ = datosRepZ.Descuentos;
        cierreMaq.BaseImponibleFactZ = datosRepZ.BaseTributados;
        cierreMaq.ImpuestoFactZ = datosRepZ.IVATributados;
        cierreMaq.ExentoFactZ = datosRepZ.Exentos;
        cierreMaq.BaseImponibleNCZ = datosRepZ.BaseNotasCredito;
        cierreMaq.ExentoNCZ = datosRepZ.ExentosNC;
        cierreMaq.ImpuestoNCZ = datosRepZ.IVANotasCredito;
        cierreMaq.TotalNCZ = datosRepZ.NotasCredito;
        cierreMaq.CantidadFacturasZ = datosRepZ.CantidadFacturas;
        cierreMaq.Zrestantes = datosRepZ.Zrestantes;
        cierreMaq.Manual = datosRepZ.Manual;
        cierreMaq.FechaCreacion = DateTime.Now;
        this.context.EPK_CierreMaquinaFiscal.Add(cierreMaq);
        var result = this.context.EPK_CierreMaquinaFiscal.Where(cmf => cmf.ReporteZ == cierreMaq.ReporteZ && cmf.EPK_Dispositivo.IdDispositivo == cierreMaq.IdMaquina);
       if (result.Count() > 0)    
       {
           MessageBox.Show(Properties.Resources.ErrorCierreMFExiste);
          return false;
           }
        //    return;
            //        select * 
            //from epk_cierremaquinafiscal cmf
            //inner join epk_dispositivo d
            //    on cmf.IdMaquina = d.IdDispositivo
            //    and cmf.ReporteZ ='0392'
            //    and d.serial ='1FC2308850'

        this.context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    public bool Guardar(int idMaquina, string nroReporteZ, DatosReduccionZ datosRepZ)
    {
      if (idMaquina <= 0)
        return false;

      if (datosRepZ == null)
        return false;

      try {
        int idFacProc = EstadoAplicacion.EstadosFactura["FACProcesada"];

        EPK_Dispositivo maquina = new Dispositivos().Obtener(idMaquina);

        if (maquina == null)
          return false;

        EPK_FacturaEncabezado ultimaFact = this.context.EPK_FacturaEncabezado.Where(fe => fe.NroReporteZ == nroReporteZ && fe.IdEstatus == idFacProc &&
          fe.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).OrderByDescending(fe => fe.IdFactura).FirstOrDefault();

        DateTime fecha = ultimaFact.Fecha;
        TimeSpan hora = ultimaFact.Hora;

        DatosCierre datosCierre = this.ObtenerDatos(idMaquina, nroReporteZ);

        if (datosCierre == null)
          return false;

        EPK_CierreMaquinaFiscal cierreMaq = new EPK_CierreMaquinaFiscal();

        cierreMaq.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
        cierreMaq.IdMaquina = idMaquina;
        cierreMaq.Fecha = fecha;
        cierreMaq.Hora = hora;
        cierreMaq.ReporteZ = nroReporteZ;

         
         cierreMaq.FacturaDesde = this.context.EPK_CierreMaquinaFiscal.Where(fe => fe.EPK_Dispositivo.IdDispositivo == idMaquina).
         OrderByDescending(f => f.IdCierreMF).Select(g => g.FacturaHasta).FirstOrDefault();

        cierreMaq.FacturaHasta = cierreMaq.FacturaDesde;

        cierreMaq.CantidadFacturas = 0;
        cierreMaq.BaseImponibleFact = cierreMaq.ExentoFact = cierreMaq.ImpuestoFact = cierreMaq.DescuentoFact = cierreMaq.MontoTotalFact = 0;

        cierreMaq.CantidadNC = 0;
        cierreMaq.BaseImponibleNC = cierreMaq.ExentoNC = cierreMaq.ImpuestoNC = cierreMaq.DescuentoNC = cierreMaq.MontoTotalNC = 0;

        int LongTF = Util.ObtenerParametroEntero("LONGTF");
        if (LongTF <= 0)
          LongTF = 8;

        string str = "";
        str = str.PadLeft(LongTF, '0');

        cierreMaq.NCDesde = str;
        cierreMaq.NCHasta = str;

        if (datosCierre.FacturasCierre != null) {
          //cierreMaq.FacturaDesde = datosCierre.FacturasCierre.FacturaDesde;
          cierreMaq.FacturaDesde = datosCierre.FacturasCierre.FacturaDesde.PadLeft(8 - (datosCierre.FacturasCierre.FacturaDesde).Length, '0');
          //cierreMaq.FacturaHasta = datosCierre.FacturasCierre.FacturaHasta;
          cierreMaq.FacturaHasta = datosCierre.FacturasCierre.FacturaHasta.PadLeft(8 - (datosCierre.FacturasCierre.FacturaHasta).Length, '0');
          cierreMaq.CantidadFacturas = datosCierre.FacturasCierre.CantidadFacturas;
          cierreMaq.BaseImponibleFact = datosCierre.FacturasCierre.BaseImponibleFact;
          cierreMaq.ExentoFact = datosCierre.FacturasCierre.ExentoFact;
          cierreMaq.ImpuestoFact = datosCierre.FacturasCierre.ImpuestoFact;
          cierreMaq.DescuentoFact = datosCierre.FacturasCierre.DescuentoFact;
          cierreMaq.MontoTotalFact = datosCierre.FacturasCierre.MontoTotalFact;
        }
        if (datosCierre.NCsCierre != null) {
          if (datosCierre.NCsCierre.MontoTotalNC > 0) {
            cierreMaq.NCDesde = datosCierre.NCsCierre.NCDesde;
            cierreMaq.NCHasta = datosCierre.NCsCierre.NCHasta;
          }
          cierreMaq.CantidadNC = datosCierre.NCsCierre.CantidadNC;
          cierreMaq.BaseImponibleNC = datosCierre.NCsCierre.BaseImponibleNC;
          cierreMaq.ExentoNC = datosCierre.NCsCierre.ExentoNC;
          cierreMaq.ImpuestoNC = datosCierre.NCsCierre.ImpuestoNC;
          cierreMaq.DescuentoNC = datosCierre.NCsCierre.DescuentoNC;
          cierreMaq.MontoTotalNC = datosCierre.NCsCierre.MontoTotalNC;
        }

        cierreMaq.COO = datosRepZ.COO;
        cierreMaq.FacturaDesdeZ = datosRepZ.PrimerTicketF;
        cierreMaq.FacturaHastaZ = datosRepZ.UltimoTicketF;
        cierreMaq.TotalFactZ = datosRepZ.VentaBruta;
        cierreMaq.DescuentoFactZ = datosRepZ.Descuentos;
        cierreMaq.TotalNCZ = datosRepZ.NotasCredito;
        cierreMaq.BaseImponibleFactZ = datosRepZ.BaseTributados;
        cierreMaq.ImpuestoFactZ = datosRepZ.IVATributados;
        cierreMaq.ExentoFactZ = datosRepZ.Exentos;
        cierreMaq.BaseImponibleNCZ = datosRepZ.BaseNotasCredito;
        cierreMaq.ImpuestoNCZ = datosRepZ.IVANotasCredito;
        cierreMaq.ExentoNCZ = datosRepZ.ExentosNC;
        cierreMaq.CantidadFacturasZ = datosRepZ.CantidadFacturas;
        cierreMaq.Zrestantes = datosRepZ.Zrestantes;

        this.context.EPK_CierreMaquinaFiscal.Add(cierreMaq);
        this.context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    public EPK_CierreMaquinaFiscal Obtener(int idMaquina, DateTime fecha)
    {
      return this.context.EPK_CierreMaquinaFiscal.FirstOrDefault(c => c.IdMaquina == idMaquina && c.Fecha == fecha.Date);
    }

    public EPK_CierreMaquinaFiscal Obtener(int idMaquina, string reporteZ)
    {
      return this.context.EPK_CierreMaquinaFiscal.FirstOrDefault(c => c.IdMaquina == idMaquina && c.ReporteZ == reporteZ);
    }

    public DatosCierre ObtenerDatos(int idMaquina, DateTime fecha, TimeSpan hora, string nroReporteZ)
    {         
        DatosCierre result = null;

        if (idMaquina <= 0)
            return result;

        try
        {
            EPK_Dispositivo maquina = new Dispositivos().Obtener(idMaquina);

            if (maquina == null)
                return result;

            int idFacProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
            int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];

            var MaxMin = this.context.EPK_FacturaEncabezado.Where(fe => fe.Fecha == fecha && fe.NroReporteZ == nroReporteZ &&
            fe.IdEstatus == idFacProc && fe.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).
            GroupBy(gb => gb.NroReporteZ).Select(y => new
            {
                FactD = y.Min(g => g.TicketFiscal),
                FactH = y.Max(g => g.TicketFiscal)
            }).FirstOrDefault();

            int FactD, FactH = 0;

            int.TryParse(MaxMin != null ? MaxMin.FactD : " ", out FactD);
            int.TryParse(MaxMin != null ? MaxMin.FactH : " ", out FactH);

            var FactEnc = this.context.EPK_FacturaEncabezado.Where(fe => fe.Fecha == fecha && fe.NroReporteZ == nroReporteZ &&
              fe.IdEstatus == idFacProc && fe.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).
              GroupBy(gb => gb.NroReporteZ).Select(y => new
              {
                  FactD = FactD.ToString(),
                  FactH = FactH.ToString(),
                  CantFact = (FactD > 0 && FactH > 0)? FactH-FactD+1 : 0, // Se le suma uno porque el rango es incluyente con el límite superior
                  MontoBI = y.Sum(g => g.MontoBase ?? 0),
                  MontoExento = y.Sum(g => (g.EPK_FacturaDetalle.Count(fd => fd.Exento && !fd.Cambio) > 0 ?
                    g.EPK_FacturaDetalle.Where(fd => fd.Exento && !fd.Cambio).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0) -
                    (g.EPK_FacturaDetalle.Count(fd => fd.Exento && fd.Cambio) > 0 ?
                    g.EPK_FacturaDetalle.Where(fd => fd.Exento && fd.Cambio).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0)),
                  MontoIVA = y.Sum(g => g.MontoIVA),
                  MontoDesc = y.Sum(g => g.MontoDescuento ?? 0)*(-1),
                  MontoTotal = y.Sum(g => g.MontoTotal ?? 0)
              }).FirstOrDefault();
          
            var NotCred = this.context.EPK_NotaCreditoEncabezado.Where(nc => nc.Fecha == fecha && nc.NroReporteZ == nroReporteZ &&
              nc.IdEstatus == idNCEmitida && nc.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).
                 GroupBy(cr => cr.NroReporteZ).Select(x => new
                 {
                     NCDesde = x.Min(g => g.TicketFiscal),
                     NCHasta = x.Max(g => g.TicketFiscal),
                     CantFactNC = x.Select(g => g.TicketFiscal).Count(),
                     MontoBINC = x.Sum(g => g.MontoBase),
                     MontoExentoNC = x.Sum(g => (g.EPK_NotaCreditoDetalle.Count(nd => nd.Exento && !nd.Cambio) > 0 ?
                      g.EPK_NotaCreditoDetalle.Where(nd => nd.Exento && !nd.Cambio).Sum(nd => nd.Cantidad * nd.PrecioNeto) : 0) -
                      (g.EPK_NotaCreditoDetalle.Count(nd => nd.Exento && nd.Cambio) > 0 ?
                      g.EPK_NotaCreditoDetalle.Where(nd => nd.Exento && nd.Cambio).Sum(nd => nd.Cantidad * nd.PrecioNeto) : 0)),
                     MontoIVANC = x.Sum(g => g.MontoIVA),
                     MontoDescNC = x.Sum(g => g.MontoDescuento)*(-1),
                     MontoTotalNC = x.Sum(g => g.MontoTotal)
                 }).FirstOrDefault();


            result = new DatosCierre();
            result.FacturasCierre = new DatosFacturasCierre();

            result.FacturasCierre.FacturaDesde = this.context.EPK_CierreMaquinaFiscal.Where(fe => fe.EPK_Dispositivo.IdDispositivo == idMaquina).
              OrderByDescending(f => f.IdCierreMF).Select(g => g.FacturaHasta).FirstOrDefault();

            result.FacturasCierre.FacturaHasta = result.FacturasCierre.FacturaDesde;

            result.FacturasCierre.CantidadFacturas = 0;
            result.FacturasCierre.BaseImponibleFact = result.FacturasCierre.ExentoFact = result.FacturasCierre.ImpuestoFact =
              result.FacturasCierre.DescuentoFact = result.FacturasCierre.MontoTotalFact = 0;
            
            if (FactEnc != null)
            {
                result.FacturasCierre.FacturaDesde = FactEnc.FactD.PadLeft(8-(FactEnc.FactD).Length, '0');
                result.FacturasCierre.FacturaHasta = FactEnc.FactH.PadLeft(8 - (FactEnc.FactH).Length, '0');
                result.FacturasCierre.CantidadFacturas = FactEnc.CantFact;
                result.FacturasCierre.BaseImponibleFact = FactEnc.MontoBI;
                result.FacturasCierre.ExentoFact = FactEnc.MontoExento;
                result.FacturasCierre.ImpuestoFact = FactEnc.MontoIVA;
                result.FacturasCierre.DescuentoFact = FactEnc.MontoDesc;
                result.FacturasCierre.MontoTotalFact = FactEnc.MontoTotal;
            }
            else 
            {
                string strNumFac = "";
                result.FacturasCierre.FacturaDesde = strNumFac.PadLeft(8, '0');
                result.FacturasCierre.FacturaHasta = strNumFac.PadLeft(8, '0');
            }

            if (NotCred != null)
            {
                result.NCsCierre = new DatosNCsCierre();

                result.NCsCierre.CantidadNC = 0;
                result.NCsCierre.BaseImponibleNC = result.NCsCierre.ExentoNC = result.NCsCierre.ImpuestoNC = result.NCsCierre.DescuentoNC =
                  result.NCsCierre.MontoTotalNC = 0;

                if (NotCred.MontoTotalNC > 0)
                {
                    result.NCsCierre.NCDesde = NotCred.NCDesde;
                    result.NCsCierre.NCHasta = NotCred.NCHasta;
                }
                result.NCsCierre.CantidadNC = NotCred.CantFactNC;
                result.NCsCierre.BaseImponibleNC = NotCred.MontoBINC;
                result.NCsCierre.ExentoNC = NotCred.MontoExentoNC;
                result.NCsCierre.ImpuestoNC = NotCred.MontoIVANC;
                result.NCsCierre.DescuentoNC = NotCred.MontoDescNC;
                result.NCsCierre.MontoTotalNC = NotCred.MontoTotalNC;
            }
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            result = null;
        }

        return result;
    }

    public DatosCierre ObtenerDatos(int idMaquina, string nroReporteZ)
    {
        DatosCierre result = null;

        if (idMaquina <= 0)
            return result;

        try
        {
            EPK_Dispositivo maquina = new Dispositivos().Obtener(idMaquina);

            if (maquina == null)
                return result;

            int idFacProc = EstadoAplicacion.EstadosFactura["FACProcesada"];
            int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];

            var FactEnc = this.context.EPK_FacturaEncabezado.Where(fe => fe.NroReporteZ == nroReporteZ &&
              fe.IdEstatus == idFacProc && fe.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).
              GroupBy(gb => gb.NroReporteZ).Select(y => new
              {
                  FactD = y.Min(g => g.TicketFiscal),
                  FactH = y.Max(g => g.TicketFiscal),
                  MontoBI = y.Sum(g => g.MontoBase ?? 0),
                  MontoExento = y.Sum(g => (g.EPK_FacturaDetalle.Count(fd => fd.Exento && !fd.Cambio) > 0 ?
                    g.EPK_FacturaDetalle.Where(fd => fd.Exento && !fd.Cambio).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0) -
                    (g.EPK_FacturaDetalle.Count(fd => fd.Exento && fd.Cambio) > 0 ?
                    g.EPK_FacturaDetalle.Where(fd => fd.Exento && fd.Cambio).Sum(fd => fd.Cantidad * fd.PrecioNeto) : 0)),
                  MontoIVA = y.Sum(g => g.MontoIVA),
                  MontoDesc = y.Sum(g => g.MontoDescuento ?? 0)*(-1),
                  MontoTotal = y.Sum(g => g.MontoTotal ?? 0)
              }).FirstOrDefault();

            var NotCred = this.context.EPK_NotaCreditoEncabezado.Where(nc => nc.NroReporteZ == nroReporteZ &&
              nc.IdEstatus == idNCEmitida && nc.SerialMF.Equals(maquina.Serial, StringComparison.OrdinalIgnoreCase)).
                 GroupBy(cr => cr.NroReporteZ).Select(x => new
                 {
                     NCDesde = x.Min(g => g.TicketFiscal),
                     NCHasta = x.Max(g => g.TicketFiscal),
                     MontoBINC = x.Sum(g => g.MontoBase),
                     MontoExentoNC = x.Sum(g => (g.EPK_NotaCreditoDetalle.Count(nd => nd.Exento && !nd.Cambio) > 0 ?
                      g.EPK_NotaCreditoDetalle.Where(nd => nd.Exento && !nd.Cambio).Sum(nd => nd.Cantidad * nd.PrecioNeto) : 0) -
                      (g.EPK_NotaCreditoDetalle.Count(nd => nd.Exento && nd.Cambio) > 0 ?
                      g.EPK_NotaCreditoDetalle.Where(nd => nd.Exento && nd.Cambio).Sum(nd => nd.Cantidad * nd.PrecioNeto) : 0)),
                     MontoIVANC = x.Sum(g => g.MontoIVA),
                     MontoDescNC = x.Sum(g => g.MontoDescuento)*(-1),
                     MontoTotalNC = x.Sum(g => g.MontoTotal)
                 }).FirstOrDefault();

            result = new DatosCierre();
            result.FacturasCierre = new DatosFacturasCierre();

            result.FacturasCierre.FacturaDesde = this.context.EPK_CierreMaquinaFiscal.Where(fe => fe.EPK_Dispositivo.IdDispositivo == idMaquina).
              OrderByDescending(f => f.IdCierreMF).Select(g => g.FacturaHasta).FirstOrDefault();

            result.FacturasCierre.FacturaHasta = result.FacturasCierre.FacturaDesde;

            result.FacturasCierre.CantidadFacturas = 0;
            result.FacturasCierre.BaseImponibleFact = result.FacturasCierre.ExentoFact = result.FacturasCierre.ImpuestoFact =
              result.FacturasCierre.DescuentoFact = result.FacturasCierre.MontoTotalFact = 0;

            if (FactEnc != null)
            {
                int factD, factH;

                int.TryParse(FactEnc.FactD, out factD);
                int.TryParse(FactEnc.FactH, out factH);

               // result.FacturasCierre.FacturaDesde = FactEnc.FactD;
                result.FacturasCierre.FacturaDesde = FactEnc.FactD.PadLeft(8 - (FactEnc.FactD).Length, '0');
                result.FacturasCierre.FacturaHasta = FactEnc.FactH.PadLeft(8 - (FactEnc.FactH).Length, '0');
               // result.FacturasCierre.FacturaHasta = FactEnc.FactH;
                result.FacturasCierre.CantidadFacturas = factH - factD + 1;
                result.FacturasCierre.BaseImponibleFact = FactEnc.MontoBI;
                result.FacturasCierre.ExentoFact = FactEnc.MontoExento;
                result.FacturasCierre.ImpuestoFact = FactEnc.MontoIVA;
                result.FacturasCierre.DescuentoFact = FactEnc.MontoDesc;
                result.FacturasCierre.MontoTotalFact = FactEnc.MontoTotal;
            }
            if (NotCred != null)
            {
                int ncD, ncH;

                int.TryParse(NotCred.NCDesde, out ncD);
                int.TryParse(NotCred.NCHasta, out ncH);

                result.NCsCierre = new DatosNCsCierre();

                result.NCsCierre.CantidadNC = 0;
                result.NCsCierre.BaseImponibleNC = result.NCsCierre.ExentoNC = result.NCsCierre.ImpuestoNC = result.NCsCierre.DescuentoNC =
                  result.NCsCierre.MontoTotalNC = 0;

                if (NotCred.MontoTotalNC > 0)
                {
                    result.NCsCierre.NCDesde = NotCred.NCDesde;
                    result.NCsCierre.NCHasta = NotCred.NCHasta;
                }
                result.NCsCierre.CantidadNC = ncH - ncD + 1;
                result.NCsCierre.BaseImponibleNC = NotCred.MontoBINC;
                result.NCsCierre.ExentoNC = NotCred.MontoExentoNC;
                result.NCsCierre.ImpuestoNC = NotCred.MontoIVANC;
                result.NCsCierre.DescuentoNC = NotCred.MontoDescNC;
                result.NCsCierre.MontoTotalNC = NotCred.MontoTotalNC;
            }
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            result = null;
        }

        return result;
    }

    #endregion Public Methods
  }
}