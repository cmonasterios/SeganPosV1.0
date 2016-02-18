namespace SEGAN_POS
{
    partial class frmCierreVentas
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.btAjustar = new System.Windows.Forms.Button();
      this.label9 = new System.Windows.Forms.Label();
      this.txDifEfectivo = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txMontoCierre = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txTotalAlivios = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txTotalRecibido = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txMontoApertura = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.grdCierreOtrosPagos = new System.Windows.Forms.DataGridView();
      this.idFormaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.formaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalMontoSistemaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalMontoCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.diferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cierreVentasOtrosPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
      this.txCierresPend = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.txtlEfectivoCierre = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.txtlOtrosPagosCierre = new System.Windows.Forms.TextBox();
      this.txObs = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txTotalSistema = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.txTotalOtros = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.txTotalCierre = new System.Windows.Forms.TextBox();
      this.txDiferencia = new System.Windows.Forms.TextBox();
      this.txTotalEfectivo = new System.Windows.Forms.TextBox();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.grdCierreOtrosPagos)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cierreVentasOtrosPagosBindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(32, 59);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 28);
      this.label1.TabIndex = 28;
      this.label1.Text = "Cierres Pendientes";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.btAjustar);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.txDifEfectivo);
      this.groupBox1.Controls.Add(this.label8);
      this.groupBox1.Controls.Add(this.txMontoCierre);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.txTotalAlivios);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txTotalRecibido);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.txMontoApertura);
      this.groupBox1.Location = new System.Drawing.Point(223, 8);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(607, 108);
      this.groupBox1.TabIndex = 31;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Efectivo";
      // 
      // btAjustar
      // 
      this.btAjustar.CausesValidation = false;
      this.btAjustar.Image = global::SEGAN_POS.Properties.Resources.editar;
      this.btAjustar.Location = new System.Drawing.Point(285, 43);
      this.btAjustar.Name = "btAjustar";
      this.btAjustar.Size = new System.Drawing.Size(31, 28);
      this.btAjustar.TabIndex = 80;
      this.btAjustar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btAjustar.UseVisualStyleBackColor = true;
      this.btAjustar.Click += new System.EventHandler(this.btAjustar_Click);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(44, 77);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(55, 13);
      this.label9.TabIndex = 31;
      this.label9.Text = "Diferencia";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txDifEfectivo
      // 
      this.txDifEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txDifEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txDifEfectivo.Location = new System.Drawing.Point(103, 73);
      this.txDifEfectivo.Name = "txDifEfectivo";
      this.txDifEfectivo.ReadOnly = true;
      this.txDifEfectivo.Size = new System.Drawing.Size(168, 20);
      this.txDifEfectivo.TabIndex = 30;
      this.txDifEfectivo.TabStop = false;
      this.txDifEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(38, 51);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(61, 13);
      this.label8.TabIndex = 29;
      this.label8.Text = "Total Cierre";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txMontoCierre
      // 
      this.txMontoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txMontoCierre.Location = new System.Drawing.Point(103, 47);
      this.txMontoCierre.Name = "txMontoCierre";
      this.txMontoCierre.ReadOnly = true;
      this.txMontoCierre.Size = new System.Drawing.Size(168, 20);
      this.txMontoCierre.TabIndex = 28;
      this.txMontoCierre.TabStop = false;
      this.txMontoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(348, 51);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(79, 13);
      this.label7.TabIndex = 27;
      this.label7.Text = "Total de Alivios";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalAlivios
      // 
      this.txTotalAlivios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalAlivios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalAlivios.Location = new System.Drawing.Point(433, 47);
      this.txTotalAlivios.Name = "txTotalAlivios";
      this.txTotalAlivios.ReadOnly = true;
      this.txTotalAlivios.Size = new System.Drawing.Size(168, 20);
      this.txTotalAlivios.TabIndex = 26;
      this.txTotalAlivios.TabStop = false;
      this.txTotalAlivios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 25);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(82, 13);
      this.label3.TabIndex = 25;
      this.label3.Text = "Total Facturado";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalRecibido
      // 
      this.txTotalRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalRecibido.Location = new System.Drawing.Point(103, 21);
      this.txTotalRecibido.Name = "txTotalRecibido";
      this.txTotalRecibido.ReadOnly = true;
      this.txTotalRecibido.Size = new System.Drawing.Size(168, 20);
      this.txTotalRecibido.TabIndex = 24;
      this.txTotalRecibido.TabStop = false;
      this.txTotalRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(327, 25);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 13);
      this.label2.TabIndex = 23;
      this.label2.Text = "Monto de Aperturas";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txMontoApertura
      // 
      this.txMontoApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txMontoApertura.Location = new System.Drawing.Point(433, 21);
      this.txMontoApertura.Name = "txMontoApertura";
      this.txMontoApertura.ReadOnly = true;
      this.txMontoApertura.Size = new System.Drawing.Size(168, 20);
      this.txMontoApertura.TabIndex = 22;
      this.txMontoApertura.TabStop = false;
      this.txMontoApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.grdCierreOtrosPagos);
      this.groupBox2.Location = new System.Drawing.Point(11, 122);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(820, 246);
      this.groupBox2.TabIndex = 32;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Otros Pagos";
      // 
      // grdCierreOtrosPagos
      // 
      this.grdCierreOtrosPagos.AllowUserToResizeColumns = false;
      this.grdCierreOtrosPagos.AllowUserToResizeRows = false;
      this.grdCierreOtrosPagos.AutoGenerateColumns = false;
      this.grdCierreOtrosPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdCierreOtrosPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFormaPagoDataGridViewTextBoxColumn,
            this.formaPagoDataGridViewTextBoxColumn,
            this.idPOSDataGridViewTextBoxColumn,
            this.pOSDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.totalMontoSistemaDataGridViewTextBoxColumn,
            this.totalMontoCierreDataGridViewTextBoxColumn,
            this.diferenciaDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn});
      this.grdCierreOtrosPagos.DataSource = this.cierreVentasOtrosPagosBindingSource;
      this.grdCierreOtrosPagos.Location = new System.Drawing.Point(6, 19);
      this.grdCierreOtrosPagos.Name = "grdCierreOtrosPagos";
      this.grdCierreOtrosPagos.RowHeadersVisible = false;
      this.grdCierreOtrosPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grdCierreOtrosPagos.Size = new System.Drawing.Size(808, 221);
      this.grdCierreOtrosPagos.TabIndex = 0;
      this.grdCierreOtrosPagos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdCierreOtrosPagos_CellBeginEdit);
      this.grdCierreOtrosPagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCierreOtrosPagos_CellDoubleClick);
      this.grdCierreOtrosPagos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdCierreOtrosPagos_DataError);
      // 
      // idFormaPagoDataGridViewTextBoxColumn
      // 
      this.idFormaPagoDataGridViewTextBoxColumn.DataPropertyName = "IdFormaPago";
      this.idFormaPagoDataGridViewTextBoxColumn.HeaderText = "IdFormaPago";
      this.idFormaPagoDataGridViewTextBoxColumn.Name = "idFormaPagoDataGridViewTextBoxColumn";
      this.idFormaPagoDataGridViewTextBoxColumn.Visible = false;
      // 
      // formaPagoDataGridViewTextBoxColumn
      // 
      this.formaPagoDataGridViewTextBoxColumn.DataPropertyName = "FormaPago";
      this.formaPagoDataGridViewTextBoxColumn.HeaderText = "Forma Pago";
      this.formaPagoDataGridViewTextBoxColumn.Name = "formaPagoDataGridViewTextBoxColumn";
      this.formaPagoDataGridViewTextBoxColumn.ReadOnly = true;
      this.formaPagoDataGridViewTextBoxColumn.Width = 105;
      // 
      // idPOSDataGridViewTextBoxColumn
      // 
      this.idPOSDataGridViewTextBoxColumn.DataPropertyName = "IdPOS";
      this.idPOSDataGridViewTextBoxColumn.HeaderText = "IdPOS";
      this.idPOSDataGridViewTextBoxColumn.Name = "idPOSDataGridViewTextBoxColumn";
      this.idPOSDataGridViewTextBoxColumn.Visible = false;
      // 
      // pOSDataGridViewTextBoxColumn
      // 
      this.pOSDataGridViewTextBoxColumn.DataPropertyName = "POS";
      this.pOSDataGridViewTextBoxColumn.HeaderText = "POS";
      this.pOSDataGridViewTextBoxColumn.Name = "pOSDataGridViewTextBoxColumn";
      this.pOSDataGridViewTextBoxColumn.ReadOnly = true;
      this.pOSDataGridViewTextBoxColumn.Width = 125;
      // 
      // loteDataGridViewTextBoxColumn
      // 
      this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
      dataGridViewCellStyle5.NullValue = null;
      this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
      this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
      this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
      this.loteDataGridViewTextBoxColumn.ReadOnly = true;
      this.loteDataGridViewTextBoxColumn.Width = 50;
      // 
      // totalMontoSistemaDataGridViewTextBoxColumn
      // 
      this.totalMontoSistemaDataGridViewTextBoxColumn.DataPropertyName = "TotalMontoSistema";
      dataGridViewCellStyle6.Format = "N2";
      dataGridViewCellStyle6.NullValue = null;
      this.totalMontoSistemaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
      this.totalMontoSistemaDataGridViewTextBoxColumn.HeaderText = "Monto Sistema";
      this.totalMontoSistemaDataGridViewTextBoxColumn.Name = "totalMontoSistemaDataGridViewTextBoxColumn";
      this.totalMontoSistemaDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalMontoSistemaDataGridViewTextBoxColumn.Width = 125;
      // 
      // totalMontoCierreDataGridViewTextBoxColumn
      // 
      this.totalMontoCierreDataGridViewTextBoxColumn.DataPropertyName = "TotalMontoCierre";
      dataGridViewCellStyle7.Format = "N2";
      dataGridViewCellStyle7.NullValue = null;
      this.totalMontoCierreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
      this.totalMontoCierreDataGridViewTextBoxColumn.HeaderText = "Monto Cierre";
      this.totalMontoCierreDataGridViewTextBoxColumn.Name = "totalMontoCierreDataGridViewTextBoxColumn";
      this.totalMontoCierreDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalMontoCierreDataGridViewTextBoxColumn.Width = 125;
      // 
      // diferenciaDataGridViewTextBoxColumn
      // 
      this.diferenciaDataGridViewTextBoxColumn.DataPropertyName = "Diferencia";
      dataGridViewCellStyle8.Format = "N2";
      dataGridViewCellStyle8.NullValue = null;
      this.diferenciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
      this.diferenciaDataGridViewTextBoxColumn.HeaderText = "Diferencia";
      this.diferenciaDataGridViewTextBoxColumn.Name = "diferenciaDataGridViewTextBoxColumn";
      this.diferenciaDataGridViewTextBoxColumn.ReadOnly = true;
      this.diferenciaDataGridViewTextBoxColumn.Width = 75;
      // 
      // observacionesDataGridViewTextBoxColumn
      // 
      this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
      this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
      this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
      this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
      this.observacionesDataGridViewTextBoxColumn.Width = 200;
      // 
      // cierreVentasOtrosPagosBindingSource
      // 
      this.cierreVentasOtrosPagosBindingSource.DataSource = typeof(SEGAN_POS.DAL.CierreVentasOtrosPagos);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(742, 155);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(82, 33);
      this.btCancel.TabIndex = 41;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(654, 155);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 40;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(459, 125);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 49;
      this.label4.Text = "Diferencia";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(29, 33);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(67, 13);
      this.label6.TabIndex = 52;
      this.label6.Text = "Fecha Cierre";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpFechaCierre
      // 
      this.dtpFechaCierre.CausesValidation = false;
      this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpFechaCierre.Location = new System.Drawing.Point(102, 31);
      this.dtpFechaCierre.Name = "dtpFechaCierre";
      this.dtpFechaCierre.Size = new System.Drawing.Size(105, 20);
      this.dtpFechaCierre.TabIndex = 54;
      this.dtpFechaCierre.ValueChanged += new System.EventHandler(this.dtpFechaCierre_ValueChanged);
      // 
      // txCierresPend
      // 
      this.txCierresPend.BackColor = System.Drawing.SystemColors.Control;
      this.txCierresPend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txCierresPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
      this.txCierresPend.Location = new System.Drawing.Point(102, 63);
      this.txCierresPend.MaxLength = 3;
      this.txCierresPend.Name = "txCierresPend";
      this.txCierresPend.ReadOnly = true;
      this.txCierresPend.Size = new System.Drawing.Size(43, 21);
      this.txCierresPend.TabIndex = 56;
      this.txCierresPend.TabStop = false;
      this.txCierresPend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.txtlEfectivoCierre);
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.txtlOtrosPagosCierre);
      this.panel1.Controls.Add(this.txObs);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.txTotalSistema);
      this.panel1.Controls.Add(this.label10);
      this.panel1.Controls.Add(this.label14);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label13);
      this.panel1.Controls.Add(this.btOK);
      this.panel1.Controls.Add(this.txTotalOtros);
      this.panel1.Controls.Add(this.btCancel);
      this.panel1.Controls.Add(this.label11);
      this.panel1.Controls.Add(this.txTotalCierre);
      this.panel1.Controls.Add(this.txDiferencia);
      this.panel1.Controls.Add(this.txTotalEfectivo);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 374);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(838, 200);
      this.panel1.TabIndex = 57;
      // 
      // txtlEfectivoCierre
      // 
      this.txtlEfectivoCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txtlEfectivoCierre.BackColor = System.Drawing.SystemColors.Control;
      this.txtlEfectivoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtlEfectivoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtlEfectivoCierre.Location = new System.Drawing.Point(629, 33);
      this.txtlEfectivoCierre.MaxLength = 10;
      this.txtlEfectivoCierre.Name = "txtlEfectivoCierre";
      this.txtlEfectivoCierre.ReadOnly = true;
      this.txtlEfectivoCierre.Size = new System.Drawing.Size(168, 20);
      this.txtlEfectivoCierre.TabIndex = 66;
      this.txtlEfectivoCierre.TabStop = false;
      this.txtlEfectivoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label12
      // 
      this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(18, 10);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(78, 13);
      this.label12.TabIndex = 57;
      this.label12.Text = "Observaciones";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtlOtrosPagosCierre
      // 
      this.txtlOtrosPagosCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txtlOtrosPagosCierre.BackColor = System.Drawing.SystemColors.Control;
      this.txtlOtrosPagosCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtlOtrosPagosCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtlOtrosPagosCierre.Location = new System.Drawing.Point(629, 62);
      this.txtlOtrosPagosCierre.MaxLength = 10;
      this.txtlOtrosPagosCierre.Name = "txtlOtrosPagosCierre";
      this.txtlOtrosPagosCierre.ReadOnly = true;
      this.txtlOtrosPagosCierre.Size = new System.Drawing.Size(168, 20);
      this.txtlOtrosPagosCierre.TabIndex = 64;
      this.txtlOtrosPagosCierre.TabStop = false;
      this.txtlOtrosPagosCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // txObs
      // 
      this.txObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.txObs.Location = new System.Drawing.Point(17, 32);
      this.txObs.MaxLength = 200;
      this.txObs.Multiline = true;
      this.txObs.Name = "txObs";
      this.txObs.Size = new System.Drawing.Size(269, 131);
      this.txObs.TabIndex = 1;
      this.txObs.TabStop = false;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(380, 93);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(31, 13);
      this.label5.TabIndex = 62;
      this.label5.Text = "Total";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalSistema
      // 
      this.txTotalSistema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txTotalSistema.BackColor = System.Drawing.SystemColors.Control;
      this.txTotalSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalSistema.Location = new System.Drawing.Point(419, 90);
      this.txTotalSistema.MaxLength = 10;
      this.txTotalSistema.Name = "txTotalSistema";
      this.txTotalSistema.ReadOnly = true;
      this.txTotalSistema.Size = new System.Drawing.Size(168, 20);
      this.txTotalSistema.TabIndex = 61;
      this.txTotalSistema.TabStop = false;
      this.txTotalSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label10
      // 
      this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(365, 37);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(46, 13);
      this.label10.TabIndex = 56;
      this.label10.Text = "Efectivo";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label14
      // 
      this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label14.AutoSize = true;
      this.label14.Location = new System.Drawing.Point(702, 11);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(34, 13);
      this.label14.TabIndex = 60;
      this.label14.Text = "Cierre";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(470, 11);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(44, 13);
      this.label13.TabIndex = 58;
      this.label13.Text = "Sistema";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txTotalOtros
      // 
      this.txTotalOtros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txTotalOtros.BackColor = System.Drawing.SystemColors.Control;
      this.txTotalOtros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalOtros.Location = new System.Drawing.Point(419, 61);
      this.txTotalOtros.MaxLength = 10;
      this.txTotalOtros.Name = "txTotalOtros";
      this.txTotalOtros.ReadOnly = true;
      this.txTotalOtros.Size = new System.Drawing.Size(168, 20);
      this.txTotalOtros.TabIndex = 59;
      this.txTotalOtros.TabStop = false;
      this.txTotalOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label11
      // 
      this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(346, 65);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(65, 13);
      this.label11.TabIndex = 58;
      this.label11.Text = "Otros Pagos";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalCierre
      // 
      this.txTotalCierre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txTotalCierre.BackColor = System.Drawing.SystemColors.Control;
      this.txTotalCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalCierre.Location = new System.Drawing.Point(629, 90);
      this.txTotalCierre.MaxLength = 10;
      this.txTotalCierre.Name = "txTotalCierre";
      this.txTotalCierre.ReadOnly = true;
      this.txTotalCierre.Size = new System.Drawing.Size(168, 20);
      this.txTotalCierre.TabIndex = 52;
      this.txTotalCierre.TabStop = false;
      this.txTotalCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // txDiferencia
      // 
      this.txDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txDiferencia.BackColor = System.Drawing.SystemColors.Control;
      this.txDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txDiferencia.Location = new System.Drawing.Point(520, 123);
      this.txDiferencia.MaxLength = 10;
      this.txDiferencia.Name = "txDiferencia";
      this.txDiferencia.ReadOnly = true;
      this.txDiferencia.Size = new System.Drawing.Size(168, 20);
      this.txDiferencia.TabIndex = 53;
      this.txDiferencia.TabStop = false;
      this.txDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // txTotalEfectivo
      // 
      this.txTotalEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txTotalEfectivo.BackColor = System.Drawing.SystemColors.Control;
      this.txTotalEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalEfectivo.Location = new System.Drawing.Point(419, 33);
      this.txTotalEfectivo.MaxLength = 10;
      this.txTotalEfectivo.Name = "txTotalEfectivo";
      this.txTotalEfectivo.ReadOnly = true;
      this.txTotalEfectivo.Size = new System.Drawing.Size(168, 20);
      this.txTotalEfectivo.TabIndex = 55;
      this.txTotalEfectivo.TabStop = false;
      this.txTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // errorProvider1
      // 
      this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
      this.errorProvider1.ContainerControl = this;
      // 
      // frmCierreVentas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(838, 574);
      this.Controls.Add(this.txCierresPend);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.dtpFechaCierre);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmCierreVentas";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Cierre de Ventas";
      this.Activated += new System.EventHandler(this.frmCierreVentas_Activated);
      this.Load += new System.EventHandler(this.frmCierreVentas_Load);
      this.Shown += new System.EventHandler(this.frmCierreVentas_Shown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.grdCierreOtrosPagos)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cierreVentasOtrosPagosBindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grdCierreOtrosPagos;
        private System.Windows.Forms.BindingSource cierreVentasOtrosPagosBindingSource;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaCierre;
        private System.Windows.Forms.TextBox txCierresPend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txTotalAlivios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txTotalRecibido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txMontoApertura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txDifEfectivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txMontoCierre;
        private System.Windows.Forms.Button btAjustar;
        private System.Windows.Forms.TextBox txDiferencia;
        private System.Windows.Forms.TextBox txTotalCierre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txTotalEfectivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txObs;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMontoSistemaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMontoCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txTotalOtros;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtlEfectivoCierre;
        private System.Windows.Forms.TextBox txtlOtrosPagosCierre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txTotalSistema;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}