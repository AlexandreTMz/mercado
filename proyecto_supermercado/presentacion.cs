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
    public partial class presentacion : Form
    {
        public presentacion()
        {
            InitializeComponent();
            this.ttmensaje.SetToolTip(TxtNombre, "Ingrese el nombre");
        }

        private void clear()
        {
            TxtCodigo.Clear();
            TxtNombre.Clear();
            TxtDescipcion.Clear();
        }

        public void ocultarColumnas()
        {
            this.DgvListado.Columns[0].Visible = false;

        }
        public void mostrar()
        {
            this.DgvListado.DataSource = Npresentacion.mostrar();
            this.ocultarColumnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();
        }

        public void buscar()
        {
            this.DgvListado.DataSource = Npresentacion.buscar_nombre(this.TxtBuscar.Text);
            this.ocultarColumnas();
            lblTotal.Text = "Total Registros: " + DgvListado.Rows.Count.ToString();
        }

        private void presentacion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrar();
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
                    Npresentacion.insertar_presentacion(TxtNombre.Text, TxtDescipcion.Text);
                    MessageBox.Show("Dato ha sido guardado", " informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                mostrar();
                clear();

            }
            catch (Exception ex)
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
            this.TxtCodigo.Text = DgvListado.CurrentRow.Cells["idpresentacion"].Value.ToString();
            this.TxtNombre.Text = DgvListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.TxtDescipcion.Text = DgvListado.CurrentRow.Cells["descripcion"].Value.ToString();
            this.tabControl1.SelectedIndex = 1;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Validar cv = new Validar();
            try
            {

                Npresentacion.editar(Convert.ToInt32(TxtCodigo.Text), TxtNombre.Text, TxtDescipcion.Text);
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
            this.clear();
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
            if (e.ColumnIndex==DgvListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opciones;
                opciones = MessageBox.Show("Quieres Eliminar Registro", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opciones == DialogResult.OK)
                {
                    string codigo;
                    foreach  (DataGridViewRow filas in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(filas.Cells[0].Value))
                        {
                            codigo = filas.Cells[1].Value.ToString();
                            Npresentacion.eliminar(Convert.ToInt32(codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
                MessageBox.Show("no se pudo eliminar");
            }

            this.mostrar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar();
        }
    }
}
