namespace SEGAN_POS
{
  partial class frmConsultarDepositos
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
      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.txNumeroTrans = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txSerialPrecinto = new System.Windows.Forms.TextBox();
      this.lbl = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cbBancos = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cbTiposDeposito = new System.Windows.Forms.ComboBox();
      this.dgResults = new System.Windows.Forms.DataGridView();
      this.IdDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FechaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idDepositoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tipoDepositoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.SerialPrecinto = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.NroTransaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.montoEfectivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.montoChequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.depositosConsultaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btImprimir = new System.Windows.Forms.Button();
      this.btExport = new System.Windows.Forms.Button();
      this.lbCantReg = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.btBuscar = new System.Windows.Forms.Button();
      this.btLimpiar = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.depositosConsultaBindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // dtpHasta
      // 
      this.dtpHasta.CausesValidation = false;
      this.dtpHasta.Checked = false;
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpHasta.Location = new System.Drawing.Point(310, 20);
      this.dtpHasta.Name = "dtpHasta";
      this.dtpHasta.ShowCheckBox = true;
      this.dtpHasta.Size = new System.Drawing.Size(118, 20);
      this.dtpHasta.TabIndex = 76;
      // 
      // dtpDesde
      // 
      this.dtpDesde.CausesValidation = false;
      this.dtpDesde.Checked = false;
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDesde.Location = new System.Drawing.Point(97, 20);
      this.dtpDesde.Name = "dtpDesde";
      this.dtpDesde.ShowCheckBox = true;
      this.dtpDesde.Size = new System.Drawing.Size(118, 20);
      this.dtpDesde.TabIndex = 75;
      this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
      // 
      // txNumeroTrans
      // 
      this.txNumeroTrans.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txNumeroTrans.Location = new System.Drawing.Point(517, 57);
      this.txNumeroTrans.MaxLength = 30;
      this.txNumeroTrans.Name = "txNumeroTrans";
      this.txNumeroTrans.Size = new System.Drawing.Size(177, 20);
      this.txNumeroTrans.TabIndex = 38;
      this.txNumeroTrans.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(446, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 39;
      this.label2.Text = "Comprobante";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txSerialPrecinto
      // 
      this.txSerialPrecinto.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txSerialPrecinto.Location = new System.Drawing.Point(310, 58);
      this.txSerialPrecinto.MaxLength = 20;
      this.txSerialPrecinto.Name = "txSerialPrecinto";
      this.txSerialPrecinto.Size = new System.Drawing.Size(118, 20);
      this.txSerialPrecinto.TabIndex = 36;
      this.txSerialPrecinto.TabStop = false;
      // 
      // lbl
      // 
      this.lbl.AutoSize = true;
      this.lbl.Location = new System.Drawing.Point(238, 61);
      this.lbl.Name = "lbl";
      this.lbl.Size = new System.Drawing.Size(66, 13);
      this.lbl.TabIndex = 37;
      this.lbl.Text = "Nro. Envase";
      this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(17, 11);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(79, 37);
      this.label5.TabIndex = 31;
      this.label5.Text = "Fecha Venta Desde";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(473, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(38, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Banco";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbBancos
      // 
      this.cbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBancos.FormattingEnabled = true;
      this.cbBancos.Location = new System.Drawing.Point(517, 19);
      this.cbBancos.Name = "cbBancos";
      this.cbBancos.Size = new System.Drawing.Size(177, 21);
      this.cbBancos.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 60);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Tipo Depósito";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbTiposDeposito
      // 
      this.cbTiposDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTiposDeposito.FormattingEnabled = true;
      this.cbTiposDeposito.Location = new System.Drawing.Point(97, 57);
      this.cbTiposDeposito.Name = "cbTiposDeposito";
      this.cbTiposDeposito.Size = new System.Drawing.Size(118, 21);
      this.cbTiposDeposito.TabIndex = 6;
      // 
      // dgResults
      // 
      this.dgResults.AllowUserToAddRows = false;
      this.dgResults.AllowUserToDeleteRows = false;
      this.dgResults.AllowUserToResizeColumns = false;
      this.dgResults.AllowUserToResizeRows = false;
      this.dgResults.AutoGenerateColumns = false;
      this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDeposito,
            this.FechaVenta,
            this.idDepositoDataGridViewTextBoxColumn,
            this.bancoDataGridViewTextBoxColumn,
            this.tipoDepositoDataGridViewTextBoxColumn,
            this.SerialPrecinto,
            this.NroTransaccion,
            this.montoEfectivoDataGridViewTextBoxColumn,
            this.montoChequeDataGridViewTextBoxColumn,
            this.montoTotalDataGridViewTextBoxColumn});
      this.dgResults.DataSource = this.depositosConsultaBindingSource;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgResults.DefaultCellStyle = dataGridViewCellStyle1;
      this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgResults.Location = new System.Drawing.Point(0, 100);
      this.dgResults.Name = "dgResults";
      this.dgResults.ReadOnly = true;
      this.dgResults.RowHeadersVisible = false;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.dgResults.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.dgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgResults.Size = new System.Drawing.Size(836, 307);
      this.dgResults.TabIndex = 2;
      this.dgResults.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
      this.dgResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgResults_CellDoubleClick);
      this.dgResults.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgResults_DataError);
      // 
      // IdDeposito
      // 
      this.IdDeposito.DataPropertyName = "IdDeposito";
      this.IdDeposito.HeaderText = "IdDeposito";
      this.IdDeposito.Name = "IdDeposito";
      this.IdDeposito.ReadOnly = true;
      this.IdDeposito.Visible = false;
      // 
      // FechaVenta
      // 
      this.FechaVenta.DataPropertyName = "FechaVenta";
      this.FechaVenta.HeaderText = "Fecha Venta";
      this.FechaVenta.Name = "FechaVenta";
      this.FechaVenta.ReadOnly = true;
      this.FechaVenta.Width = 70;
      // 
      // idDepositoDataGridViewTextBoxColumn
      // 
      this.idDepositoDataGridViewTextBoxColumn.DataPropertyName = "IdDeposito";
      this.idDepositoDataGridViewTextBoxColumn.HeaderText = "Nro. Control";
      this.idDepositoDataGridViewTextBoxColumn.Name = "idDepositoDataGridViewTextBoxColumn";
      this.idDepositoDataGridViewTextBoxColumn.ReadOnly = true;
      this.idDepositoDataGridViewTextBoxColumn.Width = 50;
      // 
      // bancoDataGridViewTextBoxColumn
      // 
      this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
      this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
      this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
      this.bancoDataGridViewTextBoxColumn.ReadOnly = true;
      this.bancoDataGridViewTextBoxColumn.Width = 160;
      // 
      // tipoDepositoDataGridViewTextBoxColumn
      // 
      this.tipoDepositoDataGridViewTextBoxColumn.DataPropertyName = "TipoDeposito";
      this.tipoDepositoDataGridViewTextBoxColumn.HeaderText = "Tipo Depósito";
      this.tipoDepositoDataGridViewTextBoxColumn.Name = "tipoDepositoDataGridViewTextBoxColumn";
      this.tipoDepositoDataGridViewTextBoxColumn.ReadOnly = true;
      this.tipoDepositoDataGridViewTextBoxColumn.Width = 70;
      // 
      // SerialPrecinto
      // 
      this.SerialPrecinto.DataPropertyName = "SerialPrecinto";
      this.SerialPrecinto.HeaderText = "Nro. Envase";
      this.SerialPrecinto.Name = "SerialPrecinto";
      this.SerialPrecinto.ReadOnly = true;
      this.SerialPrecinto.Width = 95;
      // 
      // NroTransaccion
      // 
      this.NroTransaccion.DataPropertyName = "NroTransaccion";
      this.NroTransaccion.HeaderText = "Nro. Depósito";
      this.NroTransaccion.Name = "NroTransaccion";
      this.NroTransaccion.ReadOnly = true;
      this.NroTransaccion.Width = 95;
      // 
      // montoEfectivoDataGridViewTextBoxColumn
      // 
      this.montoEfectivoDataGridViewTextBoxColumn.DataPropertyName = "MontoEfectivo";
      this.montoEfectivoDataGridViewTextBoxColumn.HeaderText = "Monto Efectivo";
      this.montoEfectivoDataGridViewTextBoxColumn.Name = "montoEfectivoDataGridViewTextBoxColumn";
      this.montoEfectivoDataGridViewTextBoxColumn.ReadOnly = true;
      this.montoEfectivoDataGridViewTextBoxColumn.Width = 90;
      // 
      // montoChequeDataGridViewTextBoxColumn
      // 
      this.montoChequeDataGridViewTextBoxColumn.DataPropertyName = "MontoCheque";
      this.montoChequeDataGridViewTextBoxColumn.HeaderText = "Monto Cheque";
      this.montoChequeDataGridViewTextBoxColumn.Name = "montoChequeDataGridViewTextBoxColumn";
      this.montoChequeDataGridViewTextBoxColumn.ReadOnly = true;
      this.montoChequeDataGridViewTextBoxColumn.Width = 90;
      // 
      // montoTotalDataGridViewTextBoxColumn
      // 
      this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "MontoTotal";
      this.montoTotalDataGridViewTextBoxColumn.HeaderText = "Monto Total";
      this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
      this.montoTotalDataGridViewTextBoxColumn.ReadOnly = true;
      this.montoTotalDataGridViewTextBoxColumn.Width = 90;
      // 
      // depositosConsultaBindingSource
      // 
      this.depositosConsultaBindingSource.DataSource = typeof(SEGAN_POS.DAL.DepositosConsulta);
      // 
      // btCancel
      // 
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(178, 2);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(70, 33);
      this.btCancel.TabIndex = 37;
      this.btCancel.Text = "Cerrar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.lbCantReg);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 407);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(836, 43);
      this.panel1.TabIndex = 38;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btCancel);
      this.panel3.Controls.Add(this.btImprimir);
      this.panel3.Controls.Add(this.btExport);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(581, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(255, 43);
      this.panel3.TabIndex = 85;
      // 
      // btImprimir
      // 
      this.btImprimir.CausesValidation = false;
      this.btImprimir.Enabled = false;
      this.btImprimir.Image = global::SEGAN_POS.Properties.Resources.reimprimir;
      this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btImprimir.Location = new System.Drawing.Point(92, 3);
      this.btImprimir.Name = "btImprimir";
      this.btImprimir.Size = new System.Drawing.Size(80, 32);
      this.btImprimir.TabIndex = 84;
      this.btImprimir.TabStop = false;
      this.btImprimir.Tag = "Imprimir";
      this.btImprimir.Text = "Imprimir";
      this.btImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btImprimir.UseVisualStyleBackColor = true;
      this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
      // 
      // btExport
      // 
      this.btExport.CausesValidation = false;
      this.btExport.Enabled = false;
      this.btExport.Image = global::SEGAN_POS.Properties.Resources.excel;
      this.btExport.Location = new System.Drawing.Point(3, 3);
      this.btExport.Name = "btExport";
      this.btExport.Size = new System.Drawing.Size(83, 33);
      this.btExport.TabIndex = 83;
      this.btExport.TabStop = false;
      this.btExport.Text = "Exportar";
      this.btExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btExport.UseVisualStyleBackColor = true;
      this.btExport.Visible = false;
      this.btExport.Click += new System.EventHandler(this.btExport_Click);
      // 
      // lbCantReg
      // 
      this.lbCantReg.AutoSize = true;
      this.lbCantReg.Location = new System.Drawing.Point(12, 15);
      this.lbCantReg.Name = "lbCantReg";
      this.lbCantReg.Size = new System.Drawing.Size(108, 13);
      this.lbCantReg.TabIndex = 82;
      this.lbCantReg.Text = "registros encontrados";
      this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lbCantReg.Visible = false;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.btBuscar);
      this.panel2.Controls.Add(this.btLimpiar);
      this.panel2.Controls.Add(this.dtpHasta);
      this.panel2.Controls.Add(this.dtpDesde);
      this.panel2.Controls.Add(this.cbTiposDeposito);
      this.panel2.Controls.Add(this.txNumeroTrans);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.cbBancos);
      this.panel2.Controls.Add(this.txSerialPrecinto);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.lbl);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(836, 100);
      this.panel2.TabIndex = 39;
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(225, 11);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 37);
      this.label4.TabIndex = 79;
      this.label4.Text = "Fecha Venta Hasta";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btBuscar
      // 
      this.btBuscar.CausesValidation = false;
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(712, 6);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(112, 53);
      this.btBuscar.TabIndex = 77;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // btLimpiar
      // 
      this.btLimpiar.CausesValidation = false;
      this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btLimpiar.Location = new System.Drawing.Point(712, 65);
      this.btLimpiar.Name = "btLimpiar";
      this.btLimpiar.Size = new System.Drawing.Size(112, 28);
      this.btLimpiar.TabIndex = 78;
      this.btLimpiar.Text = "Limpiar Criterios";
      this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btLimpiar.UseVisualStyleBackColor = true;
      this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xlsx";
      this.saveFileDialog1.Filter = "Excel|*.xlsx";
      this.saveFileDialog1.Title = "Exportar Facturas";
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
      // 
      // frmConsultarDepositos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(836, 450);
      this.Controls.Add(this.dgResults);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConsultarDepositos";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Consultar Depósitos";
      this.Activated += new System.EventHandler(this.frmConsultarDepositos_Activated);
      this.Load += new System.EventHandler(this.frmConsultarDepositos_Load);
      this.Shown += new System.EventHandler(this.frmConsultarDepositos_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.depositosConsultaBindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbBancos;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cbTiposDeposito;
    private System.Windows.Forms.TextBox txNumeroTrans;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txSerialPrecinto;
    private System.Windows.Forms.Label lbl;
    private System.Windows.Forms.DataGridView dgResults;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.BindingSource depositosConsultaBindingSource;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Button btExport;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btImprimir;
    private System.Windows.Forms.DataGridViewTextBoxColumn IdDeposito;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaVenta;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDepositoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tipoDepositoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn SerialPrecinto;
    private System.Windows.Forms.DataGridViewTextBoxColumn NroTransaccion;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoEfectivoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoChequeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
    private System.Windows.Forms.Label label4;
  }
}