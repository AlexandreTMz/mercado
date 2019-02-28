using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DCategoria
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string textobuscar { get; set; }

        // constructor vacio
        public DCategoria()
        {

        }

        public DCategoria(int pidcategoria, string pnombre, string pdescripcion, string ptextobuscar)
        {
            this.idcategoria = pidcategoria;
            this.nombre = pnombre;
            this.descripcion = pdescripcion;
            this.textobuscar = ptextobuscar;
        }

        public string insertar(DCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {             
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;               

                sqlcmd.Parameters.AddWithValue("@idcategoria", idcategoria);
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

        public string editar(DCategoria Categoria)
        {

            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                // esta ma

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                // esta malo hacer esto 5 veces es muy repetido

                sqlcmd.Parameters.AddWithValue("@idcategoria", idcategoria);
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

        public string eliminar(DCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                // esta ma

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                // esta malo hacer esto 5 veces es muy repetido

                sqlcmd.Parameters.AddWithValue("@idcategoria", idcategoria);
                sqlcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }


            return respuesta;
        }

        public DataTable mostrar()
        {
            DataTable dt = new DataTable("catergoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_categoria";
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

        public DataTable buscarnombre(DCategoria Categoria)
        {
            DataTable dt = new DataTable("catergoria");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_categoria";
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
    }
}
