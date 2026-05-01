namespace API.Data.Enum.Multibarbero
{
    /// <summary>
    /// Tipos de notificaciones disponibles en el sistema
    /// </summary>
    public enum TipoNotificacion
    {
        // Notificaciones de suscripción
        SolicitudSuscripcionNueva = 0,
        CambioSuscripcionSolicitado = 1,
        SuscripcionAprobada = 2,
        SuscripcionRechazada = 3,
        SuscripcionPorVencer = 4,
        SuscripcionVencida = 5,
        
        // Notificaciones de afiliación
        SolicitudAfiliacionRecibida = 6,
        SolicitudAfiliacionAceptada = 7,
        SolicitudAfiliacionRechazada = 8,
        AfiliacionCancelada = 9,
        
        // Notificaciones de reservas
        NuevaReserva = 10,
        ReservaConfirmada = 11,
        ReservaRechazada = 12,
        ReservaCancelada = 13,
        RecordatorioReserva = 14,
        
        // Notificaciones generales
        MensajeSistema = 15,
        AlertaAdmin = 16
    }
}
