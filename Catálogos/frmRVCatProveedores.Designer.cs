namespace SGA.Catálogos
{
    partial class frmRVCatProveedores
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
            this.rvProveedores = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvProveedores
            // 
            this.rvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvProveedores.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptProveedores.rdlc";
            this.rvProveedores.Location = new System.Drawing.Point(0, 0);
            this.rvProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.rvProveedores.Name = "rvProveedores";
            this.rvProveedores.ServerReport.BearerToken = null;
            this.rvProveedores.Size = new System.Drawing.Size(1067, 554);
            this.rvProveedores.TabIndex = 0;
            this.rvProveedores.Load += new System.EventHandler(this.rvProveedores_Load);
            // 
            // frmRVCatProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvProveedores);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVCatProveedores";
            this.Text = "Reporte de Proveedores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatProveedores_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvProveedores;
    }
}