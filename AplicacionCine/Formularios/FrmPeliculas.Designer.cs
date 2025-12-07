namespace AplicacionCine.Formularios
{
    partial class FrmPeliculas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPeliculas));
            pnTotal = new Panel();
            pnMain = new Panel();
            pnInfo = new Panel();
            tbSinopsis = new TextBox();
            cbGenero = new ComboBox();
            cbCalif = new ComboBox();
            nudDuracion = new NumericUpDown();
            tbTitulo = new TextBox();
            lbIsin = new Label();
            lbIgen = new Label();
            lbIcal = new Label();
            lbIduracion = new Label();
            lbItitulo = new Label();
            pnGrid = new Panel();
            dvgPelis = new DataGridView();
            pnTop = new Panel();
            lbFNombre = new Label();
            cbCalificacion = new ComboBox();
            tbNombre = new TextBox();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            lbFClasificacion = new Label();
            pnBotones = new Panel();
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            pnStatus = new Panel();
            ssInfo = new StatusStrip();
            tslUsuario = new ToolStripStatusLabel();
            tslRol = new ToolStripStatusLabel();
            tslEstado = new ToolStripStatusLabel();
            pnTopBar = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            pnTotal.SuspendLayout();
            pnMain.SuspendLayout();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).BeginInit();
            pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgPelis).BeginInit();
            pnTop.SuspendLayout();
            pnBotones.SuspendLayout();
            pnStatus.SuspendLayout();
            ssInfo.SuspendLayout();
            pnTopBar.SuspendLayout();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnMain);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Controls.Add(pnBotones);
            pnTotal.Controls.Add(pnStatus);
            pnTotal.Controls.Add(pnTopBar);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(1103, 468);
            pnTotal.TabIndex = 2;
            // 
            // pnMain
            // 
            pnMain.Controls.Add(pnInfo);
            pnMain.Controls.Add(pnGrid);
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(0, 64);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1103, 343);
            pnMain.TabIndex = 7;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(tbSinopsis);
            pnInfo.Controls.Add(cbGenero);
            pnInfo.Controls.Add(cbCalif);
            pnInfo.Controls.Add(nudDuracion);
            pnInfo.Controls.Add(tbTitulo);
            pnInfo.Controls.Add(lbIsin);
            pnInfo.Controls.Add(lbIgen);
            pnInfo.Controls.Add(lbIcal);
            pnInfo.Controls.Add(lbIduracion);
            pnInfo.Controls.Add(lbItitulo);
            pnInfo.Dock = DockStyle.Fill;
            pnInfo.Location = new Point(809, 0);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(294, 343);
            pnInfo.TabIndex = 1;
            // 
            // tbSinopsis
            // 
            tbSinopsis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSinopsis.Location = new Point(6, 212);
            tbSinopsis.Multiline = true;
            tbSinopsis.Name = "tbSinopsis";
            tbSinopsis.Size = new Size(280, 107);
            tbSinopsis.TabIndex = 9;
            // 
            // cbGenero
            // 
            cbGenero.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbGenero.FormattingEnabled = true;
            cbGenero.Location = new Point(60, 142);
            cbGenero.Name = "cbGenero";
            cbGenero.Size = new Size(226, 23);
            cbGenero.TabIndex = 8;
            // 
            // cbCalif
            // 
            cbCalif.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbCalif.FormattingEnabled = true;
            cbCalif.Location = new Point(78, 98);
            cbCalif.Name = "cbCalif";
            cbCalif.Size = new Size(213, 23);
            cbCalif.TabIndex = 7;
            // 
            // nudDuracion
            // 
            nudDuracion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudDuracion.Location = new Point(70, 51);
            nudDuracion.Name = "nudDuracion";
            nudDuracion.Size = new Size(221, 23);
            nudDuracion.TabIndex = 6;
            // 
            // tbTitulo
            // 
            tbTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTitulo.Location = new Point(53, 11);
            tbTitulo.Name = "tbTitulo";
            tbTitulo.Size = new Size(238, 23);
            tbTitulo.TabIndex = 5;
            // 
            // lbIsin
            // 
            lbIsin.AutoSize = true;
            lbIsin.Location = new Point(6, 194);
            lbIsin.Name = "lbIsin";
            lbIsin.Size = new Size(56, 15);
            lbIsin.TabIndex = 4;
            lbIsin.Text = "Sinopsis::";
            // 
            // lbIgen
            // 
            lbIgen.AutoSize = true;
            lbIgen.Location = new Point(6, 145);
            lbIgen.Name = "lbIgen";
            lbIgen.Size = new Size(48, 15);
            lbIgen.TabIndex = 3;
            lbIgen.Text = "Género:";
            // 
            // lbIcal
            // 
            lbIcal.AutoSize = true;
            lbIcal.Location = new Point(0, 101);
            lbIcal.Name = "lbIcal";
            lbIcal.Size = new Size(72, 15);
            lbIcal.TabIndex = 2;
            lbIcal.Text = "Calificación:";
            // 
            // lbIduracion
            // 
            lbIduracion.AutoSize = true;
            lbIduracion.Location = new Point(6, 53);
            lbIduracion.Name = "lbIduracion";
            lbIduracion.Size = new Size(58, 15);
            lbIduracion.TabIndex = 1;
            lbIduracion.Text = "Duración:";
            // 
            // lbItitulo
            // 
            lbItitulo.AutoSize = true;
            lbItitulo.Location = new Point(6, 14);
            lbItitulo.Name = "lbItitulo";
            lbItitulo.Size = new Size(41, 15);
            lbItitulo.TabIndex = 0;
            lbItitulo.Text = "Título:";
            // 
            // pnGrid
            // 
            pnGrid.Controls.Add(dvgPelis);
            pnGrid.Dock = DockStyle.Left;
            pnGrid.Location = new Point(0, 0);
            pnGrid.Name = "pnGrid";
            pnGrid.Size = new Size(809, 343);
            pnGrid.TabIndex = 0;
            // 
            // dvgPelis
            // 
            dvgPelis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgPelis.Dock = DockStyle.Fill;
            dvgPelis.Location = new Point(0, 0);
            dvgPelis.Name = "dvgPelis";
            dvgPelis.Size = new Size(809, 343);
            dvgPelis.TabIndex = 0;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(lbFNombre);
            pnTop.Controls.Add(cbCalificacion);
            pnTop.Controls.Add(tbNombre);
            pnTop.Controls.Add(btnLimpiar);
            pnTop.Controls.Add(btnBuscar);
            pnTop.Controls.Add(lbFClasificacion);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 29);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1103, 35);
            pnTop.TabIndex = 6;
            // 
            // lbFNombre
            // 
            lbFNombre.AutoSize = true;
            lbFNombre.Location = new Point(90, 10);
            lbFNombre.Name = "lbFNombre";
            lbFNombre.Size = new Size(54, 15);
            lbFNombre.TabIndex = 6;
            lbFNombre.Text = "Nombre:";
            // 
            // cbCalificacion
            // 
            cbCalificacion.FormattingEnabled = true;
            cbCalificacion.Location = new Point(377, 6);
            cbCalificacion.Name = "cbCalificacion";
            cbCalificacion.Size = new Size(131, 23);
            cbCalificacion.TabIndex = 11;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(150, 6);
            tbNombre.Name = "tbNombre";
            tbNombre.PlaceholderText = "Nombre de la Película";
            tbNombre.Size = new Size(138, 23);
            tbNombre.TabIndex = 10;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(635, 6);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(542, 6);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lbFClasificacion
            // 
            lbFClasificacion.AutoSize = true;
            lbFClasificacion.Location = new Point(294, 10);
            lbFClasificacion.Name = "lbFClasificacion";
            lbFClasificacion.Size = new Size(77, 15);
            lbFClasificacion.TabIndex = 7;
            lbFClasificacion.Text = "Clasificación:";
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCerrar);
            pnBotones.Controls.Add(btnEliminar);
            pnBotones.Controls.Add(btnGuardar);
            pnBotones.Controls.Add(btnNuevo);
            pnBotones.Dock = DockStyle.Bottom;
            pnBotones.Location = new Point(0, 407);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(1103, 31);
            pnBotones.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(565, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(399, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(232, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(90, 3);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(ssInfo);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 438);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(1103, 30);
            pnStatus.TabIndex = 3;
            // 
            // ssInfo
            // 
            ssInfo.Dock = DockStyle.Fill;
            ssInfo.Items.AddRange(new ToolStripItem[] { tslUsuario, tslRol, tslEstado });
            ssInfo.Location = new Point(0, 0);
            ssInfo.Name = "ssInfo";
            ssInfo.Size = new Size(1103, 30);
            ssInfo.TabIndex = 1;
            ssInfo.Text = "statusStrip1";
            // 
            // tslUsuario
            // 
            tslUsuario.Margin = new Padding(20, 3, 10, 2);
            tslUsuario.Name = "tslUsuario";
            tslUsuario.Size = new Size(47, 25);
            tslUsuario.Text = "Usuario";
            // 
            // tslRol
            // 
            tslRol.Margin = new Padding(0, 3, 10, 2);
            tslRol.Name = "tslRol";
            tslRol.Size = new Size(24, 25);
            tslRol.Text = "Rol";
            // 
            // tslEstado
            // 
            tslEstado.Name = "tslEstado";
            tslEstado.Size = new Size(42, 25);
            tslEstado.Text = "Estado";
            // 
            // pnTopBar
            // 
            pnTopBar.Controls.Add(menuPrincipal);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new Point(0, 0);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new Size(1103, 29);
            pnTopBar.TabIndex = 2;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1103, 29);
            menuPrincipal.TabIndex = 1;
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
            // FrmPeliculas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 468);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPeliculas";
            Text = "Peliculas";
            pnTotal.ResumeLayout(false);
            pnMain.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            pnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuracion).EndInit();
            pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgPelis).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnBotones.ResumeLayout(false);
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            ssInfo.ResumeLayout(false);
            ssInfo.PerformLayout();
            pnTopBar.ResumeLayout(false);
            pnTopBar.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnBotones;
        private Panel pnStatus;
        private Panel pnTopBar;
        private Panel pnTop;
        private Label lbFNombre;
        private ComboBox cbCalificacion;
        private TextBox tbNombre;
        private Button btnLimpiar;
        private Button btnBuscar;
        private Label lbFClasificacion;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private StatusStrip ssInfo;
        private ToolStripStatusLabel tslUsuario;
        private ToolStripStatusLabel tslRol;
        private ToolStripStatusLabel tslEstado;
        private Panel pnMain;
        private Panel pnInfo;
        private Label lbIduracion;
        private Label lbItitulo;
        private Panel pnGrid;
        private DataGridView dvgPelis;
        private ComboBox cbCalif;
        private NumericUpDown nudDuracion;
        private TextBox tbTitulo;
        private Label lbIsin;
        private Label lbIgen;
        private Label lbIcal;
        private TextBox tbSinopsis;
        private ComboBox cbGenero;
        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
    }
}