using API.Application.Dtos.Nomencladores.Familia;
using API.Application.Dtos.Nomencladores.Grupo;
using API.Data.Entidades.Nomencladores;

namespace API.Application.Mapper.Nomencladores
{
    public class GrupoDtoProfile : BaseProfile<Grupo, GrupoDto, CrearGrupoInputDto, ActualizarGrupoInputDto, ListadoPaginadoGrupoDto>
    {
        public GrupoDtoProfile()
        {
            //MapGrupoDto();
            MapDetallesGrupoDto();
        }

        /*public void MapGrupoDto()
        {
            CreateMap<Grupo, DetallesGrupoDto > ()
                .ReverseMap();
        }*/

        public void MapDetallesGrupoDto()
        {
            CreateMap<Grupo, DetallesGrupoDto>()
            .ForMember(dto => dto.OrigenDescripcion, opt => opt.MapFrom(e => e.Origen.Descripcion));
        }

        
    }
}


