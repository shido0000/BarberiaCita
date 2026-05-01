using API.Data.Entidades.Multibarbero;

namespace API.DTOs.Multibarbero.Request
{
    /// <summary>
    /// DTO para crear o actualizar un RolMultibarbero
    /// </summary>
    public class RolMultibarberoRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
    }

    /// <summary>
    /// DTO para crear un UsuarioBarbero
    /// </summary>
    public class UsuarioBarberoRequest
    {
        public Guid UsuarioId { get; set; }
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
        public Guid? RolMultibarberoId { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un UsuarioBarbero
    /// </summary>
    public class ActualizarUsuarioBarberoRequest
    {
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
    }

    /// <summary>
    /// DTO para crear un UsuarioBarberia
    /// </summary>
    public class UsuarioBarberiaRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid RolMultibarberoId { get; set; }
        public string NombreComercial { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoContacto { get; set; }
        public string? Logo { get; set; }
        public string? ImagenPortada { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un UsuarioBarberia
    /// </summary>
    public class ActualizarUsuarioBarberiaRequest
    {
        public string? NombreComercial { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoContacto { get; set; }
        public string? Logo { get; set; }
        public string? ImagenPortada { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
    }

    /// <summary>
    /// DTO para crear un UsuarioCliente
    /// </summary>
    public class UsuarioClienteRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid RolMultibarberoId { get; set; }
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public bool? Activo { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un UsuarioCliente
    /// </summary>
    public class ActualizarUsuarioClienteRequest
    {
        public string? Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public bool? Activo { get; set; }
    }

    /// <summary>
    /// DTO para crear un PlanSuscripcion
    /// </summary>
    public class PlanSuscripcionRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public Data.Enum.Multibarbero.TipoPlan? TipoPlan { get; set; }
        public bool? EsParaBarberia { get; set; }
        public decimal? Precio { get; set; }
        public int? DuracionDias { get; set; }
        public int? LimiteBarberosAfiliados { get; set; }
        public bool? PermiteRecibirReservas { get; set; }
        public bool? PermiteEstadisticasBasicas { get; set; }
        public bool? PermiteEstadisticasCompletas { get; set; }
        public bool? PermitePostearProductos { get; set; }
        public bool? PermiteModificarDatos { get; set; }
        public bool? PermiteMostrarServicios { get; set; }
        public bool? Activo { get; set; }
    }

    /// <summary>
    /// DTO para crear un Servicio
    /// </summary>
    public class ServicioRequest
    {
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? DuracionMinutos { get; set; }
        public bool? Activo { get; set; }
        public int? Orden { get; set; }
        public string? Imagen { get; set; }
        public string? Categoria { get; set; }
    }

    /// <summary>
    /// DTO para crear un Producto
    /// </summary>
    public class ProductoRequest
    {
        public Guid UsuarioBarberoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
        public bool? Activo { get; set; }
        public string? Imagenes { get; set; }
        public string? Categoria { get; set; }
        public string? Marca { get; set; }
    }

    /// <summary>
    /// DTO para crear una Reserva
    /// </summary>
    public class ReservaRequest
    {
        public Guid UsuarioClienteId { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public Guid? BarberoAfiliadoId { get; set; }
        public Guid ServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public string? NotasCliente { get; set; }
        public string? MetodoPago { get; set; }
    }

    /// <summary>
    /// DTO para actualizar el estado de una Reserva
    /// </summary>
    public class ActualizarEstadoReservaRequest
    {
        public Data.Enum.Multibarbero.EstadoReserva Estado { get; set; }
        public string? NotasInternas { get; set; }
        public Guid? UsuarioRespondioId { get; set; }
    }

    /// <summary>
    /// DTO para crear una SuscripcionUsuario
    /// </summary>
    public class SuscripcionUsuarioRequest
    {
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public Guid PlanSuscripcionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Data.Enum.Multibarbero.EstadoSuscripcion? Estado { get; set; }
        public decimal PrecioPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string? MetodoPago { get; set; }
        public string? ReferenciaPago { get; set; }
        public string? Notas { get; set; }
    }

    /// <summary>
    /// DTO para crear una AfiliacionBarbero
    /// </summary>
    public class AfiliacionBarberoRequest
    {
        public Guid UsuarioBarberoId { get; set; }
        public Guid UsuarioBarberiaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool? Activo { get; set; }
    }

    /// <summary>
    /// DTO para crear una SolicitudSuscripcion
    /// </summary>
    public class SolicitudSuscripcionRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid PlanSuscripcionId { get; set; }
        public string? Mensaje { get; set; }
    }

    /// <summary>
    /// DTO para crear una Notificacion
    /// </summary>
    public class NotificacionRequest
    {
        public Guid UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string? Tipo { get; set; }
        public string? EntidadRelacionada { get; set; }
        public Guid? EntidadId { get; set; }
        public bool? Leida { get; set; }
    }
}
