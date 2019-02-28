namespace proyecto_supermercado
{
    partial class Supermercado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supermercado));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.BtnPresentacion = new System.Windows.Forms.Button();
            this.BtnCategoria = new System.Windows.Forms.Button();
            this.BtnEmpleados = new System.Windows.Forms.Button();
            this.BtnInventarios = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnProveedores = new System.Windows.Forms.Button();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.BtnProductos = new System.Windows.Forms.Button();
            this.BtnVentas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.fecha = new System.Windows.Forms.Label();
            this.Hora = new System.Windows.Forms.Label();
            this.IconRestaurar = new System.Windows.Forms.PictureBox();
            this.BtnMaximizar = new System.Windows.Forms.PictureBox();
            this.BtnMinimizar = new System.Windows.Forms.PictureBox();
            this.BTnCerrar = new System.Windows.Forms.PictureBox();
            this.PanelContenedor = new System.Windows.Forms.Panel();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.DarkOrange;
            this.MenuVertical.Controls.Add(this.BtnPresentacion);
            this.MenuVertical.Controls.Add(this.BtnCategoria);
            this.MenuVertical.Controls.Add(this.BtnEmpleados);
            this.MenuVertical.Controls.Add(this.BtnInventarios);
            this.MenuVertical.Controls.Add(this.button1);
            this.MenuVertical.Controls.Add(this.BtnProveedores);
            this.MenuVertical.Controls.Add(this.BtnConsultar);
            this.MenuVertical.Controls.Add(this.BtnProductos);
            this.MenuVertical.Controls.Add(this.BtnVentas);
            this.MenuVertical.Controls.Add(this.pictureBox1);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(250, 650);
            this.MenuVertical.TabIndex = 0;
            // 
            // BtnPresentacion
            // 
            this.BtnPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPresentacion.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPresentacion.ForeColor = System.Drawing.Color.White;
            this.BtnPresentacion.Image = global::proyecto_supermercado.Properties.Resources.empleado;
            this.BtnPresentacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPresentacion.Location = new System.Drawing.Point(12, 443);
            this.BtnPresentacion.Name = "BtnPresentacion";
            this.BtnPresentacion.Size = new System.Drawing.Size(232, 40);
            this.BtnPresentacion.TabIndex = 9;
            this.BtnPresentacion.Text = "Presentacion";
            this.BtnPresentacion.UseVisualStyleBackColor = true;
            this.BtnPresentacion.Click += new System.EventHandler(this.BtnPresentacion_Click);
            // 
            // BtnCategoria
            // 
            this.BtnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCategoria.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCategoria.ForeColor = System.Drawing.Color.White;
            this.BtnCategoria.Image = global::proyecto_supermercado.Properties.Resources.empleado;
            this.BtnCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCategoria.Location = new System.Drawing.Point(12, 397);
            this.BtnCategoria.Name = "BtnCategoria";
            this.BtnCategoria.Size = new System.Drawing.Size(232, 40);
            this.BtnCategoria.TabIndex = 8;
            this.BtnCategoria.Text = "Categoria";
            this.BtnCategoria.UseVisualStyleBackColor = true;
            this.BtnCategoria.Click += new System.EventHandler(this.BtnCategoria_Click);
            // 
            // BtnEmpleados
            // 
            this.BtnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEmpleados.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpleados.ForeColor = System.Drawing.Color.White;
            this.BtnEmpleados.Image = global::proyecto_supermercado.Properties.Resources.empleado;
            this.BtnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEmpleados.Location = new System.Drawing.Point(9, 351);
            this.BtnEmpleados.Name = "BtnEmpleados";
            this.BtnEmpleados.Size = new System.Drawing.Size(232, 40);
            this.BtnEmpleados.TabIndex = 7;
            this.BtnEmpleados.Text = "Empleados";
            this.BtnEmpleados.UseVisualStyleBackColor = true;
            this.BtnEmpleados.Click += new System.EventHandler(this.BtnEmpleados_Click);
            // 
            // BtnInventarios
            // 
            this.BtnInventarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventarios.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInventarios.ForeColor = System.Drawing.Color.White;
            this.BtnInventarios.Image = global::proyecto_supermercado.Properties.Resources.inventario1;
            this.BtnInventarios.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInventarios.Location = new System.Drawing.Point(9, 305);
            this.BtnInventarios.Name = "BtnInventarios";
            this.BtnInventarios.Size = new System.Drawing.Size(232, 40);
            this.BtnInventarios.TabIndex = 6;
            this.BtnInventarios.Text = "Clientes";
            this.BtnInventarios.UseVisualStyleBackColor = true;
            this.BtnInventarios.Click += new System.EventHandler(this.BtnInventarios_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::proyecto_supermercado.Properties.Resources.proyecto_de_ley_1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(12, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Facturas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProveedores.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProveedores.ForeColor = System.Drawing.Color.White;
            this.BtnProveedores.Image = global::proyecto_supermercado.Properties.Resources.grupo;
            this.BtnProveedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProveedores.Location = new System.Drawing.Point(12, 207);
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(232, 40);
            this.BtnProveedores.TabIndex = 4;
            this.BtnProveedores.Text = "Proveedores";
            this.BtnProveedores.UseVisualStyleBackColor = true;
            this.BtnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConsultar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultar.ForeColor = System.Drawing.Color.White;
            this.BtnConsultar.Image = global::proyecto_supermercado.Properties.Resources.lupa;
            this.BtnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConsultar.Location = new System.Drawing.Point(12, 161);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(232, 40);
            this.BtnConsultar.TabIndex = 3;
            this.BtnConsultar.Text = "ingreso";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // BtnProductos
            // 
            this.BtnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProductos.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProductos.ForeColor = System.Drawing.Color.White;
            this.BtnProductos.Image = global::proyecto_supermercado.Properties.Resources.cesta_de_la_compra;
            this.BtnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnProductos.Location = new System.Drawing.Point(12, 115);
            this.BtnProductos.Name = "BtnProductos";
            this.BtnProductos.Size = new System.Drawing.Size(232, 40);
            this.BtnProductos.TabIndex = 2;
            this.BtnProductos.Text = "Productos";
            this.BtnProductos.UseVisualStyleBackColor = true;
            this.BtnProductos.Click += new System.EventHandler(this.BtnProductos_Click);
            // 
            // BtnVentas
            // 
            this.BtnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVentas.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVentas.ForeColor = System.Drawing.Color.White;
            this.BtnVentas.Image = global::proyecto_supermercado.Properties.Resources.moneda1;
            this.BtnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnVentas.Location = new System.Drawing.Point(12, 69);
            this.BtnVentas.Name = "BtnVentas";
            this.BtnVentas.Size = new System.Drawing.Size(232, 40);
            this.BtnVentas.TabIndex = 1;
            this.BtnVentas.Text = "Ventas";
            this.BtnVentas.UseVisualStyleBackColor = true;
            this.BtnVentas.Click += new System.EventHandler(this.BtnVentas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::proyecto_supermercado.Properties.Resources.white_shopping_cart_md1;
            this.pictureBox1.Location = new System.Drawing.Point(81, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.Controls.Add(this.fecha);
            this.BarraTitulo.Controls.Add(this.Hora);
            this.BarraTitulo.Controls.Add(this.IconRestaurar);
            this.BarraTitulo.Controls.Add(this.BtnMaximizar);
            this.BarraTitulo.Controls.Add(this.BtnMinimizar);
            this.BarraTitulo.Controls.Add(this.BTnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1050, 50);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.ForeColor = System.Drawing.Color.Orange;
            this.fecha.Location = new System.Drawing.Point(392, 29);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(60, 18);
            this.fecha.TabIndex = 22;
            this.fecha.Text = "label1";
            // 
            // Hora
            // 
            this.Hora.AutoSize = true;
            this.Hora.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hora.ForeColor = System.Drawing.Color.DarkOrange;
            this.Hora.Location = new System.Drawing.Point(450, 9);
            this.Hora.Name = "Hora";
            this.Hora.Size = new System.Drawing.Size(71, 18);
            this.Hora.TabIndex = 21;
            this.Hora.Text = "label15";
            // 
            // IconRestaurar
            // 
            this.IconRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconRestaurar.Image = global::proyecto_supermercado.Properties.Resources.restore_window2;
            this.IconRestaurar.Location = new System.Drawing.Point(992, 0);
            this.IconRestaurar.Name = "IconRestaurar";
            this.IconRestaurar.Size = new System.Drawing.Size(20, 20);
            this.IconRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconRestaurar.TabIndex = 1;
            this.IconRestaurar.TabStop = false;
            this.IconRestaurar.Visible = false;
            this.IconRestaurar.Click += new System.EventHandler(this.IconRestaurar_Click);
            // 
            // BtnMaximizar
            // 
            this.BtnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMaximizar.Image = global::proyecto_supermercado.Properties.Resources.app1;
            this.BtnMaximizar.Location = new System.Drawing.Point(992, 0);
            this.BtnMaximizar.Name = "BtnMaximizar";
            this.BtnMaximizar.Size = new System.Drawing.Size(20, 20);
            this.BtnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMaximizar.TabIndex = 0;
            this.BtnMaximizar.TabStop = false;
            this.BtnMaximizar.Click += new System.EventHandler(this.BtnMaximizar_Click);
            // 
            // BtnMinimizar
            // 
            this.BtnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMinimizar.Image = global::proyecto_supermercado.Properties.Resources.circle_minimize_5121;
            this.BtnMinimizar.Location = new System.Drawing.Point(966, 0);
            this.BtnMinimizar.Name = "BtnMinimizar";
            this.BtnMinimizar.Size = new System.Drawing.Size(20, 20);
            this.BtnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnMinimizar.TabIndex = 0;
            this.BtnMinimizar.TabStop = false;
            this.BtnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // BTnCerrar
            // 
            this.BTnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTnCerrar.Image = global::proyecto_supermercado.Properties.Resources._611552;
            this.BTnCerrar.Location = new System.Drawing.Point(1018, 0);
            this.BTnCerrar.Name = "BTnCerrar";
            this.BTnCerrar.Size = new System.Drawing.Size(20, 20);
            this.BTnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BTnCerrar.TabIndex = 0;
            this.BTnCerrar.TabStop = false;
            this.BTnCerrar.Click += new System.EventHandler(this.BTnCerrar_Click);
            // 
            // PanelContenedor
            // 
            this.PanelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContenedor.Location = new System.Drawing.Point(250, 50);
            this.PanelContenedor.Name = "PanelContenedor";
            this.PanelContenedor.Size = new System.Drawing.Size(1050, 600);
            this.PanelContenedor.TabIndex = 2;
            // 
            // HoraFecha
            // 
            this.HoraFecha.Enabled = true;
            this.HoraFecha.Tick += new System.EventHandler(this.HoraFecha_Tick);
            // 
            // Supermercado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.PanelContenedor);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Supermercado";
            this.Text = "Supermercado";
            this.Load += new System.EventHandler(this.Supermercado_Load);
            this.MenuVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BTnCerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.Panel PanelContenedor;
        private System.Windows.Forms.PictureBox BTnCerrar;
        private System.Windows.Forms.PictureBox BtnMinimizar;
        private System.Windows.Forms.PictureBox BtnMaximizar;
        private System.Windows.Forms.PictureBox IconRestaurar;
        private System.Windows.Forms.Button BtnVentas;
        private System.Windows.Forms.Button BtnProductos;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Button BtnProveedores;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label Hora;
        private System.Windows.Forms.Timer HoraFecha;
        private System.Windows.Forms.Button BtnInventarios;
        private System.Windows.Forms.Button BtnEmpleados;
        private System.Windows.Forms.Button BtnCategoria;
        private System.Windows.Forms.Button BtnPresentacion;
    }
}