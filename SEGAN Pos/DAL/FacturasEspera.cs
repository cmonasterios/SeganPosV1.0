using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class ItemsEspera
  {
    public int IdFacturaEspera { get; set; }

    public string NombreCliente { get; set; }
    public string DocCliente { get; set; }

    public int idEstatus { get; set; }
    public string Estatus { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int Indicador { get; set; }
    public Image Semaforo { get; set; }
  }

  #endregion

  public class FacturasEspera : DataAccess
  {

    #region Public Methods

    public EPK_FacturaEsperaEncabezado Obtener(int id)
    {
      try {
        return context.EPK_FacturaEsperaEncabezado.FirstOrDefault(fe => fe.IdFacturaEspera == id);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return null;
    }

    public List<EPK_FacturaEsperaEncabezado> ObtenerPorCaja(int idCaja)
    {
      try {
        return context.EPK_FacturaEsperaEncabezado.Where(fe => fe.IdCaja == idCaja).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_FacturaEsperaEncabezado>();
    }

    public List<EPK_FacturaEsperaEncabezado> ObtenerActivasPorCaja(int idCaja, DateTime fecha)
    {
      try {
        short estatus = EstadoAplicacion.EstadosFactura["FACCreada"];
        DateTime fFin = fecha.AddDays(1);

        return context.EPK_FacturaEsperaEncabezado.Where(fe => fe.IdCaja == idCaja &&
          fe.IdEstatus == estatus && fe.FechaCreacion > fecha && fe.FechaCreacion < fFin).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_FacturaEsperaEncabezado>();
    }

    public List<EPK_FacturaEsperaEncabezado> ObtenerActivasPorCaja(int idCaja)
    {
      DateTime currDate = this.FechaDB();
      return this.ObtenerActivasPorCaja(idCaja, currDate.Date);
    }

    public List<EPK_FacturaEsperaEncabezado> ObtenerPorCajaDia(int idCaja, DateTime fecha)
    {
      try {
        short eCreada = EstadoAplicacion.EstadosFactura["FACCreada"];
        short eExpirada = EstadoAplicacion.EstadosFactura["FACExpirada"];
        short eCancelada = EstadoAplicacion.EstadosFactura["FACCancelada"];
        DateTime fFin = fecha.AddDays(1);

        return context.EPK_FacturaEsperaEncabezado.Where(fe => fe.IdCaja == idCaja &&
          (fe.IdEstatus == eCreada || fe.IdEstatus == eExpirada || fe.IdEstatus == eCancelada) &&
          fe.FechaCreacion > fecha && fe.FechaCreacion < fFin).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_FacturaEsperaEncabezado>();
    }

    public List<EPK_FacturaEsperaEncabezado> ObtenerPorCajaDia(int idCaja)
    {
      DateTime currDate = this.FechaDB();
      return this.ObtenerPorCajaDia(idCaja, currDate.Date);
    }

    public int Nueva(EPK_FacturaEsperaEncabezado facturaEspera)
    {
      try {
        return this.Nueva(facturaEspera, EstadoAplicacion.EstadosFactura["FACCreada"]);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return 0;
    }

    public int Nueva(EPK_FacturaEsperaEncabezado facturaEspera, short idEstatus)
    {
      int result = 0;

      try {
        EPK_Cliente clienteActual = new Clientes().Obtener(facturaEspera.IdCliente);

        facturaEspera.IdTipoDocumento = clienteActual.IdTipoDocumento;
        facturaEspera.NumeroDocumento = clienteActual.NumeroDocumento;

        DateTime currDate = this.FechaDB();

        facturaEspera.Fecha = currDate;
        facturaEspera.Hora = currDate.TimeOfDay;
        facturaEspera.FechaCreacion = currDate;

        facturaEspera.IdEstatus = idEstatus;

        context.EPK_FacturaEsperaEncabezado.Add(facturaEspera);
        context.SaveChanges();

        result = facturaEspera.IdFacturaEspera;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool Actualizar(EPK_FacturaEsperaEncabezado factura)
    {
      bool result = false;

      try {
        DateTime currDate = this.FechaDB();

        EPK_FacturaEsperaEncabezado facturaAct = this.Obtener(factura.IdFacturaEspera);

        facturaAct.IdEstatus = factura.IdEstatus;

        facturaAct.FechaModificacion = currDate;
        facturaAct.IdUsuarioModificacion = factura.IdUsuarioModificacion;

        context.SaveChanges();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public bool Borrar(int id)
    {
      bool result = false;

      try {
        using (TransactionScope transaction = new TransactionScope()) {
          EPK_FacturaEsperaEncabezado facEspera = this.Obtener(id);

          facEspera.EPK_FacturaEsperaDetalle.Clear();
          context.EPK_FacturaEsperaEncabezado.Remove(facEspera);

          context.SaveChanges();
          transaction.Complete();
        }

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
