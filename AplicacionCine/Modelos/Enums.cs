using System;

namespace AplicacionCine.Modelos
{
    /// <summary>
    /// Estado lógico de una reserva.
    /// </summary>
    public enum EstadoReserva
    {
        Pendiente = 0,
        Confirmada = 1,
        Cancelada = 2
    }

    /// <summary>
    /// Tipo de empleado según su función principal.
    /// </summary>
    public enum TipoEmpleado
    {
        Taquilla = 0,
        Seguridad = 1,
        Encargado = 2,
        Gerente = 3
    }

    /// <summary>
    /// Rol del usuario dentro del sistema.
    /// (Puedes ajustarlos a los que uses realmente.)
    /// </summary>
    public enum RolUsuario
    {
        Admin = 0,
        Empleado = 1,
        Gerente = 2
    }

    /// <summary>
    /// Tipo de asiento en sala.
    /// </summary>
    public enum TipoAsiento
    {
        Normal = 0,
        MovilidadReducida = 1,   // PMR / discapacidad
        Bloqueado = 2            // por ejemplo roto/no vendible
    }
}
