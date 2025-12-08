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

            // Eventos
            Load += FrmBrowReservas_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnHoy.Click += BtnHoy_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnMapa.Click += BtnMapa_Click;
            btnCerrar.Click += (s, e) => Close();
            dvgUsuarios.CellDoubleClick += DgvUsuarios_CellDoubleClick;

            // Config grid
            dvgUsuarios.AutoGenerateColumns = true;
            dvgUsuarios.ReadOnly = true;
            dvgUsuarios.AllowUserToAddRows = false;
            dvgUsuarios.AllowUserToDeleteRows = false;
            dvgUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgUsuarios.MultiSelect = false;
            dvgUsuarios.DataSource = _bsReservas;
        }

        private void FrmBrowReservas_Load(object? sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;

            CargarPeliculas();
            CargarEstados();

            cbUsar.Checked = false; // por defecto la fecha no filtra
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

        // ----------------- ACCIONES -----------------

        private void BtnBuscar_Click(object? sender, EventArgs e) => Buscar();

        private void BtnHoy_Click(object? sender, EventArgs e)
        {
            cbUsar.Checked = true;
            dateTimePicker1.Value = DateTime.Today;
            Buscar();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            cbUsar.Checked = false;
            dateTimePicker1.Value = DateTime.Today;
            cbPeliculas.SelectedIndex = -1;
            cbEstado.SelectedIndex = 0;
            txtFiltroUsuario.Clear();

            _bsReservas.DataSource = new BindingList<Reserva>(new List<Reserva>());
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
                // Recargar la reserva desde BD
                var refrescada = AppContext.Reservas.GetById(reserva.IdReserva);
                if (refrescada != null)
                {
                    // 1) Sacamos la lista actual como List<Reserva>
                    var lista = _bsReservas.List.Cast<Reserva>().ToList();

                    // 2) Buscamos la posición de la reserva editada
                    int idx = lista.FindIndex(r => r.IdReserva == refrescada.IdReserva);
                    if (idx >= 0)
                    {
                        // 3) Sustituimos el objeto en la lista
                        lista[idx] = refrescada;

                        // 4) Volvemos a enchufar la lista al BindingSource
                        _bsReservas.DataSource = new BindingList<Reserva>(lista);
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

        // ----------------- BÚSQUEDA -----------------

        private void Buscar()
        {
            DateTime? fecha = cbUsar.Checked
                ? dateTimePicker1.Value.Date
                : (DateTime?)null;

            int? idPeli = null;
            if (cbPeliculas.SelectedItem is Pelicula peli)
                idPeli = peli.IdPelicula;

            string? estado = null;
            if (cbEstado.SelectedItem is EEstadoReserva est)
                estado = est.ToString();

            string? usuario = string.IsNullOrWhiteSpace(txtFiltroUsuario.Text)
                ? null
                : txtFiltroUsuario.Text.Trim();

            var lista = AppContext.Reservas.Buscar(fecha, idPeli, estado, usuario);

            _bsReservas.DataSource = new BindingList<Reserva>(lista);
            ConfigurarColumnas();
        }

        private void ConfigurarColumnas()
        {
            if (dvgUsuarios.Columns.Count == 0) return;

            // Mostrar lo importante y ocultar ids internos
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
    }
}
