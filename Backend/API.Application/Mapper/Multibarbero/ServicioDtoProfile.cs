using AutoMapper;
using API.Data.Entidades.Multibarbero;
using API.Application.Dtos.Multibarbero.Servicio;

namespace API.Application.Mapper.Multibarbero
{
    public class ServicioDtoProfile : BaseProfile
    {
        public ServicioDtoProfile()
        {
            CreateMap<Servicio, ServicioDto>()
                .ForMember(d => d.NombreBarbero, opt => opt.MapFrom(s => s.UsuarioBarbero != null ? s.UsuarioBarbero.Usuario.Username : null))
                .ForMember(d => d.NombreBarberia, opt => opt.MapFrom(s => s.UsuarioBarberia != null ? s.UsuarioBarberia.Usuario.Username : null))
                .ReverseMap();

            CreateMap<Servicio, CrearServicioInputDto>()
                .ReverseMap();

            CreateMap<Servicio, ActualizarServicioInputDto>()
                .ReverseMap();
        }
    }
}
