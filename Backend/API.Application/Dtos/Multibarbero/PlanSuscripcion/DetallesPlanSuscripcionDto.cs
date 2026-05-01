using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.PlanSuscripcion
{
    public class DetallesPlanSuscripcionDto : PlanSuscripcionDto
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int CantidadSuscriptores { get; set; }
    }
}
