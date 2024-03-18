using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SGA.Data_Sources;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Web.UI;
using SGA.Procesos;
using System.Globalization;

namespace SGA.Catálogos
{
    public partial class FrmCatProductos : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        conexion conn5 = new conexion();
        conexion conn6 = new conexion();
        MySqlDataReader R;
        string sql = "", accion = "", filtro = "";
        Int16 IVA = 0;
        Int16 Controlado=0;
        public FrmCatProductos()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void FrmCatProductos_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, 
                Primary.Brown900, Accent.Green700, TextShade.WHITE);
            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(btnGuardar, "Guardar Registro...");
            mensajes.SetToolTip(btnImprimir, "Imprimir Registros...");
            carga();

        }
        void carga()
        {
            conn2.AbrirBD();
            cbxPartidae.DisplayMember = "partidae";
            cbxPartidae.ValueMember = "id";
            cbxPartidae.DataSource = conn2.GetTable("select id,concat(id,' ',nombre) as partidae from cat_partidas_est order by id");
            conn2.cerrarBd();

            conn3.AbrirBD();
            cbxPartidaf.DisplayMember = "partidaf";
            cbxPartidaf.ValueMember = "id";
            cbxPartidaf.DataSource = conn3.GetTable("select id,concat(id,' ',nombre) as partidaf from cat_partidas_fed order by id");
            conn3.cerrarBd();

            conn4.AbrirBD();
            cbxPresentacion.DisplayMember = "presentacion";
            cbxPresentacion.ValueMember = "presentacion";
            cbxPresentacion.DataSource = conn4.GetTable("SELECT distinct upper(presentacion) as presentacion FROM bpmservi_sigal.cat_articulos order by presentacion");
            conn4.cerrarBd();

            conn5.AbrirBD();
            cbxTipo.DisplayMember = "tipo2";
            cbxTipo.ValueMember = "tipo2";
            cbxTipo.DataSource = conn5.GetTable("SELECT distinct upper(tipo2) as tipo2 FROM bpmservi_sigal.cat_articulos order by tipo2");
            conn5.cerrarBd();

            conn6.AbrirBD();
            cbxMedidas.DisplayMember = "medidas";
            cbxMedidas.ValueMember = "medidas";
            cbxMedidas.DataSource = conn6.GetTable("SELECT distinct upper(medidas) as medidas FROM bpmservi_sigal.cat_articulos order by medidas");
            conn6.cerrarBd();



            conn.AbrirBD();
            sql = "select id ,codigo as Clave,Nombre,Descripcion, idpartidae as Partida_Est,idpartidaf as Partida_Fed,Presentacion,tipo2 as Tipo_Articulo,gramaje,medidas,IVA,Controlado from cat_articulos where id>0 " + filtro + " limit 10000";
            dgProductos.DataSource = conn.GetTable(sql);
            dgProductos.AutoResizeColumns();
            if (dgProductos.Rows.Count > 0) {
                dgProductos.Columns[0].Visible = false;
               }
            conn.cerrarBd();
        }
        
    

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVCatProductos frm = new frmRVCatProductos();
            frm.Tag = filtro;
            frm.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            accion = "NUEVO";
            panel1.Enabled = true;
        }
        void limpiar()
        {
            txtid.Text = "";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtgramaje.Text = "";
            cbxMedidas.Text = "";
            cbxPartidae.Text = "";
            cbxPartidaf.Text = "";

            cbxPresentacion.Text = "";
            cbxTipo.Text = "";

            txtCodigo.Enabled = true;
            txtCodigo.Focus();
            accion = "";
        }


        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProductos_DoubleClick(object sender, EventArgs e)

        {
            try
            {
                //Segmento de código que permite editar/modificar los datos de un registro
                //celda por celda
                txtid.Text = dgProductos.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgProductos.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgProductos.CurrentRow.Cells[2].Value.ToString();

                cbxPartidae.Text = dgProductos.CurrentRow.Cells[4].Value.ToString();
                conn.AbrirBD();
                R = conn.GetData("SELECT id,concat(id,' ',nombre) as partidae FROM cat_partidas_est where id=" + cbxPartidae.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    cbxPartidae.Text = R[1].ToString().ToUpper();

                }
                else
                {
                    txtid.Focus();
                }
                R.Close();

                cbxPartidaf.Text = dgProductos.CurrentRow.Cells[5].Value.ToString();
                R = conn.GetData("SELECT concat(id,' ',nombre) as partidaf FROM cat_partidas_fed where id=" + cbxPartidaf.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    cbxPartidaf.Text = R[0].ToString().ToUpper();

                }
                else
                {
                    txtid.Focus();
                }
                R.Close();
                conn.cerrarBd();

                cbxPresentacion.Text = dgProductos.CurrentRow.Cells[6].Value.ToString();
                cbxTipo.Text = dgProductos.CurrentRow.Cells[7].Value.ToString();

                txtgramaje.Text = dgProductos.CurrentRow.Cells["gramaje"].Value.ToString();
                cbxMedidas.Text = dgProductos.CurrentRow.Cells["medidas"].Value.ToString();

                //MessageBox.Show(dgProductos.CurrentRow.Cells["controlado"].Value.ToString());
                checkBox1.Checked = false;
                if (dgProductos.CurrentRow.Cells["controlado"].Value.ToString() == "True")
                { checkBox1.Checked = true; }


                panel1.Enabled = true;
                accion = "EDITAR";
                txtCodigo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el proceso - " + ex.Message);
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (nombre like '%" + txtBusqueda.Text +
                "%' or codigo like '%" + txtBusqueda.Text + "%' )";
                carga();
            }
            else if(txtBusqueda.Text.ToString().Length==0)
            {
                filtro = "";
                carga();
            }
            
        }

        private void cbxJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            accion = "EDITAR";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp;

            if (valida() == 0)
            {
                return;
            }
            if (accion == "NUEVO")
            {
                if (valida2() == 0)
                {
                    return;
                }
            }
            panel1.Enabled = false;
            IVA = 16;
            Controlado = 0;
            if (cbxTipo.Text == "MEDICAMENTO")
            { 
                IVA = 0; 
            }
            if (checkBox1.Checked==true)
            {
                Controlado = 1;
            }

            if (accion == "NUEVO")
            {
                
                conn.AbrirBD();
                resp = conn.Executa("insert into cat_articulos (codigo,nombre,descripcion" +
                ",idpartidae,idpartidaf, presentacion, tipo2,iva,controlado,gramaje,medidas) values('" +
                    txtCodigo.Text + "','" + txtNombre.Text + "','" + txtNombre.Text + "','" + cbxPartidae.SelectedValue + "','" +
                    cbxPartidaf.SelectedValue + "','" + cbxPresentacion.Text.ToUpper() + "','" + cbxTipo.Text.ToUpper() + "'," + 
                    IVA + "," + Controlado + ",'" + txtgramaje.Text + "','" + cbxMedidas.Text + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { 
                    
                   return; }

                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Articulo " + txtid.Text + " Realizada con Exito¡");
            }
            else if (accion == "EDITAR")
            {
                conn.AbrirBD();
                resp = conn.Executa("update cat_articulos set codigo='" + txtCodigo.Text +
                "', nombre='" + txtNombre.Text + "',idpartidae='" + cbxPartidae.SelectedValue +
                "',idpartidaf='" + cbxPartidaf.SelectedValue
                + "',presentacion='" + cbxPresentacion.Text.ToUpper() +
                "', tipo2='" + cbxTipo.Text.ToUpper() +  "', iva=" + IVA + ",controlado=" + Controlado +
                ", gramaje='" + txtgramaje.Text + "',medidas='" + cbxMedidas.Text +
                "' where id=" + double.Parse(txtid.Text));

                if (!resp) { return; }

                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Articulo " + txtid.Text + " Realizada con Exito¡");
            }
            limpiar();
        }

        private int valida()
        {
            if (txtCodigo.Text == "" || cbxPartidae.Text == "" || cbxPartidaf.Text == "" || cbxPresentacion.Text == "" || cbxTipo.Text == "" || (cbxTipo.Text != "MEDICAMENTO" && cbxTipo.Text != "MATERIAL DE CURACION"))
            {
                MessageBox.Show("No es posible agregar o actualizar el Articulo sin valores¡");
                panel1.Enabled = true;
                return 0;
            }

            if (cbxTipo.Text != "MEDICAMENTO" && cbxTipo.Text != "MATERIAL DE CURACION")
            {
                MessageBox.Show("No es posible agregar o actualizar el Articulo con error en el Tipo de Articulo¡");
                panel1.Enabled = true;
                return 0;
            }

            if (cbxPartidae.SelectedValue==null) 
            {
                conn.AbrirBD();
                R = conn.GetData("SELECT id FROM cat_partidas_est where id=" + cbxPartidae.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    cbxPartidae.SelectedValue = R[0].ToString().ToUpper();

                }
                else
                {
                    return 0;
                }
                R.Close();
            }

            if (cbxPartidaf.SelectedValue == null)
            {
                conn.AbrirBD();
                R = conn.GetData("SELECT id FROM cat_partidas_fed where id=" + cbxPartidaf.Text + ";");
                if (R.HasRows)
                {
                    R.Read();
                    cbxPartidaf.SelectedValue = R[0].ToString().ToUpper();

                }
                else
                {
                    return 0;
                }
                R.Close();
            }


            return 1;
        }


        private void cbxTipo_Leave(object sender, EventArgs e)
        {
            if (cbxTipo.Text != "MEDICAMENTO")
            {
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }
            else { 
                checkBox1.Enabled = true; }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int valida2()
        { 
            conn.AbrirBD();
            R = conn.GetData("SELECT id FROM cat_articulos where codigo='" + txtCodigo.Text + "';");
            if (R.HasRows)
            {
                R.Close();
                conn.cerrarBd();
                MessageBox.Show("No es posible agregar o actualizar el Articulo con un codigo ya existente " + txtCodigo.Text + "¡");
                panel1.Enabled = true;
                return 0;
            }
            
            conn.cerrarBd() ;
            return 1;
        }
       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgProductos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta a Punto de Eliminar Datos!",
                    "Eliminacion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Cancel) { return; }
                else if (resultado == DialogResult.OK)
                {
                    foreach (DataGridViewRow Rw in dgProductos.SelectedRows)
                    {
                        dgProductos.Rows.Remove(Rw);
                    }
                }
            }
        }

    }
}
