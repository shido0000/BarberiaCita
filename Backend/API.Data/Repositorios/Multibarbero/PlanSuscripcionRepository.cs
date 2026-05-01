using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;

namespace API.Data.Repositorios.Multibarbero
{
    public class PlanSuscripcionRepository : BaseRepository<PlanSuscripcion>, IPlanSuscripcionRepository
    {
        public PlanSuscripcionRepository(ApiDbContext context) : base(context)
        {
        }
    }
}
