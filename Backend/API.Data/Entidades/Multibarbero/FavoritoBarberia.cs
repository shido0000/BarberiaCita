using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los favoritos de clientes hacia barberías
    /// </summary>
    public class FavoritoBarberia : EntidadBase
    {
        // Cliente que añade a favorito
        public required Guid UsuarioClienteId { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; } = null!;
        
        // Barbería añadida a favoritos
        public required Guid UsuarioBarberiaId { get; set; }
        public UsuarioBarberia UsuarioBarberia { get; set; } = null!;
        
        // Fecha en que se añadió a favoritos
        public DateTime FechaAgregado { get; set; } = DateTime.UtcNow;
        
        // Notas opcionales del cliente
        public string? Notas { get; set; }
    }
}
