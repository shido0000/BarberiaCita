using System.Text.Json.Serialization;

namespace API.Application.Dtos.Nomencladores.Origen
{
    public class ActualizarOrigenInputDto : OrigenDto
    {
        [JsonIgnore]
        public new string Codigo { get; set; }
        [JsonIgnore]
        public new char Tipo { get; set; }
        [JsonIgnore]
        public new Guid CategoriaId { get; set; }
    }
}
