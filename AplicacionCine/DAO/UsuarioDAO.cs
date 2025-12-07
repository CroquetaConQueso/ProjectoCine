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
                lista.Add(MapUsuario(reader));

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

            cmd.Parameters.AddWithValue("Login", u.Login);
            cmd.Parameters.AddWithValue("PasswordHash", u.PasswordHash);
            cmd.Parameters.AddWithValue("Email", (object?)u.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)u.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Rol", u.Rol.ToString().ToUpperInvariant());
            cmd.Parameters.AddWithValue("Activo", u.Activo);
            cmd.Parameters.AddWithValue("Bloqueado", u.Bloqueado);
            cmd.Parameters.AddWithValue("Intentos", u.IntentosFallidos);
            cmd.Parameters.AddWithValue("FechaAlta", u.FechaAlta);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso", (object?)u.FechaUltimoAcceso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("UltimaIp", (object?)u.UltimaIP ?? string.Empty);
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)u.NotasAdmin ?? DBNull.Value);

            u.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
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
            cmd.Parameters.AddWithValue("FechaAlta", u.FechaAlta);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso", (object?)u.FechaUltimoAcceso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("UltimaIp", (object?)u.UltimaIP ?? string.Empty);
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)u.NotasAdmin ?? DBNull.Value);

            cmd.ExecuteNonQuery();
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
            var rolStr = reader.GetString(reader.GetOrdinal("rol"));

            RolUsuario rol;
            if (!Enum.TryParse<RolUsuario>(rolStr, true, out rol))
            {
                switch (rolStr.ToUpperInvariant())
                {
                    case "TAQUILLA":
                    case "SEGURIDAD":
                    case "ENCARGADO":
                        rol = RolUsuario.Empleado;
                        break;

                    case "GERENTE":
                        rol = RolUsuario.Gerente;
                        break;

                    default:
                        rol = RolUsuario.Empleado;
                        break;
                }
            }

            return new Usuario
            {
                IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario")),
                Login = reader.GetString(reader.GetOrdinal("login")),
                PasswordHash = reader.GetString(reader.GetOrdinal("password_hash")),

                Email = reader.IsDBNull(reader.GetOrdinal("email"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("email")),

                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("telefono")),

                Rol = rol,

                Activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                Bloqueado = reader.GetBoolean(reader.GetOrdinal("bloqueado")),
                IntentosFallidos = reader.GetInt32(reader.GetOrdinal("intentos_fallidos")),

                FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta")),

                FechaUltimoAcceso = reader.IsDBNull(reader.GetOrdinal("fecha_ultimo_acceso"))
                    ? (DateTime?)null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_ultimo_acceso")),

                UltimaIP = reader.IsDBNull(reader.GetOrdinal("ultima_ip"))
                    ? string.Empty
                    : reader.GetString(reader.GetOrdinal("ultima_ip")),

                NotasAdmin = reader.IsDBNull(reader.GetOrdinal("notas_admin"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("notas_admin"))
            };
        }
    }
}
