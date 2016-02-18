namespace SEGAN_POS
{
  partial class frmCambioClave
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
      this.btCancel = new System.Windows.Forms.Button();
      this.btOK = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txNewPass = new System.Windows.Forms.TextBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.txOldPass = new System.Windows.Forms.TextBox();
      this.txNewPassConfirm = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lbUsuario = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // btCancel
      // 
      this.btCancel.AutoSize = true;
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(379, 184);
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
      this.btOK.Location = new System.Drawing.Point(291, 184);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 3;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(230, 96);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(80, 13);
      this.label2.TabIndex = 9;
      this.label2.Text = "Nueva Clave";
      // 
      // txNewPass
      // 
      this.txNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txNewPass.Location = new System.Drawing.Point(316, 94);
      this.txNewPass.MaxLength = 30;
      this.txNewPass.Name = "txNewPass";
      this.txNewPass.PasswordChar = '*';
      this.txNewPass.Size = new System.Drawing.Size(145, 20);
      this.txNewPass.TabIndex = 1;
      this.txNewPass.UseSystemPasswordChar = true;
      this.txNewPass.Enter += new System.EventHandler(this.txNewPass_Enter);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.epklogo;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(152, 112);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 10;
      this.pictureBox1.TabStop = false;
      // 
      // txOldPass
      // 
      this.txOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txOldPass.Location = new System.Drawing.Point(316, 57);
      this.txOldPass.MaxLength = 30;
      this.txOldPass.Name = "txOldPass";
      this.txOldPass.PasswordChar = '*';
      this.txOldPass.Size = new System.Drawing.Size(145, 20);
      this.txOldPass.TabIndex = 0;
      this.txOldPass.UseSystemPasswordChar = true;
      this.txOldPass.Enter += new System.EventHandler(this.txOldPass_Enter);
      // 
      // txNewPassConfirm
      // 
      this.txNewPassConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txNewPassConfirm.Location = new System.Drawing.Point(316, 131);
      this.txNewPassConfirm.MaxLength = 30;
      this.txNewPassConfirm.Name = "txNewPassConfirm";
      this.txNewPassConfirm.PasswordChar = '*';
      this.txNewPassConfirm.Size = new System.Drawing.Size(145, 20);
      this.txNewPassConfirm.TabIndex = 2;
      this.txNewPassConfirm.UseSystemPasswordChar = true;
      this.txNewPassConfirm.Enter += new System.EventHandler(this.txNewPassConfirm_Enter);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(189, 133);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 13);
      this.label3.TabIndex = 13;
      this.label3.Text = "Repita Nueva Clave";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(223, 59);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(87, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Clave Anterior";
      // 
      // lbUsuario
      // 
      this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbUsuario.ForeColor = System.Drawing.Color.White;
      this.lbUsuario.Location = new System.Drawing.Point(192, 28);
      this.lbUsuario.Name = "lbUsuario";
      this.lbUsuario.Size = new System.Drawing.Size(269, 13);
      this.lbUsuario.TabIndex = 15;
      this.lbUsuario.Text = "lbUsuario";
      this.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // frmCambioClave
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(147)))), ((int)(((byte)(148)))));
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(483, 228);
      this.Controls.Add(this.lbUsuario);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txNewPassConfirm);
      this.Controls.Add(this.txOldPass);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txNewPass);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmCambioClave";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Cambio de Clave";
      this.Activated += new System.EventHandler(this.frmCambioClave_Activated);
      this.Load += new System.EventHandler(this.frmCambioClave_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txNewPass;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TextBox txOldPass;
    private System.Windows.Forms.TextBox txNewPassConfirm;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label lbUsuario;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}