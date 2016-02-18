namespace SEGAN_POS
{
    partial class frmPedidoSugerido
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
            if (disposing && (components != null))
            {
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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.nudPidoEntre5y = new System.Windows.Forms.NumericUpDown();
      this.nudEntre5y = new System.Windows.Forms.NumericUpDown();
      this.nudPidoMenosDe = new System.Windows.Forms.NumericUpDown();
      this.nudMenosDe = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.lblRango = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.btProcesar = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lbDesde = new System.Windows.Forms.Label();
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.lbHasta = new System.Windows.Forms.Label();
      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.btBuscarArt = new System.Windows.Forms.Button();
      this.cbColeccion = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.pbPedido = new System.Windows.Forms.PictureBox();
      this.label7 = new System.Windows.Forms.Label();
      this.textBoxCapacidad = new System.Windows.Forms.TextBox();
      this.btnExportar = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.tipoPrendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pedirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ePKspPedidoSugeridoTotalesResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.dataGridViewPedido = new System.Windows.Forms.DataGridView();
      this.FotoPequena = new System.Windows.Forms.DataGridViewImageColumn();
      this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CodigoTalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CodigoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescripcionGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EnTienda = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Pedir = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.EnAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label12 = new System.Windows.Forms.Label();
      this.textBoxPorconped = new System.Windows.Forms.TextBox();
      this.textBoxExistenciaped = new System.Windows.Forms.TextBox();
      this.textBoxPorcentajeST = new System.Windows.Forms.TextBox();
      this.textBoxExiActual = new System.Windows.Forms.TextBox();
      this.textBoxPiezasVen = new System.Windows.Forms.TextBox();
      this.textBoxExiDynamics = new System.Windows.Forms.TextBox();
      this.label13 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.txtExistencia = new System.Windows.Forms.TextBox();
      this.label15 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.dataGridViewExistenciaTienda = new System.Windows.Forms.DataGridView();
      this.Foto = new System.Windows.Forms.DataGridViewImageColumn();
      this.CodigoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codigoArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.existenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ExistenciaAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.exentoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.ePKArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.btnExportarVentas = new System.Windows.Forms.Button();
      this.txtDevolucion = new System.Windows.Forms.TextBox();
      this.label14 = new System.Windows.Forms.Label();
      this.txtVendido = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.pbVentas = new System.Windows.Forms.PictureBox();
      this.dataGridViewVentas = new System.Windows.Forms.DataGridView();
      this.FotoPeq = new System.Windows.Forms.DataGridViewImageColumn();
      this.CodReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CodArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Descrip = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Ventas = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.backgroundWorkerExist = new System.ComponentModel.BackgroundWorker();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.backgroundWorkerPedido = new System.ComponentModel.BackgroundWorker();
      this.backgroundWorkerExportPedido = new System.ComponentModel.BackgroundWorker();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPidoEntre5y)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudEntre5y)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPidoMenosDe)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMenosDe)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.tabPage5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPedido)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ePKspPedidoSugeridoTotalesResultBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedido)).BeginInit();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistenciaTienda)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ePKArticuloBindingSource)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.nudPidoEntre5y);
      this.groupBox2.Controls.Add(this.nudEntre5y);
      this.groupBox2.Controls.Add(this.nudPidoMenosDe);
      this.groupBox2.Controls.Add(this.nudMenosDe);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.lblRango);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.btProcesar);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Location = new System.Drawing.Point(934, 6);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(239, 142);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Criterios de Pedido";
      // 
      // nudPidoEntre5y
      // 
      this.nudPidoEntre5y.Location = new System.Drawing.Point(179, 50);
      this.nudPidoEntre5y.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.nudPidoEntre5y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudPidoEntre5y.Name = "nudPidoEntre5y";
      this.nudPidoEntre5y.Size = new System.Drawing.Size(40, 20);
      this.nudPidoEntre5y.TabIndex = 8;
      this.nudPidoEntre5y.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // nudEntre5y
      // 
      this.nudEntre5y.Location = new System.Drawing.Point(80, 50);
      this.nudEntre5y.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.nudEntre5y.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudEntre5y.Name = "nudEntre5y";
      this.nudEntre5y.Size = new System.Drawing.Size(40, 20);
      this.nudEntre5y.TabIndex = 7;
      this.nudEntre5y.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
      this.nudEntre5y.ValueChanged += new System.EventHandler(this.nudEntre5y_ValueChanged);
      // 
      // nudPidoMenosDe
      // 
      this.nudPidoMenosDe.Location = new System.Drawing.Point(179, 22);
      this.nudPidoMenosDe.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.nudPidoMenosDe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudPidoMenosDe.Name = "nudPidoMenosDe";
      this.nudPidoMenosDe.Size = new System.Drawing.Size(40, 20);
      this.nudPidoMenosDe.TabIndex = 6;
      this.nudPidoMenosDe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // nudMenosDe
      // 
      this.nudMenosDe.Location = new System.Drawing.Point(80, 22);
      this.nudMenosDe.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.nudMenosDe.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudMenosDe.Name = "nudMenosDe";
      this.nudMenosDe.Size = new System.Drawing.Size(40, 20);
      this.nudMenosDe.TabIndex = 5;
      this.nudMenosDe.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudMenosDe.ValueChanged += new System.EventHandler(this.nudMenosDe_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(142, 52);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(28, 13);
      this.label5.TabIndex = 7;
      this.label5.Text = "Pido";
      // 
      // lblRango
      // 
      this.lblRango.AutoSize = true;
      this.lblRango.Location = new System.Drawing.Point(16, 52);
      this.lblRango.Name = "lblRango";
      this.lblRango.Size = new System.Drawing.Size(49, 13);
      this.lblRango.TabIndex = 5;
      this.lblRango.Text = "Entre 1 y";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(142, 25);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(28, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Pido";
      // 
      // btProcesar
      // 
      this.btProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btProcesar.Image = global::SEGAN_POS.Properties.Resources.ejecutar;
      this.btProcesar.Location = new System.Drawing.Point(146, 88);
      this.btProcesar.Name = "btProcesar";
      this.btProcesar.Size = new System.Drawing.Size(73, 48);
      this.btProcesar.TabIndex = 9;
      this.btProcesar.Text = "Procesar";
      this.btProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btProcesar.UseVisualStyleBackColor = true;
      this.btProcesar.Click += new System.EventHandler(this.btProcesar_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 25);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(54, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Menos de";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lbDesde);
      this.groupBox1.Controls.Add(this.dtpDesde);
      this.groupBox1.Controls.Add(this.lbHasta);
      this.groupBox1.Controls.Add(this.dtpHasta);
      this.groupBox1.Controls.Add(this.btBuscarArt);
      this.groupBox1.Controls.Add(this.cbColeccion);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(1174, 61);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Criterios de Búsqueda";
      // 
      // lbDesde
      // 
      this.lbDesde.AutoSize = true;
      this.lbDesde.Location = new System.Drawing.Point(359, 27);
      this.lbDesde.Name = "lbDesde";
      this.lbDesde.Size = new System.Drawing.Size(38, 13);
      this.lbDesde.TabIndex = 68;
      this.lbDesde.Text = "Desde";
      this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpDesde
      // 
      this.dtpDesde.CausesValidation = false;
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDesde.Location = new System.Drawing.Point(408, 23);
      this.dtpDesde.Name = "dtpDesde";
      this.dtpDesde.Size = new System.Drawing.Size(105, 20);
      this.dtpDesde.TabIndex = 66;
      // 
      // lbHasta
      // 
      this.lbHasta.AutoSize = true;
      this.lbHasta.Location = new System.Drawing.Point(540, 27);
      this.lbHasta.Name = "lbHasta";
      this.lbHasta.Size = new System.Drawing.Size(35, 13);
      this.lbHasta.TabIndex = 69;
      this.lbHasta.Text = "Hasta";
      this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpHasta
      // 
      this.dtpHasta.CausesValidation = false;
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpHasta.Location = new System.Drawing.Point(581, 24);
      this.dtpHasta.Name = "dtpHasta";
      this.dtpHasta.Size = new System.Drawing.Size(105, 20);
      this.dtpHasta.TabIndex = 67;
      // 
      // btBuscarArt
      // 
      this.btBuscarArt.AutoSize = true;
      this.btBuscarArt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.btBuscarArt.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscarArt.Location = new System.Drawing.Point(1124, 17);
      this.btBuscarArt.Name = "btBuscarArt";
      this.btBuscarArt.Size = new System.Drawing.Size(30, 30);
      this.btBuscarArt.TabIndex = 3;
      this.btBuscarArt.TabStop = false;
      this.btBuscarArt.UseVisualStyleBackColor = true;
      this.btBuscarArt.Click += new System.EventHandler(this.btBuscarArt_Click);
      // 
      // cbColeccion
      // 
      this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbColeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbColeccion.FormattingEnabled = true;
      this.cbColeccion.Location = new System.Drawing.Point(81, 23);
      this.cbColeccion.Name = "cbColeccion";
      this.cbColeccion.Size = new System.Drawing.Size(231, 21);
      this.cbColeccion.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(18, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(54, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Colección";
      // 
      // tabPage5
      // 
      this.tabPage5.Controls.Add(this.pbPedido);
      this.tabPage5.Controls.Add(this.label7);
      this.tabPage5.Controls.Add(this.groupBox2);
      this.tabPage5.Controls.Add(this.textBoxCapacidad);
      this.tabPage5.Controls.Add(this.btnExportar);
      this.tabPage5.Controls.Add(this.dataGridView1);
      this.tabPage5.Controls.Add(this.dataGridViewPedido);
      this.tabPage5.Controls.Add(this.label12);
      this.tabPage5.Controls.Add(this.textBoxPorconped);
      this.tabPage5.Controls.Add(this.textBoxExistenciaped);
      this.tabPage5.Controls.Add(this.textBoxPorcentajeST);
      this.tabPage5.Controls.Add(this.textBoxExiActual);
      this.tabPage5.Controls.Add(this.textBoxPiezasVen);
      this.tabPage5.Controls.Add(this.textBoxExiDynamics);
      this.tabPage5.Controls.Add(this.label13);
      this.tabPage5.Controls.Add(this.label11);
      this.tabPage5.Controls.Add(this.label10);
      this.tabPage5.Controls.Add(this.label9);
      this.tabPage5.Controls.Add(this.label8);
      this.tabPage5.Location = new System.Drawing.Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage5.Size = new System.Drawing.Size(1181, 552);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Pedido";
      this.tabPage5.UseVisualStyleBackColor = true;
      // 
      // pbPedido
      // 
      this.pbPedido.Image = global::SEGAN_POS.Properties.Resources.progreso;
      this.pbPedido.Location = new System.Drawing.Point(431, 212);
      this.pbPedido.Name = "pbPedido";
      this.pbPedido.Size = new System.Drawing.Size(72, 70);
      this.pbPedido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbPedido.TabIndex = 24;
      this.pbPedido.TabStop = false;
      this.pbPedido.Visible = false;
      this.pbPedido.WaitOnLoad = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(935, 176);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(109, 13);
      this.label7.TabIndex = 28;
      this.label7.Text = "Capacidad de Tienda";
      // 
      // textBoxCapacidad
      // 
      this.textBoxCapacidad.Location = new System.Drawing.Point(1047, 173);
      this.textBoxCapacidad.Name = "textBoxCapacidad";
      this.textBoxCapacidad.ReadOnly = true;
      this.textBoxCapacidad.Size = new System.Drawing.Size(124, 20);
      this.textBoxCapacidad.TabIndex = 27;
      this.textBoxCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnExportar
      // 
      this.btnExportar.Image = global::SEGAN_POS.Properties.Resources.excel;
      this.btnExportar.Location = new System.Drawing.Point(1090, 513);
      this.btnExportar.Name = "btnExportar";
      this.btnExportar.Size = new System.Drawing.Size(81, 31);
      this.btnExportar.TabIndex = 26;
      this.btnExportar.Text = "Exportar";
      this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnExportar.UseVisualStyleBackColor = true;
      this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.ColumnHeadersVisible = false;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoPrendaDataGridViewTextBoxColumn,
            this.pedirDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.ePKspPedidoSugeridoTotalesResultBindingSource;
      this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dataGridView1.Location = new System.Drawing.Point(934, 357);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.Size = new System.Drawing.Size(240, 150);
      this.dataGridView1.TabIndex = 25;
      // 
      // tipoPrendaDataGridViewTextBoxColumn
      // 
      this.tipoPrendaDataGridViewTextBoxColumn.DataPropertyName = "TipoPrenda";
      this.tipoPrendaDataGridViewTextBoxColumn.HeaderText = "Tipo de Prenda";
      this.tipoPrendaDataGridViewTextBoxColumn.Name = "tipoPrendaDataGridViewTextBoxColumn";
      this.tipoPrendaDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // pedirDataGridViewTextBoxColumn
      // 
      this.pedirDataGridViewTextBoxColumn.DataPropertyName = "Pedir";
      this.pedirDataGridViewTextBoxColumn.HeaderText = "Cantidad Pedida";
      this.pedirDataGridViewTextBoxColumn.Name = "pedirDataGridViewTextBoxColumn";
      this.pedirDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // ePKspPedidoSugeridoTotalesResultBindingSource
      // 
      this.ePKspPedidoSugeridoTotalesResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_PedidoSugeridoTotales_Result);
      // 
      // dataGridViewPedido
      // 
      this.dataGridViewPedido.AllowUserToAddRows = false;
      this.dataGridViewPedido.AllowUserToDeleteRows = false;
      this.dataGridViewPedido.AllowUserToResizeColumns = false;
      this.dataGridViewPedido.AllowUserToResizeRows = false;
      this.dataGridViewPedido.ColumnHeadersHeight = 21;
      this.dataGridViewPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FotoPequena,
            this.Referencia,
            this.Codigo,
            this.Descripcion,
            this.CodigoTalla,
            this.CodigoColor,
            this.DescripcionGenero,
            this.EnTienda,
            this.Pedir,
            this.EnAlmacen});
      this.dataGridViewPedido.Dock = System.Windows.Forms.DockStyle.Left;
      this.dataGridViewPedido.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewPedido.Name = "dataGridViewPedido";
      this.dataGridViewPedido.RowHeadersVisible = false;
      this.dataGridViewPedido.RowHeadersWidth = 80;
      this.dataGridViewPedido.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dataGridViewPedido.RowTemplate.Height = 80;
      this.dataGridViewPedido.Size = new System.Drawing.Size(919, 546);
      this.dataGridViewPedido.TabIndex = 23;
      this.dataGridViewPedido.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewExistenciaTienda_CellBeginEdit);
      // 
      // FotoPequena
      // 
      this.FotoPequena.DataPropertyName = "FotoPequena";
      this.FotoPequena.HeaderText = "Foto";
      this.FotoPequena.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
      this.FotoPequena.Name = "FotoPequena";
      this.FotoPequena.ReadOnly = true;
      // 
      // Referencia
      // 
      this.Referencia.DataPropertyName = "Referencia";
      this.Referencia.HeaderText = "Referencia";
      this.Referencia.Name = "Referencia";
      this.Referencia.ReadOnly = true;
      // 
      // Codigo
      // 
      this.Codigo.DataPropertyName = "Codigo";
      this.Codigo.HeaderText = "Código Artículo";
      this.Codigo.Name = "Codigo";
      this.Codigo.ReadOnly = true;
      // 
      // Descripcion
      // 
      this.Descripcion.DataPropertyName = "Descripcion";
      this.Descripcion.HeaderText = "Descripción";
      this.Descripcion.Name = "Descripcion";
      this.Descripcion.ReadOnly = true;
      this.Descripcion.Width = 120;
      // 
      // CodigoTalla
      // 
      this.CodigoTalla.DataPropertyName = "CodigoTalla";
      this.CodigoTalla.HeaderText = "Talla";
      this.CodigoTalla.Name = "CodigoTalla";
      this.CodigoTalla.ReadOnly = true;
      this.CodigoTalla.Width = 40;
      // 
      // CodigoColor
      // 
      this.CodigoColor.DataPropertyName = "CodigoColor";
      this.CodigoColor.HeaderText = "Color";
      this.CodigoColor.Name = "CodigoColor";
      this.CodigoColor.ReadOnly = true;
      this.CodigoColor.Width = 40;
      // 
      // DescripcionGenero
      // 
      this.DescripcionGenero.DataPropertyName = "DescripcionGenero";
      this.DescripcionGenero.HeaderText = "Género";
      this.DescripcionGenero.Name = "DescripcionGenero";
      this.DescripcionGenero.ReadOnly = true;
      // 
      // EnTienda
      // 
      this.EnTienda.DataPropertyName = "EnTienda";
      this.EnTienda.HeaderText = "En Tienda";
      this.EnTienda.Name = "EnTienda";
      this.EnTienda.ReadOnly = true;
      // 
      // Pedir
      // 
      this.Pedir.DataPropertyName = "Pedir";
      this.Pedir.HeaderText = "Pedido";
      this.Pedir.Name = "Pedir";
      this.Pedir.ReadOnly = true;
      // 
      // EnAlmacen
      // 
      this.EnAlmacen.DataPropertyName = "EnAlmacen";
      this.EnAlmacen.HeaderText = "En Almacen";
      this.EnAlmacen.Name = "EnAlmacen";
      this.EnAlmacen.ReadOnly = true;
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(983, 331);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(61, 13);
      this.label12.TabIndex = 22;
      this.label12.Text = "% de Stock";
      // 
      // textBoxPorconped
      // 
      this.textBoxPorconped.Location = new System.Drawing.Point(1048, 328);
      this.textBoxPorconped.Name = "textBoxPorconped";
      this.textBoxPorconped.ReadOnly = true;
      this.textBoxPorconped.Size = new System.Drawing.Size(124, 20);
      this.textBoxPorconped.TabIndex = 21;
      this.textBoxPorconped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxExistenciaped
      // 
      this.textBoxExistenciaped.Location = new System.Drawing.Point(1048, 302);
      this.textBoxExistenciaped.Name = "textBoxExistenciaped";
      this.textBoxExistenciaped.ReadOnly = true;
      this.textBoxExistenciaped.Size = new System.Drawing.Size(124, 20);
      this.textBoxExistenciaped.TabIndex = 19;
      this.textBoxExistenciaped.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxPorcentajeST
      // 
      this.textBoxPorcentajeST.Location = new System.Drawing.Point(1048, 277);
      this.textBoxPorcentajeST.Name = "textBoxPorcentajeST";
      this.textBoxPorcentajeST.ReadOnly = true;
      this.textBoxPorcentajeST.Size = new System.Drawing.Size(124, 20);
      this.textBoxPorcentajeST.TabIndex = 17;
      this.textBoxPorcentajeST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxExiActual
      // 
      this.textBoxExiActual.Location = new System.Drawing.Point(1048, 251);
      this.textBoxExiActual.Name = "textBoxExiActual";
      this.textBoxExiActual.ReadOnly = true;
      this.textBoxExiActual.Size = new System.Drawing.Size(124, 20);
      this.textBoxExiActual.TabIndex = 15;
      this.textBoxExiActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxPiezasVen
      // 
      this.textBoxPiezasVen.Location = new System.Drawing.Point(1048, 225);
      this.textBoxPiezasVen.Name = "textBoxPiezasVen";
      this.textBoxPiezasVen.ReadOnly = true;
      this.textBoxPiezasVen.Size = new System.Drawing.Size(124, 20);
      this.textBoxPiezasVen.TabIndex = 13;
      this.textBoxPiezasVen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // textBoxExiDynamics
      // 
      this.textBoxExiDynamics.Location = new System.Drawing.Point(1048, 199);
      this.textBoxExiDynamics.Name = "textBoxExiDynamics";
      this.textBoxExiDynamics.ReadOnly = true;
      this.textBoxExiDynamics.Size = new System.Drawing.Size(124, 20);
      this.textBoxExiDynamics.TabIndex = 11;
      this.textBoxExiDynamics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(947, 305);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(97, 13);
      this.label13.TabIndex = 20;
      this.label13.Text = "Existencia +Pedido";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(983, 280);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(61, 13);
      this.label11.TabIndex = 18;
      this.label11.Text = "% de Stock";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(956, 254);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(88, 13);
      this.label10.TabIndex = 16;
      this.label10.Text = "Existencia Actual";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(959, 228);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(85, 13);
      this.label9.TabIndex = 14;
      this.label9.Text = "Piezas Vendidas";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(940, 202);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(104, 13);
      this.label8.TabIndex = 12;
      this.label8.Text = "Existencia Dynamics";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.pictureBox1);
      this.tabPage2.Controls.Add(this.txtExistencia);
      this.tabPage2.Controls.Add(this.label15);
      this.tabPage2.Controls.Add(this.dataGridViewExistenciaTienda);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1181, 552);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Existencias";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // txtExistencia
      // 
      this.txtExistencia.Location = new System.Drawing.Point(1034, 470);
      this.txtExistencia.Name = "txtExistencia";
      this.txtExistencia.ReadOnly = true;
      this.txtExistencia.Size = new System.Drawing.Size(124, 20);
      this.txtExistencia.TabIndex = 17;
      this.txtExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(947, 473);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(82, 13);
      this.label15.TabIndex = 18;
      this.label15.Text = "Existencia Total";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.progreso;
      this.pictureBox1.Location = new System.Drawing.Point(575, 233);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(72, 70);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Visible = false;
      this.pictureBox1.WaitOnLoad = true;
      // 
      // dataGridViewExistenciaTienda
      // 
      this.dataGridViewExistenciaTienda.AllowUserToAddRows = false;
      this.dataGridViewExistenciaTienda.AllowUserToDeleteRows = false;
      this.dataGridViewExistenciaTienda.AllowUserToResizeColumns = false;
      this.dataGridViewExistenciaTienda.AllowUserToResizeRows = false;
      this.dataGridViewExistenciaTienda.AutoGenerateColumns = false;
      this.dataGridViewExistenciaTienda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewExistenciaTienda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Foto,
            this.CodigoReferencia,
            this.codigoArticuloDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.Venta,
            this.existenciaDataGridViewTextBoxColumn,
            this.ExistenciaAlmacen,
            this.activoDataGridViewCheckBoxColumn,
            this.exentoDataGridViewCheckBoxColumn});
      this.dataGridViewExistenciaTienda.DataSource = this.ePKArticuloBindingSource;
      this.dataGridViewExistenciaTienda.Dock = System.Windows.Forms.DockStyle.Top;
      this.dataGridViewExistenciaTienda.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewExistenciaTienda.Name = "dataGridViewExistenciaTienda";
      this.dataGridViewExistenciaTienda.ReadOnly = true;
      this.dataGridViewExistenciaTienda.RowHeadersVisible = false;
      this.dataGridViewExistenciaTienda.RowHeadersWidth = 80;
      this.dataGridViewExistenciaTienda.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dataGridViewExistenciaTienda.RowTemplate.Height = 80;
      this.dataGridViewExistenciaTienda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewExistenciaTienda.Size = new System.Drawing.Size(1175, 458);
      this.dataGridViewExistenciaTienda.TabIndex = 2;
      this.dataGridViewExistenciaTienda.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewExistenciaTienda_CellBeginEdit);
      // 
      // Foto
      // 
      this.Foto.DataPropertyName = "Foto";
      this.Foto.HeaderText = "Foto";
      this.Foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
      this.Foto.Name = "Foto";
      this.Foto.ReadOnly = true;
      // 
      // CodigoReferencia
      // 
      this.CodigoReferencia.DataPropertyName = "CodigoReferencia";
      this.CodigoReferencia.HeaderText = "Referencia";
      this.CodigoReferencia.Name = "CodigoReferencia";
      this.CodigoReferencia.ReadOnly = true;
      // 
      // codigoArticuloDataGridViewTextBoxColumn
      // 
      this.codigoArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodigoArticulo";
      this.codigoArticuloDataGridViewTextBoxColumn.HeaderText = "Código Artículo";
      this.codigoArticuloDataGridViewTextBoxColumn.Name = "codigoArticuloDataGridViewTextBoxColumn";
      this.codigoArticuloDataGridViewTextBoxColumn.ReadOnly = true;
      this.codigoArticuloDataGridViewTextBoxColumn.Width = 150;
      // 
      // descripcionDataGridViewTextBoxColumn
      // 
      this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
      this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
      this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
      this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
      this.descripcionDataGridViewTextBoxColumn.Width = 350;
      // 
      // Venta
      // 
      this.Venta.DataPropertyName = "Venta";
      this.Venta.HeaderText = "Ventas";
      this.Venta.Name = "Venta";
      this.Venta.ReadOnly = true;
      // 
      // existenciaDataGridViewTextBoxColumn
      // 
      this.existenciaDataGridViewTextBoxColumn.DataPropertyName = "Existencia";
      this.existenciaDataGridViewTextBoxColumn.HeaderText = "Existencia";
      this.existenciaDataGridViewTextBoxColumn.Name = "existenciaDataGridViewTextBoxColumn";
      this.existenciaDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // ExistenciaAlmacen
      // 
      this.ExistenciaAlmacen.DataPropertyName = "ExistenciaAlmacen";
      this.ExistenciaAlmacen.HeaderText = "Existencia Almacen";
      this.ExistenciaAlmacen.Name = "ExistenciaAlmacen";
      this.ExistenciaAlmacen.ReadOnly = true;
      this.ExistenciaAlmacen.Width = 120;
      // 
      // activoDataGridViewCheckBoxColumn
      // 
      this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
      this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
      this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
      this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
      this.activoDataGridViewCheckBoxColumn.Width = 50;
      // 
      // exentoDataGridViewCheckBoxColumn
      // 
      this.exentoDataGridViewCheckBoxColumn.DataPropertyName = "Exento";
      this.exentoDataGridViewCheckBoxColumn.HeaderText = "Exento";
      this.exentoDataGridViewCheckBoxColumn.Name = "exentoDataGridViewCheckBoxColumn";
      this.exentoDataGridViewCheckBoxColumn.ReadOnly = true;
      this.exentoDataGridViewCheckBoxColumn.Width = 50;
      // 
      // ePKArticuloBindingSource
      // 
      this.ePKArticuloBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_Articulo);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage5);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(1189, 578);
      this.tabControl1.TabIndex = 7;
      this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.btnExportarVentas);
      this.tabPage1.Controls.Add(this.txtDevolucion);
      this.tabPage1.Controls.Add(this.label14);
      this.tabPage1.Controls.Add(this.txtVendido);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.pbVentas);
      this.tabPage1.Controls.Add(this.dataGridViewVentas);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1181, 552);
      this.tabPage1.TabIndex = 5;
      this.tabPage1.Text = "Ventas";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // btnExportarVentas
      // 
      this.btnExportarVentas.Image = global::SEGAN_POS.Properties.Resources.excel;
      this.btnExportarVentas.Location = new System.Drawing.Point(1092, 508);
      this.btnExportarVentas.Name = "btnExportarVentas";
      this.btnExportarVentas.Size = new System.Drawing.Size(81, 31);
      this.btnExportarVentas.TabIndex = 27;
      this.btnExportarVentas.Text = "Exportar";
      this.btnExportarVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnExportarVentas.UseVisualStyleBackColor = true;
      this.btnExportarVentas.Click += new System.EventHandler(this.btnExportarVentas_Click);
      // 
      // txtDevolucion
      // 
      this.txtDevolucion.Location = new System.Drawing.Point(811, 470);
      this.txtDevolucion.Name = "txtDevolucion";
      this.txtDevolucion.ReadOnly = true;
      this.txtDevolucion.Size = new System.Drawing.Size(124, 20);
      this.txtDevolucion.TabIndex = 17;
      this.txtDevolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label14
      // 
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(703, 473);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(99, 13);
      this.label14.TabIndex = 18;
      this.label14.Text = "Total Devoluciones";
      // 
      // txtVendido
      // 
      this.txtVendido.Location = new System.Drawing.Point(1049, 470);
      this.txtVendido.Name = "txtVendido";
      this.txtVendido.ReadOnly = true;
      this.txtVendido.Size = new System.Drawing.Size(124, 20);
      this.txtVendido.TabIndex = 15;
      this.txtVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(944, 473);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(85, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Piezas Vendidas";
      // 
      // pbVentas
      // 
      this.pbVentas.Image = global::SEGAN_POS.Properties.Resources.progreso;
      this.pbVentas.Location = new System.Drawing.Point(575, 233);
      this.pbVentas.Name = "pbVentas";
      this.pbVentas.Size = new System.Drawing.Size(72, 70);
      this.pbVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pbVentas.TabIndex = 4;
      this.pbVentas.TabStop = false;
      this.pbVentas.Visible = false;
      this.pbVentas.WaitOnLoad = true;
      // 
      // dataGridViewVentas
      // 
      this.dataGridViewVentas.AllowUserToAddRows = false;
      this.dataGridViewVentas.AllowUserToDeleteRows = false;
      this.dataGridViewVentas.AllowUserToResizeColumns = false;
      this.dataGridViewVentas.AllowUserToResizeRows = false;
      this.dataGridViewVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dataGridViewVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FotoPeq,
            this.CodReferencia,
            this.CodArticulo,
            this.Descrip,
            this.Fecha,
            this.IdFactura,
            this.Ventas});
      this.dataGridViewVentas.Dock = System.Windows.Forms.DockStyle.Top;
      this.dataGridViewVentas.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewVentas.Name = "dataGridViewVentas";
      this.dataGridViewVentas.ReadOnly = true;
      this.dataGridViewVentas.RowHeadersVisible = false;
      this.dataGridViewVentas.RowHeadersWidth = 80;
      this.dataGridViewVentas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dataGridViewVentas.RowTemplate.Height = 80;
      this.dataGridViewVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewVentas.Size = new System.Drawing.Size(1175, 458);
      this.dataGridViewVentas.TabIndex = 3;
      // 
      // FotoPeq
      // 
      this.FotoPeq.DataPropertyName = "FotoPeq";
      this.FotoPeq.HeaderText = "Foto";
      this.FotoPeq.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
      this.FotoPeq.Name = "FotoPeq";
      this.FotoPeq.ReadOnly = true;
      // 
      // CodReferencia
      // 
      this.CodReferencia.DataPropertyName = "CodReferencia";
      this.CodReferencia.HeaderText = "Referencia";
      this.CodReferencia.Name = "CodReferencia";
      this.CodReferencia.ReadOnly = true;
      // 
      // CodArticulo
      // 
      this.CodArticulo.DataPropertyName = "CodArticulo";
      this.CodArticulo.HeaderText = "Código Artículo";
      this.CodArticulo.Name = "CodArticulo";
      this.CodArticulo.ReadOnly = true;
      // 
      // Descrip
      // 
      this.Descrip.DataPropertyName = "Descrip";
      this.Descrip.HeaderText = "Descripción";
      this.Descrip.Name = "Descrip";
      this.Descrip.ReadOnly = true;
      this.Descrip.Width = 350;
      // 
      // Fecha
      // 
      this.Fecha.DataPropertyName = "Fecha";
      this.Fecha.HeaderText = "Fecha";
      this.Fecha.Name = "Fecha";
      this.Fecha.ReadOnly = true;
      // 
      // IdFactura
      // 
      this.IdFactura.DataPropertyName = "IdFactura";
      this.IdFactura.HeaderText = "Id Factura";
      this.IdFactura.Name = "IdFactura";
      this.IdFactura.ReadOnly = true;
      // 
      // Ventas
      // 
      this.Ventas.DataPropertyName = "Ventas";
      this.Ventas.HeaderText = "Ventas";
      this.Ventas.Name = "Ventas";
      this.Ventas.ReadOnly = true;
      // 
      // backgroundWorkerExist
      // 
      this.backgroundWorkerExist.WorkerReportsProgress = true;
      this.backgroundWorkerExist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExist_DoWork);
      this.backgroundWorkerExist.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerExist_ProgressChanged);
      this.backgroundWorkerExist.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExist_RunWorkerCompleted);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1189, 72);
      this.panel1.TabIndex = 8;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.tabControl1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 72);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1189, 578);
      this.panel2.TabIndex = 9;
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xlsx";
      this.saveFileDialog1.Filter = "Excel|*.xlsx";
      this.saveFileDialog1.Title = "Exportar Facturas";
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk_1);
      // 
      // backgroundWorkerPedido
      // 
      this.backgroundWorkerPedido.WorkerReportsProgress = true;
      this.backgroundWorkerPedido.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPedido_DoWork);
      this.backgroundWorkerPedido.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPedido_RunWorkerCompleted);
      // 
      // backgroundWorkerExportPedido
      // 
      this.backgroundWorkerExportPedido.WorkerReportsProgress = true;
      this.backgroundWorkerExportPedido.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExportPedido_DoWork);
      this.backgroundWorkerExportPedido.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExportPedido_RunWorkerCompleted);
      // 
      // frmPedidoSugerido
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1189, 650);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmPedidoSugerido";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmPedidoSugerido";
      this.Activated += new System.EventHandler(this.frmPedidoSugerido_Activated);
      this.Load += new System.EventHandler(this.frmPedidoSugerido_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPidoEntre5y)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudEntre5y)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPidoMenosDe)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMenosDe)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbPedido)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ePKspPedidoSugeridoTotalesResultBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedido)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistenciaTienda)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ePKArticuloBindingSource)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbColeccion;
        private System.Windows.Forms.Button btBuscarArt;
        private System.Windows.Forms.BindingSource ePKArticuloBindingSource;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPorconped;
        private System.Windows.Forms.TextBox textBoxExistenciaped;
        private System.Windows.Forms.TextBox textBoxPorcentajeST;
        private System.Windows.Forms.TextBox textBoxExiActual;
        private System.Windows.Forms.TextBox textBoxPiezasVen;
        private System.Windows.Forms.TextBox textBoxExiDynamics;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewExistenciaTienda;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewImageColumn Foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn existenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistenciaAlmacen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn exentoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btProcesar;
        private System.Windows.Forms.DataGridView dataGridViewPedido;
        private System.Windows.Forms.NumericUpDown nudPidoEntre5y;
        private System.Windows.Forms.NumericUpDown nudEntre5y;
        private System.Windows.Forms.NumericUpDown nudPidoMenosDe;
        private System.Windows.Forms.NumericUpDown nudMenosDe;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExist;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewVentas;
        private System.Windows.Forms.PictureBox pbVentas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Act;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewImageColumn FotoPequena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnTienda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pedir;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnAlmacen;
        private System.Windows.Forms.PictureBox pbPedido;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtDevolucion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVendido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewImageColumn FotoPeq;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ventas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPrendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedirDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ePKspPedidoSugeridoTotalesResultBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCapacidad;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnExportarVentas;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPedido;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportPedido;
    }
}