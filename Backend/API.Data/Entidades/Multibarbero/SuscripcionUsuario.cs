using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las suscripciones de los usuarios (barberos y barberías) a los planes
    /// </summary>
    public class SuscripcionUsuario : EntidadBase
    {
        // Relación con el usuario (barbero o barbería)
        public Guid? UsuarioBarberoId { get; set; }
        public UsuarioBarbero? UsuarioBarbero { get; set; }
        
        public Guid? UsuarioBarberiaId { get; set; }
        public UsuarioBarberia? UsuarioBarberia { get; set; }
        
        // Relación con el plan de suscripción
        public required Guid PlanSuscripcionId { get; set; }
        public PlanSuscripcion PlanSuscripcion { get; set; } = null!;
        
        // Fechas de la suscripción
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
        // Estado de la suscripción
        public Enum.Multibarbero.EstadoSuscripcion Estado { get; set; } = Enum.Multibarbero.EstadoSuscripcion.Activa;
        
        // Precio pagado
        public decimal PrecioPagado { get; set; }
        
        // Fecha de pago
        public DateTime FechaPago { get; set; }
        
        // Método de pago
        public string? MetodoPago { get; set; }
        
        // Referencia de pago
        public string? ReferenciaPago { get; set; }
        
        // Notas adicionales
        public string? Notas { get; set; }
    }
}
