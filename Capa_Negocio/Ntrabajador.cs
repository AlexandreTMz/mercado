using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class Ntrabajador
    {
        public int idtrabajador { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public DateTime fecha_nac { get; set; }
        public string numero_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string acceso { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }

      

        public Ntrabajador(int pidtrabajador, string pnombre, string papellido, string psexo, DateTime pfecha_nac, string pnumero_documento,
            string pdireccion, string ptelefono, string pemail, string pacceso, string pusuario, string ppassword)
        {
            this.idtrabajador = pidtrabajador;
            this.nombre = pnombre;
            this.apellido = papellido;
            this.sexo = psexo;
            this.fecha_nac = pfecha_nac;
            this.numero_documento = pnumero_documento;
            this.direccion = pdireccion;
            this.telefono = ptelefono;
            this.email = pemail;
            this.acceso = pacceso;
            this.usuario = pusuario;
            this.password = ppassword;

        }

        public void insertar()
        {
            Dtrabajador ap = new Dtrabajador();
            ap.idtrabajador = idtrabajador;
            ap.nombre = nombre;
            ap.apellido = apellido;
            ap.sexo = sexo;
            ap.fecha_nac = fecha_nac;
            ap.numero_documento = numero_documento;
            ap.direccion = direccion;
            ap.telefono = telefono;
            ap.email = email;
            ap.acceso = acceso;
            ap.usuario = usuario;
            ap.password = password;
            ap.insertar();            
        }

        public void editar()
        {
            Dtrabajador ap = new Dtrabajador();
            ap.idtrabajador = idtrabajador;
            ap.nombre = nombre;
            ap.apellido = apellido;
            ap.sexo = sexo;
            ap.fecha_nac = fecha_nac;
            ap.numero_documento = numero_documento;
            ap.direccion = direccion;
            ap.telefono = telefono;
            ap.email = email;
            ap.acceso = acceso;
            ap.usuario = usuario;
            ap.password = password;
            ap.editar();
        }

        public static DataTable mostrar_trabajadores()
        {
            return new Dtrabajador().mostrar();
        }

        public static DataTable buscar_apellido(string textobuscar)
        {
            Dtrabajador app = new Dtrabajador();
           return app.buscar_trabajador_apellido(textobuscar);
        }

        public static DataTable buscar_numero_documento(string textobuscar)
        {
            Dtrabajador app = new Dtrabajador();
            return app.buscar_trabajador_num_documento(textobuscar);
        }

        public static string eliminar(int id)
        {
            Dtrabajador app = new Dtrabajador();
            return app.eliminar(id);
        }

        public static DataTable login(string usuario, string password)
        {
            Dtrabajador app = new Dtrabajador();
            app.usuario = usuario;
            app.password = password;
            return app.login(usuario, password);
        }
    }
}
