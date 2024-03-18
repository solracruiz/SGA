using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using SGA.Clases;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using MaterialSkin;
using System.Configuration;
using System.Linq.Expressions;
using System.Management.Instrumentation;
using SGA.Catálogos;

namespace SGA
{
    public partial class FrmAcceso : MaterialSkin.Controls.MaterialForm
    {
        //CREAR ROLES DE USUARIOS
        //CONECTAR A LA BD SGA
        //INICIAR CON ESTE FORMULARIO: TOMA NOTAS
        //MATERIAL SKIN DEBE INICIAR CON EL MENU PRINCIPAL
        //REVISAR LA PANTALLA QUE ALEX ENVIO DE DETALLE DE ENTRADAS

        /* necesitamos descargar el conector mysql, agregar el conector
         * a nuestro proyecto, crear una conexion con mysql   */

        conexion conn = new conexion();



        MySqlDataReader R;
        string sql = "", accion = "", filtro = "";



        public FrmAcceso()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

            
        }

        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmAcceso_Load_1(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { BtnOK_Click(sender, e); }
        }
        private void BtnOK_Click(object sender, EventArgs e)
        {
            conn.AbrirBD();
            R = conn.GetData("select iduser,permisos from cat_usuarios where usuario='" + txtusuario.Text + "' and password='" + txtPassword.Text + "'");
            if (R.HasRows)
            {
                R.Read();
                configuracion.USER = txtusuario.Text;
                configuracion.IDUSER = R[0].ToString();
                configuracion.PERMISOS = R[1].ToString();
                SGAMenu FrmSGAMenu = new SGAMenu();
                this.Hide();
                FrmSGAMenu.Show();
            }
            else {
                MessageBox.Show("Verifique su nombre de Usuario y Password¡");
            }

            R.Close();
            conn.cerrarBd();


            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

