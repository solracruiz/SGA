namespace SGA.Procesos
{
    partial class frmRVDetalleRequisiciones
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
            this.rvDetalleRequisiciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvDetalleRequisiciones
            // 
            this.rvDetalleRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvDetalleRequisiciones.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptDetalleRequisiciones.rdlc";
            this.rvDetalleRequisiciones.Location = new System.Drawing.Point(0, 0);
            this.rvDetalleRequisiciones.Name = "rvDetalleRequisiciones";
            this.rvDetalleRequisiciones.ServerReport.BearerToken = null;
            this.rvDetalleRequisiciones.Size = new System.Drawing.Size(800, 450);
            this.rvDetalleRequisiciones.TabIndex = 0;
            this.rvDetalleRequisiciones.Load += new System.EventHandler(this.rvDetalleRequisiciones_Load);
            // 
            // frmRVDetalleRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvDetalleRequisiciones);
            this.Name = "frmRVDetalleRequisiciones";
            this.Text = "frmRVDetalleRequisiciones";
            this.Load += new System.EventHandler(this.frmRVDetalleRequisiciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDetalleRequisiciones;
    }
}