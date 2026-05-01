namespace API.Application.Dtos.Multibarbero.UsuarioBarbero
{
    public class CrearUsuarioBarberoInputDto
    {
        public required Guid UsuarioId { get; set; }
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
}
