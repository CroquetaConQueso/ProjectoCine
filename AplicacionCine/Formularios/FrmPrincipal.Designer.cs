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
            pnTotal = new Panel();
            pnMid = new Panel();
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
            panelBotones = new Panel();
            panelInfo = new Panel();
            toolStrip1 = new ToolStrip();
            btnNavSalir = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnNavConfiguracion = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnNavUsuarios = new ToolStripButton();
            btnNavSalas = new ToolStripButton();
            btnNavPeliculas = new ToolStripButton();
            btnNavReservas = new ToolStripButton();
            btnNavPases = new ToolStripButton();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnTotal.SuspendLayout();
            pnMid.SuspendLayout();
            pnSStrip.SuspendLayout();
            sStrip.SuspendLayout();
            pnMStrip.SuspendLayout();
            menuPrincipal.SuspendLayout();
            panelBotones.SuspendLayout();
            panelInfo.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnMid);
            pnTotal.Controls.Add(pnSStrip);
            pnTotal.Controls.Add(pnMStrip);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(635, 450);
            pnTotal.TabIndex = 0;
            // 
            // pnMid
            // 
            pnMid.Controls.Add(panelInfo);
            pnMid.Controls.Add(panelBotones);
            pnMid.Dock = DockStyle.Fill;
            pnMid.Location = new Point(0, 29);
            pnMid.Name = "pnMid";
            pnMid.Size = new Size(635, 393);
            pnMid.TabIndex = 2;
            // 
            // pnSStrip
            // 
            pnSStrip.Controls.Add(sStrip);
            pnSStrip.Dock = DockStyle.Bottom;
            pnSStrip.Location = new Point(0, 422);
            pnSStrip.Name = "pnSStrip";
            pnSStrip.Size = new Size(635, 28);
            pnSStrip.TabIndex = 1;
            // 
            // sStrip
            // 
            sStrip.Dock = DockStyle.Fill;
            sStrip.Items.AddRange(new ToolStripItem[] { tsLnombreUsuario, tsLusuario, tsLestado, tsLsituacion });
            sStrip.Location = new Point(0, 0);
            sStrip.Name = "sStrip";
            sStrip.Size = new Size(635, 28);
            sStrip.TabIndex = 0;
            sStrip.Text = "statusStrip1";
            // 
            // tsLnombreUsuario
            // 
            tsLnombreUsuario.Margin = new Padding(0, 3, 10, 2);
            tsLnombreUsuario.Name = "tsLnombreUsuario";
            tsLnombreUsuario.Size = new Size(50, 23);
            tsLnombreUsuario.Text = "Usuario:";
            // 
            // tsLusuario
            // 
            tsLusuario.Name = "tsLusuario";
            tsLusuario.Size = new Size(94, 23);
            tsLusuario.Text = "Nombre Usuario";
            // 
            // tsLestado
            // 
            tsLestado.Margin = new Padding(80, 3, 10, 2);
            tsLestado.Name = "tsLestado";
            tsLestado.Size = new Size(45, 23);
            tsLestado.Text = "Estado:";
            // 
            // tsLsituacion
            // 
            tsLsituacion.Name = "tsLsituacion";
            tsLsituacion.Size = new Size(32, 23);
            tsLsituacion.Text = "Listo";
            // 
            // pnMStrip
            // 
            pnMStrip.Controls.Add(menuPrincipal);
            pnMStrip.Dock = DockStyle.Top;
            pnMStrip.Location = new Point(0, 0);
            pnMStrip.Name = "pnMStrip";
            pnMStrip.Size = new Size(635, 29);
            pnMStrip.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(635, 29);
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
            // panelBotones
            // 
            panelBotones.BorderStyle = BorderStyle.FixedSingle;
            panelBotones.Controls.Add(toolStrip1);
            panelBotones.Dock = DockStyle.Left;
            panelBotones.Location = new Point(0, 0);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(212, 393);
            panelBotones.TabIndex = 0;
            // 
            // panelInfo
            // 
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(tableLayoutPanel1);
            panelInfo.Controls.Add(groupBox1);
            panelInfo.Dock = DockStyle.Fill;
            panelInfo.Location = new Point(212, 0);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(423, 393);
            panelInfo.TabIndex = 1;
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
            toolStrip1.Size = new Size(210, 391);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNavSalir
            // 
            btnNavSalir.AutoSize = false;
            btnNavSalir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavSalir.Image = (Image)resources.GetObject("btnNavSalir.Image");
            btnNavSalir.ImageTransparentColor = Color.Magenta;
            btnNavSalir.Name = "btnNavSalir";
            btnNavSalir.Size = new Size(210, 56);
            btnNavSalir.Text = "Salir";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(208, 6);
            // 
            // btnNavConfiguracion
            // 
            btnNavConfiguracion.AutoSize = false;
            btnNavConfiguracion.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavConfiguracion.Image = (Image)resources.GetObject("btnNavConfiguracion.Image");
            btnNavConfiguracion.ImageTransparentColor = Color.Magenta;
            btnNavConfiguracion.Name = "btnNavConfiguracion";
            btnNavConfiguracion.Size = new Size(210, 50);
            btnNavConfiguracion.Text = "Configuración";
            btnNavConfiguracion.ToolTipText = "Configuración";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(208, 6);
            // 
            // btnNavUsuarios
            // 
            btnNavUsuarios.AutoSize = false;
            btnNavUsuarios.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavUsuarios.Image = (Image)resources.GetObject("btnNavUsuarios.Image");
            btnNavUsuarios.ImageTransparentColor = Color.Magenta;
            btnNavUsuarios.Name = "btnNavUsuarios";
            btnNavUsuarios.Size = new Size(210, 50);
            btnNavUsuarios.Text = "Usuarios";
            // 
            // btnNavSalas
            // 
            btnNavSalas.AutoSize = false;
            btnNavSalas.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavSalas.Image = (Image)resources.GetObject("btnNavSalas.Image");
            btnNavSalas.ImageTransparentColor = Color.Magenta;
            btnNavSalas.Name = "btnNavSalas";
            btnNavSalas.Size = new Size(210, 50);
            btnNavSalas.Text = "Salas";
            // 
            // btnNavPeliculas
            // 
            btnNavPeliculas.AutoSize = false;
            btnNavPeliculas.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavPeliculas.Image = (Image)resources.GetObject("btnNavPeliculas.Image");
            btnNavPeliculas.ImageTransparentColor = Color.Magenta;
            btnNavPeliculas.Name = "btnNavPeliculas";
            btnNavPeliculas.Size = new Size(210, 50);
            btnNavPeliculas.Text = "Películas";
            // 
            // btnNavReservas
            // 
            btnNavReservas.AutoSize = false;
            btnNavReservas.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavReservas.Image = (Image)resources.GetObject("btnNavReservas.Image");
            btnNavReservas.ImageTransparentColor = Color.Magenta;
            btnNavReservas.Name = "btnNavReservas";
            btnNavReservas.Size = new Size(210, 50);
            btnNavReservas.Text = "Reservas";
            // 
            // btnNavPases
            // 
            btnNavPases.AutoSize = false;
            btnNavPases.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNavPases.Image = (Image)resources.GetObject("btnNavPases.Image");
            btnNavPases.ImageTransparentColor = Color.Magenta;
            btnNavPases.Name = "btnNavPases";
            btnNavPases.Size = new Size(210, 50);
            btnNavPases.Text = "Pases de hoy";
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(421, 149);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pases de hoy:";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F));
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 291);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(421, 100);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 450);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuPrincipal;
            Name = "FrmPrincipal";
            Text = "Principal";
            pnTotal.ResumeLayout(false);
            pnMid.ResumeLayout(false);
            pnSStrip.ResumeLayout(false);
            pnSStrip.PerformLayout();
            sStrip.ResumeLayout(false);
            sStrip.PerformLayout();
            pnMStrip.ResumeLayout(false);
            pnMStrip.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            panelInfo.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnMid;
        private Panel pnSStrip;
        private StatusStrip sStrip;
        private Panel pnMStrip;
        private ToolStripStatusLabel tsLnombreUsuario;
        private ToolStripStatusLabel tsLusuario;
        private ToolStripStatusLabel tsLestado;
        private ToolStripStatusLabel tsLsituacion;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private Panel panelInfo;
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
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
    }
}