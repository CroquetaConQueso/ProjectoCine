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
            pnStatus = new Panel();
            statusStrip1 = new StatusStrip();
            tslReservasResumen = new ToolStripStatusLabel();
            tslReservasEstados = new ToolStripStatusLabel();
            tslReservasImporte = new ToolStripStatusLabel();
            tslReservasSeleccion = new ToolStripStatusLabel();
            pnBotones = new Panel();
            btnEliminar = new Button();
            btnEditar = new Button();
            pnInfo = new Panel();
            dvgUsuarios = new DataGridView();
            pnTop = new Panel();
            cbUsar = new CheckBox();
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
            pnStatus.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnBotones.SuspendLayout();
            pnInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgUsuarios).BeginInit();
            pnTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnStatus);
            pnTotal.Controls.Add(pnBotones);
            pnTotal.Controls.Add(pnInfo);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(781, 594);
            pnTotal.TabIndex = 0;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusStrip1);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 564);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(781, 30);
            pnStatus.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Fill;
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslReservasResumen, tslReservasEstados, tslReservasImporte, tslReservasSeleccion });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(781, 30);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslReservasResumen
            // 
            tslReservasResumen.Margin = new Padding(10, 3, 0, 2);
            tslReservasResumen.Name = "tslReservasResumen";
            tslReservasResumen.Size = new Size(101, 25);
            tslReservasResumen.Text = "ReservasResumen";
            // 
            // tslReservasEstados
            // 
            tslReservasEstados.Margin = new Padding(20, 3, 0, 2);
            tslReservasEstados.Name = "tslReservasEstados";
            tslReservasEstados.Size = new Size(92, 25);
            tslReservasEstados.Text = "ReservasEstados";
            // 
            // tslReservasImporte
            // 
            tslReservasImporte.Margin = new Padding(20, 3, 0, 2);
            tslReservasImporte.Name = "tslReservasImporte";
            tslReservasImporte.Size = new Size(94, 25);
            tslReservasImporte.Text = "ReservasImporte";
            // 
            // tslReservasSeleccion
            // 
            tslReservasSeleccion.Margin = new Padding(10, 3, 0, 2);
            tslReservasSeleccion.Name = "tslReservasSeleccion";
            tslReservasSeleccion.Size = new Size(102, 25);
            tslReservasSeleccion.Text = "ReservasSeleccion";
            // 
            // pnBotones
            // 
            pnBotones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnBotones.Controls.Add(btnEliminar);
            pnBotones.Controls.Add(btnEditar);
            pnBotones.Location = new Point(0, 527);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(781, 38);
            pnBotones.TabIndex = 4;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(382, 8);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(276, 8);
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
            pnInfo.Size = new Size(781, 525);
            pnInfo.TabIndex = 3;
            // 
            // dvgUsuarios
            // 
            dvgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgUsuarios.Dock = DockStyle.Fill;
            dvgUsuarios.Location = new Point(0, 0);
            dvgUsuarios.Name = "dvgUsuarios";
            dvgUsuarios.Size = new Size(781, 525);
            dvgUsuarios.TabIndex = 2;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(cbUsar);
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
            pnTop.Size = new Size(781, 69);
            pnTop.TabIndex = 1;
            // 
            // cbUsar
            // 
            cbUsar.AutoSize = true;
            cbUsar.Location = new Point(164, 9);
            cbUsar.Name = "cbUsar";
            cbUsar.Size = new Size(83, 19);
            cbUsar.TabIndex = 10;
            cbUsar.Text = "Usar Fecha";
            cbUsar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(502, 40);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(402, 40);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtFiltroUsuario
            // 
            txtFiltroUsuario.Location = new Point(246, 40);
            txtFiltroUsuario.Name = "txtFiltroUsuario";
            txtFiltroUsuario.Size = new Size(128, 23);
            txtFiltroUsuario.TabIndex = 7;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(181, 43);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario:";
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(593, 7);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(121, 23);
            cbEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(542, 11);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(45, 15);
            lblEstado.TabIndex = 4;
            lblEstado.Text = "Estado:";
            // 
            // cbPeliculas
            // 
            cbPeliculas.FormattingEnabled = true;
            cbPeliculas.Location = new Point(357, 7);
            cbPeliculas.Name = "cbPeliculas";
            cbPeliculas.Size = new Size(121, 23);
            cbPeliculas.TabIndex = 3;
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(300, 11);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(51, 15);
            lblPelicula.TabIndex = 2;
            lblPelicula.Text = "Pelicula:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(69, 7);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(89, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(22, 11);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // FrmBrowReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 594);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmBrowReservas";
            Text = "Lista de Reservas";
            pnTotal.ResumeLayout(false);
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private Panel pnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslReservasResumen;
        private ToolStripStatusLabel tslReservasEstados;
        private ToolStripStatusLabel tslReservasImporte;
        private ToolStripStatusLabel tslReservasSeleccion;
        private CheckBox cbUsar;
    }
}