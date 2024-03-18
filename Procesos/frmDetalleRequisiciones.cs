using Guna.UI2.WinForms.Suite;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SGA.Procesos
{
    public partial class frmDetalleRequisiciones : MaterialForm
    {
        int r = 0;
        Int64 ID_REQ, ID_SAL;
        Double PRECIO, TOTAL;
        string filtro2 = "";
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();

        MySqlDataReader R;
        public frmDetalleRequisiciones()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void frmDetalleRequisiciones_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
            Primary.Brown900, Accent.Green700, TextShade.WHITE);



            System.Windows.Forms.ToolTip mensajes = new System.Windows.Forms.ToolTip();
            //mensajes.SetToolTip(txtBusqueda, "Registro a buscar..."); 
            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo registro...");
            //mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(btnGuardar, "Guardar Registro...");
            if (Tag.ToString() == "1")
            { 
                checkDirecta.Checked = true;
                this.Text ="Detalle de Salicitudes de Abasto Directa";
            }

            cargar();
            conn.AbrirBD();
            conn1.AbrirBD();
            cbxClue.Focus();
        }

        
        internal static void show()
        {
            throw new NotImplementedException();
        }
        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString() != "")
            {
                conn.AbrirBD();
                R = conn.GetData("SELECT nombre, precio FROM cat_articulos where id=" + txtProducto.Text +
               ";");
                if (R.HasRows)
                {
                    R.Read();
                    txtNombre.Text = R[0].ToString().ToUpper();
                }
                else
                {
                    MessageBox.Show("No existe ese numero de articulo¡");
                    txtProducto.Focus();
                }
                R.Close();
                conn.cerrarBd();
            }
        }

        void cargar()
        {
            DateTime dt = DateTime.Now;                       
            txtfecha.Text = String.Format("{0:yyyy-MM-dd}", dt);

            conn2.AbrirBD();
            cbxPrograma.DisplayMember = "nombre";
            cbxPrograma.ValueMember = "id";
            cbxPrograma.DataSource = conn2.GetTable("select id,nombre from cat_programas");
            conn2.cerrarBd();
            conn3.AbrirBD();
            cbxClue.DisplayMember = "nombre";
            cbxClue.ValueMember = "id";
            cbxClue.DataSource = conn3.GetTable("select id,concat(clue,' ',descripcion) as nombre from cat_clues");
           
            conn3.cerrarBd();
        }
        private void Det_Entradas_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.cerrarBd();
            conn1.cerrarBd();
        }
        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            { txtNombre.Enabled = true; }
            else { txtNombre.Enabled = false; }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        void limpiar()
        {
            txtProducto.Text = "";
            txtcodigo.Text = "";
            txtNombre.Text = "";
            txtCantidad.Text = "0";
            txtEspecificaciones.Text = "";
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 && txtcodigo.Text == "")
            {
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                dgArticulos.DataSource = conn1.GetTable("select Codigo,nombre as Nombre," +
                    " id as Id_Producto from cat_articulos where (nombre like '%" + txtNombre.Text + "%' or codigo like '%" + txtNombre.Text + "%') order by nombre limit 40");
                if (dgArticulos.RowCount < 1)
                {
                    dgArticulos.Visible = false;
                    return;
                }
                else
                {
                    dgArticulos.Columns["Id_Producto"].Visible = false; ;
                }
                dgArticulos.AutoResizeColumns();
            }
        }
        private void dgArticulos_DoubleClick(object sender, EventArgs e)
        {
            txtcodigo.Text = dgArticulos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtProducto.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();
            txtNombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            dgArticulos.Visible = false;
            txtCantidad.Focus();
            txtNombre.Enabled = false;
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtCantidad.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }
        int validar()
        {
            if (txtProducto.Text != "" && txtcodigo.Text != "" && txtCantidad.Text != "" && txtCantidad.Text != "0" && txtNombre.Text != "")
            { return 1; }
            return 0;
        }
        int validar_ent()
        {
            if (txtfecha.Text != "" && cbxClue.Text != "" && cbxPrograma.Text != "")
            { return 1; }
            return 0;
        }

        int validar_reg()
        {


            for (int fila = 0; fila < Grid.Rows.Count - 1; fila++)
            {
                if (double.Parse(Grid.Rows[fila].Cells[0].Value.ToString()) == double.Parse(txtProducto.Text))
                {
                    MessageBox.Show("No es posible agregar el producto " + txtNombre.Text + " mas de 1 vez¡");

                    return 0;
                }

            }

            return 1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar_ent() == 0) { return; }
                Boolean resp;
                conn.AbrirBD();
                conn.inicio();

                DateTime dt = DateTime.Now;
                txtfecha.Text = String.Format("{0:yyyy-MM-dd}", dt);

                resp = conn.Executa("insert into requisiciones (fecha,fechacaptura," +
                "idclue,idprograma,estado,iduser) values('" +
                txtfecha.Text + "','" +
                DateTime.Now.ToString("yyyy-MM-dd") + "'," +
                cbxClue.SelectedValue + "," +
                cbxPrograma.SelectedValue + ",'A'," + configuracion.IDUSER + ")");
                //OBTENER ID INVENTARIO
                if (!resp) { conn.fallo(); return; }
                R = conn.GetData("SELECT id FROM requisiciones where idclue='" + cbxClue.SelectedValue
                + "' and fecha='" + txtfecha.Text
                + "' and idprograma=" + cbxPrograma.SelectedValue +
                " and iduser=" + configuracion.IDUSER + " order by id desc;") ;
                if (R.HasRows)
                {
                    R.Read();
                    ID_REQ = Int32.Parse(R[0].ToString());
                    label16.Visible = true;
                    label16.Text = "R E Q U I S I C I O N E S #" + ID_REQ.ToString();
                }
                R.Close();
                resp = grabar_grid();
                if (!resp)
                {
                    conn.fallo(); return;
                }
                if (checkDirecta.Checked)
                {
                    resp = conn.Executa("insert into salidas (idclue,idrequisicion,iduser,fechareq) " +
                    " select idclue," + ID_REQ + "," + configuracion.IDUSER + ",fecha from requisiciones where id = " + ID_REQ);
                if (!resp) { conn.fallo(); return; }
                    R = conn.GetData("SELECT id FROM salidas where idrequisicion=" + ID_REQ + ";");
                    if (R.HasRows)
                    {
                        R.Read();
                        ID_SAL = Int32.Parse(R[0].ToString());
                    }
                    R.Close();
                    resp = conn.Executa("insert into det_salidas (idsalida,idarticulo,cantidad)  " +
                        "select " + ID_SAL +  "idarticulo,cantidad from det_requisiciones where estado=1 " +
                        "and idrequisicion = " + ID_REQ);
                   

                    conn.Executa("update requisiciones set estado='V' where id=" + ID_REQ);
                }
                resp = conn.Executa("insert into bitacora (fechasis,usuario,motivo,tabla,idtabla) values('"
               +
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + configuracion.USER +
                "','ALTA','SALIDA'," + ID_REQ + ")");
                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                MessageBox.Show("Alta de Solicitud de Abasto " + ID_REQ + " Realizada con Exito¡");

                frmRVDetalleRequisiciones frm = new frmRVDetalleRequisiciones();
                frm.Tag = ID_REQ;
                frm.ShowDialog();


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
 
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtEspecificaciones.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtProducto.Focus();
            }
        }
        private void btnNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtProducto.Focus(); }
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
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
             
        }
       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (validar() == 0 || validar_ent() == 0 || validar_reg() == 0) { return; }
            panel1.Enabled = false;
            Grid.Rows.Insert(r, txtProducto.Text, txtcodigo.Text, txtNombre.Text, txtCantidad.Text, txtEspecificaciones.Text);
            r = r + 1;
            btnGuardar.Enabled = true;
            limpiar();
            //cargar_det();
            txtProducto.Focus();
        }

     

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEspecificaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

                if (txtcodigo.TextLength > 3)
                {
                txtNombre.Text = "";
                    dgArticulos.Visible = true;
                    //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                    dgArticulos.DataSource = conn1.GetTable("select Codigo,nombre as Nombre," +
                        " id as Id_Producto from cat_articulos where (nombre like '%" + txtcodigo.Text + "%' or codigo like '%" + txtcodigo.Text + "%') order by nombre limit 40");
                    if (dgArticulos.RowCount < 1)
                    {
                        dgArticulos.Visible = false;
                        return;
                    }
                    else
                    {
                        dgArticulos.Columns["Id_Producto"].Visible = false; ;
                    }
                    dgArticulos.AutoResizeColumns();
                }
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
            { txtCantidad.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }
        private void txtEspecificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                btnNuevo.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtCantidad.Focus();
            }
        }
        Boolean grabar_grid()
        {
            for (int fila = 0; fila < Grid.Rows.Count - 1; fila++)
            {
                string str = "insert into det_requisiciones (idrequisicion,idarticulo," +
                "cantidad,precio,costo,especificaciones) " +
                "values(" + ID_REQ + "," +
                Grid.Rows[fila].Cells[0].Value.ToString() + "," +
                Grid.Rows[fila].Cells[3].Value.ToString() + "," +
                "0,0,'" +
                txtEspecificaciones.Text + "')";
                if (!conn.Executa(str))
                {
                    conn.fallo();
                    return false;
                }
            }
            return true;
        }
    }
}
