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
    public partial class frmRVRequisiciones2 : Form
    {
        string filtro = "";
        public frmRVRequisiciones2()
        {
            InitializeComponent();
        }

        private void frmRVRequisiciones2_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select r.fecha,r.id as folio,c.jurisdiccion,concat(c.clue,' ',c.descripcion) as clue,ca.idpartidaf," + 
                " p.nombre as programa,cu.nombre as solicito,ca.codigo,ca.nombre as articulo,d.cantidad,r.estado as estatus,r.justificacion as especificaciones  " +
                " from requisiciones r, cat_clues c, cat_programas p, cat_usuarios cu, cat_articulos ca,det_requisiciones d " + 
                " where c.id=r.idclue and r.idprograma=p.id and r.iduser=cu.iduser and ca.id=d.idarticulo and d.idrequisicion=r.id " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvRequisiciones2.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsRequisiciones2", dt);
            rvRequisiciones2.LocalReport.DataSources.Add(rp);

            this.rvRequisiciones2.RefreshReport();

        }

    }
}
