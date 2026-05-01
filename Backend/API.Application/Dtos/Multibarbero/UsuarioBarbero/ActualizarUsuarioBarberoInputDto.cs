using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.UsuarioBarbero
{
    public class ActualizarUsuarioBarberoInputDto : EntidadBaseDto
    {
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool? Activo { get; set; }
        public bool? Verificado { get; set; }
    }
}
