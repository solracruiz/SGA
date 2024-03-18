namespace SGA.Catálogos
{
    partial class frmRVCatPartidasF
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
            this.rvPartidasf = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvPartidasf
            // 
            this.rvPartidasf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPartidasf.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptPartidasF.rdlc";
            this.rvPartidasf.Location = new System.Drawing.Point(0, 0);
            this.rvPartidasf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvPartidasf.Name = "rvPartidasf";
            this.rvPartidasf.ServerReport.BearerToken = null;
            this.rvPartidasf.Size = new System.Drawing.Size(1067, 554);
            this.rvPartidasf.TabIndex = 0;
            this.rvPartidasf.Load += new System.EventHandler(this.rvPartidasf_Load);
            // 
            // frmRVCatPartidasF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvPartidasf);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRVCatPartidasF";
            this.Text = "Catálogo de Partidas Federales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatPartidasF_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPartidasf;
    }
}