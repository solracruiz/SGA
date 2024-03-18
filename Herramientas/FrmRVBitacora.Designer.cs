namespace SGA.Herramientas
{
    partial class FrmRVBitacora
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
            this.rvBitacora = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvBitacora
            // 
            this.rvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvBitacora.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptBitacora.rdlc";
            this.rvBitacora.Location = new System.Drawing.Point(0, 0);
            this.rvBitacora.Name = "rvBitacora";
            this.rvBitacora.ServerReport.BearerToken = null;
            this.rvBitacora.Size = new System.Drawing.Size(800, 450);
            this.rvBitacora.TabIndex = 0;
            // 
            // FrmRVBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvBitacora);
            this.Name = "FrmRVBitacora";
            this.Text = "Reporte de Bitácora de Acceso de Usuarios";
            this.Load += new System.EventHandler(this.FrmRVBitacora_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvBitacora;
    }
}