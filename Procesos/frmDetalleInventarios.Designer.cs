namespace SGA.Procesos
{
    partial class frmDetalleInventarios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label16 = new MaterialSkin.Controls.MaterialLabel();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbxSolicito = new System.Windows.Forms.ComboBox();
            this.cbxTipoInventario = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dg_Det_Inventario = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtConteo3 = new System.Windows.Forms.TextBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.txtConteo2 = new System.Windows.Forms.TextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtConteo1 = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.dtp_Caducidad = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cbxEstatus2 = new System.Windows.Forms.ComboBox();
            this.cbxReviso = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMarbete = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgArticulos = new System.Windows.Forms.DataGridView();
            this.mensajes = new System.Messaging.MessageQueue();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marbete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conteo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conteo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conteo3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Auditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Det_Inventario)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.materialLabel4);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.cbxSolicito);
            this.panel1.Controls.Add(this.cbxTipoInventario);
            this.panel1.Location = new System.Drawing.Point(5, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 156);
            this.panel1.TabIndex = 0;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(8, 4);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(131, 22);
            this.txtid.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Depth = 0;
            this.label16.Font = new System.Drawing.Font("Roboto", 11F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(551, 10);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.MouseState = MaterialSkin.MouseState.HOVER;
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(181, 24);
            this.label16.TabIndex = 3;
            this.label16.Text = "I N V E N T A R I O #";
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(115, 84);
            this.dtp.Margin = new System.Windows.Forms.Padding(4);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(196, 22);
            this.dtp.TabIndex = 2;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(15, 82);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(66, 24);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Fecha:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(15, 122);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(79, 24);
            this.materialLabel4.TabIndex = 1;
            this.materialLabel4.Text = "Solicitó:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(357, 82);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(166, 24);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Tipo de Inventario:";
            // 
            // cbxSolicito
            // 
            this.cbxSolicito.FormattingEnabled = true;
            this.cbxSolicito.Location = new System.Drawing.Point(115, 122);
            this.cbxSolicito.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSolicito.Name = "cbxSolicito";
            this.cbxSolicito.Size = new System.Drawing.Size(633, 24);
            this.cbxSolicito.TabIndex = 0;
            // 
            // cbxTipoInventario
            // 
            this.cbxTipoInventario.FormattingEnabled = true;
            this.cbxTipoInventario.Items.AddRange(new object[] {
            "COMPLETO",
            "PARCIAL"});
            this.cbxTipoInventario.Location = new System.Drawing.Point(549, 80);
            this.cbxTipoInventario.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTipoInventario.Name = "cbxTipoInventario";
            this.cbxTipoInventario.Size = new System.Drawing.Size(200, 24);
            this.cbxTipoInventario.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SGA.Properties.Resources.guardar2;
            this.btnGuardar.Location = new System.Drawing.Point(1201, 442);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 62);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dg_Det_Inventario
            // 
            this.dg_Det_Inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Det_Inventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Codigo,
            this.Nombre,
            this.lote,
            this.Caducidad,
            this.Marbete,
            this.Conteo1,
            this.Conteo2,
            this.Conteo3,
            this.Estatus,
            this.Auditor});
            this.dg_Det_Inventario.Location = new System.Drawing.Point(7, 245);
            this.dg_Det_Inventario.Margin = new System.Windows.Forms.Padding(4);
            this.dg_Det_Inventario.Name = "dg_Det_Inventario";
            this.dg_Det_Inventario.RowHeadersWidth = 51;
            this.dg_Det_Inventario.Size = new System.Drawing.Size(1176, 258);
            this.dg_Det_Inventario.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.txtConteo3);
            this.panel2.Controls.Add(this.materialLabel13);
            this.panel2.Controls.Add(this.txtConteo2);
            this.panel2.Controls.Add(this.materialLabel7);
            this.panel2.Controls.Add(this.txtConteo1);
            this.panel2.Controls.Add(this.materialLabel5);
            this.panel2.Controls.Add(this.dtp_Caducidad);
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.cbxEstatus2);
            this.panel2.Controls.Add(this.cbxReviso);
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Controls.Add(this.txtMarbete);
            this.panel2.Controls.Add(this.txtLote);
            this.panel2.Controls.Add(this.txtProducto);
            this.panel2.Controls.Add(this.materialLabel10);
            this.panel2.Controls.Add(this.materialLabel9);
            this.panel2.Controls.Add(this.materialLabel8);
            this.panel2.Controls.Add(this.materialLabel12);
            this.panel2.Controls.Add(this.materialLabel11);
            this.panel2.Controls.Add(this.materialLabel6);
            this.panel2.Location = new System.Drawing.Point(12, 522);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1171, 134);
            this.panel2.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(108, 16);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(207, 22);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtConteo3
            // 
            this.txtConteo3.Location = new System.Drawing.Point(709, 98);
            this.txtConteo3.Margin = new System.Windows.Forms.Padding(4);
            this.txtConteo3.Name = "txtConteo3";
            this.txtConteo3.Size = new System.Drawing.Size(105, 22);
            this.txtConteo3.TabIndex = 16;
            this.txtConteo3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConteo3_KeyDown);
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(600, 98);
            this.materialLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(91, 24);
            this.materialLabel13.TabIndex = 15;
            this.materialLabel13.Text = "Conteo 3:";
            // 
            // txtConteo2
            // 
            this.txtConteo2.Location = new System.Drawing.Point(947, 55);
            this.txtConteo2.Margin = new System.Windows.Forms.Padding(4);
            this.txtConteo2.Name = "txtConteo2";
            this.txtConteo2.Size = new System.Drawing.Size(105, 22);
            this.txtConteo2.TabIndex = 14;
            this.txtConteo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConteo2_KeyDown);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(837, 55);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(91, 24);
            this.materialLabel7.TabIndex = 13;
            this.materialLabel7.Text = "Conteo 2:";
            // 
            // txtConteo1
            // 
            this.txtConteo1.Location = new System.Drawing.Point(709, 55);
            this.txtConteo1.Margin = new System.Windows.Forms.Padding(4);
            this.txtConteo1.Name = "txtConteo1";
            this.txtConteo1.Size = new System.Drawing.Size(105, 22);
            this.txtConteo1.TabIndex = 12;
            this.txtConteo1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConteo1_KeyDown);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(600, 55);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(91, 24);
            this.materialLabel5.TabIndex = 11;
            this.materialLabel5.Text = "Conteo 1:";
            // 
            // dtp_Caducidad
            // 
            this.dtp_Caducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Caducidad.Location = new System.Drawing.Point(709, 14);
            this.dtp_Caducidad.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_Caducidad.Name = "dtp_Caducidad";
            this.dtp_Caducidad.Size = new System.Drawing.Size(97, 22);
            this.dtp_Caducidad.TabIndex = 10;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(597, 14);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(105, 24);
            this.materialLabel3.TabIndex = 9;
            this.materialLabel3.Text = "Caducidad:";
            // 
            // cbxEstatus2
            // 
            this.cbxEstatus2.FormattingEnabled = true;
            this.cbxEstatus2.Items.AddRange(new object[] {
            "Bueno",
            "Regular",
            "Mal"});
            this.cbxEstatus2.Location = new System.Drawing.Point(956, 98);
            this.cbxEstatus2.Margin = new System.Windows.Forms.Padding(4);
            this.cbxEstatus2.Name = "cbxEstatus2";
            this.cbxEstatus2.Size = new System.Drawing.Size(100, 24);
            this.cbxEstatus2.TabIndex = 8;
            // 
            // cbxReviso
            // 
            this.cbxReviso.FormattingEnabled = true;
            this.cbxReviso.Location = new System.Drawing.Point(108, 98);
            this.cbxReviso.Margin = new System.Windows.Forms.Padding(4);
            this.cbxReviso.Name = "cbxReviso";
            this.cbxReviso.Size = new System.Drawing.Size(480, 24);
            this.cbxReviso.TabIndex = 7;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SGA.Properties.Resources.suma1;
            this.btnNuevo.Location = new System.Drawing.Point(1077, 23);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 62);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(108, 57);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(480, 22);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtMarbete
            // 
            this.txtMarbete.Location = new System.Drawing.Point(947, 14);
            this.txtMarbete.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarbete.Name = "txtMarbete";
            this.txtMarbete.Size = new System.Drawing.Size(109, 22);
            this.txtMarbete.TabIndex = 4;
            this.txtMarbete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarbete_KeyDown);
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(483, 14);
            this.txtLote.Margin = new System.Windows.Forms.Padding(4);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(105, 22);
            this.txtLote.TabIndex = 3;
            this.txtLote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLote_KeyDown);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(1038, 4);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(207, 22);
            this.txtProducto.TabIndex = 1;
            this.txtProducto.Visible = false;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyDown);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            this.txtProducto.Leave += new System.EventHandler(this.txtProducto_Leave);
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(848, 98);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(78, 24);
            this.materialLabel10.TabIndex = 0;
            this.materialLabel10.Text = "Estatus:";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(848, 15);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(85, 24);
            this.materialLabel9.TabIndex = 0;
            this.materialLabel9.Text = "Marbete:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(373, 14);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(102, 24);
            this.materialLabel8.TabIndex = 0;
            this.materialLabel8.Text = "Lote/Serie:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(8, 98);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(72, 24);
            this.materialLabel12.TabIndex = 0;
            this.materialLabel12.Text = "Revisó:";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(8, 55);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(84, 24);
            this.materialLabel11.TabIndex = 0;
            this.materialLabel11.Text = "Nombre:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(8, 16);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(92, 24);
            this.materialLabel6.TabIndex = 0;
            this.materialLabel6.Text = "Producto:";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SGA.Properties.Resources.salir_40x40;
            this.btnSalir.Location = new System.Drawing.Point(1201, 594);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(67, 62);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgArticulos
            // 
            this.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulos.Location = new System.Drawing.Point(235, 316);
            this.dgArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.dgArticulos.Name = "dgArticulos";
            this.dgArticulos.RowHeadersWidth = 51;
            this.dgArticulos.Size = new System.Drawing.Size(869, 198);
            this.dgArticulos.TabIndex = 5;
            this.dgArticulos.Visible = false;
            this.dgArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Articulos_CellContentClick);
            this.dgArticulos.DoubleClick += new System.EventHandler(this.Grid_Articulos_DoubleClick);
            // 
            // mensajes
            // 
            this.mensajes.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.mensajes.MessageReadPropertyFilter.LookupId = true;
            this.mensajes.SynchronizingObject = this;
            // 
            // id
            // 
            this.id.HeaderText = "Id Articulo";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 125;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Descripcion Articulo";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 450;
            // 
            // lote
            // 
            this.lote.HeaderText = "Lote";
            this.lote.MinimumWidth = 6;
            this.lote.Name = "lote";
            this.lote.ReadOnly = true;
            this.lote.Width = 125;
            // 
            // Caducidad
            // 
            this.Caducidad.HeaderText = "Caducidad";
            this.Caducidad.MinimumWidth = 6;
            this.Caducidad.Name = "Caducidad";
            this.Caducidad.ReadOnly = true;
            this.Caducidad.Width = 125;
            // 
            // Marbete
            // 
            this.Marbete.HeaderText = "Marbete";
            this.Marbete.MinimumWidth = 6;
            this.Marbete.Name = "Marbete";
            this.Marbete.ReadOnly = true;
            this.Marbete.Width = 75;
            // 
            // Conteo1
            // 
            this.Conteo1.HeaderText = "Conteo #1";
            this.Conteo1.MinimumWidth = 6;
            this.Conteo1.Name = "Conteo1";
            this.Conteo1.ReadOnly = true;
            this.Conteo1.Width = 75;
            // 
            // Conteo2
            // 
            this.Conteo2.HeaderText = "Conteo #2";
            this.Conteo2.MinimumWidth = 6;
            this.Conteo2.Name = "Conteo2";
            this.Conteo2.ReadOnly = true;
            this.Conteo2.Width = 75;
            // 
            // Conteo3
            // 
            this.Conteo3.HeaderText = "Conteo #3";
            this.Conteo3.MinimumWidth = 6;
            this.Conteo3.Name = "Conteo3";
            this.Conteo3.ReadOnly = true;
            this.Conteo3.Width = 75;
            // 
            // Estatus
            // 
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.MinimumWidth = 6;
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 125;
            // 
            // Auditor
            // 
            this.Auditor.HeaderText = "Auditor";
            this.Auditor.MinimumWidth = 6;
            this.Auditor.Name = "Auditor";
            this.Auditor.ReadOnly = true;
            this.Auditor.Width = 125;
            // 
            // frmDetalleInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 689);
            this.Controls.Add(this.dgArticulos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dg_Det_Inventario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDetalleInventarios";
            this.Text = "Conteo 1";
            this.Load += new System.EventHandler(this.frmDetalleInventarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Det_Inventario)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox cbxTipoInventario;
        private System.Windows.Forms.Button btnGuardar;
        private MaterialSkin.Controls.MaterialLabel label16;
        private System.Windows.Forms.DateTimePicker dtp;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dg_Det_Inventario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMarbete;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.TextBox txtProducto;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cbxReviso;
        private System.Windows.Forms.ComboBox cbxEstatus2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridView dgArticulos;
        private System.Windows.Forms.DateTimePicker dtp_Caducidad;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.ComboBox cbxSolicito;
        private System.Windows.Forms.TextBox txtConteo1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.TextBox txtConteo3;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.TextBox txtConteo2;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Messaging.MessageQueue mensajes;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caducidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marbete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conteo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conteo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conteo3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auditor;
    }
}