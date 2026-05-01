using API.Application.Dtos.Comunes;
using API.Data.Enum.Multibarbero;

namespace API.Application.Dtos.Multibarbero.Notificacion
{
    public class FiltrarConfigurarListadoPaginadoNotificacionInputDto : ConfiguracionListadoPaginadoDto
    {
        public Guid? UsuarioDestinoId { get; set; }
        public TipoNotificacion? Tipo { get; set; }
        public bool? Leida { get; set; }
        public bool? AccionRequerida { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
