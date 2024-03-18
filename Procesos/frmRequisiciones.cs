using MaterialSkin;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.Collections;
using SGA.Clases;
using SGA.Data_Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace SGA.Procesos
{
    public partial class FrmRequisiciones : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        Int16 Directa = 0;
        string filtro = "", filtro2 = "";
        Double ID_REQ = 0;
        Double ID_SAL = 0;
        public string sql = "",sql2="";
        Boolean resp = false;
        MySqlDataReader R;
        DateTime fecha1 ;
        DateTime fecha2 ;

        public FrmRequisiciones()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmRequisiciones_Load(object sender, EventArgs e)
        {
            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(BtnEliminar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnImprimir, "Imprime Registros y Exporta a Excel, Word ó PDF...");
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;
            if (Tag.ToString() == "1")
            {
                Directa = 1;
            
            }
            carga();

        }

        void carga()
        {
            conn.AbrirBD();

            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;


            sql = "select r.id as Folio, r.folio as Folio2,r.fecha as Fecha, r.justificacion as Detalles," +
             "concat(d.clue,' ',d.descripcion,' ',d.jurisdiccion) as Clue, e.nombre,if(r.estado='A','ACTIVA','VALIDADA') as estado" +
            " from requisiciones r, cat_clues d, cat_usuarios e " +
            " where d.id=r.idclue and e.iduser=r.iduser" +
            " and r.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and r.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            filtro2= filtro + " and r.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and r.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            sql2 = sql + filtro + " ORDER BY r.fecha limit 20";

            dgRequisiciones.DataSource = conn.GetTable(sql2);
            dgRequisiciones.AutoResizeColumns();
            if (dgRequisiciones.Rows.Count > 0)
            {
                dgRequisiciones.Columns[1].Visible = false;
            }
            conn.cerrarBd();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (e.nombre like '%" + txtBusqueda.Text +
                "%' or d.descripcion like '%" + txtBusqueda.Text +
                "%' or d.jurisdiccion like '%" + txtBusqueda.Text +
               "%' or d.clue like '%" + txtBusqueda.Text + "%') ";
            }
            else
            { 
                filtro = ""; 
            }
            carga();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmDetalleRequisiciones frm = new frmDetalleRequisiciones();
            frm.Tag = Directa;
            frm.ShowDialog();
            carga();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 id_det = 0, reg = 0, id_art = 0;
                conn.AbrirBD();
                conn.inicio();

                Int32 a = dgArticulos.Rows.Count;
                Int32 contador = 0;
                foreach (DataGridViewRow row in dgArticulos.Rows)
                {
                    contador += 1;
                    if (contador == a)
                    {
                        break;
                    }


                    string bandera = "False";
                    if (row.Cells[3].Value.ToString() != null)
                    {
                        bandera = row.Cells[3].Value.ToString();
                    }

                    if (bandera == "True")
                    {
                        id_art = Convert.ToInt64(row.Cells[5].Value.ToString());
                        R = conn.GetData("SELECT de.id,c.codigo,de.lote,de.caducidad FROM det_entradas de, cat_articulos c " +
                            " where de.idarticulo=c.id and de.existencia>0 and de.alerta=1 and de.idarticulo=" + id_art + ";");

                        if (R.HasRows)
                        {
                            R.Read();
                            MessageBox.Show("¡El producto con Codigo " + R["codigo"].ToString() +
                                ", lote " + R["lote"].ToString() + " y caducidad " + R["caducidad"].ToString() + " tiene alerta sanitaria y no podra ser surtido!");
                            R.Close();

                            R = conn.GetData("SELECT de.id,c.codigo,de.lote,de.caducidad FROM det_entradas de, cat_articulos c " +
                           " where de.idarticulo=c.id and de.existencia>0 and de.alerta=0 and de.idarticulo=" + id_art + ";");

                            if (R.HasRows)
                            { 
                                R.Read();
                                if (MessageBox.Show("¡El producto con Codigo " + R["codigo"].ToString() +
                                    ", lote " + R["lote"].ToString() + " y caducidad " + R["caducidad"].ToString() + " No tiene alerta sanitaria. ¿Desea validar el producto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    bandera = "True";
                                }
                                else { bandera = "False"; }
                            }

                        }
                        R.Close();

                        
                    }

                    if (bandera == "True")
                    {
                        if (reg == 0)
                        {
                            resp = conn.Executa("update requisiciones set estado='V' where id=" + ID_REQ);
                            if (!resp)
                            {
                                conn.fallo();
                                return;
                            }
                            resp = conn.Executa("insert into salidas (idclue, idrequisicion, iduser, fechareq,idprograma) " +
                            " select idclue," + ID_REQ + "," + configuracion.IDUSER +
                            ",fecha,idprograma from requisiciones where id=" + ID_REQ);
                            if (!resp)
                            {
                                conn.fallo();
                                return;
                            }
                            reg = 1;
                        }

                        id_det = Convert.ToInt64(row.Cells[4].Value.ToString());
                        resp = conn.Executa("update det_requisiciones set estado=0 where id = " + id_det);
                        if (!resp)
                        {
                            conn.fallo();
                            return;
                        }
                        R = conn.GetData("SELECT id FROM salidas where idrequisicion=" +
                            ID_REQ + ";");

                        if (R.HasRows)
                        {
                            R.Read();
                            ID_SAL = Int32.Parse(R[0].ToString());
                        }

                        R.Close();
                        resp = conn.Executa("insert into det_salidas (idsalida, idarticulo, cantidad) " +
                        " select " + ID_SAL + ",idarticulo,cantidad from det_requisiciones where  id = " + id_det);
                        if (!resp)
                        {
                            conn.fallo();
                            return;
                        }

                    }

                }



                conn.exito();
                conn.cerrarBd();
                carga();

                MessageBox.Show("Proceso Realizado con Exito");
                dgArticulos.Visible = false;
                BtnValidar.Visible = false;
                BtnCancelar.Visible = false;
            }
            catch (Exception ex) 
            {MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
             }
            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgRequisiciones.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¡Deseas Eliminar la Requisicion al Almacen?", "Precaucion",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.AbrirBD();
                    resp = conn.Executa("delete from requisiciones where id = " + dgRequisiciones.CurrentRow.Cells[0].Value);
                    if (!resp)
                    {
                        return;
                    }
                    else {
                        MessageBox.Show("Proceso Realizado con Exito");
                    }

                    conn.cerrarBd();
                    carga();

                }
            }
        }
        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgArticulos.Visible = false;
                BtnValidar.Visible = false;
            }
        }

        private void dgRequisiciones_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgRequisiciones.CurrentRow != null)
                {
                    if (dgRequisiciones.CurrentRow.Cells[0].Value.ToString() != "")
                    {
                        if (dgRequisiciones.CurrentRow.Cells["estado"].Value.ToString() == "VALIDAD")
                        {
                            MessageBox.Show("La Solicitud de Abasto ya fue Validada!");
                            return;
                        }
                            ID_REQ = double.Parse(dgRequisiciones.CurrentRow.Cells[0].Value.ToString());
                        DialogResult result = MessageBox.Show("¡Deseas Validar la Solicitud de Abasto " + ID_REQ + " al Almacen?", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            conn.AbrirBD();
                            dgArticulos.Rows.Clear();
                            MySqlDataReader R = conn.GetData("SELECT a.codigo, a.nombre, d.cantidad,d.estado,d.id as iddet,d.idarticulo FROM det_requisiciones d, cat_articulos a where d.idarticulo=a.id and d.idrequisicion=" + ID_REQ + ";");
                            if (R.HasRows)
                            {
                                int r = 0;
                                //VARIABLES GLOBALES
                                while (R.Read())
                                {
                                    dgArticulos.Rows.Insert(r, R["codigo"].ToString(), R["nombre"].ToString(), double.Parse(R["cantidad"].ToString()), "True", double.Parse(R["iddet"].ToString()), R["idarticulo"].ToString());
                                    r = r + 1;

                                }
                                R.Close();
                                dgArticulos.Visible = true;
                                BtnValidar.Visible = true;
                                BtnCancelar.Visible = true; 
                                conn.cerrarBd();

                            }
                            else
                            {
                                MessageBox.Show("La Requisicion no tiene productos autorizados!");
                            }


                            conn.cerrarBd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo al guardar en la BD:" + ex.Message, Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            }
        }

        
        private void dtp1_TextChanged(object sender, EventArgs e)
        {
            carga();

        }

        private void dtp2_TextChanged(object sender, EventArgs e)
        {
            carga();

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgArticulos.Visible = false;
            BtnValidar.Visible=false;
            BtnCancelar.Visible = false;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            double ID_REQ;
            if (dgRequisiciones.CurrentRow != null)
            {
                ID_REQ = double.Parse(dgRequisiciones.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("Desea reimprimir la Solicitud de Abasto " + ID_REQ + "?", "Reimprimir Solicitud de Abasto", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmRVDetalleRequisiciones frm = new frmRVDetalleRequisiciones();
                    frm.Tag = ID_REQ;
                    frm.ShowDialog();
                }
            }
        }

        private void dgRequisiciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        


        private void bt_exportar_Click(object sender, EventArgs e)
        {
            conn.AbrirBD();
            string nombre_archivo = "Listado de Requisiciones";
            modulo1.Exportar_Excel(conn.PropertyTable, nombre_archivo);
            conn.cerrarBd();
            MessageBox.Show("Proceso Realizado con Exito");
        }
    }
}
