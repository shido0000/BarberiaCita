using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class SolicitudSuscripcionConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudSuscripcion>().ToTable("SolicitudesSuscripciones");
            EntidadBaseConfiguracionBD<SolicitudSuscripcion>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<SolicitudSuscripcion>().Property(e => e.MotivoRechazo).HasMaxLength(1000);
            modelBuilder.Entity<SolicitudSuscripcion>().Property(e => e.Comentarios).HasMaxLength(2000);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasIndex(e => e.Estado);
            
            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasIndex(e => e.FechaSolicitud);

            // Relaciones
            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany()
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany()
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.PlanSuscripcion)
                .WithMany()
                .HasForeignKey(e => e.PlanSuscripcionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.SuscripcionActual)
                .WithMany()
                .HasForeignKey(e => e.SuscripcionActualId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.UsuarioComercial)
                .WithMany(e => e.SolicitudesEvaluadas)
                .HasForeignKey(e => e.UsuarioComercialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SolicitudSuscripcion>()
                .HasOne(e => e.UsuarioAdmin)
                .WithMany()
                .HasForeignKey(e => e.UsuarioAdminId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
