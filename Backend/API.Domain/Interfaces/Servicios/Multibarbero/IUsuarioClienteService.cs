using API.Application.Dtos.Multibarbero.UsuarioCliente;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IUsuarioClienteService : IBaseService<UsuarioClienteDto, CrearUsuarioClienteInputDto, ActualizarUsuarioClienteInputDto, FiltrarConfigurarListadoPaginadoUsuarioClienteInputDto>
    {
        Task<ListadoPaginadoDto<UsuarioClienteDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoUsuarioClienteInputDto filtro);
    }
}
