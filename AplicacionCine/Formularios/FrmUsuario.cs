using System;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmUsuario : Form
    {
        private Usuario _usuario;
        private bool _esNuevo;

        public FrmUsuario()
        {
            InitializeComponent();
            _usuario = new Usuario
            {
                Activo = true,
                Bloqueado = false,
                FechaAlta = DateTime.Now,
                Rol = RolUsuario.Empleado
            };
            _esNuevo = true;
            InicializarEventos();
        }

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
            cbRol.Items.Clear();
            foreach (RolUsuario rol in Enum.GetValues(typeof(RolUsuario)))
                cbRol.Items.Add(rol);

            txtUsuario.Text = _usuario.Login;
            txtEmail.Text = _usuario.Email ?? "";
            txtTelefono.Text = _usuario.Telefono ?? "";
            cbRol.SelectedItem = _usuario.Rol;

            nudIntentos.Value = _usuario.IntentosFallidos >= nudIntentos.Minimum &&
                                _usuario.IntentosFallidos <= nudIntentos.Maximum
                ? _usuario.IntentosFallidos
                : 0;

            checkBox1.Checked = _usuario.Activo;
            cbCuenta.Checked = _usuario.Bloqueado;
            rtbDetalles.Text = _usuario.NotasAdmin ?? "";

            lbFechaAltatxt.Text = _usuario.FechaAlta.ToString("g");
            lbUltimoAcctxt.Text = _usuario.FechaUltimoAcceso?.ToString("g") ?? "(nunca)";
            lbUltimaIPtxt.Text = string.IsNullOrEmpty(_usuario.UltimaIp) ? "-" : _usuario.UltimaIp;

            txtContrasena.Text = "";
            txtConfirmar.Text = "";
        }

        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            var login = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("El login es obligatorio.",
                    "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRol.SelectedItem is not RolUsuario rolSel)
            {
                MessageBox.Show("Selecciona un rol.",
                    "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pass = txtContrasena.Text;
            var conf = txtConfirmar.Text;
            if (!string.IsNullOrEmpty(pass) || !string.IsNullOrEmpty(conf))
            {
                if (pass != conf)
                {
                    MessageBox.Show("Las contraseñas no coinciden.",
                        "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _usuario.PasswordHash = pass;
            }

            _usuario.Login = login;
            _usuario.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            _usuario.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();
            _usuario.Rol = rolSel;
            _usuario.IntentosFallidos = (int)nudIntentos.Value;
            _usuario.Activo = checkBox1.Checked;
            _usuario.Bloqueado = cbCuenta.Checked;
            _usuario.NotasAdmin = string.IsNullOrWhiteSpace(rtbDetalles.Text) ? null : rtbDetalles.Text;

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
