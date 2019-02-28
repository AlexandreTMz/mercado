using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class Ningreso    {

        public DataTable dtdetalles { get; set; }


        public void ingresar(int pidtrabajador, int pidproveedor, DateTime pfecha, string ptipo_comprobante, string pserie, string pcorrelativo, decimal pigv, string pestado, DataTable pdetalles)
        {
            DIngreso ap = new DIngreso();   
            ap.idtrabajador = pidtrabajador;
            ap.idproveedor = pidproveedor;
            ap.fecha = pfecha;
            ap.tipo_comprobante = ptipo_comprobante;
            ap.serie = pserie;
            ap.correlativo = pcorrelativo;
            ap.igv = pigv;
            ap.estado = pestado;
            List<DDetalle_ingreso> detalles = new List<DDetalle_ingreso>();
           
            foreach (DataRow row in dtdetalles.Rows)
            {
                DDetalle_ingreso detalle = new DDetalle_ingreso();
                detalle.idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.precio_compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.stock_inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.stock_actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.fecha_produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
                
            }
            ap.insertar(detalles);
        }

        public static string anular(int idingreso)
        {
            DIngreso obj = new DIngreso();
            obj.idingreso = idingreso;
            return obj.anular(idingreso);
        }

        public static DataTable mostrar()
        {
            return new DIngreso().mostrar();
        }

        public static DataTable buscarfecha(string textobuscar, string textobuscar2)
        {
            DIngreso obj = new DIngreso();
            return obj.buscar_fechas(textobuscar, textobuscar2);

        }

        public static DataTable mostrardetalle(string textbuscar)
        {
            DIngreso obj = new DIngreso();
            return obj.mostrar_detalle(textbuscar);
        }
    }
}
