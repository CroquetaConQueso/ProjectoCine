namespace AplicacionCine.Formularios
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            pnMStrip = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            configuracionDeConexionToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            pasesDeHoyToolStripMenuItem = new ToolStripMenuItem();
            reservasToolStripMenuItem = new ToolStripMenuItem();
            peliculasToolStripMenuItem = new ToolStripMenuItem();
            salasToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            cascadaToolStripMenuItem = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem = new ToolStripMenuItem();
            cerrarTodasToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
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
            tsLsituacion = new ToolStripStatusLabel();
            tsLestado = new ToolStripStatusLabel();
            pnMStrip.SuspendLayout();
            menuPrincipal.SuspendLayout();
            panelBotones.SuspendLayout();
            toolStrip1.SuspendLayout();
            pnSStrip.SuspendLayout();
            sStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnMStrip
            // 
            pnMStrip.Controls.Add(menuPrincipal);
            pnMStrip.Dock = DockStyle.Top;
            pnMStrip.Location = new Point(0, 0);
            pnMStrip.Name = "pnMStrip";
            pnMStrip.Size = new Size(1268, 29);
            pnMStrip.TabIndex = 2;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1268, 29);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configuracionDeConexionToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 25);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // configuracionDeConexionToolStripMenuItem
            // 
            configuracionDeConexionToolStripMenuItem.Name = "configuracionDeConexionToolStripMenuItem";
            configuracionDeConexionToolStripMenuItem.Size = new Size(219, 22);
            configuracionDeConexionToolStripMenuItem.Text = "&Configuración de Conexión";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(219, 22);
            salirToolStripMenuItem.Text = "&Salir";
            // 
            // pasesToolStripMenuItem
            // 
            pasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pasesDeHoyToolStripMenuItem, reservasToolStripMenuItem, peliculasToolStripMenuItem, salasToolStripMenuItem, usuariosToolStripMenuItem });
            pasesToolStripMenuItem.Name = "pasesToolStripMenuItem";
            pasesToolStripMenuItem.Size = new Size(59, 25);
            pasesToolStripMenuItem.Text = "&Gestión";
            pasesToolStripMenuItem.Click += pasesToolStripMenuItem_Click;
            // 
            // pasesDeHoyToolStripMenuItem
            // 
            pasesDeHoyToolStripMenuItem.Name = "pasesDeHoyToolStripMenuItem";
            pasesDeHoyToolStripMenuItem.Size = new Size(144, 22);
            pasesDeHoyToolStripMenuItem.Text = "Pases de &Hoy";
            // 
            // reservasToolStripMenuItem
            // 
            reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            reservasToolStripMenuItem.Size = new Size(144, 22);
            reservasToolStripMenuItem.Text = "&Reservas";
            // 
            // peliculasToolStripMenuItem
            // 
            peliculasToolStripMenuItem.Name = "peliculasToolStripMenuItem";
            peliculasToolStripMenuItem.Size = new Size(144, 22);
            peliculasToolStripMenuItem.Text = "P&eliculas";
            // 
            // salasToolStripMenuItem
            // 
            salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            salasToolStripMenuItem.Size = new Size(144, 22);
            salasToolStripMenuItem.Text = "&Salas";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(144, 22);
            usuariosToolStripMenuItem.Text = "&Usuarios";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadaToolStripMenuItem, mosaicoHorizontalToolStripMenuItem, mosaicoVerticalToolStripMenuItem, cerrarTodasToolStripMenuItem });
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(61, 25);
            gestiónToolStripMenuItem.Text = "&Ventana";
            // 
            // cascadaToolStripMenuItem
            // 
            cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            cascadaToolStripMenuItem.Size = new Size(175, 22);
            cascadaToolStripMenuItem.Text = "&Cascada";
            // 
            // mosaicoHorizontalToolStripMenuItem
            // 
            mosaicoHorizontalToolStripMenuItem.Name = "mosaicoHorizontalToolStripMenuItem";
            mosaicoHorizontalToolStripMenuItem.Size = new Size(175, 22);
            mosaicoHorizontalToolStripMenuItem.Text = "&Mosaico horizontal";
            // 
            // mosaicoVerticalToolStripMenuItem
            // 
            mosaicoVerticalToolStripMenuItem.Name = "mosaicoVerticalToolStripMenuItem";
            mosaicoVerticalToolStripMenuItem.Size = new Size(175, 22);
            mosaicoVerticalToolStripMenuItem.Text = "M&osaico vertical";
            // 
            // cerrarTodasToolStripMenuItem
            // 
            cerrarTodasToolStripMenuItem.Name = "cerrarTodasToolStripMenuItem";
            cerrarTodasToolStripMenuItem.Size = new Size(175, 22);
            cerrarTodasToolStripMenuItem.Text = "Cerrar &Todas";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 25);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(135, 22);
            acercaDeToolStripMenuItem.Text = "A&cerca de...";
            // 
            // panelBotones
            // 
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(toolStrip1);
            panelBotones.Dock = DockStyle.Left;
            panelBotones.Location = new Point(0, 29);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(167, 677);
            panelBotones.TabIndex = 3;
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
            toolStrip1.Size = new Size(165, 675);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNavPases
            // 
            btnNavPases.AutoSize = false;
            btnNavPases.Image = Properties.Resources.icons8_entradas_48;
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
            pnSStrip.Location = new Point(167, 678);
            pnSStrip.Name = "pnSStrip";
            pnSStrip.Size = new Size(1101, 28);
            pnSStrip.TabIndex = 4;
            // 
            // sStrip
            // 
            sStrip.Dock = DockStyle.Fill;
            sStrip.Items.AddRange(new ToolStripItem[] { tsLnombreUsuario, tsLusuario, tsLsituacion, tsLestado });
            sStrip.Location = new Point(0, 0);
            sStrip.Name = "sStrip";
            sStrip.Size = new Size(1101, 28);
            sStrip.TabIndex = 0;
            sStrip.Text = "statusStrip1";
            // 
            // tsLnombreUsuario
            // 
            tsLnombreUsuario.BackColor = SystemColors.Control;
            tsLnombreUsuario.BorderStyle = Border3DStyle.SunkenOuter;
            tsLnombreUsuario.Margin = new Padding(0, 3, 10, 2);
            tsLnombreUsuario.Name = "tsLnombreUsuario";
            tsLnombreUsuario.Size = new Size(50, 23);
            tsLnombreUsuario.Text = "Usuario:";
            // 
            // tsLusuario
            // 
            tsLusuario.BackColor = SystemColors.Control;
            tsLusuario.BorderStyle = Border3DStyle.SunkenOuter;
            tsLusuario.Name = "tsLusuario";
            tsLusuario.Size = new Size(94, 23);
            tsLusuario.Text = "Nombre Usuario";
            // 
            // tsLsituacion
            // 
            tsLsituacion.BackColor = SystemColors.Control;
            tsLsituacion.BorderStyle = Border3DStyle.SunkenOuter;
            tsLsituacion.Margin = new Padding(85, 3, 0, 2);
            tsLsituacion.Name = "tsLsituacion";
            tsLsituacion.Size = new Size(27, 23);
            tsLsituacion.Text = "Rol:";
            // 
            // tsLestado
            // 
            tsLestado.BackColor = SystemColors.Control;
            tsLestado.BorderStyle = Border3DStyle.SunkenOuter;
            tsLestado.Margin = new Padding(0, 3, 10, 2);
            tsLestado.Name = "tsLestado";
            tsLestado.Size = new Size(32, 23);
            tsLestado.Text = "Listo";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1268, 706);
            Controls.Add(pnSStrip);
            Controls.Add(panelBotones);
            Controls.Add(pnMStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "FrmPrincipal";
            Text = "Principal";
            pnMStrip.ResumeLayout(false);
            pnMStrip.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnSStrip.ResumeLayout(false);
            pnSStrip.PerformLayout();
            sStrip.ResumeLayout(false);
            sStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnMStrip;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
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
        private ToolStripMenuItem configuracionDeConexionToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem pasesDeHoyToolStripMenuItem;
        private ToolStripMenuItem reservasToolStripMenuItem;
        private ToolStripMenuItem peliculasToolStripMenuItem;
        private ToolStripMenuItem salasToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem cascadaToolStripMenuItem;
        private ToolStripMenuItem mosaicoHorizontalToolStripMenuItem;
        private ToolStripMenuItem mosaicoVerticalToolStripMenuItem;
        private ToolStripMenuItem cerrarTodasToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}