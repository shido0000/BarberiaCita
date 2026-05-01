using API.Data.Repositorios.Multibarbero;
using API.Dominio.Entidades.Multibarbero;
using API.Servicios.Servicios.Base;

namespace API.Servicios.Servicios.Multibarbero
{
    public class UsuarioBarberoServicio : IUsuarioBarberoServicio
    {
        private readonly IUsuarioBarberoRepositorio _barberoRepositorio;
        private readonly ISuscripcionUsuarioRepositorio _suscripcionRepositorio;
        private readonly IAfiliacionBarberoRepositorio _afiliacionRepositorio;
        private readonly INotificacionServicio _notificacionServicio;

        public UsuarioBarberoServicio(
            IUsuarioBarberoRepositorio barberoRepositorio,
            ISuscripcionUsuarioRepositorio suscripcionRepositorio,
            IAfiliacionBarberoRepositorio afiliacionRepositorio,
            INotificacionServicio notificacionServicio)
        {
            _barberoRepositorio = barberoRepositorio;
            _suscripcionRepositorio = suscripcionRepositorio;
            _afiliacionRepositorio = afiliacionRepositorio;
            _notificacionServicio = notificacionServicio;
        }

        public async Task<UsuarioBarbero> RegistrarBarberoAsync(int usuarioId)
        {
            if (await _barberoRepositorio.ExisteBarberoConUsuarioAsync(usuarioId))
                throw new Exception("Ya existe un barbero registrado con este usuario");

            var planFree = await ObtenerPlanFreeAsync();
            
            var barbero = new UsuarioBarbero
            {
                UsuarioId = usuarioId,
                FechaRegistro = DateTime.UtcNow,
                EstadoAfiliacion = EstadoAfiliacion.SinAsignar
            };

            await _barberoRepositorio.CrearAsync(barbero);

            // Crear suscripción Free por defecto
            var suscripcion = new SuscripcionUsuario
            {
                UsuarioBarberoId = barbero.Id,
                PlanId = planFree.Id,
                FechaInicio = DateTime.UtcNow,
                FechaVencimiento = DateTime.UtcNow.AddYears(1), // Free no vence realmente
                Estado = EstadoSuscripcion.Activa
            };

            await _suscripcionRepositorio.CrearAsync(suscripcion);
            barbero.SuscripcionActualId = suscripcion.Id;
            await _barberoRepositorio.ActualizarAsync(barbero);

            return barbero;
        }

        public async Task<UsuarioBarbero?> ObtenerBarberoPorUsuarioIdAsync(int usuarioId)
        {
            return await _barberoRepositorio.ObtenerPorUsuarioIdAsync(usuarioId);
        }

        public async Task<UsuarioBarbero> ActualizarPerfilBarberoAsync(int usuarioId, ActualizarPerfilBarberoDto dto)
        {
            var barbero = await ObtenerBarberoPorUsuarioIdAsync(usuarioId)
                ?? throw new Exception("Barbero no encontrado");

            if (!string.IsNullOrEmpty(dto.Biografia))
                barbero.Biografia = dto.Biografia;
            
            if (!string.IsNullOrEmpty(dto.Especialidades))
                barbero.Especialidades = dto.Especialidades;
            
            if (dto.AniosExperiencia.HasValue)
                barbero.AniosExperiencia = dto.AniosExperiencia.Value;
            
            if (!string.IsNullOrEmpty(dto.FotoPerfilUrl))
                barbero.FotoPerfilUrl = dto.FotoPerfilUrl;
            
            if (!string.IsNullOrEmpty(dto.Direccion))
                barbero.Direccion = dto.Direccion;
            
            if (!string.IsNullOrEmpty(dto.Telefono))
                barbero.Telefono = dto.Telefono;
            
            if (dto.Latitud.HasValue)
                barbero.Latitud = dto.Latitud.Value;
            
            if (dto.Longitud.HasValue)
                barbero.Longitud = dto.Longitud.Value;

            await _barberoRepositorio.ActualizarAsync(barbero);
            return barbero;
        }

        public async Task<bool> SolicitarAfiliacionBarberiaAsync(int barberoId, int barberiaId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId)
                ?? throw new Exception("Barbero no encontrado");

