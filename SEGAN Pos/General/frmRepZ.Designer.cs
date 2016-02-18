namespace SEGAN_POS
{
  partial class frmRepZ
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbWarning = new System.Windows.Forms.Label();
      this.pbWarning = new System.Windows.Forms.PictureBox();
      this.pbOK = new System.Windows.Forms.PictureBox();
      this.lbOK = new System.Windows.Forms.Label();
      this.btContinuar = new System.Windows.Forms.Button();
      this.lbMensajes = new System.Windows.Forms.ListBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbOK)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lbWarning);
      this.panel1.Controls.Add(this.pbWarning);
      this.panel1.Controls.Add(this.pbOK);
      this.panel1.Controls.Add(this.lbOK);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(433, 93);
      this.panel1.TabIndex = 17;
      this.panel1.UseWaitCursor = true;
      // 
      // lbWarning
      // 
      this.lbWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbWarning.Location = new System.Drawing.Point(90, 20);
      this.lbWarning.Name = "lbWarning";
      this.lbWarning.Size = new System.Drawing.Size(327, 52);
      this.lbWarning.TabIndex = 17;
      this.lbWarning.Text = "Advertencia: No apague la impresora hasta que el sistema lo indique";
      this.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lbWarning.UseWaitCursor = true;
      // 
      // pbWarning
      // 
      this.pbWarning.Image = global::SEGAN_POS.Properties.Resources.warning;
      this.pbWarning.Location = new System.Drawing.Point(25, 14);
      this.pbWarning.Name = "pbWarning";
      this.pbWarning.Size = new System.Drawing.Size(64, 64);
      this.pbWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pbWarning.TabIndex = 18;
      this.pbWarning.TabStop = false;
      this.pbWarning.UseWaitCursor = true;
      // 
      // pbOK
      // 
      this.pbOK.Image = global::SEGAN_POS.Properties.Resources.check;
      this.pbOK.Location = new System.Drawing.Point(25, 21);
      this.pbOK.Name = "pbOK";
      this.pbOK.Size = new System.Drawing.Size(64, 50);
      this.pbOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pbOK.TabIndex = 21;
      this.pbOK.TabStop = false;
      this.pbOK.UseWaitCursor = true;
      this.pbOK.Visible = false;
      // 
      // lbOK
      // 
      this.lbOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbOK.Location = new System.Drawing.Point(90, 20);
      this.lbOK.Name = "lbOK";
      this.lbOK.Size = new System.Drawing.Size(327, 52);
      this.lbOK.TabIndex = 21;
      this.lbOK.Text = "Puede apagar la Impresora Fiscal";
      this.lbOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lbOK.UseWaitCursor = true;
      this.lbOK.Visible = false;
      // 
      // btContinuar
      // 
      this.btContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btContinuar.CausesValidation = false;
      this.btContinuar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btContinuar.Enabled = false;
      this.btContinuar.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btContinuar.Location = new System.Drawing.Point(333, 200);
      this.btContinuar.Name = "btContinuar";
      this.btContinuar.Size = new System.Drawing.Size(88, 32);
      this.btContinuar.TabIndex = 18;
      this.btContinuar.TabStop = false;
      this.btContinuar.Text = "Continuar";
      this.btContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btContinuar.UseVisualStyleBackColor = true;
      this.btContinuar.UseWaitCursor = true;
      this.btContinuar.Click += new System.EventHandler(this.btContinuar_Click);
      // 
      // lbMensajes
      // 
      this.lbMensajes.FormattingEnabled = true;
      this.lbMensajes.Location = new System.Drawing.Point(23, 103);
      this.lbMensajes.Name = "lbMensajes";
      this.lbMensajes.Size = new System.Drawing.Size(397, 82);
      this.lbMensajes.TabIndex = 20;
      this.lbMensajes.UseWaitCursor = true;
      // 
      // frmRepZ
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(433, 244);
      this.ControlBox = false;
      this.Controls.Add(this.lbMensajes);
      this.Controls.Add(this.btContinuar);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmRepZ";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Emitiendo Reporte Z";
      this.UseWaitCursor = true;
      this.Activated += new System.EventHandler(this.frmRepZ_Activated);
      this.Shown += new System.EventHandler(this.frmRepZ_Shown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbWarning)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pbOK)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btContinuar;
    private System.Windows.Forms.Label lbWarning;
    private System.Windows.Forms.PictureBox pbWarning;
    private System.Windows.Forms.ListBox lbMensajes;
    private System.Windows.Forms.PictureBox pbOK;
    private System.Windows.Forms.Label lbOK;
  }
}