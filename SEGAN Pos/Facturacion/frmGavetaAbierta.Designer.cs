namespace SEGAN_POS
{
  partial class frmGavetaAbierta
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tmEsperaGaveta = new System.Windows.Forms.Timer(this.components);
      this.tmGaveta = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.advertencia;
      this.pictureBox1.Location = new System.Drawing.Point(30, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.UseWaitCursor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(105, 36);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(352, 24);
      this.label1.TabIndex = 13;
      this.label1.Text = "Cierre la gaveta de dinero, por favor.";
      this.label1.UseWaitCursor = true;
      // 
      // tmEsperaGaveta
      // 
      this.tmEsperaGaveta.Interval = 1000;
      this.tmEsperaGaveta.Tick += new System.EventHandler(this.tmEsperaGaveta_Tick);
      // 
      // tmGaveta
      // 
      this.tmGaveta.Tick += new System.EventHandler(this.tmGaveta_Tick);
      // 
      // frmGavetaAbierta
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(488, 99);
      this.ControlBox = false;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmGavetaAbierta";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Gaveta Abierta";
      this.UseWaitCursor = true;
      this.Activated += new System.EventHandler(this.frmGavetaAbierta_Activated);
      this.Load += new System.EventHandler(this.frmGavetaAbierta_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Timer tmEsperaGaveta;
    private System.Windows.Forms.Timer tmGaveta;
  }
}