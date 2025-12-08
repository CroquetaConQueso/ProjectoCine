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

            // Bloquear maximizar y tamaño variable
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Load += FrmBrowUsuarios_Load;

            tsbtBuscar.Click += TsbtBuscar_Click;
            tsbtLimpiar.Click += TsbtLimpiar_Click;
            tsbtNuevo.Click += TsbtNuevo_Click;
            tsbtModificar.Click += TsbtModificar_Click;
            tsbtEliminar.Click += TsbtEliminar_Click;
            tsbtResetPass.Click += TsbtResetPass_Click;
            tsbtRefrescar.Click += TsbtRefrescar_Click;

            // Enlazamos el grid a la BindingSource
            dvgUsuarios.AutoGenerateColumns = false;
            dvgUsuarios.DataSource = _bsUsuarios;

            dvgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUsuarios.MultiSelect = false;
            dvgUsuarios.ReadOnly = true;
            dvgUsuarios.AllowUserToAddRows = false;
            dvgUsuarios.AllowUserToDeleteRows = false;
            dvgUsuarios.DoubleClick += DvgUsuarios_DoubleClick;
            dvgUsuarios.SelectionChanged += DvgUsuarios_SelectionChanged;

            ConfigurarGrid();
        }

        #region Configuración grid

        private void ConfigurarGrid()
        {
            dvgUsuarios.Columns.Clear();

            // Id
            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Usuario.IdUsuario),
                HeaderText = "Id",
                Width = 50,
                ReadOnly = true
            });

            // Login
            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Usuario.Login),
                HeaderText = "Usuario",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Rol
            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Usuario.Rol),
                HeaderText = "Rol",
                Width = 90,
                ReadOnly = true
            });

            // Activo
            dvgUsuarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(Usuario.Activo),
                HeaderText = "Activo",
                Width = 60,
                ReadOnly = true
            });

            // Bloqueado
            dvgUsuarios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(Usuario.Bloqueado),
                HeaderText = "Bloq.",
                Width = 60,
                ReadOnly = true
            });

            // Intentos fallidos
            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Usuario.IntentosFallidos),
                HeaderText = "Intentos",
                Width = 70,
                ReadOnly = true
            });

            // Fecha alta
            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Usuario.FechaAlta),
                HeaderText = "Fecha alta",
                Width = 120,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy"
                }
            });
        }

        #endregion

        #region Carga inicial

        private void FrmBrowUsuarios_Load(object? sender, EventArgs e)
        {
            CargarCombos();
            CargarUsuarios();
        }

        private void CargarCombos()
        {
            // Combo de roles
            tscbRol.Items.Clear();
            tscbRol.Items.Add("(Todos)");
            foreach (RolUsuario rol in Enum.GetValues(typeof(RolUsuario)))
            {
                tscbRol.Items.Add(rol);
            }
            tscbRol.SelectedIndex = 0;

            // Combo de estado (mapea a Activo / Bloqueado)
            tscbEstado.Items.Clear();
            tscbEstado.Items.Add("(Todos)");        // 0
            tscbEstado.Items.Add("Activos");        // 1 -> Activo = true
            tscbEstado.Items.Add("Inactivos");      // 2 -> Activo = false
            tscbEstado.Items.Add("Bloqueados");     // 3 -> Bloqueado = true
            tscbEstado.Items.Add("No bloqueados");  // 4 -> Bloqueado = false
            tscbEstado.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            _listaCompleta = AppContext.Usuarios.GetAll();
            AplicarFiltro();
        }

        #endregion

        #region Filtro

        private void AplicarFiltro()
        {
            IEnumerable<Usuario> query = _listaCompleta;

            // Texto de usuario (login)
            var textoUsuario = tstbUsuario.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(textoUsuario))
            {
                query = query.Where(u =>
                    u.Login.Contains(textoUsuario, StringComparison.OrdinalIgnoreCase));
            }

            // Rol
            if (tscbRol.SelectedIndex > 0)
            {
                var rolSeleccionado = (RolUsuario)tscbRol.SelectedItem!;
                query = query.Where(u => u.Rol == rolSeleccionado);
            }

            // Estado (activo / bloqueado)
            bool? activo = null;
            bool? bloqueado = null;

            switch (tscbEstado.SelectedIndex)
            {
                case 1: // Activos
                    activo = true;
                    break;
                case 2: // Inactivos
                    activo = false;
                    break;
                case 3: // Bloqueados
                    bloqueado = true;
                    break;
                case 4: // No bloqueados
                    bloqueado = false;
                    break;
            }

            if (activo.HasValue)
            {
                query = query.Where(u => u.Activo == activo.Value);
            }

            if (bloqueado.HasValue)
            {
                query = query.Where(u => u.Bloqueado == bloqueado.Value);
            }

            var lista = query
                .OrderBy(u => u.Login, StringComparer.OrdinalIgnoreCase)
                .ToList();

            _bsUsuarios.DataSource = new BindingList<Usuario>(lista);
            dvgUsuarios.ClearSelection();

            // Actualizar status strip (resumen, filtros, selección)
            ActualizarResumenYSeleccion(lista);
        }

        private Usuario? GetUsuarioSeleccionado()
        {
            return _bsUsuarios.Current as Usuario;
        }

        #endregion

        #region Botones ToolStrip

        private void TsbtBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void TsbtLimpiar_Click(object? sender, EventArgs e)
        {
            tstbUsuario.Text = string.Empty;
            tscbRol.SelectedIndex = 0;
            tscbEstado.SelectedIndex = 0;
            AplicarFiltro();
        }

        private void TsbtNuevo_Click(object? sender, EventArgs e)
        {
            var u = new Usuario
            {
                Activo = true,
                Bloqueado = false,
                Rol = RolUsuario.Empleado,
                FechaAlta = DateTime.Now,
                IntentosFallidos = 0
            };

            using var frm = new FrmUsuario(u);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Validar login duplicado (alta)
                if (AppContext.Usuarios.ExisteLogin(u.Login, null))
                {
                    MessageBox.Show(
                        "Ya existe otro usuario con ese login.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    CargarUsuarios();
                    return;
                }

                AppContext.Usuarios.Insert(u);
                CargarUsuarios();
            }
        }

        private void TsbtModificar_Click(object? sender, EventArgs e)
        {
            var u = GetUsuarioSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmUsuario(u);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Validar login duplicado (modificación)
                if (AppContext.Usuarios.ExisteLogin(u.Login, u.IdUsuario))
                {
                    MessageBox.Show(
                        "Ya existe otro usuario con ese login.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    CargarUsuarios();
                    return;
                }

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
            var u = GetUsuarioSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Evitar que el usuario actual se elimine a sí mismo
            if (AppContext.UsuarioActual != null &&
                AppContext.UsuarioActual.IdUsuario == u.IdUsuario)
            {
                MessageBox.Show(
                    "No puedes eliminar tu propio usuario mientras estás conectado.\n" +
                    "Inicia sesión con otra cuenta de administrador si realmente quieres borrarlo.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resp = MessageBox.Show(
                $"¿Eliminar el usuario '{u.Login}'?",
                "Usuarios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            AppContext.Usuarios.Delete(u.IdUsuario);
            CargarUsuarios();
        }

        private void TsbtResetPass_Click(object? sender, EventArgs e)
        {
            var u = GetUsuarioSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Selecciona un usuario.", "Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"¿Reiniciar la contraseña del usuario '{u.Login}' a '1234'?",
                "Usuarios",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            u.PasswordHash = "1234";
            AppContext.Usuarios.Update(u);

            MessageBox.Show("Contraseña reiniciada a '1234'.",
                "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TsbtRefrescar_Click(object? sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void DvgUsuarios_DoubleClick(object? sender, EventArgs e)
        {
            TsbtModificar_Click(sender, e);
        }

        #endregion

        #region StatusStrip (resumen + filtros + selección)

        /// <summary>
        /// Actualiza:
        /// - tslUsuariosResumen: resumen de cantidad (total / filtrados).
        /// - tslUsuariosFiltro: descripción del filtro actual.
        /// - tslUsuariosSeleccion: se delega en ActualizarSeleccion().
        /// </summary>
        private void ActualizarResumenYSeleccion(IList<Usuario> listaActual)
        {
            int total = _listaCompleta?.Count ?? 0;
            int filtrados = listaActual?.Count ?? 0;

            // Resumen cantidad
            if (total == 0)
            {
                tslUsuariosResumen.Text = "Usuarios: 0";
            }
            else if (total == filtrados)
            {
                tslUsuariosResumen.Text = $"Usuarios: {total} (sin filtro)";
            }
            else
            {
                tslUsuariosResumen.Text = $"Usuarios: {filtrados} de {total} (filtrados)";
            }

            // Resumen filtros
            var textoUsuario = tstbUsuario.Text?.Trim();
            string filtroUsuario = string.IsNullOrWhiteSpace(textoUsuario)
                ? "(cualquiera)"
                : $"'{textoUsuario}'";

            string filtroRol = tscbRol.SelectedIndex <= 0
                ? "(Todos)"
                : tscbRol.SelectedItem?.ToString() ?? "(Todos)";

            string filtroEstado = tscbEstado.SelectedIndex switch
            {
                1 => "Activos",
                2 => "Inactivos",
                3 => "Bloqueados",
                4 => "No bloqueados",
                _ => "(Todos)"
            };

            tslUsuariosFiltro.Text =
                $"Filtro → Usuario: {filtroUsuario} | Rol: {filtroRol} | Estado: {filtroEstado}";

            // Detalle de selección
            ActualizarSeleccion();
        }

        /// <summary>
        /// Actualiza tslUsuariosSeleccion según el usuario seleccionado.
        /// </summary>
        private void ActualizarSeleccion()
        {
            var u = GetUsuarioSeleccionado();
            if (u == null)
            {
                tslUsuariosSeleccion.Text = "Selección: (ningún usuario seleccionado)";
                return;
            }

            string estado;
            if (u.Bloqueado)
                estado = "Bloqueado";
            else if (u.Activo)
                estado = "Activo";
            else
                estado = "Inactivo";

            tslUsuariosSeleccion.Text =
                $"Selección: {u.Login} | Rol: {u.Rol} | Estado: {estado} | Intentos: {u.IntentosFallidos}";
        }

        private void DvgUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            ActualizarSeleccion();
        }

        #endregion
    }
}
