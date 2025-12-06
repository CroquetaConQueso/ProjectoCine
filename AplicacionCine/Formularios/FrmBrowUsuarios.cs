using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmBrowUsuarios : Form
    {
        private readonly BindingSource _bsUsuarios = new BindingSource();
        private List<Usuario> _listaCompleta = new List<Usuario>();

        public FrmBrowUsuarios()
        {
            InitializeComponent();

            Load += FrmBrowUsuarios_Load;

            tsbtBuscar.Click += TsbtBuscar_Click;
            tsbtLimpiar.Click += TsbtLimpiar_Click;
            tsbtNuevo.Click += TsbtNuevo_Click;
            tsbtModificar.Click += TsbtModificar_Click;
            tsbtEliminar.Click += TsbtEliminar_Click;
            tsbtResetPass.Click += TsbtResetPass_Click;
            tsbtRefrescar.Click += TsbtRefrescar_Click;

            dvgUsuarios.AutoGenerateColumns = true;
            dvgUsuarios.DataSource = _bsUsuarios;
            dvgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUsuarios.MultiSelect = false;
            dvgUsuarios.ReadOnly = true;
            dvgUsuarios.DoubleClick += DvgUsuarios_DoubleClick;
        }

        private void FrmBrowUsuarios_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarUsuarios();
            ActualizarEstadoUsuario();
        }

        private void CargarCombos()
        {
            tscbRol.Items.Clear();
            tscbRol.Items.Add("(Todos)");
            foreach (RolUsuario rol in Enum.GetValues(typeof(RolUsuario)))
                tscbRol.Items.Add(rol);
            tscbRol.SelectedIndex = 0;

            tscbEstado.Items.Clear();
            tscbEstado.Items.Add("(Todos)");
            tscbEstado.Items.Add("Activos");
            tscbEstado.Items.Add("Inactivos");
            tscbEstado.Items.Add("Bloqueados");
            tscbEstado.SelectedIndex = 0;
        }

        private void ActualizarEstadoUsuario()
        {
            var u = AppContext.UsuarioActual;
            if (u == null)
            {
                tslUsuario.Text = "(sin sesión)";
                tslRol.Text = "";
                tslEstado.Text = "Desconectado";
            }
            else
            {
                tslUsuario.Text = u.NombreUsuario;
                tslRol.Text = u.Rol.ToString();
                tslEstado.Text = "Listo";
            }
        }

        private void CargarUsuarios()
        {
            _listaCompleta = AppContext.Usuarios.GetAll();
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            IEnumerable<Usuario> query = _listaCompleta;

            var filtroUsuario = tstbUsuario.Text.Trim();
            if (!string.IsNullOrEmpty(filtroUsuario))
            {
                var f = filtroUsuario.ToLowerInvariant();
                query = query.Where(u =>
                    (u.Login ?? "").ToLowerInvariant().Contains(f) ||
                    (u.Email ?? "").ToLowerInvariant().Contains(f));
            }

            if (tscbRol.SelectedItem is RolUsuario rolSel)
                query = query.Where(u => u.Rol == rolSel);

            var estado = tscbEstado.SelectedItem as string;
            if (estado == "Activos")
                query = query.Where(u => u.Activo);
            else if (estado == "Inactivos")
                query = query.Where(u => !u.Activo);
            else if (estado == "Bloqueados")
                query = query.Where(u => u.Bloqueado);

            var lista = query.ToList();
            _bsUsuarios.DataSource = new BindingList<Usuario>(lista);
        }

        private Usuario? GetUsuarioActual()
        {
            return _bsUsuarios.Current as Usuario;
        }

        private void TsbtBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void TsbtLimpiar_Click(object? sender, EventArgs e)
        {
            tstbUsuario.Text = "";
            tscbRol.SelectedIndex = 0;
            tscbEstado.SelectedIndex = 0;
            AplicarFiltro();
        }

        private void TsbtRefrescar_Click(object? sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void TsbtNuevo_Click(object? sender, EventArgs e)
        {
            var u = new Usuario
            {
                Activo = true,
                Bloqueado = false,
                FechaAlta = DateTime.Now,
                Rol = RolUsuario.Empleado,
                PasswordHash = "1234"
            };

            using var frm = new FrmUsuario(u);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                AppContext.Usuarios.Insert(u);
                CargarUsuarios();
            }
        }

        private void TsbtModificar_Click(object? sender, EventArgs e)
        {
            var u = GetUsuarioActual();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmUsuario(u);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                AppContext.Usuarios.Update(u);
                CargarUsuarios();
            }
            else
            {
                CargarUsuarios();
            }
        }

        private void TsbtEliminar_Click(object? sender, EventArgs e)
        {
            var u = GetUsuarioActual();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"¿Marcar como inactivo al usuario '{u.Login}'?",
                "Usuarios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            u.Activo = false;
            AppContext.Usuarios.Update(u);
            CargarUsuarios();
        }

        private void TsbtResetPass_Click(object? sender, EventArgs e)
        {
            var u = GetUsuarioActual();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"¿Reiniciar la contraseña de '{u.Login}' a '1234'?",
                "Usuarios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            u.PasswordHash = "1234";
            AppContext.Usuarios.Update(u);
            MessageBox.Show("Contraseña reiniciada a '1234'.",
                "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DvgUsuarios_DoubleClick(object? sender, EventArgs e)
        {
            TsbtModificar_Click(sender, e);
        }
    }
}
