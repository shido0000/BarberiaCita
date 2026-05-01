using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class RolMultibarberoConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolMultibarbero>().ToTable("RolesMultibarbero");
            EntidadBaseConfiguracionBD<RolMultibarbero>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<RolMultibarbero>().Property(e => e.Nombre).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<RolMultibarbero>().Property(e => e.Descripcion).HasMaxLength(500).IsRequired();

            // Seed de roles multibarbero
            RolMultibarbero admin = new() 
            { 
                Id = new Guid("A0000000-0000-0000-0000-000000000001"), 
                Nombre = "Admin", 
                Descripcion = "Administrador del sistema con control total"
            };
            
            RolMultibarbero barbero = new() 
            { 
                Id = new Guid("A0000000-0000-0000-0000-000000000002"), 
                Nombre = "Barbero", 
                Descripcion = "Barbero independiente o afiliado a barbería"
            };
            
            RolMultibarbero barberia = new() 
            { 
                Id = new Guid("A0000000-0000-0000-0000-000000000003"), 
                Nombre = "Barberia", 
                Descripcion = "Establecimiento de barbería"
            };
            
            RolMultibarbero comercial = new() 
            { 
                Id = new Guid("A0000000-0000-0000-0000-000000000004"), 
                Nombre = "Comercial", 
                Descripcion = "Encargado de evaluar solicitudes de suscripción"
            };
            
            RolMultibarbero cliente = new() 
            { 
                Id = new Guid("A0000000-0000-0000-0000-000000000005"), 
                Nombre = "Cliente", 
                Descripcion = "Cliente que realiza reservas"
            };

            modelBuilder.Entity<RolMultibarbero>().HasData(admin, barbero, barberia, comercial, cliente);
        }
    }
}
