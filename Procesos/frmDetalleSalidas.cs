using MaterialSkin;
using MaterialSkin.Controls; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Guna.UI2.Native.WinApi;
using SGA.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Management.Instrumentation;

namespace SGA.Procesos
{
    public partial class frmDetalleSalidas : MaterialForm
    {        
        int r = 0;
        Int64 ID_SAL;
        #pragma warning disable CS0169 // El campo 'Det_Salidas.PRECIO' nunca se usa
        Double PRECIO, TOTAL = 0;
        #pragma warning restore CS0169 // El campo 'Det_Salidas.PRECIO' nunca se usa
        Boolean resp;
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        conexion conn5 = new conexion();
        MySqlDataReader R;

        public frmDetalleSalidas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void frmDetalleSalidas_Load(object sender, EventArgs e)
        {
            
            
            // mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
            ToolTip mensajes = new ToolTip();

            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo registro...");
            // mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(btnGuardar, "Guardar Registro...");
            mensajes.SetToolTip(btnImprimir, "Imprimir Registros...");


            cargar();
            conn.AbrirBD();
            conn1.AbrirBD();
            cbxTipoEntrada.Focus();
        }
        void cargar_det()
        {
            return;
            #pragma warning disable CS0162 // Se detectó código inaccesible
            dgDetalleSalidas.DataSource = conn.GetTable("select d.id,d.idarticulo as Id_Articulo,a.nombre_corto as Descripcion,cantidad as Cantidad," +
            "d.precio as Precio,totalprecio as Total,estado as Estado,d.marbete as Marbete,e.nombre as Auditor " +
            "from det_inventarios d, empleados e, catarticulos a where d.idauditor=e.id and d.idarticulo=a.id and d.idinventario=" +
            ID_SAL + " order by d.id");
            #pragma warning restore CS0162 // Se detectó código inaccesible
            if ((conn.PropertyDataSet.Tables[0].Rows.Count != 0))
            {
                dgDetalleSalidas.Columns["id"].Visible = false;
                dgDetalleSalidas.AutoResizeColumns();
            }
        }

