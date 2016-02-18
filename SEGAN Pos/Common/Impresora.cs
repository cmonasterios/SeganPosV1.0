using PrinterManager.Providers;
using SEGAN_POS.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace SEGAN_POS
{
  #region Data Types

  public class DatosReduccionZ
  {
    public decimal BaseNotasCredito { get; set; }

    public decimal BaseTributados { get; set; }

    public int CantidadFacturas { get; set; }

    public string COO { get; set; }

    public decimal Descuentos { get; set; }

    public decimal Exentos { get; set; }

    public decimal IVANotasCredito { get; set; }

    public decimal IVATributados { get; set; }

    public decimal NotasCredito { get; set; }

    public string PrimerTicketF { get; set; }

    public string UltimoTicketF { get; set; }

    public decimal VentaBruta { get; set; }

    public decimal ExentosNC { get; set; }

    public int Zrestantes { get; set; }

    public bool Manual { get; set; }

    public string FechaOperacion { get; set; }
  }

  #endregion Data Types

  /// <summary>
  /// Agrupa todos los métodos relacionados con la impresora fiscal.
  /// </summary>
  public class Impresora
  {
    #region Public Properties

    public string Serial { get; private set; }

    #endregion Public Properties

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    public Impresora()
    {
      this.Refrescar();
    }

    #endregion Constructor

    #region Public Methods

    public bool AbrirComprobanteEx(string rifCliente, string nomCliente, string dirCliente)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.AbrirComprobanteVentaExtendido(rifCliente, nomCliente, dirCliente);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Abre la gaveta de dinero.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool AbrirGaveta()
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.AccionaGaveta();

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool AbrirNotaCredito(string nomCliente, string serialMF, string rifCliente, DateTime fechaFactura, string COO)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.AbrirNotaCredito(nomCliente, serialMF, rifCliente,
          fechaFactura.ToString("dd", CultureInfo.InvariantCulture),
          fechaFactura.ToString("MM", CultureInfo.InvariantCulture),
          fechaFactura.ToString("yy", CultureInfo.InvariantCulture),
          fechaFactura.ToString("HH", CultureInfo.InvariantCulture),
          fechaFactura.ToString("mm", CultureInfo.InvariantCulture),
          fechaFactura.ToString("ss", CultureInfo.InvariantCulture),
          COO);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool AnularComprobante()
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.AnularComprobante();

        if (string.IsNullOrEmpty(strError[0])) {
          result = true;

          new NLogLogger().Info(string.Format("Comprobante anulado por: {0}({1}). Serial impresora: {2}.",
                                EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login,
                                this.Serial));
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Genera el reporte Z y crea el registro en la tabla EPK_CierreMaquinaFiscal.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool CierreReporteZ()
    {
      string Fecha = string.Empty, Hora = string.Empty;

      try {
        this.Refrescar();

        if (string.IsNullOrEmpty(this.Serial))
          return false;

        this.FechaHoraReducion(ref Fecha, ref Hora);

        //Obtiene los datos de Fact y NC para realizar el cierre MF
        int idMF = new Dispositivos().ObtenerIdMFCierre(this.Serial);
        string nroZ = this.ObtenerNroReporteZ();

        if (idMF <= 0 || string.IsNullOrEmpty(nroZ))
          return false;

        //Actualiza reporte Z en la tabla EPK_Dispositivos
        if (!new Dispositivos().ActualizarReporteZ(idMF, nroZ))
          return false;

        //Se guarda el Cierre Maquina Fiscal
        DateTime fechaZ = DateTime.ParseExact(Fecha + " " + Hora, "ddMMyy HHmmss", CultureInfo.InvariantCulture);

        DatosReduccionZ datosRepZ = this.LecturaMemoriaFiscalSerialReduccion(nroZ);

        if (datosRepZ == null)
          return false;

        if (new CierreMaquinaFiscal().Guardar(idMF, fechaZ.Date, fechaZ.TimeOfDay, nroZ, datosRepZ)) {
          new NLogLogger().Info(string.Format("CierreReporteZ realizado por: {0}({1}). Serial impresora: {2}.",
                        EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login,
                        this.Serial));
          return true;
        }

        return false;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    /// <summary>
    /// Genera el reporte Z y crea el registro en la tabla EPK_CierreMaquinaFiscal.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool CierreReporteZAutomatico()
    {
      string Fecha = string.Empty, Hora = string.Empty;

      try {
        this.FechaHoraReducion(ref Fecha, ref Hora);

        //Obtiene los datos de Fact y NC para realizar el cierre MF
        int idMF = new Dispositivos().ObtenerIdMFCierre(this.Serial);
        string nroZ = this.ObtenerNroReporteZ();

        if (idMF <= 0 || string.IsNullOrEmpty(nroZ))
          return false;
        //Actualiza reporte Z en la tabla EPK_Dispositivos
        if (!new Dispositivos().ActualizarReporteZ(idMF, nroZ))
          return false;

        //Se guarda el Cierre Maquina Fiscal
        DateTime fechaZ = DateTime.ParseExact(Fecha + " " + Hora, "ddMMyy HHmmss", CultureInfo.InvariantCulture);

        CierreMaquinaFiscal ObjCierre = new CierreMaquinaFiscal();

        if (ObjCierre.Obtener(idMF, nroZ) != null)
        {
            return true;
        }

        DatosReduccionZ datosRepZ = this.LecturaMemoriaFiscalSerialReduccion(nroZ);

        if (datosRepZ == null)
          return false;
           if(ObjCierre.Guardar(idMF, fechaZ.Date, fechaZ.TimeOfDay, nroZ, datosRepZ))
            {
                new NLogLogger().Info(string.Format("CierreReporteZAutomatico realizado por: {0}({1}). Serial impresora: {2}.",
                              EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login,
                              this.Serial));
                return true;
            }

        return false;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="DatosCierre"></param>
    /// <returns></returns>
    public bool ComprobanteDeCierre(EPK_CierreCajeroEncabezado DatosCierre, string MontoApertura, string MontoAlivios)
    {
        if (Util.ObtenerParametroEntero("ImprCierre") <= 0)
            return true;

        if (DatosCierre == null)
            return false;

        if (this.EnLinea() != 0)
            return false;
        try
        {
            string LineaInforme = string.Empty;
            string Denominacion = string.Empty;
            string Cantidad = string.Empty;
            string Monto = string.Empty;
            string FormaPago = string.Empty;
            string MontoSistema = string.Empty;
            string Diferencia = string.Empty;
            string DescripcionPos = string.Empty;
            string SiguienteLinea = string.Empty;
            string[] strError = new string[] { string.Empty, string.Empty };
            int IdFormaPago = (byte)Util.ObtenerParametroEntero("ID_EFECTIVO");
            decimal TotalAlivios = Convert.ToDecimal(MontoAlivios);
            decimal TotalDiferencia = 0;

            LineaInforme = "Cierre Nro.: " + DatosCierre.IdCierre.ToString();
            LineaInforme += string.Format("  Fecha: {0}", DatosCierre.Fecha + DatosCierre.Hora);

            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48, ' '));
            LineaInforme = "Caja: " + DatosCierre.EPK_Caja.Descripcion;
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48));
            LineaInforme = "Cajero: " + DatosCierre.EPK_Usuario.Identificacion;
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48));

            LineaInforme = "Monto Apertura: " + MontoApertura;
            LineaInforme = LineaInforme.PadRight(48);
            SiguienteLinea = "Total Alivios: " + MontoAlivios;
            SiguienteLinea = SiguienteLinea.PadRight(48);
            LineaInforme = LineaInforme + SiguienteLinea;
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48));
            LineaInforme = "-------------------   --------------------------";
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            LineaInforme = "Denominación        Cantidad            Monto   ";
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            /*----------------------------------------------------------------------
             Se Imprime el detalle del efectivo entregado
             ---------------------------------------------------------------------- */
            foreach (EPK_CierreCajeroDenominacion Detalle in DatosCierre.EPK_CierreCajeroDenominacion.OrderBy(d => d.EPK_Denominacion.Denominacion))
            {
                Denominacion = Detalle.EPK_Denominacion.Denominacion.ToString();
                Denominacion = Denominacion.PadLeft(12);
                Denominacion = Denominacion.PadRight(20);
                Cantidad = Detalle.Cantidad.ToString();
                Cantidad = Cantidad.PadLeft(8);
                Monto = (Detalle.EPK_Denominacion.Denominacion * Detalle.Cantidad).ToString();
                Monto = Monto.PadLeft(18);
                Monto = Monto.PadRight(20);
                LineaInforme = Denominacion + Cantidad + Monto;
                strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            }

            strError = PrinterProviderManager.Provider.InformeGerencial("-------------------   --------------------------");
            LineaInforme = "Forma de Pago  Monto     Monto Sist.  Diferencia";
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            // efectivos y otros formas de pago que no requieran pos y banco
            foreach (EPK_CierreCajeroPagos item in DatosCierre.EPK_CierreCajeroPagos)
            {
                FormaPago = Util.TruncarCadena(item.EPK_FormaPago.Descripcion, 15);
                FormaPago = FormaPago.PadRight(15);
                if (IdFormaPago == item.IdFormaPago)
                {
                    Monto = (item.MontoCierre + TotalAlivios).ToString();
                }
                else
                {
                    Monto = item.MontoCierre.ToString();
                }

                Monto = Monto.PadLeft(8);
                Monto = Monto.PadRight(10);

                MontoSistema = item.MontoPagos.ToString();
                MontoSistema = MontoSistema.PadLeft(8);
                MontoSistema = MontoSistema.PadRight(13);

                if (IdFormaPago == item.IdFormaPago)
                {
                    Diferencia = (item.MontoCierre + TotalAlivios - item.MontoPagos).ToString();
                }
                else
                {
                    Diferencia = (item.MontoCierre - item.MontoPagos).ToString();
                }
                TotalDiferencia = TotalDiferencia + Convert.ToDecimal(Diferencia);
                Diferencia = Diferencia.PadLeft(8);
                Diferencia = Diferencia.PadRight(10);
                LineaInforme = FormaPago + Monto + MontoSistema + Diferencia;
                strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            }

            foreach (EPK_CierreCajeroPOS DetallesPos in DatosCierre.EPK_CierreCajeroPOS.OrderBy(o => o.EPK_POS.IdEntidad))
            {
                FormaPago = Util.TruncarCadena(DetallesPos.EPK_FormaPago.Descripcion, 15);
                FormaPago = FormaPago.PadRight(15);

                Monto = DetallesPos.MontoPOS.ToString();
                Monto = Monto.PadLeft(8);
                Monto = Monto.PadRight(10);

                MontoSistema = DetallesPos.MontoPago.ToString();
                MontoSistema = MontoSistema.PadLeft(8);
                MontoSistema = MontoSistema.PadRight(13);

                Diferencia = (DetallesPos.MontoPOS - DetallesPos.MontoPago).ToString();
                TotalDiferencia = TotalDiferencia + Convert.ToDecimal(Diferencia);
                Diferencia = Diferencia.PadLeft(8);
                Diferencia = Diferencia.PadRight(10);
                LineaInforme = FormaPago + Monto + MontoSistema + Diferencia;
                DescripcionPos = DetallesPos.EPK_POS.Descripcion.Trim();
                DescripcionPos = DescripcionPos.PadRight(48);
                if (DescripcionPos.Length > 0)
                {
                    LineaInforme = LineaInforme + DescripcionPos;
                }
                strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            }

            int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");
            decimal TotalOtros = DatosCierre.EPK_CierreCajeroPOS.Sum(s => s.MontoPOS) + DatosCierre.EPK_CierreCajeroPagos.Where(c => c.IdFormaPago != idEfectivo).Sum(c => c.MontoPagos);
            decimal TotalGeneral = DatosCierre.EPK_CierreCajeroPagos.Sum(s => s.MontoCierre) + DatosCierre.EPK_CierreCajeroPOS.Sum(s => s.MontoPOS) + Convert.ToDecimal(MontoAlivios);
            strError = PrinterProviderManager.Provider.InformeGerencial("-------------------   --------------------------");
            LineaInforme = "Total Otros Pagos: " + TotalOtros.ToString("C2");
            LineaInforme = LineaInforme.PadLeft(46);
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            LineaInforme = "Total General: " + TotalGeneral.ToString("C2");
            LineaInforme = LineaInforme.PadLeft(46);
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            LineaInforme = "Total Diferencia: " + TotalDiferencia.ToString("C2");
            LineaInforme = LineaInforme.PadLeft(46);
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            strError = PrinterProviderManager.Provider.InformeGerencial("-------------------   --------------------------");
            LineaInforme = "____________________________";
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            LineaInforme = DatosCierre.EPK_Usuario.Identificacion;
            LineaInforme = LineaInforme.PadRight(48);
            strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
            strError = PrinterProviderManager.Provider.CierreInformeGerencial();

            //this.ImprimirCopiaFactura();

            return true;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        }
        return false;
    }

    public string DatosUltimaReduccion()
    {
      try {
        string UltimaReduccion = new string('\x20', 665);
        string[] strError = PrinterProviderManager.Provider.DatosUltimaReduccion(ref UltimaReduccion);

        if (string.IsNullOrEmpty(strError[0]))
          return UltimaReduccion.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public bool DevolverArticulo(string codArticulo, string Descripcion, decimal IVA, bool Exento, int Cantidad, decimal Precio, decimal PorcDescuento, bool EnDescuento)
    {
      bool result = false;

      try {
        string codArt = codArticulo.Trim();
        if (codArt.Length > 13) {
          codArt = Regex.Replace(codArt, "[^a-zA-Z0-9]", "");
          codArt = Util.TruncarCadena(codArt, 13);
        }

        string descRef = Util.TruncarCadena(Descripcion, 29);
        descRef = Util.StripAccents(descRef);

        string sIVA = (Exento || !EstadoAplicacion.AplicaImpuesto) ? "II" : Util.TruncarCadena(Util.ObtenerParametroDecimal("IVA").ToString("F2"), 5);

        string tipoCantidad = "I";

        string cantArt = Util.TruncarCadena(Cantidad.ToString(), 4);

        string decCantidad = "2";

        string precioArt = Util.TruncarCadena(Precio.ToString("F2"), 8);

        string tipoDesc = "%";

        string Descuento = "0000";
        if (EnDescuento)
          Descuento = Util.TruncarCadena(Regex.Replace(PorcDescuento.ToString("F2"), "[^0-9]", ""), 4);

        string[] strError = PrinterProviderManager.Provider.DevolverArticulo(codArt, descRef, sIVA, tipoCantidad, cantArt, decCantidad, precioArt, tipoDesc, Descuento);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool EfectuarPago(string DescFormaPago, decimal Monto)
    {
      bool result = false;

      try {
        string descFormaPago = Util.TruncarCadena(DescFormaPago, 16);
        string valorPago = Util.TruncarCadena(Monto.ToString("F2"), 14);

        descFormaPago = Util.StripAccents(descFormaPago);

        string[] strError = PrinterProviderManager.Provider.EfectuarPago(descFormaPago, valorPago);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool EfectuarPagoEx(string DescFormaPago, decimal Monto, string DescPOS, string NumeroPago)
    {
      bool result = false;

      try {
        string descFormaPago = Util.TruncarCadena(DescFormaPago, 16);
        string valorPago = Util.TruncarCadena(Monto.ToString("F2"), 14);

        string datosPago = string.Empty;

        if (!string.IsNullOrEmpty(DescPOS))
          datosPago += DescPOS + " ";

        datosPago += "#" + NumeroPago;

        datosPago = Util.TruncarCadena(datosPago, 80);

        descFormaPago = Util.StripAccents(descFormaPago);
        datosPago = Util.StripAccents(datosPago);

        string[] strError = PrinterProviderManager.Provider.EfectuaFormaPagoDescripcionForma(descFormaPago, valorPago, datosPago);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Verifica si la impresora esta en linea y su estado.
    /// </summary>
    /// <returns>0 si la impresora funciona correctamente; 1 si existe algún problema de comunicacion; 2 si la impresora tiene un cupón pendiente.</returns>
    public int EnLinea()
    {
      int ACK = 0, ST1 = 0, ST2 = 0;

      try {
        string strError = PrinterProviderManager.Provider.VerificaEstadoImpresora(ref ACK, ref ST1, ref ST2);

        /*if (!string.IsNullOrEmpty(strError))
          return 1;*/

        BitArray baST1 = new BitArray(new int[] { ST1 });
        BitArray baST2 = new BitArray(new int[] { ST2 });

        if (baST1[1])
          return 2;

        if (!baST1[0] && !baST1[1] && !baST1[2] && !baST1[3] && !baST1[4] && !baST1[5] && !baST1[7] &&
            !baST2[0] && !baST2[1] && !baST2[2] && !baST2[3] && !baST2[4] && !baST2[5] && !baST2[6] && !baST2[7])
          return 0;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 1;
    }

    public DateTime? FechaHoraImpresora()
    {
      DateTime? result = null;

      try {
        string fecha = new string(' ', 6), hora = new string(' ', 6);

        string[] strError = PrinterProviderManager.Provider.FechaHoraImpresora(ref fecha, ref hora);

        if (string.IsNullOrEmpty(strError[0])) {
          DateTime tempDate = DateTime.MinValue;
          if (DateTime.TryParseExact(fecha + " " + hora, "ddMMyy HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
            result = tempDate;
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool FechaHoraReducion(ref string Fecha, ref string Hora)
    {
      try {
        Fecha = new string('\x20', 6);
        Hora = new string('\x20', 6);
        string[] strError = PrinterProviderManager.Provider.FechaHoraReducion(ref Fecha, ref Hora);

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public DateTime? FechaHoraUltimoDocumento()
    {
      DateTime? result = null;

      try {
        string fechahora = new string(' ', 12);

        string[] strError = PrinterProviderManager.Provider.FechaHoraUltimoDocumento(ref fechahora);

        if (string.IsNullOrEmpty(strError[0])) {
          DateTime tempDate = DateTime.MinValue;
          if (DateTime.TryParseExact(fechahora, "ddMMyyHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
            result = tempDate;
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool FinalizarCierreComprobante(string PieFactura)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.FinalizarCierreComprobante(PieFactura);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Verifica el estado de la gaveta de dinero.
    /// </summary>
    /// <returns>True si la gaveta esta abierta; False si esta cerrada.</returns>
    public bool GavetaAbierta()
    {
      bool result = false;

      try {
        int tempInt = 0;

        string[] strError = PrinterProviderManager.Provider.VerificaEstadoGaveta(out tempInt);

        if (string.IsNullOrEmpty(strError[0]))
          result = (tempInt == 0);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Este método permite la impresión del comprobante del alivio de efectivo realizado por un usuario
    /// </summary>
    /// <param name="DatosAlivio"></param>
    /// <param name="Diferencia"></param>
    public bool ImprimirComprobanteAlivio(EPK_AlivioEfectivoEncabezado DatosAlivio, decimal Diferencia)
    {
      if (Util.ObtenerParametroEntero("ImprAlivio") <= 0)
            return true;

      if (DatosAlivio == null)
        return false;

      if (this.EnLinea() != 0)
        return false;

      try {
        string LineaInforme = string.Empty;
        string Denominacion = string.Empty;
        string Cantidad = string.Empty;
        string Monto = string.Empty;
        string[] strError = new string[] { string.Empty, string.Empty };

        LineaInforme = "Alivio Nro.: " + DatosAlivio.IdAlivioEfectivo.ToString();
        LineaInforme += string.Format("  Fecha: {0}", DatosAlivio.FechaAlivio + DatosAlivio.HoraAlivio);

        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48, ' '));
        LineaInforme = "Caja: " + DatosAlivio.EPK_Caja.Descripcion;
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48));
        LineaInforme = "Cajero: " + DatosAlivio.EPK_Usuario.Identificacion;
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme.PadRight(48));
        LineaInforme = "Denominación        Cantidad            Monto   ";
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        foreach (EPK_AlivioEfectivoDetalle Detalle in DatosAlivio.EPK_AlivioEfectivoDetalle.OrderBy(d => d.EPK_Denominacion.Denominacion)) {
          Denominacion = Detalle.EPK_Denominacion.Denominacion.ToString();
          Denominacion = Denominacion.PadLeft(12);
          Denominacion = Denominacion.PadRight(20);
          Cantidad = Detalle.CantidadCajero.ToString();
          Cantidad = Cantidad.PadLeft(8);
          Monto = (Detalle.EPK_Denominacion.Denominacion * Detalle.CantidadCajero).ToString();
          Monto = Monto.PadLeft(18);
          Monto = Monto.PadRight(20);
          LineaInforme = Denominacion + Cantidad + Monto;
          strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        }
        strError = PrinterProviderManager.Provider.InformeGerencial("-------------------   --------------------------");
        LineaInforme = "Monto Alivio:          " + DatosAlivio.TotalAlivio.ToString("C2");
        LineaInforme = LineaInforme.PadLeft(46);
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        LineaInforme = "Diferencia:          " + Diferencia.ToString("C2");
        LineaInforme = LineaInforme.PadLeft(46);
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        strError = PrinterProviderManager.Provider.InformeGerencial("-------------------   --------------------------");
        LineaInforme = "_______________________";
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        LineaInforme = DatosAlivio.EPK_Usuario.Identificacion;
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        LineaInforme = " ";
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        LineaInforme = "_______________________";
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        LineaInforme = "Supervisor";
        LineaInforme = LineaInforme.PadRight(48);
        strError = PrinterProviderManager.Provider.InformeGerencial(LineaInforme);
        strError = PrinterProviderManager.Provider.CierreInformeGerencial();

        //this.ImprimirCopiaFactura();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    /// <summary>
    /// Imprime un duplicado del último comprobante generado por la impresora.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool ImprimirCopiaFactura()
    {
      bool result = false;

      try {
        int espera = EstadoAplicacion.EsperaDuplicado * 1000;

        if (espera > 0)
          System.Threading.Thread.Sleep(espera);

        string ContadorSecuencial = new string(' ', 6);
        string[] strError = PrinterProviderManager.Provider.NumeroCupon(ref ContadorSecuencial);
        strError = PrinterProviderManager.Provider.ImpresionCintaDetalle("2", ContadorSecuencial, ContadorSecuencial, "1");

        if (string.IsNullOrEmpty(strError[0])) {
          result = true;
          if (espera > 0)
            System.Threading.Thread.Sleep(espera);
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool IniciarCierreComprobante()
    {
      bool result = false;

      try {
        string descRecargo = "A";
        string tipoDescRecargo = "%";
        string valorDescRecargo = "0000";

        string[] strError = PrinterProviderManager.Provider.IniciarCierreComprobante(descRecargo, tipoDescRecargo, valorDescRecargo);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool LecturaMemoriaFiscalFechaMFD(string Desde, string Hasta, string Flag)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.LecturaMemoriaFiscalFechaMFD(ref Desde, ref Hasta, ref Flag);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool LecturaMemoriaFiscalReduccion(string Desde, string Hasta)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.LecturaMemoriaFiscalReduccion(ref Desde, ref Hasta);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="Inicio"></param>
    /// <param name="Fin"></param>
    /// <returns></returns>
    public DatosReduccionZ LecturaMemoriaFiscalSerialReduccion(string Inicio, string Fin)
    {
      string[] secciones = new string[] { "----------------Primera Factura-----------------", 
                                          "-----------------Ultima Factura-----------------",
                                          "Total del periodo", 
                                          "---------------Resumen Tributados---------------", 
                                          "-------Notas de Credito y/o Devoluciones--------",
                                          "Numero de Informes Restantes"};
      string[] totales = new string[] { "DESCUENTOS" };
      string[] resumen = new string[] { "Tributados", "Exentos", "Notas de Credito", "Suma" };


      DatosReduccionZ result = new DatosReduccionZ {
        FechaOperacion = "00/00/0000",
        COO = "000000",
        PrimerTicketF = "00000000",
        UltimoTicketF = "00000000",
        CantidadFacturas = 0,
        Descuentos = 0,
        BaseTributados = 0,
        IVATributados = 0,
        Exentos = 0,
        BaseNotasCredito = 0,
        IVANotasCredito = 0,
        NotasCredito = 0,
        VentaBruta = 0,
        Zrestantes = 0
      };

      try {
        if (string.IsNullOrEmpty(Inicio) || string.IsNullOrEmpty(Fin))
          return null;

        string bmIni = Environment.SystemDirectory + @"\" + string.Format(Properties.Resources.BematechINI, 64);

        if (!File.Exists(bmIni))
          bmIni = Environment.SystemDirectory + @"\" + string.Format(Properties.Resources.BematechINI, 32);

        if (!File.Exists(bmIni))
          return null;

        IniParser.Model.IniData iniData = new IniParser.FileIniDataParser().ReadFile(bmIni);
        string bmPath = iniData["Sistema"]["Path"];

        if (!bmPath.EndsWith(@"\"))
          bmPath += @"\";

        string[] strError = PrinterProviderManager.Provider.LecturaMemoriaFiscalSerialReduccion(Inicio, Fin);

        if (!string.IsNullOrEmpty(strError[0]))
          return null;

        string bmRetorno = bmPath + Properties.Resources.BematechRetorno;

        if (!File.Exists(bmRetorno))
          return null;

        string[] archivoRetorno = File.ReadAllLines(bmRetorno, System.Text.Encoding.UTF7);

        if (archivoRetorno.Length == 0)
          return null;

        List<string> datosRetorno = new List<string>(archivoRetorno);

        //Recorre el Texto del Archivo almacenado en la Variable: datosRetorno
        int startLine = 0;
        foreach (string linea in datosRetorno)
        {

            #region Busca la Fecha de Operación
            if (Util.StripAccents(linea).StartsWith("----INFORMES", StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine + 2].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                    if (valores.Length > 0)
                        result.FechaOperacion = valores[0].Trim();
                }

                continue;
            }
            #endregion

            #region Buscar el COO

            if (Util.StripAccents(linea).Contains("COO:"))
            {
                string[] datos = linea.Split(':');
                if (datos.Length > 1)
                    result.COO = datos[datos.GetUpperBound(0)].Trim();

                continue;
            }

            #endregion

            #region Buscar la Primera Factura

            if (Util.StripAccents(linea).StartsWith(secciones[0], StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine + 1].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                    if (valores.Length > 0)
                        result.PrimerTicketF = "00" + valores[0];
                }

                continue;
            }



            #endregion

            #region Buscar la Última Factura

            if (Util.StripAccents(linea).StartsWith(secciones[1], StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine + 1].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                    //se actualiza la fecha de operación en caso de que el reporte se haya generado de forma automática
                    result.FechaOperacion = valores[1].Trim();

                    if (valores.Length > 0)
                        result.UltimoTicketF = "00" + valores[0];
                }
                
                int priTicket = 0, ultTicket = 0;
                int.TryParse(result.PrimerTicketF, out priTicket);
                int.TryParse(result.UltimoTicketF, out ultTicket);

                if (priTicket > 0 && ultTicket > 0)
                    result.CantidadFacturas = ultTicket - priTicket + 1;
            }

            #endregion

            #region Buscar Total Descuentos

            if (Util.StripAccents(linea).StartsWith(secciones[2], StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                     string[] valores = datosRetorno[startLine + 3].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                     if (valores.Length > 1)
                     {
                         decimal descuentos = 0;
                         decimal.TryParse(valores[valores.GetUpperBound(0)].Trim(), out descuentos);

                         result.Descuentos = descuentos;
                     }
                }

                continue;
            }

            #endregion

            #region Buscar Resumen Tributados

            if (Util.StripAccents(linea).StartsWith(secciones[3]))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine + 2].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                    string[] valores1 = datosRetorno[startLine + 3].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                    decimal Exentos = 0; decimal baseTributados = 0, IVATributados = 0;
                    decimal.TryParse(valores[valores.GetUpperBound(0) - 1].Trim(), out baseTributados);
                    decimal.TryParse(valores[valores.GetUpperBound(0)].Trim(), out IVATributados);
                    decimal.TryParse(valores1[valores1.GetUpperBound(0)].Trim(), out Exentos);

                    result.BaseTributados = baseTributados;
                    result.IVATributados = IVATributados;
                    result.Exentos = Exentos;
                    result.VentaBruta = baseTributados + IVATributados + Exentos;
                }

                continue;
            }

            #endregion

            #region Buscar Resumen Notas de Crédito

            if (Util.StripAccents(linea).StartsWith(secciones[4], StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);

                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine + 1].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                    string[] valores1 = datosRetorno[startLine + 2].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                    decimal baseNCs = 0, IVANCs = 0, ExentoNCs = 0;
                    decimal.TryParse(valores1[valores1.GetUpperBound(0) - 4].Trim(), out baseNCs);
                    decimal.TryParse(valores1[valores1.GetUpperBound(0)].Trim(), out IVANCs);
                    decimal.TryParse(valores[valores.GetUpperBound(0)].Trim(), out ExentoNCs);

                    result.BaseNotasCredito = baseNCs;
                    result.IVANotasCredito = IVANCs;
                    result.ExentosNC = ExentoNCs;
                    result.NotasCredito = baseNCs + IVANCs + ExentoNCs;
                }

                continue;
            }
            #endregion

            #region Cantidad Z Restante

            if (Util.StripAccents(linea).StartsWith(secciones[5], StringComparison.OrdinalIgnoreCase))
            {
                startLine = datosRetorno.IndexOf(linea);
                
                if (startLine > 0)
                {
                    string[] valores = datosRetorno[startLine].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                    int NroZRestantes = 0;
                    int.TryParse(valores[valores.GetUpperBound(0)].Trim(), out NroZRestantes);

                    result.Zrestantes = NroZRestantes;
                }

                continue;
            }

            #endregion

        } 

        return result;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public DatosReduccionZ LecturaMemoriaFiscalSerialReduccion()
    {
      string ultZ = this.NroRepZ();

      if (string.IsNullOrEmpty(ultZ))
        return null;

      return this.LecturaMemoriaFiscalSerialReduccion(ultZ, ultZ);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="repZ"></param>
    /// <returns></returns>
    public DatosReduccionZ LecturaMemoriaFiscalSerialReduccion(string repZ)
    {
      return this.LecturaMemoriaFiscalSerialReduccion(repZ, repZ);
    }

    public string NroComprobanteFiscal()
    {
      string result = string.Empty;

      try {
        string nuevoTicketFiscal = new string(' ', 6);

        string[] strError = PrinterProviderManager.Provider.NumeroComprobanteFiscal(ref nuevoTicketFiscal);

        if (string.IsNullOrEmpty(strError[0]))
          result = "00" + nuevoTicketFiscal.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public string NroCupon()
    {
      string result = string.Empty;

      try {
        string nuevoCOO = new string(' ', 6);

        string[] strError = PrinterProviderManager.Provider.NumeroCupon(ref nuevoCOO);

        if (string.IsNullOrEmpty(strError[0]))
          result = nuevoCOO.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public string NroRepZ()
    {
      string result = string.Empty;

      try {
        string numReduccion = new string(' ', 4);

        string[] strError = PrinterProviderManager.Provider.NumeroReducciones(ref numReduccion);

        if (string.IsNullOrEmpty(strError[0]))
          result = numReduccion.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public string ObtenerNroFactura()
    {
      try {
        string NroFactura = new string('\x20', 6);
        string[] strError = PrinterProviderManager.Provider.NumeroComprobanteFiscal(ref NroFactura);

        if (string.IsNullOrEmpty(strError[0]))
          return NroFactura.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public string ObtenerNroReporteZ()
    {
      try {
        string ReporteZ = new string('\x20', 4);
        string[] strError = PrinterProviderManager.Provider.NumeroReducciones(ref ReporteZ);

        if (string.IsNullOrEmpty(strError[0]))
          return ReporteZ.Trim();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public int Refrescar()
    {
      int result = 1;
      this.Serial = string.Empty;

      result = this.EnLinea();

      if (result != 1)
        this.Serial = this.ObtenerSerial();

      return result;
    }

    /// <summary>
    /// Reimprime el comprobante que corresponde al COO dado.
    /// </summary>
    /// <param name="COO">Cadena con el valor del COO del comprobante que se desea reimprimir.</param>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool ReImprimirFactura(string COO)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.ImpresionCintaDetalle("2", Util.TruncarCadena(COO, 6),
          Util.TruncarCadena(COO, 6), "1");

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool ReImprimirFactura(string COODesde, string COOHasta)
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.ImpresionCintaDetalle("2", Util.TruncarCadena(COODesde, 6),
          Util.TruncarCadena(COOHasta, 6), "1");

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool ReImprimirFactura(DateTime FechaIni, DateTime FechaFin)
    {
      bool result = false;

      try {
        string fDesde = FechaIni.ToString("ddMMyy", CultureInfo.InvariantCulture);
        string fHasta = FechaFin.ToString("ddMMyy", CultureInfo.InvariantCulture);

        string[] strError = PrinterProviderManager.Provider.ImpresionCintaDetalle("1", fDesde, fHasta, "1");

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Genera el reporte X de la impresora.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool ReporteX()
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.LecturaX();

        if (string.IsNullOrEmpty(strError[0])) {
          result = true;

          new NLogLogger().Info(string.Format("Reporte X emitido por: {0}({1}). Serial impresora: {2}.",
                      EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login,
                      this.Serial));
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Genera el reporte Z de la impresora.
    /// </summary>
    /// <returns>True si la operación fue exitosa; en caso contrario, False.</returns>
    public bool ReporteZ()
    {
      bool result = false;

      try {
        string[] strError = PrinterProviderManager.Provider.ReduccionZ("", "");

        if (string.IsNullOrEmpty(strError[0])) {
          result = true;

          new NLogLogger().Info(string.Format("Reporte Z emitido por: {0}({1}). Serial impresora: {2}.",
                                EstadoAplicacion.UsuarioActual.Identificacion, EstadoAplicacion.UsuarioActual.Login,
                                this.Serial));
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool ResetaImpresora()
    {
      try {
        return (PrinterProviderManager.Provider.ResetaImpresora() == 1);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    /// <summary>
    /// Verifica el resultado del último comando enviado a la impresora.
    /// </summary>
    /// <returns>Si el comando arrojó un error, el mensaje correspondiente. En caso contrario, null.</returns>
    public string ResultadoComando()
    {
      string result = null;

      try {
        int ACK = 0, ST1 = 0, ST2 = 0;
        result = PrinterProviderManager.Provider.VerificaEstadoImpresora(ref ACK, ref ST1, ref ST2);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public decimal SubTotal()
    {
      decimal result = -1;

      try {
        string totalImp = new string(' ', 14);

        string[] strError = PrinterProviderManager.Provider.SubTotal(ref totalImp);

        if (!string.IsNullOrEmpty(strError[0]))
          return result;

        if (string.IsNullOrEmpty(totalImp))
          return result;

        string valor = totalImp.Substring(0, totalImp.Length - 2) +
          Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator +
          totalImp.Substring(totalImp.Length - 2, 2);

        decimal tempValor;
        decimal.TryParse(valor, out tempValor);

        result = tempValor;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool VenderArticulo(string codArticulo, string Descripcion, decimal IVA, bool Exento, int Cantidad, decimal Precio, decimal PorcDescuento, bool EnDescuento)
    {
      bool result = false;

      try {
        string codArt = codArticulo.Trim();
        if (codArt.Length > 13) {
          codArt = Regex.Replace(codArt, "[^a-zA-Z0-9]", "");
          codArt = Util.TruncarCadena(codArt, 13);
        }

        string descRef = Util.TruncarCadena(Descripcion, 29);
        descRef = Util.StripAccents(descRef);

        string sIVA = (Exento || !EstadoAplicacion.AplicaImpuesto) ? "II" : Util.TruncarCadena(Util.ObtenerParametroDecimal("IVA").ToString("F2"), 5);

        string tipoCantidad = "I";

        string cantArt = Util.TruncarCadena(Cantidad.ToString(), 4);

        string decCantidad = "2";

        string precioArt = Util.TruncarCadena(Precio.ToString("F2"), 8);

        string tipoDesc = "%";

        string Descuento = "0000";
        if (EnDescuento)
          Descuento = Util.TruncarCadena(Regex.Replace(PorcDescuento.ToString("F2"), "[^0-9]", ""), 4);

        string[] strError = PrinterProviderManager.Provider.VenderArticulo(codArt, descRef, sIVA, tipoCantidad, cantArt, decCantidad, precioArt, tipoDesc, Descuento);

        if (string.IsNullOrEmpty(strError[0]))
          result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// Verifica si la impresora está prendida o conectada en la computadora.
    /// </summary>
    /// <returns></returns>
    public bool VerificaImpresoraEncendida()
    {
      try {
        return (PrinterProviderManager.Provider.VerificaImpresoraPrendida() == 1);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }
    #endregion Public Methods

    #region Private Methods

    private string ObtenerSerial()
    {
      string result = new string(' ', 15);

      try {
        string[] strError = PrinterProviderManager.Provider.NumeroSerie(ref result);
        result = result.Trim();
        if (!string.IsNullOrEmpty(strError[0]))
          result = string.Empty;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    #endregion Private Methods
  }
}