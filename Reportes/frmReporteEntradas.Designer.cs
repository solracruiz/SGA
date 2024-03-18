namespace SGA.Reportes
{
    partial class FrmReporteEntradas
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
            this.rvEntradas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvEntradas
            // 
            this.rvEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvEntradas.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptEntradas.rdlc";
            this.rvEntradas.Location = new System.Drawing.Point(0, 0);
            this.rvEntradas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvEntradas.Name = "rvEntradas";
            this.rvEntradas.ServerReport.BearerToken = null;
            this.rvEntradas.Size = new System.Drawing.Size(1067, 554);
            this.rvEntradas.TabIndex = 0;
            // 
            // FrmReporteEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvEntradas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmReporteEntradas";
            this.Text = "Reporte de Entradas";
            this.Load += new System.EventHandler(this.FrmReporteEntradas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEntradas;
    }
}