namespace SGA.Procesos
{
    partial class frmRVEntradas2
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
            this.rvEntradas2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvEntradas2
            // 
            this.rvEntradas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvEntradas2.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptEntradas2.rdlc";
            this.rvEntradas2.Location = new System.Drawing.Point(0, 0);
            this.rvEntradas2.Name = "rvEntradas2";
            this.rvEntradas2.ServerReport.BearerToken = null;
            this.rvEntradas2.Size = new System.Drawing.Size(1379, 450);
            this.rvEntradas2.TabIndex = 0;
            // 
            // frmRVEntradas2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 450);
            this.Controls.Add(this.rvEntradas2);
            this.Name = "frmRVEntradas2";
            this.Text = "frmRVEntradas2";
            this.Load += new System.EventHandler(this.frmRVEntradas2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEntradas2;
    }
}