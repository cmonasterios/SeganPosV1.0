namespace SEGAN_POS
{
    partial class frmAutorizarAlivio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutorizarAlivio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txFechaAlivio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txIdAlivio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txCajero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.txDiferencia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txMontoAlivio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txMontoSistema = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txMontoAprobado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grdAlivio = new System.Windows.Forms.DataGridView();
            this.idDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.denominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadCajeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoCajeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadAprobadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAprobadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alivioAutorizacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdAlivio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alivioAutorizacionBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txFechaAlivio
            // 
            this.txFechaAlivio.BackColor = System.Drawing.SystemColors.Control;
            this.txFechaAlivio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txFechaAlivio.Enabled = false;
            this.txFechaAlivio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txFechaAlivio.Location = new System.Drawing.Point(502, 56);
            this.txFechaAlivio.MaxLength = 50;
            this.txFechaAlivio.Name = "txFechaAlivio";
            this.txFechaAlivio.Size = new System.Drawing.Size(237, 22);
            this.txFechaAlivio.TabIndex = 20;
            this.txFechaAlivio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Último Alivio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txIdAlivio
            // 
            this.txIdAlivio.BackColor = System.Drawing.SystemColors.Control;
            this.txIdAlivio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txIdAlivio.Enabled = false;
            this.txIdAlivio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txIdAlivio.Location = new System.Drawing.Point(111, 56);
            this.txIdAlivio.MaxLength = 50;
            this.txIdAlivio.Name = "txIdAlivio";
            this.txIdAlivio.Size = new System.Drawing.Size(206, 22);
            this.txIdAlivio.TabIndex = 18;
            this.txIdAlivio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Control Alivio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txCaja
            // 
            this.txCaja.BackColor = System.Drawing.SystemColors.Control;
            this.txCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txCaja.Enabled = false;
            this.txCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txCaja.Location = new System.Drawing.Point(502, 26);
            this.txCaja.MaxLength = 50;
            this.txCaja.Name = "txCaja";
            this.txCaja.Size = new System.Drawing.Size(237, 22);
            this.txCaja.TabIndex = 16;
            this.txCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Caja";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txCajero
            // 
            this.txCajero.BackColor = System.Drawing.SystemColors.Control;
            this.txCajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txCajero.Enabled = false;
            this.txCajero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txCajero.Location = new System.Drawing.Point(111, 26);
            this.txCajero.MaxLength = 50;
            this.txCajero.Name = "txCajero";
            this.txCajero.Size = new System.Drawing.Size(206, 22);
            this.txCajero.TabIndex = 14;
            this.txCajero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cajero";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(98, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 33);
            this.btCancel.TabIndex = 33;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = ((System.Drawing.Image)(resources.GetObject("btOK.Image")));
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(10, 3);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 32;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // txDiferencia
            // 
            this.txDiferencia.BackColor = System.Drawing.SystemColors.Control;
            this.txDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txDiferencia.Location = new System.Drawing.Point(570, 419);
            this.txDiferencia.MaxLength = 50;
            this.txDiferencia.Name = "txDiferencia";
            this.txDiferencia.ReadOnly = true;
            this.txDiferencia.Size = new System.Drawing.Size(168, 22);
            this.txDiferencia.TabIndex = 28;
            this.txDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(475, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Diferencia";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoAlivio
            // 
            this.txMontoAlivio.BackColor = System.Drawing.SystemColors.Control;
            this.txMontoAlivio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMontoAlivio.Enabled = false;
            this.txMontoAlivio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txMontoAlivio.Location = new System.Drawing.Point(570, 392);
            this.txMontoAlivio.MaxLength = 50;
            this.txMontoAlivio.Name = "txMontoAlivio";
            this.txMontoAlivio.Size = new System.Drawing.Size(168, 22);
            this.txMontoAlivio.TabIndex = 26;
            this.txMontoAlivio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Monto del Alivio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoSistema
            // 
            this.txMontoSistema.BackColor = System.Drawing.SystemColors.Control;
            this.txMontoSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMontoSistema.Enabled = false;
            this.txMontoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txMontoSistema.Location = new System.Drawing.Point(280, 392);
            this.txMontoSistema.MaxLength = 50;
            this.txMontoSistema.Name = "txMontoSistema";
            this.txMontoSistema.Size = new System.Drawing.Size(168, 22);
            this.txMontoSistema.TabIndex = 24;
            this.txMontoSistema.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Monto del Sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoAprobado
            // 
            this.txMontoAprobado.BackColor = System.Drawing.SystemColors.Control;
            this.txMontoAprobado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMontoAprobado.Enabled = false;
            this.txMontoAprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txMontoAprobado.Location = new System.Drawing.Point(280, 419);
            this.txMontoAprobado.MaxLength = 50;
            this.txMontoAprobado.Name = "txMontoAprobado";
            this.txMontoAprobado.Size = new System.Drawing.Size(168, 22);
            this.txMontoAprobado.TabIndex = 34;
            this.txMontoAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Monto Aprobado";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdAlivio
            // 
            this.grdAlivio.AllowUserToAddRows = false;
            this.grdAlivio.AllowUserToDeleteRows = false;
            this.grdAlivio.AllowUserToResizeColumns = false;
            this.grdAlivio.AllowUserToResizeRows = false;
            this.grdAlivio.AutoGenerateColumns = false;
            this.grdAlivio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAlivio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDenominacionDataGridViewTextBoxColumn,
            this.logoDataGridViewImageColumn,
            this.denominacionDataGridViewTextBoxColumn,
            this.cantidadCajeroDataGridViewTextBoxColumn,
            this.montoCajeroDataGridViewTextBoxColumn,
            this.cantidadAprobadaDataGridViewTextBoxColumn,
            this.montoAprobadoDataGridViewTextBoxColumn,
            this.diferenciaDataGridViewTextBoxColumn});
            this.grdAlivio.DataSource = this.alivioAutorizacionBindingSource;
            this.grdAlivio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdAlivio.Location = new System.Drawing.Point(12, 95);
            this.grdAlivio.Name = "grdAlivio";
            this.grdAlivio.RowHeadersVisible = false;
            this.grdAlivio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAlivio.Size = new System.Drawing.Size(727, 276);
            this.grdAlivio.TabIndex = 36;
            this.grdAlivio.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdAlivio_CellBeginEdit);
            this.grdAlivio.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAlivio_CellDoubleClick);
            this.grdAlivio.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdAlivio_DataError);
            // 
            // idDenominacionDataGridViewTextBoxColumn
            // 
            this.idDenominacionDataGridViewTextBoxColumn.DataPropertyName = "IdDenominacion";
            this.idDenominacionDataGridViewTextBoxColumn.HeaderText = "IdDenominacion";
            this.idDenominacionDataGridViewTextBoxColumn.Name = "idDenominacionDataGridViewTextBoxColumn";
            this.idDenominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDenominacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // logoDataGridViewImageColumn
            // 
            this.logoDataGridViewImageColumn.DataPropertyName = "Logo";
            this.logoDataGridViewImageColumn.HeaderText = "";
            this.logoDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.logoDataGridViewImageColumn.Name = "logoDataGridViewImageColumn";
            this.logoDataGridViewImageColumn.ReadOnly = true;
            this.logoDataGridViewImageColumn.Width = 40;
            // 
            // denominacionDataGridViewTextBoxColumn
            // 
            this.denominacionDataGridViewTextBoxColumn.DataPropertyName = "Denominacion";
            this.denominacionDataGridViewTextBoxColumn.HeaderText = "Denominación";
            this.denominacionDataGridViewTextBoxColumn.Name = "denominacionDataGridViewTextBoxColumn";
            this.denominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.denominacionDataGridViewTextBoxColumn.Width = 80;
            // 
            // cantidadCajeroDataGridViewTextBoxColumn
            // 
            this.cantidadCajeroDataGridViewTextBoxColumn.DataPropertyName = "CantidadCajero";
            this.cantidadCajeroDataGridViewTextBoxColumn.HeaderText = "Cantidad Reportada";
            this.cantidadCajeroDataGridViewTextBoxColumn.Name = "cantidadCajeroDataGridViewTextBoxColumn";
            this.cantidadCajeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadCajeroDataGridViewTextBoxColumn.Width = 110;
            // 
            // montoCajeroDataGridViewTextBoxColumn
            // 
            this.montoCajeroDataGridViewTextBoxColumn.DataPropertyName = "MontoCajero";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.montoCajeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.montoCajeroDataGridViewTextBoxColumn.HeaderText = "Monto Reportado";
            this.montoCajeroDataGridViewTextBoxColumn.Name = "montoCajeroDataGridViewTextBoxColumn";
            this.montoCajeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoCajeroDataGridViewTextBoxColumn.Width = 110;
            // 
            // cantidadAprobadaDataGridViewTextBoxColumn
            // 
            this.cantidadAprobadaDataGridViewTextBoxColumn.DataPropertyName = "CantidadAprobada";
            this.cantidadAprobadaDataGridViewTextBoxColumn.HeaderText = "Cantidad Aprobada";
            this.cantidadAprobadaDataGridViewTextBoxColumn.Name = "cantidadAprobadaDataGridViewTextBoxColumn";
            this.cantidadAprobadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadAprobadaDataGridViewTextBoxColumn.Width = 130;
            // 
            // montoAprobadoDataGridViewTextBoxColumn
            // 
            this.montoAprobadoDataGridViewTextBoxColumn.DataPropertyName = "MontoAprobado";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.montoAprobadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoAprobadoDataGridViewTextBoxColumn.HeaderText = "Monto Aprobado";
            this.montoAprobadoDataGridViewTextBoxColumn.Name = "montoAprobadoDataGridViewTextBoxColumn";
            this.montoAprobadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAprobadoDataGridViewTextBoxColumn.Width = 120;
            // 
            // diferenciaDataGridViewTextBoxColumn
            // 
            this.diferenciaDataGridViewTextBoxColumn.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.diferenciaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.diferenciaDataGridViewTextBoxColumn.HeaderText = "Diferencia";
            this.diferenciaDataGridViewTextBoxColumn.Name = "diferenciaDataGridViewTextBoxColumn";
            this.diferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // alivioAutorizacionBindingSource
            // 
            this.alivioAutorizacionBindingSource.DataSource = typeof(SEGAN_POS.DAL.AlivioAutorizacion);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 45);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(558, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 45);
            this.panel2.TabIndex = 0;
            // 
            // frmAutorizarAlivio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(751, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdAlivio);
            this.Controls.Add(this.txMontoAprobado);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txDiferencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txMontoAlivio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txMontoSistema);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txFechaAlivio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txIdAlivio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txCaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txCajero);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutorizarAlivio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAutorizarAlivio";
            this.Activated += new System.EventHandler(this.frmAutorizarAlivio_Activated);
            this.Load += new System.EventHandler(this.frmAutorizarAlivio_Load);
            this.Shown += new System.EventHandler(this.frmAutorizarAlivio_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlivio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alivioAutorizacionBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txFechaAlivio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txIdAlivio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txCajero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.TextBox txDiferencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txMontoAlivio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txMontoSistema;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txMontoAprobado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grdAlivio;
        private System.Windows.Forms.BindingSource alivioAutorizacionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDenominacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn logoDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn denominacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadCajeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoCajeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadAprobadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAprobadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}