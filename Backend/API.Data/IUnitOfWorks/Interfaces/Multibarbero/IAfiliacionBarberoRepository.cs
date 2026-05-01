using API.Data.Entidades.Multibarbero;

namespace API.Data.IUnitOfWorks.Interfaces.Multibarbero
{
    public interface IAfiliacionBarberoRepository : IBaseRepository<AfiliacionBarbero>
    {
        Task<AfiliacionBarbero?> ObtenerAfiliacionActivaPorBarberoAsync(Guid barberoId);
        Task<List<AfiliacionBarbero>> ObtenerAfiliacionesPorBarberiaAsync(Guid barberiaId);
        Task<List<AfiliacionBarbero>> ObtenerAfiliacionesPendientesAsync();
        Task<AfiliacionBarbero?> ObtenerSolicitudAfiliacionAsync(Guid barberoId, Guid barberiaId);
        Task<int> ContarBarberosAfiliadosActivosAsync(Guid barberiaId);
    }
}
