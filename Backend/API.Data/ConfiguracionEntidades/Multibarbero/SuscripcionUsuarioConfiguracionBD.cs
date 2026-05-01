using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class SuscripcionUsuarioConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuscripcionUsuario>().ToTable("SuscripcionesUsuarios");
            EntidadBaseConfiguracionBD<SuscripcionUsuario>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<SuscripcionUsuario>().Property(e => e.MetodoPago).HasMaxLength(100);
            modelBuilder.Entity<SuscripcionUsuario>().Property(e => e.ReferenciaPago).HasMaxLength(200);
            modelBuilder.Entity<SuscripcionUsuario>().Property(e => e.Notas).HasMaxLength(1000);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasIndex(e => e.Estado);
            
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasIndex(e => new { e.UsuarioBarberoId, e.FechaFin });
            
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasIndex(e => new { e.UsuarioBarberiaId, e.FechaFin });

            // Relaciones
            modelBuilder.Entity<SuscripcionUsuario>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.HistorialSuscripciones)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuscripcionUsuario>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany(e => e.Suscripciones)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SuscripcionUsuario>()
                .HasOne(e => e.PlanSuscripcion)
                .WithMany(e => e.Suscripciones)
                .HasForeignKey(e => e.PlanSuscripcionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
