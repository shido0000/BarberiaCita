using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los datos específicos de los clientes en el sistema multibarbero
    /// </summary>
    public class UsuarioCliente : EntidadBase
    {
        // Relación con Usuario base
        public required Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Relación con RolMultibarbero
        public required Guid RolMultibarberoId { get; set; }
        public RolMultibarbero RolMultibarbero { get; set; } = null!;

        // Información específica del cliente
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        
        // Estado del cliente
        public bool Activo { get; set; } = true;
        
        // Relaciones
        public List<Reserva> Reservas { get; set; } = new();
        public List<FavoritoBarbero> FavoritosBarberos { get; set; } = new();
        public List<FavoritoBarberia> FavoritosBarberias { get; set; } = new();
    }
}
