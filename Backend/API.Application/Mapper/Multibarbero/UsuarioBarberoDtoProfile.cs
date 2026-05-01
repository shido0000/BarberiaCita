using AutoMapper;
using API.Data.Entidades.Multibarbero;
using API.Application.Dtos.Multibarbero.UsuarioBarbero;

namespace API.Application.Mapper.Multibarbero
{
    public class UsuarioBarberoDtoProfile : BaseProfile
    {
        public UsuarioBarberoDtoProfile()
        {
            CreateMap<UsuarioBarbero, UsuarioBarberoDto>()
                .ForMember(d => d.NombreUsuario, opt => opt.MapFrom(s => s.Usuario != null ? s.Usuario.Username : null))
                .ForMember(d => d.PlanSuscripcionNombre, opt => opt.MapFrom(s => s.SuscripcionActual != null ? s.SuscripcionActual.PlanSuscripcion.Nombre : null))
                .ForMember(d => d.FechaVencimientoSuscripcion, opt => opt.MapFrom(s => s.SuscripcionActual != null ? s.SuscripcionActual.FechaFin : null))
                .ReverseMap();

            CreateMap<UsuarioBarbero, CrearUsuarioBarberoInputDto>()
                .ReverseMap();

            CreateMap<UsuarioBarbero, ActualizarUsuarioBarberoInputDto>()
                .ReverseMap();
        }
    }
}
