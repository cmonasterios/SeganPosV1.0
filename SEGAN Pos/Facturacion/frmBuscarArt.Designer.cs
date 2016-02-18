namespace SEGAN_POS
{
  partial class frmBuscarArt
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btOK = new System.Windows.Forms.Button();
            this.cbColeccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.pbFotoArt = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txPrecioArt = new System.Windows.Forms.TextBox();
            this.txExistenciaArt = new System.Windows.Forms.TextBox();
            this.txEstatusArt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txReferencia = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbCantReg = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descColeccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descGeneroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Enabled = false;
            this.btOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOK.Image = global::SEGAN_POS.Properties.Resources.agregar2;
            this.btOK.Location = new System.Drawing.Point(85, 301);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 33);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "Agregar";
            this.btOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // cbColeccion
            // 
            this.cbColeccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbColeccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColeccion.FormattingEnabled = true;
            this.cbColeccion.Location = new System.Drawing.Point(106, 12);
            this.cbColeccion.Name = "cbColeccion";
            this.cbColeccion.Size = new System.Drawing.Size(223, 21);
            this.cbColeccion.TabIndex = 0;
            this.cbColeccion.SelectedIndexChanged += new System.EventHandler(this.cbColeccion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Colección";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Género";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGenero
            // 
            this.cbGenero.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGenero.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(439, 12);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(223, 21);
            this.cbGenero.TabIndex = 1;
            this.cbGenero.SelectedIndexChanged += new System.EventHandler(this.cbGenero_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Referencia";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Grupo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGrupo
            // 
            this.cbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(106, 48);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(223, 21);
            this.cbGrupo.TabIndex = 2;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // pbFotoArt
            // 
            this.pbFotoArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFotoArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFotoArt.Location = new System.Drawing.Point(12, 18);
            this.pbFotoArt.Name = "pbFotoArt";
            this.pbFotoArt.Size = new System.Drawing.Size(173, 173);
            this.pbFotoArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoArt.TabIndex = 16;
            this.pbFotoArt.TabStop = false;
            this.pbFotoArt.Click += new System.EventHandler(this.pbFotoArt_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Precio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Existencia";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Estatus";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txPrecioArt
            // 
            this.txPrecioArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txPrecioArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txPrecioArt.Enabled = false;
            this.txPrecioArt.Location = new System.Drawing.Point(85, 197);
            this.txPrecioArt.Name = "txPrecioArt";
            this.txPrecioArt.ReadOnly = true;
            this.txPrecioArt.Size = new System.Drawing.Size(100, 20);
            this.txPrecioArt.TabIndex = 20;
            this.txPrecioArt.TabStop = false;
            this.txPrecioArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txExistenciaArt
            // 
            this.txExistenciaArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txExistenciaArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txExistenciaArt.Enabled = false;
            this.txExistenciaArt.Location = new System.Drawing.Point(85, 223);
            this.txExistenciaArt.Name = "txExistenciaArt";
            this.txExistenciaArt.ReadOnly = true;
            this.txExistenciaArt.Size = new System.Drawing.Size(100, 20);
            this.txExistenciaArt.TabIndex = 21;
            this.txExistenciaArt.TabStop = false;
            this.txExistenciaArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txEstatusArt
            // 
            this.txEstatusArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txEstatusArt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txEstatusArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txEstatusArt.Location = new System.Drawing.Point(85, 249);
            this.txEstatusArt.Name = "txEstatusArt";
            this.txEstatusArt.ReadOnly = true;
            this.txEstatusArt.Size = new System.Drawing.Size(100, 20);
            this.txEstatusArt.TabIndex = 22;
            this.txEstatusArt.TabStop = false;
            this.txEstatusArt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txReferencia);
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.btLimpiar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbColeccion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbGenero);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbGrupo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 82);
            this.panel1.TabIndex = 23;
            // 
            // txReferencia
            // 
            this.txReferencia.Location = new System.Drawing.Point(439, 49);
            this.txReferencia.MaxLength = 11;
            this.txReferencia.Name = "txReferencia";
            this.txReferencia.Size = new System.Drawing.Size(223, 20);
            this.txReferencia.TabIndex = 3;
            this.txReferencia.TextChanged += new System.EventHandler(this.txReferencia_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.CausesValidation = false;
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscarpeq;
            this.btBuscar.Location = new System.Drawing.Point(802, 12);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 28);
            this.btBuscar.TabIndex = 4;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLimpiar.CausesValidation = false;
            this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btLimpiar.Location = new System.Drawing.Point(802, 44);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btLimpiar.TabIndex = 5;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbFotoArt);
            this.panel2.Controls.Add(this.txPrecioArt);
            this.panel2.Controls.Add(this.txEstatusArt);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txExistenciaArt);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(731, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 360);
            this.panel2.TabIndex = 24;
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToResizeRows = false;
            this.dgItems.AutoGenerateColumns = false;
            this.dgItems.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticuloDataGridViewTextBoxColumn,
            this.codigoArticuloDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.descColeccionDataGridViewTextBoxColumn,
            this.descGeneroDataGridViewTextBoxColumn,
            this.descGrupoDataGridViewTextBoxColumn});
            this.dgItems.DataSource = this.itemArticuloBindingSource;
            this.dgItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgItems.Location = new System.Drawing.Point(0, 0);
            this.dgItems.MultiSelect = false;
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgItems.RowHeadersVisible = false;
            this.dgItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.ShowEditingIcon = false;
            this.dgItems.Size = new System.Drawing.Size(729, 334);
            this.dgItems.TabIndex = 6;
            this.dgItems.TabStop = false;
            this.dgItems.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgItems_CellBeginEdit);
            this.dgItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellDoubleClick);
            this.dgItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgItems_DataError);
            this.dgItems.SelectionChanged += new System.EventHandler(this.dgItems_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbCantReg);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 418);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(729, 26);
            this.panel3.TabIndex = 25;
            // 
            // lbCantReg
            // 
            this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCantReg.AutoSize = true;
            this.lbCantReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantReg.Location = new System.Drawing.Point(7, 7);
            this.lbCantReg.Name = "lbCantReg";
            this.lbCantReg.Size = new System.Drawing.Size(129, 13);
            this.lbCantReg.TabIndex = 82;
            this.lbCantReg.Text = "registros encontrados";
            this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCantReg.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgItems);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(2, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(729, 334);
            this.panel4.TabIndex = 26;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.Visible = false;
            // 
            // codigoArticuloDataGridViewTextBoxColumn
            // 
            this.codigoArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodigoArticulo";
            this.codigoArticuloDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codigoArticuloDataGridViewTextBoxColumn.Name = "codigoArticuloDataGridViewTextBoxColumn";
            this.codigoArticuloDataGridViewTextBoxColumn.Width = 90;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 230;
            // 
            // descColeccionDataGridViewTextBoxColumn
            // 
            this.descColeccionDataGridViewTextBoxColumn.DataPropertyName = "DescColeccion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.descColeccionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.descColeccionDataGridViewTextBoxColumn.HeaderText = "Colección";
            this.descColeccionDataGridViewTextBoxColumn.Name = "descColeccionDataGridViewTextBoxColumn";
            // 
            // descGeneroDataGridViewTextBoxColumn
            // 
            this.descGeneroDataGridViewTextBoxColumn.DataPropertyName = "DescGenero";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.descGeneroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.descGeneroDataGridViewTextBoxColumn.HeaderText = "Género";
            this.descGeneroDataGridViewTextBoxColumn.Name = "descGeneroDataGridViewTextBoxColumn";
            this.descGeneroDataGridViewTextBoxColumn.Width = 145;
            // 
            // descGrupoDataGridViewTextBoxColumn
            // 
            this.descGrupoDataGridViewTextBoxColumn.DataPropertyName = "DescGrupo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.descGrupoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.descGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.descGrupoDataGridViewTextBoxColumn.Name = "descGrupoDataGridViewTextBoxColumn";
            this.descGrupoDataGridViewTextBoxColumn.Width = 140;
            // 
            // itemArticuloBindingSource
            // 
            this.itemArticuloBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemArticulo);
            // 
            // frmBuscarArt
            // 
            this.AcceptButton = this.btBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 446);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarArt";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBuscarArt";
            this.Activated += new System.EventHandler(this.frmBuscarArt_Activated);
            this.Load += new System.EventHandler(this.frmBuscarArt_Load);
            this.Shown += new System.EventHandler(this.frmBuscarArt_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuscarArt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoArt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btOK;
    private System.Windows.Forms.ComboBox cbColeccion;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cbGenero;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbGrupo;
    private System.Windows.Forms.PictureBox pbFotoArt;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox txPrecioArt;
    private System.Windows.Forms.TextBox txExistenciaArt;
    private System.Windows.Forms.TextBox txEstatusArt;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox txReferencia;
    private System.Windows.Forms.DataGridView dgItems;
    private System.Windows.Forms.BindingSource itemArticuloBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codigoArticuloDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descColeccionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descGeneroDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn descGrupoDataGridViewTextBoxColumn;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.ErrorProvider errorProvider1;
  }
}