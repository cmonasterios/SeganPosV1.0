namespace SEGAN_POS
{
  partial class frmConfig
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
      this.btOK = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.lblServidor = new System.Windows.Forms.Label();
      this.txServidor = new System.Windows.Forms.TextBox();
      this.gbDB = new System.Windows.Forms.GroupBox();
      this.txPwd = new System.Windows.Forms.TextBox();
      this.lbPwd = new System.Windows.Forms.Label();
      this.txUsr = new System.Windows.Forms.TextBox();
      this.lbUsr = new System.Windows.Forms.Label();
      this.txDB = new System.Windows.Forms.TextBox();
      this.lbDB = new System.Windows.Forms.Label();
      this.chCont = new System.Windows.Forms.CheckBox();
      this.gbCont = new System.Windows.Forms.GroupBox();
      this.txPwdCont = new System.Windows.Forms.TextBox();
      this.lbPwdCont = new System.Windows.Forms.Label();
      this.txUsrCont = new System.Windows.Forms.TextBox();
      this.lbUsrCont = new System.Windows.Forms.Label();
      this.txDBCont = new System.Windows.Forms.TextBox();
      this.lbDBCont = new System.Windows.Forms.Label();
      this.txServCont = new System.Windows.Forms.TextBox();
      this.lbServCont = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.gbDB.SuspendLayout();
      this.gbCont.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(449, 248);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 15;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(537, 248);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(82, 33);
      this.btCancel.TabIndex = 16;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // lblServidor
      // 
      this.lblServidor.AutoSize = true;
      this.lblServidor.Location = new System.Drawing.Point(21, 31);
      this.lblServidor.Name = "lblServidor";
      this.lblServidor.Size = new System.Drawing.Size(46, 13);
      this.lblServidor.TabIndex = 35;
      this.lblServidor.Text = "Servidor";
      this.lblServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txServidor
      // 
      this.txServidor.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txServidor.Location = new System.Drawing.Point(73, 28);
      this.txServidor.MaxLength = 30;
      this.txServidor.Name = "txServidor";
      this.txServidor.Size = new System.Drawing.Size(203, 20);
      this.txServidor.TabIndex = 0;
      this.txServidor.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // gbDB
      // 
      this.gbDB.Controls.Add(this.txPwd);
      this.gbDB.Controls.Add(this.lbPwd);
      this.gbDB.Controls.Add(this.txUsr);
      this.gbDB.Controls.Add(this.lbUsr);
      this.gbDB.Controls.Add(this.txDB);
      this.gbDB.Controls.Add(this.lbDB);
      this.gbDB.Controls.Add(this.txServidor);
      this.gbDB.Controls.Add(this.lblServidor);
      this.gbDB.Location = new System.Drawing.Point(12, 12);
      this.gbDB.Name = "gbDB";
      this.gbDB.Size = new System.Drawing.Size(605, 95);
      this.gbDB.TabIndex = 36;
      this.gbDB.TabStop = false;
      this.gbDB.Text = "Conexión";
      // 
      // txPwd
      // 
      this.txPwd.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txPwd.Location = new System.Drawing.Point(376, 54);
      this.txPwd.MaxLength = 30;
      this.txPwd.Name = "txPwd";
      this.txPwd.Size = new System.Drawing.Size(203, 20);
      this.txPwd.TabIndex = 3;
      this.txPwd.UseSystemPasswordChar = true;
      this.txPwd.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbPwd
      // 
      this.lbPwd.AutoSize = true;
      this.lbPwd.Location = new System.Drawing.Point(317, 57);
      this.lbPwd.Name = "lbPwd";
      this.lbPwd.Size = new System.Drawing.Size(53, 13);
      this.lbPwd.TabIndex = 41;
      this.lbPwd.Text = "Password";
      this.lbPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txUsr
      // 
      this.txUsr.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txUsr.Location = new System.Drawing.Point(376, 28);
      this.txUsr.MaxLength = 30;
      this.txUsr.Name = "txUsr";
      this.txUsr.Size = new System.Drawing.Size(203, 20);
      this.txUsr.TabIndex = 2;
      this.txUsr.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbUsr
      // 
      this.lbUsr.AutoSize = true;
      this.lbUsr.Location = new System.Drawing.Point(327, 31);
      this.lbUsr.Name = "lbUsr";
      this.lbUsr.Size = new System.Drawing.Size(43, 13);
      this.lbUsr.TabIndex = 39;
      this.lbUsr.Text = "Usuario";
      this.lbUsr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txDB
      // 
      this.txDB.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDB.Location = new System.Drawing.Point(73, 54);
      this.txDB.MaxLength = 30;
      this.txDB.Name = "txDB";
      this.txDB.Size = new System.Drawing.Size(203, 20);
      this.txDB.TabIndex = 1;
      this.txDB.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbDB
      // 
      this.lbDB.AutoSize = true;
      this.lbDB.Location = new System.Drawing.Point(45, 57);
      this.lbDB.Name = "lbDB";
      this.lbDB.Size = new System.Drawing.Size(22, 13);
      this.lbDB.TabIndex = 37;
      this.lbDB.Text = "BD";
      this.lbDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // chCont
      // 
      this.chCont.AutoSize = true;
      this.chCont.Location = new System.Drawing.Point(12, 125);
      this.chCont.Name = "chCont";
      this.chCont.Size = new System.Drawing.Size(125, 17);
      this.chCont.TabIndex = 4;
      this.chCont.Text = "Permitir Contingencia";
      this.chCont.UseVisualStyleBackColor = true;
      this.chCont.CheckedChanged += new System.EventHandler(this.cbCont_CheckedChanged);
      // 
      // gbCont
      // 
      this.gbCont.Controls.Add(this.txPwdCont);
      this.gbCont.Controls.Add(this.lbPwdCont);
      this.gbCont.Controls.Add(this.txUsrCont);
      this.gbCont.Controls.Add(this.lbUsrCont);
      this.gbCont.Controls.Add(this.txDBCont);
      this.gbCont.Controls.Add(this.lbDBCont);
      this.gbCont.Controls.Add(this.txServCont);
      this.gbCont.Controls.Add(this.lbServCont);
      this.gbCont.Enabled = false;
      this.gbCont.Location = new System.Drawing.Point(12, 148);
      this.gbCont.Name = "gbCont";
      this.gbCont.Size = new System.Drawing.Size(605, 91);
      this.gbCont.TabIndex = 38;
      this.gbCont.TabStop = false;
      this.gbCont.Text = "Contingencia";
      // 
      // txPwdCont
      // 
      this.txPwdCont.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txPwdCont.Location = new System.Drawing.Point(376, 54);
      this.txPwdCont.MaxLength = 30;
      this.txPwdCont.Name = "txPwdCont";
      this.txPwdCont.Size = new System.Drawing.Size(203, 20);
      this.txPwdCont.TabIndex = 8;
      this.txPwdCont.UseSystemPasswordChar = true;
      this.txPwdCont.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbPwdCont
      // 
      this.lbPwdCont.AutoSize = true;
      this.lbPwdCont.Location = new System.Drawing.Point(317, 57);
      this.lbPwdCont.Name = "lbPwdCont";
      this.lbPwdCont.Size = new System.Drawing.Size(53, 13);
      this.lbPwdCont.TabIndex = 41;
      this.lbPwdCont.Text = "Password";
      this.lbPwdCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txUsrCont
      // 
      this.txUsrCont.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txUsrCont.Location = new System.Drawing.Point(376, 28);
      this.txUsrCont.MaxLength = 30;
      this.txUsrCont.Name = "txUsrCont";
      this.txUsrCont.Size = new System.Drawing.Size(203, 20);
      this.txUsrCont.TabIndex = 7;
      this.txUsrCont.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbUsrCont
      // 
      this.lbUsrCont.AutoSize = true;
      this.lbUsrCont.Location = new System.Drawing.Point(327, 31);
      this.lbUsrCont.Name = "lbUsrCont";
      this.lbUsrCont.Size = new System.Drawing.Size(43, 13);
      this.lbUsrCont.TabIndex = 39;
      this.lbUsrCont.Text = "Usuario";
      this.lbUsrCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txDBCont
      // 
      this.txDBCont.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txDBCont.Location = new System.Drawing.Point(73, 54);
      this.txDBCont.MaxLength = 30;
      this.txDBCont.Name = "txDBCont";
      this.txDBCont.Size = new System.Drawing.Size(203, 20);
      this.txDBCont.TabIndex = 6;
      this.txDBCont.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbDBCont
      // 
      this.lbDBCont.AutoSize = true;
      this.lbDBCont.Location = new System.Drawing.Point(45, 57);
      this.lbDBCont.Name = "lbDBCont";
      this.lbDBCont.Size = new System.Drawing.Size(22, 13);
      this.lbDBCont.TabIndex = 37;
      this.lbDBCont.Text = "BD";
      this.lbDBCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txServCont
      // 
      this.txServCont.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.txServCont.Location = new System.Drawing.Point(73, 28);
      this.txServCont.MaxLength = 30;
      this.txServCont.Name = "txServCont";
      this.txServCont.Size = new System.Drawing.Size(203, 20);
      this.txServCont.TabIndex = 5;
      this.txServCont.Enter += new System.EventHandler(this.TextBox_Enter);
      // 
      // lbServCont
      // 
      this.lbServCont.AutoSize = true;
      this.lbServCont.Location = new System.Drawing.Point(21, 31);
      this.lbServCont.Name = "lbServCont";
      this.lbServCont.Size = new System.Drawing.Size(46, 13);
      this.lbServCont.TabIndex = 35;
      this.lbServCont.Text = "Servidor";
      this.lbServCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // frmConfig
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(631, 293);
      this.Controls.Add(this.gbCont);
      this.Controls.Add(this.chCont);
      this.Controls.Add(this.gbDB);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btCancel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConfig";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Configuración Inicial";
      this.Load += new System.EventHandler(this.frmConfig_Load);
      this.Shown += new System.EventHandler(this.frmConfig_Shown);
      this.gbDB.ResumeLayout(false);
      this.gbDB.PerformLayout();
      this.gbCont.ResumeLayout(false);
      this.gbCont.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Label lblServidor;
    private System.Windows.Forms.TextBox txServidor;
    private System.Windows.Forms.GroupBox gbDB;
    private System.Windows.Forms.TextBox txPwd;
    private System.Windows.Forms.Label lbPwd;
    private System.Windows.Forms.TextBox txUsr;
    private System.Windows.Forms.Label lbUsr;
    private System.Windows.Forms.TextBox txDB;
    private System.Windows.Forms.Label lbDB;
    private System.Windows.Forms.CheckBox chCont;
    private System.Windows.Forms.GroupBox gbCont;
    private System.Windows.Forms.TextBox txPwdCont;
    private System.Windows.Forms.Label lbPwdCont;
    private System.Windows.Forms.TextBox txUsrCont;
    private System.Windows.Forms.Label lbUsrCont;
    private System.Windows.Forms.TextBox txDBCont;
    private System.Windows.Forms.Label lbDBCont;
    private System.Windows.Forms.TextBox txServCont;
    private System.Windows.Forms.Label lbServCont;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}