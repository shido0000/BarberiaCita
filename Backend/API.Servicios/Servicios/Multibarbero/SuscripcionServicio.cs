using API.Data.Repositorios.Multibarbero;
using API.Dominio.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Servicios.Multibarbero
{
    public class SuscripcionServicio : ISuscripcionServicio
    {
        private readonly IRepositorioBase<PlanSuscripcion> _planRepositorio;
        private readonly ISuscripcionUsuarioRepositorio _suscripcionRepositorio;
        private readonly IRepositorioBase<SolicitudSuscripcion> _solicitudRepositorio;
        private readonly IAfiliacionBarberoRepositorio _afiliacionRepositorio;
        private readonly IUsuarioBarberoRepositorio _barberoRepositorio;
        private readonly IUsuarioBarberiaRepositorio _barberiaRepositorio;
        private readonly INotificacionServicio _notificacionServicio;
        private readonly IUnitOfWork _unitOfWork;

        public SuscripcionServicio(
            IRepositorioBase<PlanSuscripcion> planRepositorio,
            ISuscripcionUsuarioRepositorio suscripcionRepositorio,
            IRepositorioBase<SolicitudSuscripcion> solicitudRepositorio,
            IAfiliacionBarberoRepositorio afiliacionRepositorio,
            IUsuarioBarberoRepositorio barberoRepositorio,
            IUsuarioBarberiaRepositorio barberiaRepositorio,
            INotificacionServicio notificacionServicio,
            IUnitOfWork unitOfWork)
        {
            _planRepositorio = planRepositorio;
            _suscripcionRepositorio = suscripcionRepositorio;
            _solicitudRepositorio = solicitudRepositorio;
            _afiliacionRepositorio = afiliacionRepositorio;
            _barberoRepositorio = barberoRepositorio;
            _barberiaRepositorio = barberiaRepositorio;
            _notificacionServicio = notificacionServicio;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlanSuscripcion> CrearPlanSuscripcionAsync(CrearPlanSuscripcionDto dto)
        {
            var plan = new PlanSuscripcion
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                TipoPlan = dto.TipoPlan,
                EsParaBarbero = dto.EsParaBarbero,
                Precio = dto.Precio,
                DuracionDias = dto.DuracionDias,
                MaximoBarberosAfiliados = dto.MaximoBarberosAfiliados,
                Caracteristicas = string.Join(",", dto.Caracteristicas),
                Activo = dto.Activo
            };

            await _planRepositorio.CrearAsync(plan);
            await _unitOfWork.SaveChangesAsync();
            
            return plan;
        }

        public async Task<PlanSuscripcion> ActualizarPlanSuscripcionAsync(int planId, ActualizarPlanSuscripcionDto dto)
        {
            var plan = await _planRepositorio.ObtenerPorIdAsync(planId)
                ?? throw new Exception("Plan no encontrado");

            if (!string.IsNullOrEmpty(dto.Nombre))
                plan.Nombre = dto.Nombre;
            
            if (dto.Descripcion != null)
                plan.Descripcion = dto.Descripcion;
            
            if (dto.Precio.HasValue)
                plan.Precio = dto.Precio.Value;
            
            if (dto.DuracionDias.HasValue)
                plan.DuracionDias = dto.DuracionDias.Value;
            
            if (dto.MaximoBarberosAfiliados.HasValue)
                plan.MaximoBarberosAfiliados = dto.MaximoBarberosAfiliados.Value;
            
            if (dto.Caracteristicas != null)
                plan.Caracteristicas = string.Join(",", dto.Caracteristicas);
            
            if (dto.Activo.HasValue)
                plan.Activo = dto.Activo.Value;

            await _planRepositorio.ActualizarAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return plan;
        }

        public async Task<IEnumerable<PlanSuscripcion>> ObtenerTodosLosPlanesAsync()
        {
            return await _planRepositorio.ObtenerTodosAsync();
        }

        public async Task<PlanSuscripcion?> ObtenerPlanPorIdAsync(int planId)
        {
            return await _planRepositorio.ObtenerPorIdAsync(planId);
        }

        public async Task<SolicitudSuscripcion> SolicitarCambioSuscripcionBarberoAsync(int barberoId, int nuevoPlanId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId)
                ?? throw new Exception("Barbero no encontrado");

            var nuevoPlan = await _planRepositorio.ObtenerPorIdAsync(nuevoPlanId)
                ?? throw new Exception("Plan no encontrado");

            if (!nuevoPlan.EsParaBarbero)
                throw new Exception("El plan seleccionado no es para barberos");

            var suscripcionActual = await _suscripcionRepositorio.ObtenerPorBarberoIdAsync(barberoId);
            
            if (suscripcionActual == null)
                throw new Exception("El barbero no tiene una suscripción activa");

            // Verificar si ya existe una solicitud pendiente
            var solicitudExistente = await _solicitudRepositorio.ObtenerTodosAsync();
            var solicitudPendiente = solicitudExistente
                .FirstOrDefault(s => s.UsuarioBarberoId == barberoId && 
                                    s.Estado == EstadoSolicitud.Pendiente);

            if (solicitudPendiente != null)
                throw new Exception("Ya existe una solicitud de cambio de suscripción pendiente");

            var solicitud = new SolicitudSuscripcion
            {
                UsuarioBarberoId = barberoId,
                PlanActualId = suscripcionActual.PlanId,
                NuevoPlanId = nuevoPlanId,
                FechaSolicitud = DateTime.UtcNow,
                Estado = EstadoSolicitud.Pendiente,
                TipoSolicitud = "CambioPlan"
            };

            await _solicitudRepositorio.CrearAsync(solicitud);
            await _unitOfWork.SaveChangesAsync();

            // Notificar a Admin y Comercial
            var admins = await ObtenerAdminsAsync();
            var comerciales = await ObtenerComercialesAsync();

            foreach (var admin in admins)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    admin.Id,
                    TipoNotificacion.CambioSuscripcion,
                    $"El barbero {barbero.Usuario.Nombre} solicita cambiar de {suscripcionActual.Plan.Nombre} a {nuevoPlan.Nombre}",
                    new { SolicitudId = solicitud.Id, BarberoId = barberoId });
            }

            foreach (var comercial in comerciales)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    comercial.Id,
                    TipoNotificacion.CambioSuscripcion,
                    $"El barbero {barbero.Usuario.Nombre} solicita cambiar de {suscripcionActual.Plan.Nombre} a {nuevoPlan.Nombre}",
                    new { SolicitudId = solicitud.Id, BarberoId = barberoId });
            }

            return solicitud;
        }

        public async Task<IEnumerable<SolicitudSuscripcion>> ObtenerSolicitudesPendientesBarberoAsync(int barberoId)
        {
            var solicitudes = await _solicitudRepositorio.ObtenerTodosAsync();
            return solicitudes.Where(s => s.UsuarioBarberoId == barberoId && 
                                          s.Estado == EstadoSolicitud.Pendiente);
        }

        public async Task<SolicitudSuscripcion> SuscribirseBarberiaAsync(int barberiaId, int planId)
        {
            var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(barberiaId)
                ?? throw new Exception("Barbería no encontrada");

            var plan = await _planRepositorio.ObtenerPorIdAsync(planId)
                ?? throw new Exception("Plan no encontrado");

            if (plan.EsParaBarbero)
                throw new Exception("El plan seleccionado no es para barberías");

            // Verificar si ya tiene una suscripción activa
            var suscripcionExistente = await _suscripcionRepositorio.ObtenerPorBarberiaIdAsync(barberiaId);
            if (suscripcionExistente != null && suscripcionExistente.Estado == EstadoSuscripcion.Activa)
                throw new Exception("La barbería ya tiene una suscripción activa");

            var solicitud = new SolicitudSuscripcion
            {
                UsuarioBarberiaId = barberiaId,
                NuevoPlanId = planId,
                FechaSolicitud = DateTime.UtcNow,
                Estado = EstadoSolicitud.Pendiente,
                TipoSolicitud = "NuevaSuscripcion"
            };

            await _solicitudRepositorio.CrearAsync(solicitud);
            await _unitOfWork.SaveChangesAsync();

            // Notificar a Admin y Comercial
            var admins = await ObtenerAdminsAsync();
            var comerciales = await ObtenerComercialesAsync();

            foreach (var admin in admins)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    admin.Id,
                    TipoNotificacion.NuevaSuscripcionBarberia,
                    $"La barbería {barberia.Usuario.Nombre} solicita suscribirse al plan {plan.Nombre}",
                    new { SolicitudId = solicitud.Id, BarberiaId = barberiaId });
            }

            foreach (var comercial in comerciales)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    comercial.Id,
                    TipoNotificacion.NuevaSuscripcionBarberia,
                    $"La barbería {barberia.Usuario.Nombre} solicita suscribirse al plan {plan.Nombre}",
                    new { SolicitudId = solicitud.Id, BarberiaId = barberiaId });
            }

            return solicitud;
        }

        public async Task<bool> AprobarSolicitudSuscripcionAsync(int solicitudId, int usuarioAprobadorId)
        {
            var solicitud = await _solicitudRepositorio.ObtenerPorIdAsync(solicitudId)
                ?? throw new Exception("Solicitud no encontrada");

            if (solicitud.Estado != EstadoSolicitud.Pendiente)
                throw new Exception("La solicitud ya fue procesada");

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                solicitud.Estado = EstadoSolicitud.Aprobado;
                solicitud.FechaRespuesta = DateTime.UtcNow;
                solicitud.RespuestaMotivo = "Aprobada";
                
                await _solicitudRepositorio.ActualizarAsync(solicitud);

                if (solicitud.UsuarioBarberoId.HasValue)
                {
                    // Cambio de plan para barbero
                    var barbero = await _barberoRepositorio.ObtenerPorIdAsync(solicitud.UsuarioBarberoId.Value)
                        ?? throw new Exception("Barbero no encontrado");

                    var suscripcionActual = await _suscripcionRepositorio.ObtenerPorBarberoIdAsync(solicitud.UsuarioBarberoId.Value);
                    if (suscripcionActual != null)
                    {
                        // Desactivar suscripción anterior
                        suscripcionActual.Estado = EstadoSuscripcion.Cancelada;
                        await _suscripcionRepositorio.ActualizarAsync(suscripcionActual);
                    }

                    // Crear nueva suscripción
                    var nuevaSuscripcion = new SuscripcionUsuario
                    {
                        UsuarioBarberoId = barbero.Id,
                        PlanId = solicitud.NuevoPlanId,
                        FechaInicio = DateTime.UtcNow,
                        FechaVencimiento = DateTime.UtcNow.AddDays((await _planRepositorio.ObtenerPorIdAsync(solicitud.NuevoPlanId))!.DuracionDias),
                        Estado = EstadoSuscripcion.Activa
                    };

                    await _suscripcionRepositorio.CrearAsync(nuevaSuscripcion);
                    barbero.SuscripcionActualId = nuevaSuscripcion.Id;
                    await _barberoRepositorio.ActualizarAsync(barbero);

                    // Notificar al barbero
                    await _notificacionServicio.CrearNotificacionAsync(
                        barbero.UsuarioId,
                        TipoNotificacion.SuscripcionAprobada,
                        $"Tu cambio de suscripción ha sido aprobado. Ahora tienes el plan {(await _planRepositorio.ObtenerPorIdAsync(solicitud.NuevoPlanId))!.Nombre}",
                        new { BarberoId = barbero.Id });
                }
                else if (solicitud.UsuarioBarberiaId.HasValue)
                {
                    // Nueva suscripción para barbería
                    var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(solicitud.UsuarioBarberiaId.Value)
                        ?? throw new Exception("Barbería no encontrada");

                    var plan = await _planRepositorio.ObtenerPorIdAsync(solicitud.NuevoPlanId)
                        ?? throw new Exception("Plan no encontrado");

                    var suscripcion = new SuscripcionUsuario
                    {
                        UsuarioBarberiaId = barberia.Id,
                        PlanId = plan.Id,
                        FechaInicio = DateTime.UtcNow,
                        FechaVencimiento = DateTime.UtcNow.AddDays(plan.DuracionDias),
                        Estado = EstadoSuscripcion.Activa
                    };

                    await _suscripcionRepositorio.CrearAsync(suscripcion);
                    barberia.SuscripcionActualId = suscripcion.Id;
                    await _barberiaRepositorio.ActualizarAsync(barberia);

                    // Notificar a la barbería
                    await _notificacionServicio.CrearNotificacionAsync(
                        barberia.UsuarioId,
                        TipoNotificacion.SuscripcionAprobada,
                        $"Tu suscripción al plan {plan.Nombre} ha sido aprobada",
                        new { BarberiaId = barberia.Id });
                }

                await _unitOfWork.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> RechazarSolicitudSuscripcionAsync(int solicitudId, int usuarioAprobadorId, string motivo)
        {
            var solicitud = await _solicitudRepositorio.ObtenerPorIdAsync(solicitudId)
                ?? throw new Exception("Solicitud no encontrada");

            if (solicitud.Estado != EstadoSolicitud.Pendiente)
                throw new Exception("La solicitud ya fue procesada");

            solicitud.Estado = EstadoSolicitud.Rechazado;
            solicitud.FechaRespuesta = DateTime.UtcNow;
            solicitud.RespuestaMotivo = motivo;
            
            await _solicitudRepositorio.ActualizarAsync(solicitud);
            await _unitOfWork.SaveChangesAsync();

            // Notificar al solicitante
            if (solicitud.UsuarioBarberoId.HasValue)
            {
                var barbero = await _barberoRepositorio.ObtenerPorIdAsync(solicitud.UsuarioBarberoId.Value);
                if (barbero != null)
                {
                    await _notificacionServicio.CrearNotificacionAsync(
                        barbero.UsuarioId,
                        TipoNotificacion.SuscripcionRechazada,
                        $"Tu solicitud de cambio de suscripción ha sido rechazada: {motivo}",
                        new { SolicitudId = solicitud.Id });
                }
            }
            else if (solicitud.UsuarioBarberiaId.HasValue)
            {
                var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(solicitud.UsuarioBarberiaId.Value);
                if (barberia != null)
                {
                    await _notificacionServicio.CrearNotificacionAsync(
                        barberia.UsuarioId,
                        TipoNotificacion.SuscripcionRechazada,
                        $"Tu solicitud de suscripción ha sido rechazada: {motivo}",
                        new { SolicitudId = solicitud.Id });
                }
            }

            return true;
        }

        public async Task<IEnumerable<SolicitudSuscripcion>> ObtenerSolicitudesPendientesAsync()
        {
            var solicitudes = await _solicitudRepositorio.ObtenerTodosAsync();
            return solicitudes.Where(s => s.Estado == EstadoSolicitud.Pendiente);
        }

        public async Task<bool> TieneSuscripcionActivaBarberoAsync(int barberoId)
        {
            return await _suscripcionRepositorio.ExisteSuscripcionActivaAsync(barberoId, true);
        }

        public async Task<bool> TieneSuscripcionActivaBarberiaAsync(int barberiaId)
        {
            return await _suscripcionRepositorio.ExisteSuscripcionActivaAsync(barberiaId, false);
        }

        public async Task<bool> PuedeCambiarDePlanAsync(int entidadId, bool esBarbero)
        {
            // Implementar lógica de validación según reglas de negocio
            return true;
        }

        public async Task<int> VerificarSuscripcionesVencidasAsync()
        {
            var suscripcionesVencidas = await _suscripcionRepositorio.ObtenerSuscripcionesVencidasAsync();
            var contador = 0;

            foreach (var suscripcion in suscripcionesVencidas)
            {
                suscripcion.Estado = EstadoSuscripcion.Vencida;
                await _suscripcionRepositorio.ActualizarAsync(suscripcion);
                
                // Notificar al usuario
                if (suscripcion.UsuarioBarberoId.HasValue)
                {
                    var barbero = await _barberoRepositorio.ObtenerPorIdAsync(suscripcion.UsuarioBarberoId.Value);
                    if (barbero != null)
                    {
                        await _notificacionServicio.CrearNotificacionAsync(
                            barbero.UsuarioId,
                            TipoNotificacion.SuscripcionVencida,
                            $"Tu suscripción {suscripcion.Plan.Nombre} ha vencido",
                            new { SuscripcionId = suscripcion.Id });
                    }
                }
                else if (suscripcion.UsuarioBarberiaId.HasValue)
                {
                    var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(suscripcion.UsuarioBarberiaId.Value);
                    if (barberia != null)
                    {
                        await _notificacionServicio.CrearNotificacionAsync(
                            barberia.UsuarioId,
                            TipoNotificacion.SuscripcionVencida,
                            $"Tu suscripción {suscripcion.Plan.Nombre} ha vencido",
                            new { SuscripcionId = suscripcion.Id });
                    }
                }
                
                contador++;
            }

            await _unitOfWork.SaveChangesAsync();
            return contador;
        }

        public async Task<int> VerificarSuscripcionesPorVencerAsync(int dias = 7)
        {
            var suscripcionesPorVencer = await _suscripcionRepositorio.ObtenerSuscripcionesPorVencerAsync(dias);
            var contador = 0;

            foreach (var suscripcion in suscripcionesPorVencer)
            {
                // Notificar al usuario
                if (suscripcion.UsuarioBarberoId.HasValue)
                {
                    var barbero = await _barberoRepositorio.ObtenerPorIdAsync(suscripcion.UsuarioBarberoId.Value);
                    if (barbero != null)
                    {
                        await _notificacionServicio.CrearNotificacionAsync(
                            barbero.UsuarioId,
                            TipoNotificacion.SuscripcionPorVencer,
                            $"Tu suscripción {suscripcion.Plan.Nombre} vencerá en {dias} días",
                            new { SuscripcionId = suscripcion.Id, DiasRestantes = dias });
                    }
                }
                else if (suscripcion.UsuarioBarberiaId.HasValue)
                {
                    var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(suscripcion.UsuarioBarberiaId.Value);
                    if (barberia != null)
                    {
                        await _notificacionServicio.CrearNotificacionAsync(
                            barberia.UsuarioId,
                            TipoNotificacion.SuscripcionPorVencer,
                            $"Tu suscripción {suscripcion.Plan.Nombre} vencerá en {dias} días",
                            new { SuscripcionId = suscripcion.Id, DiasRestantes = dias });
                    }
                }
                
                contador++;
            }

            return contador;
        }

        private async Task<IEnumerable<Usuario>> ObtenerAdminsAsync()
        {
            // Implementar obtención de administradores
            return await Task.FromResult(Enumerable.Empty<Usuario>());
        }

        private async Task<IEnumerable<Usuario>> ObtenerComercialesAsync()
        {
            // Implementar obtención de comerciales
            return await Task.FromResult(Enumerable.Empty<Usuario>());
        }
    }
}
