namespace SEGAN_POS
{
    partial class frmMenuMF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuMF));
            this.btReporteX = new System.Windows.Forms.Button();
            this.btEjecutar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnFecha = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.panelRangoFechas = new System.Windows.Forms.Panel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRagoZ = new System.Windows.Forms.Panel();
            this.udHasta = new System.Windows.Forms.NumericUpDown();
            this.udDesde = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.labelSerialMF = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnFecha.SuspendLayout();
            this.panelRangoFechas.SuspendLayout();
            this.panelRagoZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHasta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDesde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btReporteX
            // 
            this.btReporteX.Image = ((System.Drawing.Image)(resources.GetObject("btReporteX.Image")));
            this.btReporteX.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btReporteX.Location = new System.Drawing.Point(355, 33);
            this.btReporteX.Name = "btReporteX";
            this.btReporteX.Size = new System.Drawing.Size(98, 67);
            this.btReporteX.TabIndex = 1;
            this.btReporteX.Text = "Reporte X";
            this.btReporteX.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btReporteX.UseVisualStyleBackColor = true;
            this.btReporteX.Click += new System.EventHandler(this.btReporteX_Click);
            // 
            // btEjecutar
            // 
            this.btEjecutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEjecutar.ForeColor = System.Drawing.Color.Black;
            this.btEjecutar.Image = global::SEGAN_POS.Properties.Resources.ejecutar;
            this.btEjecutar.Location = new System.Drawing.Point(327, 29);
            this.btEjecutar.Name = "btEjecutar";
            this.btEjecutar.Size = new System.Drawing.Size(98, 55);
            this.btEjecutar.TabIndex = 2;
            this.btEjecutar.Text = "Ejecutar";
            this.btEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEjecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btEjecutar.UseVisualStyleBackColor = true;
            this.btEjecutar.Click += new System.EventHandler(this.btEjecutar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnFecha);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.btEjecutar);
            this.groupBox1.Controls.Add(this.panelRangoFechas);
            this.groupBox1.Controls.Add(this.panelRagoZ);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(28, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 160);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informes Fiscales";
            // 
            // pnFecha
            // 
            this.pnFecha.Controls.Add(this.dtpFecha);
            this.pnFecha.Controls.Add(this.label6);
            this.pnFecha.Location = new System.Drawing.Point(48, 58);
            this.pnFecha.Name = "pnFecha";
            this.pnFecha.Size = new System.Drawing.Size(200, 82);
            this.pnFecha.TabIndex = 39;
            this.pnFecha.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(74, 13);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 21);
            this.dtpFecha.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fecha";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Reporte Z Del Día",
            "Mensual Detallado",
            "Mensual Consolidado",
            "Rango de Z",
            "Verificar Reporte Z Automático",
            "Cierre de Máquina Fiscal por Día",
            "Reimprimir Facturas por Fecha",
            "Reimprimir Facturas por COO",
            "Verificar Estado de la Impresora"});
            this.cbTipo.Location = new System.Drawing.Point(20, 29);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(231, 23);
            this.cbTipo.TabIndex = 0;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // panelRangoFechas
            // 
            this.panelRangoFechas.Controls.Add(this.dtpHasta);
            this.panelRangoFechas.Controls.Add(this.dtpDesde);
            this.panelRangoFechas.Controls.Add(this.label2);
            this.panelRangoFechas.Controls.Add(this.label1);
            this.panelRangoFechas.Location = new System.Drawing.Point(48, 58);
            this.panelRangoFechas.Name = "panelRangoFechas";
            this.panelRangoFechas.Size = new System.Drawing.Size(200, 82);
            this.panelRangoFechas.TabIndex = 38;
            this.panelRangoFechas.Visible = false;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(60, 51);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(120, 23);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(60, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 23);
            this.dtpDesde.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // panelRagoZ
            // 
            this.panelRagoZ.Controls.Add(this.udHasta);
            this.panelRagoZ.Controls.Add(this.udDesde);
            this.panelRagoZ.Controls.Add(this.label3);
            this.panelRagoZ.Controls.Add(this.label4);
            this.panelRagoZ.Location = new System.Drawing.Point(51, 58);
            this.panelRagoZ.Name = "panelRagoZ";
            this.panelRagoZ.Size = new System.Drawing.Size(200, 82);
            this.panelRagoZ.TabIndex = 40;
            this.panelRagoZ.Visible = false;
            // 
            // udHasta
            // 
            this.udHasta.Location = new System.Drawing.Point(60, 51);
            this.udHasta.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udHasta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udHasta.Name = "udHasta";
            this.udHasta.Size = new System.Drawing.Size(120, 23);
            this.udHasta.TabIndex = 3;
            this.udHasta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // udDesde
            // 
            this.udDesde.Location = new System.Drawing.Point(60, 13);
            this.udDesde.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.udDesde.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udDesde.Name = "udDesde";
            this.udDesde.Size = new System.Drawing.Size(120, 23);
            this.udDesde.TabIndex = 2;
            this.udDesde.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Desde";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.epklogo;
            this.pictureBox1.Location = new System.Drawing.Point(28, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(400, 311);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 33);
            this.btCancel.TabIndex = 39;
            this.btCancel.Text = "Cerrar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // labelSerialMF
            // 
            this.labelSerialMF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerialMF.ForeColor = System.Drawing.Color.White;
            this.labelSerialMF.Location = new System.Drawing.Point(28, 311);
            this.labelSerialMF.Name = "labelSerialMF";
            this.labelSerialMF.Size = new System.Drawing.Size(270, 23);
            this.labelSerialMF.TabIndex = 40;
            // 
            // frmMenuMF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(147)))), ((int)(((byte)(148)))));
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(501, 356);
            this.Controls.Add(this.labelSerialMF);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btReporteX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMenuMF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMenuMF";
            this.Activated += new System.EventHandler(this.frmMenuMF_Activated);
            this.Load += new System.EventHandler(this.frmMenuMF_Load);
            this.groupBox1.ResumeLayout(false);
            this.pnFecha.ResumeLayout(false);
            this.pnFecha.PerformLayout();
            this.panelRangoFechas.ResumeLayout(false);
            this.panelRangoFechas.PerformLayout();
            this.panelRagoZ.ResumeLayout(false);
            this.panelRagoZ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udHasta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udDesde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btReporteX;
        private System.Windows.Forms.Button btEjecutar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Panel panelRangoFechas;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRagoZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown udHasta;
        private System.Windows.Forms.NumericUpDown udDesde;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label labelSerialMF;
        private System.Windows.Forms.Panel pnFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label6;
    }
}