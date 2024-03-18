using Google.Protobuf.WellKnownTypes;
using MaterialSkin;
using MySql.Data.MySqlClient;
using SGA.Clases;
using SGA.Data_Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Catálogos
{
    public partial class frmCatUsuarios : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        string sql = "", accion = "", Usuario = "",Cad_Permisos="",filtro="";
        MySqlDataReader R;
        public frmCatUsuarios()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgUsuarios_DoubleClick(object sender, EventArgs e)
        {
            limpiar();
            panel1.Enabled = true;
            panel2.Enabled = true;
            accion = "EDITAR";

            Usuario = dgUsuarios.CurrentRow.Cells[0].Value.ToString();

            txtUsuario.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();


            conn.AbrirBD();
            R = conn.GetData("select iduser,permisos,password from cat_usuarios where usuario='" + Usuario.ToString() + "' and estado='1'");
            if (R.HasRows)
            {
                R.Read();
                configuracion.PERMISOS = R[1].ToString();
                txtPassword.Text = R[2].ToString();
            }

            R.Close();
            conn.cerrarBd();

            if (configuracion.PERMISOS.IndexOf("001",0) >= 0) { checkBox1.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("002",0) >= 0) { checkBox2.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("003",0) >= 0) { checkBox3.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("004",0) >= 0) { checkBox4.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("005",0) >= 0) { checkBox5.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("006",0) >= 0) { checkBox6.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("007",0) >= 0) { checkBox7.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("008",0) >= 0) { checkBox8.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("009",0) >= 0) { checkBox9.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("010",0) >= 0) { checkBox10.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("011",0) >= 0) { checkBox11.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("012",0) >= 0) { checkBox12.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("013",0) >= 0) { checkBox13.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("014",0) >= 0) { checkBox14.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("015",0) >= 0) { checkBox15.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("016",0) >= 0) { checkBox16.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("017",0) >= 0) { checkBox17.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("018",0) >= 0) { checkBox18.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("019",0) >= 0) { checkBox19.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("020",0) >= 0) { checkBox20.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("021",0) >= 0) { checkBox21.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("022",0) >= 0) { checkBox22.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("023",0) >= 0) { checkBox23.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("024",0) >= 0) { checkBox24.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("025",0) >= 0) { checkBox25.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("026",0) >= 0) { checkBox26.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("027",0) >= 0) { checkBox27.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("028",0) >= 0) { checkBox28.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("029",0) >= 0) { checkBox29.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("030",0) >= 0) { checkBox30.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("031",0) >= 0) { checkBox31.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("032",0) >= 0) { checkBox32.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("033",0) >= 0) { checkBox33.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("034",0) >= 0) { checkBox34.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("035",0) >= 0) { checkBox35.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("036",0) >= 0) { checkBox36.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("037",0) >= 0) { checkBox37.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("038",0) >= 0) { checkBox38.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("039",0) >= 0) { checkBox39.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("040",0) >= 0) { checkBox40.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("041",0) >= 0) { checkBox41.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("042",0) >= 0) { checkBox42.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("043",0) >= 0) { checkBox43.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("044",0) >= 0) { checkBox44.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("045",0) >= 0) { checkBox45.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("046",0) >= 0) { checkBox46.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("047",0) >= 0) { checkBox47.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("048",0) >= 0) { checkBox48.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("049",0) >= 0) { checkBox49.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("050",0) >= 0) { checkBox50.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("051",0) >= 0) { checkBox51.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("052",0) >= 0) { checkBox52.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("053",0) >= 0) { checkBox53.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("054",0) >= 0) { checkBox54.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("055",0) >= 0) { checkBox55.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("056",0) >= 0) { checkBox56.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("057",0) >= 0) { checkBox57.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("058",0) >= 0) { checkBox58.Checked = true; }
            if (configuracion.PERMISOS.IndexOf("059",0) >= 0) { checkBox59.Checked = true; }

        }

        void limpiar()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
            checkBox21.Checked = false;
            checkBox22.Checked = false;
            checkBox23.Checked = false;
            checkBox24.Checked = false;
            checkBox25.Checked = false;
            checkBox26.Checked = false;
            checkBox27.Checked = false;
            checkBox28.Checked = false;
            checkBox29.Checked = false;
            checkBox30.Checked = false;
            checkBox31.Checked = false;
            checkBox32.Checked = false;
            checkBox33.Checked = false;
            checkBox34.Checked = false;
            checkBox35.Checked = false;
            checkBox36.Checked = false;
            checkBox37.Checked = false;
            checkBox38.Checked = false;
            checkBox39.Checked = false;
            checkBox40.Checked = false;
            checkBox41.Checked = false;
            checkBox42.Checked = false;
            checkBox43.Checked = false;
            checkBox44.Checked = false;
            checkBox45.Checked = false;
            checkBox46.Checked = false;
            checkBox47.Checked = false;
            checkBox48.Checked = false;
            checkBox49.Checked = false;
            checkBox50.Checked = false;
            checkBox51.Checked = false;
            checkBox52.Checked = false;
            checkBox53.Checked = false;
            checkBox54.Checked = false;
            checkBox55.Checked = false;
            checkBox56.Checked = false;
            checkBox57.Checked = false;
            checkBox58.Checked = false;
            checkBox59.Checked = false;
            txtNombre.Text = string.Empty;
            txtPassword.Text = string.Empty;    
            txtUsuario.Text = string.Empty;
            Usuario = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Enabled = true;
            txtUsuario.Enabled = false;
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            accion = "NUEVO";
            txtUsuario.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = true;
            limpiar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (Usuario == "") { return; }

            Boolean resp;
            conn.AbrirBD();
            conn.inicio();

            panel1.Enabled = false;
            
                resp = conn.Executa("update cat_usuarios set estado='0' where usuario='" + txtUsuario.Text + "'");

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Usuario " + txtUsuario.Text + " Realizada con Exito¡");

            


        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Boolean valor = false;
            if (checkBox1.Checked == true)
            {
                valor = true;
            }

            checkBox2.Checked = valor;
            checkBox3.Checked = valor;
            checkBox4.Checked = valor;
            checkBox5.Checked = valor;
            checkBox6.Checked = valor;
            checkBox7.Checked = valor;
            checkBox8.Checked = valor;
            checkBox9.Checked = valor;
        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            Boolean valor = false;
            if (checkBox11.Checked == true)
            {
                valor = true;
            }

            checkBox12.Checked = valor;
            checkBox13.Checked = valor;
            checkBox14.Checked = valor;
            checkBox15.Checked = valor;
            checkBox16.Checked = valor;
            checkBox17.Checked = valor;
            checkBox18.Checked = valor;
            checkBox19.Checked = valor;
            checkBox20.Checked = valor;
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            Boolean valor = false;
            if (checkBox40.Checked == true)
            {
                valor = true;
            }
            checkBox41.Checked = valor;
            checkBox42.Checked = valor;
            checkBox43.Checked = valor;
            checkBox44.Checked = valor;
            checkBox45.Checked = valor;
            
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            Boolean valor = false;
            if (checkBox21.Checked == true)
            {
                valor = true;
            }

            checkBox22.Checked = valor;
            checkBox23.Checked = valor;
            checkBox24.Checked = valor;
            checkBox25.Checked = valor;
            checkBox26.Checked = valor;

        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {
            Boolean valor = false;
            if (checkBox50.Checked == true)
            {
                valor = true;
            }
            checkBox51.Checked = valor;
            checkBox52.Checked = valor;
            checkBox53.Checked = valor;
            checkBox54.Checked = valor;
            checkBox55.Checked = valor;

        }

        void permisos()
        {
            Cad_Permisos = "";
            if (checkBox1.Checked == true) { Cad_Permisos = Cad_Permisos + "001,"; }
            if (checkBox2.Checked == true) { Cad_Permisos = Cad_Permisos + "002,"; }
            if (checkBox3.Checked == true) { Cad_Permisos = Cad_Permisos + "003,"; }
            if (checkBox4.Checked == true) { Cad_Permisos = Cad_Permisos + "004,"; }
            if (checkBox5.Checked == true) { Cad_Permisos = Cad_Permisos + "005,"; }
            if (checkBox6.Checked == true) { Cad_Permisos = Cad_Permisos + "006,"; }
            if (checkBox7.Checked == true) { Cad_Permisos = Cad_Permisos + "007,"; }
            if (checkBox8.Checked == true) { Cad_Permisos = Cad_Permisos + "008,"; }
            if (checkBox9.Checked == true) { Cad_Permisos = Cad_Permisos + "009,"; }
            if (checkBox10.Checked == true) { Cad_Permisos = Cad_Permisos + "010,"; }
            if (checkBox11.Checked == true) { Cad_Permisos = Cad_Permisos + "011,"; }
            if (checkBox12.Checked == true) { Cad_Permisos = Cad_Permisos + "012,"; }
            if (checkBox13.Checked == true) { Cad_Permisos = Cad_Permisos + "013,"; }
            if (checkBox14.Checked == true) { Cad_Permisos = Cad_Permisos + "014,"; }
            if (checkBox15.Checked == true) { Cad_Permisos = Cad_Permisos + "015,"; }
            if (checkBox16.Checked == true) { Cad_Permisos = Cad_Permisos + "016,"; }
            if (checkBox17.Checked == true) { Cad_Permisos = Cad_Permisos + "017,"; }
            if (checkBox18.Checked == true) { Cad_Permisos = Cad_Permisos + "018,"; }
            if (checkBox19.Checked == true) { Cad_Permisos = Cad_Permisos + "019,"; }
            if (checkBox20.Checked == true) { Cad_Permisos = Cad_Permisos + "020,"; }
            if (checkBox21.Checked == true) { Cad_Permisos = Cad_Permisos + "021,"; }
            if (checkBox22.Checked == true) { Cad_Permisos = Cad_Permisos + "022,"; }
            if (checkBox23.Checked == true) { Cad_Permisos = Cad_Permisos + "023,"; }
            if (checkBox24.Checked == true) { Cad_Permisos = Cad_Permisos + "024,"; }
            if (checkBox25.Checked == true) { Cad_Permisos = Cad_Permisos + "025,"; }
            if (checkBox26.Checked == true) { Cad_Permisos = Cad_Permisos + "026,"; }
            if (checkBox27.Checked == true) { Cad_Permisos = Cad_Permisos + "027,"; }
            if (checkBox28.Checked == true) { Cad_Permisos = Cad_Permisos + "028,"; }
            if (checkBox29.Checked == true) { Cad_Permisos = Cad_Permisos + "029,"; }
            if (checkBox30.Checked == true) { Cad_Permisos = Cad_Permisos + "030,"; }
            if (checkBox31.Checked == true) { Cad_Permisos = Cad_Permisos + "031,"; }
            if (checkBox32.Checked == true) { Cad_Permisos = Cad_Permisos + "032,"; }
            if (checkBox33.Checked == true) { Cad_Permisos = Cad_Permisos + "033,"; }
            if (checkBox34.Checked == true) { Cad_Permisos = Cad_Permisos + "034,"; }
            if (checkBox35.Checked == true) { Cad_Permisos = Cad_Permisos + "035,"; }
            if (checkBox36.Checked == true) { Cad_Permisos = Cad_Permisos + "036,"; }
            if (checkBox37.Checked == true) { Cad_Permisos = Cad_Permisos + "037,"; }
            if (checkBox38.Checked == true) { Cad_Permisos = Cad_Permisos + "038,"; }
            if (checkBox39.Checked == true) { Cad_Permisos = Cad_Permisos + "039,"; }
            if (checkBox40.Checked == true) { Cad_Permisos = Cad_Permisos + "040,"; }
            if (checkBox41.Checked == true) { Cad_Permisos = Cad_Permisos + "041,"; }
            if (checkBox42.Checked == true) { Cad_Permisos = Cad_Permisos + "042,"; }
            if (checkBox43.Checked == true) { Cad_Permisos = Cad_Permisos + "043,"; }
            if (checkBox44.Checked == true) { Cad_Permisos = Cad_Permisos + "044,"; }
            if (checkBox45.Checked == true) { Cad_Permisos = Cad_Permisos + "045,"; }
            if (checkBox46.Checked == true) { Cad_Permisos = Cad_Permisos + "046,"; }
            if (checkBox47.Checked == true) { Cad_Permisos = Cad_Permisos + "047,"; }
            if (checkBox48.Checked == true) { Cad_Permisos = Cad_Permisos + "048,"; }
            if (checkBox49.Checked == true) { Cad_Permisos = Cad_Permisos + "059,"; }
            if (checkBox50.Checked == true) { Cad_Permisos = Cad_Permisos + "050,"; }
            if (checkBox51.Checked == true) { Cad_Permisos = Cad_Permisos + "051,"; }
            if (checkBox52.Checked == true) { Cad_Permisos = Cad_Permisos + "052,"; }
            if (checkBox53.Checked == true) { Cad_Permisos = Cad_Permisos + "053,"; }
            if (checkBox54.Checked == true) { Cad_Permisos = Cad_Permisos + "054,"; }
            if (checkBox55.Checked == true) { Cad_Permisos = Cad_Permisos + "055,"; }
            if (checkBox56.Checked == true) { Cad_Permisos = Cad_Permisos + "056,"; }
            if (checkBox57.Checked == true) { Cad_Permisos = Cad_Permisos + "057,"; }
            if (checkBox58.Checked == true) { Cad_Permisos = Cad_Permisos + "058,"; }
            if (checkBox59.Checked == true) { Cad_Permisos = Cad_Permisos + "059,"; }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            permisos();
            if (txtUsuario.Text == "" )
            {
                MessageBox.Show("Favor de ingresar datos de Nombre de usuario");
                return; 
            }
            if (Cad_Permisos == "")
            {
                MessageBox.Show("Favor de asignar permisos al Usuario");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Favor de ingresar el password del Usuario");
                return;
            }

           

                Boolean resp;
            conn.AbrirBD();
            conn.inicio();

            panel1.Enabled = false;
            if (accion == "NUEVO")
            {
                resp = conn.Executa("insert into cat_usuarios (usuario, nombre,password" +
                ",permisos) values('" + txtUsuario.Text + "','" + txtNombre.Text + "','" + 
                txtPassword.Text + "','" + Cad_Permisos + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Usuario " + txtUsuario.Text + " Realizada con Exito¡");
            }else if (accion=="EDITAR")
            {
                if (Usuario == "" ) {return; }

                resp = conn.Executa("update cat_usuarios set nombre='" + txtNombre.Text + 
                    "',password='" + txtPassword.Text + "', permisos='" + Cad_Permisos + 
                    "' where usuario='" + txtUsuario.Text + "'");

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Usuario " + txtUsuario.Text + " Realizada con Exito¡");

            }

            limpiar();

        }

        private void frmCatUsuarios_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900, Accent.Green700, TextShade.WHITE);

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
            sql = "select usuario,nombre,estado,permisos from cat_usuarios where usuario<>'x' " + filtro;
            dgUsuarios.DataSource = conn.GetTable(sql);
            dgUsuarios.AutoResizeColumns();
            conn.cerrarBd();
        }
    }
}
