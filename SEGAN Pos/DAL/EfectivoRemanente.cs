using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SEGAN_POS.DAL
{
  public class EfectivoRemanente : DataAccess
  {

    #region Public Methods

    public EPK_EfectivoRemanenteEncabezado Obtener(DateTime fecha)
    {
      return context.EPK_EfectivoRemanenteEncabezado.FirstOrDefault(p => p.Fecha == fecha.Date);
    }

    public EPK_EfectivoRemanenteEncabezado Obtener(int id)
    {
      return context.EPK_EfectivoRemanenteEncabezado.FirstOrDefault(p => p.IdEfectivoR == id);
    }

    public int Nuevo(EPK_EfectivoRemanenteEncabezado remanente)
    {
      int result = 0;

      try {
        context.EPK_EfectivoRemanenteEncabezado.Add(remanente);
        context.SaveChanges();

        result = remanente.IdEfectivoR;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = 0;
      }

      return result;
    }

    public bool Actualizar(EPK_EfectivoRemanenteEncabezado remanente)
    {
      try {
        EPK_EfectivoRemanenteEncabezado remActual = Obtener(remanente.IdEfectivoR);

        remActual.MontoTotal = remanente.MontoTotal;

        foreach (EPK_EfectivoRemanenteDetalle item in remanente.EPK_EfectivoRemanenteDetalle) {
          EPK_EfectivoRemanenteDetalle detActual = remActual.EPK_EfectivoRemanenteDetalle.FirstOrDefault(d => d.IdDenominacion == item.IdDenominacion);
          if (detActual == null)
            remActual.EPK_EfectivoRemanenteDetalle.Add(new EPK_EfectivoRemanenteDetalle {
              IdDenominacion = item.IdDenominacion,
              CantidadAlivio = item.CantidadAlivio,
              CantidadDeposito = item.CantidadDeposito,
              CantidadRemanente = item.CantidadRemanente
            });
          else {
            detActual.CantidadAlivio = item.CantidadAlivio;
            detActual.CantidadDeposito = item.CantidadDeposito;
            detActual.CantidadRemanente = item.CantidadRemanente;
          }
        }

        context.SaveChanges();

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public bool Guardar(long idAlivio)
    {
      try {
        DateTime currDate = this.FechaDB();

        DateTime fechaActual = currDate;

        EPK_AlivioEfectivoEncabezado alivio = new AlivioEfectivo().Obtener(idAlivio);

        if (alivio == null)
          return false;

        EPK_EfectivoRemanenteEncabezado remActual = this.Obtener(fechaActual);

        if (remActual == null) {
          remActual = new EPK_EfectivoRemanenteEncabezado();

          remActual.IdUsuario = alivio.IdUsuarioAprobador.Value;
          remActual.Fecha = fechaActual.Date;
          remActual.Hora = fechaActual.TimeOfDay;

          EPK_EfectivoRemanenteEncabezado remAnterior = this.ObtenerUltimo();

          if (remAnterior == null)
            remActual.EPK_EfectivoRemanenteDetalle = new List<EPK_EfectivoRemanenteDetalle>();
          else
            remActual.EPK_EfectivoRemanenteDetalle = remAnterior.EPK_EfectivoRemanenteDetalle.Select(rd =>
              new EPK_EfectivoRemanenteDetalle {
                IdDenominacion = rd.IdDenominacion,
                CantidadAlivio = 0,
                CantidadDeposito = 0,
                CantidadRemanente = rd.CantidadActual
              }).ToList();
        }

        remActual.MontoTotal = 0;

        foreach (EPK_AlivioEfectivoDetalle itemAlivio in alivio.EPK_AlivioEfectivoDetalle) {
          if (!itemAlivio.CantidadAprobador.HasValue)
            continue;

          EPK_EfectivoRemanenteDetalle detRem = remActual.EPK_EfectivoRemanenteDetalle.FirstOrDefault(rd => rd.IdDenominacion == itemAlivio.IdDenominacion);

          if (detRem == null) {
            detRem = new EPK_EfectivoRemanenteDetalle {
              IdDenominacion = itemAlivio.IdDenominacion,
              CantidadAlivio = itemAlivio.CantidadAprobador.Value,
              CantidadDeposito = 0,
              CantidadRemanente = 0
            };

            remActual.EPK_EfectivoRemanenteDetalle.Add(detRem);
          }
          else
            detRem.CantidadAlivio += (int)itemAlivio.CantidadAprobador;

          remActual.MontoTotal += (detRem.CantidadAlivio + detRem.CantidadRemanente - detRem.CantidadDeposito) * itemAlivio.EPK_Denominacion.Denominacion;
        }

        if (remActual.IdEfectivoR > 0)
          return this.Actualizar(remActual);
        else
          return (this.Nuevo(remActual) > 0);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public EPK_EfectivoRemanenteEncabezado ObtenerUltimo()
    {
      try {
        return context.EPK_EfectivoRemanenteEncabezado.OrderByDescending(cc => cc.Fecha).ThenByDescending(cc => cc.Hora).FirstOrDefault();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return null;
      }
    }

    public bool ActualizarDeposito(long idDeposito)
    {
      try {
        if (idDeposito <= 0)
          return false;

        EPK_DepositoEncabezado deposito = new Depositos().Obtener(idDeposito);

        if (deposito == null)
          return false;

        EPK_EfectivoRemanenteEncabezado remActual = this.ObtenerUltimo();

        if (remActual == null)
          return false;

        foreach (EPK_DepositoDetalle item in deposito.EPK_DepositoDetalle) {
          EPK_EfectivoRemanenteDetalle detActual = remActual.EPK_EfectivoRemanenteDetalle.FirstOrDefault(d => d.IdDenominacion == item.IdDenominacion);
          if (detActual == null)
            continue;

          detActual.CantidadDeposito += item.Cantidad;

          remActual.MontoTotal += (detActual.CantidadAlivio + detActual.CantidadRemanente - detActual.CantidadDeposito) * item.EPK_Denominacion.Denominacion;
        }

        return this.Actualizar(remActual);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return false;
    }

    public bool HayDisponible()
    {
      try {
        EPK_EfectivoRemanenteEncabezado efectivo = this.ObtenerUltimo();

        if (efectivo == null)
          return false;

        if (efectivo.EPK_EfectivoRemanenteDetalle.FirstOrDefault() == null)
          return false;

        if (efectivo.EPK_EfectivoRemanenteDetalle.Sum(d => d.CantidadActual) <= 0)
          return false;

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    #endregion

  }
}
