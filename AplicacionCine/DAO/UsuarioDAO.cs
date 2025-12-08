using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class UsuarioDAO
    {
        public Usuario? GetById(int idUsuario)
        {
            const string sql = @"
                SELECT  id_usuario, login, password_hash,
                        email, telefono, rol,
                        activo, bloqueado, intentos_fallidos,
                        fecha_alta, fecha_ultimo_acceso,
                        ultima_ip, notas_admin
                FROM usuarios
                WHERE id_usuario = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idUsuario);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return MapUsuario(reader);
        }

        public Usuario? GetByLogin(string login)
        {
            const string sql = @"
                SELECT  id_usuario, login, password_hash,
                        email, telefono, rol,
                        activo, bloqueado, intentos_fallidos,
                        fecha_alta, fecha_ultimo_acceso,
                        ultima_ip, notas_admin
                FROM usuarios
                WHERE login = @Login;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Login", login);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return MapUsuario(reader);
        }

        public List<Usuario> GetAll()
        {
            var lista = new List<Usuario>();

            const string sql = @"
                SELECT  id_usuario, login, password_hash,
                        email, telefono, rol,
                        activo, bloqueado, intentos_fallidos,
                        fecha_alta, fecha_ultimo_acceso,
                        ultima_ip, notas_admin
                FROM usuarios
                ORDER BY login;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(MapUsuario(reader));
            }

            return lista;
        }

        public List<Usuario> Buscar(string? login, string? email, bool? activo, bool? bloqueado)
        {
            var lista = new List<Usuario>();

            var sql = @"
                SELECT  id_usuario, login, password_hash,
                        email, telefono, rol,
                        activo, bloqueado, intentos_fallidos,
                        fecha_alta, fecha_ultimo_acceso,
                        ultima_ip, notas_admin
                FROM usuarios
                WHERE 1=1
            ";

            var parametros = new List<NpgsqlParameter>();

            if (!string.IsNullOrWhiteSpace(login))
            {
                sql += " AND UPPER(login) LIKE UPPER(@Login)";
                parametros.Add(new NpgsqlParameter("Login", $"%{login}%"));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                sql += " AND UPPER(email) LIKE UPPER(@Email)";
                parametros.Add(new NpgsqlParameter("Email", $"%{email}%"));
            }

            if (activo.HasValue)
            {
                sql += " AND activo = @Activo";
                parametros.Add(new NpgsqlParameter("Activo", activo.Value));
            }

            if (bloqueado.HasValue)
            {
                sql += " AND bloqueado = @Bloqueado";
                parametros.Add(new NpgsqlParameter("Bloqueado", bloqueado.Value));
            }

            sql += " ORDER BY login;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            foreach (var p in parametros)
                cmd.Parameters.Add(p);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(MapUsuario(reader));
            }

            return lista;
        }

        public void Insert(Usuario u)
        {
            const string sql = @"
                INSERT INTO usuarios
                    (login, password_hash, email, telefono,
                     rol, activo, bloqueado, intentos_fallidos,
                     fecha_alta, fecha_ultimo_acceso,
                     ultima_ip, notas_admin)
                VALUES
                    (@Login, @PasswordHash, @Email, @Telefono,
                     @Rol, @Activo, @Bloqueado, @Intentos,
                     @FechaAlta, @FechaUltimoAcceso,
                     @UltimaIp, @NotasAdmin)
                RETURNING id_usuario;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            // login / pass obligatorios
            cmd.Parameters.AddWithValue("Login", u.Login);
            cmd.Parameters.AddWithValue("PasswordHash", u.PasswordHash);

            // opcionales
            cmd.Parameters.AddWithValue("Email", (object?)u.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)u.Telefono ?? DBNull.Value);

            cmd.Parameters.AddWithValue("Rol", u.Rol.ToString().ToUpperInvariant());
            cmd.Parameters.AddWithValue("Activo", u.Activo);
            cmd.Parameters.AddWithValue("Bloqueado", u.Bloqueado);
            cmd.Parameters.AddWithValue("Intentos", u.IntentosFallidos);

            // Si FechaAlta viene sin inicializar (default), ponemos ahora mismo.
            var fechaAlta = u.FechaAlta == default(DateTime)
                ? DateTime.Now
                : u.FechaAlta;

            cmd.Parameters.AddWithValue("FechaAlta", fechaAlta);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso",
                (object?)u.FechaUltimoAcceso ?? DBNull.Value);

            cmd.Parameters.AddWithValue(
                "UltimaIp",
                string.IsNullOrWhiteSpace(u.UltimaIP)
                    ? (object)DBNull.Value
                    : u.UltimaIP
            );
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)u.NotasAdmin ?? DBNull.Value);

            u.IdUsuario = Convert.ToInt32(
                cmd.ExecuteScalar()
                ?? throw new InvalidOperationException("No se devolvió id_usuario tras el INSERT."));
        }

        public void Update(Usuario u)
        {
            const string sql = @"
                UPDATE usuarios
                SET login              = @Login,
                    password_hash      = @PasswordHash,
                    email              = @Email,
                    telefono           = @Telefono,
                    rol                = @Rol,
                    activo             = @Activo,
                    bloqueado          = @Bloqueado,
                    intentos_fallidos  = @Intentos,
                    fecha_alta         = @FechaAlta,
                    fecha_ultimo_acceso= @FechaUltimoAcceso,
                    ultima_ip          = @UltimaIp,
                    notas_admin        = @NotasAdmin
                WHERE id_usuario       = @IdUsuario;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("IdUsuario", u.IdUsuario);
            cmd.Parameters.AddWithValue("Login", u.Login);
            cmd.Parameters.AddWithValue("PasswordHash", u.PasswordHash);
            cmd.Parameters.AddWithValue("Email", (object?)u.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)u.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Rol", u.Rol.ToString().ToUpperInvariant());
            cmd.Parameters.AddWithValue("Activo", u.Activo);
            cmd.Parameters.AddWithValue("Bloqueado", u.Bloqueado);
            cmd.Parameters.AddWithValue("Intentos", u.IntentosFallidos);

            var fechaAlta = u.FechaAlta == default(DateTime)
                ? DateTime.Now
                : u.FechaAlta;

            cmd.Parameters.AddWithValue("FechaAlta", fechaAlta);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso",
                (object?)u.FechaUltimoAcceso ?? DBNull.Value);

            cmd.Parameters.AddWithValue(
                "UltimaIp",
                string.IsNullOrWhiteSpace(u.UltimaIP)
                    ? (object)DBNull.Value
                    : u.UltimaIP
            );
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)u.NotasAdmin ?? DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        public bool ExisteLogin(string login, int? idExcluir = null)
        {
            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = conn;

            if (idExcluir.HasValue)
            {
                cmd.CommandText = @"
                    SELECT COUNT(1)
                    FROM usuarios
                    WHERE UPPER(login) = UPPER(@Login)
                      AND id_usuario <> @IdExcluir;
                ";
                cmd.Parameters.AddWithValue("Login", login);
                cmd.Parameters.AddWithValue("IdExcluir", idExcluir.Value);
            }
            else
            {
                cmd.CommandText = @"
                    SELECT COUNT(1)
                    FROM usuarios
                    WHERE UPPER(login) = UPPER(@Login);
                ";
                cmd.Parameters.AddWithValue("Login", login);
            }

            var count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public void Delete(int idUsuario)
        {
            const string sql = @"DELETE FROM usuarios WHERE id_usuario = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idUsuario);
            cmd.ExecuteNonQuery();
        }

        private static Usuario MapUsuario(NpgsqlDataReader reader)
        {
            // Ordinales
            int ordId = reader.GetOrdinal("id_usuario");
            int ordLogin = reader.GetOrdinal("login");
            int ordPwd = reader.GetOrdinal("password_hash");
            int ordEmail = reader.GetOrdinal("email");
            int ordTelefono = reader.GetOrdinal("telefono");
            int ordRol = reader.GetOrdinal("rol");
            int ordActivo = reader.GetOrdinal("activo");
            int ordBloqueado = reader.GetOrdinal("bloqueado");
            int ordIntentos = reader.GetOrdinal("intentos_fallidos");
            int ordFechaAlta = reader.GetOrdinal("fecha_alta");
            int ordUltAcceso = reader.GetOrdinal("fecha_ultimo_acceso");
            int ordUltIp = reader.GetOrdinal("ultima_ip");
            int ordNotasAdmin = reader.GetOrdinal("notas_admin");

            // --- ROL (ahora string -> enum) ---
            RolUsuario rol;
            if (!reader.IsDBNull(ordRol))
            {
                var rolStr = reader.GetString(ordRol).Trim();

                // Intentamos casar con el enum ignorando mayúsculas/minúsculas
                if (!Enum.TryParse<RolUsuario>(rolStr, true, out rol))
                {
                    // Si no cuadra, le damos un valor por defecto razonable
                    rol = RolUsuario.Empleado;
                }
            }
            else
            {
                // Si viniera a NULL, también damos un valor por defecto
                rol = RolUsuario.Empleado;
            }

            // --- Campos NULL-safe como vimos antes ---
            string? email = reader.IsDBNull(ordEmail)
                ? null
                : reader.GetString(ordEmail);

            string? telefono = reader.IsDBNull(ordTelefono)
                ? null
                : reader.GetString(ordTelefono);

            bool activo = !reader.IsDBNull(ordActivo) &&
                          reader.GetBoolean(ordActivo);

            bool bloqueado = !reader.IsDBNull(ordBloqueado) &&
                             reader.GetBoolean(ordBloqueado);

            int intentosFallidos = reader.IsDBNull(ordIntentos)
                ? 0
                : reader.GetInt32(ordIntentos);

            DateTime fechaAlta = reader.IsDBNull(ordFechaAlta)
                ? DateTime.Now
                : reader.GetDateTime(ordFechaAlta);

            DateTime? fechaUltimoAcceso = reader.IsDBNull(ordUltAcceso)
                ? (DateTime?)null
                : reader.GetDateTime(ordUltAcceso);

            string ultimaIp = reader.IsDBNull(ordUltIp)
                ? string.Empty
                : reader.GetString(ordUltIp);

            string? notasAdmin = reader.IsDBNull(ordNotasAdmin)
                ? null
                : reader.GetString(ordNotasAdmin);

            // --- Construcción del objeto ---
            return new Usuario
            {
                IdUsuario = reader.GetInt32(ordId),
                Login = reader.GetString(ordLogin),
                PasswordHash = reader.GetString(ordPwd),
                Email = email,
                Telefono = telefono,
                Rol = rol,
                Activo = activo,
                Bloqueado = bloqueado,
                IntentosFallidos = intentosFallidos,
                FechaAlta = fechaAlta,
                FechaUltimoAcceso = fechaUltimoAcceso,
                UltimaIP = ultimaIp,
                NotasAdmin = notasAdmin
            };
        }


    }
}
