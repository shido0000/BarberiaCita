using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Jobs.Multibarbero
{
    /// <summary>
    /// Job programado con Hangfire para generar notificaciones automáticas
    /// - Notificar suscripciones próximas a vencer (3 días antes)
    /// - Notificar reservas pendientes de confirmación
    /// </summary>
    public class NotificacionesJob
    {
        private readonly DbContext _context;

        public NotificacionesJob(DbContext context)
        {
            _context = context;
        }

        public async Task Ejecutar()
        {
            var ahora = DateTime.UtcNow;
            var notificacionesCreadas = 0;

            // 1. Notificar suscripciones próximas a vencer (en los próximos 3 días)
            var fechaLimite = ahora.AddDays(3);
            var suscripcionesProximasVencer = await _context.Set<SuscripcionUsuario>()
                .Where(s => s.Estado == Data.Enum.Multibarbero.EstadoSuscripcion.Activa
                           && s.FechaFin > ahora
                           && s.FechaFin <= fechaLimite)
                .ToListAsync();

            foreach (var suscripcion in suscripcionesProximasVencer)
            {
                Guid usuarioId;
                string tipoUsuario;

                if (suscripcion.UsuarioBarberoId.HasValue)
                {
                    usuarioId = suscripcion.UsuarioBarberoId.Value;
                    tipoUsuario = "Barbero";
                }
                else if (suscripcion.UsuarioBarberiaId.HasValue)
                {
                    usuarioId = suscripcion.UsuarioBarberiaId.Value;
                    tipoUsuario = "Barbería";
                }
                else
                {
                    continue;
                }

                var diasRestantes = (int)(suscripcion.FechaFin - ahora).TotalDays;
                var notificacion = new Notificacion
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    Titulo = "Suscripción próxima a vencer",
                    Mensaje = $"Tu suscripción al plan {suscripcion.PlanSuscripcion.Nombre} vencerá en {diasRestantes} días. ¡Renueva ahora para continuar disfrutando de todos los beneficios!",
                    Tipo = "Advertencia",
                    EntidadRelacionada = "SuscripcionUsuario",
                    EntidadId = suscripcion.Id,
                    Leida = false,
                    FechaCreacion = ahora
                };

                await _context.Set<Notificacion>().AddAsync(notificacion);
                notificacionesCreadas++;
            }

            // 2. Notificar barberos/barberías sobre reservas pendientes de confirmación
            var reservasPendientes = await _context.Set<Reserva>()
                .Where(r => r.Estado == Data.Enum.Multibarbero.EstadoReserva.Pendiente
                           && r.FechaCreacion < ahora.AddHours(-1)) // Pendientes por más de 1 hora
                .Include(r => r.UsuarioBarbero)
                .Include(r => r.UsuarioBarberia)
                .ToListAsync();

            foreach (var reserva in reservasPendientes)
            {
                Guid? usuarioNotificarId = null;

                if (reserva.UsuarioBarberoId.HasValue)
                {
                    usuarioNotificarId = reserva.UsuarioBarberoId.Value;
                }
                else if (reserva.UsuarioBarberiaId.HasValue)
                {
                    usuarioNotificarId = reserva.UsuarioBarberiaId.Value;
                }

                if (usuarioNotificarId.HasValue)
                {
                    var notificacion = new Notificacion
                    {
                        Id = Guid.NewGuid(),
                        UsuarioId = usuarioNotificarId.Value,
                        Titulo = "Reserva pendiente de confirmación",
                        Mensaje = $"Tienes una reserva pendiente para el servicio {reserva.Servicio.Nombre}. Por favor confirma o rechaza la reserva.",
                        Tipo = "Recordatorio",
                        EntidadRelacionada = "Reserva",
                        EntidadId = reserva.Id,
                        Leida = false,
                        FechaCreacion = ahora
                    };

                    await _context.Set<Notificacion>().AddAsync(notificacion);
                    notificacionesCreadas++;
                }
            }

            // Guardar cambios si hay notificaciones
            if (notificacionesCreadas > 0)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}
