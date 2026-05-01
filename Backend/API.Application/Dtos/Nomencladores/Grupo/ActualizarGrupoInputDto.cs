using System.Text.Json.Serialization;
namespace API.Application.Dtos.Nomencladores.Grupo
{
    public class ActualizarGrupoInputDto : GrupoDto
    {
        [JsonIgnore]
        public new string Codigo { get; set; }
        [JsonIgnore]
        public Guid OrigenId { get; set; }

    }
}
