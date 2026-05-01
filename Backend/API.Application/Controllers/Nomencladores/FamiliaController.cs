using API.Application.Dtos.Nomencladores.Familia;
using API.Data.Entidades.Nomencladores;
using API.Domain.Interfaces.Nomencladores;
using API.Domain.Validators.Nomencladores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API.Application.Controllers.Nomencladores
{
    public class FamiliaController : BasicController<Familia, FamiliaValidator, DetallesFamiliaDto, CrearFamiliaInputDto, ActualizarFamiliaInputDto, ListadoPaginadoFamiliaDto, FiltrarConfigurarListadoPaginadoFamiliaIntputDto>
    {

        public FamiliaController(IMapper mapper, IFamiliaService servicioFamilia) : base(mapper, servicioFamilia)
        {
        }

        protected override Task<(IEnumerable<Familia>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoFamiliaIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Familia, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
                filtros.Add(familia => familia.Grupo.Descripcion.Contains(inputDto.TextoBuscar) ||
                familia.Grupo.Codigo.Contains(inputDto.TextoBuscar) ||
                familia.Grupo.Descripcion.Contains(inputDto.TextoBuscar) ||
                familia.Codigo.Contains(inputDto.TextoBuscar) ||
                familia.Descripcion.Contains(inputDto.TextoBuscar));

            //incluyendo propiedades navigacionales
            IIncludableQueryable<Familia, object> propiedadesIncluidas(IQueryable<Familia> query) => query.Include(e => e.Grupo);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas, filtros.ToArray());
        }
        protected override async Task<Familia?> ObtenerElementoPorId(Guid id)
        {
            return await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Grupo));
        }
    }
}
