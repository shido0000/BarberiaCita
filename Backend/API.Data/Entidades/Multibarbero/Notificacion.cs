using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las notificaciones del sistema
    /// </summary>
    public class Notificacion : EntidadBase
    {
        // Usuario destinatario de la notificación
        public required Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        
        // Tipo de notificación
        public required Enum.Multibarbero.TipoNotificacion Tipo { get; set; }
        
        // Título de la notificación
        public required string Titulo { get; set; }
        
        // Mensaje de la notificación
        public required string Mensaje { get; set; }
        
        // Datos adicionales en formato JSON (opcional)
        public string? DatosAdicionales { get; set; }
        
        // Estado de la notificación
        public bool Leida { get; set; } = false;
        public DateTime? FechaLectura { get; set; }
        
        // Fecha de envío
        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;
        
        // Usuario que envió la notificación (si aplica)
        public Guid? UsuarioEmisorId { get; set; }
        public Usuario? UsuarioEmisor { get; set; }
        
        // Entidad relacionada (opcional, para navegación directa)
        public Guid? EntidadRelacionadaId { get; set; }
        public string? TipoEntidadRelacionada { get; set; } // "Reserva", "Afiliacion", "Suscripcion", etc.
    }
}
