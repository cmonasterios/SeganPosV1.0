namespace SEGAN_POS
{
  partial class frmVerFoto
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
      this.pbFotoArt = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).BeginInit();
      this.SuspendLayout();
      // 
      // pbFotoArt
      // 
      this.pbFotoArt.Location = new System.Drawing.Point(0, 0);
      this.pbFotoArt.Name = "pbFotoArt";
      this.pbFotoArt.Size = new System.Drawing.Size(349, 349);
      this.pbFotoArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbFotoArt.TabIndex = 0;
      this.pbFotoArt.TabStop = false;
      this.pbFotoArt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbFotoArt_MouseClick);
      this.pbFotoArt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbFotoArt_MouseDoubleClick);
      // 
      // frmVerFoto
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(349, 349);
      this.Controls.Add(this.pbFotoArt);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmVerFoto";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmVerFoto";
      this.Activated += new System.EventHandler(this.frmVerFoto_Activated);
      this.Load += new System.EventHandler(this.frmVerFoto_Load);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmVerFoto_KeyPress);
      ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pbFotoArt;
  }
}