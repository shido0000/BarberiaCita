using API.Application.Dtos.Multibarbero.Reserva;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface IReservaService : IBaseService<ReservaDto, CrearReservaInputDto, ActualizarReservaInputDto, FiltrarConfigurarListadoPaginadoReservaInputDto>
    {
        Task<ListadoPaginadoDto<ReservaDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoReservaInputDto filtro);
    }
}
