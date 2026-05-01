using API.Data.Entidades.Multibarbero;
using Microsoft.EntityFrameworkCore;

namespace API.Data.ConfiguracionEntidades.Multibarbero
{
    public class PlanSuscripcionConfiguracionBD
    {
        public static void SetEntityBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanSuscripcion>().ToTable("PlanesSuscripcion");
            EntidadBaseConfiguracionBD<PlanSuscripcion>.SetEntityBuilder(modelBuilder);

            modelBuilder.Entity<PlanSuscripcion>().Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<PlanSuscripcion>().Property(e => e.Descripcion).HasMaxLength(1000).IsRequired();

            // Seed de planes para barberos
            var planFree = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000001"),
                Nombre = "Free",
                Descripcion = "Plan gratuito para barberos. Permite mostrar perfil y servicios, pero no recibir reservas.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Free,
                EsParaBarberia = false,
                Precio = 0,
                DuracionDias = 365,
                LimiteBarberosAfiliados = null,
                PermiteRecibirReservas = false,
                PermiteEstadisticasBasicas = false,
                PermiteEstadisticasCompletas = false,
                PermitePostearProductos = false,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            var planPopular = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000002"),
                Nombre = "Popular",
                Descripcion = "Plan popular para barberos. Permite recibir reservas y ver estadísticas básicas.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Popular,
                EsParaBarberia = false,
                Precio = 500,
                DuracionDias = 30,
                LimiteBarberosAfiliados = null,
                PermiteRecibirReservas = true,
                PermiteEstadisticasBasicas = true,
                PermiteEstadisticasCompletas = false,
                PermitePostearProductos = false,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            var planPremium = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000003"),
                Nombre = "Premium",
                Descripcion = "Plan premium para barberos. Incluye todo lo del Popular más venta de productos y estadísticas completas.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Premium,
                EsParaBarberia = false,
                Precio = 1000,
                DuracionDias = 30,
                LimiteBarberosAfiliados = null,
                PermiteRecibirReservas = true,
                PermiteEstadisticasBasicas = true,
                PermiteEstadisticasCompletas = true,
                PermitePostearProductos = true,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            // Seed de planes para barberías
            var planBasico = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000004"),
                Nombre = "Básico",
                Descripcion = "Plan básico para barberías. Hasta 3 barberos afiliados.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Basico,
                EsParaBarberia = true,
                Precio = 1500,
                DuracionDias = 30,
                LimiteBarberosAfiliados = 3,
                PermiteRecibirReservas = true,
                PermiteEstadisticasBasicas = true,
                PermiteEstadisticasCompletas = false,
                PermitePostearProductos = false,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            var planEstandar = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000005"),
                Nombre = "Estándar",
                Descripcion = "Plan estándar para barberías. Hasta 10 barberos afiliados y estadísticas completas.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Estandar,
                EsParaBarberia = true,
                Precio = 3000,
                DuracionDias = 30,
                LimiteBarberosAfiliados = 10,
                PermiteRecibirReservas = true,
                PermiteEstadisticasBasicas = true,
                PermiteEstadisticasCompletas = true,
                PermitePostearProductos = false,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            var planEnterprise = new PlanSuscripcion
            {
                Id = new Guid("B0000000-0000-0000-0000-000000000006"),
                Nombre = "Enterprise",
                Descripcion = "Plan enterprise para barberías. Barberos ilimitados y todas las características.",
                TipoPlan = Enum.Multibarbero.TipoPlan.Enterprise,
                EsParaBarberia = true,
                Precio = 5000,
                DuracionDias = 30,
                LimiteBarberosAfiliados = null,
                PermiteRecibirReservas = true,
                PermiteEstadisticasBasicas = true,
                PermiteEstadisticasCompletas = true,
                PermitePostearProductos = true,
                PermiteModificarDatos = true,
                PermiteMostrarServicios = true,
                Activo = true
            };

            modelBuilder.Entity<PlanSuscripcion>().HasData(planFree, planPopular, planPremium, planBasico, planEstandar, planEnterprise);
        }
    }
}
