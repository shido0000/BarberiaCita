using AutoMapper;
using API.Data.Entidades.Multibarbero;
using API.Application.Dtos.Multibarbero.Reserva;

namespace API.Application.Mapper.Multibarbero
{
    public class ReservaDtoProfile : BaseProfile
    {
        public ReservaDtoProfile()
        {
            CreateMap<Reserva, ReservaDto>()
                .ForMember(d => d.NombreCliente, opt => opt.MapFrom(s => s.UsuarioCliente != null ? s.UsuarioCliente.Usuario.Username : null))
                .ForMember(d => d.NombreBarbero, opt => opt.MapFrom(s => s.UsuarioBarbero != null ? s.UsuarioBarbero.Usuario.Username : null))
                .ForMember(d => d.NombreBarberia, opt => opt.MapFrom(s => s.UsuarioBarberia != null ? s.UsuarioBarberia.Usuario.Username : null))
                .ForMember(d => d.ServicioNombre, opt => opt.MapFrom(s => s.Servicio != null ? s.Servicio.Nombre : null))
                .ReverseMap();

            CreateMap<Reserva, CrearReservaInputDto>()
                .ReverseMap();

            CreateMap<Reserva, ActualizarReservaInputDto>()
                .ReverseMap();
        }
    }
}
