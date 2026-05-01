using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.PlanSuscripcion
{
    public class ActualizarPlanSuscripcionInputDto : EntidadBaseDto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? DuracionDias { get; set; }
        public int? LimiteBarberosAfiliados { get; set; }
        public bool? PermiteRecibirReservas { get; set; }
        public bool? PermiteEstadisticasBasicas { get; set; }
        public bool? PermiteEstadisticasCompletas { get; set; }
        public bool? PermitePostearProductos { get; set; }
        public bool? PermiteModificarDatos { get; set; }
        public bool? PermiteMostrarServicios { get; set; }
        public bool? Activo { get; set; }
    }
}
