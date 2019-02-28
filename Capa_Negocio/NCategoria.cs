using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class NCategoria
    {
        public static string Insertar (string nombre , string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.nombre = nombre;
            obj.descripcion = descripcion;
            return obj.insertar(obj);
        }

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.idcategoria = idcategoria;
            obj.nombre = nombre;
            obj.descripcion = descripcion;
            return obj.editar(obj);
        }

        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.idcategoria = idcategoria;            
            return obj.eliminar(obj);
        }

        public static DataTable mostrar()
        {
            return new DCategoria().mostrar();
        }

        public static DataTable Buscar_nombre(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.textobuscar = textobuscar;
            return obj.buscarnombre(obj);
        }
    }
}
