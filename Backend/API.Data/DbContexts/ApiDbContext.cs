using API.Data.ConfiguracionEntidades.Nomencladores;
using API.Data.ConfiguracionEntidades.Seguridad;
using API.Data.ConfiguracionEntidades.Multibarbero;
using API.Data.Entidades.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DbContexts
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        #region Seguridad
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermiso { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Traza> Trazas { get; set; }
        #endregion

        #region Nomencladores
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Origen> Origenes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        #endregion

        #region Multibarbero
        public DbSet<RolMultibarbero> RolesMultibarbero { get; set; }
        public DbSet<UsuarioBarbero> UsuariosBarberos { get; set; }
        public DbSet<UsuarioBarberia> UsuariosBarberias { get; set; }
        public DbSet<UsuarioComercial> UsuariosComerciales { get; set; }
        public DbSet<UsuarioCliente> UsuariosClientes { get; set; }
        public DbSet<PlanSuscripcion> PlanesSuscripcion { get; set; }
        public DbSet<SuscripcionUsuario> SuscripcionesUsuarios { get; set; }
        public DbSet<SolicitudSuscripcion> SolicitudesSuscripciones { get; set; }
        public DbSet<AfiliacionBarbero> AfiliacionesBarberos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<EstadisticaBarbero> EstadisticasBarberos { get; set; }
        public DbSet<EstadisticaBarberia> EstadisticasBarberias { get; set; }
        public DbSet<FavoritoBarbero> FavoritosBarberos { get; set; }
        public DbSet<FavoritoBarberia> FavoritosBarberias { get; set; }
        #endregion

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seguridad
            RolPermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            RolConfiguracionBD.SetEntityBuilder(modelBuilder);
            PermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioConfiguracionBD.SetEntityBuilder(modelBuilder);
            TrazaConfiguracionBD.SetEntityBuilder(modelBuilder);

            // Nomencladores
            CategoriaConfiguracionBD.SetEntityBuilder(modelBuilder);
            OrigenConfiguracionBD.SetEntityBuilder(modelBuilder);
            GrupoConfiguracionBD.SetEntityBuilder(modelBuilder);
            FamiliaConfiguracionBD.SetEntityBuilder(modelBuilder);

            // Multibarbero
            RolMultibarberoConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioBarberoConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioBarberiaConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioComercialConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioClienteConfiguracionBD.SetEntityBuilder(modelBuilder);
            PlanSuscripcionConfiguracionBD.SetEntityBuilder(modelBuilder);
            SuscripcionUsuarioConfiguracionBD.SetEntityBuilder(modelBuilder);
            SolicitudSuscripcionConfiguracionBD.SetEntityBuilder(modelBuilder);
            AfiliacionBarberoConfiguracionBD.SetEntityBuilder(modelBuilder);
            ServicioConfiguracionBD.SetEntityBuilder(modelBuilder);
            ProductoConfiguracionBD.SetEntityBuilder(modelBuilder);
            ReservaConfiguracionBD.SetEntityBuilder(modelBuilder);
            NotificacionConfiguracionBD.SetEntityBuilder(modelBuilder);
            EstadisticaBarberoConfiguracionBD.SetEntityBuilder(modelBuilder);
            EstadisticaBarberiaConfiguracionBD.SetEntityBuilder(modelBuilder);
            FavoritoBarberoConfiguracionBD.SetEntityBuilder(modelBuilder);
            FavoritoBarberiaConfiguracionBD.SetEntityBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
