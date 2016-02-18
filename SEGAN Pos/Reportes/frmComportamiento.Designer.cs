using SEGAN_POS.Reportes;
namespace SEGAN_POS
{
    partial class frmComportamiento
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
            this.ePKspReporteComportamientoVtaResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvComportamiento = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numIntervalo = new System.Windows.Forms.NumericUpDown();
            this.dtpHoraHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteComportamientoVtaResultBindingSource)).BeginInit();
            this.groupBoxCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // ePKspReporteComportamientoVtaResultBindingSource
            // 
            this.ePKspReporteComportamientoVtaResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteComportamientoVta_Result);
            // 
            // rvComportamiento
            // 
            this.rvComportamiento.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsComportamiento";
            reportDataSource1.Value = this.ePKspReporteComportamientoVtaResultBindingSource;
            this.rvComportamiento.LocalReport.DataSources.Add(reportDataSource1);
            this.rvComportamiento.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptComportamiento.rdlc";
            this.rvComportamiento.Location = new System.Drawing.Point(0, 110);
            this.rvComportamiento.Name = "rvComportamiento";
            this.rvComportamiento.Size = new System.Drawing.Size(987, 456);
            this.rvComportamiento.TabIndex = 8;
            this.rvComportamiento.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvComportamiento_ReportExport);
            this.rvComportamiento.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvComportamiento_PrintingBegin);
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Controls.Add(this.label5);
            this.groupBoxCriterios.Controls.Add(this.label4);
            this.groupBoxCriterios.Controls.Add(this.label3);
            this.groupBoxCriterios.Controls.Add(this.numIntervalo);
            this.groupBoxCriterios.Controls.Add(this.dtpHoraHasta);
            this.groupBoxCriterios.Controls.Add(this.dtpHoraDesde);
            this.groupBoxCriterios.Controls.Add(this.dtpHasta);
            this.groupBoxCriterios.Controls.Add(this.dtpDesde);
            this.groupBoxCriterios.Controls.Add(this.label2);
            this.groupBoxCriterios.Controls.Add(this.label1);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(987, 110);
            this.groupBoxCriterios.TabIndex = 0;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(826, 71);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(826, 18);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 6;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(584, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Intervalo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hora Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hora Desde";
            // 
            // numIntervalo
            // 
            this.numIntervalo.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numIntervalo.Location = new System.Drawing.Point(637, 24);
            this.numIntervalo.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numIntervalo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numIntervalo.Name = "numIntervalo";
            this.numIntervalo.Size = new System.Drawing.Size(100, 20);
            this.numIntervalo.TabIndex = 3;
            this.numIntervalo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.Checked = false;
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraHasta.Location = new System.Drawing.Point(389, 57);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.ShowCheckBox = true;
            this.dtpHoraHasta.ShowUpDown = true;
            this.dtpHoraHasta.Size = new System.Drawing.Size(116, 20);
            this.dtpHoraHasta.TabIndex = 5;
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.Checked = false;
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraDesde.Location = new System.Drawing.Point(389, 24);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.ShowCheckBox = true;
            this.dtpHoraDesde.ShowUpDown = true;
            this.dtpHoraDesde.Size = new System.Drawing.Size(116, 20);
            this.dtpHoraDesde.TabIndex = 2;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(128, 57);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(99, 20);
            this.dtpHasta.TabIndex = 4;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(128, 24);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde";
            // 
            // frmComportamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.rvComportamiento);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComportamiento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmComportamiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmComportamiento_Activated);
            this.Load += new System.EventHandler(this.frmComportamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteComportamientoVtaResultBindingSource)).EndInit();
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntervalo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComportamiento;
        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numIntervalo;
        private System.Windows.Forms.DateTimePicker dtpHoraHasta;
        private System.Windows.Forms.DateTimePicker dtpHoraDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource ePKspReporteComportamientoVtaResultBindingSource;
        private System.Windows.Forms.Button btnLimpiar;
    }
}