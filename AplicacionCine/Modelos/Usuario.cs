using System;

namespace AplicacionCine.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Login { get; set; } = string.Empty;

        // Alias para compatibilidad con formularios que usan NombreUsuario
        public string NombreUsuario
        {
            get => Login;
            set => Login = value;
        }

        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        // Alias para código antiguo que usa HashPassword
        public string HashPassword
        {
            get => PasswordHash;
            set => PasswordHash = value;
        }

        public bool Activo { get; set; }

        public RolUsuario Rol { get; set; }

        public bool CuentaBloqueada { get; set; }

        // Alias para código que usa Bloqueado
        public bool Bloqueado
        {
            get => CuentaBloqueada;
            set => CuentaBloqueada = value;
        }

        public int IntentosFallidos { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaUltimoAcceso { get; set; }

        // Propiedad principal
        public string UltimaIP { get; set; } = string.Empty;

        // Alias correcto (I mayúscula)
        public string? UltimaIp
        {
            get => UltimaIP;
            set => UltimaIP = value ?? string.Empty;
        }

        // Alias para el posible typo UltimalP que te daba error
        public string? UltimalP
        {
            get => UltimaIP;
            set => UltimaIP = value ?? string.Empty;
        }

        public string? NotasAdmin { get; set; }
    }
}
