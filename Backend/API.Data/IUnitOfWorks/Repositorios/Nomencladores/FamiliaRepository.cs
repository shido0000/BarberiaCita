using API.Data.DbContexts;
using API.Data.Entidades.Nomencladores;

using API.Data.IUnitOfWorks.Interfaces.Nomencladores;

namespace API.Data.IUnitOfWorks.Repositorios.Nomencladores
{
    public class FamiliaRepository : BaseRepository<Familia>, IFamiliaRepository
    {
        public FamiliaRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
