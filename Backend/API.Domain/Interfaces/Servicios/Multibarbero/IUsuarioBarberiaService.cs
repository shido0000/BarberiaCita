using API.Application.Dtos.Multibarbero.UsuarioBarberia;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IUsuarioBarberiaService : IBaseService<UsuarioBarberiaDto, CrearUsuarioBarberiaInputDto, ActualizarUsuarioBarberiaInputDto, FiltrarConfigurarListadoPaginadoUsuarioBarberiaInputDto>
    {
        Task<ListadoPaginadoDto<UsuarioBarberiaDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoUsuarioBarberiaInputDto filtro);
    }
}
