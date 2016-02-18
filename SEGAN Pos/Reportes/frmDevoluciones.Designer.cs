namespace SEGAN_POS
{
    partial class frmDevoluciones
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
            this.txtCajero = new System.Windows.Forms.TextBox();
            this.cbCajero = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblAutorizador = new System.Windows.Forms.Label();
            this.cbAutorizador = new System.Windows.Forms.ComboBox();
            this.lblCajero = new System.Windows.Forms.Label();
            this.lblMotivoDev = new System.Windows.Forms.Label();
            this.cbMotDevolucion = new System.Windows.Forms.ComboBox();
            this.txtFactHast = new System.Windows.Forms.TextBox();
            this.lblFactHast = new System.Windows.Forms.Label();
            this.txtFactDesd = new System.Windows.Forms.TextBox();
            this.lblFactDesd = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lblGenero = new System.Windows.Forms.Label();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.lblColeccion = new System.Windows.Forms.Label();
            this.cbColeccion = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.rvDevoluciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ePKspReporteDevolucionesResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteDevolucionesResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.txtCajero);
            this.groupBoxCriterios.Controls.Add(this.cbCajero);
            this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Controls.Add(this.lblAutorizador);
            this.groupBoxCriterios.Controls.Add(this.cbAutorizador);
            this.groupBoxCriterios.Controls.Add(this.lblCajero);
            this.groupBoxCriterios.Controls.Add(this.lblMotivoDev);
            this.groupBoxCriterios.Controls.Add(this.cbMotDevolucion);
            this.groupBoxCriterios.Controls.Add(this.txtFactHast);
            this.groupBoxCriterios.Controls.Add(this.lblFactHast);
            this.groupBoxCriterios.Controls.Add(this.txtFactDesd);
            this.groupBoxCriterios.Controls.Add(this.lblFactDesd);
            this.groupBoxCriterios.Controls.Add(this.lblGrupo);
            this.groupBoxCriterios.Controls.Add(this.cbGrupo);
            this.groupBoxCriterios.Controls.Add(this.lblGenero);
            this.groupBoxCriterios.Controls.Add(this.cbGenero);
            this.groupBoxCriterios.Controls.Add(this.lblColeccion);
            this.groupBoxCriterios.Controls.Add(this.cbColeccion);
            this.groupBoxCriterios.Controls.Add(this.dtpHasta);
            this.groupBoxCriterios.Controls.Add(this.lblHasta);
            this.groupBoxCriterios.Controls.Add(this.dtpDesde);
            this.groupBoxCriterios.Controls.Add(this.lblDesde);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(987, 112);
            this.groupBoxCriterios.TabIndex = 45;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            // 
            // txtCajero
            // 
            this.txtCajero.Location = new System.Drawing.Point(639, 82);
            this.txtCajero.Name = "txtCajero";
            this.txtCajero.Size = new System.Drawing.Size(200, 20);
            this.txtCajero.TabIndex = 9;
            // 
            // cbCajero
            // 
            this.cbCajero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCajero.FormattingEnabled = true;
            this.cbCajero.Location = new System.Drawing.Point(638, 82);
            this.cbCajero.Name = "cbCajero";
            this.cbCajero.Size = new System.Drawing.Size(200, 21);
            this.cbCajero.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(851, 74);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(851, 20);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 10;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblAutorizador
            // 
            this.lblAutorizador.AutoSize = true;
            this.lblAutorizador.Location = new System.Drawing.Point(283, 85);
            this.lblAutorizador.Name = "lblAutorizador";
            this.lblAutorizador.Size = new System.Drawing.Size(76, 13);
            this.lblAutorizador.TabIndex = 60;
            this.lblAutorizador.Text = "Autorizado Por";
            this.lblAutorizador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAutorizador
            // 
            this.cbAutorizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutorizador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAutorizador.FormattingEnabled = true;
            this.cbAutorizador.Location = new System.Drawing.Point(360, 81);
            this.cbAutorizador.Name = "cbAutorizador";
            this.cbAutorizador.Size = new System.Drawing.Size(200, 21);
            this.cbAutorizador.TabIndex = 8;
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(565, 85);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(77, 13);
            this.lblCajero.TabIndex = 58;
            this.lblCajero.Text = "Facturado Por ";
            this.lblCajero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMotivoDev
            // 
            this.lblMotivoDev.AutoSize = true;
            this.lblMotivoDev.Location = new System.Drawing.Point(22, 82);
            this.lblMotivoDev.Name = "lblMotivoDev";
            this.lblMotivoDev.Size = new System.Drawing.Size(39, 13);
            this.lblMotivoDev.TabIndex = 56;
            this.lblMotivoDev.Text = "Motivo";
            this.lblMotivoDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMotDevolucion
            // 
            this.cbMotDevolucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMotDevolucion.FormattingEnabled = true;
            this.cbMotDevolucion.ItemHeight = 13;
            this.cbMotDevolucion.Location = new System.Drawing.Point(76, 77);
            this.cbMotDevolucion.Name = "cbMotDevolucion";
            this.cbMotDevolucion.Size = new System.Drawing.Size(200, 21);
            this.cbMotDevolucion.TabIndex = 7;
            // 
            // txtFactHast
            // 
            this.txtFactHast.Location = new System.Drawing.Point(739, 20);
            this.txtFactHast.MaxLength = 15;
            this.txtFactHast.Name = "txtFactHast";
            this.txtFactHast.Size = new System.Drawing.Size(100, 20);
            this.txtFactHast.TabIndex = 3;
            this.txtFactHast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactHast_KeyPress);
            // 
            // lblFactHast
            // 
            this.lblFactHast.AutoSize = true;
            this.lblFactHast.Location = new System.Drawing.Point(647, 23);
            this.lblFactHast.Name = "lblFactHast";
            this.lblFactHast.Size = new System.Drawing.Size(89, 13);
            this.lblFactHast.TabIndex = 53;
            this.lblFactHast.Text = "N° Factura Hasta";
            // 
            // txtFactDesd
            // 
            this.txtFactDesd.Location = new System.Drawing.Point(529, 20);
            this.txtFactDesd.MaxLength = 15;
            this.txtFactDesd.Name = "txtFactDesd";
            this.txtFactDesd.Size = new System.Drawing.Size(100, 20);
            this.txtFactDesd.TabIndex = 2;
            this.txtFactDesd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactDesd_KeyPress);
            // 
            // lblFactDesd
            // 
            this.lblFactDesd.AutoSize = true;
            this.lblFactDesd.Location = new System.Drawing.Point(434, 23);
            this.lblFactDesd.Name = "lblFactDesd";
            this.lblFactDesd.Size = new System.Drawing.Size(92, 13);
            this.lblFactDesd.TabIndex = 51;
            this.lblFactDesd.Text = "N° Factura Desde";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(322, 53);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(36, 13);
            this.lblGrupo.TabIndex = 50;
            this.lblGrupo.Text = "Grupo";
            this.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(360, 49);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(200, 21);
            this.cbGrupo.TabIndex = 5;
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(593, 53);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 48;
            this.lblGenero.Text = "Género";
            this.lblGenero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGenero
            // 
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(639, 49);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(200, 21);
            this.cbGenero.TabIndex = 6;
            // 
            // lblColeccion
            // 
            this.lblColeccion.AutoSize = true;
            this.lblColeccion.Location = new System.Drawing.Point(22, 53);
            this.lblColeccion.Name = "lblColeccion";
            this.lblColeccion.Size = new System.Drawing.Size(54, 13);
            this.lblColeccion.TabIndex = 46;
            this.lblColeccion.Text = "Colección";
            this.lblColeccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbColeccion
            // 
            this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbColeccion.FormattingEnabled = true;
            this.cbColeccion.Location = new System.Drawing.Point(77, 49);
            this.cbColeccion.Name = "cbColeccion";
            this.cbColeccion.Size = new System.Drawing.Size(200, 21);
            this.cbColeccion.TabIndex = 4;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(309, 20);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(105, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(238, 23);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(68, 13);
            this.lblHasta.TabIndex = 41;
            this.lblHasta.Text = "Fecha Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(96, 21);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(121, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(22, 24);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(71, 13);
            this.lblDesde.TabIndex = 39;
            this.lblDesde.Text = "Fecha Desde";
            // 
            // rvDevoluciones
            // 
            this.rvDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsDevoluciones";
            reportDataSource1.Value = this.ePKspReporteDevolucionesResultBindingSource;
            this.rvDevoluciones.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDevoluciones.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Reportes.rptDevoluciones.rdlc";
            this.rvDevoluciones.Location = new System.Drawing.Point(0, 112);
            this.rvDevoluciones.Margin = new System.Windows.Forms.Padding(4, 4, 3, 3);
            this.rvDevoluciones.Name = "rvDevoluciones";
            this.rvDevoluciones.Size = new System.Drawing.Size(987, 454);
            this.rvDevoluciones.TabIndex = 14;
            this.rvDevoluciones.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvDevoluciones_ReportExport);
            this.rvDevoluciones.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvDevoluciones_PrintingBegin);
            // 
            // ePKspReporteDevolucionesResultBindingSource
            // 
            this.ePKspReporteDevolucionesResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ReporteDevoluciones_Result);
            // 
            // frmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 566);
            this.Controls.Add(this.rvDevoluciones);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDevoluciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDevoluciones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmDevoluciones_Activated);
            this.Load += new System.EventHandler(this.frmDevoluciones_Load);
            this.Shown += new System.EventHandler(this.frmDevoluciones_Shown);
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspReporteDevolucionesResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label lblColeccion;
        private System.Windows.Forms.ComboBox cbColeccion;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblAutorizador;
        private System.Windows.Forms.ComboBox cbAutorizador;
        private System.Windows.Forms.Label lblCajero;
        private System.Windows.Forms.Label lblMotivoDev;
        private System.Windows.Forms.ComboBox cbMotDevolucion;
        private System.Windows.Forms.TextBox txtFactHast;
        private System.Windows.Forms.Label lblFactHast;
        private System.Windows.Forms.TextBox txtFactDesd;
        private System.Windows.Forms.Label lblFactDesd;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btBuscar;
        private Microsoft.Reporting.WinForms.ReportViewer rvDevoluciones;
        private System.Windows.Forms.ComboBox cbCajero;
        private System.Windows.Forms.TextBox txtCajero;
        private System.Windows.Forms.BindingSource ePKspReporteDevolucionesResultBindingSource;
    }
}