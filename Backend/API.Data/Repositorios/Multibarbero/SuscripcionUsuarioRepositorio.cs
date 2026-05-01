using API.Data.DbContexts;
using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositorios.Multibarbero
{
    public class SuscripcionUsuarioRepositorio : RepositorioBase<SuscripcionUsuario>, ISuscripcionUsuarioRepositorio
    {
        private readonly ApiDbContext _context;

        public SuscripcionUsuarioRepositorio(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SuscripcionUsuario?> ObtenerPorBarberoIdAsync(int barberoId)
        {
            return await _context.SuscripcionesUsuarios
                .Include(s => s.Plan)
                .Include(s => s.UsuarioBarbero)
                    .ThenInclude(ub => ub.Usuario)
                .FirstOrDefaultAsync(s => s.UsuarioBarberoId == barberoId);
        }

        public async Task<SuscripcionUsuario?> ObtenerPorBarberiaIdAsync(int barberiaId)
        {
            return await _context.SuscripcionesUsuarios
                .Include(s => s.Plan)
                .Include(s => s.UsuarioBarberia)
                    .ThenInclude(ub => ub.Usuario)
                .FirstOrDefaultAsync(s => s.UsuarioBarberiaId == barberiaId);
        }

        public async Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesPorPlanAsync(int planId)
        {
            return await _context.SuscripcionesUsuarios
                .Include(s => s.Plan)
                .Where(s => s.PlanId == planId)
                .ToListAsync();
        }

        public async Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesVencidasAsync()
        {
            return await _context.SuscripcionesUsuarios
                .Include(s => s.Plan)
                .Where(s => s.Estado == EstadoSuscripcion.Activa && 
                           s.FechaVencimiento < DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<IEnumerable<SuscripcionUsuario>> ObtenerSuscripcionesPorVencerAsync(int dias)
        {
            var fechaLimite = DateTime.UtcNow.AddDays(dias);
            return await _context.SuscripcionesUsuarios
                .Include(s => s.Plan)
                .Where(s => s.Estado == EstadoSuscripcion.Activa && 
                           s.FechaVencimiento >= DateTime.UtcNow &&
                           s.FechaVencimiento <= fechaLimite)
                .ToListAsync();
        }

        public async Task<bool> ExisteSuscripcionActivaAsync(int entidadId, bool esBarbero)
        {
            if (esBarbero)
            {
                return await _context.SuscripcionesUsuarios
                    .AnyAsync(s => s.UsuarioBarberoId == entidadId &&
                                   s.Estado == EstadoSuscripcion.Activa &&
                                   s.FechaVencimiento > DateTime.UtcNow);
            }
            else
            {
                return await _context.SuscripcionesUsuarios
                    .AnyAsync(s => s.UsuarioBarberiaId == entidadId &&
                                   s.Estado == EstadoSuscripcion.Activa &&
                                   s.FechaVencimiento > DateTime.UtcNow);
            }
        }
    }
}
