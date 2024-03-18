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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Procesos
{
    public partial class frmRVEntradas2 : Form
    {
        
        public frmRVEntradas2()
        {
            InitializeComponent();
        }
        
        string filtro="";
        private void frmRVEntradas2_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select fechaentrada as fecha,orden,e.tipo,e.numfactura as factura,e.fechafactura,"+
                " p.razonsocial as proveedor,c.codigo,c.nombre as articulo,c.idpartidaf,c.presentacion as medida," +
                " de.cantidad,lote,caducidad,de.precio,totalprecio as subtotal,marca,f.descripcion as fuente,e.id as folio,de.iva, (de.iva+de.totalprecio) as total" +
                " from entradas e, det_entradas de, cat_proveedores p, cat_ffinanciamiento f, cat_articulos c " +
                " where e.id = de.identrada and de.idarticulo = c.id and e.idproveedor = p.id and e.idfuente = f.id " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvEntradas2.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsEntradas2", dt);
            rvEntradas2.LocalReport.DataSources.Add(rp);

            rvEntradas2.RefreshReport();


        }

        private void frmRVEntradas_Load_1(object sender, EventArgs e)
        {

        }
    }
}
