using System;

namespace API.DTOs.Multibarbero
{
    public class UsuarioBarberoDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? BarberiaId { get; set; }
        public string? BarberiaNombre { get; set; }
    }

    public class CrearUsuarioBarberoDto
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public int? BarberiaId { get; set; }
    }

    public class ActualizarUsuarioBarberoDto
    {
        public string NombreCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }
        public bool Activo { get; set; }
        public int? BarberiaId { get; set; }
    }
}
