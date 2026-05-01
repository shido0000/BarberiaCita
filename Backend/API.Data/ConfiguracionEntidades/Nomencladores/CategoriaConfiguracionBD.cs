using API.Data.Entidades.Nomencladores;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Nomencladores
{
    public class CategoriaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            EntidadBaseConfiguracionBD<Categoria>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Categoria>().Property(e => e.Codigo).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<Categoria>().Property(e => e.Descripcion).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Categoria>().Property(e => e.TipoDeCodigo).HasMaxLength(5).IsRequired();
            modelBuilder.Entity<Categoria>().Property(e => e.Reservado).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity<Categoria>().Property(e => e.Activo).IsRequired().HasDefaultValue(true);

            modelBuilder.Entity<Categoria>().HasIndex(e => new { e.Codigo}).IsUnique();
          
     
        }
    }
}
