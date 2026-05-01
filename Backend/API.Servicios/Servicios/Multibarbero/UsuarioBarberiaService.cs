using API.Data.Entidades.Multibarbero;
using API.DTOs.Multibarbero.Request;
using API.DTOs.Multibarbero.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Servicios.Multibarbero
{
    /// <summary>
    /// Servicio para gestionar usuarios barberos
    /// </summary>
    public class UsuarioBarberiaService
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public UsuarioBarberiaService(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioBarberiaResponse>> ObtenerTodosAsync()
        {
            var barberias = await _context.Set<UsuarioBarberia>()
                .Include(b => b.Usuario)
                .Include(b => b.RolMultibarbero)
                .Include(b => b.BarberosAfiliados)
                .Where(b => b.Activo)
                .OrderBy(b => b.NombreComercial)
                .ToListAsync();

            return _mapper.Map<List<UsuarioBarberiaResponse>>(barberias);
        }

        public async Task<UsuarioBarberiaResponse?> ObtenerPorIdAsync(Guid id)
        {
            var barberia = await _context.Set<UsuarioBarberia>()
                .Include(b => b.Usuario)
                .Include(b => b.RolMultibarbero)
                .Include(b => b.BarberosAfiliados)
                .FirstOrDefaultAsync(b => b.Id == id);

            return barberia != null ? _mapper.Map<UsuarioBarberiaResponse>(barberia) : null;
        }

        public async Task<UsuarioBarberiaResponse> CrearAsync(UsuarioBarberiaRequest request)
        {
            var barberia = _mapper.Map<UsuarioBarberia>(request);
            barberia.Id = Guid.NewGuid();
            barberia.FechaCreacion = DateTime.UtcNow;

            await _context.Set<UsuarioBarberia>().AddAsync(barberia);
            await _context.SaveChangesAsync();

            return await ObtenerPorIdAsync(barberia.Id);
        }

        public async Task<UsuarioBarberiaResponse?> ActualizarAsync(Guid id, ActualizarUsuarioBarberiaRequest request)
        {
            var barberia = await _context.Set<UsuarioBarberia>()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barberia == null)
                return null;

            _mapper.Map(request, barberia);
            barberia.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await ObtenerPorIdAsync(id);
        }

        public async Task<bool> EliminarAsync(Guid id)
        {
            var barberia = await _context.Set<UsuarioBarberia>()
                .FirstOrDefaultAsync(b => b.Id == id);

            if (barberia == null)
                return false;

            barberia.Activo = false;
            barberia.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
