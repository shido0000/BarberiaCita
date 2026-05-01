using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class AfiliacionBarberoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AfiliacionBarbero>().ToTable("AfiliacionesBarberos");
            EntidadBaseConfiguracionBD<AfiliacionBarbero>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<AfiliacionBarbero>().Property(e => e.MensajeSolicitud).HasMaxLength(1000);
            modelBuilder.Entity<AfiliacionBarbero>().Property(e => e.MensajeRespuesta).HasMaxLength(1000);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<AfiliacionBarbero>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<AfiliacionBarbero>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<AfiliacionBarbero>()
                .HasIndex(e => e.Estado);
            
            modelBuilder.Entity<AfiliacionBarbero>()
                .HasIndex(e => e.FechaSolicitud);

            // Relaciones
            modelBuilder.Entity<AfiliacionBarbero>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.BarberiasAfiliadas)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AfiliacionBarbero>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany(e => e.BarberosAfiliados)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AfiliacionBarbero>()
                .HasOne(e => e.UsuarioRespondio)
                .WithMany()
                .HasForeignKey(e => e.UsuarioRespondioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