            var barberia = await ObtenerBarberiaPorIdAsync(barberiaId)
                ?? throw new Exception("Barbería no encontrada");

            // Verificar si ya existe una solicitud
            var solicitudExistente = await _afiliacionRepositorio.ExisteSolicitudPendienteAsync(barberoId, barberiaId);
            if (solicitudExistente)
                throw new Exception("Ya existe una solicitud de afiliación pendiente");

            var afiliacion = new AfiliacionBarbero
            {
                BarberoId = barberoId,
                BarberiaId = barberiaId,
                FechaSolicitud = DateTime.UtcNow,
                Estado = EstadoAfiliacion.Pendiente
            };

            await _afiliacionRepositorio.CrearAsync(afiliacion);

            // Notificar a la barbería
            await _notificacionServicio.CrearNotificacionAsync(
                barberia.UsuarioId,
                TipoNotificacion.SolicitudAfiliacion,
                $"El barbero {barbero.Usuario.Nombre} ha solicitado unirse a tu barbería",
                new { BarberoId = barberoId, BarberiaId = barberiaId });

            return true;
        }

        public async Task<bool> CancelarSolicitudAfiliacionAsync(int barberoId, int barberiaId)
        {
            var afiliacion = await _afiliacionRepositorio.ObtenerSolicitudAsync(barberoId, barberiaId)
                ?? throw new Exception("No existe solicitud de afiliación");

            if (afiliacion.Estado != EstadoAfiliacion.Pendiente)
                throw new Exception("La solicitud ya fue procesada");

            afiliacion.Estado = EstadoAfiliacion.Cancelado;
            afiliacion.FechaRespuesta = DateTime.UtcNow;
            
            await _afiliacionRepositorio.ActualizarAsync(afiliacion);

            // Notificar cancelación
            await _notificacionServicio.CrearNotificacionAsync(
                afiliacion.Barberia.UsuarioId,
                TipoNotificacion.AfiliacionCancelada,
                "El barbero ha cancelado su solicitud de afiliación",
                new { BarberoId = barberoId, BarberiaId = barberiaId });

            return true;
        }

        public async Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosAfiliadosAsync(int barberiaId)
        {
            return await _barberoRepositorio.ObtenerBarberosPorBarberiaAsync(barberiaId);
        }

        public async Task<bool> TieneSuscripcionActivaAsync(int barberoId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId)
                ?? throw new Exception("Barbero no encontrado");

            if (barbero.SuscripcionActual == null)
                return false;

            return barbero.SuscripcionActual.Estado == EstadoSuscripcion.Activa &&
                   barbero.SuscripcionActual.FechaVencimiento > DateTime.UtcNow;
        }

        public async Task<bool> PuedeRecibirReservasAsync(int barberoId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId)
                ?? throw new Exception("Barbero no encontrado");

            if (barbero.SuscripcionActual == null)
                return false;

            var plan = barbero.SuscripcionActual.Plan;
            return plan.TipoPlan >= TipoPlan.Popular && 
                   barbero.SuscripcionActual.Estado == EstadoSuscripcion.Activa &&
                   barbero.SuscripcionActual.FechaVencimiento > DateTime.UtcNow;
        }

        public async Task<bool> PuedeVenderProductosAsync(int barberoId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId)
                ?? throw new Exception("Barbero no encontrado");

            if (barbero.SuscripcionActual == null)
                return false;

            var plan = barbero.SuscripcionActual.Plan;
            return plan.TipoPlan == TipoPlan.Premium && 
                   barbero.SuscripcionActual.Estado == EstadoSuscripcion.Activa &&
                   barbero.SuscripcionActual.FechaVencimiento > DateTime.UtcNow;
        }

        private async Task<PlanSuscripcion> ObtenerPlanFreeAsync()
        {
            // Implementación para obtener el plan Free
            // Esto se resolverá cuando implementemos el repositorio de planes
            throw new NotImplementedException();
        }

        private async Task<UsuarioBarberia?> ObtenerBarberiaPorIdAsync(int barberiaId)
        {
            // Implementación pendiente
            throw new NotImplementedException();
        }
    }
}
