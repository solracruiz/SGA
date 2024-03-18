using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ReportingServices.Interfaces;
using SGA.Clases;
using static Guna.UI2.Native.WinApi;
using System.Configuration;
using System.Reflection;
using MySql.Data.MySqlClient;
using SGA.Catálogos;
using Microsoft.VisualBasic.Logging;
using System.Management.Instrumentation;
using SGA.Data_Sources;


namespace SGA.Procesos
{

    public partial class FrmEntradas : MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        MySqlDataReader R;
        int r = 0;
        public string filtro = "", filtro2 = "";
        public string sql = "",sql2="";
        DateTime fecha1;
        DateTime fecha2;

        public FrmEntradas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
            Primary.Blue900, Accent.Green700, TextShade.WHITE);


        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgEntradas_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEntradas.CurrentRow != null)
            {
                    DialogResult result = MessageBox.Show("¡Deseas Borrar la Entrada al Almacen?", "Precaucion",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        conn.AbrirBD();
                        conn.Executa("delete from entradas where id=" + dgEntradas.CurrentRow.Cells[0].Value.ToString());
                        conn.Executa("delete from det_entradas where identrada=" +
                        dgEntradas.CurrentRow.Cells[0].Value.ToString());
                        carga();
                        conn.cerrarBd();
                    }
            }

        }

            private void dgEntradas_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void btnEditar_Click(object sender, EventArgs e)
            {
            if (dgEntradas.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("¡Deseas Editar la Entrada al Almacen?", "Precaucion",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    frmDetallesEntrada Frm = new frmDetallesEntrada();
                    Frm.Tag = dgEntradas.CurrentRow.Cells[0].Value.ToString();
                    Frm.ShowDialog();
                    carga();
                }
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
            {
                frmDetallesEntrada Frm = new frmDetallesEntrada();
                Frm.Tag = "0";
                Frm.ShowDialog();
                carga();
            }

            private void txtBusqueda_TextChanged(object sender, EventArgs e)
            {
                
                if (txtBusqueda.Text.ToString().Length > 3)
                {
                    filtro = " and (a.nombre like '%" + txtBusqueda.Text +
                    "%' or p.nombre like '%" + txtBusqueda.Text +
                   "%' or e.numfactura like '%" + txtBusqueda.Text +
                   "%' or r.nombre like '%" + txtBusqueda.Text + "%')";
                }
                else
                {
                    filtro = "";
                }
                    carga();
            }


            private void FrmEntradas_Load(object sender, EventArgs e)
            {
                // mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
                
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(this.BtnNuevo, "Agregar un Registro");
                //toolTip.SetToolTip(this.BtnEliminar, "Eliminar Datos!");
                toolTip.SetToolTip(this.BtnGuardar, "Guardar Datos");
                toolTip.SetToolTip(this.BtnImprimir, "Imprimir Reporte");
                toolTip.SetToolTip(this.BtnSalir, "Cerrar esta Ventana");
            toolTip.SetToolTip(BtnImprimir, "Imprimir Registros...");


            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;


            carga();
            }


            void carga()
            {
            
            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;


            sql = "select e.id as Identificador, e.tipo as Tipo,e.fechaentrada as Fecha, " +
           "e.numfactura as Factura,e.fechafactura as Fecha_Factura, e.costofactura as Costo,e.iva as IVA, " +
           " f.descripcion as Fuente, p.nombre Proveedor, a.nombre as Almacen,r.nombre as Receptor " +
           " from entradas e, cat_almacen a, empleados r, cat_ffinanciamiento f, cat_proveedores p " +
           " where e.idalmacen=a.id and e.idrecibio=r.id and f.id=e.idfuente and p.id=e.idproveedor " +
            " and e.fechaentrada >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and e.fechaentrada <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            filtro2 = filtro + " and e.fechaentrada >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and e.fechaentrada <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            sql2 = sql + filtro + " order by fechaentrada limit 20";

            llenar_grid(sql2);
            
            }

        void llenar_grid(string sql)
        {
            conn.AbrirBD();
            int r = 0;
            DateTime fec = DateTime.Now;
            DateTime fec2 = DateTime.Now;
            R = conn.GetData(sql);
            dgEntradas.Rows.Clear();
            if (R.HasRows)
            {
                while (R.Read())
                {
                    fec = DateTime.Parse(R[2].ToString());
                    fec2 = DateTime.Parse(R[4].ToString());
                    dgEntradas.Rows.Insert(r, R[0].ToString(), R[1].ToString(), fec.ToString("yyyy-MM-dd"),
                        R[3].ToString(),fec2.ToString("yyyy-MM-dd"), Double.Parse(R[5].ToString()), Double.Parse(R[6].ToString()),
                        R[7].ToString(), R[8].ToString(), R[9].ToString(), R[10].ToString());
                    //fec.ToString("yyyy-MM-dd"));
                    r = r + 1;
                }
            }
            else
            {

            }
            R.Close();
            conn.cerrarBd();
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click_1(object sender, EventArgs e)
        {

        }

        private void dgEntradas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgEntradas_DoubleClick(object sender, EventArgs e)
        {
            double ID_ENT;
            if (dgEntradas.CurrentRow != null)
            {
                

                ID_ENT= double.Parse(dgEntradas.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("Desea reimprimir la Entrada " + ID_ENT + "?", "Reimprimir Entrada", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmRVDetalleEntradas frm = new frmRVDetalleEntradas();
                    frm.Tag = ID_ENT;
                    frm.ShowDialog();
                }
            }

        }

     

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            double ID_ENT;
            if (dgEntradas.CurrentRow != null)
            {

                ID_ENT = double.Parse(dgEntradas.CurrentRow.Cells[0].Value.ToString());
                if (MessageBox.Show("Desea reimprimir la Entrada " + ID_ENT + "?", "Reimprimir Entrada", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmRVDetalleEntradas frm = new frmRVDetalleEntradas();
                    frm.Tag = ID_ENT;
                    frm.ShowDialog();
                }
            }
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp1_TextChanged(object sender, EventArgs e)
        {

            carga();
        }

        private void dtp2_TextChanged(object sender, EventArgs e)
        {

            carga();
        }

    }
    }






