namespace AplicacionCine.Formularios
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            tbControl = new TabControl();
            tbDatos = new TabPage();
            panel4 = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            lbUltimaIP = new Label();
            lbUltimoAcctxt = new Label();
            lbUltimaIPtxt = new Label();
            lbFechaAltatxt = new Label();
            lbUltimoAcc = new Label();
            lbFechaAlta = new Label();
            panel2 = new Panel();
            grb = new GroupBox();
            txtConfirmar = new TextBox();
            nudIntentos = new NumericUpDown();
            cbCuenta = new CheckBox();
            txtContrasena = new TextBox();
            lbConfirmar = new Label();
            lbContraseña = new Label();
            lbIntentos = new Label();
            lbBloqueado = new Label();
            checkBox1 = new CheckBox();
            cbRol = new ComboBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtUsuario = new TextBox();
            lbActivo = new Label();
            lbRol = new Label();
            lbTelefono = new Label();
            lbEmail = new Label();
            lbUsuario = new Label();
            panel1 = new Panel();
            lbTitulo = new Label();
            tbNotasAdmin = new TabPage();
            rtbDetalles = new RichTextBox();
            tbControl.SuspendLayout();
            tbDatos.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudIntentos).BeginInit();
            panel1.SuspendLayout();
            tbNotasAdmin.SuspendLayout();
            SuspendLayout();
            // 
            // tbControl
            // 
            tbControl.Controls.Add(tbDatos);
            tbControl.Controls.Add(tbNotasAdmin);
            tbControl.Dock = DockStyle.Fill;
            tbControl.Location = new Point(0, 0);
            tbControl.Name = "tbControl";
            tbControl.SelectedIndex = 0;
            tbControl.Size = new Size(800, 450);
            tbControl.TabIndex = 1;
            // 
            // tbDatos
            // 
            tbDatos.Controls.Add(panel4);
            tbDatos.Controls.Add(panel3);
            tbDatos.Controls.Add(panel2);
            tbDatos.Controls.Add(panel1);
            tbDatos.Location = new Point(4, 24);
            tbDatos.Name = "tbDatos";
            tbDatos.Padding = new Padding(3);
            tbDatos.Size = new Size(792, 422);
            tbDatos.TabIndex = 0;
            tbDatos.Text = "Datos";
            tbDatos.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCancelar);
            panel4.Controls.Add(btnAceptar);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 369);
            panel4.Name = "panel4";
            panel4.Size = new Size(786, 57);
            panel4.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(420, 17);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(292, 17);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 208);
            panel3.Name = "panel3";
            panel3.Size = new Size(786, 161);
            panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbUltimaIP);
            groupBox1.Controls.Add(lbUltimoAcctxt);
            groupBox1.Controls.Add(lbUltimaIPtxt);
            groupBox1.Controls.Add(lbFechaAltatxt);
            groupBox1.Controls.Add(lbUltimoAcc);
            groupBox1.Controls.Add(lbFechaAlta);
            groupBox1.Location = new Point(33, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(721, 116);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // lbUltimaIP
            // 
            lbUltimaIP.AutoSize = true;
            lbUltimaIP.Location = new Point(424, 22);
            lbUltimaIP.Name = "lbUltimaIP";
            lbUltimaIP.Size = new Size(58, 15);
            lbUltimaIP.TabIndex = 26;
            lbUltimaIP.Text = "Última IP:";
            // 
            // lbUltimoAcctxt
            // 
            lbUltimoAcctxt.AutoSize = true;
            lbUltimoAcctxt.Location = new Point(380, 74);
            lbUltimoAcctxt.Name = "lbUltimoAcctxt";
            lbUltimoAcctxt.Size = new Size(96, 15);
            lbUltimoAcctxt.TabIndex = 25;
            lbUltimoAcctxt.Text = "El Ultimo Acceso";
            // 
            // lbUltimaIPtxt
            // 
            lbUltimaIPtxt.AutoSize = true;
            lbUltimaIPtxt.Location = new Point(497, 22);
            lbUltimaIPtxt.Name = "lbUltimaIPtxt";
            lbUltimaIPtxt.Size = new Size(70, 15);
            lbUltimaIPtxt.TabIndex = 24;
            lbUltimaIPtxt.Text = "La Ultima IP";
            // 
            // lbFechaAltatxt
            // 
            lbFechaAltatxt.AutoSize = true;
            lbFechaAltatxt.Location = new Point(259, 22);
            lbFechaAltatxt.Name = "lbFechaAltatxt";
            lbFechaAltatxt.Size = new Size(100, 15);
            lbFechaAltatxt.TabIndex = 23;
            lbFechaAltatxt.Text = "La Fecha De Alata";
            // 
            // lbUltimoAcc
            // 
            lbUltimoAcc.AutoSize = true;
            lbUltimoAcc.Location = new Point(274, 74);
            lbUltimoAcc.Name = "lbUltimoAcc";
            lbUltimoAcc.Size = new Size(85, 15);
            lbUltimoAcc.TabIndex = 22;
            lbUltimoAcc.Text = "Último acceso:";
            // 
            // lbFechaAlta
            // 
            lbFechaAlta.AutoSize = true;
            lbFechaAlta.Location = new Point(175, 22);
            lbFechaAlta.Name = "lbFechaAlta";
            lbFechaAlta.Size = new Size(63, 15);
            lbFechaAlta.TabIndex = 21;
            lbFechaAlta.Text = "Fecha alta:";
            // 
            // panel2
            // 
            panel2.Controls.Add(grb);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(786, 164);
            panel2.TabIndex = 1;
            // 
            // grb
            // 
            grb.Controls.Add(txtConfirmar);
            grb.Controls.Add(nudIntentos);
            grb.Controls.Add(cbCuenta);
            grb.Controls.Add(txtContrasena);
            grb.Controls.Add(lbConfirmar);
            grb.Controls.Add(lbContraseña);
            grb.Controls.Add(lbIntentos);
            grb.Controls.Add(lbBloqueado);
            grb.Controls.Add(checkBox1);
            grb.Controls.Add(cbRol);
            grb.Controls.Add(txtTelefono);
            grb.Controls.Add(txtEmail);
            grb.Controls.Add(txtUsuario);
            grb.Controls.Add(lbActivo);
            grb.Controls.Add(lbRol);
            grb.Controls.Add(lbTelefono);
            grb.Controls.Add(lbEmail);
            grb.Controls.Add(lbUsuario);
            grb.Dock = DockStyle.Fill;
            grb.Location = new Point(0, 0);
            grb.Name = "grb";
            grb.Size = new Size(786, 164);
            grb.TabIndex = 25;
            grb.TabStop = false;
            // 
            // txtConfirmar
            // 
            txtConfirmar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmar.Location = new Point(432, 126);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.PasswordChar = '*';
            txtConfirmar.Size = new Size(188, 23);
            txtConfirmar.TabIndex = 33;
            txtConfirmar.UseSystemPasswordChar = true;
            // 
            // nudIntentos
            // 
            nudIntentos.Location = new Point(458, 59);
            nudIntentos.Name = "nudIntentos";
            nudIntentos.ReadOnly = true;
            nudIntentos.Size = new Size(50, 23);
            nudIntentos.TabIndex = 32;
            // 
            // cbCuenta
            // 
            cbCuenta.AutoSize = true;
            cbCuenta.Location = new Point(429, 25);
            cbCuenta.Name = "cbCuenta";
            cbCuenta.Size = new Size(123, 19);
            cbCuenta.TabIndex = 31;
            cbCuenta.Text = "Cuanta bloqueada";
            cbCuenta.UseVisualStyleBackColor = true;
            // 
            // txtContrasena
            // 
            txtContrasena.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtContrasena.Location = new Point(432, 93);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(188, 23);
            txtContrasena.TabIndex = 29;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lbConfirmar
            // 
            lbConfirmar.AutoSize = true;
            lbConfirmar.Location = new Point(303, 129);
            lbConfirmar.Name = "lbConfirmar";
            lbConfirmar.Size = new Size(127, 15);
            lbConfirmar.TabIndex = 27;
            lbConfirmar.Text = "Confirmar Contraseña:";
            // 
            // lbContraseña
            // 
            lbContraseña.AutoSize = true;
            lbContraseña.Location = new Point(356, 96);
            lbContraseña.Name = "lbContraseña";
            lbContraseña.Size = new Size(70, 15);
            lbContraseña.TabIndex = 26;
            lbContraseña.Text = "Contraseña:";
            // 
            // lbIntentos
            // 
            lbIntentos.AutoSize = true;
            lbIntentos.Location = new Point(356, 61);
            lbIntentos.Name = "lbIntentos";
            lbIntentos.Size = new Size(96, 15);
            lbIntentos.TabIndex = 25;
            lbIntentos.Text = "Intentos Fallidos:";
            // 
            // lbBloqueado
            // 
            lbBloqueado.AutoSize = true;
            lbBloqueado.Location = new Point(356, 26);
            lbBloqueado.Name = "lbBloqueado";
            lbBloqueado.Size = new Size(67, 15);
            lbBloqueado.TabIndex = 24;
            lbBloqueado.Text = "Bloqueado:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(303, 162);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 19);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "Usuario activo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(158, 122);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(121, 23);
            cbRol.TabIndex = 19;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(181, 89);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 18;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(170, 54);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 17;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(181, 19);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 16;
            // 
            // lbActivo
            // 
            lbActivo.AutoSize = true;
            lbActivo.Location = new Point(252, 163);
            lbActivo.Name = "lbActivo";
            lbActivo.Size = new Size(45, 15);
            lbActivo.TabIndex = 15;
            lbActivo.Text = "Estado:";
            // 
            // lbRol
            // 
            lbRol.AutoSize = true;
            lbRol.Location = new Point(125, 125);
            lbRol.Name = "lbRol";
            lbRol.Size = new Size(27, 15);
            lbRol.TabIndex = 14;
            lbRol.Text = "Rol:";
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.Location = new Point(125, 92);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(56, 15);
            lbTelefono.TabIndex = 13;
            lbTelefono.Text = "Telefono:";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(125, 57);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(39, 15);
            lbEmail.TabIndex = 12;
            lbEmail.Text = "Email:";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(125, 22);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 15);
            lbUsuario.TabIndex = 11;
            lbUsuario.Text = "Usuario:";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 41);
            panel1.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.Dock = DockStyle.Fill;
            lbTitulo.Font = new Font("Segoe UI", 20F);
            lbTitulo.Location = new Point(0, 0);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(786, 41);
            lbTitulo.TabIndex = 1;
            lbTitulo.Text = "Cuenta de..";
            lbTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbNotasAdmin
            // 
            tbNotasAdmin.Controls.Add(rtbDetalles);
            tbNotasAdmin.Location = new Point(4, 24);
            tbNotasAdmin.Name = "tbNotasAdmin";
            tbNotasAdmin.Padding = new Padding(3);
            tbNotasAdmin.Size = new Size(792, 422);
            tbNotasAdmin.TabIndex = 1;
            tbNotasAdmin.Text = "Notas Admin";
            tbNotasAdmin.UseVisualStyleBackColor = true;
            // 
            // rtbDetalles
            // 
            rtbDetalles.Dock = DockStyle.Fill;
            rtbDetalles.Location = new Point(3, 3);
            rtbDetalles.Name = "rtbDetalles";
            rtbDetalles.Size = new Size(786, 416);
            rtbDetalles.TabIndex = 0;
            rtbDetalles.Text = "";
            // 
            // FrmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmUsuario";
            Text = "Datos Usuario";
            tbControl.ResumeLayout(false);
            tbDatos.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            grb.ResumeLayout(false);
            grb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudIntentos).EndInit();
            panel1.ResumeLayout(false);
            tbNotasAdmin.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbControl;
        private TabPage tbDatos;
        private TabPage tbNotasAdmin;
        private RichTextBox rtbDetalles;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Label lbTitulo;
        private GroupBox grb;
        private TextBox txtConfirmar;
        private NumericUpDown nudIntentos;
        private CheckBox cbCuenta;
        private TextBox txtContrasena;
        private Label lbConfirmar;
        private Label lbContraseña;
        private Label lbIntentos;
        private Label lbBloqueado;
        private CheckBox checkBox1;
        private ComboBox cbRol;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtUsuario;
        private Label lbActivo;
        private Label lbRol;
        private Label lbTelefono;
        private Label lbEmail;
        private Label lbUsuario;
        private GroupBox groupBox1;
        private Label lbUltimaIP;
        private Label lbUltimoAcctxt;
        private Label lbUltimaIPtxt;
        private Label lbFechaAltatxt;
        private Label lbUltimoAcc;
        private Label lbFechaAlta;
        private Button btnCancelar;
        private Button btnAceptar;
    }
}