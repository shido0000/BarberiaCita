using API.Application.Dtos.Comunes;
using API.Data.Enum.Nomencladores;

namespace API.Application.Dtos.Nomencladores.Grupo
{
    public class GrupoDto : EntidadBaseDto
    {
        public string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public required TipoDeGrupo TipoDeGrupo { get; set; }

        public required decimal Desgaste { get; set; }
 
        public Guid OrigenId { get; set; }

        public bool Reservado { get; set; }
        public bool Activo { get; set; }
    }
}
