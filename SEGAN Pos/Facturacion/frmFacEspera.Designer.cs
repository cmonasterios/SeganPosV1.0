namespace SEGAN_POS
{
  partial class frmFacEspera
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.dgFacEspera = new System.Windows.Forms.DataGridView();
            this.indicadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.semaforoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.idFacturaEsperaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEstatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsEsperaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacEspera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsEsperaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.AutoSize = true;
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(578, 313);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(83, 33);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOK
            // 
            this.btOK.AutoSize = true;
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.continuar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(486, 313);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(88, 33);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "Continuar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // dgFacEspera
            // 
            this.dgFacEspera.AllowUserToAddRows = false;
            this.dgFacEspera.AllowUserToDeleteRows = false;
            this.dgFacEspera.AllowUserToResizeColumns = false;
            this.dgFacEspera.AllowUserToResizeRows = false;
            this.dgFacEspera.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFacEspera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFacEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacEspera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indicadorDataGridViewTextBoxColumn,
            this.semaforoDataGridViewImageColumn,
            this.idFacturaEsperaDataGridViewTextBoxColumn,
            this.nombreClienteDataGridViewTextBoxColumn,
            this.docClienteDataGridViewTextBoxColumn,
            this.FechaCreacion,
            this.dataGridViewTextBoxColumn1,
            this.idEstatusDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn});
            this.dgFacEspera.DataSource = this.itemsEsperaBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFacEspera.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgFacEspera.Location = new System.Drawing.Point(12, 12);
            this.dgFacEspera.MultiSelect = false;
            this.dgFacEspera.Name = "dgFacEspera";
            this.dgFacEspera.ReadOnly = true;
            this.dgFacEspera.RowHeadersVisible = false;
            this.dgFacEspera.RowTemplate.Height = 30;
            this.dgFacEspera.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFacEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacEspera.Size = new System.Drawing.Size(649, 286);
            this.dgFacEspera.TabIndex = 40;
            this.dgFacEspera.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgFacEspera_CellBeginEdit);
            this.dgFacEspera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFacEspera_CellClick);
            this.dgFacEspera.SelectionChanged += new System.EventHandler(this.dgFacEspera_SelectionChanged);
            // 
            // indicadorDataGridViewTextBoxColumn
            // 
            this.indicadorDataGridViewTextBoxColumn.DataPropertyName = "Indicador";
            this.indicadorDataGridViewTextBoxColumn.HeaderText = "Indicador";
            this.indicadorDataGridViewTextBoxColumn.Name = "indicadorDataGridViewTextBoxColumn";
            this.indicadorDataGridViewTextBoxColumn.ReadOnly = true;
            this.indicadorDataGridViewTextBoxColumn.Visible = false;
            // 
            // semaforoDataGridViewImageColumn
            // 
            this.semaforoDataGridViewImageColumn.DataPropertyName = "Semaforo";
            this.semaforoDataGridViewImageColumn.HeaderText = "";
            this.semaforoDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.semaforoDataGridViewImageColumn.Name = "semaforoDataGridViewImageColumn";
            this.semaforoDataGridViewImageColumn.ReadOnly = true;
            this.semaforoDataGridViewImageColumn.Width = 30;
            // 
            // idFacturaEsperaDataGridViewTextBoxColumn
            // 
            this.idFacturaEsperaDataGridViewTextBoxColumn.DataPropertyName = "IdFacturaEspera";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = "0";
            this.idFacturaEsperaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.idFacturaEsperaDataGridViewTextBoxColumn.HeaderText = "Número";
            this.idFacturaEsperaDataGridViewTextBoxColumn.Name = "idFacturaEsperaDataGridViewTextBoxColumn";
            this.idFacturaEsperaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreClienteDataGridViewTextBoxColumn
            // 
            this.nombreClienteDataGridViewTextBoxColumn.DataPropertyName = "NombreCliente";
            this.nombreClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nombreClienteDataGridViewTextBoxColumn.Name = "nombreClienteDataGridViewTextBoxColumn";
            this.nombreClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docClienteDataGridViewTextBoxColumn
            // 
            this.docClienteDataGridViewTextBoxColumn.DataPropertyName = "DocCliente";
            this.docClienteDataGridViewTextBoxColumn.HeaderText = "Documento";
            this.docClienteDataGridViewTextBoxColumn.Name = "docClienteDataGridViewTextBoxColumn";
            this.docClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.FechaCreacion.DefaultCellStyle = dataGridViewCellStyle3;
            this.FechaCreacion.HeaderText = "Fecha";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            this.FechaCreacion.Width = 95;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FechaCreacion";
            dataGridViewCellStyle4.Format = "T";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Hora";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // idEstatusDataGridViewTextBoxColumn
            // 
            this.idEstatusDataGridViewTextBoxColumn.DataPropertyName = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.HeaderText = "idEstatus";
            this.idEstatusDataGridViewTextBoxColumn.Name = "idEstatusDataGridViewTextBoxColumn";
            this.idEstatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEstatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCreacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemsEsperaBindingSource
            // 
            this.itemsEsperaBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemsEspera);
            // 
            // frmFacEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 358);
            this.Controls.Add(this.dgFacEspera);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFacEspera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facturas en Espera";
            this.Activated += new System.EventHandler(this.frmFacEspera_Activated);
            this.Load += new System.EventHandler(this.frmFacEspera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacEspera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsEsperaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.DataGridView dgFacEspera;
    private System.Windows.Forms.BindingSource itemsEsperaBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn indicadorDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewImageColumn semaforoDataGridViewImageColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaEsperaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nombreClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn docClienteDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn idEstatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
  }
}