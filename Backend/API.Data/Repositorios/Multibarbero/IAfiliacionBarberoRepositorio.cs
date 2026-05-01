using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public interface IAfiliacionBarberoRepositorio : IRepositorioBase<AfiliacionBarbero>
    {
        Task<AfiliacionBarbero?> ObtenerSolicitudAsync(int barberoId, int barberiaId);
        Task<bool> ExisteSolicitudPendienteAsync(int barberoId, int barberiaId);
        Task<IEnumerable<AfiliacionBarbero>> ObtenerSolicitudesPendientesPorBarberiaAsync(int barberiaId);
        Task<IEnumerable<AfiliacionBarbero>> ObtenerSolicitudesPendientesPorBarberoAsync(int barberoId);
        Task<IEnumerable<AfiliacionBarbero>> ObtenerAfiliacionesActivasPorBarberiaAsync(int barberiaId);
        Task<IEnumerable<AfiliacionBarbero>> ObtenerHistorialAfiliacionesBarberoAsync(int barberoId);
        Task<int> ContarBarberosAfiliadosActivosAsync(int barberiaId);
    }
}
