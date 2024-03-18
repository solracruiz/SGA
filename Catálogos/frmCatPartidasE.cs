using MaterialSkin;
using MySql.Data.MySqlClient;
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
    public partial class FrmCatPartidasE : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        string sql = "", accion = "", filtro = "";
        public FrmCatPartidasE()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void FrmCatPartidasE_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900,
                Accent.Green700, TextShade.WHITE);
            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
           // mensajes.SetToolTip(BtnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnGuardar, "Guardar Registro...");
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");
            carga();
        }

        void carga()
        {
            conn.AbrirBD();
            sql = "select id as Clave,Nombre from cat_partidas_est where id>0 " + filtro;
            dgPartidasE.DataSource = conn.GetTable(sql);
            dgPartidasE.AutoResizeColumns();
            conn.cerrarBd();
        }


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVCatPartidasE frm = new frmRVCatPartidasE();
            frm.ShowDialog();
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
                Boolean resp;
            string idpartidae = "";

            if (dgPartidasE.CurrentRow.Cells[0].Value.ToString() != "")
            {
                idpartidae = dgPartidasE.CurrentRow.Cells[0].Value.ToString();
                DialogResult resultado = MessageBox.Show("Esta a Punto de Eliminar la Partida " + idpartidae + "!", "Eliminacion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Cancel) { return; }
                else if (resultado == DialogResult.OK)
                {

                    conn.AbrirBD();
                    conn.inicio();


                    resp = conn.Executa("delete from cat_partidas_est where id='" + idpartidae + "'");
                    //OBTENER ID INVENTARIO


                    if (!resp) { conn.fallo(); return; }

                    conn.exito();
                    conn.cerrarBd();
                    carga();
                    MessageBox.Show("Actualizacion de la Partida " + idpartidae + " Realizada con Exito¡");
                }
            }
            accion = "";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            accion ="NUEVO";
            
           
            panel1.Enabled = true;
        }
        void limpiar()
        {
            txtClave.Text = "";
            txtNombre.Text = "";
            accion = "";
            panel1.Enabled = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp;
            conn.AbrirBD();
            conn.inicio();

            panel1.Enabled = false;
            if (accion == "NUEVO")
            {
                resp = conn.Executa("insert into cat_partidas_est (id, nombre)" +
                " values('" + txtClave.Text + "','" + txtNombre.Text + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion de la Partida Estatal " + txtClave.Text + " Realizada con Exito¡");
            }
            else if (accion == "EDITAR")
            {
                resp = conn.Executa("update cat_partidas_est set id='" + txtClave.Text +
                "', nombre='" + txtNombre.Text + "' where id=" + double.Parse(txtClave.Text));

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion de la Partida " + txtClave.Text + " Realizada con Exito¡");
            }
            limpiar();
        }

        private void dgPartidasE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (nombre like '%" + txtBusqueda.Text + "%' or id=" + txtBusqueda.Text + ")";
            }
            else
            {
                filtro = "";
            }
            carga();
        }

        private void dgPartidasE_DoubleClick(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseas Editar la Partida " + dgPartidasE.CurrentRow.Cells[0].Value.ToString() + "!", "Edicion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Cancel) {
                limpiar();

                return; }
            txtClave.Text = dgPartidasE.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgPartidasE.CurrentRow.Cells[1].Value.ToString();
            panel1.Enabled = true;
            accion = "EDITAR";
        }
    }
}


