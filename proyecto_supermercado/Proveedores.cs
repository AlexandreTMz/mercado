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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {            
            
            this.Top = 0;
            this.Left = 0;
            this.mostrar_proveedores();
        }

        private void ocultar_columnas()
        {
            this.DgvListado.Columns[0].Visible = false;
            this.DgvListado.Columns[1].Visible = false;
        }

        private void mostrar_proveedores()
        {
            this.DgvListado.DataSource = NProveedor.mostrar_proveedor();
            this.ocultar_columnas();
            lblTotal.Text = "Total registros :  " + DgvListado.Rows.Count.ToString();
        }

        private void buscar_documento()
        {
            this.DgvListado.DataSource = NProveedor.buscar_num_documento(TxtBuscar.Text);
            this.ocultar_columnas();
            this.lblTotal.Text = "Total registros : " + DgvListado.Rows.Count.ToString();
        }

        private void buscar_razon_social()
        {
            this.DgvListado.DataSource = NProveedor.buscar_razon_social(TxtBuscar.Text);
            this.ocultar_columnas();
            this.lblTotal.Text = "Total registros : " + DgvListado.Rows.Count.ToString();
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (CmbBuscar.Text.Equals("Razon social"))
            {
                this.buscar_razon_social();

            }else if (CmbBuscar.Text.Equals("Documento"))
            {
                this.buscar_documento();
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
                    foreach (DataGridViewRow filas in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(filas.Cells[0].Value))
                        {
                            codigo = filas.Cells[1].Value.ToString();
                            NProveedor.Eliminar_proveedor(Convert.ToInt32(codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                MessageBox.Show("no se pudo eliminar");

            }

            this.mostrar_proveedores();
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            NProveedor proveedor = new NProveedor(Convert.ToInt32(TxtidProveedor.Text) ,TxtRazon_social.Text, CmbSector_comercial.Text, CmbTipoDocumento.Text, TxtNum_documento.Text, TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text, TxtURL.Text);
            proveedor.insertar();
            this.mostrar_proveedores();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            NProveedor proveedor = new NProveedor(Convert.ToInt32(TxtidProveedor.Text),TxtRazon_social.Text, CmbSector_comercial.Text, CmbTipoDocumento.Text, TxtNum_documento.Text, TxtDireccion.Text, TxtTelefono.Text, TxtEmail.Text, TxtURL.Text);
            proveedor.editar();
            this.mostrar_proveedores();
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==DgvListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.TxtidProveedor.Text = this.DgvListado.CurrentRow.Cells["idproveedor"].Value.ToString();
                this.TxtRazon_social.Text = this.DgvListado.CurrentRow.Cells["razon_social"].Value.ToString();
                this.CmbSector_comercial.Text = this.DgvListado.CurrentRow.Cells["sector_comercial"].Value.ToString();
                this.CmbTipoDocumento.Text = this.DgvListado.CurrentRow.Cells["tipo_documento"].Value.ToString();
                this.TxtNum_documento.Text = this.DgvListado.CurrentRow.Cells["num_documento"].Value.ToString();
                this.TxtDireccion.Text = this.DgvListado.CurrentRow.Cells["direccion"].Value.ToString();
                this.TxtTelefono.Text = this.DgvListado.CurrentRow.Cells["telefono"].Value.ToString();
                this.TxtEmail.Text = this.DgvListado.CurrentRow.Cells["email"].Value.ToString();
                this.TxtURL.Text = this.DgvListado.CurrentRow.Cells["url"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            

            this.tabControl1.SelectedIndex = 1;
        }
    }
}
