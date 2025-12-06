using System;
using System.Collections.Generic;
using Npgsql;
using AplicacionCine.Modelos;

namespace AplicacionCine.DAO
{
    public class EmpleadoDAO
    {
        public List<Empleado> GetAll()
        {
            const string sql = @"
                SELECT id_empleado, nombre, apellidos, dni,
                       telefono, email_laboral, fecha_nacimiento,
                       tipo_empleado, turno,
                       fecha_alta, fecha_baja, activo,
                       id_usuario, id_sala_habitual, notas_rrhh
                FROM empleados
                ORDER BY nombre, apellidos;
            ";

            var result = new List<Empleado>();

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(Map(reader));
            }

            return result;
        }

        public Empleado? GetById(int idEmpleado)
        {
            const string sql = @"
                SELECT id_empleado, nombre, apellidos, dni,
                       telefono, email_laboral, fecha_nacimiento,
                       tipo_empleado, turno,
                       fecha_alta, fecha_baja, activo,
                       id_usuario, id_sala_habitual, notas_rrhh
                FROM empleados
                WHERE id_empleado = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idEmpleado);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Map(reader);
            }

            return null;
        }

        public int Insert(Empleado empleado)
        {
            const string sql = @"
                INSERT INTO empleados
                    (nombre, apellidos, dni,
                     telefono, email_laboral, fecha_nacimiento,
                     tipo_empleado, turno,
                     fecha_alta, fecha_baja, activo,
                     id_usuario, id_sala_habitual, notas_rrhh)
                VALUES
                    (@Nombre, @Apellidos, @Dni,
                     @Telefono, @EmailLaboral, @FechaNacimiento,
                     @TipoEmpleado, @Turno,
                     @FechaAlta, @FechaBaja, @Activo,
                     @IdUsuario, @IdSalaHabitual, @NotasRRHH)
                RETURNING id_empleado;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("Apellidos", (object?)empleado.Apellidos ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Dni", (object?)empleado.Dni ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)empleado.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("EmailLaboral", (object?)empleado.EmailLaboral ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaNacimiento", (object?)empleado.FechaNacimiento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("TipoEmpleado", empleado.TipoEmpleado.ToString());
            cmd.Parameters.AddWithValue("Turno", (object?)empleado.Turno ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaAlta", empleado.FechaAlta);
            cmd.Parameters.AddWithValue("FechaBaja", (object?)empleado.FechaBaja ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Activo", empleado.Activo);
            cmd.Parameters.AddWithValue("IdUsuario", (object?)empleado.IdUsuario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("IdSalaHabitual", (object?)empleado.IdSalaHabitual ?? DBNull.Value);
            cmd.Parameters.AddWithValue("NotasRRHH", (object?)empleado.NotasRRHH ?? DBNull.Value);

            empleado.IdEmpleado = Convert.ToInt32(cmd.ExecuteScalar());
            return empleado.IdEmpleado;
        }

        public void Update(Empleado empleado)
        {
            const string sql = @"
                UPDATE empleados
                SET nombre          = @Nombre,
                    apellidos       = @Apellidos,
                    dni             = @Dni,
                    telefono        = @Telefono,
                    email_laboral   = @EmailLaboral,
                    fecha_nacimiento= @FechaNacimiento,
                    tipo_empleado   = @TipoEmpleado,
                    turno           = @Turno,
                    fecha_alta      = @FechaAlta,
                    fecha_baja      = @FechaBaja,
                    activo          = @Activo,
                    id_usuario      = @IdUsuario,
                    id_sala_habitual = @IdSalaHabitual,
                    notas_rrhh      = @NotasRRHH
                WHERE id_empleado   = @Id;
            ";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("Nombre", empleado.Nombre);
            cmd.Parameters.AddWithValue("Apellidos", (object?)empleado.Apellidos ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Dni", (object?)empleado.Dni ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Telefono", (object?)empleado.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("EmailLaboral", (object?)empleado.EmailLaboral ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaNacimiento", (object?)empleado.FechaNacimiento ?? DBNull.Value);
            cmd.Parameters.AddWithValue("TipoEmpleado", empleado.TipoEmpleado.ToString());
            cmd.Parameters.AddWithValue("Turno", (object?)empleado.Turno ?? DBNull.Value);
            cmd.Parameters.AddWithValue("FechaAlta", empleado.FechaAlta);
            cmd.Parameters.AddWithValue("FechaBaja", (object?)empleado.FechaBaja ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Activo", empleado.Activo);
            cmd.Parameters.AddWithValue("IdUsuario", (object?)empleado.IdUsuario ?? DBNull.Value);
            cmd.Parameters.AddWithValue("IdSalaHabitual", (object?)empleado.IdSalaHabitual ?? DBNull.Value);
            cmd.Parameters.AddWithValue("NotasRRHH", (object?)empleado.NotasRRHH ?? DBNull.Value);
            cmd.Parameters.AddWithValue("Id", empleado.IdEmpleado);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int idEmpleado)
        {
            const string sql = @"DELETE FROM empleados WHERE id_empleado = @Id;";

            using var conn = DbConnectionFactory.CreateOpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("Id", idEmpleado);
            cmd.ExecuteNonQuery();
        }

        private static Empleado Map(NpgsqlDataReader reader)
        {
            return new Empleado
            {
                IdEmpleado = reader.GetInt32(reader.GetOrdinal("id_empleado")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Apellidos = reader.IsDBNull(reader.GetOrdinal("apellidos"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("apellidos")),
                Dni = reader.IsDBNull(reader.GetOrdinal("dni"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("dni")),
                Telefono = reader.IsDBNull(reader.GetOrdinal("telefono"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("telefono")),
                EmailLaboral = reader.IsDBNull(reader.GetOrdinal("email_laboral"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("email_laboral")),
                FechaNacimiento = reader.IsDBNull(reader.GetOrdinal("fecha_nacimiento"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_nacimiento")),
                TipoEmpleado = (TipoEmpleado)Enum.Parse(
                    typeof(TipoEmpleado),
                    reader.GetString(reader.GetOrdinal("tipo_empleado"))
                ),
                Turno = reader.IsDBNull(reader.GetOrdinal("turno"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("turno")),
                FechaAlta = reader.GetDateTime(reader.GetOrdinal("fecha_alta")),
                FechaBaja = reader.IsDBNull(reader.GetOrdinal("fecha_baja"))
                    ? null
                    : reader.GetDateTime(reader.GetOrdinal("fecha_baja")),
                Activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                IdUsuario = reader.IsDBNull(reader.GetOrdinal("id_usuario"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("id_usuario")),
                IdSalaHabitual = reader.IsDBNull(reader.GetOrdinal("id_sala_habitual"))
                    ? null
                    : reader.GetInt32(reader.GetOrdinal("id_sala_habitual")),
                NotasRRHH = reader.IsDBNull(reader.GetOrdinal("notas_rrhh"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("notas_rrhh"))
            };
        }
    }
}
