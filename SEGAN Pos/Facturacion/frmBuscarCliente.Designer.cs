namespace SEGAN_POS
{
  partial class frmBuscarCliente
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
            this.txDocNum = new System.Windows.Forms.TextBox();
            this.cbTipoDoc = new System.Windows.Forms.ComboBox();
            this.lbDoc = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txNombre = new System.Windows.Forms.TextBox();
            this.txApellido = new System.Windows.Forms.TextBox();
            this.txDireccion = new System.Windows.Forms.TextBox();
            this.lbDirecc = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txEmail = new System.Windows.Forms.TextBox();
            this.lbTelef = new System.Windows.Forms.Label();
            this.txTelef = new System.Windows.Forms.TextBox();
            this.lbEstatus = new System.Windows.Forms.Label();
            this.txEstatus = new System.Windows.Forms.TextBox();
            this.btContinuar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txRazonSoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txDocNum
            // 
            this.errorProvider1.SetIconPadding(this.txDocNum, 38);
            this.txDocNum.Location = new System.Drawing.Point(262, 26);
            this.txDocNum.MaxLength = 30;
            this.txDocNum.Name = "txDocNum";
            this.txDocNum.Size = new System.Drawing.Size(242, 20);
            this.txDocNum.TabIndex = 1;
            this.txDocNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txDocNum_KeyPress);
            this.txDocNum.Leave += new System.EventHandler(this.txDocNum_Leave);
            // 
            // cbTipoDoc
            // 
            this.cbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDoc.FormattingEnabled = true;
            this.cbTipoDoc.Location = new System.Drawing.Point(124, 26);
            this.cbTipoDoc.Name = "cbTipoDoc";
            this.cbTipoDoc.Size = new System.Drawing.Size(132, 21);
            this.cbTipoDoc.TabIndex = 0;
            this.cbTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cbTipoDoc_SelectedIndexChanged);
            this.cbTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipoDoc_KeyPress);
            // 
            // lbDoc
            // 
            this.lbDoc.AutoSize = true;
            this.lbDoc.Location = new System.Drawing.Point(56, 29);
            this.lbDoc.Name = "lbDoc";
            this.lbDoc.Size = new System.Drawing.Size(62, 13);
            this.lbDoc.TabIndex = 3;
            this.lbDoc.Text = "Documento";
            this.lbDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btBuscar
            // 
            this.btBuscar.AutoSize = true;
            this.btBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(510, 20);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(30, 30);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lbNombre
            // 
            this.lbNombre.Location = new System.Drawing.Point(12, 66);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(106, 13);
            this.lbNombre.TabIndex = 4;
            this.lbNombre.Text = "Nombre y Apellidos";
            this.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txNombre
            // 
            this.txNombre.Location = new System.Drawing.Point(124, 63);
            this.txNombre.MaxLength = 50;
            this.txNombre.Name = "txNombre";
            this.txNombre.Size = new System.Drawing.Size(188, 20);
            this.txNombre.TabIndex = 3;
            this.txNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txNombre_KeyPress);
            // 
            // txApellido
            // 
            this.txApellido.Location = new System.Drawing.Point(332, 63);
            this.txApellido.MaxLength = 50;
            this.txApellido.Name = "txApellido";
            this.txApellido.Size = new System.Drawing.Size(208, 20);
            this.txApellido.TabIndex = 4;
            this.txApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txApellido_KeyPress);
            // 
            // txDireccion
            // 
            this.txDireccion.Location = new System.Drawing.Point(124, 101);
            this.txDireccion.MaxLength = 500;
            this.txDireccion.Name = "txDireccion";
            this.txDireccion.Size = new System.Drawing.Size(416, 20);
            this.txDireccion.TabIndex = 5;
            this.txDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txDireccion_KeyPress);
            // 
            // lbDirecc
            // 
            this.lbDirecc.AutoSize = true;
            this.lbDirecc.Location = new System.Drawing.Point(66, 104);
            this.lbDirecc.Name = "lbDirecc";
            this.lbDirecc.Size = new System.Drawing.Size(52, 13);
            this.lbDirecc.TabIndex = 9;
            this.lbDirecc.Text = "Dirección";
            this.lbDirecc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(86, 178);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 11;
            this.lbEmail.Text = "Email";
            this.lbEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txEmail
            // 
            this.txEmail.Location = new System.Drawing.Point(124, 175);
            this.txEmail.MaxLength = 100;
            this.txEmail.Name = "txEmail";
            this.txEmail.Size = new System.Drawing.Size(298, 20);
            this.txEmail.TabIndex = 7;
            this.txEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txEmail_KeyPress);
            // 
            // lbTelef
            // 
            this.lbTelef.AutoSize = true;
            this.lbTelef.Location = new System.Drawing.Point(69, 141);
            this.lbTelef.Name = "lbTelef";
            this.lbTelef.Size = new System.Drawing.Size(49, 13);
            this.lbTelef.TabIndex = 13;
            this.lbTelef.Text = "Teléfono";
            this.lbTelef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txTelef
            // 
            this.txTelef.Location = new System.Drawing.Point(124, 138);
            this.txTelef.MaxLength = 20;
            this.txTelef.Name = "txTelef";
            this.txTelef.Size = new System.Drawing.Size(132, 20);
            this.txTelef.TabIndex = 6;
            this.txTelef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txTelef_KeyPress);
            // 
            // lbEstatus
            // 
            this.lbEstatus.AutoSize = true;
            this.lbEstatus.Location = new System.Drawing.Point(76, 215);
            this.lbEstatus.Name = "lbEstatus";
            this.lbEstatus.Size = new System.Drawing.Size(42, 13);
            this.lbEstatus.TabIndex = 15;
            this.lbEstatus.Text = "Estatus";
            this.lbEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txEstatus
            // 
            this.txEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txEstatus.Location = new System.Drawing.Point(124, 212);
            this.txEstatus.MaxLength = 20;
            this.txEstatus.Name = "txEstatus";
            this.txEstatus.ReadOnly = true;
            this.txEstatus.Size = new System.Drawing.Size(132, 20);
            this.txEstatus.TabIndex = 14;
            this.txEstatus.TabStop = false;
            // 
            // btContinuar
            // 
            this.btContinuar.AutoSize = true;
            this.btContinuar.Image = global::SEGAN_POS.Properties.Resources.continuar;
            this.btContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btContinuar.Location = new System.Drawing.Point(364, 247);
            this.btContinuar.Name = "btContinuar";
            this.btContinuar.Size = new System.Drawing.Size(86, 32);
            this.btContinuar.TabIndex = 8;
            this.btContinuar.Text = "Continuar";
            this.btContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btContinuar.UseVisualStyleBackColor = true;
            this.btContinuar.Click += new System.EventHandler(this.btContinuar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.AutoSize = true;
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(455, 247);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(85, 32);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txRazonSoc
            // 
            this.txRazonSoc.Location = new System.Drawing.Point(124, 63);
            this.txRazonSoc.MaxLength = 100;
            this.txRazonSoc.Name = "txRazonSoc";
            this.txRazonSoc.Size = new System.Drawing.Size(416, 20);
            this.txRazonSoc.TabIndex = 3;
            this.txRazonSoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txRazonSoc_KeyPress);
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(565, 299);
            this.Controls.Add(this.txNombre);
            this.Controls.Add(this.txApellido);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btContinuar);
            this.Controls.Add(this.lbEstatus);
            this.Controls.Add(this.txEstatus);
            this.Controls.Add(this.lbTelef);
            this.Controls.Add(this.txTelef);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txEmail);
            this.Controls.Add(this.lbDirecc);
            this.Controls.Add(this.txDireccion);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.lbDoc);
            this.Controls.Add(this.cbTipoDoc);
            this.Controls.Add(this.txDocNum);
            this.Controls.Add(this.txRazonSoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCliente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Cliente";
            this.Activated += new System.EventHandler(this.frmBuscarCliente_Activated);
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.Shown += new System.EventHandler(this.frmBuscarCliente_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txDocNum;
    private System.Windows.Forms.ComboBox cbTipoDoc;
    private System.Windows.Forms.Label lbDoc;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Label lbNombre;
    private System.Windows.Forms.TextBox txNombre;
    private System.Windows.Forms.TextBox txApellido;
    private System.Windows.Forms.TextBox txDireccion;
    private System.Windows.Forms.Label lbDirecc;
    private System.Windows.Forms.Label lbEmail;
    private System.Windows.Forms.TextBox txEmail;
    private System.Windows.Forms.Label lbTelef;
    private System.Windows.Forms.TextBox txTelef;
    private System.Windows.Forms.Label lbEstatus;
    private System.Windows.Forms.TextBox txEstatus;
    private System.Windows.Forms.Button btContinuar;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.TextBox txRazonSoc;
  }
}