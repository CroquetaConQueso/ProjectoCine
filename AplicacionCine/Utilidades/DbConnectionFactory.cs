using System;
using Npgsql;

namespace AplicacionCine
{
    /// <summary>
    /// Clase estática que centraliza la cadena de conexión
    /// y crea conexiones abiertas a PostgreSQL.
    /// </summary>
    public static class DbConnectionFactory
    {
        private static string? _connectionString;

        /// <summary>
        /// Configura la cadena de conexión global de la aplicación.
        /// Debes llamarla una vez al arrancar (Program.Main).
        /// </summary>
        public static void Configure(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Crea y devuelve una conexión ABIERTA a la base de datos.
        /// El llamador es responsable de cerrar/disponer (using).
        /// </summary>
        public static NpgsqlConnection CreateOpenConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException(
                    "DbConnectionFactory no está configurado. Llama a Configure(...) al iniciar la aplicación.");
            }

            var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
