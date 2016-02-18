namespace SEGAN_POS
{
  partial class frmConsultarCierreVentas
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.btBuscar = new System.Windows.Forms.Button();
      this.cbUsuario = new System.Windows.Forms.ComboBox();
      this.lbDesde = new System.Windows.Forms.Label();
      this.dtpDesde = new System.Windows.Forms.DateTimePicker();
      this.lbHasta = new System.Windows.Forms.Label();
      this.dtpHasta = new System.Windows.Forms.DateTimePicker();
      this.btLimpiar = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lbCantReg = new System.Windows.Forms.Label();
      this.btCancelar = new System.Windows.Forms.Button();
      this.dgCierres = new System.Windows.Forms.DataGridView();
      this.idCierreVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nombreUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalEfectivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalOtrosPagosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalGeneralDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.itemCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCierres)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemCierreBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btBuscar);
      this.panel1.Controls.Add(this.cbUsuario);
      this.panel1.Controls.Add(this.lbDesde);
      this.panel1.Controls.Add(this.dtpDesde);
      this.panel1.Controls.Add(this.lbHasta);
      this.panel1.Controls.Add(this.dtpHasta);
      this.panel1.Controls.Add(this.btLimpiar);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(744, 111);
      this.panel1.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(46, 63);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 13);
      this.label1.TabIndex = 66;
      this.label1.Text = "Realizado por";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btBuscar
      // 
      this.btBuscar.CausesValidation = false;
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(619, 10);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(112, 53);
      this.btBuscar.TabIndex = 8;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // cbUsuario
      // 
      this.cbUsuario.CausesValidation = false;
      this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbUsuario.FormattingEnabled = true;
      this.cbUsuario.Location = new System.Drawing.Point(124, 60);
      this.cbUsuario.Name = "cbUsuario";
      this.cbUsuario.Size = new System.Drawing.Size(196, 21);
      this.cbUsuario.TabIndex = 7;
      // 
      // lbDesde
      // 
      this.lbDesde.AutoSize = true;
      this.lbDesde.Location = new System.Drawing.Point(80, 27);
      this.lbDesde.Name = "lbDesde";
      this.lbDesde.Size = new System.Drawing.Size(38, 13);
      this.lbDesde.TabIndex = 63;
      this.lbDesde.Text = "Desde";
      this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpDesde
      // 
      this.dtpDesde.CausesValidation = false;
      this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpDesde.Location = new System.Drawing.Point(124, 24);
      this.dtpDesde.Name = "dtpDesde";
      this.dtpDesde.Size = new System.Drawing.Size(105, 20);
      this.dtpDesde.TabIndex = 1;
      this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
      // 
      // lbHasta
      // 
      this.lbHasta.AutoSize = true;
      this.lbHasta.Location = new System.Drawing.Point(295, 27);
      this.lbHasta.Name = "lbHasta";
      this.lbHasta.Size = new System.Drawing.Size(35, 13);
      this.lbHasta.TabIndex = 65;
      this.lbHasta.Text = "Hasta";
      this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtpHasta
      // 
      this.dtpHasta.CausesValidation = false;
      this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtpHasta.Location = new System.Drawing.Point(336, 24);
      this.dtpHasta.Name = "dtpHasta";
      this.dtpHasta.Size = new System.Drawing.Size(105, 20);
      this.dtpHasta.TabIndex = 2;
      // 
      // btLimpiar
      // 
      this.btLimpiar.CausesValidation = false;
      this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btLimpiar.Location = new System.Drawing.Point(619, 69);
      this.btLimpiar.Name = "btLimpiar";
      this.btLimpiar.Size = new System.Drawing.Size(112, 28);
      this.btLimpiar.TabIndex = 9;
      this.btLimpiar.Text = "Limpiar Criterios";
      this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btLimpiar.UseVisualStyleBackColor = true;
      this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lbCantReg);
      this.panel2.Controls.Add(this.btCancelar);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 457);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(744, 39);
      this.panel2.TabIndex = 2;
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
      this.btCancelar.Location = new System.Drawing.Point(671, 3);
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
      // dgCierres
      // 
      this.dgCierres.AllowUserToAddRows = false;
      this.dgCierres.AllowUserToDeleteRows = false;
      this.dgCierres.AllowUserToResizeColumns = false;
      this.dgCierres.AllowUserToResizeRows = false;
      this.dgCierres.AutoGenerateColumns = false;
      this.dgCierres.CausesValidation = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgCierres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgCierres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgCierres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCierreVDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.idUsuarioDataGridViewTextBoxColumn,
            this.nombreUsuarioDataGridViewTextBoxColumn,
            this.totalEfectivoDataGridViewTextBoxColumn,
            this.totalOtrosPagosDataGridViewTextBoxColumn,
            this.totalGeneralDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn});
      this.dgCierres.DataSource = this.itemCierreBindingSource;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.Format = "N2";
      dataGridViewCellStyle4.NullValue = null;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgCierres.DefaultCellStyle = dataGridViewCellStyle4;
      this.dgCierres.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgCierres.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgCierres.Location = new System.Drawing.Point(0, 111);
      this.dgCierres.Name = "dgCierres";
      this.dgCierres.ReadOnly = true;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgCierres.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.dgCierres.RowHeadersVisible = false;
      this.dgCierres.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgCierres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgCierres.ShowEditingIcon = false;
      this.dgCierres.Size = new System.Drawing.Size(744, 346);
      this.dgCierres.TabIndex = 3;
      this.dgCierres.TabStop = false;
      this.dgCierres.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgCierres_CellBeginEdit);
      this.dgCierres.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCierres_CellDoubleClick);
      this.dgCierres.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgCierres_DataError);
      // 
      // idCierreVDataGridViewTextBoxColumn
      // 
      this.idCierreVDataGridViewTextBoxColumn.DataPropertyName = "IdCierreV";
      this.idCierreVDataGridViewTextBoxColumn.HeaderText = "IdCierreV";
      this.idCierreVDataGridViewTextBoxColumn.Name = "idCierreVDataGridViewTextBoxColumn";
      this.idCierreVDataGridViewTextBoxColumn.ReadOnly = true;
      this.idCierreVDataGridViewTextBoxColumn.Visible = false;
      // 
      // fechaDataGridViewTextBoxColumn
      // 
      this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
      dataGridViewCellStyle2.Format = "d";
      dataGridViewCellStyle2.NullValue = null;
      this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
      this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
      this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
      this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // idUsuarioDataGridViewTextBoxColumn
      // 
      this.idUsuarioDataGridViewTextBoxColumn.DataPropertyName = "IdUsuario";
      this.idUsuarioDataGridViewTextBoxColumn.HeaderText = "IdUsuario";
      this.idUsuarioDataGridViewTextBoxColumn.Name = "idUsuarioDataGridViewTextBoxColumn";
      this.idUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
      this.idUsuarioDataGridViewTextBoxColumn.Visible = false;
      // 
      // nombreUsuarioDataGridViewTextBoxColumn
      // 
      this.nombreUsuarioDataGridViewTextBoxColumn.DataPropertyName = "NombreUsuario";
      this.nombreUsuarioDataGridViewTextBoxColumn.HeaderText = "Realizado por";
      this.nombreUsuarioDataGridViewTextBoxColumn.Name = "nombreUsuarioDataGridViewTextBoxColumn";
      this.nombreUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
      this.nombreUsuarioDataGridViewTextBoxColumn.Width = 145;
      // 
      // totalEfectivoDataGridViewTextBoxColumn
      // 
      this.totalEfectivoDataGridViewTextBoxColumn.DataPropertyName = "TotalEfectivo";
      this.totalEfectivoDataGridViewTextBoxColumn.HeaderText = "Total Efectivo";
      this.totalEfectivoDataGridViewTextBoxColumn.Name = "totalEfectivoDataGridViewTextBoxColumn";
      this.totalEfectivoDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalEfectivoDataGridViewTextBoxColumn.Width = 110;
      // 
      // totalOtrosPagosDataGridViewTextBoxColumn
      // 
      this.totalOtrosPagosDataGridViewTextBoxColumn.DataPropertyName = "TotalOtrosPagos";
      this.totalOtrosPagosDataGridViewTextBoxColumn.HeaderText = "Total Otros Pagos";
      this.totalOtrosPagosDataGridViewTextBoxColumn.Name = "totalOtrosPagosDataGridViewTextBoxColumn";
      this.totalOtrosPagosDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalOtrosPagosDataGridViewTextBoxColumn.Width = 110;
      // 
      // totalGeneralDataGridViewTextBoxColumn
      // 
      this.totalGeneralDataGridViewTextBoxColumn.DataPropertyName = "TotalGeneral";
      this.totalGeneralDataGridViewTextBoxColumn.HeaderText = "Total General";
      this.totalGeneralDataGridViewTextBoxColumn.Name = "totalGeneralDataGridViewTextBoxColumn";
      this.totalGeneralDataGridViewTextBoxColumn.ReadOnly = true;
      this.totalGeneralDataGridViewTextBoxColumn.Width = 110;
      // 
      // fechaCreacionDataGridViewTextBoxColumn
      // 
      this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
      dataGridViewCellStyle3.Format = "g";
      dataGridViewCellStyle3.NullValue = null;
      this.fechaCreacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
      this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "Fecha Creación";
      this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
      this.fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
      this.fechaCreacionDataGridViewTextBoxColumn.Width = 140;
      // 
      // itemCierreBindingSource
      // 
      this.itemCierreBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemCierre);
      // 
      // frmConsultarCierreVentas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(744, 496);
      this.Controls.Add(this.dgCierres);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConsultarCierreVentas";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Consultar Cierre de Ventas";
      this.Activated += new System.EventHandler(this.frmConsultarCierreVentas_Activated);
      this.Load += new System.EventHandler(this.frmConsCierreVentas_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCierres)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemCierreBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.ComboBox cbUsuario;
    private System.Windows.Forms.Label lbDesde;
    private System.Windows.Forms.DateTimePicker dtpDesde;
    private System.Windows.Forms.Label lbHasta;
    private System.Windows.Forms.DateTimePicker dtpHasta;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dgCierres;
    private System.Windows.Forms.BindingSource itemCierreBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn idCierreVDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuarioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalEfectivoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalOtrosPagosDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalGeneralDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
  }
}