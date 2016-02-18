using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class DenominacionDepositos
  {

    public byte IdDenominacion { get; set; }
    public byte[] Logo { get; set; }
    public decimal Denominacion { get; set; }
    public int Cantidad { get; set; }
    public decimal TotalDenominacion { get; set; }
    public int CantidadDeposito { get; set; }
    public decimal TotalDeposito { get; set; }

  }

  public class DepositosConsulta
  {

    public long IdDeposito { get; set; }
    public DateTime FechaDeposito { get; set; }
    public DateTime? FechaVenta { get; set; }
    public string TipoDeposito { get; set; }
    public decimal MontoEfectivo { get; set; }
    public decimal MontoCheque { get; set; }
    public decimal Saldo { get; set; }
    public decimal MontoTotal { get; set; }
    public string NroTransaccion { get; set; }
    public string Banco { get; set; }
    public string SerialPrecinto { get; set; }
    public double? DiasTranscurridos { get; set; }
    public string Observaciones { get; set; }

  }

  public class DetalleDeposito
  {

    public decimal Denominacion { get; set; }
    public short Cantidad { get; set; }
    public decimal Total { get; set; }

  }

  #endregion

  public class Depositos : DataAccess
  {

    #region Public Methods

    public List<EPK_DepositoEncabezado> ObtenerTodos(EPK_DepositoEncabezado _search, DateTime _fechaIni, DateTime _fechaFin)
    {
      try {
        return context.EPK_DepositoEncabezado.Where(p => p.IdUsuarioResponsable == (_search.IdUsuarioResponsable == 0 ? p.IdUsuarioResponsable : _search.IdUsuarioResponsable) &&
          p.IdEntidad == (_search.IdEntidad == null ? p.IdEntidad : _search.IdEntidad) &&
          (p.FechaDeposito >= _fechaIni && p.FechaDeposito <= _fechaFin)).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        return null;
      }
    }

    public long Nuevo(EPK_DepositoEncabezado deposito)
    {
      long result = 0;

      try {
        DateTime currDate = this.FechaDB();

        deposito.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        if (deposito.EPK_DepositoCheque.FirstOrDefault() != null)
          foreach (EPK_DepositoCheque item in deposito.EPK_DepositoCheque) {
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;
            item.FechaCreacion = currDate;
          }

        if (deposito.EPK_DepositoDetalle.FirstOrDefault() != null)
          foreach (EPK_DepositoDetalle item in deposito.EPK_DepositoDetalle)
            item.IdTienda = EstadoAplicacion.TiendaActual.IdTienda;

        deposito.FechaDeposito = currDate; //Este campo representa la fecha de creación del registro
        
        context.EPK_DepositoEncabezado.Add(deposito);
        context.SaveChanges();

        result = deposito.IdDeposito;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public List<DepositosConsulta> Consultar(DateTime? feIni, DateTime? feFin, string SerialPrecinto, string NumeroTransaccion,
      bool? DepositoValores, int? IdEntidad)
    {
      try {
        List<DepositosConsulta> results = context.EPK_DepositoEncabezado.Where(de =>
            (feIni.HasValue ? de.FechaVenta >= feIni : true) && (feFin.HasValue ? de.FechaVenta <= feFin : true) &&
            (string.IsNullOrEmpty(SerialPrecinto) ? true : de.SerialPrecinto == SerialPrecinto) &&
            (string.IsNullOrEmpty(NumeroTransaccion) ? true : de.NumeroTransaccion == NumeroTransaccion) &&
            (DepositoValores.HasValue ? de.DepositoValores == DepositoValores : true) &&
            (IdEntidad.HasValue ? de.IdEntidad == IdEntidad : true)
          ).Select(de => new DepositosConsulta {
            IdDeposito = de.IdDeposito,
            FechaDeposito = de.FechaDeposito,
            FechaVenta = de.FechaVenta,
            TipoDeposito = de.DepositoValores ? "Valores" : "Banco",
            MontoEfectivo = de.MontoEfectivo,
            MontoCheque = de.MontoCheque ?? 0,
            Saldo = de.Saldo ?? 0,
            MontoTotal = de.MontoEfectivo + (de.MontoCheque ?? 0),
            NroTransaccion = de.NumeroTransaccion,
            Banco = de.EPK_EntidadFinanciera.Nombre,
            SerialPrecinto = de.SerialPrecinto,
            DiasTranscurridos = null,
            Observaciones = de.Observaciones
          }).OrderByDescending(de => de.FechaVenta).ToList();

        foreach (DepositosConsulta item in results)
          if (item.FechaVenta.HasValue)
            item.DiasTranscurridos = (item.FechaVenta.Value.Date - item.FechaDeposito.Date).TotalDays;

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return new List<DepositosConsulta>();
      }
    }

    public EPK_DepositoEncabezado Obtener(long id)
    {
      return context.EPK_DepositoEncabezado.FirstOrDefault(d => d.IdDeposito == id);
    }

    public bool Actualizar(long id, EPK_DepositoEncabezado deposito)
    {
      bool result = false;

      try {
        EPK_DepositoEncabezado depActual = this.Obtener(id);

        depActual.FechaRecogida = deposito.FechaRecogida;
        depActual.ImagenCataporte = deposito.ImagenCataporte;
        depActual.FileName = deposito.FileName;
        depActual.MimeType = deposito.MimeType;
        depActual.Observaciones = deposito.Observaciones;

        context.SaveChanges();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        result = false;
      }

      return result;
    }

    #endregion

  }
}
