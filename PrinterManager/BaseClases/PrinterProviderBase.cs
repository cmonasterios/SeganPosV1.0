using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager.Providers
{
  public abstract class PrinterProviderBase : ProviderBase
  {

    #region Protected Variables

    protected string _name;

    #endregion

    #region Public Properties

    public override string Name
    {
      get { return _name; }
    }
    protected string _description;

    public override string Description
    {
      get { return _description; }
    }

    #endregion

    #region Funciones de Inicialización

    public abstract string[] ProgramarAlicuota(params string[] args);
    public abstract string[] ProgramarRedondeo(params string[] args);
    public abstract string[] ProgramarTruncamiento(params string[] args);

    #endregion

    #region Funciones del Cupon Fiscal

    public abstract string[] AbrirComprobanteVenta(params string[] args);
    public abstract string[] AbrirComprobanteVentaExtendido(params string[] args);
    public abstract string[] VenderArticulo(params string[] args);
    public abstract string[] AnularArticulo(params string[] args);
    public abstract string[] AnularComprobante(params string[] args);
    public abstract string[] CerrarComprobante(params string[] args);
    public abstract string[] IniciarCierreComprobante(params string[] args);
    public abstract string[] EfectuarPago(params string[] args);
    public abstract string[] EfectuaFormaPagoDescripcionForma(params string[] args);
    public abstract string[] FinalizarCierreComprobante(params string[] args);

    public abstract string[] DevolverArticulo(params string[] args);
    public abstract string[] AbrirNotaCredito(params string[] args);
    public abstract string[] ImpresionCintaDetalle(params string[] args);

    #endregion

    #region Funciones de los Informes Fiscales

    public abstract string[] LecturaX(params string[] args);
    public abstract string[] LecturaXSerial(params string[] args);
    public abstract string[] ReduccionZ(params string[] args);
    public abstract string[] InformeGerencial(params string[] args);
    public abstract string[] CierreInformeGerencial(params string[] args);
    public abstract string[] LecturaMemoriaFiscalSerialReduccion(params string[] args);

    #endregion

    #region Funciones de las Operaciones No Fiscales

    public abstract string[] RecebimientoNoFiscal(params string[] args);
    public abstract string[] AbreComprobanteNoFiscalVinculado(params string[] args);
    public abstract string[] ImprimeComprobanteNoFiscalVinculado(params string[] args);
    public abstract string[] CierraComprobanteNoFiscalVinculado(params string[] args);
    public abstract string[] Sangria(params string[] args);
    public abstract string[] Provision(params string[] args);

    #endregion

    #region Funciones de Informaciones de la Impresora

    public abstract string[] Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);
    public abstract string[] Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);
    public abstract string[] DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
    public abstract string[] Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);
    public abstract string[] NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);
    public abstract string[] RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas);
    public abstract string[] LecturaMemoriaFiscalReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionInicial, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionFinal);
    public abstract string[] LecturaMemoriaFiscalFechaMFD([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaDesde, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FechasHasta, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FlagLectura);
    public abstract string[] FechaHoraImpresora([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora);
    public abstract string[] FechaHoraReducion([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora);
    public abstract string[] FechaHoraUltimoDocumento([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaHora);

    #endregion

    #region Funciones de Autenticación y Gaveta de Efectivo

    public abstract string[] AccionaGaveta();
    public abstract string[] Autenticacion();
    public abstract string[] ProgramaCaracterAutenticacion(params string[] args);
    public abstract string[] VerificaEstadoGaveta(out int EstadoGaveta);

    #endregion

    #region Otras Funciones

    public abstract string[] AbrePuertaSerial();
    public abstract string[] CierraPuertaSerial();
    public abstract string[] RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);
    public abstract string VerificaEstadoImpresora(ref int ACK, ref int ST1, ref int ST2);

    public abstract string[] NumeroReducciones([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroReducciones);
    public abstract string[] NumeroCupon([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCupon);
    public abstract string[] NumeroSerie([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroSerie);
    public abstract string[] NumeroComprobanteFiscal([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroComprobanteFiscal);
    public abstract string[] SubTotal([MarshalAs(UnmanagedType.VBByRefStr)] ref string SubTotal);
    public abstract int VerificaImpresoraPrendida();
    public abstract int ResetaImpresora();

    #endregion

  }
}
