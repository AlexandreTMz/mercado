using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using Capa_Datos;

namespace proyecto_supermercado
{
    public partial class Articulos : Form
    {

        public string Par1 { get; set; }
        public string Par2 { get; set; }

        public Articulos()
        {
            InitializeComponent();
        }

        private void ocultar_columnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;
            this.DgvListado.Columns[6].Visible = false;
            this.DgvListado.Columns[8].Visible = false;

        }

        private void mostrar_articulo()
        {
            this.DgvListado.DataSource = NArticulo.mostrar();
            this.ocultar_columnas();
            lblTotal.Text = "Total registros :  " + DgvListado.Rows.Count.ToString();
        }

        private void buscar_Articulo()
        {
            this.DgvListado.DataSource = NArticulo.buscar(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total registros : " + DgvListado.Rows.Count.ToString();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {
            this.mostrar_articulo();
            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar_Articulo();
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
           
            Par1 = Convert.ToString(this.DgvListado.CurrentRow.Cells["idarticulo"].Value);
            Par2 = Convert.ToString(this.DgvListado.CurrentRow.Cells["nombre"].Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

       

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar_Articulo();
        }
    }
}
