using API.Dominio.Entidades.Multibarbero;

namespace API.Dominio.Contratos.Multibarbero
{
    public interface IUsuarioBarberoServicio
    {
        Task<UsuarioBarbero> RegistrarBarberoAsync(int usuarioId);
        Task<UsuarioBarbero?> ObtenerBarberoPorUsuarioIdAsync(int usuarioId);
        Task<UsuarioBarbero> ActualizarPerfilBarberoAsync(int usuarioId, ActualizarPerfilBarberoDto dto);
        Task<bool> SolicitarAfiliacionBarberiaAsync(int barberoId, int barberiaId);
        Task<bool> CancelarSolicitudAfiliacionAsync(int barberoId, int barberiaId);
        Task<IEnumerable<UsuarioBarbero>> ObtenerBarberosAfiliadosAsync(int barberiaId);
        Task<bool> TieneSuscripcionActivaAsync(int barberoId);
        Task<bool> PuedeRecibirReservasAsync(int barberoId);
        Task<bool> PuedeVenderProductosAsync(int barberoId);
    }

    public class ActualizarPerfilBarberoDto
    {
        public string? Biografia { get; set; }
        public string? Especialidades { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? FotoPerfilUrl { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
}
