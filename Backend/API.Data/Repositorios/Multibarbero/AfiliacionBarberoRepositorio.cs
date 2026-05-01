using API.Data.DbContexts;
using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositorios.Multibarbero
{
    public class AfiliacionBarberoRepositorio : RepositorioBase<AfiliacionBarbero>, IAfiliacionBarberoRepositorio
    {
        private readonly ApiDbContext _context;

        public AfiliacionBarberoRepositorio(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AfiliacionBarbero?> ObtenerSolicitudAsync(int barberoId, int barberiaId)
        {
            return await _context.AfiliacionesBarberos
                .Include(a => a.Barbero)
                    .ThenInclude(b => b.Usuario)
                .Include(a => a.Barberia)
                    .ThenInclude(b => b.Usuario)
                .FirstOrDefaultAsync(a => a.BarberoId == barberoId && a.BarberiaId == barberiaId);
        }

        public async Task<bool> ExisteSolicitudPendienteAsync(int barberoId, int barberiaId)
        {
            return await _context.AfiliacionesBarberos
                .AnyAsync(a => a.BarberoId == barberoId && 
                             a.BarberiaId == barberiaId && 
                             a.Estado == EstadoAfiliacion.Pendiente);
        }

        public async Task<IEnumerable<AfiliacionBarbero>> ObtenerSolicitudesPendientesPorBarberiaAsync(int barberiaId)
        {
            return await _context.AfiliacionesBarberos
                .Include(a => a.Barbero)
                    .ThenInclude(b => b.Usuario)
                .Where(a => a.BarberiaId == barberiaId && a.Estado == EstadoAfiliacion.Pendiente)
                .ToListAsync();
        }

        public async Task<IEnumerable<AfiliacionBarbero>> ObtenerSolicitudesPendientesPorBarberoAsync(int barberoId)
        {
            return await _context.AfiliacionesBarberos
                .Include(a => a.Barberia)
                    .ThenInclude(b => b.Usuario)
                .Where(a => a.BarberoId == barberoId && a.Estado == EstadoAfiliacion.Pendiente)
                .ToListAsync();
        }

        public async Task<IEnumerable<AfiliacionBarbero>> ObtenerAfiliacionesActivasPorBarberiaAsync(int barberiaId)
        {
            return await _context.AfiliacionesBarberos
                .Include(a => a.Barbero)
                    .ThenInclude(b => b.Usuario)
                .Where(a => a.BarberiaId == barberiaId && a.Estado == EstadoAfiliacion.Aceptado)
                .ToListAsync();
        }

        public async Task<IEnumerable<AfiliacionBarbero>> ObtenerHistorialAfiliacionesBarberoAsync(int barberoId)
        {
            return await _context.AfiliacionesBarberos
                .Include(a => a.Barberia)
                    .ThenInclude(b => b.Usuario)
                .Where(a => a.BarberoId == barberoId)
                .OrderByDescending(a => a.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<int> ContarBarberosAfiliadosActivosAsync(int barberiaId)
        {
            return await _context.AfiliacionesBarberos
                .CountAsync(a => a.BarberiaId == barberiaId && a.Estado == EstadoAfiliacion.Aceptado);
        }
    }
}
