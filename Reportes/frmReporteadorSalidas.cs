using MaterialSkin;
using MySql.Data.MySqlClient;
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
    public partial class frmReporteadorSalidas : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        conexion conn3 = new conexion();
        conexion conn4 = new conexion();
        conexion conn5 = new conexion();

        MySqlDataReader R;
        string Consulta = "";
        DateTime fecha1;
        DateTime fecha2;
        public frmReporteadorSalidas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void frmReporteadorSalidas_Load(object sender, EventArgs e)
        {
            cargar();
        }
        void cargar()
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            conn1.AbrirBD();
            R = conn1.GetData("select id,concat(clue,' ',descripcion) as clue from cat_clues order by clue");
            cbxClue.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxClue.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn1.cerrarBd();

            conn2.AbrirBD();
            R = conn2.GetData("select id,nombre from cat_proveedores");
            cbxProveedor.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxProveedor.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn2.cerrarBd();

            conn3.AbrirBD();
            R = conn3.GetData("select id,nombre from cat_partidas_fed");
            cbxPartidaf.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxPartidaf.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn3.cerrarBd();

            conn4.AbrirBD();
            R = conn4.GetData("select id,descripcion from cat_ffinanciamiento");
            cbxFuente.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxFuente.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn4.cerrarBd();

            conn5.AbrirBD();
            R = conn5.GetData("select distinct jurisdiccion from cat_clues");
            cbxJurisdiccion.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxJurisdiccion.Items.Add(R[0].ToString());
                }
            }
            R.Close();
            conn5.cerrarBd();

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
            if (cbxClue.Text != "")
            {
                con = cbxClue.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxClue.Text.Length;
                cadena = cbxClue.Text.Substring(con, lar - con);

                Consulta = Consulta + " and cl.id='" + cadena + "'";
            }

            if (cbxProveedor.Text != "")
            {
                con = cbxProveedor.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxProveedor.Text.Length;
                cadena = cbxProveedor.Text.Substring(con, lar - con);
                Consulta = Consulta + " and p.id='" + cadena + "'";
            }

            if (cbxFuente.Text != "")
            {
                con = cbxFuente.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxFuente.Text.Length;
                cadena = cbxFuente.Text.Substring(con, lar - con);
                Consulta = Consulta + " and e.idfuente='" + cadena + "'";
            }
            if (cbxPartidaf.Text != "")
            {
                con = cbxPartidaf.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxPartidaf.Text.Length;
                cadena = cbxPartidaf.Text.Substring(con, lar - con);
                Consulta = Consulta + " and ca.idpartidaf='" + cadena + "'";
            }

            if (cbxJurisdiccion.Text != "")
            {
                cadena = cbxJurisdiccion.Text.ToString();
                Consulta = Consulta + " and cl.jurisdiccion='" + cadena + "'";
            }



            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;

            Consulta = Consulta + " and fechasalida >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and fechasalida <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            frmRVSalidas frm = new frmRVSalidas();
            frm.Tag = Consulta;
            frm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
