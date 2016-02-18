using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{

  /// <summary>
  /// Métodos para validar permisos sobre acciones de la aplicación.
  /// </summary>
  public class Accesos : DataAccess
  {

    #region Constructor

    public Accesos(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="nombreTecnico"></param>
    /// <returns></returns>
    public bool VerificarAccesoObjeto(int idUsuario, string nombreTecnico)
    {
      bool result = false;

      if (idUsuario <= 0 || string.IsNullOrEmpty(nombreTecnico))
        return result;

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        if (context.EPK_Objeto.Where(o => o.NombreTecnico == nombreTecnico).Count() == 0)
          return false;

        result = context.EPK_PerfilObjetos.Where(po => po.EPK_Objeto.NombreTecnico == nombreTecnico &&
                   po.Habilitado && po.EPK_Objeto.EPK_Modulo.Activo && po.EPK_Objeto.EPK_Modulo.EPK_App.Activa &&
                   po.EPK_Objeto.EPK_Modulo.EPK_App.IdApp == EstadoAplicacion.IDApp &&
                   po.EPK_Perfil.EPK_UsuarioApp.Where(ua => ua.IdUsuario == idUsuario &&
                     ua.IdApp == EstadoAplicacion.IDApp && ua.EPK_App.Activa).Count() > 0
                 ).Count() > 0;
      }
      catch (Exception ex) {
        new NLogLogger().Debug(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="nombreTecnico"></param>
    /// <param name="descAccion"></param>
    /// <returns></returns>
    public bool VerificarAccesoAccion(int idUsuario, string nombreTecnico, string descAccion)
    {
      bool result = false;

      if (idUsuario <= 0 || string.IsNullOrEmpty(nombreTecnico) || string.IsNullOrEmpty(descAccion))
        return result;

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        result = context.EPK_PerfilAccion.Where(pa => pa.EPK_Accion.Descripcion == descAccion &&
                   pa.Habilitado && pa.EPK_Accion.Habilitada &&
                   pa.EPK_Perfil.EPK_PerfilObjetos.Where(po => po.EPK_Objeto.NombreTecnico == nombreTecnico &&
                     po.Habilitado && po.EPK_Objeto.EPK_Modulo.Activo && po.EPK_Objeto.EPK_Modulo.EPK_App.Activa &&
                     po.EPK_Objeto.EPK_Modulo.EPK_App.IdApp == EstadoAplicacion.IDApp &&
                     po.EPK_Perfil.EPK_UsuarioApp.Where(ua => ua.IdUsuario == idUsuario &&
                       ua.IdApp == EstadoAplicacion.IDApp && ua.EPK_App.Activa).Count() > 0).Count() > 0
                 ).Count() > 0;
      }
      catch (Exception ex) {
        new NLogLogger().Debug(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nombreTecnico"></param>
    /// <param name="descAccion"></param>
    /// <returns></returns>
    public List<EPK_Usuario> ObtenerAutorizadores(string nombreTecnico, string descAccion)
    {
      List<EPK_Usuario> result = new List<EPK_Usuario>();

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        result = context.EPK_Usuario.Where(u => u.EPK_UsuarioApp.Where(
          ua => ua.EPK_Perfil.EPK_PerfilAccion.Where(pa => pa.Autorizador && pa.EPK_Accion.Habilitada &&
            pa.EPK_Accion.Descripcion == descAccion && pa.Habilitado).Count() > 0 && // ua.EPK_Perfil.Autorizador &&
            ua.EPK_Perfil.EPK_PerfilObjetos.Where(po => po.EPK_Objeto.NombreTecnico == nombreTecnico && po.Habilitado &&
            po.EPK_Objeto.EPK_Modulo.Activo && po.EPK_Objeto.EPK_Modulo.EPK_App.Activa &&
            po.EPK_Objeto.EPK_Modulo.EPK_App.IdApp == EstadoAplicacion.IDApp).Count() > 0 && ua.IdApp == EstadoAplicacion.IDApp &&
            ua.EPK_App.Activa).Count() > 0).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Debug(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="nombreTecnico"></param>
    /// <param name="descAccion"></param>
    /// <returns></returns>
    public bool AccionReqAutorizacion(int idUsuario, string nombreTecnico, string descAccion)
    {
      bool result = true;

      if (idUsuario <= 0 || string.IsNullOrEmpty(nombreTecnico) || string.IsNullOrEmpty(descAccion))
        return result;

      try {
        if (this.EsAutorizadorAccion(idUsuario, nombreTecnico, descAccion))
          return false;

        result = context.EPK_ObjetoAccion.Where(oa => oa.NecesitaAutorizacion &&
          oa.EPK_Accion.Descripcion == descAccion && oa.EPK_Objeto.NombreTecnico == nombreTecnico).Count() > 0;
      }
      catch (Exception ex) {
        new NLogLogger().Debug(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="nombreTecnico"></param>
    /// <param name="descAccion"></param>
    /// <returns></returns>
    public bool EsAutorizadorAccion(int idUsuario, string nombreTecnico, string descAccion)
    {
      bool result = false;

      if (idUsuario <= 0 || string.IsNullOrEmpty(nombreTecnico) || string.IsNullOrEmpty(descAccion))
        return result;

      if (EstadoAplicacion.IDApp <= 0)
        return result;

      try {
        result = context.EPK_PerfilAccion.Where(pa => pa.EPK_Accion.Descripcion == descAccion &&
           pa.Habilitado && pa.EPK_Accion.Habilitada && pa.Autorizador && // pa.EPK_Perfil.Autorizador &&
           pa.EPK_Perfil.EPK_UsuarioApp.Where(ua => ua.IdUsuario == idUsuario &&
             ua.IdApp == EstadoAplicacion.IDApp && ua.EPK_App.Activa).Count() > 0 &&
           pa.EPK_Perfil.EPK_PerfilObjetos.Where(po => po.EPK_Objeto.NombreTecnico == nombreTecnico &&
             po.Habilitado && po.EPK_Objeto.EPK_Modulo.Activo).Count() > 0
         ).Count() > 0;
      }
      catch (Exception ex) {
        new NLogLogger().Debug(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    #endregion

  }

}
