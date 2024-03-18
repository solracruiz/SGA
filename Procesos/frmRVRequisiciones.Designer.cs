namespace SGA.Procesos
{
    partial class frmRVRequisiciones
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
            this.rvRequisiciones = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvRequisiciones
            // 
            this.rvRequisiciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvRequisiciones.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptRequisiciones.rdlc";
            this.rvRequisiciones.Location = new System.Drawing.Point(0, 0);
            this.rvRequisiciones.Name = "rvRequisiciones";
            this.rvRequisiciones.ServerReport.BearerToken = null;
            this.rvRequisiciones.Size = new System.Drawing.Size(1067, 554);
            this.rvRequisiciones.TabIndex = 0;
            // 
            // frmRVRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvRequisiciones);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRVRequisiciones";
            this.Text = "Reporte de Requisiciones";
            this.Load += new System.EventHandler(this.frmRVRequisiciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvRequisiciones;
    }
}