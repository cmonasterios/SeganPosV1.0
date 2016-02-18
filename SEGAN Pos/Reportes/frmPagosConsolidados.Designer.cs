namespace SEGAN_POS
{
    partial class frmPagosConsolidados
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
            this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rvPagos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ePKspReporteVentaDiariaResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteVentaDiariaResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Controls.Add(this.dtpHasta);
            this.groupBoxCriterios.Controls.Add(this.dtpDesde);
            this.groupBoxCriterios.Controls.Add(this.label2);
            this.groupBoxCriterios.Controls.Add(this.label1);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(987, 86);
            this.groupBoxCriterios.TabIndex = 1;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(753, 19);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(352, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(161, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(105, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde";
            // 
            // rvPagos
            // 
            this.rvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPagosConsolidados";
            reportDataSource1.Value = this.ePKspReporteVentaDiariaResultBindingSource;
            this.rvPagos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPagos.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptPagosConsolidados.rdlc";
            this.rvPagos.Location = new System.Drawing.Point(0, 86);
            this.rvPagos.Margin = new System.Windows.Forms.Padding(1);
            this.rvPagos.Name = "rvPagos";
            this.rvPagos.Size = new System.Drawing.Size(987, 480);
            this.rvPagos.TabIndex = 4;
            this.rvPagos.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvPagos_ReportExport);
            this.rvPagos.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvPagos_PrintingBegin);
            // 
            // ePKspReporteVentaDiariaResultBindingSource
            // 
            this.ePKspReporteVentaDiariaResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVentaDiaria_Result);
            // 
            // frmPagosConsolidados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.rvPagos);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagosConsolidados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPagosConsolidados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmPagosConsolidados_Activated);
            this.Load += new System.EventHandler(this.frmPagosConsolidados_Load);
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteVentaDiariaResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rvPagos;
        private System.Windows.Forms.BindingSource ePKspReporteVentaDiariaResultBindingSource;
    }
}