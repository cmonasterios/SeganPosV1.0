namespace SEGAN_POS
{
  partial class frmEdCierreVentas
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
      this.txLote = new System.Windows.Forms.TextBox();
      this.txMontoCierre = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txObs = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.txMontoSistema = new System.Windows.Forms.TextBox();
      this.lbPOS = new System.Windows.Forms.Label();
      this.txPOS = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txFormaPago = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
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
      this.btOK.Location = new System.Drawing.Point(3, 3);
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
      this.label1.Location = new System.Drawing.Point(86, 119);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(28, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Lote";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txLote
      // 
      this.txLote.Location = new System.Drawing.Point(120, 116);
      this.txLote.MaxLength = 5;
      this.txLote.Name = "txLote";
      this.txLote.Size = new System.Drawing.Size(129, 20);
      this.txLote.TabIndex = 1;
      this.txLote.Enter += new System.EventHandler(this.txLote_Enter);
      this.txLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txLote_KeyPress);
      // 
      // txMontoCierre
      // 
      this.txMontoCierre.Location = new System.Drawing.Point(120, 90);
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
      this.label2.Location = new System.Drawing.Point(47, 93);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Monto Cierre";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txObs
      // 
      this.txObs.Location = new System.Drawing.Point(120, 142);
      this.txObs.MaxLength = 150;
      this.txObs.Multiline = true;
      this.txObs.Name = "txObs";
      this.txObs.Size = new System.Drawing.Size(258, 49);
      this.txObs.TabIndex = 2;
      this.txObs.Enter += new System.EventHandler(this.txObs_Enter);
      this.txObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txObs_KeyPress);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(36, 145);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "Observaciones";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 201);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(401, 42);
      this.panel1.TabIndex = 11;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btOK);
      this.panel2.Controls.Add(this.btCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(221, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(180, 42);
      this.panel2.TabIndex = 0;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(37, 66);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(77, 13);
      this.label4.TabIndex = 25;
      this.label4.Text = "Monto Sistema";
      // 
      // txMontoSistema
      // 
      this.txMontoSistema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoSistema.Location = new System.Drawing.Point(120, 64);
      this.txMontoSistema.Name = "txMontoSistema";
      this.txMontoSistema.ReadOnly = true;
      this.txMontoSistema.Size = new System.Drawing.Size(129, 20);
      this.txMontoSistema.TabIndex = 24;
      this.txMontoSistema.TabStop = false;
      // 
      // lbPOS
      // 
      this.lbPOS.AutoSize = true;
      this.lbPOS.Location = new System.Drawing.Point(85, 40);
      this.lbPOS.Name = "lbPOS";
      this.lbPOS.Size = new System.Drawing.Size(29, 13);
      this.lbPOS.TabIndex = 23;
      this.lbPOS.Text = "POS";
      // 
      // txPOS
      // 
      this.txPOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txPOS.Location = new System.Drawing.Point(120, 38);
      this.txPOS.Name = "txPOS";
      this.txPOS.ReadOnly = true;
      this.txPOS.Size = new System.Drawing.Size(258, 20);
      this.txPOS.TabIndex = 22;
      this.txPOS.TabStop = false;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(35, 14);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(79, 13);
      this.label6.TabIndex = 21;
      this.label6.Text = "Forma de Pago";
      // 
      // txFormaPago
      // 
      this.txFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txFormaPago.Location = new System.Drawing.Point(120, 12);
      this.txFormaPago.Name = "txFormaPago";
      this.txFormaPago.ReadOnly = true;
      this.txFormaPago.Size = new System.Drawing.Size(258, 20);
      this.txFormaPago.TabIndex = 20;
      this.txFormaPago.TabStop = false;
      // 
      // frmEdCierreVentas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(401, 243);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txMontoSistema);
      this.Controls.Add(this.lbPOS);
      this.Controls.Add(this.txPOS);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.txFormaPago);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.txObs);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txMontoCierre);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txLote);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmEdCierreVentas";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Editar Otros Pagos";
      this.Activated += new System.EventHandler(this.frmEdCierreVentas_Activated);
      this.Load += new System.EventHandler(this.frmEditCierreVentas_Load);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txLote;
    private System.Windows.Forms.TextBox txMontoCierre;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txObs;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txMontoSistema;
    private System.Windows.Forms.Label lbPOS;
    private System.Windows.Forms.TextBox txPOS;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txFormaPago;
  }
}