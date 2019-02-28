using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
 

namespace Capa_Negocio
{
    public class NArticulo
    { 
        // mejorar este punto esta malo 
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] Image { get; set; }
        public int idcategoria { get; set; }
        public int idpresentacion { get; set; }

        public NArticulo(string pcodigo, string pnombre, string pdescripcion, byte[]pimagen, int pidcategoria, int pidpresentacion)
        {
            this.codigo = pcodigo;
            this.nombre = pnombre;
            this.descripcion = pdescripcion;
            this.Image = pimagen;
            this.idcategoria = pidcategoria;
            this.idpresentacion = pidpresentacion;
        }
        public string insertar_articulo()
        {
            DArticulo articulo = new DArticulo();
            articulo.codigo = codigo;
            articulo.descripcion = descripcion;
            articulo.nombre = nombre;
            articulo.imagen = Image;
            articulo.idcategoria = idcategoria;
            articulo.idpresentacion = idpresentacion;
            return articulo.insertar();
        }


        public string Editar_articulo()
        {
            DArticulo articulo = new DArticulo();             
            articulo.codigo = codigo;
            articulo.descripcion = descripcion;
            articulo.nombre = nombre;
            articulo.imagen = Image;
            articulo.idcategoria = idcategoria;
            articulo.idpresentacion = idpresentacion;
            return articulo.editar();

        }
        public static DataTable mostrar()
        {
            return new DArticulo().mostrar();
        }

        public static DataTable buscar(string buscar)
        {
            DArticulo obj = new DArticulo();
            obj.textobuscar = buscar;
            return obj.buscar_articulo(obj);
        }

        public static string Eliminar(int idarticulo)
        {
            DArticulo obj = new DArticulo();
            obj.idarticulo = idarticulo;
            return obj.eliminar(obj);
        }

        

    }
}
