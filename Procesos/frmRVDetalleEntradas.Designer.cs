namespace SGA.Procesos
{
    partial class frmRVDetalleEntradas
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
            this.components = new System.ComponentModel.Container();
            this.rvDetalleEntradas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsDetalleEntradas = new SGA.Data_Sources.dsDetalleEntradas();
            this.dsDetalleEntradasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsDetalleEntradas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDetalleEntradasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvDetalleEntradas
            // 
            this.rvDetalleEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvDetalleEntradas.LocalReport.ReportEmbeddedResource = "SGA.RDLC.rptDetalleEntradas.rdlc";
            this.rvDetalleEntradas.Location = new System.Drawing.Point(0, 0);
            this.rvDetalleEntradas.Margin = new System.Windows.Forms.Padding(4);
            this.rvDetalleEntradas.Name = "rvDetalleEntradas";
            this.rvDetalleEntradas.ServerReport.BearerToken = null;
            this.rvDetalleEntradas.Size = new System.Drawing.Size(1319, 596);
            this.rvDetalleEntradas.TabIndex = 0;
            // 
            // dsDetalleEntradas
            // 
            this.dsDetalleEntradas.DataSetName = "dsDetalleEntradas";
            this.dsDetalleEntradas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsDetalleEntradasBindingSource
            // 
            this.dsDetalleEntradasBindingSource.DataSource = this.dsDetalleEntradas;
            this.dsDetalleEntradasBindingSource.Position = 0;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.dsDetalleEntradas;
            // 
            // frmRVDetalleEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 596);
            this.Controls.Add(this.rvDetalleEntradas);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRVDetalleEntradas";
            this.Text = "Reporte del Detalle de Entradas";
            this.Load += new System.EventHandler(this.frmRVDetalleEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsDetalleEntradas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDetalleEntradasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvDetalleEntradas;
        private System.Windows.Forms.BindingSource dsDetalleEntradasBindingSource;
        private Data_Sources.dsDetalleEntradas dsDetalleEntradas;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
    }
}