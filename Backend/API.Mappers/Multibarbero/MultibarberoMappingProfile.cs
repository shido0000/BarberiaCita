using API.Data.Entidades.Multibarbero;
using API.DTOs.Multibarbero;
using AutoMapper;

namespace API.Mappers.Multibarbero
{
    public class MultibarberoMappingProfile : Profile
    {
        public MultibarberoMappingProfile()
        {
            // RolMultibarbero
            CreateMap<RolMultibarbero, RolMultibarberoDto>();
            CreateMap<CrearRolMultibarberoDto, RolMultibarbero>();
            CreateMap<ActualizarRolMultibarberoDto, RolMultibarbero>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // PlanSuscripcion
            CreateMap<PlanSuscripcion, PlanSuscripcionDto>();
            CreateMap<CrearPlanSuscripcionDto, PlanSuscripcion>();
            CreateMap<ActualizarPlanSuscripcionDto, PlanSuscripcion>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // UsuarioBarbero
            CreateMap<UsuarioBarbero, UsuarioBarberoDto>();
            CreateMap<CrearUsuarioBarberoDto, UsuarioBarbero>();
            CreateMap<ActualizarUsuarioBarberoDto, UsuarioBarbero>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // UsuarioBarberia
            CreateMap<UsuarioBarberia, UsuarioBarberiaDto>();
            CreateMap<CrearUsuarioBarberiaDto, UsuarioBarberia>();
            CreateMap<ActualizarUsuarioBarberiaDto, UsuarioBarberia>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // UsuarioCliente
            CreateMap<UsuarioCliente, UsuarioClienteDto>();
            CreateMap<CrearUsuarioClienteDto, UsuarioCliente>();
            CreateMap<ActualizarUsuarioClienteDto, UsuarioCliente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Servicio
            CreateMap<Servicio, ServicioDto>();
            CreateMap<CrearServicioDto, Servicio>();
            CreateMap<ActualizarServicioDto, Servicio>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Producto
            CreateMap<Producto, ProductoDto>();
            CreateMap<CrearProductoDto, Producto>();
            CreateMap<ActualizarProductoDto, Producto>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Reserva
            CreateMap<Reserva, ReservaDto>();
            CreateMap<CrearReservaDto, Reserva>();
            CreateMap<ActualizarReservaDto, Reserva>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