        void cargar()
        {
            DateTime fec = DateTime.Now;
            txtfecha.Text = fec.ToString("yyyy-MM-dd");
            conn2.AbrirBD();
            cbxEntrego.DisplayMember = "nombre";
            cbxEntrego.ValueMember = "id";
            cbxEntrego.DataSource = conn2.GetTable("select id,nombre from empleados");
            conn2.cerrarBd();
            conn4.AbrirBD();
            cbxAlmacen.DisplayMember = "nombre";
            cbxAlmacen.ValueMember = "id";
            if (configuracion.ID_ALMACEN != 0)
            {
                cbxAlmacen.DataSource = conn4.GetTable("select id,nombre from catalmacen where id=" + configuracion.ID_ALMACEN);
                cbxAlmacen.Enabled = false;
            }
            else { cbxAlmacen.DataSource = conn4.GetTable("select id,nombre from catalmacen where id>0"); }
            conn4.cerrarBd();
            conn5.AbrirBD();
            cbxClue.DisplayMember = "nombreclue";
            cbxClue.ValueMember = "id";
            cbxClue.DataSource = conn5.GetTable("select id,concat(clue,' ',nombre) as nombreclue from cat_clues");
            conn5.cerrarBd();
        }
        private void Det_Salidas_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.cerrarBd();
            conn1.cerrarBd();
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            { txtNombre.Enabled = true; }
            else { txtNombre.Enabled = false; }
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
            txtId.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtCosto.Text = "";
            txtMarca.Text = "";
            txtRequisicion.Text = "";
        }
        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 && txtId.Text == "")
            {
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                llena_grid("select id as Id_Producto,nombre_corto as Nombre," +
                " nombre_largo as Descripcion from catarticulos where nombre_corto like '%" + 
                "txtnombre.Text + '%' order by nombre_corto limit 20");
            }
        }
        private void llena_grid(string sql)
        {
            dgArticulos.DataSource = conn1.GetTable(sql);
            if (dgArticulos.RowCount < 2)
            {
                dgArticulos.Visible = false;
                return;
            }
            dgArticulos.AutoResizeColumns();
        }
        private void Grid_Articulos_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();
            txtNombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            dgArticulos.Visible = false;
            txtCantidad.Focus();
            txtNombre.Enabled = false;
        }
        private void txtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtCantidad.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }
        int validar()
        {
            if (txtId.Text != "" && txtCantidad.Text != "")
            { return 1; }
            return 0;
        }
        int validar_sal()
        {
            string P = suma_costos();
            if (txtfecha.Text != "" && cbxTipoEntrada.Text != "" && cbxAlmacen.Text != "" && cbxEntrego.Text != "" && txtImporte.Text == P.ToString())
            { return 1; }
            return 0;
        }
        private void bt_grabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar_sal() == 0) { return; }
                conn.AbrirBD();
                conn.inicio();
                DateTime fec = DateTime.Now;
                resp = conn.Executa("insert into salidas " +
                    "(tipo,fechasalida,importe,idrequisicion,identrego,idarea,idalmacen,estatus) " +
                    "values('" + cbxTipoEntrada.Text.ToUpper() + "," + DateTime.Parse(txtfecha.Text).ToString("yyyy-MM-dd") + 
                    "'," + txtImporte.Text.ToUpper() +  txtRequisicion.Text.ToUpper() + "," +  cbxEntrego.SelectedValue + "," +  
                    cbxClue.SelectedValue + "," + cbxAlmacen.SelectedValue + ",'A')");

                if (!resp) { conn.fallo(); return; }
                //OBTENER ID INVENTARIO
                R = conn.GetData("SELECT id FROM salidas where tipo='" + cbxTipoEntrada.Text.ToUpper() + 
                    " and fechasalida=" + DateTime.Parse(txtfecha.Text).ToString("yyyy-MM-dd") + 
                    " and importe=" + txtImporte.Text.ToUpper() +  " and idarea=" + cbxClue.SelectedValue + ";");
                
                if (R.HasRows)
                {
                    R.Read();
                    ID_SAL = Int32.Parse(R[0].ToString());
                    label16.Visible = true;
                    label16.Text = "S A L I D A #" + ID_SAL.ToString();
                }
                R.Close();
                resp = grabar_grid();
                if (!resp) { conn.fallo(); return; }
                resp = conn.Executa("insert into bitacora (fechasis,usuario,motivo,tabla,idtabla) values('"
                + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + configuracion.USER +
                "','ALTA','SALIDAS'," + ID_SAL + ")");
                if (!resp) { conn.fallo(); return; }
                conn.exito();
                MessageBox.Show("Alta de Entrada al Almacen " + ID_SAL + " Realizada con Exito¡");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            }
        }
        private void dgDetalleSalidas_DoubleClick(object sender, EventArgs e)
        {
            if (dgDetalleSalidas.CurrentRow.Index != -1)
            {
                TOTAL = double.Parse(txtImporte.Text) - double.Parse(dgDetalleSalidas.CurrentRow.Cells[4].Value.ToString());
                txtImporte.Text = TOTAL.ToString();
                dgDetalleSalidas.Rows.RemoveAt(dgDetalleSalidas.CurrentRow.Index);
            }
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtprecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtMarca.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtCantidad.Focus();
            }
        }
        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                btnNuevo.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtId.Focus();
            }
        }
        private void bt_agregar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtId.Focus(); }
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
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
            if (modulo1.IsNumeric(txtCantidad.Text.ToString()) && modulo1.IsNumeric(txtPrecio.Text.ToString()))
            {
                costo();
            }
        }
        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtcantidad_Leave(object sender, EventArgs e)
        {
            if (modulo1.IsNumeric(txtCantidad.Text.ToString()) && modulo1.IsNumeric(txtPrecio.Text.ToString()))
            {
                costo();
                R = conn.GetData("SELECT sum(de.existencia) FROM det_entradas de, entradas e " +
                " where de.identrada=e.id and e.idalmacen=" + cbxAlmacen.SelectedValue + " and idarticulo=" + txtId.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    if (Int64.Parse(txtCantidad.Text.ToString()) > Int64.Parse(R[0].ToString()))
                    {
                        MessageBox.Show("No se cuenta con esa existencia en el almacen de ese articulo¡");
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No existe ese numero de articulo¡");
                    txtId.Focus();
                }
                R.Close();
            }
        }
        void costo()
        {
            if (txtCantidad.Text != "" && txtPrecio.Text != "")
            {
                float costo = float.Parse(txtCantidad.Text) * float.Parse(txtPrecio.Text);
                float iva1 = float.Parse(costo.ToString()) / configuracion.IVA;
                txtCosto.Text = costo.ToString();
                txtIVA.Text = iva1.ToString();
            }
        }
        private void txtmarca_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtRequisicion.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtPrecio.Focus();
            }
        }
        private void txtrequisicion_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbxEntrego.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtfecha.Focus();
            }
        }
        public string suma_costos()
        {
            string resp = "";
            TOTAL = 0;
            for (int fila = 0; fila < dgDetalleSalidas.Rows.Count - 1; fila++)
            {
                TOTAL = TOTAL + double.Parse(dgDetalleSalidas.Rows[fila].Cells[4].Value.ToString());
            }
            resp = TOTAL.ToString();
            return resp;
        }
        private void cbtipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtfecha.Focus();
            }
        }
        private void txtfecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtRequisicion.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbxTipoEntrada.Focus();
            }
        }
        private void cbxEntrego_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbxClue.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtRequisicion.Focus();
            }
        }
        private void cbxArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                cbxAlmacen.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbxEntrego.Focus();
            }
        }
        private void cbxAlmacen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtId.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbxClue.Focus();
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        Boolean grabar_grid()
        {
            DateTime fec = DateTime.Now;
            double nuevo_costo = 0, nueva_exis = 0, sal = 0, precio = 0;
            Int64 ID_ART = 0;
            DateTime caducidad;
            string f = " order by de.identrada asc", marca = "";
            if (configuracion.METODO == "PE")
            { f = " order by de.identrada desc"; }
            for (int fila = 0; fila < dgDetalleSalidas.Rows.Count - 1; fila++)
            {
                fec = DateTime.Parse(txtfecha.Text= fec.ToString("yyyy-MM-dd"));
                ID_ART = Int64.Parse(dgDetalleSalidas.Rows[fila].Cells[0].Value.ToString());
                nueva_exis = Int32.Parse(dgDetalleSalidas.Rows[fila].Cells[2].Value.ToString());
                precio = double.Parse(dgDetalleSalidas.Rows[fila].Cells[3].Value.ToString());
                nuevo_costo = double.Parse(dgDetalleSalidas.Rows[fila].Cells[4].Value.ToString()); 
                llena_grid("select de.existencia as existencia, de.precio as precio, de.caducidad as caducidad, de.marca, de.id as id from det_entradas de, entradas e " +
                " where de.identrada=e.id and de.existencia>0 and de.idarticulo=" + ID_ART + " and e.idalmacen=" + cbxAlmacen.SelectedValue +
               f.ToString());
                for (int fila2 = 0; (fila2 < dgArticulos.Rows.Count - 1 && nueva_exis > 0); fila2++)
                {
                    if (Int64.Parse(dgArticulos.Rows[fila2].Cells["existencia"].Value.ToString()) >= nueva_exis)
                    { sal = nueva_exis; }
                    else
                    { sal = Int64.Parse(dgArticulos.Rows[fila2].Cells["existencia"].Value.ToString()); }
                    caducidad = DateTime.Parse(dgArticulos.Rows[fila2].Cells["caducidad"].Value.ToString());
                    marca = dgArticulos.Rows[fila2].Cells["marca"].Value.ToString();
                    nueva_exis = nueva_exis - sal;
                    if (configuracion.METODO != "PP")
                    {
                        //cambiar precio y costo
                        precio = double.Parse(dgArticulos.Rows[fila2].Cells["precio"].Value.ToString());
                        nuevo_costo = precio * sal;
                        //MessageBox.Show("cambiar precio y costo");
                    }
                    string str = "insert into det_salidas (idsalida,idarticulo," +
                    "cantidad,precio,totalprecio,marca,caducidad,identrada) " +
                    "values(" + ID_SAL + "," + ID_ART + "," + sal + "," + precio + "," + nuevo_costo + ",'" +
                    marca.ToString() + "','" + caducidad.ToString("yyyy-MM-dd") + "'," + dgArticulos.Rows[fila2].Cells["id"].Value + ")";
                    
                    if (!conn.Executa(str)) { conn.fallo(); return false; }

                     //CALCULAR PRECIO PROMEDIO 
                    str = "update cat_articulos set existencia=existencia-" + sal + " where id=" + ID_ART;
                   
                    if (!conn.Executa(str)) { conn.fallo(); return false; }
                    str = "update det_entradas set existencia=existencia-"
                    + sal + " where id=" + dgArticulos.Rows[fila2].Cells["id"].Value.ToString();
                    

                    if (!conn.Executa(str)) { conn.fallo(); return false; }
                    //GUARDAR EN LA TABLA KARDEX EL MOV DE ENTRADA
                    str = "insert into kardex (idtabla,idarticulo,entrada,salida,precio,costo,fecha,existencia)" +
                    "values(" + ID_SAL + "," + ID_ART + ",0," + sal + "," + precio + "," +
                    nuevo_costo + ",'" + caducidad.ToString("yyyy-MM-dd") + "',0)";
                    //MessageBox.Show(str);
                    
                    if (!conn.Executa(str)) { conn.fallo(); return false; }

                    str = "update kardex k, cat_articulos a set k.existencia=a.existencia where " +
                    "a.id=k.idarticulo and k.salida=" + dgDetalleSalidas.Rows[fila].Cells[2].Value.ToString() +
                    " and idtabla=" + ID_SAL;
                    if (!conn.Executa(str)) { conn.fallo(); return false; }

                   
                }//segundo for
            }//primer for
             //Inventario.ActiveForm=true;
            return true;
        }
    }

}

