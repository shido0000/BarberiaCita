using API.Data.Entidades.Multibarbero;

namespace API.Data.IUnitOfWorks.Interfaces.Multibarbero
{
    public interface ISuscripcionUsuarioRepository : IBaseRepository<SuscripcionUsuario>
    {
        Task<SuscripcionUsuario?> ObtenerSuscripcionActivaPorUsuarioAsync(Guid usuarioId);
        Task<List<SuscripcionUsuario>> ObtenerHistorialSuscripcionesPorUsuarioAsync(Guid usuarioId);
        Task<List<SuscripcionUsuario>> ObtenerSuscripcionesPorVencerAsync(int dias);
        Task<List<SuscripcionUsuario>> ObtenerSuscripcionesVencidasAsync();
    }
}
