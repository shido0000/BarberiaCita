using API.Data.ConfiguracionEntidades.Nomencladores;
using API.Data.ConfiguracionEntidades.Seguridad;
using API.Data.Entidades.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.DbContexts
{
    public class ApiDbContext : DbContext, IApiDbContext
    {
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermiso { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Traza> Trazas { get; set; }


        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Origen> Origenes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Familia> Familias { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RolPermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            RolConfiguracionBD.SetEntityBuilder(modelBuilder);
            PermisoConfiguracionBD.SetEntityBuilder(modelBuilder);
            UsuarioConfiguracionBD.SetEntityBuilder(modelBuilder);
            TrazaConfiguracionBD.SetEntityBuilder(modelBuilder);


            CategoriaConfiguracionBD.SetEntityBuilder(modelBuilder);
            OrigenConfiguracionBD.SetEntityBuilder(modelBuilder);
            GrupoConfiguracionBD.SetEntityBuilder(modelBuilder);
            FamiliaConfiguracionBD.SetEntityBuilder(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
