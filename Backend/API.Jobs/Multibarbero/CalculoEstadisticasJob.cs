using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Jobs.Multibarbero
{
    /// <summary>
    /// Job programado con Hangfire para calcular estadísticas de barberos y barberías
    /// Se ejecuta diariamente para actualizar métricas
    /// </summary>
    public class CalculoEstadisticasJob
    {
        private readonly DbContext _context;

        public CalculoEstadisticasJob(DbContext context)
        {
            _context = context;
        }

        public async Task Ejecutar()
        {
            var ahora = DateTime.UtcNow;
            var fechaHoyInicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 0, 0, 0, DateTimeKind.Utc);

            // 1. Calcular estadísticas para barberos
            var barberos = await _context.Set<UsuarioBarbero>()
                .Where(b => b.Activo)
                .ToListAsync();

            foreach (var barbero in barberos)
            {
                var reservas = await _context.Set<Reserva>()
                    .Where(r => r.UsuarioBarberoId == barbero.Id)
                    .ToListAsync();

                var estadistica = new EstadisticaBarbero
                {
                    Id = Guid.NewGuid(),
                    UsuarioBarberoId = barbero.Id,
                    TotalReservas = reservas.Count,
                    ReservasCompletadas = reservas.Count(r => r.Estado == Data.Enum.Multibarbero.EstadoReserva.Completada),
                    ReservasCanceladas = reservas.Count(r => r.Estado == Data.Enum.Multibarbero.EstadoReserva.Cancelada || 
                                                              r.Estado == Data.Enum.Multibarbero.EstadoReserva.Rechazada),
                    IngresosTotales = reservas.Where(r => r.Pagado).Sum(r => r.PrecioTotal),
                    CalificacionPromedio = 0, // Se puede calcular si hay tabla de calificaciones
                    TotalResenas = 0,
                    FechaCalculo = ahora,
                    FechaCreacion = ahora
                };

                await _context.Set<EstadisticaBarbero>().AddAsync(estadistica);
            }

            // 2. Calcular estadísticas para barberías
            var barberias = await _context.Set<UsuarioBarberia>()
                .Where(b => b.Activo)
                .ToListAsync();

            foreach (var barberia in barberias)
            {
                var reservas = await _context.Set<Reserva>()
                    .Where(r => r.UsuarioBarberiaId == barberia.Id)
                    .ToListAsync();

                var barberosAfiliados = await _context.Set<AfiliacionBarbero>()
                    .CountAsync(a => a.UsuarioBarberiaId == barberia.Id && a.Activo);

                var estadistica = new EstadisticaBarberia
                {
                    Id = Guid.NewGuid(),
                    UsuarioBarberiaId = barberia.Id,
                    TotalReservas = reservas.Count,
                    ReservasCompletadas = reservas.Count(r => r.Estado == Data.Enum.Multibarbero.EstadoReserva.Completada),
                    ReservasCanceladas = reservas.Count(r => r.Estado == Data.Enum.Multibarbero.EstadoReserva.Cancelada || 
                                                              r.Estado == Data.Enum.Multibarbero.EstadoReserva.Rechazada),
                    IngresosTotales = reservas.Where(r => r.Pagado).Sum(r => r.PrecioTotal),
                    TotalBarberos = barberosAfiliados,
                    CalificacionPromedio = 0,
                    TotalResenas = 0,
                    FechaCalculo = ahora,
                    FechaCreacion = ahora
                };

                await _context.Set<EstadisticaBarberia>().AddAsync(estadistica);
            }

            // Guardar cambios
            await _context.SaveChangesAsync();
        }
    }
}
