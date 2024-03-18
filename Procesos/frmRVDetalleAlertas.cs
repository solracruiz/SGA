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

namespace SGA.Procesos
{
    public partial class frmRVDetalleAlertas : Form
    {
        string filtro = "";
        public frmRVDetalleAlertas()
        {
            InitializeComponent();
        }

        private void frmRVDetalleAlertas_Load(object sender, EventArgs e)
        {

            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select a.id, a.identrada,e.lote,e.marca,a.fecha,a.motivo,c.nombre as articulo " +
                " from alertas a, det_entradas e, cat_articulos c " +
                " where a.identrada=e.id and e.idarticulo=c.id and a.id= " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvAlertas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsAlertas", dt);
            rvAlertas.LocalReport.DataSources.Add(rp);

            rvAlertas.RefreshReport();
        }
    }
}
