using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    /// <summary>
    /// Acceso a datos de asientos (tabla ASIENTOS):
    /// - Configuración estructural de la sala (movilidad_reducida / no_accesible).
    /// - Resolución de id_asiento a partir de (id_sala, fila, columna).
    /// </summary>
    public class AsientoDAO
    {
        /// <summary>
        /// Devuelve la configuración de todos los asientos de una sala.
        /// Las filas/columnas devueltas son las de BD (1-based).
        /// </summary>
        /// <param name="idSala">Identificador de la sala.</param>
        public List<(int fila, int columna, bool movRed, bool noAcc)> GetConfiguracionSala(int idSala)
        {
            const string sql = @"
                SELECT fila, columna, movilidad_reducida, no_accesible
                FROM asientos
                WHERE id_sala = @IdSala
                ORDER BY fila, columna;
            ";

            var lista = new List<(int fila, int columna, bool movRed, bool noAcc)>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdSala", idSala);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int fila = reader.GetInt32(reader.GetOrdinal("fila"));
                int col = reader.GetInt32(reader.GetOrdinal("columna"));

                bool movRed = reader.GetBoolean(reader.GetOrdinal("movilidad_reducida"));
                bool noAcc = reader.GetBoolean(reader.GetOrdinal("no_accesible"));

                lista.Add((fila, col, movRed, noAcc));
            }

            return lista;
        }

        /// <summary>
        /// Devuelve id_asiento para (idSala, filaIdx0, colIdx0).
        /// filaIdx0 / colIdx0 vienen 0-based desde el formulario,
        /// así que aquí se convierten a 1-based para la BD.
        /// Si no existe, devuelve null.
        /// </summary>
        public int? GetIdAsiento(int idSala, int filaIdx0, int colIdx0)
        {
            const string sql = @"
                SELECT id_asiento
                FROM asientos
                WHERE id_sala = @IdSala
                  AND fila    = @Fila
                  AND columna = @Columna
                LIMIT 1;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            // Convertimos de 0-based (form) a 1-based (BD).
            cmd.Parameters.AddWithValue("IdSala", idSala);
            cmd.Parameters.AddWithValue("Fila", filaIdx0 + 1);
            cmd.Parameters.AddWithValue("Columna", colIdx0 + 1);

            var result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return null;

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Persiste en la tabla ASIENTOS las flags de
        /// movilidad_reducida y no_accesible según el mapa actual.
        /// Recibe InfoButaca con Fila/Columna en 0-based y aquí
        /// se convierten a 1-based.
        /// </summary>
        /// <param name="idSala">Sala a actualizar.</param>
        /// <param name="butacas">Enumeración de todas las butacas del mapa.</param>
        public void GuardarConfiguracionSala(int idSala, IEnumerable<InfoButaca> butacas)
        {
            const string sql = @"
                UPDATE asientos
                SET movilidad_reducida = @MovRed,
                    no_accesible      = @NoAcc
                WHERE id_sala = @IdSala
                  AND fila    = @Fila
                  AND columna = @Columna;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            // Declaramos los parámetros una vez y luego solo cambiamos los valores.
            cmd.Parameters.Add("MovRed", NpgsqlTypes.NpgsqlDbType.Boolean);
            cmd.Parameters.Add("NoAcc", NpgsqlTypes.NpgsqlDbType.Boolean);
            cmd.Parameters.Add("IdSala", NpgsqlTypes.NpgsqlDbType.Integer);
            cmd.Parameters.Add("Fila", NpgsqlTypes.NpgsqlDbType.Integer);
            cmd.Parameters.Add("Columna", NpgsqlTypes.NpgsqlDbType.Integer);

            foreach (var info in butacas)
            {
                // 0-based (form) → 1-based (BD)
                cmd.Parameters["MovRed"].Value = (info.Tipo == TipoAsiento.MovilidadReducida);
                cmd.Parameters["NoAcc"].Value = (info.Estado == EstadoButaca.NoAccesible);
                cmd.Parameters["IdSala"].Value = idSala;
                cmd.Parameters["Fila"].Value = info.Fila + 1;
                cmd.Parameters["Columna"].Value = info.Columna + 1;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
