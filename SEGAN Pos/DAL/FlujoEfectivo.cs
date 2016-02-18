using System;
using System.Linq;
using System.Transactions;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class DenominacionCambioEfectivo
  {

    public byte IdDenominacion { get; set; }
    public byte[] Logo { get; set; }
    public decimal Denominacion { get; set; }
    public int Cantidad { get; set; }
    public decimal TotalDenominacion { get; set; }
    public short Ingreso { get; set; }
    public short Egreso { get; set; }

  }

  public class DenominacionIngresoEfectivo
  {

    public byte IdDenominacion { get; set; }
    public byte[] Logo { get; set; }
    public decimal Denominacion { get; set; }
    public short Ingreso { get; set; }
    public decimal TotalIngreso { get; set; }

  }

  #endregion

  class FlujoEfectivo : DataAccess
  {

    #region Public Methods

    public int Nuevo(EPK_FlujoEfectivo cambioEfectivo)
    {
      int result = 0;

      try {
        DateTime currDate = this.FechaDB();

        using (TransactionScope transaction = new TransactionScope()) {
          cambioEfectivo.IdCaja = EstadoAplicacion.CajaActual.IdCaja;
          cambioEfectivo.IdUsuario = EstadoAplicacion.UsuarioActual.IdUsuario;
          cambioEfectivo.FechaCreacion = currDate;

          this.context.EPK_FlujoEfectivo.Add(cambioEfectivo);

          EPK_EfectivoRemanenteEncabezado remanente = new EfectivoRemanente().ObtenerUltimo();

          if (remanente == null)
            return result;

          foreach (EPK_FlujoEfectivoDetalle item in cambioEfectivo.EPK_FlujoEfectivoDetalle) {
            int egreso = item.Egreso;

            EPK_EfectivoRemanenteDetalle detRemanente = remanente.EPK_EfectivoRemanenteDetalle.
              FirstOrDefault(d => d.IdDenominacion == item.IdDenominacion);

            if (detRemanente == null)
            {
                detRemanente = new EPK_EfectivoRemanenteDetalle { IdDenominacion = item.IdDenominacion, CantidadActual = 0, CantidadAlivio = 0, CantidadDeposito = 0, CantidadRemanente = 0 };
                remanente.EPK_EfectivoRemanenteDetalle.Add(detRemanente);
            }

            if (detRemanente.CantidadRemanente > 0)
              if (detRemanente.CantidadRemanente >= egreso) {
                detRemanente.CantidadRemanente -= egreso;
                egreso = 0;
              }
              else {
                egreso -= detRemanente.CantidadRemanente;
                detRemanente.CantidadRemanente = 0;
              }

            if (egreso > 0) {
              detRemanente.CantidadAlivio -= egreso;
              egreso = 0;
            }

            detRemanente.CantidadRemanente += item.Ingreso;
          }

          new EfectivoRemanente().Actualizar(remanente);

          this.context.SaveChanges();

          transaction.Complete();
        }

        result = cambioEfectivo.IdFlujoEfectivo;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_FlujoEfectivo Obtener(int id)
    {
      return this.context.EPK_FlujoEfectivo.FirstOrDefault(c => c.IdFlujoEfectivo == id);
    }

    #endregion

  }

}
