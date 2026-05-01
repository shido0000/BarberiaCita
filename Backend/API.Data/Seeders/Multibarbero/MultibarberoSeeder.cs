using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Seeders.Multibarbero
{
    /// <summary>
    /// Seeder principal para inicializar todos los datos del sistema Multibarbero
    /// </summary>
    public static class MultibarberoSeeder
    {
        public static async Task SeedAllAsync(DbContext context)
        {
            await RolMultibarberoSeeder.SeedAsync(context);
            await PlanSuscripcionSeeder.SeedAsync(context);
        }
    }
}
