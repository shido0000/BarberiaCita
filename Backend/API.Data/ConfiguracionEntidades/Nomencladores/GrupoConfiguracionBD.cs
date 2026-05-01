using API.Data.Entidades.Nomencladores;
using API.Data.Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Nomencladores
{
    public class GrupoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupo>().ToTable("Grupos");
            EntidadBaseConfiguracionBD<Grupo>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Grupo>().Property(e => e.Codigo).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Grupo>().Property(e => e.Descripcion).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Grupo>().Property(e => e.TipoDeGrupo).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<Grupo>().Property(e => e.Reservado).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Grupo>().Property(e => e.Activo).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity<Grupo>().Property(e => e.Desgaste).HasPrecision(5, 2);

            modelBuilder.Entity<Grupo>().HasIndex(e => new { e.Codigo}).IsUnique();

            modelBuilder.Entity<Grupo>().HasOne(e => e.Origen).WithMany(e => e.Grupos).HasForeignKey(e => e.OrigenId).OnDelete(DeleteBehavior.Restrict);
         
        }
    }
}
