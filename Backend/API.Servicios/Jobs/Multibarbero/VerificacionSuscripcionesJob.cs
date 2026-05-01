using API.Data.Entidades.Multibarbero;
using API.Servicios.Interfaces.Multibarbero;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicios.Jobs.Multibarbero
{
    /// <summary>
    /// Job programado para verificar el estado de las suscripciones de las barberías
    /// Se ejecuta diariamente para validar vencimientos y actualizar estados
    /// </summary>
    public class VerificacionSuscripcionesJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<VerificacionSuscripcionesJob> _logger;

        public VerificacionSuscripcionesJob(
            IServiceProvider serviceProvider,
            ILogger<VerificacionSuscripcionesJob> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Ejecuta la verificación de suscripciones
        /// Valida fechas de vencimiento y actualiza estados de barberías
        /// </summary>
        public async Task EjecutarAsync()
        {
            _logger.LogInformation("Iniciando job de verificación de suscripciones - {Fecha}", DateTime.Now);

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var contexto = scope.ServiceProvider.GetRequiredService<API.Data.DbContexts.ApiDbContext>();
                var suscripcionServicio = scope.ServiceProvider.GetRequiredService<ISuscripcionServicio>();

                var fechaActual = DateTime.Now;

                // Obtener todas las suscripciones activas
                var suscripcionesActivas = await contexto.SuscripcionUsuarios
                    .Include(s => s.UsuarioBarberia)
                    .Include(s => s.PlanSuscripcion)
                    .Where(s => s.Estado == "Activa")
                    .ToListAsync();

                int suscripcionesVencidas = 0;
                int suscripcionesPorVencer = 0;

                foreach (var suscripcion in suscripcionesActivas)
                {
                    // Verificar si la suscripción ha vencido
                    if (suscripcion.FechaFin < fechaActual)
                    {
                        _logger.LogWarning("Suscripción ID {Id} de Barberia ID {BarberiaId} ha vencido", 
                            suscripcion.Id, suscripcion.UsuarioBarberiaId);

                        // Actualizar estado de la suscripción
                        suscripcion.Estado = "Vencida";
                        suscripcion.FechaModificacion = fechaActual;

                        // Desactivar la barbería asociada
                        if (suscripcion.UsuarioBarberia != null)
                        {
                            suscripcion.UsuarioBarberia.Activo = false;
                        }

                        suscripcionesVencidas++;
                    }
                    else if ((suscripcion.FechaFin - fechaActual).TotalDias <= 7)
                    {
                        // Suscripción por vencer en menos de 7 días
                        _logger.LogInformation("Suscripción ID {Id} vence en {Dias} días", 
                            suscripcion.Id, (suscripcion.FechaFin - fechaActual).TotalDias);

                        suscripcionesPorVencer++;

                        // Aquí se podría enviar una notificación al usuario
                        await EnviarNotificacionProximoVencimiento(contexto, suscripcion);
                    }
                }

                await contexto.SaveChangesAsync();

                _logger.LogInformation("Job de verificación de suscripciones completado. " +
                    "Vencidas: {Vencidas}, Por vencer: {PorVencer}", 
                    suscripcionesVencidas, suscripcionesPorVencer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error durante la ejecución del job de verificación de suscripciones");
                throw;
            }
        }

        /// <summary>
        /// Envía notificación de próximo vencimiento
        /// </summary>
        private async Task EnviarNotificacionProximoVencimiento(
            API.Data.DbContexts.ApiDbContext contexto, 
            SuscripcionUsuario suscripcion)
        {
            try
            {
                var notificacion = new Notificacion
                {
                    UsuarioId = suscripcion.UsuarioBarberiaId,
                    Tipo = "Suscripcion",
                    Titulo = "Suscripción por Vencer",
                    Mensaje = $"Tu suscripción al plan '{suscripcion.PlanSuscripcion.Nombre}' vencerá pronto. " +
                              $"Fecha de vencimiento: {suscripcion.FechaFin:dd/MM/yyyy}",
                    Leida = false,
                    FechaCreacion = DateTime.Now
                };

                contexto.Notificaciones.Add(notificacion);
                await contexto.SaveChangesAsync();

                _logger.LogInformation("Notificación de vencimiento enviada para Suscripción ID {Id}", suscripcion.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al enviar notificación de vencimiento para Suscripción ID {Id}", suscripcion.Id);
            }
        }
    }
}
