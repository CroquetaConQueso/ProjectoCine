using AplicacionCine.Formularios;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;
using System;
using System.Windows.Forms;

namespace AplicacionCine
{
    /// <summary>
    /// Formulario de inicio de sesión de la aplicación.
    /// Valida las credenciales y, si son correctas, abre la ventana principal.
    /// </summary>
    public partial class FrmLogin : Form
    {
        /// <summary>
        /// Constructor: inicializa el formulario, aplica el tema
        /// y registra los manejadores de eventos básicos.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            TemaCine.Aplicar(this);

            // Aspecto y comportamiento de la ventana
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;

            // Permite lanzar el login con Enter
            AcceptButton = btnEntrar;

            // Eventos de ciclo de vida
            Load += FrmLogin_Load;
            FormClosed += FrmLogin_FormClosed;

            // Evento del botón de acceso
            btnEntrar.Click += btnEntrar_Click;
        }

        /// <summary>
        /// Al cargar el formulario: limpia campos y sitúa el foco en el usuario.
        /// </summary>
        private void FrmLogin_Load(object? sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtUsuario.Focus();
        }

        /// <summary>
        /// Valida credenciales:
        /// - Comprueba que haya usuario y contraseña.
        /// - Busca el usuario en BD.
        /// - Verifica contraseña, estado activo y bloqueo.
        /// Si todo es correcto, guarda el usuario en AppContext y abre FrmPrincipal.
        /// </summary>
        private void btnEntrar_Click(object? sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            var pass = txtContrasena.Text;

            // Validación rápida de campos vacíos
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show(
                    "Introduce usuario y contraseña.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Búsqueda de usuario por login
            var usuario = AppContext.Usuarios.GetByLogin(login);

            // Usuario inexistente o contraseña incorrecta
            if (usuario == null || !string.Equals(usuario.PasswordHash, pass))
            {
                MessageBox.Show(
                    "Usuario no encontrado o credenciales incorrectas.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Comprobamos estado lógico del usuario
            if (!usuario.Activo || usuario.Bloqueado)
            {
                MessageBox.Show(
                    "El usuario está inactivo o bloqueado.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Guardamos el usuario activo en el contexto global
            AppContext.UsuarioActual = usuario;

            // Abrimos la ventana principal MDI y ocultamos el login
            var frm = new FrmPrincipal();
            frm.Show();

            Hide();
        }

        /// <summary>
        /// Si se cierra el formulario de login y no quedan más ventanas abiertas,
        /// se cierra la aplicación completa.
        /// </summary>
        private void FrmLogin_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        /// <summary>
        /// Mantenido solo porque el diseñador tiene asociado el evento Click.
        /// No realiza ninguna acción.
        /// </summary>
        private void lbUsuario_Click(object sender, EventArgs e)
        {
            // Intencionadamente vacío.
        }
    }
}
