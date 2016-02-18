namespace SEGAN_POS
{
    partial class frmRepOperacionesCajero
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
            this.ePKspReporteOperacionesCajeroResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
            this.txCajero = new System.Windows.Forms.TextBox();
            this.groupBoxAccion = new System.Windows.Forms.GroupBox();
            this.optCierre = new System.Windows.Forms.RadioButton();
            this.optApertura = new System.Windows.Forms.RadioButton();
            this.optTodas = new System.Windows.Forms.RadioButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCaja = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.rvApertura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ePKspReporteAperturaCajeroResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ePKspReporteCierreCajeroResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteOperacionesCajeroResultBindingSource)).BeginInit();
            this.groupBoxCriterios.SuspendLayout();
            this.groupBoxAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteAperturaCajeroResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteCierreCajeroResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ePKspReporteOperacionesCajeroResultBindingSource
            // 
            this.ePKspReporteOperacionesCajeroResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteOperacionesCajero_Result);
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.txCajero);
            this.groupBoxCriterios.Controls.Add(this.groupBoxAccion);
            this.groupBoxCriterios.Controls.Add(this.dtpHasta);
            this.groupBoxCriterios.Controls.Add(this.label3);
            this.groupBoxCriterios.Controls.Add(this.label9);
            this.groupBoxCriterios.Controls.Add(this.cbCaja);
            this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
            this.groupBoxCriterios.Controls.Add(this.label2);
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Controls.Add(this.dtpDesde);
            this.groupBoxCriterios.Controls.Add(this.label1);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(987, 108);
            this.groupBoxCriterios.TabIndex = 3;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            // 
            // txCajero
            // 
            this.txCajero.Location = new System.Drawing.Point(598, 48);
            this.txCajero.Name = "txCajero";
            this.txCajero.Size = new System.Drawing.Size(117, 20);
            this.txCajero.TabIndex = 8;
            // 
            // groupBoxAccion
            // 
            this.groupBoxAccion.Controls.Add(this.optCierre);
            this.groupBoxAccion.Controls.Add(this.optApertura);
            this.groupBoxAccion.Controls.Add(this.optTodas);
            this.groupBoxAccion.Location = new System.Drawing.Point(724, 13);
            this.groupBoxAccion.Name = "groupBoxAccion";
            this.groupBoxAccion.Size = new System.Drawing.Size(105, 84);
            this.groupBoxAccion.TabIndex = 4;
            this.groupBoxAccion.TabStop = false;
            this.groupBoxAccion.Text = "Tipo";
            // 
            // optCierre
            // 
            this.optCierre.AutoSize = true;
            this.optCierre.Location = new System.Drawing.Point(21, 39);
            this.optCierre.Name = "optCierre";
            this.optCierre.Size = new System.Drawing.Size(52, 17);
            this.optCierre.TabIndex = 12;
            this.optCierre.Text = "Cierre";
            this.optCierre.UseVisualStyleBackColor = true;
            // 
            // optApertura
            // 
            this.optApertura.AutoSize = true;
            this.optApertura.Location = new System.Drawing.Point(21, 63);
            this.optApertura.Name = "optApertura";
            this.optApertura.Size = new System.Drawing.Size(65, 17);
            this.optApertura.TabIndex = 11;
            this.optApertura.Text = "Apertura";
            this.optApertura.UseVisualStyleBackColor = true;
            // 
            // optTodas
            // 
            this.optTodas.AutoSize = true;
            this.optTodas.Checked = true;
            this.optTodas.Location = new System.Drawing.Point(21, 16);
            this.optTodas.Name = "optTodas";
            this.optTodas.Size = new System.Drawing.Size(55, 17);
            this.optTodas.TabIndex = 10;
            this.optTodas.TabStop = true;
            this.optTodas.Text = "Todas";
            this.optTodas.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(259, 46);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(98, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha Hasta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(522, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Facturado por";
            // 
            // cbCaja
            // 
            this.cbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCaja.FormattingEnabled = true;
            this.cbCaja.Location = new System.Drawing.Point(397, 47);
            this.cbCaja.Name = "cbCaja";
            this.cbCaja.Size = new System.Drawing.Size(120, 21);
            this.cbCaja.TabIndex = 2;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(848, 67);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Caja";
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(848, 11);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 5;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(80, 45);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(101, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde";
            // 
            // rvApertura
            // 
            this.rvApertura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsAperturaCajero";
            reportDataSource1.Value = this.ePKspReporteOperacionesCajeroResultBindingSource;
            this.rvApertura.LocalReport.DataSources.Add(reportDataSource1);
            this.rvApertura.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptAperturaCajero.rdlc";
            this.rvApertura.Location = new System.Drawing.Point(0, 108);
            this.rvApertura.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.rvApertura.Name = "rvApertura";
            this.rvApertura.Size = new System.Drawing.Size(987, 458);
            this.rvApertura.TabIndex = 7;
            this.rvApertura.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvApertura_ReportExport);
            this.rvApertura.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvApertura_PrintingBegin);
            // 
            // ePKspReporteAperturaCajeroResultBindingSource
            // 
            this.ePKspReporteAperturaCajeroResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteAperturaCajero_Result);
            // 
            // ePKspReporteCierreCajeroResultBindingSource
            // 
            this.ePKspReporteCierreCajeroResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteCierreCajero_Result);
            // 
            // frmRepOperacionesCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.rvApertura);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepOperacionesCajero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmRepOperacionesCajero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmRepOperacionesCajero_Activated);
            this.Load += new System.EventHandler(this.frmRepAperturaCajero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteOperacionesCajeroResultBindingSource)).EndInit();
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            this.groupBoxAccion.ResumeLayout(false);
            this.groupBoxAccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteAperturaCajeroResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteCierreCajeroResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCaja;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rvApertura;
        private System.Windows.Forms.GroupBox groupBoxAccion;
        private System.Windows.Forms.RadioButton optCierre;
        private System.Windows.Forms.RadioButton optApertura;
        private System.Windows.Forms.RadioButton optTodas;
        private System.Windows.Forms.BindingSource ePKspReporteAperturaCajeroResultBindingSource;
        private System.Windows.Forms.BindingSource ePKspReporteCierreCajeroResultBindingSource;
        private System.Windows.Forms.BindingSource ePKspReporteOperacionesCajeroResultBindingSource;
        private System.Windows.Forms.TextBox txCajero;
    }
}