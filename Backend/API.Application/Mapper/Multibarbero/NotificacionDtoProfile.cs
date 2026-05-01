using AutoMapper;
using API.Data.Entidades.Multibarbero;
using API.Application.Dtos.Multibarbero.Notificacion;

namespace API.Application.Mapper.Multibarbero
{
    public class NotificacionDtoProfile : BaseProfile
    {
        public NotificacionDtoProfile()
        {
            CreateMap<Notificacion, NotificacionDto>()
                .ReverseMap();

            CreateMap<Notificacion, CrearNotificacionInputDto>()
                .ReverseMap();

            CreateMap<Notificacion, ActualizarNotificacionInputDto>()
                .ReverseMap();
        }
    }
}
