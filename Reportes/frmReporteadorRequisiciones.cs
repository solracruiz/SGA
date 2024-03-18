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
    public partial class frmReporteadorRequisiciones :  MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();

        MySqlDataReader R;
        string Consulta = "";
        DateTime fecha1;
        DateTime fecha2;
        public frmReporteadorRequisiciones()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void frmReporteadorRequisiciones_Load(object sender, EventArgs e)
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
            R = conn2.GetData("select id,nombre from cat_programas");
            cbxPrograma.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxPrograma.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn2.cerrarBd();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            int con = 0, lar = 0;
            String cadena = " - ";
            if (cbxClue.Text != "")
            {
                con = cbxClue.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxClue.Text.Length;
                cadena = cbxClue.Text.Substring(con, lar - con);

                Consulta = " and c.id='" + cadena + "'";
            }

            if (cbxPrograma.Text != "")
            {
                con = cbxPrograma.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxPrograma.Text.Length;
                cadena = cbxPrograma.Text.Substring(con, lar - con);
                Consulta = " and p.id='" + cadena + "'";
            }

            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;

            Consulta = Consulta + " and r.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and r.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";
            if (checkBox1.Checked == true)
            {
                frmRVRequisiciones2 frm = new frmRVRequisiciones2();
                frm.Tag = Consulta;
                frm.ShowDialog();
            }
            else
            {
                frmRVRequisiciones frm = new frmRVRequisiciones();
                frm.Tag = Consulta;
                frm.ShowDialog();
            }
        }
    }
}
