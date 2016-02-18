using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;

namespace SEGAN_POS
{
  #region Enums

  /// <summary>
  /// Estado actual de la contingencia.
  /// </summary>
  public enum EstadoContingencia
  {
    /// <summary>
    /// Operación normal (contingencia inactiva)
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Contingencia activada. Esperando por activación de la contingencia.
    /// </summary>
    Espera,

    /// <summary>
    /// Contingencia Activa.
    /// </summary>
    Activa,

    /// <summary>
    /// Esperando regreso a operación normal.
    /// </summary>
    Regreso
  }

  #endregion Enums

  /// <summary>
  /// Manejo de parámetros y estado general de la aplicación.
  /// </summary>
  public static class EstadoAplicacion
  {
    #region Private Properties

    private static List<EPK_Estatus> _estatus { get; set; }

    private static List<EPK_ParametrosSistema> _parametrosSistema { get; set; }
    #endregion Private Properties

    #region Public Properties

    // Configuración de la Caja
    public static bool AplicaImpuesto { get; private set; }

    public static bool ExisteIVA { get; private set; }

    public static bool ValorIVA { get; private set; }

    public static decimal IVA { get; private set; }

    public static EPK_Caja CajaActual { get; private set; }

    public static string CaracterGuion { get; private set; }

    public static EstadoContingencia Contingencia { get; private set; }

    public static int EsperaDuplicado { get; private set; }

    public static Dictionary<string, short> EstadosAlivio { get; private set; }

    public static Dictionary<string, short> EstadosFactura { get; private set; }

    public static Dictionary<string, short> MinimaLongitud { get; private set; }

    public static Dictionary<string, short> EstadosNC { get; private set; }

    public static int IDApp { get; private set; }

    public static int IntervaloTimer { get; private set; }

    // Otros datos necesarios para la operación. Se mantienen en memoria
    public static List<EPK_Politica> ListaPoliticas { get; private set; }

    public static bool PermitirContingencia { get; private set; }

    public static bool PermitirIngresoEfectivo { get; private set; }

    public static string PuertoVisor { get; private set; }

    public static string SerialImpresora { get; private set; }

    // Session bloqueada
    public static bool SessionLocked { get; private set; }

    // Valores del app.config
    public static bool ShellMode { get; private set; }

    // Controla si se deben saltar las validaciones normales de una caja (dispositivos, biométrico)
    public static bool SkipValidation { get; private set; }

    public static EPK_Tienda TiendaActual { get; private set; }

    public static bool TieneGaveta { get; private set; }

    public static bool TieneImpresora { get; private set; }

    public static bool TieneVisor { get; private set; }

    // Valores de EPK_ParametrosSistema
    public static int TimeoutFacturaEspera { get; set; }

    // Defaults
    public static Color ToastColor { get; private set; }
    public static int ToastTimeout { get; private set; }
    public static int BloqueoTimeout { get; private set; }
      

    // Usuario activo actualmente en el sistema
    public static EPK_Usuario UsuarioActual { get; private set; }

    public static string VersionBaseDatos { get; private set; }

    public static bool RestriccionVentasMayor { get; private set; }

    public static bool TemporadaComision { get; private set; }

    #endregion Public Properties

    #region Constructor

