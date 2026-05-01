using API.Application.Dtos.Nomencladores.Grupo;

namespace API.Application.Dtos.Nomencladores.Grupo
{
    public class DetallesGrupoDto : GrupoDto
    {
        public required string OrigenDescripcion { get; set; }
    }
}
