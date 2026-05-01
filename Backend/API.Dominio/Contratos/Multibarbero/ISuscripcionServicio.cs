using API.Dominio.Entidades.Multibarbero;

namespace API.Dominio.Contratos.Multibarbero
{
    public interface ISuscripcionServicio
    {
        // Admin: Crear planes de suscripción
        Task<PlanSuscripcion> CrearPlanSuscripcionAsync(CrearPlanSuscripcionDto dto);
        Task<PlanSuscripcion> ActualizarPlanSuscripcionAsync(int planId, ActualizarPlanSuscripcionDto dto);
        Task<IEnumerable<PlanSuscripcion>> ObtenerTodosLosPlanesAsync();
        Task<PlanSuscripcion?> ObtenerPlanPorIdAsync(int planId);
        
        // Barbero: Solicitar cambio de suscripción
        Task<SolicitudSuscripcion> SolicitarCambioSuscripcionBarberoAsync(int barberoId, int nuevoPlanId);
        Task<IEnumerable<SolicitudSuscripcion>> ObtenerSolicitudesPendientesBarberoAsync(int barberoId);
        
        // Barbería: Suscribirse a un plan (registro)
        Task<SolicitudSuscripcion> SuscribirseBarberiaAsync(int barberiaId, int planId);
        
        // Admin/Comercial: Aprobar/rechazar solicitudes
        Task<bool> AprobarSolicitudSuscripcionAsync(int solicitudId, int usuarioAprobadorId);
        Task<bool> RechazarSolicitudSuscripcionAsync(int solicitudId, int usuarioAprobadorId, string motivo);
        Task<IEnumerable<SolicitudSuscripcion>> ObtenerSolicitudesPendientesAsync();
        
        // Validaciones
        Task<bool> TieneSuscripcionActivaBarberoAsync(int barberoId);
        Task<bool> TieneSuscripcionActivaBarberiaAsync(int barberiaId);
        Task<bool> PuedeCambiarDePlanAsync(int entidadId, bool esBarbero);
        
        // Jobs programados: Verificar vencimientos
        Task<int> VerificarSuscripcionesVencidasAsync();
        Task<int> VerificarSuscripcionesPorVencerAsync(int dias = 7);
    }

    public class CrearPlanSuscripcionDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public TipoPlan TipoPlan { get; set; }
        public bool EsParaBarbero { get; set; } // true para barberos, false para barberías
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public int? MaximoBarberosAfiliados { get; set; } // Solo para barberías
        public List<string> Caracteristicas { get; set; } = new();
        public bool Activo { get; set; } = true;
    }

    public class ActualizarPlanSuscripcionDto
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? DuracionDias { get; set; }
        public int? MaximoBarberosAfiliados { get; set; }
        public List<string>? Caracteristicas { get; set; }
        public bool? Activo { get; set; }
    }
}
