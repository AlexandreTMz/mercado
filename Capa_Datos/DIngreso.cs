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
    public class DIngreso
    {
        public int idingreso { get; set; }
        public int idtrabajador { get; set; }
        public int idproveedor { get; set; }
        public DateTime fecha { get; set; }
        public string tipo_comprobante { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public decimal igv { get; set; }
        public string estado { get; set; }

        public DIngreso()
        {

        }

        public DIngreso(int pidingreso, int pidtrabajador, int pidproveedor, DateTime pfecha, string ptipo_comprobante, string pserie, string pcorrelativo, int pigv, string pestado)
        {
            this.idingreso = pidingreso;
            this.idtrabajador = pidtrabajador;
            this.idproveedor = pidproveedor;
            this.fecha = pfecha;
            this.tipo_comprobante = ptipo_comprobante;
            this.serie = pserie;
            this.correlativo = pcorrelativo;
            this.igv = pigv;
            this.estado = pestado;
        }

        public void insertar(List<DDetalle_ingreso> detalle)
        {
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlTransaction sqltran = sqlcon.BeginTransaction();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.Transaction = sqltran;
                sqlcmd.CommandText = "spinsertar_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idingreso", idingreso);
                sqlcmd.Parameters.AddWithValue("@idtrabajador", idtrabajador);
                sqlcmd.Parameters.AddWithValue("@idproveedor", idproveedor);
                sqlcmd.Parameters.AddWithValue("@fecha", fecha);
                sqlcmd.Parameters.AddWithValue("@tipo_comprobante", tipo_comprobante);
                sqlcmd.Parameters.AddWithValue("@serie", serie);
                sqlcmd.Parameters.AddWithValue("@correlativo", correlativo);
                sqlcmd.Parameters.AddWithValue("@igv", igv);
                sqlcmd.Parameters.AddWithValue("@estado", estado);                
                sqlcmd.ExecuteNonQuery();

                this.idingreso = Convert.ToInt32(sqlcmd.Parameters["@idingreso"].Value);

                foreach (DDetalle_ingreso det in detalle)
                {
                    det.idingreso = this.idingreso;
                    det.insertar_detalle_ingreso(ref sqlcon, ref sqltran);
                    
                }
                sqltran.Commit();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public string anular(int ingreso)
        {
            string respuesta = "";
            SqlConnection sqlcon = Conexion.conexion();
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spanular_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@idingreso", ingreso);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                respuesta = ex.Message;
            }
            return respuesta;
        }

        public DataTable mostrar()
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_ingreso";
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

        public DataTable buscar_fechas(String textobuscar, String textobuscar2)
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_ingreso_fecha";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@textobuscar", textobuscar);
                sqlcmd.Parameters.AddWithValue("@textobuscar2", textobuscar2);

                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                sqldat.Fill(dt);
            }
            catch (Exception)
            {

                dt = null;
            }

            return dt;
        }

        public DataTable mostrar_detalle(String textobuscar)
        {
            DataTable dt = new DataTable("ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                sqlcon.ConnectionString = Conexion.cadena;
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_detalle_ingreso";
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
