using Microsoft.Reporting.Map.WebForms.BingMaps;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.Types;
using SGA;

namespace SGA.Clases
{
    public class miConexión
    {
        //MySqlConnection miConexion = new MySqlConnection("server = 127.0.0.1; database = sga; Uid = root; pwd =root");
        MySqlConnection miConexion = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "sga";
        static string usuario = "root";
        static string password = "c1r7g4s";
        //static string puerto = "3306";

        string cadenaConexion = "server=" + servidor + "; database=" + bd + "; Uid=" + usuario +
            "; pwd=" + password;


        public MySqlConnection Conectarse()
        {
            try
            {
                miConexion.ConnectionString = cadenaConexion;
                miConexion.Open();
                //MessageBox.Show("Conexión Exitosa!");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se pudo realizar la conexion a la bd: SGA, ocurrio el error: " + e.ToString());
            }
            return miConexion;
        }
    }
}
       
       
    

