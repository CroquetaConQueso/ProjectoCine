using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;
using EstadoReserva = AplicacionCine.Modelos.EEstadoReserva;

namespace AplicacionCine.DAO
{
    /// <summary>
    /// Acceso a datos de reservas y sus líneas (CRUD + búsquedas).
    /// </summary>
    public class ReservaDAO
    {
        // --------- CONSULTAS BÁSICAS ---------

        /// <summary>
        /// Devuelve las reservas asociadas a un pase concreto,
        /// ordenadas por fecha de reserva (más recientes primero).
        /// </summary>
        /// <param name="idPase">Identificador del pase.</param>
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

        /// <summary>
        /// Devuelve todas las reservas, ordenadas de más reciente a más antigua.
        /// </summary>
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

        /// <summary>
        /// Devuelve una reserva por Id o null si no existe.
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva.</param>
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

        /// <summary>
        /// Búsqueda flexible de reservas para el explorador:
        /// permite filtrar por fecha, película, estado y texto de usuario/título.
        /// </summary>
        /// <param name="fecha">Fecha exacta de reserva, o null para no filtrar por fecha.</param>
        /// <param name="idPelicula">Id de película, o null para no filtrar por película.</param>
        /// <param name="estado">Estado lógico (texto en BD), o null/empty para ignorarlo.</param>
        /// <param name="usuario">
        /// Texto a buscar en login de usuario o título de película (ILIKE).
        /// </param>
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

        // --------- MÉTODOS EXTRA PARA MAPA DE BUTACAS ---------

        /// <summary>
        /// Devuelve las butacas ocupadas (fila, columna) para un pase,
        /// ignorando reservas CANCELADAS.
        /// </summary>
        public List<(int fila, int columna)> GetButacasOcupadasDePase(int idPase)
        {
            const string sql = @"
                SELECT a.fila, a.columna
                FROM lineas_reserva lr
                JOIN reservas r ON r.id_reserva = lr.id_reserva
                JOIN asientos a ON a.id_asiento = lr.id_asiento
                WHERE lr.id_pase = @IdPase
                  AND UPPER(r.estado) <> @EstadoCancelada;
            ";

            var resultado = new List<(int fila, int columna)>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdPase", idPase);
            cmd.Parameters.AddWithValue(
                "EstadoCancelada",
                EstadoReserva.Cancelada.ToString().ToUpperInvariant()
            );

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int fila = reader.GetInt32(reader.GetOrdinal("fila"));
                int columna = reader.GetInt32(reader.GetOrdinal("columna"));
                resultado.Add((fila, columna));
            }

            return resultado;
        }

        /// <summary>
        /// Indica si existe una línea "activa" (no cancelada) para un asiento en un pase.
        /// Se ignoran:
        ///  - Reservas con estado CANCELADA
        ///  - Líneas con estado_linea = 'CANCELADA'
        /// </summary>
        public bool ExisteLineaParaAsiento(int idPase, int idAsiento)
        {
            const string sql = @"
                SELECT COUNT(*)
                FROM lineas_reserva lr
                JOIN reservas r ON r.id_reserva = lr.id_reserva
                WHERE lr.id_pase    = @IdPase
                  AND lr.id_asiento = @IdAsiento
                  AND UPPER(r.estado) <> @EstadoCancelada
                  AND (
                        lr.estado_linea IS NULL
                        OR UPPER(lr.estado_linea) <> 'CANCELADA'
                      );
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdPase", idPase);
            cmd.Parameters.AddWithValue("IdAsiento", idAsiento);
            cmd.Parameters.AddWithValue(
                "EstadoCancelada",
                EEstadoReserva.Cancelada.ToString().ToUpperInvariant()
            );

            long count = Convert.ToInt64(cmd.ExecuteScalar());
            return count > 0;
        }

        // --------- CRUD RESERVA ---------

        /// <summary>
        /// Inserta una nueva reserva y devuelve el Id generado.
        /// Calcula id_reserva como MAX(id) + 1.
        /// Actualiza también reserva.IdReserva.
        /// </summary>
        /// <param name="reserva">Reserva a insertar.</param>
        public int InsertReserva(Reserva reserva)
        {
            const string sql = @"
                INSERT INTO reservas
                    (id_reserva, id_pase, id_usuario, fecha_reserva, estado, total, observaciones)
                VALUES
                    ((SELECT COALESCE(MAX(id_reserva), 0) + 1 FROM reservas),
                     @IdPase, @IdUsuario, @FechaReserva, @Estado, @Total, @Observaciones)
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

        /// <summary>
        /// Actualiza una reserva existente, identificada por IdReserva.
        /// </summary>
        /// <param name="reserva">Reserva con los datos ya modificados.</param>
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

        /// <summary>
        /// Elimina una reserva por Id.
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva a borrar.</param>
        public void DeleteReserva(int idReserva)
        {
            const string sql = @"DELETE FROM reservas WHERE id_reserva = @IdReserva;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdReserva", idReserva);
            cmd.ExecuteNonQuery();
        }

        // --------- CRUD LÍNEAS ---------

        /// <summary>
        /// Devuelve todas las líneas asociadas a una reserva,
        /// ordenadas por id_linea_reserva.
        /// </summary>
        /// <param name="idReserva">Identificador de la reserva.</param>
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

        /// <summary>
        /// Inserta una nueva línea de reserva y devuelve el Id generado.
        /// Calcula id_linea_reserva como MAX(id) + 1.
        /// </summary>
        /// <param name="linea">Línea de reserva a insertar.</param>
        public int InsertLinea(LineaReserva linea)
        {
            const string sql = @"
                INSERT INTO lineas_reserva
                    (id_linea_reserva, id_reserva, id_asiento, id_pase, precio, estado_linea)
                VALUES
                    ((SELECT COALESCE(MAX(id_linea_reserva), 0) + 1 FROM lineas_reserva),
                     @IdReserva, @IdAsiento, @IdPase, @Precio, @EstadoLinea)
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

        /// <summary>
        /// Actualiza una línea de reserva existente, identificada por IdLineaReserva.
        /// </summary>
        /// <param name="linea">Línea con los datos ya modificados.</param>
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

        /// <summary>
        /// Elimina una línea de reserva por Id.
        /// </summary>
        /// <param name="idLineaReserva">Identificador de la línea a borrar.</param>
        public void DeleteLinea(int idLineaReserva)
        {
            const string sql = @"DELETE FROM lineas_reserva WHERE id_linea_reserva = @IdLinea;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdLinea", idLineaReserva);
            cmd.ExecuteNonQuery();
        }

        // --------- MAPEO ---------

        /// <summary>
        /// Proyecta la fila actual del reader en un objeto Reserva.
        /// Respeta campos opcionales usados en búsquedas (título, usuario).
        /// </summary>
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

        /// <summary>
        /// Proyecta la fila actual del reader en un objeto LineaReserva.
        /// </summary>
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

        /// <summary>
        /// Indica si el reader contiene una columna con el nombre dado
        /// (útil para columnas opcionales en consultas distintas).
        /// </summary>
        private static bool HasColumn(NpgsqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }
    }
}
