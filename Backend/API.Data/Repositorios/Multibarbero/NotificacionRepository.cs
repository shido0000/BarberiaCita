using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public class NotificacionRepository : BaseRepository<Notificacion>, INotificacionRepository
    {
        public NotificacionRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
