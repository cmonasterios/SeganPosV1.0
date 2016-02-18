namespace SEGAN_POS
{
    partial class frmConciliacionFormaPago
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvPagos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.cbPOS = new System.Windows.Forms.ComboBox();
            this.cbMF = new System.Windows.Forms.ComboBox();
            this.nudMontoH = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.gbVer = new System.Windows.Forms.GroupBox();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.nudMontoD = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
            this.txtCajero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBanco = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ePKspReporteConciliacionFormaPagoResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoH)).BeginInit();
            this.gbVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoD)).BeginInit();
            this.groupBoxCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteConciliacionFormaPagoResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvPagos
            // 
            this.rvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsDetalle";
            reportDataSource1.Value = null;
            this.rvPagos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPagos.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptConsolidadoFormaPagoDetalle.rdlc";
            this.rvPagos.Location = new System.Drawing.Point(0, 137);
            this.rvPagos.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.rvPagos.Name = "rvPagos";
            this.rvPagos.Size = new System.Drawing.Size(987, 429);
            this.rvPagos.TabIndex = 13;
            this.rvPagos.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvPagos_ReportExport);
            this.rvPagos.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvPagos_PrintingBegin);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(71, 38);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(167, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(861, 38);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 11;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Caja";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(500, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Forma de pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "POS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Máquina Fiscal";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(861, 92);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbCaja
            // 
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(71, 66);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(167, 21);
            this.cbCaja.TabIndex = 5;
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(579, 66);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(167, 21);
            this.cbFormaPago.TabIndex = 7;
            // 
            // cbPOS
            // 
            this.cbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPOS.FormattingEnabled = true;
            this.cbPOS.Location = new System.Drawing.Point(326, 98);
            this.cbPOS.Name = "cbPOS";
            this.cbPOS.Size = new System.Drawing.Size(167, 21);
            this.cbPOS.TabIndex = 9;
            // 
            // cbMF
            // 
            this.cbMF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMF.FormattingEnabled = true;
            this.cbMF.Location = new System.Drawing.Point(326, 66);
            this.cbMF.Name = "cbMF";
            this.cbMF.Size = new System.Drawing.Size(167, 21);
            this.cbMF.TabIndex = 6;
            // 
            // nudMontoH
            // 
            this.nudMontoH.DecimalPlaces = 2;
            this.nudMontoH.Location = new System.Drawing.Point(579, 39);
            this.nudMontoH.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.nudMontoH.Name = "nudMontoH";
            this.nudMontoH.Size = new System.Drawing.Size(167, 20);
            this.nudMontoH.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(510, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Monto Hasta";
            // 
            // gbVer
            // 
            this.gbVer.Controls.Add(this.optDetalle);
            this.gbVer.Controls.Add(this.optResumen);
            this.gbVer.Location = new System.Drawing.Point(752, 33);
            this.gbVer.Name = "gbVer";
            this.gbVer.Size = new System.Drawing.Size(92, 87);
            this.gbVer.TabIndex = 10;
            this.gbVer.TabStop = false;
            this.gbVer.Text = "Tipo";
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Location = new System.Drawing.Point(7, 57);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(70, 17);
            this.optDetalle.TabIndex = 11;
            this.optDetalle.Text = "Detallado";
            this.optDetalle.UseVisualStyleBackColor = true;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Checked = true;
            this.optResumen.Location = new System.Drawing.Point(7, 23);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(83, 17);
            this.optResumen.TabIndex = 10;
            this.optResumen.TabStop = true;
            this.optResumen.Text = "Consolidado";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // nudMontoD
            // 
            this.nudMontoD.DecimalPlaces = 2;
            this.nudMontoD.Location = new System.Drawing.Point(326, 38);
            this.nudMontoD.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.nudMontoD.Name = "nudMontoD";
            this.nudMontoD.Size = new System.Drawing.Size(167, 20);
            this.nudMontoD.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(253, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Monto Desde";
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.txtCajero);
            this.groupBoxCriterios.Controls.Add(this.label9);
            this.groupBoxCriterios.Controls.Add(this.cbBanco);
            this.groupBoxCriterios.Controls.Add(this.label3);
            this.groupBoxCriterios.Controls.Add(this.label7);
            this.groupBoxCriterios.Controls.Add(this.nudMontoD);
            this.groupBoxCriterios.Controls.Add(this.gbVer);
            this.groupBoxCriterios.Controls.Add(this.label8);
            this.groupBoxCriterios.Controls.Add(this.nudMontoH);
            this.groupBoxCriterios.Controls.Add(this.cbMF);
            this.groupBoxCriterios.Controls.Add(this.cbPOS);
            this.groupBoxCriterios.Controls.Add(this.cbFormaPago);
            this.groupBoxCriterios.Controls.Add(this.cbCaja);
            this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
            this.groupBoxCriterios.Controls.Add(this.label6);
            this.groupBoxCriterios.Controls.Add(this.label4);
            this.groupBoxCriterios.Controls.Add(this.label5);
            this.groupBoxCriterios.Controls.Add(this.label2);
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Controls.Add(this.dtpDesde);
            this.groupBoxCriterios.Controls.Add(this.label1);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(987, 137);
            this.groupBoxCriterios.TabIndex = 2;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            this.groupBoxCriterios.AutoSizeChanged += new System.EventHandler(this.groupBoxCriterios_AutoSizeChanged);
            // 
            // txtCajero
            // 
            this.txtCajero.CausesValidation = false;
            this.txtCajero.Location = new System.Drawing.Point(579, 100);
            this.txtCajero.MaxLength = 15;
            this.txtCajero.Name = "txtCajero";
            this.txtCajero.Size = new System.Drawing.Size(167, 20);
            this.txtCajero.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 86;
            this.label9.Text = "Facturado por";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbBanco
            // 
            this.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBanco.FormattingEnabled = true;
            this.cbBanco.Location = new System.Drawing.Point(71, 97);
            this.cbBanco.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.cbBanco.Name = "cbBanco";
            this.cbBanco.Size = new System.Drawing.Size(167, 21);
            this.cbBanco.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Banco";
            // 
            // ePKspReporteConciliacionFormaPagoResultBindingSource
            // 
            this.ePKspReporteConciliacionFormaPagoResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteConciliacionFormaPago_Result);
            // 
            // ePKspReporteConciliacionFormaPagoDetalleResultBindingSource
            // 
            this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteConciliacionFormaPagoDetalle_Result);
            // 
            // frmConciliacionFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.rvPagos);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConciliacionFormaPago";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmConciliacionFormaPago";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmConciliacionFormaPago_Activated);
            this.Load += new System.EventHandler(this.frmConciliacionFormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoH)).EndInit();
            this.gbVer.ResumeLayout(false);
            this.gbVer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoD)).EndInit();
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteConciliacionFormaPagoResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteConciliacionFormaPagoDetalleResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPagos;
        private System.Windows.Forms.BindingSource ePKspReporteConciliacionFormaPagoResultBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.ComboBox cbPOS;
        private System.Windows.Forms.ComboBox cbMF;
        private System.Windows.Forms.NumericUpDown nudMontoH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbVer;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.NumericUpDown nudMontoD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource ePKspReporteConciliacionFormaPagoDetalleResultBindingSource;
        private System.Windows.Forms.TextBox txtCajero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBanco;
    }
}