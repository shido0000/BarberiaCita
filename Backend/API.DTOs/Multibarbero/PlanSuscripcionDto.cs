using System;

namespace API.DTOs.Multibarbero
{
    public class PlanSuscripcionDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public string TipoPeriodo { get; set; } = string.Empty; // Mensual, Anual, etc.
        public int MaxBarberos { get; set; }
        public int MaxReservasDia { get; set; }
        public bool IncluyeNotificaciones { get; set; }
        public bool IncluyeEstadisticas { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CrearPlanSuscripcionDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public string TipoPeriodo { get; set; } = string.Empty;
        public int MaxBarberos { get; set; }
        public int MaxReservasDia { get; set; }
        public bool IncluyeNotificaciones { get; set; } = true;
        public bool IncluyeEstadisticas { get; set; } = true;
        public bool Activo { get; set; } = true;
    }

    public class ActualizarPlanSuscripcionDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public string TipoPeriodo { get; set; } = string.Empty;
        public int MaxBarberos { get; set; }
        public int MaxReservasDia { get; set; }
        public bool IncluyeNotificaciones { get; set; }
        public bool IncluyeEstadisticas { get; set; }
        public bool Activo { get; set; }
    }
}
