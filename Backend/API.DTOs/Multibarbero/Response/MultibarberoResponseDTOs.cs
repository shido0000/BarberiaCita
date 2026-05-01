using API.Data.Entidades.Multibarbero;

namespace API.DTOs.Multibarbero.Response
{
    /// <summary>
    /// DTO para respuesta de RolMultibarbero
    /// </summary>
    public class RolMultibarberoResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de UsuarioBarbero
    /// </summary>
    public class UsuarioBarberoResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioEmail { get; set; }
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool Activo { get; set; }
        public bool Verificado { get; set; }
        public Guid? RolMultibarberoId { get; set; }
        public string? RolNombre { get; set; }
        public Guid? SuscripcionActualId { get; set; }
        public string? PlanSuscripcionNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de UsuarioBarberia
    /// </summary>
    public class UsuarioBarberiaResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioEmail { get; set; }
        public Guid RolMultibarberoId { get; set; }
        public string? RolNombre { get; set; }
        public string NombreComercial { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoContacto { get; set; }
        public string? Logo { get; set; }
        public string? ImagenPortada { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool Activo { get; set; }
        public bool Verificado { get; set; }
        public int? CantidadBarberosAfiliados { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de UsuarioCliente
    /// </summary>
    public class UsuarioClienteResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? UsuarioEmail { get; set; }
        public Guid RolMultibarberoId { get; set; }
        public string? RolNombre { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public bool Activo { get; set; }
        public int? CantidadReservas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de PlanSuscripcion
    /// </summary>
    public class PlanSuscripcionResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string TipoPlan { get; set; } = string.Empty;
        public bool EsParaBarberia { get; set; }
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public int? LimiteBarberosAfiliados { get; set; }
        public bool PermiteRecibirReservas { get; set; }
        public bool PermiteEstadisticasBasicas { get; set; }
        public bool PermiteEstadisticasCompletas { get; set; }
        public bool PermitePostearProductos { get; set; }
        public bool PermiteModificarDatos { get; set; }
        public bool PermiteMostrarServicios { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de Servicio
    /// </summary>
    public class ServicioResponse
    {
        public Guid Id { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public bool Activo { get; set; }
        public int Orden { get; set; }
        public string? Imagen { get; set; }
        public string? Categoria { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de Producto
    /// </summary>
    public class ProductoResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }
        public string? Imagenes { get; set; }
        public string? Categoria { get; set; }
        public string? Marca { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de Reserva
    /// </summary>
    public class ReservaResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public Guid? BarberoAfiliadoId { get; set; }
        public Guid ServicioId { get; set; }
        public string? ServicioNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string? NotasCliente { get; set; }
        public string? NotasInternas { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public Guid? UsuarioRespondioId { get; set; }
        public decimal PrecioTotal { get; set; }
        public string? MetodoPago { get; set; }
        public bool Pagado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de SuscripcionUsuario
    /// </summary>
    public class SuscripcionUsuarioResponse
    {
        public Guid Id { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public Guid PlanSuscripcionId { get; set; }
        public string? PlanNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal PrecioPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string? MetodoPago { get; set; }
        public string? ReferenciaPago { get; set; }
        public string? Notas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de AfiliacionBarbero
    /// </summary>
    public class AfiliacionBarberoResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public Guid UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de SolicitudSuscripcion
    /// </summary>
    public class SolicitudSuscripcionResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
        public Guid PlanSuscripcionId { get; set; }
        public string? PlanNombre { get; set; }
        public string? Mensaje { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public Guid? UsuarioRespondioId { get; set; }
        public string? RespuestaMotivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de Notificacion
    /// </summary>
    public class NotificacionResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string? Tipo { get; set; }
        public string? EntidadRelacionada { get; set; }
        public Guid? EntidadId { get; set; }
        public bool Leida { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de EstadisticaBarbero
    /// </summary>
    public class EstadisticaBarberoResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public int TotalReservas { get; set; }
        public int ReservasCompletadas { get; set; }
        public int ReservasCanceladas { get; set; }
        public decimal IngresosTotales { get; set; }
        public double CalificacionPromedio { get; set; }
        public int TotalResenas { get; set; }
        public DateTime FechaCalculo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de EstadisticaBarberia
    /// </summary>
    public class EstadisticaBarberiaResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public int TotalReservas { get; set; }
        public int ReservasCompletadas { get; set; }
        public int ReservasCanceladas { get; set; }
        public decimal IngresosTotales { get; set; }
        public int TotalBarberos { get; set; }
        public double CalificacionPromedio { get; set; }
        public int TotalResenas { get; set; }
        public DateTime FechaCalculo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de FavoritoBarbero
    /// </summary>
    public class FavoritoBarberoResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public Guid UsuarioBarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    /// <summary>
    /// DTO para respuesta de FavoritoBarberia
    /// </summary>
    public class FavoritoBarberiaResponse
    {
        public Guid Id { get; set; }
        public Guid UsuarioClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public Guid UsuarioBarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
