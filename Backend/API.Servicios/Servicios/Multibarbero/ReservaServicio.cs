using API.Data.Repositorios.Multibarbero;
using API.Dominio.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Reserva;
using API.Application.Dtos.Comunes;

namespace API.Servicios.Servicios.Multibarbero
{
    public class ReservaServicio : IReservaService, IReservaServicio
    {
        private readonly IRepositorioBase<Reserva> _reservaRepositorio;
        private readonly IUsuarioBarberoRepositorio _barberoRepositorio;
        private readonly IUsuarioBarberiaRepositorio _barberiaRepositorio;
        private readonly IUsuarioClienteRepositorio _clienteRepositorio;
        private readonly IRepositorioBase<Servicio> _servicioRepositorio;
        private readonly IAfiliacionBarberoRepositorio _afiliacionRepositorio;
        private readonly INotificacionServicio _notificacionServicio;
        private readonly IUnitOfWork _unitOfWork;

        public ReservaServicio(
            IRepositorioBase<Reserva> reservaRepositorio,
            IUsuarioBarberoRepositorio barberoRepositorio,
            IUsuarioBarberiaRepositorio barberiaRepositorio,
            IUsuarioClienteRepositorio clienteRepositorio,
            IRepositorioBase<Servicio> servicioRepositorio,
            IAfiliacionBarberoRepositorio afiliacionRepositorio,
            INotificacionServicio notificacionServicio,
            IUnitOfWork unitOfWork)
        {
            _reservaRepositorio = reservaRepositorio;
            _barberoRepositorio = barberoRepositorio;
            _barberiaRepositorio = barberiaRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _servicioRepositorio = servicioRepositorio;
            _afiliacionRepositorio = afiliacionRepositorio;
            _notificacionServicio = notificacionServicio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Reserva> CrearReservaAsync(CrearReservaDto dto, int clienteId)
        {
            // Validar que el cliente existe
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(clienteId)
                ?? throw new Exception("Cliente no encontrado");

            // Validar que el servicio existe
            var servicio = await _servicioRepositorio.ObtenerPorIdAsync(dto.ServicioId)
                ?? throw new Exception("Servicio no encontrado");

            UsuarioBarbero? barbero = null;
            UsuarioBarberia? barberia = null;

            // Determinar si es reserva para barbero o barbería
            if (dto.BarberoId.HasValue)
            {
                barbero = await _barberoRepositorio.ObtenerPorIdAsync(dto.BarberoId.Value);
                if (barbero == null)
                    throw new Exception("Barbero no encontrado");

                // Validar que el barbero puede recibir reservas
                if (!await PuedeRecibirReservasBarberoAsync(dto.BarberoId.Value))
                    throw new Exception("El barbero no puede recibir reservas con su plan actual");

                // Si el barbero está afiliado a una barbería, la reserva va a la barbería
                if (barbero.BarberiaId.HasValue && barbero.EstadoAfiliacion == EstadoAfiliacion.Aceptado)
                {
                    barberia = await _barberiaRepositorio.ObtenerPorIdAsync(barbero.BarberiaId.Value);
                    if (barberia == null)
                        throw new Exception("Barbería no encontrada");
                }
            }
            else if (dto.BarberiaId.HasValue)
            {
                barberia = await _barberiaRepositorio.ObtenerPorIdAsync(dto.BarberiaId.Value);
                if (barberia == null)
                    throw new Exception("Barbería no encontrada");
            }
            else
            {
                throw new Exception("Debe especificar un barbero o una barbería");
            }

            // VALIDACIÓN CRÍTICA: No solapamiento de fechas
            if (barbero != null)
            {
                var existeSolapamiento = await ExisteSolapamientoAsync(
                    barbero.Id, 
                    dto.FechaInicio, 
                    dto.FechaFin);

                if (existeSolapamiento)
                    throw new Exception("Ya existe una reserva en ese horario. Por favor seleccione otro horario.");
            }

            // Validar que las fechas son correctas
            if (dto.FechaInicio >= dto.FechaFin)
                throw new Exception("La fecha de inicio debe ser anterior a la fecha de fin");

            if (dto.FechaInicio < DateTime.UtcNow)
                throw new Exception("No se pueden crear reservas en el pasado");

            var reserva = new Reserva
            {
                ClienteId = clienteId,
                BarberoId = barbero?.Id,
                BarberiaId = barberia?.Id,
                ServicioId = dto.ServicioId,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Notas = dto.Notas,
                Estado = EstadoReserva.Pendiente,
                FechaReserva = DateTime.UtcNow
            };

            await _reservaRepositorio.CrearAsync(reserva);
            await _unitOfWork.SaveChangesAsync();

            // Notificar al barbero y/o barbería
            if (barbero != null)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    barbero.UsuarioId,
                    TipoNotificacion.NuevaReserva,
                    $"Nueva reserva de {cliente.Usuario.Nombre} para el {dto.FechaInicio:dd/MM/yyyy HH:mm}",
                    new { ReservaId = reserva.Id, ClienteId = clienteId });
            }

