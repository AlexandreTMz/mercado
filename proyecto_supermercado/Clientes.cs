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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

            this.Top = 0;
            this.Left = 0;
            mostrar();
            ocultar_columnas();

        }

        private void ocultar_columnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;
        }

        public void mostrar()
        {
            this.DgvListado.DataSource = NCliente.mostrar_cliente();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();
        }


        private void buscar_apellido()
        {
            this.DgvListado.DataSource = NCliente.buscar_apellido(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();

        }

        private void buscar_identificacion()
        {
            this.DgvListado.DataSource = NCliente.buscar_identificacion(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();

        }

        

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            NCliente cliente = new NCliente(Convert.ToInt32(TxtIDcliente.Text) , TxtNombre.Text, TxtApellido.Text, CmbSexo.Text, DateTimeFecha_nacimiento.Value, CmbTipo_documento.Text, Txtidentificacion.Text,TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text );
            cliente.insertar();
            this.mostrar();
           
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
                    foreach (DataGridViewRow filas in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(filas.Cells[0].Value))
                        {
                            codigo = filas.Cells[1].Value.ToString();
                            NCliente.Eliminar(Convert.ToInt32(codigo));
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

            if (e.ColumnIndex == DgvListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.TxtIDcliente.Text = this.DgvListado.CurrentRow.Cells["idcliente"].Value.ToString();
            this.TxtNombre.Text = this.DgvListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.TxtApellido.Text = this.DgvListado.CurrentRow.Cells["apellidos"].Value.ToString();
            this.Txtidentificacion.Text = this.DgvListado.CurrentRow.Cells["num_documento"].Value.ToString();
            this.TxtEmail.Text = this.DgvListado.CurrentRow.Cells["email"].Value.ToString();
            this.TxtDireccion.Text = this.DgvListado.CurrentRow.Cells["direccion"].Value.ToString();
            this.TxtTelefono.Text = this.DgvListado.CurrentRow.Cells["telefono"].Value.ToString();
            this.CmbSexo.Text = this.DgvListado.CurrentRow.Cells["sexo"].Value.ToString();
            this.CmbTipo_documento.Text = this.DgvListado.CurrentRow.Cells["tipo_documento"].Value.ToString();
            this.DateTimeFecha_nacimiento.Value = Convert.ToDateTime(this.DgvListado.CurrentRow.Cells["fecha_nacimiento"].Value);

            this.tabControl1.SelectedIndex = 1;

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (CmBuscar.Text.Equals("apellido"))
            {
                this.buscar_apellido();
            }
            else if (CmBuscar.Text.Equals("identificacion"))
            {
                this.buscar_identificacion();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            NCliente cliente = new NCliente(Convert.ToInt32(TxtIDcliente.Text), TxtNombre.Text, TxtApellido.Text, CmbSexo.Text, DateTimeFecha_nacimiento.Value, CmbTipo_documento.Text, Txtidentificacion.Text, TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text);
            cliente.Editar();
            this.mostrar();
        }
    }
}

