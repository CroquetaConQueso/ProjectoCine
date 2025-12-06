namespace AplicacionCine.Formularios
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            pnMid = new Panel();
            panelBotones = new Panel();
            toolStrip1 = new ToolStrip();
            btnNavPases = new ToolStripButton();
            btnNavReservas = new ToolStripButton();
            btnNavPeliculas = new ToolStripButton();
            btnNavSalas = new ToolStripButton();
            btnNavUsuarios = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnNavConfiguracion = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnNavSalir = new ToolStripButton();
            pnSStrip = new Panel();
            sStrip = new StatusStrip();
            tsLnombreUsuario = new ToolStripStatusLabel();
            tsLusuario = new ToolStripStatusLabel();
            tsLestado = new ToolStripStatusLabel();
            tsLsituacion = new ToolStripStatusLabel();
            pnMStrip = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            pnMid.SuspendLayout();
            panelBotones.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnSStrip.SuspendLayout();
            sStrip.SuspendLayout();
            pnMStrip.SuspendLayout();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnMid
            // 
            pnMid.Controls.Add(pnMStrip);
            pnMid.Controls.Add(pnSStrip);
            pnMid.Controls.Add(panelBotones);
            pnMid.Dock = DockStyle.Fill;
            pnMid.Location = new Point(0, 0);
            pnMid.Name = "pnMid";
            pnMid.Size = new Size(800, 450);
            pnMid.TabIndex = 3;
            // 
            // panelBotones
            // 
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(toolStrip1);
            panelBotones.Dock = DockStyle.Left;
            panelBotones.Location = new Point(0, 0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(167, 450);
            panelBotones.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.CanOverflow = false;
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNavPases, btnNavReservas, btnNavPeliculas, btnNavSalas, btnNavUsuarios, toolStripSeparator1, btnNavConfiguracion, toolStripSeparator2, btnNavSalir });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(165, 448);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNavPases
            // 
            btnNavPases.AutoSize = false;
            btnNavPases.Image = (Image)resources.GetObject("btnNavPases.Image");
            btnNavPases.ImageScaling = ToolStripItemImageScaling.None;
            btnNavPases.ImageTransparentColor = Color.Magenta;
            btnNavPases.Margin = new Padding(0);
            btnNavPases.Name = "btnNavPases";
            btnNavPases.Size = new Size(210, 50);
            btnNavPases.Text = "Pases de hoy";
            btnNavPases.TextAlign = ContentAlignment.MiddleRight;
            btnNavPases.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // btnNavReservas
            // 
            btnNavReservas.AutoSize = false;
            btnNavReservas.Image = (Image)resources.GetObject("btnNavReservas.Image");
            btnNavReservas.ImageScaling = ToolStripItemImageScaling.None;
            btnNavReservas.ImageTransparentColor = Color.Magenta;
            btnNavReservas.Name = "btnNavReservas";
            btnNavReservas.Size = new Size(210, 50);
            btnNavReservas.Text = "Reservas";
            btnNavReservas.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNavPeliculas
            // 
            btnNavPeliculas.AutoSize = false;
            btnNavPeliculas.Image = (Image)resources.GetObject("btnNavPeliculas.Image");
            btnNavPeliculas.ImageScaling = ToolStripItemImageScaling.None;
            btnNavPeliculas.ImageTransparentColor = Color.Magenta;
            btnNavPeliculas.Name = "btnNavPeliculas";
            btnNavPeliculas.Size = new Size(210, 50);
            btnNavPeliculas.Text = "Películas";
            btnNavPeliculas.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNavSalas
            // 
            btnNavSalas.AutoSize = false;
            btnNavSalas.Image = (Image)resources.GetObject("btnNavSalas.Image");
            btnNavSalas.ImageScaling = ToolStripItemImageScaling.None;
            btnNavSalas.ImageTransparentColor = Color.Magenta;
            btnNavSalas.Name = "btnNavSalas";
            btnNavSalas.Size = new Size(210, 50);
            btnNavSalas.Text = "Salas";
            btnNavSalas.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNavUsuarios
            // 
            btnNavUsuarios.AutoSize = false;
            btnNavUsuarios.Image = (Image)resources.GetObject("btnNavUsuarios.Image");
            btnNavUsuarios.ImageScaling = ToolStripItemImageScaling.None;
            btnNavUsuarios.ImageTransparentColor = Color.Magenta;
            btnNavUsuarios.Name = "btnNavUsuarios";
            btnNavUsuarios.Size = new Size(210, 50);
            btnNavUsuarios.Text = "Usuarios";
            btnNavUsuarios.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(163, 6);
            // 
            // btnNavConfiguracion
            // 
            btnNavConfiguracion.AutoSize = false;
            btnNavConfiguracion.Image = (Image)resources.GetObject("btnNavConfiguracion.Image");
            btnNavConfiguracion.ImageScaling = ToolStripItemImageScaling.None;
            btnNavConfiguracion.ImageTransparentColor = Color.Magenta;
            btnNavConfiguracion.Name = "btnNavConfiguracion";
            btnNavConfiguracion.Size = new Size(210, 50);
            btnNavConfiguracion.Text = "Configuración";
            btnNavConfiguracion.TextAlign = ContentAlignment.MiddleRight;
            btnNavConfiguracion.ToolTipText = "Configuración";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(163, 6);
            // 
            // btnNavSalir
            // 
            btnNavSalir.AutoSize = false;
            btnNavSalir.Image = (Image)resources.GetObject("btnNavSalir.Image");
            btnNavSalir.ImageScaling = ToolStripItemImageScaling.None;
            btnNavSalir.ImageTransparentColor = Color.Magenta;
            btnNavSalir.Name = "btnNavSalir";
            btnNavSalir.Size = new Size(210, 56);
            btnNavSalir.Text = "Salir";
            btnNavSalir.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnSStrip
            // 
            pnSStrip.Controls.Add(sStrip);
            pnSStrip.Dock = DockStyle.Bottom;
            pnSStrip.Location = new Point(167, 422);
            pnSStrip.Name = "pnSStrip";
            pnSStrip.Size = new Size(633, 28);
            pnSStrip.TabIndex = 2;
            // 
            // sStrip
            // 
            sStrip.Dock = DockStyle.Fill;
            sStrip.Items.AddRange(new ToolStripItem[] { tsLnombreUsuario, tsLusuario, tsLestado, tsLsituacion });
            sStrip.Location = new Point(0, 0);
            sStrip.Name = "sStrip";
            sStrip.Size = new Size(633, 28);
            sStrip.TabIndex = 0;
            sStrip.Text = "statusStrip1";
            // 
            // tsLnombreUsuario
            // 
            tsLnombreUsuario.BackColor = SystemColors.ButtonFace;
            tsLnombreUsuario.Margin = new Padding(0, 3, 10, 2);
            tsLnombreUsuario.Name = "tsLnombreUsuario";
            tsLnombreUsuario.Size = new Size(50, 23);
            tsLnombreUsuario.Text = "Usuario:";
            // 
            // tsLusuario
            // 
            tsLusuario.BackColor = SystemColors.ButtonFace;
            tsLusuario.Name = "tsLusuario";
            tsLusuario.Size = new Size(94, 23);
            tsLusuario.Text = "Nombre Usuario";
            // 
            // tsLestado
            // 
            tsLestado.BackColor = SystemColors.ButtonFace;
            tsLestado.Margin = new Padding(80, 3, 10, 2);
            tsLestado.Name = "tsLestado";
            tsLestado.Size = new Size(45, 23);
            tsLestado.Text = "Estado:";
            // 
            // tsLsituacion
            // 
            tsLsituacion.BackColor = SystemColors.ButtonFace;
            tsLsituacion.Name = "tsLsituacion";
            tsLsituacion.Size = new Size(32, 23);
            tsLsituacion.Text = "Listo";
            // 
            // pnMStrip
            // 
            pnMStrip.Controls.Add(menuPrincipal);
            pnMStrip.Dock = DockStyle.Top;
            pnMStrip.Location = new Point(167, 0);
            pnMStrip.Name = "pnMStrip";
            pnMStrip.Size = new Size(633, 29);
            pnMStrip.TabIndex = 3;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(633, 29);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 25);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // pasesToolStripMenuItem
            // 
            pasesToolStripMenuItem.Name = "pasesToolStripMenuItem";
            pasesToolStripMenuItem.Size = new Size(48, 25);
            pasesToolStripMenuItem.Text = "&Pases";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 25);
            gestiónToolStripMenuItem.Text = "&Gestión";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 25);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // test
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnMid);
            Name = "test";
            Text = "test";
            pnMid.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnSStrip.ResumeLayout(false);
            pnSStrip.PerformLayout();
            sStrip.ResumeLayout(false);
            sStrip.PerformLayout();
            pnMStrip.ResumeLayout(false);
            pnMStrip.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnMid;
        private Panel panelBotones;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNavPases;
        private ToolStripButton btnNavReservas;
        private ToolStripButton btnNavPeliculas;
        private ToolStripButton btnNavSalas;
        private ToolStripButton btnNavUsuarios;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnNavConfiguracion;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnNavSalir;
        private Panel pnSStrip;
        private StatusStrip sStrip;
        private ToolStripStatusLabel tsLnombreUsuario;
        private ToolStripStatusLabel tsLusuario;
        private ToolStripStatusLabel tsLestado;
        private ToolStripStatusLabel tsLsituacion;
        private Panel pnMStrip;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
    }
}