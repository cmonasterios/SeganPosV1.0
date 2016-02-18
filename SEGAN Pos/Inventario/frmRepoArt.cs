using OfficeOpenXml;
using OfficeOpenXml.Style;
using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmRepoArt : Form
  {
    #region Constructor

    public frmRepoArt()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      DateTime fDesde, fHasta;

      fDesde = this.dtFeDesde.Value.Date;
      fHasta = this.dtFeHasta.Value.Date;

      fDesde += new TimeSpan(this.dtHoDesde.Value.TimeOfDay.Hours, this.dtHoDesde.Value.TimeOfDay.Minutes, 00);
      fHasta += new TimeSpan(this.dtHoHasta.Value.TimeOfDay.Hours, this.dtHoHasta.Value.TimeOfDay.Minutes, 00);

      int tempInt;

      int? idColeccion = null;
      if (this.cbColeccion.SelectedIndex > -1) {
        int.TryParse(this.cbColeccion.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idColeccion = tempInt;
      }

      int? idGrupo = null;
      if (this.cbGrupo.SelectedIndex > -1) {
        int.TryParse(this.cbGrupo.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idGrupo = tempInt;
      }

      int? idGenero = null;
      if (this.cbGenero.SelectedIndex > -1) {
        int.TryParse(this.cbGenero.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idGenero = tempInt;
      }

      int? idTema = null;
      if (this.cbTema.SelectedIndex > -1) {
        int.TryParse(this.cbTema.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idTema = tempInt;
      }

      int? cantidad = null;
      if (this.udCantidad.Value > 0)
        cantidad = (int)this.udCantidad.Value;

      List<ItemRepoArticulos> results = new DAL.Reportes().ReposicionArticulos(fDesde, fHasta, idColeccion, idGrupo, idGenero,
                                                                               idTema, this.txReferencia.Text.Trim(), cantidad);

      this.dgResults.DataSource = results;
      this.dgResults.Refresh();

      this.lbCantReg.Text = string.Format(Properties.Resources.RegEncontrados, results.Count);
      this.lbCantReg.Visible = true;

      this.btExport.Enabled = (results.Count > 0);
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btExport_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "ReposicionArticulos.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void dgResults_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgResults_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dtFeDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtFeHasta.Value < ((DateTimePicker)sender).Value)
        this.dtFeHasta.Value = ((DateTimePicker)sender).Value;

      this.dtFeHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void dtHoDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtHoHasta.Value < ((DateTimePicker)sender).Value)
        this.dtHoHasta.Value = ((DateTimePicker)sender).Value;

      this.dtHoHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void frmRepoArt_Activated(object sender, EventArgs e)
    {
      this.Text = "Reposición de Artículos - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmRepoArt_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtFeDesde.Format = DateTimePickerFormat.Custom;
      this.dtFeDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtFeHasta.Format = DateTimePickerFormat.Custom;
      this.dtFeHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.CargarCombos();
      this.Limpiar();

      if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btExport.Tag.ToString()))
        this.btExport.Visible = false;
    }

    private void frmRepoArt_Shown(object sender, EventArgs e)
    {
      this.dtFeDesde.Focus();
    }

    private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      try {
        DateTime fDesde, fHasta;

        fDesde = this.dtFeDesde.Value.Date;
        fHasta = this.dtFeHasta.Value.Date;

        fDesde += new TimeSpan(this.dtHoDesde.Value.TimeOfDay.Hours, this.dtHoDesde.Value.TimeOfDay.Minutes, 00);
        fHasta += new TimeSpan(this.dtHoHasta.Value.TimeOfDay.Hours, this.dtHoHasta.Value.TimeOfDay.Minutes, 00);

        int tempInt;

        int? idColeccion = null;
        if (this.cbColeccion.SelectedIndex > -1) {
          int.TryParse(this.cbColeccion.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idColeccion = tempInt;
        }

        int? idGrupo = null;
        if (this.cbGrupo.SelectedIndex > -1) {
          int.TryParse(this.cbGrupo.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idGrupo = tempInt;
        }

        int? idGenero = null;
        if (this.cbGenero.SelectedIndex > -1) {
          int.TryParse(this.cbGenero.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idGenero = tempInt;
        }

        int? idTema = null;
        if (this.cbTema.SelectedIndex > -1) {
          int.TryParse(this.cbTema.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idTema = tempInt;
        }

        int? cantidad = null;
        if (this.udCantidad.Value > 0)
          cantidad = (int)this.udCantidad.Value;

        List<ItemRepoArticulos> results = new DAL.Reportes().ReposicionArticulos(fDesde, fHasta, idColeccion, idGrupo, idGenero,
                                                                                 idTema, this.txReferencia.Text.Trim(), cantidad);

        if (results.Count == 0)
          return;

        string filename = saveFileDialog1.FileName;
        FileInfo fileInfo = new FileInfo(filename);

        if (fileInfo.Exists)
          fileInfo.Delete();

        using (ExcelPackage pck = new ExcelPackage(fileInfo)) {
          ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reposición de Artículos");

          ws.Cells["A1:J5"].Style.Font.SetFromFont(new Font("Calibri", 11, FontStyle.Bold));
          ws.Cells["A1:J5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

          ws.Cells["A2:J2"].Merge = true;
          ws.Cells["A2:A2"].Value = "Reposición de Artículos";

          ws.Cells["A3:J3"].Merge = true;
          ws.Cells["A3:A3"].Value = "Desde " + fDesde.ToShortDateString() + " " + fDesde.ToShortTimeString() + " hasta " + fHasta.ToShortDateString() + " " + fHasta.ToShortTimeString();

          ws.Cells["A5:A5"].Value = "Colección";
          ws.Cells["B5:B5"].Value = "Tema";
          ws.Cells["C5:C5"].Value = "Género";
          ws.Cells["D5:D5"].Value = "Grupo";
          ws.Cells["E5:E5"].Value = "Referencia";
          ws.Cells["F5:F5"].Value = "Código Artículo";
          ws.Cells["G5:G5"].Value = "Ventas";
          ws.Cells["H5:H5"].Value = "Devolución";
          ws.Cells["I5:I5"].Value = "Total";
          ws.Cells["J5:J5"].Value = "Precio";

          ws.Cells["A5:J5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
          ws.Cells["A5:J5"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

          int fila = 6;
          foreach (ItemRepoArticulos item in results) {
            ws.Cells[fila, 1].Value = item.CodColec;
            ws.Cells[fila, 2].Value = item.DescTema;
            ws.Cells[fila, 3].Value = item.DescGene;
            ws.Cells[fila, 4].Value = item.CodGrupo;
            ws.Cells[fila, 5].Value = item.CodRef;
            ws.Cells[fila, 6].Value = item.CodArt;
            ws.Cells[fila, 7].Value = item.Ventas.ToString("N0");
            ws.Cells[fila, 8].Value = item.Devolucion.ToString("N0");
            ws.Cells[fila, 9].Value = item.Total.ToString("N0");
            ws.Cells[fila, 10].Value = item.Precio.ToString("C2");

            ws.Cells["A" + fila.ToString() + ":J" + fila.ToString()].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["A" + fila.ToString() + ":J" + fila.ToString()].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["A" + fila.ToString() + ":J" + fila.ToString()].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells["A" + fila.ToString() + ":J" + fila.ToString()].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            ws.Cells["D" + fila.ToString() + ":E" + fila.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            ws.Cells["F" + fila.ToString() + ":G" + fila.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            ws.Cells["H" + fila.ToString() + ":I" + fila.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
            ws.Cells["I" + fila.ToString() + ":J" + fila.ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            fila++;
          }

          fila--;

          // Se autoajustan todas las columnas
          ws.Cells.AutoFitColumns(0);

          ws.Cells["A5:J5" + fila.ToString()].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);

          ws.Cells["A" + (fila + 2).ToString() + ":J" + (fila + 6).ToString()].Style.Font.SetFromFont(new Font("Calibri", 11, FontStyle.Bold));
          ws.Cells["A" + (fila + 2).ToString() + ":J" + (fila + 6).ToString()].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

          ws.Cells["A" + (fila + 2).ToString() + ":J" + (fila + 2).ToString()].Merge = true;
          ws.Cells["A" + (fila + 2).ToString() + ":A" + (fila + 2).ToString()].Value = "Total Piezas Vendidas: " + results.Sum(r => r.Total).ToString("N0");

          ws.Cells["A" + (fila + 3).ToString() + ":J" + (fila + 3).ToString()].Merge = true;
          ws.Cells["A" + (fila + 3).ToString() + ":A" + (fila + 3).ToString()].Value = "Total Piezas en Devolución: " + results.Sum(r => r.Devolucion).ToString("N0");

          ws.Cells["A" + (fila + 4).ToString() + ":J" + (fila + 4).ToString()].Merge = true;
          ws.Cells["A" + (fila + 4).ToString() + ":A" + (fila + 4).ToString()].Value = "Total de Piezas: " + results.Sum(r => r.Ventas).ToString("N0");

          ws.Cells["A" + (fila + 5).ToString() + ":J" + (fila + 5).ToString()].Merge = true;
          ws.Cells["A" + (fila + 5).ToString() + ":A" + (fila + 5).ToString()].Value = "Elaborado por: " + EstadoAplicacion.UsuarioActual.Identificacion.Trim();

          ws.Cells["A" + (fila + 6).ToString() + ":J" + (fila + 6).ToString()].Merge = true;
          ws.Cells["A" + (fila + 6).ToString() + ":A" + (fila + 6).ToString()].Value = "Fecha / Hora: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

          ws.PrinterSettings.HorizontalCentered = true;
          ws.PrinterSettings.Orientation = eOrientation.Landscape;
          ws.PrinterSettings.FitToHeight = 0;
          ws.PrinterSettings.FitToWidth = 0;

          pck.Save();
        }

        MessageBox.Show(Properties.Resources.ExitoExpoRepoArt, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion Events

    #region Private Methods

    private void CargarCombos()
    {
      IEnumerable<EPK_Coleccion> colecciones = new Colecciones().ObtenerActivas();

      this.cbColeccion.DataSource = colecciones;
      this.cbColeccion.ValueMember = "IdColeccion";
      this.cbColeccion.DisplayMember = "Descripcion";

      IEnumerable<EPK_Genero> generos = new Generos().ObtenerTodos();

      this.cbGenero.DataSource = generos;
      this.cbGenero.ValueMember = "IdGenero";
      this.cbGenero.DisplayMember = "Descripcion";

      IEnumerable<EPK_Grupo> grupos = new Grupos().ObtenerTodos();

      this.cbGrupo.DataSource = grupos;
      this.cbGrupo.ValueMember = "IdGrupo";
      this.cbGrupo.DisplayMember = "Descripcion";

      IEnumerable<EPK_Tema> temas = new Temas().ObtenerTodos();

      this.cbTema.DataSource = temas;
      this.cbTema.ValueMember = "IdTema";
      this.cbTema.DisplayMember = "Descripcion";
    }

    private void Limpiar()
    {
      this.txReferencia.Text = string.Empty;

      this.dtFeHasta.MinDate = DateTime.Today;
      this.dtFeHasta.MaxDate = DateTime.Today;
      this.dtFeDesde.MaxDate = DateTime.Today;

      this.dtFeDesde.Value = DateTime.Today;
      this.dtFeHasta.Value = DateTime.Today;

      this.dtHoHasta.MinDate = DateTime.Today.Date;
      this.dtHoHasta.MaxDate = DateTime.Today.Date.AddDays(1).AddSeconds(-1);
      this.dtHoDesde.MaxDate = DateTime.Today.Date.AddDays(1).AddSeconds(-1);

      this.dtHoDesde.Value = DateTime.Today.Date;
      this.dtHoHasta.Value = DateTime.Today.Date.AddDays(1).AddSeconds(-1);

      this.cbColeccion.SelectedIndex = this.cbGenero.SelectedIndex = this.cbGrupo.SelectedIndex =
        this.cbTema.SelectedIndex = -1;

      this.udCantidad.Value = 0;

      List<ItemRepoArticulos> tempList = new List<ItemRepoArticulos>();

      this.dgResults.DataSource = tempList;
      this.dgResults.Refresh();

      this.lbCantReg.Visible = false;

      this.dtFeDesde.Focus();
    }

    #endregion Private Methods

  }
}