using API.Data.DbContexts;
using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.IUnitOfWorks.Repositorios.Multibarbero
{
    public class AfiliacionBarberoRepository : BaseRepository<AfiliacionBarbero>, IAfiliacionBarberoRepository
    {
        public AfiliacionBarberoRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<AfiliacionBarbero?> ObtenerAfiliacionActivaPorBarberoAsync(Guid barberoId)
        {
            return await _dbSet
                .Include(a => a.Barbero)
                .Include(a => a.Barberia)
                .FirstOrDefaultAsync(a => a.BarberoId == barberoId && a.Estado == EstadoAfiliacion.Aceptada);
        }

        public async Task<List<AfiliacionBarbero>> ObtenerAfiliacionesPorBarberiaAsync(Guid barberiaId)
        {
            return await _dbSet
                .Include(a => a.Barbero)
                .Where(a => a.BarberiaId == barberiaId && a.Estado == EstadoAfiliacion.Aceptada)
                .ToListAsync();
        }

        public async Task<List<AfiliacionBarbero>> ObtenerAfiliacionesPendientesAsync()
        {
            return await _dbSet
                .Include(a => a.Barbero)
                .Include(a => a.Barberia)
                .Where(a => a.Estado == EstadoAfiliacion.Pendiente)
                .ToListAsync();
        }

        public async Task<AfiliacionBarbero?> ObtenerSolicitudAfiliacionAsync(Guid barberoId, Guid barberiaId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(a => a.BarberoId == barberoId && a.BarberiaId == barberiaId);
        }

        public async Task<int> ContarBarberosAfiliadosActivosAsync(Guid barberiaId)
        {
            return await _dbSet.CountAsync(a => a.BarberiaId == barberiaId && a.Estado == EstadoAfiliacion.Aceptada);
        }
    }
}
