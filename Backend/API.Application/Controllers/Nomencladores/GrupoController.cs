using API.Application.Dtos.Nomencladores.Grupo;
using API.Data.Entidades.Nomencladores;
using API.Domain.Interfaces.Nomencladores;
using API.Domain.Validators.Nomencladores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace API.Application.Controllers.Nomencladores
{
    public class GrupoController : BasicController<Grupo, GrupoValidator, DetallesGrupoDto, CrearGrupoInputDto, ActualizarGrupoInputDto, ListadoPaginadoGrupoDto, FiltrarConfigurarListadoPaginadoGrupoIntputDto>
    {

        public GrupoController(IMapper mapper, IGrupoService servicioGrupo) : base(mapper, servicioGrupo)
        {
        }

        protected override Task<(IEnumerable<Grupo>, int)> AplicarFiltrosIncluirPropiedades(FiltrarConfigurarListadoPaginadoGrupoIntputDto inputDto)
        {
            //agregando filtros
            List<Expression<Func<Grupo, bool>>> filtros = new();
            if (!string.IsNullOrEmpty(inputDto.TextoBuscar))
            {
                filtros.Add(grupo => grupo.Codigo.Contains(inputDto.TextoBuscar) ||
                                       grupo.Descripcion.Contains(inputDto.TextoBuscar) ||
                                       grupo.Desgaste.ToString().Contains(inputDto.TextoBuscar) ||

                                       grupo.Origen.Codigo.Contains(inputDto.TextoBuscar) ||
                                       grupo.Origen.Descripcion.Contains(inputDto.TextoBuscar));
            }

            //IIncludableQueryable<Usuario, object> propiedadesIncluidas(IQueryable<Usuario> query) => query.Include(e => e.ShipmentItems);
            IIncludableQueryable<Grupo, object> propiedadesIncluidas(IQueryable<Grupo> query) => query.Include(e => e.Origen);

            return _servicioBase.ObtenerListadoPaginado(inputDto.CantidadIgnorar, inputDto.CantidadMostrar, inputDto.SecuenciaOrdenamiento, propiedadesIncluidas, filtros.ToArray());
        }

        protected override async Task<Grupo?> ObtenerElementoPorId(Guid id)
        {
            return await _servicioBase.ObtenerPorId(id, propiedadesIncluidas: query => query.Include(e => e.Origen));
        }

        

    }
}
