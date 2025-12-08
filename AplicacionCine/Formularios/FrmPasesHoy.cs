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

            Load += FrmPasesHoy_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnHoy.Click += BtnHoy_Click;
            btnCerrar.Click += BtnCerrar_Click;
            btnVerButacas.Click += BtnVerButacas_Click;

            // NO autogenerar columnas, las definimos nosotros
            dgvPases.AutoGenerateColumns = false;
            dgvPases.DataSource = _bsPases;

            dgvPases.ReadOnly = true;
            dgvPases.AllowUserToAddRows = false;
            dgvPases.AllowUserToDeleteRows = false;
            dgvPases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPases.MultiSelect = false;

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
            ActualizarEstadoUsuario();
            CargarPases(); // carga TODOS los pases
        }

        private void CargarPeliculas()
        {
            var pelis = AppContext.Peliculas.GetAll();

            cbPeliculas.DisplayMember = "Titulo";
            cbPeliculas.ValueMember = "IdPelicula";
            cbPeliculas.DataSource = pelis;
            cbPeliculas.SelectedIndex = -1;
        }

        private void ActualizarEstadoUsuario()
        {
            var u = AppContext.UsuarioActual;
            if (u == null)
            {
                tsslUsuario.Text = "(sin sesión)";
                tsslRol.Text = string.Empty;
                tsslEstado.Text = "Desconectado";
            }
            else
            {
                tsslUsuario.Text = u.NombreUsuario;
                tsslRol.Text = u.Rol.ToString();
                tsslEstado.Text = "Listo";
            }
        }

        /// <summary>
        /// Carga TODOS los pases desde la BD, sin filtro.
        /// </summary>
        private void CargarPases()
        {
            _listaCompleta = AppContext.Pases.GetAll();
            _bsPases.DataSource = new BindingList<Pase>(_listaCompleta);
            tsslEstado.Text = $"Mostrando {_listaCompleta.Count} pases (sin filtro)";
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
            tsslEstado.Text = $"Mostrando {listaFiltrada.Count} pases filtrados";
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

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
