using MySql.Data.MySqlClient;
using SGA.Clases;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Messaging;
using Microsoft.VisualBasic;
using SGA.Administración;

namespace SGA.Procesos
{
    public partial class frmDetallesEntrada : MaterialForm
    {
        int r = 0, idtipo=0;
        int cuadrar = 0;
        float usd = 0;
        Int64 ID_ENT;

        Double TOTAL,SUMA_TOTAL,SUMA_IVA,SUBTOTAL,IVAF;

        string filtro2 = "";

        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        conexion conn5 = new conexion();
        configuracion conf = new configuracion();
        MySqlDataReader R;

        public frmDetallesEntrada()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void Bloquear()
        { 
            cbxTipoEntrada.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            txtnumero_factura.Enabled = false;
            cbxFuente.Enabled = false;
            cbxMoneda.Enabled = false;
            cbxAlmacen.Enabled = false;
            cbxProveedor.Enabled = false;
            cbxRecibio.Enabled = false;

            if (cbxTipoEntrada.Text != "ESPECIE")
            {
                txtimporte.Enabled = false;
                txtiva1.Enabled = false;
                txtsubtotal.Enabled = false;
            }
            txtOrden.Enabled = false;
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            double i = 0, s = 0;
            if (validar() == 0) { return; }
            usd = float.Parse(txtusd.Text.ToString());
            Double Costo_Valor = conf.Convertir_Moneda(txtcosto.Text.ToString());


            Bloquear();

            dgDetalleEntradas.Rows.Insert(r, txtid.Text, txtcodigo.Text, txtnombre.Text, Double.Parse(txtcantidad.Text), Double.Parse(txtprecio.Text), Costo_Valor, Double.Parse(txtiva.Text),txtmarca.Text, txtrequisicion.Text,
           txtlote.Text, txtcaducidad.Text, checkcanje.Checked, usd);
            r = r + 1;
            btnGuardar.Enabled = true;
            
            i = double.Parse(txtiva1.Text.Replace("$", "")) + double.Parse(txtiva.Text.Replace("$", ""));
            txtiva1.Text = i.ToString();
            s = double.Parse(txtsubtotal.Text.Replace("$", "")) + double.Parse(txtcosto.Text.Replace("$", ""));
            txtsubtotal.Text = s.ToString();
            double t = 0;
            t = s + i;
            txtimporte.Text = t.ToString();
            limpiar();
            
            //cargar_det();
            txtid.Focus();
        }

        private void frmDetallesEntrada_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Brown900, Accent.Green700, TextShade.WHITE);

            //mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");

            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(btnGuardar, "Guardar Registro...");

            DateTime dt= DateTime.Now;

            txtcaducidad.Text = String.Format("{0:dd-MM-yyyy}", dt);
            cargar();

            conn.AbrirBD();
            conn1.AbrirBD();
            R = conn.GetData("SELECT usd FROM configuracion;");
            if (R.HasRows)
            {
                R.Read();
                usd = float.Parse(R[0].ToString());
            }
            else
            {
                MessageBox.Show("Error al Cargar eL valor del USD, favor de revisar la configuracion del sistema");
            }
            R.Close();
            cbxTipoEntrada.Focus();

