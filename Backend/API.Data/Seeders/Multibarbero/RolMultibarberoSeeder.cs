using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Seeders.Multibarbero
{
    /// <summary>
    /// Seeder para inicializar los roles del sistema Multibarbero
    /// </summary>
    public static class RolMultibarberoSeeder
    {
        public static async Task SeedAsync(DbContext context)
        {
            if (!await context.Set<RolMultibarbero>().AnyAsync())
            {
                var roles = new List<RolMultibarbero>
                {
                    new RolMultibarbero
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Admin",
                        Descripcion = "Administrador del sistema con acceso completo a todas las funcionalidades",
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new RolMultibarbero
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbero",
                        Descripcion = "Barbero independiente que ofrece sus servicios en la plataforma",
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new RolMultibarbero
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barberia",
                        Descripcion = "Establecimiento de barbería que puede tener múltiples barberos afiliados",
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new RolMultibarbero
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Comercial",
                        Descripcion = "Usuario comercial que gestiona promociones y ventas",
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new RolMultibarbero
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Cliente",
                        Descripcion = "Cliente que reserva servicios de barberos y barberías",
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    }
                };

                await context.Set<RolMultibarbero>().AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }
        }
    }
}
