using System;

namespace AplicacionCine.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Login { get; set; } = string.Empty;

        // Si quieres usar un “nombre visible”, reutilizamos Login
        public string NombreUsuario
        {
            get => Login;
            set => Login = value;
        }

        public string? Email { get; set; }
        public string? Telefono { get; set; }

        // Contraseña almacenada (hash o texto plano mientras desarrollas)
        public string PasswordHash { get; set; } = string.Empty;

        public bool Activo { get; set; }

        public RolUsuario Rol { get; set; }

        // Campo para bloquear la cuenta
        public bool Bloqueado { get; set; }

        public int IntentosFallidos { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaUltimoAcceso { get; set; }

        public string? UltimaIp { get; set; }

        public string? NotasAdmin { get; set; }
    }
}
