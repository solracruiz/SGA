using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    internal class configuracion
    {
        public static Int32 ID_ALMACEN;
        public static float IVA = float.Parse("0.16");
        public static string USER="ADMIN", IDUSER="1", PERFIL = "", PERMISOS="", METODO = "PE", ACCION = "", stFormat="";

    public Double Convertir_Moneda(String Numero)
        {
            Double Costo_Valor;
            Costo_Valor = Double.Parse(Numero); 
            if (Costo_Valor >= 0) stFormat = "{0:#,0.00}";
            if (Costo_Valor >= 1e3) stFormat = "{0:#,0,.00 K}";
            if (Costo_Valor >= 1e6) stFormat = "{0:#,0,,.00 M}";
            if (Costo_Valor >= 1e9) stFormat = "{0:#,0,,,.00 G}";
            return Costo_Valor;
        }
    }

    
}
