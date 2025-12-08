using System;
using System.Windows.Forms;
using AplicacionCine.Utilidades;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    /// <summary>
    /// Ventana principal MDI: navegación, menús y estado del usuario.
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        private FrmBrowUsuarios? _frmBrowUsuarios;
        private FrmPeliculas? _frmPeliculas;
        private FrmSalas? _frmSalas;
        private FrmPasesHoy? _frmPasesHoy;
        private FrmBrowReservas? _frmBrowReservas;
        private FrmMapaButacas? _frmMapaButacas;
        private FrmConfiguracion? _frmConfiguracion;

        public FrmPrincipal()
        {
            InitializeComponent();

            TemaCine.Aplicar(this);
            IsMdiContainer = true;

            Load += FrmPrincipal_Load;
            FormClosed += FrmPrincipal_FormClosed;

            // ToolStrip navegación
            btnNavPases.Click += BtnNavPases_Click;
            btnNavReservas.Click += BtnNavReservas_Click;
            btnNavPeliculas.Click += BtnNavPeliculas_Click;
            btnNavSalas.Click += BtnNavSalas_Click;
            btnNavUsuarios.Click += BtnNavUsuarios_Click;
            btnNavConfiguracion.Click += BtnNavConfiguracion_Click;
            btnNavSalir.Click += BtnNavSalir_Click;

            // MenuStrip
            // Archivo
            configuracionDeConexionToolStripMenuItem.Click += BtnNavConfiguracion_Click;
            salirToolStripMenuItem.Click += BtnNavSalir_Click;

            // Navegación
            pasesDeHoyToolStripMenuItem.Click += BtnNavPases_Click;
            reservasToolStripMenuItem.Click += BtnNavReservas_Click;
            peliculasToolStripMenuItem.Click += BtnNavPeliculas_Click;
            salasToolStripMenuItem.Click += BtnNavSalas_Click;
            usuariosToolStripMenuItem.Click += BtnNavUsuarios_Click;

            // Ventanas MDI
            cascadaToolStripMenuItem.Click += CascadaToolStripMenuItem_Click;
            mosaicoHorizontalToolStripMenuItem.Click += MosaicoHorizontalToolStripMenuItem_Click;
            mosaicoVerticalToolStripMenuItem.Click += MosaicoVerticalToolStripMenuItem_Click;
            cerrarTodasToolStripMenuItem.Click += CerrarTodasToolStripMenuItem_Click;

            // Ayuda
            acercaDeToolStripMenuItem.Click += AcercaDeToolStripMenuItem_Click;
        }

        private void FrmPrincipal_Load(object? sender, EventArgs e)
        {
            var u = AppContext.UsuarioActual;

            if (u == null)
            {
                tsLusuario.Text = "(sin sesión)";
                tsLestado.Text = "";
                return;
            }

            tsLusuario.Text = u.Login;
            tsLestado.Text = u.Rol.ToString();
        }

        private void FrmPrincipal_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Navegación

        private void BtnNavPases_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmPasesHoy, this);
        }

        private void BtnNavReservas_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmBrowReservas, this);
        }

        private void BtnNavPeliculas_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmPeliculas, this);
        }

        private void BtnNavSalas_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmSalas, this);
        }

        private void BtnNavUsuarios_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmBrowUsuarios, this);
        }

        private void BtnNavConfiguracion_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmConfiguracion, this);
        }

        private void BtnNavSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Ventanas MDI (Gestión)

        private void CascadaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MosaicoHorizontalToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MosaicoVerticalToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void CerrarTodasToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
                child.Close();
        }

        #endregion

        #region Ayuda

        private void AcercaDeToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(
                "Aplicación de gestión de cine\n" +
                "DAM - Proyecto práctico",
                "Acerca de…",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        /// <summary>
        /// Mantenido solo porque el diseñador lo tiene asignado al menú raíz "Gestión".
        /// No hace nada para evitar que se abra ningún formulario al pulsar en el título.
        /// </summary>
        private void pasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Intencionadamente vacío.
        }
    }
}
