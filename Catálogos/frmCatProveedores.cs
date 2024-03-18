using MaterialSkin;
using MySql.Data.MySqlClient;
using SGA.Data_Sources;
using SGA.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Catálogos
{
    public partial class FrmCatProveedores : MaterialSkin.Controls.MaterialForm
    {
        Int64 ID_PRO = 0;
        conexion conn = new conexion();
        string sql = "", accion = "",filtro="";
        MySqlDataReader R;
        public FrmCatProveedores()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void FrmCatProveedores_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900, Accent.Green700, TextShade.WHITE);

            ToolTip mensajes = new ToolTip();
            mensajes.SetToolTip(BtnNuevo, "Clic para agregar un nuevo registro...");
            mensajes.SetToolTip(btnEditar, "Mostrar Detalle del Registro...");
            mensajes.SetToolTip(BtnSalir, "Regresar a Pantalla Anterior");
            mensajes.SetToolTip(BtnGuardar, "Guardar Registro...");
            mensajes.SetToolTip(BtnImprimir, "Imprimir Registros...");


            carga();

        }
        void carga()
        {
            conn.AbrirBD();
            sql = "select * from cat_proveedores where id>0 " + filtro;
            dgProveedores.DataSource = conn.GetTable(sql);
            dgProveedores.AutoResizeColumns();
            dgProveedores.Columns[0].Visible = false;
            conn.cerrarBd();
        }
      


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            frmRVCatProveedores frm = new frmRVCatProveedores();    
            frm.Tag = filtro;
            frm.ShowDialog();

        }

        void limpia()
        {
            txtSicogub.Text = "";
            txtNombre.Text = "";
            txtRFC.Text = "";
            txtRazonSocial.Text = "";
            txtCalle.Text = "";
            txtNumero.Text = "";
            txtColonia.Text = "";
            txtCP.Text = "";
            txtCiudad.Text = "";
            txtTelefono.Text = "";
            txtCorreoe.Text = "";
            txtProveedor.Text = "";
            txtInterior.Text = "";
            txtcelular.Text = "";

            txtSicogub.Focus();
            panel1.Enabled = true;
            accion = "";
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpia();
            
            accion = "NUEVO";

        }

        void llenar()
        {
           
                    
        }

        private void dgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProveedores_DoubleClick(object sender, EventArgs e)
        {
            txtSicogub.Text = dgProveedores.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgProveedores.CurrentRow.Cells[2].Value.ToString();
            txtRFC.Text = dgProveedores.CurrentRow.Cells[3].Value.ToString();
            txtRazonSocial.Text = dgProveedores.CurrentRow.Cells[4].Value.ToString();
            txtCalle.Text = dgProveedores.CurrentRow.Cells[5].Value.ToString();
            txtNumero.Text = dgProveedores.CurrentRow.Cells[6].Value.ToString();
            txtColonia.Text = dgProveedores.CurrentRow.Cells["colonia"].Value.ToString();
            txtCP.Text = dgProveedores.CurrentRow.Cells["cp"].Value.ToString();
            txtCiudad.Text = dgProveedores.CurrentRow.Cells["mpioestado"].Value.ToString();
            txtTelefono.Text = dgProveedores.CurrentRow.Cells["telefono"].Value.ToString();
            txtCorreoe.Text = dgProveedores.CurrentRow.Cells["email"].Value.ToString();
            txtInterior.Text = dgProveedores.CurrentRow.Cells["numinterior"].Value.ToString();
            txtcelular.Text = dgProveedores.CurrentRow.Cells["celular"].Value.ToString();
            txtProveedor.Text = dgProveedores.CurrentRow.Cells["id"].Value.ToString();
            ID_PRO=Int64.Parse(dgProveedores.CurrentRow.Cells["id"].Value.ToString());
            panel1.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            accion = "EDITAR";
        }


        private int valida()
        {


            if (txtSicogub.Text == "" || txtRFC.Text == "" || txtRazonSocial.Text == "")
            {
                MessageBox.Show("No es posible agregar o actualizar el Articulo con sin valores¡");
                panel1.Enabled = true;
                return 0;
            }
            return 1;
        }
        private int valida2()
        {
            conn.AbrirBD();
            R = conn.GetData("SELECT id FROM cat_proveedores where numsicogub='" + txtSicogub.Text.ToString() + "';");
            if (R.HasRows)
            {
                R.Close();
                conn.cerrarBd();
                MessageBox.Show("No es posible agregar o actualizar el Proveedor con un codigo ya existente " + txtSicogub.Text + "¡");
                panel1.Enabled = true;
                return 0;
            }

            conn.cerrarBd();
            return 1;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp;
      
            
            panel1.Enabled = false;
            if (accion == "NUEVO")
            {
                if (valida() == 0)
                {
                    return;
                }
                if (valida2() == 0)
                {
                    return;
                }
                conn.AbrirBD();
                conn.inicio();
                resp = conn.Executa("insert into cat_proveedores (numsicogub, nombre,rfc" +
                ",razonsocial,calle, numexterior, colonia, cp, mpioestado, telefono" +
                ", email, numinterior, celular) values('" +
                    txtSicogub.Text + "','" + txtNombre.Text + "','" + txtRFC.Text + "','" + 
                    txtRazonSocial.Text + "','" + txtCalle.Text +"','" + txtNumero.Text + "','" + 
                    txtColonia.Text +  "','" + txtCP.Text + "','" + txtCiudad.Text + "','" + 
                    txtTelefono.Text + "', '" + txtCorreoe.Text + "','" + txtInterior.Text + "','" + 
                    txtcelular.Text + "')");
                //OBTENER ID INVENTARIO


                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Proveedor " + txtProveedor.Text + " Realizada con Exito¡");
                ID_PRO = 0;
            }
            else if (accion == "EDITAR")
            {
                if (valida() == 0)
                {
                    return;
                }

                conn.AbrirBD();
                conn.inicio();
                resp = conn.Executa ("update cat_proveedores set numsicogub='" + txtSicogub.Text +
                "', nombre='" +txtNombre.Text + "',rfc='" + txtRFC.Text +
                "',razonsocial='" + txtRazonSocial.Text + "',calle='" + txtCalle.Text +
                "', numexterior='" + txtNumero.Text + "', colonia='" + txtColonia.Text +
                "', cp='" + txtCP.Text + "', mpioestado='" + txtCiudad.Text +
                "', telefono='" + txtTelefono.Text + "', email='" + txtCorreoe.Text +
                "', numinterior='" + txtInterior.Text + "', celular='" + txtcelular.Text +
                "' where id=" + double.Parse(txtProveedor.Text) );

                if (!resp) { conn.fallo(); return; }

                conn.exito();
                conn.cerrarBd();
                carga();
                MessageBox.Show("Actualizacion del Proveedor " + txtProveedor.Text + " Realizada con Exito¡");
                ID_PRO = 0;
            }

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
         

                if (txtBusqueda.Text.ToString().Length > 3)
                {
                    filtro = " and (nombre like '%" + txtBusqueda.Text +
                    "%' or razonsocial like '%" + txtBusqueda.Text +
                   "%' or rfc like '%" + txtBusqueda.Text + "%')";
                }
                else
                {
                    filtro = "";
                }
                carga();
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgProveedores.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Esta a Punto de Eliminar Datos!", "Eliminacion de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Cancel) { return; }
                else if (resultado == DialogResult.OK)
                {
                    foreach (DataGridViewRow Rw in dgProveedores.SelectedRows)
                    {
                        dgProveedores.Rows.Remove(Rw);
                    }
                }
            }
        }
    }
}
