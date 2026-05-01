using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.PlanSuscripcion
{
    public class FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto : ConfiguracionListadoPaginadoDto
    {
        public TipoPlan? TipoPlan { get; set; }
        public bool? EsParaBarberia { get; set; }
        public bool? Activo { get; set; }
        public decimal? PrecioMinimo { get; set; }
        public decimal? PrecioMaximo { get; set; }
    }
}
