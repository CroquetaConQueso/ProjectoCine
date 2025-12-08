using System;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmUsuario : Form
    {
        private Usuario _usuario;
        private bool _esNuevo;

        /// <summary>
        /// Constructor usado por el diseñador.
        /// En tiempo de ejecución normalmente usaremos el constructor que recibe Usuario.
        /// </summary>
        public FrmUsuario()
        {
            InitializeComponent();

            // Usuario “por defecto” para diseño o alta directa
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
        /// Constructor principal: recibe el usuario a editar / crear.
        /// Si IdUsuario == 0 lo trata como alta; si no, como modificación.
        /// </summary>
        public FrmUsuario(Usuario usuario) : this()
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            _esNuevo = _usuario.IdUsuario == 0;
        }

        private void InicializarEventos()
        {
            Load += FrmUsuario_Load;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

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
            // - Si es nuevo, pediremos que rellene contraseña.
            // - Si es existente, dejar vacío significa “no cambiar”.
            txtContrasena.Text = string.Empty;
            txtConfirmar.Text = string.Empty;

            // Título del formulario
            Text = _esNuevo
                ? "Nuevo usuario"
                : $"Editar usuario: {_usuario.Login}";
        }

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

                // Aquí podrías aplicar un hash real
                _usuario.PasswordHash = pass;
            }
            else
            {
                // En modificación: solo cambiamos contraseña si hay algo escrito
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
                // Si ambos están vacíos, se mantiene la contraseña actual
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

            // FechaAlta la dejamos como estaba (la fijamos en el Load si venía por defecto).

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
