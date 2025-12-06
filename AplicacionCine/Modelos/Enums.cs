using System;

namespace AplicacionCine.Modelos
{
    // Estado lógico de una reserva
    public enum EEstadoReserva
    {
        Pendiente = 0,
        Confirmada = 1,
        Cancelada = 2
    }

    // Tipo de empleado
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
        Cliente = 2
    }

    // Tipo de asiento en la sala
    public enum TipoAsiento
    {
        Normal = 0,
        MovilidadReducida = 1,
        Bloqueado = 2
    }
}
