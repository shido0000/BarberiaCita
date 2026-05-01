using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las solicitudes de cambio de suscripción o nuevas suscripciones
    /// </summary>
    public class SolicitudSuscripcion : EntidadBase
    {
        // Usuario que solicita el cambio (barbero o barbería)
        public Guid? UsuarioBarberoId { get; set; }
        public UsuarioBarbero? UsuarioBarbero { get; set; }
        
        public Guid? UsuarioBarberiaId { get; set; }
        public UsuarioBarberia? UsuarioBarberia { get; set; }
        
        // Plan al que quiere cambiar o suscribirse
        public required Guid PlanSuscripcionId { get; set; }
        public PlanSuscripcion PlanSuscripcion { get; set; } = null!;
        
        // Suscripción actual (si es un cambio)
        public Guid? SuscripcionActualId { get; set; }
        public SuscripcionUsuario? SuscripcionActual { get; set; }
        
        // Estado de la solicitud
        public Enum.Multibarbero.EstadoSolicitud Estado { get; set; } = Enum.Multibarbero.EstadoSolicitud.Pendiente;
        
        // Fecha de la solicitud
        public DateTime FechaSolicitud { get; set; }
        
        // Fecha de respuesta
        public DateTime? FechaRespuesta { get; set; }
        
        // Usuario comercial que evaluó (si aplica)
        public Guid? UsuarioComercialId { get; set; }
        public UsuarioComercial? UsuarioComercial { get; set; }
        
        // Usuario admin que evaluó (si aplica)
        public Guid? UsuarioAdminId { get; set; }
        public Usuario? UsuarioAdmin { get; set; }
        
        // Motivo de rechazo (si aplica)
        public string? MotivoRechazo { get; set; }
        
        // Comentarios adicionales
        public string? Comentarios { get; set; }
    }
}
