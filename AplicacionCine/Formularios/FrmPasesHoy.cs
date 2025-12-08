using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmPasesHoy : Form
    {
        private readonly BindingSource _bsPases = new BindingSource();
        private List<Pase> _listaCompleta = new List<Pase>();

        public FrmPasesHoy()
        {
            InitializeComponent();

            // Bloquear maximizar y tamaño variable
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Load += FrmPasesHoy_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnHoy.Click += BtnHoy_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnVerButacas.Click += BtnVerButacas_Click;

            // Configuración del grid
            dgvPases.AutoGenerateColumns = false;
            dgvPases.DataSource = _bsPases;

            dgvPases.ReadOnly = true;
            dgvPases.AllowUserToAddRows = false;
            dgvPases.AllowUserToDeleteRows = false;
            dgvPases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPases.MultiSelect = false;

            // Cuando cambia la selección, actualizamos el StatusStrip
            dgvPases.SelectionChanged += DgvPases_SelectionChanged;

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvPases.Columns.Clear();

            // Id del pase
            dgvPases.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdPase",
                HeaderText = "Id",
                Width = 50,
                ReadOnly = true
            });

            // Fecha y hora
            dgvPases.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHora",
                HeaderText = "Fecha / hora",
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            // Título de la película
            dgvPases.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TituloPelicula",
                HeaderText = "Película",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Sala
            dgvPases.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreSala",
                HeaderText = "Sala",
                Width = 100,
                ReadOnly = true
            });

            // Precio base
            dgvPases.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioBase",
                HeaderText = "Precio",
                Width = 70,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.00 €"
                }
            });

            // Activo
            dgvPases.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo",
                Width = 60,
                ReadOnly = true
            });
        }

        private void FrmPasesHoy_Load(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarPeliculas();

            // Usuario actual en el status
            ActualizarEstadoUsuario();

            // Cargar TODOS los pases (sin filtro)
            CargarPases();
        }

        private void CargarPeliculas()
        {
            var pelis = AppContext.Peliculas.GetAll();

            cbPeliculas.DisplayMember = "Titulo";
            cbPeliculas.ValueMember = "IdPelicula";
            cbPeliculas.DataSource = pelis;
            cbPeliculas.SelectedIndex = -1;
        }

        /// <summary>
        /// Muestra el usuario actual en el StatusStrip.
        /// Solo usa tsslPasesResumen para no pisar
        /// los textos de estado/selección.
        /// </summary>
        private void ActualizarEstadoUsuario()
        {
            var u = AppContext.UsuarioActual;
            if (u == null)
            {
                tsslPasesResumen.Text = "Usuario: (sin sesión)";
            }
            else
            {
                tsslPasesResumen.Text = $"Usuario: {u.NombreUsuario} ({u.Rol})";
            }
        }

        /// <summary>
        /// Carga TODOS los pases desde la BD, sin filtro.
        /// </summary>
        private void CargarPases()
        {
            _listaCompleta = AppContext.Pases.GetAll();
            var listaActual = _listaCompleta.ToList();

            _bsPases.DataSource = new BindingList<Pase>(listaActual);

            // Actualiza resumen de pases y selección
            ActualizarResumenYSeleccion(listaActual);
        }

        /// <summary>
        /// Aplica filtros en memoria sobre _listaCompleta.
        /// </summary>
        private void AplicarFiltro()
        {
            var fecha = dtpFecha.Value.Date;

            int? idPeli = null;
            if (cbPeliculas.SelectedItem is Pelicula peli)
                idPeli = peli.IdPelicula;

            IEnumerable<Pase> query = _listaCompleta;

            // Filtrar por fecha seleccionada
            query = query.Where(p => p.FechaHora.Date == fecha);

            // Filtrar por película si hay una seleccionada
            if (idPeli.HasValue)
                query = query.Where(p => p.IdPelicula == idPeli.Value);

            var listaFiltrada = query.ToList();
            _bsPases.DataSource = new BindingList<Pase>(listaFiltrada);

            // Actualiza resumen de pases y selección
            ActualizarResumenYSeleccion(listaFiltrada);
        }

        /// <summary>
        /// Actualiza tsslPasesEstado (resumen de pases/filtros)
        /// y tsslPasesSeleccion (pase seleccionado).
        /// </summary>
        private void ActualizarResumenYSeleccion(IList<Pase> listaActual)
        {
            int total = _listaCompleta?.Count ?? 0;
            int filtrados = listaActual?.Count ?? 0;

            string textoCantidad;
            if (total == 0)
            {
                textoCantidad = "Pases: 0";
            }
            else if (total == filtrados)
            {
                textoCantidad = $"Pases: {total} (sin filtro)";
            }
            else
            {
                textoCantidad = $"Pases: {filtrados} de {total} (filtrados)";
            }

            var fecha = dtpFecha.Value.Date;
            string filtroFecha = fecha.ToString("dd/MM/yyyy");

            string filtroPeli;
            if (cbPeliculas.SelectedItem is Pelicula peli)
                filtroPeli = peli.Titulo;
            else
                filtroPeli = "Todas las películas";

            tsslPasesEstado.Text = $"{textoCantidad} | Fecha: {filtroFecha} | Película: {filtroPeli}";

            // Y ahora la parte de selección concreta
            ActualizarSeleccion();
        }

        /// <summary>
        /// Actualiza tsslPasesSeleccion con la fila actualmente seleccionada.
        /// </summary>
        private void ActualizarSeleccion()
        {
            var pase = GetPaseActual();
            if (pase == null)
            {
                tsslPasesSeleccion.Text = "Selección: (ningún pase seleccionado)";
                return;
            }

            tsslPasesSeleccion.Text =
                $"Selección: Id {pase.IdPase} | {pase.FechaHora:dd/MM HH:mm} | {pase.TituloPelicula} | Sala {pase.NombreSala}";
        }

        private void DgvPases_SelectionChanged(object? sender, EventArgs e)
        {
            ActualizarSeleccion();
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnHoy_Click(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            AplicarFiltro();
        }

        /// <summary>
        /// Limpia filtros (fecha = hoy, sin película) y muestra todos los pases.
        /// </summary>
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            cbPeliculas.SelectedIndex = -1;
            CargarPases();   // sin filtro, todos los pases
        }

        private Pase? GetPaseActual()
        {
            return _bsPases.Current as Pase;
        }

        private void BtnVerButacas_Click(object? sender, EventArgs e)
        {
            var pase = GetPaseActual();
            if (pase == null)
            {
                MessageBox.Show("Selecciona un pase.", "Pases",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sala = AppContext.Salas.GetById(pase.IdSala);
            if (sala == null)
            {
                MessageBox.Show("No se ha encontrado la sala asociada al pase.",
                    "Pases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frm = new FrmMapaButacas(sala, pase)
            {
                MdiParent = MdiParent
            };
            frm.Show();
        }
    }
}
