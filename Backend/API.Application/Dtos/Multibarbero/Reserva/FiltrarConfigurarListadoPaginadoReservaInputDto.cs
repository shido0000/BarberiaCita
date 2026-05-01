using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Reserva
{
    public class FiltrarConfigurarListadoPaginadoReservaInputDto : ConfiguracionListadoPaginadoDto
    {
        public Guid? UsuarioClienteId { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public EstadoReserva? Estado { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public bool? Pagado { get; set; }
    }
}
