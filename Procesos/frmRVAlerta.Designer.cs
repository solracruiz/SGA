﻿namespace SGA.Procesos
{
    partial class FrmRVAlerta
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
            this.rvAlerta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvAlerta
            // 
            this.rvAlerta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvAlerta.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptAlertas.rdlc";
            this.rvAlerta.Location = new System.Drawing.Point(0, 0);
            this.rvAlerta.Margin = new System.Windows.Forms.Padding(4);
            this.rvAlerta.Name = "rvAlerta";
            this.rvAlerta.ServerReport.BearerToken = null;
            this.rvAlerta.Size = new System.Drawing.Size(1067, 554);
            this.rvAlerta.TabIndex = 0;
            // 
            // FrmRVAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.rvAlerta);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRVAlerta";
            this.Text = "Reporte de Productos en Alerta Sanitaria";
            this.Load += new System.EventHandler(this.FrmRVAlerta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvAlerta;
    }
}