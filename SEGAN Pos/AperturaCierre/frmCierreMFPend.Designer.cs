namespace SEGAN_POS
{
  partial class frmCierreMFPend
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btRefrescar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbMensaje = new System.Windows.Forms.Label();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.DescCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoSistemaF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoReportadoF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiferenciaF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoSistemaNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoReportadONC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiferenciaNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dispositivoCajaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispositivoCajaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 41);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btRefrescar);
            this.panel2.Controls.Add(this.btCancelar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(744, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 41);
            this.panel2.TabIndex = 0;
            // 
            // btRefrescar
            // 
            this.btRefrescar.CausesValidation = false;
            this.btRefrescar.Image = global::SEGAN_POS.Properties.Resources.refrescar;
            this.btRefrescar.Location = new System.Drawing.Point(3, 4);
            this.btRefrescar.Name = "btRefrescar";
            this.btRefrescar.Size = new System.Drawing.Size(88, 32);
            this.btRefrescar.TabIndex = 11;
            this.btRefrescar.TabStop = false;
            this.btRefrescar.Text = "Refrescar";
            this.btRefrescar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefrescar.UseVisualStyleBackColor = true;
            this.btRefrescar.Click += new System.EventHandler(this.btRefrescar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.CausesValidation = false;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.continuar;
            this.btCancelar.Location = new System.Drawing.Point(97, 4);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(84, 32);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.TabStop = false;
            this.btCancelar.Text = "Continuar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbMensaje
            // 
            this.lbMensaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensaje.Location = new System.Drawing.Point(0, 0);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Padding = new System.Windows.Forms.Padding(3);
            this.lbMensaje.Size = new System.Drawing.Size(931, 41);
            this.lbMensaje.TabIndex = 0;
            this.lbMensaje.Text = "No es posible relizar el Cierre de Ventas para la fecha: {0:d}. Se debe emitir el" +
    " Reporte Z de las siguientes máquinas fiscales:";
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
            this.DescCaja,
            this.Serial,
            this.FechaCierre,
            this.MontoSistemaF,
            this.MontoReportadoF,
            this.DiferenciaF,
            this.MontoSistemaNC,
            this.MontoReportadONC,
            this.DiferenciaNC});
            this.dgItems.DataSource = this.dispositivoCajaBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgItems.Location = new System.Drawing.Point(0, 41);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.ShowEditingIcon = false;
            this.dgItems.Size = new System.Drawing.Size(931, 353);
            this.dgItems.TabIndex = 3;
            this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
            this.dgItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellDoubleClick);
            this.dgItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgItems_CurrentCellDirtyStateChanged);
            this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
            // 
            // DescCaja
            // 
            this.DescCaja.DataPropertyName = "DescCaja";
            this.DescCaja.HeaderText = "Caja";
            this.DescCaja.Name = "DescCaja";
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "Serial";
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            // 
            // FechaCierre
            // 
            this.FechaCierre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FechaCierre.DataPropertyName = "FechaCierre";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.FechaCierre.DefaultCellStyle = dataGridViewCellStyle2;
            this.FechaCierre.HeaderText = "Fecha de Cierre";
            this.FechaCierre.Name = "FechaCierre";
            this.FechaCierre.ReadOnly = true;
            this.FechaCierre.Width = 74;
            // 
            // MontoSistemaF
            // 
            this.MontoSistemaF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MontoSistemaF.DataPropertyName = "MontoSistemaF";
            this.MontoSistemaF.HeaderText = "Facturado por Sistema";
            this.MontoSistemaF.Name = "MontoSistemaF";
            this.MontoSistemaF.ReadOnly = true;
            this.MontoSistemaF.Width = 93;
            // 
            // MontoReportadoF
            // 
            this.MontoReportadoF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MontoReportadoF.DataPropertyName = "MontoReportadoF";
            this.MontoReportadoF.HeaderText = "Facturado por Máquina Fiscal";
            this.MontoReportadoF.Name = "MontoReportadoF";
            this.MontoReportadoF.ReadOnly = true;
            this.MontoReportadoF.Width = 132;
            // 
            // DiferenciaF
            // 
            this.DiferenciaF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DiferenciaF.DataPropertyName = "DiferenciaF";
            this.DiferenciaF.HeaderText = "Diferencia Facturada";
            this.DiferenciaF.Name = "DiferenciaF";
            this.DiferenciaF.ReadOnly = true;
            this.DiferenciaF.Width = 120;
            // 
            // MontoSistemaNC
            // 
            this.MontoSistemaNC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MontoSistemaNC.DataPropertyName = "MontoSistemaNC";
            this.MontoSistemaNC.HeaderText = "NC de Sistema";
            this.MontoSistemaNC.Name = "MontoSistemaNC";
            this.MontoSistemaNC.ReadOnly = true;
            this.MontoSistemaNC.Width = 94;
            // 
            // MontoReportadONC
            // 
            this.MontoReportadONC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MontoReportadONC.DataPropertyName = "MontoReportadONC";
            this.MontoReportadONC.FillWeight = 150F;
            this.MontoReportadONC.HeaderText = "NC de Maquina Fiscal";
            this.MontoReportadONC.MaxInputLength = 33000;
            this.MontoReportadONC.Name = "MontoReportadONC";
            this.MontoReportadONC.ReadOnly = true;
            this.MontoReportadONC.Width = 124;
            // 
            // DiferenciaNC
            // 
            this.DiferenciaNC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DiferenciaNC.DataPropertyName = "DiferenciaNC";
            this.DiferenciaNC.HeaderText = "Diferencia NC";
            this.DiferenciaNC.Name = "DiferenciaNC";
            this.DiferenciaNC.ReadOnly = true;
            this.DiferenciaNC.Width = 90;
            // 
            // dispositivoCajaBindingSource
            // 
            this.dispositivoCajaBindingSource.DataSource = typeof(SEGAN_POS.DAL.CierreMaquinaValidar);
            // 
            // frmCierreMFPend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 435);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.lbMensaje);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCierreMFPend";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cierres de Máquina Fiscal Pendientes";
            this.Activated += new System.EventHandler(this.frmCierreMFPend_Activated);
            this.Load += new System.EventHandler(this.frmCierreMFPend_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dispositivoCajaBindingSource)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.Button btRefrescar;
    private System.Windows.Forms.Label lbMensaje;
    private System.Windows.Forms.BindingSource dispositivoCajaBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn descCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn serialDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idDispositivoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn excludeDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn DescCaja;
    private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaCierre;
    private System.Windows.Forms.DataGridViewTextBoxColumn MontoSistemaF;
    private System.Windows.Forms.DataGridViewTextBoxColumn MontoReportadoF;
    private System.Windows.Forms.DataGridViewTextBoxColumn DiferenciaF;
    private System.Windows.Forms.DataGridViewTextBoxColumn MontoSistemaNC;
    private System.Windows.Forms.DataGridViewTextBoxColumn MontoReportadONC;
    private System.Windows.Forms.DataGridViewTextBoxColumn DiferenciaNC;
  }
}