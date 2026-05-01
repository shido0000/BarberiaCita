using System;

namespace API.DTOs.Multibarbero
{
    public class UsuarioBarberiaDto
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal CalificacionPromedio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? PlanSuscripcionId { get; set; }
        public string? PlanSuscripcionNombre { get; set; }
        public DateTime? FechaVencimientoSuscripcion { get; set; }
    }

    public class CrearUsuarioBarberiaDto
    {
        public string NombreComercial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int? PlanSuscripcionId { get; set; }
    }

    public class ActualizarUsuarioBarberiaDto
    {
        public string NombreComercial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int? PlanSuscripcionId { get; set; }
    }
}
