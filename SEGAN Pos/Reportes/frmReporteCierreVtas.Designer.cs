namespace SEGAN_POS
{
  partial class frmReporteCierreVtas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CierreVentasOtrosPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreVtasInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.consolidadoCierreVtasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreVtasNotasCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreVtasMaqFiscalZBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ePKCierreMaquinaFiscalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreVtasMaqFiscalNCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cierreVtasMaqFiscalNCZBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listadoFacturasAnuladasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvCierreVtas = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CierreVentasOtrosPagosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.consolidadoCierreVtasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasNotasCreditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalZBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKCierreMaquinaFiscalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalNCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalNCZBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasAnuladasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CierreVentasOtrosPagosBindingSource
            // 
            this.CierreVentasOtrosPagosBindingSource.DataMember = "CierreVentasOtrosPagos";
            // 
            // cierreVtasInventarioBindingSource
            // 
            this.cierreVtasInventarioBindingSource.DataMember = "CierreVtasInventario";
            // 
            // consolidadoCierreVtasBindingSource
            // 
            this.consolidadoCierreVtasBindingSource.DataMember = "CierreTotalConsolidados";
            // 
            // cierreVtasNotasCreditoBindingSource
            // 
            this.cierreVtasNotasCreditoBindingSource.DataMember = "CierreVtasNotasCredito";
            // 
            // cierreVtasMaqFiscalZBindingSource
            // 
            this.cierreVtasMaqFiscalZBindingSource.DataSource = typeof(SEGAN_POS.DAL.CierreVtasMaqFiscalZ);
            // 
            // ePKCierreMaquinaFiscalBindingSource
            // 
            this.ePKCierreMaquinaFiscalBindingSource.DataMember = "CierreVtasMaqFiscal";
            // 
            // cierreVtasMaqFiscalNCBindingSource
            // 
            this.cierreVtasMaqFiscalNCBindingSource.DataMember = "CierreVtasMFNC";
            // 
            // cierreVtasMaqFiscalNCZBindingSource
            // 
            this.cierreVtasMaqFiscalNCZBindingSource.DataSource = typeof(SEGAN_POS.DAL.CierreVtasMaqFiscalNCZ);
            // 
            // listadoFacturasAnuladasBindingSource
            // 
            this.listadoFacturasAnuladasBindingSource.DataSource = typeof(SEGAN_POS.DAL.ListadoFacturasAnuladas);
            // 
            // rvCierreVtas
            // 
            this.rvCierreVtas.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsCierreVtas";
            reportDataSource1.Value = this.CierreVentasOtrosPagosBindingSource;
            reportDataSource2.Name = "dsCierreVtasInventario";
            reportDataSource2.Value = this.cierreVtasInventarioBindingSource;
            reportDataSource3.Name = "dsConsolidado";
            reportDataSource3.Value = this.consolidadoCierreVtasBindingSource;
            reportDataSource4.Name = "dsNC";
            reportDataSource4.Value = this.cierreVtasNotasCreditoBindingSource;
            reportDataSource5.Name = "dsCierreMFZ";
            reportDataSource5.Value = this.cierreVtasMaqFiscalZBindingSource;
            reportDataSource6.Name = "dsCierreMF";
            reportDataSource6.Value = this.ePKCierreMaquinaFiscalBindingSource;
            reportDataSource7.Name = "dsCierreMFNC";
            reportDataSource7.Value = this.cierreVtasMaqFiscalNCBindingSource;
            reportDataSource8.Name = "dsCierreMFNCZ";
            reportDataSource8.Value = this.cierreVtasMaqFiscalNCZBindingSource;
            reportDataSource9.Name = "dsFacturasAnuladas";
            reportDataSource9.Value = this.listadoFacturasAnuladasBindingSource;
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource1);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource2);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource3);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource4);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource5);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource6);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource7);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource8);
            this.rvCierreVtas.LocalReport.DataSources.Add(reportDataSource9);
            this.rvCierreVtas.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptCierreVentas.rdlc";
            this.rvCierreVtas.Location = new System.Drawing.Point(0, 0);
            this.rvCierreVtas.Name = "rvCierreVtas";
            this.rvCierreVtas.Size = new System.Drawing.Size(784, 566);
            this.rvCierreVtas.TabIndex = 4;
            this.rvCierreVtas.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvCierreVtas_ReportExport);
            this.rvCierreVtas.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvCierreVtas_PrintingBegin);
            this.rvCierreVtas.Load += new System.EventHandler(this.frmReporteCierreVtas_Load);
            // 
            // frmReporteCierreVtas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.Controls.Add(this.rvCierreVtas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteCierreVtas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReporteCierreVtas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmReporteCierreVtas_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReporteCierreVtas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CierreVentasOtrosPagosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.consolidadoCierreVtasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasNotasCreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalZBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKCierreMaquinaFiscalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalNCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cierreVtasMaqFiscalNCZBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasAnuladasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvCierreVtas;
        private System.Windows.Forms.BindingSource CierreVentasOtrosPagosBindingSource;
        private System.Windows.Forms.BindingSource cierreVtasInventarioBindingSource;
        private System.Windows.Forms.BindingSource ePKCierreMaquinaFiscalBindingSource;
        private System.Windows.Forms.BindingSource cierreVtasNotasCreditoBindingSource;
        private System.Windows.Forms.BindingSource consolidadoCierreVtasBindingSource;
        private System.Windows.Forms.BindingSource cierreVtasMaqFiscalNCBindingSource;
        private System.Windows.Forms.BindingSource cierreVtasMaqFiscalZBindingSource;
        private System.Windows.Forms.BindingSource cierreVtasMaqFiscalNCZBindingSource;
        private System.Windows.Forms.BindingSource listadoFacturasAnuladasBindingSource;
    }
}