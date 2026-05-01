
using API.Application.Dtos.Nomencladores.Familia;
using API.Data.Entidades.Nomencladores;

namespace API.Application.Mapper.Nomencladores
{
    public class FamiliaDtoProfile : BaseProfile<Familia, FamiliaDto, CrearFamiliaInputDto, ActualizarFamiliaInputDto, ListadoPaginadoFamiliaDto>
    {
        public FamiliaDtoProfile()
        {
            MapDetallesFamiliaDto();
        }

        public void MapDetallesFamiliaDto()
        {
            CreateMap<Familia, DetallesFamiliaDto>()
            .ForMember(dto => dto.GrupoDescripcion, opt => opt.MapFrom(e => e.Grupo.Descripcion));
        }



    }
}


