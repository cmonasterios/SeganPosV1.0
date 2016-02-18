namespace SEGAN_POS
{
  partial class frmBuscarCheques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCantSel = new System.Windows.Forms.Label();
            this.lbCantReg = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.chequeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbTodos = new System.Windows.Forms.CheckBox();
            this.seleccionadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFormaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEntidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreEntidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroChequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCantSel);
            this.panel1.Controls.Add(this.lbCantReg);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 48);
            this.panel1.TabIndex = 64;
            // 
            // lbCantSel
            // 
            this.lbCantSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantSel.AutoSize = true;
            this.lbCantSel.Location = new System.Drawing.Point(6, 27);
            this.lbCantSel.Name = "lbCantSel";
            this.lbCantSel.Size = new System.Drawing.Size(142, 13);
            this.lbCantSel.TabIndex = 83;
            this.lbCantSel.Text = "0 Registro(s) Selecionado(s).";
            this.lbCantSel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCantReg
            // 
            this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantReg.AutoSize = true;
            this.lbCantReg.Location = new System.Drawing.Point(6, 8);
            this.lbCantReg.Name = "lbCantReg";
            this.lbCantReg.Size = new System.Drawing.Size(138, 13);
            this.lbCantReg.TabIndex = 82;
            this.lbCantReg.Text = "0 Registro(s) Encontrado(s).";
            this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(655, 6);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(743, 6);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 33);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
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
            this.seleccionadoDataGridViewCheckBoxColumn,
            this.idPagoDataGridViewTextBoxColumn,
            this.idFormaPagoDataGridViewTextBoxColumn,
            this.fechaVentaDataGridViewTextBoxColumn,
            this.idFacturaDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn,
            this.documentoClienteDataGridViewTextBoxColumn,
            this.idEntidadDataGridViewTextBoxColumn,
            this.nombreEntidadDataGridViewTextBoxColumn,
            this.numeroChequeDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn});
            this.dgItems.DataSource = this.chequeBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgItems.Location = new System.Drawing.Point(2, 2);
            this.dgItems.MultiSelect = false;
            this.dgItems.Name = "dgItems";
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.Size = new System.Drawing.Size(828, 309);
            this.dgItems.TabIndex = 65;
            this.dgItems.TabStop = false;
            this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
            this.dgItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellValueChanged);
            this.dgItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgItems_CurrentCellDirtyStateChanged);
            this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
            // 
            // chequeBindingSource
            // 
            this.chequeBindingSource.DataSource = typeof(SEGAN_POS.DAL.Cheque);
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Enabled = false;
            this.cbTodos.Location = new System.Drawing.Point(11, 13);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.TabIndex = 66;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // seleccionadoDataGridViewCheckBoxColumn
            // 
            this.seleccionadoDataGridViewCheckBoxColumn.DataPropertyName = "Seleccionado";
            this.seleccionadoDataGridViewCheckBoxColumn.HeaderText = "";
            this.seleccionadoDataGridViewCheckBoxColumn.Name = "seleccionadoDataGridViewCheckBoxColumn";
            this.seleccionadoDataGridViewCheckBoxColumn.Width = 30;
            // 
            // idPagoDataGridViewTextBoxColumn
            // 
            this.idPagoDataGridViewTextBoxColumn.DataPropertyName = "IdPago";
            this.idPagoDataGridViewTextBoxColumn.HeaderText = "IdPago";
            this.idPagoDataGridViewTextBoxColumn.Name = "idPagoDataGridViewTextBoxColumn";
            this.idPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPagoDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFormaPagoDataGridViewTextBoxColumn
            // 
            this.idFormaPagoDataGridViewTextBoxColumn.DataPropertyName = "IdFormaPago";
            this.idFormaPagoDataGridViewTextBoxColumn.HeaderText = "IdFormaPago";
            this.idFormaPagoDataGridViewTextBoxColumn.Name = "idFormaPagoDataGridViewTextBoxColumn";
            this.idFormaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFormaPagoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaVentaDataGridViewTextBoxColumn
            // 
            this.fechaVentaDataGridViewTextBoxColumn.DataPropertyName = "FechaVenta";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaVentaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaVentaDataGridViewTextBoxColumn.HeaderText = "Fecha Venta";
            this.fechaVentaDataGridViewTextBoxColumn.Name = "fechaVentaDataGridViewTextBoxColumn";
            this.fechaVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idFacturaDataGridViewTextBoxColumn
            // 
            this.idFacturaDataGridViewTextBoxColumn.DataPropertyName = "IdFactura";
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = "0";
            this.idFacturaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idFacturaDataGridViewTextBoxColumn.HeaderText = "Nro. Factura";
            this.idFacturaDataGridViewTextBoxColumn.Name = "idFacturaDataGridViewTextBoxColumn";
            this.idFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Nombre Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreClienteDataGridViewTextBoxColumn.Width = 135;
            // 
            // documentoClienteDataGridViewTextBoxColumn
            // 
            this.documentoClienteDataGridViewTextBoxColumn.DataPropertyName = "DocumentoCliente";
            this.documentoClienteDataGridViewTextBoxColumn.HeaderText = "Documento Cliente";
            this.documentoClienteDataGridViewTextBoxColumn.Name = "documentoClienteDataGridViewTextBoxColumn";
            this.documentoClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEntidadDataGridViewTextBoxColumn
            // 
            this.idEntidadDataGridViewTextBoxColumn.DataPropertyName = "IdEntidad";
            this.idEntidadDataGridViewTextBoxColumn.HeaderText = "IdEntidad";
            this.idEntidadDataGridViewTextBoxColumn.Name = "idEntidadDataGridViewTextBoxColumn";
            this.idEntidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEntidadDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreEntidadDataGridViewTextBoxColumn
            // 
            this.nombreEntidadDataGridViewTextBoxColumn.DataPropertyName = "NombreEntidad";
            this.nombreEntidadDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.nombreEntidadDataGridViewTextBoxColumn.Name = "nombreEntidadDataGridViewTextBoxColumn";
            this.nombreEntidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreEntidadDataGridViewTextBoxColumn.Width = 120;
            // 
            // numeroChequeDataGridViewTextBoxColumn
            // 
            this.numeroChequeDataGridViewTextBoxColumn.DataPropertyName = "NumeroCheque";
            this.numeroChequeDataGridViewTextBoxColumn.HeaderText = "Número Cheque";
            this.numeroChequeDataGridViewTextBoxColumn.Name = "numeroChequeDataGridViewTextBoxColumn";
            this.numeroChequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroChequeDataGridViewTextBoxColumn.Width = 95;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.montoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoDataGridViewTextBoxColumn.Width = 120;
            // 
            // frmBuscarCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 361);
            this.Controls.Add(this.cbTodos);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCheques";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBuscarCheques";
            this.Activated += new System.EventHandler(this.frmBuscarCheques_Activated);
            this.Load += new System.EventHandler(this.frmBuscarCheques_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chequeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.BindingSource chequeBindingSource;
    private System.Windows.Forms.CheckBox cbTodos;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Label lbCantSel;
    private System.Windows.Forms.DataGridViewCheckBoxColumn seleccionadoDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFormaPagoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaVentaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn documentoClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idEntidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreEntidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn numeroChequeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
  }
}