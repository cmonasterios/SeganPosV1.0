using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class CierreCajeroEntidad
  {
    public byte idFormaPago { get; set; }
    public string FormaPago { get; set; }
    public int IdPos { get; set; }
    public string Pos { get; set; }
    public short Lote { get; set; }
    public decimal Monto { get; set; }
    public decimal MontoPOS { get; set; }
    public decimal Diferencia { get; set; }
    public string Observacion { get; set; }
    public bool DatosPOS { get; set; }
  }

  public class CierreVentasEfectivo
  {
    public decimal TotalEfectivo { get; set; }
    public decimal TotalAlivios { get; set; }
    public decimal DiferenciaSistema { get; set; }
    public decimal MontoApertura { get; set; }
    public decimal MontoCierre { get; set; }
    public decimal DiferenciaCajas { get; set; }
    public decimal Saldo { get; set; }
  }

  public class CierreVentasOtrosPagos
  {
    public int IdFormaPago { get; set; }
    public string FormaPago { get; set; }
    public int IdPOS { get; set; }
    public string POS { get; set; }
    public short Lote { get; set; }
    public decimal TotalMontoSistema { get; set; }
    public decimal TotalMontoCierre { get; set; }
    public decimal Diferencia { get; set; }
    public string Observaciones { get; set; }
  }

  #endregion

  public class Cajas : DataAccess
  {

    #region Constructor

    public Cajas(bool skip = false)
      : base(skip)
    {
    }

    #endregion

    #region Public Methods

    public List<EPK_Caja> ObtenerTodas()
    {
      try {
        return context.EPK_Caja.OrderBy(c => c.Descripcion).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      return null;
    }

    public EPK_Caja BuscarPorIP(string DireccionIP)
    {
      return context.EPK_Caja.FirstOrDefault(c => c.DireccionIP == DireccionIP);
    }

    public EPK_Caja BuscarPorMAC(string DireccionMAC)
    {
      return context.EPK_Caja.FirstOrDefault(c => c.DireccionMAC == DireccionMAC);
    }

    public EPK_Caja Obtener(int id)
    {
      return context.EPK_Caja.FirstOrDefault(c => c.IdCaja == id);
    }

    public bool Actualizar(EPK_Caja caja)
    {
      bool result = false;

      try {
        EPK_Caja cajaActual = this.Obtener(caja.IdCaja);

        cajaActual.DireccionMAC = caja.DireccionMAC;

        context.SaveChanges();

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
