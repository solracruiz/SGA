using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using SGA.Data_Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Catálogos
{
    public partial class FrmCatFuentes : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        string sql = "", accion = "",filtro="";
        public FrmCatFuentes()
        {            
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void FrmCatFuentes_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, 
                Primary.Brown900, Accent.Green700, TextShade.WHITE);


            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
            //mensajes.SetToolTip(BtnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnGuardar, "Guardar Registro...");
           
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");
            carga();
        }

        void carga()
        {
            conn.AbrirBD();
            sql = "select * from cat_ffinanciamiento " + filtro;
            dgFuentes.DataSource = conn.GetTable(sql);
            dgFuentes.AutoResizeColumns();
            conn.cerrarBd();
        }



        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVCatFF frm = new frmRVCatFF();
            frm.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();

            //limpiamos los campos 
            accion = "NUEVO";
            panel1.Enabled = true;
         

        }
        void limpiar()
        {
            txtClave.Text = "";
            txtNivel.Text = "";
            txtDescripcion.Text = "";
            // le damos el foco al primer campo
            txtClave.Focus();
            accion = "";
        }
       
        private void dgFuentes_DoubleClick(object sender, EventArgs e)
        {
            txtClave.Text = dgFuentes.CurrentRow.Cells[0].Value.ToString();
            txtNivel.Text = dgFuentes.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgFuentes.CurrentRow.Cells[2].Value.ToString();
            panel1.Enabled = true;
            accion = "EDITAR";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Boolean resp;
            string idfuente = "";

            if (dgFuentes.CurrentRow.Cells[0].Value.ToString()!="")
            {
                idfuente=dgFuentes.CurrentRow.Cells[0].Value.ToString();
                DialogResult resultado = MessageBox.Show("Esta a Punto de Eliminar la Fuente " + idfuente + "!", "Eliminacion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Cancel) { return; }
                else if (resultado == DialogResult.OK)
                {

                    conn.AbrirBD();
                    conn.inicio();


                    resp = conn.Executa("delete from cat_ffinanciamiento where id='"+ idfuente + "'");
                    //OBTENER ID INVENTARIO


                    if (!resp) { conn.fallo(); return; }

                    conn.exito();
                    conn.cerrarBd();
                    carga();
                    MessageBox.Show("Actualizacion de la Fuente de Financiamiento " + idfuente + " Realizada con Exito¡");
                } 
            }
        }

        private void dgFuentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " where (descripcion like '%" + txtBusqueda.Text +
                "%' or id like '%" + txtBusqueda.Text + "%' )";
            }
            else
            {
                filtro = "";
            }
            carga();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp;
            conn.AbrirBD();
            conn.inicio();

            panel1.Enabled = false;
            if (accion == "NUEVO")
            {
                resp = conn.Executa("insert into cat_ffinanciamiento (id,ultimo_nivel,descripcion) values('" +
                    txtClave.Text + "','" + txtNivel.Text + "','" + txtDescripcion.Text + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion de la Fuente de Financiamiento " + txtClave.Text + " Realizada con Exito¡");
            }
            else if (accion == "EDITAR")
            {
                resp = conn.Executa("update cat_ffinanciamiento set id='" + txtClave.Text +
                "', ultimo_nivel='" + txtNivel.Text + "',descripcion='" + txtDescripcion.Text + 
                "' where id='" + txtClave.Text.ToString() + "'");

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion de la Fuente de Financiamiento " + txtClave.Text + " Realizada con Exito¡");
            }
            limpiar();

        }

    }
}
