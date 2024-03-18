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
    public partial class frmRVCatProveedores : Form
    {
        string filtro = "";
        public frmRVCatProveedores()
        {
            InitializeComponent();
        }

        private void frmRVCatProveedores_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro=this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select * from cat_proveedores where id>0 " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvProveedores.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsProveedores", dt);
            rvProveedores.LocalReport.DataSources.Add(rp);

            rvProveedores.RefreshReport();

            this.rvProveedores.RefreshReport();
        }

        private void rvProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
