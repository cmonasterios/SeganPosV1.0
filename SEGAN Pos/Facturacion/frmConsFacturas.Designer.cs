namespace SEGAN_POS
{
  partial class frmConsFacturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbEstatusFac = new System.Windows.Forms.ComboBox();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txNFact = new System.Windows.Forms.TextBox();
            this.lbFactDesd = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lbHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lbDesde = new System.Windows.Forms.Label();
            this.lbEstatusFac = new System.Windows.Forms.Label();
            this.txDocCliente = new System.Windows.Forms.TextBox();
            this.lbDocCliente = new System.Windows.Forms.Label();
            this.txSerialMF = new System.Windows.Forms.TextBox();
            this.lbSerialMF = new System.Windows.Forms.Label();
            this.txMontoDesde = new System.Windows.Forms.TextBox();
            this.lbMontoDesde = new System.Windows.Forms.Label();
            this.txMontoHasta = new System.Windows.Forms.TextBox();
            this.lbMontoHasta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txCajero = new System.Windows.Forms.TextBox();
            this.chDesc = new System.Windows.Forms.CheckBox();
            this.chDev = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgFacturas = new System.Windows.Forms.DataGridView();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaEsperaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialMFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listadoFacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btVer = new System.Windows.Forms.Button();
            this.btSolNCredito = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.lbCantReg = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEstatusFac
            // 
            this.cbEstatusFac.CausesValidation = false;
            this.cbEstatusFac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstatusFac.FormattingEnabled = true;
            this.cbEstatusFac.Location = new System.Drawing.Point(616, 48);
            this.cbEstatusFac.Name = "cbEstatusFac";
            this.cbEstatusFac.Size = new System.Drawing.Size(169, 21);
            this.cbEstatusFac.TabIndex = 7;
            // 
            // btLimpiar
            // 
            this.btLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLimpiar.CausesValidation = false;
            this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btLimpiar.Location = new System.Drawing.Point(830, 72);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btLimpiar.TabIndex = 13;
            this.btLimpiar.Text = "Limpiar Criterios";
            this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.CausesValidation = false;
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(830, 13);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 12;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txNFact
            // 
            this.txNFact.CausesValidation = false;
            this.txNFact.Location = new System.Drawing.Point(102, 13);
            this.txNFact.MaxLength = 15;
            this.txNFact.Name = "txNFact";
            this.txNFact.Size = new System.Drawing.Size(124, 20);
            this.txNFact.TabIndex = 0;
            this.txNFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFact_KeyPress);
            // 
            // lbFactDesd
            // 
            this.lbFactDesd.AutoSize = true;
            this.lbFactDesd.Location = new System.Drawing.Point(38, 16);
            this.lbFactDesd.Name = "lbFactDesd";
            this.lbFactDesd.Size = new System.Drawing.Size(58, 13);
            this.lbFactDesd.TabIndex = 67;
            this.lbFactDesd.Text = "N° Factura";
            this.lbFactDesd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CausesValidation = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(477, 13);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(81, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // lbHasta
            // 
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(407, 16);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(68, 13);
            this.lbHasta.TabIndex = 65;
            this.lbHasta.Text = "Fecha Hasta";
            this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDesde
            // 
            this.dtpDesde.CausesValidation = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(313, 13);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(81, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lbDesde
            // 
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(239, 16);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(71, 13);
            this.lbDesde.TabIndex = 63;
            this.lbDesde.Text = "Fecha Desde";
            this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbEstatusFac
            // 
            this.lbEstatusFac.AutoSize = true;
            this.lbEstatusFac.Location = new System.Drawing.Point(568, 51);
            this.lbEstatusFac.Name = "lbEstatusFac";
            this.lbEstatusFac.Size = new System.Drawing.Size(42, 13);
            this.lbEstatusFac.TabIndex = 73;
            this.lbEstatusFac.Text = "Estatus";
            this.lbEstatusFac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txDocCliente
            // 
            this.txDocCliente.CausesValidation = false;
            this.txDocCliente.Location = new System.Drawing.Point(658, 13);
            this.txDocCliente.MaxLength = 15;
            this.txDocCliente.Name = "txDocCliente";
            this.txDocCliente.Size = new System.Drawing.Size(127, 20);
            this.txDocCliente.TabIndex = 3;
            // 
            // lbDocCliente
            // 
            this.lbDocCliente.AutoSize = true;
            this.lbDocCliente.Location = new System.Drawing.Point(587, 16);
            this.lbDocCliente.Name = "lbDocCliente";
            this.lbDocCliente.Size = new System.Drawing.Size(65, 13);
            this.lbDocCliente.TabIndex = 74;
            this.lbDocCliente.Text = "Doc. Cliente";
            this.lbDocCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSerialMF
            // 
            this.txSerialMF.CausesValidation = false;
            this.txSerialMF.Location = new System.Drawing.Point(102, 48);
            this.txSerialMF.MaxLength = 15;
            this.txSerialMF.Name = "txSerialMF";
            this.txSerialMF.Size = new System.Drawing.Size(106, 20);
            this.txSerialMF.TabIndex = 4;
            // 
            // lbSerialMF
            // 
            this.lbSerialMF.AutoSize = true;
            this.lbSerialMF.Location = new System.Drawing.Point(18, 51);
            this.lbSerialMF.Name = "lbSerialMF";
            this.lbSerialMF.Size = new System.Drawing.Size(78, 13);
            this.lbSerialMF.TabIndex = 76;
            this.lbSerialMF.Text = "Máquina Fiscal";
            this.lbSerialMF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoDesde
            // 
            this.txMontoDesde.CausesValidation = false;
            this.txMontoDesde.Location = new System.Drawing.Point(291, 48);
            this.txMontoDesde.MaxLength = 15;
            this.txMontoDesde.Name = "txMontoDesde";
            this.txMontoDesde.Size = new System.Drawing.Size(90, 20);
            this.txMontoDesde.TabIndex = 5;
            this.txMontoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txMontoDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMontoDesde_KeyPress);
            // 
            // lbMontoDesde
            // 
            this.lbMontoDesde.AutoSize = true;
            this.lbMontoDesde.Location = new System.Drawing.Point(214, 51);
            this.lbMontoDesde.Name = "lbMontoDesde";
            this.lbMontoDesde.Size = new System.Drawing.Size(71, 13);
            this.lbMontoDesde.TabIndex = 78;
            this.lbMontoDesde.Text = "Monto Desde";
            this.lbMontoDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoHasta
            // 
            this.txMontoHasta.CausesValidation = false;
            this.txMontoHasta.Location = new System.Drawing.Point(461, 48);
            this.txMontoHasta.MaxLength = 15;
            this.txMontoHasta.Name = "txMontoHasta";
            this.txMontoHasta.Size = new System.Drawing.Size(90, 20);
            this.txMontoHasta.TabIndex = 6;
            this.txMontoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txMontoHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMontoHasta_KeyPress);
            // 
            // lbMontoHasta
            // 
            this.lbMontoHasta.AutoSize = true;
            this.lbMontoHasta.Location = new System.Drawing.Point(387, 51);
            this.lbMontoHasta.Name = "lbMontoHasta";
            this.lbMontoHasta.Size = new System.Drawing.Size(68, 13);
            this.lbMontoHasta.TabIndex = 80;
            this.lbMontoHasta.Text = "Monto Hasta";
            this.lbMontoHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txCajero);
            this.panel1.Controls.Add(this.chDesc);
            this.panel1.Controls.Add(this.chDev);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbCaja);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.txMontoHasta);
            this.panel1.Controls.Add(this.cbEstatusFac);
            this.panel1.Controls.Add(this.lbMontoHasta);
            this.panel1.Controls.Add(this.lbDesde);
            this.panel1.Controls.Add(this.txMontoDesde);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.lbMontoDesde);
            this.panel1.Controls.Add(this.lbHasta);
            this.panel1.Controls.Add(this.txSerialMF);
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.lbSerialMF);
            this.panel1.Controls.Add(this.lbFactDesd);
            this.panel1.Controls.Add(this.txDocCliente);
            this.panel1.Controls.Add(this.txNFact);
            this.panel1.Controls.Add(this.lbDocCliente);
            this.panel1.Controls.Add(this.btLimpiar);
            this.panel1.Controls.Add(this.lbEstatusFac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 113);
            this.panel1.TabIndex = 0;
            // 
            // txCajero
            // 
            this.txCajero.CausesValidation = false;
            this.txCajero.Location = new System.Drawing.Point(102, 80);
            this.txCajero.MaxLength = 15;
            this.txCajero.Name = "txCajero";
            this.txCajero.Size = new System.Drawing.Size(240, 20);
            this.txCajero.TabIndex = 8;
            // 
            // chDesc
            // 
            this.chDesc.AutoSize = true;
            this.chDesc.Checked = true;
            this.chDesc.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chDesc.Location = new System.Drawing.Point(702, 84);
            this.chDesc.Name = "chDesc";
            this.chDesc.Size = new System.Drawing.Size(83, 17);
            this.chDesc.TabIndex = 11;
            this.chDesc.Text = "Descuentos";
            this.chDesc.ThreeState = true;
            this.chDesc.UseVisualStyleBackColor = true;
            // 
            // chDev
            // 
            this.chDev.AutoSize = true;
            this.chDev.Checked = true;
            this.chDev.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chDev.Location = new System.Drawing.Point(571, 84);
            this.chDev.Name = "chDev";
            this.chDev.Size = new System.Drawing.Size(91, 17);
            this.chDev.TabIndex = 10;
            this.chDev.Text = "Devoluciones";
            this.chDev.ThreeState = true;
            this.chDev.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Facturado por";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCaja
            // 
            this.cbCaja.CausesValidation = false;
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(382, 80);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(169, 21);
            this.cbCaja.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Caja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgFacturas
            // 
            this.dgFacturas.AllowUserToAddRows = false;
            this.dgFacturas.AllowUserToDeleteRows = false;
            this.dgFacturas.AllowUserToResizeColumns = false;
            this.dgFacturas.AllowUserToResizeRows = false;
            this.dgFacturas.AutoGenerateColumns = false;
            this.dgFacturas.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.FechaCreacion,
            this.numeroDataGridViewTextBoxColumn,
            this.Ticket,
            this.idFacturaDataGridViewTextBoxColumn,
            this.idFacturaEsperaDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn,
            this.docClienteDataGridViewTextBoxColumn,
            this.serialMFDataGridViewTextBoxColumn,
            this.montoTotalDataGridViewTextBoxColumn,
            this.idEstatusDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn});
            this.dgFacturas.DataSource = this.listadoFacturasBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFacturas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFacturas.Location = new System.Drawing.Point(2, 115);
            this.dgFacturas.MultiSelect = false;
            this.dgFacturas.Name = "dgFacturas";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgFacturas.RowHeadersVisible = false;
            this.dgFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacturas.ShowEditingIcon = false;
            this.dgFacturas.Size = new System.Drawing.Size(952, 323);
            this.dgFacturas.TabIndex = 0;
            this.dgFacturas.TabStop = false;
            this.dgFacturas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgFacturas_CellBeginEdit);
            this.dgFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFacturas_CellDoubleClick);
            this.dgFacturas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgFacturas_DataError);
            this.dgFacturas.SelectionChanged += new System.EventHandler(this.dgFacturas_SelectionChanged);
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaCreacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.Width = 75;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.FechaCreacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaCreacion.HeaderText = "Hora";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 75;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            dataGridViewCellStyle4.Format = "D";
            dataGridViewCellStyle4.NullValue = "0";
            this.numeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.numeroDataGridViewTextBoxColumn.HeaderText = "N° Factura";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.Width = 90;
            // 
            // Ticket
            // 
            this.Ticket.DataPropertyName = "Ticket";
            this.Ticket.HeaderText = "Ticket";
            this.Ticket.Name = "Ticket";
            this.Ticket.Width = 60;
            // 
            // idFacturaDataGridViewTextBoxColumn
            // 
            this.idFacturaDataGridViewTextBoxColumn.DataPropertyName = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.HeaderText = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.Name = "idFacturaDataGridViewTextBoxColumn";
            this.idFacturaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFacturaEsperaDataGridViewTextBoxColumn
            // 
            this.idFacturaEsperaDataGridViewTextBoxColumn.DataPropertyName = "IdFacturaEspera";
            this.idFacturaEsperaDataGridViewTextBoxColumn.HeaderText = "IdFacturaEspera";
            this.idFacturaEsperaDataGridViewTextBoxColumn.Name = "idFacturaEsperaDataGridViewTextBoxColumn";
            this.idFacturaEsperaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Nombre Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.Width = 200;
            // 
            // docClienteDataGridViewTextBoxColumn
            // 
            this.docClienteDataGridViewTextBoxColumn.DataPropertyName = "DocCliente";
            this.docClienteDataGridViewTextBoxColumn.HeaderText = "Doc. Cliente";
            this.docClienteDataGridViewTextBoxColumn.Name = "docClienteDataGridViewTextBoxColumn";
            this.docClienteDataGridViewTextBoxColumn.Width = 110;
            // 
            // serialMFDataGridViewTextBoxColumn
            // 
            this.serialMFDataGridViewTextBoxColumn.DataPropertyName = "SerialMF";
            this.serialMFDataGridViewTextBoxColumn.HeaderText = "Máquina Fiscal";
            this.serialMFDataGridViewTextBoxColumn.Name = "serialMFDataGridViewTextBoxColumn";
            this.serialMFDataGridViewTextBoxColumn.Width = 118;
            // 
            // montoTotalDataGridViewTextBoxColumn
            // 
            this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "MontoTotal";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.montoTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.montoTotalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
            this.montoTotalDataGridViewTextBoxColumn.Width = 114;
            // 
            // idEstatusDataGridViewTextBoxColumn
            // 
            this.idEstatusDataGridViewTextBoxColumn.DataPropertyName = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.HeaderText = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.Name = "idEstatusDataGridViewTextBoxColumn";
            this.idEstatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.Width = 90;
            // 
            // listadoFacturasBindingSource
            // 
            this.listadoFacturasBindingSource.DataSource = typeof(SEGAN_POS.DAL.ListadoFacturas);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btVer);
            this.panel2.Controls.Add(this.btSolNCredito);
            this.panel2.Controls.Add(this.btExport);
            this.panel2.Controls.Add(this.lbCantReg);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 39);
            this.panel2.TabIndex = 1;
            // 
            // btVer
            // 
            this.btVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btVer.CausesValidation = false;
            this.btVer.Enabled = false;
            this.btVer.Image = global::SEGAN_POS.Properties.Resources.view;
            this.btVer.Location = new System.Drawing.Point(771, 4);
            this.btVer.Name = "btVer";
            this.btVer.Size = new System.Drawing.Size(95, 32);
            this.btVer.TabIndex = 84;
            this.btVer.TabStop = false;
            this.btVer.Tag = "";
            this.btVer.Text = "Ver Factura";
            this.btVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btVer.UseVisualStyleBackColor = true;
            this.btVer.Click += new System.EventHandler(this.btVer_Click);
            // 
            // btSolNCredito
            // 
            this.btSolNCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSolNCredito.CausesValidation = false;
            this.btSolNCredito.Enabled = false;
            this.btSolNCredito.Image = global::SEGAN_POS.Properties.Resources.notadecredito;
            this.btSolNCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSolNCredito.Location = new System.Drawing.Point(533, 4);
            this.btSolNCredito.Name = "btSolNCredito";
            this.btSolNCredito.Size = new System.Drawing.Size(143, 32);
            this.btSolNCredito.TabIndex = 83;
            this.btSolNCredito.TabStop = false;
            this.btSolNCredito.Tag = "frmNCredito";
            this.btSolNCredito.Text = "Generar Solicitud N/C";
            this.btSolNCredito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSolNCredito.UseVisualStyleBackColor = true;
            this.btSolNCredito.Click += new System.EventHandler(this.btSolNCredito_Click);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.CausesValidation = false;
            this.btExport.Enabled = false;
            this.btExport.Image = global::SEGAN_POS.Properties.Resources.excel;
            this.btExport.Location = new System.Drawing.Point(682, 4);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(83, 32);
            this.btExport.TabIndex = 82;
            this.btExport.TabStop = false;
            this.btExport.Tag = "Exportar";
            this.btExport.Text = "Exportar";
            this.btExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // lbCantReg
            // 
            this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantReg.AutoSize = true;
            this.lbCantReg.Location = new System.Drawing.Point(13, 14);
            this.lbCantReg.Name = "lbCantReg";
            this.lbCantReg.Size = new System.Drawing.Size(108, 13);
            this.lbCantReg.TabIndex = 81;
            this.lbCantReg.Text = "registros encontrados";
            this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCantReg.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.CausesValidation = false;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancelar.Location = new System.Drawing.Point(872, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(70, 32);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.TabStop = false;
            this.btCancelar.Text = "Cerrar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Filter = "Excel|*.xlsx";
            this.saveFileDialog1.Title = "Exportar Facturas";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmConsFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 479);
            this.Controls.Add(this.dgFacturas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsFacturas";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consultar Facturas";
            this.Activated += new System.EventHandler(this.frmConsFacturas_Activated);
            this.Load += new System.EventHandler(this.frmConsFacturas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox cbEstatusFac;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.TextBox txNFact;
    private System.Windows.Forms.Label lbFactDesd;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Label lbHasta;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label lbDesde;
    private System.Windows.Forms.Label lbEstatusFac;
    private System.Windows.Forms.TextBox txDocCliente;
    private System.Windows.Forms.Label lbDocCliente;
    private System.Windows.Forms.TextBox txSerialMF;
    private System.Windows.Forms.Label lbSerialMF;
    private System.Windows.Forms.TextBox txMontoDesde;
    private System.Windows.Forms.Label lbMontoDesde;
    private System.Windows.Forms.TextBox txMontoHasta;
    private System.Windows.Forms.Label lbMontoHasta;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView dgFacturas;
    private System.Windows.Forms.BindingSource listadoFacturasBindingSource;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Button btExport;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.ComboBox cbCaja;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox chDesc;
    private System.Windows.Forms.CheckBox chDev;
    private System.Windows.Forms.TextBox txCajero;
    private System.Windows.Forms.Button btSolNCredito;
    private System.Windows.Forms.Button btVer;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
    private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn Ticket;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaEsperaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn docClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn serialMFDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idEstatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;
  }
}