namespace SEGAN_POS
{
  partial class frmCantidad
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
      this.udCantidad = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.udCantidad)).BeginInit();
      this.SuspendLayout();
      // 
      // udCantidad
      // 
      this.udCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.udCantidad.Dock = System.Windows.Forms.DockStyle.Fill;
      this.udCantidad.Location = new System.Drawing.Point(0, 0);
      this.udCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.udCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.udCantidad.Name = "udCantidad";
      this.udCantidad.Size = new System.Drawing.Size(179, 20);
      this.udCantidad.TabIndex = 4;
      this.udCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.udCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.udCantidad_KeyPress);
      // 
      // frmCantidad
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(179, 20);
      this.Controls.Add(this.udCantidad);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmCantidad";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Editar Cantidad";
      this.Load += new System.EventHandler(this.frmCantidad_Load);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCantidad_KeyPress);
      ((System.ComponentModel.ISupportInitialize)(this.udCantidad)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown udCantidad;
  }
}