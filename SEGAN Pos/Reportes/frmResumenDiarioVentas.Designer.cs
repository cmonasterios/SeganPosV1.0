namespace SEGAN_POS
{
    partial class frmResumenDiarioVentas
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
      this.ePKspReporteResumenDiarioVtasResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
      this.txtMFiscal = new System.Windows.Forms.TextBox();
      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.lblFHasta = new System.Windows.Forms.Label();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.lblMFiscal = new System.Windows.Forms.Label();
      this.btBuscar = new System.Windows.Forms.Button();
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.lblFDesde = new System.Windows.Forms.Label();
      this.rvResumenDiarioVtas = new Microsoft.Reporting.WinForms.ReportViewer();
      ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteResumenDiarioVtasResultBindingSource)).BeginInit();
      this.groupBoxCriterios.SuspendLayout();
      this.SuspendLayout();
      // 
      // ePKspReporteResumenDiarioVtasResultBindingSource
      // 
      this.ePKspReporteResumenDiarioVtasResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteResumenDiarioVtas_Result);
      // 
      // groupBoxCriterios
      // 
      this.groupBoxCriterios.Controls.Add(this.txtMFiscal);
      this.groupBoxCriterios.Controls.Add(this.dtpHasta);
      this.groupBoxCriterios.Controls.Add(this.lblFHasta);
      this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
      this.groupBoxCriterios.Controls.Add(this.lblMFiscal);
      this.groupBoxCriterios.Controls.Add(this.btBuscar);
      this.groupBoxCriterios.Controls.Add(this.dtpDesde);
      this.groupBoxCriterios.Controls.Add(this.lblFDesde);
      this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
      this.groupBoxCriterios.Name = "groupBoxCriterios";
      this.groupBoxCriterios.Size = new System.Drawing.Size(987, 118);
      this.groupBoxCriterios.TabIndex = 3;
      this.groupBoxCriterios.TabStop = false;
      this.groupBoxCriterios.Text = "Criterios de Búsqueda";
      // 
      // txtMFiscal
      // 
      this.txtMFiscal.Location = new System.Drawing.Point(198, 74);
      this.txtMFiscal.Name = "txtMFiscal";
      this.txtMFiscal.Size = new System.Drawing.Size(121, 20);
      this.txtMFiscal.TabIndex = 4;
      // 
      // dtpHasta
      // 
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpHasta.Location = new System.Drawing.Point(561, 37);
      this.dtpHasta.Name = "dtpHasta";
      this.dtpHasta.Size = new System.Drawing.Size(121, 20);
      this.dtpHasta.TabIndex = 3;
      // 
      // lblFHasta
      // 
      this.lblFHasta.AutoSize = true;
      this.lblFHasta.Location = new System.Drawing.Point(479, 37);
      this.lblFHasta.Name = "lblFHasta";
      this.lblFHasta.Size = new System.Drawing.Size(68, 13);
      this.lblFHasta.TabIndex = 53;
      this.lblFHasta.Text = "Fecha Hasta";
      // 
      // btnLimpiar
      // 
      this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btnLimpiar.Location = new System.Drawing.Point(810, 23);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
      this.btnLimpiar.TabIndex = 5;
      this.btnLimpiar.Text = "Limpiar Criterios";
      this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnLimpiar.UseVisualStyleBackColor = true;
      this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
      // 
      // lblMFiscal
      // 
      this.lblMFiscal.AutoSize = true;
      this.lblMFiscal.Location = new System.Drawing.Point(103, 74);
      this.lblMFiscal.Name = "lblMFiscal";
      this.lblMFiscal.Size = new System.Drawing.Size(78, 13);
      this.lblMFiscal.TabIndex = 11;
      this.lblMFiscal.Text = "Maquina Fiscal";
      // 
      // btBuscar
      // 
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(810, 54);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(112, 53);
      this.btBuscar.TabIndex = 1;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // dtpDesde
      // 
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDesde.Location = new System.Drawing.Point(198, 37);
      this.dtpDesde.Name = "dtpDesde";
      this.dtpDesde.Size = new System.Drawing.Size(121, 20);
      this.dtpDesde.TabIndex = 2;
      // 
      // lblFDesde
      // 
      this.lblFDesde.AutoSize = true;
      this.lblFDesde.Location = new System.Drawing.Point(110, 37);
      this.lblFDesde.Name = "lblFDesde";
      this.lblFDesde.Size = new System.Drawing.Size(71, 13);
      this.lblFDesde.TabIndex = 0;
      this.lblFDesde.Text = "Fecha Desde";
      // 
      // rvResumenDiarioVtas
      // 
      this.rvResumenDiarioVtas.Dock = System.Windows.Forms.DockStyle.Fill;
      reportDataSource1.Name = "dsResumenDiarioVtas";
      reportDataSource1.Value = this.ePKspReporteResumenDiarioVtasResultBindingSource;
      this.rvResumenDiarioVtas.LocalReport.DataSources.Add(reportDataSource1);
      this.rvResumenDiarioVtas.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptResumenDiarioVentas.rdlc";
      this.rvResumenDiarioVtas.Location = new System.Drawing.Point(0, 118);
      this.rvResumenDiarioVtas.Name = "rvResumenDiarioVtas";
      this.rvResumenDiarioVtas.Size = new System.Drawing.Size(987, 448);
      this.rvResumenDiarioVtas.TabIndex = 4;
      this.rvResumenDiarioVtas.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvResumenDiarioVtas_ReportExport);
      this.rvResumenDiarioVtas.Print += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvResumenDiarioVtas_Print);
      this.rvResumenDiarioVtas.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvResumenDiarioVtas_PrintingBegin);
      // 
      // frmResumenDiarioVentas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(987, 566);
      this.Controls.Add(this.rvResumenDiarioVtas);
      this.Controls.Add(this.groupBoxCriterios);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmResumenDiarioVentas";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmResumenDiarioVentas";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Activated += new System.EventHandler(this.frmResumenDiarioVentas_Activated);
      this.Load += new System.EventHandler(this.frmResumenDiarioVentas_Load);
      ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteResumenDiarioVtasResultBindingSource)).EndInit();
      this.groupBoxCriterios.ResumeLayout(false);
      this.groupBoxCriterios.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblFHasta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblMFiscal;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblFDesde;
        private Microsoft.Reporting.WinForms.ReportViewer rvResumenDiarioVtas;
        private System.Windows.Forms.TextBox txtMFiscal;
        private System.Windows.Forms.BindingSource ePKspReporteResumenDiarioVtasResultBindingSource;
    }
}