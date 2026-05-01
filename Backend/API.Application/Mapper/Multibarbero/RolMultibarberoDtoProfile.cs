using API.Data.Entidades.Multibarbero;
using AutoMapper;
using API.Application.Dtos.Multibarbero.RolMultibarbero;

namespace API.Application.Mapper.Multibarbero
{
    public class RolMultibarberoDtoProfile : BaseProfile
    {
        public RolMultibarberoDtoProfile()
        {
            CreateMap<RolMultibarbero, RolMultibarberoDto>()
                .ReverseMap();

            CreateMap<RolMultibarbero, CrearRolMultibarberoInputDto>()
                .ReverseMap();

            CreateMap<RolMultibarbero, ActualizarRolMultibarberoInputDto>()
                .ReverseMap();
        }
    }
}
