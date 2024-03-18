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
    public partial class FrmRVBitacora : Form
    {
        public FrmRVBitacora()
        {
            InitializeComponent();
        }

        private void FrmRVBitacora_Load(object sender, EventArgs e)
        {
            MySqlConnection miConexion = new MySqlConnection("server=localhost; database=sga; " +
                    "Uid=root;  pwd = Ch1v4scampeo#");

            DataTable dt = new DataTable();

            string consulta = "select * from bitacora";
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, miConexion);
            da.Fill(dt);

            rvBitacora.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsBitacora", dt);
            rvBitacora.LocalReport.DataSources.Add(rp);
            rvBitacora.RefreshReport();                        
        }
    }
}
