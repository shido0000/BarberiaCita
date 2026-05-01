using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Reserva
{
    public class ReservaDto : EntidadBaseDto
    {
        public Guid UsuarioClienteId { get; set; }
        public string? NombreCliente { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public string? NombreBarbero { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public string? NombreBarberia { get; set; }
        public Guid ServicioId { get; set; }
        public string? ServicioNombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoReserva Estado { get; set; }
        public string? NotasCliente { get; set; }
        public string? NotasInternas { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Pagado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
