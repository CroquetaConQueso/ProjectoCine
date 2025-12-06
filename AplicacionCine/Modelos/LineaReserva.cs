namespace AplicacionCine.Modelos
{
    public class LineaReserva
    {
        public int IdLineaReserva { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }
        public int IdPase { get; set; }
        public decimal Precio { get; set; }
        public string EstadoLinea { get; set; } = "RESERVADA";
    }
}
