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
            pnBotones = new Panel();
            btnCerrar = new Button();
            btnMapa = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            pnInfo = new Panel();
            dvgUsuarios = new DataGridView();
            pnTop = new Panel();
            cbUsar = new CheckBox();
            btnHoy = new Button();
            btnLimpiar = new Button();
            btnBuscar = new Button();
            txtFiltroUsuario = new TextBox();
            lblUsuario = new Label();
            cbEstado = new ComboBox();
            lblEstado = new Label();
            cbPeliculas = new ComboBox();
            lblPelicula = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblFecha = new Label();
            pnTotal.SuspendLayout();
            pnBotones.SuspendLayout();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgUsuarios).BeginInit();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnBotones);
            pnTotal.Controls.Add(pnInfo);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(669, 554);
            pnTotal.TabIndex = 0;
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCerrar);
            pnBotones.Controls.Add(btnMapa);
            pnBotones.Controls.Add(btnEliminar);
            pnBotones.Controls.Add(btnEditar);
            pnBotones.Dock = DockStyle.Bottom;
            pnBotones.Location = new Point(0, 517);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(669, 37);
            pnBotones.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(468, 7);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnMapa
            // 
            btnMapa.Location = new Point(341, 7);
            btnMapa.Name = "btnMapa";
            btnMapa.Size = new Size(75, 23);
            btnMapa.TabIndex = 7;
            btnMapa.Text = "Ver Mapa";
            btnMapa.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(232, 7);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(120, 7);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(dvgUsuarios);
            pnInfo.Dock = DockStyle.Fill;
            pnInfo.Location = new Point(0, 69);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(669, 485);
            pnInfo.TabIndex = 3;
            // 
            // dvgUsuarios
            // 
            dvgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgUsuarios.Dock = DockStyle.Fill;
            dvgUsuarios.Location = new Point(0, 0);
            dvgUsuarios.Name = "dvgUsuarios";
            dvgUsuarios.Size = new Size(669, 485);
            dvgUsuarios.TabIndex = 2;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(cbUsar);
            pnTop.Controls.Add(btnHoy);
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
            pnTop.Location = new Point(0, 0);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(669, 69);
            pnTop.TabIndex = 1;
            // 
            // cbUsar
            // 
            cbUsar.AutoSize = true;
            cbUsar.Location = new Point(176, 10);
            cbUsar.Name = "cbUsar";
            cbUsar.Size = new Size(83, 19);
            cbUsar.TabIndex = 11;
            cbUsar.Text = "Usar Fecha";
            cbUsar.UseVisualStyleBackColor = true;
            // 
            // btnHoy
            // 
            btnHoy.Location = new Point(493, 40);
            btnHoy.Name = "btnHoy";
            btnHoy.Size = new Size(75, 23);
            btnHoy.TabIndex = 10;
            btnHoy.Text = "Hoy";
            btnHoy.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(400, 40);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(300, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtFiltroUsuario
            // 
            txtFiltroUsuario.Location = new Point(144, 40);
            txtFiltroUsuario.Name = "txtFiltroUsuario";
            txtFiltroUsuario.Size = new Size(128, 23);
            txtFiltroUsuario.TabIndex = 7;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(79, 43);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(519, 9);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(121, 23);
            cbEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(468, 12);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // cbPeliculas
            // 
            cbPeliculas.FormattingEnabled = true;
            cbPeliculas.Location = new Point(335, 9);
            cbPeliculas.Name = "cbPeliculas";
            cbPeliculas.Size = new Size(121, 23);
            cbPeliculas.TabIndex = 3;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(278, 12);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(51, 15);
            lblPelicula.TabIndex = 2;
            lblPelicula.Text = "Pelicula:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(69, 6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(89, 23);
            dateTimePicker1.TabIndex = 1;
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
            // FrmBrowReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 554);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmBrowReservas";
            Text = "Lista de Reservas";
            pnTotal.ResumeLayout(false);
            pnBotones.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dvgUsuarios).EndInit();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnTop;
        private Panel pnInfo;
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
        private Button btnHoy;
        private CheckBox cbUsar;
    }
}