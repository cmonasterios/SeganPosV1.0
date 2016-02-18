using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmMenuEfec : Form
  {

    #region Constructor

    public frmMenuEfec()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void btAprobarAlivio_Click(object sender, EventArgs e)
    {
      new frmAprobarAlivio().ShowDialog();
    }

    private void btGenerarAlivio_Click(object sender, EventArgs e)
    {
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Aliviar_Efectivo"))
        {
            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = Properties.Resources.MsgAutorizarAlivio;
            fAut.NombreTecnico = this.Name;
            fAut.Accion = "Aliviar_Efectivo";
            fAut.ShowDialog();

            if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
            {
                if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,
                      EstadoAplicacion.ToastTimeout);
            }
        }
        else
        {
            if (new frmAliviarEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                NotificationManager.Show(this, "Alivio de efectivo realizado con éxito", EstadoAplicacion.ToastColor,
                  EstadoAplicacion.ToastTimeout);
        }
    }

    private void btConsultarAlivio_Click(object sender, EventArgs e)
    {
      new frmConsultarAlivio().ShowDialog();
    }

    private void btAperturaCajero_Click(object sender, EventArgs e)
    {
        if (new frmAperturaCajero().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            NotificationManager.Show(this, "Apertura de cajero realizada con éxito", EstadoAplicacion.ToastColor, EstadoAplicacion.ToastTimeout);
    }

    private void btCierreCajero_Click(object sender, EventArgs e)
    {
        EPK_AperturaCajeroEncabezado _apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario);

        if (_apertura == null) {
            MessageBox.Show(Properties.Resources.NoExisteAperturaCaja);
          return;
        }
        //EPK_AperturaCajeroEncabezado apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaNuevoCierre);

        //if (apertura == null)
        //{
        //    MessageBox.Show(Properties.Resources.NoExisteAperturaCaja);
        //    return;
        //}
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Cierre_Cajero"))
        {
            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = Properties.Resources.MsgAutorizarMF;
            fAut.NombreTecnico = this.Name;
            fAut.Accion = "Cierre_Cajero";
            fAut.ShowDialog();

            if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK || fAut.Autorizado)
            {
                if (new frmCierreCajero().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
        else
        {
            if (new frmCierreCajero().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }        
        }

    }

    private void btCierreVentas_Click(object sender, EventArgs e)
    {
      new frmCierreVentas().ShowDialog();
    }

    private void btConsultarCierreVentas_Click(object sender, EventArgs e)
    {
      new frmConsultarCierreVentas().ShowDialog();
    }

    private void btConsultaDepositos_Click(object sender, EventArgs e)
    {
      new frmConsultarDepositos().ShowDialog();
    }

    private void btDepositoBanco_Click(object sender, EventArgs e)
    {
      if (new frmDepositos().ShowDialog() == System.Windows.Forms.DialogResult.OK)
        NotificationManager.Show(this, Properties.Resources.MsgDepCreado, EstadoAplicacion.ToastColor,
          EstadoAplicacion.ToastTimeout);
    }

    private void frmMenuEfec_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      foreach (Control controlItem in this.Controls) {
        if (controlItem.GetType() != typeof(Button))
          continue;

        string target = string.Empty;
        if (((Button)controlItem).Tag != null)
          target = ((Button)controlItem).Tag.ToString();

        if (string.IsNullOrEmpty(target))
          continue;

        ((Button)controlItem).Enabled = new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, target);
      }

      this.btIngresoEfectivo.Enabled = false;
      if(new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, "frmIngresoEfectivo") &&
         (EstadoAplicacion.Contingencia == EstadoContingencia.Activa || EstadoAplicacion.PermitirIngresoEfectivo))
        this.btIngresoEfectivo.Enabled = true;
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmMenuEfec_Activated(object sender, EventArgs e)
    {
      this.Text = "Manejo de Efectivo - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btCambioEfectivo_Click(object sender, EventArgs e)
    {
      if (new frmCambioEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
        NotificationManager.Show(this, Properties.Resources.ExitoCambioEfectivo, EstadoAplicacion.ToastColor,
          EstadoAplicacion.ToastTimeout);
    }

    private void btIngresoEfectivo_Click(object sender, EventArgs e)
    {
      if (new frmIngresoEfectivo().ShowDialog() == System.Windows.Forms.DialogResult.OK)
        NotificationManager.Show(this, Properties.Resources.ExitoIngresoEfectivo, EstadoAplicacion.ToastColor,
          EstadoAplicacion.ToastTimeout);
    }

    #endregion

  }
}
