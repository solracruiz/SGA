using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SGA.Administración;
using SGA.Catálogos;
using SGA.Clases;
using SGA.Data_Sources;
using SGA.Herramientas;
using SGA.Procesos;
using SGA.Reportes;

namespace SGA
{
    public partial class SGAMenu : Form
    {
        conexion conn = new conexion();
        string sql = "", accion = "", filtro = "";
        public SGAMenu()
        {
            InitializeComponent();
            //var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            //skinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            //skinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
            //   Primary.Blue900, Accent.Green700, TextShade.WHITE);

        }

        private void SGAMenu_Load(object sender, EventArgs e)
        {
            permisos();
        }
        
        void permisos()
        {
            
             if (configuracion.PERMISOS.IndexOf("001") < 0) { catálogoDeProductosToolStripMenuItem1.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("002") < 0) { catálogoDeProveedoresToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("003") < 0) { catálogoDeFuentesDeFinanciamientoToolStripMenuItem1.Enabled = false; ; }
             if (configuracion.PERMISOS.IndexOf("004") < 0) { catálogoDeCentrosDeCostoCLUESToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("005") < 0) { catálogoDePartidasEstatalesToolStripMenuItem1.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("006") < 0) { catálogoDePartidasFederalesToolStripMenuItem1.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("007") < 0) { catálogoDeUsuariosToolStripMenuItem.Enabled = false; }

//PROCESOS
             if (configuracion.PERMISOS.IndexOf("012") < 0) { entradaDeProductosToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("013") < 0) { CluesToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("014") < 0) { directaToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("015") < 0) { deRequisicionToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("016") < 0) { normalToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("017") < 0) { pruebaDeAperturaToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("018") < 0) { inventarioFisicoToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("019") < 0) { kardexDeAlmacenToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("020") < 0) { alertaSanitariaToolStripMenuItem.Enabled = false; }

             //REPORTES
             if (configuracion.PERMISOS.IndexOf("022") < 0) { reporteDeArticulosToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("023") < 0) { reporteDeEntradasToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("024") < 0) { reporteRequisicionestoolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("025") < 0) { reporteDeSalidasToolStripMenuItem.Enabled = false; }
             if (configuracion.PERMISOS.IndexOf("026") < 0) { reporteDeInventarioToolStripMenuItem.Enabled = false; }
    
             //ADMINISTRACION
            if (configuracion.PERMISOS.IndexOf("041") < 0) { aperturaDelInventarioToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("042") < 0) { bloqueoDelInventarioToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("043") < 0) { cierreDelInventarioToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("044") < 0) { datosDeAlmacénToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("045") < 0) { responsablesDeAlmacénToolStripMenuItem.Enabled = false; }

            //HERRAMIENTAS
            if (configuracion.PERMISOS.IndexOf("051") < 0) { respaldoDelSistemaToolStripMenuItem1.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("052") < 0) { bitácoraToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("053") < 0) { gestiónDeUsuariosDelSistemaToolStripMenuItem.Enabled = false; }
            if (configuracion.PERMISOS.IndexOf("054") < 0) { importacionDeInformaciónToolStripMenuItem.Enabled = false; ; }
           
            
        }
        

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
        private void salirDelSistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void catálogoDeProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCatProductos Frm = new FrmCatProductos();
            // 
            Frm.ShowDialog();
        }

        private void catálogoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatProveedores Frm = new FrmCatProveedores();
             
            Frm.ShowDialog();
        }

        private void catálogoDeFuentesDeFinanciamientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCatFuentes Frm = new FrmCatFuentes();
             
            Frm.ShowDialog();

        }

        private void catálogoDeCentrosDeCostoCLUESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatClues Frm = new FrmCatClues();
             
            Frm.ShowDialog();
            
        }

        private void catálogoDePartidasEstatalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCatPartidasE Frm = new FrmCatPartidasE();
             
            Frm.ShowDialog();
        }

        private void catálogoDePartidasFederalesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCatPartidasF Frm = new FrmCatPartidasF();
             
            Frm.ShowDialog();
        }

        private void entradaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEntradas Frm = new FrmEntradas();

            Frm.ShowDialog();
        }

        private void requisicionesDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void salidaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void programaciónDeEntradasSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProgramacion Frm = new FrmProgramacion();
             
            Frm.ShowDialog();
        }

        private void productosEnAlertaSanitariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlerta Frm = new FrmAlerta();
             
            Frm.ShowDialog();
        }

        private void productosControladToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlados Frm = new FrmControlados();
             
            Frm.ShowDialog();
        }

        private void respaldoDelSistemaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRespaldo Frm = new FrmRespaldo();
            Frm.ShowDialog();
        }

        private void bitácoraDeAccesoAlSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBitacora Frm = new FrmBitacora();
             
            Frm.ShowDialog();
        }

        private void gestiónDeUsuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios Frm = new FrmUsuarios();
             
            Frm.ShowDialog();
        }

        private void aperturaDelInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbrirInventario Frm = new FrmAbrirInventario();
             
            Frm.ShowDialog();
        }

        private void bloqueoDelInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBloquearInventario Frm = new FrmBloquearInventario();
             
            Frm.ShowDialog();
        }

        private void cierreDelInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCerrarInventario Frm = new FrmCerrarInventario();
             
            Frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pruebaDeAperturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frvControlados.Show();
        }

        private void catálogosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        void SGAMenu_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }
  

   

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void cLUESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRequisiciones Frm = new FrmRequisiciones();
            Frm.Tag = 0;
            Frm.ShowDialog();
        }

        private void deRequisicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSalidas Frm = new FrmSalidas();
            // 
            Frm.ShowDialog();
        }

        private void kardexDeAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKardex Frm = new frmKardex();
             
            Frm.ShowDialog();
        }

        private void reporteDeInventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeSalidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteadorSalidas frm = new frmReporteadorSalidas();

            frm.ShowDialog();
        }

        private void reporteDeProductosDañadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void directaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRequisiciones Frm = new FrmRequisiciones();
            Frm.Tag = 1;
            Frm.ShowDialog();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void alertaSanitariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlerta Frm = new FrmAlerta();
             
            Frm.ShowDialog();
        }

        private void reporteDePorductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteadorProductos Frm = new frmReporteadorProductos();

            Frm.ShowDialog();
        }

        private void importacionDeInformaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportaciones Frm = new frmImportaciones();

            Frm.ShowDialog();
        }

        private void reporteDeEntradasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteadorEntradas Frm = new frmReporteadorEntradas();

            Frm.ShowDialog();
        }

        private void reporteRequisicionestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteadorRequisiciones Frm = new frmReporteadorRequisiciones();

            Frm.ShowDialog();
        }

        private void reporteDeAlertasSanitariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteadorAlertas Frm = new frmReporteadorAlertas();

            Frm.ShowDialog();
        }



        private void inventarioFisicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario Frm = new frmInventario();
             
            Frm.ShowDialog();
        }

        private void catálogoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatUsuarios Frm = new frmCatUsuarios();
             
            Frm.ShowDialog();
        }
    }
}
