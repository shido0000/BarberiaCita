using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class UsuarioClienteConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioCliente>().ToTable("UsuariosClientes");
            EntidadBaseConfiguracionBD<UsuarioCliente>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<UsuarioCliente>().Property(e => e.Telefono).HasMaxLength(20);
            modelBuilder.Entity<UsuarioCliente>().Property(e => e.Genero).HasMaxLength(50);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<UsuarioCliente>()
                .HasIndex(e => e.UsuarioId);
            
            modelBuilder.Entity<UsuarioCliente>()
                .HasIndex(e => e.Activo);

            // Relaciones
            modelBuilder.Entity<UsuarioCliente>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioCliente>()
                .HasOne(e => e.RolMultibarbero)
                .WithMany(e => e.UsuariosClientes)
                .HasForeignKey(e => e.RolMultibarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioCliente>()
                .HasMany(e => e.Reservas)
                .WithOne(e => e.UsuarioCliente)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioCliente>()
                .HasMany(e => e.FavoritosBarberos)
                .WithOne(e => e.UsuarioCliente)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsuarioCliente>()
                .HasMany(e => e.FavoritosBarberias)
                .WithOne(e => e.UsuarioCliente)
                .HasForeignKey(e => e.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
