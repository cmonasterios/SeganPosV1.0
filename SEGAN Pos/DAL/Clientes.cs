using System;
using System.Collections.Generic;
using System.Linq;

using EntityFramework.Audit;
using EntityFramework.Extensions;

namespace SEGAN_POS.DAL
{
  public class Clientes : DataAccess
  {

    #region Constructor

    public Clientes(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public EPK_Cliente Obtener(int id)
    {
      return context.EPK_Cliente.Where(c => c.IdCliente == id).FirstOrDefault();
    }

    public EPK_Cliente BuscarPorNumDoc(int idTipoDoc, string NumDoc)
    {
      return context.EPK_Cliente.Where(c => c.IdTipoDocumento == idTipoDoc && c.NumeroDocumento == NumDoc).FirstOrDefault();
    }

    public IEnumerable<EPK_TipoDocumento> ObtenerTiposDoc()
    {
      try {
        return context.EPK_TipoDocumento.OrderByDescending(td => td.PersonaNatural).OrderBy(td => td.Descripcion).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return null;
    }

    public int Nuevo(EPK_Cliente Cliente)
    {
      int result = 0;

      try {
        foreach (EPK_ClienteTelefono item in Cliente.EPK_ClienteTelefono) {
          item.IdTipoDocumento = Cliente.IdTipoDocumento;
          item.NumeroDocumento = Cliente.NumeroDocumento;
        }

        Cliente.FechaCreacion = this.FechaDB();

        context.EPK_Cliente.Add(Cliente);
        context.SaveChanges();

        if (EstadoAplicacion.PermitirContingencia && Cliente.IdCliente > 0)
          Util.SetAppSettingsValue("UltimoCliente", Cliente.IdCliente.ToString(), false);

        result = Cliente.IdCliente;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool Actualizar(int id, EPK_Cliente cliente)
    {
      bool result = false;

      try {
        AuditLogger audit = this.context.BeginAudit();

        EPK_Cliente clienteActual = this.Obtener(id);

        clienteActual.Nombre = cliente.Nombre;
        clienteActual.Apellido = cliente.Apellido;
        clienteActual.Direccion = cliente.Direccion;
        clienteActual.Email = cliente.Email;

        string Numero = cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero;

        if (clienteActual.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0) {
          clienteActual.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero = Numero;
          clienteActual.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).IdTipoDocumento = clienteActual.IdTipoDocumento;
          clienteActual.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).NumeroDocumento = clienteActual.NumeroDocumento;
        }
        else
          clienteActual.EPK_ClienteTelefono.Add(new EPK_ClienteTelefono {
            Numero = Numero,
            Principal = true,
            IdTipoDocumento = clienteActual.IdTipoDocumento,
            NumeroDocumento = clienteActual.NumeroDocumento
          });

        this.context.SaveChanges();

        AuditLog log = audit.CreateLog();

        new NLogLogger().Trace(log.ToXml());

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_Descuento ObtenerDescuento(int id)
    {
      EPK_Descuento result = null;

      try {
        EPK_Cliente clienteActual = this.Obtener(id);

        if (clienteActual.IdTipoDescuento.HasValue)
          result = clienteActual.EPK_TipoDescuento.EPK_Descuento.FirstOrDefault(d => d.FechaInicio <= DateTime.Today && d.FechaFin >= DateTime.Today);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_Descuento ObtenerDescuento(EPK_Cliente cliente)
    {
      EPK_Descuento result = null;

      try {
        if (cliente.IdTipoDescuento.HasValue)
          result = cliente.EPK_TipoDescuento.EPK_Descuento.FirstOrDefault(d => d.FechaInicio <= DateTime.Today && d.FechaFin >= DateTime.Today);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public int ObtenerUltimoId()
    {
      try {
        return this.context.EPK_Cliente.Max(c => c.IdCliente);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return 0;
    }

    public bool ReSeed(int id)
    {
      if (id <= 0)
        return false;

      try {
        this.context.Database.ExecuteSqlCommand(string.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})",
          "EPK_Cliente", id.ToString()));

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    #endregion

  }
}
