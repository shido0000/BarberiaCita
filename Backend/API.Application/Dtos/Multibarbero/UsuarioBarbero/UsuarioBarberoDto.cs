using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.UsuarioBarbero
{
    public class UsuarioBarberoDto : EntidadBaseDto
    {
        public Guid UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public bool Activo { get; set; } = true;
        public bool Verificado { get; set; } = false;
        public Guid? SuscripcionActualId { get; set; }
        public string? PlanSuscripcionNombre { get; set; }
        public DateTime? FechaVencimientoSuscripcion { get; set; }
    }
}
