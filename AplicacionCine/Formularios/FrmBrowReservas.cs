using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    public partial class FrmBrowReservas : Form
    {
        // BindingSource para enlazar la lista de reservas al DataGridView
        private readonly BindingSource _bsReservas = new BindingSource();

        public FrmBrowReservas()
        {
            InitializeComponent();

            // Eventos de ciclo de vida
            Load += FrmBrowReservas_Load;

            // Eventos de botones
            btnBuscar.Click += BtnBuscar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnNuevo.Click += BtnNuevo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnMapa.Click += BtnMapa_Click;
            btnCerrar.Click += (s, e) => Close();

            // Doble clic en la rejilla = editar
            dvgUsuarios.DoubleClick += DvgUsuarios_DoubleClick;
        }

        // =====================================================
        //  CARGA INICIAL
        // =====================================================

        private void FrmBrowReservas_Load(object? sender, EventArgs e)
        {
            // StatusStrip
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

            // Filtros por defecto
            dateTimePicker1.Value = DateTime.Today;

            cbEstado.Items.Clear();
            cbEstado.Items.Add("(Todos)");
            cbEstado.Items.Add("Pendiente");
            cbEstado.Items.Add("Pagada");
            cbEstado.Items.Add("Cancelada");
            cbEstado.SelectedIndex = 0;

            // TODO: cuando tengas PeliculaDAO, carga el combo desde la BD
            cbPeliculas.Items.Clear();
            cbPeliculas.Items.Add("(Todas)");
            cbPeliculas.SelectedIndex = 0;

            ConfigurarGrid();

            dvgUsuarios.DataSource = _bsReservas;

            // Primera carga (ahora mismo solo vacía, sin BD)
            Recargar();
        }

        // Configuración de columnas del grid
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
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PeliculaTitulo",
                HeaderText = "Película",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsuarioNombre",
                HeaderText = "Usuario",
                Width = 160
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 90
            });

            dvgUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "0.00 €"
                }
            });
        }

        // =====================================================
        //  CARGA / FILTRO (ahora mismo sin BD real)
        // =====================================================

        private void Recargar()
        {
            tslEstado.Text = "Cargando...";
            tsLsituacion.Text = string.Empty;

            // Lee los filtros, por si luego quieres usarlos con ReservaDAO
            DateTime? fechaFiltro = dateTimePicker1.Value.Date;

            int? idPelicula = null;
            if (cbPeliculas.SelectedIndex > 0 && cbPeliculas.SelectedValue is int v)
                idPelicula = v;

            string? estado = null;
            if (cbEstado.SelectedIndex > 0)
                estado = cbEstado.SelectedItem?.ToString();

            string? usuario = string.IsNullOrWhiteSpace(txtFiltroUsuario.Text)
                ? null
                : txtFiltroUsuario.Text.Trim();

            // TODO: sustituir esta lista "dummy" por la llamada real a ReservaDAO.Buscar(...)
            var lista = new List<Reserva>();
            // Ejemplo futuro:
            // lista = _reservaDAO.Buscar(fechaFiltro, idPelicula, estado, usuario);

            _bsReservas.DataSource = lista;

            tslEstado.Text = "Listo";
            tsLsituacion.Text = $"{lista.Count} reservas encontradas";
        }

        // =====================================================
        //  BOTONES DE FILTRO
        // =====================================================

        private void BtnBuscar_Click(object? sender, EventArgs e) => Recargar();

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            if (cbPeliculas.Items.Count > 0) cbPeliculas.SelectedIndex = 0;
            if (cbEstado.Items.Count > 0) cbEstado.SelectedIndex = 0;
            txtFiltroUsuario.Clear();

            Recargar();
        }

        // =====================================================
        //  UTILIDAD: obtener reserva seleccionada
        // =====================================================

        private Reserva? GetReservaSeleccionada()
        {
            return _bsReservas.Current as Reserva;
        }

        // =====================================================
        //  CRUD (sin lógica de BD todavía)
        // =====================================================

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            // TODO: cuando tengas FrmReserva, abrelo aquí en modo "nuevo"
            // using (var frm = new FrmReserva())
            // {
            //     if (frm.ShowDialog(this) == DialogResult.OK)
            //         Recargar();
            // }
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

            // TODO: abrir FrmReserva en modo edición
            // using (var frm = new FrmReserva(r.IdReserva))
            // {
            //     if (frm.ShowDialog(this) == DialogResult.OK)
            //         Recargar();
            // }
        }

        private void DvgUsuarios_DoubleClick(object? sender, EventArgs e)
        {
            // reutilizamos la lógica del botón Editar
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

            // TODO: llamar a ReservaDAO.Delete(r.IdReserva);
            // _reservaDAO.Delete(r.IdReserva);

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

            // TODO: cuando FrmMapaButacas acepte datos de reserva/pase, abrirlo aquí
            // using (var frm = new FrmMapaButacas(r.IdPase, r.IdReserva))
            // {
            //     frm.ShowDialog(this);
            // }
        }
    }
}
