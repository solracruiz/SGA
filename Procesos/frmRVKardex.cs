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

namespace SGA.Procesos
{
    public partial class frmRVKardex : Form
    {
        public frmRVKardex()
        {
            InitializeComponent();
        }

        private void frmRVKardex_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            string consulta = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvKardex.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsKardex", dt);
            rvKardex.LocalReport.DataSources.Add(rp);

            this.rvKardex.RefreshReport();
        }
    }
}
