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
    public partial class frmRVControlados : Form
    {
        public frmRVControlados()
        {
            InitializeComponent();
        }

        private void frmRVControlados_Load(object sender, EventArgs e)
        {

            this.rvControlados.RefreshReport();
        }
    }
}
