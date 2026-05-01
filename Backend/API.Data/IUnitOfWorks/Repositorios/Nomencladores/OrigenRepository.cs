using API.Data.DbContexts;
using API.Data.Entidades.Nomencladores;

using API.Data.IUnitOfWorks.Interfaces.Nomencladores;

namespace API.Data.IUnitOfWorks.Repositorios.Nomencladores
{
    public class OrigenRepository : BaseRepository<Origen>, IOrigenRepository
    {
        public OrigenRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
