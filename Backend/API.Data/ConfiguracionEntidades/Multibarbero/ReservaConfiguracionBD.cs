using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class ReservaConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>().ToTable("Reservas");
            EntidadBaseConfiguracionBD<Reserva>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<Reserva>().Property(e => e.NotasCliente).HasMaxLength(1000);
            modelBuilder.Entity<Reserva>().Property(e => e.NotasInternas).HasMaxLength(1000);
            modelBuilder.Entity<Reserva>().Property(e => e.MetodoPago).HasMaxLength(100);

            // Índices para validación de solapamiento
            modelBuilder.Entity<Reserva>()
                .HasIndex(e => new { e.UsuarioBarberoId, e.FechaInicio, e.FechaFin });
            
            modelBuilder.Entity<Reserva>()
                .HasIndex(e => new { e.UsuarioBarberiaId, e.FechaInicio, e.FechaFin });

            // Relaciones
            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.UsuarioCliente)
                .WithMany(e => e.Reservas)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.UsuarioBarbero)
                .WithMany(e => e.Reservas)
                .HasForeignKey(e => e.UsuarioBarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.UsuarioBarberia)
                .WithMany(e => e.Reservas)
                .HasForeignKey(e => e.UsuarioBarberiaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.Servicio)
                .WithMany()
                .HasForeignKey(e => e.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne(e => e.BarberoAfiliado)
                .WithMany()
                .HasForeignKey(e => e.BarberoAfiliadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
