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
    public partial class frmRVDetalleEntradas : Form
    {
        string filtro = "";
        public frmRVDetalleEntradas()
        {
            InitializeComponent();
        }

        private void frmRVDetalleEntradas_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select d.*,e.costofactura,e.iva as ivatotal,e.subtotal,e.tipo,c.nombre as producto,e.fechaentrada as fecha, " +
                " c.codigo,p.nombre as proveedor,e.fechafactura,e.remision,e.orden,e.numfactura,c.presentacion as medida, cf.descripcion as fuente " +
                " from det_entradas d, entradas e, cat_articulos c,cat_proveedores p, cat_ffinanciamiento cf " +
                " where e.id=d.identrada and d.idarticulo=c.id and e.idproveedor=p.id and cf.id=e.idfuente and identrada= " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvDetalleEntradas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsDetalleEntradas", dt);
            rvDetalleEntradas.LocalReport.DataSources.Add(rp);

            rvDetalleEntradas.RefreshReport();

            this.rvDetalleEntradas.RefreshReport();
        }
    }
}
