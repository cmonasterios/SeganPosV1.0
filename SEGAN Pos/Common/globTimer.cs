using SEGAN_POS.DAL;
using System;
using System.Timers;

namespace SEGAN_POS
{
  /// <summary>
  /// Clase para manejo del paso hacia y desde contingencia.
  /// </summary>
  public static class globTimer
  {
    #region Private Variables

    private static System.Timers.Timer _timer = null;

    #endregion Private Variables

    #region Public Methods

    /// <summary>
    /// Inicia el timer que verifica el estado de la contingencia.
    /// </summary>
    public static void Start()
    {
      _timer = new System.Timers.Timer(EstadoAplicacion.IntervaloTimer * 1000);
      _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
      _timer.Start();
    }

    /// <summary>
    /// Detiene el timer que verifica el estado de la contingencia.
    /// </summary>
    public static void Stop()
    {
      _timer.Stop();
    }

    #endregion Public Methods

    #region Private Methods

    private static void _timer_Elapsed(object sender, EventArgs e)
    {
      ((System.Timers.Timer)sender).Stop();

      if (EstadoAplicacion.Contingencia == EstadoContingencia.Espera) {
        int vCont = new Parametros(true).ObtenerValorEntero("Contingencia");

        if (vCont == (int)EstadoContingencia.Normal || vCont == (int)EstadoContingencia.Regreso ||
            vCont == (int)EstadoContingencia.Espera) {
          frmContingencia fCont = new frmContingencia();
          if (fCont.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            return;
        }

        if (vCont == (int)EstadoContingencia.Activa) {
          frmAutorizar fAut = new frmAutorizar();
          fAut.Mensaje = Properties.Resources.MsgAutorizarCont;
          fAut.NombreTecnico = "frmFacturar";
          fAut.Accion = "Contingencia";
          fAut.Obligatoria = true;
          fAut.ShowDialog();

          if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
            EstadoAplicacion.SetContingencia(EstadoContingencia.Activa);
        }
      }

      if (EstadoAplicacion.Contingencia == EstadoContingencia.Regreso) {
        frmAutorizar fAut = new frmAutorizar();
        fAut.Mensaje = Properties.Resources.MsgAutorizarCont;
        fAut.NombreTecnico = "frmFacturar";
        fAut.Accion = "Contingencia";
        fAut.Obligatoria = true;
        fAut.ShowDialog();

        if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
          EstadoAplicacion.SetContingencia(EstadoContingencia.Normal);
      }

      ((System.Timers.Timer)sender).Start();
    }

    #endregion Private Methods
  }
}