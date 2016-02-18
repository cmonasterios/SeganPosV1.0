namespace SEGAN_POS.Facturacion
{
    partial class frmFacturaManual
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnPrincipal = new System.Windows.Forms.Panel();
            this.btAgregar = new System.Windows.Forms.Button();
            this.btBuscarArt = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btCancelar = new System.Windows.Forms.Button();
            this.txNumControl = new System.Windows.Forms.TextBox();
            this.lbNumControl = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.txTotalPagar = new System.Windows.Forms.TextBox();
            this.txIVA = new System.Windows.Forms.TextBox();
            this.txTotal = new System.Windows.Forms.TextBox();
            this.txAjuste = new System.Windows.Forms.TextBox();
            this.txOtros = new System.Windows.Forms.TextBox();
            this.txSubTotal = new System.Windows.Forms.TextBox();
            this.lbTotalPagar = new System.Windows.Forms.Label();
            this.lbIVA = new System.Windows.Forms.Label();
            this.lbAjuste = new System.Windows.Forms.Label();
            this.lbOtros = new System.Windows.Forms.Label();
            this.lbSubTotal = new System.Windows.Forms.Label();
            this.dgFormaPago = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.lbFormaPago = new System.Windows.Forms.Label();
            this.dgArticulo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txArticulo = new System.Windows.Forms.TextBox();
            this.lbArticulo = new System.Windows.Forms.Label();
            this.pnCliente = new System.Windows.Forms.Panel();
            this.txTelef = new System.Windows.Forms.TextBox();
            this.txDomicilio = new System.Windows.Forms.TextBox();
            this.lbDomicilio = new System.Windows.Forms.Label();
            this.txCedula = new System.Windows.Forms.TextBox();
            this.lbTelef = new System.Windows.Forms.Label();
            this.lbCedula = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txCliente = new System.Windows.Forms.TextBox();
            this.pnCondPago = new System.Windows.Forms.Panel();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbContado = new System.Windows.Forms.RadioButton();
            this.lbCondPago = new System.Windows.Forms.Label();
            this.txSerie = new System.Windows.Forms.TextBox();
            this.txNumFactura = new System.Windows.Forms.TextBox();
            this.cbTienda = new System.Windows.Forms.ComboBox();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbSerie = new System.Windows.Forms.Label();
            this.lbNumFactura = new System.Windows.Forms.Label();
            this.lbTienda = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulo)).BeginInit();
            this.pnCliente.SuspendLayout();
            this.pnCondPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEGAN_POS.Properties.Resources.coronaepk;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 31);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestionar Factura Manual";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 39);
            this.panel1.TabIndex = 2;
            // 
            // pnPrincipal
            // 
            this.pnPrincipal.Controls.Add(this.btAgregar);
            this.pnPrincipal.Controls.Add(this.btBuscarArt);
            this.pnPrincipal.Controls.Add(this.dtpFecha);
            this.pnPrincipal.Controls.Add(this.btCancelar);
            this.pnPrincipal.Controls.Add(this.txNumControl);
            this.pnPrincipal.Controls.Add(this.lbNumControl);
            this.pnPrincipal.Controls.Add(this.lbTotal);
            this.pnPrincipal.Controls.Add(this.txTotalPagar);
            this.pnPrincipal.Controls.Add(this.txIVA);
            this.pnPrincipal.Controls.Add(this.txTotal);
            this.pnPrincipal.Controls.Add(this.txAjuste);
            this.pnPrincipal.Controls.Add(this.txOtros);
            this.pnPrincipal.Controls.Add(this.txSubTotal);
            this.pnPrincipal.Controls.Add(this.lbTotalPagar);
            this.pnPrincipal.Controls.Add(this.lbIVA);
            this.pnPrincipal.Controls.Add(this.lbAjuste);
            this.pnPrincipal.Controls.Add(this.lbOtros);
            this.pnPrincipal.Controls.Add(this.lbSubTotal);
            this.pnPrincipal.Controls.Add(this.dgFormaPago);
            this.pnPrincipal.Controls.Add(this.cbFormaPago);
            this.pnPrincipal.Controls.Add(this.lbFormaPago);
            this.pnPrincipal.Controls.Add(this.dgArticulo);
            this.pnPrincipal.Controls.Add(this.txArticulo);
            this.pnPrincipal.Controls.Add(this.lbArticulo);
            this.pnPrincipal.Controls.Add(this.pnCliente);
            this.pnPrincipal.Controls.Add(this.pnCondPago);
            this.pnPrincipal.Controls.Add(this.txSerie);
            this.pnPrincipal.Controls.Add(this.txNumFactura);
            this.pnPrincipal.Controls.Add(this.cbTienda);
            this.pnPrincipal.Controls.Add(this.lbFecha);
            this.pnPrincipal.Controls.Add(this.lbSerie);
            this.pnPrincipal.Controls.Add(this.lbNumFactura);
            this.pnPrincipal.Controls.Add(this.lbTienda);
            this.pnPrincipal.Controls.Add(this.btAceptar);
            this.pnPrincipal.Location = new System.Drawing.Point(14, 47);
            this.pnPrincipal.Name = "pnPrincipal";
            this.pnPrincipal.Size = new System.Drawing.Size(1088, 672);
            this.pnPrincipal.TabIndex = 3;
            // 
            // btAgregar
            // 
            this.btAgregar.Image = global::SEGAN_POS.Properties.Resources.agregar;
            this.btAgregar.Location = new System.Drawing.Point(344, 425);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(42, 34);
            this.btAgregar.TabIndex = 39;
            this.btAgregar.UseVisualStyleBackColor = true;
            // 
            // btBuscarArt
            // 
            this.btBuscarArt.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscarArt.Location = new System.Drawing.Point(344, 242);
            this.btBuscarArt.Name = "btBuscarArt";
            this.btBuscarArt.Size = new System.Drawing.Size(75, 30);
            this.btBuscarArt.TabIndex = 38;
            this.btBuscarArt.Text = "Buscar";
            this.btBuscarArt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscarArt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscarArt.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(615, 11);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 37;
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancelar.Location = new System.Drawing.Point(951, 609);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(97, 51);
            this.btCancelar.TabIndex = 36;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // txNumControl
            // 
            this.txNumControl.Location = new System.Drawing.Point(121, 567);
            this.txNumControl.Name = "txNumControl";
            this.txNumControl.Size = new System.Drawing.Size(200, 20);
            this.txNumControl.TabIndex = 33;
            // 
            // lbNumControl
            // 
            this.lbNumControl.AutoSize = true;
            this.lbNumControl.Location = new System.Drawing.Point(14, 570);
            this.lbNumControl.Name = "lbNumControl";
            this.lbNumControl.Size = new System.Drawing.Size(95, 13);
            this.lbNumControl.TabIndex = 32;
            this.lbNumControl.Text = "Numero de Control";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(799, 516);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(31, 13);
            this.lbTotal.TabIndex = 31;
            this.lbTotal.Text = "Total";
            // 
            // txTotalPagar
            // 
            this.txTotalPagar.Location = new System.Drawing.Point(916, 567);
            this.txTotalPagar.Name = "txTotalPagar";
            this.txTotalPagar.Size = new System.Drawing.Size(150, 20);
            this.txTotalPagar.TabIndex = 30;
            // 
            // txIVA
            // 
            this.txIVA.Location = new System.Drawing.Point(916, 540);
            this.txIVA.Name = "txIVA";
            this.txIVA.Size = new System.Drawing.Size(150, 20);
            this.txIVA.TabIndex = 29;
            // 
            // txTotal
            // 
            this.txTotal.Location = new System.Drawing.Point(916, 513);
            this.txTotal.Name = "txTotal";
            this.txTotal.Size = new System.Drawing.Size(150, 20);
            this.txTotal.TabIndex = 28;
            // 
            // txAjuste
            // 
            this.txAjuste.Location = new System.Drawing.Point(916, 486);
            this.txAjuste.Name = "txAjuste";
            this.txAjuste.Size = new System.Drawing.Size(150, 20);
            this.txAjuste.TabIndex = 27;
            // 
            // txOtros
            // 
            this.txOtros.Location = new System.Drawing.Point(916, 456);
            this.txOtros.Name = "txOtros";
            this.txOtros.Size = new System.Drawing.Size(150, 20);
            this.txOtros.TabIndex = 26;
            // 
            // txSubTotal
            // 
            this.txSubTotal.Location = new System.Drawing.Point(916, 421);
            this.txSubTotal.Name = "txSubTotal";
            this.txSubTotal.Size = new System.Drawing.Size(150, 20);
            this.txSubTotal.TabIndex = 25;
            // 
            // lbTotalPagar
            // 
            this.lbTotalPagar.AutoSize = true;
            this.lbTotalPagar.Location = new System.Drawing.Point(798, 570);
            this.lbTotalPagar.Name = "lbTotalPagar";
            this.lbTotalPagar.Size = new System.Drawing.Size(71, 13);
            this.lbTotalPagar.TabIndex = 24;
            this.lbTotalPagar.Text = "Total a Pagar";
            // 
            // lbIVA
            // 
            this.lbIVA.AutoSize = true;
            this.lbIVA.Location = new System.Drawing.Point(798, 543);
            this.lbIVA.Name = "lbIVA";
            this.lbIVA.Size = new System.Drawing.Size(76, 13);
            this.lbIVA.TabIndex = 23;
            this.lbIVA.Text = "I.V.A (%) sobre";
            // 
            // lbAjuste
            // 
            this.lbAjuste.AutoSize = true;
            this.lbAjuste.Location = new System.Drawing.Point(798, 489);
            this.lbAjuste.Name = "lbAjuste";
            this.lbAjuste.Size = new System.Drawing.Size(36, 13);
            this.lbAjuste.TabIndex = 22;
            this.lbAjuste.Text = "Ajuste";
            // 
            // lbOtros
            // 
            this.lbOtros.AutoSize = true;
            this.lbOtros.Location = new System.Drawing.Point(798, 459);
            this.lbOtros.Name = "lbOtros";
            this.lbOtros.Size = new System.Drawing.Size(32, 13);
            this.lbOtros.TabIndex = 21;
            this.lbOtros.Text = "Otros";
            // 
            // lbSubTotal
            // 
            this.lbSubTotal.AutoSize = true;
            this.lbSubTotal.Location = new System.Drawing.Point(798, 428);
            this.lbSubTotal.Name = "lbSubTotal";
            this.lbSubTotal.Size = new System.Drawing.Size(50, 13);
            this.lbSubTotal.TabIndex = 20;
            this.lbSubTotal.Text = "SubTotal";
            // 
            // dgFormaPago
            // 
            this.dgFormaPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFormaPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            this.dgFormaPago.Location = new System.Drawing.Point(402, 427);
            this.dgFormaPago.Name = "dgFormaPago";
            this.dgFormaPago.Size = new System.Drawing.Size(344, 79);
            this.dgFormaPago.TabIndex = 19;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Forma";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Monto";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(121, 428);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(200, 21);
            this.cbFormaPago.TabIndex = 17;
            // 
            // lbFormaPago
            // 
            this.lbFormaPago.AutoSize = true;
            this.lbFormaPago.Location = new System.Drawing.Point(18, 428);
            this.lbFormaPago.Name = "lbFormaPago";
            this.lbFormaPago.Size = new System.Drawing.Size(79, 13);
            this.lbFormaPago.TabIndex = 16;
            this.lbFormaPago.Text = "Forma de Pago";
            // 
            // dgArticulo
            // 
            this.dgArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgArticulo.Location = new System.Drawing.Point(16, 278);
            this.dgArticulo.Name = "dgArticulo";
            this.dgArticulo.Size = new System.Drawing.Size(1053, 130);
            this.dgArticulo.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Referencia";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Concepto";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Cantidad";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio Venta Unitario";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Monto Total";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // txArticulo
            // 
            this.txArticulo.Location = new System.Drawing.Point(121, 246);
            this.txArticulo.Name = "txArticulo";
            this.txArticulo.Size = new System.Drawing.Size(200, 20);
            this.txArticulo.TabIndex = 13;
            // 
            // lbArticulo
            // 
            this.lbArticulo.AutoSize = true;
            this.lbArticulo.Location = new System.Drawing.Point(17, 246);
            this.lbArticulo.Name = "lbArticulo";
            this.lbArticulo.Size = new System.Drawing.Size(95, 13);
            this.lbArticulo.TabIndex = 12;
            this.lbArticulo.Text = "Código de Artículo";
            // 
            // pnCliente
            // 
            this.pnCliente.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnCliente.Controls.Add(this.txTelef);
            this.pnCliente.Controls.Add(this.txDomicilio);
            this.pnCliente.Controls.Add(this.lbDomicilio);
            this.pnCliente.Controls.Add(this.txCedula);
            this.pnCliente.Controls.Add(this.lbTelef);
            this.pnCliente.Controls.Add(this.lbCedula);
            this.pnCliente.Controls.Add(this.lbNombre);
            this.pnCliente.Controls.Add(this.txCliente);
            this.pnCliente.Location = new System.Drawing.Point(16, 110);
            this.pnCliente.Name = "pnCliente";
            this.pnCliente.Size = new System.Drawing.Size(1053, 116);
            this.pnCliente.TabIndex = 11;
            // 
            // txTelef
            // 
            this.txTelef.Location = new System.Drawing.Point(659, 50);
            this.txTelef.Name = "txTelef";
            this.txTelef.Size = new System.Drawing.Size(250, 20);
            this.txTelef.TabIndex = 14;
            // 
            // txDomicilio
            // 
            this.txDomicilio.Location = new System.Drawing.Point(153, 88);
            this.txDomicilio.Name = "txDomicilio";
            this.txDomicilio.Size = new System.Drawing.Size(600, 20);
            this.txDomicilio.TabIndex = 13;
            // 
            // lbDomicilio
            // 
            this.lbDomicilio.AutoSize = true;
            this.lbDomicilio.Location = new System.Drawing.Point(3, 88);
            this.lbDomicilio.Name = "lbDomicilio";
            this.lbDomicilio.Size = new System.Drawing.Size(79, 13);
            this.lbDomicilio.TabIndex = 12;
            this.lbDomicilio.Text = "Domicilio Fiscal";
            // 
            // txCedula
            // 
            this.txCedula.Location = new System.Drawing.Point(153, 50);
            this.txCedula.Name = "txCedula";
            this.txCedula.Size = new System.Drawing.Size(250, 20);
            this.txCedula.TabIndex = 11;
            // 
            // lbTelef
            // 
            this.lbTelef.AutoSize = true;
            this.lbTelef.Location = new System.Drawing.Point(587, 50);
            this.lbTelef.Name = "lbTelef";
            this.lbTelef.Size = new System.Drawing.Size(52, 13);
            this.lbTelef.TabIndex = 2;
            this.lbTelef.Text = "Telefóno:";
            // 
            // lbCedula
            // 
            this.lbCedula.AutoSize = true;
            this.lbCedula.Location = new System.Drawing.Point(4, 53);
            this.lbCedula.Name = "lbCedula";
            this.lbCedula.Size = new System.Drawing.Size(45, 13);
            this.lbCedula.TabIndex = 1;
            this.lbCedula.Text = "C.I/ RIF";
            this.lbCedula.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(3, 10);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(119, 13);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre o Razón Social";
            // 
            // txCliente
            // 
            this.txCliente.Location = new System.Drawing.Point(153, 7);
            this.txCliente.Name = "txCliente";
            this.txCliente.Size = new System.Drawing.Size(600, 20);
            this.txCliente.TabIndex = 10;
            // 
            // pnCondPago
            // 
            this.pnCondPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCondPago.Controls.Add(this.rbCredito);
            this.pnCondPago.Controls.Add(this.rbContado);
            this.pnCondPago.Controls.Add(this.lbCondPago);
            this.pnCondPago.Location = new System.Drawing.Point(873, 4);
            this.pnCondPago.Name = "pnCondPago";
            this.pnCondPago.Size = new System.Drawing.Size(196, 88);
            this.pnCondPago.TabIndex = 8;
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Location = new System.Drawing.Point(126, 41);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(58, 17);
            this.rbCredito.TabIndex = 2;
            this.rbCredito.TabStop = true;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            // 
            // rbContado
            // 
            this.rbContado.AutoSize = true;
            this.rbContado.Location = new System.Drawing.Point(126, 1);
            this.rbContado.Name = "rbContado";
            this.rbContado.Size = new System.Drawing.Size(65, 17);
            this.rbContado.TabIndex = 1;
            this.rbContado.TabStop = true;
            this.rbContado.Text = "Contado";
            this.rbContado.UseVisualStyleBackColor = true;
            // 
            // lbCondPago
            // 
            this.lbCondPago.AutoSize = true;
            this.lbCondPago.Location = new System.Drawing.Point(3, 3);
            this.lbCondPago.Name = "lbCondPago";
            this.lbCondPago.Size = new System.Drawing.Size(108, 13);
            this.lbCondPago.TabIndex = 0;
            this.lbCondPago.Text = "Condiciones de Pago";
            // 
            // txSerie
            // 
            this.txSerie.Location = new System.Drawing.Point(615, 56);
            this.txSerie.Name = "txSerie";
            this.txSerie.Size = new System.Drawing.Size(200, 20);
            this.txSerie.TabIndex = 6;
            // 
            // txNumFactura
            // 
            this.txNumFactura.Location = new System.Drawing.Point(142, 51);
            this.txNumFactura.Name = "txNumFactura";
            this.txNumFactura.Size = new System.Drawing.Size(200, 20);
            this.txNumFactura.TabIndex = 5;
            // 
            // cbTienda
            // 
            this.cbTienda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTienda.FormattingEnabled = true;
            this.cbTienda.Location = new System.Drawing.Point(142, 6);
            this.cbTienda.Name = "cbTienda";
            this.cbTienda.Size = new System.Drawing.Size(300, 21);
            this.cbTienda.TabIndex = 4;
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(518, 11);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(91, 13);
            this.lbFecha.TabIndex = 3;
            this.lbFecha.Text = "Fecha de Factura";
            // 
            // lbSerie
            // 
            this.lbSerie.AutoSize = true;
            this.lbSerie.Location = new System.Drawing.Point(518, 59);
            this.lbSerie.Name = "lbSerie";
            this.lbSerie.Size = new System.Drawing.Size(31, 13);
            this.lbSerie.TabIndex = 2;
            this.lbSerie.Text = "Serie";
            // 
            // lbNumFactura
            // 
            this.lbNumFactura.AutoSize = true;
            this.lbNumFactura.Location = new System.Drawing.Point(14, 58);
            this.lbNumFactura.Name = "lbNumFactura";
            this.lbNumFactura.Size = new System.Drawing.Size(98, 13);
            this.lbNumFactura.TabIndex = 1;
            this.lbNumFactura.Text = "Número de Factura";
            // 
            // lbTienda
            // 
            this.lbTienda.AutoSize = true;
            this.lbTienda.Location = new System.Drawing.Point(13, 10);
            this.lbTienda.Name = "lbTienda";
            this.lbTienda.Size = new System.Drawing.Size(40, 13);
            this.lbTienda.TabIndex = 0;
            this.lbTienda.Text = "Tienda";
            // 
            // btAceptar
            // 
            this.btAceptar.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btAceptar.Location = new System.Drawing.Point(789, 609);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(97, 51);
            this.btAceptar.TabIndex = 35;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAceptar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SEGAN_POS.Properties.Resources.usuario;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(259, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(843, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar Cliente (F2)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmFacturaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnPrincipal);
            this.Controls.Add(this.panel1);
            this.Name = "frmFacturaManual";
            this.Text = "frmFacturaManual";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnPrincipal.ResumeLayout(false);
            this.pnPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulo)).EndInit();
            this.pnCliente.ResumeLayout(false);
            this.pnCliente.PerformLayout();
            this.pnCondPago.ResumeLayout(false);
            this.pnCondPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnPrincipal;
        private System.Windows.Forms.Panel pnCondPago;
        private System.Windows.Forms.TextBox txSerie;
        private System.Windows.Forms.TextBox txNumFactura;
        private System.Windows.Forms.ComboBox cbTienda;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbSerie;
        private System.Windows.Forms.Label lbNumFactura;
        private System.Windows.Forms.Label lbTienda;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbContado;
        private System.Windows.Forms.Panel pnCliente;
        private System.Windows.Forms.Label lbDomicilio;
        private System.Windows.Forms.TextBox txCedula;
        private System.Windows.Forms.Label lbTelef;
        private System.Windows.Forms.Label lbCedula;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txCliente;
        private System.Windows.Forms.TextBox txTelef;
        private System.Windows.Forms.TextBox txDomicilio;
        private System.Windows.Forms.Label lbArticulo;
        private System.Windows.Forms.Label lbCondPago;
        private System.Windows.Forms.TextBox txArticulo;
        private System.Windows.Forms.DataGridView dgArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label lbFormaPago;
        private System.Windows.Forms.DataGridView dgFormaPago;
        private System.Windows.Forms.TextBox txNumControl;
        private System.Windows.Forms.Label lbNumControl;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.TextBox txTotalPagar;
        private System.Windows.Forms.TextBox txIVA;
        private System.Windows.Forms.TextBox txTotal;
        private System.Windows.Forms.TextBox txAjuste;
        private System.Windows.Forms.TextBox txOtros;
        private System.Windows.Forms.TextBox txSubTotal;
        private System.Windows.Forms.Label lbTotalPagar;
        private System.Windows.Forms.Label lbIVA;
        private System.Windows.Forms.Label lbAjuste;
        private System.Windows.Forms.Label lbOtros;
        private System.Windows.Forms.Label lbSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btBuscarArt;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Button button1;
    }
}