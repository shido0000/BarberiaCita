using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Multibarbero.RolMultibarbero
{
    public class FiltrarConfigurarListadoPaginadoRolMultibarberoInputDto : FiltrarConfigurarListadoPaginadoInputDto
    {
        public string? Nombre { get; set; }
        public bool? Activo { get; set; }
    }
}
