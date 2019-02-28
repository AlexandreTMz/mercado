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
namespace proyecto_supermercado
{
    public partial class vista : Form
    {
        public vista()
        {
            InitializeComponent();
        }

        private void vista_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }

        public void mostrar()
        {
            this.DgvListado.DataSource = NCategoria.mostrar();
            this.ocultarColumnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();
        }

        public void buscar()
        {
            this.DgvListado.DataSource = NCategoria.Buscar_nombre(TxtBuscar.Text);
            this.ocultarColumnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();

        }
        public void ocultarColumnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }
    }
}
