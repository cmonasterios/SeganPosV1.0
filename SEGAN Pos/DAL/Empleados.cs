using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{
  public class Empleados : DataAccess
  {
    #region Public Methods

    public EPK_Empleados Obtener(int id)
    {
      return this.context.EPK_Empleados.FirstOrDefault(e => e.IdEmpleado == id);
    }

    public List<EPK_Empleados> ObtenerVendedores()
    {
        List<EPK_Empleados> result = new List<EPK_Empleados>();

        try
        {
            int idCargoVendedor = Util.ObtenerParametroEntero("IdCargoVendedor");
            int idCargoAsistInt = Util.ObtenerParametroEntero("IdCargoAsistInt");
            int idCargoAsistVen = Util.ObtenerParametroEntero("IdCargoAsistVen");
            int idVendClienteNoAtendido = Util.ObtenerParametroEntero("EmpleadoComision");

            if (new Terminales().HayActivas())
            {
                List<EPK_Empleados> vendedores = this.context.EPK_Empleados.Where(
                    e => e.IdCargo == idCargoVendedor && (e.Estatus ?? false)).Select(e => new
                    {
                        UltSalida = (e.EPK_Lecturas.Where(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                          (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
                          ).OrderByDescending(l => l.HoraLectura).FirstOrDefault()),
                        empleado = e
                    }).
                    Where(r => r.empleado.EPK_Lecturas.Any(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                      (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
                      (r.UltSalida == null ? true : (l.HoraLectura > (r.UltSalida.HoraLectura)))) &&
                      (r.empleado.IdUsuario.HasValue ? !r.empleado.EPK_Usuario.IdCajaActual.HasValue : true)
                    ).Select(r => r.empleado).ToList();

                List<EPK_Empleados> asistentesInt = this.context.EPK_Empleados.Where(
                    e => e.IdCargo == idCargoAsistInt && (e.Estatus ?? false)).Select(e => new
                    {
                        UltSalida = (e.EPK_Lecturas.Where(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                          (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
                          ).OrderByDescending(l => l.HoraLectura).FirstOrDefault()),
                        empleado = e
                    }).
                    Where(r => r.empleado.EPK_Lecturas.Any(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                      (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
                      (r.UltSalida == null ? true : (l.HoraLectura > (r.UltSalida.HoraLectura)))) &&
                      (r.empleado.IdUsuario.HasValue ? !r.empleado.EPK_Usuario.IdCajaActual.HasValue : true)
                    ).Select(r => r.empleado).ToList();

                List<EPK_Empleados> asistentesVen = this.context.EPK_Empleados.Where(
                    e => e.IdCargo == idCargoAsistVen && (e.Estatus ?? false)).Select(e => new
                    {
                        UltSalida = (e.EPK_Lecturas.Where(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                          (l.TipoEntrada == (int)TipoLectura.Salida || l.TipoEntrada == (int)TipoLectura.SalidaBreak)
                          ).OrderByDescending(l => l.HoraLectura).FirstOrDefault()),
                        empleado = e
                    }).
                    Where(r => r.empleado.EPK_Lecturas.Any(l => (l.FechaLectura.HasValue && l.FechaLectura.Value == DateTime.Today) &&
                      (l.TipoEntrada == (int)TipoLectura.Entrada || l.TipoEntrada == (int)TipoLectura.EntradaBreak) &&
                      (r.UltSalida == null ? true : (l.HoraLectura > (r.UltSalida.HoraLectura)))) &&
                      (r.empleado.IdUsuario.HasValue ? !r.empleado.EPK_Usuario.IdCajaActual.HasValue : true)
                    ).Select(r => r.empleado).ToList();

                result = vendedores.Union(asistentesInt).Union(asistentesVen).ToList().OrderBy(e => e.Nombre).ThenBy(e => e.Apellido).ToList();

                //Inserta al Vendedor Cliente No Atendido
                int IdClienteNoAtendido = Util.ObtenerParametroEntero("EmpleadoComision");
                EPK_Empleados VendedorClienteNoAtendido = this.context.EPK_Empleados.Where(p => p.IdEmpleado == IdClienteNoAtendido).FirstOrDefault();

                if (VendedorClienteNoAtendido != null)
                    result.Add(VendedorClienteNoAtendido);
            }
            else
            {
                List<EPK_Empleados> vendedores = this.context.EPK_Empleados.Where(
                  e => (e.Estatus ?? false) && e.IdCargo == idCargoVendedor && (e.IdUsuario.HasValue ? !e.EPK_Usuario.IdCajaActual.HasValue : true)
                  ).ToList();

                List<EPK_Empleados> asistentesInt = this.context.EPK_Empleados.Where(
                    e => (e.Estatus ?? false) && e.IdCargo == idCargoAsistInt && (e.IdUsuario.HasValue ? !e.EPK_Usuario.IdCajaActual.HasValue : true)
                  ).ToList();

                List<EPK_Empleados> asistentesVen = this.context.EPK_Empleados.Where(
                    e => (e.Estatus ?? false) && e.IdCargo == idCargoAsistVen && (e.IdUsuario.HasValue ? !e.EPK_Usuario.IdCajaActual.HasValue : true)
                  ).ToList();

                result = vendedores.Union(asistentesInt).Union(asistentesVen).ToList().OrderBy(e => e.Nombre).ThenBy(e => e.Apellido).ToList();
            }
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        }

        return result;
    }
        
    #endregion Public Methods
  }
}