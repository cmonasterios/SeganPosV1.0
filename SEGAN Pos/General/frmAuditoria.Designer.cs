namespace SEGAN_POS
{
  partial class frmAuditoria
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
      this.btLimpiar = new System.Windows.Forms.Button();
      this.btBuscar = new System.Windows.Forms.Button();
      this.lbTipo = new System.Windows.Forms.Label();
      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.lbHasta = new System.Windows.Forms.Label();
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.lbDesde = new System.Windows.Forms.Label();
      this.txtUsuario = new System.Windows.Forms.TextBox();
      this.lblUsuario = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbTipoEvento = new System.Windows.Forms.ComboBox();
      this.dgAuditoria = new System.Windows.Forms.DataGridView();
      this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tipoEventoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.accionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.hostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.itemAuditoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel2 = new System.Windows.Forms.Panel();
      this.btExport = new System.Windows.Forms.Button();
      this.lbCantReg = new System.Windows.Forms.Label();
      this.btCancelar = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgAuditoria)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemAuditoriaBindingSource)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btLimpiar
      // 
      this.btLimpiar.CausesValidation = false;
      this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btLimpiar.Location = new System.Drawing.Point(866, 11);
      this.btLimpiar.Name = "btLimpiar";
      this.btLimpiar.Size = new System.Drawing.Size(72, 38);
      this.btLimpiar.TabIndex = 9;
      this.btLimpiar.Text = "Limpiar";
      this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btLimpiar.UseVisualStyleBackColor = true;
      this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
      // 
      // btBuscar
      // 
      this.btBuscar.CausesValidation = false;
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(784, 11);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(76, 38);
      this.btBuscar.TabIndex = 8;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // lbTipo
      // 
      this.lbTipo.AutoSize = true;
      this.lbTipo.Location = new System.Drawing.Point(331, 24);
      this.lbTipo.Name = "lbTipo";
      this.lbTipo.Size = new System.Drawing.Size(65, 13);
      this.lbTipo.TabIndex = 67;
      this.lbTipo.Text = "Tipo Evento";
      this.lbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpHasta
      // 
      this.dtpHasta.CausesValidation = false;
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpHasta.Location = new System.Drawing.Point(220, 21);
      this.dtpHasta.Name = "dtpHasta";
      this.dtpHasta.Size = new System.Drawing.Size(105, 20);
      this.dtpHasta.TabIndex = 2;
      // 
      // lbHasta
      // 
      this.lbHasta.AutoSize = true;
      this.lbHasta.Location = new System.Drawing.Point(179, 24);
      this.lbHasta.Name = "lbHasta";
      this.lbHasta.Size = new System.Drawing.Size(35, 13);
      this.lbHasta.TabIndex = 65;
      this.lbHasta.Text = "Hasta";
      this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpDesde
      // 
      this.dtpDesde.CausesValidation = false;
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDesde.Location = new System.Drawing.Point(61, 21);
      this.dtpDesde.Name = "dtpDesde";
      this.dtpDesde.Size = new System.Drawing.Size(105, 20);
      this.dtpDesde.TabIndex = 1;
      this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
      // 
      // lbDesde
      // 
      this.lbDesde.AutoSize = true;
      this.lbDesde.Location = new System.Drawing.Point(17, 24);
      this.lbDesde.Name = "lbDesde";
      this.lbDesde.Size = new System.Drawing.Size(38, 13);
      this.lbDesde.TabIndex = 63;
      this.lbDesde.Text = "Desde";
      this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtUsuario
      // 
      this.txtUsuario.CausesValidation = false;
      this.txtUsuario.Location = new System.Drawing.Point(595, 21);
      this.txtUsuario.MaxLength = 15;
      this.txtUsuario.Name = "txtUsuario";
      this.txtUsuario.Size = new System.Drawing.Size(127, 20);
      this.txtUsuario.TabIndex = 3;
      // 
      // lblUsuario
      // 
      this.lblUsuario.AutoSize = true;
      this.lblUsuario.Location = new System.Drawing.Point(556, 24);
      this.lblUsuario.Name = "lblUsuario";
      this.lblUsuario.Size = new System.Drawing.Size(33, 13);
      this.lblUsuario.TabIndex = 74;
      this.lblUsuario.Text = "Login";
      this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cbTipoEvento);
      this.panel1.Controls.Add(this.btBuscar);
      this.panel1.Controls.Add(this.lbDesde);
      this.panel1.Controls.Add(this.dtpDesde);
      this.panel1.Controls.Add(this.lbHasta);
      this.panel1.Controls.Add(this.dtpHasta);
      this.panel1.Controls.Add(this.lbTipo);
      this.panel1.Controls.Add(this.txtUsuario);
      this.panel1.Controls.Add(this.lblUsuario);
      this.panel1.Controls.Add(this.btLimpiar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(950, 63);
      this.panel1.TabIndex = 0;
      // 
      // cbTipoEvento
      // 
      this.cbTipoEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTipoEvento.FormattingEnabled = true;
      this.cbTipoEvento.Items.AddRange(new object[] {
            "",
            "Trace",
            "Debug",
            "Info",
            "Warn",
            "Error",
            "Fatal"});
      this.cbTipoEvento.Location = new System.Drawing.Point(402, 21);
      this.cbTipoEvento.Name = "cbTipoEvento";
      this.cbTipoEvento.Size = new System.Drawing.Size(148, 21);
      this.cbTipoEvento.TabIndex = 75;
      // 
      // dgAuditoria
      // 
      this.dgAuditoria.AllowUserToAddRows = false;
      this.dgAuditoria.AllowUserToDeleteRows = false;
      this.dgAuditoria.AllowUserToResizeColumns = false;
      this.dgAuditoria.AllowUserToResizeRows = false;
      this.dgAuditoria.AutoGenerateColumns = false;
      this.dgAuditoria.CausesValidation = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgAuditoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgAuditoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.tipoEventoDataGridViewTextBoxColumn,
            this.accionDataGridViewTextBoxColumn,
            this.iPDataGridViewTextBoxColumn,
            this.hostDataGridViewTextBoxColumn});
      this.dgAuditoria.DataSource = this.itemAuditoriaBindingSource;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle2.Format = "N2";
      dataGridViewCellStyle2.NullValue = null;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgAuditoria.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgAuditoria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgAuditoria.Location = new System.Drawing.Point(0, 63);
      this.dgAuditoria.Name = "dgAuditoria";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgAuditoria.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
      this.dgAuditoria.RowHeadersVisible = false;
      this.dgAuditoria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgAuditoria.ShowEditingIcon = false;
      this.dgAuditoria.Size = new System.Drawing.Size(950, 377);
      this.dgAuditoria.TabIndex = 0;
      this.dgAuditoria.TabStop = false;
      this.dgAuditoria.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgFacturas_CellBeginEdit);
      this.dgAuditoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFacturas_CellDoubleClick);
      this.dgAuditoria.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgFacturas_DataError);
      // 
      // fechaDataGridViewTextBoxColumn
      // 
      this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
      this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
      this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
      // 
      // loginDataGridViewTextBoxColumn
      // 
      this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
      this.loginDataGridViewTextBoxColumn.HeaderText = "Login";
      this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
      // 
      // usuarioDataGridViewTextBoxColumn
      // 
      this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
      this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
      this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
      this.usuarioDataGridViewTextBoxColumn.Width = 150;
      // 
      // tipoEventoDataGridViewTextBoxColumn
      // 
      this.tipoEventoDataGridViewTextBoxColumn.DataPropertyName = "TipoEvento";
      this.tipoEventoDataGridViewTextBoxColumn.HeaderText = "TipoEvento";
      this.tipoEventoDataGridViewTextBoxColumn.Name = "tipoEventoDataGridViewTextBoxColumn";
      // 
      // accionDataGridViewTextBoxColumn
      // 
      this.accionDataGridViewTextBoxColumn.DataPropertyName = "Accion";
      this.accionDataGridViewTextBoxColumn.HeaderText = "Accion";
      this.accionDataGridViewTextBoxColumn.Name = "accionDataGridViewTextBoxColumn";
      this.accionDataGridViewTextBoxColumn.Width = 275;
      // 
      // iPDataGridViewTextBoxColumn
      // 
      this.iPDataGridViewTextBoxColumn.DataPropertyName = "IP";
      this.iPDataGridViewTextBoxColumn.HeaderText = "IP";
      this.iPDataGridViewTextBoxColumn.Name = "iPDataGridViewTextBoxColumn";
      // 
      // hostDataGridViewTextBoxColumn
      // 
      this.hostDataGridViewTextBoxColumn.DataPropertyName = "Host";
      this.hostDataGridViewTextBoxColumn.HeaderText = "Host";
      this.hostDataGridViewTextBoxColumn.Name = "hostDataGridViewTextBoxColumn";
      // 
      // itemAuditoriaBindingSource
      // 
      this.itemAuditoriaBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemAuditoria);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btExport);
      this.panel2.Controls.Add(this.lbCantReg);
      this.panel2.Controls.Add(this.btCancelar);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 440);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(950, 39);
      this.panel2.TabIndex = 1;
      // 
      // btExport
      // 
      this.btExport.CausesValidation = false;
      this.btExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btExport.Enabled = false;
      this.btExport.Image = global::SEGAN_POS.Properties.Resources.excel;
      this.btExport.Location = new System.Drawing.Point(788, 4);
      this.btExport.Name = "btExport";
      this.btExport.Size = new System.Drawing.Size(83, 32);
      this.btExport.TabIndex = 82;
      this.btExport.TabStop = false;
      this.btExport.Text = "Exportar";
      this.btExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btExport.UseVisualStyleBackColor = true;
      this.btExport.Click += new System.EventHandler(this.btExport_Click);
      // 
      // lbCantReg
      // 
      this.lbCantReg.AutoSize = true;
      this.lbCantReg.Location = new System.Drawing.Point(12, 14);
      this.lbCantReg.Name = "lbCantReg";
      this.lbCantReg.Size = new System.Drawing.Size(108, 13);
      this.lbCantReg.TabIndex = 81;
      this.lbCantReg.Text = "registros encontrados";
      this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lbCantReg.Visible = false;
      // 
      // btCancelar
      // 
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.Location = new System.Drawing.Point(877, 4);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(70, 32);
      this.btCancelar.TabIndex = 9;
      this.btCancelar.TabStop = false;
      this.btCancelar.Text = "Cerrar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xlsx";
      this.saveFileDialog1.Filter = "Excel|*.xlsx";
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
      // 
      // frmAuditoria
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(950, 479);
      this.Controls.Add(this.dgAuditoria);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAuditoria";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Auditoria";
      this.Activated += new System.EventHandler(this.frmAuditoria_Activated);
      this.Load += new System.EventHandler(this.frmConsFacturas_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgAuditoria)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemAuditoriaBindingSource)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Label lbTipo;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Label lbHasta;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label lbDesde;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.Label lblUsuario;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView dgAuditoria;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Button btExport;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.ComboBox cbTipoEvento;
    private System.Windows.Forms.BindingSource itemAuditoriaBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tipoEventoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn accionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn hostDataGridViewTextBoxColumn;
  }
}