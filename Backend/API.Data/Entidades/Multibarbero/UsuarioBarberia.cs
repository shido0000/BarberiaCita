using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los datos específicos de las barberías en el sistema multibarbero
    /// </summary>
    public class UsuarioBarberia : EntidadBase
    {
        // Relación con Usuario base
        public required Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Relación con RolMultibarbero
        public required Guid RolMultibarberoId { get; set; }
        public RolMultibarbero RolMultibarbero { get; set; } = null!;

        // Información específica de la barbería
        public required string NombreComercial { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoContacto { get; set; }
        public string? Logo { get; set; }
        public string? ImagenPortada { get; set; }
        
        // Ubicación geográfica
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        
        // Estado de la barbería
        public bool Activo { get; set; } = true;
        public bool Verificado { get; set; } = false;
        
        // Relaciones
        public List<SuscripcionUsuario> Suscripciones { get; set; } = new();
        public List<AfiliacionBarbero> BarberosAfiliados { get; set; } = new();
        public List<ServicioBarberia> Servicios { get; set; } = new();
        public List<ProductoBarberia> Productos { get; set; } = new();
        public List<Reserva> Reservas { get; set; } = new();
        public List<EstadisticaBarberia> Estadisticas { get; set; } = new();
    }
}
