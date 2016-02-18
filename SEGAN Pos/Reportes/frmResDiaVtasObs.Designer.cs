namespace SEGAN_POS.Reportes
{
    partial class frmResDiaVtasObs
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
            if (disposing && (components != null))
            {
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
      this.txtObservaciones = new System.Windows.Forms.TextBox();
      this.btAceptar = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.Observaciones = new System.Windows.Forms.GroupBox();
      this.Observaciones.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtObservaciones
      // 
      this.txtObservaciones.Location = new System.Drawing.Point(19, 23);
      this.txtObservaciones.Multiline = true;
      this.txtObservaciones.Name = "txtObservaciones";
      this.txtObservaciones.Size = new System.Drawing.Size(232, 131);
      this.txtObservaciones.TabIndex = 0;
      // 
      // btAceptar
      // 
      this.btAceptar.Image = global::SEGAN_POS.Properties.Resources.aceptar;
      this.btAceptar.Location = new System.Drawing.Point(39, 171);
      this.btAceptar.Name = "btAceptar";
      this.btAceptar.Size = new System.Drawing.Size(75, 33);
      this.btAceptar.TabIndex = 1;
      this.btAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btAceptar.UseVisualStyleBackColor = true;
      this.btAceptar.Click += new System.EventHandler(this.button1_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.Location = new System.Drawing.Point(157, 171);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(75, 33);
      this.btCancelar.TabIndex = 2;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // Observaciones
      // 
      this.Observaciones.Controls.Add(this.txtObservaciones);
      this.Observaciones.Controls.Add(this.btAceptar);
      this.Observaciones.Controls.Add(this.btCancelar);
      this.Observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Observaciones.Location = new System.Drawing.Point(8, 6);
      this.Observaciones.Name = "Observaciones";
      this.Observaciones.Size = new System.Drawing.Size(271, 217);
      this.Observaciones.TabIndex = 3;
      this.Observaciones.TabStop = false;
      this.Observaciones.Text = "Observaciones";
      // 
      // frmResDiaVtasObs
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 230);
      this.Controls.Add(this.Observaciones);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmResDiaVtasObs";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Observaciones.ResumeLayout(false);
      this.Observaciones.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.GroupBox Observaciones;
    }
}