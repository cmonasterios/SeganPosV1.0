namespace SEGAN_POS
{
  partial class frmCierreMFManual
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txSerial = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txFecha = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txRepZ = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txExentosSys = new System.Windows.Forms.TextBox();
            this.txExentos = new System.Windows.Forms.TextBox();
            this.txIVASys = new System.Windows.Forms.TextBox();
            this.txIVA = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txFactHastaSys = new System.Windows.Forms.TextBox();
            this.txBaseSys = new System.Windows.Forms.TextBox();
            this.txBase = new System.Windows.Forms.TextBox();
            this.txFactDesde = new System.Windows.Forms.TextBox();
            this.txFactHasta = new System.Windows.Forms.TextBox();
            this.txFactDesdeSys = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txCantFactSys = new System.Windows.Forms.TextBox();
            this.txCantFact = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txVentaNetaSys = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txVentaNeta = new System.Windows.Forms.TextBox();
            this.txTotFactSys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txCOO = new System.Windows.Forms.TextBox();
            this.txTotFact = new System.Windows.Forms.TextBox();
            this.txTotNC = new System.Windows.Forms.TextBox();
            this.txTotNCSys = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txDesc = new System.Windows.Forms.TextBox();
            this.txDescSys = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txExentoNCSys = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txBaseNCSys = new System.Windows.Forms.TextBox();
            this.txBaseNC = new System.Windows.Forms.TextBox();
            this.txExentoNC = new System.Windows.Forms.TextBox();
            this.txIVANC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txIVANCSys = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txZrestantes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.aceptar;
            this.btOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOK.Location = new System.Drawing.Point(306, 566);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 33);
            this.btOK.TabIndex = 12;
            this.btOK.Text = "Aceptar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.CausesValidation = false;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(404, 566);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 33);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "Cancelar";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txSerial
            // 
            this.txSerial.Location = new System.Drawing.Point(128, 15);
            this.txSerial.Name = "txSerial";
            this.txSerial.ReadOnly = true;
            this.txSerial.Size = new System.Drawing.Size(103, 20);
            this.txSerial.TabIndex = 82;
            this.txSerial.TabStop = false;
            this.txSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 13);
            this.label15.TabIndex = 83;
            this.label15.Text = "Serial Impresora";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txFecha
            // 
            this.txFecha.Location = new System.Drawing.Point(128, 48);
            this.txFecha.Name = "txFecha";
            this.txFecha.ReadOnly = true;
            this.txFecha.Size = new System.Drawing.Size(103, 20);
            this.txFecha.TabIndex = 84;
            this.txFecha.TabStop = false;
            this.txFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(85, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 85;
            this.label17.Text = "Fecha";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtHora
            // 
            this.dtHora.CustomFormat = "HH:mm";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHora.Location = new System.Drawing.Point(286, 48);
            this.dtHora.Name = "dtHora";
            this.dtHora.ShowUpDown = true;
            this.dtHora.Size = new System.Drawing.Size(89, 20);
            this.dtHora.TabIndex = 1;
            this.dtHora.Value = new System.DateTime(2014, 6, 12, 16, 56, 0, 0);
            this.dtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtHora_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(250, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 87;
            this.label18.Text = "Hora";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(404, 15);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 53);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(243, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 90;
            this.label16.Text = "Nro. Z";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txRepZ
            // 
            this.txRepZ.Location = new System.Drawing.Point(286, 15);
            this.txRepZ.MaxLength = 4;
            this.txRepZ.Name = "txRepZ";
            this.txRepZ.Size = new System.Drawing.Size(89, 20);
            this.txRepZ.TabIndex = 0;
            this.txRepZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txRepZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txRepZ_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txExentosSys);
            this.panel2.Controls.Add(this.txExentos);
            this.panel2.Controls.Add(this.txIVASys);
            this.panel2.Controls.Add(this.txIVA);
            this.panel2.Location = new System.Drawing.Point(0, 298);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 94);
            this.panel2.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Impuestos Tributados";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Exentos Tributados";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Base Tributados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txExentosSys
            // 
            this.txExentosSys.Location = new System.Drawing.Point(154, 34);
            this.txExentosSys.Name = "txExentosSys";
            this.txExentosSys.ReadOnly = true;
            this.txExentosSys.Size = new System.Drawing.Size(115, 20);
            this.txExentosSys.TabIndex = 56;
            this.txExentosSys.TabStop = false;
            this.txExentosSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txExentos
            // 
            this.txExentos.Location = new System.Drawing.Point(289, 35);
            this.txExentos.Name = "txExentos";
            this.txExentos.Size = new System.Drawing.Size(115, 20);
            this.txExentos.TabIndex = 9;
            this.txExentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txExentos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txExentos_KeyPress);
            this.txExentos.Leave += new System.EventHandler(this.txBase_Leave);
            // 
            // txIVASys
            // 
            this.txIVASys.Location = new System.Drawing.Point(154, 59);
            this.txIVASys.Name = "txIVASys";
            this.txIVASys.ReadOnly = true;
            this.txIVASys.Size = new System.Drawing.Size(115, 20);
            this.txIVASys.TabIndex = 54;
            this.txIVASys.TabStop = false;
            this.txIVASys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txIVA
            // 
            this.txIVA.Location = new System.Drawing.Point(289, 59);
            this.txIVA.Name = "txIVA";
            this.txIVA.Size = new System.Drawing.Size(115, 20);
            this.txIVA.TabIndex = 7;
            this.txIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txIVA_KeyPress);
            this.txIVA.Leave += new System.EventHandler(this.txBase_Leave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(0, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 98);
            this.panel1.TabIndex = 88;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Factura desde";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Factura hasta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 86;
            this.label14.Text = "Cantidad Facturas";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txFactHastaSys
            // 
            this.txFactHastaSys.Location = new System.Drawing.Point(158, 235);
            this.txFactHastaSys.MaxLength = 8;
            this.txFactHastaSys.Name = "txFactHastaSys";
            this.txFactHastaSys.ReadOnly = true;
            this.txFactHastaSys.Size = new System.Drawing.Size(115, 20);
            this.txFactHastaSys.TabIndex = 49;
            this.txFactHastaSys.TabStop = false;
            this.txFactHastaSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txBaseSys
            // 
            this.txBaseSys.Location = new System.Drawing.Point(156, 309);
            this.txBaseSys.Name = "txBaseSys";
            this.txBaseSys.ReadOnly = true;
            this.txBaseSys.Size = new System.Drawing.Size(115, 20);
            this.txBaseSys.TabIndex = 50;
            this.txBaseSys.TabStop = false;
            this.txBaseSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txBase
            // 
            this.txBase.Location = new System.Drawing.Point(290, 309);
            this.txBase.Name = "txBase";
            this.txBase.Size = new System.Drawing.Size(115, 20);
            this.txBase.TabIndex = 6;
            this.txBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txBase_KeyPress);
            this.txBase.Leave += new System.EventHandler(this.txBase_Leave);
            // 
            // txFactDesde
            // 
            this.txFactDesde.Location = new System.Drawing.Point(292, 209);
            this.txFactDesde.MaxLength = 8;
            this.txFactDesde.Name = "txFactDesde";
            this.txFactDesde.Size = new System.Drawing.Size(115, 20);
            this.txFactDesde.TabIndex = 4;
            this.txFactDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txFactDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txFactDesde_KeyPress);
            this.txFactDesde.Leave += new System.EventHandler(this.txFactDesde_Leave);
            // 
            // txFactHasta
            // 
            this.txFactHasta.Location = new System.Drawing.Point(292, 235);
            this.txFactHasta.MaxLength = 8;
            this.txFactHasta.Name = "txFactHasta";
            this.txFactHasta.Size = new System.Drawing.Size(115, 20);
            this.txFactHasta.TabIndex = 5;
            this.txFactHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txFactHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txFactHasta_KeyPress);
            this.txFactHasta.Leave += new System.EventHandler(this.txFactHasta_Leave);
            // 
            // txFactDesdeSys
            // 
            this.txFactDesdeSys.Location = new System.Drawing.Point(158, 209);
            this.txFactDesdeSys.MaxLength = 8;
            this.txFactDesdeSys.Name = "txFactDesdeSys";
            this.txFactDesdeSys.ReadOnly = true;
            this.txFactDesdeSys.Size = new System.Drawing.Size(115, 20);
            this.txFactDesdeSys.TabIndex = 47;
            this.txFactDesdeSys.TabStop = false;
            this.txFactDesdeSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(289, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Reporte Z";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(155, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "Sistema";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txCantFactSys
            // 
            this.txCantFactSys.Location = new System.Drawing.Point(158, 261);
            this.txCantFactSys.Name = "txCantFactSys";
            this.txCantFactSys.ReadOnly = true;
            this.txCantFactSys.Size = new System.Drawing.Size(115, 20);
            this.txCantFactSys.TabIndex = 85;
            this.txCantFactSys.TabStop = false;
            this.txCantFactSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txCantFact
            // 
            this.txCantFact.Location = new System.Drawing.Point(292, 261);
            this.txCantFact.Name = "txCantFact";
            this.txCantFact.ReadOnly = true;
            this.txCantFact.Size = new System.Drawing.Size(115, 20);
            this.txCantFact.TabIndex = 87;
            this.txCantFact.TabStop = false;
            this.txCantFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.txZrestantes);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.txVentaNetaSys);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.txVentaNeta);
            this.panel4.Controls.Add(this.txTotFactSys);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txCOO);
            this.panel4.Controls.Add(this.txTotFact);
            this.panel4.Controls.Add(this.txTotNC);
            this.panel4.Controls.Add(this.txTotNCSys);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txDesc);
            this.panel4.Controls.Add(this.txDescSys);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(0, 23);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 165);
            this.panel4.TabIndex = 90;
            // 
            // txVentaNetaSys
            // 
            this.txVentaNetaSys.Location = new System.Drawing.Point(152, 110);
            this.txVentaNetaSys.Name = "txVentaNetaSys";
            this.txVentaNetaSys.ReadOnly = true;
            this.txVentaNetaSys.Size = new System.Drawing.Size(115, 20);
            this.txVentaNetaSys.TabIndex = 114;
            this.txVentaNetaSys.TabStop = false;
            this.txVentaNetaSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(76, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 13);
            this.label20.TabIndex = 115;
            this.label20.Text = "Venta Neta";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txVentaNeta
            // 
            this.txVentaNeta.Location = new System.Drawing.Point(287, 110);
            this.txVentaNeta.Name = "txVentaNeta";
            this.txVentaNeta.ReadOnly = true;
            this.txVentaNeta.Size = new System.Drawing.Size(115, 20);
            this.txVentaNeta.TabIndex = 116;
            this.txVentaNeta.TabStop = false;
            this.txVentaNeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txTotFactSys
            // 
            this.txTotFactSys.Location = new System.Drawing.Point(153, 34);
            this.txTotFactSys.Name = "txTotFactSys";
            this.txTotFactSys.ReadOnly = true;
            this.txTotFactSys.Size = new System.Drawing.Size(115, 20);
            this.txTotFactSys.TabIndex = 105;
            this.txTotFactSys.TabStop = false;
            this.txTotFactSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "COO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Total Tributados";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txCOO
            // 
            this.txCOO.Location = new System.Drawing.Point(289, 6);
            this.txCOO.MaxLength = 6;
            this.txCOO.Name = "txCOO";
            this.txCOO.Size = new System.Drawing.Size(115, 20);
            this.txCOO.TabIndex = 103;
            this.txCOO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txCOO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txCOO_KeyPress);
            // 
            // txTotFact
            // 
            this.txTotFact.Location = new System.Drawing.Point(288, 34);
            this.txTotFact.Name = "txTotFact";
            this.txTotFact.ReadOnly = true;
            this.txTotFact.Size = new System.Drawing.Size(115, 20);
            this.txTotFact.TabIndex = 107;
            this.txTotFact.TabStop = false;
            this.txTotFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txTotNC
            // 
            this.txTotNC.Location = new System.Drawing.Point(288, 60);
            this.txTotNC.Name = "txTotNC";
            this.txTotNC.ReadOnly = true;
            this.txTotNC.Size = new System.Drawing.Size(115, 20);
            this.txTotNC.TabIndex = 110;
            this.txTotNC.TabStop = false;
            this.txTotNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txTotNCSys
            // 
            this.txTotNCSys.Location = new System.Drawing.Point(154, 60);
            this.txTotNCSys.Name = "txTotNCSys";
            this.txTotNCSys.ReadOnly = true;
            this.txTotNCSys.Size = new System.Drawing.Size(115, 20);
            this.txTotNCSys.TabIndex = 108;
            this.txTotNCSys.TabStop = false;
            this.txTotNCSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(82, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "Total NCs";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txDesc
            // 
            this.txDesc.Location = new System.Drawing.Point(287, 84);
            this.txDesc.Name = "txDesc";
            this.txDesc.Size = new System.Drawing.Size(115, 20);
            this.txDesc.TabIndex = 8;
            this.txDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txDesc_KeyPress);
            this.txDesc.Leave += new System.EventHandler(this.txDesc_Leave);
            // 
            // txDescSys
            // 
            this.txDescSys.Location = new System.Drawing.Point(153, 84);
            this.txDescSys.Name = "txDescSys";
            this.txDescSys.ReadOnly = true;
            this.txDescSys.Size = new System.Drawing.Size(115, 20);
            this.txDescSys.TabIndex = 52;
            this.txDescSys.TabStop = false;
            this.txDescSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Total Descuentos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txCantFact);
            this.groupBox1.Controls.Add(this.txCantFactSys);
            this.groupBox1.Controls.Add(this.txFactHastaSys);
            this.groupBox1.Controls.Add(this.txBaseSys);
            this.groupBox1.Controls.Add(this.txBase);
            this.groupBox1.Controls.Add(this.txFactDesde);
            this.groupBox1.Controls.Add(this.txFactDesdeSys);
            this.groupBox1.Controls.Add(this.txFactHasta);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(22, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 486);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txExentoNCSys);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txBaseNCSys);
            this.panel3.Controls.Add(this.txBaseNC);
            this.panel3.Controls.Add(this.txExentoNC);
            this.panel3.Controls.Add(this.txIVANC);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txIVANCSys);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Location = new System.Drawing.Point(0, 398);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(457, 88);
            this.panel3.TabIndex = 91;
            // 
            // txExentoNCSys
            // 
            this.txExentoNCSys.Location = new System.Drawing.Point(154, 34);
            this.txExentoNCSys.Name = "txExentoNCSys";
            this.txExentoNCSys.ReadOnly = true;
            this.txExentoNCSys.Size = new System.Drawing.Size(115, 20);
            this.txExentoNCSys.TabIndex = 116;
            this.txExentoNCSys.TabStop = false;
            this.txExentoNCSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Base NCs";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txBaseNCSys
            // 
            this.txBaseNCSys.Location = new System.Drawing.Point(153, 7);
            this.txBaseNCSys.Name = "txBaseNCSys";
            this.txBaseNCSys.ReadOnly = true;
            this.txBaseNCSys.Size = new System.Drawing.Size(115, 20);
            this.txBaseNCSys.TabIndex = 111;
            this.txBaseNCSys.TabStop = false;
            this.txBaseNCSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txBaseNC
            // 
            this.txBaseNC.Location = new System.Drawing.Point(288, 6);
            this.txBaseNC.Name = "txBaseNC";
            this.txBaseNC.Size = new System.Drawing.Size(115, 20);
            this.txBaseNC.TabIndex = 109;
            this.txBaseNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txBaseNC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txBaseNC_KeyPress);
            this.txBaseNC.Leave += new System.EventHandler(this.txBaseNC_Leave);
            // 
            // txExentoNC
            // 
            this.txExentoNC.Location = new System.Drawing.Point(289, 33);
            this.txExentoNC.Name = "txExentoNC";
            this.txExentoNC.Size = new System.Drawing.Size(115, 20);
            this.txExentoNC.TabIndex = 115;
            this.txExentoNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txExentoNC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txExentoNC_KeyPress);
            this.txExentoNC.Leave += new System.EventHandler(this.txExentoNC_Leave);
            // 
            // txIVANC
            // 
            this.txIVANC.Location = new System.Drawing.Point(289, 60);
            this.txIVANC.Name = "txIVANC";
            this.txIVANC.Size = new System.Drawing.Size(115, 20);
            this.txIVANC.TabIndex = 110;
            this.txIVANC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txIVANC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txIVANC_KeyPress);
            this.txIVANC.Leave += new System.EventHandler(this.txIVANC_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 114;
            this.label9.Text = "Impuesto NCs";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txIVANCSys
            // 
            this.txIVANCSys.Location = new System.Drawing.Point(154, 60);
            this.txIVANCSys.Name = "txIVANCSys";
            this.txIVANCSys.ReadOnly = true;
            this.txIVANCSys.Size = new System.Drawing.Size(115, 20);
            this.txIVANCSys.TabIndex = 113;
            this.txIVANCSys.TabStop = false;
            this.txIVANCSys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 117;
            this.label19.Text = "Exento NCs";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(63, 137);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 117;
            this.label21.Text = "N° Z restantes";
            // 
            // txZrestantes
            // 
            this.txZrestantes.Location = new System.Drawing.Point(288, 135);
            this.txZrestantes.Name = "txZrestantes";
            this.txZrestantes.Size = new System.Drawing.Size(115, 20);
            this.txZrestantes.TabIndex = 119;
            this.txZrestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txZrestantes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txZrestantes_KeyPress);
            // 
            // frmCierreMFManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(502, 611);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txRepZ);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dtHora);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txFecha);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txSerial);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCierreMFManual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cierre Manual de Máquina Fiscal";
            this.Activated += new System.EventHandler(this.frmCierreMFManual_Activated);
            this.Load += new System.EventHandler(this.frmCierreMFManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.TextBox txSerial;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox txFecha;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.DateTimePicker dtHora;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txRepZ;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.TextBox txExentoNCSys;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txBaseNCSys;
    private System.Windows.Forms.TextBox txBaseNC;
    private System.Windows.Forms.TextBox txExentoNC;
    private System.Windows.Forms.TextBox txIVANC;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txIVANCSys;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.TextBox txVentaNetaSys;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.TextBox txVentaNeta;
    private System.Windows.Forms.TextBox txTotFactSys;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox txCOO;
    private System.Windows.Forms.TextBox txTotFact;
    private System.Windows.Forms.TextBox txTotNC;
    private System.Windows.Forms.TextBox txTotNCSys;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox txDesc;
    private System.Windows.Forms.TextBox txDescSys;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txCantFact;
    private System.Windows.Forms.TextBox txCantFactSys;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txFactDesdeSys;
    private System.Windows.Forms.TextBox txFactHasta;
    private System.Windows.Forms.TextBox txFactDesde;
    private System.Windows.Forms.TextBox txBase;
    private System.Windows.Forms.TextBox txBaseSys;
    private System.Windows.Forms.TextBox txFactHastaSys;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txExentosSys;
    private System.Windows.Forms.TextBox txExentos;
    private System.Windows.Forms.TextBox txIVASys;
    private System.Windows.Forms.TextBox txIVA;
    private System.Windows.Forms.TextBox txZrestantes;
    private System.Windows.Forms.Label label21;
  }
}