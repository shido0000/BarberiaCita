using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class EstadisticaBarberoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadisticaBarbero>().ToTable("EstadisticasBarberos");
            EntidadBaseConfiguracionBD<EstadisticaBarbero>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<EstadisticaBarbero>().Property(e => e.ServicioMasSolicitadoNombre).HasMaxLength(200);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<EstadisticaBarbero>()
                .HasIndex(e => e.UsuarioBarberoId);
            
            modelBuilder.Entity<EstadisticaBarbero>()
                .HasIndex(e => new { e.UsuarioBarberoId, e.FechaInicio, e.FechaFin });
            
            modelBuilder.Entity<EstadisticaBarbero>()
                .HasIndex(e => e.FechaGeneracion);

            // Relaciones
            modelBuilder.Entity<EstadisticaBarbero>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.Estadisticas)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
