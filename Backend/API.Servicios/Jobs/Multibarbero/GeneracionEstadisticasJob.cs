using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Jobs.Multibarbero
{
    /// <summary>
    /// Job programado para generar estadísticas diarias de barberos y barberías
    /// Se ejecuta diariamente para consolidar métricas del día anterior
    /// </summary>
    public class GeneracionEstadisticasJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<GeneracionEstadisticasJob> _logger;

        public GeneracionEstadisticasJob(
            IServiceProvider serviceProvider,
            ILogger<GeneracionEstadisticasJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Ejecuta la generación de estadísticas diarias
        /// </summary>
        public async Task EjecutarAsync()
        {
            _logger.LogInformation("Iniciando job de generación de estadísticas - {Fecha}", DateTime.Now);

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var contexto = scope.ServiceProvider.GetRequiredService<API.Data.DbContexts.ApiDbContext>();

                var fechaHoy = DateTime.Today;
                var fechaAyer = fechaHoy.AddDays(-1);

                // Generar estadísticas para cada barbería
                await GenerarEstadisticasBarberias(contexto, fechaAyer);

                // Generar estadísticas para cada barbero
                await GenerarEstadisticasBarberos(contexto, fechaAyer);

                await contexto.SaveChangesAsync();

                _logger.LogInformation("Job de generación de estadísticas completado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la ejecución del job de generación de estadísticas");
                throw;
            }
        }

        /// <summary>
        /// Genera estadísticas diarias para todas las barberías
        /// </summary>
        private async Task GenerarEstadisticasBarberias(
            API.Data.DbContexts.ApiDbContext contexto, 
            DateTime fechaReferencia)
        {
            var barberias = contexto.UsuarioBarberias
                .Where(b => b.Activo)
                .ToList();

            foreach (var barberia in barberias)
            {
                var reservasDia = contexto.Reservas
                    .Where(r => r.BarberiaId == barberia.Id &&
                               r.FechaHora.Date == fechaReferencia)
                    .ToList();

                var estadistica = new EstadisticaBarberia
                {
                    UsuarioBarberiaId = barberia.Id,
                    Fecha = fechaReferencia,
                    TotalReservas = reservasDia.Count,
                    ReservasConfirmadas = reservasDia.Count(r => r.Estado == "Confirmada"),
                    ReservasCompletadas = reservasDia.Count(r => r.Estado == "Completada"),
                    ReservasCanceladas = reservasDia.Count(r => r.Estado == "Cancelada"),
                    IngresosTotales = reservasDia.Where(r => r.Estado == "Completada").Sum(r => r.PrecioTotal),
                    ClientesUnicos = reservasDia.Select(r => r.ClienteId).Distinct().Count(),
                    FechaCreacion = DateTime.Now
                };

                contexto.EstadisticasBarberias.Add(estadistica);
                
                _logger.LogDebug("Estadísticas generadas para Barberia ID {Id} - Fecha {Fecha}", 
                    barberia.Id, fechaReferencia);
            }
        }

        /// <summary>
        /// Genera estadísticas diarias para todos los barberos
        /// </summary>
        private async Task GenerarEstadisticasBarberos(
            API.Data.DbContexts.ApiDbContext contexto, 
            DateTime fechaReferencia)
        {
            var barberos = contexto.UsuarioBarberos
                .Where(b => b.Activo)
                .ToList();

            foreach (var barbero in barberos)
            {
                var reservasDia = contexto.Reservas
                    .Where(r => r.BarberoId == barbero.Id &&
                               r.FechaHora.Date == fechaReferencia)
                    .ToList();

                var estadistica = new EstadisticaBarbero
                {
                    UsuarioBarberoId = barbero.Id,
                    Fecha = fechaReferencia,
                    TotalReservas = reservasDia.Count,
                    ReservasCompletadas = reservasDia.Count(r => r.Estado == "Completada"),
                    ReservasCanceladas = reservasDia.Count(r => r.Estado == "Cancelada"),
                    IngresosTotales = reservasDia.Where(r => r.Estado == "Completada").Sum(r => r.PrecioTotal),
                    PropinaPromedio = 0, // Se podría calcular si se tiene información de propinas
                    FechaCreacion = DateTime.Now
                };

                contexto.EstadisticasBarberos.Add(estadistica);
                
                _logger.LogDebug("Estadísticas generadas para Barbero ID {Id} - Fecha {Fecha}", 
                    barbero.Id, fechaReferencia);
            }
        }
    }
}
