using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;

namespace SGA.Herramientas
{
    public partial class FrmBitacora : MaterialForm
    {
        public FrmBitacora()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900, Primary.Brown900,
                Accent.Green700, TextShade.WHITE);


            string cadena = "server= localhost; database= sga; Uid=root; pwd=Ch1v4scampeo#";
            MySqlConnection conectar = new MySqlConnection(cadena);
            try
            {
                conectar.Open();
                string Qry = "select * from bitacora";
                MySqlCommand cmd = new MySqlCommand(Qry, conectar);
                cmd.CommandTimeout = 30;
                MySqlDataReader leer;
                try
                {

                    leer = cmd.ExecuteReader();
                    if (leer.HasRows)
                    {
                        while (leer.Read())
                        {
                            int n = dgBitacora.Rows.Add();
                            dgBitacora.Rows[n].Cells[0].Value = leer.GetString(0);
                            dgBitacora.Rows[n].Cells[1].Value = leer.GetString(1);
                            dgBitacora.Rows[n].Cells[2].Value = leer.GetString(2);
                            dgBitacora.Rows[n].Cells[3].Value = leer.GetString(3);
                            dgBitacora.Rows[n].Cells[4].Value = leer.GetString(4);
                            dgBitacora.Rows[n].Cells[5].Value = leer.GetString(5);

                            //MessageBox.Show(leer.GetString(0));

                            if (dgBitacora.CurrentRow.Cells[0].Selected == true)
                            {
                                txtId.Text = dgBitacora.CurrentRow.Cells[0].Value.ToString();
                                txtFecha.Text = dgBitacora.CurrentRow.Cells[1].Value.ToString();
                                txtUsuario.Text = dgBitacora.CurrentRow.Cells[2].Value.ToString();
                                txtTabla.Text = dgBitacora.CurrentRow.Cells[3].Value.ToString();
                                txtMotivo.Text = dgBitacora.CurrentRow.Cells[4].Value.ToString();
                                txtIdtabla.Text = dgBitacora.CurrentRow.Cells[5].Value.ToString();

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Hay Datos!");
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgBitacora.CurrentRow.Selected = true;

            txtId.Text = dgBitacora.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFecha .Text =dgBitacora .Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUsuario.Text = dgBitacora.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTabla.Text = dgBitacora .Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMotivo .Text =dgBitacora .Rows[e.RowIndex].Cells[4].Value.ToString();
            txtIdtabla .Text =dgBitacora .Rows[e.RowIndex ].Cells[5].Value.ToString();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmRVBitacora frm = new FrmRVBitacora();
            frm.ShowDialog();
            frm.Show();
        }
    }
}
