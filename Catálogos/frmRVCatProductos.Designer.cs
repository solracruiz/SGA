namespace SGA.Catálogos
{
    partial class frmRVCatProductos
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
            this.rvProductos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvProductos
            // 
            this.rvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvProductos.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptProductos.rdlc";
            this.rvProductos.Location = new System.Drawing.Point(0, 0);
            this.rvProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rvProductos.Name = "rvProductos";
            this.rvProductos.ServerReport.BearerToken = null;
            this.rvProductos.Size = new System.Drawing.Size(1067, 554);
            this.rvProductos.TabIndex = 0;
            this.rvProductos.Load += new System.EventHandler(this.rvProductos_Load);
            // 
            // frmRVCatProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvProductos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRVCatProductos";
            this.Text = "frmRVCatProductos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRVCatProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvProductos;
    }
}