using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public interface ISuscripcionUsuarioRepositorio : IRepositorioBase<SuscripcionUsuario>
    {
        Task<SuscripcionUsuario?> ObtenerPorBarberoIdAsync(int barberoId);
        Task<SuscripcionUsuario?> ObtenerPorBarberiaIdAsync(int barberiaId);
        Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesPorPlanAsync(int planId);
        Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesVencidasAsync();
        Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesPorVencerAsync(int dias);
        Task<bool> ExisteSuscripcionActivaAsync(int entidadId, bool esBarbero);
    }
}
