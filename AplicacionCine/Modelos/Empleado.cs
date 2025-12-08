using System;

namespace AplicacionCine.Modelos
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string? Apellidos { get; set; }
        public string? Dni { get; set; }
        public string? Telefono { get; set; }
        public string? EmailLaboral { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; } = TipoEmpleado.Taquilla;

        public string? Turno { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; } = true;

        public int? IdUsuario { get; set; }
        public int? IdSalaHabitual { get; set; }

        public string? NotasRRHH { get; set; }
    }
}
