using Microsoft.Reporting.WinForms;
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
    public partial class frmRVCatPartidasE : Form
    {
        public frmRVCatPartidasE()
        {
            InitializeComponent();
        }

        private void frmRVCatPartidasE_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();

            conn.AbrirBD();

            DataTable dt = new DataTable();

            string consulta = "select * from cat_partidas_est";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvPartidase.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsPartidase", dt);
            rvPartidase.LocalReport.DataSources.Add(rp);

            rvPartidase.RefreshReport();

            //this.rvPartidase.RefreshReport();
        }

        private void rvPartidase_Load(object sender, EventArgs e)
        {

        }
    }
}
