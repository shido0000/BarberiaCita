using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class UsuarioComercialConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioComercial>().ToTable("UsuariosComerciales");
            EntidadBaseConfiguracionBD<UsuarioComercial>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<UsuarioComercial>().Property(e => e.Telefono).HasMaxLength(20);
            modelBuilder.Entity<UsuarioComercial>().Property(e => e.Direccion).HasMaxLength(500);

            // Índices para búsqueda eficiente
            modelBuilder.Entity<UsuarioComercial>()
                .HasIndex(e => e.UsuarioId);
            
            modelBuilder.Entity<UsuarioComercial>()
                .HasIndex(e => e.Activo);

            // Relaciones
            modelBuilder.Entity<UsuarioComercial>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioComercial>()
                .HasOne(e => e.RolMultibarbero)
                .WithMany(e => e.UsuariosComerciales)
                .HasForeignKey(e => e.RolMultibarberoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioComercial>()
                .HasMany(e => e.SolicitudesEvaluadas)
                .WithOne(e => e.UsuarioComercial)
                .HasForeignKey(e => e.UsuarioComercialId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioComercial>()
                .HasMany(e => e.NotificacionesEnviadas)
                .WithOne(e => e.UsuarioEmisor)
                .HasForeignKey(e => e.UsuarioEmisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
