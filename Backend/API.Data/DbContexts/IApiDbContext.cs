using API.Data.Entidades.Seguridad;
using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DbContexts
{
    public interface IApiDbContext
    {
        #region Entities Seguridad

        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Traza> Trazas { get; set; }

        #endregion

        #region Entities Multibarbero

        DbSet<RolMultibarbero> RolMultibarberos { get; set; }
        DbSet<PlanSuscripcion> PlanSuscripcions { get; set; }
        DbSet<UsuarioBarbero> UsuarioBarberos { get; set; }
        DbSet<UsuarioBarberia> UsuarioBarberias { get; set; }
        DbSet<UsuarioCliente> UsuarioClientes { get; set; }
        DbSet<UsuarioComercial> UsuarioComercials { get; set; }
        DbSet<Servicio> Servicios { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Reserva> Reservas { get; set; }
        DbSet<AfiliacionBarbero> AfiliacionBarberos { get; set; }
        DbSet<SolicitudSuscripcion> SolicitudSuscripcions { get; set; }
        DbSet<SuscripcionUsuario> SuscripcionUsuarios { get; set; }
        DbSet<Notificacion> Notificaciones { get; set; }
        DbSet<EstadisticaBarbero> EstadisticasBarberos { get; set; }
        DbSet<EstadisticaBarberia> EstadisticasBarberias { get; set; }
        DbSet<FavoritoBarbero> FavoritoBarberos { get; set; }
        DbSet<FavoritoBarberia> FavoritoBarberias { get; set; }

        #endregion
    }
}
