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
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Txtusuario.Text == "")
                Txtusuario.Text = "Usuario";
            Txtusuario.ForeColor = Color.Silver;          
        }

        private void TxtContraseña_Leave(object sender, EventArgs e)
        {
            if (TxtContraseña.Text == "")
                TxtContraseña.Text = "Contraseña";
            TxtContraseña.ForeColor = Color.Silver;
            TxtContraseña.UseSystemPasswordChar = false;
           
        }

        private void Txtusuario_Enter(object sender, EventArgs e)
        {
            if (Txtusuario.Text == "Usuario")
                Txtusuario.Text = "";
            TxtContraseña.ForeColor = Color.Silver;            
        }

        private void TxtContraseña_Enter(object sender, EventArgs e)
        {
            if (TxtContraseña.Text == "Contraseña")
                TxtContraseña.Text = "";
            TxtContraseña.ForeColor = Color.Silver;
            TxtContraseña.UseSystemPasswordChar = true;          
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(" ¿ Desea salir del programa ?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Application.Exit();
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable datos = Capa_Negocio.Ntrabajador.login(Txtusuario.Text, TxtContraseña.Text);

            if (datos.Rows.Count == 0)
            {
                MessageBox.Show("Usuario", "El usuario no existe ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Supermercado open = new Supermercado(datos.Rows[0][0].ToString());
                open.idtrabajador = datos.Rows[0][0].ToString();
                MessageBox.Show("ID L: "+open.idtrabajador);
                open.nombre = datos.Rows[0][1].ToString();
                open.apellidos = datos.Rows[0][2].ToString();
                open.acceso = datos.Rows[0][3].ToString();
                open.Show();
                this.Hide();
               

            }
            
        }
    }
}
