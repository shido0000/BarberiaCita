using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class UsuarioBarberoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioBarbero>().ToTable("UsuariosBarberos");
            EntidadBaseConfiguracionBD<UsuarioBarbero>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<UsuarioBarbero>().Property(e => e.Biografia).HasMaxLength(2000);
            modelBuilder.Entity<UsuarioBarbero>().Property(e => e.Especialidades).HasMaxLength(500);
            modelBuilder.Entity<UsuarioBarbero>().Property(e => e.Direccion).HasMaxLength(500);
            modelBuilder.Entity<UsuarioBarbero>().Property(e => e.Telefono).HasMaxLength(20);
            modelBuilder.Entity<UsuarioBarbero>().Property(e => e.FotoPerfil).HasMaxLength(500);

            // Relaciones
            modelBuilder.Entity<UsuarioBarbero>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioBarbero>()
                .HasOne(e => e.RolMultibarbero)
                .WithMany(e => e.UsuariosBarberos)
                .HasForeignKey(e => e.RolMultibarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioBarbero>()
                .HasMany(e => e.Servicios)
                .WithOne(e => e.UsuarioBarbero)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioBarbero>()
                .HasMany(e => e.Productos)
                .WithOne(e => e.UsuarioBarbero)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioBarbero>()
                .HasMany(e => e.AfiliacionesBarberias)
                .WithOne(e => e.UsuarioBarbero)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioBarbero>()
                .HasMany(e => e.Reservas)
                .WithOne(e => e.UsuarioBarbero)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
