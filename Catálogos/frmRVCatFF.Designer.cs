namespace SGA.Catálogos
{
    partial class frmRVCatFF
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
            this.rvFF = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvFF
            // 
            this.rvFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvFF.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptFF.rdlc";
            this.rvFF.Location = new System.Drawing.Point(0, 0);
            this.rvFF.Name = "rvFF";
            this.rvFF.ServerReport.BearerToken = null;
            this.rvFF.Size = new System.Drawing.Size(800, 450);
            this.rvFF.TabIndex = 0;
            this.rvFF.Load += new System.EventHandler(this.rvFF_Load);
            // 
            // frmRVCatFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvFF);
            this.Name = "frmRVCatFF";
            this.Text = "Reporte de Fuentes de Financiamiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatFF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFF;
    }
}