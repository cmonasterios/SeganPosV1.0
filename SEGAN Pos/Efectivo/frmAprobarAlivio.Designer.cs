namespace SEGAN_POS
{
  partial class frmAprobarAlivio
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.grdAlivios = new System.Windows.Forms.DataGridView();
      this.fechaAlivioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.horaAlivioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idAlivioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idCajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cajeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.alivioAprobacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btCancel = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.grdAlivios)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.alivioAprobacionBindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // grdAlivios
      // 
      this.grdAlivios.AllowUserToAddRows = false;
      this.grdAlivios.AllowUserToDeleteRows = false;
      this.grdAlivios.AllowUserToResizeColumns = false;
      this.grdAlivios.AllowUserToResizeRows = false;
      this.grdAlivios.AutoGenerateColumns = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.grdAlivios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.grdAlivios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdAlivios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaAlivioDataGridViewTextBoxColumn,
            this.horaAlivioDataGridViewTextBoxColumn,
            this.idAlivioDataGridViewTextBoxColumn,
            this.idCajaDataGridViewTextBoxColumn,
            this.cajaDataGridViewTextBoxColumn,
            this.cajeroDataGridViewTextBoxColumn});
      this.grdAlivios.DataSource = this.alivioAprobacionBindingSource;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.grdAlivios.DefaultCellStyle = dataGridViewCellStyle4;
      this.grdAlivios.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grdAlivios.Location = new System.Drawing.Point(0, 0);
      this.grdAlivios.Name = "grdAlivios";
      this.grdAlivios.ReadOnly = true;
      this.grdAlivios.RowHeadersVisible = false;
      this.grdAlivios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.grdAlivios.Size = new System.Drawing.Size(604, 403);
      this.grdAlivios.TabIndex = 14;
      this.grdAlivios.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdAlivios_CellBeginEdit);
      this.grdAlivios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAlivios_CellDoubleClick);
      // 
      // fechaAlivioDataGridViewTextBoxColumn
      // 
      this.fechaAlivioDataGridViewTextBoxColumn.DataPropertyName = "FechaAlivio";
      dataGridViewCellStyle2.Format = "d";
      dataGridViewCellStyle2.NullValue = null;
      this.fechaAlivioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
      this.fechaAlivioDataGridViewTextBoxColumn.HeaderText = "Fecha";
      this.fechaAlivioDataGridViewTextBoxColumn.Name = "fechaAlivioDataGridViewTextBoxColumn";
      this.fechaAlivioDataGridViewTextBoxColumn.ReadOnly = true;
      this.fechaAlivioDataGridViewTextBoxColumn.Width = 70;
      // 
      // horaAlivioDataGridViewTextBoxColumn
      // 
      this.horaAlivioDataGridViewTextBoxColumn.DataPropertyName = "FechaAlivio";
      dataGridViewCellStyle3.Format = "t";
      dataGridViewCellStyle3.NullValue = null;
      this.horaAlivioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
      this.horaAlivioDataGridViewTextBoxColumn.HeaderText = "Hora";
      this.horaAlivioDataGridViewTextBoxColumn.Name = "horaAlivioDataGridViewTextBoxColumn";
      this.horaAlivioDataGridViewTextBoxColumn.ReadOnly = true;
      this.horaAlivioDataGridViewTextBoxColumn.Width = 70;
      // 
      // idAlivioDataGridViewTextBoxColumn
      // 
      this.idAlivioDataGridViewTextBoxColumn.DataPropertyName = "IdAlivio";
      this.idAlivioDataGridViewTextBoxColumn.HeaderText = "Id Alivio";
      this.idAlivioDataGridViewTextBoxColumn.Name = "idAlivioDataGridViewTextBoxColumn";
      this.idAlivioDataGridViewTextBoxColumn.ReadOnly = true;
      this.idAlivioDataGridViewTextBoxColumn.Width = 50;
      // 
      // idCajaDataGridViewTextBoxColumn
      // 
      this.idCajaDataGridViewTextBoxColumn.DataPropertyName = "IdCaja";
      this.idCajaDataGridViewTextBoxColumn.HeaderText = "Id Caja";
      this.idCajaDataGridViewTextBoxColumn.Name = "idCajaDataGridViewTextBoxColumn";
      this.idCajaDataGridViewTextBoxColumn.ReadOnly = true;
      this.idCajaDataGridViewTextBoxColumn.Width = 50;
      // 
      // cajaDataGridViewTextBoxColumn
      // 
      this.cajaDataGridViewTextBoxColumn.DataPropertyName = "Caja";
      this.cajaDataGridViewTextBoxColumn.HeaderText = "Caja";
      this.cajaDataGridViewTextBoxColumn.Name = "cajaDataGridViewTextBoxColumn";
      this.cajaDataGridViewTextBoxColumn.ReadOnly = true;
      this.cajaDataGridViewTextBoxColumn.Width = 170;
      // 
      // cajeroDataGridViewTextBoxColumn
      // 
      this.cajeroDataGridViewTextBoxColumn.DataPropertyName = "Cajero";
      this.cajeroDataGridViewTextBoxColumn.HeaderText = "Nombre y Apellido";
      this.cajeroDataGridViewTextBoxColumn.Name = "cajeroDataGridViewTextBoxColumn";
      this.cajeroDataGridViewTextBoxColumn.ReadOnly = true;
      this.cajeroDataGridViewTextBoxColumn.Width = 170;
      // 
      // alivioAprobacionBindingSource
      // 
      this.alivioAprobacionBindingSource.DataSource = typeof(SEGAN_POS.DAL.AlivioAprobacion);
      // 
      // btCancel
      // 
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(518, 5);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(82, 33);
      this.btCancel.TabIndex = 24;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btCancel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 403);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(604, 43);
      this.panel1.TabIndex = 25;
      // 
      // frmAprobarAlivio
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(604, 446);
      this.Controls.Add(this.grdAlivios);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAprobarAlivio";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmAprobarAlivio";
      this.Activated += new System.EventHandler(this.frmAprobarAlivio_Activated);
      this.Load += new System.EventHandler(this.frmAprobarAlivio_Load);
      this.Shown += new System.EventHandler(this.frmAprobarAlivio_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.grdAlivios)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.alivioAprobacionBindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView grdAlivios;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.BindingSource alivioAprobacionBindingSource;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridViewTextBoxColumn fechaAlivioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn horaAlivioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idAlivioDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn idCajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cajaDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn cajeroDataGridViewTextBoxColumn;
  }
}