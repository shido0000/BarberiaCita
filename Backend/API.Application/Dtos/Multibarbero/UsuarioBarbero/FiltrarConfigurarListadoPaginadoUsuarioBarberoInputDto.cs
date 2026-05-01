using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.UsuarioBarbero
{
    public class FiltrarConfigurarListadoPaginadoUsuarioBarberoInputDto : ConfiguracionListadoPaginadoDto
    {
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
        public Guid? PlanSuscripcionId { get; set; }
        public decimal? LatitudMin { get; set; }
        public decimal? LatitudMax { get; set; }
        public decimal? LongitudMin { get; set; }
        public decimal? LongitudMax { get; set; }
    }
}
