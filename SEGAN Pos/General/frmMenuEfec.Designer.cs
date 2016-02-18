namespace SEGAN_POS
{
    partial class frmMenuEfec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuEfec));
            this.btCancel = new System.Windows.Forms.Button();
            this.btConsultarCierreVentas = new System.Windows.Forms.Button();
            this.btCierreVentas = new System.Windows.Forms.Button();
            this.btConsultaDepositos = new System.Windows.Forms.Button();
            this.btDepositoBanco = new System.Windows.Forms.Button();
            this.btAprobarAlivio = new System.Windows.Forms.Button();
            this.btConsultarAlivio = new System.Windows.Forms.Button();
            this.btGenerarAlivio = new System.Windows.Forms.Button();
            this.btCierreCajero = new System.Windows.Forms.Button();
            this.btAperturaCajero = new System.Windows.Forms.Button();
            this.btCambioEfectivo = new System.Windows.Forms.Button();
            this.btIngresoEfectivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(441, 280);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(69, 33);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cerrar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btConsultarCierreVentas
            // 
            this.btConsultarCierreVentas.Enabled = false;
            this.btConsultarCierreVentas.Image = global::SEGAN_POS.Properties.Resources.consultarcierredeventas;
            this.btConsultarCierreVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultarCierreVentas.Location = new System.Drawing.Point(25, 224);
            this.btConsultarCierreVentas.Name = "btConsultarCierreVentas";
            this.btConsultarCierreVentas.Size = new System.Drawing.Size(105, 77);
            this.btConsultarCierreVentas.TabIndex = 8;
            this.btConsultarCierreVentas.Tag = "frmConsultarCierreVentas";
            this.btConsultarCierreVentas.Text = "Consulta de Cierre de Ventas";
            this.btConsultarCierreVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultarCierreVentas.UseVisualStyleBackColor = true;
            this.btConsultarCierreVentas.Click += new System.EventHandler(this.btConsultarCierreVentas_Click);
            // 
            // btCierreVentas
            // 
            this.btCierreVentas.Enabled = false;
            this.btCierreVentas.Image = ((System.Drawing.Image)(resources.GetObject("btCierreVentas.Image")));
            this.btCierreVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCierreVentas.Location = new System.Drawing.Point(391, 125);
            this.btCierreVentas.Name = "btCierreVentas";
            this.btCierreVentas.Size = new System.Drawing.Size(105, 77);
            this.btCierreVentas.TabIndex = 7;
            this.btCierreVentas.Tag = "frmCierreVentas";
            this.btCierreVentas.Text = "Cierre de Ventas";
            this.btCierreVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCierreVentas.UseVisualStyleBackColor = true;
            this.btCierreVentas.Click += new System.EventHandler(this.btCierreVentas_Click);
            // 
            // btConsultaDepositos
            // 
            this.btConsultaDepositos.Enabled = false;
            this.btConsultaDepositos.Image = ((System.Drawing.Image)(resources.GetObject("btConsultaDepositos.Image")));
            this.btConsultaDepositos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultaDepositos.Location = new System.Drawing.Point(269, 125);
            this.btConsultaDepositos.Name = "btConsultaDepositos";
            this.btConsultaDepositos.Size = new System.Drawing.Size(105, 77);
            this.btConsultaDepositos.TabIndex = 6;
            this.btConsultaDepositos.Tag = "frmConsultarDepositos";
            this.btConsultaDepositos.Text = "Consulta de Depósitos";
            this.btConsultaDepositos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultaDepositos.UseVisualStyleBackColor = true;
            this.btConsultaDepositos.Click += new System.EventHandler(this.btConsultaDepositos_Click);
            // 
            // btDepositoBanco
            // 
            this.btDepositoBanco.Enabled = false;
            this.btDepositoBanco.Image = ((System.Drawing.Image)(resources.GetObject("btDepositoBanco.Image")));
            this.btDepositoBanco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDepositoBanco.Location = new System.Drawing.Point(147, 125);
            this.btDepositoBanco.Name = "btDepositoBanco";
            this.btDepositoBanco.Size = new System.Drawing.Size(105, 77);
            this.btDepositoBanco.TabIndex = 5;
            this.btDepositoBanco.Tag = "frmDepositos";
            this.btDepositoBanco.Text = "Gestionar Depósitos";
            this.btDepositoBanco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDepositoBanco.UseVisualStyleBackColor = true;
            this.btDepositoBanco.Click += new System.EventHandler(this.btDepositoBanco_Click);
            // 
            // btAprobarAlivio
            // 
            this.btAprobarAlivio.Enabled = false;
            this.btAprobarAlivio.Image = ((System.Drawing.Image)(resources.GetObject("btAprobarAlivio.Image")));
            this.btAprobarAlivio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAprobarAlivio.Location = new System.Drawing.Point(391, 26);
            this.btAprobarAlivio.Name = "btAprobarAlivio";
            this.btAprobarAlivio.Size = new System.Drawing.Size(105, 77);
            this.btAprobarAlivio.TabIndex = 3;
            this.btAprobarAlivio.Tag = "frmAprobarAlivio";
            this.btAprobarAlivio.Text = "Aprobar Alivio";
            this.btAprobarAlivio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAprobarAlivio.UseVisualStyleBackColor = true;
            this.btAprobarAlivio.Click += new System.EventHandler(this.btAprobarAlivio_Click);
            // 
            // btConsultarAlivio
            // 
            this.btConsultarAlivio.Enabled = false;
            this.btConsultarAlivio.Image = ((System.Drawing.Image)(resources.GetObject("btConsultarAlivio.Image")));
            this.btConsultarAlivio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btConsultarAlivio.Location = new System.Drawing.Point(25, 125);
            this.btConsultarAlivio.Name = "btConsultarAlivio";
            this.btConsultarAlivio.Size = new System.Drawing.Size(105, 77);
            this.btConsultarAlivio.TabIndex = 4;
            this.btConsultarAlivio.Tag = "frmConsultarAlivio";
            this.btConsultarAlivio.Text = "Consultar Alivio";
            this.btConsultarAlivio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConsultarAlivio.UseVisualStyleBackColor = true;
            this.btConsultarAlivio.Click += new System.EventHandler(this.btConsultarAlivio_Click);
            // 
            // btGenerarAlivio
            // 
            this.btGenerarAlivio.Image = ((System.Drawing.Image)(resources.GetObject("btGenerarAlivio.Image")));
            this.btGenerarAlivio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGenerarAlivio.Location = new System.Drawing.Point(269, 26);
            this.btGenerarAlivio.Name = "btGenerarAlivio";
            this.btGenerarAlivio.Size = new System.Drawing.Size(105, 77);
            this.btGenerarAlivio.TabIndex = 2;
            this.btGenerarAlivio.Tag = "frmAliviarEfectivo";
            this.btGenerarAlivio.Text = "Generar Alivio";
            this.btGenerarAlivio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGenerarAlivio.UseVisualStyleBackColor = true;
            this.btGenerarAlivio.Click += new System.EventHandler(this.btGenerarAlivio_Click);
            // 
            // btCierreCajero
            // 
            this.btCierreCajero.Enabled = false;
            this.btCierreCajero.Image = ((System.Drawing.Image)(resources.GetObject("btCierreCajero.Image")));
            this.btCierreCajero.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCierreCajero.Location = new System.Drawing.Point(147, 26);
            this.btCierreCajero.Name = "btCierreCajero";
            this.btCierreCajero.Size = new System.Drawing.Size(105, 77);
            this.btCierreCajero.TabIndex = 1;
            this.btCierreCajero.Tag = "frmCierreCajero";
            this.btCierreCajero.Text = "Cierre de Cajero";
            this.btCierreCajero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCierreCajero.UseVisualStyleBackColor = true;
            this.btCierreCajero.Click += new System.EventHandler(this.btCierreCajero_Click);
            // 
            // btAperturaCajero
            // 
            this.btAperturaCajero.Enabled = false;
            this.btAperturaCajero.Image = ((System.Drawing.Image)(resources.GetObject("btAperturaCajero.Image")));
            this.btAperturaCajero.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAperturaCajero.Location = new System.Drawing.Point(25, 26);
            this.btAperturaCajero.Name = "btAperturaCajero";
            this.btAperturaCajero.Size = new System.Drawing.Size(105, 77);
            this.btAperturaCajero.TabIndex = 0;
            this.btAperturaCajero.Tag = "frmAperturaCajero";
            this.btAperturaCajero.Text = "Apertura de Cajero";
            this.btAperturaCajero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAperturaCajero.UseVisualStyleBackColor = true;
            this.btAperturaCajero.Click += new System.EventHandler(this.btAperturaCajero_Click);
            // 
            // btCambioEfectivo
            // 
            this.btCambioEfectivo.Enabled = false;
            this.btCambioEfectivo.Image = global::SEGAN_POS.Properties.Resources.cambioefectivo;
            this.btCambioEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCambioEfectivo.Location = new System.Drawing.Point(147, 224);
            this.btCambioEfectivo.Name = "btCambioEfectivo";
            this.btCambioEfectivo.Size = new System.Drawing.Size(105, 77);
            this.btCambioEfectivo.TabIndex = 9;
            this.btCambioEfectivo.Tag = "frmCambioEfectivo";
            this.btCambioEfectivo.Text = "Cambio de Efectivo";
            this.btCambioEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCambioEfectivo.UseVisualStyleBackColor = true;
            this.btCambioEfectivo.Click += new System.EventHandler(this.btCambioEfectivo_Click);
            // 
            // btIngresoEfectivo
            // 
            this.btIngresoEfectivo.Enabled = false;
            this.btIngresoEfectivo.Image = global::SEGAN_POS.Properties.Resources.ingresoefectivo;
            this.btIngresoEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btIngresoEfectivo.Location = new System.Drawing.Point(269, 224);
            this.btIngresoEfectivo.Name = "btIngresoEfectivo";
            this.btIngresoEfectivo.Size = new System.Drawing.Size(105, 77);
            this.btIngresoEfectivo.TabIndex = 10;
            this.btIngresoEfectivo.Tag = "frmIngresoEfectivo";
            this.btIngresoEfectivo.Text = "Ingreso de Efectivo";
            this.btIngresoEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btIngresoEfectivo.UseVisualStyleBackColor = true;
            this.btIngresoEfectivo.Click += new System.EventHandler(this.btIngresoEfectivo_Click);
            // 
            // frmMenuEfec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(522, 325);
            this.Controls.Add(this.btIngresoEfectivo);
            this.Controls.Add(this.btCambioEfectivo);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btConsultarCierreVentas);
            this.Controls.Add(this.btCierreVentas);
            this.Controls.Add(this.btConsultaDepositos);
            this.Controls.Add(this.btDepositoBanco);
            this.Controls.Add(this.btAperturaCajero);
            this.Controls.Add(this.btCierreCajero);
            this.Controls.Add(this.btAprobarAlivio);
            this.Controls.Add(this.btGenerarAlivio);
            this.Controls.Add(this.btConsultarAlivio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenuEfec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manejo de Efectivo";
            this.Activated += new System.EventHandler(this.frmMenuEfec_Activated);
            this.Load += new System.EventHandler(this.frmMenuEfec_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAperturaCajero;
        private System.Windows.Forms.Button btCierreVentas;
        private System.Windows.Forms.Button btConsultaDepositos;
        private System.Windows.Forms.Button btDepositoBanco;
        private System.Windows.Forms.Button btAprobarAlivio;
        private System.Windows.Forms.Button btConsultarAlivio;
        private System.Windows.Forms.Button btGenerarAlivio;
        private System.Windows.Forms.Button btCierreCajero;
        private System.Windows.Forms.Button btConsultarCierreVentas;
        private System.Windows.Forms.Button btCambioEfectivo;
        private System.Windows.Forms.Button btIngresoEfectivo;
    }
}