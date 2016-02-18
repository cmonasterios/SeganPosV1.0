using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{

  public class ItemAuditoria
  {
    public long IdAuditoria { get; set; }
    public string Accion { get; set; }
    public string TipoEvento { get; set; }
    public int IdUsuario { get; set; }
    public string Usuario { get; set; }
    public DateTime Fecha { get; set; }
    public string Login { get; set; }
    public string IP { get; set; }
    public string Host { get; set; }
  }

  public class Auditoria : DataAccess
  {

    #region Public Methods

    public List<ItemAuditoria> Consultar(string Nivel, string Login, DateTime FechaDesde, DateTime FechaHasta)
    {
      return (from a in context.EPK_Auditoria
              join u in context.EPK_Usuario on a.IdUsuario equals u.IdUsuario
              where a.FechaEjecucion >= FechaDesde && a.FechaEjecucion <= FechaHasta &&
                    (string.IsNullOrEmpty(Nivel) ? true : a.EventLevel == Nivel) &&
                    (string.IsNullOrEmpty(Login) ? true : u.Login == Login)
              select new ItemAuditoria {
                IdAuditoria = a.IdAuditoria,
                Accion = a.AccionEjecutada,
                Fecha = a.FechaEjecucion,
                TipoEvento = a.EventLevel,
                IdUsuario = u.IdUsuario,
                Usuario = u.Identificacion,
                Login = u.Login,
                IP = a.IP,
                Host = a.Host,
              }).ToList();
    }

    #endregion

  }
}
