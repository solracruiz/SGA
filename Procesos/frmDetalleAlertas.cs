using MaterialSkin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using MaterialSkin.Controls;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Common;
using System.Messaging;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace SGA.Procesos
{
    public partial class frmDetalleAlertas : MaterialSkin.Controls.MaterialForm
    {
        Int64 id_det = 0, contador = 0;
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        string sql = "", sql2 = "", filtro = "";
        MySqlDataReader R;

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text == "")
            { txtNombre.Enabled = true; }
            else { txtNombre.Enabled = false; }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.TextLength > 3 && txtcodigo.Text == "")
            {
                conn1.AbrirBD();
                dgArticulos.Visible = true;
                //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                dgArticulos.DataSource = conn1.GetTable("select Codigo,nombre as Nombre,id as Id_Producto " +
                    " from cat_articulos where (nombre like '%" + txtNombre.Text + "%' or codigo like '%" + txtNombre.Text + "%') order by nombre limit 20");
                if (dgArticulos.RowCount < 2)
                {
                    dgArticulos.Visible = false;
                    return;
                }
                dgArticulos.AutoResizeColumns();
                conn1.cerrarBd();
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
                    conn1.AbrirBD();
                    dgArticulos.Visible = true;
                    //grid1.DataSource = conn.GetTable("select id,nombre_corto,nombre_largo from catarticulos");
                    dgArticulos.DataSource = conn1.GetTable("select Codigo,Nombre,id as Id_Producto" +
                    "  from cat_articulos where (codigo like '%" + txtcodigo.Text + "%') order by nombre limit 40");
                    if (dgArticulos.RowCount < 2)
                    {
                        dgArticulos.Visible = false;
                        conn.cerrarBd();
                        return;
                    }
                    dgArticulos.AutoResizeColumns();
                    conn.cerrarBd();
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
        public frmDetalleAlertas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }


        private void frmDetalleAlertas_Load(object sender, EventArgs e)
        {

        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            marcar();

        }

        private void marcar()
        {
            
            conn.AbrirBD();
            conn.inicio();

            Int32 a = dgAlertas.Rows.Count;

            foreach (DataGridViewRow row in dgAlertas.Rows)
            {
                string bandera = "False";
                if (row.Cells[9].Value != null)
                {
                    bandera = row.Cells[9].Value.ToString();
                }
                if (bandera == "True")
                {
                    id_det = Int64.Parse( row.Cells[0].Value.ToString());
                    conn.Executa("Insert into alertas (idarticulo,identrada,fecha,motivo) " +
                      "values (" + Int64.Parse(row.Cells[1].Value.ToString()) + 
                      "," + id_det + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtMotivo.Text.ToString() +"')");
                    conn.Executa("update det_entradas set alerta=1 where id=" + id_det);
                    contador = contador + 1;
                }
            }
            if (contador == 0)
            {
                MessageBox.Show("No se marcaron entradas de ese articulo¡");
                limpiar();
                txtProducto.Focus();
                conn.cerrarBd();
            }
            else
            {
                conn.exito();
                conn.cerrarBd();
                pdf();
                MessageBox.Show("Proceso realizado con exito¡");
                limpiar();
                txtProducto.Focus();
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
                    File.Copy(str_RutaArchivo, "C:\\SIGAL\\PDFS\\ALERTA_" + id_det + ".PDF");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void carga()
        {
       

            sql = "select de.id,de.idarticulo,ca.codigo, de.cantidad,de.precio,de.totalprecio,marca,lote,caducidad,de.alerta " + 
                " from det_entradas de, entradas e, cat_articulos ca " +
                " where de.identrada=e.id and de.idarticulo=ca.id and de.alerta=0 and de.idarticulo="+ txtProducto.Text + filtro ;

            sql2 = " ORDER BY e.fechaentrada";            
                sql = sql + sql2 ;
         
            llenar_grid(sql);


        }

        void llenar_grid(string sql)
        {
            conn.AbrirBD();
            int r = 0;
            DateTime fec = DateTime.Now;
            R = conn.GetData(sql);

            dgAlertas.Rows.Clear();
            if (R.HasRows)
            {

                while (R.Read())
                {

                    fec = DateTime.Parse(R[8].ToString());
                    dgAlertas.Rows.Insert(r, R[0].ToString(), R[1].ToString(), R[2].ToString(), R[3].ToString()
                        ,Double.Parse( R[4].ToString()), Double.Parse(R[5].ToString()), R[6].ToString(),R[7].ToString(), fec.ToString("yyyy-MM-dd"));
                    r = r + 1;
                }
            }
            else 
            {
                MessageBox.Show("No existen entradas de ese articulo¡");
                limpiar();
                txtProducto.Focus();
            }
            R.Close();
            conn.cerrarBd();
        }
        void limpiar()
        {
            txtNombre.Text = "";
            txtProducto.Text = "";
            txtcodigo.Text = "";
        }

        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnFiltrar_Click_1(object sender, EventArgs e)
        {
            carga();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString() != "")
            {
                conn.AbrirBD();
                R = conn.GetData("SELECT nombre, precio FROM cat_articulos where id=" + txtProducto.Text +";");
                if (R.HasRows)
                {
                    R.Read();
                    txtNombre.Text = R[0].ToString().ToUpper();
                    carga();
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
        private void dgArticulos_DoubleClick(object sender, EventArgs e)
        {
            txtcodigo.Text = dgArticulos.CurrentRow.Cells["Codigo"].Value.ToString();
            txtProducto.Text = dgArticulos.CurrentRow.Cells["Id_Producto"].Value.ToString();
            txtNombre.Text = dgArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
            dgArticulos.Visible = false;
            txtNombre.Enabled = false;
        }
    }

}
