using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    /// <summary>
    /// Acceso a datos de películas: CRUD sobre la tabla peliculas.
    /// </summary>
    public class PeliculaDAO
    {
        /// <summary>
        /// Devuelve todas las películas ordenadas por título.
        /// </summary>
        public List<Pelicula> GetAll()
        {
            const string sql = @"
                SELECT id_pelicula, titulo, duracion_min, clasificacion,
                       genero, sinopsis, activa
                FROM peliculas
                ORDER BY titulo;
            ";

            var result = new List<Pelicula>();

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
        /// Busca una película por Id.
        /// Devuelve null si no existe.
        /// </summary>
        /// <param name="idPelicula">Identificador de la película.</param>
        public Pelicula? GetById(int idPelicula)
        {
            const string sql = @"
                SELECT id_pelicula, titulo, duracion_min, clasificacion,
                       genero, sinopsis, activa
                FROM peliculas
                WHERE id_pelicula = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idPelicula);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return Map(reader);
        }

        /// <summary>
        /// Inserta una nueva película y actualiza peli.IdPelicula
        /// con el Id generado (se calcula como MAX + 1).
        /// </summary>
        /// <param name="peli">Película a insertar.</param>
        public void Insert(Pelicula peli)
        {
            const string sql = @"
                INSERT INTO peliculas
                    (id_pelicula, titulo, duracion_min, clasificacion, genero, sinopsis, activa)
                VALUES
                    ((SELECT COALESCE(MAX(id_pelicula), 0) + 1 FROM peliculas),
                     @Titulo, @Duracion, @Clasificacion, @Genero, @Sinopsis, @Activa)
                RETURNING id_pelicula;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Titulo", peli.Titulo);
            cmd.Parameters.AddWithValue("Duracion", peli.DuracionMin);
            cmd.Parameters.AddWithValue("Clasificacion", (object?)peli.Clasificacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Genero", (object?)peli.Genero ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Sinopsis", (object?)peli.Sinopsis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Activa", peli.Activa);

            peli.IdPelicula = Convert.ToInt32(cmd.ExecuteScalar());
        }

        /// <summary>
        /// Actualiza los datos de una película existente,
        /// identificada por IdPelicula.
        /// </summary>
        /// <param name="peli">Película con los campos ya modificados.</param>
        public void Update(Pelicula peli)
        {
            const string sql = @"
                UPDATE peliculas
                SET titulo        = @Titulo,
                    duracion_min  = @Duracion,
                    clasificacion = @Clasificacion,
                    genero        = @Genero,
                    sinopsis      = @Sinopsis,
                    activa        = @Activa
                WHERE id_pelicula = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Titulo", peli.Titulo);
            cmd.Parameters.AddWithValue("Duracion", peli.DuracionMin);
            cmd.Parameters.AddWithValue("Clasificacion", (object?)peli.Clasificacion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Genero", (object?)peli.Genero ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Sinopsis", (object?)peli.Sinopsis ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Activa", peli.Activa);
            cmd.Parameters.AddWithValue("Id", peli.IdPelicula);

            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina una película por Id.
        /// </summary>
        /// <param name="idPelicula">Identificador de la película a borrar.</param>
        public void Delete(int idPelicula)
        {
            const string sql = @"DELETE FROM peliculas WHERE id_pelicula = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idPelicula);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Proyecta la fila actual del reader en un objeto Pelicula.
        /// </summary>
        private static Pelicula Map(NpgsqlDataReader reader)
        {
            return new Pelicula
            {
                IdPelicula = reader.GetInt32(reader.GetOrdinal("id_pelicula")),
                Titulo = reader.GetString(reader.GetOrdinal("titulo")),
                DuracionMin = reader.GetInt32(reader.GetOrdinal("duracion_min")),
                Clasificacion = reader.IsDBNull(reader.GetOrdinal("clasificacion"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("clasificacion")),
                Genero = reader.IsDBNull(reader.GetOrdinal("genero"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("genero")),
                Sinopsis = reader.IsDBNull(reader.GetOrdinal("sinopsis"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("sinopsis")),
                Activa = reader.GetBoolean(reader.GetOrdinal("activa"))
            };
        }
    }
}
