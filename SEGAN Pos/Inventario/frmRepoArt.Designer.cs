namespace SEGAN_POS
{
  partial class frmRepoArt
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.pnFooter = new System.Windows.Forms.Panel();
      this.btExport = new System.Windows.Forms.Button();
      this.lbCantReg = new System.Windows.Forms.Label();
      this.btCancelar = new System.Windows.Forms.Button();
      this.dgResults = new System.Windows.Forms.DataGridView();
      this.pnHeader = new System.Windows.Forms.Panel();
      this.label8 = new System.Windows.Forms.Label();
      this.cbTema = new System.Windows.Forms.ComboBox();
      this.txReferencia = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.udCantidad = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.cbGrupo = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cbGenero = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.dtHoHasta = new System.Windows.Forms.DateTimePicker();
      this.dtHoDesde = new System.Windows.Forms.DateTimePicker();
      this.cbColeccion = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btBuscar = new System.Windows.Forms.Button();
      this.lbDesde = new System.Windows.Forms.Label();
      this.dtFeDesde = new System.Windows.Forms.DateTimePicker();
      this.lbHasta = new System.Windows.Forms.Label();
      this.dtFeHasta = new System.Windows.Forms.DateTimePicker();
      this.btLimpiar = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.itemRepoArticulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.codColecDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.DescTema = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.descGeneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codRefDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.codArtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ventasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.devolucionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnFooter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
      this.pnHeader.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.udCantidad)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemRepoArticulosBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // pnFooter
      // 
      this.pnFooter.Controls.Add(this.btExport);
      this.pnFooter.Controls.Add(this.lbCantReg);
      this.pnFooter.Controls.Add(this.btCancelar);
      this.pnFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnFooter.Location = new System.Drawing.Point(2, 467);
      this.pnFooter.Name = "pnFooter";
      this.pnFooter.Size = new System.Drawing.Size(1125, 39);
      this.pnFooter.TabIndex = 2;
      // 
      // btExport
      // 
      this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btExport.CausesValidation = false;
      this.btExport.Enabled = false;
      this.btExport.Image = global::SEGAN_POS.Properties.Resources.excel;
      this.btExport.Location = new System.Drawing.Point(962, 4);
      this.btExport.Name = "btExport";
      this.btExport.Size = new System.Drawing.Size(83, 32);
      this.btExport.TabIndex = 11;
      this.btExport.Tag = "Exportar";
      this.btExport.Text = "Exportar";
      this.btExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btExport.UseVisualStyleBackColor = true;
      this.btExport.Click += new System.EventHandler(this.btExport_Click);
      // 
      // lbCantReg
      // 
      this.lbCantReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbCantReg.AutoSize = true;
      this.lbCantReg.Location = new System.Drawing.Point(12, 14);
      this.lbCantReg.Name = "lbCantReg";
      this.lbCantReg.Size = new System.Drawing.Size(114, 13);
      this.lbCantReg.TabIndex = 81;
      this.lbCantReg.Text = "Registros Encontrados";
      this.lbCantReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.lbCantReg.Visible = false;
      // 
      // btCancelar
      // 
      this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancelar.CausesValidation = false;
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancelar.Location = new System.Drawing.Point(1051, 4);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(70, 32);
      this.btCancelar.TabIndex = 12;
      this.btCancelar.Text = "Cerrar";
      this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // dgResults
      // 
      this.dgResults.AllowUserToAddRows = false;
      this.dgResults.AllowUserToDeleteRows = false;
      this.dgResults.AllowUserToResizeColumns = false;
      this.dgResults.AllowUserToResizeRows = false;
      this.dgResults.AutoGenerateColumns = false;
      this.dgResults.CausesValidation = false;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codColecDataGridViewTextBoxColumn,
            this.DescTema,
            this.descGeneDataGridViewTextBoxColumn,
            this.codGrupoDataGridViewTextBoxColumn,
            this.codRefDataGridViewTextBoxColumn,
            this.codArtDataGridViewTextBoxColumn,
            this.ventasDataGridViewTextBoxColumn,
            this.devolucionDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn});
      this.dgResults.DataSource = this.itemRepoArticulosBindingSource;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle7.Format = "N2";
      dataGridViewCellStyle7.NullValue = null;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgResults.DefaultCellStyle = dataGridViewCellStyle7;
      this.dgResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.dgResults.Location = new System.Drawing.Point(2, 110);
      this.dgResults.Name = "dgResults";
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
      this.dgResults.RowHeadersVisible = false;
      this.dgResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.dgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgResults.ShowEditingIcon = false;
      this.dgResults.Size = new System.Drawing.Size(1125, 357);
      this.dgResults.TabIndex = 0;
      this.dgResults.TabStop = false;
      this.dgResults.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgResults_CellBeginEdit);
      this.dgResults.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgResults_DataError);
      // 
      // pnHeader
      // 
      this.pnHeader.Controls.Add(this.label8);
      this.pnHeader.Controls.Add(this.cbTema);
      this.pnHeader.Controls.Add(this.txReferencia);
      this.pnHeader.Controls.Add(this.label7);
      this.pnHeader.Controls.Add(this.udCantidad);
      this.pnHeader.Controls.Add(this.label6);
      this.pnHeader.Controls.Add(this.label5);
      this.pnHeader.Controls.Add(this.cbGrupo);
      this.pnHeader.Controls.Add(this.label4);
      this.pnHeader.Controls.Add(this.cbGenero);
      this.pnHeader.Controls.Add(this.label3);
      this.pnHeader.Controls.Add(this.label1);
      this.pnHeader.Controls.Add(this.dtHoHasta);
      this.pnHeader.Controls.Add(this.dtHoDesde);
      this.pnHeader.Controls.Add(this.cbColeccion);
      this.pnHeader.Controls.Add(this.label2);
      this.pnHeader.Controls.Add(this.btBuscar);
      this.pnHeader.Controls.Add(this.lbDesde);
      this.pnHeader.Controls.Add(this.dtFeDesde);
      this.pnHeader.Controls.Add(this.lbHasta);
      this.pnHeader.Controls.Add(this.dtFeHasta);
      this.pnHeader.Controls.Add(this.btLimpiar);
      this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnHeader.Location = new System.Drawing.Point(2, 2);
      this.pnHeader.Name = "pnHeader";
      this.pnHeader.Size = new System.Drawing.Size(1125, 108);
      this.pnHeader.TabIndex = 0;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(678, 16);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(34, 13);
      this.label8.TabIndex = 101;
      this.label8.Text = "Tema";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbTema
      // 
      this.cbTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTema.FormattingEnabled = true;
      this.cbTema.Location = new System.Drawing.Point(718, 13);
      this.cbTema.Name = "cbTema";
      this.cbTema.Size = new System.Drawing.Size(207, 21);
      this.cbTema.TabIndex = 7;
      // 
      // txReferencia
      // 
      this.txReferencia.Location = new System.Drawing.Point(88, 65);
      this.txReferencia.MaxLength = 11;
      this.txReferencia.Name = "txReferencia";
      this.txReferencia.Size = new System.Drawing.Size(105, 20);
      this.txReferencia.TabIndex = 4;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(200, 68);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(49, 13);
      this.label7.TabIndex = 99;
      this.label7.Text = "Cantidad";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // udCantidad
      // 
      this.udCantidad.Location = new System.Drawing.Point(268, 66);
      this.udCantidad.Name = "udCantidad";
      this.udCantidad.Size = new System.Drawing.Size(105, 20);
      this.udCantidad.TabIndex = 5;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(23, 68);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(59, 13);
      this.label6.TabIndex = 97;
      this.label6.Text = "Referencia";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(676, 48);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(36, 13);
      this.label5.TabIndex = 95;
      this.label5.Text = "Grupo";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbGrupo
      // 
      this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbGrupo.FormattingEnabled = true;
      this.cbGrupo.Location = new System.Drawing.Point(718, 45);
      this.cbGrupo.Name = "cbGrupo";
      this.cbGrupo.Size = new System.Drawing.Size(207, 21);
      this.cbGrupo.TabIndex = 9;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(417, 45);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 13);
      this.label4.TabIndex = 93;
      this.label4.Text = "Género";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cbGenero
      // 
      this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbGenero.FormattingEnabled = true;
      this.cbGenero.Location = new System.Drawing.Point(465, 42);
      this.cbGenero.Name = "cbGenero";
      this.cbGenero.Size = new System.Drawing.Size(207, 21);
      this.cbGenero.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(203, 42);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 13);
      this.label3.TabIndex = 91;
      this.label3.Text = "Hora Hasta";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(20, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(64, 13);
      this.label1.TabIndex = 90;
      this.label1.Text = "Hora Desde";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtHoHasta
      // 
      this.dtHoHasta.CustomFormat = "HH:mm";
      this.dtHoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtHoHasta.Location = new System.Drawing.Point(268, 39);
      this.dtHoHasta.Name = "dtHoHasta";
      this.dtHoHasta.ShowUpDown = true;
      this.dtHoHasta.Size = new System.Drawing.Size(61, 20);
      this.dtHoHasta.TabIndex = 3;
      // 
      // dtHoDesde
      // 
      this.dtHoDesde.CustomFormat = "HH:mm";
      this.dtHoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtHoDesde.Location = new System.Drawing.Point(88, 39);
      this.dtHoDesde.Name = "dtHoDesde";
      this.dtHoDesde.ShowUpDown = true;
      this.dtHoDesde.Size = new System.Drawing.Size(61, 20);
      this.dtHoDesde.TabIndex = 2;
      this.dtHoDesde.Value = new System.DateTime(2014, 6, 12, 16, 56, 0, 0);
      this.dtHoDesde.ValueChanged += new System.EventHandler(this.dtHoDesde_ValueChanged);
      // 
      // cbColeccion
      // 
      this.cbColeccion.CausesValidation = false;
      this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbColeccion.FormattingEnabled = true;
      this.cbColeccion.Location = new System.Drawing.Point(465, 13);
      this.cbColeccion.Name = "cbColeccion";
      this.cbColeccion.Size = new System.Drawing.Size(207, 21);
      this.cbColeccion.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(405, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(54, 13);
      this.label2.TabIndex = 84;
      this.label2.Text = "Colección";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btBuscar
      // 
      this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBuscar.CausesValidation = false;
      this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
      this.btBuscar.Location = new System.Drawing.Point(997, 13);
      this.btBuscar.Name = "btBuscar";
      this.btBuscar.Size = new System.Drawing.Size(112, 53);
      this.btBuscar.TabIndex = 10;
      this.btBuscar.Text = "Buscar";
      this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btBuscar.UseVisualStyleBackColor = true;
      this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
      // 
      // lbDesde
      // 
      this.lbDesde.AutoSize = true;
      this.lbDesde.Location = new System.Drawing.Point(12, 16);
      this.lbDesde.Name = "lbDesde";
      this.lbDesde.Size = new System.Drawing.Size(71, 13);
      this.lbDesde.TabIndex = 63;
      this.lbDesde.Text = "Fecha Desde";
      this.lbDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtFeDesde
      // 
      this.dtFeDesde.CausesValidation = false;
      this.dtFeDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtFeDesde.Location = new System.Drawing.Point(88, 13);
      this.dtFeDesde.Name = "dtFeDesde";
      this.dtFeDesde.Size = new System.Drawing.Size(105, 20);
      this.dtFeDesde.TabIndex = 0;
      this.dtFeDesde.ValueChanged += new System.EventHandler(this.dtFeDesde_ValueChanged);
      // 
      // lbHasta
      // 
      this.lbHasta.AutoSize = true;
      this.lbHasta.Location = new System.Drawing.Point(198, 16);
      this.lbHasta.Name = "lbHasta";
      this.lbHasta.Size = new System.Drawing.Size(68, 13);
      this.lbHasta.TabIndex = 65;
      this.lbHasta.Text = "Fecha Hasta";
      this.lbHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // dtFeHasta
      // 
      this.dtFeHasta.CausesValidation = false;
      this.dtFeHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.dtFeHasta.Location = new System.Drawing.Point(268, 13);
      this.dtFeHasta.Name = "dtFeHasta";
      this.dtFeHasta.Size = new System.Drawing.Size(105, 20);
      this.dtFeHasta.TabIndex = 1;
      // 
      // btLimpiar
      // 
      this.btLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btLimpiar.CausesValidation = false;
      this.btLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
      this.btLimpiar.Location = new System.Drawing.Point(997, 72);
      this.btLimpiar.Name = "btLimpiar";
      this.btLimpiar.Size = new System.Drawing.Size(112, 28);
      this.btLimpiar.TabIndex = 11;
      this.btLimpiar.Text = "Limpiar Criterios";
      this.btLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btLimpiar.UseVisualStyleBackColor = true;
      this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xlsx";
      this.saveFileDialog1.Filter = "Excel|*.xlsx";
      this.saveFileDialog1.Title = "Reposición de Artículos";
      this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
      // 
      // itemRepoArticulosBindingSource
      // 
      this.itemRepoArticulosBindingSource.DataSource = typeof(SEGAN_POS.DAL.ItemRepoArticulos);
      // 
      // codColecDataGridViewTextBoxColumn
      // 
      this.codColecDataGridViewTextBoxColumn.DataPropertyName = "CodColec";
      this.codColecDataGridViewTextBoxColumn.HeaderText = "Colección";
      this.codColecDataGridViewTextBoxColumn.Name = "codColecDataGridViewTextBoxColumn";
      this.codColecDataGridViewTextBoxColumn.Width = 112;
      // 
      // DescTema
      // 
      this.DescTema.DataPropertyName = "DescTema";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.DescTema.DefaultCellStyle = dataGridViewCellStyle2;
      this.DescTema.HeaderText = "Tema";
      this.DescTema.Name = "DescTema";
      this.DescTema.Width = 169;
      // 
      // descGeneDataGridViewTextBoxColumn
      // 
      this.descGeneDataGridViewTextBoxColumn.DataPropertyName = "DescGene";
      this.descGeneDataGridViewTextBoxColumn.HeaderText = "Género";
      this.descGeneDataGridViewTextBoxColumn.Name = "descGeneDataGridViewTextBoxColumn";
      this.descGeneDataGridViewTextBoxColumn.Width = 169;
      // 
      // codGrupoDataGridViewTextBoxColumn
      // 
      this.codGrupoDataGridViewTextBoxColumn.DataPropertyName = "CodGrupo";
      this.codGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
      this.codGrupoDataGridViewTextBoxColumn.Name = "codGrupoDataGridViewTextBoxColumn";
      this.codGrupoDataGridViewTextBoxColumn.Width = 113;
      // 
      // codRefDataGridViewTextBoxColumn
      // 
      this.codRefDataGridViewTextBoxColumn.DataPropertyName = "CodRef";
      this.codRefDataGridViewTextBoxColumn.HeaderText = "Referencia";
      this.codRefDataGridViewTextBoxColumn.Name = "codRefDataGridViewTextBoxColumn";
      this.codRefDataGridViewTextBoxColumn.Width = 105;
      // 
      // codArtDataGridViewTextBoxColumn
      // 
      this.codArtDataGridViewTextBoxColumn.DataPropertyName = "CodArt";
      this.codArtDataGridViewTextBoxColumn.HeaderText = "Código Artículo";
      this.codArtDataGridViewTextBoxColumn.Name = "codArtDataGridViewTextBoxColumn";
      this.codArtDataGridViewTextBoxColumn.Width = 109;
      // 
      // ventasDataGridViewTextBoxColumn
      // 
      this.ventasDataGridViewTextBoxColumn.DataPropertyName = "Ventas";
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle3.Format = "N0";
      this.ventasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
      this.ventasDataGridViewTextBoxColumn.HeaderText = "Ventas";
      this.ventasDataGridViewTextBoxColumn.Name = "ventasDataGridViewTextBoxColumn";
      this.ventasDataGridViewTextBoxColumn.Width = 68;
      // 
      // devolucionDataGridViewTextBoxColumn
      // 
      this.devolucionDataGridViewTextBoxColumn.DataPropertyName = "Devolucion";
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.Format = "N0";
      this.devolucionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
      this.devolucionDataGridViewTextBoxColumn.HeaderText = "Devolución";
      this.devolucionDataGridViewTextBoxColumn.Name = "devolucionDataGridViewTextBoxColumn";
      this.devolucionDataGridViewTextBoxColumn.Width = 78;
      // 
      // totalDataGridViewTextBoxColumn
      // 
      this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.Format = "N0";
      this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
      this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
      this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
      this.totalDataGridViewTextBoxColumn.Width = 79;
      // 
      // precioDataGridViewTextBoxColumn
      // 
      this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle6.Format = "C2";
      this.precioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
      this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
      this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
      // 
      // frmRepoArt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1129, 508);
      this.Controls.Add(this.dgResults);
      this.Controls.Add(this.pnHeader);
      this.Controls.Add(this.pnFooter);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmRepoArt";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Reposición de Artículos";
      this.Activated += new System.EventHandler(this.frmRepoArt_Activated);
      this.Load += new System.EventHandler(this.frmRepoArt_Load);
      this.Shown += new System.EventHandler(this.frmRepoArt_Shown);
      this.pnFooter.ResumeLayout(false);
      this.pnFooter.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
      this.pnHeader.ResumeLayout(false);
      this.pnHeader.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.udCantidad)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.itemRepoArticulosBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnFooter;
    private System.Windows.Forms.Button btExport;
    private System.Windows.Forms.Label lbCantReg;
    private System.Windows.Forms.Button btCancelar;
    private System.Windows.Forms.DataGridView dgResults;
    private System.Windows.Forms.Panel pnHeader;
    private System.Windows.Forms.ComboBox cbColeccion;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btBuscar;
    private System.Windows.Forms.Label lbDesde;
    private System.Windows.Forms.DateTimePicker dtFeDesde;
    private System.Windows.Forms.Label lbHasta;
    private System.Windows.Forms.DateTimePicker dtFeHasta;
    private System.Windows.Forms.Button btLimpiar;
    private System.Windows.Forms.DateTimePicker dtHoDesde;
    private System.Windows.Forms.DateTimePicker dtHoHasta;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cbGenero;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbGrupo;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown udCantidad;
    private System.Windows.Forms.TextBox txReferencia;
    private System.Windows.Forms.BindingSource itemRepoArticulosBindingSource;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.ComboBox cbTema;
    private System.Windows.Forms.DataGridViewTextBoxColumn codColecDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn DescTema;
    private System.Windows.Forms.DataGridViewTextBoxColumn descGeneDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codGrupoDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codRefDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn codArtDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ventasDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn devolucionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
  }
}