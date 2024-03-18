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
    public partial class frmRVCatProductos : Form
    {
        string filtro = "";
        public frmRVCatProductos()
        {
            InitializeComponent();
        }

        private void frmRVCatProductos_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();


            string consulta = "select * from cat_articulos where codigo<>'000000' " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvProductos.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsProductos", dt);
            rvProductos.LocalReport.DataSources.Add(rp);

            rvProductos.RefreshReport();

            this.rvProductos.RefreshReport();
        }

        private void rvProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
