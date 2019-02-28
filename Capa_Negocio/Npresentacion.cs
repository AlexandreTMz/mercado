using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class Npresentacion
    {
        public static string insertar_presentacion(string nombre, string descripcion)
        {
            DPresentacion apps = new DPresentacion();
            apps.nombre = nombre;
            apps.descripcion = descripcion;
            return apps.insertar(apps);            
        }

        public static string editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion apps = new DPresentacion();
            apps.idpresentacion = idpresentacion;
            apps.nombre = nombre;
            apps.descripcion = descripcion;
            return apps.editar(apps);
        }

        public static string eliminar(int Idpresentacion)
        {
            DPresentacion apps = new DPresentacion();
            apps.idpresentacion = Idpresentacion;
            return apps.eliminar(apps);
        }

        public static DataTable mostrar()
        {
            return new DPresentacion().mostrar();
        }
        public static DataTable buscar_nombre(string Textobuscar)
        {
            DPresentacion apps = new DPresentacion();
            apps.textobuscar = Textobuscar;
            return apps.buscarnombre_presentacion(apps);
        }


    }
}
