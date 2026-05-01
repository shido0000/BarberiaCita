using API.Application.Dtos.Nomencladores.Origen;
using API.Data.Entidades.Nomencladores;
using API.Domain.Interfaces.Nomencladores;
using API.Domain.Validators.Nomencladores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API.Application.Controllers.Nomencladores
{
    public class OrigenController : BasicController<Origen, OrigenValidator, DetallesOrigenDto, CrearOrigenInputDto, ActualizarOrigenInputDto, ListadoPaginadoOrigenDto, FiltrarConfigurarListadoPaginadoOrigenIntputDto>
    {

        public OrigenController(IMapper mapper, IOrigenService servicioOrigen) : base(mapper, servicioOrigen)
        {
        }

        protected override Task<(IEnumerable<Origen>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoOrigenIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Origen, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(origen => origen.Codigo.Contains(inputDto.TextoBuscar) ||
                                       origen.Descripcion.Contains(inputDto.TextoBuscar) ||
                                       origen.Tipo.ToString().Contains(inputDto.TextoBuscar) ||
                                       origen.Categoria.Codigo.Contains(inputDto.TextoBuscar) ||
                                       origen.Categoria.Descripcion.Contains(inputDto.TextoBuscar));
            }

            IIncludableQueryable<Origen, object> propiedadesIncluidas(IQueryable<Origen> query) => query.Include(e => e.Categoria);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas, filtros.ToArray());
        }

        protected override async Task<Origen?> ObtenerElementoPorId(Guid id)
        {
            return await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Categoria));
        }
    }
}