            if (double.Parse(this.Tag.ToString()) >0 )
            {
                Editar(double.Parse(this.Tag.ToString()));
                ID_ENT= Int64.Parse(this.Tag.ToString());
            }

        }

        void Editar( double entrada)
        {
            Boolean canje_ok = false;
            conn.AbrirBD();
            R = conn.GetData("SELECT * FROM entradas where id=" + entrada + ";");
            if (R.HasRows)
            {
                R.Read();
                cbxTipoEntrada.Text = R["tipo"].ToString().ToUpper();
                txtfecha.Text = R["fechaentrada"].ToString().ToUpper();
                txtnumero_factura.Text = R["numfactura"].ToString().ToUpper();
                txtimporte.Text = R["costofactura"].ToString().ToUpper();
                txtOrden.Text = R["orden"].ToString().ToUpper();
                txtRemision.Text = R["remision"].ToString().ToUpper();

                Bloquear();
                R.Close();
                R = conn.GetData("SELECT de.*,a.codigo as codigo,a.nombre as nombre  FROM det_entradas de, cat_articulos a where a.id=de.idarticulo and identrada=" + entrada + ";");
                r = 0;
                if (R.HasRows)
                {
                    while (R.Read())
                    {
                        canje_ok = false;
                        if (R["canje"].ToString() == "0")
                        {
                            canje_ok = true;
                        }
                            dgDetalleEntradas.Rows.Insert(r, R["idarticulo"].ToString(), R["codigo"].ToString(), R["nombre"].ToString(),
                            Double.Parse(R["cantidad"].ToString()), Double.Parse(R["precio"].ToString()),
                            Double.Parse(R["totalprecio"].ToString()), Double.Parse(R["iva"].ToString()),
                            R["marca"].ToString().ToUpper(), R["requisicion"].ToString().ToUpper(),
                            R["lote"].ToString().ToUpper(), String.Format("{0:dd-MM-yyyy}", R["caducidad"].ToString()), canje_ok, R["usd"].ToString());
                            r = r + 1;
                            btnGuardar.Enabled = true;
                    }

                }
                R.Close();
            }
            else
            {
                MessageBox.Show("No existe ese numero de Entrada¡");
                txtid.Focus();
            }
            R.Close();


            conn.cerrarBd();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }
        private void txtid_Leave(object sender, EventArgs e)
        {
            conn.AbrirBD();
            if (txtid.Text.ToString() != "")
            {
                R = conn.GetData("SELECT nombre, tipo FROM cat_articulos where id=" + txtid.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    txtnombre.Text = R[0].ToString().ToUpper();
                    idtipo = Int16.Parse( R[1].ToString());
                }
                else
                {
                    MessageBox.Show("No existe ese numero de articulo¡");
                    txtid.Focus();
                }
                R.Close();
            }
            conn.cerrarBd();
        }

        void cargar()
        {
            DateTime dt = DateTime.Now;

            txtcaducidad.Text = String.Format("{0:dd-MM-yyyy}", dt);
            txtfecha_factura.Text = String.Format("{0:dd-MM-yyyy}", dt); 
            txtfecha.Text = String.Format("{0:dd-MM-yyyy}", dt);
            txtOrden.Text = "0";
            conn2.AbrirBD();
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "id";
            cbxProveedor.DataSource = conn2.GetTable("select id,nombre from cat_proveedores");
            conn2.cerrarBd();
            conn3.AbrirBD();
            cbxRecibio.DisplayMember = "nombre";
            cbxRecibio.ValueMember = "id";
            cbxRecibio.DataSource = conn3.GetTable("select id,nombre from empleados");
            conn3.cerrarBd();
            conn4.AbrirBD();
            cbxAlmacen.DisplayMember = "nombre";
            cbxAlmacen.ValueMember = "id";
            if (configuracion.ID_ALMACEN != 0)
            {
                cbxAlmacen.DataSource = conn4.GetTable("select id,nombre from cat_almacen where id=" + configuracion.ID_ALMACEN);
                cbxAlmacen.Enabled = false;
            }
            else { cbxAlmacen.DataSource = conn4.GetTable("select id,nombre from cat_almacen where id>0"); }
            conn4.cerrarBd();
            conn5.AbrirBD();
            cbxFuente.DisplayMember = "fuente";
            cbxFuente.ValueMember = "id";
            cbxFuente.DataSource = conn5.GetTable("select id,concat(id,' ',descripcion) as fuente from cat_ffinanciamiento");
            conn5.cerrarBd();
        }

        private void frmDetallesEntrada_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.cerrarBd();
            conn1.cerrarBd();
        }
        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            { txtnombre.Enabled = true; }
            else { txtnombre.Enabled = false; }
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == 46)
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        void limpiar()
        {
            txtid.Text = "";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtcantidad.Text = "0";
            txtprecio.Text = "0";
            txtcosto.Text = "0";
            txtiva.Text = "0";
            txtmarca.Text = "";
            txtrequisicion.Text = "";
            txtlote.Text = "";

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (txtnombre.Text == "")
            {
                txtnombre.Enabled = true;
                txtnombre.Text = "";
                txtid.Text = "";
                dgArticulos.Visible = false;
            }
                if (txtnombre.TextLength > 3 && txtcodigo.Text == "")
            {
                conn1.AbrirBD();
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                dgArticulos.DataSource = conn1.GetTable("select Codigo as Clave,Nombre,id as Id_Producto " +
                " from cat_articulos where (nombre like '%" + txtnombre.Text +
                "%' or Codigo like '%" + txtnombre.Text + "%') order by nombre limit 40");
                if (dgArticulos.RowCount < 2)
                {
                    dgArticulos.Visible = false;
                    conn1.cerrarBd();
                    return;
                }
                dgArticulos.AutoResizeColumns();
                
            }
        }

        private void dgArticulos_DoubleClick(object sender, EventArgs e)
        {   
            txtcodigo.Text = dgArticulos.CurrentRow.Cells["Clave"].Value.ToString();
            txtid.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();

            txtnombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            
            dgArticulos.Visible = false;
            txtcodigo.Focus();
            txtnombre.Enabled = false;
            
        }
        private void txtid_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            { txtcantidad.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtnombre.Focus(); }
        }
        int validar()
        {
            if (txtid.Text != "" && txtcodigo.Text != "" && txtcantidad.Text != "" && txtprecio.Text != ""  && txtlote.Text != "" && txtimporte.Text != "" && double.Parse(txtcantidad.Text) > 0 && double.Parse(txtprecio.Text) > 0)
            {
                string cod = "";
                string lot = "";
                for (int fila = 0; fila < dgDetalleEntradas.Rows.Count - 1; fila++)
                {
                    cod = dgDetalleEntradas.Rows[fila].Cells[1].Value.ToString();
                    lot = dgDetalleEntradas.Rows[fila].Cells[9].Value.ToString();

                    if (cod == txtcodigo.Text && lot == txtlote.Text)
                    {
                        MessageBox.Show("No es posible agregar un registro dumplicado en producto y lote¡");
                        return 0;
                    }

                }


                return 1;
            }
            else
            {
                MessageBox.Show("No es posible guardar el registro por datos vacios¡");
                return 0;
            }
        }
        int validar_ent()
        {
            suma_costos();
            if (txtsubtotal.Text== SUMA_TOTAL.ToString())
            { 
                if (txtiva1.Text == SUMA_IVA.ToString())
                {
                    return 1;
                }
            }
            

            if (MessageBox.Show("Los importes de la suma de detalles y el total de la factura no coinciden. Deseas Guardar la Entrada?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                cuadrar = 1;
                ID_ENT = Int64.Parse(this.Tag.ToString());
                return 1;
            }
            return 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                cuadrar = 0;
                double SUMATODO = 0;
                if (validar_ent() == 0)
                {
                    
                     return; 
                }
                Boolean resp;
                conn.AbrirBD();
                conn.inicio();

                if (double.Parse(this.Tag.ToString()) == 0)
                {
                    txtfecha.Text = dt.ToString("yyyy-MM-dd");
                    txtfecha_factura.Text = dt.ToString("yyyy-MM-dd");

                    SUMATODO = SUMA_TOTAL + SUMA_IVA;

                    resp = conn.Executa("insert into entradas (tipo,fechaentrada,numfactura,fechafactura,subtotal,iva,costofactura," +
                    "idproveedor,idfuente,idalmacen,idrecibio,estatus,orden,remision,iduser) values('" +
                    cbxTipoEntrada.Text.ToUpper() + "','" + txtfecha.Text.ToString() + "','" +
                    txtnumero_factura.Text.ToUpper() + "','" + txtfecha_factura.Text + "'," +
                    SUMA_TOTAL + "," + SUMA_IVA + "," + SUMATODO + "," + cbxProveedor.SelectedValue + ",'" +
                    cbxFuente.SelectedValue.ToString() + "'," + cbxAlmacen.SelectedValue + "," + 
                    cbxRecibio.SelectedValue + ",'A','" + txtOrden.Text.ToString() + "','" + txtRemision.Text.ToString() +"'," + configuracion.IDUSER +  ")");
                    //OBTENER ID INVENTARIO
                    if (!resp) { conn.fallo(); return; }
                    R = conn.GetData("SELECT id FROM entradas where tipo='" + cbxTipoEntrada.Text.ToUpper()
                    + "' and fechaentrada='" + dt.ToString("yyyy'-'MM'-'dd", CultureInfo.InvariantCulture)
                    + "' and fechafactura='" + txtfecha_factura.Text
                    + "' and numfactura='" + txtnumero_factura.Text.ToString()
                     + "' and costofactura=" + SUMATODO
                    + " and idproveedor=" + cbxProveedor.SelectedValue + ";");
                    if (R.HasRows)
                    {
                        R.Read();
                        ID_ENT = Int32.Parse(R[0].ToString());
                        label16.Visible = true;
                        label16.Text = "E N T R A D A #" + ID_ENT.ToString();
                    }
                    R.Close();
                }
                resp = grabar_grid();
                if (!resp) { return; }
                resp = conn.Executa("insert into bitacora (fechasis,usuario,motivo,tabla,idtabla) values('"
                + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + configuracion.USER +
                "','ALTA','ENTRADAS'," + ID_ENT + ")");
                if (!resp) { conn.fallo(); return; }
                conn.exito();
                conn.cerrarBd();
                MessageBox.Show("Alta de Entrada al Almacen " + ID_ENT + " Realizada con Exito¡");

                frmRVDetalleEntradas frm = new frmRVDetalleEntradas();
                frm.Tag = ID_ENT;
                frm.ShowDialog();

                pdf();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            }
        }

        void pdf()
        {
            openFileDialog1.InitialDirectory = "C:\\";
            // filtro de archivos.
            openFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";

            // codigo para abrir el cuadro de dialogo
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = openFileDialog1.FileName;
                    textBox1.Text = str_RutaArchivo;
                    MessageBox.Show(textBox1.Text);
                    File.Copy(str_RutaArchivo, "C:\\SIGAL\\PDFS\\ENT_" + ID_ENT + ".PDF");


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void dgDetalleEntradas_DoubleClick(object sender, EventArgs e)
        {
            double i = 0, s = 0;
            if (dgDetalleEntradas.CurrentRow != null)
            {
                

                if (MessageBox.Show("Desea eliminar el registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {


                    txtIVA_Det.Text = dgDetalleEntradas.CurrentRow.Cells[6].Value.ToString();
                    txtSub_Det.Text = dgDetalleEntradas.CurrentRow.Cells[5].Value.ToString();

                    i=  double.Parse(txtiva1.Text.Replace("$", "")) - double.Parse(txtIVA_Det.Text.Replace("$", ""));
                    txtiva1.Text = i.ToString();
                    s = double.Parse(txtsubtotal.Text.Replace("$", "")) - double.Parse(txtSub_Det.Text.Replace("$", ""));
                    txtsubtotal.Text = s.ToString();
                    double t = 0;
                    t = s + i;
                    txtimporte.Text = t.ToString();

                    dgDetalleEntradas.Rows.RemoveAt(dgDetalleEntradas.CurrentRow.Index);
                    r = r - 1;
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (panel2.Enabled == false)

            {
                if (MessageBox.Show("¿Desea cerrar la ventana sin guardar cambios?", "Eliminar Registro", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }

            
        }
        private void txtprecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtmarca.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtcantidad.Focus();
            }
        }

        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtprecio.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtid.Focus();
            }
        }
        private void bt_agregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtid.Focus(); }
        }
        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void txtprecio_Leave(object sender, EventArgs e)
        {
            if (txtcantidad.Text == "") { txtcantidad.Text = "0"; }
            if (txtprecio.Text == "") { txtprecio.Text = "0"; }
            if (modulo1.IsNumeric(txtcantidad.Text.ToString()) && modulo1.IsNumeric(txtprecio.Text.ToString()))
            {
                costo();
            }
        }

        private void txtcantidad_Leave(object sender, EventArgs e)
        {
            if (txtcantidad.Text == "") { txtcantidad.Text = "0"; }
            if (txtprecio.Text == "") { txtprecio.Text = "0"; }
            if (modulo1.IsNumeric(txtcantidad.Text.ToString()) && modulo1.IsNumeric(txtprecio.Text.ToString()))
            {
                costo();
            }
        }
        void costo()
        {
            if (txtcantidad.Text != "" && txtprecio.Text != "")
            {
                if (cbxMoneda.Text.ToString() == "MXN")
                {
                    usd = 1;
                }
                else
                {
                    usd = float.Parse(txtusd.Text.ToString());
                }
                float costo = float.Parse(txtcantidad.Text) * float.Parse(txtprecio.Text) * usd;
                if (idtipo > 0)
                { 
                    float iva1 = float.Parse(costo.ToString()) * configuracion.IVA;
                    txtiva.Text = iva1.ToString();
                }
                else 
                {
                    txtiva.Text = "0";
                }

                
                txtcosto.Text = costo.ToString();
                
                
            }
        }
        private void txtlote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtrequisicion.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtmarca.Focus();
            }
        }
        private void txtmarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtlote.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtprecio.Focus();
            }
        }
        private void txtrequisicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                btnNuevo.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtlote.Focus();
            }
        }
        public string suma_costos()
        {
            string resp = "";
            Double SUMA = 0;
            SUMA_TOTAL = 0;
            SUMA_IVA = 0;
            for (int fila = 0; fila < dgDetalleEntradas.Rows.Count - 1; fila++)
            {
                SUMA_TOTAL = SUMA_TOTAL + double.Parse(dgDetalleEntradas.Rows[fila].Cells[5].Value.ToString()) ;
                SUMA_IVA = SUMA_IVA  + double.Parse(dgDetalleEntradas.Rows[fila].Cells[6].Value.ToString());
            }
            SUMA = SUMA_TOTAL + SUMA_IVA;
            resp = SUMA.ToString();
            return resp;
        }
        
        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
        }
        
        private void cbxMoneda_Leave(object sender, EventArgs e)
        {
            if (cbxMoneda.Text == "USD")
            {
                txtusd.Text = usd.ToString();
                txtusd.Visible = true;
            }
            else
            {
                txtusd.Visible = false;
                txtusd.Text = "1";
            }
        }

        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void cbxMoneda_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void dgDetalleEntradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnumero_factura_KeyPress(object sender, KeyPressEventArgs e)
         {
     
        }

        private void txtimporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == 46)
            { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgDetalleEntradas.CurrentRow.Index != -1)
            {

                if (MessageBox.Show("Desea Editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    txtid.Text= dgDetalleEntradas.CurrentRow.Cells[0].Value.ToString();
                    txtcodigo.Text = dgDetalleEntradas.CurrentRow.Cells[1].Value.ToString();
                    txtnombre.Text = dgDetalleEntradas.CurrentRow.Cells[2].Value.ToString();
                    txtcantidad.Text = dgDetalleEntradas.CurrentRow.Cells[3].Value.ToString();
                    txtprecio.Text = dgDetalleEntradas.CurrentRow.Cells[4].Value.ToString();
                    txtcosto.Text = dgDetalleEntradas.CurrentRow.Cells[5].Value.ToString();
                    txtiva.Text = dgDetalleEntradas.CurrentRow.Cells[6].Value.ToString();
                    txtmarca.Text = dgDetalleEntradas.CurrentRow.Cells[7].Value.ToString();
                    txtrequisicion.Text = dgDetalleEntradas.CurrentRow.Cells[8].Value.ToString();
                    txtlote.Text = dgDetalleEntradas.CurrentRow.Cells[9].Value.ToString();
                    txtcaducidad.Text = String.Format("{0:dd-MM-yyyy}", dgDetalleEntradas.CurrentRow.Cells[10].Value.ToString());
                    dgDetalleEntradas.Rows.RemoveAt(dgDetalleEntradas.CurrentRow.Index);
                    r = r - 1;

                }
            }
        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

            if (txtcodigo.Text == "")
            { 
                txtnombre.Enabled = true;
                txtnombre.Text = "";
                txtid.Text = "";

                dgArticulos.Visible = false;

            }
            else { 
                txtnombre.Enabled = false;
                if (txtcodigo.TextLength > 3)
                {
                    dgArticulos.Visible = true;
                    //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                    dgArticulos.DataSource = conn1.GetTable("select Codigo as Clave, Nombre, id as Id_Producto " +
                    " from cat_articulos where (codigo like '%" + txtcodigo.Text + "%') order by nombre limit 40");
                    if (dgArticulos.RowCount < 2)
                    {
                        dgArticulos.Visible = false;
                        return;
                    }
                    dgArticulos.AutoResizeColumns();
                }
            }


        }
        private void txtcodigo_Leave(object sender, EventArgs e)
        {

            conn.AbrirBD();
            if (txtcodigo.Text.ToString() != "")
            {
                R = conn.GetData("SELECT nombre, iva, id FROM cat_articulos where codigo='" + txtcodigo.Text + "';");
                if (R.HasRows)
                {
                    R.Read();
                    txtnombre.Text = R[0].ToString().ToUpper();
                    idtipo = Int16.Parse(R[1].ToString());
                    txtid.Text = R[2].ToString().ToUpper();
                }
                
                R.Close();
            }
            conn.cerrarBd();
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == 46)
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtcantidad.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtnombre.Focus(); }
        }

        private void cbxTipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtiva1.Enabled = false;
            txtsubtotal.Enabled = false;
            txtimporte.Enabled = false;
            if (cbxTipoEntrada.Text == "ESPECIE")
            {
                materialLabel6.Text = "Orden Sum.:";
                materialLabel23.Visible = true;
                txtRemision.Visible = true;
                txtiva1.Enabled = true;
                txtsubtotal.Enabled = true;
            }
            if (cbxTipoEntrada.Text == "COMPRAS")
            {
                materialLabel6.Text = "Orden Compra:";
                materialLabel23.Visible = true;
                txtRemision.Visible = true;
            }
            if (cbxTipoEntrada.Text == "DONACION")
            {
                materialLabel6.Text = "Orden Don.:";
                materialLabel23.Visible = false;
                txtRemision.Visible = false;
            }

        }


        private void txtsubtotal_Leave(object sender, EventArgs e)
        {
            if (txtsubtotal.Text == "") { txtsubtotal.Text = "0"; }
            if (txtiva1.Text == "") { txtiva1.Text = "0"; }
            double amount = 0.0d;
            if (Double.TryParse(txtsubtotal.Text, NumberStyles.Currency, null, out amount))
            {
                txtsubtotal.Text = amount.ToString("C2");
            }
            SUBTOTAL = Double.Parse(txtsubtotal.Text.Replace("$", ""));

            
            TOTAL = SUBTOTAL +IVAF;
            txtimporte.Text = TOTAL.ToString("C2");
        }
        private void txtiva1_Leave(object sender, EventArgs e)
        {
            
            if (txtsubtotal.Text == "") { txtsubtotal.Text = "0"; }
            if (txtiva1.Text == "") { txtiva1.Text = "0"; }

            double amount = 0.0d;
            if (Double.TryParse(txtiva1.Text, NumberStyles.Currency, null, out amount))
            {
                txtiva1.Text = amount.ToString("C2");
            }
            IVAF = Double.Parse(txtiva1.Text.Replace("$", ""));

            
            TOTAL = SUBTOTAL + IVAF;
            txtimporte.Text = TOTAL.ToString("C2");
        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            if (txtIVA_Det.Text == "") { txtIVA_Det.Text = "0"; }

            double SUBS = 0.0d;
            if (Double.TryParse(txtIVA_Det.Text, NumberStyles.Currency, null, out SUBS))
            {
                txtIVA_Det.Text = SUBS.ToString("C2");
            }
            TOTAL = SUBTOTAL + IVAF;
            txtimporte.Text = TOTAL.ToString("C2");
        }
        private void txtsubtotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == 46)
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void txtiva1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else if (e.KeyChar == 46)
            { e.Handled = false; }
            else { e.Handled = true; }
        }

        private void materialLabel20_Click(object sender, EventArgs e)
        {

        }

        private void txtiva1_TextChanged(object sender, EventArgs e)
        {
            if (txtIVA_Det.Text == "") { txtIVA_Det.Text = "0"; }

            double IVAS = 0.0d;
            if (Double.TryParse(txtIVA_Det.Text, NumberStyles.Currency, null, out IVAS))
            {
                txtIVA_Det.Text = IVAS.ToString("C2");
            }

            TOTAL = SUBTOTAL + IVAF;
            txtimporte.Text = TOTAL.ToString("C2");
        }

        private void txtIVA_Det_Leave(object sender, EventArgs e)
        {

            if (txtIVA_Det.Text == "") { txtIVA_Det.Text = "0"; }

            double amount = 0.0d;
            if (Double.TryParse(txtIVA_Det.Text, NumberStyles.Currency, null, out amount))
            {
                txtIVA_Det.Text = amount.ToString("C2");
            }
        }

        private void txtSub_Det_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSub_Det_Leave(object sender, EventArgs e)
        {

            if (txtSub_Det.Text == "") { txtSub_Det.Text = "0"; }

            double amount = 0.0d;
            if (Double.TryParse(txtSub_Det.Text, NumberStyles.Currency, null, out amount))
            {
                txtSub_Det.Text = amount.ToString("C2");
            }
        }

       

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmarca_TextChanged(object sender, EventArgs e)
        {

        }





        private void txtnumero_factura_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtiva_TextChanged(object sender, EventArgs e)
        {

        }

        Boolean grabar_grid()
        {
            DateTime fec = DateTime.Now;
            int canj = 0;
            String str2 = "",str="";
            double nuevo_costo = 0, nueva_exis = 0, nuevo_iva=0;

            str = "DELETE from det_entradas where identrada=" + ID_ENT;
            if (!conn.Executa(str))
            {
                conn.fallo();
                return false;
            }

            for (int fila = 0; fila < dgDetalleEntradas.Rows.Count - 1; fila++)
            {

                if (dgDetalleEntradas.Rows[fila].Cells[11].Value.ToString() == "true")
                {
                    canj = 1;
                }

                fec = DateTime.Parse(dgDetalleEntradas.Rows[fila].Cells[10].Value.ToString());
                nueva_exis = double.Parse(dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString());
                nuevo_costo = double.Parse(dgDetalleEntradas.Rows[fila].Cells[5].Value.ToString());
                nuevo_iva = double.Parse(dgDetalleEntradas.Rows[fila].Cells[6].Value.ToString());
                str = "insert into det_entradas (identrada,idarticulo," +
                "cantidad,existencia,precio,totalprecio,iva,marca,requisicion,lote,caducidad,canje,usd) " +
                "values(" + ID_ENT + "," +
                dgDetalleEntradas.Rows[fila].Cells[0].Value.ToString() + "," +
                dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() + "," +
                dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() + "," +
                dgDetalleEntradas.Rows[fila].Cells[4].Value.ToString() + "," +
                dgDetalleEntradas.Rows[fila].Cells[5].Value.ToString() + ",'" +
                dgDetalleEntradas.Rows[fila].Cells[6].Value.ToString() + "','" +
                dgDetalleEntradas.Rows[fila].Cells[7].Value.ToString() + "','" +
                dgDetalleEntradas.Rows[fila].Cells[8].Value.ToString() + "','" +
                dgDetalleEntradas.Rows[fila].Cells[9].Value.ToString() + "','" +
                fec.ToString("yyyy-MM-dd") + "'," +
                canj + "," +
                dgDetalleEntradas.Rows[fila].Cells[12].Value.ToString() + ")";
                //MessageBox.Show(str);
                if (!conn.Executa(str))
                {
                    conn.fallo();
                    return false;
                }

                if (cuadrar == 0)
                {



                    //CALCULAR PRECIO 
                    str = "update cat_articulos " +
                    "set precio=((existencia*precio)+" + nuevo_costo + nuevo_iva + ")/(existencia+" + nueva_exis +
                    "), existencia=existencia+" + nueva_exis + " where id=" + dgDetalleEntradas.Rows[fila].Cells[0].Value.ToString();
                    if (!conn.Executa(str))
                    {
                        conn.fallo();
                        return false;
                    }
                    //GUARDAR EN LA TABLA KARDEX EL MOV DE ENTRADA
                    if (cbxTipoEntrada.Text != "COMPRAS")
                    {
                        str = "insert into kardex (idtabla,idarticulo,entrada,salida,precio,costo,iva,fecha,existencia)" +
                        "values(" + ID_ENT + "," +
                        dgDetalleEntradas.Rows[fila].Cells[0].Value.ToString() + "," +
                        dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() + ",0,0,0,0,'" +
                        txtfecha.Text + "',0)";

                        str2 = "update kardex k, cat_articulos a set k.existencia=a.existencia where " +
                        "a.id=k.idarticulo and k.entrada=" + dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() +
                        " and idtabla=" + ID_ENT;
                    }
                    else
                    {
                        str = "insert into kardex (idtabla,idarticulo,entrada,salida,precio,costo,iva,fecha,existencia)" +
                        "values(" + ID_ENT + "," +
                        dgDetalleEntradas.Rows[fila].Cells[0].Value.ToString() + "," +
                        dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() + ",0," +
                        dgDetalleEntradas.Rows[fila].Cells[4].Value.ToString() + "," +
                        dgDetalleEntradas.Rows[fila].Cells[5].Value.ToString() + "," +
                        dgDetalleEntradas.Rows[fila].Cells[6].Value.ToString() + ",'" +
                        txtfecha.Text.ToString() + "',0)";

                        str2 = "update kardex k, cat_articulos a set k.existencia=a.existencia where " +
                        "a.id=k.idarticulo and k.entrada=" + dgDetalleEntradas.Rows[fila].Cells[3].Value.ToString() +
                        " and k.costo=" + nuevo_costo + " and k.iva=" + nuevo_iva + " and k.idtabla=" + ID_ENT;
                    }
                    //MessageBox.Show(str);
                    if (!conn.Executa(str))
                    {
                        conn.fallo();
                        return false;
                    }

                    if (!conn.Executa(str2))
                    {
                        conn.fallo();
                        return false;
                    }
                }
            }
            //Inventario.ActiveForm=true;
            return true;
        }
    }
}

