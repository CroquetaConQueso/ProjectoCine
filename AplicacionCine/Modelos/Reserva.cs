using System;

namespace AplicacionCine.Modelos
{
    public enum EstadoReserva
    {
        Pendiente = 0,
        Confirmada = 1,
        Cancelada = 2,
        Anulada = 3
    }

    public class Reserva
    {
        public int IdReserva { get; set; }

        public int? IdUsuario { get; set; }

        public int IdPase { get; set; }

        public DateTime FechaReserva { get; set; }

        public EstadoReserva Estado { get; set; }

        public int NumeroEntradas { get; set; }

        public decimal PrecioBase { get; set; }

        public decimal? Total { get; set; }

        public string? Observaciones { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
