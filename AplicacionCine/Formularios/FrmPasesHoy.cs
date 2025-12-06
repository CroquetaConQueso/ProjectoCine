using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmPasesHoy : Form
    {
        private readonly BindingSource _bsPases = new BindingSource();
        private List<Pase> _listaCompleta = new List<Pase>();

        public FrmPasesHoy()
        {
            InitializeComponent();

            Load += FrmPasesHoy_Load;
            btnBuscar.Click += BtnBuscar_Click;
            btnHoy.Click += BtnHoy_Click;
            btnCerrar.Click += BtnCerrar_Click;
            btnVerButacas.Click += BtnVerButacas_Click;

            dgvPases.AutoGenerateColumns = true;
            dgvPases.DataSource = _bsPases;
        }

        private void FrmPasesHoy_Load(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarPeliculas();
            ActualizarEstadoUsuario();
            CargarPases();
        }

        private void CargarPeliculas()
        {
            var pelis = AppContext.Peliculas.GetAll();
            cbPeliculas.DisplayMember = "Titulo";
            cbPeliculas.ValueMember = "IdPelicula";
            cbPeliculas.DataSource = pelis;
            cbPeliculas.SelectedIndex = -1;
        }

        private void ActualizarEstadoUsuario()
        {
            var u = AppContext.UsuarioActual;
            if (u == null)
            {
                tsslUsuario.Text = "(sin sesión)";
                tsslRol.Text = string.Empty;
                tsslEstado.Text = "Desconectado";
            }
            else
            {
                tsslUsuario.Text = u.NombreUsuario;
                tsslRol.Text = u.Rol.ToString();
                tsslEstado.Text = "Listo";
            }
        }

        private void CargarPases()
        {
            int? idPeli = null;
            if (cbPeliculas.SelectedItem is Pelicula peli)
                idPeli = peli.IdPelicula;

            var fecha = dtpFecha.Value.Date;
            _listaCompleta = AppContext.Pases.GetPasesDeFecha(fecha, idPeli);
            _bsPases.DataSource = new BindingList<Pase>(_listaCompleta);
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            CargarPases();
        }

        private void BtnHoy_Click(object? sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarPases();
        }

        private Pase? GetPaseActual()
        {
            return _bsPases.Current as Pase;
        }

        private void BtnVerButacas_Click(object? sender, EventArgs e)
        {
            var pase = GetPaseActual();
            if (pase == null)
            {
                MessageBox.Show("Selecciona un pase.", "Pases",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmMapaButacas();
            frm.MdiParent = MdiParent;
            frm.Show();
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
