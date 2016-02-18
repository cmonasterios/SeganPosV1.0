namespace SEGAN_POS
{
  partial class frmBuscarFact
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbCantReg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBuscarFact = new System.Windows.Forms.Button();
            this.lbFactDesd = new System.Windows.Forms.Label();
            this.txDocCliente = new System.Windows.Forms.TextBox();
            this.txNFact = new System.Windows.Forms.TextBox();
            this.lbDocCliente = new System.Windows.Forms.Label();
            this.dgFacturas = new System.Windows.Forms.DataGridView();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaEsperaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialMFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listadoFacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Controls.Add(this.lbCantReg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(949, 39);
            this.panel2.TabIndex = 4;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.AutoSize = true;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(775, 3);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 83;
            this.btOK.TabStop = false;
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
            this.btCancelar.Location = new System.Drawing.Point(863, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(83, 32);
            this.btCancelar.TabIndex = 82;
            this.btCancelar.TabStop = false;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbCantReg
            // 
            this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantReg.AutoSize = true;
            this.lbCantReg.Location = new System.Drawing.Point(13, 14);
            this.lbCantReg.Name = "lbCantReg";
            this.lbCantReg.Size = new System.Drawing.Size(108, 13);
            this.lbCantReg.TabIndex = 81;
            this.lbCantReg.Text = "registros encontrados";
            this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCantReg.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btBuscarFact);
            this.panel1.Controls.Add(this.lbFactDesd);
            this.panel1.Controls.Add(this.txDocCliente);
            this.panel1.Controls.Add(this.txNFact);
            this.panel1.Controls.Add(this.lbDocCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 45);
            this.panel1.TabIndex = 3;
            // 
            // btBuscarFact
            // 
            this.btBuscarFact.Image = global::SEGAN_POS.Properties.Resources.buscarpeq;
            this.btBuscarFact.Location = new System.Drawing.Point(451, 9);
            this.btBuscarFact.Name = "btBuscarFact";
            this.btBuscarFact.Size = new System.Drawing.Size(65, 25);
            this.btBuscarFact.TabIndex = 2;
            this.btBuscarFact.Text = "Buscar";
            this.btBuscarFact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscarFact.UseVisualStyleBackColor = true;
            this.btBuscarFact.Click += new System.EventHandler(this.btBuscarFact_Click);
            // 
            // lbFactDesd
            // 
            this.lbFactDesd.AutoSize = true;
            this.lbFactDesd.Location = new System.Drawing.Point(13, 15);
            this.lbFactDesd.Name = "lbFactDesd";
            this.lbFactDesd.Size = new System.Drawing.Size(58, 13);
            this.lbFactDesd.TabIndex = 67;
            this.lbFactDesd.Text = "N° Factura";
            this.lbFactDesd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txDocCliente
            // 
            this.txDocCliente.CausesValidation = false;
            this.txDocCliente.Location = new System.Drawing.Point(299, 12);
            this.txDocCliente.MaxLength = 15;
            this.txDocCliente.Name = "txDocCliente";
            this.txDocCliente.Size = new System.Drawing.Size(127, 20);
            this.txDocCliente.TabIndex = 1;
            // 
            // txNFact
            // 
            this.txNFact.CausesValidation = false;
            this.txNFact.Location = new System.Drawing.Point(77, 12);
            this.txNFact.MaxLength = 15;
            this.txNFact.Name = "txNFact";
            this.txNFact.Size = new System.Drawing.Size(124, 20);
            this.txNFact.TabIndex = 0;
            this.txNFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txNFact_KeyPress);
            // 
            // lbDocCliente
            // 
            this.lbDocCliente.AutoSize = true;
            this.lbDocCliente.Location = new System.Drawing.Point(228, 15);
            this.lbDocCliente.Name = "lbDocCliente";
            this.lbDocCliente.Size = new System.Drawing.Size(65, 13);
            this.lbDocCliente.TabIndex = 74;
            this.lbDocCliente.Text = "Doc. Cliente";
            this.lbDocCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgFacturas
            // 
            this.dgFacturas.AllowUserToAddRows = false;
            this.dgFacturas.AllowUserToDeleteRows = false;
            this.dgFacturas.AllowUserToResizeColumns = false;
            this.dgFacturas.AllowUserToResizeRows = false;
            this.dgFacturas.AutoGenerateColumns = false;
            this.dgFacturas.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.FechaCreacion,
            this.numeroDataGridViewTextBoxColumn,
            this.Ticket,
            this.idFacturaDataGridViewTextBoxColumn,
            this.idFacturaEsperaDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn,
            this.docClienteDataGridViewTextBoxColumn,
            this.serialMFDataGridViewTextBoxColumn,
            this.montoTotalDataGridViewTextBoxColumn,
            this.idEstatusDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn});
            this.dgFacturas.DataSource = this.listadoFacturasBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFacturas.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFacturas.Location = new System.Drawing.Point(0, 45);
            this.dgFacturas.MultiSelect = false;
            this.dgFacturas.Name = "dgFacturas";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgFacturas.RowHeadersVisible = false;
            this.dgFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacturas.ShowEditingIcon = false;
            this.dgFacturas.Size = new System.Drawing.Size(949, 345);
            this.dgFacturas.TabIndex = 5;
            this.dgFacturas.TabStop = false;
            this.dgFacturas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgFacturas_CellBeginEdit);
            this.dgFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFacturas_CellDoubleClick);
            this.dgFacturas.SelectionChanged += new System.EventHandler(this.dgFacturas_SelectionChanged);
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaCreacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.Width = 75;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.FechaCreacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaCreacion.HeaderText = "Hora";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 75;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            dataGridViewCellStyle4.Format = "D";
            dataGridViewCellStyle4.NullValue = "0";
            this.numeroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.numeroDataGridViewTextBoxColumn.HeaderText = "N° Factura";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.Width = 90;
            // 
            // Ticket
            // 
            this.Ticket.DataPropertyName = "Ticket";
            this.Ticket.HeaderText = "Ticket";
            this.Ticket.Name = "Ticket";
            this.Ticket.Width = 60;
            // 
            // idFacturaDataGridViewTextBoxColumn
            // 
            this.idFacturaDataGridViewTextBoxColumn.DataPropertyName = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.HeaderText = "IdFactura";
            this.idFacturaDataGridViewTextBoxColumn.Name = "idFacturaDataGridViewTextBoxColumn";
            this.idFacturaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFacturaEsperaDataGridViewTextBoxColumn
            // 
            this.idFacturaEsperaDataGridViewTextBoxColumn.DataPropertyName = "IdFacturaEspera";
            this.idFacturaEsperaDataGridViewTextBoxColumn.HeaderText = "IdFacturaEspera";
            this.idFacturaEsperaDataGridViewTextBoxColumn.Name = "idFacturaEsperaDataGridViewTextBoxColumn";
            this.idFacturaEsperaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Nombre Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.Width = 200;
            // 
            // docClienteDataGridViewTextBoxColumn
            // 
            this.docClienteDataGridViewTextBoxColumn.DataPropertyName = "DocCliente";
            this.docClienteDataGridViewTextBoxColumn.HeaderText = "Doc. Cliente";
            this.docClienteDataGridViewTextBoxColumn.Name = "docClienteDataGridViewTextBoxColumn";
            this.docClienteDataGridViewTextBoxColumn.Width = 110;
            // 
            // serialMFDataGridViewTextBoxColumn
            // 
            this.serialMFDataGridViewTextBoxColumn.DataPropertyName = "SerialMF";
            this.serialMFDataGridViewTextBoxColumn.HeaderText = "Máquina Fiscal";
            this.serialMFDataGridViewTextBoxColumn.Name = "serialMFDataGridViewTextBoxColumn";
            this.serialMFDataGridViewTextBoxColumn.Width = 118;
            // 
            // montoTotalDataGridViewTextBoxColumn
            // 
            this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "MontoTotal";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.montoTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.montoTotalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
            this.montoTotalDataGridViewTextBoxColumn.Width = 114;
            // 
            // idEstatusDataGridViewTextBoxColumn
            // 
            this.idEstatusDataGridViewTextBoxColumn.DataPropertyName = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.HeaderText = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.Name = "idEstatusDataGridViewTextBoxColumn";
            this.idEstatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.Width = 90;
            // 
            // listadoFacturasBindingSource
            // 
            this.listadoFacturasBindingSource.DataSource = typeof(SEGAN_POS.DAL.ListadoFacturas);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBuscarFact
            // 
            this.AcceptButton = this.btBuscarFact;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(949, 429);
            this.Controls.Add(this.dgFacturas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarFact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Factura";
            this.Load += new System.EventHandler(this.frmBuscarFact_Load);
            this.Shown += new System.EventHandler(this.frmBuscarFact_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoFacturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lbFactDesd;
    private System.Windows.Forms.TextBox txDocCliente;
    private System.Windows.Forms.TextBox txNFact;
    private System.Windows.Forms.Label lbDocCliente;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.Button btBuscarFact;
    private System.Windows.Forms.BindingSource listadoFacturasBindingSource;
    private System.Windows.Forms.DataGridView dgFacturas;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
    private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn Ticket;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaEsperaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn docClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn serialMFDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idEstatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;

  }
}