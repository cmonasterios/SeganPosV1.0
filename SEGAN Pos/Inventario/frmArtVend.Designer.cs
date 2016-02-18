namespace SEGAN_POS
{
  partial class frmArtVend
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lbDesde = new System.Windows.Forms.Label();
            this.cbColeccion = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDevolucion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVendido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btExport = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.dataGridViewVentas = new System.Windows.Forms.DataGridView();
            this.codReferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fotoPeqDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Act = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ePKspReporteVentasxArticulosResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbVentas = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerExist = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteVentasxArticulosResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.lbDesde);
            this.panel1.Controls.Add(this.cbColeccion);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbHasta);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 100);
            this.panel1.TabIndex = 9;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(768, 63);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.CausesValidation = false;
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.Location = new System.Drawing.Point(768, 9);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(375, 36);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(71, 13);
            this.lbDesde.TabIndex = 68;
            this.lbDesde.Text = "Fecha Desde";
            this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbColeccion
            // 
            this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColeccion.FormattingEnabled = true;
            this.cbColeccion.Location = new System.Drawing.Point(78, 33);
            this.cbColeccion.Name = "cbColeccion";
            this.cbColeccion.Size = new System.Drawing.Size(272, 21);
            this.cbColeccion.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CausesValidation = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(450, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(105, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Colección";
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(568, 36);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(68, 13);
            this.lbHasta.TabIndex = 69;
            this.lbHasta.Text = "Fecha Hasta";
            this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CausesValidation = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(639, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDevolucion);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtVendido);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btExport);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 39);
            this.panel2.TabIndex = 10;
            // 
            // txtDevolucion
            // 
            this.txtDevolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDevolucion.Location = new System.Drawing.Point(131, 11);
            this.txtDevolucion.Name = "txtDevolucion";
            this.txtDevolucion.ReadOnly = true;
            this.txtDevolucion.Size = new System.Drawing.Size(124, 20);
            this.txtDevolucion.TabIndex = 85;
            this.txtDevolucion.TabStop = false;
            this.txtDevolucion.Text = "0";
            this.txtDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 86;
            this.label14.Text = "Total Devoluciones";
            // 
            // txtVendido
            // 
            this.txtVendido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVendido.Location = new System.Drawing.Point(364, 11);
            this.txtVendido.Name = "txtVendido";
            this.txtVendido.ReadOnly = true;
            this.txtVendido.Size = new System.Drawing.Size(124, 20);
            this.txtVendido.TabIndex = 83;
            this.txtVendido.TabStop = false;
            this.txtVendido.Text = "0";
            this.txtVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Piezas Vendidas";
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.CausesValidation = false;
            this.btExport.Enabled = false;
            this.btExport.Image = global::SEGAN_POS.Properties.Resources.excel;
            this.btExport.Location = new System.Drawing.Point(821, 4);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(83, 32);
            this.btExport.TabIndex = 5;
            this.btExport.Tag = "Exportar";
            this.btExport.Text = "Exportar";
            this.btExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.CausesValidation = false;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancelar.Location = new System.Drawing.Point(910, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(70, 32);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cerrar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // dataGridViewVentas
            // 
            this.dataGridViewVentas.AllowUserToAddRows = false;
            this.dataGridViewVentas.AllowUserToDeleteRows = false;
            this.dataGridViewVentas.AllowUserToResizeRows = false;
            this.dataGridViewVentas.AutoGenerateColumns = false;
            this.dataGridViewVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codReferenciaDataGridViewTextBoxColumn,
            this.CodArticulo,
            this.descripDataGridViewTextBoxColumn,
            this.fotoPeqDataGridViewImageColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.IdFactura,
            this.ventasDataGridViewTextBoxColumn,
            this.Act});
            this.dataGridViewVentas.DataSource = this.ePKspReporteVentasxArticulosResultBindingSource;
            this.dataGridViewVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewVentas.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewVentas.Name = "dataGridViewVentas";
            this.dataGridViewVentas.ReadOnly = true;
            this.dataGridViewVentas.RowHeadersVisible = false;
            this.dataGridViewVentas.RowHeadersWidth = 80;
            this.dataGridViewVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewVentas.RowTemplate.Height = 80;
            this.dataGridViewVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVentas.Size = new System.Drawing.Size(983, 363);
            this.dataGridViewVentas.TabIndex = 5;
            this.dataGridViewVentas.TabStop = false;
            this.dataGridViewVentas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewVentas_CellBeginEdit);
            this.dataGridViewVentas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewVentas_DataError);
            // 
            // codReferenciaDataGridViewTextBoxColumn
            // 
            this.codReferenciaDataGridViewTextBoxColumn.DataPropertyName = "CodReferencia";
            this.codReferenciaDataGridViewTextBoxColumn.HeaderText = "Referencia";
            this.codReferenciaDataGridViewTextBoxColumn.Name = "codReferenciaDataGridViewTextBoxColumn";
            this.codReferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codReferenciaDataGridViewTextBoxColumn.Width = 103;
            // 
            // CodArticulo
            // 
            this.CodArticulo.DataPropertyName = "CodArticulo";
            this.CodArticulo.HeaderText = "Código Artículo";
            this.CodArticulo.Name = "CodArticulo";
            this.CodArticulo.ReadOnly = true;
            this.CodArticulo.Width = 112;
            // 
            // descripDataGridViewTextBoxColumn
            // 
            this.descripDataGridViewTextBoxColumn.DataPropertyName = "Descrip";
            this.descripDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripDataGridViewTextBoxColumn.Name = "descripDataGridViewTextBoxColumn";
            this.descripDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripDataGridViewTextBoxColumn.Width = 349;
            // 
            // fotoPeqDataGridViewImageColumn
            // 
            this.fotoPeqDataGridViewImageColumn.DataPropertyName = "FotoPeq";
            this.fotoPeqDataGridViewImageColumn.HeaderText = "Foto";
            this.fotoPeqDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.fotoPeqDataGridViewImageColumn.Name = "fotoPeqDataGridViewImageColumn";
            this.fotoPeqDataGridViewImageColumn.ReadOnly = true;
            this.fotoPeqDataGridViewImageColumn.Width = 80;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IdFactura
            // 
            this.IdFactura.DataPropertyName = "IdFactura";
            this.IdFactura.HeaderText = "N° Factura";
            this.IdFactura.Name = "IdFactura";
            this.IdFactura.ReadOnly = true;
            this.IdFactura.Width = 97;
            // 
            // ventasDataGridViewTextBoxColumn
            // 
            this.ventasDataGridViewTextBoxColumn.DataPropertyName = "Ventas";
            this.ventasDataGridViewTextBoxColumn.HeaderText = "Ventas";
            this.ventasDataGridViewTextBoxColumn.Name = "ventasDataGridViewTextBoxColumn";
            this.ventasDataGridViewTextBoxColumn.ReadOnly = true;
            this.ventasDataGridViewTextBoxColumn.Width = 79;
            // 
            // Act
            // 
            this.Act.DataPropertyName = "Act";
            this.Act.HeaderText = "Activo";
            this.Act.Name = "Act";
            this.Act.ReadOnly = true;
            this.Act.Width = 43;
            // 
            // ePKspReporteVentasxArticulosResultBindingSource
            // 
            this.ePKspReporteVentasxArticulosResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVentasxArticulos_Result);
            // 
            // pbVentas
            // 
            this.pbVentas.Image = global::SEGAN_POS.Properties.Resources.progreso;
            this.pbVentas.Location = new System.Drawing.Point(454, 235);
            this.pbVentas.Name = "pbVentas";
            this.pbVentas.Size = new System.Drawing.Size(72, 70);
            this.pbVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVentas.TabIndex = 71;
            this.pbVentas.TabStop = false;
            this.pbVentas.Visible = false;
            this.pbVentas.WaitOnLoad = true;
            // 
            // backgroundWorkerExist
            // 
            this.backgroundWorkerExist.WorkerReportsProgress = true;
            this.backgroundWorkerExist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExist_DoWork);
            this.backgroundWorkerExist.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExist_RunWorkerCompleted);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel|*.xlsx";
            this.saveFileDialog1.Title = "Exportar Facturas";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmArtVend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(983, 502);
            this.Controls.Add(this.pbVentas);
            this.Controls.Add(this.dataGridViewVentas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArtVend";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmArtVend";
            this.Activated += new System.EventHandler(this.frmArtVend_Activated);
            this.Load += new System.EventHandler(this.frmArtVend_Load);
            this.Shown += new System.EventHandler(this.frmArtVend_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteVentasxArticulosResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lbDesde;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label lbHasta;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.ComboBox cbColeccion;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btExport;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dataGridViewVentas;
    private System.Windows.Forms.PictureBox pbVentas;
    private System.ComponentModel.BackgroundWorker backgroundWorkerExist;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.TextBox txtDevolucion;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.TextBox txtVendido;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnLimpiar;
    private System.Windows.Forms.BindingSource ePKspReporteVentasxArticulosResultBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn codReferenciaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn CodArticulo;
    private System.Windows.Forms.DataGridViewTextBoxColumn descripDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn fotoPeqDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn IdFactura;
    private System.Windows.Forms.DataGridViewTextBoxColumn ventasDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Act;
  }
}