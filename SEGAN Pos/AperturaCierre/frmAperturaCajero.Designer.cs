namespace SEGAN_POS
{
  partial class frmAperturaCajero
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgDenominaciones = new System.Windows.Forms.DataGridView();
            this.idDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.denominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalXDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denominacionAlivioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txCajero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.txtMontoApertura = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lbMaximo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDenominaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denominacionAlivioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDenominaciones
            // 
            this.dgDenominaciones.AllowUserToAddRows = false;
            this.dgDenominaciones.AllowUserToDeleteRows = false;
            this.dgDenominaciones.AllowUserToResizeColumns = false;
            this.dgDenominaciones.AllowUserToResizeRows = false;
            this.dgDenominaciones.AutoGenerateColumns = false;
            this.dgDenominaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDenominaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDenominacionDataGridViewTextBoxColumn,
            this.logoDataGridViewImageColumn,
            this.denominacionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.totalXDenominacionDataGridViewTextBoxColumn});
            this.dgDenominaciones.DataSource = this.denominacionAlivioBindingSource;
            this.dgDenominaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgDenominaciones.Location = new System.Drawing.Point(18, 97);
            this.dgDenominaciones.MultiSelect = false;
            this.dgDenominaciones.Name = "dgDenominaciones";
            this.dgDenominaciones.ReadOnly = true;
            this.dgDenominaciones.RowHeadersVisible = false;
            this.dgDenominaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDenominaciones.Size = new System.Drawing.Size(375, 316);
            this.dgDenominaciones.TabIndex = 18;
            this.dgDenominaciones.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgDenominaciones_CellBeginEdit);
            this.dgDenominaciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDenominaciones_CellDoubleClick);
            this.dgDenominaciones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgDenominaciones_DataError);
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
            this.logoDataGridViewImageColumn.HeaderText = "Logo";
            this.logoDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.logoDataGridViewImageColumn.Name = "logoDataGridViewImageColumn";
            this.logoDataGridViewImageColumn.ReadOnly = true;
            this.logoDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.logoDataGridViewImageColumn.Width = 40;
            // 
            // denominacionDataGridViewTextBoxColumn
            // 
            this.denominacionDataGridViewTextBoxColumn.DataPropertyName = "Denominacion";
            this.denominacionDataGridViewTextBoxColumn.HeaderText = "Denominación";
            this.denominacionDataGridViewTextBoxColumn.Name = "denominacionDataGridViewTextBoxColumn";
            this.denominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.denominacionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.denominacionDataGridViewTextBoxColumn.Width = 90;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidadDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalXDenominacionDataGridViewTextBoxColumn
            // 
            this.totalXDenominacionDataGridViewTextBoxColumn.DataPropertyName = "TotalXDenominacion";
            this.totalXDenominacionDataGridViewTextBoxColumn.HeaderText = "Total por Denominación";
            this.totalXDenominacionDataGridViewTextBoxColumn.Name = "totalXDenominacionDataGridViewTextBoxColumn";
            this.totalXDenominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalXDenominacionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.totalXDenominacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // denominacionAlivioBindingSource
            // 
            this.denominacionAlivioBindingSource.DataSource = typeof(SEGAN_POS.DAL.DenominacionAlivio);
            // 
            // txCaja
            // 
            this.txCaja.BackColor = System.Drawing.SystemColors.Control;
            this.txCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txCaja.Enabled = false;
            this.txCaja.Location = new System.Drawing.Point(58, 59);
            this.txCaja.MaxLength = 50;
            this.txCaja.Name = "txCaja";
            this.txCaja.Size = new System.Drawing.Size(142, 20);
            this.txCaja.TabIndex = 16;
            this.txCaja.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 61);
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
            this.txCajero.Location = new System.Drawing.Point(58, 22);
            this.txCajero.MaxLength = 50;
            this.txCajero.Name = "txCajero";
            this.txCajero.Size = new System.Drawing.Size(335, 20);
            this.txCajero.TabIndex = 14;
            this.txCajero.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Cajero";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btCancel
            // 
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(311, 454);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 33);
            this.btCancel.TabIndex = 25;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(223, 454);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 24;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // txtMontoApertura
            // 
            this.txtMontoApertura.BackColor = System.Drawing.SystemColors.Control;
            this.txtMontoApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoApertura.Enabled = false;
            this.txtMontoApertura.Location = new System.Drawing.Point(272, 419);
            this.txtMontoApertura.MaxLength = 50;
            this.txtMontoApertura.Name = "txtMontoApertura";
            this.txtMontoApertura.Size = new System.Drawing.Size(121, 20);
            this.txtMontoApertura.TabIndex = 26;
            this.txtMontoApertura.TabStop = false;
            this.txtMontoApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 422);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Monto de Apertura";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Fecha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.SystemColors.Control;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(249, 59);
            this.txtFecha.MaxLength = 50;
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(144, 20);
            this.txtFecha.TabIndex = 19;
            this.txtFecha.TabStop = false;
            // 
            // lbMaximo
            // 
            this.lbMaximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaximo.Location = new System.Drawing.Point(24, 454);
            this.lbMaximo.Name = "lbMaximo";
            this.lbMaximo.Size = new System.Drawing.Size(176, 31);
            this.lbMaximo.TabIndex = 28;
            this.lbMaximo.Text = "El monto de apertura no debe exceder Bs F. 100,00";
            this.lbMaximo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMaximo.Visible = false;
            // 
            // frmAperturaCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(413, 504);
            this.Controls.Add(this.lbMaximo);
            this.Controls.Add(this.txtMontoApertura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgDenominaciones);
            this.Controls.Add(this.txCaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txCajero);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAperturaCajero";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apertura de Caja";
            this.Activated += new System.EventHandler(this.frmAperturaCajero_Activated);
            this.Load += new System.EventHandler(this.frmAperturaCajero_Load);
            this.Shown += new System.EventHandler(this.frmAperturaCajero_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgDenominaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denominacionAlivioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dgDenominaciones;
    private System.Windows.Forms.TextBox txCaja;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txCajero;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.BindingSource denominacionAlivioBindingSource;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.TextBox txtMontoApertura;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDenominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn logoDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn denominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalXDenominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtFecha;
    private System.Windows.Forms.Label lbMaximo;
  }
}