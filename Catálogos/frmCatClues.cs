using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
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
    public partial class FrmCatClues : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        string sql = "",accion="",filtro="";
        public FrmCatClues()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void FrmCatClues_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900, Accent.Green700, TextShade.WHITE);

            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnGuardar, "Guardar Registro...");
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");


            cargar();

            carga();
        }

        void cargar()
        {

            conn2.AbrirBD();
            cbxJurisdiccion.DisplayMember = "jurisdiccion";
            cbxJurisdiccion.ValueMember = "jurisdiccion";
            cbxJurisdiccion.DataSource = conn2.GetTable("select distinct jurisdiccion from cat_clues");
            conn2.cerrarBd();

            conn3.AbrirBD();
            cbxTipo_Clue.DisplayMember = "tipo";
            cbxTipo_Clue.ValueMember = "tipo";
            cbxTipo_Clue.DataSource = conn3.GetTable("select distinct tipo from cat_clues");
            conn3.cerrarBd();
        }

        void carga()
            {
                conn.AbrirBD();
                sql = "select * from cat_clues where id>0 " + filtro;
                dgClues.DataSource = conn.GetTable(sql);
                dgClues.AutoResizeColumns();
                conn.cerrarBd();
            }

        void limpia()
        {
            txtClue.Text = "";
            txtid.Text = "";

            cbxJurisdiccion.Text = "";
            cbxTipo_Clue.Text = "";
   
            txtNombreUnidad.Text = "";

            txtClue.Enabled = true;
            accion = "";
        }

    private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVCatClues frm = new frmRVCatClues();
            frm.Tag = filtro;
            frm.Show();
        }



        private void dgClues_DoubleClick(object sender, EventArgs e)
      
        {
            //Segmento de código que permite editar/modificar los datos de un registro
            //celda por celda
            panel1.Enabled = true;
            accion = "EDITAR";
            txtClue.Enabled = false;
            txtid.Text = dgClues.CurrentRow.Cells[0].Value.ToString();
            txtClue.Text = dgClues.CurrentRow.Cells[1].Value.ToString();
            txtNombreUnidad.Text = dgClues.CurrentRow.Cells[2].Value.ToString();

            cbxJurisdiccion.Text = dgClues.CurrentRow.Cells[3].Value.ToString();
            cbxTipo_Clue.Text = dgClues.CurrentRow.Cells[4].Value.ToString();
        }
              

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp;
            conn.AbrirBD();
            conn.inicio();

            panel1.Enabled = false;
            if (accion == "NUEVO")
            {
                resp = conn.Executa("insert into cat_clues (clue, descripcion,jurisdiccion,tipo)" +
                " values('" + txtClue.Text + "','" + txtNombreUnidad.Text + "','" + 
                cbxJurisdiccion.Text + "','" + cbxTipo_Clue.Text + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Clue " + txtClue.Text + " Realizada con Exito¡");
            }
            else if (accion == "EDITAR")
            {
                resp = conn.Executa("update cat_clues set clue='" + txtClue.Text +
                "', descripcion='" + txtNombreUnidad.Text + "',jurisdiccion='" + cbxJurisdiccion.Text +
                "',tipo='" + cbxTipo_Clue.Text + "' where id=" + double.Parse(txtid.Text));

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Clue " + txtid.Text + " Realizada con Exito¡");
            }
            limpia();

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //limpiamos los campos 
            limpia();
            accion = "NUEVO";
            panel1.Enabled = true;
            
            // le damos el foco al primer campo
            txtClue.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Boolean resp;
            string idclue = "";

            if (dgClues.CurrentRow.Cells[0].Value.ToString() != "")
            {
                idclue = dgClues.CurrentRow.Cells[0].Value.ToString();
                DialogResult resultado = MessageBox.Show("Esta a Punto de Eliminar la Clue " + idclue + "!", "Eliminacion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Cancel) { return; }
                else if (resultado == DialogResult.OK)
                {

                    conn.AbrirBD();
                    conn.inicio();


                    resp = conn.Executa("delete from cat_clues where id='" + idclue + "'");
                    //OBTENER ID INVENTARIO


                    if (!resp) { conn.fallo(); return; }

                    conn.exito();
                    conn.cerrarBd();
                    carga();
                    MessageBox.Show("Actualizacion de la Clue " + idclue + " Realizada con Exito¡");
                }
            }
            accion = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            accion = "EDITAR";
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (clue like '%" + txtBusqueda.Text +
                "%' or descripcion like '%" + txtBusqueda.Text + "%' or jurisdiccion like '%" + txtBusqueda.Text + "%')";
            }
            else
            {
                filtro = "";
            }
            carga();
        }

        private void dgClues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}

