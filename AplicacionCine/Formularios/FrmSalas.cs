using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    /// <summary>
    /// Formulario de mantenimiento de salas:
    /// búsqueda, alta/edición básica y resumen de capacidad.
    /// </summary>
    public partial class FrmSalas : Form
    {
        /// <summary>
        /// Origen de datos principal del grid de salas.
        /// </summary>
        private readonly BindingSource _bsSalas = new BindingSource();

        /// <summary>
        /// Lista completa de salas cargadas desde la base de datos
        /// sobre la que se aplican los filtros de búsqueda.
        /// </summary>
        private List<Sala> _listaCompleta = new List<Sala>();

        /// <summary>
        /// Sala actualmente seleccionada o en edición en el panel de detalle.
        /// </summary>
        private Sala? _salaActual;

        /// <summary>
        /// Constructor por defecto: inicializa el formulario,
        /// aplica el tema y configura eventos y grid.
        /// </summary>
        public FrmSalas()
        {
            InitializeComponent();
            TemaCine.Aplicar(this);

            // Bloquear maximizar y tamaño variable
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Load += FrmSalas_Load;

            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnNuevo.Click += BtnNuevo_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnCerrar.Click += BtnCerrar_Click;

            dvgSalas.AutoGenerateColumns = false;
            dvgSalas.DataSource = _bsSalas;
            dvgSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgSalas.MultiSelect = false;

            // El grid NO es totalmente de solo lectura:
            // solo permitimos editar el checkbox de Activa
            dvgSalas.ReadOnly = false;
            dvgSalas.AllowUserToAddRows = false;
            dvgSalas.AllowUserToDeleteRows = false;

            dvgSalas.SelectionChanged += DvgSalas_SelectionChanged;
            dvgSalas.CellContentClick += DvgSalas_CellContentClick;

            ConfigurarGrid();
        }

        #region Configurar grid

        /// <summary>
        /// Configura las columnas del DataGridView de salas,
        /// incluyendo el checkbox editable de "Activa".
        /// </summary>
        private void ConfigurarGrid()
        {
            dvgSalas.Columns.Clear();

            // IdSala
            dvgSalas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Sala.IdSala),
                HeaderText = "Id",
                Width = 50,
                ReadOnly = true
            });

            // Nombre
            dvgSalas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Sala.Nombre),
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Filas
            dvgSalas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Sala.Filas),
                HeaderText = "Filas",
                Width = 60,
                ReadOnly = true
            });

            // Columnas
            dvgSalas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Sala.Columnas),
                HeaderText = "Columnas",
                Width = 80,
                ReadOnly = true
            });

            // Capacidad
            dvgSalas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Sala.Capacidad),
                HeaderText = "Capacidad",
                Width = 80,
                ReadOnly = true
            });

            // Activa (EDITABLE en el grid)
            dvgSalas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(Sala.Activa),
                HeaderText = "Activa",
                Width = 60,
                ReadOnly = false
            });
        }

        #endregion

        #region Carga inicial

        /// <summary>
        /// Carga inicial del formulario: obtiene las salas
        /// desde la capa de datos y aplica el filtro actual.
        /// </summary>
        private void FrmSalas_Load(object? sender, EventArgs e)
        {
            CargarSalas();
        }

        /// <summary>
        /// Recupera todas las salas de la base de datos
        /// y refresca el grid aplicando el filtro de búsqueda.
        /// </summary>
        private void CargarSalas()
        {
            _listaCompleta = AppContext.Salas.GetAll();
            AplicarFiltro();
        }

        #endregion

        #region Filtro / selección

        /// <summary>
        /// Aplica el filtro por nombre sobre la lista completa
        /// y actualiza el BindingSource, el detalle y el status strip.
        /// </summary>
        private void AplicarFiltro()
        {
            IEnumerable<Sala> query = _listaCompleta;

            var nombre = tbNomSal.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(s => s.Nombre.ToLowerInvariant().Contains(nombre));

            var lista = query.ToList();
            _bsSalas.DataSource = new BindingList<Sala>(lista);

            // Limpiar selección y detalle
            dvgSalas.ClearSelection();
            _salaActual = null;
            RellenarDetalle();

            // Actualizar status strip (cantidad, capacidad, selección)
            ActualizarResumenYSeleccion(lista);
        }

        /// <summary>
        /// Devuelve la sala asociada a la fila seleccionada en el grid,
        /// o null si no hay ninguna fila seleccionada.
        /// </summary>
        private Sala? GetSalaActual()
        {
            if (dvgSalas.SelectedRows.Count > 0)
                return dvgSalas.SelectedRows[0].DataBoundItem as Sala;

            return null;
        }

        /// <summary>
        /// Maneja el cambio de selección en el grid:
        /// actualiza la sala actual, el detalle y el texto de selección.
        /// </summary>
        private void DvgSalas_SelectionChanged(object? sender, EventArgs e)
        {
            _salaActual = GetSalaActual();
            RellenarDetalle();
            ActualizarSeleccion();
        }

        #endregion

        #region Detalle

        /// <summary>
        /// Rellena el panel de detalle con los datos de la sala actual.
        /// Si no hay sala seleccionada, limpia los controles.
        /// </summary>
        private void RellenarDetalle()
        {
            if (_salaActual == null)
            {
                tbTitulo.Text = "";
                tbDescripcion.Text = "";
                nudFilas.Value = 0;
                nudColumnas.Value = 0;
                nudCapacidad.Value = 0;

                if (chkActiva != null)
                    chkActiva.Checked = true;

                return;
            }

            tbTitulo.Text = _salaActual.Nombre;
            tbDescripcion.Text = _salaActual.Descripcion ?? "";

            nudFilas.Value = _salaActual.Filas >= nudFilas.Minimum &&
                             _salaActual.Filas <= nudFilas.Maximum
                ? _salaActual.Filas
                : nudFilas.Minimum;

            nudColumnas.Value = _salaActual.Columnas >= nudColumnas.Minimum &&
                                _salaActual.Columnas <= nudColumnas.Maximum
                ? _salaActual.Columnas
                : nudColumnas.Minimum;

            nudCapacidad.Value = _salaActual.Capacidad >= nudCapacidad.Minimum &&
                                 _salaActual.Capacidad <= nudCapacidad.Maximum
                ? _salaActual.Capacidad
                : nudCapacidad.Minimum;

            if (chkActiva != null)
                chkActiva.Checked = _salaActual.Activa;
        }

        #endregion

        #region StatusStrip (resumen + selección)

        /// <summary>
        /// Actualiza:
        /// - tslCantidadSalas: nº salas total / filtradas.
        /// - tslCantidadCapacidad: capacidad total / filtrada.
        /// - tslResultadoSeleccion: se delega en ActualizarSeleccion().
        /// </summary>
        /// <param name="listaActual">Lista de salas actualmente mostradas en el grid.</param>
        private void ActualizarResumenYSeleccion(IList<Sala> listaActual)
        {
            int total = _listaCompleta?.Count ?? 0;
            int filtradas = listaActual?.Count ?? 0;

            // Cantidad de salas
            if (total == 0)
            {
                tslCantidadSalas.Text = "Salas: 0";
            }
            else if (total == filtradas)
            {
                tslCantidadSalas.Text = $"Salas: {total} (sin filtro)";
            }
            else
            {
                tslCantidadSalas.Text = $"Salas: {filtradas} de {total} (filtradas)";
            }

            // Capacidad total / filtrada
            int capTotal = _listaCompleta?.Sum(s => s.Capacidad) ?? 0;
            int capFiltrada = listaActual?.Sum(s => s.Capacidad) ?? 0;

            if (capTotal == 0)
            {
                tslCantidadCapacidad.Text = "Capacidad total: 0";
            }
            else if (capTotal == capFiltrada)
            {
                tslCantidadCapacidad.Text = $"Capacidad total: {capTotal}";
            }
            else
            {
                tslCantidadCapacidad.Text = $"Capacidad filtrada: {capFiltrada} de {capTotal}";
            }

            // Detalle de selección
            ActualizarSeleccion();
        }

        /// <summary>
        /// Muestra en tslResultadoSeleccion un resumen de la sala seleccionada,
        /// o indica que no hay selección.
        /// </summary>
        private void ActualizarSeleccion()
        {
            var sala = GetSalaActual();
            if (sala == null)
            {
                tslResultadoSeleccion.Text = "Selección: (ninguna sala seleccionada)";
                return;
            }

            tslResultadoSeleccion.Text =
                $"Selección: Id {sala.IdSala} | {sala.Nombre} | {sala.Filas}x{sala.Columnas} | Cap: {sala.Capacidad} | {(sala.Activa ? "Activa" : "Inactiva")}";
        }

        #endregion

        #region Botones

        /// <summary>
        /// Aplica el filtro actual de búsqueda por nombre.
        /// </summary>
        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        /// <summary>
        /// Limpia el filtro de nombre y recarga la lista completa.
        /// </summary>
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            tbNomSal.Text = "";
            AplicarFiltro();
        }

        /// <summary>
        /// Prepara el formulario para dar de alta una nueva sala
        /// iniciando una Sala en memoria sin guardar.
        /// </summary>
        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            _salaActual = new Sala
            {
                Activa = true
            };

            RellenarDetalle();
            if (chkActiva != null)
                chkActiva.Checked = true;

            tslResultadoSeleccion.Text = "Selección: (nueva sala sin guardar)";
            tbTitulo.Focus();
        }

        /// <summary>
        /// Valida y guarda la sala actual en la base de datos,
        /// insertando o actualizando según el IdSala.
        /// </summary>
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (_salaActual == null)
                _salaActual = new Sala { Activa = true };

            // --- Validaciones suaves ---
            var nombre = tbTitulo.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show(
                    "El nombre de la sala es obligatorio.",
                    "Salas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbTitulo.Focus();
                return;
            }

            if (nombre.Length < 2)
            {
                MessageBox.Show(
                    "El nombre de la sala debe tener al menos 2 caracteres.",
                    "Salas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbTitulo.Focus();
                tbTitulo.SelectAll();
                return;
            }

            int filas = (int)nudFilas.Value;
            int columnas = (int)nudColumnas.Value;
            int capacidad = (int)nudCapacidad.Value;

            if (filas <= 0)
            {
                MessageBox.Show(
                    "Las filas deben ser mayores que 0.",
                    "Salas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                nudFilas.Focus();
                return;
            }

            if (columnas <= 0)
            {
                MessageBox.Show(
                    "Las columnas deben ser mayores que 0.",
                    "Salas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                nudColumnas.Focus();
                return;
            }

            if (capacidad <= 0)
            {
                MessageBox.Show(
                    "La capacidad debe ser mayor que 0.",
                    "Salas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                nudCapacidad.Focus();
                return;
            }

            // (Opcional, solo aviso, no bloqueo)
            int capacidadTeorica = filas * columnas;
            if (capacidad != capacidadTeorica)
            {
                var res = MessageBox.Show(
                    $"Capacidad distinta a filas x columnas ({filas} x {columnas} = {capacidadTeorica}).\n\n" +
                    "¿Quieres ajustar automáticamente la capacidad a ese valor?",
                    "Salas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    capacidad = capacidadTeorica;
                    nudCapacidad.Value = capacidad;
                }
            }

            // --- Volcar datos a la entidad ---
            _salaActual.Nombre = nombre;
            _salaActual.Descripcion = string.IsNullOrWhiteSpace(tbDescripcion.Text)
                ? null
                : tbDescripcion.Text;

            _salaActual.Filas = filas;
            _salaActual.Columnas = columnas;
            _salaActual.Capacidad = capacidad;

            if (chkActiva != null)
                _salaActual.Activa = chkActiva.Checked;
            else if (_salaActual.IdSala == 0)
                _salaActual.Activa = true;

            if (_salaActual.IdSala == 0)
                AppContext.Salas.Insert(_salaActual);
            else
                AppContext.Salas.Update(_salaActual);

            CargarSalas();
        }

        /// <summary>
        /// Elimina la sala seleccionada previa confirmación del usuario.
        /// </summary>
        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            var s = GetSalaActual();
            if (s == null || s.IdSala == 0)
            {
                MessageBox.Show("Selecciona una sala.", "Salas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show(
                $"¿Eliminar la sala '{s.Nombre}'?",
                "Salas",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res != DialogResult.Yes) return;

            AppContext.Salas.Delete(s.IdSala);
            CargarSalas();
        }

        /// <summary>
        /// Cierra el formulario sin realizar más acciones.
        /// </summary>
        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Edición rápida de 'Activa' en el grid

        /// <summary>
        /// Permite cambiar el estado "Activa" directamente desde el checkbox del grid
        /// y persiste el cambio en la base de datos.
        /// </summary>
        private void DvgSalas_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var col = dvgSalas.Columns[e.ColumnIndex];

            // Solo reaccionamos a la columna checkbox "Activa"
            if (col is not DataGridViewCheckBoxColumn ||
                col.DataPropertyName != nameof(Sala.Activa))
            {
                return;
            }

            // Confirmar la edición del checkbox
            dvgSalas.EndEdit();

            // Obtenemos la sala asociada a la fila
            if (dvgSalas.Rows[e.RowIndex].DataBoundItem is not Sala sala)
                return;

            var celda = dvgSalas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            bool nuevoValor = (celda.Value is bool b && b);

            sala.Activa = nuevoValor;

            // Guardar en BD
            AppContext.Salas.Update(sala);

            // Sincronizar panel de detalle si esta sala es la seleccionada
            _salaActual = GetSalaActual();
            if (_salaActual != null &&
                chkActiva != null &&
                _salaActual.IdSala == sala.IdSala)
            {
                chkActiva.Checked = sala.Activa;
            }

            // Actualizar texto de selección
            tslResultadoSeleccion.Text =
                $"Sala '{sala.Nombre}' marcada como {(sala.Activa ? "activa" : "inactiva")}.";

            // También refrescamos la selección calculada
            ActualizarSeleccion();
        }

        #endregion
    }
}
