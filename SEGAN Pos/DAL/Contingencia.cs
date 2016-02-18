using System;
using System.Collections.Generic;
using System.Linq;

namespace SEGAN_POS.DAL
{

  #region Public Enums

  public enum Destino { Normal, Principal, Contingencia };

  #endregion

  #region Public Types

  public class CajaContingencia
  {

    public int idCaja { get; set; }
    public string DescCaja { get; set; }

    public int UltimaFactura { get; set; }
    public int UltimoPago { get; set; }
    public int UltimaNC { get; set; }
    public int UltimoCliente { get; set; }
    public long UltimaApertura { get; set; }
    public long UltimoAlivio { get; set; }
    public long UltimoCierreCajero { get; set; }
    public int UltimoCierreVentas { get; set; }

    public DateTime FechaModificacion { get; set; }

  }

  #endregion

  public class Contingencia : DataAccess
  {

    #region Constructor

    public Contingencia( bool ServContingencia = true )
          : base(ServContingencia ? "Contingencia" : "SEGANPOSEntities")
    {
    }

    #endregion

    #region Public Methods

    public List<CajaContingencia> ObtenerTodas()
    {
      List<CajaContingencia> results = new List<CajaContingencia>();
      try {
        results = context.EPK_Caja.Select(c => new CajaContingencia {
          idCaja = c.IdCaja,
          DescCaja = c.Descripcion,
          UltimaFactura = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdFactura),
          UltimoPago = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdPago),
          UltimaNC = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdNotaC),
          UltimoCliente = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdCliente),
          UltimaApertura = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdApertura),
          UltimoAlivio = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdAlivioEfectivo),
          UltimoCierreCajero = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdCierre),
          UltimoCierreVentas = (c.EPK_Contingencia == null ? 0 : c.EPK_Contingencia.IdCierreV),
          FechaModificacion = (c.EPK_Contingencia == null ? DateTime.MinValue : c.EPK_Contingencia.FechaModificacion)
        }).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }

    public bool Actualizar(EPK_Contingencia datosCont)
    {
      bool result = false;

      try {
        DateTime currDate = this.FechaDB();

        EPK_Contingencia contingencia = this.Obtener(datosCont.IdCaja);

        if (contingencia == null) {
          contingencia = new EPK_Contingencia();
          contingencia.IdCaja = datosCont.IdCaja;

          contingencia.IdFactura = datosCont.IdFactura;
          contingencia.IdPago = datosCont.IdPago;
          contingencia.IdNotaC = datosCont.IdNotaC;
          contingencia.IdCliente = datosCont.IdCliente;
          contingencia.IdApertura = datosCont.IdApertura;
          contingencia.IdAlivioEfectivo = datosCont.IdAlivioEfectivo;
          contingencia.IdCierre = datosCont.IdCierre;
          contingencia.IdCierreV = datosCont.IdCierreV;

          contingencia.FechaModificacion = currDate;

          context.EPK_Contingencia.Add(contingencia);
        }
        else {
          contingencia.IdFactura = datosCont.IdFactura;
          contingencia.IdPago = datosCont.IdPago;
          contingencia.IdNotaC = datosCont.IdNotaC;
          contingencia.IdCliente = datosCont.IdCliente;
          contingencia.IdApertura = datosCont.IdApertura;
          contingencia.IdAlivioEfectivo = datosCont.IdAlivioEfectivo;
          contingencia.IdCierre = datosCont.IdCierre;
          contingencia.IdCierreV = datosCont.IdCierreV;

          contingencia.FechaModificacion = currDate;
        }

        context.SaveChanges();

        result = true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public EPK_Contingencia Obtener(int idCaja)
    {
      EPK_Contingencia result = null;

      try {
        result = context.EPK_Contingencia.FirstOrDefault(c => c.IdCaja == idCaja);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return result;
    }

    public DateTime? FechaUltimaContingencia()
    {
        try
        {
            int count = context.EPK_HistoricoContingencia.Count();

            DateTime? result = count>0? context.EPK_HistoricoContingencia.Max(h=>h.FechaModificacion) : DateTime.MinValue;

            if (result > DateTime.MinValue)
                return result;
            else
                return null;
        }
        catch (Exception ex)
        {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

            return null;
        }
    }

    #endregion

  }

}
