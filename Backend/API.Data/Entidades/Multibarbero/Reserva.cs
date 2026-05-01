using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las reservas de clientes con barberos o barberías
    /// </summary>
    public class Reserva : EntidadBase
    {
        // Cliente que realiza la reserva
        public required Guid UsuarioClienteId { get; set; }
        public UsuarioCliente UsuarioCliente { get; set; } = null!;
        
        // Barbero o barbería con quien se reserva
        // Si es con un barbero afiliado, se usa BarberoAfiliadoId
        public Guid? UsuarioBarberoId { get; set; }
        public UsuarioBarbero? UsuarioBarbero { get; set; }
        
        public Guid? UsuarioBarberiaId { get; set; }
        public UsuarioBarberia? UsuarioBarberia { get; set; }
        
        // Si el barbero está afiliado a una barbería, esta reserva va a la barbería
        public Guid? BarberoAfiliadoId { get; set; }
        public AfiliacionBarbero? BarberoAfiliado { get; set; }
        
        // Servicio reservado
        public required Guid ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;
        
        // Fecha y hora de inicio de la reserva
        public DateTime FechaInicio { get; set; }
        
        // Fecha y hora de fin de la reserva (calculada según duración del servicio)
        public DateTime FechaFin { get; set; }
        
        // Estado de la reserva
        public Enum.Multibarbero.EstadoReserva Estado { get; set; } = Enum.Multibarbero.EstadoReserva.Pendiente;
        
        // Notas del cliente
        public string? NotasCliente { get; set; }
        
        // Notas internas (barbero/barbería)
        public string? NotasInternas { get; set; }
        
        // Fecha de confirmación/rechazo
        public DateTime? FechaRespuesta { get; set; }
        
        // Usuario que confirmó/rechazó (barbero o representante de barbería)
        public Guid? UsuarioRespondioId { get; set; }
        public Usuario? UsuarioRespondio { get; set; }
        
        // Precio total de la reserva
        public decimal PrecioTotal { get; set; }
        
        // Método de pago
        public string? MetodoPago { get; set; }
        
        // Estado del pago
        public bool Pagado { get; set; } = false;
    }
}
