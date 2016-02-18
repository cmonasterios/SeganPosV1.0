namespace SEGAN_POS
{
  partial class frmEdCierreVentasEf
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
      this.btCancel = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.txMontoSistema = new System.Windows.Forms.TextBox();
      this.txObs = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txMontoCierre = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 122);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(381, 42);
      this.panel1.TabIndex = 12;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btOK);
      this.panel2.Controls.Add(this.btCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(201, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(180, 42);
      this.panel2.TabIndex = 0;
      // 
      // btOK
      // 
      this.btOK.AutoSize = true;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(3, 3);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 2;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancel
      // 
      this.btCancel.AutoSize = true;
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(91, 3);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(83, 33);
      this.btCancel.TabIndex = 3;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(18, 14);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(77, 13);
      this.label4.TabIndex = 31;
      this.label4.Text = "Monto Sistema";
      // 
      // txMontoSistema
      // 
      this.txMontoSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoSistema.Location = new System.Drawing.Point(101, 12);
      this.txMontoSistema.Name = "txMontoSistema";
      this.txMontoSistema.ReadOnly = true;
      this.txMontoSistema.Size = new System.Drawing.Size(129, 20);
      this.txMontoSistema.TabIndex = 30;
      this.txMontoSistema.TabStop = false;
      // 
      // txObs
      // 
      this.txObs.Location = new System.Drawing.Point(101, 64);
      this.txObs.MaxLength = 150;
      this.txObs.Multiline = true;
      this.txObs.Name = "txObs";
      this.txObs.Size = new System.Drawing.Size(258, 49);
      this.txObs.TabIndex = 1;
      this.txObs.Enter += new System.EventHandler(this.txObs_Enter);
      this.txObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txObs_KeyPress);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 67);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 13);
      this.label3.TabIndex = 29;
      this.label3.Text = "Observaciones";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txMontoCierre
      // 
      this.txMontoCierre.Location = new System.Drawing.Point(101, 38);
      this.txMontoCierre.MaxLength = 30;
      this.txMontoCierre.Name = "txMontoCierre";
      this.txMontoCierre.Size = new System.Drawing.Size(129, 20);
      this.txMontoCierre.TabIndex = 0;
      this.txMontoCierre.Enter += new System.EventHandler(this.txMontoCierre_Enter);
      this.txMontoCierre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txMontoCierre_KeyDown);
      this.txMontoCierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMontoCierre_KeyPress);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(28, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(73, 13);
      this.label2.TabIndex = 28;
      this.label2.Text = "Total Efectivo";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // frmEdCierreVentasEf
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(381, 164);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txMontoSistema);
      this.Controls.Add(this.txObs);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txMontoCierre);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmEdCierreVentasEf";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Editar Efectivo";
      this.Activated += new System.EventHandler(this.frmEdCierreVentasEf_Activated);
      this.Load += new System.EventHandler(this.frmEditCierreVentasEf_Load);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txMontoSistema;
    private System.Windows.Forms.TextBox txObs;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txMontoCierre;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}