using API.Application.Dtos.Nomencladores.Categoria;
using API.Data.Entidades.Nomencladores;

namespace API.Application.Mapper.Nomencladores
{
    public class CategoriaDtoProfile : BaseProfile<Categoria, CategoriaDto, CrearCategoriaInputDto, ActualizarCategoriaInputDto, ListadoPaginadoCategoriaDto>
    {
        public CategoriaDtoProfile()
        {
            MapCategoriaDto();
        }

        public void MapCategoriaDto()
        {
            CreateMap<Categoria, DetallesCategoriaDto>()
                .ReverseMap();
        }
    }
}


