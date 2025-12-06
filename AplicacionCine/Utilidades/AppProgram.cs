using System;
using System.Windows.Forms;

namespace AplicacionCine.Utilidades
{
    public static class AppProgram
    {
        public static void AbrirFormulario<T>(ref T instancia, Form? owner = null)
            where T : Form, new()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new T();

                if (owner != null && owner.IsMdiContainer)
                {
                    instancia.MdiParent = owner;
                    instancia.StartPosition = FormStartPosition.Manual;
                    instancia.WindowState = FormWindowState.Normal;
                    instancia.Show();
                    owner.LayoutMdi(MdiLayout.Cascade);
                }
                else if (owner != null)
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
                if (!instancia.Visible)
                {
                    if (owner != null && owner.IsMdiContainer)
                    {
                        instancia.MdiParent = owner;
                        instancia.StartPosition = FormStartPosition.Manual;
                        instancia.WindowState = FormWindowState.Normal;
                        instancia.Show();
                        owner.LayoutMdi(MdiLayout.Cascade);
                    }
                    else if (owner != null)
                    {
                        instancia.Show(owner);
                    }
                    else
                    {
                        instancia.Show();
                    }
                }

                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
                instancia.Focus();
            }
        }

        public static DialogResult AbrirDialogo<T>(Form? owner = null)
            where T : Form, new()
        {
            using (var frm = new T())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                if (owner != null)
                    return frm.ShowDialog(owner);
                return frm.ShowDialog();
            }
        }
    }
}
