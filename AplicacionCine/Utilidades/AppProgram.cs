using System;
using System.Windows.Forms;

namespace AplicacionCine.Utilidades
{
    /// <summary>
    /// Clase de utilidad para abrir formularios sin crear instancias duplicadas.
    /// 
    /// Uso típico desde FrmPrincipal:
    /// 
    /// private FrmPeliculas? _frmPeliculas;
    ///
    /// private void mnuPeliculas_Click(object sender, EventArgs e)
    /// {
    ///     FormHelper.AbrirFormulario(ref _frmPeliculas, this);
    /// }
    /// </summary>
    public static class AppProgram
    {
        /// <summary>
        /// Abre un formulario asegurando una única instancia por referencia.
        /// Si la instancia es null o está disposeda, crea una nueva.
        /// Si ya existe, la trae al frente.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo del formulario a abrir (debe heredar de Form y tener constructor sin parámetros).
        /// </typeparam>
        /// <param name="instancia">
        /// Referencia a la variable que guarda la instancia del formulario.
        /// Normalmente un campo privado del formulario principal.
        /// </param>
        /// <param name="owner">
        /// Formulario propietario (opcional). Si se pasa, se usa como Owner.
        /// </param>
        public static void AbrirFormulario<T>(ref T instancia, Form? owner = null)
            where T : Form, new()
        {
            // Si no hay instancia o está disposeda, creamos una nueva
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new T();

                if (owner != null)
                {
                    instancia.StartPosition = FormStartPosition.CenterParent;
                    instancia.Show(owner);
                }
                else
                {
                    instancia.StartPosition = FormStartPosition.CenterScreen;
                    instancia.Show();
                }
            }
            else
            {
                // Ya existe la instancia
                if (!instancia.Visible)
                {
                    if (owner != null)
                    {
                        instancia.Show(owner);
                    }
                    else
                    {
                        instancia.Show();
                    }
                }

                instancia.BringToFront();
            }
        }

        /// <summary>
        /// Abre un formulario como diálogo modal, creando siempre una nueva instancia.
        /// Devuelve el DialogResult.
        /// Uso típico: FormHelper.AbrirDialogo&lt;FrmUsuario&gt;();
        /// </summary>
        public static DialogResult AbrirDialogo<T>(Form? owner = null)
            where T : Form, new()
        {
            using (var frm = new T())
            {
                frm.StartPosition = FormStartPosition.CenterParent;

                if (owner != null)
                {
                    return frm.ShowDialog(owner);
                }
                else
                {
                    return frm.ShowDialog();
                }
            }
        }
    }
}
