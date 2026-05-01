using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Seeders.Multibarbero
{
    /// <summary>
    /// Seeder para inicializar los planes de suscripción del sistema Multibarbero
    /// </summary>
    public static class PlanSuscripcionSeeder
    {
        public static async Task SeedAsync(DbContext context)
        {
            if (!await context.Set<PlanSuscripcion>().AnyAsync())
            {
                var planes = new List<PlanSuscripcion>
                {
                    // Planes para Barberos
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbero Free",
                        Descripcion = "Plan gratuito para barberos que comienzan en la plataforma",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Free,
                        EsParaBarberia = false,
                        Precio = 0,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = null,
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = false,
                        PermitePostearProductos = false,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbero Popular",
                        Descripcion = "Plan popular para barberos con mayor visibilidad",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Popular,
                        EsParaBarberia = false,
                        Precio = 15.00m,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = null,
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = true,
                        PermitePostearProductos = true,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbero Premium",
                        Descripcion = "Plan premium con todas las funcionalidades para barberos",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Premium,
                        EsParaBarberia = false,
                        Precio = 30.00m,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = null,
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = true,
                        PermitePostearProductos = true,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    
                    // Planes para Barberías
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbería Básico",
                        Descripcion = "Plan básico para barberías pequeñas",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Basico,
                        EsParaBarberia = true,
                        Precio = 25.00m,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = 3,
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = false,
                        PermitePostearProductos = false,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbería Estándar",
                        Descripcion = "Plan estándar para barberías en crecimiento",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Estandar,
                        EsParaBarberia = true,
                        Precio = 50.00m,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = 10,
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = true,
                        PermitePostearProductos = true,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    },
                    new PlanSuscripcion
                    {
                        Id = Guid.NewGuid(),
                        Nombre = "Barbería Enterprise",
                        Descripcion = "Plan enterprise para grandes cadenas de barberías",
                        TipoPlan = Data.Enum.Multibarbero.TipoPlan.Enterprise,
                        EsParaBarberia = true,
                        Precio = 100.00m,
                        DuracionDias = 30,
                        LimiteBarberosAfiliados = null, // Sin límite
                        PermiteRecibirReservas = true,
                        PermiteEstadisticasBasicas = true,
                        PermiteEstadisticasCompletas = true,
                        PermitePostearProductos = true,
                        PermiteModificarDatos = true,
                        PermiteMostrarServicios = true,
                        Activo = true,
                        FechaCreacion = DateTime.UtcNow
                    }
                };

                await context.Set<PlanSuscripcion>().AddRangeAsync(planes);
                await context.SaveChangesAsync();
            }
        }
    }
}
