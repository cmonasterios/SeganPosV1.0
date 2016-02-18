namespace SEGAN_POS
{
    partial class frmComprobanteDeposito
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
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
      this.rvComprobante = new Microsoft.Reporting.WinForms.ReportViewer();
      this.detalleDepositoBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.detalleDepositoBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // rvComprobante
      // 
      this.rvComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
      reportDataSource1.Name = "dsCompDeposito";
      reportDataSource1.Value = this.detalleDepositoBindingSource;
      this.rvComprobante.LocalReport.DataSources.Add(reportDataSource1);
      this.rvComprobante.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Depositos.rptComprobateDeposito.rdlc";
      this.rvComprobante.Location = new System.Drawing.Point(0, 0);
      this.rvComprobante.Name = "rvComprobante";
      this.rvComprobante.Size = new System.Drawing.Size(784, 566);
      this.rvComprobante.TabIndex = 4;
      this.rvComprobante.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.rvComprobante_ReportExport);
      this.rvComprobante.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.rvComprobante_PrintingBegin);
      // 
      // detalleDepositoBindingSource
      // 
      this.detalleDepositoBindingSource.DataSource = typeof(SEGAN_POS.DAL.DetalleDeposito);
      // 
      // frmComprobanteDeposito
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 566);
      this.Controls.Add(this.rvComprobante);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmComprobanteDeposito";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmComprobanteDeposito";
      this.Activated += new System.EventHandler(this.frmComprobanteDeposito_Activated);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComprobanteDeposito_FormClosing);
      this.Load += new System.EventHandler(this.frmComprobanteDeposito_Load);
      ((System.ComponentModel.ISupportInitialize)(this.detalleDepositoBindingSource)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvComprobante;
        private System.Windows.Forms.BindingSource detalleDepositoBindingSource;
    }
}