namespace SEGAN_POS
{
  partial class frmIngresoEfectivo
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      this.dgEfectivo = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.txIngreso = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txMontoIngreso = new System.Windows.Forms.TextBox();
      this.btOK = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.label12 = new System.Windows.Forms.Label();
      this.txObs = new System.Windows.Forms.TextBox();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.denominacionIngresoEfectivoBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.idDenominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.logoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
      this.denominacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ingresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalIngresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.dgEfectivo)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.denominacionIngresoEfectivoBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // dgEfectivo
      // 
      this.dgEfectivo.AllowUserToAddRows = false;
      this.dgEfectivo.AllowUserToDeleteRows = false;
      this.dgEfectivo.AllowUserToResizeRows = false;
      this.dgEfectivo.AutoGenerateColumns = false;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgEfectivo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
      this.dgEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgEfectivo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDenominacionDataGridViewTextBoxColumn,
            this.logoDataGridViewImageColumn,
            this.denominacionDataGridViewTextBoxColumn,
            this.ingresoDataGridViewTextBoxColumn,
            this.totalIngresoDataGridViewTextBoxColumn});
      this.dgEfectivo.DataSource = this.denominacionIngresoEfectivoBindingSource;
      dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgEfectivo.DefaultCellStyle = dataGridViewCellStyle10;
      this.dgEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgEfectivo.Location = new System.Drawing.Point(2, 2);
      this.dgEfectivo.Name = "dgEfectivo";
      this.dgEfectivo.ReadOnly = true;
      this.dgEfectivo.RowHeadersVisible = false;
      this.dgEfectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgEfectivo.Size = new System.Drawing.Size(434, 326);
      this.dgEfectivo.TabIndex = 33;
      this.dgEfectivo.TabStop = false;
      this.dgEfectivo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgEfectivo_CellBeginEdit);
      this.dgEfectivo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEfectivo_CellDoubleClick);
      this.dgEfectivo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgEfectivo_DataError);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label12);
      this.panel1.Controls.Add(this.txObs);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.txIngreso);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.txMontoIngreso);
      this.panel1.Controls.Add(this.btOK);
      this.panel1.Controls.Add(this.btCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(2, 328);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(434, 126);
      this.panel1.TabIndex = 34;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(24, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 13);
      this.label1.TabIndex = 55;
      this.label1.Text = "Total Billetes";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txIngreso
      // 
      this.txIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txIngreso.BackColor = System.Drawing.SystemColors.Control;
      this.txIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txIngreso.Location = new System.Drawing.Point(97, 13);
      this.txIngreso.MaxLength = 10;
      this.txIngreso.Name = "txIngreso";
      this.txIngreso.ReadOnly = true;
      this.txIngreso.Size = new System.Drawing.Size(94, 20);
      this.txIngreso.TabIndex = 54;
      this.txIngreso.TabStop = false;
      this.txIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(197, 15);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(75, 13);
      this.label5.TabIndex = 53;
      this.label5.Text = "Monto Ingreso";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txMontoIngreso
      // 
      this.txMontoIngreso.BackColor = System.Drawing.SystemColors.Control;
      this.txMontoIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoIngreso.Location = new System.Drawing.Point(278, 13);
      this.txMontoIngreso.MaxLength = 10;
      this.txMontoIngreso.Name = "txMontoIngreso";
      this.txMontoIngreso.ReadOnly = true;
      this.txMontoIngreso.Size = new System.Drawing.Size(141, 20);
      this.txMontoIngreso.TabIndex = 52;
      this.txMontoIngreso.TabStop = false;
      this.txMontoIngreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(249, 86);
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
      this.btCancel.Location = new System.Drawing.Point(337, 86);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(82, 33);
      this.btCancel.TabIndex = 9;
      this.btCancel.TabStop = false;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(13, 42);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(78, 13);
      this.label12.TabIndex = 59;
      this.label12.Text = "Observaciones";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txObs
      // 
      this.txObs.Location = new System.Drawing.Point(97, 39);
      this.txObs.MaxLength = 100;
      this.txObs.Multiline = true;
      this.txObs.Name = "txObs";
      this.txObs.Size = new System.Drawing.Size(322, 37);
      this.txObs.TabIndex = 58;
      this.txObs.TabStop = false;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // denominacionIngresoEfectivoBindingSource
      // 
      this.denominacionIngresoEfectivoBindingSource.DataSource = typeof(SEGAN_POS.DAL.DenominacionIngresoEfectivo);
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
      this.logoDataGridViewImageColumn.Width = 90;
      // 
      // denominacionDataGridViewTextBoxColumn
      // 
      this.denominacionDataGridViewTextBoxColumn.DataPropertyName = "Denominacion";
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.Format = "N0";
      this.denominacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
      this.denominacionDataGridViewTextBoxColumn.HeaderText = "Denominación";
      this.denominacionDataGridViewTextBoxColumn.Name = "denominacionDataGridViewTextBoxColumn";
      this.denominacionDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // ingresoDataGridViewTextBoxColumn
      // 
      this.ingresoDataGridViewTextBoxColumn.DataPropertyName = "Ingreso";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.Format = "N0";
      this.ingresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
      this.ingresoDataGridViewTextBoxColumn.HeaderText = "Ingreso";
      this.ingresoDataGridViewTextBoxColumn.Name = "ingresoDataGridViewTextBoxColumn";
      this.ingresoDataGridViewTextBoxColumn.ReadOnly = true;
      this.ingresoDataGridViewTextBoxColumn.Width = 80;
      // 
      // totalIngresoDataGridViewTextBoxColumn
      // 
      this.totalIngresoDataGridViewTextBoxColumn.DataPropertyName = "TotalIngreso";
      dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle9.Format = "C2";
      this.totalIngresoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
      this.totalIngresoDataGridViewTextBoxColumn.HeaderText = "Monto Ingreso";
      this.totalIngresoDataGridViewTextBoxColumn.Name = "totalIngresoDataGridViewTextBoxColumn";
      this.totalIngresoDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalIngresoDataGridViewTextBoxColumn.Width = 160;
      // 
      // frmIngresoEfectivo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(438, 456);
      this.Controls.Add(this.dgEfectivo);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmIngresoEfectivo";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Ingreso de Efectivo";
      this.Activated += new System.EventHandler(this.frmIngresoEfectivo_Activated);
      this.Load += new System.EventHandler(this.frmIngresoEfectivo_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dgEfectivo)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.denominacionIngresoEfectivoBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dgEfectivo;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txIngreso;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txMontoIngreso;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.BindingSource denominacionIngresoEfectivoBindingSource;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txObs;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDenominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn logoDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn denominacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ingresoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalIngresoDataGridViewTextBoxColumn;
  }
}