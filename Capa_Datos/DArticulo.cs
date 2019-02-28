using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DArticulo
    {
        public int idarticulo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] imagen { get; set; }
        public int idcategoria { get; set; }
        public int idpresentacion { get; set; }
        public string textobuscar { get; set; }

        public DArticulo()
        {

        }
        public DArticulo(int pidarticulo, string pcodigo, string pnombre, string pdescripcion, byte[]pImagen, int pidcategoria, int pidpresentacion, string ptextobuscar )
        {
            this.idarticulo = pidarticulo;
            this.codigo = pcodigo;
            this.nombre = pnombre;
            this.descripcion = pdescripcion;
            this.imagen = pImagen;
            this.idcategoria = pidcategoria;
            this.idpresentacion = pidpresentacion;
            this.textobuscar = ptextobuscar;
        }

        public string insertar()
        {
            string respuesta = "";
            SqlConnection con = Conexion.conexion();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spinsertar_articulo";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idarticulo", idarticulo);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@imagen", imagen);
                cmd.Parameters.AddWithValue("@idcategoria", idcategoria);
                cmd.Parameters.AddWithValue("@idpresentacion", idpresentacion);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }

            return respuesta;
        }

        // arreglar 
        public string editar()
        {
            string respuesta = "";
            SqlConnection con = Conexion.conexion();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "speditar_articulo";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idarticulo", idarticulo);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@imagen", imagen);
                cmd.Parameters.AddWithValue("@idcategoria", idcategoria);
                cmd.Parameters.AddWithValue("@idpresentacion", idpresentacion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public string eliminar(DArticulo articulo)
        {
            string respuesta = "";
            SqlConnection cn = Conexion.conexion();
            try
            {
                SqlCommand apps = new SqlCommand();
                apps.Connection = cn;
                apps.CommandText = "speliminar_articulo";
                apps.CommandType = CommandType.StoredProcedure;
                apps.Parameters.AddWithValue("@idarticulo", idarticulo);
                apps.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }

            return respuesta;
        }

        public DataTable mostrar()
        {
            DataTable dt = new DataTable("articulo");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_articulo";
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

        public DataTable buscar_articulo(DArticulo articulo)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_articulo";
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
