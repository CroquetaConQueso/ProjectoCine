namespace AplicacionCine
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnTotal = new Panel();
            pnBot = new Panel();
            btnEntrar = new Button();
            txtContrasena = new TextBox();
            lbContrasena = new Label();
            txtUsuario = new TextBox();
            lbUsuario = new Label();
            pictureBox1 = new PictureBox();
            pnTotal.SuspendLayout();
            pnBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnBot);
            pnTotal.Controls.Add(pictureBox1);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(768, 428);
            pnTotal.TabIndex = 0;
            // 
            // pnBot
            // 
            pnBot.Controls.Add(btnEntrar);
            pnBot.Controls.Add(txtContrasena);
            pnBot.Controls.Add(lbContrasena);
            pnBot.Controls.Add(txtUsuario);
            pnBot.Controls.Add(lbUsuario);
            pnBot.Location = new Point(233, 107);
            pnBot.Name = "pnBot";
            pnBot.Size = new Size(295, 212);
            pnBot.TabIndex = 0;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(110, 167);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 5;
            btnEntrar.Text = "Enviar";
            btnEntrar.UseVisualStyleBackColor = true;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(95, 114);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(151, 23);
            txtContrasena.TabIndex = 4;
            // 
            // lbContrasena
            // 
            lbContrasena.Location = new Point(6, 112);
            lbContrasena.Name = "lbContrasena";
            lbContrasena.Size = new Size(100, 23);
            lbContrasena.TabIndex = 3;
            lbContrasena.Text = "Contraseña:";
            lbContrasena.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(95, 53);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(151, 23);
            txtUsuario.TabIndex = 1;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(32, 60);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 15);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = "Usuario:";
            lbUsuario.Click += lbUsuario_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(768, 428);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 428);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            Text = "Login";
            pnTotal.ResumeLayout(false);
            pnBot.ResumeLayout(false);
            pnBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnBot;
        private Label lbUsuario;
        private Button btnEntrar;
        private TextBox txtContrasena;
        private Label lbContrasena;
        private TextBox txtUsuario;
        private PictureBox pictureBox1;
    }
}
