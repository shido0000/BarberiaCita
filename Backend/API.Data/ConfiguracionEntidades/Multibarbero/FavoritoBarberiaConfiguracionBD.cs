using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class FavoritoBarberiaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoritoBarberia>().ToTable("FavoritosBarberias");
            EntidadBaseConfiguracionBD<FavoritoBarberia>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<FavoritoBarberia>().Property(e => e.Notas).HasMaxLength(500);

            // Índice único para evitar duplicados
            modelBuilder.Entity<FavoritoBarberia>()
                .HasIndex(e => new { e.UsuarioClienteId, e.UsuarioBarberiaId })
                .IsUnique();

            // Índices para búsqueda eficiente
            modelBuilder.Entity<FavoritoBarberia>()
                .HasIndex(e => e.UsuarioClienteId);
            
            modelBuilder.Entity<FavoritoBarberia>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<FavoritoBarberia>()
                .HasIndex(e => e.FechaAgregado);

            // Relaciones
            modelBuilder.Entity<FavoritoBarberia>()
                .HasOne(e => e.UsuarioCliente)
                .WithMany(e => e.FavoritosBarberias)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoritoBarberia>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany()
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
