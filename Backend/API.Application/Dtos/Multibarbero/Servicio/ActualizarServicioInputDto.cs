using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.Servicio
{
    public class ActualizarServicioInputDto : EntidadBaseDto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? DuracionMinutos { get; set; }
        public bool? Activo { get; set; }
        public int? Orden { get; set; }
        public string? Imagen { get; set; }
        public string? Categoria { get; set; }
    }
}
