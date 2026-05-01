using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public class UsuarioBarberoRepository : BaseRepository<UsuarioBarbero>, IUsuarioBarberoRepository
    {
        public UsuarioBarberoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
