using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
