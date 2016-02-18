using PrinterManager.Providers.Bematech32.Extension;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterManager.Providers
{
  public class BematechPrinter32 : PrinterProviderBase
  {
    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
      #region Attributes check
      if ((config == null) || (config.Count == 0))
        throw new ArgumentNullException("You must supply a valid configuration parameters.");
      this._name = name;
      #endregion

      #region Description
      if (string.IsNullOrEmpty(config["description"])) {
        throw new ProviderException("You must specify a description attribute.");
      }
      this._description = config["description"];
      config.Remove("description");
      #endregion

      #region Extra Attributes validations
      if (config.Count > 0) {
        string extraAttribute = config.GetKey(0);
        if (!String.IsNullOrEmpty(extraAttribute))
          throw new ProviderException("The following unrecognized attribute was found in " + Name + "'s configuration: '" +
                                      extraAttribute + "'");
        else
          throw new ProviderException("An unrecognized attribute was found in the provider's configuration.");
      }
      #endregion
    }

    #region Funciones de Inicialización
    public override string[] ProgramarAlicuota(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_ProgramaAlicuota(args[0], Convert.ToInt32(args[1]));
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };
      return strError;
    }

    public override string[] ProgramarRedondeo(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_ProgramaRedondeo();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] ProgramarTruncamiento(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_ProgramaTruncamiento();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    #endregion

    #region Funciones del Cupon Fiscal
    public override string[] AbrirComprobanteVenta(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_AbreComprobanteDeVenta(args[0], args[1]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };
      return strError;
    }

    public override string[] AbrirComprobanteVentaExtendido(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 2) {
        iResult = classBematech32.Bematech_FI_AbreComprobanteDeVentaEx(args[0], args[1], args[2]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] VenderArticulo(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 9) {
        iResult = classBematech32.Bematech_FI_VendeArticulo(args[0], args[1], args[2], args[3], args[4], Convert.ToInt32(args[5]), args[6], args[7], args[8]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] AnularArticulo(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_AnulaArticuloAnterior();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] AnularComprobante(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_AnulaCupon();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] CerrarComprobante(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 6) {
        iResult = classBematech32.Bematech_FI_CierraCupon(args[0], args[1], args[2], args[3], args[4], args[5]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] IniciarCierreComprobante(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 3) {
        iResult = classBematech32.Bematech_FI_IniciaCierreCupon(args[0], args[1], args[2]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] EfectuarPago(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 2) {
        iResult = classBematech32.Bematech_FI_EfectuaFormaPago(args[0], args[1]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] EfectuaFormaPagoDescripcionForma(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 2) {
        iResult = classBematech32.Bematech_FI_EfectuaFormaPagoDescripcionForma(args[0], args[1], args[2]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] FinalizarCierreComprobante(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_FinalizarCierreCupon(args[0]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] DevolverArticulo(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 9) {
        iResult = classBematech32.Bematech_FI_DevolucionArticulo(args[0], args[1], args[2], args[3], args[4], Convert.ToInt32(args[5]), args[6], args[7], args[8]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] AbrirNotaCredito(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 10) {
        iResult = classBematech32.Bematech_FI_AbreNotaDeCredito(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] ImpresionCintaDetalle(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      if (args.Length >= 4) {
        iResult = classBematech32.Bematech_FI_ImpresionCintaDetalle(args[0], args[1], args[2], args[3]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    #endregion

    #region Funciones de los Informes Fiscales
    public override string[] LecturaX(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_LecturaX();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] LecturaXSerial(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_LecturaXSerial();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] ReduccionZ(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 2) {
        iResult = classBematech32.Bematech_FI_ReduccionZ(args[0], args[1]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;

    }

    public override string[] InformeGerencial(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_InformeGerencial(args[0]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] CierreInformeGerencial(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;

      iResult = classBematech32.Bematech_FI_CierraInformeGerencial();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] LecturaMemoriaFiscalSerialReduccion(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_LecturaMemoriaFiscalSerialReduccion(args[0], args[1]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }
    
    #endregion

    #region Funciones de las Operaciones No Fiscales
    public override string[] RecebimientoNoFiscal(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 3) {
        iResult = classBematech32.Bematech_FI_RecebimientoNoFiscal(args[0], args[1], args[2]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] AbreComprobanteNoFiscalVinculado(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 3) {
        iResult = classBematech32.Bematech_FI_AbreComprobanteNoFiscalVinculado(args[0], args[1], args[2]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] ImprimeComprobanteNoFiscalVinculado(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_ImprimeComprobanteNoFiscalVinculado(args[0]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] CierraComprobanteNoFiscalVinculado(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_CierraComprobanteNoFiscalVinculado();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] Sangria(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_Sangria(args[0]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] Provision(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 2) {
        iResult = classBematech32.Bematech_FI_Provision(args[0], args[1]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }
    #endregion

    #region Funciones de Informaciones de la Impresora

    public override string[] Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_Agregado(ref ValorIncrementos);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_Cancelamientos(ref ValorCancelamientos);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_DatosUltimaReduccion(ref DatosReduccion);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_Descuentos(ref ValorDescuentos);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_NumeroCuponesAnulados(ref NumeroCancelamientos);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_RetornoAlicuotas(ref Alicuotas);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] LecturaMemoriaFiscalReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionInicial, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionFinal)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_LecturaMemoriaFiscalReduccion(ref ReduccionInicial, ref ReduccionFinal);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] LecturaMemoriaFiscalFechaMFD([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaDesde, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FechasHasta, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FlagLectura)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_LecturaMemoriaFiscalFechaMFD(ref FechaDesde, ref FechasHasta, ref FlagLectura);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] FechaHoraImpresora([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_FechaHoraImpresora(ref Fecha, ref Hora);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] FechaHoraReducion([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_FechaHoraReduccion(ref Fecha, ref Hora);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] FechaHoraUltimoDocumento([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaHora)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_FechaHoraUltimoDocumentoMFD(ref FechaHora);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    #endregion

    #region Funciones de Autenticación y Gaveta de Efectivo

    public override string[] AccionaGaveta()
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_AccionaGaveta();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] Autenticacion()
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_Autenticacion();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] ProgramaCaracterAutenticacion(params string[] args)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      if (args.Length >= 1) {
        iResult = classBematech32.Bematech_FI_ProgramaCaracterAutenticacion(args[0]);
        strError = classBematech32.Analiza_iRetorno(iResult);
        strRetorno = classBematech32.Analiza_RetornoImpresora();
      }
      else
        strError = new string[] { "Error faltan parametros para el metodo" };

      return strError;
    }

    public override string[] VerificaEstadoGaveta(out int EstadoGaveta)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_VerificaEstadoGaveta(out EstadoGaveta);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    #endregion

    #region Otras Funciones
    public override string[] AbrePuertaSerial()
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_AbrePuertaSerial();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] CierraPuertaSerial()
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_CierraPuertaSerial();
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] RetornoImpresora(ref int ACK, ref int ST1, ref int ST2)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_RetornoImpresora(ref ACK, ref ST1, ref ST2);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string VerificaEstadoImpresora(ref int ACK, ref int ST1, ref int ST2)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_VerificaEstadoImpresora(ref ACK, ref ST1, ref ST2);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      if (iResult != 1)
        return strRetorno;

      return strError[0];
    }

    public override string[] NumeroReducciones([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroReducciones)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_NumeroReducciones(ref NumeroReducciones);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] NumeroCupon([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCupon)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_NumeroCupon(ref NumeroCupon);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] NumeroSerie([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroSerie)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_NumeroSerie(ref NumeroSerie);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] NumeroComprobanteFiscal([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroComprobanteFiscal)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_NumeroComprobanteFiscal(ref NumeroComprobanteFiscal);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override string[] SubTotal([MarshalAs(UnmanagedType.VBByRefStr)] ref string SubTotal)
    {
      int iResult = 0;
      string[] strError = new string[] { string.Empty, string.Empty };
      string strRetorno = string.Empty;
      iResult = classBematech32.Bematech_FI_SubTotal(ref SubTotal);
      strError = classBematech32.Analiza_iRetorno(iResult);
      strRetorno = classBematech32.Analiza_RetornoImpresora();

      return strError;
    }

    public override int VerificaImpresoraPrendida()
    {
      return classBematech32.Bematech_FI_VerificaImpresoraPrendida();
    }

    public override int ResetaImpresora()
    {
      return classBematech32.Bematech_FI_ResetaImpresora();
    }

    #endregion

  }
}
