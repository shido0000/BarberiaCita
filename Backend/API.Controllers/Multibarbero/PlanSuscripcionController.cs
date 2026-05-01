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
    public class PlanSuscripcionController : ControllerBase
    {
        private readonly IPlanSuscripcionServicio _planServicio;
        private readonly IMapper _mapper;
        private readonly ILogger<PlanSuscripcionController> _logger;

        public PlanSuscripcionController(
            IPlanSuscripcionServicio planServicio,
            IMapper mapper,
            ILogger<PlanSuscripcionController> logger)
        {
            _planServicio = planServicio;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los planes de suscripción con paginación
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PlanSuscripcionDto>>> ObtenerTodos([FromQuery] int pagina = 1, [FromQuery] int registrosPorPagina = 10)
        {
            try
            {
                var resultado = await _planServicio.ObtenerTodosAsync(pagina, registrosPorPagina);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener planes de suscripción");
                return StatusCode(500, "Error interno al obtener los planes");
            }
        }

        /// <summary>
        /// Obtiene un plan de suscripción por su ID
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<PlanSuscripcionDto>> ObtenerPorId(int id)
        {
            try
            {
                var plan = await _planServicio.ObtenerPorIdAsync(id);
                if (plan == null)
                    return NotFound($"No se encontró el plan con ID {id}");

                return Ok(_mapper.Map<PlanSuscripcionDto>(plan));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener plan de suscripción con ID {Id}", id);
                return StatusCode(500, "Error interno al obtener el plan");
            }
        }

        /// <summary>
        /// Crea un nuevo plan de suscripción
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PlanSuscripcionDto>> Crear([FromBody] CrearPlanSuscripcionDto dto)
        {
            try
            {
                var plan = _mapper.Map<API.Data.Entidades.Multibarbero.PlanSuscripcion>(dto);
                var planCreado = await _planServicio.CrearAsync(plan);
                
                _logger.LogInformation("Plan de suscripción creado exitosamente con ID {Id}", planCreado.Id);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = planCreado.Id }, _mapper.Map<PlanSuscripcionDto>(planCreado));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear plan de suscripción");
                return StatusCode(500, "Error interno al crear el plan");
            }
        }

        /// <summary>
        /// Actualiza un plan de suscripción existente
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ActualizarPlanSuscripcionDto dto)
        {
            try
            {
                var planExistente = await _planServicio.ObtenerPorIdAsync(id);
                if (planExistente == null)
                    return NotFound($"No se encontró el plan con ID {id}");

                _mapper.Map(dto, planExistente);
                await _planServicio.ActualizarAsync(planExistente);

                _logger.LogInformation("Plan de suscripción actualizado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar plan de suscripción con ID {Id}", id);
                return StatusCode(500, "Error interno al actualizar el plan");
            }
        }

        /// <summary>
        /// Elimina un plan de suscripción
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var plan = await _planServicio.ObtenerPorIdAsync(id);
                if (plan == null)
                    return NotFound($"No se encontró el plan con ID {id}");

                await _planServicio.EliminarAsync(id);

                _logger.LogInformation("Plan de suscripción eliminado exitosamente con ID {Id}", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar plan de suscripción con ID {Id}", id);
                return StatusCode(500, "Error interno al eliminar el plan");
            }
        }
    }
}
