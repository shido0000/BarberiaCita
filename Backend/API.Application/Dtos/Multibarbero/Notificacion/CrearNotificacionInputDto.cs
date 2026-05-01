using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Notificacion
{
    public class CrearNotificacionInputDto
    {
        public required Guid UsuarioDestinoId { get; set; }
        public required TipoNotificacion Tipo { get; set; }
        public required string Titulo { get; set; }
        public required string Mensaje { get; set; }
        public Guid? EntidadRelacionadaId { get; set; }
        public string? TipoEntidad { get; set; }
        public bool AccionRequerida { get; set; }
        public string? UrlAccion { get; set; }
    }
}
