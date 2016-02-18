namespace SEGAN_POS
{
  partial class frmAutorizarDesc
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
      this.txPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txLogin = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.udDescuento = new System.Windows.Forms.NumericUpDown();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.udDescuento)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // txPassword
      // 
      this.txPassword.Location = new System.Drawing.Point(269, 133);
      this.txPassword.Name = "txPassword";
      this.txPassword.PasswordChar = '*';
      this.txPassword.Size = new System.Drawing.Size(145, 20);
      this.txPassword.TabIndex = 2;
      this.txPassword.UseSystemPasswordChar = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(229, 136);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(34, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Clave";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txLogin
      // 
      this.txLogin.Location = new System.Drawing.Point(269, 95);
      this.txLogin.Name = "txLogin";
      this.txLogin.Size = new System.Drawing.Size(145, 20);
      this.txLogin.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(220, 98);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 15;
      this.label1.Text = "Usuario";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btCancel
      // 
      this.btCancel.AutoSize = true;
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(331, 182);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(83, 33);
      this.btCancel.TabIndex = 4;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btOK
      // 
      this.btOK.AutoSize = true;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(243, 182);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 3;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // udDescuento
      // 
      this.udDescuento.DecimalPlaces = 2;
      this.errorProvider1.SetIconPadding(this.udDescuento, 16);
      this.udDescuento.Location = new System.Drawing.Point(86, 95);
      this.udDescuento.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
      this.udDescuento.Name = "udDescuento";
      this.udDescuento.Size = new System.Drawing.Size(77, 20);
      this.udDescuento.TabIndex = 0;
      this.udDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.advertencia;
      this.pictureBox1.Location = new System.Drawing.Point(12, 17);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(54, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 18;
      this.pictureBox1.TabStop = false;
      // 
      // label3
      // 
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(72, 17);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(342, 48);
      this.label3.TabIndex = 20;
      this.label3.Text = "¿ Autorizar Descuento ?";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(21, 98);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 13);
      this.label4.TabIndex = 21;
      this.label4.Text = "Descuento";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(167, 99);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(15, 13);
      this.label5.TabIndex = 22;
      this.label5.Text = "%";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // frmAutorizarDesc
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(437, 227);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.udDescuento);
      this.Controls.Add(this.txPassword);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txLogin);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAutorizarDesc";
      this.ShowInTaskbar = false;
      this.Text = "Autorizar Descuento";
      this.Activated += new System.EventHandler(this.frmAutorizarDesc_Activated);
      this.Load += new System.EventHandler(this.frmAutorizarDesc_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.udDescuento)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txPassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txLogin;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.NumericUpDown udDescuento;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
  }
}