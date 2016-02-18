namespace SEGAN_POS.Facturacion
{
    partial class frmBuscarFacturaManual
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNumFactM = new System.Windows.Forms.Label();
            this.txNFactM = new System.Windows.Forms.TextBox();
            this.lbFactDesd = new System.Windows.Forms.Label();
            this.lbFactHasta = new System.Windows.Forms.Label();
            this.lbControl = new System.Windows.Forms.Label();
            this.txNControlM = new System.Windows.Forms.TextBox();
            this.lbTienda = new System.Windows.Forms.Label();
            this.lbDocCliente = new System.Windows.Forms.Label();
            this.txDocCliente = new System.Windows.Forms.TextBox();
            this.cbTienda = new System.Windows.Forms.ComboBox();
            this.btBuscarFactM = new System.Windows.Forms.Button();
            this.dgFactManual = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btAgregarFactM = new System.Windows.Forms.Button();
            this.lbCantReg = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFactManual)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpHasta);
            this.panel1.Controls.Add(this.dtpDesde);
            this.panel1.Controls.Add(this.lbCantReg);
            this.panel1.Controls.Add(this.btAgregarFactM);
            this.panel1.Controls.Add(this.btLimpiar);
            this.panel1.Controls.Add(this.dgFactManual);
            this.panel1.Controls.Add(this.btBuscarFactM);
            this.panel1.Controls.Add(this.cbTienda);
            this.panel1.Controls.Add(this.txDocCliente);
            this.panel1.Controls.Add(this.lbDocCliente);
            this.panel1.Controls.Add(this.lbTienda);
            this.panel1.Controls.Add(this.txNControlM);
            this.panel1.Controls.Add(this.lbControl);
            this.panel1.Controls.Add(this.lbFactHasta);
            this.panel1.Controls.Add(this.lbFactDesd);
            this.panel1.Controls.Add(this.txNFactM);
            this.panel1.Controls.Add(this.lbNumFactM);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 431);
            this.panel1.TabIndex = 0;
            // 
            // lbNumFactM
            // 
            this.lbNumFactM.AutoSize = true;
            this.lbNumFactM.Location = new System.Drawing.Point(14, 11);
            this.lbNumFactM.Name = "lbNumFactM";
            this.lbNumFactM.Size = new System.Drawing.Size(73, 13);
            this.lbNumFactM.TabIndex = 0;
            this.lbNumFactM.Text = "N° de Factura";
            // 
            // txNFactM
            // 
            this.txNFactM.Location = new System.Drawing.Point(106, 11);
            this.txNFactM.Name = "txNFactM";
            this.txNFactM.Size = new System.Drawing.Size(150, 20);
            this.txNFactM.TabIndex = 1;
            // 
            // lbFactDesd
            // 
            this.lbFactDesd.AutoSize = true;
            this.lbFactDesd.Location = new System.Drawing.Point(14, 59);
            this.lbFactDesd.Name = "lbFactDesd";
            this.lbFactDesd.Size = new System.Drawing.Size(71, 13);
            this.lbFactDesd.TabIndex = 2;
            this.lbFactDesd.Text = "Fecha Desde";
            // 
            // lbFactHasta
            // 
            this.lbFactHasta.AutoSize = true;
            this.lbFactHasta.Location = new System.Drawing.Point(283, 57);
            this.lbFactHasta.Name = "lbFactHasta";
            this.lbFactHasta.Size = new System.Drawing.Size(68, 13);
            this.lbFactHasta.TabIndex = 3;
            this.lbFactHasta.Text = "Fecha Hasta";
            // 
            // lbControl
            // 
            this.lbControl.AutoSize = true;
            this.lbControl.Location = new System.Drawing.Point(283, 14);
            this.lbControl.Name = "lbControl";
            this.lbControl.Size = new System.Drawing.Size(70, 13);
            this.lbControl.TabIndex = 6;
            this.lbControl.Text = "N° de Control";
            // 
            // txNControlM
            // 
            this.txNControlM.Location = new System.Drawing.Point(371, 10);
            this.txNControlM.Name = "txNControlM";
            this.txNControlM.Size = new System.Drawing.Size(150, 20);
            this.txNControlM.TabIndex = 7;
            // 
            // lbTienda
            // 
            this.lbTienda.AutoSize = true;
            this.lbTienda.Location = new System.Drawing.Point(534, 11);
            this.lbTienda.Name = "lbTienda";
            this.lbTienda.Size = new System.Drawing.Size(40, 13);
            this.lbTienda.TabIndex = 8;
            this.lbTienda.Text = "Tienda";
            // 
            // lbDocCliente
            // 
            this.lbDocCliente.AutoSize = true;
            this.lbDocCliente.Location = new System.Drawing.Point(534, 57);
            this.lbDocCliente.Name = "lbDocCliente";
            this.lbDocCliente.Size = new System.Drawing.Size(65, 13);
            this.lbDocCliente.TabIndex = 9;
            this.lbDocCliente.Text = "Doc. Cliente";
            // 
            // txDocCliente
            // 
            this.txDocCliente.Location = new System.Drawing.Point(624, 54);
            this.txDocCliente.Name = "txDocCliente";
            this.txDocCliente.Size = new System.Drawing.Size(150, 20);
            this.txDocCliente.TabIndex = 10;
            // 
            // cbTienda
            // 
            this.cbTienda.BackColor = System.Drawing.SystemColors.Window;
            this.cbTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTienda.FormattingEnabled = true;
            this.cbTienda.Location = new System.Drawing.Point(624, 8);
            this.cbTienda.Name = "cbTienda";
            this.cbTienda.Size = new System.Drawing.Size(150, 21);
            this.cbTienda.TabIndex = 11;
            // 
            // btBuscarFactM
            // 
            this.btBuscarFactM.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscarFactM.Location = new System.Drawing.Point(836, 5);
            this.btBuscarFactM.Name = "btBuscarFactM";
            this.btBuscarFactM.Size = new System.Drawing.Size(75, 30);
            this.btBuscarFactM.TabIndex = 12;
            this.btBuscarFactM.Text = "Buscar";
            this.btBuscarFactM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscarFactM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscarFactM.UseVisualStyleBackColor = true;
            // 
            // dgFactManual
            // 
            this.dgFactManual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFactManual.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgFactManual.Location = new System.Drawing.Point(17, 122);
            this.dgFactManual.Name = "dgFactManual";
            this.dgFactManual.Size = new System.Drawing.Size(894, 234);
            this.dgFactManual.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nro Factura";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nro de Control";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tienda";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cliente";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Monto de Factura";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // btLimpiar
            // 
            this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btLimpiar.Location = new System.Drawing.Point(836, 58);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btLimpiar.TabIndex = 14;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiar.UseVisualStyleBackColor = true;
            // 
            // btAgregarFactM
            // 
            this.btAgregarFactM.Image = global::SEGAN_POS.Properties.Resources.agregar2;
            this.btAgregarFactM.Location = new System.Drawing.Point(814, 368);
            this.btAgregarFactM.Name = "btAgregarFactM";
            this.btAgregarFactM.Size = new System.Drawing.Size(97, 46);
            this.btAgregarFactM.TabIndex = 15;
            this.btAgregarFactM.Text = "Agregar Factura";
            this.btAgregarFactM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btAgregarFactM.UseVisualStyleBackColor = true;
            // 
            // lbCantReg
            // 
            this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantReg.AutoSize = true;
            this.lbCantReg.Location = new System.Drawing.Point(14, 368);
            this.lbCantReg.Name = "lbCantReg";
            this.lbCantReg.Size = new System.Drawing.Size(108, 13);
            this.lbCantReg.TabIndex = 82;
            this.lbCantReg.Text = "registros encontrados";
            this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCantReg.Visible = false;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(106, 52);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(150, 20);
            this.dtpDesde.TabIndex = 83;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(371, 54);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(150, 20);
            this.dtpHasta.TabIndex = 84;
            // 
            // frmBuscarFacturaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 455);
            this.Controls.Add(this.panel1);
            this.Name = "frmBuscarFacturaManual";
            this.Text = "frmBuscarFacturaManual";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFactManual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNumFactM;
        private System.Windows.Forms.Label lbFactHasta;
        private System.Windows.Forms.Label lbFactDesd;
        private System.Windows.Forms.TextBox txNFactM;
        private System.Windows.Forms.Label lbDocCliente;
        private System.Windows.Forms.Label lbTienda;
        private System.Windows.Forms.TextBox txNControlM;
        private System.Windows.Forms.Label lbControl;
        private System.Windows.Forms.ComboBox cbTienda;
        private System.Windows.Forms.TextBox txDocCliente;
        internal System.Windows.Forms.Button btBuscarFactM;
        private System.Windows.Forms.DataGridView dgFactManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btAgregarFactM;
        private System.Windows.Forms.Label lbCantReg;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
    }
}