    static EstadoAplicacion()
    {
      TieneGaveta = false;
      TieneImpresora = false;
      TieneVisor = false;
      SerialImpresora = string.Empty;

      _parametrosSistema = null;
      _estatus = null;
      UsuarioActual = null;
      TiendaActual = null;
      CajaActual = null;
      ListaPoliticas = new List<EPK_Politica>();
      EstadosFactura = new Dictionary<string, short>();
      EstadosAlivio = new Dictionary<string, short>();
      EstadosNC = new Dictionary<string, short>();
      Contingencia = EstadoContingencia.Normal;
      IntervaloTimer = 5;
      PermitirContingencia = false;
      ToastTimeout = 1000;
      PermitirIngresoEfectivo = false;

      AplicaImpuesto = true;

      ToastColor = Color.Gray;

      ShellMode = false;
      IDApp = 0;
      EsperaDuplicado = 0;

      SessionLocked = false;
      SkipValidation = false;

      try {
        bool tempBool;
        bool.TryParse(ConfigurationManager.AppSettings["ShellMode"], out tempBool);
        ShellMode = tempBool;

        int tempInt;
        int.TryParse(ConfigurationManager.AppSettings["IDApp"], out tempInt);
        IDApp = tempInt;

        CaracterGuion = ConfigurationManager.AppSettings["CaracterGuion"];

        int.TryParse(ConfigurationManager.AppSettings["EsperaDuplicado"], out tempInt);
        EsperaDuplicado = tempInt;
        if (EsperaDuplicado == 0)
          EsperaDuplicado = 3;

        VersionBaseDatos = ConfigurationManager.AppSettings["VersionBaseDatos"];

        int.TryParse(ConfigurationManager.AppSettings["Timer"], out tempInt);
        IntervaloTimer = tempInt;

        if (IntervaloTimer <= 0)
          IntervaloTimer = 5;

        bool.TryParse(ConfigurationManager.AppSettings["PermitirContingencia"], out tempBool);
        PermitirContingencia = tempBool;

        int.TryParse(ConfigurationManager.AppSettings["EstadoContingencia"], out tempInt);
        Contingencia = (EstadoContingencia)tempInt;

        int.TryParse(ConfigurationManager.AppSettings["ToastTimeout"], out tempInt);
        ToastTimeout = tempInt * 1000;
        if (ToastTimeout == 0)
          ToastTimeout = 1000;

        int.TryParse(ConfigurationManager.AppSettings["BloqueoTimeout"], out tempInt);
        BloqueoTimeout = tempInt * 1000;
        if (BloqueoTimeout == 0)
            BloqueoTimeout = 1000;

        PuertoVisor = ConfigurationManager.AppSettings["PuertoVisor"];
        if (string.IsNullOrEmpty(PuertoVisor))
          PuertoVisor = "COM1";
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion Constructor

    #region Public Methods

    public static bool CargaInicial()
    {
      bool result = false;

      try {
        if (!EstadoAplicacion.SkipValidation) {
          // Se comprueba si tiene gaveta, visor e impresora configurada.
          if (CajaActual == null)
            return result;

          if (CajaActual.EPK_CajaDispositivo == null)
            return result;

          int estatusActivo = GetEstatus("Activo");
          if (estatusActivo > 0) {
            int idGav = Util.ObtenerParametroEntero("IdGaveta");
            if (idGav > 0)
              TieneGaveta = CajaActual.EPK_CajaDispositivo.Where(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idGav &&
                cd.EPK_Dispositivo.IdEstatus == estatusActivo).Count() > 0;

            int idVisor = Util.ObtenerParametroEntero("IdVisor");
            if (idVisor > 0)
              TieneVisor = CajaActual.EPK_CajaDispositivo.Where(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idVisor &&
                cd.EPK_Dispositivo.IdEstatus == estatusActivo).Count() > 0;

            int idImpresora = Util.ObtenerParametroEntero("IdImpresora");
            if (idImpresora > 0)
              TieneImpresora = CajaActual.EPK_CajaDispositivo.Where(cd => cd.EPK_Dispositivo.IdTipoDispositivo == idImpresora &&
                cd.EPK_Dispositivo.IdEstatus == estatusActivo).Count() > 0;
          }
        }

        ListaPoliticas = new Politicas().Obtener(true);

        if (!CargarEstadosFactura())
          return result;

        if (!CargarMinimaLongitud())
            return result;

        if (!CargarEstadosNC())
          return result;

        if (!CargarEstadosAlivio())
          return result;

        TimeoutFacturaEspera = Util.ObtenerParametroEntero("TIMEOUTFacturaEspera");
        if (TimeoutFacturaEspera == 0)
          TimeoutFacturaEspera = 300;

        int DiasIngresoEfectivo = Util.ObtenerParametroEntero("DIASINGRESOEFECTIVO");
        if (DiasIngresoEfectivo == 0)
          DiasIngresoEfectivo = 1;

        DateTime? FechaUltimaContingencia = new Contingencia(false).FechaUltimaContingencia();
        DateTime currDate = new DataAccess(true).FechaDB();

        if (FechaUltimaContingencia.HasValue)
            if ((currDate.Date - FechaUltimaContingencia.Value.Date).TotalDays <= DiasIngresoEfectivo)
            PermitirIngresoEfectivo = true;

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        result = false;
      }

      return result;
    }

    public static bool CargarCaja()
    {
      bool result = false;

      try {
        // Se busca la caja por MAC Address.
        string MAC = Util.GetMAC();

        if (!string.IsNullOrEmpty(MAC))
          CajaActual = new Cajas(true).BuscarPorMAC(MAC);

        if (CajaActual == null) { // Si no se encuentra, se busca por IP.
          string IP = Util.GetIP();

          if (!string.IsNullOrEmpty(IP))
            CajaActual = new Cajas(true).BuscarPorIP(IP);

          if (CajaActual != null && !string.IsNullOrEmpty(MAC)) { // Y se actualiza la MAC Address.
            CajaActual.DireccionMAC = MAC;
            new Cajas(true).Actualizar(CajaActual);
          }
        }

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public static bool CargarEstadosAlivio()
    {
      string[] nombresParam = { "ALICreacion", "ALIAprobacion" };

      try {
        EstadosAlivio = new Dictionary<string, short>();

        foreach (string nombreItem in nombresParam) {
          short valor = (short)Util.ObtenerParametroEntero(nombreItem);
          if (valor > 0)
            EstadosAlivio.Add(nombreItem, valor);
        }

        if (EstadosAlivio.Count() == nombresParam.Count())
          return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        EstadosAlivio = new Dictionary<string, short>();
      }

      return false;
    }

    public static bool CargarMinimaLongitud()
    {
        string[] nombresParam = { "MinLengthID","MinLengthPhone","MinLengthAddress","MinLengthLastName","MinLengthName" };

        try
        {
            MinimaLongitud = new Dictionary<string, short>();

            foreach (string nombreItem in nombresParam)
            {
                short valor = (short)Util.ObtenerParametroEntero(nombreItem);
                if (valor > 0)
                    MinimaLongitud.Add(nombreItem, valor);
            }

            if (MinimaLongitud.Count() == nombresParam.Count())
                return true;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
            EstadosFactura = new Dictionary<string, short>();
        }

        return false;
    }



    public static bool CargarEstadosFactura()
    {
      string[] nombresParam = { "FACCreada", "FACAprobada", "FACCancelada", "FACAnulada", "FACExpirada", "FACProcesada" };

      try {
        EstadosFactura = new Dictionary<string, short>();

        foreach (string nombreItem in nombresParam) {
          short valor = (short)Util.ObtenerParametroEntero(nombreItem);
          if (valor > 0)
            EstadosFactura.Add(nombreItem, valor);
        }

        if (EstadosFactura.Count() == nombresParam.Count())
          return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        EstadosFactura = new Dictionary<string, short>();
      }

      return false;
    }

    public static bool CargarEstadosNC()
    {
      string[] nombresParam = { "NCCreada", "NCAprobada", "NCEnviada", "NCRecibida", "NCEmitida", "NCRechazada", "NCAnulada" };

      try {
        EstadosNC = new Dictionary<string, short>();

        foreach (string nombreItem in nombresParam) {
          short valor = (short)Util.ObtenerParametroEntero(nombreItem);
          if (valor > 0)
            EstadosNC.Add(nombreItem, valor);
        }

        if (EstadosNC.Count() == nombresParam.Count())
          return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        EstadosNC = new Dictionary<string, short>();
      }

      return false;
    }

    public static bool CargarEstatus()
    {
      bool result = false;

      try {
        if (_estatus == null)
          _estatus = new Estatus(true).ObtenerTodos().ToList();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        result = false;
      }

      return result;
    }

    public static bool CargarParametros()
    {
      bool result = false;

      try {
        if (_parametrosSistema == null)
          _parametrosSistema = new Parametros(true).ObtenerTodos().ToList();

        result = _parametrosSistema != null;

        ValorIVA = _parametrosSistema.Any(p => p.CodParametro == "IVA") ?
                (_parametrosSistema.Find(p => p.CodParametro == "IVA").ValorNumerico.Value > 0) : false;

        ExisteIVA = EstadoAplicacion._parametrosSistema.Any(p => p.CodParametro == "IVA");
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        result = false;
      }

      return result;
    }

    public static bool CargarTienda()
    {
      bool result = false;

      try
      {
          TiendaActual = new Tiendas().ObtenerPrimera();

          if (TiendaActual == null)
              return result;

          AplicaImpuesto = TiendaActual.EPK_TipoTienda.AplicaImpuesto;

      

          RestriccionVentasMayor = (new Parametros().ObtenerValorEntero("EstatusRestriccion") > 0);

          TemporadaComision = (new Parametros().ObtenerValorEntero("TemporadaComision") > 0);

          string IP = Util.GetIP();

          if (TiendaActual.DireccionIP == IP)
          {
              int? IdMaqFiscal = new Parametros().Obtener("IdImpresora").ValorEntero;
              int? IdEstActivo = new Parametros().Obtener("ESTActivo").ValorEntero;

              EPK_Caja Caja = new Cajas().BuscarPorIP(IP);

              if (Caja.IdCaja > 0)
              {
                  if (!(Caja.EPK_CajaDispositivo.Where(cd => cd.EPK_Dispositivo.IdTipoDispositivo == IdMaqFiscal && cd.EPK_Dispositivo.IdEstatus == IdEstActivo && 
                      !cd.FechaFin.HasValue).Count() > 0))
                      EstadoAplicacion.SkipValidation = true;
              }
          }

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

    //public static string ValidarConfigImpuestos()
    //{
    //    try
    //    {
    //        bool AI = AplicaImpuesto;
    //        bool TI = EstadoAplicacion._parametrosSistema.Any(p => p.CodParametro == "IVA");
    //        bool IV = _parametrosSistema.Any(p => p.CodParametro == "IVA") ?
    //                  (_parametrosSistema.Find(p => p.CodParametro == "IVA").ValorNumerico.Value > 0) : false;

    //        if ((!AI && !TI && !IV) || (!AI && !TI && IV) || (AI && TI && IV))
    //            return string.Empty;

    //        //Retorna los mensajes de errores
    //        if (AI && !TI)
    //            return Properties.Resources.ErrorTiendaSinIva;

    //        if (AI && TI && !IV)
    //            return Properties.Resources.ErrorTiendaIvaInv;

    //        if ((!AI && TI && IV))
    //            return Properties.Resources.ErrorTiendaImpNA;

    //        return Properties.Resources.ErrorTiendaImpGen;
    //    }
    //    catch (Exception ex)
    //    {
    //        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." +
    //                               System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

    //        return Properties.Resources.ErrorTiendaImpGen;
    //    }
    
    //}

    public static string ValidarConfigImpuestos()
    {
        try
        {
            bool AI = AplicaImpuesto;
            bool TI = ExisteIVA;
            bool IV = ValorIVA;

            //bool IV = _parametrosSistema.Any(p => p.CodParametro == "IVA") ?
           //    (_parametrosSistema.Find(p => p.CodParametro == "IVA").ValorNumerico.Value > 0) : false;
            if (AI)
            {
                if (TI)
                {
                    if (IV)
                    {
                        IVA = Util.ObtenerParametroDecimal("IVA");
                        return string.Empty;
                    }
                    else
                        return Properties.Resources.ErrorTiendaIvaInv;
                }
                else
                    return Properties.Resources.ErrorTiendaSinIva;
            }
            else
                { 
                  IVA = 0;
                  return string.Empty;            
                }
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." +
                                   System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            return Properties.Resources.ErrorTiendaImpGen;
        }

    }   

    public static int GetEstatus(string descripcion)
    {
      int result = 0;

      try {
        result = _estatus.Where(e => e.Descripcion == descripcion).FirstOrDefault().IdEstatus;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public static EPK_ParametrosSistema GetParametroSistema(string Codigo)
    {
      return _parametrosSistema.Where(ps => ps.CodParametro == Codigo && ps.FechaInicio <= DateTime.Now &&
        (!ps.FechaFin.HasValue || ps.FechaFin.Value >= DateTime.Now)).FirstOrDefault();
    }

    public static EPK_ParametrosSistema GetParametroSistema(string Codigo, DateTime fecha)
    {
      return _parametrosSistema.Where(ps => ps.CodParametro == Codigo && ps.FechaInicio <= fecha.Date &&
        (!ps.FechaFin.HasValue || ps.FechaFin.Value >= fecha.Date)).FirstOrDefault();
    }

    public static void RefrescarTienda()
    {
      TiendaActual = new Tiendas().ObtenerPrimera();
    }

    public static void SetContingencia(EstadoContingencia valor)
    {
      Contingencia = valor;
      Util.SetAppSettingsValue("EstadoContingencia", ((int)valor).ToString());
    }

    public static void SetPermitirIngresoEfectivo(bool valor)
    {
      PermitirIngresoEfectivo = valor;
    }

    public static void SetSerialImpresora(string valor)
    {
      SerialImpresora = valor;
    }

    public static void SetSessionLocked(bool valor)
    {
      SessionLocked = valor;
    }

    public static void SetShellMode(bool valor)
    {
      ShellMode = valor;
    }

    public static void SetSkipValidation(bool valor)
    {
      SkipValidation = valor;
    }

    public static void SetUsuarioActual(EPK_Usuario usuario)
    {
      UsuarioActual = usuario;

      if (usuario == null)
        SessionLocked = false;
    }

    #endregion Public Methods
  }
}