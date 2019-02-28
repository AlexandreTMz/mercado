using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class NProveedor
    {
        // mejorar esta malo 
        public int idproveedor { get; set; }
        public string razon_social { get; set; }
        public string sector_comercial { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        

        public NProveedor(int pdiproveedor,string prazon_social, string psector_comercial, string ptipo_documento, string pnum_documento, string pdireccion, string ptelefono, string pemail, string purl)
        {

            this.idproveedor = pdiproveedor;
            this.razon_social = prazon_social;
            this.sector_comercial = psector_comercial;
            this.tipo_documento = ptipo_documento;
            this.num_documento = pnum_documento;
            this.direccion = pdireccion;
            this.telefono = ptelefono;
            this.email = pemail;
            this.url = purl;            
        }

        public string insertar()
        {
            DProveedor obj = new DProveedor();
           
            obj.razon_social = razon_social;
            obj.sector_comercial = sector_comercial;
            obj.tipo_documento = tipo_documento;
            obj.num_documento = num_documento;
            obj.direccion = direccion;
            obj.telefono = telefono;
            obj.email = email;
            obj.url = url;
            return obj.Insertar_proveedor();
        }

        public string editar()
        {
           
            DProveedor obj = new DProveedor();
            obj.id_proveedor = idproveedor;        
            obj.razon_social = razon_social;
            obj.sector_comercial = sector_comercial;
            obj.tipo_documento = tipo_documento;
            obj.num_documento = num_documento;
            obj.direccion = direccion;
            obj.telefono = telefono;
            obj.email = email;
            obj.url = url;
            return obj.editar_proveedor();
        }

        public static DataTable mostrar_proveedor()
        {
            return new DProveedor().mostrar_proveedores();
        }

        public static DataTable buscar_razon_social(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.textobuscar = textobuscar;
            return obj.buscar_razon_social(obj);
        }

       public static DataTable buscar_num_documento(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.textobuscar = textobuscar;
            return obj.buscar_num_documento(obj);
        }

        public static string Eliminar_proveedor(int idproveedor)
        {
            DProveedor obj = new DProveedor();
            obj.id_proveedor = idproveedor;
            return obj.eliminar_proveedor(obj);
        }
    }
}
