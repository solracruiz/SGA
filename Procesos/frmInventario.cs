using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SGA.Procesos
{
    public partial class frmInventario : MaterialForm
    {
        conexion conn = new conexion();
        Boolean resp;

        public string filtro = "", filtro2 = "";
        public string sql = "", sql2 = "";
        DateTime fecha1;
        DateTime fecha2;

        public frmInventario()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void dgInventario_DoubleClick(object sender, EventArgs e)
        {
            if (dgInventario.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("¡Deseas Borrar el Inventario ? ", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.AbrirBD();
                    resp = conn.Executa("delete from inventarios where id= grid_inv.CurrentRow.Cells[0].Value.ToString()");
                    resp = conn.Executa("delete from det_inventarios where idinventario = " + dgInventario.CurrentRow.Cells[0].Value.ToString());

                    carga();
                    conn.cerrarBd();
                }
            }
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip mensajes = new System.Windows.Forms.ToolTip();
            mensajes.SetToolTip(txtBusqueda, "Registro a buscar...");
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
            //mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            //mensajes.SetToolTip(btnGrabar, "Guardar Registro..."); 
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");
            carga();
        }

            void carga()
            {
                conn.AbrirBD();
                fecha1 = dtp1.Value;
                fecha2 = dtp2.Value;


            sql = "select i.id as Identificador, i.tipo as Tipo,i.fecha as Fecha,i.fechacierre,i.estatus as Estado, " +
              " e.nombre as Auditor from inventarios i, empleados e " +
              "where  i.idautorizo=e.id  and i.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
                " and i.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

                sql2 = sql + filtro + " order by fecha limit 20";

                dgInventario.DataSource = conn.GetTable(sql2);
                dgInventario.AutoResizeColumns();
                conn.cerrarBd();
            }
        
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgInventario.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("¡Deseas Editar el Inventario ? ", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    frmDetalleInventarios frm = new frmDetalleInventarios();
                    frm.Tag = dgInventario.CurrentRow.Cells[0].Value.ToString();
                    frm.ShowDialog();
                }
            }
        }


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgInventario.CurrentRow.Cells[0].Value.ToString() != "")
            {
                DialogResult result = MessageBox.Show("¡Deseas Borrar el Inventario ? ", "Precaucion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    conn.AbrirBD();
                    resp = conn.Executa("delete from inventarios where id= grid_inv.CurrentRow.Cells[0].Value.ToString()");
                    resp = conn.Executa("delete from det_inventarios where idinventario = " + dgInventario.CurrentRow.Cells[0].Value.ToString());

                    carga();
                    conn.cerrarBd();
                }
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
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmDetalleInventarios frm = new frmDetalleInventarios();
        
            frm.Tag=0;
            frm.ShowDialog();
            carga();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

                if (txtBusqueda.Text.ToString().Length > 3)
                {
                    filtro = " and (e.nombre like '%" + txtBusqueda.Text +
                   "%' or tipo like '%" + txtBusqueda.Text + "%')";
                    carga();
                }
                else
                {
                    filtro = "";
                }
                
            
        }


    }
}


