using Business.Implements;
using Entity.Dtos.PizzaDto;
using Entity.Dtos.PlayersDto;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;
using WebApplication1.Controllers.Interface;

namespace WebApplication1.Controllers.Implements
{
    [Route("api/[controller]")]
    public class PlayersController : GenericController<PlayersDto, Players>, IPlayersController
    {
        private readonly PlayerBusiness _playersBusiness;

        public PlayersController(PlayerBusiness playersBusiness, ILogger<PlayersController> logger)
            : base(playersBusiness, logger)
        {
            _playersBusiness = playersBusiness;
        }

        protected override int GetEntityId(PlayersDto dto)
        {
            return dto.Id;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePartialPlayers(int id, [FromBody] UpdatePlayersDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _playersBusiness.UpdatePartialPlayerAsync(dto);
                return Ok(new { Success = result });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al actualizar parcialmente Player: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar parcialmente Player: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogicPlayers(int id)
        {
            try
            {
                var dto = new DeleteLogicPlayersDto { Id = id, Status = false };
                var result = await _playersBusiness.DeleteLogicPlayerAsync(dto);
                if (!result)
                    return NotFound($"Jugador con ID {id} no encontrado");
                return Ok(new { Success = true });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Error de validación al eliminar lógicamente Player: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar lógicamente Player: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
