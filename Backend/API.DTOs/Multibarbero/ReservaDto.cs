using System;

namespace API.DTOs.Multibarbero
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; }
        public string Estado { get; set; } = string.Empty; // Pendiente, Confirmada, Cancelada, Completada
        public decimal PrecioTotal { get; set; }
        public string Notas { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public int? BarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public int? BarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
        public int? ServicioId { get; set; }
        public string? ServicioNombre { get; set; }
    }

    public class CrearReservaDto
    {
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Notas { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public int? BarberoId { get; set; }
        public int? BarberiaId { get; set; }
        public int? ServicioId { get; set; }
    }

    public class ActualizarReservaDto
    {
        public DateTime FechaHora { get; set; }
        public int DuracionMinutos { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal PrecioTotal { get; set; }
        public string Notas { get; set; } = string.Empty;
        public int? BarberoId { get; set; }
        public int? BarberiaId { get; set; }
        public int? ServicioId { get; set; }
    }

    public class CancelarReservaDto
    {
        public string MotivoCancelacion { get; set; } = string.Empty;
    }
}
