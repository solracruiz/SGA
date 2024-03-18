namespace SGA.Procesos
{
    partial class frmRVRequisiciones2
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
            this.rvRequisiciones2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvRequisiciones2
            // 
            this.rvRequisiciones2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvRequisiciones2.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptRequisiciones2.rdlc";
            this.rvRequisiciones2.Location = new System.Drawing.Point(0, 0);
            this.rvRequisiciones2.Name = "rvRequisiciones2";
            this.rvRequisiciones2.ServerReport.BearerToken = null;
            this.rvRequisiciones2.Size = new System.Drawing.Size(1067, 554);
            this.rvRequisiciones2.TabIndex = 0;
            // 
            // frmRVRequisiciones2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvRequisiciones2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVRequisiciones2";
            this.Text = "Reporte de Requisiciones";
            this.Load += new System.EventHandler(this.frmRVRequisiciones2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvRequisiciones2;
    }
}