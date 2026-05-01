using API.Data.DbContexts;
using API.Data.Repositorios;
using API.Dominio.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repositorios.Multibarbero
{
    public class UsuarioBarberoRepositorio : RepositorioBase<UsuarioBarbero>, IUsuarioBarberoRepositorio
    {
        private readonly ApiDbContext _context;

        public UsuarioBarberoRepositorio(ApiDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UsuarioBarbero?> ObtenerPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuariosBarberos
                .Include(ub => ub.Usuario)
                .Include(ub => ub.SuscripcionActual)
                    .ThenInclude(s => s.Plan)
                .Include(ub => ub.BarberiaActual)
                .FirstOrDefaultAsync(ub => ub.UsuarioId == usuarioId);
        }

        public async Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosConSuscripcionActivaAsync()
        {
            return await _context.UsuariosBarberos
                .Include(ub => ub.SuscripcionActual)
                    .ThenInclude(s => s.Plan)
                .Where(ub => ub.SuscripcionActual != null && 
                             ub.SuscripcionActual.Estado == Dominio.Entidades.Multibarbero.EstadoSuscripcion.Activa &&
                             ub.SuscripcionActual.FechaVencimiento > DateTime.UtcNow)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosPorBarberiaAsync(int barberiaId)
        {
            return await _context.UsuariosBarberos
                .Include(ub => ub.Usuario)
                .Include(ub => ub.SuscripcionActual)
                .Where(ub => ub.BarberiaId == barberiaId && 
                             ub.EstadoAfiliacion == Dominio.Entidades.Multibarbero.EstadoAfiliacion.Aceptado)
                .ToListAsync();
        }

        public async Task<bool> ExisteBarberoConUsuarioAsync(int usuarioId)
        {
            return await _context.UsuariosBarberos.AnyAsync(ub => ub.UsuarioId == usuarioId);
        }
    }
}
