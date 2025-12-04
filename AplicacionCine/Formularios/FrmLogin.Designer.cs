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
            pnTop = new Panel();
            lbTitulo = new Label();
            pictureBox1 = new PictureBox();
            lbUsuario = new Label();
            txtUsuario = new TextBox();
            lbContrasena = new Label();
            txtContrasena = new TextBox();
            btnEntrar = new Button();
            pnTotal.SuspendLayout();
            pnBot.SuspendLayout();
            pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnTotal
            // 
            pnTotal.Controls.Add(pnBot);
            pnTotal.Controls.Add(pnTop);
            pnTotal.Dock = DockStyle.Fill;
            pnTotal.Location = new Point(0, 0);
            pnTotal.Name = "pnTotal";
            pnTotal.Size = new Size(800, 450);
            pnTotal.TabIndex = 0;
            // 
            // pnBot
            // 
            pnBot.Controls.Add(btnEntrar);
            pnBot.Controls.Add(txtContrasena);
            pnBot.Controls.Add(lbContrasena);
            pnBot.Controls.Add(txtUsuario);
            pnBot.Controls.Add(lbUsuario);
            pnBot.Dock = DockStyle.Fill;
            pnBot.Location = new Point(0, 49);
            pnBot.Name = "pnBot";
            pnBot.Size = new Size(800, 401);
            pnBot.TabIndex = 1;
            // 
            // pnTop
            // 
            pnTop.Controls.Add(pictureBox1);
            pnTop.Controls.Add(lbTitulo);
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(800, 49);
            pnTop.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.AutoSize = true;
            lbTitulo.Location = new Point(360, 16);
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(62, 15);
            lbTitulo.TabIndex = 0;
            lbTitulo.Text = "CINE FEED";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(24, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(296, 96);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 15);
            lbUsuario.TabIndex = 2;
            lbUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(360, 92);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario...";
            txtUsuario.Size = new Size(152, 23);
            txtUsuario.TabIndex = 3;
            // 
            // lbContrasena
            // 
            lbContrasena.AutoSize = true;
            lbContrasena.Location = new Point(280, 152);
            lbContrasena.Name = "lbContrasena";
            lbContrasena.Size = new Size(70, 15);
            lbContrasena.TabIndex = 4;
            lbContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(360, 148);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PlaceholderText = "Contraseña..";
            txtContrasena.Size = new Size(152, 23);
            txtContrasena.TabIndex = 5;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(360, 240);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(75, 23);
            btnEntrar.TabIndex = 6;
            btnEntrar.Text = "Enviar";
            btnEntrar.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnTotal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLogin";
            Text = "Login";
            pnTotal.ResumeLayout(false);
            pnBot.ResumeLayout(false);
            pnBot.PerformLayout();
            pnTop.ResumeLayout(false);
            pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTotal;
        private Panel pnBot;
        private Panel pnTop;
        private Label lbTitulo;
        private Label lbUsuario;
        private PictureBox pictureBox1;
        private Button btnEntrar;
        private TextBox txtContrasena;
        private Label lbContrasena;
        private TextBox txtUsuario;
    }
}
