using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmMapaButacas : Form
    {
        private readonly Sala _sala;
        private readonly Pase _pase;

        private Button[,] _botones = new Button[1, 1];
        private readonly ContextMenuStrip _menuButaca = new ContextMenuStrip();
        private InfoButaca? _butacaContexto;
        private Button? _btnContexto;

        private class InfoButaca
        {
            public int Fila { get; set; }
            public int Columna { get; set; }
            public EstadoButaca Estado { get; set; }
            public TipoAsiento Tipo { get; set; }
        }

        public FrmMapaButacas(Sala sala, Pase pase)
        {
            _sala = sala ?? throw new ArgumentNullException(nameof(sala));
            _pase = pase ?? throw new ArgumentNullException(nameof(pase));

            InitializeComponent();
            InicializarMenuContexto();
            Load += FrmMapaButacas_Load;
        }

        private void FrmMapaButacas_Load(object? sender, EventArgs e)
        {
            Text = $"Mapa de butacas - {_sala.Nombre}";
            ConstruirGrid();
        }

        private void InicializarMenuContexto()
        {
            var itemLibre = new ToolStripMenuItem("Libre", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;
                _butacaContexto.Estado = EstadoButaca.Libre;
                ActualizarIcono(_btnContexto, _butacaContexto);
            });

            var itemReservada = new ToolStripMenuItem("Reservada", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;
                _butacaContexto.Estado = EstadoButaca.Reservada;
                ActualizarIcono(_btnContexto, _butacaContexto);
            });

            var itemOcupada = new ToolStripMenuItem("Ocupada", null, (s, e) =>
            {
                if (_butacaContexto == null || _btnContexto == null) return;
                _butacaContexto.Estado = EstadoButaca.Ocupada;
                ActualizarIcono(_btnContexto, _butacaContexto);
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
            };

            _menuButaca.Items.Add(itemLibre);      // 0
            _menuButaca.Items.Add(itemReservada);  // 1
            _menuButaca.Items.Add(itemOcupada);    // 2
            _menuButaca.Items.Add(new ToolStripSeparator());
            _menuButaca.Items.Add(itemMovRed);     // 4
        }

        private void ConstruirGrid()
        {
            // cogemos filas/columnas de Sala, con un mínimo por seguridad
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
                        Dock = DockStyle.Fill,
                        Margin = new Padding(4),
                        Tag = info,
                        FlatStyle = FlatStyle.Flat,
                        Text = string.Empty
                    };
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Click += BotonButaca_Click;       // click izq
                    btn.MouseUp += BotonButaca_MouseUp;   // click der

                    _botones[f, c] = btn;
                    tlpButacas.Controls.Add(btn, c, f);

                    ActualizarIcono(btn, info);
                }
            }

            tlpButacas.ResumeLayout();
        }

        private void BotonButaca_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (btn.Tag is not InfoButaca info) return;

            if (info.Estado == EstadoButaca.Reservada ||
                info.Estado == EstadoButaca.Ocupada)
                return;

            info.Estado = info.Estado == EstadoButaca.Libre
                ? EstadoButaca.Seleccionada
                : EstadoButaca.Libre;

            ActualizarIcono(btn, info);
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
                _menuButaca.Items[4] is ToolStripMenuItem miMovRed)
            {
                miLibre.Checked = info.Estado == EstadoButaca.Libre;
                miReservada.Checked = info.Estado == EstadoButaca.Reservada;
                miOcupada.Checked = info.Estado == EstadoButaca.Ocupada;
                miMovRed.Checked = info.Tipo == TipoAsiento.MovilidadReducida;
            }

            _menuButaca.Show(Cursor.Position);
        }

        private void ActualizarIcono(Button btn, InfoButaca info)
        {
            bool di = info.Tipo == TipoAsiento.MovilidadReducida;

            if (info.Estado == EstadoButaca.Libre)
                btn.BackgroundImage = di
                    ? Properties.Resources.LibreDi_32
                    : Properties.Resources.Libre_32;
            else if (info.Estado == EstadoButaca.Seleccionada)
                btn.BackgroundImage = di
                    ? Properties.Resources.SeleccionadoDi_32
                    : Properties.Resources.Seleccionado_32;
            else if (info.Estado == EstadoButaca.Reservada)
                btn.BackgroundImage = di
                    ? Properties.Resources.ReservadoDi_32
                    : Properties.Resources.Reservado_32;
            else if (info.Estado == EstadoButaca.Ocupada)
                btn.BackgroundImage = di
                    ? Properties.Resources.OcupadoDi_32
                    : Properties.Resources.Ocupado_32;
        }

        public IEnumerable<(int fila, int columna)> ObtenerSeleccionadas()
        {
            var lista = new List<(int, int)>();

            foreach (Control ctrl in tlpButacas.Controls)
            {
                if (ctrl is Button b && b.Tag is InfoButaca info &&
                    info.Estado == EstadoButaca.Seleccionada)
                {
                    lista.Add((info.Fila, info.Columna));
                }
            }

            return lista;
        }
    }
}
