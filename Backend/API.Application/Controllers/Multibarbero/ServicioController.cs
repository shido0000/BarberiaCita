using Microsoft.AspNetCore.Mvc;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Servicio;
using API.Application.Dtos.Comunes;

namespace API.Application.Controllers.Multibarbero
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : BasicController
    {
        private readonly IServicioService _service;

        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ListadoPaginadoDto<ServicioDto>>> ObtenerListadoPaginado(
            [FromQuery] FiltrarConfigurarListadoPaginadoServicioInputDto filtro)
        {
            var resultado = await _service.ObtenerListadoPaginado(filtro);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioDto>> ObtenerPorId(Guid id)
        {
            var resultado = await _service.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<ServicioDto>> Crear([FromBody] CrearServicioInputDto dto)
        {
            var resultado = await _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServicioDto>> Actualizar(Guid id, [FromBody] ActualizarServicioInputDto dto)
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
