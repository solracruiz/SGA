namespace SGA.Catálogos
{
    partial class frmRVCatPartidasE
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
            this.rvPartidase = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvPartidase
            // 
            this.rvPartidase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPartidase.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptPartidasE.rdlc";
            this.rvPartidase.Location = new System.Drawing.Point(0, 0);
            this.rvPartidase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvPartidase.Name = "rvPartidase";
            this.rvPartidase.ServerReport.BearerToken = null;
            this.rvPartidase.Size = new System.Drawing.Size(1067, 554);
            this.rvPartidase.TabIndex = 0;
            this.rvPartidase.Load += new System.EventHandler(this.rvPartidase_Load);
            // 
            // frmRVCatPartidasE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvPartidase);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRVCatPartidasE";
            this.Text = "Catálogo de Partidas Estatales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatPartidasE_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPartidase;
    }
}