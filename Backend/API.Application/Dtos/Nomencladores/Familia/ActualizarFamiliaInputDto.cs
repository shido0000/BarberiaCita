using System.Text.Json.Serialization;

namespace API.Application.Dtos.Nomencladores.Familia
{
    public class ActualizarFamiliaInputDto : FamiliaDto
    {
        [JsonIgnore]
        public new string Codigo { get; set; }
        [JsonIgnore]
        public new Guid GrupoId { get; set; }
    }
}
