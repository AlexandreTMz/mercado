using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class Conexion
    {
        public static string cadena = Properties.Settings.Default.dbventasConnectionString;
        public static SqlConnection cnxion = new SqlConnection(cadena);

        public static SqlConnection conexion()
            
        {
            if (cnxion.State ==   System.Data.ConnectionState.Closed) {
                cnxion.Open();
            }
            return cnxion;
        }
     }
}
