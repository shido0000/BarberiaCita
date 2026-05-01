using API.Data.Entidades.Multibarbero;
using API.DTOs.Multibarbero.Request;
using API.DTOs.Multibarbero.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Servicios.Multibarbero
{
    /// <summary>
    /// Servicio para gestionar usuarios clientes
    /// </summary>
    public class UsuarioClienteService
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public UsuarioClienteService(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsuarioClienteResponse>> ObtenerTodosAsync()
        {
            var clientes = await _context.Set<UsuarioCliente>()
                .Include(c => c.Usuario)
                .Include(c => c.RolMultibarbero)
                .Include(c => c.Reservas)
                .Where(c => c.Activo)
                .OrderBy(c => c.Usuario.Nombre)
                .ToListAsync();

            return _mapper.Map<List<UsuarioClienteResponse>>(clientes);
        }

        public async Task<UsuarioClienteResponse?> ObtenerPorIdAsync(Guid id)
        {
            var cliente = await _context.Set<UsuarioCliente>()
                .Include(c => c.Usuario)
                .Include(c => c.RolMultibarbero)
                .Include(c => c.Reservas)
                .FirstOrDefaultAsync(c => c.Id == id);

            return cliente != null ? _mapper.Map<UsuarioClienteResponse>(cliente) : null;
        }

        public async Task<UsuarioClienteResponse> CrearAsync(UsuarioClienteRequest request)
        {
            var cliente = _mapper.Map<UsuarioCliente>(request);
            cliente.Id = Guid.NewGuid();
            cliente.FechaCreacion = DateTime.UtcNow;

            await _context.Set<UsuarioCliente>().AddAsync(cliente);
            await _context.SaveChangesAsync();

            return await ObtenerPorIdAsync(cliente.Id);
        }

        public async Task<UsuarioClienteResponse?> ActualizarAsync(Guid id, ActualizarUsuarioClienteRequest request)
        {
            var cliente = await _context.Set<UsuarioCliente>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return null;

            _mapper.Map(request, cliente);
            cliente.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return await ObtenerPorIdAsync(id);
        }

        public async Task<bool> EliminarAsync(Guid id)
        {
            var cliente = await _context.Set<UsuarioCliente>()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
                return false;

            cliente.Activo = false;
            cliente.FechaModificacion = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
