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

namespace SGA.Procesos
{
    public partial class FrmProgramacion : MaterialSkin.Controls.MaterialForm
    {
        public FrmProgramacion()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void FrmProgramacion_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkSalida_CheckedChanged(object sender, EventArgs e)
        {
            MSlblProveedor.Text = "Centro de Costo:";
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            //frmRVProgramacion.Show();
        }
    }
}
