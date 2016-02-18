namespace SEGAN_POS
{
  partial class frmAutorizar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txLogin = new System.Windows.Forms.TextBox();
            this.txPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txMensaje = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbObservacion = new System.Windows.Forms.Label();
            this.txObservacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.AutoSize = true;
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(331, 211);
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
            this.btOK.Location = new System.Drawing.Point(243, 211);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txLogin
            // 
            this.txLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txLogin.Location = new System.Drawing.Point(142, 104);
            this.txLogin.Name = "txLogin";
            this.txLogin.Size = new System.Drawing.Size(145, 20);
            this.txLogin.TabIndex = 0;
            // 
            // txPassword
            // 
            this.txPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txPassword.Location = new System.Drawing.Point(142, 144);
            this.txPassword.Name = "txPassword";
            this.txPassword.PasswordChar = '*';
            this.txPassword.Size = new System.Drawing.Size(145, 20);
            this.txPassword.TabIndex = 1;
            this.txPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Clave";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txMensaje
            // 
            this.txMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txMensaje.Location = new System.Drawing.Point(72, 20);
            this.txMensaje.Multiline = true;
            this.txMensaje.Name = "txMensaje";
            this.txMensaje.ReadOnly = true;
            this.txMensaje.Size = new System.Drawing.Size(353, 67);
            this.txMensaje.TabIndex = 9;
            this.txMensaje.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.advertencia;
            this.pictureBox1.Location = new System.Drawing.Point(12, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lbObservacion
            // 
            this.lbObservacion.AutoSize = true;
            this.lbObservacion.Location = new System.Drawing.Point(69, 178);
            this.lbObservacion.Name = "lbObservacion";
            this.lbObservacion.Size = new System.Drawing.Size(67, 13);
            this.lbObservacion.TabIndex = 11;
            this.lbObservacion.Text = "Observación";
            this.lbObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbObservacion.Visible = false;
            // 
            // txObservacion
            // 
            this.txObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txObservacion.Location = new System.Drawing.Point(142, 178);
            this.txObservacion.MaxLength = 150;
            this.txObservacion.Multiline = true;
            this.txObservacion.Name = "txObservacion";
            this.txObservacion.PasswordChar = '*';
            this.txObservacion.Size = new System.Drawing.Size(272, 20);
            this.txObservacion.TabIndex = 2;
            this.txObservacion.UseSystemPasswordChar = true;
            this.txObservacion.Visible = false;
            // 
            // frmAutorizar
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(437, 255);
            this.Controls.Add(this.txObservacion);
            this.Controls.Add(this.lbObservacion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txMensaje);
            this.Controls.Add(this.txPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutorizar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorización";
            this.Activated += new System.EventHandler(this.frmAutorizar_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAutorizar_FormClosing);
            this.Load += new System.EventHandler(this.frmAutorizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txLogin;
    private System.Windows.Forms.TextBox txPassword;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txMensaje;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lbObservacion;
    private System.Windows.Forms.TextBox txObservacion;
  }
}