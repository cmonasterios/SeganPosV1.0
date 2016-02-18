using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class UsuariosBloqueados
  {

    public int IdUsuario { get; set; }
    public string Identificacion { get; set; }
    public string Login { get; set; }
    public DateTime? LastLockedDate { get; set; }

  }

  #endregion

  public class Usuarios : DataAccess
  {

    #region Constructor

    public Usuarios(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<EPK_Usuario> ObtenerTodos()
    {
      return this.context.EPK_Usuario.ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    public EPK_Usuario Obtener(string login)
    {
      return this.context.EPK_Usuario.FirstOrDefault(u => u.Login.Equals(login, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <returns></returns>
    public EPK_Usuario Obtener(int idUsuario)
    {
      return this.context.EPK_Usuario.FirstOrDefault(u => u.IdUsuario == idUsuario);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <param name="checkonly"></param>
    /// <returns></returns>
    public KeyValuePair<EPK_Usuario, string> Validar(string login, string password, bool checkonly = true)
    {
      KeyValuePair<EPK_Usuario, string> result = new KeyValuePair<EPK_Usuario, string>(null, string.Empty);

      if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        return result;

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        EPK_Usuario usuario = this.Obtener(login);

        if (usuario == null) {
          result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgUsuarioNoExiste, login));
          new NLogLogger().Info(result.Value);
          return result;
        }

        if (usuario.Locked) {
          result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgUsuarioBloqueado, usuario.Login));
          new NLogLogger().Info(result.Value);
          return result;
        }

        string encryptedPass = new Seguridad(Seguridad.CryptoProvider.Rijndael).CifrarCadena(password);

        if (usuario.Clave != encryptedPass) {
          result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgClaveIncorrecta, usuario.Login));
          new NLogLogger().Info(result.Value);

          int maxIntentos = Util.ObtenerParametroEntero("INTENTOS_CLAVE");
          if (maxIntentos <= 0)
            maxIntentos = 3;

          usuario.FailedLoginAttempts++;

          bool bloqClave = usuario.EPK_UsuarioApp.FirstOrDefault(ua => ua.IdApp == EstadoAplicacion.IDApp).EPK_Perfil.BloqueoClave;

          DateTime currDate = this.FechaDB();

          if (usuario.FailedLoginAttempts >= maxIntentos && bloqClave) {
            usuario.Locked = true;
            usuario.LastLockedDate = currDate;
            usuario.LastLockedReason = Properties.Resources.ReasonLocked;
          }

          usuario.FechaModificacion = currDate;

          context.SaveChanges();
          return result;
        }
        else
          if (usuario.FailedLoginAttempts > 0) {
            DateTime currDate = this.FechaDB();

            usuario.FailedLoginAttempts = 0;
            usuario.LastLockedDate = null;
            usuario.LastLockedReason = null;
            usuario.FechaModificacion = currDate;

            context.SaveChanges();
          }

        if (usuario.EPK_UsuarioApp.Where(ua => ua.IdApp == EstadoAplicacion.IDApp).Count() == 0) {
          result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgUsuarioNoApp, usuario.Identificacion, usuario.Login));
          new NLogLogger().Info(result.Value);
          return result;
        }

        new NLogLogger().Info(string.Format("Usuario {0} ({1}) autenticado.", usuario.Identificacion, usuario.Login));

        bool valAsistencia = usuario.EPK_UsuarioApp.FirstOrDefault(ua => ua.IdApp == EstadoAplicacion.IDApp).EPK_Perfil.Asistencia;

        if (new Terminales(this._skip).HayActivas() && !EstadoAplicacion.SkipValidation && EstadoAplicacion.Contingencia == EstadoContingencia.Normal)
          if (valAsistencia)
            if (!new Lecturas(this._skip).TieneEntrada(usuario.IdUsuario)) {
              result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgSinLectura, usuario.Identificacion, usuario.Login));
              new NLogLogger().Info(result.Value);
              return result;
            }

        if (!checkonly && !new DAL.Accesos().VerificarAccesoObjeto(usuario.IdUsuario, "frmMenuPrincipal")) {
          if (usuario.IdCajaActual.HasValue)
            if (usuario.IdCajaActual.Value != EstadoAplicacion.CajaActual.IdCaja) {
              result = new KeyValuePair<EPK_Usuario, string>(null, string.Format(Properties.Resources.MsgLoginOtraCaja, usuario.EPK_Caja.Descripcion));
              new NLogLogger().Info(result.Value);
              return result;
            }

          usuario.IdCajaActual = EstadoAplicacion.CajaActual.IdCaja;
          context.SaveChanges();
        }

        result = new KeyValuePair<EPK_Usuario, string>(usuario, string.Empty);
      }
      catch (Exception ex) {
        result = new KeyValuePair<EPK_Usuario, string>(null, Properties.Resources.MsgErrorLogin);
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="newPass"></param>
    /// <returns></returns>
    public bool CambiarClave(int idUsuario, string newPass)
    {
      bool result = false;

      if (idUsuario <= 0 || string.IsNullOrEmpty(newPass))
        return result;

      try {
        EPK_Usuario usuarioActual = this.Obtener(idUsuario);

        if (usuarioActual == null)
          return result;

        string encryptedPass = new Seguridad(Seguridad.CryptoProvider.Rijndael).CifrarCadena(newPass);

        usuarioActual.Clave = encryptedPass;
        usuarioActual.ReqPassChange = false;
        DateTime currDate = this.FechaDB();
        usuarioActual.LastPassChange = currDate;
        usuarioActual.FechaModificacion = currDate;

        context.SaveChanges();

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
    /// <returns></returns>
    public List<EPK_Usuario> ObtenerCajeros()
    {
      List<EPK_Usuario> result = null;

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        int idCargoCajero = Util.ObtenerParametroEntero("IdCargoCajero");
        int idCargoCajeroP = Util.ObtenerParametroEntero("IdCargoCajeroP");

        if (idCargoCajero > 0 || idCargoCajeroP > 0)
          result = context.EPK_Usuario.Where(u => u.EPK_Empleados.Where(e => e.IdCargo == idCargoCajero || e.IdCargo == idCargoCajeroP).Count() > 0).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return result;
    }

    public bool Logout(int idUsuario)
    {
      try {
        EPK_Usuario usuarioActual = this.Obtener(idUsuario);

        if (usuarioActual == null)
          return false;

        usuarioActual.IdCajaActual = null;

        context.SaveChanges();

        new NLogLogger().Info(string.Format("Usuario {0} ({1}) desconectado.", usuarioActual.Identificacion, usuarioActual.Login));

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public List<UsuariosBloqueados> ObtenerBloqueados(int idUsuario)
    {
      return context.EPK_Usuario.Where(u => u.Locked).OrderBy(u => u.Identificacion).Select(u => new UsuariosBloqueados {
        IdUsuario = u.IdUsuario,
        Identificacion = u.Identificacion.Trim(),
        Login = u.Login.Trim(),
        LastLockedDate = u.LastLockedDate
      }).ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <returns></returns>
    public bool Desbloquear(int idUsuario)
    {
      bool result = false;

      if (idUsuario <= 0)
        return result;

      try {
        EPK_Usuario usuarioActual = this.Obtener(idUsuario);

        if (usuarioActual == null)
          return result;

        string claveBase = Util.ObtenerParametroCadena("ClaveBase");

        if (!string.IsNullOrEmpty(claveBase)) {
          string encryptedPass = new Seguridad(Seguridad.CryptoProvider.Rijndael).CifrarCadena(claveBase);
          usuarioActual.Clave = encryptedPass;
        }

        usuarioActual.Locked = false;
        usuarioActual.LastLockedDate = null;
        usuarioActual.LastLockedReason = null;
        usuarioActual.ReqPassChange = true;
        usuarioActual.FailedLoginAttempts = 0;
        usuarioActual.IdCajaActual = null;
        usuarioActual.FechaModificacion = this.FechaDB();

        context.SaveChanges();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public List<EPK_Usuario> ObtenerActivos()
    {
      List<EPK_Usuario> results = new List<EPK_Usuario>();

      try {
        if (new Terminales().HayActivas()) {
          results = context.EPK_Usuario.Where(u => !u.Locked && u.EPK_Empleados.Any()).Select(u => new {
            UltSalida = (u.EPK_Empleados.FirstOrDefault().EPK_Lecturas.Where(l =>
              (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
              (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
              ).OrderByDescending(l => l.HoraLectura).FirstOrDefault()),
            usuario = u
          }).Where(r => r.usuario.EPK_Empleados.FirstOrDefault().EPK_Lecturas.Where(l => (l.FechaLectura.HasValue &&
            l.FechaLectura.Value == DateTime.Today) &&
            (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
            (r.UltSalida == null ? true : (l.HoraLectura > (r.UltSalida.HoraLectura)))).Count() > 0).Select(r => r.usuario).ToList();
        }
        else {
          results = context.EPK_Usuario.Where(u => !u.Locked).ToList();
        }
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public bool LimpiarSesiones()
    {
      bool result = false;

      try {
        this.context.EPK_Usuario.Update(u => new EPK_Usuario { IdCajaActual = null, FechaModificacion = DateTime.Now });

        this.context.SaveChanges();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    #endregion

  }
}
