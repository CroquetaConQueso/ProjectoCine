using AplicacionCine.DAO;
using AplicacionCine.Modelos;

namespace AplicacionCine
{
    /// <summary>
    /// Contexto global de la aplicación.
    /// Guarda el usuario actual y expone DAOs compartidos.
    /// </summary>
    public static class AppContext
    {
        /// <summary>
        /// Usuario actualmente logueado en la aplicación.
        /// </summary>
        public static Usuario? UsuarioActual { get; set; }

        public static UsuarioDAO Usuarios { get; } = new UsuarioDAO();
        public static EmpleadoDAO Empleados { get; } = new EmpleadoDAO();
        public static PeliculaDAO Peliculas { get; } = new PeliculaDAO();
        public static SalaDAO Salas { get; } = new SalaDAO();
        public static PaseDAO Pases { get; } = new PaseDAO();
        public static ReservaDAO Reservas { get; } = new ReservaDAO();
    }
}
