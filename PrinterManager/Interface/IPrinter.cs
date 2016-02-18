using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PrinterManager
{
  public interface IPrinter
  {

    #region Funciones de Inicialización

    string[] ProgramarAlicuota(params string[] args);
    string[] ProgramarRedondeo(params string[] args);
    string[] ProgramarTruncamiento(params string[] args);

    #endregion

    #region Funciones del Cupon Fiscal

    string[] AbrirComprobanteVenta(params string[] args);
    string[] AbrirComprobanteVentaExtendido(params string[] args);
    string[] VenderArticulo(params string[] args);
    string[] AnularArticulo(params string[] args);
    string[] AnularComprobante(params string[] args);
    string[] CerrarComprobante(params string[] args);
    string[] IniciarCierreComprobante(params string[] args);
    string[] EfectuarPago(params string[] args);
    string[] FinalizarCierreComprobante(params string[] args);
    string[] DevolverArticulo(params string[] args);
    string[] AbrirNotaCredito(params string[] args);

    #endregion

    #region Funciones de los Informes Fiscales

    string[] LecturaX(params string[] args);
    string[] LecturaXSerial(params string[] args);
    string[] ReduccionZ(params string[] args);
    string[] InformeGerencial(params string[] args);
    string[] CierreInformeGerencial(params string[] args);

    #endregion

    #region Funciones de las Operaciones No Fiscales

    string[] RecebimientoNoFiscal(params string[] args);
    string[] AbreComprobanteNoFiscalVinculado(params string[] args);
    string[] ImprimeComprobanteNoFiscalVinculado(params string[] args);
    string[] CierraComprobanteNoFiscalVinculado(params string[] args);
    string[] Sangria(params string[] args);
    string[] Provision(params string[] args);

    #endregion

    #region Funciones de Informaciones de la Impresora

    string[] Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);
    string[] Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);
    string[] DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
    string[] DatosUltimaReduccionMFD([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
    string[] Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);
    string[] NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);
    string[] RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas);

    #endregion

    #region Funciones de Autenticación y Gaveta de Efectivo

    string[] AccionaGaveta();
    string[] Autenticacion();
    string[] ProgramaCaracterAutenticacion(params string[] args);
    string[] VerificaEstadoGaveta(out int EstadoGaveta);

    #endregion

    #region Otras Funciones

    string[] AbrePuertaSerial();
    string[] CierraPuertaSerial();
    string[] RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);
    string[] VerificaEstadoImpresora(ref int ACK, ref int ST1, ref int ST2);

    #endregion

  }
}
