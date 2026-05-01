using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los servicios ofrecidos por barberos y barberías
    /// </summary>
    public class Servicio : EntidadBase
    {
        // Relación con el barbero (si es un servicio de barbero independiente)
        public Guid? UsuarioBarberoId { get; set; }
        public UsuarioBarbero? UsuarioBarbero { get; set; }
        
        // Relación con la barbería (si es un servicio de barbería)
        public Guid? UsuarioBarberiaId { get; set; }
        public UsuarioBarberia? UsuarioBarberia { get; set; }
        
        // Información del servicio
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required decimal Precio { get; set; }
        public int DuracionMinutos { get; set; } = 30;
        
        // Estado del servicio
        public bool Activo { get; set; } = true;
        
        // Orden de visualización
        public int Orden { get; set; } = 0;
        
        // Imagen del servicio
        public string? Imagen { get; set; }
        
        // Categoría del servicio
        public string? Categoria { get; set; }
    }
}
