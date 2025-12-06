namespace AplicacionCine.Formularios
{
    partial class FrmBrowReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowReservas));
            pnTotal = new Panel();
            pnInfo = new Panel();
            dvgUsuarios = new DataGridView();
            pnStatus = new Panel();
            ssInfo = new StatusStrip();
            tsLnombreUsuario = new ToolStripStatusLabel();
            tsLusuario = new ToolStripStatusLabel();
            tslEstado = new ToolStripStatusLabel();
            pnTop = new Panel();
            lblFecha = new Label();
            pnTopBar = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            dateTimePicker1 = new DateTimePicker();
            lblPelicula = new Label();
            cbPeliculas = new ComboBox();
            lblEstado = new Label();
            cbEstado = new ComboBox();
            lblUsuario = new Label();
            txtFiltroUsuario = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            pnBotones = new Panel();
            btnMapa = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tsLsituacion = new ToolStripStatusLabel();
            btnCerrar = new Button();
            pnTotal.SuspendLayout();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgUsuarios).BeginInit();
            pnStatus.SuspendLayout();
            ssInfo.SuspendLayout();
            pnTop.SuspendLayout();
            pnTopBar.SuspendLayout();
            menuPrincipal.SuspendLayout();
            pnBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnBotones);
            pnTotal.Controls.Add(pnInfo);
            pnTotal.Controls.Add(pnStatus);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Controls.Add(pnTopBar);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(970, 554);
            pnTotal.TabIndex = 0;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(dvgUsuarios);
            pnInfo.Dock = DockStyle.Fill;
            pnInfo.Location = new Point(0, 65);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(970, 459);
            pnInfo.TabIndex = 3;
            // 
            // dvgUsuarios
            // 
            dvgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgUsuarios.Dock = DockStyle.Fill;
            dvgUsuarios.Location = new Point(0, 0);
            dvgUsuarios.Name = "dvgUsuarios";
            dvgUsuarios.Size = new Size(970, 459);
            dvgUsuarios.TabIndex = 2;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(ssInfo);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 524);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(970, 30);
            pnStatus.TabIndex = 2;
            // 
            // ssInfo
            // 
            ssInfo.Dock = DockStyle.Fill;
            ssInfo.Items.AddRange(new ToolStripItem[] { tsLnombreUsuario, tsLusuario, tslEstado, tsLsituacion });
            ssInfo.Location = new Point(0, 0);
            ssInfo.Name = "ssInfo";
            ssInfo.Size = new Size(970, 30);
            ssInfo.TabIndex = 3;
            ssInfo.Text = "statusStrip1";
            // 
            // tsLnombreUsuario
            // 
            tsLnombreUsuario.Margin = new Padding(20, 3, 10, 2);
            tsLnombreUsuario.Name = "tsLnombreUsuario";
            tsLnombreUsuario.Size = new Size(94, 25);
            tsLnombreUsuario.Text = "Nombre Usuario";
            // 
            // tsLusuario
            // 
            tsLusuario.Margin = new Padding(0, 3, 10, 2);
            tsLusuario.Name = "tsLusuario";
            tsLusuario.Size = new Size(47, 25);
            tsLusuario.Text = "Usuario";
            // 
            // tslEstado
            // 
            tslEstado.Margin = new Padding(0, 3, 10, 2);
            tslEstado.Name = "tslEstado";
            tslEstado.Size = new Size(42, 25);
            tslEstado.Text = "Estado";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(btnLimpiar);
            pnTop.Controls.Add(btnBuscar);
            pnTop.Controls.Add(txtFiltroUsuario);
            pnTop.Controls.Add(lblUsuario);
            pnTop.Controls.Add(cbEstado);
            pnTop.Controls.Add(lblEstado);
            pnTop.Controls.Add(cbPeliculas);
            pnTop.Controls.Add(lblPelicula);
            pnTop.Controls.Add(dateTimePicker1);
            pnTop.Controls.Add(lblFecha);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 31);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(970, 34);
            pnTop.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(22, 9);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // pnTopBar
            // 
            pnTopBar.Controls.Add(menuPrincipal);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new Point(0, 0);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new Size(970, 31);
            pnTopBar.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(970, 31);
            menuPrincipal.TabIndex = 2;
            menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 27);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // pasesToolStripMenuItem
            // 
            pasesToolStripMenuItem.Name = "pasesToolStripMenuItem";
            pasesToolStripMenuItem.Size = new Size(48, 27);
            pasesToolStripMenuItem.Text = "&Pases";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 27);
            gestiónToolStripMenuItem.Text = "&Gestión";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 27);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(69, 6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(89, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(175, 9);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(51, 15);
            lblPelicula.TabIndex = 2;
            lblPelicula.Text = "Pelicula:";
            // 
            // cbPeliculas
            // 
            cbPeliculas.FormattingEnabled = true;
            cbPeliculas.Location = new Point(232, 6);
            cbPeliculas.Name = "cbPeliculas";
            cbPeliculas.Size = new Size(121, 23);
            cbPeliculas.TabIndex = 3;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(371, 9);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(422, 6);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(121, 23);
            cbEstado.TabIndex = 5;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(549, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // txtFiltroUsuario
            // 
            txtFiltroUsuario.Location = new Point(605, 6);
            txtFiltroUsuario.Name = "txtFiltroUsuario";
            txtFiltroUsuario.Size = new Size(128, 23);
            txtFiltroUsuario.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(754, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(854, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCerrar);
            pnBotones.Controls.Add(btnMapa);
            pnBotones.Controls.Add(btnEliminar);
            pnBotones.Controls.Add(btnEditar);
            pnBotones.Controls.Add(btnNuevo);
            pnBotones.Dock = DockStyle.Bottom;
            pnBotones.Location = new Point(0, 487);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(970, 37);
            pnBotones.TabIndex = 4;
            // 
            // btnMapa
            // 
            btnMapa.Location = new Point(628, 7);
            btnMapa.Name = "btnMapa";
            btnMapa.Size = new Size(75, 23);
            btnMapa.TabIndex = 7;
            btnMapa.Text = "Ver Mapa";
            btnMapa.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(510, 7);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(352, 7);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(210, 7);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 4;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // tsLsituacion
            // 
            tsLsituacion.Name = "tsLsituacion";
            tsLsituacion.Size = new Size(56, 25);
            tsLsituacion.Text = "Situación";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(809, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // FrmBrowReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 554);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmBrowReservas";
            Text = "Lista de Reservas";
            pnTotal.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgUsuarios).EndInit();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            ssInfo.ResumeLayout(false);
            ssInfo.PerformLayout();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnTopBar.ResumeLayout(false);
            pnTopBar.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            pnBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnTop;
        private Panel pnTopBar;
        private Panel pnStatus;
        private Panel pnInfo;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private StatusStrip ssInfo;
        private ToolStripStatusLabel tsLnombreUsuario;
        private ToolStripStatusLabel tsLusuario;
        private ToolStripStatusLabel tslEstado;
        private DataGridView dvgUsuarios;
        private Label lblFecha;
        private Button btnLimpiar;
        private Button btnBuscar;
        private TextBox txtFiltroUsuario;
        private Label lblUsuario;
        private ComboBox cbEstado;
        private Label lblEstado;
        private ComboBox cbPeliculas;
        private Label lblPelicula;
        private DateTimePicker dateTimePicker1;
        private Panel pnBotones;
        private Button btnMapa;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private Button btnCerrar;
        private ToolStripStatusLabel tsLsituacion;
    }
}