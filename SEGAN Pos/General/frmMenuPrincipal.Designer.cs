namespace SEGAN_POS
{
    partial class frmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            this.btBloquear = new System.Windows.Forms.Button();
            this.pnBotones = new System.Windows.Forms.Panel();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnManejoEfectivo = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnConsultaFactura = new System.Windows.Forms.Button();
            this.ulVersion = new iGreen.Controls.uControls.uLabelX.uLabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBloquear
            // 
            this.btBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBloquear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btBloquear.FlatAppearance.BorderSize = 0;
            this.btBloquear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btBloquear.Image = global::SEGAN_POS.Properties.Resources.bloquear;
            this.btBloquear.Location = new System.Drawing.Point(983, 30);
            this.btBloquear.Name = "btBloquear";
            this.btBloquear.Size = new System.Drawing.Size(54, 54);
            this.btBloquear.TabIndex = 4;
            this.btBloquear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBloquear.UseVisualStyleBackColor = false;
            this.btBloquear.Click += new System.EventHandler(this.btBloquear_Click);
            // 
            // pnBotones
            // 
            this.pnBotones.BackColor = System.Drawing.Color.Transparent;
            this.pnBotones.Controls.Add(this.btnFacturacion);
            this.pnBotones.Controls.Add(this.btnManejoEfectivo);
            this.pnBotones.Controls.Add(this.btnReportes);
            this.pnBotones.Controls.Add(this.btnConsultaFactura);
            this.pnBotones.Location = new System.Drawing.Point(88, 188);
            this.pnBotones.Name = "pnBotones";
            this.pnBotones.Size = new System.Drawing.Size(801, 177);
            this.pnBotones.TabIndex = 16;
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFacturacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.BackgroundImage")));
            this.btnFacturacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFacturacion.Location = new System.Drawing.Point(-1, 0);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Size = new System.Drawing.Size(177, 177);
            this.btnFacturacion.TabIndex = 0;
            this.btnFacturacion.UseVisualStyleBackColor = false;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnManejoEfectivo
            // 
            this.btnManejoEfectivo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManejoEfectivo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnManejoEfectivo.BackgroundImage")));
            this.btnManejoEfectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnManejoEfectivo.FlatAppearance.BorderSize = 0;
            this.btnManejoEfectivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManejoEfectivo.Location = new System.Drawing.Point(206, 0);
            this.btnManejoEfectivo.Name = "btnManejoEfectivo";
            this.btnManejoEfectivo.Size = new System.Drawing.Size(177, 177);
            this.btnManejoEfectivo.TabIndex = 1;
            this.btnManejoEfectivo.UseVisualStyleBackColor = false;
            this.btnManejoEfectivo.Click += new System.EventHandler(this.btnManejoEfectivo_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReportes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReportes.BackgroundImage")));
            this.btnReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReportes.Location = new System.Drawing.Point(416, 0);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(177, 177);
            this.btnReportes.TabIndex = 2;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnConsultaFactura
            // 
            this.btnConsultaFactura.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConsultaFactura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultaFactura.BackgroundImage")));
            this.btnConsultaFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultaFactura.FlatAppearance.BorderSize = 0;
            this.btnConsultaFactura.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConsultaFactura.Location = new System.Drawing.Point(624, 0);
            this.btnConsultaFactura.Name = "btnConsultaFactura";
            this.btnConsultaFactura.Size = new System.Drawing.Size(177, 177);
            this.btnConsultaFactura.TabIndex = 3;
            this.btnConsultaFactura.UseVisualStyleBackColor = false;
            this.btnConsultaFactura.Click += new System.EventHandler(this.btnConsultaFactura_Click);
            // 
            // ulVersion
            // 
            this.ulVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ulVersion.BorderColor = System.Drawing.Color.Black;
            this.ulVersion.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.ulVersion.BorderStyle = iGreen.Controls.uControls.uLabelX.Common.BorderStyles.None;
            this.ulVersion.BorderWidth = 1F;
            this.ulVersion.ForeColor = System.Drawing.Color.DimGray;
            this.ulVersion.Image = null;
            this.ulVersion.Location = new System.Drawing.Point(18, 446);
            this.ulVersion.Name = "ulVersion";
            this.ulVersion.Size = new System.Drawing.Size(211, 16);
            this.ulVersion.Text = "ulVersion";
            this.ulVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::SEGAN_POS.Properties.Resources.maincopy2;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(82, 442);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(955, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "EPK Grupo los Principitos, C.A. © 2013. Todos los Derechos Reservados.  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.mainname;
            this.pictureBox1.Location = new System.Drawing.Point(45, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btBloquear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 118);
            this.panel1.TabIndex = 23;
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SEGAN_POS.Properties.Resources.mainbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1056, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnBotones);
            this.Controls.Add(this.ulVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmMenuPrincipal";
            this.Text = "frmMenuPrincipal";
            this.Activated += new System.EventHandler(this.frmMenuPrincipal_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            this.Shown += new System.EventHandler(this.frmMenuPrincipal_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMenuPrincipal_KeyDown);
            this.pnBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBloquear;
        private iGreen.Controls.uControls.uLabelX.uLabelX ulVersion;
        private System.Windows.Forms.Panel pnBotones;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnManejoEfectivo;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConsultaFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}