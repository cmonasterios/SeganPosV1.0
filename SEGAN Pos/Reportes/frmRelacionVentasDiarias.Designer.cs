namespace SEGAN_POS
{
    partial class frmRelacionVentasDiarias
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
      this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
      this.btnLimpiar = new System.Windows.Forms.Button();
      this.gbVer = new System.Windows.Forms.GroupBox();
      this.optDetalle = new System.Windows.Forms.RadioButton();
      this.optResumen = new System.Windows.Forms.RadioButton();
      this.cbFormaPago = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btBuscar = new System.Windows.Forms.Button();
      this.dtpFecha = new System.Windows.Forms.DateTimePicker();
      this.label1 = new System.Windows.Forms.Label();
      this.rvRelacion = new Microsoft.Reporting.WinForms.ReportViewer();
      this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource)).BeginInit();
      this.groupBoxCriterios.SuspendLayout();
      this.gbVer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource
      // 
      this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVtaDiariaFPConsolidado_Result);
      // 
      // EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource
      // 
      this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_Result);
      // 
      // EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource
      // 
      this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVtaDiariaTotalesConsolidado_Result);
      // 
      // groupBoxCriterios
      // 
      this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
      this.groupBoxCriterios.Controls.Add(this.gbVer);
      this.groupBoxCriterios.Controls.Add(this.cbFormaPago);
      this.groupBoxCriterios.Controls.Add(this.label5);
      this.groupBoxCriterios.Controls.Add(this.btBuscar);
      this.groupBoxCriterios.Controls.Add(this.dtpFecha);
      this.groupBoxCriterios.Controls.Add(this.label1);
      this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
      this.groupBoxCriterios.Name = "groupBoxCriterios";
      this.groupBoxCriterios.Size = new System.Drawing.Size(987, 99);
      this.groupBoxCriterios.TabIndex = 5;
      this.groupBoxCriterios.TabStop = false;
      this.groupBoxCriterios.Text = "Criterios de Búsqueda";
      this.groupBoxCriterios.Enter += new System.EventHandler(this.groupBoxCriterios_Enter);
      // 
      // btnLimpiar
      // 
      this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btnLimpiar.Location = new System.Drawing.Point(826, 65);
      this.btnLimpiar.Name = "btnLimpiar";
      this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
      this.btnLimpiar.TabIndex = 4;
      this.btnLimpiar.Text = "Limpiar Criterios";
      this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnLimpiar.UseVisualStyleBackColor = true;
      this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
      // 
      // gbVer
      // 
      this.gbVer.Controls.Add(this.optDetalle);
      this.gbVer.Controls.Add(this.optResumen);
      this.gbVer.Location = new System.Drawing.Point(557, 21);
      this.gbVer.Name = "gbVer";
      this.gbVer.Size = new System.Drawing.Size(194, 53);
      this.gbVer.TabIndex = 2;
      this.gbVer.TabStop = false;
      this.gbVer.Text = "Tipo";
      // 
      // optDetalle
      // 
      this.optDetalle.AutoSize = true;
      this.optDetalle.Checked = true;
      this.optDetalle.Location = new System.Drawing.Point(117, 22);
      this.optDetalle.Name = "optDetalle";
      this.optDetalle.Size = new System.Drawing.Size(70, 17);
      this.optDetalle.TabIndex = 3;
      this.optDetalle.TabStop = true;
      this.optDetalle.Text = "Detallado";
      this.optDetalle.UseVisualStyleBackColor = true;
      // 
      // optResumen
      // 
      this.optResumen.AutoSize = true;
      this.optResumen.Location = new System.Drawing.Point(7, 22);
      this.optResumen.Name = "optResumen";
      this.optResumen.Size = new System.Drawing.Size(83, 17);
      this.optResumen.TabIndex = 4;
      this.optResumen.Text = "Consolidado";
      this.optResumen.UseVisualStyleBackColor = true;
      // 
      // cbFormaPago
      // 
      this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbFormaPago.FormattingEnabled = true;
      this.cbFormaPago.Location = new System.Drawing.Point(330, 38);
      this.cbFormaPago.Name = "cbFormaPago";
      this.cbFormaPago.Size = new System.Drawing.Size(167, 21);
      this.cbFormaPago.TabIndex = 1;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(248, 42);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(79, 13);
      this.label5.TabIndex = 19;
      this.label5.Text = "Forma de Pago";
      // 
      // btBuscar
      // 
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(826, 12);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(112, 53);
      this.btBuscar.TabIndex = 3;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // dtpFecha
      // 
      this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpFecha.Location = new System.Drawing.Point(110, 40);
      this.dtpFecha.Name = "dtpFecha";
      this.dtpFecha.Size = new System.Drawing.Size(99, 20);
      this.dtpFecha.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(68, 43);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Fecha";
      // 
      // rvRelacion
      // 
      this.rvRelacion.Dock = System.Windows.Forms.DockStyle.Fill;
      reportDataSource1.Name = "dsRelacion";
      reportDataSource1.Value = this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource;
      reportDataSource2.Name = "dsTotalesFP";
      reportDataSource2.Value = this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource;
      reportDataSource3.Name = "dsTotalesGenerales";
      reportDataSource3.Value = this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource;
      this.rvRelacion.LocalReport.DataSources.Add(reportDataSource1);
      this.rvRelacion.LocalReport.DataSources.Add(reportDataSource2);
      this.rvRelacion.LocalReport.DataSources.Add(reportDataSource3);
      this.rvRelacion.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptRelacionVta.rdlc";
      this.rvRelacion.Location = new System.Drawing.Point(0, 99);
      this.rvRelacion.Name = "rvRelacion";
      this.rvRelacion.Size = new System.Drawing.Size(987, 467);
      this.rvRelacion.TabIndex = 2;
      // 
      // EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource
      // 
      this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteVtaDiariaFPDetallado_Result);
      // 
      // frmRelacionVentasDiarias
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(987, 566);
      this.Controls.Add(this.rvRelacion);
      this.Controls.Add(this.groupBoxCriterios);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmRelacionVentasDiarias";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmRelacionVentasDiarias";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Activated += new System.EventHandler(this.frmRelacionVentasDiarias_Activated);
      this.Load += new System.EventHandler(this.frmRelacionVentasDiarias_Load);
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource)).EndInit();
      this.groupBoxCriterios.ResumeLayout(false);
      this.groupBoxCriterios.PerformLayout();
      this.gbVer.ResumeLayout(false);
      this.gbVer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbVer;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.BindingSource EPK_sp_ReporteVtaDiariaFPConsolidado_ResultBindingSource;
        private System.Windows.Forms.BindingSource EPK_sp_ReporteVtaDiariaTotalesFPConsolidado_ResultBindingSource;
        private System.Windows.Forms.BindingSource EPK_sp_ReporteVtaDiariaTotalesConsolidado_ResultBindingSource;
        private System.Windows.Forms.BindingSource EPK_sp_ReporteVtaDiariaFPDetallado_ResultBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer rvRelacion;
    }
}