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
    public partial class frmRVRequisiciones : Form
    {
        string filtro = "";
        public frmRVRequisiciones()
        {
            InitializeComponent();
        }

        private void frmRVRequisiciones_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select r.*,c.clue,c.descripcion,p.nombre from requisiciones r, cat_clues c, cat_programas p " + 
                " where c.id=r.idclue and r.idprograma=p.id  " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvRequisiciones.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsRequisiciones", dt);
            rvRequisiciones.LocalReport.DataSources.Add(rp);

            this.rvRequisiciones.RefreshReport();

        }


    }
}
