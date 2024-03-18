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
    public partial class FrmReporteInventario : Form
    {
        public FrmReporteInventario()
        {
            InitializeComponent();
        }

        private void FrmReporteInventario_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
