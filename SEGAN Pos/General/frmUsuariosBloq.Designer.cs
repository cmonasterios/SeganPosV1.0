namespace SEGAN_POS
{
  partial class frmUsuariosBloq
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btCancelar = new System.Windows.Forms.Button();
      this.dgItems = new System.Windows.Forms.DataGridView();
      this.idUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.identificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lastLockedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Desbloquear = new System.Windows.Forms.DataGridViewImageColumn();
      this.usuariosBloqueadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.usuariosBloqueadosBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 364);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(506, 41);
      this.panel1.TabIndex = 2;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btCancelar);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(422, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(84, 41);
      this.panel2.TabIndex = 0;
      // 
      // btCancelar
      // 
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.Location = new System.Drawing.Point(3, 3);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(75, 32);
      this.btCancelar.TabIndex = 10;
      this.btCancelar.TabStop = false;
      this.btCancelar.Text = "Cerrar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // dgItems
      // 
      this.dgItems.AllowUserToAddRows = false;
      this.dgItems.AllowUserToDeleteRows = false;
      this.dgItems.AllowUserToResizeColumns = false;
      this.dgItems.AllowUserToResizeRows = false;
      this.dgItems.AutoGenerateColumns = false;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuarioDataGridViewTextBoxColumn,
            this.identificacionDataGridViewTextBoxColumn,
            this.loginDataGridViewTextBoxColumn,
            this.lastLockedDateDataGridViewTextBoxColumn,
            this.Desbloquear});
      this.dgItems.DataSource = this.usuariosBloqueadosBindingSource;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle7.Format = "N2";
      dataGridViewCellStyle7.NullValue = null;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgItems.DefaultCellStyle = dataGridViewCellStyle7;
      this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgItems.Location = new System.Drawing.Point(0, 0);
      this.dgItems.Name = "dgItems";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
      this.dgItems.RowHeadersVisible = false;
      this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgItems.ShowEditingIcon = false;
      this.dgItems.Size = new System.Drawing.Size(506, 364);
      this.dgItems.TabIndex = 4;
      this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
      this.dgItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellContentClick);
      this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
      // 
      // idUsuarioDataGridViewTextBoxColumn
      // 
      this.idUsuarioDataGridViewTextBoxColumn.DataPropertyName = "IdUsuario";
      this.idUsuarioDataGridViewTextBoxColumn.HeaderText = "IdUsuario";
      this.idUsuarioDataGridViewTextBoxColumn.Name = "idUsuarioDataGridViewTextBoxColumn";
      this.idUsuarioDataGridViewTextBoxColumn.Visible = false;
      // 
      // identificacionDataGridViewTextBoxColumn
      // 
      this.identificacionDataGridViewTextBoxColumn.DataPropertyName = "Identificacion";
      this.identificacionDataGridViewTextBoxColumn.HeaderText = "Nombre";
      this.identificacionDataGridViewTextBoxColumn.Name = "identificacionDataGridViewTextBoxColumn";
      this.identificacionDataGridViewTextBoxColumn.Width = 200;
      // 
      // loginDataGridViewTextBoxColumn
      // 
      this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
      this.loginDataGridViewTextBoxColumn.HeaderText = "Login";
      this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
      // 
      // lastLockedDateDataGridViewTextBoxColumn
      // 
      this.lastLockedDateDataGridViewTextBoxColumn.DataPropertyName = "LastLockedDate";
      dataGridViewCellStyle6.Format = "g";
      dataGridViewCellStyle6.NullValue = null;
      this.lastLockedDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
      this.lastLockedDateDataGridViewTextBoxColumn.HeaderText = "Fecha de Bloqueo";
      this.lastLockedDateDataGridViewTextBoxColumn.Name = "lastLockedDateDataGridViewTextBoxColumn";
      this.lastLockedDateDataGridViewTextBoxColumn.Width = 150;
      // 
      // Desbloquear
      // 
      this.Desbloquear.HeaderText = "";
      this.Desbloquear.Image = global::SEGAN_POS.Properties.Resources.unlock;
      this.Desbloquear.Name = "Desbloquear";
      this.Desbloquear.ToolTipText = "Desbloquear";
      this.Desbloquear.Width = 30;
      // 
      // usuariosBloqueadosBindingSource
      // 
      this.usuariosBloqueadosBindingSource.DataSource = typeof(SEGAN_POS.DAL.UsuariosBloqueados);
      // 
      // frmUsuariosBloq
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancelar;
      this.ClientSize = new System.Drawing.Size(506, 405);
      this.Controls.Add(this.dgItems);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmUsuariosBloq";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmUsuariosBloq";
      this.Activated += new System.EventHandler(this.frmUsuariosBloq_Activated);
      this.Load += new System.EventHandler(this.frmUsuariosBloq_Load);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.usuariosBloqueadosBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.BindingSource usuariosBloqueadosBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn idUsuarioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn identificacionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn lastLockedDateDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn Desbloquear;
  }
}