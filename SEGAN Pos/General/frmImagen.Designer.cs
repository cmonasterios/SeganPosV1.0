namespace SEGAN_POS
{
  partial class frmImagen
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagen));
      this.panel1 = new System.Windows.Forms.Panel();
      this.pnEdit = new System.Windows.Forms.Panel();
      this.btAbrir = new System.Windows.Forms.Button();
      this.btEliminar = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btOK = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.panel4 = new System.Windows.Forms.Panel();
      this.pbImagen = new System.Windows.Forms.PictureBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.panel1.SuspendLayout();
      this.pnEdit.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.pnEdit);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 393);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(653, 43);
      this.panel1.TabIndex = 64;
      // 
      // pnEdit
      // 
      this.pnEdit.Controls.Add(this.btAbrir);
      this.pnEdit.Controls.Add(this.btEliminar);
      this.pnEdit.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnEdit.Location = new System.Drawing.Point(0, 0);
      this.pnEdit.Name = "pnEdit";
      this.pnEdit.Size = new System.Drawing.Size(207, 43);
      this.pnEdit.TabIndex = 75;
      // 
      // btAbrir
      // 
      this.btAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btAbrir.Image")));
      this.btAbrir.Location = new System.Drawing.Point(6, 3);
      this.btAbrir.Name = "btAbrir";
      this.btAbrir.Size = new System.Drawing.Size(104, 33);
      this.btAbrir.TabIndex = 73;
      this.btAbrir.Text = "Seleccionar";
      this.btAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btAbrir.UseVisualStyleBackColor = true;
      this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
      // 
      // btEliminar
      // 
      this.btEliminar.Image = global::SEGAN_POS.Properties.Resources.borrar;
      this.btEliminar.Location = new System.Drawing.Point(116, 3);
      this.btEliminar.Name = "btEliminar";
      this.btEliminar.Size = new System.Drawing.Size(82, 33);
      this.btEliminar.TabIndex = 74;
      this.btEliminar.Text = "Eliminar";
      this.btEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btEliminar.UseVisualStyleBackColor = true;
      this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btOK);
      this.panel2.Controls.Add(this.btCancel);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel2.Location = new System.Drawing.Point(473, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(180, 43);
      this.panel2.TabIndex = 0;
      // 
      // btOK
      // 
      this.btOK.CausesValidation = false;
      this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btOK.Location = new System.Drawing.Point(3, 3);
      this.btOK.Name = "btOK";
      this.btOK.Size = new System.Drawing.Size(82, 33);
      this.btOK.TabIndex = 6;
      this.btOK.Text = "Aceptar";
      this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btOK.UseVisualStyleBackColor = true;
      this.btOK.Click += new System.EventHandler(this.btOK_Click);
      // 
      // btCancel
      // 
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(91, 3);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(82, 33);
      this.btCancel.TabIndex = 7;
      this.btCancel.Text = "Cancelar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.pbImagen);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel4.Location = new System.Drawing.Point(0, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(653, 393);
      this.panel4.TabIndex = 67;
      // 
      // pbImagen
      // 
      this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pbImagen.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pbImagen.Location = new System.Drawing.Point(0, 0);
      this.pbImagen.Name = "pbImagen";
      this.pbImagen.Size = new System.Drawing.Size(653, 393);
      this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbImagen.TabIndex = 0;
      this.pbImagen.TabStop = false;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "jpg";
      this.openFileDialog1.Filter = "Imagenes|*.jpg;*.jpeg;*.png";
      this.openFileDialog1.Title = "Seleccionar depósito";
      this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
      // 
      // frmImagen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(653, 436);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel1);
      this.Name = "frmImagen";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmImagen";
      this.Activated += new System.EventHandler(this.frmImagen_Activated);
      this.Load += new System.EventHandler(this.frmImagen_Load);
      this.panel1.ResumeLayout(false);
      this.pnEdit.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btAbrir;
    private System.Windows.Forms.Button btEliminar;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.PictureBox pbImagen;
    private System.Windows.Forms.Panel pnEdit;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
  }
}