using DisplayManager.Providers;
using Microsoft.Win32;
using SEGAN_POS.DAL;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public static class Util
  {
    #region External Declarations

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd,
                                           [MarshalAs(UnmanagedType.U4)] uint wMsgFilterMin,
                                           [MarshalAs(UnmanagedType.U4)] uint wMsgFilterMax,
                                           [MarshalAs(UnmanagedType.U4)] uint wRemoveMsg);

    #endregion External Declarations

    #region Private Constants

    private const int PM_NOREMOVE = 0;
    private const int PM_REMOVE = 1;
    private const int WM_KEYFIRST = 256;
    private const int WM_KEYLAST = 264;
    private const int WM_MOUSEFIRST = 512;
    private const int WM_MOUSELAST = 521;

    #endregion Private Constants

    #region Private Types

    [StructLayout(LayoutKind.Sequential)]
    internal struct MSG
    {
      public IntPtr hwnd;

      [MarshalAs(UnmanagedType.U4)]
      public int message;

      public IntPtr wParam;
      public IntPtr lParam;

      [MarshalAs(UnmanagedType.U4)]
      public int time;

      public Point pt;
    }

    #endregion Private Types

    #region Redondeo

    public static decimal TruncarDecimal(decimal value, int precision)
    {
      decimal step = (decimal)Math.Pow(10, precision);
      int tmp = (int)Math.Truncate(step * value);
      return tmp / step;
    }

    #endregion Redondeo

    #region Parametros

    public static string ObtenerParametroCadena(string codigo)
    {
      string result = string.Empty;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo).ValorCadena;
      }
      catch { }

      return result;
    }

    public static string ObtenerParametroCadena(string codigo, DateTime fecha)
    {
      string result = string.Empty;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo, fecha).ValorCadena;
      }
      catch { }

      return result;
    }

    public static decimal ObtenerParametroDecimal(string codigo)
    {
      decimal result = 0;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo).ValorNumerico.Value;
      }
      catch { }

      return result;
    }

    public static decimal ObtenerParametroDecimal(string codigo, DateTime fecha)
    {
      decimal result = 0;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo, fecha).ValorNumerico.Value;
      }
      catch { }

      return result;
    }

    public static int ObtenerParametroEntero(string codigo)
    {
      int result = 0;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo).ValorEntero.Value;
      }
      catch { }

      return result;
    }

    public static int ObtenerParametroEntero(string codigo, DateTime fecha)
    {
      int result = 0;

      try {
        result = EstadoAplicacion.GetParametroSistema(codigo, fecha).ValorEntero.Value;
      }
      catch { }

      return result;
    }

    #endregion Parametros

    #region Red

    public static string GetIP()
    {
      string result = string.Empty;

      try {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
          if (nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 &&
            nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
            continue;

          if (nic.OperationalStatus == OperationalStatus.Up) {
            foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
              if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                result = ip.Address.ToString();
                break;
              }
            break;
          }
        }
      }
      catch { }

      return result;
    }

    public static string GetMAC()
    {
      string result = string.Empty;

      try {
        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
          if (nic.NetworkInterfaceType != NetworkInterfaceType.Wireless80211 &&
            nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
            continue;

          if (nic.OperationalStatus == OperationalStatus.Up) {
            result = nic.GetPhysicalAddress().ToString();
            break;
          }
        }
      }
      catch { }

      return result;
    }

    public static bool IsConnectedToInternet()
    {
      int desc;
      return InternetGetConnectedState(out desc, 0);
    }

    [DllImport("wininet.dll")]
    private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

    #endregion Red

    #region Cadenas

    public static string CenterString(string originalString, int desiredLength)
    {
      string result = originalString;

      result = TruncarCadena(result, desiredLength);

      if (result.Length == desiredLength)
        return result;

      result = result.PadLeft(((desiredLength - result.Length) / 2) + result.Length);

      return result;
    }

    /// <summary>
    /// Fuente: http://stackoverflow.com/questions/2566793/string-replace-diacritics-in-c-sharp
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string StripAccents(string input)
    {
      string normalized = input.Normalize(NormalizationForm.FormKD);
      Encoding removal = Encoding.GetEncoding(Encoding.ASCII.CodePage, new EncoderReplacementFallback(""), new DecoderReplacementFallback(""));
      byte[] bytes = removal.GetBytes(normalized);

      return Encoding.ASCII.GetString(bytes);
    }

    public static string TruncarCadena(string source, int length, bool dots = false, bool trim = true)
    {
      if (trim)
        source = source.Trim();

      if (string.IsNullOrEmpty(source))
        return source;

      if (source.Length > length)
        source = source.Substring(0, length);

      if (dots)
        source += "...";

      return source;
    }

    /// <summary>
    /// Fuente: http://devio.wordpress.com/2010/01/26/stripping-accents-from-strings-in-c/
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    /*public static string StripAccents(string s)
    {
      StringBuilder sb = new StringBuilder();

      foreach (char c in s.Normalize(NormalizationForm.FormKD))
        switch (CharUnicodeInfo.GetUnicodeCategory(c)) {
          case UnicodeCategory.NonSpacingMark:
          case UnicodeCategory.SpacingCombiningMark:
          case UnicodeCategory.EnclosingMark:
            break;

          default:
            sb.Append(c);
            break;
        }

      return sb.ToString();
    }*/

    #endregion Cadenas

    #region Imagenes

    public static byte[] ToByteArray(this Image image, ImageFormat format)
    {
      using (MemoryStream ms = new MemoryStream()) {
        image.Save(ms, format);
        return ms.ToArray();
      }
    }

    public static Image ToImage(this byte[] byteArray)
    {
      using (MemoryStream ms = new MemoryStream(byteArray)) {
        Image returnImage = Image.FromStream(ms);
        return returnImage;
      }
    }

    #endregion Imagenes

    #region Archivos

    public static string GetMimeType(FileInfo fileInfo)
    {
      string mimeType = "application/unknown";

      try {
        RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(fileInfo.Extension.ToLower());

        if (regKey != null) {
          object contentType = regKey.GetValue("Content Type");

          if (contentType != null)
            mimeType = contentType.ToString();
        }
      }
      catch { }

      return mimeType;
    }

    public static bool SaveConfigSetting(string settingName, string settingValue)
    {
      bool result = false;

      try {
        //Create the object
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        //make changes
        config.AppSettings.Settings[settingName].Value = settingValue;

        //save to apply changes
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");

        result = true;
      }
      catch { }

      return result;
    }

    #endregion Archivos

    #region Dispositivos

    public static void IniciarVisor()
    {
      if (!EstadoAplicacion.TieneVisor)
        return;

      if (EstadoAplicacion.TiendaActual == null || EstadoAplicacion.CajaActual == null)
        return;

      try {
        BematechDisplay visorManager = new BematechDisplay();

        using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
          visorManager.ClearDisplay(serialPort);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, Util.StripAccents("EPK " + EstadoAplicacion.TiendaActual.Descripcion), DisplayManagerEnum.Alineacion.Centrado);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, Util.StripAccents(EstadoAplicacion.CajaActual.Descripcion), DisplayManagerEnum.Alineacion.Centrado);
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    public static bool VerificarImpresora(string formName, bool skipAuth = false)
    {
      bool result = false;

      try {
        Impresora impresora = new Impresora();

        int impLinea = impresora.EnLinea();
        if (string.IsNullOrEmpty(impresora.Serial)) {
          bool isOK = false;
          while (MessageBox.Show(Properties.Resources.MsgImpNoResp, "Error de Impresora", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
            impLinea = impresora.Refrescar();
            if (!string.IsNullOrEmpty(impresora.Serial)) {
              isOK = true;
              break;
            }
          }
          if (!isOK)
            return false;
        }

        if (impLinea == 2) {
          int? idAut = null;


          if (!skipAuth) {
            if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, formName, "Anular_Factura")) {
              frmAutorizar fAut = new frmAutorizar();
              fAut.Mensaje = Properties.Resources.MsgAutorizarAnul;
              fAut.NombreTecnico = formName;
              fAut.Accion = "Anular_Factura";
              fAut.Obligatoria = true;
              fAut.ShowDialog();

              if (fAut.UsuarioAutorizador != null)
                idAut = fAut.UsuarioAutorizador.IdUsuario;
            }
          }
          else {
            idAut = EstadoAplicacion.UsuarioActual.IdUsuario;
          }

          string ticketFiscal = impresora.NroComprobanteFiscal();
          string COO = impresora.NroCupon();

          impresora.AnularComprobante();

          new Facturas().Anular(COO, ticketFiscal, idAut);

          impresora.Refrescar();

          MessageBox.Show(string.Format(Properties.Resources.MsgCuponAnulado, ticketFiscal), "Cupón Anulado",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        result = true;
      }
      catch (Exception ex) {
        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = false;
      }

      return result;
    }

    #endregion Dispositivos

    #region Configuracion

    /// <summary>
    ///
    /// </summary>
    /// <param name="section"></param>
    /// <returns></returns>
    public static bool RefreshConfig(string section)
    {
      try {
        ConfigurationManager.RefreshSection(section);
        return true;
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
    /// <param name="settingName"></param>
    /// <param name="settingValue"></param>
    /// <param name="refresh"></param>
    /// <returns></returns>
    public static bool SetAppSettingsValue(string settingName, string settingValue, bool refresh = true)
    {
      try {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        config.AppSettings.Settings[settingName].Value = settingValue;
        config.Save(ConfigurationSaveMode.Modified);

        if (refresh)
          ConfigurationManager.RefreshSection("appSettings");

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public static EPK_Contingencia ValoresContingencia()
    {
      try {
        EPK_Contingencia result = new EPK_Contingencia();

        int ultFactura, ultPago, ultNC, ultCliente, ultCierreVentas;
        long ultApertura, ultAlivio, ultCierreCajero;

        int.TryParse(ConfigurationManager.AppSettings["UltimaFactura"], out ultFactura);
        int.TryParse(ConfigurationManager.AppSettings["UltimoPago"], out ultPago);
        int.TryParse(ConfigurationManager.AppSettings["UltimaNC"], out ultNC);
        int.TryParse(ConfigurationManager.AppSettings["UltimoCliente"], out ultCliente);
        long.TryParse(ConfigurationManager.AppSettings["UltimaApertura"], out ultApertura);
        long.TryParse(ConfigurationManager.AppSettings["UltimoAlivio"], out ultAlivio);
        long.TryParse(ConfigurationManager.AppSettings["UltimoCierreCajero"], out ultCierreCajero);
        int.TryParse(ConfigurationManager.AppSettings["UltimoCierreVentas"], out ultCierreVentas);

        result.IdFactura = ultFactura;
        result.IdPago = ultPago;
        result.IdNotaC = ultNC;
        result.IdCliente = ultCliente;
        result.IdApertura = ultApertura;
        result.IdAlivioEfectivo = ultAlivio;
        result.IdCierre = ultCierreCajero;
        result.IdCierreV = ultCierreVentas;

        return result;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    #endregion Configuracion

    #region Cola de Mensajes

    /// <summary>
    /// Limpa la cola de mensajes de la aplicación.
    /// </summary>
    public static void ClearMessages(bool includeMouse = true)
    {
      MSG lpMsg;

      while (PeekMessage(out lpMsg, IntPtr.Zero, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)) ;

      if (includeMouse)
        while (PeekMessage(out lpMsg, IntPtr.Zero, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE)) ;
    }

    #endregion Cola de Mensajes

    #region Contingencia

    public static bool VerificarValoresContingencia()
    {
      try {
        if (!EstadoAplicacion.PermitirContingencia || EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
          return false;

        EPK_Contingencia datosCont = Util.ValoresContingencia();

        if (datosCont == null)
          return false;

        if (datosCont.IdFactura == 0) {
          int ultFactura = new Facturas().ObtenerUltimoId(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimaFactura", ultFactura.ToString(), false);
        }

        if (datosCont.IdPago == 0) {
          int ultPago = new Facturas().ObtenerUltimoIdPago(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimoPago", ultPago.ToString(), false);
        }

        if (datosCont.IdNotaC == 0) {
          int ultNC = new NotasCredito().ObtenerUltimoId(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimaNC", ultNC.ToString(), false);
        }

        if (datosCont.IdCliente == 0) {
          int ultCliente = new Clientes().ObtenerUltimoId();
          Util.SetAppSettingsValue("UltimoCliente", ultCliente.ToString(), false);
        }

        if (datosCont.IdApertura == 0) {
          long ultApertura = new AperturaCajero().ObtenerUltimoId(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimaApertura", ultApertura.ToString(), false);
        }

        if (datosCont.IdAlivioEfectivo == 0) {
          long ultAlivio = new AlivioEfectivo().ObtenerUltimoId(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimoAlivio", ultAlivio.ToString(), false);
        }

        if (datosCont.IdCierre == 0) {
          long ultCierreCajero = new CierreCajero().ObtenerUltimoId(EstadoAplicacion.CajaActual.IdCaja);
          Util.SetAppSettingsValue("UltimoCierreCajero", ultCierreCajero.ToString(), false);
        }

        if (datosCont.IdCierreV == 0) {
          int ultCierreVentas = new CierreVentas().ObtenerUltimoId();
          Util.SetAppSettingsValue("UltimoCierreVentas", ultCierreVentas.ToString(), false);
        }

        Util.RefreshConfig("appSettings");

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    #endregion Contingencia

    #region Clientes

    public static string GenDocCliente(EPK_Cliente cliente, bool truncar = false)
    {
      string result = string.Empty;

      if (cliente.EPK_TipoDocumento.PersonaNatural) {
        result = cliente.EPK_TipoDocumento.Sigla + "-" + cliente.NumeroDocumento;
      }
      else {
        result = cliente.EPK_TipoDocumento.Sigla + "-" +
          cliente.NumeroDocumento.Substring(0, cliente.NumeroDocumento.Length - 1) + "-" +
          cliente.NumeroDocumento.Substring(cliente.NumeroDocumento.Length - 1, 1);
      }

      if (truncar && result.Length > 18) {
        result = Regex.Replace(result, "[^a-zA-Z0-9]", "");
        result = TruncarCadena(result, 18);
        result = StripAccents(result);
      }

      return result;
    }

    public static string GenNomCliente(EPK_Cliente cliente, bool truncar = false)
    {
      string result = string.Empty;

      if (cliente.EPK_TipoDocumento.PersonaNatural)
        result = cliente.Nombre + " " + cliente.Apellido;
      else
        result = cliente.Nombre + cliente.Apellido;

      if (truncar) {
        result = TruncarCadena(result, 100);
        result = StripAccents(result);
      }

      return result;
    }

    #endregion Clientes
  }
}