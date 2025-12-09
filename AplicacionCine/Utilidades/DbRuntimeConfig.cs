using Npgsql;

namespace AplicacionCine.Utilidades
{
    /// <summary>
    /// Configuración de conexión a PostgreSQL en memoria.
    /// Genera la cadena de conexión que usa DbConnectionFactory.
    /// </summary>
    public static class DbRuntimeConfig
    {
        public static string Servidor { get; set; } = "localhost";
        public static int Puerto { get; set; } = 5432;
        public static string BaseDatos { get; set; } = "cine";
        public static string Usuario { get; set; } = "postgres";
        public static string Contrasena { get; set; } = "postgres";

        public static string ConnectionString
        {
            get
            {
                var builder = new NpgsqlConnectionStringBuilder
                {
                    Host = Servidor,
                    Port = Puerto,
                    Database = BaseDatos,
                    Username = Usuario,
                    Password = Contrasena
                };

                return builder.ConnectionString;
            }
        }
    }
}
