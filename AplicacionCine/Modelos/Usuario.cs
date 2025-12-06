using System;

namespace AplicacionCine.Modelos
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public string? NombreCompleto { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Telefono { get; set; }

        public RolUsuario Rol { get; set; } = RolUsuario.Empleado;

        public bool Activo { get; set; } = true;
        public bool Bloqueado { get; set; } = false;
        public int IntentosFallidos { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime? UltimoAcceso { get; set; }
        public string? UltimaIp { get; set; }

        public string? NotasAdmin { get; set; }
    }
}
