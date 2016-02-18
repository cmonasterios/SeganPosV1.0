using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEGAN_POS.DAL
{

  #region Data Types

  public class DispositivoCaja
  {

    public int IdCaja { get; set; }
    public string DescCaja { get; set; }
    public int IdDispositivo { get; set; }
    public string Serial { get; set; }
    public bool Exclude { get; set; }

  }

  #endregion

  public class Dispositivos : DataAccess
  {

    #region Public Methods

    public EPK_Dispositivo Obtener(string serial)
    {
        return context.EPK_Dispositivo.FirstOrDefault(c => c.Serial.Equals(serial, StringComparison.OrdinalIgnoreCase));
            //.Join ( context.EPK_CajaDispositivo,  D => D.IdDispositivo, CD => CD.IdCajaDispositivo, (D) => new {});
    }

    public EPK_Dispositivo Obtener(int id)
    {
      return context.EPK_Dispositivo.FirstOrDefault(c => c.IdDispositivo == id);
    }

    public EPK_Dispositivo Obtener(string serial, int status)
    {
        return context.EPK_Dispositivo.FirstOrDefault(c => c.Serial.Equals(serial, StringComparison.OrdinalIgnoreCase) && c.IdEstatus == status);
        //.Join ( context.EPK_CajaDispositivo,  D => D.IdDispositivo, CD => CD.IdCajaDispositivo, (D) => new {});
    }

    public int ObtenerIdMF(string serial)
    {
      EPK_Dispositivo disp = this.Obtener(serial);

      if (disp == null)
        return 0;

      return disp.IdDispositivo;
    }

    public int ObtenerIdMFCierre(string serial)
    {
        EPK_Dispositivo disp = this.Obtener(serial, 1);

        if (disp == null)
            return 0;

        return disp.IdDispositivo;
    }
    /// <summary>
    /// Actualiza el valor del reporte Z para un serial de dispositivo dado.
    /// </summary>
    /// <param name="Serial">Serial del dispositivo.</param>
    /// <param name="NroReporteZ">Número del reporte Z.</param>
    /// <returns></returns>
    public bool ActualizarReporteZ(string Serial, string NroReporteZ)
    {
      bool result = false;

      try {
        EPK_Dispositivo DispositivoActual = this.Obtener(Serial);

        DispositivoActual.NroReporteZ = NroReporteZ;

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

    public bool ActualizarReporteZ(int id, string NroReporteZ)
    {
      bool result = false;

      try {
        DateTime currDate = this.FechaDB();

        EPK_Dispositivo DispositivoActual = this.Obtener(id);

        DispositivoActual.NroReporteZ = NroReporteZ;
        DispositivoActual.FechaModificacion = currDate;

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

    public IEnumerable<EPK_Dispositivo> ObtenerTodos()
    {
      return context.EPK_Dispositivo.ToList();
    }

    public IEnumerable<EPK_Dispositivo> ObtenerMF()
    {
      int vMF = Util.ObtenerParametroEntero("IdImpresora");
      return context.EPK_Dispositivo.Where(d => d.IdTipoDispositivo == vMF).ToList();
    }

    public List<EPK_Dispositivo> PendientesPorCierre(DateTime fecha)
    {
      List<EPK_Dispositivo> results = new List<EPK_Dispositivo>();

      try {
        int idImpresora = Util.ObtenerParametroEntero("IdImpresora");
        int estatusActivo = EstadoAplicacion.GetEstatus("Activo");

        results = context.EPK_Dispositivo.Where(d => d.IdEstatus == estatusActivo && d.IdTipoDispositivo == idImpresora &&
          d.EPK_CierreMaquinaFiscal.Where(c => c.Fecha == fecha.Date).Count() == 0).ToList();
          //d.EPK_CierreMaquinaFiscal.Where(c => c.Fecha == fecha.Date).Sum(c.MontoTotalFact)).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return results;
    }


    #endregion

  }
}
