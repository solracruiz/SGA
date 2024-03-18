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
    public partial class FrmReporteEntradas : Form
    {
        public FrmReporteEntradas()
        {
            InitializeComponent();
        }

        private void FrmReporteEntradas_Load(object sender, EventArgs e)
        {

            this.rvEntradas.RefreshReport();
        }
    }
}
