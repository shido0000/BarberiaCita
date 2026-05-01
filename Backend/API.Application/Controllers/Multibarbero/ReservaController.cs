using Microsoft.AspNetCore.Mvc;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Reserva;
using API.Application.Dtos.Comunes;

namespace API.Application.Controllers.Multibarbero
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : BasicController
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ListadoPaginadoDto<ReservaDto>>> ObtenerListadoPaginado(
            [FromQuery] FiltrarConfigurarListadoPaginadoReservaInputDto filtro)
        {
            var resultado = await _service.ObtenerListadoPaginado(filtro);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaDto>> ObtenerPorId(Guid id)
        {
            var resultado = await _service.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<ReservaDto>> Crear([FromBody] CrearReservaInputDto dto)
        {
            var resultado = await _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservaDto>> Actualizar(Guid id, [FromBody] ActualizarReservaInputDto dto)
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
