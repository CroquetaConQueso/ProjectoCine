using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.DAO;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmBrowReservas : Form
    {
        private readonly BindingSource _bsReservas = new BindingSource();

        public FrmBrowReservas()
        {
            InitializeComponent();

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;   // <-- añadido

            // Eventos de la ventana
            Load += FrmBrowReservas_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnMapa.Click += BtnMapa_Click;
            btnCerrar.Click += (s, e) => Close();

            dvgUsuarios.CellDoubleClick += DgvUsuarios_CellDoubleClick;
            dvgUsuarios.SelectionChanged += DvgUsuarios_SelectionChanged;

            // Configuración del grid
            dvgUsuarios.AutoGenerateColumns = true;
            dvgUsuarios.ReadOnly = true;
            dvgUsuarios.AllowUserToAddRows = false;
            dvgUsuarios.AllowUserToDeleteRows = false;
            dvgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUsuarios.MultiSelect = false;
            dvgUsuarios.DataSource = _bsReservas;

            // Eventos de filtro por fecha
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;

            // Checkbox que decide si usamos la fecha como filtro
            cbUsar.CheckedChanged += CbUsar_CheckedChanged;
        }

        private void FrmBrowReservas_Load(object? sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;

            CargarPeliculas();
            CargarEstados();

            // Por defecto: NO filtrar por fecha -> se verán todas las reservas
            cbUsar.Checked = false;

            Buscar();
        }

        private void CargarPeliculas()
        {
            var pelis = AppContext.Peliculas.GetAll();
            cbPeliculas.DisplayMember = "Titulo";
            cbPeliculas.ValueMember = "IdPelicula";
            cbPeliculas.DataSource = pelis;
            cbPeliculas.SelectedIndex = -1;
        }

        private void CargarEstados()
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add("(Todos)");
            foreach (var v in Enum.GetValues(typeof(EEstadoReserva)))
                cbEstado.Items.Add(v);
            cbEstado.SelectedIndex = 0;
        }

        // ================= ACCIONES =================

        private void BtnBuscar_Click(object? sender, EventArgs e) => Buscar();

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            // Reset de filtros
            cbUsar.Checked = false; // al limpiar, dejamos de filtrar por fecha
            dateTimePicker1.Value = DateTime.Today;
            cbPeliculas.SelectedIndex = -1;
            cbEstado.SelectedIndex = 0;
            txtFiltroUsuario.Clear();

            Buscar();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            var reserva = GetReservaActual();
            if (reserva == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmReserva(reserva);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var refrescada = AppContext.Reservas.GetById(reserva.IdReserva);
                if (refrescada != null)
                {
                    var lista = _bsReservas.List.Cast<Reserva>().ToList();
                    int idx = lista.FindIndex(r => r.IdReserva == refrescada.IdReserva);
                    if (idx >= 0)
                    {
                        lista[idx] = refrescada;
                        _bsReservas.DataSource = new BindingList<Reserva>(lista);
                        ConfigurarColumnas();
                        ActualizarStatus();
                    }
                }
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var reserva = GetReservaActual();
            if (reserva == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show(
                $"¿Eliminar la reserva #{reserva.IdReserva}?",
                "Reservas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r != DialogResult.Yes) return;

            // Primero borrar líneas
            var lineas = AppContext.Reservas.GetLineasDeReserva(reserva.IdReserva);
            foreach (var lin in lineas)
                AppContext.Reservas.DeleteLinea(lin.IdLineaReserva);

            // Luego la reserva
            AppContext.Reservas.DeleteReserva(reserva.IdReserva);

            // Refrescar listado
            Buscar();
        }

        private void BtnMapa_Click(object? sender, EventArgs e)
        {
            var reserva = GetReservaActual();
            if (reserva == null)
            {
                MessageBox.Show("Selecciona una reserva.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var pase = AppContext.Pases.GetById(reserva.IdPase);
            if (pase == null)
            {
                MessageBox.Show("No se ha encontrado el pase asociado.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sala = AppContext.Salas.GetById(pase.IdSala);
            if (sala == null)
            {
                MessageBox.Show("No se ha encontrado la sala del pase.", "Reservas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new FrmMapaButacas(sala, pase)
            {
                MdiParent = MdiParent
            };
            frm.Show();
        }

        private void DgvUsuarios_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                BtnEditar_Click(sender, EventArgs.Empty);
        }

        private void DvgUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            ActualizarStatus();
        }

        private void DateTimePicker1_ValueChanged(object? sender, EventArgs e)
        {
            // Si el usuario ha decidido usar la fecha, recargamos con ese filtro
            Buscar();
        }

        private void CbUsar_CheckedChanged(object? sender, EventArgs e)
        {
            // Cada vez que el usuario marca/desmarca el uso de la fecha, volvemos a buscar
            Buscar();
        }

        // ================= BÚSQUEDA =================

        private void Buscar()
        {
            // Filtrar por fecha SOLO si cbUsar está marcado
            DateTime? fecha = null;
            if (cbUsar.Checked)
                fecha = dateTimePicker1.Value.Date;

            int? idPeli = null;
            if (cbPeliculas.SelectedItem is Pelicula peli)
                idPeli = peli.IdPelicula;

            string? estado = null;
            if (cbEstado.SelectedItem is EEstadoReserva est)
                estado = est.ToString(); // el DAO sigue recibiendo string

            string? usuario = string.IsNullOrWhiteSpace(txtFiltroUsuario.Text)
                ? null
                : txtFiltroUsuario.Text.Trim();

            var lista = AppContext.Reservas.Buscar(fecha, idPeli, estado, usuario);

            _bsReservas.DataSource = new BindingList<Reserva>(lista);
            ConfigurarColumnas();
            ActualizarStatus();
        }

        private void ConfigurarColumnas()
        {
            if (dvgUsuarios.Columns.Count == 0) return;

            void Hide(string name)
            {
                if (dvgUsuarios.Columns.Contains(name))
                    dvgUsuarios.Columns[name].Visible = false;
            }

            Hide("IdPase");
            Hide("IdUsuario");
            Hide("Observaciones");

            if (dvgUsuarios.Columns.Contains("IdReserva"))
                dvgUsuarios.Columns["IdReserva"].HeaderText = "Id";

            if (dvgUsuarios.Columns.Contains("FechaReserva"))
                dvgUsuarios.Columns["FechaReserva"].HeaderText = "Fecha";

            if (dvgUsuarios.Columns.Contains("PeliculaTitulo"))
                dvgUsuarios.Columns["PeliculaTitulo"].HeaderText = "Película";

            if (dvgUsuarios.Columns.Contains("UsuarioNombre"))
                dvgUsuarios.Columns["UsuarioNombre"].HeaderText = "Usuario";

            if (dvgUsuarios.Columns.Contains("Estado"))
                dvgUsuarios.Columns["Estado"].HeaderText = "Estado";

            if (dvgUsuarios.Columns.Contains("Total"))
                dvgUsuarios.Columns["Total"].HeaderText = "Total (€)";
        }

        private Reserva? GetReservaActual()
        {
            return _bsReservas.Current as Reserva;
        }

        // ================= STATUSSTRIP =================

        private void ActualizarStatus()
        {
            var lista = _bsReservas.List.Cast<Reserva>().ToList();

            // 1) Resumen: número de reservas visibles
            int visibles = lista.Count;
            if (tslReservasResumen != null)
                tslReservasResumen.Text = $"Reservas: {visibles}";

            // 2) Estados: desglose por estado
            string estadosTexto;
            if (visibles == 0)
            {
                estadosTexto = "Estados: (ninguno)";
            }
            else
            {
                var grupos = lista
                    .GroupBy(r => r.Estado)
                    .OrderBy(g => g.Key.ToString());

                estadosTexto = "Estados: " +
                               string.Join(" | ",
                                   grupos.Select(g => $"{g.Key}: {g.Count()}"));
            }

            if (tslReservasEstados != null)
                tslReservasEstados.Text = estadosTexto;

            // 3) Importe total
            decimal totalImporte = lista.Sum(r => r.Total ?? 0m);
            if (tslReservasImporte != null)
                tslReservasImporte.Text = $"Importe total: {totalImporte:0.00} €";

            // 4) Reserva seleccionada
            var rSel = GetReservaActual();
            string selTexto;

            if (rSel != null)
            {
                var usuario = string.IsNullOrWhiteSpace(rSel.UsuarioNombre)
                    ? "(sin usuario)"
                    : rSel.UsuarioNombre;

                decimal importeSel = rSel.Total ?? 0m;

                selTexto =
                    $"Selección: #{rSel.IdReserva} - {usuario} - {rSel.Estado} - {importeSel:0.00} €";
            }
            else
            {
                selTexto = "Selección: (ninguna)";
            }

            if (tslReservasSeleccion != null)
                tslReservasSeleccion.Text = selTexto;
        }
    }
}

