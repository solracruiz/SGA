using MaterialSkin;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace SGA.Procesos
{
    public partial class FrmSalidas : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn2 = new conexion();
        string filtro = "", filtro2 = "";
        public string sql = "", sql2 = "";
        bool resp;
        public double ID_SAL = 0;
        DateTime fecha1;
        DateTime fecha2;
        DateTime fecha_salida;
        MySqlDataReader R, RR;
        public FrmSalidas()
        {

            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }


        private void grid_inv_DoubleClick(object sender, EventArgs e)
        {
            return;
            #pragma warning disable CS0162 // Se detectó código inaccesible
            if (dgSalidas.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("¡Deseas Borrar la Entrada al Almacen ? ", "Precaucion", MessageBoxButtons.YesNo, 
               MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.AbrirBD();
                    conn.Executa("delete from entradas where id=" +
                    dgSalidas.CurrentRow.Cells[0].Value.ToString());
                    conn.Executa("delete from det_entradas where identrada=" +
                   dgSalidas.CurrentRow.Cells[0].Value.ToString());
                    carga();
                    conn.cerrarBd();
                }
            }
        #pragma warning restore CS0162 // Se detectó código inaccesible
        }

        private void FrmSalidas_Load(object sender, EventArgs e)
        {
            ToolTip mensajes = new ToolTip();

            mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
            mensajes.SetToolTip(btnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(btnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(btnImprimir, "Imprimir Registro y Exportar a Excel, Word o PDF...");
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;
            carga();
        }
        void carga()
        {
            conn.AbrirBD();
            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;

            sql = "select s.id as Folio, s.tipo as Tipo, s.fechareq as Fecha_Solicitud, " +
            " concat(d.clue,' ',d.descripcion) as Clue,e.nombre as Capturo, idrequisicion as Solicitud_Abasto,s.estatus" +
            " from salidas s, empleados e, cat_clues d " +
            " where s.iduser=e.id and d.id=s.idclue" +
            " and s.fechareq >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and s.fechareq <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            filtro2=filtro+ " and s.fechareq >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and s.fechareq <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            sql2 = sql + filtro + " ORDER BY FECHAreq limit 20";


            dgSalidas.DataSource = conn.GetTable(sql2);
            dgSalidas.AutoResizeColumns();



            conn.cerrarBd();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgSalidas.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("¡Deseas Editar la Salida al Almacen ? ", "Precaucion", MessageBoxButtons.YesNo, 
               MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    frmDetallesEntrada frm = new frmDetallesEntrada();
                    frm.Tag = dgSalidas.CurrentRow.Cells[0].Value.ToString();
                    frm.ShowDialog();
                    carga();
                }
            }
        }
        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            filtro = "";
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (clue like '%" + txtBusqueda.Text +
                "%' or r.nombre like '%" + txtBusqueda.Text + "%') limit 20";
            }
            carga();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Mandar a programar
            conn.AbrirBD();
            conn.inicio();
            Int32 a = dgSalidas.Rows.Count;
            Int32 contador = 0;
            foreach (DataGridViewRow row in dgSalidas.Rows)
            {
                contador += 1;
                if (contador == a)
                {
                    break;
                }
                string bandera = "false";
                bandera = row.Cells[4].Value.ToString();
                if (bandera == "True")
                {
                    ID_SAL = Convert.ToDouble(row.Cells[5].Value.ToString());
                    conn.Executa("update salidas set estatus='A' where id=" +
                    ID_SAL);
                }
            }
            carga();
        }
        private void bt_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void Grid_CellContentClick(object sender,DataGridViewCellEventArgs e)
        {
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            conn.AbrirBD();
            string nombre_archivo = "Listado de Salidas";
            modulo1.Exportar_Excel(conn.PropertyTable, nombre_archivo);
            conn.cerrarBd();
            MessageBox.Show("Proceso Realizado con Exito");
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
        
            if (txtBusqueda.Text.ToString().Length > 3)
            {
                filtro = " and (d.clue like '%" + txtBusqueda.Text +
               "%' or d.descripcion like '%" + txtBusqueda.Text +
               "%' or e.nombre like '%" + txtBusqueda.Text + "%')";
            }
            else 
            {
                filtro = "";
            }
            carga();
        }

        private void dtp1_TextChanged(object sender, EventArgs e)
        {
            carga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //frmRVSalidas frm = new frmRVSalidas();
            double ID_SAL;
            if (dgSalidas.CurrentRow != null)
            {

                ID_SAL = double.Parse(dgSalidas.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("Desea reimprimir la Salida " + ID_SAL + "?", "Reimprimir Entrada", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    frmRVDetalleSalidas frm = new frmRVDetalleSalidas();
                    frm.Tag = ID_SAL;
                    frm.ShowDialog();
                }
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {

        }

        private void dgSalidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgSalidas_DoubleClick(object sender, EventArgs e)
        {
            Int64 id_art = 0;
            string stado = "";
            string bandera = "False";
            if (dgSalidas.CurrentRow.Cells[0].Value.ToString() != "")
            {

                ID_SAL = double.Parse(dgSalidas.CurrentRow.Cells[0].Value.ToString());
                stado = dgSalidas.CurrentRow.Cells["estatus"].Value.ToString();
                
                fecha_salida = DateTime.Parse(dgSalidas.CurrentRow.Cells[2].Value.ToString());
                if (stado == "S")
                {
                    DialogResult result = MessageBox.Show("¡Deseas Reimprimir la Salida " + ID_SAL + " al Almacen?", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        frmRVDetalleSalidas frm = new frmRVDetalleSalidas();
                        frm.Tag = ID_SAL;
                        frm.ShowDialog();
                    }
                }
                else 
                {

                  
                        DialogResult result2 = MessageBox.Show("¡Deseas Surtir la Salida " + ID_SAL + " al Almacen?", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result2 == DialogResult.Yes)
                        {
                            BtnValidar.Visible = true;
                            conn.AbrirBD();
                            conn2.AbrirBD();
                            dgArticulos.Rows.Clear();
                            MySqlDataReader R = conn.GetData("SELECT d.idarticulo, a.nombre, d.cantidad,a.existencia,0,d.id as iddet FROM det_salidas d, cat_articulos a where d.idarticulo=a.id and d.idsalida=" + ID_SAL + ";");
                            if (R.HasRows)
                            {
                                int r = 0;
                                //VARIABLES GLOBALES
                                while (R.Read())
                                {

                                    id_art = Convert.ToInt64(R["idarticulo"].ToString());
                                    MySqlDataReader RR = conn2.GetData("SELECT de.id,c.codigo,de.lote,de.caducidad FROM det_entradas de, cat_articulos c " +
                                        " where de.idarticulo=c.id and de.existencia>0 and de.alerta=1 and de.idarticulo=" + id_art + ";");

                                    if (RR.HasRows)
                                    {
                                        RR.Read();
                                        MessageBox.Show("¡El producto con Codigo " + RR["codigo"].ToString() +
                                            ", lote " + RR["lote"].ToString() + " y caducidad " + RR["caducidad"].ToString() + " tiene alerta sanitaria y no podra ser surtido!");
                                        RR.Close();

                                        RR = conn2.GetData("SELECT de.id,c.codigo,de.lote,de.caducidad FROM det_entradas de, cat_articulos c " +
                                       " where de.idarticulo=c.id and de.existencia>0 and de.alerta=0 and de.idarticulo=" + id_art + ";");

                                        if (RR.HasRows)
                                        {
                                            RR.Read();
                                            if (MessageBox.Show("¡El producto con Codigo " + RR["codigo"].ToString() +
                                                ", lote " + RR["lote"].ToString() + " y caducidad " + RR["caducidad"].ToString() + " No tiene alerta sanitaria. ¿Desea surtir el producto?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                bandera = "True";
                                            }
                                            else { bandera = "False"; }
                                        }

                                    }
                                    else
                                    {
                                        bandera = "True";
                                    }
                                    RR.Close();

                                    if (bandera == "True")
                                    {

                                        RR = conn2.GetData("SELECT de.id,c.codigo,de.lote,de.marca FROM det_entradas de, cat_articulos c " +
                                       " where de.idarticulo=c.id and de.existencia>0 and de.alerta=0 and de.idarticulo=" + id_art + ";");

                                        if (RR.HasRows)
                                        {
                                            RR.Read();

                                        }

                                        dgArticulos.Rows.Insert(r, (int)Int64.Parse(R["idarticulo"].ToString()), RR["codigo"].ToString(), R["nombre"].ToString(), RR["lote"].ToString(), RR["marca"].ToString(), double.Parse(R["cantidad"].ToString()), double.Parse(R["existencia"].ToString()), "0", double.Parse(R["iddet"].ToString()));
                                        RR.Close();
                                        r = r + 1;
                                    }
                                }
                                R.Close();
                                dgArticulos.Visible = true;
                                BtnValidar.Visible = true;
                                BtnCancelar.Visible = true;
                                conn.cerrarBd();

                            }
                            else
                            {
                                MessageBox.Show("La salida numero " + ID_SAL + " no tiene articulos por surtir!");
                            }


                            conn.cerrarBd();
                        }
                    
                }
            }



            //SURTIR SALIDAS
            // MOSTRAR DETALLES Y PERMITIR CAPTURAR CANTIDADES PARA SURTIDO ABAJO DE LA EXISTENCIA

        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {

            Afectar_Existencias();
            carga();
        }

        Boolean Afectar_Existencias()
        {
            DateTime fec = DateTime.Now;
            double nuevo_costo = 0, nueva_exis = 0, sal = 0, precio = 0;
            Int64 ID_ART = 0;
            DateTime caducidad;

            string f = " order by de.identrada asc", marca = "";
            if (configuracion.METODO == "PE")
            {
                f = " order by de.caducidad asc";
            }

            conn.AbrirBD();
            conn.inicio();

            for (int fila = 0; fila < dgArticulos.Rows.Count - 1; fila++)
            {

                ID_ART = Int64.Parse(dgArticulos.Rows[fila].Cells[0].Value.ToString());
                nueva_exis = Int32.Parse(dgArticulos.Rows[fila].Cells[7].Value.ToString());
                precio = 0;
                nuevo_costo = 0;
                dgExistencias.Rows.Clear();
                MySqlDataReader R = conn.GetData("select de.existencia as existencia, de.precio as precio, de.caducidad as caducidad, de.marca,de.lote, de.id as iddet from det_entradas de, entradas e " +
                    " where de.identrada=e.id and de.existencia>0 and de.idarticulo=" + ID_ART + " and de.existencia>0 and de.alerta=0 " + f);
                if (R.HasRows)
                {
                    int r = 0;
                    //VARIABLES GLOBALES
                    while (R.Read())
                    {
                        dgExistencias.Rows.Insert(r, Int32.Parse(R["existencia"].ToString()), Double.Parse(R["precio"].ToString()), R["caducidad"].ToString(), R["marca"].ToString(), R["lote"].ToString(), double.Parse(R["iddet"].ToString()));
                        //MessageBox.Show(R["existencia"].ToString());
                        r = r + 1;
                    }
                    

                }
                R.Close();

                //nueva_exis  es lo solicitado que se va surtiendo
                String str = "";
                for (int fila2 = 0; (fila2 < dgExistencias.Rows.Count - 1 && nueva_exis > 0); fila2++)
                {
                    if (Int64.Parse(dgExistencias.Rows[fila2].Cells["salida"].Value.ToString()) >= nueva_exis)
                    { sal = nueva_exis; }
                    else
                    { sal = Int64.Parse(dgExistencias.Rows[fila2].Cells["salida"].Value.ToString()); }

                    caducidad = DateTime.Parse(dgExistencias.Rows[fila2].Cells["caducidad"].Value.ToString());
                    marca = dgExistencias.Rows[fila2].Cells["marca"].Value.ToString();
                    precio = Double.Parse(dgExistencias.Rows[fila2].Cells["precio"].Value.ToString());
                    nueva_exis = nueva_exis - sal;
                    nuevo_costo = precio * sal;

                    //GUARDAR EN LA TABLA KARDEX EL MOV DE SALIDA
                    str = "insert into kardex (idtabla,idarticulo,entrada,salida,precio,costo,fecha,existencia,identrada)" +
                       "values(" + ID_SAL + "," + ID_ART + ",0," + sal + "," + precio + "," +
                        nuevo_costo + ",'" + caducidad.ToString("yyyy-MM-dd") + "',0," + dgExistencias.Rows[fila2].Cells["iddet"].Value + ")";
                    //MessageBox.Show(str);
                    resp = conn.Executa(str);
                    if (!resp) { conn.fallo(); return false; }
                    //CALCULAR PRECIO PROMEDIO 
                    str = "update cat_articulos set existencia=existencia-" + sal + " where id=" + ID_ART;
                    resp = conn.Executa(str);
                    if (!resp) { conn.fallo(); return false; }

                    str = "update kardex k, cat_articulos a set k.existencia=a.existencia where " +
                    "a.id=k.idarticulo and k.salida=" + sal + " and costo=" + nuevo_costo + 
                    " and idtabla=" + ID_SAL;
                    
                    if (!conn.Executa(str)) { conn.fallo(); return false; }

                    str = "update det_entradas set existencia=existencia-"
                            + sal + " where id=" + dgExistencias.Rows[fila2].Cells["iddet"].Value.ToString();
                    resp = conn.Executa(str);
                    if (!resp) { conn.fallo(); return false; }

                    

                }//segundo for
                str = "update salidas set estatus='S',fechasalida='" + DateTime.Now.ToString("yyyy-MM-dd") + "' where id=" + ID_SAL;
                resp = conn.Executa(str);
                if (!resp) { conn.fallo(); return false; }

                str = "update kardex k, salidas s set k.fecha=s.fechasalida, k.fechasis='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "' where s.id=k.idtabla and k.salida>0 and s.id=" + ID_SAL;
                resp = conn.Executa(str);
                if (!resp) { conn.fallo(); return false; }

            }//primer for
            //Inventario.ActiveForm=true;
            conn.exito();
            conn.cerrarBd();

            MessageBox.Show("Proceso Realizado con Exito");

            dgArticulos.Visible = false;
            BtnCancelar.Visible = false;
            return true;
        }

        private void dgArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtp2_TextChanged(object sender, EventArgs e)
        {
            carga();
        }

        private void dgArticulos_CellEnter(object sender,DataGridViewCellEventArgs e)
        {
            dgArticulos[e.ColumnIndex, e.RowIndex].Style
                .SelectionBackColor = Color.Blue;
        }

        private void dgArticulos_CellLeave(object sender,DataGridViewCellEventArgs e)
        {
            dgArticulos[e.ColumnIndex, e.RowIndex].Style
                .SelectionBackColor = Color.Empty;

           }

        private void dgArticulos_CellValidating(object sender,DataGridViewCellValidatingEventArgs e)
        {
           
        }

        void dgArticulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dgArticulos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            dgArticulos.Visible = false;
            BtnValidar.Visible = false;
            BtnCancelar.Visible = false;
        }

        private void dgArticulos_CellValueChanged( object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                // Update the balance column whenever the value of any cell changes.
                Int32 number1 = 0;
                bool canConvert = Int32.TryParse(dgArticulos[e.ColumnIndex, e.RowIndex].Value.ToString(), out number1);
                if (canConvert == false)
                {
                    dgArticulos.Rows[e.RowIndex].ErrorText =
                        "La cantidad a surtir debe ser numerico";
                    MessageBox.Show("La cantidad a surtir debe ser numerico ");
                    dgArticulos[e.ColumnIndex, e.RowIndex].Value = 0;
                }
                else
                {
                    if (Int32.Parse( dgArticulos[e.ColumnIndex, e.RowIndex].Value.ToString())> Int32.Parse(dgArticulos[6, e.RowIndex].Value.ToString()))
                    {
                        MessageBox.Show("Verificar existencia del producto " + dgArticulos[2, e.RowIndex].Value.ToString());
                        dgArticulos[e.ColumnIndex, e.RowIndex].Value = Int32.Parse(dgArticulos[6, e.RowIndex].Value.ToString());

                    }
                    if (Int32.Parse(dgArticulos[e.ColumnIndex, e.RowIndex].Value.ToString()) > Int32.Parse(dgArticulos[5, e.RowIndex].Value.ToString()))
                    {
                        MessageBox.Show("Verificar la cantidad solicitada del producto " + dgArticulos[1, e.RowIndex].Value.ToString());
                        dgArticulos[e.ColumnIndex, e.RowIndex].Value = Int32.Parse(dgArticulos[5, e.RowIndex].Value.ToString());

                    }

                }
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
