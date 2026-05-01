using API.Data.Entidades.Multibarbero;

namespace API.Data.IUnitOfWorks.Interfaces.Multibarbero
{
    public interface IPlanSuscripcionRepository : IBaseRepository<PlanSuscripcion>
    {
        Task<List<PlanSuscripcion>> ObtenerPlanesPorTipoAsync(TipoPlan tipoPlan);
        Task<PlanSuscripcion?> ObtenerPlanPorNombreAsync(string nombre);
        Task<List<PlanSuscripcion>> ObtenerPlanesActivosAsync();
    }
}
