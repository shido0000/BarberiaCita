using API.Data.DbContexts;
using API.Data.Entidades.Nomencladores;

using API.Data.IUnitOfWorks.Interfaces.Nomencladores;

namespace API.Data.IUnitOfWorks.Repositorios.Nomencladores
{
    public class GrupoRepository : BaseRepository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
