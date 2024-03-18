using Microsoft.Reporting.WinForms;
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
    public partial class frmRVCatFF : Form
    {
        public frmRVCatFF()
        {
            InitializeComponent();
        }

        private void frmRVCatFF_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();

            conn.AbrirBD();

            DataTable dt= new DataTable();

            string consulta = "select * from cat_ffinanciamiento";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);
           
            rvFF.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource ("dsFF", dt);
            rvFF.LocalReport.DataSources.Add(rp);

            rvFF.RefreshReport();
            
        }

        private void rvFF_Load(object sender, EventArgs e)
        {

        }
    }
}
