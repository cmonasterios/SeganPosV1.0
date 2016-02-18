namespace SEGAN_POS
{
  partial class frmCambioEfectivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.dgEfectivo = new System.Windows.Forms.DataGridView();
            this.idDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.denominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.egresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denominacionCambioEfectivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txEgreso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txDiferencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txIngreso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txMontoApro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denominacionCambioEfectivoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(352, 95);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 8;
            this.btOK.TabStop = false;
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
            this.btCancel.Location = new System.Drawing.Point(440, 95);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 33);
            this.btCancel.TabIndex = 9;
            this.btCancel.TabStop = false;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // dgEfectivo
            // 
            this.dgEfectivo.AllowUserToAddRows = false;
            this.dgEfectivo.AllowUserToDeleteRows = false;
            this.dgEfectivo.AllowUserToResizeColumns = false;
            this.dgEfectivo.AllowUserToResizeRows = false;
            this.dgEfectivo.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEfectivo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEfectivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDenominacionDataGridViewTextBoxColumn,
            this.logoDataGridViewImageColumn,
            this.denominacionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.totalDenominacionDataGridViewTextBoxColumn,
            this.ingresoDataGridViewTextBoxColumn,
            this.egresoDataGridViewTextBoxColumn});
            this.dgEfectivo.DataSource = this.denominacionCambioEfectivoBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEfectivo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEfectivo.Location = new System.Drawing.Point(2, 2);
            this.dgEfectivo.Name = "dgEfectivo";
            this.dgEfectivo.ReadOnly = true;
            this.dgEfectivo.RowHeadersVisible = false;
            this.dgEfectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEfectivo.Size = new System.Drawing.Size(534, 288);
            this.dgEfectivo.TabIndex = 31;
            this.dgEfectivo.TabStop = false;
            this.dgEfectivo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgEfectivo_CellBeginEdit);
            this.dgEfectivo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEfectivo_CellDoubleClick);
            this.dgEfectivo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgEfectivo_DataError);
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
            this.logoDataGridViewImageColumn.Name = "logoDataGridViewImageColumn";
            this.logoDataGridViewImageColumn.ReadOnly = true;
            this.logoDataGridViewImageColumn.Width = 80;
            // 
            // denominacionDataGridViewTextBoxColumn
            // 
            this.denominacionDataGridViewTextBoxColumn.DataPropertyName = "Denominacion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.denominacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.denominacionDataGridViewTextBoxColumn.HeaderText = "Denominación";
            this.denominacionDataGridViewTextBoxColumn.Name = "denominacionDataGridViewTextBoxColumn";
            this.denominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.denominacionDataGridViewTextBoxColumn.Width = 80;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 70;
            // 
            // totalDenominacionDataGridViewTextBoxColumn
            // 
            this.totalDenominacionDataGridViewTextBoxColumn.DataPropertyName = "TotalDenominacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.totalDenominacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalDenominacionDataGridViewTextBoxColumn.HeaderText = "Monto por Denominación";
            this.totalDenominacionDataGridViewTextBoxColumn.Name = "totalDenominacionDataGridViewTextBoxColumn";
            this.totalDenominacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDenominacionDataGridViewTextBoxColumn.Width = 160;
            // 
            // ingresoDataGridViewTextBoxColumn
            // 
            this.ingresoDataGridViewTextBoxColumn.DataPropertyName = "Ingreso";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            this.ingresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.ingresoDataGridViewTextBoxColumn.HeaderText = "Ingreso";
            this.ingresoDataGridViewTextBoxColumn.Name = "ingresoDataGridViewTextBoxColumn";
            this.ingresoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ingresoDataGridViewTextBoxColumn.Width = 70;
            // 
            // egresoDataGridViewTextBoxColumn
            // 
            this.egresoDataGridViewTextBoxColumn.DataPropertyName = "Egreso";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "N0";
            this.egresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.egresoDataGridViewTextBoxColumn.HeaderText = "Egreso";
            this.egresoDataGridViewTextBoxColumn.Name = "egresoDataGridViewTextBoxColumn";
            this.egresoDataGridViewTextBoxColumn.ReadOnly = true;
            this.egresoDataGridViewTextBoxColumn.Width = 70;
            // 
            // denominacionCambioEfectivoBindingSource
            // 
            this.denominacionCambioEfectivoBindingSource.DataSource = typeof(SEGAN_POS.DAL.DenominacionCambioEfectivo);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txEgreso);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txDiferencia);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txIngreso);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txMontoApro);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 139);
            this.panel1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Egreso";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txEgreso
            // 
            this.txEgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txEgreso.BackColor = System.Drawing.SystemColors.Control;
            this.txEgreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txEgreso.Enabled = false;
            this.txEgreso.Location = new System.Drawing.Point(381, 34);
            this.txEgreso.MaxLength = 10;
            this.txEgreso.Name = "txEgreso";
            this.txEgreso.ReadOnly = true;
            this.txEgreso.Size = new System.Drawing.Size(141, 20);
            this.txEgreso.TabIndex = 58;
            this.txEgreso.TabStop = false;
            this.txEgreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Diferencia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txDiferencia
            // 
            this.txDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txDiferencia.BackColor = System.Drawing.SystemColors.Control;
            this.txDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txDiferencia.Enabled = false;
            this.txDiferencia.Location = new System.Drawing.Point(381, 58);
            this.txDiferencia.MaxLength = 10;
            this.txDiferencia.Name = "txDiferencia";
            this.txDiferencia.ReadOnly = true;
            this.txDiferencia.Size = new System.Drawing.Size(141, 20);
            this.txDiferencia.TabIndex = 56;
            this.txDiferencia.TabStop = false;
            this.txDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Ingreso";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txIngreso
            // 
            this.txIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txIngreso.BackColor = System.Drawing.SystemColors.Control;
            this.txIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txIngreso.Enabled = false;
            this.txIngreso.Location = new System.Drawing.Point(381, 8);
            this.txIngreso.MaxLength = 10;
            this.txIngreso.Name = "txIngreso";
            this.txIngreso.ReadOnly = true;
            this.txIngreso.Size = new System.Drawing.Size(141, 20);
            this.txIngreso.TabIndex = 54;
            this.txIngreso.TabStop = false;
            this.txIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Monto Aprobado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMontoApro
            // 
            this.txMontoApro.BackColor = System.Drawing.SystemColors.Control;
            this.txMontoApro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMontoApro.Enabled = false;
            this.txMontoApro.Location = new System.Drawing.Point(126, 8);
            this.txMontoApro.MaxLength = 10;
            this.txMontoApro.Name = "txMontoApro";
            this.txMontoApro.ReadOnly = true;
            this.txMontoApro.Size = new System.Drawing.Size(141, 20);
            this.txMontoApro.TabIndex = 52;
            this.txMontoApro.TabStop = false;
            this.txMontoApro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCambioEfectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 431);
            this.Controls.Add(this.dgEfectivo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioEfectivo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambio de Efectivo";
            this.Activated += new System.EventHandler(this.frmCambioEfectivo_Activated);
            this.Load += new System.EventHandler(this.frmCambioEfectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denominacionCambioEfectivoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.DataGridView dgEfectivo;
    private System.Windows.Forms.BindingSource denominacionCambioEfectivoBindingSource;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txEgreso;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txDiferencia;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txIngreso;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txMontoApro;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDenominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn logoDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn denominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalDenominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ingresoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn egresoDataGridViewTextBoxColumn;
  }
}