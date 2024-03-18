namespace SGA.Procesos
{
    partial class frmRVDetalleAlertas
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
            this.rvAlertas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvAlertas
            // 
            this.rvAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvAlertas.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptDetalleAlertas.rdlc";
            this.rvAlertas.Location = new System.Drawing.Point(0, 0);
            this.rvAlertas.Name = "rvAlertas";
            this.rvAlertas.ServerReport.BearerToken = null;
            this.rvAlertas.Size = new System.Drawing.Size(800, 450);
            this.rvAlertas.TabIndex = 0;
            // 
            // frmRVDetalleAlertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvAlertas);
            this.Name = "frmRVDetalleAlertas";
            this.Text = "frmRVDetalleAlertas";
            this.Load += new System.EventHandler(this.frmRVDetalleAlertas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvAlertas;
    }
}