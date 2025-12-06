using System;
using System.Windows.Forms;

namespace AplicacionCine
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // AJUSTA la cadena de conexión a tu entorno PostgreSQL
            var connectionString =
                "Host=localhost;Port=5432;Database=cine_dam;Username=postgres;Password=usuario";

            DbConnectionFactory.Configure(connectionString);

            // Lanzamos el formulario de login como entrada a la aplicación
            Application.Run(new FrmLogin());
        }
    }
}
