using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los productos en venta (solo para barberos con plan Premium)
    /// </summary>
    public class Producto : EntidadBase
    {
        // Relación con el barbero (propietario del producto)
        public required Guid UsuarioBarberoId { get; set; }
        public UsuarioBarbero UsuarioBarbero { get; set; } = null!;
        
        // Información del producto
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required decimal Precio { get; set; }
        public int Stock { get; set; } = 0;
        
        // Estado del producto
        public bool Activo { get; set; } = true;
        
        // Imágenes del producto (pueden ser múltiples, separadas por coma o JSON)
        public string? Imagenes { get; set; }
        
        // Categoría del producto
        public string? Categoria { get; set; }
        
        // Marca del producto
        public string? Marca { get; set; }
        
        // Fecha de publicación
        public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;
    }
}
