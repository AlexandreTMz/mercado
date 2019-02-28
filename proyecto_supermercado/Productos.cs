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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            this.llenar_comboBox();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiar()
        {
            this.PximgenCargar.Image = global::proyecto_supermercado.Properties.Resources.file;
            TxtNombre.Clear();
            TxtCodigoVentas.Clear();
            TxtDescipcion.Clear();
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

      

        private void llenar_comboBox()
        {
            CmbCategoria.DataSource = NCategoria.mostrar();
            CmbCategoria.ValueMember = "idcategoria";
            CmbCategoria.DisplayMember = "nombre";
            CmbPresentacion.DataSource = Npresentacion.mostrar();
            CmbPresentacion.ValueMember = "idpresentacion";
            CmbPresentacion.DisplayMember = "nombre";
        }
        private void buscar_Articulo()
        {
            this.DgvListado.DataSource = NArticulo.buscar(TxtBuscar.Text);
            this.ocultar_columnas();
            lblTotal.Text = "Total registros : " + DgvListado.Rows.Count.ToString();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            DialogResult resultado = open.ShowDialog();

            if (resultado==DialogResult.OK)
             {
                this.PximgenCargar.SizeMode = PictureBoxSizeMode.StretchImage;
                this.PximgenCargar.Image = Image.FromFile(open.FileName);
            }
        }

        private void Btlimpiar_Click(object sender, EventArgs e)
        {
            this.PximgenCargar.SizeMode = PictureBoxSizeMode.StretchImage;
            this.PximgenCargar.Image = global::proyecto_supermercado.Properties.Resources.file;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.mostrar_articulo();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.buscar_Articulo();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscar_Articulo();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            this.PximgenCargar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imagen = ms.GetBuffer();

           NArticulo articulo = new NArticulo(TxtCodigoVentas.Text, TxtNombre.Text, TxtDescipcion.Text, imagen, Convert.ToInt32(this.CmbCategoria.SelectedValue), Convert.ToInt32(CmbPresentacion.SelectedValue));
            articulo.insertar_articulo();
            mostrar_articulo();
            limpiar();
            MessageBox.Show("datos guardado en la base de datos");
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.PximgenCargar.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imagen = ms.GetBuffer();

                DArticulo editar = new DArticulo(Convert.ToInt32(Txtarticulo.Text), TxtCodigoVentas.Text, TxtNombre.Text, TxtDescipcion.Text, imagen, Convert.ToInt32(this.CmbCategoria.SelectedValue), Convert.ToInt32(CmbPresentacion.SelectedValue), TxtBuscar.Text);
                editar.editar();
                mostrar_articulo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
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

        private void DgvListado_DoubleClick(object sender, EventArgs e)
        {
            this.Txtarticulo.Text = this.DgvListado.CurrentRow.Cells["idarticulo"].Value.ToString();
            this.TxtCodigoVentas.Text = this.DgvListado.CurrentRow.Cells["codigo"].Value.ToString();
            this.TxtNombre.Text = this.DgvListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.TxtDescipcion.Text = this.DgvListado.CurrentRow.Cells["descripcion"].Value.ToString();
            byte[] imagenbuffer = (byte[])this.DgvListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenbuffer);
            this.PximgenCargar.Image = Image.FromStream(ms);
            this.PximgenCargar.SizeMode = PictureBoxSizeMode.StretchImage;
            this.CmbCategoria.SelectedValue = this.DgvListado.CurrentRow.Cells["idcategoria"].Value;
            this.CmbPresentacion.SelectedValue = this.DgvListado.CurrentRow.Cells["idpresentacion"].Value;
            this.tabControl1.SelectedIndex = 1;
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
                            NArticulo.Eliminar(Convert.ToInt32(codigo));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
                MessageBox.Show("no se pudo eliminar");
            }

            this.mostrar_articulo();
        }
    }
}
