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

namespace SGA.Reportes
{
    public partial class FrmReporteSalidas : Form
    {
        string filtro = "";
        public FrmReporteSalidas()
        {
            InitializeComponent();
        }

        private void FrmReporteSalidas_Load(object sender, EventArgs e)
        {

        }

        void validar()
        { 
        
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = "";
            
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select s.*,concat(c.clue,' ',c.descripcion) as clue " +
                " from salidas s, cat_clues c " +
                " where  c.id=s.idclue " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvSalidas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsSalidas", dt);


            rvSalidas.LocalReport.DataSources.Add(rp);


            this.rvSalidas.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
