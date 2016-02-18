using OfficeOpenXml;
using OfficeOpenXml.Style;
using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmPedidoSugerido : Form
  {
    private int Entre5y;
    private DateTime FechaDesde;
    private DateTime FechaHasta;
    private int IdColeccion;
    private int MenosDe;
    private List<EPK_sp_MaestroPedidoSugerido_Result> Pedido;
    private List<PedidoSugerido> pedidosSug;
    private int PidoEntre5y;
    private int PidoPMenosDe;
    private int PiezasVendidas = 0;
    private int Solicitado = 0;
    private int TotalExistenciaAlmacen = 0;
    private int TotalExistenciaTienda = 0;
    private List<EPK_sp_ReporteVentasxArticulos_Result> VentasxArticulos;
    public frmPedidoSugerido()
    {
      InitializeComponent();
      CargarCombos();
    }

    private void backgroundWorkerExist_DoWork(object sender, DoWorkEventArgs e)
    {
      try {
        pedidosSug = new Articulos().BuscarPorColeccion(IdColeccion);
        VentasxArticulos = new DAL.Reportes().ReporteVentasxArticulos(IdColeccion, FechaDesde, FechaHasta);
        /*foreach (EPK_sp_ReporteVentasxArticulos_Result item in VentasxArticulos)
          if (item.FotoPeq == null)
            item.FotoPeq = Properties.Resources.imagennodisp.ToByteArray(ImageFormat.Bmp);*/
      }
      catch (Exception) {
        MessageBox.Show("Error al consultar las existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }

    private void backgroundWorkerExist_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      // progressBarExistencias.Value = e.ProgressPercentage; //actualizamos la barra de progreso
      DateTime time = Convert.ToDateTime(e.UserState); //obtenemos información adicional si procede

      ////en este ejemplo, logamos a un textbox
      //txtOutput.AppendText(time.ToLongTimeString());
      //txtOutput.AppendText(Environment.NewLine);
    }

    private void backgroundWorkerExist_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      btBuscarArt.Enabled = true;
      btProcesar.Enabled = true;
      pictureBox1.Visible = false;
      pbVentas.Visible = false;
      double Porcentaje;
      TotalExistenciaAlmacen = 0;
      TotalExistenciaTienda = 0;
      long totaldev = 0;
      long totalventa = 0;
      PiezasVendidas = 0;
      if (pedidosSug == null)
        return;

      if (pedidosSug.Count() == 0)
        return;

      foreach (var item in pedidosSug) {
        TotalExistenciaTienda += item.Existencia;
        TotalExistenciaAlmacen += item.ExistenciaAlmacen;
        PiezasVendidas += (item.Venta == null ? 0 : item.Venta.Value);
      }

      textBoxExiDynamics.Text = TotalExistenciaTienda.ToString();
      textBoxPiezasVen.Text = PiezasVendidas.ToString();
      textBoxExiActual.Text = (TotalExistenciaTienda - PiezasVendidas).ToString();
      Porcentaje = (TotalExistenciaTienda - PiezasVendidas) / Convert.ToDouble(EstadoAplicacion.TiendaActual.CapacidadPiezas);
      textBoxPorcentajeST.Text = Porcentaje.ToString("0%");
      dataGridViewExistenciaTienda.ClearSelection();
      dataGridViewExistenciaTienda.DataSource = pedidosSug;

      dataGridViewExistenciaTienda.Columns[6].Visible = new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, "MostrarExistenciaAlmacen");

      dataGridViewVentas.ClearSelection();
      dataGridViewVentas.DataSource = VentasxArticulos;
      foreach (var item in VentasxArticulos) {
        if (item.Ventas.Value > 0) {
          totalventa += item.Ventas.Value;
        }
        else {
          totaldev += item.Ventas.Value;
        }
      }
      txtVendido.Text = totalventa.ToString("0");
      txtDevolucion.Text = Math.Abs(totaldev).ToString("0");
      txtExistencia.Text = TotalExistenciaTienda.ToString("0");
      btnExportarVentas.Enabled = (totalventa != 0 || totaldev != 0);
    }

    private void backgroundWorkerExportPedido_DoWork(object sender, DoWorkEventArgs e)
    {
      //if (Solicitado > 0) {
      string filename = saveFileDialog1.FileName;
      FileInfo fileInfo = new FileInfo(filename);

      if (fileInfo.Exists)
        fileInfo.Delete();

      using (ExcelPackage pck = new ExcelPackage(fileInfo)) {
        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Packing");

        ws.Cells["1:1048576"].Style.Font.SetFromFont(new Font("Calibri", 10, FontStyle.Regular));

        // Etiquetas de las columnas.
        ws.Cells[1, 1].Value = "PACKING";
        ws.Cells["A1:K1"].Merge = true;
        ws.Cells["A1:K1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

        ws.Cells[2, 1].Value = "TIENDA";
        ws.Cells[2, 2].Value = EstadoAplicacion.TiendaActual.Descripcion;
        ws.Cells["B2:F2"].Merge = true;
        ws.Cells["B2:F2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
        ws.Cells["A1:Y6"].Style.Font.Bold = true;

        ws.Cells[2, 15].Value = "FECHA";
        ws.Cells[2, 16].Value = DateTime.Now.Date.ToString();
        ws.Cells[5, 6].Value = "AGOTADOS";
        ws.Cells[5, 9].Value = "ACTIVOS";
        ws.Cells[5, 12].Value = "ROPA";
        ws.Cells[5, 15].Value = "ACCESORIOS";
        ws.Cells[5, 18].Value = "BISUTERIA";
        ws.Cells[5, 22].Value = "PIEZAS";
        int fila = 6;
        ws.Cells[fila, 1].Value = "Referencia";
        ws.Cells[fila, 2].Value = "Online";
        ws.Cells[fila, 3].Value = "Tipo";
        ws.Cells[fila, 4].Value = "Color";

        ws.Cells["A2:F2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        ws.Cells["A2:F2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        ws.Cells["A2:F2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        ws.Cells["A2:F2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        ws.Cells["O2:R2"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        ws.Cells["O2:R2"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        ws.Cells["O2:R2"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        ws.Cells["O2:R2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

        List<EPK_Talla> TallaColeccion = new Talla().ObtenerPorColeccion(IdColeccion);

        int agotados = 0, activos = 0, ropa = 0, acc = 0, bisu = 0, piezas = 0;
        int tc = 5;
        foreach (var item in TallaColeccion) {
          ws.Cells[fila, tc].Value = item.CodigoTalla;
          tc++;
        }
        //           ws.Cells[fila, 5].Value = "1M";

        ws.Cells[fila, tc].Value = "TOTAL";

        List<EPK_sp_MaestroPedidoSugerido_Result> Pedido = new DAL.Reportes().MaestroPedidoSugerido(IdColeccion, MenosDe, PidoPMenosDe, Entre5y, PidoEntre5y);

        foreach (var item in Pedido) {
          if (ws.Cells[fila, 1].Value.ToString() != item.Referencia.ToString()) {
            fila++;
            Solicitado = 0;
          }
          Solicitado += item.Pedir.Value;
          ws.Cells[fila, 1].Value = item.Referencia;
          ws.Cells[fila, 2].Value = item.Descripcion;
          ws.Cells[fila, 3].Value = item.DescripcionGenero;
          ws.Cells[fila, 4].Value = item.CodigoColor;
          for (int t = 5; t <= tc; t++) {
            if (ws.Cells[6, t].Value.ToString().Trim() == item.CodigoTalla.ToString()) {
              if (item.Pedir == 0) { ws.Cells[fila, t].Value = ""; }
              else {
                if (item.TipoPrenda != null) {
                  if (item.TipoPrenda.ToString() == "Bisutería") { bisu = int.Parse(item.Pedir.ToString()); }
                  if (item.TipoPrenda.ToString() == "Accesorio") { acc = acc + int.Parse(item.Pedir.ToString()); }
                  ws.Cells[fila, t].Value = item.Pedir;
                }
              }
              if (item.EnAlmacen > 0) {
                ws.Cells[fila, t].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[fila, t].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                activos++;
              }
              else {
                ws.Cells[fila, t].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws.Cells[fila, t].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                agotados++;
              }
              ropa++;
            }
          }
          ws.Cells[fila, tc].Value = Solicitado;
          piezas += Solicitado;
        }
        ws.Cells[5, 7].Value = agotados;
        ws.Cells[5, 10].Value = activos;
        ws.Cells[5, 13].Value = ropa;
        ws.Cells[5, 16].Value = acc;
        ws.Cells[5, 19].Value = bisu;
        ws.Cells[5, 23].Value = piezas;
        ws.Cells["A4:W" + fila].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        ws.Cells["A4:W" + fila].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        ws.Cells["A4:W" + fila].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        ws.Cells["A4:W" + fila].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

        // Se autoajustan todas las columnas...
        //ws.Cells.AutoFitColumns(0);

        pck.Save();
      }
    }

    private void backgroundWorkerExportPedido_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      pbPedido.Visible = false;
      MessageBox.Show("Packing exportado exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void backgroundWorkerPedido_DoWork(object sender, DoWorkEventArgs e)
    {
      try {
        Pedido = new DAL.Reportes().MaestroPedidoSugerido(IdColeccion, MenosDe, PidoPMenosDe, Entre5y, PidoEntre5y);
        foreach (var item in Pedido) {
          Solicitado += item.Pedir.Value;
        }
      }
      catch (Exception) {
        Cursor.Current = Cursors.Default;
        throw;
      }
    }

    private void backgroundWorkerPedido_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      double Porcentaje;
      dataGridViewPedido.DataSource = Pedido;
      textBoxExistenciaped.Text = (TotalExistenciaTienda - PiezasVendidas + Solicitado).ToString();
      Porcentaje = (TotalExistenciaTienda - PiezasVendidas + Solicitado) / Convert.ToDouble(EstadoAplicacion.TiendaActual.CapacidadPiezas);
      textBoxPorconped.Text = Porcentaje.ToString("0%");
      btnExportar.Enabled = (dataGridViewPedido.RowCount > 0);

      this.ePKspPedidoSugeridoTotalesResultBindingSource.DataSource = new DAL.Reportes().PedidoSugeridoTotales(IdColeccion, MenosDe, PidoPMenosDe, Entre5y, PidoEntre5y);

      pbPedido.Visible = false;
      Cursor.Current = Cursors.Default;
    }

    private void btBuscarArt_Click(object sender, EventArgs e)
    {
      btBuscarArt.Enabled = false;
      IdColeccion = Convert.ToInt32(cbColeccion.SelectedValue);
      FechaDesde = this.dtpDesde.Value.Date;
      FechaHasta = this.dtpHasta.Value.Date;
      btProcesar.Enabled = false;
      pictureBox1.Visible = true;
      pbVentas.Visible = true;

      backgroundWorkerExist.RunWorkerAsync();
    }

    private void btnExportar_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "Packing.xlsx";
      saveFileDialog1.ShowDialog();
    }

    private void btnExportarVentas_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "Ventas.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void btProcesar_Click(object sender, EventArgs e)
    {
      pbPedido.Visible = true;
      pbPedido.BringToFront();
      Cursor.Current = Cursors.WaitCursor;
      MenosDe = Convert.ToInt32(nudMenosDe.Value);
      PidoPMenosDe = Convert.ToInt32(nudPidoMenosDe.Value);
      Entre5y = Convert.ToInt32(nudEntre5y.Value);
      PidoEntre5y = Convert.ToInt32(nudPidoEntre5y.Value);
      IdColeccion = Convert.ToInt32(cbColeccion.SelectedValue);
      Solicitado = 0;

      backgroundWorkerPedido.RunWorkerAsync();
    }

    private void CargarCombos()
    {
      this.cbColeccion.Focus();

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

        if (actual != null)
          this.cbColeccion.SelectedValue = actual.IdColeccion;
      }
    }

    private void dataGridViewExistenciaTienda_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmPedidoSugerido_Activated(object sender, EventArgs e)
    {
      this.Text = "Pedido Sugerido  - " + EstadoAplicacion.UsuarioActual.Identificacion + " - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmPedidoSugerido_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      textBoxCapacidad.Text = EstadoAplicacion.TiendaActual.CapacidadPiezas.ToString();
      btnExportar.Enabled = false;
      btnExportarVentas.Enabled = false;
      btProcesar.Enabled = false;
      dataGridViewExistenciaTienda.Columns[6].Visible = false; //Escondemos la columna y se mostrara segun sea el perfil
    }
    private void ListToExcel<T>(List<T> query)
    {
      using (ExcelPackage pck = new ExcelPackage()) {
        //Create the worksheet
        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Result");

        //get our column headings
        var t = typeof(T);
        var Headings = t.GetProperties();
        for (int i = 0; i < Headings.Count(); i++) {
          ws.Cells[1, i + 1].Value = Headings[i].Name;
        }

        //populate our Data
        if (query.Count() > 0) {
          ws.Cells["A2"].LoadFromCollection(query);
        }

        //Format the header
        using (ExcelRange rng = ws.Cells["A1:BZ1"]) {
          rng.Style.Font.Bold = true;

          rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
          rng.Style.Font.Color.SetColor(Color.White);
        }
      }
    }

    private void nudEntre5y_ValueChanged(object sender, EventArgs e)
    {
      if (nudEntre5y.Value <= nudMenosDe.Value) {
        nudEntre5y.Value = nudMenosDe.Value + 1;
      }
    }

    private void nudMenosDe_ValueChanged(object sender, EventArgs e)
    {
      lblRango.Text = "Entre " + nudMenosDe.Value.ToString() + " y ";
      if (nudEntre5y.Value <= nudMenosDe.Value) {
        nudEntre5y.Value = nudMenosDe.Value + 1;
      }
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveFileDialog1_FileOk_1(object sender, CancelEventArgs e)
    {
      switch (tabControl1.SelectedTab.Text) {
        case "Ventas":

          IdColeccion = Convert.ToInt32(cbColeccion.SelectedValue);
          VentasxArticulos = new DAL.Reportes().ReporteVentasxArticulos(IdColeccion, FechaDesde, FechaHasta);

          if (VentasxArticulos.Count() == 0)
            return;

          var exceldata = (from r in VentasxArticulos
                           select new {
                             Fecha = r.Fecha.ToString(),
                             IdFactura = r.IdFactura.ToString(),
                             CodigoArticulo = r.CodArticulo.ToString(),
                             Ventas = r.Ventas.ToString()
                           }).ToList();

          if (new ExportExcel().DumpExcel(exceldata, ((SaveFileDialog)sender).FileName))
            MessageBox.Show("Ventas exportadas exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
          else
            MessageBox.Show("Error al escribir el archivo", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
          break;

        case "Pedido":
          backgroundWorkerExportPedido.RunWorkerAsync();
          pbPedido.Visible = true;
          //}
          //else {
          //  MessageBox.Show("Debe procesar el pedido primero", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
          //}
          break;
      }
    }

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (((TabControl)sender).SelectedIndex) {
        case 0:
          this.btnExportarVentas.Enabled = (dataGridViewVentas.RowCount > 0);
          break;

        case 2:
          this.btnExportar.Enabled = (dataGridViewPedido.RowCount > 0);
          break;

        default:
          this.btnExportar.Enabled = false;
          break;
      }
    }

    private void textBoxMenosde_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back)) {
        e.Handled = true;
      }
    }
  }
}