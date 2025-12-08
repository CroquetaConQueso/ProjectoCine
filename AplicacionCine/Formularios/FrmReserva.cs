using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;
using AplicacionCine.DAO;
using AplicacionCine;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    /// <summary>
    /// Formulario de detalle de una reserva:
    /// muestra datos de pase, usuario, líneas y permite editar estado/observaciones.
    /// </summary>
    public partial class FrmReserva : Form
    {
        /// <summary>
        /// Reserva que se está creando o editando.
        /// </summary>
        private Reserva _reserva;

        /// <summary>
        /// Indica si la reserva es nueva (true) o se está editando una existente (false).
        /// </summary>
        private bool _esNueva;

        /// <summary>
        /// Líneas asociadas a la reserva (butacas/entradas).
        /// </summary>
        private List<LineaReserva> _lineas = new List<LineaReserva>();

        /// <summary>
        /// Constructor por defecto: pensado para altas directas o uso del diseñador.
        /// Inicializa una reserva nueva en estado Pendiente y fecha actual.
        /// </summary>
        public FrmReserva()
        {
            
            InitializeComponent();
            TemaCine.Aplicar(this);
            _reserva = new Reserva
            {
                FechaReserva = DateTime.Now,
                Estado = EEstadoReserva.Pendiente
            };
            _esNueva = true;

            InicializarEventos();
        }

        /// <summary>
        /// Constructor principal: recibe la reserva a editar o visualizar.
        /// Considera la reserva como nueva si IdReserva == 0.
        /// </summary>
        /// <param name="reserva">Reserva sobre la que se trabajará.</param>
        /// <exception cref="ArgumentNullException">Si la reserva es null.</exception>
        public FrmReserva(Reserva reserva)
        {
            InitializeComponent();
            TemaCine.Aplicar(this);
            _reserva = reserva ?? throw new ArgumentNullException(nameof(reserva));
            _esNueva = reserva.IdReserva == 0;

            InicializarEventos();
        }

        /// <summary>
        /// Registra los manejadores de eventos del formulario.
        /// </summary>
        private void InicializarEventos()
        {
            Load += FrmReserva_Load;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        /// <summary>
        /// Carga inicial del formulario: estados, fecha, observaciones,
        /// información de pase/usuario y líneas de reserva si aplica.
        /// </summary>
        private void FrmReserva_Load(object? sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            foreach (var valor in Enum.GetValues(typeof(EEstadoReserva)))
                cbEstado.Items.Add(valor);

            if (_reserva.FechaReserva == default)
                _reserva.FechaReserva = DateTime.Now;

            lblIdReserva.Text = _esNueva
                ? "(nueva)"
                : _reserva.IdReserva.ToString();

            dateTimePicker1.Value = _reserva.FechaReserva;

            if (cbEstado.Items.Contains(_reserva.Estado))
                cbEstado.SelectedItem = _reserva.Estado;
            else
                cbEstado.SelectedItem = EEstadoReserva.Pendiente;

            rtbObservaciones.Text = _reserva.Observaciones ?? string.Empty;

            CargarInfoPaseYUsuario();

            if (!_esNueva && _reserva.IdReserva != 0)
                CargarLineasReserva();
        }

        /// <summary>
        /// Asigna texto a una etiqueta si la referencia no es null.
        /// Útil para evitar comprobaciones repetitivas.
        /// </summary>
        private void SafeSet(Label? lbl, string texto)
        {
            if (lbl != null)
                lbl.Text = texto;
        }

        /// <summary>
        /// Carga y muestra la información del pase (película, sala, fecha)
        /// y del usuario asociado a la reserva.
        /// </summary>
        private void CargarInfoPaseYUsuario()
        {
            // -------- Info Pase / Película / Sala ----------
            if (_reserva.IdPase > 0)
            {
                var pase = AppContext.Pases.GetById(_reserva.IdPase);
                if (pase != null)
                {
                    SafeSet(lblPelicula, pase.TituloPelicula ?? "(película desconocida)");
                    SafeSet(lblSala, pase.NombreSala ?? $"Sala {pase.IdSala}");
                    SafeSet(lblPase, $"Pase #{pase.IdPase}");
                    SafeSet(lblFecha, pase.FechaHora.ToString("g"));
                }
                else
                {
                    SafeSet(lblPelicula, _reserva.PeliculaTitulo ?? "(película no disponible)");
                    SafeSet(lblSala, string.Empty);
                    SafeSet(lblPase, $"Pase #{_reserva.IdPase}");
                    SafeSet(lblFecha, _reserva.FechaReserva.ToString("g"));
                }
            }
            else
            {
                SafeSet(lblPelicula, _reserva.PeliculaTitulo ?? "(sin película)");
                SafeSet(lblSala, string.Empty);
                SafeSet(lblPase, "(sin pase)");
                SafeSet(lblFecha, _reserva.FechaReserva.ToString("g"));
            }

            // -------- Info usuario ----------
            if (!string.IsNullOrWhiteSpace(_reserva.UsuarioNombre))
            {
                SafeSet(lblUsuario, _reserva.UsuarioNombre!);
            }
            else if (_reserva.IdUsuario.HasValue && _reserva.IdUsuario.Value > 0)
            {
                var usuario = AppContext.Usuarios.GetById(_reserva.IdUsuario.Value);
                SafeSet(lblUsuario, usuario?.NombreUsuario ?? $"Id usuario {_reserva.IdUsuario.Value}");
            }
            else
            {
                SafeSet(lblUsuario, "Anónimo / sin usuario");
            }
        }

        /// <summary>
        /// Carga las líneas de la reserva desde base de datos y actualiza
        /// el grid y los totales de entradas e importes.
        /// </summary>
        private void CargarLineasReserva()
        {
            // Cargar líneas desde la BD
            _lineas = AppContext.Reservas.GetLineasDeReserva(_reserva.IdReserva);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _lineas;

            int nEntradas = _lineas.Count;
            decimal totalLineas = _lineas.Sum(l => l.Precio);

            // Nº entradas
            lbCantidadEntradas.Text = nEntradas.ToString();

            // Precio base (unitario aproximado)
            if (nEntradas > 0)
                lbCantidadPrecio.Text = _lineas[0].Precio.ToString("0.00 €");
            else
                lbCantidadPrecio.Text = "0.00 €";

            // Total ENTRADAS (suma de las líneas)
            lbCantidadTotalEntradas.Text = totalLineas.ToString("0.00 €");

            // Total RESERVA (campo Total de la reserva, o suma si es null)
            decimal totalReserva = _reserva.Total ?? totalLineas;
            lbCantidadTotalReservas.Text = totalReserva.ToString("0.00 €");
        }

        /// <summary>
        /// Valida y vuelca los datos del formulario sobre la reserva,
        /// guarda en base de datos (insert/update) y cierra con DialogResult.OK.
        /// </summary>
        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            _reserva.FechaReserva = dateTimePicker1.Value;

            if (cbEstado.SelectedItem is EEstadoReserva estado)
                _reserva.Estado = estado;
            else
                _reserva.Estado = EEstadoReserva.Pendiente;

            _reserva.Observaciones = string.IsNullOrWhiteSpace(rtbObservaciones.Text)
                ? null
                : rtbObservaciones.Text;

            if (_lineas.Count > 0)
                _reserva.Total = _lineas.Sum(l => l.Precio);

            if (_esNueva)
            {
                if (_reserva.IdPase <= 0)
                {
                    MessageBox.Show(
                        "No se puede guardar una reserva nueva sin un pase asociado.",
                        "Reservas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                _reserva.IdReserva = AppContext.Reservas.InsertReserva(_reserva);
            }
            else
            {
                AppContext.Reservas.UpdateReserva(_reserva);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cancela la edición de la reserva y cierra el formulario
        /// usando DialogResult.Cancel.
        /// </summary>
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Mantenido solo porque el diseñador lo tiene asignado.
        /// No realiza ninguna acción al cambiar el checkbox.
        /// </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Mantenido solo porque el diseñador lo tiene asignado.
        /// No realiza ninguna acción al pulsar sobre la etiqueta de precio.
        /// </summary>
        private void lbCantidadPrecio_Click(object sender, EventArgs e)
        {
        }
    }
}
