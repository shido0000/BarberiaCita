namespace API.Application.Dtos.Multibarbero.RolMultibarbero
{
    public class CrearRolMultibarberoInputDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}
