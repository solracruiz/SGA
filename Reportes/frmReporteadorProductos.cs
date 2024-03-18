using MaterialSkin;
using MySql.Data.MySqlClient;
using SGA.Catálogos;
using SGA.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Reportes
{
    public partial class frmReporteadorProductos : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();


        MySqlDataReader R;
        string Consulta = "";

        public frmReporteadorProductos()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void frmReporteadorProductos_Load(object sender, EventArgs e)
        {
            cargar();
        }
        void cargar()
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;


            conn.AbrirBD();
            R = conn.GetData("select id,nombre from cat_partidas_fed");
            cbxPartidaf.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxPartidaf.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn.cerrarBd();

            conn1.AbrirBD();
            R = conn1.GetData("select distinct tipo2 from cat_articulos");
            cbxTipo.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxTipo.Items.Add(R[0].ToString());
                }
            }
            R.Close();
            conn1.cerrarBd();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            int con = 0, lar = 0;
            String cadena = " - ";
            Consulta = "";
            if (cbxPartidaf.Text != "")
            {
                con = cbxPartidaf.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxPartidaf.Text.Length;
                cadena = cbxPartidaf.Text.Substring(con, lar - con);
                Consulta = Consulta + " and idpartidaf='" + cadena + "'";
            }

            if (cbxTipo.Text != "")
            {
                cadena = cbxTipo.Text.ToString();
                Consulta = Consulta + " and tipo2='" + cadena + "'";
            }


            frmRVCatProductos frm = new frmRVCatProductos();
            frm.Tag = Consulta;
            frm.ShowDialog();
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {

        }
    }
}
