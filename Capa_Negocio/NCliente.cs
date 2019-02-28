using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;


namespace Capa_Negocio
{
    public class NCliente
    {
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string tipo_documento { get; set; }
        public DateTime fecha_nacimiento { set; get; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; } 
        
        

        public NCliente(int pidcliente, string pnombre, string papellido, string psexo, DateTime pfecha_nacimiento, string ptipo_documento, string pnum_documento, 
            string pdireccion, string ptelefono, string pemail)
        {
            this.idcliente = pidcliente;
            this.nombre = pnombre;
            this.apellido = papellido;
            this.sexo = psexo;
            this.fecha_nacimiento = pfecha_nacimiento;
            this.tipo_documento = ptipo_documento;
            this.num_documento = pnum_documento;
            this.direccion = pdireccion;
            this.telefono = ptelefono;
            this.email = pemail;

        }

        public string insertar()
        {
            DClientes ap = new DClientes();
            ap.idcliente = idcliente;
            ap.nombre = nombre;
            ap.apellido = apellido;
            ap.sexo = sexo;
            ap.fecha_nacimiento = fecha_nacimiento;
            ap.tipo_documento = tipo_documento;
            ap.num_documento = num_documento;
            ap.direccion = direccion;
            ap.telefono = telefono;
            ap.email = email;
            return ap.insertar();

        }

        public string Editar()
        {
            DClientes ap = new DClientes();
            ap.idcliente = idcliente;
            ap.nombre = nombre;
            ap.apellido = apellido;
            ap.sexo = sexo;
            ap.fecha_nacimiento = fecha_nacimiento;
            ap.tipo_documento = tipo_documento;
            ap.num_documento = num_documento;
            ap.direccion = direccion;
            ap.telefono = telefono;
            ap.email = email;
            return ap.editar();
        }

        public static DataTable buscar_apellido(string textobuscar)
        {
            DClientes ap = new DClientes();
             return ap.buscar_cliente_apellido(textobuscar);
        }
        public static DataTable buscar_identificacion(string textobuscar)
        {
            DClientes ap = new DClientes();
             return ap.buscar_cliente_identifacion(textobuscar);
        }

        public static DataTable mostrar_cliente()
        {
            return new DClientes().mostrar_cliente();
        }
        public  static string Eliminar(int idarticulo)
        {
            DClientes ap = new DClientes();
            return ap.Eliminar(idarticulo);
        }
    }
}
