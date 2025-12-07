namespace AplicacionCine.Formularios
{
    partial class FrmPasesHoy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPasesHoy));
            pnTotal = new Panel();
            pnGrid = new Panel();
            dgvPases = new DataGridView();
            pnOpciones = new Panel();
            btnCerrar = new Button();
            btnVerButacas = new Button();
            pnEstado = new Panel();
            ssEstado = new StatusStrip();
            tsslUsuario = new ToolStripStatusLabel();
            tsslRol = new ToolStripStatusLabel();
            tsslEstado = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            pnFiltro = new Panel();
            btnHoy = new Button();
            btnBuscar = new Button();
            cbPeliculas = new ComboBox();
            lbPelicula = new Label();
            dtpFecha = new DateTimePicker();
            lbFecha = new Label();
            panel1 = new Panel();
            menuPrincipal = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            pasesToolStripMenuItem = new ToolStripMenuItem();
            gestiónToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            pnTotal.SuspendLayout();
            pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPases).BeginInit();
            pnOpciones.SuspendLayout();
            pnEstado.SuspendLayout();
            ssEstado.SuspendLayout();
            pnFiltro.SuspendLayout();
            panel1.SuspendLayout();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnGrid);
            pnTotal.Controls.Add(pnOpciones);
            pnTotal.Controls.Add(pnEstado);
            pnTotal.Controls.Add(pnFiltro);
            pnTotal.Controls.Add(panel1);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(953, 450);
            pnTotal.TabIndex = 0;
            // 
            // pnGrid
            // 
            pnGrid.Controls.Add(dgvPases);
            pnGrid.Dock = DockStyle.Fill;
            pnGrid.Location = new Point(0, 84);
            pnGrid.Name = "pnGrid";
            pnGrid.Size = new Size(953, 303);
            pnGrid.TabIndex = 4;
            // 
            // dgvPases
            // 
            dgvPases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPases.Dock = DockStyle.Fill;
            dgvPases.Location = new Point(0, 0);
            dgvPases.Name = "dgvPases";
            dgvPases.Size = new Size(953, 303);
            dgvPases.TabIndex = 0;
            // 
            // pnOpciones
            // 
            pnOpciones.BackColor = SystemColors.ActiveCaption;
            pnOpciones.Controls.Add(btnCerrar);
            pnOpciones.Controls.Add(btnVerButacas);
            pnOpciones.Dock = DockStyle.Bottom;
            pnOpciones.Location = new Point(0, 387);
            pnOpciones.Name = "pnOpciones";
            pnOpciones.Size = new Size(953, 31);
            pnOpciones.TabIndex = 3;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(450, 5);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 1;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnVerButacas
            // 
            btnVerButacas.Location = new Point(233, 5);
            btnVerButacas.Name = "btnVerButacas";
            btnVerButacas.Size = new Size(125, 23);
            btnVerButacas.TabIndex = 0;
            btnVerButacas.Text = "Ver Mapa Butacas";
            btnVerButacas.UseVisualStyleBackColor = true;
            // 
            // pnEstado
            // 
            pnEstado.Controls.Add(ssEstado);
            pnEstado.Dock = DockStyle.Bottom;
            pnEstado.Location = new Point(0, 418);
            pnEstado.Name = "pnEstado";
            pnEstado.Size = new Size(953, 32);
            pnEstado.TabIndex = 2;
            // 
            // ssEstado
            // 
            ssEstado.Dock = DockStyle.Fill;
            ssEstado.Items.AddRange(new ToolStripItem[] { tsslUsuario, tsslRol, tsslEstado, toolStripProgressBar1 });
            ssEstado.Location = new Point(0, 0);
            ssEstado.Name = "ssEstado";
            ssEstado.Size = new Size(953, 32);
            ssEstado.TabIndex = 0;
            ssEstado.Text = "statusStrip1";
            // 
            // tsslUsuario
            // 
            tsslUsuario.Margin = new Padding(0, 3, 40, 2);
            tsslUsuario.Name = "tsslUsuario";
            tsslUsuario.Size = new Size(47, 27);
            tsslUsuario.Text = "Usuario";
            // 
            // tsslRol
            // 
            tsslRol.Margin = new Padding(0, 0, 40, 2);
            tsslRol.Name = "tsslRol";
            tsslRol.Size = new Size(24, 30);
            tsslRol.Text = "Rol";
            // 
            // tsslEstado
            // 
            tsslEstado.Margin = new Padding(0, 3, 40, 2);
            tsslEstado.Name = "tsslEstado";
            tsslEstado.Size = new Size(42, 27);
            tsslEstado.Text = "Estado";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 26);
            // 
            // pnFiltro
            // 
            pnFiltro.Controls.Add(btnHoy);
            pnFiltro.Controls.Add(btnBuscar);
            pnFiltro.Controls.Add(cbPeliculas);
            pnFiltro.Controls.Add(lbPelicula);
            pnFiltro.Controls.Add(dtpFecha);
            pnFiltro.Controls.Add(lbFecha);
            pnFiltro.Dock = DockStyle.Top;
            pnFiltro.Location = new Point(0, 29);
            pnFiltro.Name = "pnFiltro";
            pnFiltro.Size = new Size(953, 55);
            pnFiltro.TabIndex = 1;
            // 
            // btnHoy
            // 
            btnHoy.Location = new Point(713, 16);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(75, 23);
            btnHoy.TabIndex = 5;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(450, 16);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cbPeliculas
            // 
            cbPeliculas.FormattingEnabled = true;
            cbPeliculas.Location = new Point(290, 16);
            cbPeliculas.Name = "cbPeliculas";
            cbPeliculas.Size = new Size(154, 23);
            cbPeliculas.TabIndex = 3;
            // 
            // lbPelicula
            // 
            lbPelicula.AutoSize = true;
            lbPelicula.Location = new Point(233, 20);
            lbPelicula.Name = "lbPelicula";
            lbPelicula.Size = new Size(51, 15);
            lbPelicula.TabIndex = 2;
            lbPelicula.Text = "Película:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(76, 16);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(84, 23);
            dtpFecha.TabIndex = 1;
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Location = new Point(29, 20);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(41, 15);
            lbFecha.TabIndex = 0;
            lbFecha.Text = "Fecha:";
            // 
            // panel1
            // 
            panel1.Controls.Add(menuPrincipal);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 29);
            panel1.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(953, 29);
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
            // FrmPasesHoy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPasesHoy";
            Text = "Pases de Hoy";
            pnTotal.ResumeLayout(false);
            pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPases).EndInit();
            pnOpciones.ResumeLayout(false);
            pnEstado.ResumeLayout(false);
            pnEstado.PerformLayout();
            ssEstado.ResumeLayout(false);
            ssEstado.PerformLayout();
            pnFiltro.ResumeLayout(false);
            pnFiltro.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel panel1;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private Panel pnFiltro;
        private Label lbPelicula;
        private DateTimePicker dtpFecha;
        private Label lbFecha;
        private Button btnHoy;
        private Button btnBuscar;
        private ComboBox cbPeliculas;
        private Panel pnGrid;
        private Panel pnOpciones;
        private Panel pnEstado;
        private DataGridView dgvPases;
        private Button btnCerrar;
        private Button btnVerButacas;
        private StatusStrip ssEstado;
        private ToolStripStatusLabel tsslUsuario;
        private ToolStripStatusLabel tsslRol;
        private ToolStripStatusLabel tsslEstado;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}