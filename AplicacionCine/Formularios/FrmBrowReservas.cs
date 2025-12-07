using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmBrowReservas : Form
    {
        #region Campos

        private readonly BindingSource _bsReservas = new BindingSource();
        private List<Reserva> _todasReservas = new List<Reserva>();

        #endregion

        #region Constructor

        public FrmBrowReservas()
        {
            InitializeComponent();

            Load += FrmBrowReservas_Load;

            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnMapa.Click += BtnMapa_Click;
            btnCerrar.Click += (s, e) => Close();

            dvgUsuarios.DoubleClick += DvgUsuarios_DoubleClick;
        }

        #endregion

        #region Carga inicial

        private void FrmBrowReservas_Load(object? sender, EventArgs e)
        {
            if (AppContext.UsuarioActual != null)
            {
                tsLnombreUsuario.Text = "Usuario:";
                tsLusuario.Text = AppContext.UsuarioActual.NombreUsuario;
            }
            else
            {
                tsLnombreUsuario.Text = "Usuario:";
                tsLusuario.Text = "(no conectado)";
            }

            tslEstado.Text = "Listo";
            tsLsituacion.Text = string.Empty;

            dateTimePicker1.Value = DateTime.Today;

            cbEstado.Items.Clear();
            cbEstado.Items.Add("(Todos)");
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Confirmada");
            cbEstado.Items.Add("Cancelada");
            cbEstado.SelectedIndex = 0;

            cbPeliculas.Items.Clear();
            cbPeliculas.Items.Add("(Todas)");
            cbPeliculas.SelectedIndex = 0;

            ConfigurarGrid();

            dvgUsuarios.DataSource = _bsReservas;

            Recargar();
        }

        private void ConfigurarGrid()
        {
            dvgUsuarios.AutoGenerateColumns = false;
            dvgUsuarios.Columns.Clear();

            dvgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUsuarios.MultiSelect = false;
            dvgUsuarios.ReadOnly = true;
            dvgUsuarios.RowHeadersVisible = false;

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdReserva",
                HeaderText = "Id",
                Width = 60
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaReserva",
                HeaderText = "Fecha",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "g" }
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdPase",
                HeaderText = "Pase",
                Width = 80
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "Usuario",
                Width = 80
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 100
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.00 €"
                }
            });
        }

        #endregion

        #region Carga / filtro

        private void Recargar()
        {
            tslEstado.Text = "Cargando...";
            tsLsituacion.Text = string.Empty;

            // Cargamos TODAS las reservas desde la BD (sin filtro por fecha aquí).
            _todasReservas = AppContext.Reservas.GetAll();

            var lista = AplicarFiltros(_todasReservas);

            _bsReservas.DataSource = lista;

            tslEstado.Text = "Listo";
            tsLsituacion.Text = $"{lista.Count} reservas encontradas";
        }

        private List<Reserva> AplicarFiltros(List<Reserva> origen)
        {
            var lista = origen;

            // Filtro por estado (opcional)
            if (cbEstado.SelectedIndex > 0)
            {
                var estadoFiltro = cbEstado.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(estadoFiltro))
                {
                    lista = lista
                        .Where(r => r.Estado.ToString()
                            .Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }
            }

            // De momento ignoramos cbPeliculas y txtFiltroUsuario
            // hasta que tengamos un DTO o joins preparados.

            return lista
                .OrderByDescending(r => r.FechaReserva)
                .ThenByDescending(r => r.IdReserva)
                .ToList();
        }

        #endregion

        #region Botones de filtro

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            if (_todasReservas == null || _todasReservas.Count == 0)
                Recargar();
            else
            {
                var lista = AplicarFiltros(_todasReservas);
                _bsReservas.DataSource = lista;
                tsLsituacion.Text = $"{lista.Count} reservas encontradas";
            }
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            if (cbPeliculas.Items.Count > 0) cbPeliculas.SelectedIndex = 0;
            if (cbEstado.Items.Count > 0) cbEstado.SelectedIndex = 0;
            txtFiltroUsuario.Clear();

            Recargar();
        }

        #endregion

        #region Utilidades

        private Reserva? GetReservaSeleccionada()
        {
            return _bsReservas.Current as Reserva;
        }

        #endregion

        #region CRUD / mapa (pendiente de implementar con DAO completo)

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            // TODO: abrir formulario de edición/alta de reserva y tras guardar llamar a Recargar()
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            var r = GetReservaSeleccionada();
            if (r == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: abrir formulario de edición y al aceptar, Recargar()
        }

        private void DvgUsuarios_DoubleClick(object? sender, EventArgs e)
        {
            BtnEditar_Click(sender, e);
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var r = GetReservaSeleccionada();
            if (r == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resp = MessageBox.Show(
                "¿Eliminar la reserva seleccionada?",
                "Reservas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            // TODO: AppContext.Reservas.DeleteReserva(r.IdReserva);
            Recargar();
        }

        private void BtnMapa_Click(object? sender, EventArgs e)
        {
            var r = GetReservaSeleccionada();
            if (r == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: abrir FrmMapaButacas con datos de pase/reserva
        }

        #endregion
    }
}
