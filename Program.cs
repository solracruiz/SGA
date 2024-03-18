using System;
using SGA.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace SGA
{

    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SGAMenu());
            Application.Run(new FrmAcceso()); 
            //Aqui se define el formulaio de arranque del sistema frmAcceso
        }
    }
}
