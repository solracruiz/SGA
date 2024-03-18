namespace SGA.Procesos
{
    partial class frmRVControlados
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
            this.rvControlados = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvControlados
            // 
            this.rvControlados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvControlados.Location = new System.Drawing.Point(0, 0);
            this.rvControlados.Name = "rvControlados";
            this.rvControlados.ServerReport.BearerToken = null;
            this.rvControlados.Size = new System.Drawing.Size(800, 450);
            this.rvControlados.TabIndex = 0;
            // 
            // frmRVControlados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvControlados);
            this.Name = "frmRVControlados";
            this.Text = "Reporte de Productos Controlados";
            this.Load += new System.EventHandler(this.frmRVControlados_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvControlados;
    }
}