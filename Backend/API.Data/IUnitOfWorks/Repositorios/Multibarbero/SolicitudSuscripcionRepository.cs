using API.Data.DbContexts;
using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.IUnitOfWorks.Repositorios.Multibarbero
{
    public class SolicitudSuscripcionRepository : BaseRepository<SolicitudSuscripcion>, ISolicitudSuscripcionRepository
    {
        public SolicitudSuscripcionRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<List<SolicitudSuscripcion>> ObtenerSolicitudesPendientesAsync()
        {
            return await _dbSet
                .Include(s => s.Usuario)
                .Include(s => s.PlanSolicitado)
                .Where(s => s.Estado == EstadoSolicitud.Pendiente)
                .ToListAsync();
        }

        public async Task<SolicitudSuscripcion?> ObtenerSolicitudPorUsuarioAsync(Guid usuarioId, EstadoSolicitud? estado = null)
        {
            var query = _dbSet.Where(s => s.UsuarioId == usuarioId);
            
            if (estado.HasValue)
            {
                query = query.Where(s => s.Estado == estado.Value);
            }
            
            return await query
                .Include(s => s.PlanSolicitado)
                .OrderByDescending(s => s.FechaSolicitud)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SolicitudSuscripcion>> ObtenerSolicitudesPorUsuarioAsync(Guid usuarioId)
        {
            return await _dbSet
                .Include(s => s.PlanSolicitado)
                .Where(s => s.UsuarioId == usuarioId)
                .OrderByDescending(s => s.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<int> ContarSolicitudesPendientesAsync()
        {
            return await _dbSet.CountAsync(s => s.Estado == EstadoSolicitud.Pendiente);
        }
    }
}
