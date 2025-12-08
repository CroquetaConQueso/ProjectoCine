using System;

namespace AplicacionCine.Modelos
{
    public class Pase
    {
        public int IdPase { get; set; }
        public int IdPelicula { get; set; }
        public int IdSala { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal PrecioBase { get; set; }

        public int? IdEmpleadoEncargado { get; set; }
        public int? IdEmpleadoSeguridad { get; set; }
        public bool Activo { get; set; } = true;
        public string? TituloPelicula { get; set; }
        public string? NombreSala { get; set; }
    }
}
