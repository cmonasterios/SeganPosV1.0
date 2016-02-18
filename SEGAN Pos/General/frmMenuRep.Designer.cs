namespace SEGAN_POS
{
    partial class frmMenuRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuRep));
            this.btCancel = new System.Windows.Forms.Button();
            this.btDevoluciones = new System.Windows.Forms.Button();
            this.btFormasPago = new System.Windows.Forms.Button();
            this.btVentasDiarias = new System.Windows.Forms.Button();
            this.btDenominaciones = new System.Windows.Forms.Button();
            this.btHorasPico = new System.Windows.Forms.Button();
            this.btnPagosConsolidados = new System.Windows.Forms.Button();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.btnPedidoSugerido = new System.Windows.Forms.Button();
            this.btRepoArt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btRefSinMovimiento = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(437, 352);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(71, 33);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Cerrar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btDevoluciones
            // 
            this.btDevoluciones.Enabled = false;
            this.btDevoluciones.Image = ((System.Drawing.Image)(resources.GetObject("btDevoluciones.Image")));
            this.btDevoluciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDevoluciones.Location = new System.Drawing.Point(375, 19);
            this.btDevoluciones.Name = "btDevoluciones";
            this.btDevoluciones.Size = new System.Drawing.Size(105, 77);
            this.btDevoluciones.TabIndex = 3;
            this.btDevoluciones.Tag = "frmDevoluciones";
            this.btDevoluciones.Text = "Devoluciones";
            this.btDevoluciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDevoluciones.UseVisualStyleBackColor = true;
            this.btDevoluciones.Click += new System.EventHandler(this.btDevoluciones_Click);
            // 
            // btFormasPago
            // 
            this.btFormasPago.Enabled = false;
            this.btFormasPago.Image = ((System.Drawing.Image)(resources.GetObject("btFormasPago.Image")));
            this.btFormasPago.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFormasPago.Location = new System.Drawing.Point(135, 19);
            this.btFormasPago.Name = "btFormasPago";
            this.btFormasPago.Size = new System.Drawing.Size(105, 77);
            this.btFormasPago.TabIndex = 1;
            this.btFormasPago.Tag = "frmConciliacionFormaPago";
            this.btFormasPago.Text = "Consolidado por Formas de Pago";
            this.btFormasPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFormasPago.UseVisualStyleBackColor = true;
            this.btFormasPago.Click += new System.EventHandler(this.btFormasPago_Click);
            // 
            // btVentasDiarias
            // 
            this.btVentasDiarias.Enabled = false;
            this.btVentasDiarias.Image = ((System.Drawing.Image)(resources.GetObject("btVentasDiarias.Image")));
            this.btVentasDiarias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btVentasDiarias.Location = new System.Drawing.Point(135, 117);
            this.btVentasDiarias.Name = "btVentasDiarias";
            this.btVentasDiarias.Size = new System.Drawing.Size(105, 77);
            this.btVentasDiarias.TabIndex = 5;
            this.btVentasDiarias.Tag = "frmResumenDiarioVentas";
            this.btVentasDiarias.Text = "Relación de Ventas Diarias";
            this.btVentasDiarias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btVentasDiarias.UseVisualStyleBackColor = true;
            this.btVentasDiarias.Click += new System.EventHandler(this.btVentasDiarias_Click);
            // 
            // btDenominaciones
            // 
            this.btDenominaciones.Enabled = false;
            this.btDenominaciones.Image = ((System.Drawing.Image)(resources.GetObject("btDenominaciones.Image")));
            this.btDenominaciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDenominaciones.Location = new System.Drawing.Point(15, 117);
            this.btDenominaciones.Name = "btDenominaciones";
            this.btDenominaciones.Size = new System.Drawing.Size(105, 77);
            this.btDenominaciones.TabIndex = 4;
            this.btDenominaciones.Tag = "frmRepOperacionesCajero";
            this.btDenominaciones.Text = "Operaciones de Cajeros";
            this.btDenominaciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDenominaciones.UseVisualStyleBackColor = true;
            this.btDenominaciones.Click += new System.EventHandler(this.btDenominaciones_Click);
            // 
            // btHorasPico
            // 
            this.btHorasPico.Enabled = false;
            this.btHorasPico.Image = ((System.Drawing.Image)(resources.GetObject("btHorasPico.Image")));
            this.btHorasPico.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btHorasPico.Location = new System.Drawing.Point(255, 19);
            this.btHorasPico.Name = "btHorasPico";
            this.btHorasPico.Size = new System.Drawing.Size(105, 77);
            this.btHorasPico.TabIndex = 2;
            this.btHorasPico.Tag = "frmComportamiento";
            this.btHorasPico.Text = "Comportamiento de Ventas";
            this.btHorasPico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btHorasPico.UseVisualStyleBackColor = true;
            this.btHorasPico.Click += new System.EventHandler(this.btHorasPico_Click);
            // 
            // btnPagosConsolidados
            // 
            this.btnPagosConsolidados.Enabled = false;
            this.btnPagosConsolidados.Image = ((System.Drawing.Image)(resources.GetObject("btnPagosConsolidados.Image")));
            this.btnPagosConsolidados.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPagosConsolidados.Location = new System.Drawing.Point(15, 19);
            this.btnPagosConsolidados.Name = "btnPagosConsolidados";
            this.btnPagosConsolidados.Size = new System.Drawing.Size(105, 77);
            this.btnPagosConsolidados.TabIndex = 0;
            this.btnPagosConsolidados.Tag = "frmPagosConsolidados";
            this.btnPagosConsolidados.Text = "Pagos Consolidados";
            this.btnPagosConsolidados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPagosConsolidados.UseVisualStyleBackColor = true;
            this.btnPagosConsolidados.Click += new System.EventHandler(this.btnPagosConsolidados_Click);
            // 
            // btnExistencias
            // 
            this.btnExistencias.Enabled = false;
            this.btnExistencias.Image = ((System.Drawing.Image)(resources.GetObject("btnExistencias.Image")));
            this.btnExistencias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExistencias.Location = new System.Drawing.Point(135, 19);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(105, 77);
            this.btnExistencias.TabIndex = 7;
            this.btnExistencias.Tag = "frmArticulos";
            this.btnExistencias.Text = "Consulta de Existencia";
            this.btnExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExistencias.UseVisualStyleBackColor = true;
            this.btnExistencias.Click += new System.EventHandler(this.btnExistencias_Click);
            // 
            // btnPedidoSugerido
            // 
            this.btnPedidoSugerido.Enabled = false;
            this.btnPedidoSugerido.Image = global::SEGAN_POS.Properties.Resources.ventasporarticulo;
            this.btnPedidoSugerido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPedidoSugerido.Location = new System.Drawing.Point(255, 19);
            this.btnPedidoSugerido.Name = "btnPedidoSugerido";
            this.btnPedidoSugerido.Size = new System.Drawing.Size(105, 77);
            this.btnPedidoSugerido.TabIndex = 8;
            this.btnPedidoSugerido.Tag = "frmArtVend";
            this.btnPedidoSugerido.Text = "Ventas por Artículo";
            this.btnPedidoSugerido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPedidoSugerido.UseVisualStyleBackColor = true;
            this.btnPedidoSugerido.Click += new System.EventHandler(this.btnPedidoSugerido_Click);
            // 
            // btRepoArt
            // 
            this.btRepoArt.Enabled = false;
            this.btRepoArt.Image = global::SEGAN_POS.Properties.Resources.reposisionarticulos;
            this.btRepoArt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRepoArt.Location = new System.Drawing.Point(375, 19);
            this.btRepoArt.Name = "btRepoArt";
            this.btRepoArt.Size = new System.Drawing.Size(105, 77);
            this.btRepoArt.TabIndex = 9;
            this.btRepoArt.Tag = "frmRepoArt";
            this.btRepoArt.Text = "Reposición de Artículos";
            this.btRepoArt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRepoArt.UseVisualStyleBackColor = true;
            this.btRepoArt.Click += new System.EventHandler(this.btRepoArt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPagosConsolidados);
            this.groupBox1.Controls.Add(this.btHorasPico);
            this.groupBox1.Controls.Add(this.btDenominaciones);
            this.groupBox1.Controls.Add(this.btVentasDiarias);
            this.groupBox1.Controls.Add(this.btFormasPago);
            this.groupBox1.Controls.Add(this.btDevoluciones);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 211);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btRefSinMovimiento);
            this.groupBox2.Controls.Add(this.btRepoArt);
            this.groupBox2.Controls.Add(this.btnExistencias);
            this.groupBox2.Controls.Add(this.btnPedidoSugerido);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 112);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventario";
            // 
            // btRefSinMovimiento
            // 
            this.btRefSinMovimiento.Enabled = false;
            this.btRefSinMovimiento.Image = ((System.Drawing.Image)(resources.GetObject("btRefSinMovimiento.Image")));
            this.btRefSinMovimiento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRefSinMovimiento.Location = new System.Drawing.Point(15, 19);
            this.btRefSinMovimiento.Name = "btRefSinMovimiento";
            this.btRefSinMovimiento.Size = new System.Drawing.Size(105, 77);
            this.btRefSinMovimiento.TabIndex = 12;
            this.btRefSinMovimiento.Tag = "frmReferenciasSinMovimiento";
            this.btRefSinMovimiento.Text = "Referencias Sin Movimiento";
            this.btRefSinMovimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRefSinMovimiento.UseVisualStyleBackColor = true;
            // 
            // frmMenuRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(519, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenuRep";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMenuRep";
            this.Activated += new System.EventHandler(this.frmMenuRep_Activated);
            this.Load += new System.EventHandler(this.frmMenuRep_Load);
            this.Click += new System.EventHandler(this.groupBox2_Enter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btDevoluciones;
        private System.Windows.Forms.Button btFormasPago;
        private System.Windows.Forms.Button btVentasDiarias;
        private System.Windows.Forms.Button btDenominaciones;
        private System.Windows.Forms.Button btHorasPico;
        private System.Windows.Forms.Button btnPagosConsolidados;
        private System.Windows.Forms.Button btnExistencias;
        private System.Windows.Forms.Button btnPedidoSugerido;
        private System.Windows.Forms.Button btRepoArt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btRefSinMovimiento;
        public System.Windows.Forms.GroupBox groupBox2;
    }
}