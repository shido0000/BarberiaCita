namespace API.Application.Dtos.Multibarbero.Servicio
{
    public class CrearServicioInputDto
    {
        public Guid? UsuarioBarberoId { get; set; }
        public Guid? UsuarioBarberiaId { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required decimal Precio { get; set; }
        public int DuracionMinutos { get; set; } = 30;
        public int Orden { get; set; } = 0;
        public string? Imagen { get; set; }
        public string? Categoria { get; set; }
    }
}
