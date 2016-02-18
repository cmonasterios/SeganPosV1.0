namespace SEGAN_POS
{
  partial class frmVentasDia
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
            this.lbTotal = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.itemVentasDiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialMF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVentasDiaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Controls.Add(this.btCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 38);
            this.panel1.TabIndex = 0;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(12, 13);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(46, 13);
            this.lbTotal.TabIndex = 11;
            this.lbTotal.Text = "lbTotal";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotal.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.CausesValidation = false;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancelar.Location = new System.Drawing.Point(607, 3);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(70, 32);
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
            this.idCajaDataGridViewTextBoxColumn,
            this.descCajaDataGridViewTextBoxColumn,
            this.SerialMF,
            this.RepZ,
            this.montoTotalDataGridViewTextBoxColumn,
            this.porcentDataGridViewTextBoxColumn});
            this.dgItems.DataSource = this.itemVentasDiaBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgItems.Location = new System.Drawing.Point(0, 0);
            this.dgItems.Name = "dgItems";
            this.dgItems.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.ShowEditingIcon = false;
            this.dgItems.Size = new System.Drawing.Size(680, 358);
            this.dgItems.TabIndex = 1;
            this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
            // 
            // itemVentasDiaBindingSource
            // 
            this.itemVentasDiaBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemVentasDia);
            // 
            // idCajaDataGridViewTextBoxColumn
            // 
            this.idCajaDataGridViewTextBoxColumn.DataPropertyName = "IdCaja";
            this.idCajaDataGridViewTextBoxColumn.HeaderText = "IdCaja";
            this.idCajaDataGridViewTextBoxColumn.Name = "idCajaDataGridViewTextBoxColumn";
            this.idCajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCajaDataGridViewTextBoxColumn.Visible = false;
            // 
            // descCajaDataGridViewTextBoxColumn
            // 
            this.descCajaDataGridViewTextBoxColumn.DataPropertyName = "DescCaja";
            this.descCajaDataGridViewTextBoxColumn.HeaderText = "Caja";
            this.descCajaDataGridViewTextBoxColumn.Name = "descCajaDataGridViewTextBoxColumn";
            this.descCajaDataGridViewTextBoxColumn.ReadOnly = true;
            this.descCajaDataGridViewTextBoxColumn.Width = 165;
            // 
            // SerialMF
            // 
            this.SerialMF.DataPropertyName = "SerialMF";
            this.SerialMF.HeaderText = "Serial Máquina Fiscal";
            this.SerialMF.Name = "SerialMF";
            this.SerialMF.ReadOnly = true;
            this.SerialMF.Width = 130;
            // 
            // RepZ
            // 
            this.RepZ.DataPropertyName = "RepZ";
            this.RepZ.HeaderText = "Reporte Z";
            this.RepZ.Name = "RepZ";
            this.RepZ.ReadOnly = true;
            this.RepZ.Width = 130;
            // 
            // montoTotalDataGridViewTextBoxColumn
            // 
            this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "MontoTotal";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.montoTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoTotalDataGridViewTextBoxColumn.HeaderText = "Monto Total";
            this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
            this.montoTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoTotalDataGridViewTextBoxColumn.Width = 130;
            // 
            // porcentDataGridViewTextBoxColumn
            // 
            this.porcentDataGridViewTextBoxColumn.DataPropertyName = "Porcent";
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.porcentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.porcentDataGridViewTextBoxColumn.HeaderText = "%";
            this.porcentDataGridViewTextBoxColumn.Name = "porcentDataGridViewTextBoxColumn";
            this.porcentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmVentasDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(680, 396);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVentasDia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmVentasDia";
            this.Activated += new System.EventHandler(this.frmVentasDia_Activated);
            this.Load += new System.EventHandler(this.frmVentasDia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVentasDiaBindingSource)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.Label lbTotal;
    private System.Windows.Forms.BindingSource itemVentasDiaBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn idCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn SerialMF;
    private System.Windows.Forms.DataGridViewTextBoxColumn RepZ;
    private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn porcentDataGridViewTextBoxColumn;
  }
}