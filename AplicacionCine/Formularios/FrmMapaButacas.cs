using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AplicacionCine.DAO;
using AplicacionCine.Modelos;
using AplicacionCine.Utilidades;
using Npgsql;

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
        /// Estado visual / lógico dentro del mapa.
        /// NO es el mismo enum que el de Reservas.
        /// Solo se usa para pintar y decidir qué se guarda.
        /// </summary>
        private enum EstadoButaca
        {
            Libre = 0,
            Reservada = 1,   // nuevas reservas (rojas que grabaremos)
            Ocupada = 2,     // ya vendida (BD)
            NoAccesible = 3  // amarilla (config de sala)
        }

        /// <summary>
        /// Información asociada a cada botón del mapa:
        /// posición (fila/columna), estado y tipo de asiento.
        /// </summary>
        private class InfoButaca
        {
            public int Fila { get; set; }      // índice 0-based
            public int Columna { get; set; }   // índice 0-based
            public EstadoButaca Estado { get; set; }
            public TipoAsiento Tipo { get; set; }
        }

        /// <summary>
        /// Crea el mapa para una sala y un pase concretos.
        /// </summary>
        public FrmMapaButacas(Sala sala, Pase pase)
        {
            // Aplicamos tema antes de inicializar controles.
            TemaCine.Aplicar(this);

            _sala = sala ?? throw new ArgumentNullException(nameof(sala));
            _pase = pase ?? throw new ArgumentNullException(nameof(pase));

            InitializeComponent();
            InicializarMenuContexto();

            Load += FrmMapaButacas_Load;

            btnCancelar.Click += (s, e) => Close();
            btnConfirmarReserva.Click += BtnConfirmarReserva_Click;

            // Evitar que el usuario deforme el layout.
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Carga inicial: títulos, labels y construcción del grid
        /// + lectura del estado real desde BD.
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

        /// <summary>
        /// Crea y configura las opciones del menú contextual
        /// que se abre sobre una butaca.
        /// </summary>
        private void InicializarMenuContexto()
        {
            var itemLibre = new ToolStripMenuItem("Libre", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;

                // No dejamos liberar una butaca marcada como Ocupada (BD).
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

            _menuButaca.Items.Add(itemLibre);        // 0
            _menuButaca.Items.Add(itemReservada);    // 1
            _menuButaca.Items.Add(itemOcupada);      // 2
            _menuButaca.Items.Add(itemNoAccesible);  // 3
            _menuButaca.Items.Add(new ToolStripSeparator());
            _menuButaca.Items.Add(itemMovRed);       // 5
        }

        #endregion

        #region Construcción del grid

        /// <summary>
        /// Genera dinámicamente el TableLayoutPanel de butacas
        /// y crea un botón + InfoButaca por cada celda.
        /// </summary>
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

        /// <summary>
        /// Click izquierdo: alterna Libre/Reservada
        /// (respetando Ocupada y NoAccesible).
        /// </summary>
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

        /// <summary>
        /// Click derecho: abre menú contextual para editar estado/tipo.
        /// </summary>
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

        /// <summary>
        /// Asigna el icono apropiado según estado + tipo.
        /// </summary>
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

        /// <summary>
        /// Refresca el panel de "Selección" con la butaca actual.
        /// </summary>
        private void ActualizarLabelsSeleccion(InfoButaca info)
        {
            lbSdfila.Text = (info.Fila + 1).ToString();
            lbSdbu.Text = (info.Columna + 1).ToString();
            lbSdtipo.Text = info.Tipo.ToString();
            lbSdest.Text = info.Estado.ToString();
        }

        #endregion

        #region Cargar estado desde BD

        /// <summary>
        /// Lee de BD la configuración estructural de asientos
        /// (movilidad reducida / no accesible) y las butacas ocupadas
        /// para el pase actual, y las refleja en el mapa.
        /// </summary>
        private void CargarEstadoDesdeBD()
        {
            using var conn = DbConnectionFactory.CreateOpenConnection();

            // 1) Configuración de asientos (MR / NoAccesible).
            const string sqlAsientos = @"
                SELECT fila, columna, movilidad_reducida, no_accesible
                FROM asientos
                WHERE id_sala = @IdSala
                ORDER BY fila, columna;
            ";

            using (var cmdAs = new NpgsqlCommand(sqlAsientos, conn))
            {
                cmdAs.Parameters.AddWithValue("IdSala", _sala.IdSala);

                using var reader = cmdAs.ExecuteReader();
                while (reader.Read())
                {
                    int fila = reader.GetInt32(reader.GetOrdinal("fila"));
                    int col = reader.GetInt32(reader.GetOrdinal("columna"));

                    int f = fila - 1;
                    int c = col - 1;

                    if (f < 0 || f >= _sala.Filas || c < 0 || c >= _sala.Columnas)
                        continue;

                    var btn = _botones[f, c];
                    if (btn?.Tag is not InfoButaca info)
                        continue;

                    bool movRed = reader.GetBoolean(reader.GetOrdinal("movilidad_reducida"));
                    bool noAcc = reader.GetBoolean(reader.GetOrdinal("no_accesible"));

                    info.Tipo = movRed ? TipoAsiento.MovilidadReducida : TipoAsiento.Normal;
                    info.Estado = noAcc ? EstadoButaca.NoAccesible : EstadoButaca.Libre;

                    ActualizarIcono(btn, info);
                }
            }

            // 2) Butacas ocupadas para este pase (JOIN lineas_reserva + asientos).
            const string sqlOcupadas = @"
                SELECT a.fila, a.columna
                FROM lineas_reserva lr
                JOIN asientos a ON a.id_asiento = lr.id_asiento
                WHERE lr.id_pase = @IdPase;
            ";

            using (var cmdOc = new NpgsqlCommand(sqlOcupadas, conn))
            {
                cmdOc.Parameters.AddWithValue("IdPase", _pase.IdPase);

                using var reader = cmdOc.ExecuteReader();
                while (reader.Read())
                {
                    int fila = reader.GetInt32(reader.GetOrdinal("fila"));
                    int col = reader.GetInt32(reader.GetOrdinal("columna"));

                    int f = fila - 1;
                    int c = col - 1;

                    if (f < 0 || f >= _sala.Filas || c < 0 || c >= _sala.Columnas)
                        continue;

                    var btn = _botones[f, c];
                    if (btn?.Tag is not InfoButaca info)
                        continue;

                    info.Estado = EstadoButaca.Ocupada;
                    ActualizarIcono(btn, info);
                }
            }
        }

        #endregion

        #region Confirmar reserva + guardar configuración

        /// <summary>
        /// Confirma la reserva: crea Reserva + líneas para las butacas
        /// marcadas como Reservada/Ocupada y guarda configuración MR/NoAcc.
        /// </summary>
        private void BtnConfirmarReserva_Click(object? sender, EventArgs e)
        {
            // 1) Butacas que implican reserva (Reservada u Ocupada).
            var seleccionadas = ObtenerButacasReservadas();

            var usuario = AppContext.UsuarioActual;
            decimal precioUnitario = _pase.PrecioBase;
            if (precioUnitario <= 0) precioUnitario = 7.50m;

            int idReserva = 0;
            int numButacasReserva = seleccionadas.Count;
            decimal total = 0m;

            if (numButacasReserva > 0)
            {
                // 2) Crear reserva.
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

                // 3) Insertar líneas para las butacas seleccionadas (evitando duplicados).
                using var conn = DbConnectionFactory.CreateOpenConnection();

                foreach (var info in seleccionadas)
                {
                    int? idAsiento = TryGetIdAsiento(conn, info.Fila, info.Columna);
                    if (idAsiento == null)
                        continue;

                    if (ExisteLineaParaAsiento(conn, _pase.IdPase, idAsiento.Value))
                        continue;

                    var linea = new LineaReserva
                    {
                        IdReserva = idReserva,
                        IdAsiento = idAsiento.Value,
                        IdPase = _pase.IdPase,
                        Precio = precioUnitario,
                        EstadoLinea = "RESERVADA" // o "OCUPADA" si quieres distinguir.
                    };

                    AppContext.Reservas.InsertLinea(linea);
                }

                // 4) Guardar configuración estructural (MR / NoAccesible).
                using (var conn2 = DbConnectionFactory.CreateOpenConnection())
                {
                    GuardarConfiguracionAsientos(conn2);
                }

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
                // No hay reservas nuevas, pero sí queremos guardar la configuración de sala.
                using var conn = DbConnectionFactory.CreateOpenConnection();
                GuardarConfiguracionAsientos(conn);

                MessageBox.Show(
                    "Configuración de asientos guardada.\n" +
                    "No se han creado reservas nuevas.",
                    "Mapa de butacas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            Close();
        }

        /// <summary>
        /// Devuelve todas las butacas marcadas como Reservada u Ocupada
        /// en el grid actual.
        /// </summary>
        private List<InfoButaca> ObtenerButacasReservadas()
        {
            var lista = new List<InfoButaca>();

            foreach (Control ctrl in tlpButacas.Controls)
            {
                if (ctrl is Button b && b.Tag is InfoButaca info &&
                    (info.Estado == EstadoButaca.Reservada ||
                     info.Estado == EstadoButaca.Ocupada)) // <-- ahora también Ocupada
                {
                    lista.Add(info);
                }
            }

            return lista;
        }

        /// <summary>
        /// Comprueba si ya existe una línea para (idPase, idAsiento)
        /// para evitar duplicar reservas.
        /// </summary>
        private bool ExisteLineaParaAsiento(NpgsqlConnection conn, int idPase, int idAsiento)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM lineas_reserva
                WHERE id_pase = @IdPase
                  AND id_asiento = @IdAsiento;
            ";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdPase", idPase);
            cmd.Parameters.AddWithValue("IdAsiento", idAsiento);

            long count = Convert.ToInt64(cmd.ExecuteScalar());
            return count > 0;
        }

        /// <summary>
        /// Devuelve id_asiento para (fila, columna). Si no existe, devuelve null.
        /// </summary>
        private int? TryGetIdAsiento(NpgsqlConnection conn, int filaIdx, int colIdx)
        {
            const string sql = @"
                SELECT id_asiento
                FROM asientos
                WHERE id_sala = @IdSala
                  AND fila    = @Fila
                  AND columna = @Columna
                LIMIT 1;
            ";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdSala", _sala.IdSala);
            cmd.Parameters.AddWithValue("Fila", filaIdx + 1);
            cmd.Parameters.AddWithValue("Columna", colIdx + 1);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Persiste en la tabla ASIENTOS las flags de
        /// movilidad_reducida y no_accesible según el mapa actual.
        /// </summary>
        private void GuardarConfiguracionAsientos(NpgsqlConnection conn)
        {
            const string sql = @"
                UPDATE asientos
                SET movilidad_reducida = @MovRed,
                    no_accesible      = @NoAcc
                WHERE id_sala = @IdSala
                  AND fila    = @Fila
                  AND columna = @Columna;
            ";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.Add("MovRed", NpgsqlTypes.NpgsqlDbType.Boolean);
            cmd.Parameters.Add("NoAcc", NpgsqlTypes.NpgsqlDbType.Boolean);
            cmd.Parameters.Add("IdSala", NpgsqlTypes.NpgsqlDbType.Integer);
            cmd.Parameters.Add("Fila", NpgsqlTypes.NpgsqlDbType.Integer);
            cmd.Parameters.Add("Columna", NpgsqlTypes.NpgsqlDbType.Integer);

            foreach (Control ctrl in tlpButacas.Controls)
            {
                if (ctrl is not Button b || b.Tag is not InfoButaca info)
                    continue;

                cmd.Parameters["MovRed"].Value = (info.Tipo == TipoAsiento.MovilidadReducida);
                cmd.Parameters["NoAcc"].Value = (info.Estado == EstadoButaca.NoAccesible);
                cmd.Parameters["IdSala"].Value = _sala.IdSala;
                cmd.Parameters["Fila"].Value = info.Fila + 1;
                cmd.Parameters["Columna"].Value = info.Columna + 1;

                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        /// <summary>
        /// Resetea el panel de detalle de selección.
        /// </summary>
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
