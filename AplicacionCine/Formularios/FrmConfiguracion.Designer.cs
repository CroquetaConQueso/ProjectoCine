namespace AplicacionCine.Formularios
{
    partial class FrmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            pnTotal = new Panel();
            panel2 = new Panel();
            statusStrip1 = new StatusStrip();
            tslConfigEstado = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            button2 = new Button();
            btnProbar = new Button();
            lbCadena = new Label();
            txtContrasena = new TextBox();
            lbContrasena = new Label();
            txtUsuario = new TextBox();
            lbUsuario = new Label();
            txtBaseDatos = new TextBox();
            lbBaseDatos = new Label();
            txtServidor = new TextBox();
            lbServidor = new Label();
            panel1 = new Panel();
            lbTitulo = new Label();
            pnTotal.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(panel2);
            pnTotal.Controls.Add(groupBox1);
            pnTotal.Controls.Add(panel1);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(680, 450);
            pnTotal.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(statusStrip1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 421);
            panel2.Name = "panel2";
            panel2.Size = new Size(680, 29);
            panel2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Fill;
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslConfigEstado });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(680, 29);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslConfigEstado
            // 
            tslConfigEstado.Margin = new Padding(10, 3, 0, 2);
            tslConfigEstado.Name = "tslConfigEstado";
            tslConfigEstado.Size = new Size(121, 24);
            tslConfigEstado.Text = "Estado Configuración";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(btnProbar);
            groupBox1.Controls.Add(lbCadena);
            groupBox1.Controls.Add(txtContrasena);
            groupBox1.Controls.Add(lbContrasena);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(lbUsuario);
            groupBox1.Controls.Add(txtBaseDatos);
            groupBox1.Controls.Add(lbBaseDatos);
            groupBox1.Controls.Add(txtServidor);
            groupBox1.Controls.Add(lbServidor);
            groupBox1.Location = new Point(115, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(454, 334);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 222);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(312, 62);
            textBox1.TabIndex = 12;
            // 
            // button2
            // 
            button2.Location = new Point(369, 297);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnProbar
            // 
            btnProbar.Location = new Point(278, 297);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(75, 23);
            btnProbar.TabIndex = 10;
            btnProbar.Text = "Probar";
            btnProbar.UseVisualStyleBackColor = true;
            // 
            // lbCadena
            // 
            lbCadena.AutoSize = true;
            lbCadena.Location = new Point(66, 205);
            lbCadena.Name = "lbCadena";
            lbCadena.Size = new Size(100, 15);
            lbCadena.TabIndex = 8;
            lbCadena.Text = "Cadena Conexión";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(134, 162);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(144, 23);
            txtContrasena.TabIndex = 7;
            // 
            // lbContrasena
            // 
            lbContrasena.AutoSize = true;
            lbContrasena.Location = new Point(55, 165);
            lbContrasena.Name = "lbContrasena";
            lbContrasena.Size = new Size(70, 15);
            lbContrasena.TabIndex = 6;
            lbContrasena.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(134, 123);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(144, 23);
            txtUsuario.TabIndex = 5;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(66, 126);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 15);
            lbUsuario.TabIndex = 4;
            lbUsuario.Text = "Usuario:";
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Location = new Point(134, 77);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(209, 23);
            txtBaseDatos.TabIndex = 3;
            // 
            // lbBaseDatos
            // 
            lbBaseDatos.AutoSize = true;
            lbBaseDatos.Location = new Point(42, 80);
            lbBaseDatos.Name = "lbBaseDatos";
            lbBaseDatos.Size = new Size(82, 15);
            lbBaseDatos.TabIndex = 2;
            lbBaseDatos.Text = "Base de datos:";
            // 
            // txtServidor
            // 
            txtServidor.Location = new Point(134, 33);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(144, 23);
            txtServidor.TabIndex = 1;
            // 
            // lbServidor
            // 
            lbServidor.AutoSize = true;
            lbServidor.Location = new Point(66, 36);
            lbServidor.Name = "lbServidor";
            lbServidor.Size = new Size(53, 15);
            lbServidor.TabIndex = 0;
            lbServidor.Text = "Servidor:";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbTitulo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(680, 46);
            panel1.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.Dock = DockStyle.Fill;
            lbTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbTitulo.Location = new Point(0, 0);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(680, 46);
            lbTitulo.TabIndex = 0;
            lbTitulo.Text = "Configuración de la base de datos";
            lbTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmConfiguracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 450);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmConfiguracion";
            Text = "Configuración";
            pnTotal.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label lbTitulo;
        private Label lbCadena;
        private TextBox txtContrasena;
        private Label lbContrasena;
        private TextBox txtUsuario;
        private Label lbUsuario;
        private TextBox txtBaseDatos;
        private Label lbBaseDatos;
        private TextBox txtServidor;
        private Label lbServidor;
        private Button button2;
        private Button btnProbar;
        private Panel panel2;
        private StatusStrip statusStrip1;
        private TextBox textBox1;
        private ToolStripStatusLabel tslConfigEstado;
    }
}