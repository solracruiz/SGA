using Google.Protobuf.WellKnownTypes;
using Guna.UI2.WinForms.Suite;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace SGA.Procesos
{
    public partial class frmDetalleInventarios : MaterialForm
    {
#pragma warning disable CS0414 // El campo 'Det_Inventarios.r' está asignado pero su valor nunca se usa
        int r = 0;
#pragma warning restore CS0414 // El campo 'Det_Inventarios.r' está asignado pero su valor  nunca se usa
        Int64 ID_INV;
#pragma warning disable CS0649 // El campo 'Det_Inventarios.TOTAL' nunca se asigna y siempre tendrá el valor predeterminado 0
        Double PRECIO, TOTAL;
#pragma warning restore CS0649 // El campo 'Det_Inventarios.TOTAL' nunca se asigna y siempre tendrá el valor predeterminado 0
        Boolean resp;

        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        MySqlDataReader R;
        public frmDetalleInventarios()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void frmDetalleInventarios_Load(object sender, EventArgs e)
        {
            


            ToolTip mensajes = new ToolTip();
            // mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo detalle...");
            // mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(this.btnGuardar, "Guardar Datos");
            // mensajes.SetToolTip(btnGrabar, "Guardar Registro..."); 

            cargar();
            conn.AbrirBD();
            conn1.AbrirBD();
            if (this.Tag !=null)
            {   
                panel1.Enabled = false;
                ID_INV = Int64.Parse(this.Tag.ToString());
                panel1.Visible = true;
                panel2.Enabled = false;
                MySqlDataReader R = conn.GetData("SELECT i.fecha,i.tipo, e.nombre as autorizo" +
                " FROM inventarios i, empleados e " +
                " where  i.idautorizo=e.id and i.id='" + ID_INV + "';");
                if (R.HasRows)
                {
                    R.Read();
                    dtp.Text = R["fecha"].ToString();
                    cbxTipoInventario.Text = R["tipo"].ToString();
                    cbxSolicito.Text = R["autorizo"].ToString();
                    label16.Visible = true;
                    label16.Text = "I N V E N T A R I O #" + ID_INV.ToString();
                }
                else
                {
                    this.Close();
                }
                R.Close();
                cargar_det();
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (validar() == 0) { return; }
            panel1.Enabled = false;
            dg_Det_Inventario.Rows.Insert(r, txtProducto.Text, txtCodigo.Text, txtNombre.Text, txtLote.Text,dtp_Caducidad.Value, txtMarbete.Text,
            txtConteo1.Text,txtConteo2.Text,txtConteo3.Text, cbxEstatus2.Text,cbxReviso.SelectedValue);
            r = r + 1;
            btnGuardar.Enabled = true;
            limpiar();
            //cargar_det();
            txtid.Focus();
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }
       
        

        void cargar_det()
        {
            conn.AbrirBD();
            DateTime caduci;

            
                R = conn.GetData("select d.id,d.idarticulo, a.codigo as Clave, " +
                "a.nombre as Descripcion, Lote,Caducidad,Marbete,conteo1,conteo2,conteo3," +
                "estado as Estado,idauditor as Auditor,estatus " +
                "from det_inventarios d, empleados e, cat_articulos a where d.idauditor=e.id and " +
                "d.idarticulo = a.id and d.idinventario = " + ID_INV + " order by d.id");
                r = 0;
                if (R.HasRows)
                {
                    while (R.Read())
                {
                    caduci = DateTime.Parse( R["caducidad"].ToString());
                        
                        dg_Det_Inventario.Rows.Insert(r, R["idarticulo"].ToString(), R["clave"].ToString(), R["descripcion"].ToString(),
                        R["lote"].ToString(), caduci.ToString("yyyy-MM-dd") , R["marbete"].ToString(),
                        R["conteo1"].ToString(), R["conteo2"].ToString(), R["conteo3"].ToString(), R["estatus"].ToString(),
                        R["Auditor"].ToString());


                    r = r + 1;
                        btnGuardar.Enabled = true;
                    }

                }
                R.Close();
           
          
            if ((dg_Det_Inventario.Rows.Count != 0))
            {
                dg_Det_Inventario.Columns["id"].Visible = false;
                dg_Det_Inventario.AutoResizeColumns();
            }
        }
        void cargar()
        {
         

            conn2.AbrirBD();
            cbxReviso.DisplayMember = "nombre";
            cbxReviso.ValueMember = "id";
            cbxReviso.DataSource = conn2.GetTable("select id,nombre from empleados");
            conn2.cerrarBd();
            conn3.AbrirBD();
            cbxSolicito.DisplayMember = "nombre";
            cbxSolicito.ValueMember = "id";
            cbxSolicito.DataSource = conn3.GetTable("select id,nombre from empleados");
            conn3.cerrarBd();

        }


  

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtNombre.Text = "";
            txtConteo1.Text = "";
            txtConteo2.Text = "";
            txtConteo3.Text = "";
            cbxEstatus2.Text = "";
            cbxReviso.Text = "";
            txtLote.Text = "";
            txtMarbete.Text = "";
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 && txtProducto.Text == "")
            {
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                dgArticulos.DataSource = conn1.GetTable("select Codigo,Nombre,id as Id_Producto " +
                "  from cat_articulos where nombre like '%" + txtNombre.Text + "%' order by nombre limit 20");
                if (dgArticulos.RowCount < 2)
                {
                    dgArticulos.Visible = false;
                    return;
                }
                dgArticulos.AutoResizeColumns();
            }
        }

        private void Grid_Articulos_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = dgArticulos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtProducto.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();
            txtNombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            dgArticulos.Visible = false;
            txtLote.Focus();
            txtNombre.Enabled = false;
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtLote.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }
        private void txtConteo1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtConteo2.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }

        private void txtConteo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtConteo3.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }

        private void txtConteo3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { cbxEstatus2.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
        }


        int validar()
        {
            if (txtProducto.Text != "" && txtConteo1.Text != "" && cbxEstatus2.Text != "" && txtMarbete.Text !=
           "" && cbxReviso.Text != "" && cbxReviso.SelectedValue!=null)
            { return 1; }
            MessageBox.Show("Favor de revisar los datos del detalle de Inventario", Application.ProductName,
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return 0;
        }

        int validar_inv()
        {
            if (dtp.Value.ToString("yyyy-MM-dd") != "" && cbxTipoInventario.Text != ""  && cbxSolicito.Text != "")
            { return 1; }
            return 0;
        }

        private void bt_grabar_Click(object sender, EventArgs e)
        {


            try
            {
                if (validar_inv() == 0) { return; }
                conn.AbrirBD();
                panel1.Visible = true;
                resp = conn.Executa("insert into inventarios " +
                    "(tipo,fecha,idautorizo,estatus), " +
                    "values('" + cbxTipoInventario.Text.ToUpper() + "','" +
                    dtp.Value.ToString("yyyy-MM-dd")  + "'," +
                    cbxSolicito.SelectedValue + ",'A')");

                if (!resp) { conn.fallo(); return; }
                //OBTENER ID INVENTARIO
                R = conn.GetData("SELECT id FROM inventarios where tipo='" + cbxTipoInventario.Text.ToUpper()
                + "' and fecha='" + dtp.Value.ToString("yyyy-MM-dd") + ";");
                if (R.HasRows)
                {
                    R.Read();
                    ID_INV = Int32.Parse(R[0].ToString());
                }
                R.Close();
                resp = conn.Executa("insert into bitacora (fechasis,usuario,motivo,tabla,idtabla) values('"
                + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + configuracion.USER +
                "','ALTA','INVENTARIOS'," + ID_INV + ")");
                if (!resp) { conn.fallo(); return; }
                panel2.Enabled = false;
                panel1.Visible = true;
                txtid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        

        private void btsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtMarbete.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtMarbete.Focus();
            }
        }


        private void txtMarbete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            { txtConteo1.Focus(); }
            else if (e.KeyCode == Keys.Up) { txtLote.Focus(); }
        }

        private void cbxEstatus2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            { cbxReviso.Focus(); }
            else if (e.KeyCode == Keys.Up) { txtMarbete.Focus(); }
        }

        private void cbxReviso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            { btnNuevo.Focus(); }
            else if (e.KeyCode == Keys.Up) { cbxEstatus2.Focus(); }
        }

        private void btnNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtProducto.Focus(); }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

            private void txtProducto_Leave(object sender, EventArgs e)
            {
                if (txtProducto.Text.ToString() != "")
                {
                    R = conn.GetData("SELECT nombre FROM cat_articulos where id="
                   + txtProducto.Text + ";");
                    if (R.HasRows)
                    {
                        R.Read();
                        txtNombre.Text = R[0].ToString().ToUpper();
                        
                    }
                    else
                    {
                        MessageBox.Show("No existe ese numero de articulo¡");
                        txtNombre.Text = "";
                        txtProducto.Focus();
                    }
                    R.Close();
                }
            }

        private void Grid_Articulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;

                Boolean resp;
                conn.AbrirBD();
                conn.inicio();

                resp = conn.Executa("insert into inventarios (tipo,fecha,idautorizo,estatus) values('" +
                cbxTipoInventario.Text.ToUpper() + "','" + dtp.Value.ToString("yyyy-MM-dd") + "'," +
                cbxSolicito.SelectedValue + ",'A')");
                //OBTENER ID INVENTARIO
                if (!resp) { conn.fallo(); return; }
                R = conn.GetData("SELECT id FROM inventarios where tipo='" + cbxTipoInventario.Text.ToUpper()
                + "' and fecha='" + dtp.Value.ToString("yyyy-MM-dd")
                + "' and idautorizo=" + cbxSolicito.SelectedValue + ";");
                if (R.HasRows)
                {
                    R.Read();
                    ID_INV = Int32.Parse(R[0].ToString());
                    label16.Visible = true;
                    label16.Text = "I N V E N T A R I O #" + ID_INV.ToString();
                }
                R.Close();
                resp = grabar_grid();
                if (!resp) { return; }
                resp = conn.Executa("insert into bitacora (fechasis,usuario,motivo,tabla,idtabla) values('"
                + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" + configuracion.USER +
                "','ALTA','INVENTARIO'," + ID_INV + ")");
                if (!resp) { conn.fallo(); return; }
                conn.exito();
                conn.cerrarBd();
                MessageBox.Show("Alta de Inventario " + ID_INV + " Realizada con Exito¡");
                MessageBox.Show("CREAR REPORTE DE INVENTARIO Y MOSTRARLO AQUI¡");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            }
        }
        Boolean grabar_grid()
        {
            try
            {
                DateTime fec = DateTime.Now;
                for (int fila = 0; fila < dg_Det_Inventario.Rows.Count - 1; fila++)
                {



                    fec = DateTime.Parse(dg_Det_Inventario.Rows[fila].Cells[4].Value.ToString());

                    string str = "insert into det_inventarios (idinventario,idarticulo," +
                    "lote,marbete,conteo1,conteo2,conteo3,caducidad,estado,idauditor) " +
                    "values(" + ID_INV + "," +
                    dg_Det_Inventario.Rows[fila].Cells[0].Value.ToString() + ",'" +
                    dg_Det_Inventario.Rows[fila].Cells[3].Value.ToString() + "','" +
                    dg_Det_Inventario.Rows[fila].Cells[5].Value.ToString() + "'," +
                    dg_Det_Inventario.Rows[fila].Cells[6].Value.ToString() + "," +
                    dg_Det_Inventario.Rows[fila].Cells[7].Value.ToString() + "," +
                    dg_Det_Inventario.Rows[fila].Cells[8].Value.ToString() + ",'" +
                    fec.ToString("yyyy-MM-dd") + "','" +
                    dg_Det_Inventario.Rows[fila].Cells[9].Value.ToString() + "','" +
                    dg_Det_Inventario.Rows[fila].Cells[10].Value.ToString() + "')";
                    //MessageBox.Show(str);
                    if (!conn.Executa(str))
                    {
                        conn.fallo();
                        return false;
                    }



                }
                //Inventario.ActiveForm=true;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
                return false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                txtNombre.Enabled = true;
                txtNombre.Text = "";
                txtid.Text = "";
            }
            else
            {
                txtNombre.Enabled = false;
                if (txtCodigo.TextLength > 3)
                {
                    dgArticulos.Visible = true;
                    //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                    dgArticulos.DataSource = conn1.GetTable("select Codigo, Nombre, id as Id_Producto " +
                    " from cat_articulos where (codigo like '%" + txtCodigo.Text + "%') order by nombre limit 40");
                    if (dgArticulos.RowCount < 2)
                    {
                        dgArticulos.Visible = false;
                        return;
                    }
                    dgArticulos.AutoResizeColumns();
                }
            }

        }
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { txtLote.Focus(); }
            else if (e.KeyCode == Keys.Down) { txtNombre.Focus(); }
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
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else { e.Handled = true; }
        }








    }
}

    

