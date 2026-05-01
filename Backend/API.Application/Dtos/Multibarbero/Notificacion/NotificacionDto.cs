using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Notificacion
{
    public class NotificacionDto : EntidadBaseDto
    {
        public Guid UsuarioDestinoId { get; set; }
        public TipoNotificacion Tipo { get; set; }
        public required string Titulo { get; set; }
        public required string Mensaje { get; set; }
        public bool Leida { get; set; }
        public DateTime? FechaLectura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid? EntidadRelacionadaId { get; set; }
        public string? TipoEntidad { get; set; }
        public bool AccionRequerida { get; set; }
        public string? UrlAccion { get; set; }
    }
}
