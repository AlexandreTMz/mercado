using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;
using Capa_Negocio;

namespace proyecto_supermercado
{
    public partial class Consultar : Form
    {
        public int idtrabajador;
        private static Consultar instancia;
        private DataTable DTDetalle;
        private decimal totalpagado;
        private Articulos objArticulos;

        public static Consultar getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Consultar();
            }

            return instancia;
        }

       

        public Consultar()
        {
            InitializeComponent();
            this.TxtIdarticulo.Visible = false;
            this.TxtArticulo.ReadOnly = true;
            this.llenar_combobox();           
          }

        private void Consultar_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrar();
            this.Crear_Tabla();                    
            
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Consultar_FormClosing(object sender, FormClosingEventArgs e)
        {
            instancia = null;
        }

        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            Articulos open = new Articulos(this);
            open.ShowDialog();
        }

        private void ocultarcolumnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;
        }

        private void mostrar()
        {
            this.DgvListado.DataSource = Ningreso.mostrar();
            this.ocultarcolumnas();
            lblTotal.Text = "Total Registros " + DgvListado.Rows.Count.ToString();
        }

        private void mostrar_detalle()
        {
            this.DgvListadoDetalle.DataSource = Ningreso.mostrardetalle(this.TxtIdingreso.Text);
        }

        private void buscar_fecha()
        {
            this.DgvListado.DataSource = Ningreso.buscarfecha(DateTimeFechaIngreso.Value.ToString("dd/MM/yyyy"), DateTimeFecha2.Value.ToString("dd/MM/yyyy"));
            this.ocultarcolumnas();
            lblTotal.Text = "Total Registros " + DgvListado.Rows.Count.ToString();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar_fecha();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opciones;
                opciones = MessageBox.Show("Quieres Anular Registro", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opciones == DialogResult.OK)
                {
                    string codigo;
                    foreach (DataGridViewRow filas in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(filas.Cells[0].Value))
                        {
                            codigo = filas.Cells[1].Value.ToString();
                            Ningreso.anular(Convert.ToInt32(codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("no se pudo eliminar");

            }
        }

        private void ChkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEliminar.Checked)
            {
                this.DgvListado.Columns[0].Visible = true;
            }
            else
            {
                this.DgvListado.Columns[0].Visible = false;
            }
        }
        private void Crear_Tabla()
        {
            this.DTDetalle = new DataTable("Detalle");
            this.DTDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DTDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DTDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.DTDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.DTDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Decimal"));
            this.DTDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.DTDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));

            this.DgvListadoDetalle.DataSource = this.DTDetalle;

        }

        private void llenar_combobox()
        {
            CmbProveedor.DataSource = NProveedor.mostrar_proveedor();
            CmbProveedor.ValueMember = "idproveedor";
            CmbProveedor.DisplayMember = "razon_social";
        }

        private void limpiar()
        {
            this.Crear_Tabla();
        }
        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Ningreso ap = new Ningreso();
            ap.ingresar(idtrabajador, Convert.ToInt32(CmbProveedor.SelectedValue), DateTimeFechaIngreso.Value, CmbComprobante.Text, TxtSerie.Text,TxtCorrelativo.Text, Convert.ToDecimal(TxtIgv.Text), "EMITIDO",DTDetalle);
        }

        private void BtAgregar_Click(object sender, EventArgs e)
        {
            bool registrar = true;
            foreach (DataRow row in DTDetalle.Rows)
            {
                if (Convert.ToInt32(row["idarticulo"])== Convert.ToInt32(this.TxtIdarticulo.Text))
                {
                    registrar = false;
                    MessageBox.Show("Ya se encuentra el articulo en el detalle");
                }
            }
            if (registrar)
            {
                decimal subtotal = Convert.ToDecimal(this.TxtStock.Text) * Convert.ToDecimal(this.TxtPrecioCompra.Text);
                totalpagado = totalpagado + subtotal;
                this.lblTotalPagar.Text = totalpagado.ToString("#0.00#");

                DataRow row = this.DTDetalle.NewRow();
                row["idarticulo"] = Convert.ToInt32(this.TxtIdarticulo.Text);
                row["articulo"] = this.TxtArticulo.Text;
                row["precio_compra"] = Convert.ToDecimal(TxtPrecioCompra.Text);
                row["precio_venta"] = Convert.ToDecimal(txtPrecioventa.Text);
                row["stock_inicial"] = Convert.ToInt32(TxtStock.Text);
                row["fecha_produccion"] = DateTimefecha_prod.Value;
                row["fecha_vencimiento"] = DateTime_vencimiento.Value;
                row["subtotal"] = subtotal;
                this.DTDetalle.Rows.Add(row);

            }
                 
            }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indicefilas = this.DgvListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.DTDetalle.Rows[indicefilas];

                totalpagado = this.totalpagado - Convert.ToDecimal(row["subtotal"].ToString());
                lblTotalPagar.Text = totalpagado.ToString("#0.00#");
                this.DTDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + " no se pudo quitar de la fila");
            }
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
          
            this.TxtIdingreso.Text = DgvListado.CurrentRow.Cells["idingreso"].Value.ToString();
            this.CmbProveedor.SelectedValue = DgvListado.CurrentRow.Cells["proveedor"].Value;
            this.DateTimeFechaIngreso.Value = Convert.ToDateTime(DgvListado.CurrentRow.Cells["fecha"].Value);
            this.CmbComprobante.Text = DgvListado.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            this.TxtSerie.Text = DgvListado.CurrentRow.Cells["serie"].Value.ToString();
            this.TxtCorrelativo.Text = DgvListado.CurrentRow.Cells["correlativo"].Value.ToString();
            this.lblTotalPagar.Text = DgvListado.CurrentRow.Cells["total"].Value.ToString();
            this.mostrar_detalle();
            this.tabControl1.SelectedIndex = 1;
        }
    }
    }

