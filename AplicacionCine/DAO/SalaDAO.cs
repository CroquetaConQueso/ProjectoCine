using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class SalaDAO
    {
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

        public void Delete(int idSala)
        {
            const string sql = @"DELETE FROM salas WHERE id_sala = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idSala);
            cmd.ExecuteNonQuery();
        }

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
