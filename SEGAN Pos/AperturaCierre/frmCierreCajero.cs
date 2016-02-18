using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Globalization;

namespace SEGAN_POS
{
  public partial class frmCierreCajero : Form
  {
    #region Private Properties

    private DateTime _fechaIniNuevoCierre { get; set; }

    private DateTime _fechaNuevoCierre { get; set; }

    private BindingList<CierreCajeroEntidad> _listCierre { get; set; }

    private BindingList<DenominacionAlivio> _listDenominacionAlivio { get; set; }

    private static bool sessionalive;
    private static System.Timers.Timer usertimer;
    private int VigenciaVisualizarSeg; 

    public static bool SessionAlive
    {
        get { return sessionalive; }
        set { sessionalive = value; }
    }

    #endregion Private Properties
    #region Public Properties
    
  
    #endregion Public Properties 
    #region Constructor

        public frmCierreCajero()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btCalc_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("calc.exe");
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      decimal totalCierre = 0;
      //decimal.TryParse(this.txTotalCierre.Tag.ToString(), out totalCierre);
      decimal.TryParse(decimal.Parse(this.txTotalCierre.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), out totalCierre);
      bool AutorizadoReporteZ = false;

      if (this.cbCierreCaja.Checked) {
        if (MessageBox.Show(Properties.Resources.MsgPregCierreCaja, "Confirmación " + this.Text,
          MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) {
          return;
        }
      }
      else {
        if (MessageBox.Show(Properties.Resources.MsgPregCierreCajero, "Confirmación " + this.Text,
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) {
          return;
        }
      }

      decimal efectivoCajero = 0, efectivoSistema = 0;
      //decimal.TryParse(this.txMontoCierreEfectivo.Tag.ToString(), out efectivoCajero);
      //decimal.TryParse(this.txEfectivoPorEntregar.Tag.ToString(), out efectivoSistema);
      decimal.TryParse(decimal.Parse(this.txMontoCierreEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), out efectivoCajero);
      decimal.TryParse(decimal.Parse(this.txEfectivoPorEntregar.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), out efectivoSistema);

      bool difOtrosPag = false;
      foreach (CierreCajeroEntidad item in this._listCierre)
        if (item.Monto != item.MontoPOS) {
          difOtrosPag = true;
          break;
        }

      if (efectivoSistema != efectivoCajero || difOtrosPag)
        if (MessageBox.Show(Properties.Resources.MsgDifCierreCaj, "Confirmación " + this.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes) {
          return;
        }
        else {
          if (this.cbCierreCaja.Checked) {
            if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "DiffCierre") &&
                new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreMF")) {
              frmAutorizar fAut = new frmAutorizar();
              fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecajaRepZ;
              fAut.NombreTecnico = this.Name;
              fAut.Accion = "DiffCierre";
              fAut.ShowDialog();

              if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || (!fAut.Autorizado))
                return;

              KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(fAut.Login, fAut.Password);

              if (!new Accesos(true).EsAutorizadorAccion(result.Key.IdUsuario, this.Name, "CierreMF")) {
                MessageBox.Show(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                new NLogLogger().Error(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login));
                return;
              }
              else {
                AutorizadoReporteZ = true;
              }
            }
          }
          else {
            if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "DiffCierre")){
                  frmAutorizar fAut = new frmAutorizar();
                  fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecaja;
                  fAut.NombreTecnico = this.Name;
                  fAut.Accion = "DiffCierre";
                  fAut.ShowDialog();

              if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                return;
            }
          }
        }

      if ((efectivoSistema == efectivoCajero || !difOtrosPag) && totalCierre == 0)
          //if (totalCierre == 0 || difOtrosPag)
          {
              if (this.cbCierreCaja.Checked)
              {
                  if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreCero") &&
                      new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreMF"))
                  {
                      frmAutorizar fAut = new frmAutorizar();
                      fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecajaRepZ;
                      fAut.NombreTecnico = this.Name;
                      fAut.Accion = "CierreCero";
                      fAut.ShowDialog();

                      if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || (!fAut.Autorizado))
                          return;

                      KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(fAut.Login, fAut.Password);

                      if (!new Accesos(true).EsAutorizadorAccion(result.Key.IdUsuario, this.Name, "CierreMF"))
                      {
                          MessageBox.Show(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                          new NLogLogger().Error(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login));
                          return;
                      }
                      else
                      {
                          AutorizadoReporteZ = true;
                      }
                  }
              }
              else
              {
                  if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreCero"))
                  {
                      frmAutorizar fAut = new frmAutorizar();
                      fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecaja;
                      fAut.NombreTecnico = this.Name;
                      fAut.Accion = "CierreCero";
                      fAut.ShowDialog();

                      if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                          return;
                  }
              }
          }
        
      decimal TotalAlvPendientes=0;
      //decimal.TryParse(this.TxTotalAliviosPendientes.Tag.ToString(), out TotalAlvPendientes);
      decimal.TryParse(decimal.Parse(this.TxTotalAliviosPendientes.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), out TotalAlvPendientes);


      decimal TotalAlv = 0;
     // decimal.TryParse(this.txTotalAlivios.Tag.ToString(), out TotalAlv);
      decimal.TryParse(decimal.Parse(this.txTotalAlivios.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), out TotalAlv);

      decimal TotalAlivio = TotalAlv + TotalAlvPendientes;

      if ((TotalAlvPendientes > 0) && (efectivoSistema == efectivoCajero || !difOtrosPag) && (totalCierre != 0))
      {
        if (this.cbCierreCaja.Checked)
          {
          if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreAlivioPdte")&&
                      new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreMF"))      
                  {
                      frmAutorizar fAut = new frmAutorizar();
                      fAut.Mensaje = Properties.Resources.MsgAliviosPendCajero;
                      fAut.NombreTecnico = this.Name;
                      fAut.Accion = "CierreAlivioPdte";
                      fAut.ShowDialog();

                      if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                          return;

                      KeyValuePair<EPK_Usuario, string> result = new Usuarios(true).Validar(fAut.Login, fAut.Password);

                      if (!new Accesos(true).EsAutorizadorAccion(result.Key.IdUsuario, this.Name, "CierreMF"))
                      {
                          MessageBox.Show(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login), "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                          new NLogLogger().Error(string.Format(Properties.Resources.MsgNoEsAutorizador, result.Key.Login));
                          return;
                      }
                      else
                      {
                          AutorizadoReporteZ = true;
                      }


                  }

              }
           else
           {
               if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreAlivioPdte"))
               {
                   frmAutorizar fAut = new frmAutorizar();
                   fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecaja;
                   fAut.NombreTecnico = this.Name;
                   fAut.Accion = "CierreAlivioPdte";
                   fAut.ShowDialog();

                   if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
                       return;
               }
           }
      }

      if (this.cbCierreCaja.Checked)
          if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "CierreMF") && !AutorizadoReporteZ)
          {
              frmAutorizar fAut = new frmAutorizar();
              // fAut.Mensaje = Properties.Resources.MsgAutCierreCaja;
              fAut.Mensaje = Properties.Resources.MsgAutorizarDifCierreCierrecajaRepZ;
              fAut.NombreTecnico = this.Name;
              fAut.Accion = "CierreMF";
              fAut.ShowDialog();

              if (fAut.DialogResult == System.Windows.Forms.DialogResult.OK && fAut.Autorizado)
                  AutorizadoReporteZ = true;
              else
                  return;
          }
          else
              AutorizadoReporteZ = true;

      ((Button)sender).Enabled = false;
      Cursor.Current = Cursors.WaitCursor;

      if (efectivoCajero > 0 && !this.GuardarAlivio()) {
        MessageBox.Show(Properties.Resources.MsgErrorAlivio, "Error -" + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        new NLogLogger().Error(Properties.Resources.MsgErrorAlivio);
        Util.ClearMessages();
        ((Button)sender).Enabled = true;
        Cursor.Current = Cursors.Default;
        return;
      }

      EPK_CierreCajeroEncabezado cierre = new EPK_CierreCajeroEncabezado();

      cierre.IdCaja = EstadoAplicacion.CajaActual.IdCaja;
      cierre.IdCajero = EstadoAplicacion.UsuarioActual.IdUsuario;
      cierre.Fecha = this._fechaNuevoCierre.Date;
      cierre.Hora = this._fechaNuevoCierre.TimeOfDay;
      cierre.TotalAlivios = TotalAlivio;

      cierre.EPK_CierreCajeroDenominacion = this.GenerarDetalleCierre();

      cierre.EPK_CierreCajeroPOS = this._listCierre.Where(lc => lc.DatosPOS).Select(lc =>
        new EPK_CierreCajeroPOS {
          IdFormaPago = lc.idFormaPago,
          IdPOS = lc.IdPos,
          LotePOS = lc.Lote,
          MontoPago = lc.Monto,
          MontoPOS = lc.MontoPOS,
          Observacion = lc.Observacion
        }).ToList();

      cierre.EPK_CierreCajeroPagos = this._listCierre.Where(lc => !lc.DatosPOS).Select(lc => new EPK_CierreCajeroPagos {
        IdFormaPago = lc.idFormaPago,
        MontoCierre = lc.MontoPOS,
        MontoPagos = lc.Monto,
        Observacion = lc.Observacion
      }).ToList();

      cierre.EPK_CierreCajeroPagos.Add(new EPK_CierreCajeroPagos {
        IdFormaPago = (byte)Util.ObtenerParametroEntero("ID_EFECTIVO"),
       // MontoCierre = Convert.ToDecimal(this.txMontoCierreEfectivo.Tag),
        MontoCierre = Convert.ToDecimal(decimal.Parse(this.txMontoCierreEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture)),
      //  MontoPagos = Convert.ToDecimal(this.txTotalEfectivo.Tag),
        MontoPagos = Convert.ToDecimal(decimal.Parse(this.txTotalEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture)),
        Observacion = ""
      });

      long Result = new CierreCajero().Nuevo(cierre);

      if (Result == 0) {
        MessageBox.Show(Properties.Resources.MsgErrorCierreCajero, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        new NLogLogger().Error(Properties.Resources.MsgErrorCierreCajero); // Log Auditoria
        Util.ClearMessages();
        ((Button)sender).Enabled = true;
        Cursor.Current = Cursors.Default;
        return;
      }

      EPK_AperturaCajeroEncabezado apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaNuevoCierre);

      if (apertura != null) {
        apertura.IdCierre = Result;

        if (!new AperturaCajero().Actualizar(apertura)) {
          MessageBox.Show(Properties.Resources.MsgErrorCierreCajero, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          new NLogLogger().Error(Properties.Resources.MsgErrorCierreCajero); // Log Auditoria
          Util.ClearMessages();
          ((Button)sender).Enabled = true;
          Cursor.Current = Cursors.Default;
          return;
        }
      }

      EPK_CierreCajeroEncabezado Cierre = new CierreCajero().Obtener(Result);

    //  new Impresora().ComprobanteDeCierre(Cierre, this.txMontoApertura.Tag.ToString(), TotalAlivio.ToString());
      //new Impresora().ComprobanteDeCierre(Cierre, decimal.Parse(this.txMontoApertura.Text, NumberStyles.Currency, CultureInfo.CurrentCulture).ToString(), TotalAlivio.ToString());

      MessageBox.Show(Properties.Resources.MsgExitoCierre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
      new NLogLogger().Info(Properties.Resources.MsgExitoCierre); // Log Auditoria

      if (AutorizadoReporteZ)
        new frmRepZ(multiplesZ: true, confim: false).ShowDialog();

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
        
      Util.ClearMessages();
      Cursor.Current = Cursors.Default;

      this.Close();
    }

    private void cbCierreCaja_CheckedChanged(object sender, EventArgs e)
    {
      ((CheckBox)sender).Font = new Font(((CheckBox)sender).Font, ((CheckBox)sender).Checked ? FontStyle.Bold : FontStyle.Regular);
    }

    private void dgCierre_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgCierre_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1) // Header
            return;

        CierreCajeroEntidad itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as CierreCajeroEntidad);

        if (itemSel == null)
            return;

        frmEdCierreCajero fEdCierre = new frmEdCierreCajero();
        fEdCierre.ItemCierre = itemSel;
        fEdCierre.ShowDialog();

        if (fEdCierre.DialogResult != System.Windows.Forms.DialogResult.OK)
            return;

        ((DataGridView)sender).Refresh();

        this.CalcularTotales();
    }

    private void dgCierre_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dgDenominacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgDenominacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DenominacionAlivio itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionAlivio);

      if (itemSel == null)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;
      fCant.ValorMaximo = short.MaxValue;
      fCant.Cantidad = itemSel.Cantidad;
      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      itemSel.Cantidad = (short)fCant.Cantidad;
      itemSel.TotalXDenominacion = itemSel.Cantidad * itemSel.Denominacion;

      ((DataGridView)sender).Refresh();

      this.CalcularTotales();
    }

    private void dgDenominacion_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void frmCierreCajero_Activated(object sender, EventArgs e)
    {
      this.Text = "Cierre de Cajero - " + EstadoAplicacion.UsuarioActual.Identificacion + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmCierreCajero_Load(object sender, EventArgs e)
    {
        VigenciaVisualizarSeg = Util.ObtenerParametroEntero("VIGENCIAVISUALIZARSEG");
        //DataGridViewCellFormattingEventArgs dg = dgCierre;
        Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        this.Icon = appIcon;
        BloquearInformacion();

          this.AgregarToolTips();
          EPK_AperturaCajeroEncabezado apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaNuevoCierre);
          
          //if (apertura == null)
          //{
          //    MessageBox.Show(Properties.Resources.NoExisteAperturaCaja);
          //    return;
          //}
          //else
           this.CargarDatos();
                }

    private void BloquearInformacion()
    {
   
        if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Visualizar"))
        {

            foreach (var ctrl in this.panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    var tagString = (ctrl as TextBox).Tag;
                    if (tagString != null)
                    {
                        if (!string.IsNullOrEmpty(tagString.ToString()))
                        {
                            if (tagString.ToString() == "Visualizar")
                                ((TextBox)ctrl).PasswordChar = 'x';
                        }
                    }
                }

            }
            if ((string)dgCierre.Tag == "Visualizar")
                this.dgCierre.Columns["MontoPOS"].DefaultCellStyle.Format = "xxxxxxxxx";

            foreach (var ctrl in this.panel2.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    var tagString = (ctrl as TextBox).Tag;
                    if (tagString != null)
                    {
                        if (!string.IsNullOrEmpty(tagString.ToString()))
                        {
                            if (tagString.ToString() == "Visualizar")
                                ((TextBox)ctrl).PasswordChar = 'x';
                        }
                    }
                }

            }
        }
    }
    

    private void frmCierreCajero_Shown(object sender, EventArgs e)
    {
        if (new CierreVentas().Obtener() != null)
        {
            MessageBox.Show(Properties.Resources.MsgCierreVentaExiste, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
            return;
        }

        /*
        if (new AlivioEfectivo().CantidadPorAprobar(EstadoAplicacion.UsuarioActual.IdUsuario) > 0) {
          MessageBox.Show(Properties.Resources.MsgAliviosPendCajero, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
          return;
        }
        */

        if (!Util.VerificarImpresora("frmFacturar"))
        {
            this.Close();
            return;
        }

       }

    private void frmCierreCajero_FormClosing(object sender, FormClosingEventArgs e)
    {

    }

    private void btAgregarFP_Click(object sender, EventArgs e)
    {
        frmEdCierreCajeroAgregar fEdCierre = new frmEdCierreCajeroAgregar();
        fEdCierre._listCierre = this._listCierre;
        fEdCierre.ShowDialog();

        if (fEdCierre.DialogResult != System.Windows.Forms.DialogResult.OK)
            return;

        this.dgCierre.DataSource = fEdCierre._listCierre;
        this.dgCierre.Refresh();
        CalcularTotales();
    }

 

    #endregion Events

    #region Private Methods

    private decimal ObtenerMontoFormaPago(int _idFormaPago, int _idPos, DateTime _fechaApertura)
    {
        decimal _montoOtrosPagos = 0;
        DateTime _fecha = new DataAccess(true).FechaDB().Date;

        List<EPK_FacturaEncabezado> _facturas = new Facturas().ObtenerTodas(new EPK_FacturaEncabezado
        {
            IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario,
            Fecha = _fecha
        }).ToList();

        foreach (EPK_FacturaEncabezado itemFactura in _facturas)
            if (itemFactura.FechaCreacion >= _fechaApertura)
            {
                List<EPK_FacturaPago> _listPagos = itemFactura.EPK_FacturaPago.Where(p => p.IdFormaPago == _idFormaPago && p.IdPOS == (_idPos == 0 ? p.IdPOS : _idPos)).ToList();
                _montoOtrosPagos += _listPagos.Sum(a => a.Monto);
            }

        return _montoOtrosPagos;
    }

    private void AgregarToolTips()
    {
      ToolTip mainToolTip = new ToolTip();

      // Se asignan los tiempos.
      mainToolTip.AutoPopDelay = 5000;
      mainToolTip.InitialDelay = 1000;
      mainToolTip.ReshowDelay = 500;

      // Se muestra el tooltip siempre, aunque la forma no esté activa.
      mainToolTip.ShowAlways = true;

      // Se colocan los tooltips a los controles.
      mainToolTip.SetToolTip(this.btCalc, Properties.Resources.TipCalc);
      mainToolTip.SetToolTip(this.btAgregarFP, Properties.Resources.TipAgregarFP);
    }

    private void CalcularTotales()
    {
      decimal EfectivoCajero = this._listDenominacionAlivio.Sum(lda => lda.Denominacion * lda.Cantidad);

      //this.txMontoCierreEfectivo.Tag = EfectivoCajero;
      this.txMontoCierreEfectivo.Text = string.Format("{0:C2}", EfectivoCajero);
     
      // Totales Otros Pagos
      decimal totalOtrosPagos = this._listCierre.Sum(lc => lc.Monto);
      decimal totalMontoOperaciones = this._listCierre.Sum(lc => lc.MontoPOS);

     // this.txTotalOtros.Tag = totalOtrosPagos;
      this.txTotalOtros.Text = string.Format("{0:C2}", totalOtrosPagos);
      
      //this.txOtrosCierre.Tag = totalMontoOperaciones;
      this.txOtrosCierre.Text = string.Format("{0:C2}", totalMontoOperaciones);

      decimal totalDifOtrosPagos = this._listCierre.Sum(lc => lc.Diferencia);

     // this.txDifOtrosPagos.Tag = totalDifOtrosPagos;
      this.txDifOtrosPagos.Text = string.Format("{0:C2}", totalDifOtrosPagos);

      if (totalDifOtrosPagos > 0)
      {
          this.txDifOtrosPagos.ForeColor = Color.Red;
      }
      else
      {
          this.txDifOtrosPagos.ForeColor = Color.Black;
      }

      // Totales Efectivo
      decimal totalCierreEfectivo = 0;
      //if (this.txMontoCierreEfectivo.Tag != null)
            //decimal.TryParse(this.txMontoCierreEfectivo.Tag.ToString(), out totalCierreEfectivo);
      if ((decimal.Parse(this.txMontoCierreEfectivo.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)) != null)
          decimal.TryParse((decimal.Parse(this.txMontoCierreEfectivo.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)).ToString(), out totalCierreEfectivo);



      decimal totalAlivioDia = 0;
      //if (this.txTotalAlivios.Tag != null)
      //  decimal.TryParse(this.txTotalAlivios.Tag.ToString(), out totalAlivioDia);
      if ((decimal.Parse(this.txTotalAlivios.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)) != null)
          decimal.TryParse((decimal.Parse(this.txTotalAlivios.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)).ToString(), out totalAlivioDia);




      decimal totalAlivioPdte = 0;
      //if (this.txTotalAlivios.Tag != null)
      //    decimal.TryParse(this.TxTotalAliviosPendientes.Tag.ToString(), out totalAlivioPdte);
      if ((decimal.Parse(this.txTotalAlivios.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)) != null)
          decimal.TryParse((decimal.Parse(this.TxTotalAliviosPendientes.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)).ToString(), out totalAlivioPdte);


      decimal EfectivoSistema = 0;
      //if (this.txEfectivoSistema.Tag != null)
      //  decimal.TryParse(this.txEfectivoSistema.Tag.ToString(), out EfectivoSistema);
      if ((decimal.Parse(this.txEfectivoSistema.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)) != null)
          decimal.TryParse((decimal.Parse(this.txEfectivoSistema.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)).ToString(), out EfectivoSistema);

      decimal totalEfectivoCierre = EfectivoCajero + totalAlivioDia + totalAlivioPdte;

      //this.txEfectivoCierre.Tag = totalEfectivoCierre;
      this.txEfectivoCierre.Text = string.Format("{0:C2}", totalEfectivoCierre);

      decimal DifEfectivo = EfectivoSistema - totalEfectivoCierre;
      //this.txEfectivoDif.Tag = DifEfectivo;
      this.txEfectivoDif.Text = string.Format("{0:C2}", DifEfectivo);

      if (DifEfectivo > 0)
        this.txEfectivoDif.ForeColor = Color.Red;
      else
        this.txEfectivoDif.ForeColor = Color.Black;

      // Totales Generales
      decimal totalsis = EfectivoSistema + totalOtrosPagos;
     // this.txTotalSistema.Tag = totalsis;
      this.txTotalSistema.Text = string.Format("{0:C2}", totalsis);

      decimal totalcierre = totalMontoOperaciones + totalEfectivoCierre;
    // this.txTotalCierreSistema.Tag = totalcierre;
      this.txTotalCierreSistema.Text = string.Format("{0:C2}", totalcierre);

      decimal totaldif = DifEfectivo + totalDifOtrosPagos;
    //  this.txTotalCierre.Tag = totaldif;
      this.txTotalCierre.Text = string.Format("{0:C2}", totaldif);

      if (totaldif > 0)
        this.txTotalCierre.ForeColor = Color.Red;
      else
        this.txTotalCierre.ForeColor = Color.Black;

      decimal MontoApertura = 0;
      //decimal.TryParse(this.txMontoApertura.Tag.ToString(), out MontoApertura);
      decimal.TryParse((decimal.Parse(this.txMontoApertura.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture)).ToString(), out MontoApertura);
     
     // this.txDiferenciaAperturaCierre.Tag = Convert.ToDecimal(this.txEfectivoPorEntregar.Tag) - totalCierreEfectivo;
     // this.txDiferenciaAperturaCierre.Text = string.Format("{0:C2}", (Convert.ToDecimal(this.txEfectivoPorEntregar.Tag) - totalCierreEfectivo));
      this.txDiferenciaAperturaCierre.Text = string.Format("{0:C2}", (Convert.ToDecimal(decimal.Parse(this.txEfectivoPorEntregar.Text, NumberStyles.Currency, CultureInfo.CurrentCulture)) - totalCierreEfectivo));

      this.dgDenominacion.Enabled = true;

      //Hay facturación en el día
      if (totalsis > 0)
      {
          this.dgDenominacion.Enabled = true;
          this.btAgregarFP.Enabled = true;
      }
      else
      {
          this.dgDenominacion.Enabled = false;
          this.btAgregarFP.Enabled = false;      
      }
    }

    private void CargarDatos()
    {
      DateTime currDate = new DataAccess(true).FechaDB();

      DateTime? fechaUltCierre = null;

      this._fechaNuevoCierre = currDate;

    //(  this.txTotalEfectivo.Tag = this.txTotalAlivios.Tag = this.txEfectivoPorEntregar.Tag = this.txMontoApertura.Tag = 0;

      this.txTotalEfectivo.Text = this.txTotalAlivios.Text = this.txEfectivoPorEntregar.Text = this.txMontoApertura.Text =
        string.Format("{0:C2}", 0);

      this.txCajero.Text = EstadoAplicacion.UsuarioActual.Identificacion.Trim();
      this.txCaja.Text = EstadoAplicacion.CajaActual.Descripcion.Trim();

      EPK_CierreCajeroEncabezado ultimoCierre = new CierreCajero().ObtenerUltimo(EstadoAplicacion.UsuarioActual.IdUsuario);

      if (ultimoCierre != null)
        fechaUltCierre = ultimoCierre.Fecha + ultimoCierre.Hora;

      EPK_FacturaEncabezado primeraFactura = new Facturas().ObtenerPrimera(EstadoAplicacion.UsuarioActual.IdUsuario, fechaUltCierre);

      if (primeraFactura != null) {
        this._fechaIniNuevoCierre = primeraFactura.FechaCreacion;

        if (primeraFactura.FechaCreacion.Date != this._fechaNuevoCierre.Date) {
          DateTime fechaFin = primeraFactura.FechaCreacion.Date.AddDays(1).Date;

          EPK_FacturaEncabezado ultimaFactura = new Facturas().ObtenerUltima(EstadoAplicacion.UsuarioActual.IdUsuario, fechaFin);

          if (ultimaFactura != null)
            this._fechaNuevoCierre = ultimaFactura.FechaCreacion;
        }
      }

      this.txFechaCierre.Text = this._fechaNuevoCierre.ToString("d");

      EPK_AperturaCajeroEncabezado apertura = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaNuevoCierre);
      if (apertura != null) {
        decimal montoApertura = apertura.EPK_AperturaCajeroDenominacion.Sum(acd => acd.EPK_Denominacion.Denominacion * acd.Cantidad);
      //  this.txMontoApertura.Tag = montoApertura;
        this.txMontoApertura.Text = string.Format("{0:C2}", montoApertura);
      }
      //if (apertura == null)
      //{
      //    MessageBox.Show(Properties.Resources.NoExisteAperturaCaja);
      //    return ;
      //}
      decimal MontoEfectivoSistema = new Facturas().MontoPendiente(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);
     // this.txTotalEfectivo.Tag = MontoEfectivoSistema;
      this.txTotalEfectivo.Text = string.Format("{0:C2}", MontoEfectivoSistema);

    //  this.txEfectivoSistema.Tag = MontoEfectivoSistema;
      this.txEfectivoSistema.Text = string.Format("{0:C2}", MontoEfectivoSistema);

      decimal TotalAlivioDia = new AlivioEfectivo().BuscarMontoTotalAlivios(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);
    //  this.txTotalAlivios.Tag = TotalAlivioDia;
      this.txTotalAlivios.Text = string.Format("{0:C2}", TotalAlivioDia);


      decimal TotalAliviosPendiente = new AlivioEfectivo().TotalPendientes(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);
    // this.TxTotalAliviosPendientes.Tag = TotalAliviosPendiente;
      this.TxTotalAliviosPendientes.Text = string.Format("{0:C2}", TotalAliviosPendiente);
      if(TotalAliviosPendiente > 0)
          this.TxTotalAliviosPendientes.ForeColor = Color.Red; 
      else
        this.TxTotalAliviosPendientes.ForeColor = Color.Gray;

     // this.txEfectivoPorEntregar.Tag = MontoEfectivoSistema - TotalAlivioDia - TotalAliviosPendiente;
      this.txEfectivoPorEntregar.Text = string.Format("{0:C2}", MontoEfectivoSistema - TotalAlivioDia - TotalAliviosPendiente);

      // Carga de las denominaciones de efectivo
      IEnumerable<EPK_Denominacion> denominaciones = new Denominacion().ObtenerTodas();

      this._listDenominacionAlivio = new BindingList<DenominacionAlivio>(
        denominaciones.Select(d => new DenominacionAlivio {
          IdDenominacion = d.IdDenominacion,
          Denominacion = d.Denominacion,
          Logo = d.Logo,
          Cantidad = 0,
          TotalXDenominacion = 0
        }).ToList());

      this.dgDenominacion.DataSource = this._listDenominacionAlivio;
      this.dgDenominacion.Refresh();

      // Se cargan las otras formas de pago.
      int idEfectivo = Util.ObtenerParametroEntero("ID_EFECTIVO");

      List<EPK_FacturaEncabezado> facturas = new Facturas().ObtenerTodas(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);

      BindingList<CierreCajeroEntidad> tempList = new BindingList<CierreCajeroEntidad>();

      if (facturas != null)
        foreach (EPK_FacturaEncabezado itemFactura in facturas) {
          List<EPK_FacturaPago> _listPagos = itemFactura.EPK_FacturaPago.Where(p => p.IdFormaPago != idEfectivo).ToList();

          foreach (EPK_FacturaPago itemPago in _listPagos) {
            CierreCajeroEntidad itemCierre = tempList.FirstOrDefault(p => p.idFormaPago == itemPago.IdFormaPago && (itemPago.IdPOS.HasValue ? p.IdPos == itemPago.IdPOS : true));

            if (itemCierre == null) {
              tempList.Add(new CierreCajeroEntidad {
                idFormaPago = itemPago.IdFormaPago,
                FormaPago = itemPago.EPK_FormaPago.Descripcion,
                IdPos = itemPago.IdPOS != null ? (int)itemPago.IdPOS : 0,
                Pos = itemPago.IdPOS != null ? itemPago.EPK_POS.Descripcion : string.Empty,
                MontoPOS = 0,
                Monto = itemPago.Monto,
                Diferencia = itemPago.Monto,
                Observacion = string.Empty,
                DatosPOS = itemPago.EPK_FormaPago.DatosPOS
              });
              continue;
            }

            itemCierre.Monto += itemPago.Monto;
            itemCierre.Diferencia += itemPago.Monto;
          }
        }

      this._listCierre = new BindingList<CierreCajeroEntidad>(tempList.OrderBy(t => t.Pos).ThenBy(t => t.FormaPago).ToList());

      this.dgCierre.DataSource = this._listCierre;
      this.dgCierre.Refresh();

      this.cbCierreCaja.Checked = false;
     // this.cbCierreCaja.Enabled = (this._fechaNuevoCierre.Date == currDate.Date);

      string Fecha = string.Empty, Hora = string.Empty;
      new Impresora().FechaHoraReducion(ref Fecha, ref Hora);

      if (currDate.ToString("ddMMyy") == Fecha)
        this.cbCierreCaja.Checked = false;

      this.CalcularTotales();
    }

    private List<EPK_CierreCajeroDenominacion> GenerarDetalleCierre()
    {
      List<EPK_CierreCajeroDenominacion> listCierreCajeroDenominacion =
        this._listDenominacionAlivio.Where(ld => ld.Cantidad != 0).Select(ld =>
        new EPK_CierreCajeroDenominacion {
          IdDenominacion = ld.IdDenominacion,
          Cantidad = ld.Cantidad
        }).ToList();

      if (listCierreCajeroDenominacion == null)
        listCierreCajeroDenominacion = new List<EPK_CierreCajeroDenominacion>();

      return listCierreCajeroDenominacion;
    }

    private bool GuardarAlivio()
    {
      try {
        decimal totalAlivio = this._listDenominacionAlivio.Sum(lda => lda.Cantidad * lda.Denominacion);

        if (totalAlivio <= 0)
          return true;

        decimal MontoAlivioSistema = new Facturas().MontoPendiente(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);
        decimal TotalAlivioDia = new AlivioEfectivo().BuscarMontoTotalAlivios(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);
        decimal TotalAliviosPendiente = new AlivioEfectivo().TotalPendientes(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);

        EPK_AlivioEfectivoEncabezado nuevoAlivio = new EPK_AlivioEfectivoEncabezado();

        nuevoAlivio.IdUsuarioCajero = EstadoAplicacion.UsuarioActual.IdUsuario;
        nuevoAlivio.TotalAlivio = totalAlivio;
        nuevoAlivio.IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario;
        nuevoAlivio.TotalPagosEfectivo = MontoAlivioSistema - TotalAlivioDia;
        nuevoAlivio.IdCaja = EstadoAplicacion.CajaActual.IdCaja;
        nuevoAlivio.FechaAlivio = this._fechaNuevoCierre.Date;
        nuevoAlivio.HoraAlivio = this._fechaNuevoCierre.TimeOfDay;

        List<EPK_AlivioEfectivoDetalle> listAlivioEfectivoDetalle =
          this._listDenominacionAlivio.Where(lda => lda.Cantidad > 0).Select(lda => new EPK_AlivioEfectivoDetalle {
            IdDenominacion = lda.IdDenominacion,
            CantidadCajero = lda.Cantidad
          }).ToList();

        nuevoAlivio.EPK_AlivioEfectivoDetalle = listAlivioEfectivoDetalle;

        long IdAlivio = new AlivioEfectivo().Nuevo(nuevoAlivio);

        if (IdAlivio > 0) {
          nuevoAlivio = new AlivioEfectivo().Obtener(IdAlivio);
          new Impresora().ImprimirComprobanteAlivio(nuevoAlivio, (MontoAlivioSistema - TotalAlivioDia - totalAlivio - TotalAliviosPendiente));
        }

        return true;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        return false;
      }
    }

    #endregion Private Methods

    private void frmCierreCajero_KeyDown(object sender, KeyEventArgs e)
    {
       if (e.Shift || e.Alt || e.Control)
            return;

        switch (e.KeyCode)
        {

            case Keys.F3:

                VisualizarInformacion();
                BloqueoTimeout.Interval = VigenciaVisualizarSeg * 1000;
                BloqueoTimeout.Start();
               
                break;

            case Keys.F4:                
                BloquearInformacion();
              
                break;
        }
    }

    private void VisualizarInformacion()
    {
        if (new Accesos().AccionReqAutorizacion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "Visualizar"))
        {
            frmAutorizar fAut = new frmAutorizar();
            fAut.Mensaje = Properties.Resources.MsgAutorizarCierreCaja;
            fAut.NombreTecnico = this.Name;
            fAut.Accion = "Visualizar";
            fAut.ShowDialog();
            if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || (!fAut.Autorizado))
                return;
            foreach (var ctrl in this.panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    var tagString = (ctrl as TextBox).PasswordChar;
                    if (tagString != null)
                    {
                        if (!string.IsNullOrEmpty(tagString.ToString()))
                        {
                            if (tagString.ToString().Contains('x'))
                            {
                                ((TextBox)ctrl).PasswordChar = '\0';
                                ((TextBox)ctrl).Tag = "Visualizar";
                                ((TextBox)ctrl).Refresh();
                            }

                        }
                    }
                }

            }
            if ((string)dgCierre.Tag == "Visualizar")
                this.dgCierre.Columns["MontoPOS"].DefaultCellStyle.Format = string.Empty;

            foreach (var ctrl in this.panel2.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    var tagString = (ctrl as TextBox).PasswordChar;
                    if (tagString != null)
                    {
                        if (!string.IsNullOrEmpty(tagString.ToString()))
                        {
                            if (tagString.ToString().Contains('x'))
                            {
                                ((TextBox)ctrl).PasswordChar = '\0';
                                ((TextBox)ctrl).Tag = "Visualizar";
                                ((TextBox)ctrl).Refresh();
                            }

                        }
                    }
                }

            }
        }
      
    }

    public void PerformOperation(TimeSpan timeout)
    {
        // Insert code for the method here.
        Console.WriteLine("performing operation with timeout {0}",
          timeout.ToString());
    }

    private void BloqueoTimeout_Tick(object sender, EventArgs e)
    {
        
        BloqueoTimeout.Stop();
        BloquearInformacion();
       
    }
  }
}