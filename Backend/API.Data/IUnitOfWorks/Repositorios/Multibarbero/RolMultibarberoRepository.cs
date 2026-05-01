using API.Data.DbContexts;
using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.IUnitOfWorks.Repositorios.Multibarbero
{
    public class RolMultibarberoRepository : BaseRepository<RolMultibarbero>, IRolMultibarberoRepository
    {
        public RolMultibarberoRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<RolMultibarbero?> ObtenerPorNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.Nombre == nombre && r.Activo);
        }

        public async Task<List<RolMultibarbero>> ObtenerRolesActivosAsync()
        {
            return await _dbSet.Where(r => r.Activo).ToListAsync();
        }
    }
}
