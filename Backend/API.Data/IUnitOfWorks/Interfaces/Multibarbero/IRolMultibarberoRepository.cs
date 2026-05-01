using API.Data.Entidades.Multibarbero;

namespace API.Data.IUnitOfWorks.Interfaces.Multibarbero
{
    public interface IRolMultibarberoRepository : IBaseRepository<RolMultibarbero>
    {
        Task<RolMultibarbero?> ObtenerPorNombreAsync(string nombre);
        Task<List<RolMultibarbero>> ObtenerRolesActivosAsync();
    }
}
