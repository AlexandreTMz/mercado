using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace proyecto_supermercado
{
    public partial class Supermercado : Form
    {
        public string idtrabajador = "";
        public string apellidos = "";
        public string nombre = "";
        public string acceso = "";

        public Supermercado()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BTnCerrar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("¿Desea salir del programar? ", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Application.Exit();
            }
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            IconRestaurar.Visible = true;
            BtnMaximizar.Visible = false;

        }

        private void IconRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            IconRestaurar.Visible = false;
            BtnMaximizar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormPanel(object formulario_hijo_Ventas)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = formulario_hijo_Ventas as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();

        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Ventas());
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Productos());
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Consultar());
            Consultar form = Consultar.getinstancia();
            form.idtrabajador = Convert.ToInt32(this.idtrabajador);
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Proveedores());
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToLongTimeString();
            fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Facturas());
        }

        private void BtnInventarios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Clientes());
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Empleadoscs());
        }

        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new Categoria());
        }

        private void BtnPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new presentacion());
        }

        private void GestionUsuario()
        {
            if (acceso=="administrador ")
            {
                this.BtnVentas.Enabled = true;
                this.BtnConsultar.Enabled = true;

            } else if(acceso== "vendedor")
            {
                this.BtnCategoria.Enabled = false;
                this.BtnPresentacion.Enabled = false;
                this.BtnEmpleados.Enabled = false;
                this.BtnProductos.Enabled = false;
            }
        }

        private void Supermercado_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }
    }
}
