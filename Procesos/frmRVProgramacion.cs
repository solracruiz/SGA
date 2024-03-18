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
    public partial class frmRVProgramacion : Form
    {
        public frmRVProgramacion()
        {
            InitializeComponent();
        }

        private void frmRVProgramacion_Load(object sender, EventArgs e)
        {

            this.rvProgramacion.RefreshReport();
        }
    }
}
