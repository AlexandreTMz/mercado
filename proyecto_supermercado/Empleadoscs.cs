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
    public partial class Empleadoscs : Form
    {
        public Empleadoscs()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Empleadoscs_Load(object sender, EventArgs e)
        {
            this.Top = 0;         
            this.Left = 0;          
            mostrar_empleado();
        }

        private void mostrar_empleado()
        {
            this.DgvListado.DataSource = Ntrabajador.mostrar_trabajadores();
            this.ocultar_columnas();
            lblTotal.Text = "Total de Registros: " + DgvListado.Rows.Count.ToString();
        }
        private void ocultar_columnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;
        }
        
        private void buscar_apellido()
        {
            this.DgvListado.DataSource = Ntrabajador.buscar_apellido(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();

        }

        private void buscar_documento()
        {
            this.DgvListado.DataSource = Ntrabajador.buscar_numero_documento(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total de registros " + DgvListado.Rows.Count.ToString();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (CmBuscar.Text.Equals("apellido"))
            {
                this.buscar_apellido();
            }else if (CmBuscar.Text.Equals("identificacion"))
            {
                this.buscar_documento();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Ntrabajador ap = new Ntrabajador(Convert.ToInt32(TxtIDtrabajador.Text), TxtNombre.Text, TxtApellido.Text, CmbSexo.Text, DateTimeFecha_nacimiento.Value, Txtidentificacion.Text, TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text, CmBAcceso.Text, TxtUsuario.Text, TxtPassword.Text);
            ap.insertar();
            mostrar_empleado();
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
                            Ntrabajador.eliminar(Convert.ToInt32(codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                MessageBox.Show("no se pudo eliminar");

            }
            this.mostrar_empleado();
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
            DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["eliminar"];
            ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
        }

        private void DgvListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Ntrabajador ap = new Ntrabajador(Convert.ToInt32(TxtIDtrabajador.Text), TxtNombre.Text, TxtApellido.Text, CmbSexo.Text, DateTimeFecha_nacimiento.Value, Txtidentificacion.Text, TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text, CmBAcceso.Text, TxtUsuario.Text, TxtPassword.Text);
              ap.editar();
            this.mostrar_empleado();
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.TxtIDtrabajador.Text = this.DgvListado.CurrentRow.Cells["idtrabajador"].Value.ToString();
            this.TxtNombre.Text = this.DgvListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.TxtApellido.Text = this.DgvListado.CurrentRow.Cells["apellidos"].Value.ToString();
            this.Txtidentificacion.Text = this.DgvListado.CurrentRow.Cells["numero_documento"].Value.ToString();
            this.TxtEmail.Text = this.DgvListado.CurrentRow.Cells["email"].Value.ToString();
            this.TxtDireccion.Text = this.DgvListado.CurrentRow.Cells["direccion"].Value.ToString();
            this.TxtTelefono.Text = this.DgvListado.CurrentRow.Cells["telefono"].Value.ToString();
            this.CmbSexo.Text = this.DgvListado.CurrentRow.Cells["sexo"].Value.ToString();
            this.CmBAcceso.Text = this.DgvListado.CurrentRow.Cells["acceso"].Value.ToString();
            this.DateTimeFecha_nacimiento.Value = Convert.ToDateTime(this.DgvListado.CurrentRow.Cells["fecha_nac"].Value);
            this.TxtUsuario.Text = this.DgvListado.CurrentRow.Cells["usuario"].Value.ToString();
            this.TxtPassword.Text = this.DgvListado.CurrentRow.Cells["pasword"].Value.ToString();

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
