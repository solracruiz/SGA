namespace SGA.Procesos
{
    partial class frmRVSalidas
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
            this.rvSalidas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvSalidas
            // 
            this.rvSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvSalidas.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptSalidas.rdlc";
            this.rvSalidas.Location = new System.Drawing.Point(0, 0);
            this.rvSalidas.Margin = new System.Windows.Forms.Padding(4);
            this.rvSalidas.Name = "rvSalidas";
            this.rvSalidas.ServerReport.BearerToken = null;
            this.rvSalidas.Size = new System.Drawing.Size(1067, 554);
            this.rvSalidas.TabIndex = 0;
            // 
            // frmRVSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvSalidas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVSalidas";
            this.Text = "Reporte de Salidas";
            this.Load += new System.EventHandler(this.frmRVSalidas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvSalidas;
    }
}