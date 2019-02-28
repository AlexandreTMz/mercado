using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_supermercado
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Ventas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Add)
            {
                MessageBox.Show("esta presionado la tecla +");
            }
        }
    }
    }

