using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Extensión de Usuario para barberos con información específica
    /// </summary>
    public class UsuarioBarbero : EntidadBase
    {
        public Guid UsuarioId { get; set; }
        
        // Información profesional del barbero
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; } // JSON o texto separado por comas
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; } // URL o ruta de la imagen
        
        // Ubicación y contacto
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        
        // Estado del barbero
        public bool Activo { get; set; } = true;
        public bool Verificado { get; set; } = false;
        
        // Relaciones
        public Usuario Usuario { get; set; } = null!;
        public Guid? RolMultibarberoId { get; set; }
        public RolMultibarbero? RolMultibarbero { get; set; }
        
        // Suscripción actual
        public Guid? SuscripcionActualId { get; set; }
        public SuscripcionUsuario? SuscripcionActual { get; set; }
        
        // Historial de suscripciones
        public List<SuscripcionUsuario> HistorialSuscripciones { get; set; } = new();
        
        // Servicios ofrecidos
        public List<ServicioBarbero> Servicios { get; set; } = new();
        
        // Productos en venta (solo Premium)
        public List<ProductoBarbero> Productos { get; set; } = new();
        
        // Reservas recibidas
        public List<Reserva> Reservas { get; set; } = new();
        
        // Barberías a las que está afiliado
        public List<BarberoBarberia> BarberiasAfiliadas { get; set; } = new();
        
        // Estadísticas
        public List<EstadisticaBarbero> Estadisticas { get; set; } = new();
    }
}
