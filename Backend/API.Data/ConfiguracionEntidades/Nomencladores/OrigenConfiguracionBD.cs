using API.Data.Entidades.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Nomencladores
{
    public class OrigenConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Origen>().ToTable("Origenes");
            EntidadBaseConfiguracionBD<Origen>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Origen>().Property(e => e.Codigo).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<Origen>().Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Origen>().Property(e => e.Tipo).HasMaxLength(5).IsRequired();
            modelBuilder.Entity<Origen>().Property(e => e.Reservado).HasDefaultValue(false);
            modelBuilder.Entity<Origen>().Property(e => e.Activo).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity<Origen>().Property(e => e.CategoriaId).IsRequired();


            modelBuilder.Entity<Origen>().HasIndex(e => new { e.Codigo, e.CategoriaId}).IsUnique();

            modelBuilder.Entity<Origen>().HasOne(e => e.Categoria).WithMany(e => e.Origenes).HasForeignKey(e => e.CategoriaId).OnDelete(DeleteBehavior.Restrict);
            //   modelBuilder.Entity<Usuario>().HasOne(e => e.Rol).WithMany(e => e.Usuarios).HasForeignKey(e => e.RolId).OnDelete(DeleteBehavior.Restrict);

            #region Seed
            /*  Usuario usuario = new() { Id = new Guid("42717FB8-6E3F-4C94-B6B1-A88E8718D0A6"), Nombre = "Admin", Apellidos = "System", Username = "admin.system", Correo = "admin.system@api.cu", Contrasenna = "poner hash", RolId = new Guid("C0B7E3B3-A06E-4580-B985-BB2FC4336522") };
              modelBuilder.Entity<Usuario>().HasData(usuario);*/
            #endregion
        }
    }
}
