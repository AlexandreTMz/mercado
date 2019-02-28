using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class DProveedor
    {
        public int id_proveedor { get; set; }
        public string razon_social { get; set; }
        public string sector_comercial { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public string textobuscar { get; set; }


        public DProveedor()
        {

        }
        public DProveedor(int pidproveedor, string prazon_social, string psector_comercial, string ptipo_documento, string pnum_documento, string pdireccion, string ptelefono, string pemail, string purl, string ptextobuscar)
        {
            this.id_proveedor = pidproveedor;
            this.razon_social = prazon_social;
            this.sector_comercial = psector_comercial;
            this.tipo_documento = ptipo_documento;
            this.num_documento = pnum_documento;
            this.direccion = pdireccion;
            this.telefono = ptelefono;
            this.email = pemail;
            this.url = purl;
            this.textobuscar = ptextobuscar;
        }

       public string Insertar_proveedor()
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spinsertar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idproveedor", id_proveedor);
                sqlcmd.Parameters.AddWithValue("@razon_social", razon_social);
                sqlcmd.Parameters.AddWithValue("@sector_comercial", sector_comercial);
                sqlcmd.Parameters.AddWithValue("@tipo_documento", tipo_documento);
                sqlcmd.Parameters.AddWithValue("@num_documento", num_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono",telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.Parameters.AddWithValue("@url", url);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex )
            {

                respuesta = ex.Message;
            }

            return respuesta;
        }

       public string editar_proveedor()
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speditar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idproveedor", id_proveedor);
                sqlcmd.Parameters.AddWithValue("@razon_social", razon_social);
                sqlcmd.Parameters.AddWithValue("@sector_comercial", sector_comercial);
                sqlcmd.Parameters.AddWithValue("@tipo_documento", tipo_documento);
                sqlcmd.Parameters.AddWithValue("@num_documento", num_documento);
                sqlcmd.Parameters.AddWithValue("@direccion", direccion);
                sqlcmd.Parameters.AddWithValue("@telefono", telefono);
                sqlcmd.Parameters.AddWithValue("@email", email);
                sqlcmd.Parameters.AddWithValue("@url", url);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                respuesta = ex.Message;
            }

            return respuesta;
        }

        public string eliminar_proveedor(DProveedor proveedor)
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idproveedor", id_proveedor);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                
            }

            return respuesta;
        }

        public DataTable mostrar_proveedores()
        {           
            DataTable dt = new DataTable("proveedor");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_proveedor";
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
        public DataTable buscar_razon_social(DProveedor proveedor)
        {
            DataTable dt = new DataTable("proveedor");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_proveedor_razon_social";
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
        public DataTable buscar_num_documento(DProveedor proveedor)
        {
            DataTable dt = new DataTable("proveedor");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_proveedor_num_documento";
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
