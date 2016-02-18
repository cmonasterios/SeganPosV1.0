namespace SEGAN_POS
{
  partial class frmVerCierreVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtlEfectivoCierre = new System.Windows.Forms.TextBox();
            this.txtlOtrosPagosCierre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txTotalSistema = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txTotalOtros = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txTotalEfectivo = new System.Windows.Forms.TextBox();
            this.txDiferencia = new System.Windows.Forms.TextBox();
            this.txTotalCierre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txObsEf = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txDifEfectivo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txMontoCierre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txTotalRecibido = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbObs = new System.Windows.Forms.Label();
            this.txObs = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdCierreOtrosPagos = new System.Windows.Forms.DataGridView();
            this.idFormaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMontoSistemaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMontoCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cierreVentasOtrosPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txFecha = new System.Windows.Forms.TextBox();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCierreOtrosPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVentasOtrosPagosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(460, 145);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(71, 33);
            this.btCancel.TabIndex = 41;
            this.btCancel.Text = "Cerrar";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Fecha Cierre";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtlEfectivoCierre);
            this.panel2.Controls.Add(this.txtlOtrosPagosCierre);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txTotalSistema);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txTotalOtros);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txTotalEfectivo);
            this.panel2.Controls.Add(this.txDiferencia);
            this.panel2.Controls.Add(this.txTotalCierre);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(288, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 200);
            this.panel2.TabIndex = 0;
            // 
            // txtlEfectivoCierre
            // 
            this.txtlEfectivoCierre.BackColor = System.Drawing.SystemColors.Control;
            this.txtlEfectivoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlEfectivoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtlEfectivoCierre.Location = new System.Drawing.Point(318, 36);
            this.txtlEfectivoCierre.MaxLength = 10;
            this.txtlEfectivoCierre.Name = "txtlEfectivoCierre";
            this.txtlEfectivoCierre.ReadOnly = true;
            this.txtlEfectivoCierre.Size = new System.Drawing.Size(168, 22);
            this.txtlEfectivoCierre.TabIndex = 79;
            this.txtlEfectivoCierre.TabStop = false;
            this.txtlEfectivoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtlOtrosPagosCierre
            // 
            this.txtlOtrosPagosCierre.BackColor = System.Drawing.SystemColors.Control;
            this.txtlOtrosPagosCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlOtrosPagosCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtlOtrosPagosCierre.Location = new System.Drawing.Point(318, 65);
            this.txtlOtrosPagosCierre.MaxLength = 10;
            this.txtlOtrosPagosCierre.Name = "txtlOtrosPagosCierre";
            this.txtlOtrosPagosCierre.ReadOnly = true;
            this.txtlOtrosPagosCierre.Size = new System.Drawing.Size(168, 22);
            this.txtlOtrosPagosCierre.TabIndex = 78;
            this.txtlOtrosPagosCierre.TabStop = false;
            this.txtlOtrosPagosCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 77;
            this.label5.Text = "Total";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txTotalSistema
            // 
            this.txTotalSistema.BackColor = System.Drawing.SystemColors.Control;
            this.txTotalSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txTotalSistema.Location = new System.Drawing.Point(108, 93);
            this.txTotalSistema.MaxLength = 10;
            this.txTotalSistema.Name = "txTotalSistema";
            this.txTotalSistema.ReadOnly = true;
            this.txTotalSistema.Size = new System.Drawing.Size(168, 22);
            this.txTotalSistema.TabIndex = 76;
            this.txTotalSistema.TabStop = false;
            this.txTotalSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(391, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 75;
            this.label14.Text = "Cierre";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(159, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Sistema";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txTotalOtros
            // 
            this.txTotalOtros.BackColor = System.Drawing.SystemColors.Control;
            this.txTotalOtros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txTotalOtros.Location = new System.Drawing.Point(108, 64);
            this.txTotalOtros.MaxLength = 10;
            this.txTotalOtros.Name = "txTotalOtros";
            this.txTotalOtros.ReadOnly = true;
            this.txTotalOtros.Size = new System.Drawing.Size(168, 22);
            this.txTotalOtros.TabIndex = 74;
            this.txTotalOtros.TabStop = false;
            this.txTotalOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Otros Pagos";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Efectivo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txTotalEfectivo
            // 
            this.txTotalEfectivo.BackColor = System.Drawing.SystemColors.Control;
            this.txTotalEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txTotalEfectivo.Location = new System.Drawing.Point(108, 36);
            this.txTotalEfectivo.MaxLength = 10;
            this.txTotalEfectivo.Name = "txTotalEfectivo";
            this.txTotalEfectivo.ReadOnly = true;
            this.txTotalEfectivo.Size = new System.Drawing.Size(168, 22);
            this.txTotalEfectivo.TabIndex = 70;
            this.txTotalEfectivo.TabStop = false;
            this.txTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txDiferencia
            // 
            this.txDiferencia.BackColor = System.Drawing.SystemColors.Control;
            this.txDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.txDiferencia.Location = new System.Drawing.Point(209, 126);
            this.txDiferencia.MaxLength = 10;
            this.txDiferencia.Name = "txDiferencia";
            this.txDiferencia.ReadOnly = true;
            this.txDiferencia.Size = new System.Drawing.Size(168, 22);
            this.txDiferencia.TabIndex = 69;
            this.txDiferencia.TabStop = false;
            this.txDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txTotalCierre
            // 
            this.txTotalCierre.BackColor = System.Drawing.SystemColors.Control;
            this.txTotalCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txTotalCierre.Location = new System.Drawing.Point(318, 93);
            this.txTotalCierre.MaxLength = 10;
            this.txTotalCierre.Name = "txTotalCierre";
            this.txTotalCierre.ReadOnly = true;
            this.txTotalCierre.Size = new System.Drawing.Size(168, 22);
            this.txTotalCierre.TabIndex = 68;
            this.txTotalCierre.TabStop = false;
            this.txTotalCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Diferencia";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txObsEf);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txDifEfectivo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txMontoCierre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txTotalRecibido);
            this.groupBox1.Location = new System.Drawing.Point(236, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 108);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Efectivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Observaciones";
            // 
            // txObsEf
            // 
            this.txObsEf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txObsEf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txObsEf.Location = new System.Drawing.Point(289, 32);
            this.txObsEf.Multiline = true;
            this.txObsEf.Name = "txObsEf";
            this.txObsEf.ReadOnly = true;
            this.txObsEf.Size = new System.Drawing.Size(294, 61);
            this.txObsEf.TabIndex = 32;
            this.txObsEf.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Diferencia";
            // 
            // txDifEfectivo
            // 
            this.txDifEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txDifEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txDifEfectivo.Location = new System.Drawing.Point(97, 73);
            this.txDifEfectivo.Name = "txDifEfectivo";
            this.txDifEfectivo.ReadOnly = true;
            this.txDifEfectivo.Size = new System.Drawing.Size(168, 22);
            this.txDifEfectivo.TabIndex = 30;
            this.txDifEfectivo.TabStop = false;
            this.txDifEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Total Cierre";
            // 
            // txMontoCierre
            // 
            this.txMontoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMontoCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txMontoCierre.Location = new System.Drawing.Point(97, 47);
            this.txMontoCierre.Name = "txMontoCierre";
            this.txMontoCierre.ReadOnly = true;
            this.txMontoCierre.Size = new System.Drawing.Size(168, 22);
            this.txMontoCierre.TabIndex = 28;
            this.txMontoCierre.TabStop = false;
            this.txMontoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Total Facturado";
            // 
            // txTotalRecibido
            // 
            this.txTotalRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTotalRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txTotalRecibido.Location = new System.Drawing.Point(97, 21);
            this.txTotalRecibido.Name = "txTotalRecibido";
            this.txTotalRecibido.ReadOnly = true;
            this.txTotalRecibido.Size = new System.Drawing.Size(168, 22);
            this.txTotalRecibido.TabIndex = 24;
            this.txTotalRecibido.TabStop = false;
            this.txTotalRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbObs);
            this.panel1.Controls.Add(this.txObs);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 200);
            this.panel1.TabIndex = 64;
            // 
            // lbObs
            // 
            this.lbObs.AutoSize = true;
            this.lbObs.Location = new System.Drawing.Point(14, 12);
            this.lbObs.Name = "lbObs";
            this.lbObs.Size = new System.Drawing.Size(78, 13);
            this.lbObs.TabIndex = 59;
            this.lbObs.Text = "Observaciones";
            this.lbObs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbObs.Visible = false;
            // 
            // txObs
            // 
            this.txObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txObs.Location = new System.Drawing.Point(13, 28);
            this.txObs.MaxLength = 200;
            this.txObs.Multiline = true;
            this.txObs.Name = "txObs";
            this.txObs.ReadOnly = true;
            this.txObs.Size = new System.Drawing.Size(255, 143);
            this.txObs.TabIndex = 58;
            this.txObs.TabStop = false;
            this.txObs.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdCierreOtrosPagos);
            this.groupBox2.Location = new System.Drawing.Point(11, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 246);
            this.groupBox2.TabIndex = 60;
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
            this.totalMontoSistemaDataGridViewTextBoxColumn,
            this.totalMontoCierreDataGridViewTextBoxColumn,
            this.diferenciaDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn});
            this.grdCierreOtrosPagos.DataSource = this.cierreVentasOtrosPagosBindingSource;
            this.grdCierreOtrosPagos.Location = new System.Drawing.Point(6, 19);
            this.grdCierreOtrosPagos.Name = "grdCierreOtrosPagos";
            this.grdCierreOtrosPagos.ReadOnly = true;
            this.grdCierreOtrosPagos.RowHeadersVisible = false;
            this.grdCierreOtrosPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCierreOtrosPagos.Size = new System.Drawing.Size(808, 221);
            this.grdCierreOtrosPagos.TabIndex = 0;
            this.grdCierreOtrosPagos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdCierreOtrosPagos_CellBeginEdit);
            this.grdCierreOtrosPagos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdCierreOtrosPagos_DataError);
            // 
            // idFormaPagoDataGridViewTextBoxColumn
            // 
            this.idFormaPagoDataGridViewTextBoxColumn.DataPropertyName = "IdFormaPago";
            this.idFormaPagoDataGridViewTextBoxColumn.HeaderText = "IdFormaPago";
            this.idFormaPagoDataGridViewTextBoxColumn.Name = "idFormaPagoDataGridViewTextBoxColumn";
            this.idFormaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFormaPagoDataGridViewTextBoxColumn.Visible = false;
            // 
            // formaPagoDataGridViewTextBoxColumn
            // 
            this.formaPagoDataGridViewTextBoxColumn.DataPropertyName = "FormaPago";
            this.formaPagoDataGridViewTextBoxColumn.HeaderText = "Forma Pago";
            this.formaPagoDataGridViewTextBoxColumn.Name = "formaPagoDataGridViewTextBoxColumn";
            this.formaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.formaPagoDataGridViewTextBoxColumn.Width = 130;
            // 
            // idPOSDataGridViewTextBoxColumn
            // 
            this.idPOSDataGridViewTextBoxColumn.DataPropertyName = "IdPOS";
            this.idPOSDataGridViewTextBoxColumn.HeaderText = "IdPOS";
            this.idPOSDataGridViewTextBoxColumn.Name = "idPOSDataGridViewTextBoxColumn";
            this.idPOSDataGridViewTextBoxColumn.ReadOnly = true;
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
            // totalMontoSistemaDataGridViewTextBoxColumn
            // 
            this.totalMontoSistemaDataGridViewTextBoxColumn.DataPropertyName = "TotalMontoSistema";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.totalMontoSistemaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalMontoSistemaDataGridViewTextBoxColumn.HeaderText = "Monto Sistema";
            this.totalMontoSistemaDataGridViewTextBoxColumn.Name = "totalMontoSistemaDataGridViewTextBoxColumn";
            this.totalMontoSistemaDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalMontoSistemaDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalMontoCierreDataGridViewTextBoxColumn
            // 
            this.totalMontoCierreDataGridViewTextBoxColumn.DataPropertyName = "TotalMontoCierre";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.totalMontoCierreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalMontoCierreDataGridViewTextBoxColumn.HeaderText = "Monto Cierre";
            this.totalMontoCierreDataGridViewTextBoxColumn.Name = "totalMontoCierreDataGridViewTextBoxColumn";
            this.totalMontoCierreDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalMontoCierreDataGridViewTextBoxColumn.Width = 125;
            // 
            // diferenciaDataGridViewTextBoxColumn
            // 
            this.diferenciaDataGridViewTextBoxColumn.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.diferenciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.diferenciaDataGridViewTextBoxColumn.HeaderText = "Diferencia";
            this.diferenciaDataGridViewTextBoxColumn.Name = "diferenciaDataGridViewTextBoxColumn";
            this.diferenciaDataGridViewTextBoxColumn.ReadOnly = true;
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
            // txFecha
            // 
            this.txFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txFecha.Location = new System.Drawing.Point(90, 31);
            this.txFecha.Name = "txFecha";
            this.txFecha.ReadOnly = true;
            this.txFecha.Size = new System.Drawing.Size(136, 22);
            this.txFecha.TabIndex = 65;
            this.txFecha.TabStop = false;
            this.txFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txUsuario
            // 
            this.txUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txUsuario.Location = new System.Drawing.Point(90, 68);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.ReadOnly = true;
            this.txUsuario.Size = new System.Drawing.Size(136, 22);
            this.txUsuario.TabIndex = 67;
            this.txUsuario.TabStop = false;
            this.txUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Realizado por";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmVerCierreVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 574);
            this.Controls.Add(this.txUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVerCierreVentas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ver Cierre de Ventas";
            this.Activated += new System.EventHandler(this.frmVerCierreVentas_Activated);
            this.Load += new System.EventHandler(this.frmVerCierreVentas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCierreOtrosPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVentasOtrosPagosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.BindingSource cierreVentasOtrosPagosBindingSource;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txDifEfectivo;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txMontoCierre;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txTotalRecibido;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView grdCierreOtrosPagos;
    private System.Windows.Forms.TextBox txFecha;
    private System.Windows.Forms.TextBox txUsuario;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txObsEf;
    private System.Windows.Forms.Label lbObs;
    private System.Windows.Forms.TextBox txObs;
    private System.Windows.Forms.TextBox txtlEfectivoCierre;
    private System.Windows.Forms.TextBox txtlOtrosPagosCierre;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txTotalSistema;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txTotalOtros;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txTotalEfectivo;
    private System.Windows.Forms.TextBox txDiferencia;
    private System.Windows.Forms.TextBox txTotalCierre;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn formaPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idPOSDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn pOSDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalMontoSistemaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalMontoCierreDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn diferenciaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
  }
}