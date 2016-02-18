namespace SEGAN_POS
{
  partial class frmDevolucion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.itemsFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descRefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.devolucionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.exentoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMotivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idReferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDescuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioBaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioNetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aplicaRestriccionDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.AutoSize = true;
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(556, 300);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 6;
            this.btOK.TabStop = false;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.AutoSize = true;
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(644, 300);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(83, 33);
            this.btCancel.TabIndex = 7;
            this.btCancel.TabStop = false;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.cantidadDataGridViewTextBoxColumn,
            this.codigoArticuloDataGridViewTextBoxColumn,
            this.descRefDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.descuentoDataGridViewCheckBoxColumn,
            this.devolucionDataGridViewCheckBoxColumn,
            this.exentoDataGridViewCheckBoxColumn,
            this.idArticuloDataGridViewTextBoxColumn,
            this.idMotivoDataGridViewTextBoxColumn,
            this.idReferenciaDataGridViewTextBoxColumn,
            this.montoDescuentoDataGridViewTextBoxColumn,
            this.montoIVADataGridViewTextBoxColumn,
            this.precioBaseDataGridViewTextBoxColumn,
            this.precioNetoDataGridViewTextBoxColumn,
            this.precioVentaDataGridViewTextBoxColumn,
            this.aplicaRestriccionDataGridViewCheckBoxColumn});
            this.dgItems.DataSource = this.itemsFacturaBindingSource;
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
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgItems.Location = new System.Drawing.Point(12, 12);
            this.dgItems.MultiSelect = false;
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.Size = new System.Drawing.Size(715, 266);
            this.dgItems.TabIndex = 5;
            this.dgItems.TabStop = false;
            this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
            this.dgItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellEnter);
            this.dgItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellValueChanged);
            this.dgItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgItems_CurrentCellDirtyStateChanged);
            // 
            // itemsFacturaBindingSource
            // 
            this.itemsFacturaBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemsFactura);
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // codigoArticuloDataGridViewTextBoxColumn
            // 
            this.codigoArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodigoArticulo";
            this.codigoArticuloDataGridViewTextBoxColumn.HeaderText = "CodigoArticulo";
            this.codigoArticuloDataGridViewTextBoxColumn.Name = "codigoArticuloDataGridViewTextBoxColumn";
            // 
            // descRefDataGridViewTextBoxColumn
            // 
            this.descRefDataGridViewTextBoxColumn.DataPropertyName = "DescRef";
            this.descRefDataGridViewTextBoxColumn.HeaderText = "DescRef";
            this.descRefDataGridViewTextBoxColumn.Name = "descRefDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // descuentoDataGridViewCheckBoxColumn
            // 
            this.descuentoDataGridViewCheckBoxColumn.DataPropertyName = "Descuento";
            this.descuentoDataGridViewCheckBoxColumn.HeaderText = "Descuento";
            this.descuentoDataGridViewCheckBoxColumn.Name = "descuentoDataGridViewCheckBoxColumn";
            // 
            // devolucionDataGridViewCheckBoxColumn
            // 
            this.devolucionDataGridViewCheckBoxColumn.DataPropertyName = "Devolucion";
            this.devolucionDataGridViewCheckBoxColumn.HeaderText = "Devolucion";
            this.devolucionDataGridViewCheckBoxColumn.Name = "devolucionDataGridViewCheckBoxColumn";
            // 
            // exentoDataGridViewCheckBoxColumn
            // 
            this.exentoDataGridViewCheckBoxColumn.DataPropertyName = "Exento";
            this.exentoDataGridViewCheckBoxColumn.HeaderText = "Exento";
            this.exentoDataGridViewCheckBoxColumn.Name = "exentoDataGridViewCheckBoxColumn";
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            // 
            // idMotivoDataGridViewTextBoxColumn
            // 
            this.idMotivoDataGridViewTextBoxColumn.DataPropertyName = "IdMotivo";
            this.idMotivoDataGridViewTextBoxColumn.HeaderText = "IdMotivo";
            this.idMotivoDataGridViewTextBoxColumn.Name = "idMotivoDataGridViewTextBoxColumn";
            // 
            // idReferenciaDataGridViewTextBoxColumn
            // 
            this.idReferenciaDataGridViewTextBoxColumn.DataPropertyName = "IdReferencia";
            this.idReferenciaDataGridViewTextBoxColumn.HeaderText = "IdReferencia";
            this.idReferenciaDataGridViewTextBoxColumn.Name = "idReferenciaDataGridViewTextBoxColumn";
            // 
            // montoDescuentoDataGridViewTextBoxColumn
            // 
            this.montoDescuentoDataGridViewTextBoxColumn.DataPropertyName = "MontoDescuento";
            this.montoDescuentoDataGridViewTextBoxColumn.HeaderText = "MontoDescuento";
            this.montoDescuentoDataGridViewTextBoxColumn.Name = "montoDescuentoDataGridViewTextBoxColumn";
            // 
            // montoIVADataGridViewTextBoxColumn
            // 
            this.montoIVADataGridViewTextBoxColumn.DataPropertyName = "MontoIVA";
            this.montoIVADataGridViewTextBoxColumn.HeaderText = "MontoIVA";
            this.montoIVADataGridViewTextBoxColumn.Name = "montoIVADataGridViewTextBoxColumn";
            // 
            // precioBaseDataGridViewTextBoxColumn
            // 
            this.precioBaseDataGridViewTextBoxColumn.DataPropertyName = "PrecioBase";
            this.precioBaseDataGridViewTextBoxColumn.HeaderText = "PrecioBase";
            this.precioBaseDataGridViewTextBoxColumn.Name = "precioBaseDataGridViewTextBoxColumn";
            // 
            // precioNetoDataGridViewTextBoxColumn
            // 
            this.precioNetoDataGridViewTextBoxColumn.DataPropertyName = "PrecioNeto";
            this.precioNetoDataGridViewTextBoxColumn.HeaderText = "PrecioNeto";
            this.precioNetoDataGridViewTextBoxColumn.Name = "precioNetoDataGridViewTextBoxColumn";
            // 
            // precioVentaDataGridViewTextBoxColumn
            // 
            this.precioVentaDataGridViewTextBoxColumn.DataPropertyName = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.HeaderText = "PrecioVenta";
            this.precioVentaDataGridViewTextBoxColumn.Name = "precioVentaDataGridViewTextBoxColumn";
            // 
            // aplicaRestriccionDataGridViewCheckBoxColumn
            // 
            this.aplicaRestriccionDataGridViewCheckBoxColumn.DataPropertyName = "AplicaRestriccion";
            this.aplicaRestriccionDataGridViewCheckBoxColumn.HeaderText = "AplicaRestriccion";
            this.aplicaRestriccionDataGridViewCheckBoxColumn.Name = "aplicaRestriccionDataGridViewCheckBoxColumn";
            // 
            // frmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 347);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDevolucion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Devoluciones";
            this.Activated += new System.EventHandler(this.frmDevolucion_Activated);
            this.Load += new System.EventHandler(this.frmDevolucion_Load);
            this.Shown += new System.EventHandler(this.frmDevolucion_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.BindingSource itemsFacturaBindingSource;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codigoArticuloDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descRefDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn descuentoDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn devolucionDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn exentoDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idMotivoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idReferenciaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoDescuentoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoIVADataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn precioBaseDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn precioNetoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn precioVentaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn aplicaRestriccionDataGridViewCheckBoxColumn;
  }
}