using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class UsuarioDAO
    {
        public Usuario? GetByLogin(string login)
        {
            const string sql = @"
                SELECT id_usuario, login, password_hash, email, telefono,
                       rol, activo, bloqueado, intentos_fallidos,
                       fecha_alta, fecha_ultimo_acceso, ultima_ip, notas_admin
                FROM usuarios
                WHERE login = @login;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("login", login);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return MapUsuario(reader);
        }

        public List<Usuario> GetAll()
        {
            const string sql = @"
                SELECT id_usuario, login, password_hash, email, telefono,
                       rol, activo, bloqueado, intentos_fallidos,
                       fecha_alta, fecha_ultimo_acceso, ultima_ip, notas_admin
                FROM usuarios
                ORDER BY login;
            ";

            var result = new List<Usuario>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(MapUsuario(reader));
            }

            return result;
        }

        public void Insert(Usuario usuario)
        {
            const string sql = @"
                INSERT INTO usuarios
                    (login, password_hash, email, telefono, rol,
                     activo, bloqueado, intentos_fallidos,
                     fecha_alta, fecha_ultimo_acceso, ultima_ip, notas_admin)
                VALUES
                    (@login, @password_hash, @Email, @Telefono, @Rol,
                     @Activo, @Bloqueado, @IntentosFallidos,
                     @FechaAlta, @FechaUltimoAcceso, @UltimaIp, @NotasAdmin)
                RETURNING id_usuario;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("login", usuario.Login);
            cmd.Parameters.AddWithValue("password_hash", usuario.PasswordHash);
            cmd.Parameters.AddWithValue("Email", (object?)usuario.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)usuario.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Rol", usuario.Rol);
            cmd.Parameters.AddWithValue("Activo", usuario.Activo);
            cmd.Parameters.AddWithValue("Bloqueado", usuario.Bloqueado);
            cmd.Parameters.AddWithValue("IntentosFallidos", usuario.IntentosFallidos);
            cmd.Parameters.AddWithValue("FechaAlta", usuario.FechaAlta);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso", (object?)usuario.FechaUltimoAcceso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("UltimaIp", (object?)usuario.UltimaIp ?? DBNull.Value);
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)usuario.NotasAdmin ?? DBNull.Value);

            usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Update(Usuario usuario)
        {
            const string sql = @"
                UPDATE usuarios
                SET email = @Email,
                    telefono = @Telefono,
                    rol = @Rol,
                    activo = @Activo,
                    bloqueado = @Bloqueado,
                    intentos_fallidos = @IntentosFallidos,
                    fecha_ultimo_acceso = @FechaUltimoAcceso,
                    ultima_ip = @UltimaIp,
                    notas_admin = @NotasAdmin
                WHERE id_usuario = @IdUsuario;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Email", (object?)usuario.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)usuario.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Rol", usuario.Rol);
            cmd.Parameters.AddWithValue("Activo", usuario.Activo);
            cmd.Parameters.AddWithValue("Bloqueado", usuario.Bloqueado);
            cmd.Parameters.AddWithValue("IntentosFallidos", usuario.IntentosFallidos);
            cmd.Parameters.AddWithValue("FechaUltimoAcceso", (object?)usuario.FechaUltimoAcceso ?? DBNull.Value);
            cmd.Parameters.AddWithValue("UltimaIp", (object?)usuario.UltimaIp ?? DBNull.Value);
            cmd.Parameters.AddWithValue("NotasAdmin", (object?)usuario.NotasAdmin ?? DBNull.Value);
            cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int idUsuario)
        {
            const string sql = @"DELETE FROM usuarios WHERE id_usuario = @IdUsuario;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("IdUsuario", idUsuario);
            cmd.ExecuteNonQuery();
        }

        private static Usuario MapUsuario(NpgsqlDataReader reader)
        {
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
                Rol = reader.GetString(reader.GetOrdinal("rol")),
                Activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                Bloqueado = reader.GetBoolean(reader.GetOrdinal("bloqueado")),
                IntentosFallidos = reader.GetInt32(reader.GetOrdinal("intentos_fallidos")),
                FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta")),
                FechaUltimoAcceso = reader.IsDBNull(reader.GetOrdinal("fecha_ultimo_acceso"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_ultimo_acceso")),
                UltimaIp = reader.IsDBNull(reader.GetOrdinal("ultima_ip"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("ultima_ip")),
                NotasAdmin = reader.IsDBNull(reader.GetOrdinal("notas_admin"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("notas_admin"))
            };
        }
    }
}
