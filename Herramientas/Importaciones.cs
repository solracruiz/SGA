using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using SGA.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA.Herramientas
{
    public partial class frmImportaciones : MaterialSkin.Controls.MaterialForm
    {

        conexion conn = new conexion();
        MySqlDataReader R;
        public frmImportaciones()
        {
            InitializeComponent();
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT; //Color del fondo
            SkinManager.ColorScheme = new ColorScheme(Primary.Red900, Primary.Brown900,
                Primary.Blue900, Accent.Green700, TextShade.WHITE);
        }

        private void Importaciones_Load(object sender, EventArgs e)
        {
            ToolTip mensajes = new ToolTip();

            mensajes.SetToolTip(BtnGuardar, "Importar Catálogos...");


        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Boolean resp=false;
            if (cbx_catalogo.Text == "Articulos")
            {
                openFileDialog1.InitialDirectory = "C:\\";
                // filtro de archivos.
                openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv";

                // codigo para abrir el cuadro de dialogo
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string str_RutaArchivo = openFileDialog1.FileName;
                        textBox1.Text = str_RutaArchivo;
                        System.IO.StreamReader archivo = new System.IO.StreamReader(str_RutaArchivo);
                        string cadena ="";
                        string separador = ",";
                        string linea;
                        // Si el archivo no tiene encabezado, elimina la siguiente línea
                        archivo.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado

                        while ((linea = archivo.ReadLine()) != null)
                        {
                            string[] fila = linea.Split(Char.Parse(separador));
                            //MessageBox.Show(linea);
                            Int64 id = Int64.Parse(fila[0]);
                            string codigo = fila[1];
                            string nombre = fila[2];
                            string idpartidae = fila[4];
                            string idpartidaf = fila[5];
                            string presentacion = fila[6];
                            string tipo2 = fila[7];
                            string idanaquel = fila[8];
                            string precio = fila[9];
                            string existencia = fila[10];
                            string existenciamin = fila[11];
                            string existenciamax = fila[12];
                            string tipo = fila[13];

                            conn.AbrirBD();
                            conn.inicio();

                            cadena="insert into cat_articulos (id,codigo,nombre,descripcion,idpartidae,idpartidaf," +
                            "presentacion,tipo2,idanaquel,precio,existencia,existenciamin,existenciamax,iva) values(" +
                            id + ",'" + codigo + "','" + nombre + "','','" + idpartidae + "','" + idpartidaf + "','" +
                            presentacion + "','" + tipo2 + "','" + idanaquel + "','" + precio + "','" + existencia + "','" +
                            existenciamin + "','" + existenciamax + "','" + tipo + "')";
                            resp = conn.Executa(cadena);
                            //OBTENER ID INVENTARIO
                            if (!resp) { conn.fallo(); return; }

                            conn.exito();
                            conn.cerrarBd();
                            
                        }
                        MessageBox.Show("Proceso terminado con exito", Application.ProductName, MessageBoxButtons.OK,
               MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Fallo al guardar en la BD:" + ex.Message , Application.ProductName, MessageBoxButtons.YesNo,
               MessageBoxIcon.Error);
                    }
                }
            }
         
        }
    }
}
