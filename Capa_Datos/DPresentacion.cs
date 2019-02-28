using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DPresentacion
    {
        public int idpresentacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string textobuscar { get; set; }

        public DPresentacion()
        {

        }

        public DPresentacion(int pidpresentacion, string pnombre, string pdescripcion, string ptextobuscar)
        {
            this.idpresentacion = pidpresentacion;
            this.nombre = pnombre;
            this.descripcion = pdescripcion;
            this.textobuscar = ptextobuscar;
        }

        public string insertar(DPresentacion presentacion)
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_presentacion";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idpresentacion", idpresentacion);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }

            return respuesta;
        }

        public string editar(DPresentacion presentacion)
        {
            string repuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_presentacion";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idpresentacion", idpresentacion);
                sqlcmd.Parameters.AddWithValue("@nombre", nombre);
                sqlcmd.Parameters.AddWithValue("@descripcion", descripcion);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                repuesta = ex.Message;
            }
           
            return repuesta;
        }

        public string eliminar(DPresentacion presentacion)
        {
            string rpts = "";
            SqlConnection consql = Conexion.conexion();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = consql;
                cmd.CommandText = "speliminar_presentacion";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idpresentacion", idpresentacion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                rpts = ex.Message;
            }

            return rpts;
        }

        public DataTable mostrar()
        {
            DataTable cv = new DataTable("presentacion");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_presentacion";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(cv);
            }
            catch (Exception)
            {

                cv = null;
            }

            return cv;
        }

        public DataTable buscarnombre_presentacion(DPresentacion presentacion)
        {
            DataTable ap = new DataTable("presentacion");
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = con;
                sqlcmd.CommandText = "spbuscar_presentacion";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", textobuscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(ap);             


            }
            catch (Exception)
            {

                ap = null;
            }

            return ap;
        }
    }
}
