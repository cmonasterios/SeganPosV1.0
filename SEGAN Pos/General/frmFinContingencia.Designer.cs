namespace SEGAN_POS
{
  partial class frmFinContingencia
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btOK = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.txPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txLogin = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 272);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(464, 47);
      this.panel1.TabIndex = 5;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btOK);
      this.panel2.Controls.Add(this.btCancelar);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(281, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(183, 47);
      this.panel2.TabIndex = 13;
      // 
      // btOK
      // 
      this.btOK.AutoSize = true;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(3, 7);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 11;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancelar.Location = new System.Drawing.Point(91, 7);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(83, 32);
      this.btCancelar.TabIndex = 10;
      this.btCancelar.TabStop = false;
      this.btCancelar.Text = "Cancelar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // txPassword
      // 
      this.txPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txPassword.Location = new System.Drawing.Point(177, 159);
      this.txPassword.Name = "txPassword";
      this.txPassword.PasswordChar = '*';
      this.txPassword.Size = new System.Drawing.Size(145, 20);
      this.txPassword.TabIndex = 14;
      this.txPassword.UseSystemPasswordChar = true;
      this.txPassword.Enter += new System.EventHandler(this.txPassword_Enter);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(137, 162);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Clave";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txLogin
      // 
      this.txLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txLogin.Location = new System.Drawing.Point(177, 121);
      this.txLogin.Name = "txLogin";
      this.txLogin.Size = new System.Drawing.Size(145, 20);
      this.txLogin.TabIndex = 13;
      this.txLogin.Enter += new System.EventHandler(this.txLogin_Enter);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(128, 124);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "Usuario";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(96, 29);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(357, 48);
      this.label3.TabIndex = 23;
      this.label3.Text = "Desactivación de la Contingencia";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.fincontingencia;
      this.pictureBox1.Location = new System.Drawing.Point(26, 22);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(64, 64);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 22;
      this.pictureBox1.TabStop = false;
      // 
      // frmFinContingencia
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancelar;
      this.ClientSize = new System.Drawing.Size(464, 319);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.txPassword);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txLogin);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmFinContingencia";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Desactivación de la Contingencia";
      this.Load += new System.EventHandler(this.frmFinContingencia_Load);
      this.Shown += new System.EventHandler(this.frmFinContingencia_Shown);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.TextBox txPassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txLogin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}