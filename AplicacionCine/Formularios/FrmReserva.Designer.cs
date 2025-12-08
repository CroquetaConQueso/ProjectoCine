namespace AplicacionCine.Formularios
{
    partial class FrmReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReserva));
            tbControl = new TabControl();
            tbDatos = new TabPage();
            pnExtra = new Panel();
            groupBox1 = new GroupBox();
            lbCantidadTotalReservas = new Label();
            lbTotalReserva = new Label();
            lbPrecio = new Label();
            lbCantidadTotalEntradas = new Label();
            lbCantidadPrecio = new Label();
            lbCantidadEntradas = new Label();
            lbTotalEntradas = new Label();
            lbNentradas = new Label();
            pnDatos = new Panel();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            pnBotones = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnInfo = new Panel();
            grb = new GroupBox();
            lPase = new Label();
            lFecha = new Label();
            cbEstado = new ComboBox();
            lblPase = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblUsuario = new Label();
            lblSala = new Label();
            lblPelicula = new Label();
            lblIdReserva = new Label();
            lbActivo = new Label();
            lbUsuario = new Label();
            lbSala = new Label();
            lbPelicula = new Label();
            lbReserva = new Label();
            pnTop = new Panel();
            lbTitulo = new Label();
            tbObservaciones = new TabPage();
            rtbObservaciones = new RichTextBox();
            tbControl.SuspendLayout();
            tbDatos.SuspendLayout();
            pnExtra.SuspendLayout();
            groupBox1.SuspendLayout();
            pnDatos.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnBotones.SuspendLayout();
            pnInfo.SuspendLayout();
            grb.SuspendLayout();
            pnTop.SuspendLayout();
            tbObservaciones.SuspendLayout();
            SuspendLayout();
            // 
            // tbControl
            // 
            tbControl.Controls.Add(tbDatos);
            tbControl.Controls.Add(tbObservaciones);
            tbControl.Dock = DockStyle.Fill;
            tbControl.Location = new Point(0, 0);
            tbControl.Name = "tbControl";
            tbControl.SelectedIndex = 0;
            tbControl.Size = new Size(828, 517);
            tbControl.TabIndex = 0;
            // 
            // tbDatos
            // 
            tbDatos.Controls.Add(pnExtra);
            tbDatos.Controls.Add(pnDatos);
            tbDatos.Controls.Add(pnBotones);
            tbDatos.Controls.Add(pnInfo);
            tbDatos.Controls.Add(pnTop);
            tbDatos.Location = new Point(4, 24);
            tbDatos.Name = "tbDatos";
            tbDatos.Padding = new Padding(3);
            tbDatos.Size = new Size(820, 489);
            tbDatos.TabIndex = 0;
            tbDatos.Text = "Datos";
            tbDatos.UseVisualStyleBackColor = true;
            // 
            // pnExtra
            // 
            pnExtra.Controls.Add(groupBox1);
            pnExtra.Dock = DockStyle.Top;
            pnExtra.Location = new Point(3, 372);
            pnExtra.Name = "pnExtra";
            pnExtra.Size = new Size(814, 51);
            pnExtra.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbCantidadTotalReservas);
            groupBox1.Controls.Add(lbTotalReserva);
            groupBox1.Controls.Add(lbPrecio);
            groupBox1.Controls.Add(lbCantidadTotalEntradas);
            groupBox1.Controls.Add(lbCantidadPrecio);
            groupBox1.Controls.Add(lbCantidadEntradas);
            groupBox1.Controls.Add(lbTotalEntradas);
            groupBox1.Controls.Add(lbNentradas);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(814, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lbCantidadTotalReservas
            // 
            lbCantidadTotalReservas.AutoSize = true;
            lbCantidadTotalReservas.Location = new Point(701, 22);
            lbCantidadTotalReservas.Name = "lbCantidadTotalReservas";
            lbCantidadTotalReservas.Size = new Size(86, 15);
            lbCantidadTotalReservas.TabIndex = 7;
            lbCantidadTotalReservas.Text = "CTotalReservas";
            // 
            // lbTotalReserva
            // 
            lbTotalReserva.AutoSize = true;
            lbTotalReserva.Location = new Point(611, 22);
            lbTotalReserva.Name = "lbTotalReserva";
            lbTotalReserva.Size = new Size(84, 15);
            lbTotalReserva.TabIndex = 6;
            lbTotalReserva.Text = "Total Reservas:";
            // 
            // lbPrecio
            // 
            lbPrecio.AutoSize = true;
            lbPrecio.Location = new Point(251, 22);
            lbPrecio.Name = "lbPrecio";
            lbPrecio.Size = new Size(70, 15);
            lbPrecio.TabIndex = 2;
            lbPrecio.Text = "Precio base:";
            // 
            // lbCantidadTotalEntradas
            // 
            lbCantidadTotalEntradas.AutoSize = true;
            lbCantidadTotalEntradas.Location = new Point(516, 22);
            lbCantidadTotalEntradas.Name = "lbCantidadTotalEntradas";
            lbCantidadTotalEntradas.Size = new Size(81, 15);
            lbCantidadTotalEntradas.TabIndex = 5;
            lbCantidadTotalEntradas.Text = "CantidadTotal";
            // 
            // lbCantidadPrecio
            // 
            lbCantidadPrecio.AutoSize = true;
            lbCantidadPrecio.Location = new Point(327, 22);
            lbCantidadPrecio.Name = "lbCantidadPrecio";
            lbCantidadPrecio.Size = new Size(88, 15);
            lbCantidadPrecio.TabIndex = 3;
            lbCantidadPrecio.Text = "CantidadPrecio";
            lbCantidadPrecio.Click += lbCantidadPrecio_Click;
            // 
            // lbCantidadEntradas
            // 
            lbCantidadEntradas.AutoSize = true;
            lbCantidadEntradas.Location = new Point(117, 22);
            lbCantidadEntradas.Name = "lbCantidadEntradas";
            lbCantidadEntradas.Size = new Size(100, 15);
            lbCantidadEntradas.TabIndex = 1;
            lbCantidadEntradas.Text = "CantidadEntradas";
            // 
            // lbTotalEntradas
            // 
            lbTotalEntradas.AutoSize = true;
            lbTotalEntradas.Location = new Point(426, 22);
            lbTotalEntradas.Name = "lbTotalEntradas";
            lbTotalEntradas.Size = new Size(84, 15);
            lbTotalEntradas.TabIndex = 4;
            lbTotalEntradas.Text = "Total Entradas:";
            // 
            // lbNentradas
            // 
            lbNentradas.AutoSize = true;
            lbNentradas.Location = new Point(39, 22);
            lbNentradas.Name = "lbNentradas";
            lbNentradas.Size = new Size(72, 15);
            lbNentradas.TabIndex = 0;
            lbNentradas.Text = "Nº Entradas:";
            // 
            // pnDatos
            // 
            pnDatos.Controls.Add(groupBox2);
            pnDatos.Dock = DockStyle.Top;
            pnDatos.Location = new Point(3, 165);
            pnDatos.Name = "pnDatos";
            pnDatos.Size = new Size(814, 207);
            pnDatos.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(814, 207);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(808, 185);
            dataGridView1.TabIndex = 0;
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCancelar);
            pnBotones.Controls.Add(btnAceptar);
            pnBotones.Dock = DockStyle.Bottom;
            pnBotones.Location = new Point(3, 429);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(814, 57);
            pnBotones.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(420, 17);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(292, 17);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(grb);
            pnInfo.Dock = DockStyle.Top;
            pnInfo.Location = new Point(3, 44);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(814, 121);
            pnInfo.TabIndex = 1;
            // 
            // grb
            // 
            grb.Controls.Add(lPase);
            grb.Controls.Add(lFecha);
            grb.Controls.Add(cbEstado);
            grb.Controls.Add(lblPase);
            grb.Controls.Add(dateTimePicker1);
            grb.Controls.Add(lblUsuario);
            grb.Controls.Add(lblSala);
            grb.Controls.Add(lblPelicula);
            grb.Controls.Add(lblIdReserva);
            grb.Controls.Add(lbActivo);
            grb.Controls.Add(lbUsuario);
            grb.Controls.Add(lbSala);
            grb.Controls.Add(lbPelicula);
            grb.Controls.Add(lbReserva);
            grb.Dock = DockStyle.Fill;
            grb.Location = new Point(0, 0);
            grb.Name = "grb";
            grb.Size = new Size(814, 121);
            grb.TabIndex = 0;
            grb.TabStop = false;
            // 
            // lPase
            // 
            lPase.AutoSize = true;
            lPase.Location = new Point(452, 55);
            lPase.Name = "lPase";
            lPase.Size = new Size(34, 15);
            lPase.TabIndex = 11;
            lPase.Text = "Pase:";
            // 
            // lFecha
            // 
            lFecha.AutoSize = true;
            lFecha.Location = new Point(444, 27);
            lFecha.Name = "lFecha";
            lFecha.Size = new Size(41, 15);
            lFecha.TabIndex = 9;
            lFecha.Text = "Fecha:";
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(495, 79);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(121, 23);
            cbEstado.TabIndex = 0;
            // 
            // lblPase
            // 
            lblPase.AutoSize = true;
            lblPase.Location = new Point(495, 55);
            lblPase.Name = "lblPase";
            lblPase.Size = new Size(52, 15);
            lblPase.TabIndex = 12;
            lblPase.Text = "InfoPase";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(488, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(95, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(269, 94);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(68, 15);
            lblUsuario.TabIndex = 8;
            lblUsuario.Text = "InfoUsuario";
            // 
            // lblSala
            // 
            lblSala.AutoSize = true;
            lblSala.Location = new Point(264, 71);
            lblSala.Name = "lblSala";
            lblSala.Size = new Size(49, 15);
            lblSala.TabIndex = 6;
            lblSala.Text = "InfoSala";
            // 
            // lblPelicula
            // 
            lblPelicula.AutoSize = true;
            lblPelicula.Location = new Point(280, 46);
            lblPelicula.Name = "lblPelicula";
            lblPelicula.Size = new Size(69, 15);
            lblPelicula.TabIndex = 4;
            lblPelicula.Text = "InfoPelicula";
            // 
            // lblIdReserva
            // 
            lblIdReserva.AutoSize = true;
            lblIdReserva.Location = new Point(280, 23);
            lblIdReserva.Name = "lblIdReserva";
            lblIdReserva.Size = new Size(68, 15);
            lblIdReserva.TabIndex = 2;
            lblIdReserva.Text = "InfoReserva";
            // 
            // lbActivo
            // 
            lbActivo.AutoSize = true;
            lbActivo.Location = new Point(444, 84);
            lbActivo.Name = "lbActivo";
            lbActivo.Size = new Size(45, 15);
            lbActivo.TabIndex = 13;
            lbActivo.Text = "Estado:";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(213, 94);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 15);
            lbUsuario.TabIndex = 7;
            lbUsuario.Text = "Usuario:";
            // 
            // lbSala
            // 
            lbSala.AutoSize = true;
            lbSala.Location = new Point(218, 71);
            lbSala.Name = "lbSala";
            lbSala.Size = new Size(31, 15);
            lbSala.TabIndex = 5;
            lbSala.Text = "Sala:";
            // 
            // lbPelicula
            // 
            lbPelicula.AutoSize = true;
            lbPelicula.Location = new Point(213, 46);
            lbPelicula.Name = "lbPelicula";
            lbPelicula.Size = new Size(51, 15);
            lbPelicula.TabIndex = 3;
            lbPelicula.Text = "Pelicula:";
            // 
            // lbReserva
            // 
            lbReserva.AutoSize = true;
            lbReserva.Location = new Point(213, 23);
            lbReserva.Name = "lbReserva";
            lbReserva.Size = new Size(50, 15);
            lbReserva.TabIndex = 1;
            lbReserva.Text = "Reserva:";
            // 
            // pnTop
            // 
            pnTop.Controls.Add(lbTitulo);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(3, 3);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(814, 41);
            pnTop.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.Dock = DockStyle.Fill;
            lbTitulo.Font = new Font("Segoe UI", 20F);
            lbTitulo.Location = new Point(0, 0);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(814, 41);
            lbTitulo.TabIndex = 0;
            lbTitulo.Text = "Reserva de..";
            lbTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbObservaciones
            // 
            tbObservaciones.Controls.Add(rtbObservaciones);
            tbObservaciones.Location = new Point(4, 24);
            tbObservaciones.Name = "tbObservaciones";
            tbObservaciones.Padding = new Padding(3);
            tbObservaciones.Size = new Size(820, 489);
            tbObservaciones.TabIndex = 1;
            tbObservaciones.Text = "Observaciones";
            tbObservaciones.UseVisualStyleBackColor = true;
            // 
            // rtbObservaciones
            // 
            rtbObservaciones.Dock = DockStyle.Fill;
            rtbObservaciones.Location = new Point(3, 3);
            rtbObservaciones.Name = "rtbObservaciones";
            rtbObservaciones.Size = new Size(814, 483);
            rtbObservaciones.TabIndex = 0;
            rtbObservaciones.Text = "";
            // 
            // FrmReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 517);
            Controls.Add(tbControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmReserva";
            Text = "Datos Reserva";
            tbControl.ResumeLayout(false);
            tbDatos.ResumeLayout(false);
            pnExtra.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnDatos.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnBotones.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            grb.ResumeLayout(false);
            grb.PerformLayout();
            pnTop.ResumeLayout(false);
            tbObservaciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbControl;
        private TabPage tbDatos;
        private TabPage tbObservaciones;
        private RichTextBox rtbObservaciones;
        private Panel pnInfo;
        private Panel pnTop;
        private Panel pnBotones;
        private Label lbTitulo;
        private GroupBox grb;
        private TextBox txtConfirmar;
        private NumericUpDown nudIntentos;
        private CheckBox cbCuenta;
        private TextBox txtContrasena;
        private Label lbConfirmar;
        private Label lbContraseña;
        private Label lblFecha;
        private CheckBox checkBox1;
        private ComboBox cbRol;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtUsuario;
        private Label lbActivo;
        private Label lbUsuario;
        private Label lbSala;
        private Label lbPelicula;
        private Label lbReserva;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label lblIdReserva;
        private Label lblPelicula;
        private Label lblSala;
        private Label lblUsuario;
        private DateTimePicker dateTimePicker1;
        private ComboBox cbEstado;
        private Label lblPase;
        private Panel pnExtra;
        private GroupBox groupBox1;
        private Label lbPrecio;
        private Label lbCantidadTotalEntradas;
        private Label lbCantidadPrecio;
        private Label lbCantidadEntradas;
        private Label lbTotalEntradas;
        private Label lbNentradas;
        private Panel pnDatos;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Label lPase;
        private Label lFecha;
        private Label lbCantidadTotalReservas;
        private Label lbTotalReserva;
    }
}