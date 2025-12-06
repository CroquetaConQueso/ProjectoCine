using System;
using System.Windows.Forms;
using AplicacionCine.Utilidades;

namespace AplicacionCine.Formularios
{
    public partial class FrmPrincipal : Form
    {
        // Instancias únicas de cada formulario de trabajo
        private FrmBrowUsuarios? _frmBrowUsuarios;
        private FrmBrowEmpleados? _frmBrowEmpleados;
        private FrmPeliculas? _frmPeliculas;
        private FrmSalas? _frmSalas;
        private FrmPasesHoy? _frmPasesHoy;
        private FrmBrowReservas? _frmReservas;
        private FrmMapaButacas? _frmMapaButacas;

        public FrmPrincipal()
        {
            InitializeComponent();

            // Eventos de ciclo de vida
            Load += FrmPrincipal_Load;
            FormClosed += FrmPrincipal_FormClosed;

            // Eventos de navegación lateral
            btnNavPases.Click += BtnNavPases_Click;
            btnNavReservas.Click += BtnNavReservas_Click;
            btnNavPeliculas.Click += BtnNavPeliculas_Click;
            btnNavSalas.Click += BtnNavSalas_Click;
            btnNavUsuarios.Click += BtnNavUsuarios_Click;
            btnNavConfiguracion.Click += BtnNavConfiguracion_Click;
            btnNavSalir.Click += BtnNavSalir_Click;
        }

        private void FrmPrincipal_Load(object? sender, EventArgs e)
        {
            var u = AppContext.UsuarioActual;

            if (u != null)
            {
                // tsLnombreUsuario y tsLestado son textos fijos.
                // Sólo actualizamos el valor dinámico y la situación.
                tsLusuario.Text = u.NombreUsuario;
                tsLsituacion.Text = "Listo";
            }
            else
            {
                tsLusuario.Text = "(no conectado)";
                tsLsituacion.Text = "Sin sesión";
            }
        }

        private void FrmPrincipal_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Cerramos toda la aplicación cuando se cierra la ventana principal
            Application.Exit();
        }

        // ---------------- Navegación ToolStrip lateral ----------------

        private void BtnNavPases_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmPasesHoy, this);
        }

        private void BtnNavReservas_Click(object? sender, EventArgs e)
        {
            AppProgram.AbrirFormulario(ref _frmReservas, this);
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
            // De momento no hay formulario de configuración implementado.
            MessageBox.Show(
                "Pantalla de configuración pendiente de implementar.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void BtnNavSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
