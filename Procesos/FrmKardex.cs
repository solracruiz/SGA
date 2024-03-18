using Guna.UI2.WinForms.Suite;
using MaterialSkin;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SGA.Procesos
{
    public partial class frmKardex : MaterialSkin.Controls.MaterialForm
    {
        public string filtro = "", filtro_ent = "", filtro_sal = "";
        public string sql = "", sql1 = "", sql2 = "", sql3 = "";
        Boolean resp = false;

        DateTime fecha1;
        DateTime fecha2;
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        conexion conn5 = new conexion();
        MySqlDataReader R;
        public frmKardex()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
            Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            { txtNombre.Enabled = true; }
            else { txtNombre.Enabled = false; }
        }
        private void txtProducto_Leave(object sender, EventArgs e)
        {
            try
            {
                conn.AbrirBD();
                if (txtProducto.Text.ToString() != "")
                {
                    R = conn.GetData("SELECT nombre, precio FROM cat_articulos where id=" + txtProducto.Text + ";");
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
                }
                conn.cerrarBd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existe el producto " + ex.Message, Application.ProductName,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

        }
        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

            if (txtcodigo.Text == "")
            {
                txtNombre.Enabled = true;
                txtNombre.Text = "";
                txtProducto.Text = "";
            }
            else
            {
                txtNombre.Enabled = false;
                if (txtcodigo.TextLength > 3)
                {
                    dgArticulos.Visible = true;
                    //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                    dgArticulos.DataSource = conn1.GetTable("select id as Id_Producto,Nombre,Codigo" +
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
       

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsSeparator(e.KeyChar))
            { e.Handled = false; }
            else { e.Handled = true; }
        }
        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void FrmKardex_Load(object sender, EventArgs e)
        {
            ToolTip mensajes = new ToolTip();


            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros Filtrados");
            mensajes.SetToolTip(BtnFiltrar, "Aplicar Filtro");
            cargar();
            conn.AbrirBD();
            conn1.AbrirBD();
            txtProducto.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgArticulos_DoubleClick(object sender, EventArgs e)
        {
            txtcodigo.Text = dgArticulos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtProducto.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();
            txtNombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            dgArticulos.Visible = false;
            BtnFiltrar.Focus();
            txtNombre.Enabled = false;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 && txtProducto.Text == "")
            {
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                dgArticulos.DataSource = conn1.GetTable("select id as Id_Producto,Codigo,Nombre" +
                " from cat_articulos where (nombre like '%" + txtNombre.Text + "%' or codigo like '%" + txtNombre.Text + "%' ) order by nombre limit 40");
                if (dgArticulos.RowCount < 2)
                {
                    dgArticulos.Visible = false;
                    return;
                }
                dgArticulos.AutoResizeColumns();
            }
        }

        private void dgKardex_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            conn.AbrirBD();
            conn.inicio();
              resp = conn.Executa("update kardex k, det_entradas d set k.lote = d.lote, k.caducidad = d.caducidad where k.identrada = d.id and k.idarticulo = d.idarticulo and entrada = 0");
            if (!resp)
            {
                conn.fallo();
                return;
            }
            resp = conn.Executa("update kardex k, det_entradas d set k.lote = d.lote, k.caducidad = d.caducidad where k.idtabla = d.identrada and k.idarticulo = d.idarticulo  and salida = 0");
            if (!resp)
            {
                conn.fallo();
                return;
            }

            

            conn.exito();
            conn.cerrarBd();

            carga();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVKardex frm = new frmRVKardex();
            frm.Tag = sql;
            frm.ShowDialog();
        }

        void cargar()
        {
            dtp1.Value = DateTime.Parse("2023-01-01"); ;
            dtp2.Value = DateTime.Now;


            conn2.AbrirBD();
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "id";
            cbxProveedor.DataSource = conn2.GetTable("select id,nombre from cat_proveedores order by nombre");
            conn2.cerrarBd();

            conn3.AbrirBD();
            cbxClue.DisplayMember = "nombreclue";
            cbxClue.ValueMember = "id";
            cbxClue.DataSource = conn3.GetTable("select id,concat(clue,' ',descripcion) as nombreclue from cat_clues");
            conn3.cerrarBd();

            conn4.AbrirBD();
            cbxPartida.DisplayMember = "nombre";
            cbxPartida.ValueMember = "id";
            cbxPartida.DataSource = conn4.GetTable("select id,concat(id,' ',nombre) as nombre from cat_partidas_fed");
            conn4.cerrarBd();

            conn5.AbrirBD();
            cbxFuente.DisplayMember = "fuente";
            cbxFuente.ValueMember = "id";
            cbxFuente.DataSource = conn5.GetTable("select id,concat(id,' ',descripcion) as fuente from cat_ffinanciamiento");
            conn5.cerrarBd();

            
            cbxProveedor.Text = "";
            cbxClue.Text = "";
            cbxPartida.Text = "";
            cbxFuente.Text = "";
            //carga();

        }
        void filtrar()
        {
            filtro_ent = "";
            filtro_sal = "";
            filtro = " and k.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
                   " and k.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";
            if (txtProducto.Text != "")
            {
                filtro = filtro + " and ca.id=" + txtProducto.Text;
            }
            if (cbxPartida.Text != "")
            {
                filtro = filtro + " and ca.idpartidaf=" + cbxPartida.SelectedValue;
            }
            if (cbxProveedor.Text != "")
            {
                filtro_ent = filtro_ent + " and e.idproveedor=" + cbxProveedor.SelectedValue;
            }
            if (cbxFuente.Text != "")
            {
                filtro_ent = filtro_ent + " and e.idfuente='" + cbxFuente.SelectedValue + "'";
            }
            if (cbxClue.Text != "")
            {
                filtro_sal = filtro_sal + " and s.idclue=" + cbxClue.SelectedValue;
            }
        }

        void carga()
        {
            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;
            filtrar();

            sql1 = "(select 'ENTRADA' as Tipo, k.idarticulo as Articulo,ca.Codigo as Codigo, ca.nombre as Nombre,k.lote,k.caducidad,ca.idpartidaf as Partida," +
            " Entrada,Salida,k.precio as Precio,costo as Costo,k.existencia as Existencia,fecha as Fecha," +
            " (select descripcion from  cat_ffinanciamiento cf, entradas e where cf.id=e.idfuente and e.id=k.idtabla) as Fuente_Financiamiento, " +
            " (select nombre from cat_proveedores cp, entradas e where cp.id = e.idproveedor and e.id = k.idtabla) as Proveedor," +
            " '' as CLUE, k.id as idk,k.identrada " +
            " from kardex k, cat_articulos ca, entradas e " +
            " where k.idarticulo = ca.id and entrada>0 and e.id=k.idtabla  " + filtro + filtro_ent + ")";


            sql2 = " (select 'SALIDA' as Tipo, k.idarticulo as Articulo,ca.Codigo as Codigo,ca.descripcion as Descripcion,k.lote,k.caducidad,ca.idpartidaf as Partida," +
            " Entrada,Salida,k.precio as Precio,costo as Costo,k.existencia as Existencia,fecha as Fecha," +
            " '' as Fuente_Financiamiento, " +
            " '' as Proveedor," +
            " (select clue from cat_clues cc, salidas s where cc.id = s.idclue and s.id = k.idtabla) as CLUE, k.id as idk,k.identrada  " +
            " from kardex k, cat_articulos ca, salidas s" +
            " where k.idarticulo = ca.id and salida>0 and s.id=k.idtabla " + filtro + filtro_sal + ")";


            sql3 = " ORDER BY idk,tipo,Articulo";

            if (filtro_ent == "" && filtro_sal == "")
            {
                sql = sql1 + " union " + sql2 + sql3;
            }
            else if (filtro_ent != "" && filtro_sal != "")
            {
                sql = sql1 + " union " + sql2 + sql3;
            }
            else if (filtro_ent != "")
            {
                sql = sql1 + sql3;
            }
            else if (filtro_sal != "")
            {
                sql = sql2 + sql3;
            }
      

            llenar_grid(sql);
            colores();

        }

        void llenar_grid(string sql)
        {
            conn.AbrirBD();
            int r = 0;
            R = conn.GetData(sql);

            dgKardex.Rows.Clear();
            if (R.HasRows)
            {

                while (R.Read())
                {

                    //dgDetalleEntradas.Rows.Insert(r, txtid.Text, txtnombre.Text, Double.Parse(txtcantidad.Text), Double.Parse(txtprecio.Text), Costo_Valor, txtmarca.Text, txtlote.Text,
                    //txtrequisicion.Text, txtcaducidad.Text, checkcanje.Checked, usd);

                    dgKardex.Rows.Insert(r, R[0].ToString(), R[1].ToString(), R[2].ToString(), R[3].ToString()
                        , R[4].ToString(), R[5].ToString(), Double.Parse(R[6].ToString()), Double.Parse(R[7].ToString())
                        , R[8].ToString(), R[9].ToString(), R[10].ToString(), R[11].ToString(), R[12].ToString(), R[13].ToString(), R[14].ToString(), R[15].ToString(), R[17].ToString());
                    r = r + 1;

                }
            }
            else 
            {
                MessageBox.Show("No existe movimientos del articulo articulo¡");
            }

            R.Close();
            conn.cerrarBd();
 
        }

        void colores()
        {
            string ident = "";
            Color color = Color.OrangeRed;
            Color colorAux = Color.White;
            Color tmpColor;

            conn.AbrirBD();

            R = conn.GetData("select id from det_entradas where alerta=1");


            if (R.HasRows)
            {

                while (R.Read())
                {
                    ident = ident + "," + Int64.Parse(R[0].ToString());

                }
            }

            if (dgKardex.Rows.Count < 2)
            {
                return;
            }

            foreach (DataGridViewRow row in dgKardex.Rows)
            {
                if (row.Cells["identrada"].Value != null)
                {

                    if (ident.IndexOf(row.Cells["identrada"].Value.ToString(), 0) > 0)
                    {
                        row.DefaultCellStyle.BackColor = color;
                    }
                    else
                    { 
                        row.DefaultCellStyle.BackColor = colorAux;
                    }
                }
            }
            R.Close();
            conn.cerrarBd();
        }
    }
}
