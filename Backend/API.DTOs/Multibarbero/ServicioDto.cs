using System;

namespace API.DTOs.Multibarbero
{
    public class ServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? BarberoId { get; set; }
        public string? BarberoNombre { get; set; }
        public int? BarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
    }

    public class CrearServicioDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public int? BarberoId { get; set; }
        public int? BarberiaId { get; set; }
    }

    public class ActualizarServicioDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int? BarberoId { get; set; }
        public int? BarberiaId { get; set; }
    }
}
