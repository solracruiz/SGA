using MaterialSkin;
using MySql.Data.MySqlClient;
using SGA.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Reportes
{
    public partial class frmReporteadorAlertas :   MaterialSkin.Controls.MaterialForm
    {
        conexion conn = new conexion();
        conexion conn1 = new conexion();
        conexion conn2 = new conexion();
        MySqlDataReader R;
        string Consulta = "";
        DateTime fecha1;
        DateTime fecha2;
        public frmReporteadorAlertas()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void frmReporteadorAlertas_Load(object sender, EventArgs e)
        {
            cargar();
        }
        void cargar()
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;

            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
         
           

            fecha1 = dtp1.Value;
            fecha2 = dtp2.Value;
            Consulta = Consulta + " and a.fecha >= '" + fecha1.ToString("yyyy-MM-dd") + "'" +
            " and a.fecha <= '" + fecha2.ToString("yyyy-MM-dd") + "'";

            FrmRVAlerta frm = new FrmRVAlerta();
            frm.Tag = Consulta;
            frm.ShowDialog();

        }
    }
}
