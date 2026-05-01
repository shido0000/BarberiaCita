using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class ProductoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Productos");
            EntidadBaseConfiguracionBD<Producto>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Producto>().Property(e => e.Nombre).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Producto>().Property(e => e.Descripcion).HasMaxLength(1000);
            modelBuilder.Entity<Producto>().Property(e => e.Imagenes).HasMaxLength(2000);
            modelBuilder.Entity<Producto>().Property(e => e.Categoria).HasMaxLength(100);
            modelBuilder.Entity<Producto>().Property(e => e.Marca).HasMaxLength(100);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<Producto>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<Producto>()
                .HasIndex(e => e.Activo);
            
            modelBuilder.Entity<Producto>()
                .HasIndex(e => e.FechaPublicacion);

            // Relaciones
            modelBuilder.Entity<Producto>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.Productos)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
