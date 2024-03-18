namespace SGA.Herramientas
{
    partial class frmRVUsuarios
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
            this.rvUsuarios = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvUsuarios
            // 
            this.rvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvUsuarios.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptUsuarios.rdlc";
            this.rvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.rvUsuarios.Name = "rvUsuarios";
            this.rvUsuarios.ServerReport.BearerToken = null;
            this.rvUsuarios.Size = new System.Drawing.Size(800, 450);
            this.rvUsuarios.TabIndex = 0;
            // 
            // frmRVUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvUsuarios);
            this.Name = "frmRVUsuarios";
            this.Text = "Reporte de Usuarios del Sistema";
            this.Load += new System.EventHandler(this.frmRVUsuarios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvUsuarios;
    }
}