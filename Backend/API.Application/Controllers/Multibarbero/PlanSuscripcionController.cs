using Microsoft.AspNetCore.Mvc;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.PlanSuscripcion;
using API.Application.Dtos.Comunes;

namespace API.Application.Controllers.Multibarbero
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanSuscripcionController : BasicController
    {
        private readonly IPlanSuscripcionService _service;

        public PlanSuscripcionController(IPlanSuscripcionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ListadoPaginadoDto<PlanSuscripcionDto>>> ObtenerListadoPaginado(
            [FromQuery] FiltrarConfigurarListadoPaginadoPlanSuscripcionInputDto filtro)
        {
            var resultado = await _service.ObtenerListadoPaginado(filtro);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesPlanSuscripcionDto>> ObtenerPorId(Guid id)
        {
            var resultado = await _service.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<PlanSuscripcionDto>> Crear([FromBody] CrearPlanSuscripcionInputDto dto)
        {
            var resultado = await _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlanSuscripcionDto>> Actualizar(Guid id, [FromBody] ActualizarPlanSuscripcionInputDto dto)
        {
            dto.Id = id;
            var resultado = await _service.Actualizar(dto);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            await _service.Eliminar(id);
            return NoContent();
        }
    }
}
