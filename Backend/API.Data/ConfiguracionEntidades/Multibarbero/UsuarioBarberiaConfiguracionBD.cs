using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class UsuarioBarberiaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioBarberia>().ToTable("UsuariosBarberias");
            EntidadBaseConfiguracionBD<UsuarioBarberia>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.NombreComercial).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.Descripcion).HasMaxLength(2000);
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.Direccion).HasMaxLength(500);
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.Telefono).HasMaxLength(20);
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.CorreoContacto).HasMaxLength(100);
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.Logo).HasMaxLength(500);
            modelBuilder.Entity<UsuarioBarberia>().Property(e => e.ImagenPortada).HasMaxLength(500);

            // Relaciones
            modelBuilder.Entity<UsuarioBarberia>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioBarberia>()
                .HasOne(e => e.RolMultibarbero)
                .WithMany(e => e.UsuariosBarberias)
                .HasForeignKey(e => e.RolMultibarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioBarberia>()
                .HasMany(e => e.BarberosAfiliados)
                .WithOne(e => e.UsuarioBarberia)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioBarberia>()
                .HasMany(e => e.Servicios)
                .WithOne(e => e.UsuarioBarberia)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioBarberia>()
                .HasMany(e => e.Reservas)
                .WithOne(e => e.UsuarioBarberia)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
