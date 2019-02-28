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
    public partial class Categoria : Form
    {       

        public Categoria()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(TxtNombre, "Ingrese el nombre de la categoria");

        }       

        private void clear()
        {           
            TxtCodigo.Clear();
            TxtDescipcion.Clear();
            TxtNombre.Clear();
        }       

        public void ocultarColumnas()
        {      
                this.DgvListado.Columns[0].Visible = false;
                this.DgvListado.Columns[1].Visible = false;      
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
        private void Categoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrar();            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }       

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            { 
              
                if (this.TxtNombre.Text == string.Empty)
                {
                    MessageBox.Show("Error", "debe ingresar todos los datos ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    NCategoria.Insertar(TxtNombre.Text, TxtDescipcion.Text);
                    MessageBox.Show("Dato ha sido guardado", " informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                mostrar();
                clear();

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
               
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.TxtCodigo.Text = DgvListado.CurrentRow.Cells["idcategoria"].Value.ToString();
            this.TxtNombre.Text = DgvListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.TxtDescipcion.Text = DgvListado.CurrentRow.Cells["descripcion"].Value.ToString();
            this.tabControl1.SelectedIndex = 1;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
            Validar cv = new Validar();
            try
            {             

                NCategoria.Editar(Convert.ToInt32(TxtCodigo.Text), TxtNombre.Text, TxtDescipcion.Text);
                MessageBox.Show("actualizado correctamente");
                mostrar();
                clear();
            }
            catch (Exception)
            {
                MessageBox.Show("debe seleecionar una fila con doble click");                
            }
               
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            clear();
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

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==DgvListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);

            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Desea Eliminar los registros", "Supermercado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion==DialogResult.OK)
                {
                    string codigo;
                    //string repuesta = "";
                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = row.Cells[1].Value.ToString();
                            NCategoria.Eliminar(Convert.ToInt32(codigo));

                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.mostrar();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar();
        }
    }
}
