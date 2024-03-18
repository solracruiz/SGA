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
    public partial class frmRVEntradas : Form
    {
        
        public frmRVEntradas()
        {
            InitializeComponent();
        }
        
        string filtro="";
        private void frmRVEntradas_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = "select year(e.fechaentrada) as ejercicio,fechaentrada,orden, "+
                "p.razonsocial as proveedor,c.codigo,c.nombre," +
                "de.cantidad,lote,caducidad,de.precio,totalprecio,marca,f.descripcion as fuente,e.id " +
                "from entradas e, det_entradas de, cat_proveedores p, cat_ffinanciamiento f, cat_articulos c " +
                "where e.id = de.identrada and de.idarticulo = c.id and e.idproveedor = p.id and e.idfuente = f.id " + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvEntradas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsEntradas", dt);
            rvEntradas.LocalReport.DataSources.Add(rp);

            rvEntradas.RefreshReport();


        }
    }
}
