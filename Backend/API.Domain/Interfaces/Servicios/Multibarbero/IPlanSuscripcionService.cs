using API.Application.Dtos.Multibarbero.PlanSuscripcion;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IPlanSuscripcionService : IBaseService<PlanSuscripcionDto, CrearPlanSuscripcionInputDto, ActualizarPlanSuscripcionInputDto, FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto>
    {
        Task<DetallesPlanSuscripcionDto> ObtenerPorId(Guid id);
        Task<ListadoPaginadoDto<PlanSuscripcionDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto filtro);
    }
}
