using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class FavoritoBarberoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoritoBarbero>().ToTable("FavoritosBarberos");
            EntidadBaseConfiguracionBD<FavoritoBarbero>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<FavoritoBarbero>().Property(e => e.Notas).HasMaxLength(500);

            // Índice único para evitar duplicados
            modelBuilder.Entity<FavoritoBarbero>()
                .HasIndex(e => new { e.UsuarioClienteId, e.UsuarioBarberoId })
                .IsUnique();

            // Índices para búsqueda eficiente
            modelBuilder.Entity<FavoritoBarbero>()
                .HasIndex(e => e.UsuarioClienteId);
            
            modelBuilder.Entity<FavoritoBarbero>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<FavoritoBarbero>()
                .HasIndex(e => e.FechaAgregado);

            // Relaciones
            modelBuilder.Entity<FavoritoBarbero>()
                .HasOne(e => e.UsuarioCliente)
                .WithMany(e => e.FavoritosBarberos)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoritoBarbero>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany()
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
