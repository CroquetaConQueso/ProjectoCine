using System;
using System.Windows.Forms;
using AplicacionCine.Utilidades;
using AplicacionCine.Modelos;

namespace AplicacionCine.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private FrmBrowUsuarios? _frmBrowUsuarios;
        private FrmBrowEmpleados? _frmBrowEmpleados;
        private FrmPeliculas? _frmPeliculas;
        private FrmSalas? _frmSalas;
        private FrmPasesHoy? _frmPasesHoy;
        private FrmBrowReservas? _frmBrowReservas;
        private FrmMapaButacas? _frmMapaButacas;

        public FrmPrincipal()
        {
            InitializeComponent();

            // Contenedor MDI
            IsMdiContainer = true;

            // Eventos del propio formulario
            Load += FrmPrincipal_Load;
            FormClosed += FrmPrincipal_FormClosed;

            // Eventos de botones del ToolStrip
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

            if (u == null)
            {
                tsLusuario.Text = "(sin sesión)";
                tsLestado.Text = "";
                tsLsituacion.Text = "Desconectado";
                return;
            }

            tsLusuario.Text = u.Login;
            tsLestado.Text = u.Rol.ToString();
            tsLsituacion.Text = "Listo";
        }

        private void FrmPrincipal_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

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
            MessageBox.Show("Pantalla de configuración pendiente de implementar.",
                "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnNavSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
