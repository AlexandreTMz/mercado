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
    public class Dtrabajador
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
       
        public Dtrabajador()
        {

        }

        public Dtrabajador(int pidtrabajador, string pnombre, string papellido, string psexo, DateTime pfecha_nac, string pnumero_documento,
            string pdireccion, string ptelefono, string pemail, string pacceso, string pusuario, string ppassword, string ptextobuscar)
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

            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idtrabajador", idtrabajador);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@apellidos", apellido);
                sqlcmd.Parameters.AddWithValue("@sexo", sexo);
                sqlcmd.Parameters.AddWithValue("@fecha_nac", fecha_nac);
                sqlcmd.Parameters.AddWithValue("@numero_documento", numero_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.Parameters.AddWithValue("@acceso", acceso);
                sqlcmd.Parameters.AddWithValue("@usuario", usuario);
                sqlcmd.Parameters.AddWithValue("@password", password);
                sqlcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void editar()
        {
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("idtrabajador", idtrabajador);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@apellidos", apellido);
                sqlcmd.Parameters.AddWithValue("@sexo", sexo);
                sqlcmd.Parameters.AddWithValue("@fecha_nac", fecha_nac);
                sqlcmd.Parameters.AddWithValue("@numero_documento", numero_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.Parameters.AddWithValue("@acceso", acceso);
                sqlcmd.Parameters.AddWithValue("@usuario", usuario);
                sqlcmd.Parameters.AddWithValue("@password", password);
                sqlcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public string eliminar(int idtrabajador)
        {
            string eliminar = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idtrabajador", idtrabajador);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return eliminar;
            
        }

        public DataTable mostrar()
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_trabajador";
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

        public DataTable buscar_trabajador_apellido(string textobuscar)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_trabajador_apellido";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", textobuscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable buscar_trabajador_num_documento(string textobuscar)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_trabajador_num_documento";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", textobuscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable login (string usuario, string password)
        {
            DataTable dt = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "splogin";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@usuario", usuario);
                sqlcmd.Parameters.AddWithValue("@password", password);           


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

