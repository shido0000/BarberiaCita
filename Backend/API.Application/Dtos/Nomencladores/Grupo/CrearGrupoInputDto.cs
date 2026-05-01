using System.Text.Json.Serialization;

namespace API.Application.Dtos.Nomencladores.Grupo
{
    public class CrearGrupoInputDto : GrupoDto
    {
        [JsonIgnore]
        public new Guid Id { get; set; }
        [JsonIgnore]
        public new bool Reservado { get; set; }
        [JsonIgnore]
        public new bool Activo { get; set; }
      
    }
}
