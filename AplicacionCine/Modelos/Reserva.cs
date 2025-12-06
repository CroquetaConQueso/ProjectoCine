namespace AplicacionCine.Modelos
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdPase { get; set; }
        public int? IdUsuarioCreador { get; set; }
        public DateTime FechaReserva { get; set; }

        public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;

        public decimal? Total { get; set; }
        public string? Observaciones { get; set; }
    }
}
