using API.Data.Entidades.Multibarbero;
using API.DTOs.Multibarbero.Request;
using API.DTOs.Multibarbero.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Servicios.Multibarbero
{
    /// <summary>
    /// Servicio para gestionar roles del sistema Multibarbero
    /// </summary>
    public class RolMultibarberoService
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public RolMultibarberoService(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RolMultibarberoResponse>> ObtenerTodosAsync()
        {
            var roles = await _context.Set<RolMultibarbero>()
                .Where(r => r.Activo)
                .OrderBy(r => r.Nombre)
                .ToListAsync();

            return _mapper.Map<List<RolMultibarberoResponse>>(roles);
        }

        public async Task<RolMultibarberoResponse?> ObtenerPorIdAsync(Guid id)
        {
            var rol = await _context.Set<RolMultibarbero>()
                .FirstOrDefaultAsync(r => r.Id == id);

            return rol != null ? _mapper.Map<RolMultibarberoResponse>(rol) : null;
        }

        public async Task<RolMultibarberoResponse> CrearAsync(RolMultibarberoRequest request)
        {
            var rol = _mapper.Map<RolMultibarbero>(request);
            rol.Id = Guid.NewGuid();
            rol.FechaCreacion = DateTime.UtcNow;

            await _context.Set<RolMultibarbero>().AddAsync(rol);
            await _context.SaveChangesAsync();

            return _mapper.Map<RolMultibarberoResponse>(rol);
        }

        public async Task<RolMultibarberoResponse?> ActualizarAsync(Guid id, RolMultibarberoRequest request)
        {
            var rol = await _context.Set<RolMultibarbero>()
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rol == null)
                return null;

            _mapper.Map(request, rol);
            rol.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return _mapper.Map<RolMultibarberoResponse>(rol);
        }

        public async Task<bool> EliminarAsync(Guid id)
        {
            var rol = await _context.Set<RolMultibarbero>()
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rol == null)
                return false;

            rol.Activo = false;
            rol.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
