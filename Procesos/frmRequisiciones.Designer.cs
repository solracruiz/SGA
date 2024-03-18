namespace SGA.Procesos
{
    partial class FrmRequisiciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRequisiciones));
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.mensajes = new System.Messaging.MessageQueue();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnValidar = new System.Windows.Forms.Button();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.dgArticulos = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id_det = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_art = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRequisiciones = new System.Windows.Forms.DataGridView();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.BtnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(128, 143);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(355, 22);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(124, 121);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(174, 24);
            this.materialLabel4.TabIndex = 1;
            this.materialLabel4.Text = "Filtro de Busqueda:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SGA.Properties.Resources.Requi2;
            this.pictureBox2.Location = new System.Drawing.Point(10, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 100);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(525, 119);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(36, 24);
            this.materialLabel5.TabIndex = 1;
            this.materialLabel5.Text = "de:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(755, 119);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(25, 24);
            this.materialLabel6.TabIndex = 1;
            this.materialLabel6.Text = "a:";
            // 
            // mensajes
            // 
            this.mensajes.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.mensajes.MessageReadPropertyFilter.LookupId = true;
            this.mensajes.SynchronizingObject = this;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Image = global::SGA.Properties.Resources.suma1;
            this.BtnNuevo.Location = new System.Drawing.Point(941, 190);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(50, 50);
            this.BtnNuevo.TabIndex = 48;
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnValidar
            // 
            this.BtnValidar.Image = global::SGA.Properties.Resources.ok_40x40;
            this.BtnValidar.Location = new System.Drawing.Point(433, 573);
            this.BtnValidar.Name = "BtnValidar";
            this.BtnValidar.Size = new System.Drawing.Size(50, 50);
            this.BtnValidar.TabIndex = 50;
            this.BtnValidar.UseVisualStyleBackColor = true;
            this.BtnValidar.Visible = false;
            this.BtnValidar.Click += new System.EventHandler(this.BtnValidar_Click);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = global::SGA.Properties.Resources.impresora_40x40;
            this.BtnImprimir.Location = new System.Drawing.Point(941, 358);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(50, 50);
            this.BtnImprimir.TabIndex = 51;
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Image = global::SGA.Properties.Resources.salir_40x40;
            this.BtnSalir.Location = new System.Drawing.Point(941, 437);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(50, 50);
            this.BtnSalir.TabIndex = 52;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // dgArticulos
            // 
            this.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.nombre,
            this.cantidad,
            this.validar,
            this.id_det,
            this.id_art});
            this.dgArticulos.Location = new System.Drawing.Point(102, 229);
            this.dgArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.dgArticulos.Name = "dgArticulos";
            this.dgArticulos.RowHeadersWidth = 51;
            this.dgArticulos.Size = new System.Drawing.Size(662, 337);
            this.dgArticulos.TabIndex = 54;
            this.dgArticulos.Visible = false;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 120;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Descripcion";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 400;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 60;
            // 
            // validar
            // 
            this.validar.HeaderText = " ";
            this.validar.MinimumWidth = 6;
            this.validar.Name = "validar";
            this.validar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.validar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.validar.Width = 20;
            // 
            // id_det
            // 
            this.id_det.HeaderText = "iddet";
            this.id_det.MinimumWidth = 6;
            this.id_det.Name = "id_det";
            this.id_det.Visible = false;
            this.id_det.Width = 125;
            // 
            // id_art
            // 
            this.id_art.HeaderText = "id_art";
            this.id_art.MinimumWidth = 6;
            this.id_art.Name = "id_art";
            this.id_art.ReadOnly = true;
            this.id_art.Visible = false;
            this.id_art.Width = 125;
            // 
            // dgRequisiciones
            // 
            this.dgRequisiciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequisiciones.Location = new System.Drawing.Point(13, 191);
            this.dgRequisiciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgRequisiciones.MultiSelect = false;
            this.dgRequisiciones.Name = "dgRequisiciones";
            this.dgRequisiciones.ReadOnly = true;
            this.dgRequisiciones.RowHeadersWidth = 51;
            this.dgRequisiciones.Size = new System.Drawing.Size(900, 375);
            this.dgRequisiciones.TabIndex = 53;
            this.dgRequisiciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRequisiciones_CellContentClick);
            this.dgRequisiciones.DoubleClick += new System.EventHandler(this.dgRequisiciones_DoubleClick);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEliminar.Location = new System.Drawing.Point(941, 273);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(50, 50);
            this.BtnEliminar.TabIndex = 55;
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(533, 150);
            this.dtp1.Margin = new System.Windows.Forms.Padding(4);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(137, 22);
            this.dtp1.TabIndex = 56;
            this.dtp1.TextChanged += new System.EventHandler(this.dtp1_TextChanged);
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(714, 147);
            this.dtp2.Margin = new System.Windows.Forms.Padding(4);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(137, 22);
            this.dtp2.TabIndex = 57;
            this.dtp2.TextChanged += new System.EventHandler(this.dtp2_TextChanged);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Image = global::SGA.Properties.Resources.eliminar;
            this.BtnCancelar.Location = new System.Drawing.Point(313, 573);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(50, 50);
            this.BtnCancelar.TabIndex = 58;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Visible = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // FrmRequisiciones
            // 
            this.ClientSize = new System.Drawing.Size(1036, 635);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.dgArticulos);
            this.Controls.Add(this.dgRequisiciones);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnImprimir);
            this.Controls.Add(this.BtnValidar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtBusqueda);
            this.Name = "FrmRequisiciones";
            this.Text = "Solicitudes de Abasto de Productos";
            this.Load += new System.EventHandler(this.FrmRequisiciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequisiciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgRequifull;
        private System.Windows.Forms.DataGridView dgRequiClue;

        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtBusqueda;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Messaging.MessageQueue mensajes;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.Button BtnValidar;
        private System.Windows.Forms.DataGridView dgArticulos;
        private System.Windows.Forms.DataGridView dgRequisiciones;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn validar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_det;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_art;
        private System.Windows.Forms.Button BtnCancelar;
    }
}