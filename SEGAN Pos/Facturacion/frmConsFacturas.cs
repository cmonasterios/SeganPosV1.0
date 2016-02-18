using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmConsFacturas : Form
  {
    #region Constructor

    public frmConsFacturas()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      this.LimpiarGrid();

      int tempInt;

      int? Numero = null;
      if (int.TryParse(this.txNFact.Text, out tempInt))
        Numero = tempInt;

      int? idEstatus = null;
      if (this.cbEstatusFac.SelectedIndex > -1) {
        int.TryParse(this.cbEstatusFac.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idEstatus = tempInt;
      }

      decimal tempDec;

      decimal? montoDesde = null;
      if (decimal.TryParse(this.txMontoDesde.Text, out tempDec))
        montoDesde = tempDec;

      decimal? montoHasta = null;
      if (decimal.TryParse(this.txMontoHasta.Text, out tempDec))
        montoHasta = tempDec;

      int? idCaja = null;
      if (this.cbCaja.SelectedIndex > -1) {
        int.TryParse(this.cbCaja.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idCaja = tempInt;
      }

      this.txCajero.Text = this.txCajero.Text.Trim();

      bool? dev = null;
      if (this.chDev.CheckState != CheckState.Indeterminate)
        dev = this.chDev.CheckState == CheckState.Checked ? true : false;

      bool? desc = null;
      if (this.chDesc.CheckState != CheckState.Indeterminate)
        desc = this.chDesc.CheckState == CheckState.Checked ? true : false;

      SortableBindingList<ListadoFacturas> resultFacturas = new SortableBindingList<ListadoFacturas>(
        new Facturas().Consultar(Numero, this.dtpDesde.Value.Date, this.dtpHasta.Value.Date, this.txDocCliente.Text,
          this.txSerialMF.Text, montoDesde, montoHasta, idEstatus, idCaja, this.txCajero.Text, dev, desc)
        );

      this.dgFacturas.DataSource = resultFacturas;
      this.dgFacturas.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", resultFacturas.Count());
      this.lbCantReg.Visible = true;

      this.btExport.Enabled = (resultFacturas.Count() > 0);
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btExport_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "Facturas.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
    }

    private void btSolNCredito_Click(object sender, EventArgs e)
    {
      if (this.dgFacturas.SelectedRows.Count == 0)
        return;

      ListadoFacturas itemSel = (this.dgFacturas.SelectedRows[0].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      if (itemSel.idEstatus != EstadoAplicacion.EstadosFactura["FACProcesada"] || itemSel.TieneNC == (int)TipoNC.Total)
        return;

      if (new frmNCredito(itemSel.IdFactura.Value).ShowDialog() == System.Windows.Forms.DialogResult.OK)
        this.btBuscar_Click(this, EventArgs.Empty);
    }

    private void btVer_Click(object sender, EventArgs e)
    {
      if (this.dgFacturas.SelectedRows.Count == 0)
        return;

      ListadoFacturas itemSel = (this.dgFacturas.SelectedRows[0].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      frmVerFactura fVer = new frmVerFactura();

      fVer.idFactura = itemSel.IdFactura;
      fVer.idFacturaEspera = itemSel.IdFacturaEspera;

      if (fVer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        this.btBuscar_Click(this, EventArgs.Empty);
    }

    private void dgFacturas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      ListadoFacturas itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      frmVerFactura fVer = new frmVerFactura();

      fVer.idFactura = itemSel.IdFactura;
      fVer.idFacturaEspera = itemSel.IdFacturaEspera;

      if (fVer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        this.btBuscar_Click(this, EventArgs.Empty);
    }

    private void dgFacturas_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dgFacturas_SelectionChanged(object sender, EventArgs e)
    {
      this.btSolNCredito.Enabled = this.btVer.Enabled = false;

      if (((DataGridView)sender).SelectedRows.Count == 0)
        return;

      ListadoFacturas itemSel = (((DataGridView)sender).SelectedRows[0].DataBoundItem as ListadoFacturas);

      if (itemSel == null)
        return;

      if (itemSel.idEstatus == EstadoAplicacion.EstadosFactura["FACProcesada"] &&
          itemSel.TieneNC != (int)TipoNC.Total && itemSel.MontoTotal > 0)
        this.btSolNCredito.Enabled = true;

      this.btVer.Enabled = true;
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
        this.dtpHasta.Value = ((DateTimePicker)sender).Value;

      this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void frmConsFacturas_Activated(object sender, EventArgs e)
    {
      this.Text = "Consulta de Facturas - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmConsFacturas_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.CargarCombos();
      this.Limpiar();

      if (!new Accesos().VerificarAccesoAccion(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name, this.btExport.Tag.ToString()))
        this.btExport.Visible = false;

      if (!new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.btSolNCredito.Tag.ToString()))
        this.btSolNCredito.Visible = false;

      if (!this.btExport.Visible)
        this.btSolNCredito.Location = new Point(this.btExport.Left - (this.btSolNCredito.Width - this.btExport.Width), this.btSolNCredito.Top);
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      try {
        int tempInt;

        int? Numero = null;
        if (int.TryParse(this.txNFact.Text, out tempInt))
          Numero = tempInt;

        int? idEstatus = null;
        if (this.cbEstatusFac.SelectedIndex > -1) {
          int.TryParse(this.cbEstatusFac.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idEstatus = tempInt;
        }

        decimal tempDec;

        decimal? montoDesde = null;
        if (decimal.TryParse(this.txMontoDesde.Text, out tempDec))
          montoDesde = tempDec;

        decimal? montoHasta = null;
        if (decimal.TryParse(this.txMontoHasta.Text, out tempDec))
          montoHasta = tempDec;

        int? idCaja = null;
        if (this.cbCaja.SelectedIndex > -1) {
          int.TryParse(this.cbCaja.SelectedValue.ToString(), out tempInt);
          if (tempInt > 0)
            idCaja = tempInt;
        }

        this.txCajero.Text = this.txCajero.Text.Trim();

        bool? dev = null;
        if (this.chDev.CheckState != CheckState.Indeterminate)
          dev = this.chDev.CheckState == CheckState.Checked ? true : false;

        bool? desc = null;
        if (this.chDesc.CheckState != CheckState.Indeterminate)
          dev = this.chDesc.CheckState == CheckState.Checked ? true : false;

        List<ListadoFacturas> resultFacturas = new Facturas().Consultar(Numero, this.dtpDesde.Value.Date,
          this.dtpHasta.Value.Date, this.txDocCliente.Text, this.txSerialMF.Text, montoDesde, montoHasta, idEstatus,
          idCaja, this.txCajero.Text, dev, desc);

        if (resultFacturas.Count() == 0)
          return;

        string filename = saveFileDialog1.FileName;
        FileInfo fileInfo = new FileInfo(filename);

        if (fileInfo.Exists)
          fileInfo.Delete();

        using (ExcelPackage pck = new ExcelPackage(fileInfo)) {
          ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Facturas");

          ws.Cells["A2:H2"].Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Regular));
          ExcelPicture pic = ws.Drawings.AddPicture("Facturas", Properties.Resources.logoEPKpeq);

          // Etiquetas de las columnas.
          ws.Cells[2, 1].Value = "Reporte Facturas";
          ws.Cells["A2:H2"].Merge = true;
          ws.Cells["A2:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

          ws.Cells["A3:H4"].Style.Font.SetFromFont(new Font("Calibri", 12, FontStyle.Regular));

          ws.Cells[3, 1].Value = "Tienda: " + EstadoAplicacion.TiendaActual.Descripcion;
          ws.Cells["A3:H3"].Merge = true;

          ws.Cells["A3:H3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

          ws.Cells[4, 1].Value = "Desde " + this.dtpDesde.Value.ToShortDateString() + " al " + this.dtpHasta.Value.ToShortDateString();
          ws.Cells["A4:H4"].Merge = true;
          ws.Cells["A1:H4"].Style.Font.Bold = true;
          ws.Cells["A4:H4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;

          ws.Cells["A8:H9"].Style.Font.SetFromFont(new Font("Calibri", 8, FontStyle.Regular));

          ws.Cells[8, 1].Value = "Fecha Emisión:";
          ws.Cells[8, 2].Value = DateTime.Today.ToShortDateString();
          ws.Cells[9, 1].Value = "Usuario";
          ws.Cells[9, 2].Value = EstadoAplicacion.UsuarioActual.Identificacion;

          ws.Cells["12:1048576"].Style.Font.SetFromFont(new Font("Calibri", 10, FontStyle.Regular));

          ws.Cells[12, 1].Value = "Fecha";
          ws.Cells[12, 2].Value = "Hora";
          ws.Cells[12, 3].Value = "N° Factura";
          ws.Cells[12, 4].Value = "Nombre Cliente";
          ws.Cells[12, 5].Value = "Documento";
          ws.Cells[12, 6].Value = "Maquina Fiscal";
          ws.Cells[12, 7].Value = "Total";
          ws.Cells[12, 8].Value = "Estatus";
          //ws.Cells[12, 9].Value = "Cajero";
          //ws.Cells[12, 10].Value = "Vendedor";
          ws.Cells["A12:H12"].Style.Font.Bold = true;

          int fila = 13;
          foreach (var item in resultFacturas) {
            ws.Cells[fila, 1].Value = item.FechaCreacion.ToString("d");
            ws.Cells[fila, 2].Value = item.FechaCreacion.ToString("t");
            ws.Cells[fila, 3].Value = item.Numero.ToString();
            ws.Cells[fila, 4].Value = item.NombreCliente;
            ws.Cells[fila, 5].Value = item.DocCliente;
            ws.Cells[fila, 6].Value = item.SerialMF;
            ws.Cells[fila, 7].Value = item.MontoTotal.ToString("C2");
            ws.Cells[fila, 8].Value = item.Estatus;
            //ws.Cells[fila, 9].Value = item.Cajero.Nombre +" "+ item.Cajero.Apellido;
            //ws.Cells[fila, 10].Value = item.Cajero;
              
            ws.Cells["A12:H" + fila].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells["A12:H" + fila].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells["A12:H" + fila].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            ws.Cells["A12:H" + fila].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            fila++;
          }

          // Se autoajustan todas las columnas.
          ws.Cells.AutoFitColumns(0);

          ws.PrinterSettings.HorizontalCentered = true;
          ws.PrinterSettings.Orientation = eOrientation.Landscape;
          ws.PrinterSettings.FitToHeight = 0;
          ws.PrinterSettings.FitToWidth = 0;

          pck.Save();
        }

        MessageBox.Show(Properties.Resources.ExitoExpoFacturas, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    private void txMontoDesde_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9,]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txMontoHasta_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9,]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txtNFact_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), "^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }
    #endregion Events

    #region Private Methods

    private void CargarCombos()
    {
      List<EPK_Estatus> listadoEstatus = new Estatus().ObtenerTodos();
      if (listadoEstatus != null && listadoEstatus.Count() > 0) {
        List<EPK_Estatus> listaEstadosFactura = new List<EPK_Estatus>();

        foreach (KeyValuePair<string, short> item in EstadoAplicacion.EstadosFactura) {
          EPK_Estatus itemEstatus = listadoEstatus.FirstOrDefault(le => le.IdEstatus == item.Value);
          if (itemEstatus != null)
            listaEstadosFactura.Add(itemEstatus);
        }

        if (listaEstadosFactura.Count() == 0)
          return;

        this.cbEstatusFac.DataSource = listaEstadosFactura;
        this.cbEstatusFac.ValueMember = "IdEstatus";
        this.cbEstatusFac.DisplayMember = "Descripcion";
      }

      List<EPK_Caja> listadoCajas = new Cajas().ObtenerTodas();
      if (listadoCajas != null && listadoCajas.Count() > 0) {
        this.cbCaja.DataSource = listadoCajas;
        this.cbCaja.ValueMember = "IdCaja";
        this.cbCaja.DisplayMember = "Descripcion";
      }
    }

    private void Limpiar()
    {
      this.txNFact.Text = this.txDocCliente.Text = this.txSerialMF.Text = this.txMontoDesde.Text =
        this.txMontoHasta.Text = this.txCajero.Text = string.Empty;

      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      this.cbEstatusFac.SelectedIndex = this.cbCaja.SelectedIndex = -1;

      this.chDev.CheckState = this.chDesc.CheckState = CheckState.Indeterminate;

      this.LimpiarGrid();

      this.txNFact.Focus();
    }

    private void LimpiarGrid()
    {
      List<ListadoFacturas> tempList = new List<ListadoFacturas>();

      this.dgFacturas.DataSource = tempList;
      this.dgFacturas.Refresh();

      this.lbCantReg.Visible = false;
      this.btExport.Enabled = this.btSolNCredito.Enabled = this.btVer.Enabled = false;
    }

    #endregion Private Methods
  }
}