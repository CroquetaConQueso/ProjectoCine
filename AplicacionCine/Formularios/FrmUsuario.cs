using System;
using System.Windows.Forms;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    /// <summary>
    /// Formulario de alta/edición de un usuario del sistema.
    /// Trabaja sobre una instancia de Usuario recibida desde fuera.
    /// </summary>
    public partial class FrmUsuario : Form
    {
        /// <summary>
        /// Usuario que se está creando o editando.
        /// </summary>
        private Usuario _usuario;

        /// <summary>
        /// Indica si el formulario está en modo alta (true) o edición (false).
        /// </summary>
        private bool _esNuevo;

        /// <summary>
        /// Constructor usado por el diseñador.
        /// En ejecución normal se utiliza el constructor que recibe Usuario.
        /// </summary>
        public FrmUsuario()
        {
            InitializeComponent();
            TemaCine.Aplicar(this);

            // Usuario base para diseño o alta directa desde este formulario.
            _usuario = new Usuario
            {
                Activo = true,
                Bloqueado = false,
                FechaAlta = DateTime.Now,
                Rol = RolUsuario.Empleado,
                IntentosFallidos = 0
            };
            _esNuevo = true;

            InicializarEventos();
        }

        /// <summary>
        /// Constructor principal: recibe el usuario a editar o crear.
        /// Si IdUsuario == 0 se considera alta; en caso contrario, edición.
        /// </summary>
        /// <param name="usuario">Instancia de Usuario sobre la que se trabajará.</param>
        public FrmUsuario(Usuario usuario) : this()
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _esNuevo = _usuario.IdUsuario == 0;
        }

        /// <summary>
        /// Asocia los manejadores de eventos básicos del formulario.
        /// </summary>
        private void InicializarEventos()
        {
            Load += FrmUsuario_Load;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        /// <summary>
        /// Carga inicial del formulario: rellena controles desde el Usuario
        /// y ajusta valores por defecto (fechas, roles, intentos, título).
        /// </summary>
        private void FrmUsuario_Load(object? sender, EventArgs e)
        {
            // Aseguramos una FechaAlta razonable
            if (_usuario.FechaAlta == default)
                _usuario.FechaAlta = DateTime.Now;

            // Combo de roles
            cbRol.Items.Clear();
            foreach (RolUsuario rol in Enum.GetValues(typeof(RolUsuario)))
                cbRol.Items.Add(rol);

            // Rellenar controles desde el objeto
            txtUsuario.Text = _usuario.Login ?? string.Empty;
            txtEmail.Text = _usuario.Email ?? string.Empty;
            txtTelefono.Text = _usuario.Telefono ?? string.Empty;

            // Rol seleccionado
            if (cbRol.Items.Contains(_usuario.Rol))
                cbRol.SelectedItem = _usuario.Rol;
            else if (cbRol.Items.Count > 0)
                cbRol.SelectedIndex = 0;

            // Intentos fallidos (respetando límites del NumericUpDown)
            int intentos = _usuario.IntentosFallidos;
            if (intentos < nudIntentos.Minimum) intentos = (int)nudIntentos.Minimum;
            if (intentos > nudIntentos.Maximum) intentos = (int)nudIntentos.Maximum;
            nudIntentos.Value = intentos;

            // Activo / Bloqueado
            checkBox1.Checked = _usuario.Activo;
            cbCuenta.Checked = _usuario.Bloqueado;

            // Notas del administrador
            rtbDetalles.Text = _usuario.NotasAdmin ?? string.Empty;

            // Info de fechas e IP
            lbFechaAltatxt.Text = _usuario.FechaAlta.ToString("g");
            lbUltimoAcctxt.Text = _usuario.FechaUltimoAcceso?.ToString("g") ?? "(nunca)";
            lbUltimaIPtxt.Text = string.IsNullOrEmpty(_usuario.UltimaIp) ? "-" : _usuario.UltimaIp;

            // Password:
            // - Alta: campos vacíos, se obliga a introducir una nueva.
            // - Edición: mostramos la contraseña actual (en este proyecto se guarda en claro),
            //   para que el reset desde el brow sea coherente con este formulario.
            if (_esNuevo)
            {
                txtContrasena.Text = string.Empty;
                txtConfirmar.Text = string.Empty;
            }
            else
            {
                var actual = _usuario.PasswordHash ?? string.Empty;
                txtContrasena.Text = actual;
                txtConfirmar.Text = actual;
            }

            // Título del formulario
            Text = _esNuevo
                ? "Nuevo usuario"
                : $"Editar usuario: {_usuario.Login}";
        }

        /// <summary>
        /// Valida los datos del formulario, vuelca los valores en el Usuario
        /// y, si todo es correcto, establece DialogResult.OK y cierra el formulario.
        /// </summary>
        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            // --- Validaciones básicas ---

            var login = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show(
                    "El login es obligatorio.",
                    "Usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (cbRol.SelectedItem is not RolUsuario rolSel)
            {
                MessageBox.Show(
                    "Selecciona un rol.",
                    "Usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cbRol.Focus();
                return;
            }

            var pass = txtContrasena.Text;
            var conf = txtConfirmar.Text;

            if (_esNuevo)
            {
                // Para altas, la contraseña es obligatoria
                if (string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(conf))
                {
                    MessageBox.Show(
                        "Para un nuevo usuario es obligatoria la contraseña y su confirmación.",
                        "Usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }

                if (pass != conf)
                {
                    MessageBox.Show(
                        "Las contraseñas no coinciden.",
                        "Usuario",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtContrasena.Focus();
                    return;
                }

                _usuario.PasswordHash = pass;
            }
            else
            {
                // En modificación: solo cambiamos contraseña si hay algo escrito diferente
                // (si quisieras exigir que escriba de nuevo para cambiar, mantén esta lógica simple).
                if (!string.IsNullOrEmpty(pass) || !string.IsNullOrEmpty(conf))
                {
                    if (pass != conf)
                    {
                        MessageBox.Show(
                            "Las contraseñas no coinciden.",
                            "Usuario",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        txtContrasena.Focus();
                        return;
                    }

                    _usuario.PasswordHash = pass;
                }
            }

            // --- Volcar datos de los controles al objeto ---

            _usuario.Login = login;
            _usuario.Email = string.IsNullOrWhiteSpace(txtEmail.Text)
                ? null
                : txtEmail.Text.Trim();

            _usuario.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text)
                ? null
                : txtTelefono.Text.Trim();

            _usuario.Rol = rolSel;
            _usuario.IntentosFallidos = (int)nudIntentos.Value;

            _usuario.Activo = checkBox1.Checked;
            _usuario.Bloqueado = cbCuenta.Checked;

            _usuario.NotasAdmin = string.IsNullOrWhiteSpace(rtbDetalles.Text)
                ? null
                : rtbDetalles.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancela la edición, no aplica cambios en el Usuario
        /// y cierra el formulario con DialogResult.Cancel.
        /// </summary>
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
