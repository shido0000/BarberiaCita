using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los planes de suscripción disponibles para barberos y barberías
    /// </summary>
    public class PlanSuscripcion : EntidadBase
    {
        public required string Nombre { get; set; } // Free, Popular, Premium, Básico, Estándar, Enterprise
        public required string Descripcion { get; set; }
        public required Enum.Multibarbero.TipoPlan TipoPlan { get; set; }
        
        // Especifico para tipo de usuario
        public required bool EsParaBarberia { get; set; } // true = para barberías, false = para barberos
        
        // Precio del plan (0 para Free)
        public decimal Precio { get; set; }
        
        // Duración en días del plan
        public int DuracionDias { get; set; }
        
        // Límite de barberos afiliados (solo para barberías, null para barberos)
        public int? LimiteBarberosAfiliados { get; set; }
        
        // Características del plan
        public bool PermiteRecibirReservas { get; set; } = false;
        public bool PermiteEstadisticasBasicas { get; set; } = false;
        public bool PermiteEstadisticasCompletas { get; set; } = false;
        public bool PermitePostearProductos { get; set; } = false;
        public bool PermiteModificarDatos { get; set; } = true;
        public bool PermiteMostrarServicios { get; set; } = true;
        
        // Estado del plan
        public bool Activo { get; set; } = true;
        
        // Relaciones
        public List<SuscripcionUsuario> Suscripciones { get; set; } = new();
    }
}
