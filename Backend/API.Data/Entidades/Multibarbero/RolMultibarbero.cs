using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda los diferentes tipos de roles específicos del sistema multibarbero
    /// Extiende de Rol para integrar con el sistema de seguridad existente
    /// </summary>
    public class RolMultibarbero : EntidadBase
    {
        public required string Nombre { get; set; } // Admin, Barbero, Barberia, Comercial, Cliente
        public required string Descripcion { get; set; }
        public bool Activo { get; set; } = true;

        // Relación con Usuario (ya existe en Rol base)
        public List<UsuarioBarbero> UsuariosBarberos { get; set; } = new();
        public List<UsuarioBarberia> UsuariosBarberias { get; set; } = new();
        public List<UsuarioComercial> UsuariosComerciales { get; set; } = new();
        public List<UsuarioCliente> UsuariosClientes { get; set; } = new();
    }
}
