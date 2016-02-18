namespace SEGAN_POS
{
  partial class frmInfoNC
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
      this.btOK = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.txNroFactura = new System.Windows.Forms.TextBox();
      this.lbFactDesd = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.txFechaFactura = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txNombre = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txMontoTotal = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txNroSolNC = new System.Windows.Forms.TextBox();
      this.txDoc = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btOK
      // 
      this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOK.AutoSize = true;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.reimprimir;
      this.btOK.Location = new System.Drawing.Point(323, 273);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 13;
      this.btOK.Text = "Imprimir";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.Location = new System.Drawing.Point(411, 273);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(83, 32);
      this.btCancelar.TabIndex = 12;
      this.btCancelar.TabStop = false;
      this.btCancelar.Text = "Cancelar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // txNroFactura
      // 
      this.txNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txNroFactura.Location = new System.Drawing.Point(118, 59);
      this.txNroFactura.Name = "txNroFactura";
      this.txNroFactura.ReadOnly = true;
      this.txNroFactura.Size = new System.Drawing.Size(121, 20);
      this.txNroFactura.TabIndex = 15;
      this.txNroFactura.TabStop = false;
      // 
      // lbFactDesd
      // 
      this.lbFactDesd.AutoSize = true;
      this.lbFactDesd.Location = new System.Drawing.Point(54, 61);
      this.lbFactDesd.Name = "lbFactDesd";
      this.lbFactDesd.Size = new System.Drawing.Size(58, 13);
      this.lbFactDesd.TabIndex = 68;
      this.lbFactDesd.Text = "N° Factura";
      this.lbFactDesd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(75, 98);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 70;
      this.label1.Text = "Fecha";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txFechaFactura
      // 
      this.txFechaFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txFechaFactura.Location = new System.Drawing.Point(118, 96);
      this.txFechaFactura.Name = "txFechaFactura";
      this.txFechaFactura.ReadOnly = true;
      this.txFechaFactura.Size = new System.Drawing.Size(164, 20);
      this.txFechaFactura.TabIndex = 69;
      this.txFechaFactura.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(33, 172);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(79, 13);
      this.label2.TabIndex = 72;
      this.label2.Text = "Nombre Cliente";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txNombre
      // 
      this.txNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txNombre.Location = new System.Drawing.Point(118, 170);
      this.txNombre.Name = "txNombre";
      this.txNombre.ReadOnly = true;
      this.txNombre.Size = new System.Drawing.Size(344, 20);
      this.txNombre.TabIndex = 71;
      this.txNombre.TabStop = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(47, 209);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 13);
      this.label3.TabIndex = 74;
      this.label3.Text = "Monto Total";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txMontoTotal
      // 
      this.txMontoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txMontoTotal.Location = new System.Drawing.Point(118, 207);
      this.txMontoTotal.Name = "txMontoTotal";
      this.txMontoTotal.ReadOnly = true;
      this.txMontoTotal.Size = new System.Drawing.Size(121, 20);
      this.txMontoTotal.TabIndex = 73;
      this.txMontoTotal.TabStop = false;
      this.txMontoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(32, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(80, 13);
      this.label4.TabIndex = 76;
      this.label4.Text = "N° Solicitud NC";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txNroSolNC
      // 
      this.txNroSolNC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txNroSolNC.Location = new System.Drawing.Point(118, 22);
      this.txNroSolNC.Name = "txNroSolNC";
      this.txNroSolNC.ReadOnly = true;
      this.txNroSolNC.Size = new System.Drawing.Size(121, 20);
      this.txNroSolNC.TabIndex = 75;
      this.txNroSolNC.TabStop = false;
      // 
      // txDoc
      // 
      this.txDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txDoc.Location = new System.Drawing.Point(118, 133);
      this.txDoc.Name = "txDoc";
      this.txDoc.ReadOnly = true;
      this.txDoc.Size = new System.Drawing.Size(121, 20);
      this.txDoc.TabIndex = 77;
      this.txDoc.TabStop = false;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(47, 135);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(65, 13);
      this.label5.TabIndex = 78;
      this.label5.Text = "Doc. Cliente";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // frmInfoNC
      // 
      this.AcceptButton = this.btOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancelar;
      this.ClientSize = new System.Drawing.Size(506, 317);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.txDoc);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txNroSolNC);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txMontoTotal);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txNombre);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txFechaFactura);
      this.Controls.Add(this.lbFactDesd);
      this.Controls.Add(this.txNroFactura);
      this.Controls.Add(this.btOK);
      this.Controls.Add(this.btCancelar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmInfoNC";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Impresión de Nota de Crédito";
      this.Activated += new System.EventHandler(this.frmInfoNC_Activated);
      this.Load += new System.EventHandler(this.frmInfoNC_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.TextBox txNroFactura;
    private System.Windows.Forms.Label lbFactDesd;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txFechaFactura;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txNombre;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txMontoTotal;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txNroSolNC;
    private System.Windows.Forms.TextBox txDoc;
    private System.Windows.Forms.Label label5;
  }
}