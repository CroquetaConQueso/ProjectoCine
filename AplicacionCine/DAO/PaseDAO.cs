using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class PaseDAO
    {
        public Pase? GetById(int idPase)
        {
            const string sql = @"
                SELECT p.id_pase,
                       p.id_pelicula,
                       p.id_sala,
                       p.fecha_hora,
                       p.precio_base,
                       pel.titulo AS titulo_pelicula,
                       s.nombre   AS nombre_sala
                FROM pases p
                JOIN peliculas pel ON pel.id_pelicula = p.id_pelicula
                JOIN salas     s   ON s.id_sala       = p.id_sala
                WHERE p.id_pase = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idPase);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return Map(reader);
        }

        public List<Pase> GetAll()
        {
            var result = new List<Pase>();

            const string sql = @"
                SELECT p.id_pase,
                       p.id_pelicula,
                       p.id_sala,
                       p.fecha_hora,
                       p.precio_base,
                       pel.titulo AS titulo_pelicula,
                       s.nombre   AS nombre_sala
                FROM pases p
                JOIN peliculas pel ON pel.id_pelicula = p.id_pelicula
                JOIN salas     s   ON s.id_sala       = p.id_sala
                ORDER BY p.fecha_hora;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                result.Add(Map(reader));

            return result;
        }

        /// <summary>
        /// Devuelve los pases de una fecha concreta, opcionalmente filtrados por película o sala.
        /// </summary>
        public List<Pase> GetPasesDeFecha(DateTime fecha, int? idPelicula = null, int? idSala = null)
        {
            var result = new List<Pase>();

            var sql = @"
                SELECT p.id_pase,
                       p.id_pelicula,
                       p.id_sala,
                       p.fecha_hora,
                       p.precio_base,
                       pel.titulo AS titulo_pelicula,
                       s.nombre   AS nombre_sala
                FROM pases p
                JOIN peliculas pel ON pel.id_pelicula = p.id_pelicula
                JOIN salas     s   ON s.id_sala       = p.id_sala
                WHERE DATE(p.fecha_hora) = @Fecha
            ";

            if (idPelicula.HasValue)
                sql += " AND p.id_pelicula = @IdPelicula ";
            if (idSala.HasValue)
                sql += " AND p.id_sala = @IdSala ";

            sql += " ORDER BY p.fecha_hora;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Fecha", fecha.Date);
            if (idPelicula.HasValue)
                cmd.Parameters.AddWithValue("IdPelicula", idPelicula.Value);
            if (idSala.HasValue)
                cmd.Parameters.AddWithValue("IdSala", idSala.Value);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(Map(reader));
            }

            return result;
        }

        public void Insert(Pase pase)
        {
            const string sql = @"
                INSERT INTO pases
                    (id_pelicula, id_sala, fecha_hora, precio_base)
                VALUES
                    (@IdPelicula, @IdSala, @FechaHora, @PrecioBase)
                RETURNING id_pase;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdPelicula", pase.IdPelicula);
            cmd.Parameters.AddWithValue("IdSala", pase.IdSala);
            cmd.Parameters.AddWithValue("FechaHora", pase.FechaHora);
            cmd.Parameters.AddWithValue("PrecioBase", pase.PrecioBase);

            pase.IdPase = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(Pase pase)
        {
            const string sql = @"
                UPDATE pases
                SET id_pelicula = @IdPelicula,
                    id_sala     = @IdSala,
                    fecha_hora  = @FechaHora,
                    precio_base = @PrecioBase
                WHERE id_pase   = @IdPase;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdPelicula", pase.IdPelicula);
            cmd.Parameters.AddWithValue("IdSala", pase.IdSala);
            cmd.Parameters.AddWithValue("FechaHora", pase.FechaHora);
            cmd.Parameters.AddWithValue("PrecioBase", pase.PrecioBase);
            cmd.Parameters.AddWithValue("IdPase", pase.IdPase);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int idPase)
        {
            const string sql = @"DELETE FROM pases WHERE id_pase = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idPase);
            cmd.ExecuteNonQuery();
        }

        private static Pase Map(NpgsqlDataReader reader)
        {
            return new Pase
            {
                IdPase = reader.GetInt32(reader.GetOrdinal("id_pase")),
                IdPelicula = reader.GetInt32(reader.GetOrdinal("id_pelicula")),
                IdSala = reader.GetInt32(reader.GetOrdinal("id_sala")),
                FechaHora = reader.GetDateTime(reader.GetOrdinal("fecha_hora")),
                PrecioBase = reader.GetDecimal(reader.GetOrdinal("precio_base")),

                // Estos campos ya no existen en la BD simplificada; se dejan con valores por defecto.
                IdEmpleadoEncargado = null,
                IdEmpleadoSeguridad = null,
                Activo = true,

                TituloPelicula = reader.IsDBNull(reader.GetOrdinal("titulo_pelicula"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("titulo_pelicula")),
                NombreSala = reader.IsDBNull(reader.GetOrdinal("nombre_sala"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("nombre_sala"))
            };
        }
    }
}
