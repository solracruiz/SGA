
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaterialSkin;
using MySql.Data.MySqlClient;
using SGA.Clases;
using SGA.Procesos;

namespace SGA.Reportes
{
    public partial class frmReporteadorEntradas : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        MySqlDataReader R;
        string Consulta = "";
        DateTime fecha1;
        DateTime fecha2;
        public frmReporteadorEntradas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void frmReporteadorEntradas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        void cargar()
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            conn1.AbrirBD();
            R = conn1.GetData("select id,nombre from cat_proveedores order by nombre");
            cbxProveedor.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxProveedor.Items.Add(R[1].ToString() + " - " + R[0].ToString());
                }
            }
            R.Close();
            conn1.cerrarBd();
            /*conn1.AbrirBD();
            cbxProveedor.DisplayMember = "nombre";
            cbxProveedor.ValueMember = "id";
            cbxProveedor.DataSource = conn1.GetTable("select id,nombre from cat_proveedores");
            conn1.cerrarBd();
            */
            conn2.AbrirBD();
            R = conn2.GetData("select id,descripcion from cat_ffinanciamiento order by id");
            cbxFuente.Items.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    cbxFuente.Items.Add(R[1].ToString() + " - " + R[01].ToString());
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
            if (cbxProveedor.Text != "")
            {
                con = cbxProveedor.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxProveedor.Text.Length;
                cadena = cbxProveedor.Text.Substring(con, lar - con);

                Consulta = " and p.id='" + cadena + "'";
            }
            if (cbxFuente.Text != "")
            {
                con = cbxFuente.Text.IndexOf(" - ");
                con = con + 3;
                lar = cbxFuente.Text.Length;
                cadena = cbxFuente.Text.Substring(con, lar - con);
                Consulta = Consulta + " and f.id='" + cadena + "'";
            }

            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;
            Consulta = Consulta + " and e.fechaentrada >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and e.fechaentrada <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            if (checkBox1.Checked == true)
            {
                frmRVEntradas frm = new frmRVEntradas();
                frm.Tag = Consulta;
                frm.ShowDialog();
            }
            else 
            {
                frmRVEntradas2 frm = new frmRVEntradas2();
                frm.Tag = Consulta;
                frm.ShowDialog();
            }



        }
    }
}
