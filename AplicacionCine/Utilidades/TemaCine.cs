using System;
using System.Drawing;
using System.Windows.Forms;

namespace AplicacionCine.Utilidades
{
    /// <summary>
    /// Tema visual oscuro para todos los formularios del cine.
    /// </summary>
    public static class TemaCine
    {
        // Colores base del tema
        public static readonly Color FondoVentana = Color.FromArgb(20, 20, 28);
        public static readonly Color FondoPanel = Color.FromArgb(24, 24, 34);
        public static readonly Color FondoControl = Color.FromArgb(30, 30, 40);
        public static readonly Color TextoPrincipal = Color.Gainsboro;
        public static readonly Color TextoSuave = Color.Silver;
        public static readonly Color BordeSuave = Color.FromArgb(70, 70, 90);
        public static readonly Color Acento = Color.FromArgb(255, 193, 7);   // amarillo cine

        /// <summary>
        /// Aplica el tema al formulario completo.
        /// Llama a esto en el constructor de cada Form: TemaCine.Aplicar(this);
        /// </summary>
        public static void Aplicar(Form form)
        {
            form.BackColor = FondoVentana;
            form.ForeColor = TextoPrincipal;

            AplicarRecursivo(form);
        }

        private static void AplicarRecursivo(Control c)
        {
            switch (c)
            {
                case Panel or GroupBox:
                    c.BackColor = FondoPanel;
                    c.ForeColor = TextoPrincipal;
                    break;

                case Label lbl:
                    lbl.ForeColor = TextoPrincipal;
                    break;

                case TextBox tb:
                    tb.BackColor = FondoControl;
                    tb.ForeColor = TextoPrincipal;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ComboBox cb:
                    cb.BackColor = FondoControl;
                    cb.ForeColor = TextoPrincipal;
                    cb.FlatStyle = FlatStyle.Flat;
                    break;

                case DateTimePicker dtp:
                    dtp.BackColor = FondoControl;
                    dtp.ForeColor = TextoPrincipal;
                    dtp.CalendarMonthBackground = FondoControl;
                    dtp.CalendarForeColor = TextoPrincipal;
                    break;

                case NumericUpDown nud:
                    nud.BackColor = FondoControl;
                    nud.ForeColor = TextoPrincipal;
                    break;

                case DataGridView dgv:
                    dgv.BackgroundColor = FondoPanel;
                    dgv.GridColor = BordeSuave;

                    dgv.DefaultCellStyle.BackColor = FondoControl;
                    dgv.DefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.DefaultCellStyle.SelectionBackColor = Acento;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

                    dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoPanel;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.EnableHeadersVisualStyles = false;
                    break;

                case Button btn:
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.UseVisualStyleBackColor = false;
                    btn.BackColor = FondoControl;
                    btn.ForeColor = TextoPrincipal;

                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BordeSuave;
                    btn.FlatAppearance.MouseOverBackColor = Acento;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 160, 0);
                    break;

                case ToolStrip ts:
                    ts.BackColor = FondoPanel;
                    ts.ForeColor = TextoPrincipal;
                    foreach (ToolStripItem item in ts.Items)
                        item.ForeColor = TextoPrincipal;
                    break;
            }

            foreach (Control child in c.Controls)
            {
                AplicarRecursivo(child);
            }
        }
    }
}
