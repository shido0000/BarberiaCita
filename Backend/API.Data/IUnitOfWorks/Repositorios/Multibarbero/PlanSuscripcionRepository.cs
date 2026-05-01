using API.Data.DbContexts;
using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.IUnitOfWorks.Repositorios.Multibarbero
{
    public class PlanSuscripcionRepository : BaseRepository<PlanSuscripcion>, IPlanSuscripcionRepository
    {
        public PlanSuscripcionRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<List<PlanSuscripcion>> ObtenerPlanesPorTipoAsync(TipoPlan tipoPlan)
        {
            return await _dbSet.Where(p => p.TipoPlan == tipoPlan && p.Activo).ToListAsync();
        }

        public async Task<PlanSuscripcion?> ObtenerPlanPorNombreAsync(string nombre)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Nombre == nombre && p.Activo);
        }

        public async Task<List<PlanSuscripcion>> ObtenerPlanesActivosAsync()
        {
            return await _dbSet.Where(p => p.Activo).ToListAsync();
        }
    }
}
