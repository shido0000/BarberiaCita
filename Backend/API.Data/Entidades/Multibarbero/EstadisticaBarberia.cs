using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las estadísticas de barberías
    /// </summary>
    public class EstadisticaBarberia : EntidadBase
    {
        // Barbería a la que pertenecen las estadísticas
        public required Guid UsuarioBarberiaId { get; set; }
        public UsuarioBarberia UsuarioBarberia { get; set; } = null!;
        
        // Período de las estadísticas
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
        // Métricas básicas
        public int TotalReservas { get; set; }
        public int ReservasConfirmadas { get; set; }
        public int ReservasCanceladas { get; set; }
        public int ReservasCompletadas { get; set; }
        public int TotalClientesAtendidos { get; set; }
        public int ClientesNuevos { get; set; }
        public int ClientesRecurrentes { get; set; }
        
        // Métricas de barberos afiliados
        public int TotalBarberosAfiliados { get; set; }
        public int BarberosActivos { get; set; }
        public int NuevasAfiliaciones { get; set; }
        
        // Métricas financieras
        public decimal IngresosTotales { get; set; }
        public decimal IngresosPromedioPorReserva { get; set; }
        
        // Métricas de servicios
        public int ServicioMasSolicitadoId { get; set; }
        public string? ServicioMasSolicitadoNombre { get; set; }
        
        // Calificación promedio
        public double CalificacionPromedio { get; set; } = 0.0;
        public int TotalCalificaciones { get; set; }
        
        // Ocupación promedio (porcentaje)
        public double OcupacionPromedio { get; set; } = 0.0;
        
        // Fecha de generación del reporte
        public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;
    }
}
