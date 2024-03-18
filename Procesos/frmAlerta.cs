using MaterialSkin;
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
    public partial class FrmAlerta : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        string sql = "", sql2 = "", filtro = "", estado=" and a.estatus=1";
        Boolean resp= false;
      
        public FrmAlerta()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmAlerta_Load(object sender, EventArgs e)
        {

            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo alerta sanitaria...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnEliminar, "Canlar Alerta Sanitaria ...");
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");
            mensajes.SetToolTip(BtnHistorico, "Mostrar Historico de Alertas Sanitarias ...");
            carga();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmDetalleAlertas frm = new frmDetalleAlertas();
            frm.ShowDialog();
            carga();
        }

        private void dgAlertas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgAlertas.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¡Deseas Eliminar la Alerta Sanitaria del Articulo " + 
                    dgAlertas.CurrentRow.Cells[2].Value  + " con numero de lote " + dgAlertas.CurrentRow.Cells["lote"].Value + "?", "Precaucion",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.AbrirBD();
                    conn.inicio();
                    resp = conn.Executa("update alertas set estatus=0 where  id = " + dgAlertas.CurrentRow.Cells[7].Value);
                    if (!resp)
                    {
                        conn.fallo();
                        return;
                    }
                    resp = conn.Executa("update det_entradas set alerta=0 where id = " + dgAlertas.CurrentRow.Cells[8].Value);
                    if (!resp)
                    {
                        conn.fallo();
                        return;
                    }

                    MessageBox.Show("Proceso Realizado con Exito");
                    

                    conn.exito();
                    conn.cerrarBd();
                    carga();

                }
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            double ID_ENT;
            if (dgAlertas.CurrentRow != null)
            {

                ID_ENT = double.Parse(dgAlertas.CurrentRow.Cells[7].Value.ToString());
                if (MessageBox.Show("Desea reimprimir la Alerta " + ID_ENT + "?", "Reimprimir Alerta", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmRVDetalleAlertas frm = new frmRVDetalleAlertas();
                    frm.Tag = ID_ENT;
                    frm.ShowDialog();
                }
            }
        }

        private void BtnHistorico_Click(object sender, EventArgs e)
        {
            estado = "";
            carga();
        }

        void carga()
        {
            conn.AbrirBD();
            

            sql = "select a.idarticulo as Producto,ca.codigo as Clave, ca.nombre as Nombre, date(a.fecha) as Fecha,de.lote,date(de.caducidad),a.motivo as Motivo, a.id as id ,a.identrada" +
                " from cat_articulos ca, alertas a, det_entradas de " +
                " where a.idarticulo=ca.id and a.identrada=de.id " + estado;
             
            sql2 = sql + filtro + " ORDER BY a.fecha limit 50";

            dgAlertas.DataSource = conn.GetTable(sql2);
            dgAlertas.AutoResizeColumns();

            if (dgAlertas.RowCount > 0)
            {
                dgAlertas.Columns["id"].Visible = false;
                dgAlertas.Columns["identrada"].Visible = false;
            }
            conn.cerrarBd();
            


        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
