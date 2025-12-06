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

            dvgSalas.AutoGenerateColumns = true;
            dvgSalas.DataSource = _bsSalas;
            dvgSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgSalas.MultiSelect = false;
            dvgSalas.ReadOnly = true;
            dvgSalas.SelectionChanged += DvgSalas_SelectionChanged;
        }

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

        private void AplicarFiltro()
        {
            IEnumerable<Sala> query = _listaCompleta;

            var nombre = tbNomSal.Text.Trim().ToLowerInvariant();
            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(s => s.Nombre.ToLowerInvariant().Contains(nombre));

            var lista = query.ToList();
            _bsSalas.DataSource = new BindingList<Sala>(lista);
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

        private void RellenarDetalle()
        {
            if (_salaActual == null)
            {
                tbTitulo.Text = "";
                tbDescripcion.Text = "";
                nudFilas.Value = 0;
                nudColumnas.Value = 0;
                nudCapacidad.Value = 0;
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
        }

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
            _salaActual = new Sala { Activa = true };
            RellenarDetalle();
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
                ? null : tbDescripcion.Text;

            _salaActual.Filas = (int)nudFilas.Value;
            _salaActual.Columnas = (int)nudColumnas.Value;
            _salaActual.Capacidad = (int)nudCapacidad.Value;

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
    }
}
