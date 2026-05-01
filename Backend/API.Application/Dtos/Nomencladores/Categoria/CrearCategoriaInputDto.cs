using System.Text.Json.Serialization;

namespace API.Application.Dtos.Nomencladores.Categoria
{
    public class CrearCategoriaInputDto : CategoriaDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
        [JsonIgnore]
        public new bool Reservado { get; set; }
        [JsonIgnore]
        public new bool Activo { get; set; }
    }
}
