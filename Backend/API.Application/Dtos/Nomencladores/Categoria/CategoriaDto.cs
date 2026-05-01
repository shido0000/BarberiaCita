using API.Application.Dtos.Comunes;
using API.Data.Enum.Nomencladores;

namespace API.Application.Dtos.Nomencladores.Categoria
{
    public class CategoriaDto : EntidadBaseDto
    {
        public required string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public required TipoDeCodigo TipoDeCodigo { get; set; }

        public bool Reservado { get; set; }
        public bool Activo { get; set; }
    }
}
