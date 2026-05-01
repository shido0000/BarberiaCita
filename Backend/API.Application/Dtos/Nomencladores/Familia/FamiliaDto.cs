using API.Application.Dtos.Comunes;

namespace API.Application.Dtos.Nomencladores.Familia
{
    public class FamiliaDto : EntidadBaseDto
    {
        public string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public required string TipoDeCodigo { get; set; }

        public Guid GrupoId { get; set; }

        public bool Reservado { get; set; }
        public bool Activo { get; set; }
    }
}
