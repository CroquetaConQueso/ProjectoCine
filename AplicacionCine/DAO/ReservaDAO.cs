using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;
using EstadoReserva = AplicacionCine.Modelos.EEstadoReserva;

namespace AplicacionCine.DAO
{
    public class ReservaDAO
    {
        // --------- CONSULTAS BÁSICAS ---------

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
                result.Add(MapReserva(reader));

            return result;
        }

        public List<Reserva> GetAll()
        {
            const string sql = @"
                SELECT id_reserva, id_pase, id_usuario,
                       fecha_reserva, estado, total, observaciones
                FROM reservas
                ORDER BY fecha_reserva DESC, id_reserva DESC;
            ";

            var result = new List<Reserva>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add(MapReserva(reader));

            return result;
        }

        public Reserva? GetById(int idReserva)
        {
            const string sql = @"
                SELECT id_reserva, id_pase, id_usuario,
                       fecha_reserva, estado, total, observaciones
                FROM reservas
                WHERE id_reserva = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idReserva);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return MapReserva(reader);
        }

        // --------- BÚSQUEDA PARA FrmBrowReservas ---------

        public List<Reserva> Buscar(
            DateTime? fecha = null,
            int? idPelicula = null,
            string? estado = null,
            string? usuario = null)
        {
            var resultado = new List<Reserva>();

            var sql = @"
                SELECT r.id_reserva,
                       r.id_pase,
                       r.id_usuario,
                       r.fecha_reserva,
                       r.estado,
                       r.total,
                       r.observaciones,
                       pel.titulo           AS titulo_pelicula,
                       COALESCE(u.login,'') AS usuario_nombre
                FROM reservas r
                JOIN pases p        ON p.id_pase       = r.id_pase
                JOIN peliculas pel  ON pel.id_pelicula = p.id_pelicula
                LEFT JOIN usuarios u ON u.id_usuario   = r.id_usuario
                WHERE 1 = 1
            ";

            if (fecha.HasValue)
                sql += " AND r.fecha_reserva = @Fecha";
            if (idPelicula.HasValue)
                sql += " AND pel.id_pelicula = @IdPelicula";
            if (!string.IsNullOrWhiteSpace(estado))
                sql += " AND UPPER(r.estado) = UPPER(@Estado)";
            if (!string.IsNullOrWhiteSpace(usuario))
                sql += " AND (u.login ILIKE @Usuario OR pel.titulo ILIKE @Usuario)";

            sql += " ORDER BY r.fecha_reserva DESC, r.id_reserva DESC;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            if (fecha.HasValue)
                cmd.Parameters.AddWithValue("Fecha", fecha.Value.Date);
            if (idPelicula.HasValue)
                cmd.Parameters.AddWithValue("IdPelicula", idPelicula.Value);
            if (!string.IsNullOrWhiteSpace(estado))
                cmd.Parameters.AddWithValue("Estado", estado);
            if (!string.IsNullOrWhiteSpace(usuario))
                cmd.Parameters.AddWithValue("Usuario", "%" + usuario + "%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                resultado.Add(MapReserva(reader));

            return resultado;
        }

        // --------- CRUD RESERVA ---------

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
            cmd.Parameters.AddWithValue("Estado", reserva.Estado.ToString().ToUpperInvariant());
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
            cmd.Parameters.AddWithValue("Estado", reserva.Estado.ToString().ToUpperInvariant());
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

        // --------- CRUD LÍNEAS ---------

        public List<LineaReserva> GetLineasDeReserva(int idReserva)
        {
            const string sql = @"
                SELECT id_linea_reserva, id_reserva, id_asiento, id_pase,
                       precio, estado_linea
                FROM lineas_reserva
                WHERE id_reserva = @IdReserva
                ORDER BY id_linea_reserva;
            ";

            var result = new List<LineaReserva>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdReserva", idReserva);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                result.Add(MapLinea(reader));

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

        public void UpdateLinea(LineaReserva linea)
        {
            const string sql = @"
                UPDATE lineas_reserva
                SET id_reserva   = @IdReserva,
                    id_asiento   = @IdAsiento,
                    id_pase      = @IdPase,
                    precio       = @Precio,
                    estado_linea = @EstadoLinea
                WHERE id_linea_reserva = @IdLinea;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdReserva", linea.IdReserva);
            cmd.Parameters.AddWithValue("IdAsiento", linea.IdAsiento);
            cmd.Parameters.AddWithValue("IdPase", linea.IdPase);
            cmd.Parameters.AddWithValue("Precio", linea.Precio);
            cmd.Parameters.AddWithValue("EstadoLinea", linea.EstadoLinea);
            cmd.Parameters.AddWithValue("IdLinea", linea.IdLineaReserva);

            cmd.ExecuteNonQuery();
        }

        public void DeleteLinea(int idLineaReserva)
        {
            const string sql = @"DELETE FROM lineas_reserva WHERE id_linea_reserva = @IdLinea;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdLinea", idLineaReserva);
            cmd.ExecuteNonQuery();
        }

        // --------- MAPEO ---------

        private static Reserva MapReserva(NpgsqlDataReader reader)
        {
            var estadoStr = reader.GetString(reader.GetOrdinal("estado"));
            if (!Enum.TryParse<EstadoReserva>(estadoStr, true, out var estado))
                estado = EstadoReserva.Pendiente;

            var reserva = new Reserva
            {
                IdReserva = reader.GetInt32(reader.GetOrdinal("id_reserva")),
                IdPase = reader.GetInt32(reader.GetOrdinal("id_pase")),
                IdUsuario = reader.IsDBNull(reader.GetOrdinal("id_usuario"))
                    ? (int?)null
                    : reader.GetInt32(reader.GetOrdinal("id_usuario")),
                FechaReserva = reader.GetDateTime(reader.GetOrdinal("fecha_reserva")),
                Estado = estado,
                Total = reader.IsDBNull(reader.GetOrdinal("total"))
                    ? (decimal?)null
                    : reader.GetDecimal(reader.GetOrdinal("total")),
                Observaciones = reader.IsDBNull(reader.GetOrdinal("observaciones"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("observaciones"))
            };

            if (HasColumn(reader, "titulo_pelicula") &&
                !reader.IsDBNull(reader.GetOrdinal("titulo_pelicula")))
                reserva.PeliculaTitulo = reader.GetString(reader.GetOrdinal("titulo_pelicula"));

            if (HasColumn(reader, "usuario_nombre") &&
                !reader.IsDBNull(reader.GetOrdinal("usuario_nombre")))
                reserva.UsuarioNombre = reader.GetString(reader.GetOrdinal("usuario_nombre"));

            return reserva;
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

        private static bool HasColumn(NpgsqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }
    }
}
