namespace SEGAN_POS
{
  partial class frmArtPorRef
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
      this.lbArticulos = new System.Windows.Forms.ListBox();
      this.pbFotoArt = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).BeginInit();
      this.SuspendLayout();
      // 
      // lbArticulos
      // 
      this.lbArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbArticulos.FormattingEnabled = true;
      this.lbArticulos.IntegralHeight = false;
      this.lbArticulos.ItemHeight = 16;
      this.lbArticulos.Location = new System.Drawing.Point(2, 2);
      this.lbArticulos.Name = "lbArticulos";
      this.lbArticulos.Size = new System.Drawing.Size(131, 173);
      this.lbArticulos.TabIndex = 1;
      this.lbArticulos.UseTabStops = false;
      this.lbArticulos.SelectedIndexChanged += new System.EventHandler(this.lbArticulos_SelectedIndexChanged);
      this.lbArticulos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbArticulos_KeyPress);
      this.lbArticulos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbArticulos_MouseDoubleClick);
      // 
      // pbFotoArt
      // 
      this.pbFotoArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pbFotoArt.Location = new System.Drawing.Point(135, 2);
      this.pbFotoArt.Name = "pbFotoArt";
      this.pbFotoArt.Size = new System.Drawing.Size(173, 173);
      this.pbFotoArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbFotoArt.TabIndex = 2;
      this.pbFotoArt.TabStop = false;
      // 
      // frmArtPorRef
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(311, 178);
      this.ControlBox = false;
      this.Controls.Add(this.pbFotoArt);
      this.Controls.Add(this.lbArticulos);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmArtPorRef";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = " Seleccionar Artículo";
      this.Activated += new System.EventHandler(this.frmArtPorRef_Activated);
      this.Load += new System.EventHandler(this.frmArtPorRef_Load);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmArtPorRef_KeyPress);
      ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lbArticulos;
    private System.Windows.Forms.PictureBox pbFotoArt;

  }
}