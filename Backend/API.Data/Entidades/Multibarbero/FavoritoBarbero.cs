using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los favoritos de clientes hacia barberos
    /// </summary>
    public class FavoritoBarbero : EntidadBase
    {
        // Cliente que añade a favorito
        public required Guid UsuarioClienteId { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; } = null!;
        
        // Barbero añadido a favoritos
        public required Guid UsuarioBarberoId { get; set; }
        public UsuarioBarbero UsuarioBarbero { get; set; } = null!;
        
        // Fecha en que se añadió a favoritos
        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
        
        // Notas opcionales del cliente
        public string? Notas { get; set; }
    }
}
