using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las solicitudes de afiliación de barberos a barberías
    /// </summary>
    public class AfiliacionBarbero : EntidadBase
    {
        // Barbero que solicita la afiliación
        public required Guid UsuarioBarberoId { get; set; }
        public UsuarioBarbero UsuarioBarbero { get; set; } = null!;
        
        // Barbería a la que se quiere afiliar
        public required Guid UsuarioBarberiaId { get; set; }
        public UsuarioBarberia UsuarioBarberia { get; set; } = null!;
        
        // Estado de la solicitud
        public Enum.Multibarbero.EstadoAfiliacion Estado { get; set; } = Enum.Multibarbero.EstadoAfiliacion.Pendiente;
        
        // Fecha de la solicitud
        public DateTime FechaSolicitud { get; set; }
        
        // Fecha de respuesta (aceptación/rechazo)
        public DateTime? FechaRespuesta { get; set; }
        
        // Mensaje del barbero en la solicitud
        public string? MensajeSolicitud { get; set; }
        
        // Mensaje de respuesta de la barbería
        public string? MensajeRespuesta { get; set; }
        
        // Usuario que respondió (de la barbería)
        public Guid? UsuarioRespondioId { get; set; }
        public Usuario? UsuarioRespondio { get; set; }
        
        // Fecha de finalización de la afiliación (si aplica)
        public DateTime? FechaFin { get; set; }
    }
}
