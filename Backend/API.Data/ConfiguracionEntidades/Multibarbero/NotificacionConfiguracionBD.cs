using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class NotificacionConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notificacion>().ToTable("Notificaciones");
            EntidadBaseConfiguracionBD<Notificacion>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Notificacion>().Property(e => e.Titulo).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Notificacion>().Property(e => e.Mensaje).HasMaxLength(1000).IsRequired();
            modelBuilder.Entity<Notificacion>().Property(e => e.DatosAdicionales).HasMaxLength(2000);
            modelBuilder.Entity<Notificacion>().Property(e => e.TipoEntidadRelacionada).HasMaxLength(50);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<Notificacion>()
                .HasIndex(e => e.UsuarioId);
            
            modelBuilder.Entity<Notificacion>()
                .HasIndex(e => e.Tipo);
            
            modelBuilder.Entity<Notificacion>()
                .HasIndex(e => e.Leida);
            
            modelBuilder.Entity<Notificacion>()
                .HasIndex(e => e.FechaEnvio);

            // Relaciones
            modelBuilder.Entity<Notificacion>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notificacion>()
                .HasOne(e => e.UsuarioEmisor)
                .WithMany()
                .HasForeignKey(e => e.UsuarioEmisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
