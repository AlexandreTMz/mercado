using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class DClientes
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
        

       public DClientes()
        {

        }

        public DClientes(int pidcliente, string pnombre, string papellido, string psexo, DateTime pfecha_nacimiento, string ptipo_documento, string pnum_documento, string pdireccion, string ptelefono, string pemail)
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
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idcliente", idcliente);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@apellidos", apellido);
                sqlcmd.Parameters.AddWithValue("@sexo", sexo);
                sqlcmd.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                sqlcmd.Parameters.AddWithValue("@tipo_documento", tipo_documento);
                sqlcmd.Parameters.AddWithValue("@num_documento", num_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return respuesta;
        }

        public string editar()
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idcliente", idcliente);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@apellidos", apellido);
                sqlcmd.Parameters.AddWithValue("@sexo", sexo);
                sqlcmd.Parameters.AddWithValue("@tipo_documento", tipo_documento);
                sqlcmd.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                sqlcmd.Parameters.AddWithValue("@num_documento", num_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return respuesta;
        }

        public string Eliminar(int idcliente)
        {
            string eliminar = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("idcliente", idcliente);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                eliminar = ex.Message;
            }

            return eliminar;
        }

        public DataTable mostrar_cliente()
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }
            return dt;
        }

        public DataTable buscar_cliente_identifacion(string texto_buscar)
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_cliente_num_documento";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", texto_buscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }
        public DataTable buscar_cliente_apellido(string texto_buscar)
        {
            DataTable dt = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", texto_buscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }
    }
    }

