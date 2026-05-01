using API.Application.Dtos.Multibarbero.Servicio;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IServicioService : IBaseService<ServicioDto, CrearServicioInputDto, ActualizarServicioInputDto, FiltrarConfigurarListadoPaginadoServicioInputDto>
    {
        Task<ListadoPaginadoDto<ServicioDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoServicioInputDto filtro);
    }
}
