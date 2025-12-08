using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;
using AplicacionCine.DAO;
using AplicacionCine;

namespace AplicacionCine.Formularios
{
    public partial class FrmReserva : Form
    {
        private Reserva _reserva;
        private bool _esNueva;
        private List<LineaReserva> _lineas = new List<LineaReserva>();

        public FrmReserva()
        {
            InitializeComponent();

            _reserva = new Reserva
            {
                FechaReserva = DateTime.Now,
                Estado = EEstadoReserva.Pendiente
            };
            _esNueva = true;

            InicializarEventos();
        }

        public FrmReserva(Reserva reserva)
        {
            InitializeComponent();

            _reserva = reserva ?? throw new ArgumentNullException(nameof(reserva));
            _esNueva = reserva.IdReserva == 0;

            InicializarEventos();
        }

        private void InicializarEventos()
        {
            Load += FrmReserva_Load;
            btnAceptar.Click += BtnAceptar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

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

        private void SafeSet(Label? lbl, string texto)
        {
            if (lbl != null)
                lbl.Text = texto;
        }

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

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lbCantidadPrecio_Click(object sender, EventArgs e)
        {
        }
    }
}
