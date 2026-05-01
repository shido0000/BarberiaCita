using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public interface IUsuarioBarberoRepositorio : IRepositorioBase<UsuarioBarbero>
    {
        Task<UsuarioBarbero?> ObtenerPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosConSuscripcionActivaAsync();
        Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosPorBarberiaAsync(int barberiaId);
        Task<bool> ExisteBarberoConUsuarioAsync(int usuarioId);
    }
}
