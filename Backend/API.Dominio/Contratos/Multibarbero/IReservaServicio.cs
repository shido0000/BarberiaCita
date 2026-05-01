using API.Dominio.Entidades.Multibarbero;

namespace API.Dominio.Contratos.Multibarbero
{
    public interface IReservaServicio
    {
        // Cliente: Crear reserva
        Task<Reserva> CrearReservaAsync(CrearReservaDto dto, int clienteId);
        
        // Cliente: Cancelar reserva
        Task<bool> CancelarReservaClienteAsync(int reservaId, int clienteId);
        
        // Barbero/Barbería: Confirmar reserva
        Task<bool> ConfirmarReservaAsync(int reservaId, int usuarioId);
        
        // Barbero/Barbería: Rechazar reserva
        Task<bool> RechazarReservaAsync(int reservaId, int usuarioId, string motivo);
        
        // Obtener reservas
        Task<IEnumerable<Reserva>> ObtenerReservasPorClienteAsync(int clienteId);
        Task<IEnumerable<Reserva>> ObtenerReservasPorBarberoAsync(int barberoId);
        Task<IEnumerable<Reserva>> ObtenerReservasPorBarberiaAsync(int barberiaId);
        Task<Reserva?> ObtenerReservaPorIdAsync(int reservaId);
        
        // Validaciones críticas
        Task<bool> ExisteSolapamientoAsync(int barberoId, DateTime fechaInicio, DateTime fechaFin, int? reservaIdExcluida = null);
        Task<bool> PuedeReservarAsync(int clienteId, int barberoId, DateTime fechaInicio, DateTime fechaFin);
    }

    public class CrearReservaDto
    {
        public int? BarberoId { get; set; }
        public int? BarberiaId { get; set; }
        public int ServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Notas { get; set; }
    }
}
