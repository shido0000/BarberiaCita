using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los datos específicos de los usuarios comerciales en el sistema multibarbero
    /// </summary>
    public class UsuarioComercial : EntidadBase
    {
        // Relación con Usuario base
        public required Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Relación con RolMultibarbero
        public required Guid RolMultibarberoId { get; set; }
        public RolMultibarbero RolMultibarbero { get; set; } = null!;

        // Información específica del comercial
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        
        // Estado del comercial
        public bool Activo { get; set; } = true;
        
        // Relaciones
        public List<SolicitudSuscripcion> SolicitudesEvaluadas { get; set; } = new();
        public List<Notificacion> NotificacionesEnviadas { get; set; } = new();
    }
}
