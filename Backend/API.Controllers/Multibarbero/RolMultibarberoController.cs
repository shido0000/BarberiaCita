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
    public class RolMultibarberoController : ControllerBase
    {
        private readonly IRolMultibarberoServicio _rolServicio;
        private readonly IMapper _mapper;
        private readonly ILogger<RolMultibarberoController> _logger;

        public RolMultibarberoController(
            IRolMultibarberoServicio rolServicio,
            IMapper mapper,
            ILogger<RolMultibarberoController> logger)
        {
            _rolServicio = rolServicio;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los roles multibarbero con paginación
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RolMultibarberoDto>>> ObtenerTodos([FromQuery] int pagina = 1, [FromQuery] int registrosPorPagina = 10)
        {
            try
            {
                var resultado = await _rolServicio.ObtenerTodosAsync(pagina, registrosPorPagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener roles multibarbero");
                return StatusCode(500, "Error interno al obtener los roles");
            }
        }

        /// <summary>
        /// Obtiene un rol multibarbero por su ID
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<RolMultibarberoDto>> ObtenerPorId(int id)
        {
            try
            {
                var rol = await _rolServicio.ObtenerPorIdAsync(id);
                if (rol == null)
                    return NotFound($"No se encontró el rol con ID {id}");

                return Ok(_mapper.Map<RolMultibarberoDto>(rol));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rol multibarbero con ID {Id}", id);
                return StatusCode(500, "Error interno al obtener el rol");
            }
        }

        /// <summary>
        /// Crea un nuevo rol multibarbero
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RolMultibarberoDto>> Crear([FromBody] CrearRolMultibarberoDto dto)
        {
            try
            {
                var rol = _mapper.Map<API.Data.Entidades.Multibarbero.RolMultibarbero>(dto);
                var rolCreado = await _rolServicio.CrearAsync(rol);
                
                _logger.LogInformation("Rol multibarbero creado exitosamente con ID {Id}", rolCreado.Id);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = rolCreado.Id }, _mapper.Map<RolMultibarberoDto>(rolCreado));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear rol multibarbero");
                return StatusCode(500, "Error interno al crear el rol");
            }
        }

        /// <summary>
        /// Actualiza un rol multibarbero existente
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarRolMultibarberoDto dto)
        {
            try
            {
                var rolExistente = await _rolServicio.ObtenerPorIdAsync(id);
                if (rolExistente == null)
                    return NotFound($"No se encontró el rol con ID {id}");

                _mapper.Map(dto, rolExistente);
                await _rolServicio.ActualizarAsync(rolExistente);

                _logger.LogInformation("Rol multibarbero actualizado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar rol multibarbero con ID {Id}", id);
                return StatusCode(500, "Error interno al actualizar el rol");
            }
        }

        /// <summary>
        /// Elimina un rol multibarbero
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var rol = await _rolServicio.ObtenerPorIdAsync(id);
                if (rol == null)
                    return NotFound($"No se encontró el rol con ID {id}");

                await _rolServicio.EliminarAsync(id);

                _logger.LogInformation("Rol multibarbero eliminado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar rol multibarbero con ID {Id}", id);
                return StatusCode(500, "Error interno al eliminar el rol");
            }
        }
    }
}
