namespace SEGAN_POS
{
  partial class frmEdCierreCajeroAgregar
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
            this.txMonto = new System.Windows.Forms.TextBox();
            this.txLote = new System.Windows.Forms.TextBox();
            this.txObs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPOS = new System.Windows.Forms.Label();
            this.cbFormasPago = new System.Windows.Forms.ComboBox();
            this.cbPOS = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txMonto
            // 
            this.txMonto.Location = new System.Drawing.Point(120, 70);
            this.txMonto.MaxLength = 30;
            this.txMonto.Name = "txMonto";
            this.txMonto.Size = new System.Drawing.Size(129, 20);
            this.txMonto.TabIndex = 0;
            this.txMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txMonto.Enter += new System.EventHandler(this.txMonto_Enter);
            this.txMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txMonto_KeyDown);
            this.txMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txMonto_KeyPress);
            // 
            // txLote
            // 
            this.txLote.Location = new System.Drawing.Point(323, 70);
            this.txLote.MaxLength = 5;
            this.txLote.Name = "txLote";
            this.txLote.Size = new System.Drawing.Size(129, 20);
            this.txLote.TabIndex = 1;
            this.txLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txLote.Enter += new System.EventHandler(this.txLote_Enter);
            this.txLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txLote_KeyPress);
            // 
            // txObs
            // 
            this.txObs.Location = new System.Drawing.Point(120, 100);
            this.txObs.MaxLength = 200;
            this.txObs.Multiline = true;
            this.txObs.Name = "txObs";
            this.txObs.Size = new System.Drawing.Size(332, 49);
            this.txObs.TabIndex = 2;
            this.txObs.Enter += new System.EventHandler(this.txObs_Enter);
            this.txObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txObs_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Monto Operaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lote";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Observaciones";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Forma de Pago";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 44);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Controls.Add(this.btCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(291, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 44);
            this.panel2.TabIndex = 0;
            // 
            // lbPOS
            // 
            this.lbPOS.AutoSize = true;
            this.lbPOS.Location = new System.Drawing.Point(85, 41);
            this.lbPOS.Name = "lbPOS";
            this.lbPOS.Size = new System.Drawing.Size(29, 13);
            this.lbPOS.TabIndex = 17;
            this.lbPOS.Text = "POS";
            // 
            // cbFormasPago
            // 
            this.cbFormasPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormasPago.FormattingEnabled = true;
            this.cbFormasPago.Location = new System.Drawing.Point(120, 11);
            this.cbFormasPago.Name = "cbFormasPago";
            this.cbFormasPago.Size = new System.Drawing.Size(332, 21);
            this.cbFormasPago.TabIndex = 18;
            this.cbFormasPago.SelectedIndexChanged += new System.EventHandler(this.cbFormasPago_SelectedIndexChanged);
            // 
            // cbPOS
            // 
            this.cbPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPOS.FormattingEnabled = true;
            this.cbPOS.Location = new System.Drawing.Point(120, 38);
            this.cbPOS.Name = "cbPOS";
            this.cbPOS.Size = new System.Drawing.Size(332, 21);
            this.cbPOS.TabIndex = 19;
            this.cbPOS.SelectedIndexChanged += new System.EventHandler(this.cbPOS_SelectedIndexChanged);
            // 
            // frmEdCierreCajeroAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 217);
            this.Controls.Add(this.cbPOS);
            this.Controls.Add(this.cbFormasPago);
            this.Controls.Add(this.lbPOS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txObs);
            this.Controls.Add(this.txLote);
            this.Controls.Add(this.txMonto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEdCierreCajeroAgregar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar Forma de Pago";
            this.Activated += new System.EventHandler(this.frmEdCierreCajero_Activated);
            this.Load += new System.EventHandler(this.frmEdCierreCajero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txMonto;
    private System.Windows.Forms.TextBox txLote;
    private System.Windows.Forms.TextBox txObs;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lbPOS;
    private System.Windows.Forms.ComboBox cbPOS;
    private System.Windows.Forms.ComboBox cbFormasPago;
  }
}