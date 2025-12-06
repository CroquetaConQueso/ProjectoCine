namespace AplicacionCine.Formularios
{
    partial class FrmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpleado));
            tbControl = new TabControl();
            tbDatos = new TabPage();
            pnBotones = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnDatos = new Panel();
            groupBox1 = new GroupBox();
            lbUltimaIP = new Label();
            lbUltimoAcctxt = new Label();
            lbUltimaIPtxt = new Label();
            lbFechaAltatxt = new Label();
            lblTotalEnc = new Label();
            pnMain = new Panel();
            grb = new GroupBox();
            chkActivo = new CheckBox();
            lblActivo = new Label();
            txtDNI = new TextBox();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            lblDNI = new Label();
            lblApellidos = new Label();
            lblNombre = new Label();
            pnTitulo = new Panel();
            lbTitulo = new Label();
            tbNotasRRHH = new TabPage();
            rtbDetalles = new RichTextBox();
            lblEmail = new Label();
            lblFeNaci = new Label();
            tbEmail = new TextBox();
            dtpFeNaci = new DateTimePicker();
            dtpBaja = new DateTimePicker();
            lblFechaBaja = new Label();
            dtpAlta = new DateTimePicker();
            lblFechaAlta = new Label();
            lblTurno = new Label();
            lblSalaHabitual = new Label();
            lblPuesto = new Label();
            cbTipo = new ComboBox();
            cbSalaHabitual = new ComboBox();
            cbTurno = new ComboBox();
            lblUsuario = new Label();
            cbUsuario = new ComboBox();
            txtbTelefono = new TextBox();
            tbControl.SuspendLayout();
            tbDatos.SuspendLayout();
            pnBotones.SuspendLayout();
            pnDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            pnMain.SuspendLayout();
            grb.SuspendLayout();
            pnTitulo.SuspendLayout();
            tbNotasRRHH.SuspendLayout();
            SuspendLayout();
            // 
            // tbControl
            // 
            tbControl.Controls.Add(tbDatos);
            tbControl.Controls.Add(tbNotasRRHH);
            tbControl.Dock = DockStyle.Fill;
            tbControl.Location = new Point(0, 0);
            tbControl.Name = "tbControl";
            tbControl.SelectedIndex = 0;
            tbControl.Size = new Size(869, 529);
            tbControl.TabIndex = 1;
            // 
            // tbDatos
            // 
            tbDatos.Controls.Add(pnBotones);
            tbDatos.Controls.Add(pnDatos);
            tbDatos.Controls.Add(pnMain);
            tbDatos.Controls.Add(pnTitulo);
            tbDatos.Location = new Point(4, 24);
            tbDatos.Name = "tbDatos";
            tbDatos.Padding = new Padding(3);
            tbDatos.Size = new Size(861, 501);
            tbDatos.TabIndex = 0;
            tbDatos.Text = "Datos";
            tbDatos.UseVisualStyleBackColor = true;
            // 
            // pnBotones
            // 
            pnBotones.Controls.Add(btnCancelar);
            pnBotones.Controls.Add(btnAceptar);
            pnBotones.Dock = DockStyle.Top;
            pnBotones.Location = new Point(3, 455);
            pnBotones.Name = "pnBotones";
            pnBotones.Size = new Size(855, 57);
            pnBotones.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(438, 12);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(310, 12);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // pnDatos
            // 
            pnDatos.Controls.Add(groupBox1);
            pnDatos.Dock = DockStyle.Top;
            pnDatos.Location = new Point(3, 294);
            pnDatos.Name = "pnDatos";
            pnDatos.Size = new Size(855, 161);
            pnDatos.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbUltimaIP);
            groupBox1.Controls.Add(lbUltimoAcctxt);
            groupBox1.Controls.Add(lbUltimaIPtxt);
            groupBox1.Controls.Add(lbFechaAltatxt);
            groupBox1.Controls.Add(lblTotalEnc);
            groupBox1.Location = new Point(64, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(721, 116);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // lbUltimaIP
            // 
            lbUltimaIP.AutoSize = true;
            lbUltimaIP.Location = new Point(369, 29);
            lbUltimaIP.Name = "lbUltimaIP";
            lbUltimaIP.Size = new Size(128, 15);
            lbUltimaIP.TabIndex = 26;
            lbUltimaIP.Text = "Pases como seguridad:";
            // 
            // lbUltimoAcctxt
            // 
            lbUltimoAcctxt.AutoSize = true;
            lbUltimoAcctxt.Location = new Point(325, 81);
            lbUltimoAcctxt.Name = "lbUltimoAcctxt";
            lbUltimoAcctxt.Size = new Size(132, 15);
            lbUltimoAcctxt.TabIndex = 25;
            lbUltimoAcctxt.Text = "Placeholder UltimoPase";
            // 
            // lbUltimaIPtxt
            // 
            lbUltimaIPtxt.AutoSize = true;
            lbUltimaIPtxt.Location = new Point(494, 29);
            lbUltimaIPtxt.Name = "lbUltimaIPtxt";
            lbUltimaIPtxt.Size = new Size(121, 15);
            lbUltimaIPtxt.TabIndex = 24;
            lbUltimaIPtxt.Text = "Placeholde Seguridad";
            // 
            // lbFechaAltatxt
            // 
            lbFechaAltatxt.AutoSize = true;
            lbFechaAltatxt.Location = new Point(258, 29);
            lbFechaAltatxt.Name = "lbFechaAltatxt";
            lbFechaAltatxt.Size = new Size(101, 15);
            lbFechaAltatxt.TabIndex = 23;
            lbFechaAltatxt.Text = "Placeholder Pases";
            // 
            // lblTotalEnc
            // 
            lblTotalEnc.AutoSize = true;
            lblTotalEnc.Location = new Point(120, 29);
            lblTotalEnc.Name = "lblTotalEnc";
            lblTotalEnc.Size = new Size(132, 15);
            lblTotalEnc.TabIndex = 21;
            lblTotalEnc.Text = "Pases como encargado:";
            // 
            // pnMain
            // 
            pnMain.Controls.Add(grb);
            pnMain.Dock = DockStyle.Top;
            pnMain.Location = new Point(3, 44);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(855, 250);
            pnMain.TabIndex = 1;
            // 
            // grb
            // 
            grb.Controls.Add(txtbTelefono);
            grb.Controls.Add(cbUsuario);
            grb.Controls.Add(lblUsuario);
            grb.Controls.Add(cbTurno);
            grb.Controls.Add(cbSalaHabitual);
            grb.Controls.Add(cbTipo);
            grb.Controls.Add(lblPuesto);
            grb.Controls.Add(lblSalaHabitual);
            grb.Controls.Add(lblTurno);
            grb.Controls.Add(dtpAlta);
            grb.Controls.Add(lblFechaAlta);
            grb.Controls.Add(dtpBaja);
            grb.Controls.Add(lblFechaBaja);
            grb.Controls.Add(dtpFeNaci);
            grb.Controls.Add(tbEmail);
            grb.Controls.Add(lblFeNaci);
            grb.Controls.Add(lblEmail);
            grb.Controls.Add(chkActivo);
            grb.Controls.Add(lblActivo);
            grb.Controls.Add(txtDNI);
            grb.Controls.Add(txtApellidos);
            grb.Controls.Add(txtNombre);
            grb.Controls.Add(lblTelefono);
            grb.Controls.Add(lblDNI);
            grb.Controls.Add(lblApellidos);
            grb.Controls.Add(lblNombre);
            grb.Dock = DockStyle.Fill;
            grb.Location = new Point(0, 0);
            grb.Name = "grb";
            grb.Size = new Size(855, 250);
            grb.TabIndex = 25;
            grb.TabStop = false;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(519, 191);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(59, 19);
            chkActivo.TabIndex = 31;
            chkActivo.Text = "Activa";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Location = new Point(468, 193);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(45, 15);
            lblActivo.TabIndex = 24;
            lblActivo.Text = "Estado:";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(245, 88);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(147, 23);
            txtDNI.TabIndex = 18;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(251, 53);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(141, 23);
            txtApellidos.TabIndex = 17;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(245, 18);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(122, 23);
            txtNombre.TabIndex = 16;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(189, 125);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Telefono:";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(189, 92);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(30, 15);
            lblDNI.TabIndex = 13;
            lblDNI.Text = "DNI:";
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(189, 57);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(59, 15);
            lblApellidos.TabIndex = 12;
            lblApellidos.Text = "Apellidos:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(189, 22);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 11;
            lblNombre.Text = "Nombre:";
            // 
            // pnTitulo
            // 
            pnTitulo.Controls.Add(lbTitulo);
            pnTitulo.Dock = DockStyle.Top;
            pnTitulo.Location = new Point(3, 3);
            pnTitulo.Name = "pnTitulo";
            pnTitulo.Size = new Size(855, 41);
            pnTitulo.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.Dock = DockStyle.Fill;
            lbTitulo.Font = new Font("Segoe UI", 20F);
            lbTitulo.Location = new Point(0, 0);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(855, 41);
            lbTitulo.TabIndex = 1;
            lbTitulo.Text = "Empleado..";
            lbTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbNotasRRHH
            // 
            tbNotasRRHH.Controls.Add(rtbDetalles);
            tbNotasRRHH.Location = new Point(4, 24);
            tbNotasRRHH.Name = "tbNotasRRHH";
            tbNotasRRHH.Padding = new Padding(3);
            tbNotasRRHH.Size = new Size(861, 501);
            tbNotasRRHH.TabIndex = 1;
            tbNotasRRHH.Text = "Notas RRHH";
            tbNotasRRHH.UseVisualStyleBackColor = true;
            // 
            // rtbDetalles
            // 
            rtbDetalles.Dock = DockStyle.Fill;
            rtbDetalles.Location = new Point(3, 3);
            rtbDetalles.Name = "rtbDetalles";
            rtbDetalles.Size = new Size(855, 495);
            rtbDetalles.TabIndex = 0;
            rtbDetalles.Text = "";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(189, 161);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 34;
            lblEmail.Text = "Email:";
            // 
            // lblFeNaci
            // 
            lblFeNaci.AutoSize = true;
            lblFeNaci.Location = new Point(189, 193);
            lblFeNaci.Name = "lblFeNaci";
            lblFeNaci.Size = new Size(122, 15);
            lblFeNaci.TabIndex = 35;
            lblFeNaci.Text = "Fecha de Nacimiento:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(234, 157);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(179, 23);
            tbEmail.TabIndex = 36;
            // 
            // dtpFeNaci
            // 
            dtpFeNaci.Format = DateTimePickerFormat.Short;
            dtpFeNaci.Location = new Point(317, 189);
            dtpFeNaci.Name = "dtpFeNaci";
            dtpFeNaci.Size = new Size(96, 23);
            dtpFeNaci.TabIndex = 37;
            // 
            // dtpBaja
            // 
            dtpBaja.Format = DateTimePickerFormat.Short;
            dtpBaja.Location = new Point(556, 157);
            dtpBaja.Name = "dtpBaja";
            dtpBaja.Size = new Size(96, 23);
            dtpBaja.TabIndex = 39;
            // 
            // lblFechaBaja
            // 
            lblFechaBaja.AutoSize = true;
            lblFechaBaja.Location = new Point(468, 161);
            lblFechaBaja.Name = "lblFechaBaja";
            lblFechaBaja.Size = new Size(82, 15);
            lblFechaBaja.TabIndex = 38;
            lblFechaBaja.Text = "Fecha de Baja:";
            // 
            // dtpAlta
            // 
            dtpAlta.Format = DateTimePickerFormat.Short;
            dtpAlta.Location = new Point(556, 121);
            dtpAlta.Name = "dtpAlta";
            dtpAlta.Size = new Size(96, 23);
            dtpAlta.TabIndex = 41;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(469, 125);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(81, 15);
            lblFechaAlta.TabIndex = 40;
            lblFechaAlta.Text = "Fecha de Alta:";
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(468, 92);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(42, 15);
            lblTurno.TabIndex = 42;
            lblTurno.Text = "Turno:";
            // 
            // lblSalaHabitual
            // 
            lblSalaHabitual.AutoSize = true;
            lblSalaHabitual.Location = new Point(468, 57);
            lblSalaHabitual.Name = "lblSalaHabitual";
            lblSalaHabitual.Size = new Size(77, 15);
            lblSalaHabitual.TabIndex = 43;
            lblSalaHabitual.Text = "Sala habitual:";
            // 
            // lblPuesto
            // 
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(469, 22);
            lblPuesto.Name = "lblPuesto";
            lblPuesto.Size = new Size(46, 15);
            lblPuesto.TabIndex = 44;
            lblPuesto.Text = "Puesto:";
            // 
            // cbTipo
            // 
            cbTipo.FormattingEnabled = true;
            cbTipo.Location = new Point(543, 18);
            cbTipo.Name = "cbTipo";
            cbTipo.Size = new Size(121, 23);
            cbTipo.TabIndex = 45;
            // 
            // cbSalaHabitual
            // 
            cbSalaHabitual.FormattingEnabled = true;
            cbSalaHabitual.Location = new Point(551, 53);
            cbSalaHabitual.Name = "cbSalaHabitual";
            cbSalaHabitual.Size = new Size(121, 23);
            cbSalaHabitual.TabIndex = 46;
            // 
            // cbTurno
            // 
            cbTurno.FormattingEnabled = true;
            cbTurno.Location = new Point(516, 88);
            cbTurno.Name = "cbTurno";
            cbTurno.Size = new Size(121, 23);
            cbTurno.TabIndex = 47;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(285, 226);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(94, 15);
            lblUsuario.TabIndex = 48;
            lblUsuario.Text = "Usuario Sistema:";
            // 
            // cbUsuario
            // 
            cbUsuario.FormattingEnabled = true;
            cbUsuario.Location = new Point(388, 223);
            cbUsuario.Name = "cbUsuario";
            cbUsuario.Size = new Size(121, 23);
            cbUsuario.TabIndex = 49;
            // 
            // txtbTelefono
            // 
            txtbTelefono.Location = new Point(251, 121);
            txtbTelefono.Name = "txtbTelefono";
            txtbTelefono.Size = new Size(147, 23);
            txtbTelefono.TabIndex = 50;
            // 
            // FrmEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 529);
            Controls.Add(tbControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEmpleado";
            Text = "Datos Empleado";
            tbControl.ResumeLayout(false);
            tbDatos.ResumeLayout(false);
            pnBotones.ResumeLayout(false);
            pnDatos.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnMain.ResumeLayout(false);
            grb.ResumeLayout(false);
            grb.PerformLayout();
            pnTitulo.ResumeLayout(false);
            tbNotasRRHH.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbControl;
        private TabPage tbDatos;
        private TabPage tbNotasRRHH;
        private RichTextBox rtbDetalles;
        private Panel pnMain;
        private Panel pnTitulo;
        private Panel pnBotones;
        private Panel pnDatos;
        private Label lbTitulo;
        private GroupBox grb;
        private CheckBox chkActivo;
        private Label lblActivo;
        private ComboBox cbRol;
        private TextBox txtDNI;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private Label lblTelefono;
        private Label lblDNI;
        private Label lblApellidos;
        private Label lblNombre;
        private GroupBox groupBox1;
        private Label lbUltimaIP;
        private Label lbUltimoAcctxt;
        private Label lbUltimaIPtxt;
        private Label lbFechaAltatxt;
        private Label lbUltimoAcc;
        private Label lblTotalEnc;
        private Button btnCancelar;
        private Button btnAceptar;
        private DateTimePicker dtpFeNaci;
        private TextBox tbEmail;
        private Label lblFeNaci;
        private Label lblEmail;
        private Label lblPuesto;
        private Label lblSalaHabitual;
        private Label lblTurno;
        private DateTimePicker dtpAlta;
        private Label lblFechaAlta;
        private DateTimePicker dtpBaja;
        private Label lblFechaBaja;
        private ComboBox cbTurno;
        private ComboBox cbSalaHabitual;
        private ComboBox cbTipo;
        private ComboBox cbUsuario;
        private Label lblUsuario;
        private TextBox txtbTelefono;
    }
}