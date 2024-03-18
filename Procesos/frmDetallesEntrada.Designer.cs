using System.Windows.Forms;

namespace SGA.Procesos
{
    partial class frmDetallesEntrada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRemision = new System.Windows.Forms.TextBox();
            this.materialLabel23 = new MaterialSkin.Controls.MaterialLabel();
            this.txtiva1 = new System.Windows.Forms.TextBox();
            this.materialLabel21 = new MaterialSkin.Controls.MaterialLabel();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.materialLabel20 = new MaterialSkin.Controls.MaterialLabel();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.label16 = new MaterialSkin.Controls.MaterialLabel();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.cbxRecibio = new System.Windows.Forms.ComboBox();
            this.txtnumero_factura = new System.Windows.Forms.TextBox();
            this.cbxFuente = new System.Windows.Forms.ComboBox();
            this.txtimporte = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbxMoneda = new System.Windows.Forms.ComboBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbxTipoEntrada = new System.Windows.Forms.ComboBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.txtfecha_factura = new System.Windows.Forms.TextBox();
            this.dgArticulos = new System.Windows.Forms.DataGridView();
            this.mensajes = new System.Messaging.MessageQueue();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtcosto = new System.Windows.Forms.TextBox();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.txtiva = new System.Windows.Forms.TextBox();
            this.txtmarca = new System.Windows.Forms.TextBox();
            this.txtlote = new System.Windows.Forms.TextBox();
            this.txtcaducidad = new System.Windows.Forms.TextBox();
            this.txtrequisicion = new System.Windows.Forms.TextBox();
            this.checkcanje = new System.Windows.Forms.CheckBox();
            this.txtusd = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIVA_Det = new System.Windows.Forms.TextBox();
            this.materialLabel22 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel24 = new MaterialSkin.Controls.MaterialLabel();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.txtSub_Det = new System.Windows.Forms.TextBox();
            this.materialLabel19 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel25 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.dgDetalleEntradas = new System.Windows.Forms.DataGridView();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requisicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canje = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ValorUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.txtRemision);
            this.panel2.Controls.Add(this.materialLabel23);
            this.panel2.Controls.Add(this.txtiva1);
            this.panel2.Controls.Add(this.materialLabel21);
            this.panel2.Controls.Add(this.txtsubtotal);
            this.panel2.Controls.Add(this.materialLabel20);
            this.panel2.Controls.Add(this.txtOrden);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cbxProveedor);
            this.panel2.Controls.Add(this.cbxAlmacen);
            this.panel2.Controls.Add(this.cbxRecibio);
            this.panel2.Controls.Add(this.txtnumero_factura);
            this.panel2.Controls.Add(this.cbxFuente);
            this.panel2.Controls.Add(this.txtimporte);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.cbxMoneda);
            this.panel2.Controls.Add(this.materialLabel6);
            this.panel2.Controls.Add(this.materialLabel7);
            this.panel2.Controls.Add(this.materialLabel8);
            this.panel2.Controls.Add(this.materialLabel9);
            this.panel2.Controls.Add(this.materialLabel10);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.cbxTipoEntrada);
            this.panel2.Controls.Add(this.materialLabel5);
            this.panel2.Controls.Add(this.materialLabel4);
            this.panel2.Controls.Add(this.materialLabel3);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.txtfecha);
            this.panel2.Controls.Add(this.txtfecha_factura);
            this.panel2.Location = new System.Drawing.Point(16, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1188, 238);
            this.panel2.TabIndex = 0;
            // 
            // txtRemision
            // 
            this.txtRemision.Location = new System.Drawing.Point(573, 172);
            this.txtRemision.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemision.Name = "txtRemision";
            this.txtRemision.Size = new System.Drawing.Size(201, 22);
            this.txtRemision.TabIndex = 13;
            this.txtRemision.Visible = false;
            // 
            // materialLabel23
            // 
            this.materialLabel23.AutoSize = true;
            this.materialLabel23.Depth = 0;
            this.materialLabel23.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel23.Location = new System.Drawing.Point(457, 172);
            this.materialLabel23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel23.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel23.Name = "materialLabel23";
            this.materialLabel23.Size = new System.Drawing.Size(95, 24);
            this.materialLabel23.TabIndex = 22;
            this.materialLabel23.Text = "Remision:";
            this.materialLabel23.Visible = false;
            // 
            // txtiva1
            // 
            this.txtiva1.Enabled = false;
            this.txtiva1.Location = new System.Drawing.Point(211, 172);
            this.txtiva1.Margin = new System.Windows.Forms.Padding(4);
            this.txtiva1.Name = "txtiva1";
            this.txtiva1.Size = new System.Drawing.Size(201, 22);
            this.txtiva1.TabIndex = 6;
            this.txtiva1.Text = "0";
            this.txtiva1.TextChanged += new System.EventHandler(this.txtiva1_TextChanged);
            this.txtiva1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtiva1_KeyPress);
            this.txtiva1.Leave += new System.EventHandler(this.txtiva1_Leave);
            // 
            // materialLabel21
            // 
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel21.Location = new System.Drawing.Point(16, 165);
            this.materialLabel21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Size = new System.Drawing.Size(176, 24);
            this.materialLabel21.TabIndex = 21;
            this.materialLabel21.Text = "IVA Total Factura $:";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Enabled = false;
            this.txtsubtotal.Location = new System.Drawing.Point(211, 141);
            this.txtsubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(201, 22);
            this.txtsubtotal.TabIndex = 5;
            this.txtsubtotal.Text = "0";
            this.txtsubtotal.TextChanged += new System.EventHandler(this.txtsubtotal_TextChanged);
            this.txtsubtotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsubtotal_KeyPress);
            this.txtsubtotal.Leave += new System.EventHandler(this.txtsubtotal_Leave);
            // 
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel20.Location = new System.Drawing.Point(16, 135);
            this.materialLabel20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(174, 24);
            this.materialLabel20.TabIndex = 19;
            this.materialLabel20.Text = "SubTotal Factura $:";
            this.materialLabel20.Click += new System.EventHandler(this.materialLabel20_Click);
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(573, 142);
            this.txtOrden.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(201, 22);
            this.txtOrden.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Depth = 0;
            this.label16.Font = new System.Drawing.Font("Roboto", 11F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(877, 13);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.MouseState = MaterialSkin.MouseState.HOVER;
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(141, 24);
            this.label16.TabIndex = 17;
            this.label16.Text = "# E N T R A D A";
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.ItemHeight = 16;
            this.cbxProveedor.Location = new System.Drawing.Point(573, 48);
            this.cbxProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(591, 24);
            this.cbxProveedor.TabIndex = 9;
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.ItemHeight = 16;
            this.cbxAlmacen.Location = new System.Drawing.Point(1073, 150);
            this.cbxAlmacen.Margin = new System.Windows.Forms.Padding(4);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(91, 24);
            this.cbxAlmacen.TabIndex = 9;
            this.cbxAlmacen.Visible = false;
            this.cbxAlmacen.SelectedIndexChanged += new System.EventHandler(this.cbxAlmacen_SelectedIndexChanged);
            // 
            // cbxRecibio
            // 
            this.cbxRecibio.FormattingEnabled = true;
            this.cbxRecibio.Location = new System.Drawing.Point(573, 110);
            this.cbxRecibio.Margin = new System.Windows.Forms.Padding(4);
            this.cbxRecibio.Name = "cbxRecibio";
            this.cbxRecibio.Size = new System.Drawing.Size(591, 24);
            this.cbxRecibio.TabIndex = 11;
            // 
            // txtnumero_factura
            // 
            this.txtnumero_factura.Location = new System.Drawing.Point(212, 79);
            this.txtnumero_factura.Margin = new System.Windows.Forms.Padding(4);
            this.txtnumero_factura.Name = "txtnumero_factura";
            this.txtnumero_factura.Size = new System.Drawing.Size(201, 22);
            this.txtnumero_factura.TabIndex = 3;
            this.txtnumero_factura.TextChanged += new System.EventHandler(this.txtnumero_factura_TextChanged);
            this.txtnumero_factura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumero_factura_KeyPress);
            // 
            // cbxFuente
            // 
            this.cbxFuente.FormattingEnabled = true;
            this.cbxFuente.Location = new System.Drawing.Point(573, 79);
            this.cbxFuente.Margin = new System.Windows.Forms.Padding(4);
            this.cbxFuente.Name = "cbxFuente";
            this.cbxFuente.Size = new System.Drawing.Size(591, 24);
            this.cbxFuente.TabIndex = 10;
            // 
            // txtimporte
            // 
            this.txtimporte.Enabled = false;
            this.txtimporte.Location = new System.Drawing.Point(211, 203);
            this.txtimporte.Margin = new System.Windows.Forms.Padding(4);
            this.txtimporte.Name = "txtimporte";
            this.txtimporte.Size = new System.Drawing.Size(201, 22);
            this.txtimporte.TabIndex = 7;
            this.txtimporte.Text = "0";
            this.txtimporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtimporte_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(687, 19);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(77, 22);
            this.textBox3.TabIndex = 12;
            // 
            // cbxMoneda
            // 
            this.cbxMoneda.FormattingEnabled = true;
            this.cbxMoneda.ItemHeight = 16;
            this.cbxMoneda.Items.AddRange(new object[] {
            "MXN",
            "USD"});
            this.cbxMoneda.Location = new System.Drawing.Point(573, 17);
            this.cbxMoneda.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMoneda.Name = "cbxMoneda";
            this.cbxMoneda.Size = new System.Drawing.Size(105, 24);
            this.cbxMoneda.TabIndex = 8;
            this.cbxMoneda.Text = "MXN";
            this.cbxMoneda.SelectedIndexChanged += new System.EventHandler(this.cbxMoneda_SelectedIndexChanged_2);
            this.cbxMoneda.Leave += new System.EventHandler(this.cbxMoneda_Leave);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(457, 142);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(108, 24);
            this.materialLabel6.TabIndex = 6;
            this.materialLabel6.Text = "Orden Sum:";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(456, 108);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(79, 24);
            this.materialLabel7.TabIndex = 7;
            this.materialLabel7.Text = "Recibió:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(456, 77);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(72, 24);
            this.materialLabel8.TabIndex = 8;
            this.materialLabel8.Text = "Fuente:";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(456, 46);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(101, 24);
            this.materialLabel9.TabIndex = 9;
            this.materialLabel9.Text = "Proveedor:";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(456, 15);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(84, 24);
            this.materialLabel10.TabIndex = 10;
            this.materialLabel10.Text = "Moneda:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(213, 110);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(201, 22);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(211, 48);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // cbxTipoEntrada
            // 
            this.cbxTipoEntrada.FormattingEnabled = true;
            this.cbxTipoEntrada.Items.AddRange(new object[] {
            "COMPRAS",
            "ESPECIE",
            "DONACION"});
            this.cbxTipoEntrada.Location = new System.Drawing.Point(212, 15);
            this.cbxTipoEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTipoEntrada.Name = "cbxTipoEntrada";
            this.cbxTipoEntrada.Size = new System.Drawing.Size(201, 24);
            this.cbxTipoEntrada.TabIndex = 1;
            this.cbxTipoEntrada.SelectedIndexChanged += new System.EventHandler(this.cbxTipoEntrada_SelectedIndexChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(93, 202);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(88, 24);
            this.materialLabel5.TabIndex = 0;
            this.materialLabel5.Text = "TOTAL $:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(16, 105);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(160, 24);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Fecha de Factura:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(16, 75);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(177, 24);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Número de Factura:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(16, 45);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(161, 24);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Fecha de Entrada:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(16, 15);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(148, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Tipo de Entrada:";
            // 
            // txtfecha
            // 
            this.txtfecha.Location = new System.Drawing.Point(990, 212);
            this.txtfecha.Margin = new System.Windows.Forms.Padding(4);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(193, 22);
            this.txtfecha.TabIndex = 14;
            this.txtfecha.Visible = false;
            // 
            // txtfecha_factura
            // 
            this.txtfecha_factura.Location = new System.Drawing.Point(990, 182);
            this.txtfecha_factura.Margin = new System.Windows.Forms.Padding(4);
            this.txtfecha_factura.Name = "txtfecha_factura";
            this.txtfecha_factura.Size = new System.Drawing.Size(184, 22);
            this.txtfecha_factura.TabIndex = 16;
            this.txtfecha_factura.Visible = false;
            // 
            // dgArticulos
            // 
            this.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulos.Location = new System.Drawing.Point(251, 420);
            this.dgArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.dgArticulos.Name = "dgArticulos";
            this.dgArticulos.RowHeadersWidth = 51;
            this.dgArticulos.Size = new System.Drawing.Size(869, 198);
            this.dgArticulos.TabIndex = 2;
            this.dgArticulos.Visible = false;
            this.dgArticulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgArticulos_CellContentClick);
            this.dgArticulos.DoubleClick += new System.EventHandler(this.dgArticulos_DoubleClick);
            // 
            // mensajes
            // 
            this.mensajes.DefaultPropertiesToSend.HashAlgorithm = System.Messaging.HashAlgorithm.Sha512;
            this.mensajes.MessageReadPropertyFilter.LookupId = true;
            this.mensajes.SynchronizingObject = this;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SGA.Properties.Resources.suma1;
            this.btnNuevo.Location = new System.Drawing.Point(1101, 66);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 62);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::SGA.Properties.Resources.editar_40x40;
            this.btnEditar.Location = new System.Drawing.Point(1236, 374);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 62);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SGA.Properties.Resources.salir_40x40;
            this.btnSalir.Location = new System.Drawing.Point(1236, 697);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(67, 62);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::SGA.Properties.Resources.guardar2;
            this.btnGuardar.Location = new System.Drawing.Point(1236, 544);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(67, 62);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtcosto
            // 
            this.txtcosto.Enabled = false;
            this.txtcosto.Location = new System.Drawing.Point(849, 12);
            this.txtcosto.Margin = new System.Windows.Forms.Padding(4);
            this.txtcosto.Name = "txtcosto";
            this.txtcosto.Size = new System.Drawing.Size(118, 22);
            this.txtcosto.TabIndex = 14;
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(499, 15);
            this.txtprecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(111, 22);
            this.txtprecio.TabIndex = 12;
            this.txtprecio.TextChanged += new System.EventHandler(this.txtprecio_TextChanged);
            this.txtprecio.Leave += new System.EventHandler(this.txtprecio_Leave);
            // 
            // txtiva
            // 
            this.txtiva.Enabled = false;
            this.txtiva.Location = new System.Drawing.Point(687, 15);
            this.txtiva.Margin = new System.Windows.Forms.Padding(4);
            this.txtiva.Name = "txtiva";
            this.txtiva.Size = new System.Drawing.Size(71, 22);
            this.txtiva.TabIndex = 13;
            this.txtiva.TextChanged += new System.EventHandler(this.txtiva_TextChanged);
            // 
            // txtmarca
            // 
            this.txtmarca.Location = new System.Drawing.Point(849, 65);
            this.txtmarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.Size = new System.Drawing.Size(118, 22);
            this.txtmarca.TabIndex = 17;
            this.txtmarca.TextChanged += new System.EventHandler(this.txtmarca_TextChanged);
            this.txtmarca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmarca_KeyDown);
            // 
            // txtlote
            // 
            this.txtlote.Location = new System.Drawing.Point(687, 65);
            this.txtlote.Margin = new System.Windows.Forms.Padding(4);
            this.txtlote.Name = "txtlote";
            this.txtlote.Size = new System.Drawing.Size(71, 22);
            this.txtlote.TabIndex = 16;
            this.txtlote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlote_KeyDown);
            // 
            // txtcaducidad
            // 
            this.txtcaducidad.Location = new System.Drawing.Point(1092, 12);
            this.txtcaducidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtcaducidad.Name = "txtcaducidad";
            this.txtcaducidad.Size = new System.Drawing.Size(91, 22);
            this.txtcaducidad.TabIndex = 15;
            // 
            // txtrequisicion
            // 
            this.txtrequisicion.Location = new System.Drawing.Point(733, 104);
            this.txtrequisicion.Margin = new System.Windows.Forms.Padding(4);
            this.txtrequisicion.Name = "txtrequisicion";
            this.txtrequisicion.Size = new System.Drawing.Size(88, 22);
            this.txtrequisicion.TabIndex = 18;
            this.txtrequisicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtrequisicion_KeyDown);
            // 
            // checkcanje
            // 
            this.checkcanje.AutoSize = true;
            this.checkcanje.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkcanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkcanje.Location = new System.Drawing.Point(865, 100);
            this.checkcanje.Margin = new System.Windows.Forms.Padding(4);
            this.checkcanje.Name = "checkcanje";
            this.checkcanje.Size = new System.Drawing.Size(102, 26);
            this.checkcanje.TabIndex = 19;
            this.checkcanje.Text = "C. Canje";
            this.checkcanje.UseVisualStyleBackColor = true;
            // 
            // txtusd
            // 
            this.txtusd.Location = new System.Drawing.Point(1226, 664);
            this.txtusd.Margin = new System.Windows.Forms.Padding(4);
            this.txtusd.Name = "txtusd";
            this.txtusd.Size = new System.Drawing.Size(68, 22);
            this.txtusd.TabIndex = 19;
            this.txtusd.Text = "1";
            this.txtusd.Visible = false;
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(117, 66);
            this.txtnombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(492, 22);
            this.txtnombre.TabIndex = 20;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(328, 15);
            this.txtcantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(69, 22);
            this.txtcantidad.TabIndex = 11;
            this.txtcantidad.TextChanged += new System.EventHandler(this.txtcantidad_TextChanged);
            this.txtcantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcantidad_KeyDown);
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            this.txtcantidad.Leave += new System.EventHandler(this.txtcantidad_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtIVA_Det);
            this.panel1.Controls.Add(this.materialLabel22);
            this.panel1.Controls.Add(this.materialLabel24);
            this.panel1.Controls.Add(this.txtcodigo);
            this.panel1.Controls.Add(this.txtSub_Det);
            this.panel1.Controls.Add(this.materialLabel19);
            this.panel1.Controls.Add(this.materialLabel25);
            this.panel1.Controls.Add(this.txtcosto);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.txtiva);
            this.panel1.Controls.Add(this.materialLabel16);
            this.panel1.Controls.Add(this.txtcantidad);
            this.panel1.Controls.Add(this.materialLabel15);
            this.panel1.Controls.Add(this.txtnombre);
            this.panel1.Controls.Add(this.materialLabel14);
            this.panel1.Controls.Add(this.materialLabel13);
            this.panel1.Controls.Add(this.materialLabel12);
            this.panel1.Controls.Add(this.txtlote);
            this.panel1.Controls.Add(this.txtcaducidad);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.txtmarca);
            this.panel1.Controls.Add(this.txtrequisicion);
            this.panel1.Controls.Add(this.checkcanje);
            this.panel1.Controls.Add(this.materialLabel18);
            this.panel1.Controls.Add(this.materialLabel17);
            this.panel1.Controls.Add(this.materialLabel11);
            this.panel1.Controls.Add(this.txtprecio);
            this.panel1.Location = new System.Drawing.Point(16, 626);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 133);
            this.panel1.TabIndex = 22;
            // 
            // txtIVA_Det
            // 
            this.txtIVA_Det.Enabled = false;
            this.txtIVA_Det.Location = new System.Drawing.Point(418, 107);
            this.txtIVA_Det.Margin = new System.Windows.Forms.Padding(4);
            this.txtIVA_Det.Name = "txtIVA_Det";
            this.txtIVA_Det.Size = new System.Drawing.Size(193, 22);
            this.txtIVA_Det.TabIndex = 25;
            this.txtIVA_Det.Text = "0";
            this.txtIVA_Det.Visible = false;
            this.txtIVA_Det.Leave += new System.EventHandler(this.txtIVA_Det_Leave);
            // 
            // materialLabel22
            // 
            this.materialLabel22.AutoSize = true;
            this.materialLabel22.Depth = 0;
            this.materialLabel22.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel22.Location = new System.Drawing.Point(779, 12);
            this.materialLabel22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel22.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel22.Name = "materialLabel22";
            this.materialLabel22.Size = new System.Drawing.Size(65, 24);
            this.materialLabel22.TabIndex = 28;
            this.materialLabel22.Text = "Costo:";
            // 
            // materialLabel24
            // 
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel24.Location = new System.Drawing.Point(350, 105);
            this.materialLabel24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel24.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.Size = new System.Drawing.Size(60, 24);
            this.materialLabel24.TabIndex = 27;
            this.materialLabel24.Text = "IVA $:";
            this.materialLabel24.Visible = false;
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(117, 16);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(112, 22);
            this.txtcodigo.TabIndex = 26;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            this.txtcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodigo_KeyDown);
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            this.txtcodigo.Leave += new System.EventHandler(this.txtcodigo_Leave);
            // 
            // txtSub_Det
            // 
            this.txtSub_Det.Enabled = false;
            this.txtSub_Det.Location = new System.Drawing.Point(118, 107);
            this.txtSub_Det.Margin = new System.Windows.Forms.Padding(4);
            this.txtSub_Det.Name = "txtSub_Det";
            this.txtSub_Det.Size = new System.Drawing.Size(152, 22);
            this.txtSub_Det.TabIndex = 24;
            this.txtSub_Det.Text = "0";
            this.txtSub_Det.Visible = false;
            this.txtSub_Det.TextChanged += new System.EventHandler(this.txtSub_Det_TextChanged);
            this.txtSub_Det.Leave += new System.EventHandler(this.txtSub_Det_Leave);
            // 
            // materialLabel19
            // 
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel19.Location = new System.Drawing.Point(619, 14);
            this.materialLabel19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Size = new System.Drawing.Size(39, 24);
            this.materialLabel19.TabIndex = 25;
            this.materialLabel19.Text = "IVA";
            // 
            // materialLabel25
            // 
            this.materialLabel25.AutoSize = true;
            this.materialLabel25.Depth = 0;
            this.materialLabel25.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel25.Location = new System.Drawing.Point(9, 107);
            this.materialLabel25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel25.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel25.Name = "materialLabel25";
            this.materialLabel25.Size = new System.Drawing.Size(101, 24);
            this.materialLabel25.TabIndex = 26;
            this.materialLabel25.Text = "SubTotal$:";
            this.materialLabel25.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(965, 42);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 22);
            this.textBox1.TabIndex = 24;
            this.textBox1.Visible = false;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(1073, 38);
            this.txtid.Margin = new System.Windows.Forms.Padding(4);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(112, 22);
            this.txtid.TabIndex = 10;
            this.txtid.Visible = false;
            this.txtid.TextChanged += new System.EventHandler(this.txtid_TextChanged);
            this.txtid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtid_KeyDown);
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtid_KeyPress);
            this.txtid.Leave += new System.EventHandler(this.txtid_Leave);
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(619, 105);
            this.materialLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(109, 24);
            this.materialLabel16.TabIndex = 0;
            this.materialLabel16.Text = "Requisición";
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(619, 64);
            this.materialLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(52, 24);
            this.materialLabel15.TabIndex = 0;
            this.materialLabel15.Text = "Lote:";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(779, 64);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(63, 24);
            this.materialLabel14.TabIndex = 0;
            this.materialLabel14.Text = "Marca";
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(397, 14);
            this.materialLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(86, 24);
            this.materialLabel13.TabIndex = 0;
            this.materialLabel13.Text = "Precio U.";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(231, 14);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(85, 24);
            this.materialLabel12.TabIndex = 0;
            this.materialLabel12.Text = "Cantidad";
            // 
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel18.Location = new System.Drawing.Point(979, 10);
            this.materialLabel18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(100, 24);
            this.materialLabel18.TabIndex = 0;
            this.materialLabel18.Text = "Caducidad";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(9, 65);
            this.materialLabel17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(84, 24);
            this.materialLabel17.TabIndex = 0;
            this.materialLabel17.Text = "Nombre:";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(7, 14);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(92, 24);
            this.materialLabel11.TabIndex = 0;
            this.materialLabel11.Text = "Producto:";
            // 
            // dgDetalleEntradas
            // 
            this.dgDetalleEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Clave,
            this.Descripcion,
            this.cantidad,
            this.precio_u,
            this.costo_u,
            this.iva,
            this.marca,
            this.requisicion,
            this.lote,
            this.caducidad,
            this.canje,
            this.ValorUSD});
            this.dgDetalleEntradas.Location = new System.Drawing.Point(13, 356);
            this.dgDetalleEntradas.Margin = new System.Windows.Forms.Padding(4);
            this.dgDetalleEntradas.Name = "dgDetalleEntradas";
            this.dgDetalleEntradas.ReadOnly = true;
            this.dgDetalleEntradas.RowHeadersWidth = 51;
            this.dgDetalleEntradas.Size = new System.Drawing.Size(1191, 250);
            this.dgDetalleEntradas.TabIndex = 23;
            this.dgDetalleEntradas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetalleEntradas_CellContentClick);
            this.dgDetalleEntradas.DoubleClick += new System.EventHandler(this.dgDetalleEntradas_DoubleClick);
            // 
            // Articulo
            // 
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Articulo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.MinimumWidth = 6;
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Articulo.Visible = false;
            this.Articulo.Width = 75;
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.MinimumWidth = 6;
            this.Clave.Name = "Clave";
            this.Clave.ReadOnly = true;
            this.Clave.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 150;
            // 
            // cantidad
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 75;
            // 
            // precio_u
            // 
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "$0.00";
            this.precio_u.DefaultCellStyle = dataGridViewCellStyle3;
            this.precio_u.HeaderText = "Precio";
            this.precio_u.MinimumWidth = 6;
            this.precio_u.Name = "precio_u";
            this.precio_u.ReadOnly = true;
            this.precio_u.Width = 125;
            // 
            // costo_u
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "$0.00";
            this.costo_u.DefaultCellStyle = dataGridViewCellStyle4;
            this.costo_u.HeaderText = "Costo";
            this.costo_u.MinimumWidth = 6;
            this.costo_u.Name = "costo_u";
            this.costo_u.ReadOnly = true;
            this.costo_u.Width = 125;
            // 
            // iva
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = "$0.00";
            this.iva.DefaultCellStyle = dataGridViewCellStyle5;
            this.iva.HeaderText = "IVA";
            this.iva.MinimumWidth = 6;
            this.iva.Name = "iva";
            this.iva.ReadOnly = true;
            this.iva.Width = 75;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.MinimumWidth = 6;
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            this.marca.Width = 125;
            // 
            // requisicion
            // 
            this.requisicion.HeaderText = "Requisicion";
            this.requisicion.MinimumWidth = 6;
            this.requisicion.Name = "requisicion";
            this.requisicion.ReadOnly = true;
            this.requisicion.Width = 125;
            // 
            // lote
            // 
            this.lote.HeaderText = "Lote";
            this.lote.MinimumWidth = 6;
            this.lote.Name = "lote";
            this.lote.ReadOnly = true;
            this.lote.Width = 125;
            // 
            // caducidad
            // 
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.caducidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.caducidad.HeaderText = "Caducidad";
            this.caducidad.MinimumWidth = 6;
            this.caducidad.Name = "caducidad";
            this.caducidad.ReadOnly = true;
            this.caducidad.Width = 125;
            // 
            // canje
            // 
            this.canje.HeaderText = "Canje";
            this.canje.MinimumWidth = 6;
            this.canje.Name = "canje";
            this.canje.ReadOnly = true;
            this.canje.Width = 125;
            // 
            // ValorUSD
            // 
            this.ValorUSD.HeaderText = "dolar";
            this.ValorUSD.MinimumWidth = 6;
            this.ValorUSD.Name = "ValorUSD";
            this.ValorUSD.ReadOnly = true;
            this.ValorUSD.Width = 125;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // frmDetallesEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 771);
            this.Controls.Add(this.dgArticulos);
            this.Controls.Add(this.dgDetalleEntradas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtusd);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDetallesEntrada";
            this.Text = "Detalles de Entrada de Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDetallesEntrada_FormClosing);
            this.Load += new System.EventHandler(this.frmDetallesEntrada_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleEntradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.ComboBox cbxAlmacen;
        private System.Windows.Forms.ComboBox cbxRecibio;
        private System.Windows.Forms.ComboBox cbxFuente;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cbxMoneda;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbxTipoEntrada;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.DataGridView dgArticulos;
        private System.Messaging.MessageQueue mensajes;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtfecha_factura;
        private System.Windows.Forms.TextBox txtcosto;
        private System.Windows.Forms.CheckBox checkcanje;
        private System.Windows.Forms.TextBox txtrequisicion;
        private System.Windows.Forms.TextBox txtcaducidad;
        private System.Windows.Forms.TextBox txtlote;
        private System.Windows.Forms.TextBox txtmarca;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.TextBox txtiva;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtusd;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.TextBox txtcantidad;
        private MaterialSkin.Controls.MaterialLabel label16;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridView dgDetalleEntradas;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel19;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.TextBox txtnumero_factura;
        private System.Windows.Forms.TextBox txtiva1;
        private MaterialSkin.Controls.MaterialLabel materialLabel21;
        private System.Windows.Forms.TextBox txtsubtotal;
        private MaterialSkin.Controls.MaterialLabel materialLabel20;
        private MaterialSkin.Controls.MaterialLabel materialLabel22;
        private TextBox txtRemision;
        private MaterialSkin.Controls.MaterialLabel materialLabel23;
        private TextBox txtIVA_Det;
        private MaterialSkin.Controls.MaterialLabel materialLabel24;
        private TextBox txtSub_Det;
        private MaterialSkin.Controls.MaterialLabel materialLabel25;
        private DataGridViewTextBoxColumn Articulo;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn Descripcion;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precio_u;
        private DataGridViewTextBoxColumn costo_u;
        private DataGridViewTextBoxColumn iva;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn requisicion;
        private DataGridViewTextBoxColumn lote;
        private DataGridViewTextBoxColumn caducidad;
        private DataGridViewCheckBoxColumn canje;
        private DataGridViewTextBoxColumn ValorUSD;
    }
}