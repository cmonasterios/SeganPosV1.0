using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmArtVend : Form
  {
    #region Private Properties

    private DateTime FechaDesde { get; set; }

    private DateTime FechaHasta { get; set; }

    private int IdColeccion { get; set; }

    private List<EPK_sp_ReporteVentasxArticulos_Result> ventasxArticulos { get; set; }

    #endregion Private Properties

    #region Constructor

    public frmArtVend()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void backgroundWorkerExist_DoWork(object sender, DoWorkEventArgs e)
    {
      this.ventasxArticulos = new DAL.Reportes().ReporteVentasxArticulos(this.IdColeccion, this.FechaDesde, this.FechaHasta);
    }

    private void backgroundWorkerExist_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      try {
        if (e.Error != null) {
          new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
            "." + System.Reflection.MethodBase.GetCurrentMethod().Name), e.Error);
          MessageBox.Show("Error al ejecutar la consulta", "Error " + this.Text, MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);
          return;
        }

        long totalventa = this.ventasxArticulos.Where(v => v.Ventas.HasValue && v.Ventas.Value > 0).Sum(v => v.Ventas.Value);
        long totaldev = this.ventasxArticulos.Where(v => v.Ventas.HasValue && v.Ventas.Value < 0).Sum(v => v.Ventas.Value);

        this.dataGridViewVentas.ClearSelection();
        this.dataGridViewVentas.DataSource = this.ventasxArticulos;

        this.txtVendido.Text = totalventa.ToString("0");
        this.txtDevolucion.Text = Math.Abs(totaldev).ToString("0");

        this.btExport.Enabled = (this.ventasxArticulos.Count() > 0);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
      finally {
        this.btBuscar.Enabled = true;
        this.pbVentas.Visible = false;
        Cursor = Cursors.Default;
      }
    }

    private void btBuscar_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;

      ((Button)sender).Enabled = this.btExport.Enabled = false;
      this.pbVentas.Visible = true;

      this.IdColeccion = Convert.ToInt32(this.cbColeccion.SelectedValue);
      this.FechaDesde = this.dtpDesde.Value.Date;
      this.FechaHasta = this.dtpHasta.Value.Date;

      this.backgroundWorkerExist.RunWorkerAsync();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btExport_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "VentasxArticulo.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void dataGridViewVentas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dataGridViewVentas_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void frmArtVend_Activated(object sender, EventArgs e)
    {
      this.Text = "Ventas por Artículo  - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmArtVend_Load(object sender, EventArgs e)
    {
        this.dtpHasta.MinDate = DateTime.Today;
        this.dtpHasta.MaxDate = DateTime.Today;
        this.dtpDesde.MaxDate = DateTime.Today;

        this.dtpDesde.Value = DateTime.Today;
        this.dtpHasta.Value = DateTime.Today;

        Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        this.Icon = appIcon;

        this.dtpDesde.Format = DateTimePickerFormat.Custom;
        this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

        this.dtpHasta.Format = DateTimePickerFormat.Custom;
        this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

        if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btExport.Tag.ToString()))
            this.btExport.Visible = false;

        this.CargarCombo();
        this.Limpiar();
    }

    private void frmArtVend_Shown(object sender, EventArgs e)
    {
      this.cbColeccion.Focus();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      try {
        Cursor = Cursors.WaitCursor;

        this.ventasxArticulos = new DAL.Reportes().ReporteVentasxArticulos(Convert.ToInt32(cbColeccion.SelectedValue),
         this.dtpDesde.Value.Date, this.dtpHasta.Value.Date);

        if (this.ventasxArticulos.Count() == 0)
          return;

        var exceldata = (from r in this.ventasxArticulos
                         select new {
                           Fecha = r.Fecha.ToShortDateString(),
                           IdFactura = r.IdFactura.ToString(),
                           CodigoArticulo = r.CodArticulo.ToString(),
                           Ventas = r.Ventas.ToString()
                         }).ToList();

        if (new ExportExcel().DumpExcel(exceldata, ((SaveFileDialog)sender).FileName))
          NotificationManager.Show(this, "Ventas exportadas exitosamente", EstadoAplicacion.ToastColor,
            EstadoAplicacion.ToastTimeout);
        else
          MessageBox.Show("Error al escribir el archivo", "Exportar - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show("Error al escribir el archivo", "Exportar - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      finally {
        Cursor = Cursors.Default;
      }
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
        if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
            this.dtpHasta.Value = ((DateTimePicker)sender).Value;

        this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }
    #endregion Events

    #region Private Methods

    private void CargarCombo()
    {
      IEnumerable<EPK_Coleccion> colecciones = new Colecciones().ObtenerActivas();

      this.cbColeccion.DataSource = colecciones;
      this.cbColeccion.ValueMember = "IdColeccion";
      this.cbColeccion.DisplayMember = "Descripcion";

      if (colecciones.Count() == 1) {
        this.cbColeccion.SelectedIndex = 0;
        this.cbColeccion.Enabled = false;
      }
      else {
        EPK_Coleccion actual = colecciones.FirstOrDefault(c => c.Actual);
        this.cbColeccion.SelectedIndex = -1;
      }
    }

    private void Limpiar()
    {
      this.cbColeccion.SelectedIndex = -1;
      this.dtpDesde.Value = this.dtpHasta.Value = DateTime.Now.Date;

      this.IdColeccion = Convert.ToInt32(this.cbColeccion.SelectedValue);
      this.FechaDesde = this.dtpDesde.Value.Date;
      this.FechaHasta = this.dtpHasta.Value.Date;

      this.txtVendido.Text = this.txtDevolucion.Text = "0";

      List<EPK_sp_ReporteVentasxArticulos_Result> tempList = new List<EPK_sp_ReporteVentasxArticulos_Result>();

      this.dataGridViewVentas.DataSource = tempList;
      this.dataGridViewVentas.Refresh();
    }

    #endregion Private Methods


  }
}