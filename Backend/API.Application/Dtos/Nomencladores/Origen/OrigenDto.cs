using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Nomencladores.Origen
{
    public class OrigenDto : EntidadBaseDto
    {
        public string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public char Tipo { get; set; }

        public Guid CategoriaId { get; set; }
        public bool Reservado { get; set; }
        public bool Activo { get; set; }

    }
}
