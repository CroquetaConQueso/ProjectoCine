using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class ReservaDAO
    {
        public List<Reserva> GetReservasDePase(int idPase)
        {
            const string sql = @"
                SELECT id_reserva, id_pase, id_usuario,
                       fecha_reserva, estado, total, observaciones
                FROM reservas
                WHERE id_pase = @IdPase
                ORDER BY fecha_reserva DESC, id_reserva DESC;
            ";

            var result = new List<Reserva>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdPase", idPase);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(MapReserva(reader));
            }

            return result;
        }

        public int InsertReserva(Reserva reserva)
        {
            const string sql = @"
                INSERT INTO reservas
                    (id_pase, id_usuario, fecha_reserva, estado, total, observaciones)
                VALUES
                    (@IdPase, @IdUsuario, @FechaReserva, @Estado, @Total, @Observaciones)
                RETURNING id_reserva;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdPase", reserva.IdPase);
            cmd.Parameters.AddWithValue("IdUsuario", (object?)reserva.IdUsuario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaReserva", reserva.FechaReserva);
            cmd.Parameters.AddWithValue("Estado", reserva.Estado);
            cmd.Parameters.AddWithValue("Total", (object?)reserva.Total ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Observaciones", (object?)reserva.Observaciones ?? DBNull.Value);

            reserva.IdReserva = Convert.ToInt32(cmd.ExecuteScalar());
            return reserva.IdReserva;
        }

        public void UpdateReserva(Reserva reserva)
        {
            const string sql = @"
                UPDATE reservas
                SET id_pase       = @IdPase,
                    id_usuario    = @IdUsuario,
                    fecha_reserva = @FechaReserva,
                    estado        = @Estado,
                    total         = @Total,
                    observaciones = @Observaciones
                WHERE id_reserva  = @IdReserva;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdPase", reserva.IdPase);
            cmd.Parameters.AddWithValue("IdUsuario", (object?)reserva.IdUsuario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaReserva", reserva.FechaReserva);
            cmd.Parameters.AddWithValue("Estado", reserva.Estado);
            cmd.Parameters.AddWithValue("Total", (object?)reserva.Total ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Observaciones", (object?)reserva.Observaciones ?? DBNull.Value);
            cmd.Parameters.AddWithValue("IdReserva", reserva.IdReserva);

            cmd.ExecuteNonQuery();
        }

        public void DeleteReserva(int idReserva)
        {
            const string sql = @"DELETE FROM reservas WHERE id_reserva = @IdReserva;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdReserva", idReserva);
            cmd.ExecuteNonQuery();
        }

        // ---------- Líneas de reserva ----------

        public List<LineaReserva> GetLineasDeReserva(int idReserva)
        {
            const string sql = @"
                SELECT id_linea_reserva, id_reserva, id_asiento, id_pase,
                       precio, estado_linea
                FROM lineas_reserva
                WHERE id_reserva = @IdReserva;
            ";

            var result = new List<LineaReserva>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdReserva", idReserva);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(MapLinea(reader));
            }

            return result;
        }

        public int InsertLinea(LineaReserva linea)
        {
            const string sql = @"
                INSERT INTO lineas_reserva
                    (id_reserva, id_asiento, id_pase, precio, estado_linea)
                VALUES
                    (@IdReserva, @IdAsiento, @IdPase, @Precio, @EstadoLinea)
                RETURNING id_linea_reserva;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdReserva", linea.IdReserva);
            cmd.Parameters.AddWithValue("IdAsiento", linea.IdAsiento);
            cmd.Parameters.AddWithValue("IdPase", linea.IdPase);
            cmd.Parameters.AddWithValue("Precio", linea.Precio);
            cmd.Parameters.AddWithValue("EstadoLinea", linea.EstadoLinea);

            linea.IdLineaReserva = Convert.ToInt32(cmd.ExecuteScalar());
            return linea.IdLineaReserva;
        }

        public void DeleteLinea(int idLineaReserva)
        {
            const string sql = @"DELETE FROM lineas_reserva WHERE id_linea_reserva = @IdLinea;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdLinea", idLineaReserva);
            cmd.ExecuteNonQuery();
        }

        // ---------- Mapeadores internos ----------

        private static Reserva MapReserva(NpgsqlDataReader reader)
        {
            return new Reserva
            {
                IdReserva = reader.GetInt32(reader.GetOrdinal("id_reserva")),
                IdPase = reader.GetInt32(reader.GetOrdinal("id_pase")),
                IdUsuario = reader.IsDBNull(reader.GetOrdinal("id_usuario"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("id_usuario")),
                FechaReserva = reader.GetDateTime(reader.GetOrdinal("fecha_reserva")),
                Estado = reader.GetString(reader.GetOrdinal("estado")),
                Total = reader.IsDBNull(reader.GetOrdinal("total"))
                    ? null
                    : reader.GetDecimal(reader.GetOrdinal("total")),
                Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("observaciones"))
            };
        }

        private static LineaReserva MapLinea(NpgsqlDataReader reader)
        {
            return new LineaReserva
            {
                IdLineaReserva = reader.GetInt32(reader.GetOrdinal("id_linea_reserva")),
                IdReserva = reader.GetInt32(reader.GetOrdinal("id_reserva")),
                IdAsiento = reader.GetInt32(reader.GetOrdinal("id_asiento")),
                IdPase = reader.GetInt32(reader.GetOrdinal("id_pase")),
                Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                EstadoLinea = reader.GetString(reader.GetOrdinal("estado_linea"))
            };
        }
    }
}
