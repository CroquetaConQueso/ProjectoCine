using System;
using System.Windows.Forms;
using Npgsql;
using AplicacionCine.Utilidades;
using AplicacionCine;   // para DbConnectionFactory

namespace AplicacionCine.Formularios
{
    public partial class FrmConfiguracion : Form
    {
        public FrmConfiguracion()
        {
            InitializeComponent();
            TemaCine.Aplicar(this);
            // Ventana fija, sin maximizar
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterParent;

            Load += FrmConfiguracion_Load;
            btnProbar.Click += BtnProbar_Click;
            button2.Click += ButtonGuardar_Click; // button2 = Guardar
        }

        private void FrmConfiguracion_Load(object? sender, EventArgs e)
        {
            // Cargar valores actuales desde DbRuntimeConfig
            txtServidor.Text = DbRuntimeConfig.Servidor;
            txtBaseDatos.Text = DbRuntimeConfig.BaseDatos;
            txtUsuario.Text = DbRuntimeConfig.Usuario;
            txtContrasena.Text = DbRuntimeConfig.Contrasena;
            textBox1.Text = DbRuntimeConfig.ConnectionString;

            tslConfigEstado.Text = "Configuración cargada.";
        }

        private void BtnProbar_Click(object? sender, EventArgs e)
        {
            tslConfigEstado.Text = "Probando conexión...";

            // Construimos una cadena de prueba con lo que hay en los TextBox
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = txtServidor.Text.Trim(),
                Database = txtBaseDatos.Text.Trim(),
                Username = txtUsuario.Text.Trim(),
                Password = txtContrasena.Text,
                Port = DbRuntimeConfig.Puerto
            };

            string cadena = builder.ConnectionString;
            textBox1.Text = cadena;

            try
            {
                using var cn = new NpgsqlConnection(cadena);
                cn.Open();
                tslConfigEstado.Text = "Conexión correcta.";
            }
            catch (Exception ex)
            {
                tslConfigEstado.Text = $"Error de conexión: {ex.Message}";
            }
        }

        private void ButtonGuardar_Click(object? sender, EventArgs e)
        {
            // Actualizamos la configuración en memoria
            DbRuntimeConfig.Servidor = txtServidor.Text.Trim();
            DbRuntimeConfig.BaseDatos = txtBaseDatos.Text.Trim();
            DbRuntimeConfig.Usuario = txtUsuario.Text.Trim();
            DbRuntimeConfig.Contrasena = txtContrasena.Text;

            // Regenerar cadena y aplicar a DbConnectionFactory
            var nuevaCadena = DbRuntimeConfig.ConnectionString;
            textBox1.Text = nuevaCadena;

            DbConnectionFactory.Configure(nuevaCadena);

            tslConfigEstado.Text = "Configuración actualizada (en memoria).";
        }
    }
}
