namespace SEGAN_POS
{
  partial class frmRepDepositos
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
      Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
      this.DepositosConsultaBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.btCancel = new System.Windows.Forms.Button();
      this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
      ((System.ComponentModel.ISupportInitialize)(this.DepositosConsultaBindingSource)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // DepositosConsultaBindingSource
      // 
      this.DepositosConsultaBindingSource.DataSource = typeof(SEGAN_POS.DAL.DepositosConsulta);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 589);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1016, 43);
      this.panel1.TabIndex = 39;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.btCancel);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(936, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(80, 43);
      this.panel3.TabIndex = 85;
      // 
      // btCancel
      // 
      this.btCancel.CausesValidation = false;
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.Image = global::SEGAN_POS.Properties.Resources.cancelar;
      this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btCancel.Location = new System.Drawing.Point(3, 3);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(70, 33);
      this.btCancel.TabIndex = 37;
      this.btCancel.Text = "Cerrar";
      this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // reportViewer1
      // 
      this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
      reportDataSource2.Name = "DSetDepositos";
      reportDataSource2.Value = this.DepositosConsultaBindingSource;
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
      this.reportViewer1.LocalReport.ReportEmbeddedResource = "SEGAN_POS.Depositos.rptDepositos.rdlc";
      this.reportViewer1.Location = new System.Drawing.Point(0, 0);
      this.reportViewer1.Name = "reportViewer1";
      this.reportViewer1.Size = new System.Drawing.Size(1016, 589);
      this.reportViewer1.TabIndex = 40;
      // 
      // frmRepDepositos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1016, 632);
      this.Controls.Add(this.reportViewer1);
      this.Controls.Add(this.panel1);
      this.MinimizeBox = false;
      this.Name = "frmRepDepositos";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "frmRepDepositos";
      this.Activated += new System.EventHandler(this.frmRepDepositos_Activated);
      this.Load += new System.EventHandler(this.frmRepDepositos_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DepositosConsultaBindingSource)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btCancel;
    private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    private System.Windows.Forms.BindingSource DepositosConsultaBindingSource;
  }
}