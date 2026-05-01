namespace API.Application.Dtos.Multibarbero.Reserva
{
    public class CrearReservaInputDto
    {
        public required Guid UsuarioClienteId { get; set; }
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public required Guid ServicioId { get; set; }
        public required DateTime FechaInicio { get; set; }
        public string? NotasCliente { get; set; }
    }
}
