using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    /// <summary>
    /// Acceso a datos de usuarios: CRUD, búsquedas y control de unicidad de login.
    /// </summary>
    public class UsuarioDAO
    {
        /// <summary>
        /// Devuelve un usuario por Id o null si no existe.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario.</param>
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

        /// <summary>
        /// Devuelve un usuario por su login o null si no existe.
        /// </summary>
        /// <param name="login">Nombre de login.</param>
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

        /// <summary>
        /// Devuelve todos los usuarios ordenados por login.
        /// </summary>
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

        /// <summary>
        /// Búsqueda flexible de usuarios por login, email y estado lógico.
        /// </summary>
        /// <param name="login">Fragmento de login (LIKE), o null.</param>
        /// <param name="email">Fragmento de email (LIKE), o null.</param>
        /// <param name="activo">Filtrar por activo/inactivo, o null para ignorar.</param>
        /// <param name="bloqueado">Filtrar por bloqueado/no, o null para ignorar.</param>
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

        /// <summary>
        /// Inserta un nuevo usuario y actualiza u.IdUsuario con el Id generado.
        /// </summary>
        /// <param name="u">Usuario a insertar.</param>
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

        /// <summary>
        /// Actualiza los datos de un usuario existente, identificado por IdUsuario.
        /// </summary>
        /// <param name="u">Usuario con campos ya modificados.</param>
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

        /// <summary>
        /// Indica si existe ya un usuario con ese login.
        /// Permite excluir un Id concreto (para actualizaciones).
        /// </summary>
        /// <param name="login">Login a comprobar.</param>
        /// <param name="idExcluir">
        /// Id a excluir de la comprobación, o null si no se excluye ninguno.
        /// </param>
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

        /// <summary>
        /// Elimina un usuario por Id.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario a borrar.</param>
        public void Delete(int idUsuario)
        {
            const string sql = @"DELETE FROM usuarios WHERE id_usuario = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idUsuario);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Proyecta la fila actual del reader en un objeto Usuario.
        /// Incluye parseo defensivo del rol y campos null-safe.
        /// </summary>
        private static Usuario MapUsuario(NpgsqlDataReader reader)
        {
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

            RolUsuario rol;
            if (!reader.IsDBNull(ordRol))
            {
                var rolStr = reader.GetString(ordRol).Trim();

                if (!Enum.TryParse<RolUsuario>(rolStr, true, out rol))
                {
                    rol = RolUsuario.Empleado;
                }
            }
            else
            {
                rol = RolUsuario.Empleado;
            }

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
