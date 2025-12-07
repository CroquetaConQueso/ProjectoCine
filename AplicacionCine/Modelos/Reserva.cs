using System;

namespace AplicacionCine.Modelos
{
    public class Reserva
    {
        public int IdReserva { get; set; }

        public int IdPase { get; set; }

        public int? IdUsuario { get; set; }

        public DateTime FechaReserva { get; set; }

        public EEstadoReserva Estado { get; set; }

        public decimal? Total { get; set; }

        public string? Observaciones { get; set; }

        public string? PeliculaTitulo { get; set; }

        public string? UsuarioNombre { get; set; }

        public DateTime Fecha => FechaReserva.Date;
    }
}
