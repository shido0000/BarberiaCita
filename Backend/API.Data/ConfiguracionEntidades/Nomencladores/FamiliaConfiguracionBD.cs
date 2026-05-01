using API.Data.Entidades.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Nomencladores
{
    public class FamiliaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>().ToTable("Familias");
            EntidadBaseConfiguracionBD<Familia>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Familia>().Property(e => e.Codigo).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Familia>().Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
         
            modelBuilder.Entity<Familia>().Property(e => e.Reservado).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity<Familia>().Property(e => e.Activo).IsRequired().HasDefaultValue(true);

            modelBuilder.Entity<Familia>().HasIndex(e => new { e.Codigo}).IsUnique();
          
            modelBuilder.Entity<Familia>().HasOne(e => e.Grupo).WithMany(e => e.Familias).HasForeignKey(e => e.GrupoId).OnDelete(DeleteBehavior.Restrict);
          
            #region Seed
          /*  Usuario usuario = new() { Id = new Guid("42717FB8-6E3F-4C94-B6B1-A88E8718D0A6"), Nombre = "Admin", Apellidos = "System", Username = "admin.system", Correo = "admin.system@api.cu", Contrasenna = "poner hash", RolId = new Guid("C0B7E3B3-A06E-4580-B985-BB2FC4336522") };
            modelBuilder.Entity<Usuario>().HasData(usuario);*/
            #endregion
        }
    }
}
