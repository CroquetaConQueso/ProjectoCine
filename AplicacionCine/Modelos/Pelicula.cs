namespace AplicacionCine.Modelos
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int DuracionMin { get; set; }
        public string? Clasificacion { get; set; } 
        public string? Genero { get; set; }
        public string? Sinopsis { get; set; }
        public bool Activa { get; set; } = true;
    }
}
