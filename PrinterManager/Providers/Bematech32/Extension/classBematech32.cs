using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PrinterManager.Providers.Bematech32.Extension
{
  public class classBematech32
  {

    #region Funciones de tratamiento de error

    /// <summary>
    /// Función para analizar los retorno de la impresora (ST1 y ST2).
    /// </summary>
    public static string Analiza_RetornoImpresora()
    {
      int ACK, ST1, ST2;
      string Errores = "";
      ACK = ST1 = ST2 = 0;

      Bematech_FI_RetornoImpresora(ref ACK, ref ST1, ref ST2);

      #region Tratando o ST1

      if (ST1 >= 128) {
        ST1 = ST1 - 128;
        Errores += "BIT 7 - Fin de Papel" + '\x0D';
      }
      if (ST1 >= 64) {
        ST1 = ST1 - 64;
        Errores += "BIT 6 - Poco Papel" + '\x0D';
      }
      if (ST1 >= 32) {
        ST1 = ST1 - 32;
        Errores += "BIT 5 - Error en el Reloj" + '\x0D';
      }
      if (ST1 >= 16) {
        ST1 = ST1 - 16;
        Errores += "BIT 4 - Impresora en ERROR" + '\x0D';
      }
      if (ST1 >= 8) {
        ST1 = ST1 - 8;
        Errores += "BIT 3 - CMD não iniciado com ESC" + '\x0D';
      }
      if (ST1 >= 4) {
        ST1 = ST1 - 4;
        Errores += "BIT 2 - Comando Inexistente" + '\x0D';
      }
      if (ST1 >= 2) {
        ST1 = ST1 - 2;
        Errores += "BIT 1 - Comprobante Abierto" + '\x0D';
      }
      if (ST1 >= 1) {
        ST1 = ST1 - 1;
        Errores += "BIT 0 - Nº de Parámetros Inválidos" + '\x0D';
      }

      #endregion

      #region Tratando o ST2

      if (ST2 >= 128) {
        ST2 = ST2 - 128;
        Errores += "BIT 7 - Tipo de Parámetro Inválido" + '\x0D';
      }
      if (ST2 >= 64) {
        ST2 = ST2 - 64;
        Errores += "BIT 6 - Memória Fiscal Llena" + '\x0D';
      }
      if (ST2 >= 32) {
        ST2 = ST2 - 32;
        Errores += "BIT 5 - CMOS noo Volátil" + '\x0D';
      }
      if (ST2 >= 16) {
        ST2 = ST2 - 16;
        Errores += "BIT 4 - Alicuota no programada" + '\x0D';
      }
      if (ST2 >= 8) {
        ST2 = ST2 - 8;
        Errores += "BIT 3 - Alicuotas llenas" + '\x0D';
      }
      if (ST2 >= 4) {
        ST2 = ST2 - 4;
        Errores += "BIT 2 - Anulación no permitida" + '\x0D';
      }
      if (ST2 >= 2) {
        ST2 = ST2 - 2;
        Errores += "BIT 1 - RIF no programado" + '\x0D';
      }
      if (ST2 >= 1) {
        ST2 = ST2 - 1;
        Errores += "BIT 0 - Comando no ejecutado" + '\x0D';
      }

      #endregion

      return Errores;
      //if (Errores.Length != 0)
      //    System.Windows.Forms.MessageBox.Show(Errores, "Error en la ejecución del comando", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Função que analiza o retorno da função.
    /// </summary>
    /// <param name="IRetorno">Inteiro com o valor a ser analizado.</param>
    public static string[] Analiza_iRetorno(int IRetorno)
    {
      string MSG = "";
      string MSGCaption = "Atención";
      //MessageBoxIcon MSGIco = MessageBoxIcon.Information;

      switch (IRetorno) {
        case 0:
          MSG = "Error de Comunicación !";
          MSGCaption = "Error";
          //MSGIco = MessageBoxIcon.Error;
          break;
        case -1:
          MSG = "Error de ejecución en la función. Verifique!";
          MSGCaption = "Error";
          //MSGIco = MessageBoxIcon.Error;
          break;
        case -2:
          MSG = "Parámetro Inválido !";
          MSGCaption = "Error";
          //MSGIco = MessageBoxIcon.Error;
          break;
        case -3:
          MSG = "Alicuota no programada !";
          break;
        case -4:
          MSG = "Archivo BemaFI32.INI no encontrado. Verifique!";
          break;
        case -5:
          MSG = "Error al abrir el puerto de comunicación";
          MSGCaption = "Error";
          //MSGIco = MessageBoxIcon.Error;
          break;
        case -6:
          MSG = "Impresora apagada o desconectada.";
          break;
        case -7:
          MSG = "Banco no registrado en el Archivo BemaFI32.ini";
          break;
        case -8:
          MSG = "Error al crear o Grabar en el archivo Retorno.txt o Status.txt.";
          MSGCaption = "Error";
          //MSGIco = MessageBoxIcon.Error;
          break;
        case -18:
          MSG = "No fué posíble abrir el archivo INTPOS.001!";
          break;
        case -19:
          MSG = "Parámetros diferentes!";
          break;
        case -20:
          MSG = "Transación anulada por el operador!";
          break;
        case -21:
          MSG = "La transación no fué aprobada!";
          break;
        case -22:
          MSG = "No fué posible finalizar la impresión!";
          break;
        case -23: MSG = "No fué posible finalizar la operación!";
          break;
        case -24: MSG = "No fué posible finalizar la operación!";
          break;
        case -25: MSG = "Totalizador no fiscal no programado.";
          break;
        case -26: MSG = "Transación ya efectuada!";
          break;
        case -27: Analiza_RetornoImpresora();
          break;
        case -28: MSG = "No hay informaciones para imprimir!";
          break;
      }
      //if (MSG.Length != 0)
      //    System.Windows.Forms.MessageBox.Show(MSG, MSGCaption, MessageBoxButtons.OK, MSGIco);
      return new string[] { MSG, MSGCaption };
    }

    #endregion

    #region DECLARACIÓN DE LAS FUNCIONES DE LA BemaFI32.DLL

    #region Funciones de Inicialización

    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ProgramaAlicuota(string Alicuota, int ICMS_ISS);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ProgramaRedondeo();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ProgramaTruncamiento();

    #endregion

    #region Funciones del Cupon Fiscal

    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AbreComprobanteDeVenta(string RIF, string Nombre);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AbreComprobanteDeVentaEx(string RIF, string Nombre, string Direccion);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_VendeArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnitario, string TipoDescuento, string Descuento);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AnulaArticuloAnterior();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AnulaCupon();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_CierraCupon(string FormaPago, string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento, string ValorPago, string Mensaje);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_IniciaCierreCupon(string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_EfectuaFormaPago(string FormaPago, string ValorFormaPago);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_EfectuaFormaPagoDescripcionForma(string FormaPago, string ValorFormaPago, string DescripcionFormaPago);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_FinalizarCierreCupon(string Mensaje);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_DevolucionArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnit, string TipoDescuento, string ValorDesc);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ImpresionCintaDetalle(string cTipo, string cDadoInicial, string cDadoFinal, string cUsuario);

    #endregion

    #region Funciones de los Informes Fiscales

    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_LecturaX();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_LecturaXSerial();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ReduccionZ(string Fecha, string Hora);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_InformeGerencial(string Texto);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_CierraInformeGerencial();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_LecturaMemoriaFiscalSerialReduccion(string ReduccionInicial, string ReduccionFinal);

    #endregion

    #region Funciones de las Operaciones No Fiscales
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_RecebimientoNoFiscal(string IndiceTotalizador, string Valor, string FormaPago);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AbreComprobanteNoFiscalVinculado(string FormaPago, string Valor, string NumeroCupon);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ImprimeComprobanteNoFiscalVinculado(string Texto);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_CierraComprobanteNoFiscalVinculado();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Sangria(string Valor);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Provision(string Valor, string FormaPago);
    #endregion

    #region Funciones de Informaciones de la Impresora

    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_LecturaMemoriaFiscalReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionInicial, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReduccionFinal);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_LecturaMemoriaFiscalFechaMFD([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaDesde, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FechasHasta, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FlagLectura);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_FechaHoraImpresora([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_FechaHoraReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string Fecha, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Hora);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_FechaHoraUltimoDocumentoMFD([MarshalAs(UnmanagedType.VBByRefStr)] ref string FechaHora);

    #endregion

    #region Funciones de Autenticación y Gaveta de Efectivo
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AccionaGaveta();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_Autenticacion();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ProgramaCaracterAutenticacion(string Parametros);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_VerificaEstadoGaveta(out int EstadoGaveta);
    #endregion

    #region Otras Funciones

    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_AbrePuertaSerial();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_CierraPuertaSerial();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_VerificaEstadoImpresora(ref int ACK, ref int ST1, ref int ST2);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_NumeroReducciones([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroReducciones);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_NumeroCupon([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCupon);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_NumeroSerie([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroSerie);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_NumeroComprobanteFiscal([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroComprobanteFiscal);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_SubTotal([MarshalAs(UnmanagedType.VBByRefStr)] ref string SubTotal);
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_VerificaImpresoraPrendida();
    [DllImport("BemaFI32.dll")]
    public static extern int Bematech_FI_ResetaImpresora();

    #endregion

    #endregion

  }
}
