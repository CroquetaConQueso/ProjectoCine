namespace AplicacionCine.Formularios
{
    partial class FrmSalas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalas));
            pnTotal = new Panel();
            pnMain = new Panel();
            pnInfo = new Panel();
            tbDescripcion = new TextBox();
            lbDescripcion = new Label();
            nudColumnas = new NumericUpDown();
            label2 = new Label();
            nudFilas = new NumericUpDown();
            label1 = new Label();
            nudCapacidad = new NumericUpDown();
            tbTitulo = new TextBox();
            lbIcapacidad = new Label();
            lbItitulo = new Label();
            pnGrid = new Panel();
            dvgSalas = new DataGridView();
            pnTop = new Panel();
            lbFNombre = new Label();
            tbNomSal = new TextBox();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            pnBot = new Panel();
            pnBotones = new Panel();
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            pnBotBar = new Panel();
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
            ((System.ComponentModel.ISupportInitialize)nudColumnas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFilas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).BeginInit();
            pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgSalas).BeginInit();
            pnTop.SuspendLayout();
            pnBot.SuspendLayout();
            pnBotones.SuspendLayout();
            pnBotBar.SuspendLayout();
            ssInfo.SuspendLayout();
            pnTopBar.SuspendLayout();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnMain);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Controls.Add(pnBot);
            pnTotal.Controls.Add(pnBotBar);
            pnTotal.Controls.Add(pnTopBar);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(1054, 533);
            pnTotal.TabIndex = 0;
            // 
            // pnMain
            // 
            pnMain.Controls.Add(pnInfo);
            pnMain.Controls.Add(pnGrid);
            pnMain.Dock = DockStyle.Fill;
            pnMain.Location = new Point(0, 66);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1054, 400);
            pnMain.TabIndex = 4;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(tbDescripcion);
            pnInfo.Controls.Add(lbDescripcion);
            pnInfo.Controls.Add(nudColumnas);
            pnInfo.Controls.Add(label2);
            pnInfo.Controls.Add(nudFilas);
            pnInfo.Controls.Add(label1);
            pnInfo.Controls.Add(nudCapacidad);
            pnInfo.Controls.Add(tbTitulo);
            pnInfo.Controls.Add(lbIcapacidad);
            pnInfo.Controls.Add(lbItitulo);
            pnInfo.Dock = DockStyle.Fill;
            pnInfo.Location = new Point(762, 0);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(292, 400);
            pnInfo.TabIndex = 1;
            // 
            // tbDescripcion
            // 
            tbDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDescripcion.Location = new Point(13, 173);
            tbDescripcion.Multiline = true;
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(267, 202);
            tbDescripcion.TabIndex = 16;
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.Location = new Point(5, 155);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(72, 15);
            lbDescripcion.TabIndex = 15;
            lbDescripcion.Text = "Descripción:";
            // 
            // nudColumnas
            // 
            nudColumnas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudColumnas.Location = new Point(83, 115);
            nudColumnas.Name = "nudColumnas";
            nudColumnas.Size = new Size(197, 23);
            nudColumnas.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 117);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 13;
            label2.Text = "Columnas:";
            // 
            // nudFilas
            // 
            nudFilas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudFilas.Location = new Point(83, 81);
            nudFilas.Name = "nudFilas";
            nudFilas.Size = new Size(197, 23);
            nudFilas.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 83);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 11;
            label1.Text = "Filas:";
            // 
            // nudCapacidad
            // 
            nudCapacidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudCapacidad.Location = new Point(83, 46);
            nudCapacidad.Name = "nudCapacidad";
            nudCapacidad.Size = new Size(197, 23);
            nudCapacidad.TabIndex = 10;
            // 
            // tbTitulo
            // 
            tbTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTitulo.Location = new Point(66, 12);
            tbTitulo.Name = "tbTitulo";
            tbTitulo.Size = new Size(214, 23);
            tbTitulo.TabIndex = 9;
            // 
            // lbIcapacidad
            // 
            lbIcapacidad.AutoSize = true;
            lbIcapacidad.Location = new Point(11, 48);
            lbIcapacidad.Name = "lbIcapacidad";
            lbIcapacidad.Size = new Size(66, 15);
            lbIcapacidad.TabIndex = 8;
            lbIcapacidad.Text = "Capacidad:";
            // 
            // lbItitulo
            // 
            lbItitulo.AutoSize = true;
            lbItitulo.Location = new Point(19, 15);
            lbItitulo.Name = "lbItitulo";
            lbItitulo.Size = new Size(41, 15);
            lbItitulo.TabIndex = 7;
            lbItitulo.Text = "Título:";
            // 
            // pnGrid
            // 
            pnGrid.Controls.Add(dvgSalas);
            pnGrid.Dock = DockStyle.Left;
            pnGrid.Location = new Point(0, 0);
            pnGrid.Name = "pnGrid";
            pnGrid.Size = new Size(762, 400);
            pnGrid.TabIndex = 0;
            // 
            // dvgSalas
            // 
            dvgSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgSalas.Dock = DockStyle.Fill;
            dvgSalas.Location = new Point(0, 0);
            dvgSalas.Name = "dvgSalas";
            dvgSalas.Size = new Size(762, 400);
            dvgSalas.TabIndex = 1;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(lbFNombre);
            pnTop.Controls.Add(tbNomSal);
            pnTop.Controls.Add(btnLimpiar);
            pnTop.Controls.Add(btnBuscar);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 32);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1054, 34);
            pnTop.TabIndex = 3;
            // 
            // lbFNombre
            // 
            lbFNombre.AutoSize = true;
            lbFNombre.Location = new Point(172, 9);
            lbFNombre.Name = "lbFNombre";
            lbFNombre.Size = new Size(54, 15);
            lbFNombre.TabIndex = 12;
            lbFNombre.Text = "Nombre:";
            // 
            // tbNomSal
            // 
            tbNomSal.Location = new Point(232, 5);
            tbNomSal.Name = "tbNomSal";
            tbNomSal.PlaceholderText = "Nombre de la Película";
            tbNomSal.Size = new Size(138, 23);
            tbNomSal.TabIndex = 16;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(499, 5);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(406, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // pnBot
            // 
            pnBot.Controls.Add(pnBotones);
            pnBot.Dock = DockStyle.Bottom;
            pnBot.Location = new Point(0, 466);
            pnBot.Name = "pnBot";
            pnBot.Size = new Size(1054, 34);
            pnBot.TabIndex = 2;
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCerrar);
            pnBotones.Controls.Add(btnEliminar);
            pnBotones.Controls.Add(btnGuardar);
            pnBotones.Controls.Add(btnNuevo);
            pnBotones.Dock = DockStyle.Bottom;
            pnBotones.Location = new Point(0, 3);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(1054, 31);
            pnBotones.TabIndex = 5;
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
            // pnBotBar
            // 
            pnBotBar.Controls.Add(ssInfo);
            pnBotBar.Dock = DockStyle.Bottom;
            pnBotBar.Location = new Point(0, 500);
            pnBotBar.Name = "pnBotBar";
            pnBotBar.Size = new Size(1054, 33);
            pnBotBar.TabIndex = 1;
            // 
            // ssInfo
            // 
            ssInfo.Dock = DockStyle.Fill;
            ssInfo.Items.AddRange(new ToolStripItem[] { tslUsuario, tslRol, tslEstado });
            ssInfo.Location = new Point(0, 0);
            ssInfo.Name = "ssInfo";
            ssInfo.Size = new Size(1054, 33);
            ssInfo.TabIndex = 2;
            ssInfo.Text = "statusStrip1";
            // 
            // tslUsuario
            // 
            tslUsuario.Margin = new Padding(20, 3, 10, 2);
            tslUsuario.Name = "tslUsuario";
            tslUsuario.Size = new Size(47, 28);
            tslUsuario.Text = "Usuario";
            // 
            // tslRol
            // 
            tslRol.Margin = new Padding(0, 3, 10, 2);
            tslRol.Name = "tslRol";
            tslRol.Size = new Size(24, 28);
            tslRol.Text = "Rol";
            // 
            // tslEstado
            // 
            tslEstado.Name = "tslEstado";
            tslEstado.Size = new Size(42, 28);
            tslEstado.Text = "Estado";
            // 
            // pnTopBar
            // 
            pnTopBar.Controls.Add(menuPrincipal);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new Point(0, 0);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new Size(1054, 32);
            pnTopBar.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.Dock = DockStyle.Fill;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, pasesToolStripMenuItem, gestiónToolStripMenuItem, ayudaToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1054, 32);
            menuPrincipal.TabIndex = 2;
            menuPrincipal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 28);
            archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // pasesToolStripMenuItem
            // 
            pasesToolStripMenuItem.Name = "pasesToolStripMenuItem";
            pasesToolStripMenuItem.Size = new Size(48, 28);
            pasesToolStripMenuItem.Text = "&Pases";
            // 
            // gestiónToolStripMenuItem
            // 
            gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
            gestiónToolStripMenuItem.Size = new Size(59, 28);
            gestiónToolStripMenuItem.Text = "&Gestión";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 28);
            ayudaToolStripMenuItem.Text = "A&yuda";
            // 
            // FrmSalas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 533);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmSalas";
            Text = "Gestión de Salas";
            pnTotal.ResumeLayout(false);
            pnMain.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            pnInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudColumnas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFilas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacidad).EndInit();
            pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgSalas).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            pnBot.ResumeLayout(false);
            pnBotones.ResumeLayout(false);
            pnBotBar.ResumeLayout(false);
            pnBotBar.PerformLayout();
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
        private Panel pnTopBar;
        private Panel pnMain;
        private Panel pnInfo;
        private Panel pnGrid;
        private Panel pnTop;
        private Panel pnBot;
        private Panel pnBotBar;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem pasesToolStripMenuItem;
        private ToolStripMenuItem gestiónToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private StatusStrip ssInfo;
        private ToolStripStatusLabel tslUsuario;
        private ToolStripStatusLabel tslRol;
        private ToolStripStatusLabel tslEstado;
        private Panel pnBotones;
        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private DataGridView dvgSalas;
        private Label lbDescripcion;
        private NumericUpDown nudColumnas;
        private Label label2;
        private NumericUpDown nudFilas;
        private Label label1;
        private NumericUpDown nudCapacidad;
        private TextBox tbTitulo;
        private Label lbIcapacidad;
        private Label lbItitulo;
        private TextBox tbDescripcion;
        private Label lbFNombre;
        private TextBox tbNomSal;
        private Button btnLimpiar;
        private Button btnBuscar;
    }
}