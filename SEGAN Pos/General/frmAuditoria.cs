using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SEGAN_POS
{
  public partial class frmAuditoria : Form
  {
    #region Constructor

    public frmAuditoria()
    {
      InitializeComponent();
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      string Tipo = string.Empty;
      if (this.cbTipoEvento.SelectedIndex > -1) {
        Tipo = cbTipoEvento.SelectedItem.ToString();
      }

      List<ItemAuditoria> resultAuditoria = new DAL.Auditoria().Consultar(Tipo, txtUsuario.Text, this.dtpDesde.Value.Date,
        this.dtpHasta.Value.Date);

      this.dgAuditoria.DataSource = resultAuditoria;
      this.dgAuditoria.Refresh();

      this.lbCantReg.Text = string.Format("{0} registros encontrados.", resultAuditoria.Count());
      this.lbCantReg.Visible = true;

      this.btExport.Enabled = (resultAuditoria.Count() > 0);
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btExport_Click(object sender, EventArgs e)
    {
      this.saveFileDialog1.FileName = "Auditoria.xlsx";
      this.saveFileDialog1.ShowDialog();
    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
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

      fVer.ShowDialog();
    }

    private void dgFacturas_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
        this.dtpHasta.Value = ((DateTimePicker)sender).Value;

      this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void frmAuditoria_Activated(object sender, EventArgs e)
    {
      this.Text = "Auditoria - " + Application.ProductName;

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

      this.Limpiar();
    }

    private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
    {
      string Tipo = string.Empty;
      if (this.cbTipoEvento.SelectedIndex > -1) {
        Tipo = cbTipoEvento.SelectedItem.ToString();
      }
      List<ItemAuditoria> resultAuditoria = new DAL.Auditoria().Consultar(Tipo, txtUsuario.Text, this.dtpDesde.Value.Date,
        this.dtpHasta.Value.Date);

      if (resultAuditoria.Count() == 0)
        return;

      var exceldata = (from r in resultAuditoria
                       select new {
                         Fecha = r.Fecha.ToString("d"),
                         Accion = r.Accion.ToString(),
                         TipoEvento = r.TipoEvento,
                         Usuario = r.Usuario,
                         Login = r.Login,
                         IP = r.IP,
                         Host = r.Host
                       }).ToList();

      if (new ExportExcel().DumpExcel(exceldata, ((SaveFileDialog)sender).FileName))
        MessageBox.Show("Auditorias exportadas exitosamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show("Error al escribir el archivo", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private void Limpiar()
    {
      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      List<ItemAuditoria> tempList = new List<ItemAuditoria>();

      this.dgAuditoria.DataSource = tempList;
      this.dgAuditoria.Refresh();
      this.txtUsuario.Text = string.Empty;
      this.cbTipoEvento.SelectedIndex = -1;

      this.lbCantReg.Visible = false;
      this.btExport.Enabled = false;
    }

    #endregion Private Methods
  }
}