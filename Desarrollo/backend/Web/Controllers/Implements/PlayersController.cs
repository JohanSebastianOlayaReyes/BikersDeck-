using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Entity.Dtos.PizzaDto;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerBusiness _playerBusiness;
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(IPlayerBusiness playerBusiness, ILogger<PlayersController> logger)
        {
            _playerBusiness = playerBusiness;
            _logger = logger;
        }

        [HttpPost("crear-sala")]
        public IActionResult CrearSala([FromQuery] int cantidad)
        {
            var salaId = _playerBusiness.Quantity(cantidad);
            return Ok(new { SalaId = salaId });
        }

        [HttpPost("registrar-jugador")]
        public IActionResult RegistrarJugador([FromQuery] int playersId, [FromQuery] string namePlayers)
        {
            try
            {
                _playerBusiness.RegisterPlayers(playersId, namePlayers);
                return Ok(new { Mensaje = "Jugador registrado correctamente." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar jugador");
                return StatusCode(500, new { Error = "Error interno del servidor" });
            }
        }

        [HttpGet("jugadores/{playersId}")]
        public IActionResult ObtenerJugadores(int playersId)
        {
            var jugadores = _playerBusiness.GetPlayers(playersId);
            return Ok(jugadores);
        }

        [HttpGet("faltantes/{playersId}")]
        public IActionResult ObtenerCantidadRestante(int playersId)
        {
            var faltantes = _playerBusiness.GetQuantity(playersId);
            return Ok(new { Faltantes = faltantes });
        }

        [HttpPatch("actualizar/{id}")]
        public async Task<IActionResult> UpdatePartialPlayers(int id, [FromBody] UpdatePlayersDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                dto.Id = id;
                var result = await _playerBusiness.UpdatePartialPlayerAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar jugador");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPatch("eliminar-logico/{id}")]
        public async Task<IActionResult> DeleteLogicPlayers(int id)
        {
            try
            {
                var dto = new DeleteLogicPlayersDto { Id = id, Status = false };
                var result = await _playerBusiness.DeleteLogicPlayerAsync(dto);
                if (!result)
                    return NotFound($"Jugador con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar lógicamente jugador");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}