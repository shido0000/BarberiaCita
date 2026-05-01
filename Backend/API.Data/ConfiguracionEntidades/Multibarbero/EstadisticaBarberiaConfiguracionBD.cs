using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class EstadisticaBarberiaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadisticaBarberia>().ToTable("EstadisticasBarberias");
            EntidadBaseConfiguracionBD<EstadisticaBarberia>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<EstadisticaBarberia>().Property(e => e.ServicioMasSolicitadoNombre).HasMaxLength(200);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<EstadisticaBarberia>()
                .HasIndex(e => e.UsuarioBarberiaId);
            
            modelBuilder.Entity<EstadisticaBarberia>()
                .HasIndex(e => new { e.UsuarioBarberiaId, e.FechaInicio, e.FechaFin });
            
            modelBuilder.Entity<EstadisticaBarberia>()
                .HasIndex(e => e.FechaGeneracion);

            // Relaciones
            modelBuilder.Entity<EstadisticaBarberia>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany(e => e.Estadisticas)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
