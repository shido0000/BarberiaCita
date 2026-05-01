using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.RolMultibarbero
{
    public class RolMultibarberoDto : EntidadBaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}
