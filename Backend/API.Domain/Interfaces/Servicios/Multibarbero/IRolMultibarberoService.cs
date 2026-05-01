using API.Application.Dtos.Multibarbero.RolMultibarbero;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IRolMultibarberoService
    {
        Task<ListadoPaginadoDto<RolMultibarberoDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoRolMultibarberoInputDto filtro);
        Task<RolMultibarberoDto> ObtenerPorId(Guid id);
        Task<RolMultibarberoDto> Crear(CrearRolMultibarberoInputDto dto);
        Task<RolMultibarberoDto> Actualizar(ActualizarRolMultibarberoInputDto dto);
        Task Eliminar(Guid id);
    }
}
