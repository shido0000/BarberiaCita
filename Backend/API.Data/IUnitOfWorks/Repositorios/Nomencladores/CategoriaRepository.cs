using API.Data.DbContexts;
using API.Data.Entidades.Nomencladores;

using API.Data.IUnitOfWorks.Interfaces.Nomencladores;

namespace API.Data.IUnitOfWorks.Repositorios.Nomencladores
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
