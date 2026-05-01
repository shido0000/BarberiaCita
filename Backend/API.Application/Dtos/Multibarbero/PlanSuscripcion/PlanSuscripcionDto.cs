using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.PlanSuscripcion
{
    public class PlanSuscripcionDto : EntidadBaseDto
    {
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required TipoPlan TipoPlan { get; set; }
        public required bool EsParaBarberia { get; set; }
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public int? LimiteBarberosAfiliados { get; set; }
        public bool PermiteRecibirReservas { get; set; } = false;
        public bool PermiteEstadisticasBasicas { get; set; } = false;
        public bool PermiteEstadisticasCompletas { get; set; } = false;
        public bool PermitePostearProductos { get; set; } = false;
        public bool PermiteModificarDatos { get; set; } = true;
        public bool PermiteMostrarServicios { get; set; } = true;
        public bool Activo { get; set; } = true;
    }
}
