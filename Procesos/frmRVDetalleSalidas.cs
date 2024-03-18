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
    public partial class frmRVDetalleSalidas : Form
    {
        string filtro = "";
        public frmRVDetalleSalidas()
        {
            InitializeComponent();
        }

        private void frmRVDetalleSalidas_Load(object sender, EventArgs e)
        {
            conexion conn = new conexion();
            filtro = this.Tag.ToString();
            conn.AbrirBD();
            DataTable dt = new DataTable();

            string consulta = " select k.salida as cantidad,k.costo,k.precio,k.iva,de.lote,de.marca,de.caducidad " + 
                 ",s.tipo,s.fechasalida as fecha,c.nombre as producto,c.codigo,concat(cc.clue,' ' ,cc.descripcion) as clue,d.idsalida, c.presentacion as medida " +
                 " from det_salidas d, salidas s, cat_articulos c,cat_clues cc, kardex k, det_entradas de " +
                 " where s.id = d.idsalida and d.idarticulo = c.id and s.idclue = cc.id " +
                 " and k.salida > 0 and k.idtabla = d.idsalida and k.idarticulo = d.idarticulo and de.id = k.identrada and s.id=" + filtro;
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn.PropertyConexion);
            da.Fill(dt);

            rvDetalleSalidas.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("dsDetalleSalidas", dt);
            rvDetalleSalidas.LocalReport.DataSources.Add(rp);

            this.rvDetalleSalidas.RefreshReport();
        }

        private void rvDetalleSalidas_Load(object sender, EventArgs e)
        {

        }
    }
}
