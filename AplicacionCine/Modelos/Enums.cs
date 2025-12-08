using System;

namespace AplicacionCine.Modelos
{
    // Estado lógico de una reserva (nombre nuevo usado en la app)
    public enum EstadoReserva
    {
        Pendiente = 0,
        Confirmada = 1,
        Cancelada = 2
    }

    // Alias del enum antiguo por si aún queda código que lo use
    public enum EEstadoReserva
    {
        Pendiente = 0,
        Confirmada = 1,
        Cancelada = 2
    }

    // Tipo de empleado (para la tabla EMPLEADOS)
    public enum TipoEmpleado
    {
        Taquilla = 0,
        Seguridad = 1,
        Encargado = 2,
        Gerente = 3
    }

    // Rol del usuario en la aplicación
    public enum RolUsuario
    {
        Admin = 0,
        Empleado = 1,
        Cliente = 2,
        Gerente = 3  // añadido para mapear usuarios con rol GERENTE
    }

    // Tipo de asiento en la sala
    public enum TipoAsiento
    {
        Normal = 0,
        MovilidadReducida = 1,
        Bloqueado = 2
    }
    // Tipo de estado de una butaca, si se cancela vuelve a libre
    public enum EstadoButaca
    {
        Libre = 0,
        Reservada = 1,
        Ocupada = 2,
        NoAccesible = 3
    }
}
