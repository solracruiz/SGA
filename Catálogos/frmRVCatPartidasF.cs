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
    public partial class frmRVCatPartidasF : Form
    {
        public frmRVCatPartidasF()
        {
            InitializeComponent();
        }

        private void frmRVCatPartidasF_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();

            conn.AbrirBD();

            DataTable dt = new DataTable();

            string consulta = "select * from cat_partidas_fed";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvPartidasf.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsPartidasf", dt);
            rvPartidasf.LocalReport.DataSources.Add(rp);

            rvPartidasf.RefreshReport();

            this.rvPartidasf.RefreshReport();
        }

        private void rvPartidasf_Load(object sender, EventArgs e)
        {

        }
    }
}
