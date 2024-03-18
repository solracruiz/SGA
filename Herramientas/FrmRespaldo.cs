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
    public partial class FrmRespaldo : MaterialForm
    {
        public FrmRespaldo()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmRespaldo_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = "server=localhost; database=sigal; Uid=root; pwd=c1r7g4s;" +
                "charset=utf8;convertzerodatetime=true;";


            DateTime dateTime = DateTime.Now;   //fecha de hoy
            String dateTimeFormat = dateTime.ToString("dd/MM/yyyy"); //formato 
            //A la variable fileName le concatenamos la fecha
            //fileName = fileName + " " + dateTimeFormat;


            string miRespaldo = "C:\\Users\\Felipao\\source\\repos\\SGA\\Respaldo\\Respaldo_SGA.sql";

            using (MySqlConnection conectar = new MySqlConnection(cadena))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup miBackup = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conectar;
                        conectar.Open();
                        miBackup.ExportToFile(miRespaldo);
                        conectar.Close();
                    }
                }
            }
            MessageBox.Show("¡Respaldo realizado con éxito!");


        }
    }
}
