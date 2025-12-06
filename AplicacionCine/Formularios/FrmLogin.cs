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
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Opcional: limpiar campos al cargar
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            var pass = txtContrasena.Text; // DE MOMENTO sin hash

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Introduce usuario y contraseña.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos el usuario por login
            var usuario = AppContext.Usuarios.GetByLogin(login);

            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado o credenciales incorrectas.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // De momento comparamos el texto plano con HashPassword (luego lo cambias a hash real)
            if (!string.Equals(usuario.HashPassword, pass))
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

            // Login correcto
            AppContext.UsuarioActual = usuario;

            var frm = new FrmPrincipal();
            frm.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opcional: si se cierra el form de login, cerrar la app
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