            if (barberia != null)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    barberia.UsuarioId,
                    TipoNotificacion.NuevaReserva,
                    $"Nueva reserva de {cliente.Usuario.Nombre} para el {dto.FechaInicio:dd/MM/yyyy HH:mm}",
                    new { ReservaId = reserva.Id, ClienteId = clienteId });
            }

            return reserva;
        }

        public async Task<bool> CancelarReservaClienteAsync(int reservaId, int clienteId)
        {
            var reserva = await _reservaRepositorio.ObtenerPorIdAsync(reservaId)
                ?? throw new Exception("Reserva no encontrada");

            if (reserva.ClienteId != clienteId)
                throw new Exception("No tiene permiso para cancelar esta reserva");

            if (reserva.Estado == EstadoReserva.Cancelada)
                throw new Exception("La reserva ya está cancelada");

            if (reserva.Estado == EstadoReserva.Completada)
                throw new Exception("No se puede cancelar una reserva completada");

            reserva.Estado = EstadoReserva.Cancelada;
            reserva.FechaActualizacion = DateTime.UtcNow;
            
            await _reservaRepositorio.ActualizarAsync(reserva);
            await _unitOfWork.SaveChangesAsync();

            // Notificar al barbero/barbería
            if (reserva.BarberoId.HasValue)
            {
                var barbero = await _barberoRepositorio.ObtenerPorIdAsync(reserva.BarberoId.Value);
                if (barbero != null)
                {
                    await _notificacionServicio.CrearNotificacionAsync(
                        barbero.UsuarioId,
                        TipoNotificacion.ReservaCancelada,
                        "El cliente ha cancelado la reserva",
                        new { ReservaId = reservaId });
                }
            }

            if (reserva.BarberiaId.HasValue)
            {
                var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(reserva.BarberiaId.Value);
                if (barberia != null)
                {
                    await _notificacionServicio.CrearNotificacionAsync(
                        barberia.UsuarioId,
                        TipoNotificacion.ReservaCancelada,
                        "El cliente ha cancelado la reserva",
                        new { ReservaId = reservaId });
                }
            }

            return true;
        }

        public async Task<bool> ConfirmarReservaAsync(int reservaId, int usuarioId)
        {
            var reserva = await _reservaRepositorio.ObtenerPorIdAsync(reservaId)
                ?? throw new Exception("Reserva no encontrada");

            if (reserva.Estado != EstadoReserva.Pendiente)
                throw new Exception("La reserva ya ha sido procesada");

            // Verificar que el usuario es el barbero o pertenece a la barbería
            bool puedeConfirmar = false;

            if (reserva.BarberoId.HasValue)
            {
                var barbero = await _barberoRepositorio.ObtenerPorIdAsync(reserva.BarberoId.Value);
                if (barbero != null && barbero.UsuarioId == usuarioId)
                    puedeConfirmar = true;
            }

            if (reserva.BarberiaId.HasValue && !puedeConfirmar)
            {
                var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(reserva.BarberiaId.Value);
                if (barberia != null && barberia.UsuarioId == usuarioId)
                    puedeConfirmar = true;
            }

            if (!puedeConfirmar)
                throw new Exception("No tiene permiso para confirmar esta reserva");

            // VALIDACIÓN CRÍTICA: Verificar nuevamente solapamiento antes de confirmar
            if (reserva.BarberoId.HasValue)
            {
                var existeSolapamiento = await ExisteSolapamientoAsync(
                    reserva.BarberoId.Value,
                    reserva.FechaInicio,
                    reserva.FechaFin,
                    reserva.Id);

                if (existeSolapamiento)
                    throw new Exception("Existe un conflicto de horario. No se puede confirmar la reserva.");
            }

            reserva.Estado = EstadoReserva.Confirmada;
            reserva.FechaActualizacion = DateTime.UtcNow;
            
            await _reservaRepositorio.ActualizarAsync(reserva);
            await _unitOfWork.SaveChangesAsync();

            // Notificar al cliente
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(reserva.ClienteId);
            if (cliente != null)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    cliente.UsuarioId,
                    TipoNotificacion.ReservaConfirmada,
                    "Tu reserva ha sido confirmada",
                    new { ReservaId = reservaId });
            }

            return true;
        }

        public async Task<bool> RechazarReservaAsync(int reservaId, int usuarioId, string motivo)
        {
            var reserva = await _reservaRepositorio.ObtenerPorIdAsync(reservaId)
                ?? throw new Exception("Reserva no encontrada");

            if (reserva.Estado != EstadoReserva.Pendiente)
                throw new Exception("La reserva ya ha sido procesada");

            // Verificar que el usuario es el barbero o pertenece a la barbería
            bool puedeRechazar = false;

            if (reserva.BarberoId.HasValue)
            {
                var barbero = await _barberoRepositorio.ObtenerPorIdAsync(reserva.BarberoId.Value);
                if (barbero != null && barbero.UsuarioId == usuarioId)
                    puedeRechazar = true;
            }

            if (reserva.BarberiaId.HasValue && !puedeRechazar)
            {
                var barberia = await _barberiaRepositorio.ObtenerPorIdAsync(reserva.BarberiaId.Value);
                if (barberia != null && barberia.UsuarioId == usuarioId)
                    puedeRechazar = true;
            }

            if (!puedeRechazar)
                throw new Exception("No tiene permiso para rechazar esta reserva");

            reserva.Estado = EstadoReserva.Rechazada;
            reserva.MotivoRechazo = motivo;
            reserva.FechaActualizacion = DateTime.UtcNow;
            
            await _reservaRepositorio.ActualizarAsync(reserva);
            await _unitOfWork.SaveChangesAsync();

            // Notificar al cliente
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(reserva.ClienteId);
            if (cliente != null)
            {
                await _notificacionServicio.CrearNotificacionAsync(
                    cliente.UsuarioId,
                    TipoNotificacion.ReservaRechazada,
                    $"Tu reserva ha sido rechazada: {motivo}",
                    new { ReservaId = reservaId });
            }

            return true;
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasPorClienteAsync(int clienteId)
        {
            var reservas = await _reservaRepositorio.ObtenerTodosAsync();
            return reservas.Where(r => r.ClienteId == clienteId)
                          .OrderByDescending(r => r.FechaReserva);
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasPorBarberoAsync(int barberoId)
        {
            var reservas = await _reservaRepositorio.ObtenerTodosAsync();
            return reservas.Where(r => r.BarberoId == barberoId)
                          .OrderByDescending(r => r.FechaInicio);
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservasPorBarberiaAsync(int barberiaId)
        {
            var reservas = await _reservaRepositorio.ObtenerTodosAsync();
            return reservas.Where(r => r.BarberiaId == barberiaId)
                          .OrderByDescending(r => r.FechaInicio);
        }

        public async Task<Reserva?> ObtenerReservaPorIdAsync(int reservaId)
        {
            return await _reservaRepositorio.ObtenerPorIdAsync(reservaId);
        }

        public async Task<bool> ExisteSolapamientoAsync(int barberoId, DateTime fechaInicio, DateTime fechaFin, int? reservaIdExcluida = null)
        {
            var reservas = await _reservaRepositorio.ObtenerTodosAsync();
            
            var existeSolapamiento = reservas.Any(r => 
                r.BarberoId == barberoId &&
                r.Estado != EstadoReserva.Cancelada &&
                r.Estado != EstadoReserva.Rechazada &&
                r.Id != reservaIdExcluida &&
                ((r.FechaInicio <= fechaInicio && r.FechaFin > fechaInicio) ||
                 (r.FechaInicio < fechaFin && r.FechaFin >= fechaFin) ||
                 (r.FechaInicio >= fechaInicio && r.FechaFin <= fechaFin)));

            return existeSolapamiento;
        }

        public async Task<bool> PuedeReservarAsync(int clienteId, int barberoId, DateTime fechaInicio, DateTime fechaFin)
        {
            // Validar que el cliente existe
            var cliente = await _clienteRepositorio.ObtenerPorIdAsync(clienteId);
            if (cliente == null)
                return false;

            // Validar que el barbero existe y puede recibir reservas
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId);
            if (barbero == null)
                return false;

            if (!await PuedeRecibirReservasBarberoAsync(barberoId))
                return false;

            // Validar que no hay solapamiento
            var existeSolapamiento = await ExisteSolapamientoAsync(barberoId, fechaInicio, fechaFin);
            if (existeSolapamiento)
                return false;

            return true;
        }

        private async Task<bool> PuedeRecibirReservasBarberoAsync(int barberoId)
        {
            var barbero = await _barberoRepositorio.ObtenerPorIdAsync(barberoId);
            if (barbero == null || barbero.SuscripcionActual == null)
                return false;

            var plan = barbero.SuscripcionActual.Plan;
            return plan.TipoPlan >= TipoPlan.Popular &&
                   barbero.SuscripcionActual.Estado == EstadoSuscripcion.Activa &&
                   barbero.SuscripcionActual.FechaVencimiento > DateTime.UtcNow;
        }
    }
}
