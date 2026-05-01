using Microsoft.AspNetCore.Mvc;
using API.Domain.Interfaces.Servicios.Multibarbero;
using API.Application.Dtos.Multibarbero.Notificacion;
using API.Application.Dtos.Comunes;

namespace API.Application.Controllers.Multibarbero
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : BasicController
    {
        private readonly INotificacionService _service;

        public NotificacionController(INotificacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ListadoPaginadoDto<NotificacionDto>>> ObtenerListadoPaginado(
            [FromQuery] FiltrarConfigurarListadoPaginadoNotificacionInputDto filtro)
        {
            var resultado = await _service.ObtenerListadoPaginado(filtro);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificacionDto>> ObtenerPorId(Guid id)
        {
            var resultado = await _service.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<NotificacionDto>> Crear([FromBody] CrearNotificacionInputDto dto)
        {
            var resultado = await _service.Crear(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Id }, resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NotificacionDto>> Actualizar(Guid id, [FromBody] ActualizarNotificacionInputDto dto)
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
