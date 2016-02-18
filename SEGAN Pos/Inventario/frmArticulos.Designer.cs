namespace SEGAN_POS
{
    partial class frmArticulos
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxCriterios = new System.Windows.Forms.GroupBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTalla = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTema = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGenero = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbColeccion = new System.Windows.Forms.ComboBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dataGridViewExistenciaTienda = new System.Windows.Forms.DataGridView();
            this.ePKspArticuloConsultarResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbVentas = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerExistencias = new System.ComponentModel.BackgroundWorker();
            this.FotoPequena = new System.Windows.Forms.DataGridViewImageColumn();
            this.codigoReferenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioGravableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioExentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBoxCriterios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistenciaTienda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspArticuloConsultarResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCriterios
            // 
            this.groupBoxCriterios.Controls.Add(this.lbResult);
            this.groupBoxCriterios.Controls.Add(this.label9);
            this.groupBoxCriterios.Controls.Add(this.cbColor);
            this.groupBoxCriterios.Controls.Add(this.label8);
            this.groupBoxCriterios.Controls.Add(this.cbTalla);
            this.groupBoxCriterios.Controls.Add(this.btnLimpiar);
            this.groupBoxCriterios.Controls.Add(this.txtReferencia);
            this.groupBoxCriterios.Controls.Add(this.label5);
            this.groupBoxCriterios.Controls.Add(this.cbTema);
            this.groupBoxCriterios.Controls.Add(this.label2);
            this.groupBoxCriterios.Controls.Add(this.cbGrupo);
            this.groupBoxCriterios.Controls.Add(this.label3);
            this.groupBoxCriterios.Controls.Add(this.label4);
            this.groupBoxCriterios.Controls.Add(this.cbGenero);
            this.groupBoxCriterios.Controls.Add(this.label6);
            this.groupBoxCriterios.Controls.Add(this.cbColeccion);
            this.groupBoxCriterios.Controls.Add(this.btBuscar);
            this.groupBoxCriterios.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCriterios.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCriterios.Name = "groupBoxCriterios";
            this.groupBoxCriterios.Size = new System.Drawing.Size(1189, 120);
            this.groupBoxCriterios.TabIndex = 4;
            this.groupBoxCriterios.TabStop = false;
            this.groupBoxCriterios.Text = "Criterios de Búsqueda";
            // 
            // lbResult
            // 
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(658, 76);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(332, 31);
            this.lbResult.TabIndex = 43;
            this.lbResult.Text = "Nro. de Registros.";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbResult.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(386, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Color";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(423, 82);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(216, 21);
            this.cbColor.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(387, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Talla";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTalla
            // 
            this.cbTalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTalla.FormattingEnabled = true;
            this.cbTalla.Location = new System.Drawing.Point(423, 52);
            this.cbTalla.Name = "cbTalla";
            this.cbTalla.Size = new System.Drawing.Size(216, 21);
            this.cbTalla.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::SEGAN_POS.Properties.Resources.eliminar;
            this.btnLimpiar.Location = new System.Drawing.Point(1044, 77);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 28);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar Criterios";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(718, 23);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(216, 20);
            this.txtReferencia.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTema
            // 
            this.cbTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTema.FormattingEnabled = true;
            this.cbTema.Location = new System.Drawing.Point(148, 52);
            this.cbTema.Name = "cbTema";
            this.cbTema.Size = new System.Drawing.Size(216, 21);
            this.cbTema.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Grupo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(423, 21);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(216, 21);
            this.cbGrupo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(653, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Referencia";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Género";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbGenero
            // 
            this.cbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGenero.FormattingEnabled = true;
            this.cbGenero.Location = new System.Drawing.Point(148, 82);
            this.cbGenero.Name = "cbGenero";
            this.cbGenero.Size = new System.Drawing.Size(216, 21);
            this.cbGenero.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Colección";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbColeccion
            // 
            this.cbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColeccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbColeccion.FormattingEnabled = true;
            this.cbColeccion.Location = new System.Drawing.Point(148, 23);
            this.cbColeccion.Name = "cbColeccion";
            this.cbColeccion.Size = new System.Drawing.Size(216, 21);
            this.cbColeccion.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.Image = global::SEGAN_POS.Properties.Resources.buscar;
            this.btBuscar.Location = new System.Drawing.Point(1044, 23);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 53);
            this.btBuscar.TabIndex = 7;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dataGridViewExistenciaTienda
            // 
            this.dataGridViewExistenciaTienda.AllowUserToAddRows = false;
            this.dataGridViewExistenciaTienda.AllowUserToDeleteRows = false;
            this.dataGridViewExistenciaTienda.AllowUserToResizeColumns = false;
            this.dataGridViewExistenciaTienda.AllowUserToResizeRows = false;
            this.dataGridViewExistenciaTienda.AutoGenerateColumns = false;
            this.dataGridViewExistenciaTienda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewExistenciaTienda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FotoPequena,
            this.codigoReferenciaDataGridViewTextBoxColumn,
            this.codigoArticuloDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.precioGravableDataGridViewTextBoxColumn,
            this.precioExentoDataGridViewTextBoxColumn,
            this.existenciaDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn});
            this.dataGridViewExistenciaTienda.DataSource = this.ePKspArticuloConsultarResultBindingSource;
            this.dataGridViewExistenciaTienda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExistenciaTienda.Location = new System.Drawing.Point(0, 120);
            this.dataGridViewExistenciaTienda.Name = "dataGridViewExistenciaTienda";
            this.dataGridViewExistenciaTienda.ReadOnly = true;
            this.dataGridViewExistenciaTienda.RowHeadersVisible = false;
            this.dataGridViewExistenciaTienda.RowHeadersWidth = 80;
            this.dataGridViewExistenciaTienda.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewExistenciaTienda.RowTemplate.Height = 80;
            this.dataGridViewExistenciaTienda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExistenciaTienda.ShowEditingIcon = false;
            this.dataGridViewExistenciaTienda.Size = new System.Drawing.Size(1189, 508);
            this.dataGridViewExistenciaTienda.TabIndex = 5;
            this.dataGridViewExistenciaTienda.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewExistenciaTienda_CellBeginEdit);
            this.dataGridViewExistenciaTienda.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewExistenciaTienda_DataError);
            // 
            // ePKspArticuloConsultarResultBindingSource
            // 
            this.ePKspArticuloConsultarResultBindingSource.DataSource = typeof(SEGAN_POS.DAL.EPK_sp_ArticuloConsultar_Result);
            // 
            // pbVentas
            // 
            this.pbVentas.Image = global::SEGAN_POS.Properties.Resources.progreso;
            this.pbVentas.Location = new System.Drawing.Point(540, 307);
            this.pbVentas.Name = "pbVentas";
            this.pbVentas.Size = new System.Drawing.Size(72, 70);
            this.pbVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVentas.TabIndex = 6;
            this.pbVentas.TabStop = false;
            this.pbVentas.Visible = false;
            this.pbVentas.WaitOnLoad = true;
            // 
            // backgroundWorkerExistencias
            // 
            this.backgroundWorkerExistencias.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExistencias_DoWork);
            this.backgroundWorkerExistencias.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExistencias_RunWorkerCompleted);
            // 
            // FotoPequena
            // 
            this.FotoPequena.DataPropertyName = "FotoPequena";
            this.FotoPequena.HeaderText = "Foto";
            this.FotoPequena.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.FotoPequena.Name = "FotoPequena";
            this.FotoPequena.ReadOnly = true;
            // 
            // codigoReferenciaDataGridViewTextBoxColumn
            // 
            this.codigoReferenciaDataGridViewTextBoxColumn.DataPropertyName = "CodigoReferencia";
            this.codigoReferenciaDataGridViewTextBoxColumn.HeaderText = "Referencia";
            this.codigoReferenciaDataGridViewTextBoxColumn.Name = "codigoReferenciaDataGridViewTextBoxColumn";
            this.codigoReferenciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoReferenciaDataGridViewTextBoxColumn.Width = 120;
            // 
            // codigoArticuloDataGridViewTextBoxColumn
            // 
            this.codigoArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodigoArticulo";
            this.codigoArticuloDataGridViewTextBoxColumn.HeaderText = "Codigo de Artículo";
            this.codigoArticuloDataGridViewTextBoxColumn.Name = "codigoArticuloDataGridViewTextBoxColumn";
            this.codigoArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.codigoArticuloDataGridViewTextBoxColumn.Width = 130;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 350;
            // 
            // precioGravableDataGridViewTextBoxColumn
            // 
            this.precioGravableDataGridViewTextBoxColumn.DataPropertyName = "PrecioGravable";
            this.precioGravableDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioGravableDataGridViewTextBoxColumn.Name = "precioGravableDataGridViewTextBoxColumn";
            this.precioGravableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioExentoDataGridViewTextBoxColumn
            // 
            this.precioExentoDataGridViewTextBoxColumn.DataPropertyName = "PrecioExento";
            this.precioExentoDataGridViewTextBoxColumn.HeaderText = "Precio Exento";
            this.precioExentoDataGridViewTextBoxColumn.Name = "precioExentoDataGridViewTextBoxColumn";
            this.precioExentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // existenciaDataGridViewTextBoxColumn
            // 
            this.existenciaDataGridViewTextBoxColumn.DataPropertyName = "Existencia";
            this.existenciaDataGridViewTextBoxColumn.HeaderText = "Existencia";
            this.existenciaDataGridViewTextBoxColumn.Name = "existenciaDataGridViewTextBoxColumn";
            this.existenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 628);
            this.Controls.Add(this.pbVentas);
            this.Controls.Add(this.dataGridViewExistenciaTienda);
            this.Controls.Add(this.groupBoxCriterios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmArticulos";
            this.Activated += new System.EventHandler(this.frmArticulos_Activated);
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            this.groupBoxCriterios.ResumeLayout(false);
            this.groupBoxCriterios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExistenciaTienda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePKspArticuloConsultarResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCriterios;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTalla;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTema;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGenero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbColeccion;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dataGridViewExistenciaTienda;
        private System.Windows.Forms.BindingSource ePKspArticuloConsultarResultBindingSource;
        private System.Windows.Forms.PictureBox pbVentas;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExistencias;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.DataGridViewImageColumn FotoPequena;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoReferenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioGravableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioExentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn existenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
    }
}