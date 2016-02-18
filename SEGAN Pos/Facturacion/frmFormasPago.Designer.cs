namespace SEGAN_POS
{
  partial class frmFormasPago
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.cbFormaPago = new System.Windows.Forms.ComboBox();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.lbFormaPago = new System.Windows.Forms.Label();
      this.lbBanco = new System.Windows.Forms.Label();
      this.cbBanco = new System.Windows.Forms.ComboBox();
      this.lbPOS = new System.Windows.Forms.Label();
      this.cbPOS = new System.Windows.Forms.ComboBox();
      this.lbBancoPOS = new System.Windows.Forms.Label();
      this.cbBancoPOS = new System.Windows.Forms.ComboBox();
      this.btAgregar = new System.Windows.Forms.Button();
      this.txMonto = new System.Windows.Forms.TextBox();
      this.txNumero = new System.Windows.Forms.TextBox();
      this.lbNumero = new System.Windows.Forms.Label();
      this.lbMonto = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.txTotalRecibido = new System.Windows.Forms.TextBox();
      this.dgItems = new System.Windows.Forms.DataGridView();
      this.Borrar = new System.Windows.Forms.DataGridViewImageColumn();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.label10 = new System.Windows.Forms.Label();
      this.txCambio = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txSaldo = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.txTotalPagar = new System.Windows.Forms.TextBox();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.itemsPagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemsPagoBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // cbFormaPago
      // 
      this.cbFormaPago.BackColor = System.Drawing.SystemColors.Window;
      this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFormaPago.FormattingEnabled = true;
      this.cbFormaPago.Location = new System.Drawing.Point(133, 23);
      this.cbFormaPago.Name = "cbFormaPago";
      this.cbFormaPago.Size = new System.Drawing.Size(257, 21);
      this.cbFormaPago.TabIndex = 0;
      this.cbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cbFormaPago_SelectedIndexChanged);
      this.cbFormaPago.Enter += new System.EventHandler(this.cbFormaPago_Enter);
      this.cbFormaPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFormaPago_KeyDown);
      this.cbFormaPago.Leave += new System.EventHandler(this.cbFormaPago_Leave);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.AutoSize = true;
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(774, 317);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(83, 33);
      this.btCancel.TabIndex = 7;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.AutoSize = true;
      this.btOK.Enabled = false;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(686, 317);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 6;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // lbFormaPago
      // 
      this.lbFormaPago.Location = new System.Drawing.Point(12, 26);
      this.lbFormaPago.Name = "lbFormaPago";
      this.lbFormaPago.Size = new System.Drawing.Size(115, 13);
      this.lbFormaPago.TabIndex = 5;
      this.lbFormaPago.Text = "Forma de Pago";
      this.lbFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lbBanco
      // 
      this.lbBanco.Location = new System.Drawing.Point(12, 53);
      this.lbBanco.Name = "lbBanco";
      this.lbBanco.Size = new System.Drawing.Size(115, 13);
      this.lbBanco.TabIndex = 8;
      this.lbBanco.Text = "Banco Emisor";
      this.lbBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbBanco
      // 
      this.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBanco.Enabled = false;
      this.cbBanco.FormattingEnabled = true;
      this.cbBanco.Location = new System.Drawing.Point(133, 50);
      this.cbBanco.Name = "cbBanco";
      this.cbBanco.Size = new System.Drawing.Size(257, 21);
      this.cbBanco.TabIndex = 1;
      this.cbBanco.Enter += new System.EventHandler(this.cbBanco_Enter);
      this.cbBanco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBanco_KeyDown);
      this.cbBanco.Leave += new System.EventHandler(this.cbBanco_Leave);
      // 
      // lbPOS
      // 
      this.lbPOS.Location = new System.Drawing.Point(416, 53);
      this.lbPOS.Name = "lbPOS";
      this.lbPOS.Size = new System.Drawing.Size(115, 13);
      this.lbPOS.TabIndex = 10;
      this.lbPOS.Text = "POS";
      this.lbPOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbPOS
      // 
      this.cbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPOS.Enabled = false;
      this.cbPOS.FormattingEnabled = true;
      this.cbPOS.Location = new System.Drawing.Point(537, 50);
      this.cbPOS.Name = "cbPOS";
      this.cbPOS.Size = new System.Drawing.Size(257, 21);
      this.cbPOS.TabIndex = 4;
      this.cbPOS.Enter += new System.EventHandler(this.cbPOS_Enter);
      this.cbPOS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPOS_KeyDown);
      this.cbPOS.Leave += new System.EventHandler(this.cbPOS_Leave);
      // 
      // lbBancoPOS
      // 
      this.lbBancoPOS.Location = new System.Drawing.Point(416, 26);
      this.lbBancoPOS.Name = "lbBancoPOS";
      this.lbBancoPOS.Size = new System.Drawing.Size(115, 13);
      this.lbBancoPOS.TabIndex = 12;
      this.lbBancoPOS.Text = "Banco POS";
      this.lbBancoPOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbBancoPOS
      // 
      this.cbBancoPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbBancoPOS.Enabled = false;
      this.cbBancoPOS.FormattingEnabled = true;
      this.cbBancoPOS.Location = new System.Drawing.Point(537, 23);
      this.cbBancoPOS.Name = "cbBancoPOS";
      this.cbBancoPOS.Size = new System.Drawing.Size(257, 21);
      this.cbBancoPOS.TabIndex = 3;
      this.cbBancoPOS.SelectedIndexChanged += new System.EventHandler(this.cbBancoPOS_SelectedIndexChanged);
      this.cbBancoPOS.Enter += new System.EventHandler(this.cbBancoPOS_Enter);
      this.cbBancoPOS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBancoPOS_KeyDown);
      this.cbBancoPOS.Leave += new System.EventHandler(this.cbBancoPOS_Leave);
      // 
      // btAgregar
      // 
      this.btAgregar.Image = global::SEGAN_POS.Properties.Resources.agregar2;
      this.btAgregar.Location = new System.Drawing.Point(800, 74);
      this.btAgregar.Name = "btAgregar";
      this.btAgregar.Size = new System.Drawing.Size(27, 26);
      this.btAgregar.TabIndex = 13;
      this.btAgregar.TabStop = false;
      this.btAgregar.Tag = "Autorizar_Pago";
      this.btAgregar.UseVisualStyleBackColor = true;
      this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
      // 
      // txMonto
      // 
      this.errorProvider1.SetIconPadding(this.txMonto, 36);
      this.txMonto.Location = new System.Drawing.Point(537, 77);
      this.txMonto.Name = "txMonto";
      this.txMonto.ShortcutsEnabled = false;
      this.txMonto.Size = new System.Drawing.Size(257, 20);
      this.txMonto.TabIndex = 5;
      this.txMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txMonto.Enter += new System.EventHandler(this.txMonto_Enter);
      this.txMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txMonto_KeyDown);
      this.txMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMonto_KeyPress);
      this.txMonto.Leave += new System.EventHandler(this.txMonto_Leave);
      // 
      // txNumero
      // 
      this.txNumero.BackColor = System.Drawing.SystemColors.Window;
      this.txNumero.Enabled = false;
      this.txNumero.Location = new System.Drawing.Point(133, 77);
      this.txNumero.Name = "txNumero";
      this.txNumero.ShortcutsEnabled = false;
      this.txNumero.Size = new System.Drawing.Size(257, 20);
      this.txNumero.TabIndex = 2;
      this.txNumero.Enter += new System.EventHandler(this.txNumero_Enter);
      this.txNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txNumero_KeyPress);
      this.txNumero.Leave += new System.EventHandler(this.txNumero_Leave);
      // 
      // lbNumero
      // 
      this.lbNumero.Location = new System.Drawing.Point(12, 81);
      this.lbNumero.Name = "lbNumero";
      this.lbNumero.Size = new System.Drawing.Size(115, 13);
      this.lbNumero.TabIndex = 16;
      this.lbNumero.Text = "Cheque / Tarjeta";
      this.lbNumero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lbMonto
      // 
      this.lbMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbMonto.Location = new System.Drawing.Point(416, 81);
      this.lbMonto.Name = "lbMonto";
      this.lbMonto.Size = new System.Drawing.Size(115, 13);
      this.lbMonto.TabIndex = 17;
      this.lbMonto.Text = "Pago Recibido";
      this.lbMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(554, 278);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(113, 17);
      this.label7.TabIndex = 20;
      this.label7.Text = "Total Recibido";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalRecibido
      // 
      this.txTotalRecibido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.txTotalRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalRecibido.Location = new System.Drawing.Point(673, 276);
      this.txTotalRecibido.Name = "txTotalRecibido";
      this.txTotalRecibido.ReadOnly = true;
      this.txTotalRecibido.Size = new System.Drawing.Size(184, 23);
      this.txTotalRecibido.TabIndex = 19;
      this.txTotalRecibido.TabStop = false;
      this.txTotalRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // dgItems
      // 
      this.dgItems.AllowUserToAddRows = false;
      this.dgItems.AllowUserToDeleteRows = false;
      this.dgItems.AllowUserToResizeColumns = false;
      this.dgItems.AllowUserToResizeRows = false;
      this.dgItems.AutoGenerateColumns = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn7,
            this.Borrar});
      this.dgItems.DataSource = this.itemsPagoBindingSource;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.Format = "N2";
      dataGridViewCellStyle2.NullValue = null;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgItems.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgItems.Location = new System.Drawing.Point(12, 121);
      this.dgItems.MultiSelect = false;
      this.dgItems.Name = "dgItems";
      this.dgItems.ReadOnly = true;
      this.dgItems.RowHeadersVisible = false;
      this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgItems.Size = new System.Drawing.Size(845, 134);
      this.dgItems.TabIndex = 21;
      this.dgItems.TabStop = false;
      this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
      this.dgItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellContentClick);
      this.dgItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellDoubleClick);
      this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
      this.dgItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgItems_KeyDown);
      // 
      // Borrar
      // 
      this.Borrar.HeaderText = "";
      this.Borrar.Image = global::SEGAN_POS.Properties.Resources.eliminar_peq;
      this.Borrar.Name = "Borrar";
      this.Borrar.ReadOnly = true;
      this.Borrar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.Borrar.ToolTipText = "Eliminar";
      this.Borrar.Width = 30;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label10.Location = new System.Drawing.Point(286, 323);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(60, 18);
      this.label10.TabIndex = 27;
      this.label10.Text = "Cambio";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txCambio
      // 
      this.txCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txCambio.Location = new System.Drawing.Point(352, 323);
      this.txCambio.Name = "txCambio";
      this.txCambio.ReadOnly = true;
      this.txCambio.Size = new System.Drawing.Size(150, 23);
      this.txCambio.TabIndex = 26;
      this.txCambio.TabStop = false;
      this.txCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label9.Location = new System.Drawing.Point(300, 276);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(46, 18);
      this.label9.TabIndex = 25;
      this.label9.Text = "Saldo";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txSaldo
      // 
      this.txSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txSaldo.ForeColor = System.Drawing.SystemColors.WindowText;
      this.txSaldo.Location = new System.Drawing.Point(352, 276);
      this.txSaldo.Name = "txSaldo";
      this.txSaldo.ReadOnly = true;
      this.txSaldo.Size = new System.Drawing.Size(150, 23);
      this.txSaldo.TabIndex = 24;
      this.txSaldo.TabStop = false;
      this.txSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(9, 276);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(96, 18);
      this.label8.TabIndex = 23;
      this.label8.Text = "Total a Pagar";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txTotalPagar
      // 
      this.txTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txTotalPagar.Location = new System.Drawing.Point(111, 276);
      this.txTotalPagar.Name = "txTotalPagar";
      this.txTotalPagar.ReadOnly = true;
      this.txTotalPagar.Size = new System.Drawing.Size(150, 23);
      this.txTotalPagar.TabIndex = 22;
      this.txTotalPagar.TabStop = false;
      this.txTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "idFormaPago";
      this.dataGridViewTextBoxColumn2.HeaderText = "idFormaPago";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      this.dataGridViewTextBoxColumn2.Visible = false;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "idEntidad";
      this.dataGridViewTextBoxColumn4.HeaderText = "idEntidad";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.ReadOnly = true;
      this.dataGridViewTextBoxColumn4.Visible = false;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "idPOS";
      this.dataGridViewTextBoxColumn5.HeaderText = "idPOS";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.Visible = false;
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "DescFormaPago";
      this.dataGridViewTextBoxColumn8.HeaderText = "Forma Pago";
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      this.dataGridViewTextBoxColumn8.Width = 96;
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "DescEntidad";
      this.dataGridViewTextBoxColumn9.HeaderText = "Banco Emisor";
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn9.ReadOnly = true;
      this.dataGridViewTextBoxColumn9.Width = 196;
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "NumeroPago";
      this.dataGridViewTextBoxColumn6.HeaderText = "Cheque / Tarjeta";
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.Width = 78;
      // 
      // dataGridViewTextBoxColumn11
      // 
      this.dataGridViewTextBoxColumn11.DataPropertyName = "DescEntidadPOS";
      this.dataGridViewTextBoxColumn11.HeaderText = "Banco POS";
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      this.dataGridViewTextBoxColumn11.ReadOnly = true;
      this.dataGridViewTextBoxColumn11.Width = 196;
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "DescPOS";
      this.dataGridViewTextBoxColumn10.HeaderText = "POS";
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn10.ReadOnly = true;
      this.dataGridViewTextBoxColumn10.Width = 144;
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "Monto";
      this.dataGridViewTextBoxColumn7.HeaderText = "Pago Recibido";
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      // 
      // itemsPagoBindingSource
      // 
      this.itemsPagoBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemsPago);
      // 
      // frmFormasPago
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(870, 364);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.txCambio);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.txSaldo);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.txTotalPagar);
      this.Controls.Add(this.dgItems);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.txTotalRecibido);
      this.Controls.Add(this.lbMonto);
      this.Controls.Add(this.lbNumero);
      this.Controls.Add(this.txNumero);
      this.Controls.Add(this.txMonto);
      this.Controls.Add(this.btAgregar);
      this.Controls.Add(this.lbBancoPOS);
      this.Controls.Add(this.cbBancoPOS);
      this.Controls.Add(this.lbPOS);
      this.Controls.Add(this.cbPOS);
      this.Controls.Add(this.lbBanco);
      this.Controls.Add(this.cbBanco);
      this.Controls.Add(this.lbFormaPago);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.cbFormaPago);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmFormasPago";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Pagos";
      this.Activated += new System.EventHandler(this.frmFormasPago_Activated);
      this.Load += new System.EventHandler(this.frmFormasPago_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemsPagoBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbFormaPago;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Label lbFormaPago;
    private System.Windows.Forms.Label lbBanco;
    private System.Windows.Forms.ComboBox cbBanco;
    private System.Windows.Forms.Label lbPOS;
    private System.Windows.Forms.ComboBox cbPOS;
    private System.Windows.Forms.Label lbBancoPOS;
    private System.Windows.Forms.ComboBox cbBancoPOS;
    private System.Windows.Forms.Button btAgregar;
    private System.Windows.Forms.TextBox txMonto;
    private System.Windows.Forms.TextBox txNumero;
    private System.Windows.Forms.Label lbNumero;
    private System.Windows.Forms.Label lbMonto;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txTotalRecibido;
    private System.Windows.Forms.DataGridViewTextBoxColumn idPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idEntidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idPOSDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descFormaPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descEntidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descEntidadPOSDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descPOSDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn numeroPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource itemsPagoBindingSource;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txCambio;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txSaldo;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txTotalPagar;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    private System.Windows.Forms.DataGridViewImageColumn Borrar;
  }
}