namespace SGA.Procesos
{
    partial class frmRVDetalleSalidas
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
            this.rvDetalleSalidas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvDetalleSalidas
            // 
            this.rvDetalleSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvDetalleSalidas.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptDetalleSalidas.rdlc";
            this.rvDetalleSalidas.Location = new System.Drawing.Point(0, 0);
            this.rvDetalleSalidas.Margin = new System.Windows.Forms.Padding(4);
            this.rvDetalleSalidas.Name = "rvDetalleSalidas";
            this.rvDetalleSalidas.ServerReport.BearerToken = null;
            this.rvDetalleSalidas.Size = new System.Drawing.Size(1067, 554);
            this.rvDetalleSalidas.TabIndex = 0;
            this.rvDetalleSalidas.Load += new System.EventHandler(this.rvDetalleSalidas_Load);
            // 
            // frmRVDetalleSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvDetalleSalidas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVDetalleSalidas";
            this.Text = "Reporte del Detalle de Salidas";
            this.Load += new System.EventHandler(this.frmRVDetalleSalidas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDetalleSalidas;
    }
}