using System;
using System.Windows.Forms;
using System.Threading;

using SEGAN_POS.DAL;
using System.Collections.Generic;

namespace SEGAN_POS
{
  public partial class frmMenuMF : Form
  {

    #region Constructor
    public frmMenuMF()
    {
      InitializeComponent();
      cbTipo.SelectedIndex = 0;
    }
    #endregion

    #region Events

    private void btReporteX_Click(object sender, EventArgs e)
    {
      string[] strError = new string[] { string.Empty, string.Empty };

      try {
        if (MessageBox.Show(Properties.Resources.MsgConfirmarX, "SEGAN POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
          return;

        Impresora impresora = new Impresora();

        string UltimaReduccion = impresora.DatosUltimaReduccion();
        if (string.IsNullOrEmpty(impresora.Serial)) {
          MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error - ", MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        impresora.ReporteX();

        MessageBox.Show(Properties.Resources.MsgSucessX, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void btEjecutar_Click(object sender, EventArgs e)
    {
      string automatico = string.Empty;
      string[] strError = new string[] { string.Empty, string.Empty };
      this.btEjecutar.Enabled = false;

      try {
        DateTime currDate = new DataAccess(true).FechaDB();
        Impresora impresora = new Impresora();

        switch (cbTipo.SelectedIndex) {
          case 1: // Mensual Detallado
            if (dtpDesde.Value.CompareTo(dtpHasta.Value) > 0) {
              MessageBox.Show(Properties.Resources.MsgValidacionFecha, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
              break;
            }

            impresora.LecturaMemoriaFiscalFechaMFD(dtpDesde.Value.ToString("dd/MM/yy"), dtpHasta.Value.ToString("dd/MM/yy"), "c");
            if (string.IsNullOrEmpty(impresora.Serial)) {
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error -", MessageBoxButtons.OK, MessageBoxIcon.Error);
              break;
            }
            MessageBox.Show(Properties.Resources.MsgSucessZDetallado, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 2: // Mensual Consolidado
            if (dtpDesde.Value.CompareTo(dtpHasta.Value) > 0) {
              MessageBox.Show(Properties.Resources.MsgValidacionFecha, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
              break;
            }

            impresora.LecturaMemoriaFiscalFechaMFD(dtpDesde.Value.ToString("dd/MM/yy"), dtpHasta.Value.ToString("dd/MM/yy"), "s");

            if (string.IsNullOrEmpty(impresora.Serial)) {
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error -", MessageBoxButtons.OK, MessageBoxIcon.Error);
              break;
            }
            MessageBox.Show(Properties.Resources.MsgSucessZMensual, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 3: //Rango de Z
            if (udDesde.Value.CompareTo(udHasta.Value) > 0) {
              MessageBox.Show(Properties.Resources.MsgValidacionRango, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
              break;
            }

            impresora.LecturaMemoriaFiscalReduccion(udDesde.Value.ToString(), udHasta.Value.ToString());

            if (string.IsNullOrEmpty(impresora.Serial)) {
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error -", MessageBoxButtons.OK, MessageBoxIcon.Error);
              break;
            }
            MessageBox.Show(Properties.Resources.MsgSucessZRango, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 4: // Verificar Reporte Z Automático
            string nroZ = impresora.NroRepZ(); // se obtiene el nro de reporte Z

            if (impresora.DatosUltimaReduccion() != string.Empty) {
              // se valida que sea un reporte automatico, si es 01 es un reporte automatico
              automatico = (impresora.DatosUltimaReduccion()).Substring(0, 2);
            }
            if (automatico == "01") {
              if (!impresora.CierreReporteZ()) {
                new NLogLogger().Error(Properties.Resources.ErrorCierreMF);
                MessageBox.Show(Properties.Resources.ErrorCierreMF, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
              }
              MessageBox.Show(Properties.Resources.MsgReporteReporteZAutomatico, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
              MessageBox.Show(Properties.Resources.MsgReporteReporteZNOAutomatico, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            break;

          case 5: // Cierre de Máquina Fiscal por Día
            this.Cursor = Cursors.WaitCursor;
            List<string> repsZ = new Facturas().ObtenerRepZ(this.dtpFecha.Value, impresora.Serial);

            if (repsZ.Count <= 0) {
              this.Cursor = Cursors.Default;
              MessageBox.Show(Properties.Resources.MsgErrorSinFact, "Error - " + this.Text, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
              break;
            }

            int idMF = new Dispositivos().ObtenerIdMFCierre(impresora.Serial);

            int totalCierres = 0, totalErrores = 0;

            foreach (string itemZ in repsZ) {
              if (new CierreMaquinaFiscal().Obtener(idMF, itemZ) != null)
                continue;

              DatosReduccionZ datosRepZ = new Impresora().LecturaMemoriaFiscalSerialReduccion(itemZ);

              if (new CierreMaquinaFiscal().Guardar(idMF, itemZ, datosRepZ))
                totalCierres++;
              else
                totalErrores++;
            }

            string mensaje = string.Empty;
            if (totalCierres > 0)
              mensaje = string.Format("Se efectuó con éxito {0} cierre de Máquina Fiscal.", totalCierres);

            if (totalErrores > 0) {
              if (!string.IsNullOrEmpty(mensaje))
                mensaje += Environment.NewLine;

              mensaje += string.Format("Se presentaron errores en {0} de los cierres de Máquina Fiscal.", totalErrores);
            }

            if (totalCierres == 0 && totalErrores == 0)
              mensaje = "No tiene cierres de Máquina Fiscal pendientes para la fecha seleccionada.";

            if (!string.IsNullOrEmpty(mensaje))
              MessageBox.Show(mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Cursor = Cursors.Default;
            break;

          case 6: // Reimprimir Facturas por Fecha
            if (dtpDesde.Value.CompareTo(dtpHasta.Value) > 0) {
              MessageBox.Show(Properties.Resources.MsgValidacionFecha, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
              break;
            }

            impresora.ReImprimirFactura(this.dtpDesde.Value, this.dtpHasta.Value);
            if (string.IsNullOrEmpty(impresora.Serial)) {
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error -", MessageBoxButtons.OK, MessageBoxIcon.Error);
              break;
            }
            MessageBox.Show("Facturas reimpresas exitosamente", "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            break;

          case 7: // Reimprimir Facturas por COO
            if (udDesde.Value.CompareTo(udHasta.Value) > 0) {
              MessageBox.Show(Properties.Resources.MsgValidacionRango, "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
              break;
            }

            impresora.ReImprimirFactura(this.udDesde.Value.ToString("000000"), this.udHasta.Value.ToString("000000"));
            if (string.IsNullOrEmpty(impresora.Serial)) {
              MessageBox.Show(Properties.Resources.MsgErrorComImp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              break;
            }
            MessageBox.Show("Facturas reimpresas exitosamente", "SEGAN POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          case 8:
            if (Util.VerificarImpresora(null, true))
              MessageBox.Show("Impresora lista y en línea.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            break;

          default: // Del Día
            if (MessageBox.Show(Properties.Resources.MsgConfirmarZ, "SEGAN POS", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {

              new frmRepZ(multiplesZ: true).ShowDialog();
            }
            break;
        }

      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        this.Cursor = Cursors.Default;
      }
      finally {
        btEjecutar.Enabled = true;
      }
    }

    private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (cbTipo.SelectedIndex) {
        case 1: // Mensual Detallado
          this.panelRagoZ.Visible = this.pnFecha.Visible = false;
          this.panelRangoFechas.Visible = true;
          break;

        case 2: // Mensual Consolidado
          this.panelRagoZ.Visible = this.pnFecha.Visible = false;
          this.panelRangoFechas.Visible = true;
          break;

        case 3: // Rango de Z
          this.panelRagoZ.Visible = true;
          this.panelRangoFechas.Visible = this.pnFecha.Visible = false;
          break;

        case 4: // Verificar Reporte Z Automático
          this.panelRagoZ.Visible = this.panelRangoFechas.Visible =
            this.pnFecha.Visible = false;
          break;

        case 5: // Cierre de Máquina Fiscal por Día
          this.panelRagoZ.Visible = this.panelRangoFechas.Visible = false;
          this.pnFecha.Visible = true;
          this.dtpFecha.Focus();
          break;

        case 6: // Reimprimir Facturas por Fecha
          this.panelRagoZ.Visible = this.pnFecha.Visible = false;
          this.panelRangoFechas.Visible = true;
          break;

        case 7: // Reimprimir Facturas por COO
          this.panelRagoZ.Visible = true;
          this.panelRangoFechas.Visible = this.pnFecha.Visible = false;
          break;

        default: // Del Día
          this.panelRagoZ.Visible = this.panelRangoFechas.Visible =
            this.pnFecha.Visible = false;
          break;
      }
    }

    private void frmMenuMF_Activated(object sender, EventArgs e)
    {
      this.Text = "Reportes de Máquina Fiscal - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmMenuMF_Load(object sender, EventArgs e)
    {
      this.dtpFecha.Format = DateTimePickerFormat.Custom;
      this.dtpFecha.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpDesde.Value = this.dtpHasta.Value = DateTime.Today;
      this.dtpDesde.MaxDate = this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpFecha.Value = DateTime.Today;
      this.dtpFecha.MaxDate = DateTime.Today;
      Impresora impresora = new Impresora();
      if (string.IsNullOrEmpty(impresora.Serial)) {
        this.btReporteX.Enabled = this.groupBox1.Enabled = false;
        this.labelSerialMF.Text = "Serial: Impresora no conectada";
      }
      else {
        this.btReporteX.Enabled = this.groupBox1.Enabled = true;
        this.labelSerialMF.Text = "Serial: " + impresora.Serial;
      }
    }

    #endregion

  }
}
