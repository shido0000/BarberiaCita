using API.Data.Entidades.Multibarbero;
using API.DTOs.Multibarbero.Request;
using API.DTOs.Multibarbero.Response;
using AutoMapper;

namespace API.Application.Mapper.Multibarbero
{
    /// <summary>
    /// Perfil de mapeo para entidades Multibarbero
    /// </summary>
    public class MultibarberoDtoProfile : Profile
    {
        public MultibarberoDtoProfile()
        {
            // RolMultibarbero
            CreateMap<RolMultibarbero, RolMultibarberoResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.Activo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.FechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.FechaModificacion));

            CreateMap<RolMultibarberoRequest, RolMultibarbero>()
                .ForMember(dest => dest.Nombre, opt => opt.Condition(src => src.Nombre != null))
                .ForMember(dest => dest.Descripcion, opt => opt.Condition(src => src.Descripcion != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null));

            // UsuarioBarbero
            CreateMap<UsuarioBarbero, UsuarioBarberoResponse>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null))
                .ForMember(dest => dest.UsuarioEmail, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Correo : null))
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.RolMultibarbero != null ? src.RolMultibarbero.Nombre : null))
                .ForMember(dest => dest.PlanSuscripcionNombre, opt => opt.MapFrom(src => src.SuscripcionActual != null ? src.SuscripcionActual.PlanSuscripcion.Nombre : null));

            CreateMap<UsuarioBarberoRequest, UsuarioBarbero>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Condition(src => src.UsuarioId != Guid.Empty))
                .ForMember(dest => dest.Biografia, opt => opt.Condition(src => src.Biografia != null))
                .ForMember(dest => dest.Especialidades, opt => opt.Condition(src => src.Especialidades != null))
                .ForMember(dest => dest.AniosExperiencia, opt => opt.Condition(src => src.AniosExperiencia != null))
                .ForMember(dest => dest.FotoPerfil, opt => opt.Condition(src => src.FotoPerfil != null))
                .ForMember(dest => dest.Direccion, opt => opt.Condition(src => src.Direccion != null))
                .ForMember(dest => dest.Telefono, opt => opt.Condition(src => src.Telefono != null))
                .ForMember(dest => dest.Latitud, opt => opt.Condition(src => src.Latitud != null))
                .ForMember(dest => dest.Longitud, opt => opt.Condition(src => src.Longitud != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null))
                .ForMember(dest => dest.Verificado, opt => opt.Condition(src => src.Verificado != null))
                .ForMember(dest => dest.RolMultibarberoId, opt => opt.Condition(src => src.RolMultibarberoId != null));

            CreateMap<ActualizarUsuarioBarberoRequest, UsuarioBarbero>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // UsuarioBarberia
            CreateMap<UsuarioBarberia, UsuarioBarberiaResponse>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null))
                .ForMember(dest => dest.UsuarioEmail, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Correo : null))
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.RolMultibarbero != null ? src.RolMultibarbero.Nombre : null))
                .ForMember(dest => dest.CantidadBarberosAfiliados, opt => opt.MapFrom(src => src.BarberosAfiliados != null ? src.BarberosAfiliados.Count(b => b.Activo) : 0));

            CreateMap<UsuarioBarberiaRequest, UsuarioBarberia>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Condition(src => src.UsuarioId != Guid.Empty))
                .ForMember(dest => dest.RolMultibarberoId, opt => opt.Condition(src => src.RolMultibarberoId != Guid.Empty))
                .ForMember(dest => dest.NombreComercial, opt => opt.Condition(src => !string.IsNullOrEmpty(src.NombreComercial)))
                .ForMember(dest => dest.Descripcion, opt => opt.Condition(src => src.Descripcion != null))
                .ForMember(dest => dest.Direccion, opt => opt.Condition(src => src.Direccion != null))
                .ForMember(dest => dest.Telefono, opt => opt.Condition(src => src.Telefono != null))
                .ForMember(dest => dest.CorreoContacto, opt => opt.Condition(src => src.CorreoContacto != null))
                .ForMember(dest => dest.Logo, opt => opt.Condition(src => src.Logo != null))
                .ForMember(dest => dest.ImagenPortada, opt => opt.Condition(src => src.ImagenPortada != null))
                .ForMember(dest => dest.Latitud, opt => opt.Condition(src => src.Latitud != null))
                .ForMember(dest => dest.Longitud, opt => opt.Condition(src => src.Longitud != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null))
                .ForMember(dest => dest.Verificado, opt => opt.Condition(src => src.Verificado != null));

            CreateMap<ActualizarUsuarioBarberiaRequest, UsuarioBarberia>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // UsuarioCliente
            CreateMap<UsuarioCliente, UsuarioClienteResponse>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null))
                .ForMember(dest => dest.UsuarioEmail, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Correo : null))
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.RolMultibarbero != null ? src.RolMultibarbero.Nombre : null))
                .ForMember(dest => dest.CantidadReservas, opt => opt.MapFrom(src => src.Reservas != null ? src.Reservas.Count : 0));

            CreateMap<UsuarioClienteRequest, UsuarioCliente>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Condition(src => src.UsuarioId != Guid.Empty))
                .ForMember(dest => dest.RolMultibarberoId, opt => opt.Condition(src => src.RolMultibarberoId != Guid.Empty))
                .ForMember(dest => dest.Telefono, opt => opt.Condition(src => src.Telefono != null))
                .ForMember(dest => dest.FechaNacimiento, opt => opt.Condition(src => src.FechaNacimiento != null))
                .ForMember(dest => dest.Genero, opt => opt.Condition(src => src.Genero != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null));

            CreateMap<ActualizarUsuarioClienteRequest, UsuarioCliente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // PlanSuscripcion
            CreateMap<PlanSuscripcion, PlanSuscripcionResponse>()
                .ForMember(dest => dest.TipoPlan, opt => opt.MapFrom(src => src.TipoPlan.ToString()));

            CreateMap<PlanSuscripcionRequest, PlanSuscripcion>()
                .ForMember(dest => dest.Nombre, opt => opt.Condition(src => src.Nombre != null))
                .ForMember(dest => dest.Descripcion, opt => opt.Condition(src => src.Descripcion != null))
                .ForMember(dest => dest.TipoPlan, opt => opt.Condition(src => src.TipoPlan != null))
                .ForMember(dest => dest.EsParaBarberia, opt => opt.Condition(src => src.EsParaBarberia != null))
                .ForMember(dest => dest.Precio, opt => opt.Condition(src => src.Precio != null))
                .ForMember(dest => dest.DuracionDias, opt => opt.Condition(src => src.DuracionDias != null))
                .ForMember(dest => dest.LimiteBarberosAfiliados, opt => opt.Condition(src => src.LimiteBarberosAfiliados != null))
                .ForMember(dest => dest.PermiteRecibirReservas, opt => opt.Condition(src => src.PermiteRecibirReservas != null))
                .ForMember(dest => dest.PermiteEstadisticasBasicas, opt => opt.Condition(src => src.PermiteEstadisticasBasicas != null))
                .ForMember(dest => dest.PermiteEstadisticasCompletas, opt => opt.Condition(src => src.PermiteEstadisticasCompletas != null))
                .ForMember(dest => dest.PermitePostearProductos, opt => opt.Condition(src => src.PermitePostearProductos != null))
                .ForMember(dest => dest.PermiteModificarDatos, opt => opt.Condition(src => src.PermiteModificarDatos != null))
                .ForMember(dest => dest.PermiteMostrarServicios, opt => opt.Condition(src => src.PermiteMostrarServicios != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null));

            // Servicio
            CreateMap<Servicio, ServicioResponse>()
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null));

            CreateMap<ServicioRequest, Servicio>()
                .ForMember(dest => dest.UsuarioBarberoId, opt => opt.Condition(src => src.UsuarioBarberoId != null))
                .ForMember(dest => dest.UsuarioBarberiaId, opt => opt.Condition(src => src.UsuarioBarberiaId != null))
                .ForMember(dest => dest.Nombre, opt => opt.Condition(src => src.Nombre != null))
                .ForMember(dest => dest.Descripcion, opt => opt.Condition(src => src.Descripcion != null))
                .ForMember(dest => dest.Precio, opt => opt.Condition(src => src.Precio != null))
                .ForMember(dest => dest.DuracionMinutos, opt => opt.Condition(src => src.DuracionMinutos != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null))
                .ForMember(dest => dest.Orden, opt => opt.Condition(src => src.Orden != null))
                .ForMember(dest => dest.Imagen, opt => opt.Condition(src => src.Imagen != null))
                .ForMember(dest => dest.Categoria, opt => opt.Condition(src => src.Categoria != null));

            // Producto
            CreateMap<Producto, ProductoResponse>()
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null));

            CreateMap<ProductoRequest, Producto>()
                .ForMember(dest => dest.UsuarioBarberoId, opt => opt.Condition(src => src.UsuarioBarberoId != Guid.Empty))
                .ForMember(dest => dest.Nombre, opt => opt.Condition(src => src.Nombre != null))
                .ForMember(dest => dest.Descripcion, opt => opt.Condition(src => src.Descripcion != null))
                .ForMember(dest => dest.Precio, opt => opt.Condition(src => src.Precio != null))
                .ForMember(dest => dest.Stock, opt => opt.Condition(src => src.Stock != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null))
                .ForMember(dest => dest.Imagenes, opt => opt.Condition(src => src.Imagenes != null))
                .ForMember(dest => dest.Categoria, opt => opt.Condition(src => src.Categoria != null))
                .ForMember(dest => dest.Marca, opt => opt.Condition(src => src.Marca != null));

            // Reserva
            CreateMap<Reserva, ReservaResponse>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.UsuarioCliente != null ? src.UsuarioCliente.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null))
                .ForMember(dest => dest.ServicioNombre, opt => opt.MapFrom(src => src.Servicio != null ? src.Servicio.Nombre : null))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));

            CreateMap<ReservaRequest, Reserva>()
                .ForMember(dest => dest.UsuarioClienteId, opt => opt.Condition(src => src.UsuarioClienteId != Guid.Empty))
                .ForMember(dest => dest.UsuarioBarberoId, opt => opt.Condition(src => src.UsuarioBarberoId != null))
                .ForMember(dest => dest.UsuarioBarberiaId, opt => opt.Condition(src => src.UsuarioBarberiaId != null))
                .ForMember(dest => dest.BarberoAfiliadoId, opt => opt.Condition(src => src.BarberoAfiliadoId != null))
                .ForMember(dest => dest.ServicioId, opt => opt.Condition(src => src.ServicioId != Guid.Empty))
                .ForMember(dest => dest.FechaInicio, opt => opt.Condition(src => src.FechaInicio != default))
                .ForMember(dest => dest.NotasCliente, opt => opt.Condition(src => src.NotasCliente != null))
                .ForMember(dest => dest.MetodoPago, opt => opt.Condition(src => src.MetodoPago != null));

            CreateMap<ActualizarEstadoReservaRequest, Reserva>()
                .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != default))
                .ForMember(dest => dest.NotasInternas, opt => opt.Condition(src => src.NotasInternas != null))
                .ForMember(dest => dest.UsuarioRespondioId, opt => opt.Condition(src => src.UsuarioRespondioId != null));

            // SuscripcionUsuario
            CreateMap<SuscripcionUsuario, SuscripcionUsuarioResponse>()
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null))
                .ForMember(dest => dest.PlanNombre, opt => opt.MapFrom(src => src.PlanSuscripcion != null ? src.PlanSuscripcion.Nombre : null))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));

            CreateMap<SuscripcionUsuarioRequest, SuscripcionUsuario>()
                .ForMember(dest => dest.UsuarioBarberoId, opt => opt.Condition(src => src.UsuarioBarberoId != null))
                .ForMember(dest => dest.UsuarioBarberiaId, opt => opt.Condition(src => src.UsuarioBarberiaId != null))
                .ForMember(dest => dest.PlanSuscripcionId, opt => opt.Condition(src => src.PlanSuscripcionId != Guid.Empty))
                .ForMember(dest => dest.FechaInicio, opt => opt.Condition(src => src.FechaInicio != default))
                .ForMember(dest => dest.FechaFin, opt => opt.Condition(src => src.FechaFin != default))
                .ForMember(dest => dest.Estado, opt => opt.Condition(src => src.Estado != null))
                .ForMember(dest => dest.PrecioPagado, opt => opt.Condition(src => src.PrecioPagado != default))
                .ForMember(dest => dest.FechaPago, opt => opt.Condition(src => src.FechaPago != default))
                .ForMember(dest => dest.MetodoPago, opt => opt.Condition(src => src.MetodoPago != null))
                .ForMember(dest => dest.ReferenciaPago, opt => opt.Condition(src => src.ReferenciaPago != null))
                .ForMember(dest => dest.Notas, opt => opt.Condition(src => src.Notas != null));

            // AfiliacionBarbero
            CreateMap<AfiliacionBarbero, AfiliacionBarberoResponse>()
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null));

            CreateMap<AfiliacionBarberoRequest, AfiliacionBarbero>()
                .ForMember(dest => dest.UsuarioBarberoId, opt => opt.Condition(src => src.UsuarioBarberoId != Guid.Empty))
                .ForMember(dest => dest.UsuarioBarberiaId, opt => opt.Condition(src => src.UsuarioBarberiaId != Guid.Empty))
                .ForMember(dest => dest.FechaInicio, opt => opt.Condition(src => src.FechaInicio != default))
                .ForMember(dest => dest.FechaFin, opt => opt.Condition(src => src.FechaFin != null))
                .ForMember(dest => dest.Activo, opt => opt.Condition(src => src.Activo != null));

            // SolicitudSuscripcion
            CreateMap<SolicitudSuscripcion, SolicitudSuscripcionResponse>()
                .ForMember(dest => dest.UsuarioNombre, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.Nombre : null))
                .ForMember(dest => dest.PlanNombre, opt => opt.MapFrom(src => src.PlanSuscripcion != null ? src.PlanSuscripcion.Nombre : null))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));

            CreateMap<SolicitudSuscripcionRequest, SolicitudSuscripcion>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Condition(src => src.UsuarioId != Guid.Empty))
                .ForMember(dest => dest.PlanSuscripcionId, opt => opt.Condition(src => src.PlanSuscripcionId != Guid.Empty))
                .ForMember(dest => dest.Mensaje, opt => opt.Condition(src => src.Mensaje != null));

            // Notificacion
            CreateMap<Notificacion, NotificacionResponse>();

            CreateMap<NotificacionRequest, Notificacion>()
                .ForMember(dest => dest.UsuarioId, opt => opt.Condition(src => src.UsuarioId != Guid.Empty))
                .ForMember(dest => dest.Titulo, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Titulo)))
                .ForMember(dest => dest.Mensaje, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Mensaje)))
                .ForMember(dest => dest.Tipo, opt => opt.Condition(src => src.Tipo != null))
                .ForMember(dest => dest.EntidadRelacionada, opt => opt.Condition(src => src.EntidadRelacionada != null))
                .ForMember(dest => dest.EntidadId, opt => opt.Condition(src => src.EntidadId != null))
                .ForMember(dest => dest.Leida, opt => opt.Condition(src => src.Leida != null));

            // EstadisticaBarbero
            CreateMap<EstadisticaBarbero, EstadisticaBarberoResponse>()
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null));

            // EstadisticaBarberia
            CreateMap<EstadisticaBarberia, EstadisticaBarberiaResponse>()
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null));

            // FavoritoBarbero
            CreateMap<FavoritoBarbero, FavoritoBarberoResponse>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.UsuarioCliente != null ? src.UsuarioCliente.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberoNombre, opt => opt.MapFrom(src => src.UsuarioBarbero != null ? src.UsuarioBarbero.Usuario.Nombre : null));

            // FavoritoBarberia
            CreateMap<FavoritoBarberia, FavoritoBarberiaResponse>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.UsuarioCliente != null ? src.UsuarioCliente.Usuario.Nombre : null))
                .ForMember(dest => dest.BarberiaNombre, opt => opt.MapFrom(src => src.UsuarioBarberia != null ? src.UsuarioBarberia.NombreComercial : null));
        }
    }
}
