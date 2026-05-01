using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.Notificacion
{
    public class ActualizarNotificacionInputDto : EntidadBaseDto
    {
        public bool? Leida { get; set; }
        public DateTime? FechaLectura { get; set; }
    }
}
