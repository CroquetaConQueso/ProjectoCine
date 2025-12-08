using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmPeliculas : Form
    {
        private readonly BindingSource _bsPelis = new BindingSource();
        private List<Pelicula> _listaCompleta = new List<Pelicula>();
        private Pelicula? _peliculaActual;

        public FrmPeliculas()
        {
            InitializeComponent();

            // >>> NUEVO: bloquear maximizar y el tamaño de la ventana
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            // <<<

            Load += FrmPeliculas_Load;

            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnNuevo.Click += BtnNuevo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnCerrar.Click += BtnCerrar_Click;

            dvgPelis.AutoGenerateColumns = false;   // definimos columnas a mano
            dvgPelis.DataSource = _bsPelis;

            dvgPelis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgPelis.MultiSelect = false;

            // El grid NO es de solo lectura para permitir el clic en el check
            dvgPelis.ReadOnly = false;
            dvgPelis.AllowUserToAddRows = false;
            dvgPelis.AllowUserToDeleteRows = false;

            dvgPelis.SelectionChanged += DvgPelis_SelectionChanged;
            dvgPelis.CellContentClick += DvgPelis_CellContentClick;

            ConfigurarGrid();
        }

        #region Configurar grid

        private void ConfigurarGrid()
        {
            dvgPelis.Columns.Clear();

            // Id
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.IdPelicula),
                HeaderText = "IdPelicula",
                Width = 70,
                ReadOnly = true
            });

            // Título
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.Titulo),
                HeaderText = "Título",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Duración
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.DuracionMin),
                HeaderText = "Duración (min)",
                Width = 90,
                ReadOnly = true
            });

            // Clasificación
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.Clasificacion),
                HeaderText = "Clasificación",
                Width = 90,
                ReadOnly = true
            });

            // Género
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.Genero),
                HeaderText = "Género",
                Width = 120,
                ReadOnly = true
            });

            // Sinopsis
            dvgPelis.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Pelicula.Sinopsis),
                HeaderText = "Sinopsis",
                Width = 250,
                ReadOnly = true
            });

            // Activa (EDITABLE en grid)
            dvgPelis.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(Pelicula.Activa),
                HeaderText = "Activa",
                Width = 60,
                ReadOnly = false
            });
        }

        #endregion

        #region Carga inicial

        private void FrmPeliculas_Load(object? sender, EventArgs e)
        {
            nudDuracion.Maximum = 600; // pelis largas

            CargarCombos();
            CargarPeliculas();
            ActualizarEstadoUsuario();   // ahora actualiza el StatusStrip de pelis
        }

        private void CargarCombos()
        {
            var clasifs = new[] { "", "TP", "7", "12", "16", "18" };
            cbCalificacion.Items.AddRange(clasifs);
            cbCalif.Items.AddRange(clasifs.Where(c => c != "").ToArray());

            cbGenero.Items.AddRange(new object[]
            {
                "", "Acción", "Aventura", "Comedia", "Drama",
                "Terror", "Animación", "Ciencia ficción"
            });
        }

        /// <summary>
        /// ACTUALIZAR STATUSSTRIP (ya no muestra usuario/rol).
        /// </summary>
        private void ActualizarEstadoUsuario()
        {
            // 1) Totales / visibles
            int total = _listaCompleta?.Count ?? 0;

            int visibles = 0;
            if (_bsPelis.List is IList<Pelicula> lista)
                visibles = lista.Count;

            tslPeliculas.Text = "Películas:";
            tslCantidadPeliculas.Text = $"{visibles} / {total}";

            // 2) Descripción del filtro
            string filtroTexto = "(ninguno)";
            var partes = new List<string>();

            if (!string.IsNullOrWhiteSpace(tbNombre.Text))
                partes.Add($"Título contiene \"{tbNombre.Text.Trim()}\"");

            if (cbCalificacion.SelectedIndex > 0)
                partes.Add($"Clasificación = {cbCalificacion.SelectedItem}");

            if (partes.Count > 0)
                filtroTexto = string.Join("; ", partes);

            tslFiltro.Text = "Filtro:";
            tslCantidadFiltro.Text = filtroTexto;

            // 3) Selección actual
            tslSeleccion.Text = "Selección:";
            if (_peliculaActual != null)
                tslResultadoSeleccion.Text =
                    $"{_peliculaActual.IdPelicula} - {_peliculaActual.Titulo}";
            else
                tslResultadoSeleccion.Text = "(ninguna)";
        }

        private void CargarPeliculas()
        {
            _listaCompleta = AppContext.Peliculas.GetAll();
            AplicarFiltro();
        }

        #endregion

        #region Filtro

        private void AplicarFiltro()
        {
            IEnumerable<Pelicula> query = _listaCompleta;

            var nombre = tbNombre.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.Titulo.ToLowerInvariant().Contains(nombre));

            var clasif = cbCalificacion.SelectedItem as string;
            if (!string.IsNullOrEmpty(clasif))
                query = query.Where(p => (p.Clasificacion ?? "")
                    .Equals(clasif, StringComparison.OrdinalIgnoreCase));

            var lista = query.ToList();
            _bsPelis.DataSource = new BindingList<Pelicula>(lista);
            dvgPelis.ClearSelection();

            // tras cambiar el filtro, refrescamos el status
            ActualizarEstadoUsuario();
        }

        private Pelicula? GetPeliculaActual()
        {
            return _bsPelis.Current as Pelicula;
        }

        #endregion

        #region Detalle

        private void DvgPelis_SelectionChanged(object? sender, EventArgs e)
        {
            _peliculaActual = GetPeliculaActual();
            RellenarDetalle();
            ActualizarEstadoUsuario();
        }

        private void RellenarDetalle()
        {
            if (_peliculaActual == null)
            {
                tbTitulo.Text = "";
                nudDuracion.Value = 0;
                cbCalif.SelectedIndex = -1;
                cbGenero.SelectedIndex = -1;
                tbSinopsis.Text = "";
                if (chkActiva != null)
                    chkActiva.Checked = true;
                return;
            }

            tbTitulo.Text = _peliculaActual.Titulo;

            nudDuracion.Value = _peliculaActual.DuracionMin >= nudDuracion.Minimum &&
                                _peliculaActual.DuracionMin <= nudDuracion.Maximum
                ? _peliculaActual.DuracionMin
                : nudDuracion.Minimum;

            if (_peliculaActual.Clasificacion != null &&
                cbCalif.Items.Contains(_peliculaActual.Clasificacion))
                cbCalif.SelectedItem = _peliculaActual.Clasificacion;
            else
                cbCalif.SelectedIndex = -1;

            if (_peliculaActual.Genero != null &&
                cbGenero.Items.Contains(_peliculaActual.Genero))
                cbGenero.SelectedItem = _peliculaActual.Genero;
            else
                cbGenero.SelectedIndex = -1;

            tbSinopsis.Text = _peliculaActual.Sinopsis ?? "";

            if (chkActiva != null)
                chkActiva.Checked = _peliculaActual.Activa;
        }

        #endregion

        #region Botones

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            tbNombre.Text = "";
            cbCalificacion.SelectedIndex = -1;
            AplicarFiltro();
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            _peliculaActual = new Pelicula
            {
                Activa = true
            };

            RellenarDetalle();
            if (chkActiva != null)
                chkActiva.Checked = true;

            tbTitulo.Focus();
            // no es necesario actualizar status aquí: todavía no está en la lista
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (_peliculaActual == null)
                _peliculaActual = new Pelicula { Activa = true };

            var titulo = tbTitulo.Text.Trim();
            if (string.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("El título es obligatorio.",
                    "Películas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _peliculaActual.Titulo = titulo;
            _peliculaActual.DuracionMin = (int)nudDuracion.Value;
            _peliculaActual.Clasificacion = cbCalif.SelectedItem as string;
            _peliculaActual.Genero = cbGenero.SelectedItem as string;
            _peliculaActual.Sinopsis = string.IsNullOrWhiteSpace(tbSinopsis.Text)
                ? null
                : tbSinopsis.Text;

            if (chkActiva != null)
                _peliculaActual.Activa = chkActiva.Checked;
            else if (_peliculaActual.IdPelicula == 0)
                _peliculaActual.Activa = true; // seguridad para altas

            if (_peliculaActual.IdPelicula == 0)
                AppContext.Peliculas.Insert(_peliculaActual);
            else
                AppContext.Peliculas.Update(_peliculaActual);

            CargarPeliculas(); // AplicarFiltro + ActualizarEstadoUsuario()
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var p = GetPeliculaActual();
            if (p == null || p.IdPelicula == 0)
            {
                MessageBox.Show("Selecciona una película.", "Películas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"¿Eliminar la película '{p.Titulo}'?",
                "Películas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            AppContext.Peliculas.Delete(p.IdPelicula);
            CargarPeliculas();
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Edición rápida de 'Activa' en el grid

        private void DvgPelis_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var col = dvgPelis.Columns[e.ColumnIndex];

            // Solo reaccionamos a la columna checkbox "Activa"
            if (col is not DataGridViewCheckBoxColumn ||
                col.DataPropertyName != nameof(Pelicula.Activa))
            {
                return;
            }

            dvgPelis.EndEdit();

            if (dvgPelis.Rows[e.RowIndex].DataBoundItem is not Pelicula peli)
                return;

            var celda = dvgPelis.Rows[e.RowIndex].Cells[e.ColumnIndex];
            bool nuevoValor = (celda.Value is bool b && b);

            peli.Activa = nuevoValor;
            AppContext.Peliculas.Update(peli);

            _peliculaActual = GetPeliculaActual();
            if (_peliculaActual != null && chkActiva != null &&
                _peliculaActual.IdPelicula == peli.IdPelicula)
            {
                chkActiva.Checked = peli.Activa;
            }

            // Actualizamos el StatusStrip con la selección actual
            ActualizarEstadoUsuario();
        }

        #endregion
    }
}
