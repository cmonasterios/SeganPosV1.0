namespace SEGAN_POS
{
  partial class frmBuscarVendedor
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
      this.cbVendedor = new System.Windows.Forms.ComboBox();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // cbVendedor
      // 
      this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbVendedor.Enabled = false;
      this.cbVendedor.FormattingEnabled = true;
      this.cbVendedor.Location = new System.Drawing.Point(84, 25);
      this.cbVendedor.Name = "cbVendedor";
      this.cbVendedor.Size = new System.Drawing.Size(257, 21);
      this.cbVendedor.TabIndex = 0;
      this.cbVendedor.SelectedIndexChanged += new System.EventHandler(this.cbVendedor_SelectedIndexChanged);
      // 
      // btCancel
      // 
      this.btCancel.AutoSize = true;
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(258, 74);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(83, 33);
      this.btCancel.TabIndex = 2;
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
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(170, 74);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 1;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(25, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 13);
      this.label1.TabIndex = 12;
      this.label1.Text = "Vendedor";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // frmBuscarVendedor
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(357, 124);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.cbVendedor);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmBuscarVendedor";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmBuscarVendedor";
      this.Activated += new System.EventHandler(this.frmBuscarVendedor_Activated);
      this.Load += new System.EventHandler(this.frmBuscarVendedor_Load);
      this.Shown += new System.EventHandler(this.frmBuscarVendedor_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cbVendedor;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Label label1;
  }
}