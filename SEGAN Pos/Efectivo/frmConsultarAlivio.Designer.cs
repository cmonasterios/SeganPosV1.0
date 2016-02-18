namespace SEGAN_POS
{
  partial class frmConsultarAlivio
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCajero = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.tbAlivios = new System.Windows.Forms.TabControl();
            this.tbPage1 = new System.Windows.Forms.TabPage();
            this.grdAlivios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semaforoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.cajeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadAliviosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoConsolidadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoAprobado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alivioConsultaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbPage2 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grdAliviosDet = new System.Windows.Forms.DataGridView();
            this.dsAlivioConsultaDet = new System.Windows.Forms.BindingSource(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.txTotalAlivioApro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txTotalAlivio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAlivio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbAlivios.SuspendLayout();
            this.tbPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlivios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alivioConsultaBindingSource)).BeginInit();
            this.tbPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAliviosDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAlivioConsultaDet)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Fecha de Venta Fin";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Fecha de Venta Inicio";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Estatus";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEstatus
            // 
            this.cbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstatus.FormattingEnabled = true;
            this.cbEstatus.Items.AddRange(new object[] {
            "Pendientes",
            "Aprobados"});
            this.cbEstatus.Location = new System.Drawing.Point(377, 57);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(132, 21);
            this.cbEstatus.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cajero";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCajero
            // 
            this.cbCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajero.FormattingEnabled = true;
            this.cbCajero.Location = new System.Drawing.Point(85, 57);
            this.cbCajero.Name = "cbCajero";
            this.cbCajero.Size = new System.Drawing.Size(165, 21);
            this.cbCajero.TabIndex = 4;
            // 
            // btCancel
            // 
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(717, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(73, 33);
            this.btCancel.TabIndex = 35;
            this.btCancel.Text = "Cerrar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // tbAlivios
            // 
            this.tbAlivios.Controls.Add(this.tbPage1);
            this.tbAlivios.Controls.Add(this.tbPage2);
            this.tbAlivios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAlivios.Location = new System.Drawing.Point(0, 0);
            this.tbAlivios.Name = "tbAlivios";
            this.tbAlivios.SelectedIndex = 0;
            this.tbAlivios.Size = new System.Drawing.Size(797, 398);
            this.tbAlivios.TabIndex = 36;
            this.tbAlivios.SelectedIndexChanged += new System.EventHandler(this.tbAlivios_SelectedIndexChanged);
            // 
            // tbPage1
            // 
            this.tbPage1.Controls.Add(this.grdAlivios);
            this.tbPage1.Location = new System.Drawing.Point(4, 22);
            this.tbPage1.Name = "tbPage1";
            this.tbPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage1.Size = new System.Drawing.Size(789, 372);
            this.tbPage1.TabIndex = 0;
            this.tbPage1.Text = "Consulta de Alivios";
            this.tbPage1.UseVisualStyleBackColor = true;
            // 
            // grdAlivios
            // 
            this.grdAlivios.AllowUserToAddRows = false;
            this.grdAlivios.AllowUserToDeleteRows = false;
            this.grdAlivios.AllowUserToResizeColumns = false;
            this.grdAlivios.AllowUserToResizeRows = false;
            this.grdAlivios.AutoGenerateColumns = false;
            this.grdAlivios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAlivios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.semaforoDataGridViewImageColumn,
            this.cajeroDataGridViewTextBoxColumn,
            this.cantidadAliviosDataGridViewTextBoxColumn,
            this.montoConsolidadoDataGridViewTextBoxColumn,
            this.MontoAprobado});
            this.grdAlivios.DataSource = this.alivioConsultaBindingSource;
            this.grdAlivios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAlivios.Location = new System.Drawing.Point(3, 3);
            this.grdAlivios.MultiSelect = false;
            this.grdAlivios.Name = "grdAlivios";
            this.grdAlivios.ReadOnly = true;
            this.grdAlivios.RowHeadersVisible = false;
            this.grdAlivios.RowHeadersWidth = 21;
            this.grdAlivios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAlivios.RowTemplate.Height = 30;
            this.grdAlivios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAlivios.Size = new System.Drawing.Size(783, 366);
            this.grdAlivios.TabIndex = 0;
            this.grdAlivios.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdAlivios_CellBeginEdit);
            this.grdAlivios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAlivios_CellDoubleClick);
            this.grdAlivios.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdAlivios_DataError);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // semaforoDataGridViewImageColumn
            // 
            this.semaforoDataGridViewImageColumn.DataPropertyName = "Semaforo";
            this.semaforoDataGridViewImageColumn.HeaderText = "";
            this.semaforoDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.semaforoDataGridViewImageColumn.Name = "semaforoDataGridViewImageColumn";
            this.semaforoDataGridViewImageColumn.ReadOnly = true;
            this.semaforoDataGridViewImageColumn.Width = 30;
            // 
            // cajeroDataGridViewTextBoxColumn
            // 
            this.cajeroDataGridViewTextBoxColumn.DataPropertyName = "Cajero";
            this.cajeroDataGridViewTextBoxColumn.HeaderText = "Cajero";
            this.cajeroDataGridViewTextBoxColumn.Name = "cajeroDataGridViewTextBoxColumn";
            this.cajeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.cajeroDataGridViewTextBoxColumn.Width = 150;
            // 
            // cantidadAliviosDataGridViewTextBoxColumn
            // 
            this.cantidadAliviosDataGridViewTextBoxColumn.DataPropertyName = "CantidadAlivios";
            this.cantidadAliviosDataGridViewTextBoxColumn.HeaderText = "Cantidad Alivios";
            this.cantidadAliviosDataGridViewTextBoxColumn.Name = "cantidadAliviosDataGridViewTextBoxColumn";
            this.cantidadAliviosDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadAliviosDataGridViewTextBoxColumn.Width = 110;
            // 
            // montoConsolidadoDataGridViewTextBoxColumn
            // 
            this.montoConsolidadoDataGridViewTextBoxColumn.DataPropertyName = "MontoConsolidado";
            this.montoConsolidadoDataGridViewTextBoxColumn.HeaderText = "Monto Consolidado";
            this.montoConsolidadoDataGridViewTextBoxColumn.Name = "montoConsolidadoDataGridViewTextBoxColumn";
            this.montoConsolidadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoConsolidadoDataGridViewTextBoxColumn.Width = 120;
            // 
            // MontoAprobado
            // 
            this.MontoAprobado.DataPropertyName = "MontoAprobado";
            this.MontoAprobado.HeaderText = "Monto Aprobado";
            this.MontoAprobado.Name = "MontoAprobado";
            this.MontoAprobado.ReadOnly = true;
            this.MontoAprobado.Width = 120;
            // 
            // alivioConsultaBindingSource
            // 
            this.alivioConsultaBindingSource.DataSource = typeof(SEGAN_POS.DAL.AlivioConsulta);
            // 
            // tbPage2
            // 
            this.tbPage2.Controls.Add(this.panel5);
            this.tbPage2.Controls.Add(this.panel4);
            this.tbPage2.Location = new System.Drawing.Point(4, 22);
            this.tbPage2.Name = "tbPage2";
            this.tbPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage2.Size = new System.Drawing.Size(789, 372);
            this.tbPage2.TabIndex = 1;
            this.tbPage2.Text = "Detalle";
            this.tbPage2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.grdAliviosDet);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(783, 333);
            this.panel5.TabIndex = 3;
            // 
            // grdAliviosDet
            // 
            this.grdAliviosDet.AllowUserToAddRows = false;
            this.grdAliviosDet.AllowUserToDeleteRows = false;
            this.grdAliviosDet.AllowUserToResizeRows = false;
            this.grdAliviosDet.AutoGenerateColumns = false;
            this.grdAliviosDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAliviosDet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.FechaAlivio,
            this.Column1,
            this.Column2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.grdAliviosDet.DataSource = this.dsAlivioConsultaDet;
            this.grdAliviosDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAliviosDet.Location = new System.Drawing.Point(0, 0);
            this.grdAliviosDet.MultiSelect = false;
            this.grdAliviosDet.Name = "grdAliviosDet";
            this.grdAliviosDet.RowHeadersVisible = false;
            this.grdAliviosDet.RowHeadersWidth = 21;
            this.grdAliviosDet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAliviosDet.RowTemplate.Height = 30;
            this.grdAliviosDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAliviosDet.Size = new System.Drawing.Size(783, 333);
            this.grdAliviosDet.TabIndex = 1;
            this.grdAliviosDet.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdAliviosDet_CellBeginEdit);
            this.grdAliviosDet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAliviosDet_CellContentClick);
            this.grdAliviosDet.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdAliviosDet_DataError);
            // 
            // dsAlivioConsultaDet
            // 
            this.dsAlivioConsultaDet.DataSource = typeof(SEGAN_POS.DAL.AlivioConsulta);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txTotalAlivioApro);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txTotalAlivio);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 336);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(783, 33);
            this.panel4.TabIndex = 2;
            // 
            // txTotalAlivioApro
            // 
            this.txTotalAlivioApro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txTotalAlivioApro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalAlivioApro.Location = new System.Drawing.Point(678, 6);
            this.txTotalAlivioApro.Name = "txTotalAlivioApro";
            this.txTotalAlivioApro.ReadOnly = true;
            this.txTotalAlivioApro.Size = new System.Drawing.Size(100, 20);
            this.txTotalAlivioApro.TabIndex = 3;
            this.txTotalAlivioApro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Alivio Aprobado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txTotalAlivio
            // 
            this.txTotalAlivio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalAlivio.Location = new System.Drawing.Point(458, 6);
            this.txTotalAlivio.Name = "txTotalAlivio";
            this.txTotalAlivio.ReadOnly = true;
            this.txTotalAlivio.Size = new System.Drawing.Size(100, 20);
            this.txTotalAlivio.TabIndex = 1;
            this.txTotalAlivio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Alivio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CausesValidation = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(131, 18);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(118, 20);
            this.dtpDesde.TabIndex = 55;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.CausesValidation = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(391, 18);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(118, 20);
            this.dtpHasta.TabIndex = 77;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.btLimpiar);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.cbCajero);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbEstatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 100);
            this.panel1.TabIndex = 37;
            // 
            // btBuscar
            // 
            this.btBuscar.CausesValidation = false;
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(675, 7);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 80;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.CausesValidation = false;
            this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btLimpiar.Location = new System.Drawing.Point(675, 66);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btLimpiar.TabIndex = 79;
            this.btLimpiar.Text = "Limpiar Criterios";
            this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 46);
            this.panel2.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbAlivios);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(797, 398);
            this.panel3.TabIndex = 39;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Semaforo";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id Alivio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // FechaAlivio
            // 
            this.FechaAlivio.DataPropertyName = "FechaVenta";
            this.FechaAlivio.HeaderText = "Fecha de Venta";
            this.FechaAlivio.Name = "FechaAlivio";
            this.FechaAlivio.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FechaAlivio";
            this.Column1.HeaderText = "Fecha  Alivio";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FechaAprobación";
            this.Column2.HeaderText = "Fecha de Aprobación";
            this.Column2.Name = "Column2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Caja";
            this.dataGridViewTextBoxColumn3.HeaderText = "Caja";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Cajero";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cajero";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CantidadAlivios";
            this.dataGridViewTextBoxColumn5.HeaderText = "Cantidad Alivios";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MontoConsolidado";
            this.dataGridViewTextBoxColumn6.HeaderText = "Monto Alivio";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MontoAprobado";
            this.dataGridViewTextBoxColumn7.HeaderText = "Monto Aprobado";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // frmConsultarAlivio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 544);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultarAlivio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmConsultarAlivio";
            this.Activated += new System.EventHandler(this.frmConsultarAlivio_Activated);
            this.Load += new System.EventHandler(this.frmConsultarAlivio_Load);
            this.Shown += new System.EventHandler(this.frmConsultarAlivio_Shown);
            this.tbAlivios.ResumeLayout(false);
            this.tbPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlivios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alivioConsultaBindingSource)).EndInit();
            this.tbPage2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAliviosDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAlivioConsultaDet)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbEstatus;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbCajero;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.TabControl tbAlivios;
    private System.Windows.Forms.TabPage tbPage1;
    private System.Windows.Forms.TabPage tbPage2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.BindingSource alivioConsultaBindingSource;
    private System.Windows.Forms.DataGridView grdAlivios;
    private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource dsAlivioConsultaDet;
    private System.Windows.Forms.DataGridView grdAliviosDet;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TextBox txTotalAlivio;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txTotalAlivioApro;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    private System.Windows.Forms.DataGridViewImageColumn semaforoDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cajeroDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cantidadAliviosDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoConsolidadoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn MontoAprobado;
    private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaAlivio;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
  }
}