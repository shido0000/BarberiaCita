using API.Application.Dtos.Multibarbero.Notificacion;
using API.Application.Dtos.Comunes;

namespace API.Domain.Interfaces.Servicios.Multibarbero
{
    public interface INotificacionService : IBaseService<NotificacionDto, CrearNotificacionInputDto, ActualizarNotificacionInputDto, FiltrarConfigurarListadoPaginadoNotificacionInputDto>
    {
        Task<ListadoPaginadoDto<NotificacionDto>> ObtenerListadoPaginado(FiltrarConfigurarListadoPaginadoNotificacionInputDto filtro);
    }
}
