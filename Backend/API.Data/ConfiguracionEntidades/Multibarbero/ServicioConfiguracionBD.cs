using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class ServicioConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().ToTable("Servicios");
            EntidadBaseConfiguracionBD<Servicio>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Servicio>().Property(e => e.Nombre).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Servicio>().Property(e => e.Descripcion).HasMaxLength(1000);
            modelBuilder.Entity<Servicio>().Property(e => e.Imagen).HasMaxLength(500);
            modelBuilder.Entity<Servicio>().Property(e => e.Categoria).HasMaxLength(100);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<Servicio>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<Servicio>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<Servicio>()
                .HasIndex(e => e.Activo);

            // Relaciones
            modelBuilder.Entity<Servicio>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.Servicios)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Servicio>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany(e => e.Servicios)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
