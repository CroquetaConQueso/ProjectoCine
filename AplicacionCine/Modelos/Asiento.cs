namespace AplicacionCine.Modelos
{
    public class Asiento
    {
        public int IdAsiento { get; set; }
        public int IdSala { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public bool Accesible { get; set; }
        public bool Activo { get; set; }
    }
}
