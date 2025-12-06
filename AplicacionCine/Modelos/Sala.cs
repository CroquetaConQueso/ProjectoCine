namespace AplicacionCine.Modelos
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        public int Capacidad { get; set; }
        public bool Activa { get; set; } = true;
    }
}
