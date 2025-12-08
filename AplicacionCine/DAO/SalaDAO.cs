using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    /// <summary>
    /// Acceso a datos de salas: CRUD sobre la tabla salas.
    /// </summary>
    public class SalaDAO
    {
        /// <summary>
        /// Devuelve todas las salas ordenadas por nombre.
        /// </summary>
        public List<Sala> GetAll()
        {
            const string sql = @"
                SELECT id_sala, nombre, descripcion,
                       filas, columnas, capacidad, activa
                FROM salas
                ORDER BY nombre;
            ";

            var result = new List<Sala>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(Map(reader));
            }

            return result;
        }

        /// <summary>
        /// Busca una sala por Id.
        /// Devuelve null si no existe.
        /// </summary>
        /// <param name="idSala">Identificador de la sala.</param>
        public Sala? GetById(int idSala)
        {
            const string sql = @"
                SELECT id_sala, nombre, descripcion,
                       filas, columnas, capacidad, activa
                FROM salas
                WHERE id_sala = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idSala);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return Map(reader);
        }

        /// <summary>
        /// Inserta una nueva sala y actualiza sala.IdSala con el Id generado.
        /// </summary>
        /// <param name="sala">Sala a insertar.</param>
        public void Insert(Sala sala)
        {
            const string sql = @"
                INSERT INTO salas
                    (nombre, descripcion, filas, columnas, capacidad, activa)
                VALUES
                    (@Nombre, @Descripcion, @Filas, @Columnas, @Capacidad, @Activa)
                RETURNING id_sala;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Nombre", sala.Nombre);
            cmd.Parameters.AddWithValue("Descripcion", (object?)sala.Descripcion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Filas", sala.Filas);
            cmd.Parameters.AddWithValue("Columnas", sala.Columnas);
            cmd.Parameters.AddWithValue("Capacidad", sala.Capacidad);
            cmd.Parameters.AddWithValue("Activa", sala.Activa);

            sala.IdSala = Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>
        /// Actualiza los datos de una sala existente, identificada por IdSala.
        /// </summary>
        /// <param name="sala">Sala con los campos ya modificados.</param>
        public void Update(Sala sala)
        {
            const string sql = @"
                UPDATE salas
                SET nombre      = @Nombre,
                    descripcion = @Descripcion,
                    filas       = @Filas,
                    columnas    = @Columnas,
                    capacidad   = @Capacidad,
                    activa      = @Activa
                WHERE id_sala   = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Nombre", sala.Nombre);
            cmd.Parameters.AddWithValue("Descripcion", (object?)sala.Descripcion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Filas", sala.Filas);
            cmd.Parameters.AddWithValue("Columnas", sala.Columnas);
            cmd.Parameters.AddWithValue("Capacidad", sala.Capacidad);
            cmd.Parameters.AddWithValue("Activa", sala.Activa);
            cmd.Parameters.AddWithValue("Id", sala.IdSala);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina una sala por Id.
        /// </summary>
        /// <param name="idSala">Identificador de la sala a borrar.</param>
        public void Delete(int idSala)
        {
            const string sql = @"DELETE FROM salas WHERE id_sala = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idSala);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Proyecta la fila actual del reader en un objeto Sala.
        /// </summary>
        private static Sala Map(NpgsqlDataReader reader)
        {
            return new Sala
            {
                IdSala = reader.GetInt32(reader.GetOrdinal("id_sala")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("descripcion")),
                Filas = reader.GetInt32(reader.GetOrdinal("filas")),
                Columnas = reader.GetInt32(reader.GetOrdinal("columnas")),
                Capacidad = reader.GetInt32(reader.GetOrdinal("capacidad")),
                Activa = reader.GetBoolean(reader.GetOrdinal("activa"))
            };
        }
    }
}
