using API.Data.DbContexts;
using API.Data.Entidades.Multibarbero;
using API.Data.IUnitOfWorks.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.IUnitOfWorks.Repositorios.Multibarbero
{
    public class SuscripcionUsuarioRepository : BaseRepository<SuscripcionUsuario>, ISuscripcionUsuarioRepository
    {
        public SuscripcionUsuarioRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<SuscripcionUsuario?> ObtenerSuscripcionActivaPorUsuarioAsync(Guid usuarioId)
        {
            return await _dbSet
                .Include(s => s.Plan)
                .FirstOrDefaultAsync(s => s.UsuarioId == usuarioId && s.Estado == EstadoSuscripcion.Activa);
        }

        public async Task<List<SuscripcionUsuario>> ObtenerHistorialSuscripcionesPorUsuarioAsync(Guid usuarioId)
        {
            return await _dbSet
                .Include(s => s.Plan)
                .Where(s => s.UsuarioId == usuarioId)
                .OrderByDescending(s => s.FechaInicio)
                .ToListAsync();
        }

        public async Task<List<SuscripcionUsuario>> ObtenerSuscripcionesPorVencerAsync(int dias)
        {
            var fechaLimite = DateTime.UtcNow.AddDays(dias);
            return await _dbSet
                .Include(s => s.Plan)
                .Where(s => s.Estado == EstadoSuscripcion.Activa && s.FechaFin <= fechaLimite)
                .ToListAsync();
        }

        public async Task<List<SuscripcionUsuario>> ObtenerSuscripcionesVencidasAsync()
        {
            return await _dbSet
                .Include(s => s.Plan)
                .Where(s => s.Estado == EstadoSuscripcion.Activa && s.FechaFin < DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
