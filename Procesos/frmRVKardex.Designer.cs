namespace SGA.Procesos
{
    partial class frmRVKardex
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
            this.rvKardex = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvKardex
            // 
            this.rvKardex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvKardex.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptKardex.rdlc";
            this.rvKardex.Location = new System.Drawing.Point(0, 0);
            this.rvKardex.Name = "rvKardex";
            this.rvKardex.ServerReport.BearerToken = null;
            this.rvKardex.Size = new System.Drawing.Size(800, 450);
            this.rvKardex.TabIndex = 0;
            // 
            // frmRVKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvKardex);
            this.Name = "frmRVKardex";
            this.Text = "frmRVKardex";
            this.Load += new System.EventHandler(this.frmRVKardex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvKardex;
    }
}