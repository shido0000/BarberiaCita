using API.Application.Dtos.Nomencladores.Categoria;
using API.Application.Dtos.Seguridad.Usuario;
using API.Data.Entidades.Nomencladores;
using API.Data.Entidades.Seguridad;
using API.Domain.Interfaces.Nomencladores;
using API.Domain.Validators.Nomencladores;
using AutoMapper;
using System.Linq.Expressions;

namespace API.Application.Controllers.Nomencladores
{
    public class CategoriaController : BasicController<Categoria, CategoriaValidator, DetallesCategoriaDto, CrearCategoriaInputDto, ActualizarCategoriaInputDto, ListadoPaginadoCategoriaDto, FiltrarConfigurarListadoPaginadoCategoriaIntputDto>
    {

        public CategoriaController(IMapper mapper, ICategoriaService servicioCategoria) : base(mapper, servicioCategoria)
        {
        }

        protected override Task<(IEnumerable<Categoria>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoCategoriaIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Categoria, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(categoria => categoria.Codigo.Contains(inputDto.TextoBuscar) ||
                                       categoria.Descripcion.Contains(inputDto.TextoBuscar) ||
                                       categoria.TipoDeCodigo.ToString().Contains(inputDto.TextoBuscar));
            }

            //IIncludableQueryable<Usuario, object> propiedadesIncluidas(IQueryable<Usuario> query) => query.Include(e => e.ShipmentItems);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, null, filtros.ToArray());
        }

    }
}
