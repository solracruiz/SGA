namespace SGA.Catálogos
{
    partial class frmRVCatClues
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
            this.rvClues = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvClues
            // 
            this.rvClues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvClues.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptClues.rdlc";
            this.rvClues.Location = new System.Drawing.Point(0, 0);
            this.rvClues.Margin = new System.Windows.Forms.Padding(4);
            this.rvClues.Name = "rvClues";
            this.rvClues.ServerReport.BearerToken = null;
            this.rvClues.Size = new System.Drawing.Size(1067, 554);
            this.rvClues.TabIndex = 2;
            // 
            // frmRVCatClues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvClues);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVCatClues";
            this.Text = "Reporte de Centros de Clave Única de Establecimientos de Salud";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatClues_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rvClues;
    }
}