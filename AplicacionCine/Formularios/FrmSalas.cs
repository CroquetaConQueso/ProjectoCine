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
            dvgSalas.ReadOnly = true;
            dvgSalas.AllowUserToAddRows = false;
            dvgSalas.AllowUserToDeleteRows = false;
            dvgSalas.SelectionChanged += DvgSalas_SelectionChanged;

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

            // Activa (solo lectura en el grid)
            dvgSalas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = nameof(Sala.Activa),
                HeaderText = "Activa",
                Width = 60,
                ReadOnly = true
            });
        }

        #endregion

        #region Carga inicial / estado usuario

        private void FrmSalas_Load(object? sender, EventArgs e)
        {
            CargarSalas();
            ActualizarEstadoUsuario();
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
            dvgSalas.ClearSelection();
        }

        private Sala? GetSalaActual()
        {
            return _bsSalas.Current as Sala;
        }

        private void DvgSalas_SelectionChanged(object? sender, EventArgs e)
        {
            _salaActual = GetSalaActual();
            RellenarDetalle();
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
                // por defecto marcamos activa para nuevas
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

            // nuevo: estado activa en el panel derecho
            if (chkActiva != null)
                chkActiva.Checked = _salaActual.Activa;
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

            // leer el checkbox de detalle
            if (chkActiva != null)
                _salaActual.Activa = chkActiva.Checked;
            else if (_salaActual.IdSala == 0)
                _salaActual.Activa = true; // por si acaso

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
    }
}
