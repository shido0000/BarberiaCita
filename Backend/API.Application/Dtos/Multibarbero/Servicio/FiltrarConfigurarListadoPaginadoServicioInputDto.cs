using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.Servicio
{
    public class FiltrarConfigurarListadoPaginadoServicioInputDto : ConfiguracionListadoPaginadoDto
    {
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public bool? Activo { get; set; }
        public string? Categoria { get; set; }
        public decimal? PrecioMinimo { get; set; }
        public decimal? PrecioMaximo { get; set; }
    }
}
