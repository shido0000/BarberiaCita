using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Reserva
{
    public class ActualizarReservaInputDto : EntidadBaseDto
    {
        public EstadoReserva? Estado { get; set; }
        public string? NotasInternas { get; set; }
        public bool? Pagado { get; set; }
        public string? MetodoPago { get; set; }
    }
}
