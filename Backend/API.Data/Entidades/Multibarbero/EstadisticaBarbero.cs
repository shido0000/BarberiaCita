using API.Data.Entidades.Seguridad;

namespace API.Data.Entidades.Multibarbero
{
    /// <summary>
    /// Tabla que guarda las estadísticas de barberos
    /// </summary>
    public class EstadisticaBarbero : EntidadBase
    {
        // Barbero al que pertenecen las estadísticas
        public required Guid UsuarioBarberoId { get; set; }
        public UsuarioBarbero UsuarioBarbero { get; set; } = null!;
        
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
        
        // Métricas financieras
        public decimal IngresosTotales { get; set; }
        public decimal IngresosPromedioPorReserva { get; set; }
        
        // Métricas de servicios
        public int ServicioMasSolicitadoId { get; set; }
        public string? ServicioMasSolicitadoNombre { get; set; }
        
        // Métricas de productos (solo Premium)
        public int ProductosVendidos { get; set; }
        public decimal IngresosPorProductos { get; set; }
        
        // Calificación promedio
        public double CalificacionPromedio { get; set; } = 0.0;
        public int TotalCalificaciones { get; set; }
        
        // Fecha de generación del reporte
        public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;
    }
}
