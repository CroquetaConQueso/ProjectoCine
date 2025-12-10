using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AplicacionCine.DAO;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    /// <summary>
    /// Mapa visual de butacas para una sala + pase concreto.
    /// Permite ver ocupación, marcar nuevas reservas y guardar
    /// la configuración estructural de los asientos.
    /// </summary>
    public partial class FrmMapaButacas : Form
    {
        private readonly Sala _sala;
        private readonly Pase _pase;

        // Matriz de botones físicos en el TableLayoutPanel.
        private Button[,] _botones = new Button[1, 1];

        // Menú contextual asociado a cada butaca.
        private readonly ContextMenuStrip _menuButaca = new ContextMenuStrip();
        private InfoButaca? _butacaContexto;
        private Button? _btnContexto;

        /// <summary>
        /// Crea el mapa para una sala y un pase concretos.
        /// </summary>
        public FrmMapaButacas(Sala sala, Pase pase)
        {
            TemaCine.Aplicar(this);

            _sala = sala ?? throw new ArgumentNullException(nameof(sala));
            _pase = pase ?? throw new ArgumentNullException(nameof(pase));

            InitializeComponent();
            InicializarMenuContexto();

            Load += FrmMapaButacas_Load;

            btnCancelar.Click += (s, e) => Close();
            btnConfirmarReserva.Click += BtnConfirmarReserva_Click;

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Carga inicial: títulos, labels y construcción del grid
        /// + lectura del estado real desde BD (vía DAOs).
        /// </summary>
        private void FrmMapaButacas_Load(object? sender, EventArgs e)
        {
            Text = $"Mapa de butacas - {_sala.Nombre}";
            lbTitulo.Text = Text;

            lbFeedButacas.Text =
                $"Sala: {_sala.Nombre} · Filas: {_sala.Filas} · Columnas: {_sala.Columnas} · Capacidad: {_sala.Capacidad}";
            lbInfoButacas.Text =
                $"Pase: {_pase.TituloPelicula ?? "(sin título)"} · {_pase.FechaHora:dd/MM/yyyy HH:mm}";

            LimpiarSeleccion();
            ConstruirGrid();
            CargarEstadoDesdeBD();
        }

        #region Menú contextual

        private void InicializarMenuContexto()
        {
            var itemLibre = new ToolStripMenuItem("Libre", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                if (_butacaContexto.Estado == EstadoButaca.Ocupada)
                {
                    ActualizarLabelsSeleccion(_butacaContexto);
                    return;
                }

                _butacaContexto.Estado = EstadoButaca.Libre;
                ActualizarIcono(_btnContexto, _butacaContexto);
                ActualizarLabelsSeleccion(_butacaContexto);
            });

            var itemReservada = new ToolStripMenuItem("Reservada (nueva)", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                if (_butacaContexto.Estado == EstadoButaca.NoAccesible ||
                    _butacaContexto.Estado == EstadoButaca.Ocupada)
                {
                    ActualizarLabelsSeleccion(_butacaContexto);
                    return;
                }

                _butacaContexto.Estado = EstadoButaca.Reservada;
                ActualizarIcono(_btnContexto, _butacaContexto);
                ActualizarLabelsSeleccion(_butacaContexto);
            });

            var itemOcupada = new ToolStripMenuItem("Ocupada (BD)", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                _butacaContexto.Estado = EstadoButaca.Ocupada;
                ActualizarIcono(_btnContexto, _butacaContexto);
                ActualizarLabelsSeleccion(_butacaContexto);
            });

            var itemNoAccesible = new ToolStripMenuItem("No accesible", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                _butacaContexto.Estado = EstadoButaca.NoAccesible;
                ActualizarIcono(_btnContexto, _butacaContexto);
                ActualizarLabelsSeleccion(_butacaContexto);
            });

            var itemMovRed = new ToolStripMenuItem("Movilidad reducida")
            {
                CheckOnClick = true
            };
            itemMovRed.CheckedChanged += (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                _butacaContexto.Tipo = itemMovRed.Checked
                    ? TipoAsiento.MovilidadReducida
                    : TipoAsiento.Normal;

                ActualizarIcono(_btnContexto, _butacaContexto);
                ActualizarLabelsSeleccion(_butacaContexto);
            };

            _menuButaca.Items.Add(itemLibre);
            _menuButaca.Items.Add(itemReservada);
            _menuButaca.Items.Add(itemOcupada);
            _menuButaca.Items.Add(itemNoAccesible);
            _menuButaca.Items.Add(new ToolStripSeparator());
            _menuButaca.Items.Add(itemMovRed);
        }

        #endregion

        #region Construcción del grid

        private void ConstruirGrid()
        {
            var filas = _sala.Filas <= 0 ? 4 : _sala.Filas;
            var columnas = _sala.Columnas <= 0 ? 4 : _sala.Columnas;

            _botones = new Button[filas, columnas];

            tlpButacas.SuspendLayout();
            tlpButacas.Controls.Clear();

            tlpButacas.RowCount = filas;
            tlpButacas.ColumnCount = columnas;
            tlpButacas.RowStyles.Clear();
            tlpButacas.ColumnStyles.Clear();

            for (int f = 0; f < filas; f++)
                tlpButacas.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / filas));
            for (int c = 0; c < columnas; c++)
                tlpButacas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnas));

            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    var info = new InfoButaca
                    {
                        Fila = f,
                        Columna = c,
                        Estado = EstadoButaca.Libre,
                        Tipo = TipoAsiento.Normal
                    };

                    var btn = new Button
                    {
                        Size = new Size(40, 40),
                        Anchor = AnchorStyles.None,
                        Margin = new Padding(4),
                        Tag = info,
                        FlatStyle = FlatStyle.Flat,
                        Text = string.Empty,
                        BackgroundImageLayout = ImageLayout.Zoom
                    };
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Click += BotonButaca_Click;
                    btn.MouseUp += BotonButaca_MouseUp;

                    _botones[f, c] = btn;
                    tlpButacas.Controls.Add(btn, c, f);

                    ActualizarIcono(btn, info);
                }
            }

            tlpButacas.ResumeLayout();
        }

        #endregion

        #region Eventos de butaca

        private void BotonButaca_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (btn.Tag is not InfoButaca info) return;

            if (info.Estado == EstadoButaca.Ocupada ||
                info.Estado == EstadoButaca.NoAccesible)
            {
                ActualizarLabelsSeleccion(info);
                return;
            }

            info.Estado = info.Estado == EstadoButaca.Libre
                ? EstadoButaca.Reservada
                : EstadoButaca.Libre;

            ActualizarIcono(btn, info);
            ActualizarLabelsSeleccion(info);
        }

        private void BotonButaca_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (sender is not Button btn) return;
            if (btn.Tag is not InfoButaca info) return;

            _btnContexto = btn;
            _butacaContexto = info;

            if (_menuButaca.Items[0] is ToolStripMenuItem miLibre &&
                _menuButaca.Items[1] is ToolStripMenuItem miReservada &&
                _menuButaca.Items[2] is ToolStripMenuItem miOcupada &&
                _menuButaca.Items[3] is ToolStripMenuItem miNoAcc &&
                _menuButaca.Items[5] is ToolStripMenuItem miMovRed)
            {
                miLibre.Checked = info.Estado == EstadoButaca.Libre;
                miReservada.Checked = info.Estado == EstadoButaca.Reservada;
                miOcupada.Checked = info.Estado == EstadoButaca.Ocupada;
                miNoAcc.Checked = info.Estado == EstadoButaca.NoAccesible;
                miMovRed.Checked = info.Tipo == TipoAsiento.MovilidadReducida;
            }

            _menuButaca.Show(Cursor.Position);
        }

        private void ActualizarIcono(Button btn, InfoButaca info)
        {
            bool di = info.Tipo == TipoAsiento.MovilidadReducida;

            switch (info.Estado)
            {
                case EstadoButaca.Libre:
                    btn.BackgroundImage = di
                        ? Properties.Resources.LibreDi_32
                        : Properties.Resources.Libre_32;
                    break;

                case EstadoButaca.Reservada:
                    btn.BackgroundImage = di
                        ? Properties.Resources.ReservadoDi_32
                        : Properties.Resources.Reservado_32;
                    break;

                case EstadoButaca.Ocupada:
                    btn.BackgroundImage = di
                        ? Properties.Resources.OcupadoDi_32
                        : Properties.Resources.Ocupado_32;
                    break;

                case EstadoButaca.NoAccesible:
                    btn.BackgroundImage = di
                        ? Properties.Resources.SeleccionadoDi_32
                        : Properties.Resources.Seleccionado_32;
                    break;
            }
        }

        private void ActualizarLabelsSeleccion(InfoButaca info)
        {
            lbSdfila.Text = (info.Fila + 1).ToString();
            lbSdbu.Text = (info.Columna + 1).ToString();
            lbSdtipo.Text = info.Tipo.ToString();
            lbSdest.Text = info.Estado.ToString();
        }

        #endregion

        #region Cargar estado desde BD

        private void CargarEstadoDesdeBD()
        {
            // 1) Configuración estructural.
            var config = AppContext.Asientos.GetConfiguracionSala(_sala.IdSala);

            foreach (var (fila, columna, movRed, noAcc) in config)
            {
                int f = fila - 1;
                int c = columna - 1;

                if (f < 0 || f >= _sala.Filas || c < 0 || c >= _sala.Columnas)
                    continue;

                var btn = _botones[f, c];
                if (btn?.Tag is not InfoButaca info)
                    continue;

                info.Tipo = movRed ? TipoAsiento.MovilidadReducida : TipoAsiento.Normal;
                info.Estado = noAcc ? EstadoButaca.NoAccesible : EstadoButaca.Libre;

                ActualizarIcono(btn, info);
            }

            // 2) Butacas ocupadas (ignorando reservas CANCELADAS y líneas CANCELADAS).
            var ocupadas = AppContext.Reservas.GetButacasOcupadasDePase(_pase.IdPase);

            foreach (var (fila, columna) in ocupadas)
            {
                int f = fila - 1;
                int c = columna - 1;

                if (f < 0 || f >= _sala.Filas || c < 0 || c >= _sala.Columnas)
                    continue;

                var btn = _botones[f, c];
                if (btn?.Tag is not InfoButaca info)
                    continue;

                info.Estado = EstadoButaca.Ocupada;
                ActualizarIcono(btn, info);
            }
        }

        #endregion

        #region Confirmar reserva + guardar configuración

        private void BtnConfirmarReserva_Click(object? sender, EventArgs e)
        {
            // Reservada u Ocupada: ambas generan línea de reserva.
            var seleccionadas = ObtenerButacasReservadas();

            var usuario = AppContext.UsuarioActual;
            decimal precioUnitario = _pase.PrecioBase;
            if (precioUnitario <= 0) precioUnitario = 7.50m;

            int idReserva = 0;
            int numButacasReserva = seleccionadas.Count;
            decimal total = 0m;

            if (numButacasReserva > 0)
            {
                total = precioUnitario * numButacasReserva;

                var reserva = new Reserva
                {
                    IdPase = _pase.IdPase,
                    IdUsuario = usuario?.IdUsuario,
                    FechaReserva = DateTime.Now,
                    Estado = EEstadoReserva.Confirmada,
                    Total = total,
                    Observaciones = $"Reserva automática de {_sala.Nombre}"
                };

                idReserva = AppContext.Reservas.InsertReserva(reserva);

                foreach (var info in seleccionadas)
                {
                    int? idAsiento = AppContext.Asientos.GetIdAsiento(_sala.IdSala, info.Fila, info.Columna);
                    if (idAsiento == null)
                        continue;

                    if (AppContext.Reservas.ExisteLineaParaAsiento(_pase.IdPase, idAsiento.Value))
                        continue;

                    var linea = new LineaReserva
                    {
                        IdReserva = idReserva,
                        IdAsiento = idAsiento.Value,
                        IdPase = _pase.IdPase,
                        Precio = precioUnitario,
                        EstadoLinea = info.Estado == EstadoButaca.Ocupada
                            ? "OCUPADA"
                            : "RESERVADA"
                    };

                    AppContext.Reservas.InsertLinea(linea);
                }

                AppContext.Asientos.GuardarConfiguracionSala(_sala.IdSala, EnumerarInfoButacas());

                MessageBox.Show(
                    $"Cambios guardados.\n" +
                    $"Reserva creada: {idReserva}\n" +
                    $"Butacas afectadas: {numButacasReserva}\n" +
                    $"Total reserva: {total:0.00} €",
                    "Mapa de butacas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                AppContext.Asientos.GuardarConfiguracionSala(_sala.IdSala, EnumerarInfoButacas());

                MessageBox.Show(
                    "Configuración de asientos guardada.\n" +
                    "No se han creado reservas nuevas.",
                    "Mapa de butacas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Close();
        }

        private List<InfoButaca> ObtenerButacasReservadas()
        {
            var lista = new List<InfoButaca>();

            foreach (Control ctrl in tlpButacas.Controls)
            {
                if (ctrl is Button b && b.Tag is InfoButaca info &&
                    (info.Estado == EstadoButaca.Reservada ||
                     info.Estado == EstadoButaca.Ocupada))
                {
                    lista.Add(info);
                }
            }

            return lista;
        }

        private IEnumerable<InfoButaca> EnumerarInfoButacas()
        {
            foreach (Control ctrl in tlpButacas.Controls)
            {
                if (ctrl is Button b && b.Tag is InfoButaca info)
                    yield return info;
            }
        }

        #endregion

        private void LimpiarSeleccion()
        {
            lbSdfila.Text = "-";
            lbSdbu.Text = "-";
            lbSdtipo.Text = "-";
            lbSdest.Text = "-";
            lbSdpb.Text = "-";
            lbSdpf.Text = "-";
        }
    }
}
