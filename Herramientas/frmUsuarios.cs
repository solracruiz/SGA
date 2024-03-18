using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Herramientas
{
    public partial class FrmUsuarios : MaterialForm
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Brown900, Accent.Green700, TextShade.WHITE);


            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnNuevo, "Agregar un Registro");
            toolTip.SetToolTip(this.btnGuardar, "Guardar Datos");
            toolTip.SetToolTip(this.btnImprimir, "Imprimir Reporte");
            toolTip.SetToolTip(this.btnSalir, "Cerrar esta Ventana");

            string cadena = "server= localhost; database= sga; Uid=root; pwd=Ch1v4scampeo#";
            MySqlConnection conectar = new MySqlConnection(cadena);
            try
            {
                conectar.Open();
                //MessageBox.Show("Conectado");
                string Qry = "select * from ususarios";
                MySqlCommand cmd = new MySqlCommand(Qry, conectar);
                cmd.CommandTimeout = 60;
                MySqlDataReader leer;
                try
                {
                    leer = cmd.ExecuteReader();
                    if (leer.HasRows)
                    {
                        while (leer.Read())
                        {
                            int n = dgUsuarios.Rows.Add();
                            dgUsuarios.Rows[n].Cells[0].Value = leer.GetString(0);
                            dgUsuarios.Rows[n].Cells[1].Value = leer.GetString(1);
                            dgUsuarios.Rows[n].Cells[2].Value = leer.GetString(2);
                            dgUsuarios.Rows[n].Cells[3].Value = leer.GetString(3);
                            dgUsuarios.Rows[n].Cells[4].Value = leer.GetString(4);
                            dgUsuarios.Rows[n].Cells[5].Value = leer.GetString(5);
                            dgUsuarios.Rows[n].Cells[6].Value = leer.GetString(6);
                            dgUsuarios.Rows[n].Cells[7].Value = leer.GetString(7);
                                                        
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay usuarios!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Conexión: ", ex.ToString());
            }
            conectar.Close();
        }
    

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtPermisos.Text = "";
            txtEstado.Text = "";
            txtNombre.Text = "";
            txtNumero.Text = "";
            txtIdalmacen.Text = "";
            txtIdempleado.Text = "";

            txtUsuario .Focus ();

        }

        private void dgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Segmento de código que permite editar/modificar los datos de un registro
            //celda por celda
            string titulo = "Edicion de Datos de Usuarios";
            int columna = e.ColumnIndex;
            switch (columna)
            {
                case 0:
                    string NuevoUsuario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuev Usuario", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[0].Value = NuevoUsuario;
                    break;
                case 1:
                    string NuevaContraseña = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nueva Contraseña", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[1].Value = NuevaContraseña;
                    break;
                case 2:
                    string NuevoPermiso = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuevo Permiso", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[2].Value = NuevoPermiso;
                    break;
                case 3:
                    string NuevoEstado = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuevo Estado", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[0].Value = NuevoEstado;
                    break;
                case 4:
                    string NuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuevo Nombre", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[1].Value = NuevoNombre;
                    break;
                case 5:
                    string NuevoNumero = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuevo Número", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[2].Value = NuevoNumero;
                    break;
                case 6:
                    string NuevoIdalmacen = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nueva Id Almacén", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[0].Value = NuevoIdalmacen;
                    break;
                case 7:
                    string NuevoIdempleado = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nuevo Id empleado", titulo);
                    dgUsuarios.Rows[e.RowIndex].Cells[1].Value = NuevoIdempleado;
                    break;
                
                default: break;
            }
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUsuario.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtContraseña.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtPermisos.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtEstado.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtNumero.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtIdalmacen.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtIdempleado.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();

            txtUsuario.Focus ();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmRVUsuarios frm = new frmRVUsuarios();
            frm.ShowDialog();

        }
    }
}
