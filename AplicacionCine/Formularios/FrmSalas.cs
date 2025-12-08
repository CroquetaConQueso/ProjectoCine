using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmSalas : Form
    {
        private readonly BindingSource _bsSalas = new BindingSource();
        private List<Sala> _listaCompleta = new List<Sala>();
        private Sala? _salaActual;

        public FrmSalas()
        {
            InitializeComponent();

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

        private void FrmSalas_Load(object? sender, EventArgs e)
        {
            CargarSalas();
        }

        private void CargarSalas()
        {
            _listaCompleta = AppContext.Salas.GetAll();
            AplicarFiltro();
        }

        #endregion

        #region Filtro / selección

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

        private Sala? GetSalaActual()
        {
            if (dvgSalas.SelectedRows.Count > 0)
                return dvgSalas.SelectedRows[0].DataBoundItem as Sala;

            return null;
        }

        private void DvgSalas_SelectionChanged(object? sender, EventArgs e)
        {
            _salaActual = GetSalaActual();
            RellenarDetalle();
            ActualizarSeleccion();
        }

        #endregion

        #region Detalle

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
        /// Actualiza tslResultadoSeleccion con la sala seleccionada.
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

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            tbNomSal.Text = "";
            AplicarFiltro();
        }

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

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (_salaActual == null)
                _salaActual = new Sala { Activa = true };

            var nombre = tbTitulo.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.",
                    "Salas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _salaActual.Nombre = nombre;
            _salaActual.Descripcion = string.IsNullOrWhiteSpace(tbDescripcion.Text)
                ? null
                : tbDescripcion.Text;

            _salaActual.Filas = (int)nudFilas.Value;
            _salaActual.Columnas = (int)nudColumnas.Value;
            _salaActual.Capacidad = (int)nudCapacidad.Value;

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

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Edición rápida de 'Activa' en el grid

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
