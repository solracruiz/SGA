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
    public partial class frmRVSalidas : Form
    {
        string filtro = "";
        public frmRVSalidas()
        {
            InitializeComponent();
        }

        private void frmRVSalidas_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = " select s.id as folio,cu.nombre as solicita,s.fechasalida as fecha,p.razonsocial as proveedor,ca.idpartidaf," +
            " codigo,ca.nombre as articulo,ca.presentacion as medida,k.lote,k.caducidad,e.idfuente as fuente,concat(clue, ' ', cl.descripcion) as clue, cl.jurisdiccion," +
            " ds.cantidad,de.precio, de.totalprecio as subtotal,de.iva,(de.totalprecio + de.iva) as total " +
            " from salidas s, det_salidas ds, cat_articulos ca, kardex k, det_entradas de, entradas e, cat_proveedores p, cat_usuarios cu, cat_clues cl " +
            " where s.id = ds.idsalida and ds.idarticulo = ca.id and k.idtabla = ds.idsalida and k.idarticulo = ds.idarticulo and k.salida > 0 " +
            " and k.identrada = de.id and k.idarticulo = de.idarticulo and e.id = de.identrada and e.idproveedor = p.id and cu.iduser = s.iduser " +
            " and cl.id = s.idclue" + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvSalidas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsSalidas", dt);


            rvSalidas.LocalReport.DataSources.Add(rp);


            this.rvSalidas.RefreshReport();
        }
    }
}
