using API.DTOs.Multibarbero;
using API.Servicios.Interfaces.Multibarbero;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Multibarbero
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioBarberoController : ControllerBase
    {
        private readonly IUsuarioBarberoServicio _barberoServicio;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioBarberoController> _logger;

        public UsuarioBarberoController(
            IUsuarioBarberoServicio barberoServicio,
            IMapper mapper,
            ILogger<UsuarioBarberoController> logger)
        {
            _barberoServicio = barberoServicio;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los barberos con paginación
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioBarberoDto>>> ObtenerTodos([FromQuery] int pagina = 1, [FromQuery] int registrosPorPagina = 10)
        {
            try
            {
                var resultado = await _barberoServicio.ObtenerTodosAsync(pagina, registrosPorPagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener barberos");
                return StatusCode(500, "Error interno al obtener los barberos");
            }
        }

        /// <summary>
        /// Obtiene un barbero por su ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioBarberoDto>> ObtenerPorId(int id)
        {
            try
            {
                var barbero = await _barberoServicio.ObtenerPorIdAsync(id);
                if (barbero == null)
                    return NotFound($"No se encontró el barbero con ID {id}");

                return Ok(_mapper.Map<UsuarioBarberoDto>(barbero));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener barbero con ID {Id}", id);
                return StatusCode(500, "Error interno al obtener el barbero");
            }
        }

        /// <summary>
        /// Crea un nuevo barbero
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Barberia")]
        public async Task<ActionResult<UsuarioBarberoDto>> Crear([FromBody] CrearUsuarioBarberoDto dto)
        {
            try
            {
                var barbero = _mapper.Map<API.Data.Entidades.Multibarbero.UsuarioBarbero>(dto);
                var barberoCreado = await _barberoServicio.CrearAsync(barbero);
                
                _logger.LogInformation("Barbero creado exitosamente con ID {Id}", barberoCreado.Id);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = barberoCreado.Id }, _mapper.Map<UsuarioBarberoDto>(barberoCreado));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear barbero");
                return StatusCode(500, "Error interno al crear el barbero");
            }
        }

        /// <summary>
        /// Actualiza un barbero existente
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Barberia,Barbero")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarUsuarioBarberoDto dto)
        {
            try
            {
                var barberoExistente = await _barberoServicio.ObtenerPorIdAsync(id);
                if (barberoExistente == null)
                    return NotFound($"No se encontró el barbero con ID {id}");

                _mapper.Map(dto, barberoExistente);
                await _barberoServicio.ActualizarAsync(barberoExistente);

                _logger.LogInformation("Barbero actualizado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar barbero con ID {Id}", id);
                return StatusCode(500, "Error interno al actualizar el barbero");
            }
        }

        /// <summary>
        /// Elimina un barbero
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Barberia")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var barbero = await _barberoServicio.ObtenerPorIdAsync(id);
                if (barbero == null)
                    return NotFound($"No se encontró el barbero con ID {id}");

                await _barberoServicio.EliminarAsync(id);

                _logger.LogInformation("Barbero eliminado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar barbero con ID {Id}", id);
                return StatusCode(500, "Error interno al eliminar el barbero");
            }
        }
    }
}
