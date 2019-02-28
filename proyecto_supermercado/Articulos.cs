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
        Consultar objConsultar = null;
        public Articulos(Consultar consultar)
        {
            InitializeComponent();
            objConsultar = consultar;
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
            //Consultar form = new Consultar();
            //string par1, par2;
            //par1 = Convert.ToString(this.DgvListado.CurrentRow.Cells["idarticulo"].Value);
            //par2 = Convert.ToString(this.DgvListado.CurrentRow.Cells["nombre"].Value);
            //form.setArticulo(par1, par2);
            //objConsultar.TxtArticulo.Text = valor1;
            //objConsultar.TxtIdarticulo.Text = valor2;
            //this.Hide();
            objConsultar.TxtIdarticulo.Text = Convert.ToString(this.DgvListado.CurrentRow.Cells["idarticulo"].Value);
            objConsultar.TxtArticulo.Text = Convert.ToString(this.DgvListado.CurrentRow.Cells["nombre"].Value);
            this.Hide();
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
