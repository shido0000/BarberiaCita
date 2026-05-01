using API.Data.Entidades.Multibarbero;

namespace API.Data.IUnitOfWorks.Interfaces.Multibarbero
{
    public interface ISolicitudSuscripcionRepository : IBaseRepository<SolicitudSuscripcion>
    {
        Task<List<SolicitudSuscripcion>> ObtenerSolicitudesPendientesAsync();
        Task<SolicitudSuscripcion?> ObtenerSolicitudPorUsuarioAsync(Guid usuarioId, EstadoSolicitud? estado = null);
        Task<List<SolicitudSuscripcion>> ObtenerSolicitudesPorUsuarioAsync(Guid usuarioId);
        Task<int> ContarSolicitudesPendientesAsync();
    }
}
