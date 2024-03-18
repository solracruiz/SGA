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
    public partial class frmRVDetalleRequisiciones : Form
    {
        string filtro = "";
        public frmRVDetalleRequisiciones()
        {
            InitializeComponent();
        }

        private void frmRVDetalleRequisiciones_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select  r.id,concat(cc.clue,' ',cc.descripcion) as clue,r.fecha,c.codigo as clave,c.nombre as articulo,c.presentacion as unidad,d.cantidad,cu.nombre as solicita " +
                " from det_requisiciones d, requisiciones r, cat_articulos c,cat_clues cc,cat_usuarios cu " +
                " where r.id=d.idrequisicion and d.idarticulo=c.id and r.idclue=cc.id and r.iduser=cu.iduser and idrequisicion= " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvDetalleRequisiciones.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsDetalleRequisiciones", dt);
            rvDetalleRequisiciones.LocalReport.DataSources.Add(rp);

            rvDetalleRequisiciones.RefreshReport();

            this.rvDetalleRequisiciones.RefreshReport();

            this.rvDetalleRequisiciones.RefreshReport();
        }

        private void rvDetalleRequisiciones_Load(object sender, EventArgs e)
        {

        }
    }
}
