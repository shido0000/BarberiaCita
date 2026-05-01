using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Jobs.Multibarbero
{
    /// <summary>
    /// Job programado con Hangfire para verificar y actualizar el estado de las suscripciones
    /// Se ejecuta diariamente para marcar suscripciones vencidas
    /// </summary>
    public class VerificacionSuscripcionesJob
    {
        private readonly DbContext _context;

        public VerificacionSuscripcionesJob(DbContext context)
        {
            _context = context;
        }

        public async Task Ejecutar()
        {
            var ahora = DateTime.UtcNow;
            
            // Obtener todas las suscripciones activas que han vencido
            var suscripcionesVencidas = await _context.Set<SuscripcionUsuario>()
                .Where(s => s.Estado == Data.Enum.Multibarbero.EstadoSuscripcion.Activa 
                           && s.FechaFin < ahora)
                .ToListAsync();

            foreach (var suscripcion in suscripcionesVencidas)
            {
                suscripcion.Estado = Data.Enum.Multibarbero.EstadoSuscripcion.Vencida;
                suscripcion.FechaModificacion = ahora;
            }

            // Actualizar barberos cuyas suscripciones vencieron
            var barberosConSuscripcionVencida = await _context.Set<UsuarioBarbero>()
                .Where(b => b.SuscripcionActualId.HasValue 
                           && suscripcionesVencidas.Select(s => s.Id).Contains(b.SuscripcionActualId.Value))
                .ToListAsync();

            foreach (var barbero in barberosConSuscripcionVencida)
            {
                barbero.SuscripcionActualId = null;
                barbero.FechaModificacion = ahora;
            }

            // Actualizar barberías cuyas suscripciones vencieron
            var barberiasConSuscripcionVencida = await _context.Set<UsuarioBarberia>()
                .Where(b => b.Suscripciones.Any(s => suscripcionesVencidas.Select(sv => sv.Id).Contains(s.Id)))
                .ToListAsync();

            // Guardar cambios
            if (suscripcionesVencidas.Count > 0 || barberosConSuscripcionVencida.Count > 0)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
