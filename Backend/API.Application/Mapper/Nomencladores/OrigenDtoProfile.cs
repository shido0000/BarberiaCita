using API.Application.Dtos.Nomencladores.Familia;
using API.Application.Dtos.Nomencladores.Origen;
using API.Data.Entidades.Nomencladores;

namespace API.Application.Mapper.Nomencladores
{
    public class OrigenDtoProfile : BaseProfile<Origen, OrigenDto, CrearOrigenInputDto, ActualizarOrigenInputDto, ListadoPaginadoOrigenDto>
    {
        public OrigenDtoProfile()
        {
            //  MapOrigenDto();
            MapDetallesOrigenDto();
        }

        /*public void MapOrigenDto()
        {
            CreateMap<Origen, DetallesOrigenDto>()
                .ReverseMap();
        }*/

        public void MapDetallesOrigenDto()
        {
            CreateMap<Origen, DetallesOrigenDto>()
            .ForMember(dto => dto.CategoriaDescripcion, opt => opt.MapFrom(e => e.Categoria.Descripcion));
        }
    }
}


