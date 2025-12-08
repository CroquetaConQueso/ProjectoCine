using AplicacionCine.Formularios;
using AplicacionCine.Modelos;
using System;
using System.Windows.Forms;

namespace AplicacionCine
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            Load += FrmLogin_Load;
            FormClosed += FrmLogin_FormClosed;
            btnEntrar.Click += btnEntrar_Click;
        }

        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private void btnEntrar_Click(object? sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            var pass = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Introduce usuario y contraseña.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Logueamos SIEMPRE contra la tabla USUARIOS
            var usuario = AppContext.Usuarios.GetByLogin(login);

            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado o credenciales incorrectas.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // De momento password en texto plano
            if (!string.Equals(usuario.PasswordHash, pass))
            {
                MessageBox.Show("Usuario no encontrado o credenciales incorrectas.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!usuario.Activo || usuario.Bloqueado)
            {
                MessageBox.Show("El usuario está inactivo o bloqueado.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Login correcto: guardamos el usuario REAL con su IdUsuario
            AppContext.UsuarioActual = usuario;

            var frm = new FrmPrincipal();
            frm.Show();

            Hide();
        }

        private void FrmLogin_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
    }
}
