using API.Application.Dtos.Multibarbero.UsuarioBarbero;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IUsuarioBarberoService : IBaseService<UsuarioBarberoDto, CrearUsuarioBarberoInputDto, ActualizarUsuarioBarberoInputDto, FiltrarConfigurarListadoPaginadoUsuarioBarberoInputDto>
    {
        Task<ListadoPaginadoDto<UsuarioBarberoDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoUsuarioBarberoInputDto filtro);
    }
}
