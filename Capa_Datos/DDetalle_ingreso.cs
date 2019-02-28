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
    public class DDetalle_ingreso
    {
        public int IdDetalle_ingreso { get; set; }
        public int idingreso { get; set; }
        public int idarticulo { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
        public int stock_inicial { get; set; }
        public int stock_actual { get; set; }
        public DateTime fecha_produccion { get; set; }
        public DateTime fecha_vencimiento { get; set; }

        public DDetalle_ingreso()
        {

        }

        public DDetalle_ingreso(int piddetalle_ingreso, int pidingreso, int pidarticulo, decimal pprecio_compra, decimal pprecio_venta, int pstock_inicial, int pstock_actual, DateTime pfecha_produccion, DateTime pfecha_vecimiento)
        {
            this.IdDetalle_ingreso = piddetalle_ingreso;
            this.idingreso = pidingreso;
            this.idarticulo = pidarticulo;
            this.precio_compra = pprecio_compra;
            this.precio_venta = pprecio_venta;
            this.stock_inicial = pstock_inicial;
            this.stock_actual = pstock_actual;
            this.fecha_produccion = pfecha_produccion;
            this.fecha_vencimiento = pfecha_vecimiento;
        }

        public void insertar_detalle_ingreso(ref SqlConnection sqlcon, ref SqlTransaction sqltrans)
        {
           
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.Transaction = sqltrans;
                sqlcmd.CommandText = "spinsertar_detalle_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@iddetalle_ingreso", IdDetalle_ingreso);
                sqlcmd.Parameters.AddWithValue("@idingreso", idingreso);
                sqlcmd.Parameters.AddWithValue("@idarticulo", idarticulo);
                sqlcmd.Parameters.AddWithValue("@precio_compra", precio_compra);
                sqlcmd.Parameters.AddWithValue("@precio_venta", precio_venta);
                sqlcmd.Parameters.AddWithValue("@stock_inicial", stock_inicial);
                sqlcmd.Parameters.AddWithValue("@stock_actual", stock_actual);
                sqlcmd.Parameters.AddWithValue("@fecha_produccion", fecha_produccion);
                sqlcmd.Parameters.AddWithValue("@fecha_vencimiento", fecha_vencimiento);
              
                sqlcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
