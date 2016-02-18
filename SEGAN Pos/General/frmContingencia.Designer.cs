namespace SEGAN_POS
{
  partial class frmContingencia
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
      if (disposing && (components != null)) {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.txUltimaNC = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btRefrescar = new System.Windows.Forms.Button();
      this.txUltimaF = new System.Windows.Forms.TextBox();
      this.btOK = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.txLogin = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label3 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.dgItems = new System.Windows.Forms.DataGridView();
      this.idCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.descCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ultimaFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimaNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimaApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimoAlivio = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimoCierreCajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UltimoCierreVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fechaModificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cajaContingenciaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tmRefresh = new System.Windows.Forms.Timer(this.components);
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cajaContingenciaBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.txUltimaNC);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.btRefrescar);
      this.panel1.Controls.Add(this.txUltimaF);
      this.panel1.Controls.Add(this.btOK);
      this.panel1.Controls.Add(this.btCancelar);
      this.panel1.Controls.Add(this.txLogin);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.txPassword);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 378);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(918, 92);
      this.panel1.TabIndex = 4;
      // 
      // txUltimaNC
      // 
      this.txUltimaNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txUltimaNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txUltimaNC.Location = new System.Drawing.Point(321, 10);
      this.txUltimaNC.Name = "txUltimaNC";
      this.txUltimaNC.ReadOnly = true;
      this.txUltimaNC.Size = new System.Drawing.Size(100, 23);
      this.txUltimaNC.TabIndex = 30;
      this.txUltimaNC.TabStop = false;
      this.txUltimaNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(216, 8);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(99, 26);
      this.label5.TabIndex = 29;
      this.label5.Text = "Ultima Nota de Crédito Generada";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btRefrescar
      // 
      this.btRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btRefrescar.CausesValidation = false;
      this.btRefrescar.Image = global::SEGAN_POS.Properties.Resources.refrescar;
      this.btRefrescar.Location = new System.Drawing.Point(697, 48);
      this.btRefrescar.Name = "btRefrescar";
      this.btRefrescar.Size = new System.Drawing.Size(32, 32);
      this.btRefrescar.TabIndex = 28;
      this.btRefrescar.TabStop = false;
      this.btRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btRefrescar.UseVisualStyleBackColor = true;
      this.btRefrescar.Click += new System.EventHandler(this.btRefrescar_Click);
      // 
      // txUltimaF
      // 
      this.txUltimaF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txUltimaF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txUltimaF.Location = new System.Drawing.Point(99, 10);
      this.txUltimaF.Name = "txUltimaF";
      this.txUltimaF.ReadOnly = true;
      this.txUltimaF.Size = new System.Drawing.Size(100, 23);
      this.txUltimaF.TabIndex = 27;
      this.txUltimaF.TabStop = false;
      this.txUltimaF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.AutoSize = true;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(735, 48);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 4;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancelar.Location = new System.Drawing.Point(823, 48);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(83, 32);
      this.btCancelar.TabIndex = 5;
      this.btCancelar.TabStop = false;
      this.btCancelar.Text = "Cancelar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // txLogin
      // 
      this.txLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txLogin.Location = new System.Drawing.Point(570, 12);
      this.txLogin.Name = "txLogin";
      this.txLogin.Size = new System.Drawing.Size(145, 20);
      this.txLogin.TabIndex = 1;
      this.txLogin.Enter += new System.EventHandler(this.txLogin_Enter);
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(14, 8);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 26);
      this.label4.TabIndex = 23;
      this.label4.Text = "Ultima Factura Generada";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(521, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Usuario";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txPassword
      // 
      this.txPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txPassword.Location = new System.Drawing.Point(761, 12);
      this.txPassword.Name = "txPassword";
      this.txPassword.PasswordChar = '*';
      this.txPassword.Size = new System.Drawing.Size(145, 20);
      this.txPassword.TabIndex = 2;
      this.txPassword.UseSystemPasswordChar = true;
      this.txPassword.Enter += new System.EventHandler(this.txPassword_Enter);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(721, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Clave";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.advertencia;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(84, 12);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(347, 48);
      this.label3.TabIndex = 21;
      this.label3.Text = "Activación de Contingencia";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label3);
      this.panel3.Controls.Add(this.pictureBox1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(918, 73);
      this.panel3.TabIndex = 24;
      // 
      // dgItems
      // 
      this.dgItems.AllowUserToAddRows = false;
      this.dgItems.AllowUserToDeleteRows = false;
      this.dgItems.AllowUserToResizeColumns = false;
      this.dgItems.AllowUserToResizeRows = false;
      this.dgItems.AutoGenerateColumns = false;
      dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
      this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCajaDataGridViewTextBoxColumn,
            this.descCajaDataGridViewTextBoxColumn,
            this.ultimaFacturaDataGridViewTextBoxColumn,
            this.UltimoPago,
            this.UltimaNC,
            this.UltimoCliente,
            this.UltimaApertura,
            this.UltimoAlivio,
            this.UltimoCierreCajero,
            this.UltimoCierreVentas,
            this.fechaModificacionDataGridViewTextBoxColumn});
      this.dgItems.DataSource = this.cajaContingenciaBindingSource;
      dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle23.Format = "N2";
      dataGridViewCellStyle23.NullValue = null;
      dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgItems.DefaultCellStyle = dataGridViewCellStyle23;
      this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgItems.Location = new System.Drawing.Point(0, 73);
      this.dgItems.Name = "dgItems";
      dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
      this.dgItems.RowHeadersVisible = false;
      this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgItems.ShowEditingIcon = false;
      this.dgItems.Size = new System.Drawing.Size(918, 305);
      this.dgItems.TabIndex = 26;
      this.dgItems.TabStop = false;
      this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
      this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
      // 
      // idCajaDataGridViewTextBoxColumn
      // 
      this.idCajaDataGridViewTextBoxColumn.DataPropertyName = "idCaja";
      this.idCajaDataGridViewTextBoxColumn.HeaderText = "idCaja";
      this.idCajaDataGridViewTextBoxColumn.Name = "idCajaDataGridViewTextBoxColumn";
      this.idCajaDataGridViewTextBoxColumn.Visible = false;
      // 
      // descCajaDataGridViewTextBoxColumn
      // 
      this.descCajaDataGridViewTextBoxColumn.DataPropertyName = "DescCaja";
      this.descCajaDataGridViewTextBoxColumn.HeaderText = "Caja";
      this.descCajaDataGridViewTextBoxColumn.Name = "descCajaDataGridViewTextBoxColumn";
      this.descCajaDataGridViewTextBoxColumn.Width = 150;
      // 
      // ultimaFacturaDataGridViewTextBoxColumn
      // 
      this.ultimaFacturaDataGridViewTextBoxColumn.DataPropertyName = "UltimaFactura";
      dataGridViewCellStyle14.Format = "D";
      dataGridViewCellStyle14.NullValue = "0";
      this.ultimaFacturaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
      this.ultimaFacturaDataGridViewTextBoxColumn.HeaderText = "Ultima Factura";
      this.ultimaFacturaDataGridViewTextBoxColumn.Name = "ultimaFacturaDataGridViewTextBoxColumn";
      this.ultimaFacturaDataGridViewTextBoxColumn.Width = 80;
      // 
      // UltimoPago
      // 
      this.UltimoPago.DataPropertyName = "UltimoPago";
      dataGridViewCellStyle15.Format = "D";
      dataGridViewCellStyle15.NullValue = "0";
      this.UltimoPago.DefaultCellStyle = dataGridViewCellStyle15;
      this.UltimoPago.HeaderText = "Ultimo Pago";
      this.UltimoPago.Name = "UltimoPago";
      this.UltimoPago.Width = 80;
      // 
      // UltimaNC
      // 
      this.UltimaNC.DataPropertyName = "UltimaNC";
      dataGridViewCellStyle16.Format = "D";
      dataGridViewCellStyle16.NullValue = "0";
      this.UltimaNC.DefaultCellStyle = dataGridViewCellStyle16;
      this.UltimaNC.HeaderText = "Ultima NC";
      this.UltimaNC.Name = "UltimaNC";
      this.UltimaNC.Width = 80;
      // 
      // UltimoCliente
      // 
      this.UltimoCliente.DataPropertyName = "UltimoCliente";
      dataGridViewCellStyle17.Format = "D";
      dataGridViewCellStyle17.NullValue = "0";
      this.UltimoCliente.DefaultCellStyle = dataGridViewCellStyle17;
      this.UltimoCliente.HeaderText = "Ultimo Cliente";
      this.UltimoCliente.Name = "UltimoCliente";
      this.UltimoCliente.Width = 80;
      // 
      // UltimaApertura
      // 
      this.UltimaApertura.DataPropertyName = "UltimaApertura";
      dataGridViewCellStyle18.Format = "D";
      dataGridViewCellStyle18.NullValue = "0";
      this.UltimaApertura.DefaultCellStyle = dataGridViewCellStyle18;
      this.UltimaApertura.HeaderText = "Ultima Apertura";
      this.UltimaApertura.Name = "UltimaApertura";
      this.UltimaApertura.Width = 80;
      // 
      // UltimoAlivio
      // 
      this.UltimoAlivio.DataPropertyName = "UltimoAlivio";
      dataGridViewCellStyle19.Format = "D";
      dataGridViewCellStyle19.NullValue = "0";
      this.UltimoAlivio.DefaultCellStyle = dataGridViewCellStyle19;
      this.UltimoAlivio.HeaderText = "Ultimo Alivio";
      this.UltimoAlivio.Name = "UltimoAlivio";
      this.UltimoAlivio.Width = 80;
      // 
      // UltimoCierreCajero
      // 
      this.UltimoCierreCajero.DataPropertyName = "UltimoCierreCajero";
      dataGridViewCellStyle20.Format = "D";
      dataGridViewCellStyle20.NullValue = "0";
      this.UltimoCierreCajero.DefaultCellStyle = dataGridViewCellStyle20;
      this.UltimoCierreCajero.HeaderText = "Ultimo Cierre de Cajero";
      this.UltimoCierreCajero.Name = "UltimoCierreCajero";
      this.UltimoCierreCajero.Width = 80;
      // 
      // UltimoCierreVentas
      // 
      this.UltimoCierreVentas.DataPropertyName = "UltimoCierreVentas";
      dataGridViewCellStyle21.Format = "D";
      dataGridViewCellStyle21.NullValue = "0";
      this.UltimoCierreVentas.DefaultCellStyle = dataGridViewCellStyle21;
      this.UltimoCierreVentas.HeaderText = "Ultimo Cierre de Ventas";
      this.UltimoCierreVentas.Name = "UltimoCierreVentas";
      this.UltimoCierreVentas.Width = 80;
      // 
      // fechaModificacionDataGridViewTextBoxColumn
      // 
      this.fechaModificacionDataGridViewTextBoxColumn.DataPropertyName = "FechaModificacion";
      dataGridViewCellStyle22.Format = "g";
      dataGridViewCellStyle22.NullValue = null;
      this.fechaModificacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
      this.fechaModificacionDataGridViewTextBoxColumn.HeaderText = "Fecha";
      this.fechaModificacionDataGridViewTextBoxColumn.Name = "fechaModificacionDataGridViewTextBoxColumn";
      // 
      // cajaContingenciaBindingSource
      // 
      this.cajaContingenciaBindingSource.DataSource = typeof(SEGAN_POS.DAL.CajaContingencia);
      // 
      // tmRefresh
      // 
      this.tmRefresh.Interval = 30000;
      this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
      // 
      // frmContingencia
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancelar;
      this.ClientSize = new System.Drawing.Size(918, 470);
      this.Controls.Add(this.dgItems);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmContingencia";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Activación de Contingencia";
      this.Load += new System.EventHandler(this.frmContingencia_Load);
      this.Shown += new System.EventHandler(this.frmContingencia_Shown);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContingencia_KeyDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cajaContingenciaBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.TextBox txPassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txLogin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.BindingSource cajaContingenciaBindingSource;
    private System.Windows.Forms.TextBox txUltimaF;
    private System.Windows.Forms.Button btRefrescar;
    private System.Windows.Forms.TextBox txUltimaNC;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DataGridViewTextBoxColumn idCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ultimaFacturaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimoPago;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimaNC;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimoCliente;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimaApertura;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimoAlivio;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimoCierreCajero;
    private System.Windows.Forms.DataGridViewTextBoxColumn UltimoCierreVentas;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaModificacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.Timer tmRefresh;
  }
}