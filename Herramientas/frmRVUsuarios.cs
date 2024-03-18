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

namespace SGA.Herramientas
{
    public partial class frmRVUsuarios : Form
    {
        public frmRVUsuarios()
        {
            InitializeComponent();
        }

        private void frmRVUsuarios_Load(object sender, EventArgs e)
        {

            MySqlConnection miConexion = new MySqlConnection("server=localhost; database=sga; " +
               "Uid=root;  pwd = Ch1v4scampeo#");

            DataTable dt = new DataTable();

            string consulta = "select * from ususarios";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, miConexion);
            da.Fill(dt);

            rvUsuarios.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsUsuarios", dt);
            rvUsuarios.LocalReport.DataSources.Add(rp);

            rvUsuarios.LocalReport.Refresh();
            rvUsuarios.Refresh();
            rvUsuarios.RefreshReport();
        }
    }
}
